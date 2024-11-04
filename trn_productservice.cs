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
   public class trn_productservice : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel12"+"_"+"LOCATIONID") == 0 )
         {
            AV33LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            AssignAttri("", false, "AV33LocationId", AV33LocationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV33LocationId, context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX12ASALOCATIONID0875( AV33LocationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel14"+"_"+"ORGANISATIONID") == 0 )
         {
            AV34OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "AV34OrganisationId", AV34OrganisationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV34OrganisationId, context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX14ASAORGANISATIONID0875( AV34OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_31") == 0 )
         {
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_31( A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
         {
            A42SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_32( A42SupplierGenId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
         {
            A49SupplierAgbId = StringUtil.StrToGuid( GetPar( "SupplierAgbId"));
            n49SupplierAgbId = false;
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_33( A49SupplierAgbId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_productservice.aspx")), "trn_productservice.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_productservice.aspx")))) ;
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
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
                  AssignAttri("", false, "AV12ProductServiceId", AV12ProductServiceId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTSERVICEID", GetSecureSignedToken( "", AV12ProductServiceId, context));
                  AV33LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "AV33LocationId", AV33LocationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV33LocationId, context));
                  AV34OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "AV34OrganisationId", AV34OrganisationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV34OrganisationId, context));
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Product/Service", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProductServiceName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_productservice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_productservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_ProductServiceId ,
                           Guid aP2_LocationId ,
                           Guid aP3_OrganisationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV12ProductServiceId = aP1_ProductServiceId;
         this.AV33LocationId = aP2_LocationId;
         this.AV34OrganisationId = aP3_OrganisationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbProductServiceClass = new GXCombobox();
         cmbProductServiceGroup = new GXCombobox();
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
            return "trn_productservice_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         if ( cmbProductServiceClass.ItemCount > 0 )
         {
            A408ProductServiceClass = cmbProductServiceClass.getValidValue(A408ProductServiceClass);
            AssignAttri("", false, "A408ProductServiceClass", A408ProductServiceClass);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProductServiceClass.CurrentValue = StringUtil.RTrim( A408ProductServiceClass);
            AssignProp("", false, cmbProductServiceClass_Internalname, "Values", cmbProductServiceClass.ToJavascriptSource(), true);
         }
         if ( cmbProductServiceGroup.ItemCount > 0 )
         {
            A366ProductServiceGroup = cmbProductServiceGroup.getValidValue(A366ProductServiceGroup);
            AssignAttri("", false, "A366ProductServiceGroup", A366ProductServiceGroup);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProductServiceGroup.CurrentValue = StringUtil.RTrim( A366ProductServiceGroup);
            AssignProp("", false, cmbProductServiceGroup_Internalname, "Values", cmbProductServiceGroup.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Product/Service", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_ProductService.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceName_Internalname, A59ProductServiceName, StringUtil.RTrim( context.localUtil.Format( A59ProductServiceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceTileName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceTileName_Internalname, context.GetMessage( "Tile Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceTileName_Internalname, StringUtil.RTrim( A301ProductServiceTileName), StringUtil.RTrim( context.localUtil.Format( A301ProductServiceTileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceTileName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceTileName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProductServiceImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Image", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A61ProductServiceImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServiceImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage));
         GxWebStd.gx_bitmap( context, imgProductServiceImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductServiceImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", "", "", 0, A61ProductServiceImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_ProductService.htm");
         AssignProp("", false, imgProductServiceImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage)), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "IsBlob", StringUtil.BoolToStr( A61ProductServiceImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProductServiceClass_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProductServiceClass_Internalname, context.GetMessage( "Group", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProductServiceClass, cmbProductServiceClass_Internalname, StringUtil.RTrim( A408ProductServiceClass), 1, cmbProductServiceClass_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbProductServiceClass.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_Trn_ProductService.htm");
         cmbProductServiceClass.CurrentValue = StringUtil.RTrim( A408ProductServiceClass);
         AssignProp("", false, cmbProductServiceClass_Internalname, "Values", (string)(cmbProductServiceClass.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProductServiceGroup_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProductServiceGroup_Internalname, context.GetMessage( "Supplier", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProductServiceGroup, cmbProductServiceGroup_Internalname, StringUtil.RTrim( A366ProductServiceGroup), 1, cmbProductServiceGroup_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbProductServiceGroup.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_Trn_ProductService.htm");
         cmbProductServiceGroup.CurrentValue = StringUtil.RTrim( A366ProductServiceGroup);
         AssignProp("", false, cmbProductServiceGroup_Internalname, "Values", (string)(cmbProductServiceGroup.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablegen_Internalname, divTablegen_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsuppliergenid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergenid_Internalname, context.GetMessage( "General Supplier", ""), "", "", lblTextblocksuppliergenid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_suppliergenid.SetProperty("Caption", Combo_suppliergenid_Caption);
         ucCombo_suppliergenid.SetProperty("Cls", Combo_suppliergenid_Cls);
         ucCombo_suppliergenid.SetProperty("DataListProc", Combo_suppliergenid_Datalistproc);
         ucCombo_suppliergenid.SetProperty("DataListProcParametersPrefix", Combo_suppliergenid_Datalistprocparametersprefix);
         ucCombo_suppliergenid.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_suppliergenid.SetProperty("DropDownOptionsData", AV21SupplierGenId_Data);
         ucCombo_suppliergenid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenid_Internalname, "COMBO_SUPPLIERGENIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenId_Internalname, context.GetMessage( "Supplier Gen Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenId_Internalname, A42SupplierGenId.ToString(), A42SupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenId_Visible, edtSupplierGenId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductService.htm");
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
         GxWebStd.gx_div_start( context, divTableagb_Internalname, divTableagb_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsupplieragbid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksupplieragbid_Internalname, context.GetMessage( "AGB Supplier", ""), "", "", lblTextblocksupplieragbid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_supplieragbid.SetProperty("Caption", Combo_supplieragbid_Caption);
         ucCombo_supplieragbid.SetProperty("Cls", Combo_supplieragbid_Cls);
         ucCombo_supplieragbid.SetProperty("DataListProc", Combo_supplieragbid_Datalistproc);
         ucCombo_supplieragbid.SetProperty("DataListProcParametersPrefix", Combo_supplieragbid_Datalistprocparametersprefix);
         ucCombo_supplieragbid.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
         ucCombo_supplieragbid.SetProperty("DropDownOptionsData", AV29SupplierAgbId_Data);
         ucCombo_supplieragbid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragbid_Internalname, "COMBO_SUPPLIERAGBIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbId_Internalname, context.GetMessage( "Supplier Agb Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbId_Internalname, A49SupplierAgbId.ToString(), A49SupplierAgbId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierAgbId_Visible, edtSupplierAgbId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductService.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceDescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProductServiceDescription_Internalname, A60ProductServiceDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", 0, 1, edtProductServiceDescription_Enabled, 0, 40, "chr", 5, "row", 0, StyleString, ClassString, "", "", "2097152", 1, 0, "", "", -1, true, "LongDescription", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_ProductService.htm");
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
         context.WriteHtmlText( "</fieldset>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductService.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergenid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergenid_Internalname, AV26ComboSupplierGenId.ToString(), AV26ComboSupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergenid_Visible, edtavCombosuppliergenid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_supplieragbid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosupplieragbid_Internalname, AV30ComboSupplierAgbId.ToString(), AV30ComboSupplierAgbId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosupplieragbid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosupplieragbid_Visible, edtavCombosupplieragbid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, A58ProductServiceId.ToString(), A58ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceId_Visible, edtProductServiceId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductService.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationId_Visible, edtLocationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductService.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ProductService.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11082 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV22DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENID_DATA"), AV21SupplierGenId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERAGBID_DATA"), AV29SupplierAgbId_Data);
               /* Read saved values. */
               Z58ProductServiceId = StringUtil.StrToGuid( cgiGet( "Z58ProductServiceId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z59ProductServiceName = cgiGet( "Z59ProductServiceName");
               Z301ProductServiceTileName = cgiGet( "Z301ProductServiceTileName");
               Z408ProductServiceClass = cgiGet( "Z408ProductServiceClass");
               Z366ProductServiceGroup = cgiGet( "Z366ProductServiceGroup");
               Z42SupplierGenId = StringUtil.StrToGuid( cgiGet( "Z42SupplierGenId"));
               Z49SupplierAgbId = StringUtil.StrToGuid( cgiGet( "Z49SupplierAgbId"));
               n49SupplierAgbId = ((Guid.Empty==A49SupplierAgbId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N42SupplierGenId = StringUtil.StrToGuid( cgiGet( "N42SupplierGenId"));
               N49SupplierAgbId = StringUtil.StrToGuid( cgiGet( "N49SupplierAgbId"));
               n49SupplierAgbId = ((Guid.Empty==A49SupplierAgbId) ? true : false);
               AV12ProductServiceId = StringUtil.StrToGuid( cgiGet( "vPRODUCTSERVICEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV33LocationId = StringUtil.StrToGuid( cgiGet( "vLOCATIONID"));
               AV34OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               AV10Insert_SupplierGenId = StringUtil.StrToGuid( cgiGet( "vINSERT_SUPPLIERGENID"));
               AV9Insert_SupplierAgbId = StringUtil.StrToGuid( cgiGet( "vINSERT_SUPPLIERAGBID"));
               A40000ProductServiceImage_GXI = cgiGet( "PRODUCTSERVICEIMAGE_GXI");
               A44SupplierGenCompanyName = cgiGet( "SUPPLIERGENCOMPANYNAME");
               A51SupplierAgbName = cgiGet( "SUPPLIERAGBNAME");
               AV41Pgmname = cgiGet( "vPGMNAME");
               Combo_suppliergenid_Objectcall = cgiGet( "COMBO_SUPPLIERGENID_Objectcall");
               Combo_suppliergenid_Class = cgiGet( "COMBO_SUPPLIERGENID_Class");
               Combo_suppliergenid_Icontype = cgiGet( "COMBO_SUPPLIERGENID_Icontype");
               Combo_suppliergenid_Icon = cgiGet( "COMBO_SUPPLIERGENID_Icon");
               Combo_suppliergenid_Caption = cgiGet( "COMBO_SUPPLIERGENID_Caption");
               Combo_suppliergenid_Tooltip = cgiGet( "COMBO_SUPPLIERGENID_Tooltip");
               Combo_suppliergenid_Cls = cgiGet( "COMBO_SUPPLIERGENID_Cls");
               Combo_suppliergenid_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENID_Selectedvalue_set");
               Combo_suppliergenid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENID_Selectedvalue_get");
               Combo_suppliergenid_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENID_Selectedtext_set");
               Combo_suppliergenid_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENID_Selectedtext_get");
               Combo_suppliergenid_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENID_Gamoauthtoken");
               Combo_suppliergenid_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENID_Ddointernalname");
               Combo_suppliergenid_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENID_Titlecontrolalign");
               Combo_suppliergenid_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENID_Dropdownoptionstype");
               Combo_suppliergenid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Enabled"));
               Combo_suppliergenid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Visible"));
               Combo_suppliergenid_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENID_Titlecontrolidtoreplace");
               Combo_suppliergenid_Datalisttype = cgiGet( "COMBO_SUPPLIERGENID_Datalisttype");
               Combo_suppliergenid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Allowmultipleselection"));
               Combo_suppliergenid_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENID_Datalistfixedvalues");
               Combo_suppliergenid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Isgriditem"));
               Combo_suppliergenid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Hasdescription"));
               Combo_suppliergenid_Datalistproc = cgiGet( "COMBO_SUPPLIERGENID_Datalistproc");
               Combo_suppliergenid_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENID_Datalistprocparametersprefix");
               Combo_suppliergenid_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENID_Remoteservicesparameters");
               Combo_suppliergenid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_suppliergenid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Includeonlyselectedoption"));
               Combo_suppliergenid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Includeselectalloption"));
               Combo_suppliergenid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Emptyitem"));
               Combo_suppliergenid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENID_Includeaddnewoption"));
               Combo_suppliergenid_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENID_Htmltemplate");
               Combo_suppliergenid_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENID_Multiplevaluestype");
               Combo_suppliergenid_Loadingdata = cgiGet( "COMBO_SUPPLIERGENID_Loadingdata");
               Combo_suppliergenid_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENID_Noresultsfound");
               Combo_suppliergenid_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENID_Emptyitemtext");
               Combo_suppliergenid_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENID_Onlyselectedvalues");
               Combo_suppliergenid_Selectalltext = cgiGet( "COMBO_SUPPLIERGENID_Selectalltext");
               Combo_suppliergenid_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENID_Multiplevaluesseparator");
               Combo_suppliergenid_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENID_Addnewoptiontext");
               Combo_suppliergenid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_supplieragbid_Objectcall = cgiGet( "COMBO_SUPPLIERAGBID_Objectcall");
               Combo_supplieragbid_Class = cgiGet( "COMBO_SUPPLIERAGBID_Class");
               Combo_supplieragbid_Icontype = cgiGet( "COMBO_SUPPLIERAGBID_Icontype");
               Combo_supplieragbid_Icon = cgiGet( "COMBO_SUPPLIERAGBID_Icon");
               Combo_supplieragbid_Caption = cgiGet( "COMBO_SUPPLIERAGBID_Caption");
               Combo_supplieragbid_Tooltip = cgiGet( "COMBO_SUPPLIERAGBID_Tooltip");
               Combo_supplieragbid_Cls = cgiGet( "COMBO_SUPPLIERAGBID_Cls");
               Combo_supplieragbid_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERAGBID_Selectedvalue_set");
               Combo_supplieragbid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERAGBID_Selectedvalue_get");
               Combo_supplieragbid_Selectedtext_set = cgiGet( "COMBO_SUPPLIERAGBID_Selectedtext_set");
               Combo_supplieragbid_Selectedtext_get = cgiGet( "COMBO_SUPPLIERAGBID_Selectedtext_get");
               Combo_supplieragbid_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERAGBID_Gamoauthtoken");
               Combo_supplieragbid_Ddointernalname = cgiGet( "COMBO_SUPPLIERAGBID_Ddointernalname");
               Combo_supplieragbid_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERAGBID_Titlecontrolalign");
               Combo_supplieragbid_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERAGBID_Dropdownoptionstype");
               Combo_supplieragbid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Enabled"));
               Combo_supplieragbid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Visible"));
               Combo_supplieragbid_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERAGBID_Titlecontrolidtoreplace");
               Combo_supplieragbid_Datalisttype = cgiGet( "COMBO_SUPPLIERAGBID_Datalisttype");
               Combo_supplieragbid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Allowmultipleselection"));
               Combo_supplieragbid_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERAGBID_Datalistfixedvalues");
               Combo_supplieragbid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Isgriditem"));
               Combo_supplieragbid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Hasdescription"));
               Combo_supplieragbid_Datalistproc = cgiGet( "COMBO_SUPPLIERAGBID_Datalistproc");
               Combo_supplieragbid_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERAGBID_Datalistprocparametersprefix");
               Combo_supplieragbid_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERAGBID_Remoteservicesparameters");
               Combo_supplieragbid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERAGBID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_supplieragbid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Includeonlyselectedoption"));
               Combo_supplieragbid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Includeselectalloption"));
               Combo_supplieragbid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Emptyitem"));
               Combo_supplieragbid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBID_Includeaddnewoption"));
               Combo_supplieragbid_Htmltemplate = cgiGet( "COMBO_SUPPLIERAGBID_Htmltemplate");
               Combo_supplieragbid_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERAGBID_Multiplevaluestype");
               Combo_supplieragbid_Loadingdata = cgiGet( "COMBO_SUPPLIERAGBID_Loadingdata");
               Combo_supplieragbid_Noresultsfound = cgiGet( "COMBO_SUPPLIERAGBID_Noresultsfound");
               Combo_supplieragbid_Emptyitemtext = cgiGet( "COMBO_SUPPLIERAGBID_Emptyitemtext");
               Combo_supplieragbid_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERAGBID_Onlyselectedvalues");
               Combo_supplieragbid_Selectalltext = cgiGet( "COMBO_SUPPLIERAGBID_Selectalltext");
               Combo_supplieragbid_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERAGBID_Multiplevaluesseparator");
               Combo_supplieragbid_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERAGBID_Addnewoptiontext");
               Combo_supplieragbid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERAGBID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A59ProductServiceName = cgiGet( edtProductServiceName_Internalname);
               AssignAttri("", false, "A59ProductServiceName", A59ProductServiceName);
               A301ProductServiceTileName = cgiGet( edtProductServiceTileName_Internalname);
               AssignAttri("", false, "A301ProductServiceTileName", A301ProductServiceTileName);
               A61ProductServiceImage = cgiGet( imgProductServiceImage_Internalname);
               AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
               cmbProductServiceClass.CurrentValue = cgiGet( cmbProductServiceClass_Internalname);
               A408ProductServiceClass = cgiGet( cmbProductServiceClass_Internalname);
               AssignAttri("", false, "A408ProductServiceClass", A408ProductServiceClass);
               cmbProductServiceGroup.CurrentValue = cgiGet( cmbProductServiceGroup_Internalname);
               A366ProductServiceGroup = cgiGet( cmbProductServiceGroup_Internalname);
               AssignAttri("", false, "A366ProductServiceGroup", A366ProductServiceGroup);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierGenId_Internalname), "") == 0 )
               {
                  A42SupplierGenId = Guid.Empty;
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               }
               else
               {
                  try
                  {
                     A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
                     n42SupplierGenId = false;
                     AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERGENID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtSupplierAgbId_Internalname), "") == 0 )
               {
                  A49SupplierAgbId = Guid.Empty;
                  n49SupplierAgbId = false;
                  AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
               }
               else
               {
                  try
                  {
                     A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbId_Internalname));
                     n49SupplierAgbId = false;
                     AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERAGBID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierAgbId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n49SupplierAgbId = ((Guid.Empty==A49SupplierAgbId) ? true : false);
               A60ProductServiceDescription = cgiGet( edtProductServiceDescription_Internalname);
               AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
               AV26ComboSupplierGenId = StringUtil.StrToGuid( cgiGet( edtavCombosuppliergenid_Internalname));
               AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
               AV30ComboSupplierAgbId = StringUtil.StrToGuid( cgiGet( edtavCombosupplieragbid_Internalname));
               AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
               if ( StringUtil.StrCmp(cgiGet( edtProductServiceId_Internalname), "") == 0 )
               {
                  A58ProductServiceId = Guid.Empty;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               }
               else
               {
                  try
                  {
                     A58ProductServiceId = StringUtil.StrToGuid( cgiGet( edtProductServiceId_Internalname));
                     AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "PRODUCTSERVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtProductServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtLocationId_Internalname), "") == 0 )
               {
                  A29LocationId = Guid.Empty;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               }
               else
               {
                  try
                  {
                     A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                     AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "LOCATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtOrganisationId_Internalname), "") == 0 )
               {
                  A11OrganisationId = Guid.Empty;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
               else
               {
                  try
                  {
                     A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                     AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ORGANISATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtOrganisationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProductServiceImage_Internalname, ref  A61ProductServiceImage, ref  A40000ProductServiceImage_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_ProductService");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_productservice:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV12ProductServiceId) )
                  {
                     A58ProductServiceId = AV12ProductServiceId;
                     AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A58ProductServiceId) && ( Gx_BScreen == 0 ) )
                     {
                        A58ProductServiceId = Guid.NewGuid( );
                        AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode75 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV12ProductServiceId) )
                     {
                        A58ProductServiceId = AV12ProductServiceId;
                        AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A58ProductServiceId) && ( Gx_BScreen == 0 ) )
                        {
                           A58ProductServiceId = Guid.NewGuid( );
                           AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                        }
                     }
                     Gx_mode = sMode75;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound75 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_080( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODUCTSERVICEID");
                        AnyError = 1;
                        GX_FocusControl = edtProductServiceId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERGENID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_suppliergenid.Onoptionclicked */
                           E12082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERAGBID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_supplieragbid.Onoptionclicked */
                           E13082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E14082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E14082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0875( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0875( ) ;
         }
         AssignProp("", false, edtavCombosuppliergenid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosupplieragbid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbid_Enabled), 5, 0), true);
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_080( )
      {
         BeforeValidate0875( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0875( ) ;
            }
            else
            {
               CheckExtendedTable0875( ) ;
               CloseExtendedTableCursors0875( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption080( )
      {
      }

      protected void E11082( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV22DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV22DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV27GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV28GAMErrors);
         Combo_supplieragbid_Gamoauthtoken = AV27GAMSession.gxTpr_Token;
         ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "GAMOAuthToken", Combo_supplieragbid_Gamoauthtoken);
         edtSupplierAgbId_Visible = 0;
         AssignProp("", false, edtSupplierAgbId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Visible), 5, 0), true);
         AV30ComboSupplierAgbId = Guid.Empty;
         AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
         edtavCombosupplieragbid_Visible = 0;
         AssignProp("", false, edtavCombosupplieragbid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbid_Visible), 5, 0), true);
         Combo_suppliergenid_Gamoauthtoken = AV27GAMSession.gxTpr_Token;
         ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "GAMOAuthToken", Combo_suppliergenid_Gamoauthtoken);
         edtSupplierGenId_Visible = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Visible), 5, 0), true);
         AV26ComboSupplierGenId = Guid.Empty;
         AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
         edtavCombosuppliergenid_Visible = 0;
         AssignProp("", false, edtavCombosuppliergenid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV16TrnContext.FromXml(AV18WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV16TrnContext.gxTpr_Transactionname, AV41Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV42GXV1 = 1;
            AssignAttri("", false, "AV42GXV1", StringUtil.LTrimStr( (decimal)(AV42GXV1), 8, 0));
            while ( AV42GXV1 <= AV16TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV16TrnContext.gxTpr_Attributes.Item(AV42GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "SupplierGenId") == 0 )
               {
                  AV10Insert_SupplierGenId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV10Insert_SupplierGenId", AV10Insert_SupplierGenId.ToString());
                  if ( ! (Guid.Empty==AV10Insert_SupplierGenId) )
                  {
                     AV26ComboSupplierGenId = AV10Insert_SupplierGenId;
                     AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
                     Combo_suppliergenid_Selectedvalue_set = StringUtil.Trim( AV26ComboSupplierGenId.ToString());
                     ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new trn_productserviceloaddvcombo(context ).execute(  "SupplierGenId",  "GET",  false,  AV12ProductServiceId,  AV33LocationId,  AV34OrganisationId,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_suppliergenid_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "SelectedText_set", Combo_suppliergenid_Selectedtext_set);
                     Combo_suppliergenid_Enabled = false;
                     ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergenid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "SupplierAgbId") == 0 )
               {
                  AV9Insert_SupplierAgbId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV9Insert_SupplierAgbId", AV9Insert_SupplierAgbId.ToString());
                  if ( ! (Guid.Empty==AV9Insert_SupplierAgbId) )
                  {
                     AV30ComboSupplierAgbId = AV9Insert_SupplierAgbId;
                     AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
                     Combo_supplieragbid_Selectedvalue_set = StringUtil.Trim( AV30ComboSupplierAgbId.ToString());
                     ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
                     GXt_char2 = AV25Combo_DataJson;
                     new trn_productserviceloaddvcombo(context ).execute(  "SupplierAgbId",  "GET",  false,  AV12ProductServiceId,  AV33LocationId,  AV34OrganisationId,  AV17TrnContextAtt.gxTpr_Attributevalue, out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
                     AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
                     AV25Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
                     Combo_supplieragbid_Selectedtext_set = AV24ComboSelectedText;
                     ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "SelectedText_set", Combo_supplieragbid_Selectedtext_set);
                     Combo_supplieragbid_Enabled = false;
                     ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_supplieragbid_Enabled));
                  }
               }
               AV42GXV1 = (int)(AV42GXV1+1);
               AssignAttri("", false, "AV42GXV1", StringUtil.LTrimStr( (decimal)(AV42GXV1), 8, 0));
            }
         }
         edtProductServiceId_Visible = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Visible), 5, 0), true);
         edtLocationId_Visible = 0;
         AssignProp("", false, edtLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
      }

      protected void E14082( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV16TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_productserviceww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void E13082( )
      {
         /* Combo_supplieragbid_Onoptionclicked Routine */
         returnInSub = false;
         AV26ComboSupplierGenId = Guid.Empty;
         AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
         AV30ComboSupplierAgbId = StringUtil.StrToGuid( Combo_supplieragbid_Selectedvalue_get);
         AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
         /*  Sending Event outputs  */
      }

      protected void E12082( )
      {
         /* Combo_suppliergenid_Onoptionclicked Routine */
         returnInSub = false;
         AV30ComboSupplierAgbId = Guid.Empty;
         AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
         AV26ComboSupplierGenId = StringUtil.StrToGuid( Combo_suppliergenid_Selectedvalue_get);
         AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERAGBID' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new trn_productserviceloaddvcombo(context ).execute(  "SupplierAgbId",  Gx_mode,  false,  AV12ProductServiceId,  AV33LocationId,  AV34OrganisationId,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_supplieragbid_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
         Combo_supplieragbid_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "SelectedText_set", Combo_supplieragbid_Selectedtext_set);
         AV30ComboSupplierAgbId = StringUtil.StrToGuid( AV23ComboSelectedValue);
         AssignAttri("", false, "AV30ComboSupplierAgbId", AV30ComboSupplierAgbId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_supplieragbid_Enabled = false;
            ucCombo_supplieragbid.SendProperty(context, "", false, Combo_supplieragbid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_supplieragbid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSUPPLIERGENID' Routine */
         returnInSub = false;
         GXt_char2 = AV25Combo_DataJson;
         new trn_productserviceloaddvcombo(context ).execute(  "SupplierGenId",  Gx_mode,  false,  AV12ProductServiceId,  AV33LocationId,  AV34OrganisationId,  "", out  AV23ComboSelectedValue, out  AV24ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV23ComboSelectedValue", AV23ComboSelectedValue);
         AssignAttri("", false, "AV24ComboSelectedText", AV24ComboSelectedText);
         AV25Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV25Combo_DataJson", AV25Combo_DataJson);
         Combo_suppliergenid_Selectedvalue_set = AV23ComboSelectedValue;
         ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
         Combo_suppliergenid_Selectedtext_set = AV24ComboSelectedText;
         ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "SelectedText_set", Combo_suppliergenid_Selectedtext_set);
         AV26ComboSupplierGenId = StringUtil.StrToGuid( AV23ComboSelectedValue);
         AssignAttri("", false, "AV26ComboSupplierGenId", AV26ComboSupplierGenId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergenid_Enabled = false;
            ucCombo_suppliergenid.SendProperty(context, "", false, Combo_suppliergenid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergenid_Enabled));
         }
      }

      protected void ZM0875( short GX_JID )
      {
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z59ProductServiceName = T00083_A59ProductServiceName[0];
               Z301ProductServiceTileName = T00083_A301ProductServiceTileName[0];
               Z408ProductServiceClass = T00083_A408ProductServiceClass[0];
               Z366ProductServiceGroup = T00083_A366ProductServiceGroup[0];
               Z42SupplierGenId = T00083_A42SupplierGenId[0];
               Z49SupplierAgbId = T00083_A49SupplierAgbId[0];
            }
            else
            {
               Z59ProductServiceName = A59ProductServiceName;
               Z301ProductServiceTileName = A301ProductServiceTileName;
               Z408ProductServiceClass = A408ProductServiceClass;
               Z366ProductServiceGroup = A366ProductServiceGroup;
               Z42SupplierGenId = A42SupplierGenId;
               Z49SupplierAgbId = A49SupplierAgbId;
            }
         }
         if ( GX_JID == -30 )
         {
            Z58ProductServiceId = A58ProductServiceId;
            Z59ProductServiceName = A59ProductServiceName;
            Z301ProductServiceTileName = A301ProductServiceTileName;
            Z60ProductServiceDescription = A60ProductServiceDescription;
            Z408ProductServiceClass = A408ProductServiceClass;
            Z61ProductServiceImage = A61ProductServiceImage;
            Z40000ProductServiceImage_GXI = A40000ProductServiceImage_GXI;
            Z366ProductServiceGroup = A366ProductServiceGroup;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z42SupplierGenId = A42SupplierGenId;
            Z49SupplierAgbId = A49SupplierAgbId;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z51SupplierAgbName = A51SupplierAgbName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV41Pgmname = "Trn_ProductService";
         AssignAttri("", false, "AV41Pgmname", AV41Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV12ProductServiceId) )
         {
            edtProductServiceId_Enabled = 0;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         }
         else
         {
            edtProductServiceId_Enabled = 1;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV12ProductServiceId) )
         {
            edtProductServiceId_Enabled = 0;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV33LocationId) )
         {
            A29LocationId = AV33LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         else
         {
            GXt_guid3 = A29LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid3) ;
            A29LocationId = GXt_guid3;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         if ( ! (Guid.Empty==AV33LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         else
         {
            edtLocationId_Enabled = 1;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV33LocationId) )
         {
            edtLocationId_Enabled = 0;
            AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV34OrganisationId) )
         {
            A11OrganisationId = AV34OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            GXt_guid3 = A11OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
            A11OrganisationId = GXt_guid3;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ! (Guid.Empty==AV34OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV34OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV10Insert_SupplierGenId) )
         {
            edtSupplierGenId_Enabled = 0;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierGenId_Enabled = 1;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV9Insert_SupplierAgbId) )
         {
            edtSupplierAgbId_Enabled = 0;
            AssignProp("", false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierAgbId_Enabled = 1;
            AssignProp("", false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV10Insert_SupplierGenId) )
         {
            A42SupplierGenId = AV10Insert_SupplierGenId;
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV26ComboSupplierGenId) )
            {
               A42SupplierGenId = Guid.Empty;
               n42SupplierGenId = false;
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               n42SupplierGenId = true;
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV26ComboSupplierGenId) )
               {
                  A42SupplierGenId = AV26ComboSupplierGenId;
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV9Insert_SupplierAgbId) )
         {
            A49SupplierAgbId = AV9Insert_SupplierAgbId;
            n49SupplierAgbId = false;
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV30ComboSupplierAgbId) )
            {
               A49SupplierAgbId = Guid.Empty;
               n49SupplierAgbId = false;
               AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
               n49SupplierAgbId = true;
               AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV30ComboSupplierAgbId) )
               {
                  A49SupplierAgbId = AV30ComboSupplierAgbId;
                  n49SupplierAgbId = false;
                  AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
               }
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV12ProductServiceId) )
         {
            A58ProductServiceId = AV12ProductServiceId;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A58ProductServiceId) && ( Gx_BScreen == 0 ) )
            {
               A58ProductServiceId = Guid.NewGuid( );
               AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            }
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A366ProductServiceGroup)) && ( Gx_BScreen == 0 ) )
         {
            A366ProductServiceGroup = "Location";
            AssignAttri("", false, "A366ProductServiceGroup", A366ProductServiceGroup);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00085 */
            pr_default.execute(3, new Object[] {n42SupplierGenId, A42SupplierGenId});
            A44SupplierGenCompanyName = T00085_A44SupplierGenCompanyName[0];
            pr_default.close(3);
            /* Using cursor T00086 */
            pr_default.execute(4, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
            A51SupplierAgbName = T00086_A51SupplierAgbName[0];
            pr_default.close(4);
            divTablegen_Visible = (((StringUtil.StrCmp(A366ProductServiceGroup, "General Supplier")==0)) ? 1 : 0);
            AssignProp("", false, divTablegen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegen_Visible), 5, 0), true);
            divTableagb_Visible = (((StringUtil.StrCmp(A366ProductServiceGroup, " AGB Supplier")==0)) ? 1 : 0);
            AssignProp("", false, divTableagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableagb_Visible), 5, 0), true);
         }
      }

      protected void Load0875( )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound75 = 1;
            A59ProductServiceName = T00087_A59ProductServiceName[0];
            AssignAttri("", false, "A59ProductServiceName", A59ProductServiceName);
            A301ProductServiceTileName = T00087_A301ProductServiceTileName[0];
            AssignAttri("", false, "A301ProductServiceTileName", A301ProductServiceTileName);
            A60ProductServiceDescription = T00087_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A408ProductServiceClass = T00087_A408ProductServiceClass[0];
            AssignAttri("", false, "A408ProductServiceClass", A408ProductServiceClass);
            A40000ProductServiceImage_GXI = T00087_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A366ProductServiceGroup = T00087_A366ProductServiceGroup[0];
            AssignAttri("", false, "A366ProductServiceGroup", A366ProductServiceGroup);
            A44SupplierGenCompanyName = T00087_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = T00087_A51SupplierAgbName[0];
            A42SupplierGenId = T00087_A42SupplierGenId[0];
            n42SupplierGenId = T00087_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            A49SupplierAgbId = T00087_A49SupplierAgbId[0];
            n49SupplierAgbId = T00087_n49SupplierAgbId[0];
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            A61ProductServiceImage = T00087_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            ZM0875( -30) ;
         }
         pr_default.close(5);
         OnLoadActions0875( ) ;
      }

      protected void OnLoadActions0875( )
      {
         divTablegen_Visible = (((StringUtil.StrCmp(A366ProductServiceGroup, "General Supplier")==0)) ? 1 : 0);
         AssignProp("", false, divTablegen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegen_Visible), 5, 0), true);
         divTableagb_Visible = (((StringUtil.StrCmp(A366ProductServiceGroup, " AGB Supplier")==0)) ? 1 : 0);
         AssignProp("", false, divTableagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableagb_Visible), 5, 0), true);
      }

      protected void CheckExtendedTable0875( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A59ProductServiceName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Product Service Name", ""), "", "", "", "", "", "", "", ""), 1, "PRODUCTSERVICENAME");
            AnyError = 1;
            GX_FocusControl = edtProductServiceName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A301ProductServiceTileName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Product Service Tile Name", ""), "", "", "", "", "", "", "", ""), 1, "PRODUCTSERVICETILENAME");
            AnyError = 1;
            GX_FocusControl = edtProductServiceTileName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A408ProductServiceClass, "MyLiving") == 0 ) || ( StringUtil.StrCmp(A408ProductServiceClass, "MyCare") == 0 ) || ( StringUtil.StrCmp(A408ProductServiceClass, "MyServices") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Product Service Class", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PRODUCTSERVICECLASS");
            AnyError = 1;
            GX_FocusControl = cmbProductServiceClass_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A366ProductServiceGroup, "Location") == 0 ) || ( StringUtil.StrCmp(A366ProductServiceGroup, " AGB Supplier") == 0 ) || ( StringUtil.StrCmp(A366ProductServiceGroup, "General Supplier") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Product Service Group", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PRODUCTSERVICEGROUP");
            AnyError = 1;
            GX_FocusControl = cmbProductServiceGroup_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         divTablegen_Visible = (((StringUtil.StrCmp(A366ProductServiceGroup, "General Supplier")==0)) ? 1 : 0);
         AssignProp("", false, divTablegen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegen_Visible), 5, 0), true);
         divTableagb_Visible = (((StringUtil.StrCmp(A366ProductServiceGroup, " AGB Supplier")==0)) ? 1 : 0);
         AssignProp("", false, divTableagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableagb_Visible), 5, 0), true);
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A42SupplierGenId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierGen", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
               AnyError = 1;
               GX_FocusControl = edtSupplierGenId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A44SupplierGenCompanyName = T00085_A44SupplierGenCompanyName[0];
         pr_default.close(3);
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A49SupplierAgbId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierAGB", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERAGBID");
               AnyError = 1;
               GX_FocusControl = edtSupplierAgbId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A51SupplierAgbName = T00086_A51SupplierAgbName[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0875( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_31( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_32( Guid A42SupplierGenId )
      {
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A42SupplierGenId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierGen", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
               AnyError = 1;
               GX_FocusControl = edtSupplierGenId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A44SupplierGenCompanyName = T00089_A44SupplierGenCompanyName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A44SupplierGenCompanyName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_33( Guid A49SupplierAgbId )
      {
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A49SupplierAgbId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierAGB", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERAGBID");
               AnyError = 1;
               GX_FocusControl = edtSupplierAgbId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A51SupplierAgbName = T000810_A51SupplierAgbName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A51SupplierAgbName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0875( )
      {
         /* Using cursor T000811 */
         pr_default.execute(9, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound75 = 1;
         }
         else
         {
            RcdFound75 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0875( 30) ;
            RcdFound75 = 1;
            A58ProductServiceId = T00083_A58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A59ProductServiceName = T00083_A59ProductServiceName[0];
            AssignAttri("", false, "A59ProductServiceName", A59ProductServiceName);
            A301ProductServiceTileName = T00083_A301ProductServiceTileName[0];
            AssignAttri("", false, "A301ProductServiceTileName", A301ProductServiceTileName);
            A60ProductServiceDescription = T00083_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A408ProductServiceClass = T00083_A408ProductServiceClass[0];
            AssignAttri("", false, "A408ProductServiceClass", A408ProductServiceClass);
            A40000ProductServiceImage_GXI = T00083_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A366ProductServiceGroup = T00083_A366ProductServiceGroup[0];
            AssignAttri("", false, "A366ProductServiceGroup", A366ProductServiceGroup);
            A29LocationId = T00083_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T00083_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A42SupplierGenId = T00083_A42SupplierGenId[0];
            n42SupplierGenId = T00083_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            A49SupplierAgbId = T00083_A49SupplierAgbId[0];
            n49SupplierAgbId = T00083_n49SupplierAgbId[0];
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            A61ProductServiceImage = T00083_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0875( ) ;
            if ( AnyError == 1 )
            {
               RcdFound75 = 0;
               InitializeNonKey0875( ) ;
            }
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound75 = 0;
            InitializeNonKey0875( ) ;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0875( ) ;
         if ( RcdFound75 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound75 = 0;
         /* Using cursor T000812 */
         pr_default.execute(10, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000812_A58ProductServiceId[0], A58ProductServiceId, 0) < 0 ) || ( T000812_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000812_A29LocationId[0], A29LocationId, 0) < 0 ) || ( T000812_A29LocationId[0] == A29LocationId ) && ( T000812_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000812_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000812_A58ProductServiceId[0], A58ProductServiceId, 0) > 0 ) || ( T000812_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000812_A29LocationId[0], A29LocationId, 0) > 0 ) || ( T000812_A29LocationId[0] == A29LocationId ) && ( T000812_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000812_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               A58ProductServiceId = T000812_A58ProductServiceId[0];
               AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               A29LocationId = T000812_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A11OrganisationId = T000812_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound75 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound75 = 0;
         /* Using cursor T000813 */
         pr_default.execute(11, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000813_A58ProductServiceId[0], A58ProductServiceId, 0) > 0 ) || ( T000813_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000813_A29LocationId[0], A29LocationId, 0) > 0 ) || ( T000813_A29LocationId[0] == A29LocationId ) && ( T000813_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000813_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000813_A58ProductServiceId[0], A58ProductServiceId, 0) < 0 ) || ( T000813_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000813_A29LocationId[0], A29LocationId, 0) < 0 ) || ( T000813_A29LocationId[0] == A29LocationId ) && ( T000813_A58ProductServiceId[0] == A58ProductServiceId ) && ( GuidUtil.Compare(T000813_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               A58ProductServiceId = T000813_A58ProductServiceId[0];
               AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               A29LocationId = T000813_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A11OrganisationId = T000813_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound75 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0875( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductServiceName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0875( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound75 == 1 )
            {
               if ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A58ProductServiceId = Z58ProductServiceId;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  A29LocationId = Z29LocationId;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  A11OrganisationId = Z11OrganisationId;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTSERVICEID");
                  AnyError = 1;
                  GX_FocusControl = edtProductServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProductServiceName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0875( ) ;
                  GX_FocusControl = edtProductServiceName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtProductServiceName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0875( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTSERVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtProductServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProductServiceName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0875( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
         {
            A58ProductServiceId = Z58ProductServiceId;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = Z29LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = Z11OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTSERVICEID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProductServiceName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0875( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ProductService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z59ProductServiceName, T00082_A59ProductServiceName[0]) != 0 ) || ( StringUtil.StrCmp(Z301ProductServiceTileName, T00082_A301ProductServiceTileName[0]) != 0 ) || ( StringUtil.StrCmp(Z408ProductServiceClass, T00082_A408ProductServiceClass[0]) != 0 ) || ( StringUtil.StrCmp(Z366ProductServiceGroup, T00082_A366ProductServiceGroup[0]) != 0 ) || ( Z42SupplierGenId != T00082_A42SupplierGenId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z49SupplierAgbId != T00082_A49SupplierAgbId[0] ) )
            {
               if ( StringUtil.StrCmp(Z59ProductServiceName, T00082_A59ProductServiceName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"ProductServiceName");
                  GXUtil.WriteLogRaw("Old: ",Z59ProductServiceName);
                  GXUtil.WriteLogRaw("Current: ",T00082_A59ProductServiceName[0]);
               }
               if ( StringUtil.StrCmp(Z301ProductServiceTileName, T00082_A301ProductServiceTileName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"ProductServiceTileName");
                  GXUtil.WriteLogRaw("Old: ",Z301ProductServiceTileName);
                  GXUtil.WriteLogRaw("Current: ",T00082_A301ProductServiceTileName[0]);
               }
               if ( StringUtil.StrCmp(Z408ProductServiceClass, T00082_A408ProductServiceClass[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"ProductServiceClass");
                  GXUtil.WriteLogRaw("Old: ",Z408ProductServiceClass);
                  GXUtil.WriteLogRaw("Current: ",T00082_A408ProductServiceClass[0]);
               }
               if ( StringUtil.StrCmp(Z366ProductServiceGroup, T00082_A366ProductServiceGroup[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"ProductServiceGroup");
                  GXUtil.WriteLogRaw("Old: ",Z366ProductServiceGroup);
                  GXUtil.WriteLogRaw("Current: ",T00082_A366ProductServiceGroup[0]);
               }
               if ( Z42SupplierGenId != T00082_A42SupplierGenId[0] )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"SupplierGenId");
                  GXUtil.WriteLogRaw("Old: ",Z42SupplierGenId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A42SupplierGenId[0]);
               }
               if ( Z49SupplierAgbId != T00082_A49SupplierAgbId[0] )
               {
                  GXUtil.WriteLog("trn_productservice:[seudo value changed for attri]"+"SupplierAgbId");
                  GXUtil.WriteLogRaw("Old: ",Z49SupplierAgbId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A49SupplierAgbId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ProductService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0875( )
      {
         if ( ! IsAuthorized("trn_productservice_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0875( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0875( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0875( 0) ;
            CheckOptimisticConcurrency0875( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0875( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0875( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000814 */
                     pr_default.execute(12, new Object[] {A58ProductServiceId, A59ProductServiceName, A301ProductServiceTileName, A60ProductServiceDescription, A408ProductServiceClass, A61ProductServiceImage, A40000ProductServiceImage_GXI, A366ProductServiceGroup, A29LocationId, A11OrganisationId, n42SupplierGenId, A42SupplierGenId, n49SupplierAgbId, A49SupplierAgbId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
                     if ( (pr_default.getStatus(12) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption080( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0875( ) ;
            }
            EndLevel0875( ) ;
         }
         CloseExtendedTableCursors0875( ) ;
      }

      protected void Update0875( )
      {
         if ( ! IsAuthorized("trn_productservice_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0875( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0875( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0875( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0875( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0875( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000815 */
                     pr_default.execute(13, new Object[] {A59ProductServiceName, A301ProductServiceTileName, A60ProductServiceDescription, A408ProductServiceClass, A366ProductServiceGroup, n42SupplierGenId, A42SupplierGenId, n49SupplierAgbId, A49SupplierAgbId, A58ProductServiceId, A29LocationId, A11OrganisationId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ProductService"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0875( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0875( ) ;
         }
         CloseExtendedTableCursors0875( ) ;
      }

      protected void DeferredUpdate0875( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000816 */
            pr_default.execute(14, new Object[] {A61ProductServiceImage, A40000ProductServiceImage_GXI, A58ProductServiceId, A29LocationId, A11OrganisationId});
            pr_default.close(14);
            pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_productservice_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0875( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0875( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0875( ) ;
            AfterConfirm0875( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0875( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000817 */
                  pr_default.execute(15, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode75 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0875( ) ;
         Gx_mode = sMode75;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0875( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            divTablegen_Visible = (((StringUtil.StrCmp(A366ProductServiceGroup, "General Supplier")==0)) ? 1 : 0);
            AssignProp("", false, divTablegen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegen_Visible), 5, 0), true);
            divTableagb_Visible = (((StringUtil.StrCmp(A366ProductServiceGroup, " AGB Supplier")==0)) ? 1 : 0);
            AssignProp("", false, divTableagb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableagb_Visible), 5, 0), true);
            /* Using cursor T000818 */
            pr_default.execute(16, new Object[] {n42SupplierGenId, A42SupplierGenId});
            A44SupplierGenCompanyName = T000818_A44SupplierGenCompanyName[0];
            pr_default.close(16);
            /* Using cursor T000819 */
            pr_default.execute(17, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
            A51SupplierAgbName = T000819_A51SupplierAgbName[0];
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000820 */
            pr_default.execute(18, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_CallToAction", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel0875( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0875( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_productservice",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_productservice",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0875( )
      {
         /* Scan By routine */
         /* Using cursor T000821 */
         pr_default.execute(19);
         RcdFound75 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound75 = 1;
            A58ProductServiceId = T000821_A58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = T000821_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000821_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0875( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound75 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound75 = 1;
            A58ProductServiceId = T000821_A58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = T000821_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T000821_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
      }

      protected void ScanEnd0875( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm0875( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0875( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0875( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0875( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0875( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0875( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0875( )
      {
         edtProductServiceName_Enabled = 0;
         AssignProp("", false, edtProductServiceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceName_Enabled), 5, 0), true);
         edtProductServiceTileName_Enabled = 0;
         AssignProp("", false, edtProductServiceTileName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceTileName_Enabled), 5, 0), true);
         imgProductServiceImage_Enabled = 0;
         AssignProp("", false, imgProductServiceImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductServiceImage_Enabled), 5, 0), true);
         cmbProductServiceClass.Enabled = 0;
         AssignProp("", false, cmbProductServiceClass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProductServiceClass.Enabled), 5, 0), true);
         cmbProductServiceGroup.Enabled = 0;
         AssignProp("", false, cmbProductServiceGroup_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProductServiceGroup.Enabled), 5, 0), true);
         edtSupplierGenId_Enabled = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         edtSupplierAgbId_Enabled = 0;
         AssignProp("", false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
         edtProductServiceDescription_Enabled = 0;
         AssignProp("", false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), true);
         edtavCombosuppliergenid_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergenid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenid_Enabled), 5, 0), true);
         edtavCombosupplieragbid_Enabled = 0;
         AssignProp("", false, edtavCombosupplieragbid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbid_Enabled), 5, 0), true);
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0875( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
      {
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
         MasterPageObj.master_styles();
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_productservice.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV12ProductServiceId.ToString()) + "," + UrlEncode(AV33LocationId.ToString()) + "," + UrlEncode(AV34OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_ProductService");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_productservice:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z59ProductServiceName", Z59ProductServiceName);
         GxWebStd.gx_hidden_field( context, "Z301ProductServiceTileName", StringUtil.RTrim( Z301ProductServiceTileName));
         GxWebStd.gx_hidden_field( context, "Z408ProductServiceClass", Z408ProductServiceClass);
         GxWebStd.gx_hidden_field( context, "Z366ProductServiceGroup", Z366ProductServiceGroup);
         GxWebStd.gx_hidden_field( context, "Z42SupplierGenId", Z42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "Z49SupplierAgbId", Z49SupplierAgbId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N42SupplierGenId", A42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "N49SupplierAgbId", A49SupplierAgbId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENID_DATA", AV21SupplierGenId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENID_DATA", AV21SupplierGenId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERAGBID_DATA", AV29SupplierAgbId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERAGBID_DATA", AV29SupplierAgbId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV16TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV16TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV16TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPRODUCTSERVICEID", AV12ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTSERVICEID", GetSecureSignedToken( "", AV12ProductServiceId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV33LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV33LocationId, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV34OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV34OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERGENID", AV10Insert_SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERAGBID", AV9Insert_SupplierAgbId.ToString());
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEIMAGE_GXI", A40000ProductServiceImage_GXI);
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENCOMPANYNAME", A44SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "SUPPLIERAGBNAME", A51SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GXCCtlgxBlob = "PRODUCTSERVICEIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A61ProductServiceImage);
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Objectcall", StringUtil.RTrim( Combo_suppliergenid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Cls", StringUtil.RTrim( Combo_suppliergenid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergenid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Selectedtext_set", StringUtil.RTrim( Combo_suppliergenid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Gamoauthtoken", StringUtil.RTrim( Combo_suppliergenid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Enabled", StringUtil.BoolToStr( Combo_suppliergenid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Datalistproc", StringUtil.RTrim( Combo_suppliergenid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_suppliergenid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Objectcall", StringUtil.RTrim( Combo_supplieragbid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Cls", StringUtil.RTrim( Combo_supplieragbid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Selectedvalue_set", StringUtil.RTrim( Combo_supplieragbid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Selectedtext_set", StringUtil.RTrim( Combo_supplieragbid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Gamoauthtoken", StringUtil.RTrim( Combo_supplieragbid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Enabled", StringUtil.BoolToStr( Combo_supplieragbid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Datalistproc", StringUtil.RTrim( Combo_supplieragbid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_supplieragbid_Datalistprocparametersprefix));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_productservice.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV12ProductServiceId.ToString()) + "," + UrlEncode(AV33LocationId.ToString()) + "," + UrlEncode(AV34OrganisationId.ToString());
         return formatLink("trn_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_ProductService" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Product/Service", "") ;
      }

      protected void InitializeNonKey0875( )
      {
         A42SupplierGenId = Guid.Empty;
         n42SupplierGenId = false;
         AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         A49SupplierAgbId = Guid.Empty;
         n49SupplierAgbId = false;
         AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
         n49SupplierAgbId = ((Guid.Empty==A49SupplierAgbId) ? true : false);
         A59ProductServiceName = "";
         AssignAttri("", false, "A59ProductServiceName", A59ProductServiceName);
         A301ProductServiceTileName = "";
         AssignAttri("", false, "A301ProductServiceTileName", A301ProductServiceTileName);
         A60ProductServiceDescription = "";
         AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
         A408ProductServiceClass = "";
         AssignAttri("", false, "A408ProductServiceClass", A408ProductServiceClass);
         A61ProductServiceImage = "";
         AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A40000ProductServiceImage_GXI = "";
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A44SupplierGenCompanyName = "";
         AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
         A51SupplierAgbName = "";
         AssignAttri("", false, "A51SupplierAgbName", A51SupplierAgbName);
         A366ProductServiceGroup = "Location";
         AssignAttri("", false, "A366ProductServiceGroup", A366ProductServiceGroup);
         Z59ProductServiceName = "";
         Z301ProductServiceTileName = "";
         Z408ProductServiceClass = "";
         Z366ProductServiceGroup = "";
         Z42SupplierGenId = Guid.Empty;
         Z49SupplierAgbId = Guid.Empty;
      }

      protected void InitAll0875( )
      {
         A58ProductServiceId = Guid.NewGuid( );
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         InitializeNonKey0875( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A366ProductServiceGroup = i366ProductServiceGroup;
         AssignAttri("", false, "A366ProductServiceGroup", A366ProductServiceGroup);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411496168", true, true);
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
         context.AddJavascriptSource("trn_productservice.js", "?2024114961610", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME";
         edtProductServiceTileName_Internalname = "PRODUCTSERVICETILENAME";
         imgProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         cmbProductServiceClass_Internalname = "PRODUCTSERVICECLASS";
         cmbProductServiceGroup_Internalname = "PRODUCTSERVICEGROUP";
         lblTextblocksuppliergenid_Internalname = "TEXTBLOCKSUPPLIERGENID";
         Combo_suppliergenid_Internalname = "COMBO_SUPPLIERGENID";
         edtSupplierGenId_Internalname = "SUPPLIERGENID";
         divTablesplittedsuppliergenid_Internalname = "TABLESPLITTEDSUPPLIERGENID";
         divTablegen_Internalname = "TABLEGEN";
         lblTextblocksupplieragbid_Internalname = "TEXTBLOCKSUPPLIERAGBID";
         Combo_supplieragbid_Internalname = "COMBO_SUPPLIERAGBID";
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID";
         divTablesplittedsupplieragbid_Internalname = "TABLESPLITTEDSUPPLIERAGBID";
         divTableagb_Internalname = "TABLEAGB";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombosuppliergenid_Internalname = "vCOMBOSUPPLIERGENID";
         divSectionattribute_suppliergenid_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENID";
         edtavCombosupplieragbid_Internalname = "vCOMBOSUPPLIERAGBID";
         divSectionattribute_supplieragbid_Internalname = "SECTIONATTRIBUTE_SUPPLIERAGBID";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Product/Service", "");
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         edtLocationId_Visible = 1;
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Enabled = 1;
         edtProductServiceId_Visible = 1;
         edtavCombosupplieragbid_Jsonclick = "";
         edtavCombosupplieragbid_Enabled = 0;
         edtavCombosupplieragbid_Visible = 1;
         edtavCombosuppliergenid_Jsonclick = "";
         edtavCombosuppliergenid_Enabled = 0;
         edtavCombosuppliergenid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtProductServiceDescription_Enabled = 1;
         edtSupplierAgbId_Jsonclick = "";
         edtSupplierAgbId_Enabled = 1;
         edtSupplierAgbId_Visible = 1;
         Combo_supplieragbid_Datalistprocparametersprefix = " \"ComboName\": \"SupplierAgbId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProductServiceId\": \"00000000-0000-0000-0000-000000000000\", \"LocationId\": \"00000000-0000-0000-0000-000000000000\", \"OrganisationId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_supplieragbid_Datalistproc = "Trn_ProductServiceLoadDVCombo";
         Combo_supplieragbid_Cls = "ExtendedCombo Attribute";
         Combo_supplieragbid_Caption = "";
         Combo_supplieragbid_Enabled = Convert.ToBoolean( -1);
         divTableagb_Visible = 1;
         edtSupplierGenId_Jsonclick = "";
         edtSupplierGenId_Enabled = 1;
         edtSupplierGenId_Visible = 1;
         Combo_suppliergenid_Datalistprocparametersprefix = " \"ComboName\": \"SupplierGenId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ProductServiceId\": \"00000000-0000-0000-0000-000000000000\", \"LocationId\": \"00000000-0000-0000-0000-000000000000\", \"OrganisationId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_suppliergenid_Datalistproc = "Trn_ProductServiceLoadDVCombo";
         Combo_suppliergenid_Cls = "ExtendedCombo Attribute";
         Combo_suppliergenid_Caption = "";
         Combo_suppliergenid_Enabled = Convert.ToBoolean( -1);
         divTablegen_Visible = 1;
         cmbProductServiceGroup_Jsonclick = "";
         cmbProductServiceGroup.Enabled = 1;
         cmbProductServiceClass_Jsonclick = "";
         cmbProductServiceClass.Enabled = 1;
         imgProductServiceImage_Enabled = 1;
         edtProductServiceTileName_Jsonclick = "";
         edtProductServiceTileName_Enabled = 1;
         edtProductServiceName_Jsonclick = "";
         edtProductServiceName_Enabled = 1;
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX12ASALOCATIONID0875( Guid AV33LocationId )
      {
         if ( ! (Guid.Empty==AV33LocationId) )
         {
            A29LocationId = AV33LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         else
         {
            GXt_guid3 = A29LocationId;
            new prc_getuserlocationid(context ).execute( out  GXt_guid3) ;
            A29LocationId = GXt_guid3;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A29LocationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX14ASAORGANISATIONID0875( Guid AV34OrganisationId )
      {
         if ( ! (Guid.Empty==AV34OrganisationId) )
         {
            A11OrganisationId = AV34OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            GXt_guid3 = A11OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid3) ;
            A11OrganisationId = GXt_guid3;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A11OrganisationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbProductServiceClass.Name = "PRODUCTSERVICECLASS";
         cmbProductServiceClass.WebTags = "";
         cmbProductServiceClass.addItem("MyLiving", context.GetMessage( "My Living", ""), 0);
         cmbProductServiceClass.addItem("MyCare", context.GetMessage( "My Care", ""), 0);
         cmbProductServiceClass.addItem("MyServices", context.GetMessage( "My Services", ""), 0);
         if ( cmbProductServiceClass.ItemCount > 0 )
         {
            A408ProductServiceClass = cmbProductServiceClass.getValidValue(A408ProductServiceClass);
            AssignAttri("", false, "A408ProductServiceClass", A408ProductServiceClass);
         }
         cmbProductServiceGroup.Name = "PRODUCTSERVICEGROUP";
         cmbProductServiceGroup.WebTags = "";
         cmbProductServiceGroup.addItem("Location", context.GetMessage( "Location", ""), 0);
         cmbProductServiceGroup.addItem(" AGB Supplier", context.GetMessage( "AGB Supplier", ""), 0);
         cmbProductServiceGroup.addItem("General Supplier", context.GetMessage( "General Supplier", ""), 0);
         if ( cmbProductServiceGroup.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A366ProductServiceGroup)) )
            {
               A366ProductServiceGroup = "Location";
               AssignAttri("", false, "A366ProductServiceGroup", A366ProductServiceGroup);
            }
         }
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Organisationid( )
      {
         /* Using cursor T000822 */
         pr_default.execute(20, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Suppliergenid( )
      {
         n42SupplierGenId = false;
         /* Using cursor T000818 */
         pr_default.execute(16, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (Guid.Empty==A42SupplierGenId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierGen", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
               AnyError = 1;
               GX_FocusControl = edtSupplierGenId_Internalname;
            }
         }
         A44SupplierGenCompanyName = T000818_A44SupplierGenCompanyName[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
      }

      public void Valid_Supplieragbid( )
      {
         n49SupplierAgbId = false;
         /* Using cursor T000819 */
         pr_default.execute(17, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (Guid.Empty==A49SupplierAgbId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_SupplierAGB", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERAGBID");
               AnyError = 1;
               GX_FocusControl = edtSupplierAgbId_Internalname;
            }
         }
         A51SupplierAgbName = T000819_A51SupplierAgbName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A51SupplierAgbName", A51SupplierAgbName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV12ProductServiceId","fld":"vPRODUCTSERVICEID","hsh":true},{"av":"AV33LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV34OrganisationId","fld":"vORGANISATIONID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV16TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV12ProductServiceId","fld":"vPRODUCTSERVICEID","hsh":true},{"av":"AV33LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV34OrganisationId","fld":"vORGANISATIONID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E14082","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV16TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED","""{"handler":"E13082","iparms":[{"av":"Combo_supplieragbid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED",""","oparms":[{"av":"AV26ComboSupplierGenId","fld":"vCOMBOSUPPLIERGENID"},{"av":"AV30ComboSupplierAgbId","fld":"vCOMBOSUPPLIERAGBID"}]}""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED","""{"handler":"E12082","iparms":[{"av":"Combo_suppliergenid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED",""","oparms":[{"av":"AV30ComboSupplierAgbId","fld":"vCOMBOSUPPLIERAGBID"},{"av":"AV26ComboSupplierGenId","fld":"vCOMBOSUPPLIERGENID"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICENAME","""{"handler":"Valid_Productservicename","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICETILENAME","""{"handler":"Valid_Productservicetilename","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICECLASS","""{"handler":"Valid_Productserviceclass","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEGROUP","""{"handler":"Valid_Productservicegroup","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENID","""{"handler":"Valid_Suppliergenid","iparms":[{"av":"A42SupplierGenId","fld":"SUPPLIERGENID"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"}]""");
         setEventMetadata("VALID_SUPPLIERGENID",""","oparms":[{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"}]}""");
         setEventMetadata("VALID_SUPPLIERAGBID","""{"handler":"Valid_Supplieragbid","iparms":[{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"}]""");
         setEventMetadata("VALID_SUPPLIERAGBID",""","oparms":[{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"}]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENID","""{"handler":"Validv_Combosuppliergenid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERAGBID","""{"handler":"Validv_Combosupplieragbid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(20);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV12ProductServiceId = Guid.Empty;
         wcpOAV33LocationId = Guid.Empty;
         wcpOAV34OrganisationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z59ProductServiceName = "";
         Z301ProductServiceTileName = "";
         Z408ProductServiceClass = "";
         Z366ProductServiceGroup = "";
         Z42SupplierGenId = Guid.Empty;
         Z49SupplierAgbId = Guid.Empty;
         N42SupplierGenId = Guid.Empty;
         N49SupplierAgbId = Guid.Empty;
         Combo_supplieragbid_Selectedvalue_get = "";
         Combo_suppliergenid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         A49SupplierAgbId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A408ProductServiceClass = "";
         A366ProductServiceGroup = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A59ProductServiceName = "";
         A301ProductServiceTileName = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         sImgUrl = "";
         lblTextblocksuppliergenid_Jsonclick = "";
         ucCombo_suppliergenid = new GXUserControl();
         AV22DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21SupplierGenId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblocksupplieragbid_Jsonclick = "";
         ucCombo_supplieragbid = new GXUserControl();
         AV29SupplierAgbId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A60ProductServiceDescription = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV26ComboSupplierGenId = Guid.Empty;
         AV30ComboSupplierAgbId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         AV10Insert_SupplierGenId = Guid.Empty;
         AV9Insert_SupplierAgbId = Guid.Empty;
         A44SupplierGenCompanyName = "";
         A51SupplierAgbName = "";
         AV41Pgmname = "";
         Combo_suppliergenid_Objectcall = "";
         Combo_suppliergenid_Class = "";
         Combo_suppliergenid_Icontype = "";
         Combo_suppliergenid_Icon = "";
         Combo_suppliergenid_Tooltip = "";
         Combo_suppliergenid_Selectedvalue_set = "";
         Combo_suppliergenid_Selectedtext_set = "";
         Combo_suppliergenid_Selectedtext_get = "";
         Combo_suppliergenid_Gamoauthtoken = "";
         Combo_suppliergenid_Ddointernalname = "";
         Combo_suppliergenid_Titlecontrolalign = "";
         Combo_suppliergenid_Dropdownoptionstype = "";
         Combo_suppliergenid_Titlecontrolidtoreplace = "";
         Combo_suppliergenid_Datalisttype = "";
         Combo_suppliergenid_Datalistfixedvalues = "";
         Combo_suppliergenid_Remoteservicesparameters = "";
         Combo_suppliergenid_Htmltemplate = "";
         Combo_suppliergenid_Multiplevaluestype = "";
         Combo_suppliergenid_Loadingdata = "";
         Combo_suppliergenid_Noresultsfound = "";
         Combo_suppliergenid_Emptyitemtext = "";
         Combo_suppliergenid_Onlyselectedvalues = "";
         Combo_suppliergenid_Selectalltext = "";
         Combo_suppliergenid_Multiplevaluesseparator = "";
         Combo_suppliergenid_Addnewoptiontext = "";
         Combo_supplieragbid_Objectcall = "";
         Combo_supplieragbid_Class = "";
         Combo_supplieragbid_Icontype = "";
         Combo_supplieragbid_Icon = "";
         Combo_supplieragbid_Tooltip = "";
         Combo_supplieragbid_Selectedvalue_set = "";
         Combo_supplieragbid_Selectedtext_set = "";
         Combo_supplieragbid_Selectedtext_get = "";
         Combo_supplieragbid_Gamoauthtoken = "";
         Combo_supplieragbid_Ddointernalname = "";
         Combo_supplieragbid_Titlecontrolalign = "";
         Combo_supplieragbid_Dropdownoptionstype = "";
         Combo_supplieragbid_Titlecontrolidtoreplace = "";
         Combo_supplieragbid_Datalisttype = "";
         Combo_supplieragbid_Datalistfixedvalues = "";
         Combo_supplieragbid_Remoteservicesparameters = "";
         Combo_supplieragbid_Htmltemplate = "";
         Combo_supplieragbid_Multiplevaluestype = "";
         Combo_supplieragbid_Loadingdata = "";
         Combo_supplieragbid_Noresultsfound = "";
         Combo_supplieragbid_Emptyitemtext = "";
         Combo_supplieragbid_Onlyselectedvalues = "";
         Combo_supplieragbid_Selectalltext = "";
         Combo_supplieragbid_Multiplevaluesseparator = "";
         Combo_supplieragbid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode75 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV27GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV28GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV16TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV18WebSession = context.GetSession();
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV25Combo_DataJson = "";
         AV23ComboSelectedValue = "";
         AV24ComboSelectedText = "";
         GXt_char2 = "";
         Z60ProductServiceDescription = "";
         Z61ProductServiceImage = "";
         Z40000ProductServiceImage_GXI = "";
         Z44SupplierGenCompanyName = "";
         Z51SupplierAgbName = "";
         T00085_A44SupplierGenCompanyName = new string[] {""} ;
         T00086_A51SupplierAgbName = new string[] {""} ;
         T00087_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00087_A59ProductServiceName = new string[] {""} ;
         T00087_A301ProductServiceTileName = new string[] {""} ;
         T00087_A60ProductServiceDescription = new string[] {""} ;
         T00087_A408ProductServiceClass = new string[] {""} ;
         T00087_A40000ProductServiceImage_GXI = new string[] {""} ;
         T00087_A366ProductServiceGroup = new string[] {""} ;
         T00087_A44SupplierGenCompanyName = new string[] {""} ;
         T00087_A51SupplierAgbName = new string[] {""} ;
         T00087_A29LocationId = new Guid[] {Guid.Empty} ;
         T00087_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00087_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00087_n42SupplierGenId = new bool[] {false} ;
         T00087_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00087_n49SupplierAgbId = new bool[] {false} ;
         T00087_A61ProductServiceImage = new string[] {""} ;
         T00084_A29LocationId = new Guid[] {Guid.Empty} ;
         T00088_A29LocationId = new Guid[] {Guid.Empty} ;
         T00089_A44SupplierGenCompanyName = new string[] {""} ;
         T000810_A51SupplierAgbName = new string[] {""} ;
         T000811_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000811_A29LocationId = new Guid[] {Guid.Empty} ;
         T000811_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00083_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00083_A59ProductServiceName = new string[] {""} ;
         T00083_A301ProductServiceTileName = new string[] {""} ;
         T00083_A60ProductServiceDescription = new string[] {""} ;
         T00083_A408ProductServiceClass = new string[] {""} ;
         T00083_A40000ProductServiceImage_GXI = new string[] {""} ;
         T00083_A366ProductServiceGroup = new string[] {""} ;
         T00083_A29LocationId = new Guid[] {Guid.Empty} ;
         T00083_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00083_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00083_n42SupplierGenId = new bool[] {false} ;
         T00083_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00083_n49SupplierAgbId = new bool[] {false} ;
         T00083_A61ProductServiceImage = new string[] {""} ;
         T000812_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000812_A29LocationId = new Guid[] {Guid.Empty} ;
         T000812_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000813_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000813_A29LocationId = new Guid[] {Guid.Empty} ;
         T000813_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00082_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00082_A59ProductServiceName = new string[] {""} ;
         T00082_A301ProductServiceTileName = new string[] {""} ;
         T00082_A60ProductServiceDescription = new string[] {""} ;
         T00082_A408ProductServiceClass = new string[] {""} ;
         T00082_A40000ProductServiceImage_GXI = new string[] {""} ;
         T00082_A366ProductServiceGroup = new string[] {""} ;
         T00082_A29LocationId = new Guid[] {Guid.Empty} ;
         T00082_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00082_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00082_n42SupplierGenId = new bool[] {false} ;
         T00082_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00082_n49SupplierAgbId = new bool[] {false} ;
         T00082_A61ProductServiceImage = new string[] {""} ;
         T000818_A44SupplierGenCompanyName = new string[] {""} ;
         T000819_A51SupplierAgbName = new string[] {""} ;
         T000820_A367CallToActionId = new Guid[] {Guid.Empty} ;
         T000821_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000821_A29LocationId = new Guid[] {Guid.Empty} ;
         T000821_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         i366ProductServiceGroup = "";
         GXt_guid3 = Guid.Empty;
         T000822_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_productservice__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productservice__default(),
            new Object[][] {
                new Object[] {
               T00082_A58ProductServiceId, T00082_A59ProductServiceName, T00082_A301ProductServiceTileName, T00082_A60ProductServiceDescription, T00082_A408ProductServiceClass, T00082_A40000ProductServiceImage_GXI, T00082_A366ProductServiceGroup, T00082_A29LocationId, T00082_A11OrganisationId, T00082_A42SupplierGenId,
               T00082_n42SupplierGenId, T00082_A49SupplierAgbId, T00082_n49SupplierAgbId, T00082_A61ProductServiceImage
               }
               , new Object[] {
               T00083_A58ProductServiceId, T00083_A59ProductServiceName, T00083_A301ProductServiceTileName, T00083_A60ProductServiceDescription, T00083_A408ProductServiceClass, T00083_A40000ProductServiceImage_GXI, T00083_A366ProductServiceGroup, T00083_A29LocationId, T00083_A11OrganisationId, T00083_A42SupplierGenId,
               T00083_n42SupplierGenId, T00083_A49SupplierAgbId, T00083_n49SupplierAgbId, T00083_A61ProductServiceImage
               }
               , new Object[] {
               T00084_A29LocationId
               }
               , new Object[] {
               T00085_A44SupplierGenCompanyName
               }
               , new Object[] {
               T00086_A51SupplierAgbName
               }
               , new Object[] {
               T00087_A58ProductServiceId, T00087_A59ProductServiceName, T00087_A301ProductServiceTileName, T00087_A60ProductServiceDescription, T00087_A408ProductServiceClass, T00087_A40000ProductServiceImage_GXI, T00087_A366ProductServiceGroup, T00087_A44SupplierGenCompanyName, T00087_A51SupplierAgbName, T00087_A29LocationId,
               T00087_A11OrganisationId, T00087_A42SupplierGenId, T00087_n42SupplierGenId, T00087_A49SupplierAgbId, T00087_n49SupplierAgbId, T00087_A61ProductServiceImage
               }
               , new Object[] {
               T00088_A29LocationId
               }
               , new Object[] {
               T00089_A44SupplierGenCompanyName
               }
               , new Object[] {
               T000810_A51SupplierAgbName
               }
               , new Object[] {
               T000811_A58ProductServiceId, T000811_A29LocationId, T000811_A11OrganisationId
               }
               , new Object[] {
               T000812_A58ProductServiceId, T000812_A29LocationId, T000812_A11OrganisationId
               }
               , new Object[] {
               T000813_A58ProductServiceId, T000813_A29LocationId, T000813_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000818_A44SupplierGenCompanyName
               }
               , new Object[] {
               T000819_A51SupplierAgbName
               }
               , new Object[] {
               T000820_A367CallToActionId
               }
               , new Object[] {
               T000821_A58ProductServiceId, T000821_A29LocationId, T000821_A11OrganisationId
               }
               , new Object[] {
               T000822_A29LocationId
               }
            }
         );
         Z58ProductServiceId = Guid.NewGuid( );
         A58ProductServiceId = Guid.NewGuid( );
         AV41Pgmname = "Trn_ProductService";
         Z366ProductServiceGroup = "Location";
         A366ProductServiceGroup = "Location";
         i366ProductServiceGroup = "Location";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound75 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtProductServiceName_Enabled ;
      private int edtProductServiceTileName_Enabled ;
      private int imgProductServiceImage_Enabled ;
      private int divTablegen_Visible ;
      private int edtSupplierGenId_Visible ;
      private int edtSupplierGenId_Enabled ;
      private int divTableagb_Visible ;
      private int edtSupplierAgbId_Visible ;
      private int edtSupplierAgbId_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombosuppliergenid_Visible ;
      private int edtavCombosuppliergenid_Enabled ;
      private int edtavCombosupplieragbid_Visible ;
      private int edtavCombosupplieragbid_Enabled ;
      private int edtProductServiceId_Visible ;
      private int edtProductServiceId_Enabled ;
      private int edtLocationId_Visible ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int Combo_suppliergenid_Datalistupdateminimumcharacters ;
      private int Combo_suppliergenid_Gxcontroltype ;
      private int Combo_supplieragbid_Datalistupdateminimumcharacters ;
      private int Combo_supplieragbid_Gxcontroltype ;
      private int AV42GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z301ProductServiceTileName ;
      private string Combo_supplieragbid_Selectedvalue_get ;
      private string Combo_suppliergenid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProductServiceName_Internalname ;
      private string cmbProductServiceClass_Internalname ;
      private string cmbProductServiceGroup_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string TempTags ;
      private string edtProductServiceName_Jsonclick ;
      private string edtProductServiceTileName_Internalname ;
      private string A301ProductServiceTileName ;
      private string edtProductServiceTileName_Jsonclick ;
      private string imgProductServiceImage_Internalname ;
      private string sImgUrl ;
      private string divUnnamedtable3_Internalname ;
      private string cmbProductServiceClass_Jsonclick ;
      private string cmbProductServiceGroup_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divTablegen_Internalname ;
      private string divTablesplittedsuppliergenid_Internalname ;
      private string lblTextblocksuppliergenid_Internalname ;
      private string lblTextblocksuppliergenid_Jsonclick ;
      private string Combo_suppliergenid_Caption ;
      private string Combo_suppliergenid_Cls ;
      private string Combo_suppliergenid_Datalistproc ;
      private string Combo_suppliergenid_Datalistprocparametersprefix ;
      private string Combo_suppliergenid_Internalname ;
      private string edtSupplierGenId_Internalname ;
      private string edtSupplierGenId_Jsonclick ;
      private string divTableagb_Internalname ;
      private string divTablesplittedsupplieragbid_Internalname ;
      private string lblTextblocksupplieragbid_Internalname ;
      private string lblTextblocksupplieragbid_Jsonclick ;
      private string Combo_supplieragbid_Caption ;
      private string Combo_supplieragbid_Cls ;
      private string Combo_supplieragbid_Datalistproc ;
      private string Combo_supplieragbid_Datalistprocparametersprefix ;
      private string Combo_supplieragbid_Internalname ;
      private string edtSupplierAgbId_Internalname ;
      private string edtSupplierAgbId_Jsonclick ;
      private string edtProductServiceDescription_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_suppliergenid_Internalname ;
      private string edtavCombosuppliergenid_Internalname ;
      private string edtavCombosuppliergenid_Jsonclick ;
      private string divSectionattribute_supplieragbid_Internalname ;
      private string edtavCombosupplieragbid_Internalname ;
      private string edtavCombosupplieragbid_Jsonclick ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceId_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string AV41Pgmname ;
      private string Combo_suppliergenid_Objectcall ;
      private string Combo_suppliergenid_Class ;
      private string Combo_suppliergenid_Icontype ;
      private string Combo_suppliergenid_Icon ;
      private string Combo_suppliergenid_Tooltip ;
      private string Combo_suppliergenid_Selectedvalue_set ;
      private string Combo_suppliergenid_Selectedtext_set ;
      private string Combo_suppliergenid_Selectedtext_get ;
      private string Combo_suppliergenid_Gamoauthtoken ;
      private string Combo_suppliergenid_Ddointernalname ;
      private string Combo_suppliergenid_Titlecontrolalign ;
      private string Combo_suppliergenid_Dropdownoptionstype ;
      private string Combo_suppliergenid_Titlecontrolidtoreplace ;
      private string Combo_suppliergenid_Datalisttype ;
      private string Combo_suppliergenid_Datalistfixedvalues ;
      private string Combo_suppliergenid_Remoteservicesparameters ;
      private string Combo_suppliergenid_Htmltemplate ;
      private string Combo_suppliergenid_Multiplevaluestype ;
      private string Combo_suppliergenid_Loadingdata ;
      private string Combo_suppliergenid_Noresultsfound ;
      private string Combo_suppliergenid_Emptyitemtext ;
      private string Combo_suppliergenid_Onlyselectedvalues ;
      private string Combo_suppliergenid_Selectalltext ;
      private string Combo_suppliergenid_Multiplevaluesseparator ;
      private string Combo_suppliergenid_Addnewoptiontext ;
      private string Combo_supplieragbid_Objectcall ;
      private string Combo_supplieragbid_Class ;
      private string Combo_supplieragbid_Icontype ;
      private string Combo_supplieragbid_Icon ;
      private string Combo_supplieragbid_Tooltip ;
      private string Combo_supplieragbid_Selectedvalue_set ;
      private string Combo_supplieragbid_Selectedtext_set ;
      private string Combo_supplieragbid_Selectedtext_get ;
      private string Combo_supplieragbid_Gamoauthtoken ;
      private string Combo_supplieragbid_Ddointernalname ;
      private string Combo_supplieragbid_Titlecontrolalign ;
      private string Combo_supplieragbid_Dropdownoptionstype ;
      private string Combo_supplieragbid_Titlecontrolidtoreplace ;
      private string Combo_supplieragbid_Datalisttype ;
      private string Combo_supplieragbid_Datalistfixedvalues ;
      private string Combo_supplieragbid_Remoteservicesparameters ;
      private string Combo_supplieragbid_Htmltemplate ;
      private string Combo_supplieragbid_Multiplevaluestype ;
      private string Combo_supplieragbid_Loadingdata ;
      private string Combo_supplieragbid_Noresultsfound ;
      private string Combo_supplieragbid_Emptyitemtext ;
      private string Combo_supplieragbid_Onlyselectedvalues ;
      private string Combo_supplieragbid_Selectalltext ;
      private string Combo_supplieragbid_Multiplevaluesseparator ;
      private string Combo_supplieragbid_Addnewoptiontext ;
      private string hsh ;
      private string sMode75 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n42SupplierGenId ;
      private bool n49SupplierAgbId ;
      private bool wbErr ;
      private bool A61ProductServiceImage_IsBlob ;
      private bool Combo_suppliergenid_Enabled ;
      private bool Combo_suppliergenid_Visible ;
      private bool Combo_suppliergenid_Allowmultipleselection ;
      private bool Combo_suppliergenid_Isgriditem ;
      private bool Combo_suppliergenid_Hasdescription ;
      private bool Combo_suppliergenid_Includeonlyselectedoption ;
      private bool Combo_suppliergenid_Includeselectalloption ;
      private bool Combo_suppliergenid_Emptyitem ;
      private bool Combo_suppliergenid_Includeaddnewoption ;
      private bool Combo_supplieragbid_Enabled ;
      private bool Combo_supplieragbid_Visible ;
      private bool Combo_supplieragbid_Allowmultipleselection ;
      private bool Combo_supplieragbid_Isgriditem ;
      private bool Combo_supplieragbid_Hasdescription ;
      private bool Combo_supplieragbid_Includeonlyselectedoption ;
      private bool Combo_supplieragbid_Includeselectalloption ;
      private bool Combo_supplieragbid_Emptyitem ;
      private bool Combo_supplieragbid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A60ProductServiceDescription ;
      private string AV25Combo_DataJson ;
      private string Z60ProductServiceDescription ;
      private string Z59ProductServiceName ;
      private string Z408ProductServiceClass ;
      private string Z366ProductServiceGroup ;
      private string A408ProductServiceClass ;
      private string A366ProductServiceGroup ;
      private string A59ProductServiceName ;
      private string A40000ProductServiceImage_GXI ;
      private string A44SupplierGenCompanyName ;
      private string A51SupplierAgbName ;
      private string AV23ComboSelectedValue ;
      private string AV24ComboSelectedText ;
      private string Z40000ProductServiceImage_GXI ;
      private string Z44SupplierGenCompanyName ;
      private string Z51SupplierAgbName ;
      private string i366ProductServiceGroup ;
      private string A61ProductServiceImage ;
      private string Z61ProductServiceImage ;
      private Guid wcpOAV12ProductServiceId ;
      private Guid wcpOAV33LocationId ;
      private Guid wcpOAV34OrganisationId ;
      private Guid Z58ProductServiceId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid Z42SupplierGenId ;
      private Guid Z49SupplierAgbId ;
      private Guid N42SupplierGenId ;
      private Guid N49SupplierAgbId ;
      private Guid AV33LocationId ;
      private Guid AV34OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A42SupplierGenId ;
      private Guid A49SupplierAgbId ;
      private Guid AV12ProductServiceId ;
      private Guid AV26ComboSupplierGenId ;
      private Guid AV30ComboSupplierAgbId ;
      private Guid A58ProductServiceId ;
      private Guid AV10Insert_SupplierGenId ;
      private Guid AV9Insert_SupplierAgbId ;
      private Guid GXt_guid3 ;
      private IGxSession AV18WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_suppliergenid ;
      private GXUserControl ucCombo_supplieragbid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProductServiceClass ;
      private GXCombobox cmbProductServiceGroup ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV22DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV21SupplierGenId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29SupplierAgbId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV27GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV28GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV16TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00085_A44SupplierGenCompanyName ;
      private string[] T00086_A51SupplierAgbName ;
      private Guid[] T00087_A58ProductServiceId ;
      private string[] T00087_A59ProductServiceName ;
      private string[] T00087_A301ProductServiceTileName ;
      private string[] T00087_A60ProductServiceDescription ;
      private string[] T00087_A408ProductServiceClass ;
      private string[] T00087_A40000ProductServiceImage_GXI ;
      private string[] T00087_A366ProductServiceGroup ;
      private string[] T00087_A44SupplierGenCompanyName ;
      private string[] T00087_A51SupplierAgbName ;
      private Guid[] T00087_A29LocationId ;
      private Guid[] T00087_A11OrganisationId ;
      private Guid[] T00087_A42SupplierGenId ;
      private bool[] T00087_n42SupplierGenId ;
      private Guid[] T00087_A49SupplierAgbId ;
      private bool[] T00087_n49SupplierAgbId ;
      private string[] T00087_A61ProductServiceImage ;
      private Guid[] T00084_A29LocationId ;
      private Guid[] T00088_A29LocationId ;
      private string[] T00089_A44SupplierGenCompanyName ;
      private string[] T000810_A51SupplierAgbName ;
      private Guid[] T000811_A58ProductServiceId ;
      private Guid[] T000811_A29LocationId ;
      private Guid[] T000811_A11OrganisationId ;
      private Guid[] T00083_A58ProductServiceId ;
      private string[] T00083_A59ProductServiceName ;
      private string[] T00083_A301ProductServiceTileName ;
      private string[] T00083_A60ProductServiceDescription ;
      private string[] T00083_A408ProductServiceClass ;
      private string[] T00083_A40000ProductServiceImage_GXI ;
      private string[] T00083_A366ProductServiceGroup ;
      private Guid[] T00083_A29LocationId ;
      private Guid[] T00083_A11OrganisationId ;
      private Guid[] T00083_A42SupplierGenId ;
      private bool[] T00083_n42SupplierGenId ;
      private Guid[] T00083_A49SupplierAgbId ;
      private bool[] T00083_n49SupplierAgbId ;
      private string[] T00083_A61ProductServiceImage ;
      private Guid[] T000812_A58ProductServiceId ;
      private Guid[] T000812_A29LocationId ;
      private Guid[] T000812_A11OrganisationId ;
      private Guid[] T000813_A58ProductServiceId ;
      private Guid[] T000813_A29LocationId ;
      private Guid[] T000813_A11OrganisationId ;
      private Guid[] T00082_A58ProductServiceId ;
      private string[] T00082_A59ProductServiceName ;
      private string[] T00082_A301ProductServiceTileName ;
      private string[] T00082_A60ProductServiceDescription ;
      private string[] T00082_A408ProductServiceClass ;
      private string[] T00082_A40000ProductServiceImage_GXI ;
      private string[] T00082_A366ProductServiceGroup ;
      private Guid[] T00082_A29LocationId ;
      private Guid[] T00082_A11OrganisationId ;
      private Guid[] T00082_A42SupplierGenId ;
      private bool[] T00082_n42SupplierGenId ;
      private Guid[] T00082_A49SupplierAgbId ;
      private bool[] T00082_n49SupplierAgbId ;
      private string[] T00082_A61ProductServiceImage ;
      private string[] T000818_A44SupplierGenCompanyName ;
      private string[] T000819_A51SupplierAgbName ;
      private Guid[] T000820_A367CallToActionId ;
      private Guid[] T000821_A58ProductServiceId ;
      private Guid[] T000821_A29LocationId ;
      private Guid[] T000821_A11OrganisationId ;
      private Guid[] T000822_A29LocationId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_productservice__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_productservice__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00082;
        prmT00082 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00083;
        prmT00083 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00084;
        prmT00084 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00085;
        prmT00085 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00086;
        prmT00086 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00087;
        prmT00087 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00088;
        prmT00088 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00089;
        prmT00089 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000810;
        prmT000810 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000811;
        prmT000811 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000812;
        prmT000812 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000813;
        prmT000813 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000814;
        prmT000814 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ProductServiceName",GXType.VarChar,100,0) ,
        new ParDef("ProductServiceTileName",GXType.Char,20,0) ,
        new ParDef("ProductServiceDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("ProductServiceClass",GXType.VarChar,400,0) ,
        new ParDef("ProductServiceImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("ProductServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=5, Tbl="Trn_ProductService", Fld="ProductServiceImage"} ,
        new ParDef("ProductServiceGroup",GXType.VarChar,40,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000815;
        prmT000815 = new Object[] {
        new ParDef("ProductServiceName",GXType.VarChar,100,0) ,
        new ParDef("ProductServiceTileName",GXType.Char,20,0) ,
        new ParDef("ProductServiceDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("ProductServiceClass",GXType.VarChar,400,0) ,
        new ParDef("ProductServiceGroup",GXType.VarChar,40,0) ,
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000816;
        prmT000816 = new Object[] {
        new ParDef("ProductServiceImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("ProductServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_ProductService", Fld="ProductServiceImage"} ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000817;
        prmT000817 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000818;
        prmT000818 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000819;
        prmT000819 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000820;
        prmT000820 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000821;
        prmT000821 = new Object[] {
        };
        Object[] prmT000822;
        prmT000822 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00082", "SELECT ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceClass, ProductServiceImage_GXI, ProductServiceGroup, LocationId, OrganisationId, SupplierGenId, SupplierAgbId, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_ProductService NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00083", "SELECT ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceClass, ProductServiceImage_GXI, ProductServiceGroup, LocationId, OrganisationId, SupplierGenId, SupplierAgbId, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00084", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00085", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00086", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00087", "SELECT TM1.ProductServiceId, TM1.ProductServiceName, TM1.ProductServiceTileName, TM1.ProductServiceDescription, TM1.ProductServiceClass, TM1.ProductServiceImage_GXI, TM1.ProductServiceGroup, T2.SupplierGenCompanyName, T3.SupplierAgbName, TM1.LocationId, TM1.OrganisationId, TM1.SupplierGenId, TM1.SupplierAgbId, TM1.ProductServiceImage FROM ((Trn_ProductService TM1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = TM1.SupplierGenId) LEFT JOIN Trn_SupplierAGB T3 ON T3.SupplierAgbId = TM1.SupplierAgbId) WHERE TM1.ProductServiceId = :ProductServiceId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00088", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00089", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000810", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000811", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000812", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE ( ProductServiceId > :ProductServiceId or ProductServiceId = :ProductServiceId and LocationId > :LocationId or LocationId = :LocationId and ProductServiceId = :ProductServiceId and OrganisationId > :OrganisationId) ORDER BY ProductServiceId, LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000812,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000813", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE ( ProductServiceId < :ProductServiceId or ProductServiceId = :ProductServiceId and LocationId < :LocationId or LocationId = :LocationId and ProductServiceId = :ProductServiceId and OrganisationId < :OrganisationId) ORDER BY ProductServiceId DESC, LocationId DESC, OrganisationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000813,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000814", "SAVEPOINT gxupdate;INSERT INTO Trn_ProductService(ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceClass, ProductServiceImage, ProductServiceImage_GXI, ProductServiceGroup, LocationId, OrganisationId, SupplierGenId, SupplierAgbId) VALUES(:ProductServiceId, :ProductServiceName, :ProductServiceTileName, :ProductServiceDescription, :ProductServiceClass, :ProductServiceImage, :ProductServiceImage_GXI, :ProductServiceGroup, :LocationId, :OrganisationId, :SupplierGenId, :SupplierAgbId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000814)
           ,new CursorDef("T000815", "SAVEPOINT gxupdate;UPDATE Trn_ProductService SET ProductServiceName=:ProductServiceName, ProductServiceTileName=:ProductServiceTileName, ProductServiceDescription=:ProductServiceDescription, ProductServiceClass=:ProductServiceClass, ProductServiceGroup=:ProductServiceGroup, SupplierGenId=:SupplierGenId, SupplierAgbId=:SupplierAgbId  WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000815)
           ,new CursorDef("T000816", "SAVEPOINT gxupdate;UPDATE Trn_ProductService SET ProductServiceImage=:ProductServiceImage, ProductServiceImage_GXI=:ProductServiceImage_GXI  WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000816)
           ,new CursorDef("T000817", "SAVEPOINT gxupdate;DELETE FROM Trn_ProductService  WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000817)
           ,new CursorDef("T000818", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000818,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000819", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000819,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000820", "SELECT CallToActionId FROM Trn_CallToAction WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000820,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000821", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService ORDER BY ProductServiceId, LocationId, OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000821,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000822", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000822,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((Guid[]) buf[7])[0] = rslt.getGuid(8);
              ((Guid[]) buf[8])[0] = rslt.getGuid(9);
              ((Guid[]) buf[9])[0] = rslt.getGuid(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((Guid[]) buf[11])[0] = rslt.getGuid(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(6));
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((Guid[]) buf[7])[0] = rslt.getGuid(8);
              ((Guid[]) buf[8])[0] = rslt.getGuid(9);
              ((Guid[]) buf[9])[0] = rslt.getGuid(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((Guid[]) buf[11])[0] = rslt.getGuid(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(6));
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((Guid[]) buf[9])[0] = rslt.getGuid(10);
              ((Guid[]) buf[10])[0] = rslt.getGuid(11);
              ((Guid[]) buf[11])[0] = rslt.getGuid(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((Guid[]) buf[13])[0] = rslt.getGuid(13);
              ((bool[]) buf[14])[0] = rslt.wasNull(13);
              ((string[]) buf[15])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(6));
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 19 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 20 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
