using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class api_toolboxservice : GXProcedure
   {
      public api_toolboxservice( )
      {
         context = new GxContext(  );
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
         initialize();
      }

      public api_toolboxservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         initialize();
         if ( context.HttpContext != null )
         {
            Gx_restmethod = (string)(context.HttpContext.Request.Method);
         }
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void InitLocation( )
      {
         restLocation = new GxLocation();
         restLocation.Host = "localhost";
         restLocation.Port = 8082;
         restLocation.BaseUrl = "staging.comforta.yukon.software/api";
         gxProperties = new GxObjectProperties();
      }

      public GxObjectProperties ObjProperties
      {
         get {
            return gxProperties ;
         }

         set {
            gxProperties = value ;
         }

      }

      public void SetObjectProperties( GxObjectProperties gxobjppt )
      {
         gxProperties = gxobjppt ;
         restLocation = gxobjppt.Location ;
      }

      public void gxep_getpages( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         restCliGetPages = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages/list2";
         restCliGetPages.Location = restLocation;
         restCliGetPages.HttpMethod = "GET";
         restCliGetPages.AddQueryVar("Locationid", (Guid)(aP0_LocationId));
         restCliGetPages.AddQueryVar("Organisationid", (Guid)(aP1_OrganisationId));
         restCliGetPages.RestExecute();
         if ( restCliGetPages.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetPages.ErrorCode;
            gxProperties.ErrorMessage = restCliGetPages.ErrorMessage;
            gxProperties.StatusCode = restCliGetPages.StatusCode;
            aP2_SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>();
         }
         else
         {
            aP2_SDT_PageCollection = restCliGetPages.GetBodySdtCollection<SdtSDT_Page>("SDT_PageCollection");
         }
         /* GetPages Constructor */
      }

      public void gxep_pagesapi( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_MobilePageCollection )
      {
         restCliPagesAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages";
         restCliPagesAPI.Location = restLocation;
         restCliPagesAPI.HttpMethod = "GET";
         restCliPagesAPI.AddQueryVar("Locationid", (Guid)(aP0_LocationId));
         restCliPagesAPI.AddQueryVar("Organisationid", (Guid)(aP1_OrganisationId));
         restCliPagesAPI.RestExecute();
         if ( restCliPagesAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliPagesAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliPagesAPI.ErrorMessage;
            gxProperties.StatusCode = restCliPagesAPI.StatusCode;
            aP2_SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>();
         }
         else
         {
            aP2_SDT_MobilePageCollection = restCliPagesAPI.GetBodySdtCollection<SdtSDT_MobilePage>("SDT_MobilePageCollection");
         }
         /* PagesAPI Constructor */
      }

      public void gxep_contentpagesapi( Guid aP0_LocationId ,
                                        Guid aP1_OrganisationId ,
                                        out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         restCliContentPagesAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/content-pages";
         restCliContentPagesAPI.Location = restLocation;
         restCliContentPagesAPI.HttpMethod = "GET";
         restCliContentPagesAPI.AddQueryVar("Locationid", (Guid)(aP0_LocationId));
         restCliContentPagesAPI.AddQueryVar("Organisationid", (Guid)(aP1_OrganisationId));
         restCliContentPagesAPI.RestExecute();
         if ( restCliContentPagesAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliContentPagesAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliContentPagesAPI.ErrorMessage;
            gxProperties.StatusCode = restCliContentPagesAPI.StatusCode;
            aP2_SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>();
         }
         else
         {
            aP2_SDT_ContentPageCollection = restCliContentPagesAPI.GetBodySdtCollection<SdtSDT_ContentPage>("SDT_ContentPageCollection");
         }
         /* ContentPagesAPI Constructor */
      }

      public void gxep_getsinglepage( Guid aP0_PageId ,
                                      out SdtSDT_Page aP1_SDT_Page )
      {
         restCliGetSinglePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/singlepage";
         restCliGetSinglePage.Location = restLocation;
         restCliGetSinglePage.HttpMethod = "GET";
         restCliGetSinglePage.AddQueryVar("Pageid", (Guid)(aP0_PageId));
         restCliGetSinglePage.RestExecute();
         if ( restCliGetSinglePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetSinglePage.ErrorCode;
            gxProperties.ErrorMessage = restCliGetSinglePage.ErrorMessage;
            gxProperties.StatusCode = restCliGetSinglePage.StatusCode;
            aP1_SDT_Page = new SdtSDT_Page();
         }
         else
         {
            aP1_SDT_Page = restCliGetSinglePage.GetBodySdt<SdtSDT_Page>("SDT_Page");
         }
         /* GetSinglePage Constructor */
      }

      public void gxep_listpages( Guid aP0_LocationId ,
                                  Guid aP1_OrganisationId ,
                                  out GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection )
      {
         restCliListPages = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages/list";
         restCliListPages.Location = restLocation;
         restCliListPages.HttpMethod = "GET";
         restCliListPages.AddQueryVar("Locationid", (Guid)(aP0_LocationId));
         restCliListPages.AddQueryVar("Organisationid", (Guid)(aP1_OrganisationId));
         restCliListPages.RestExecute();
         if ( restCliListPages.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliListPages.ErrorCode;
            gxProperties.ErrorMessage = restCliListPages.ErrorMessage;
            gxProperties.StatusCode = restCliListPages.StatusCode;
            aP2_SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>();
         }
         else
         {
            aP2_SDT_PageStructureCollection = restCliListPages.GetBodySdtCollection<SdtSDT_PageStructure>("SDT_PageStructureCollection");
         }
         /* ListPages Constructor */
      }

      public void gxep_createpage( string aP0_PageName ,
                                   out string aP1_result )
      {
         restCliCreatePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/create-page";
         restCliCreatePage.Location = restLocation;
         restCliCreatePage.HttpMethod = "POST";
         restCliCreatePage.AddBodyVar("PageName", (string)(aP0_PageName));
         restCliCreatePage.RestExecute();
         if ( restCliCreatePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreatePage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreatePage.ErrorMessage;
            gxProperties.StatusCode = restCliCreatePage.StatusCode;
            aP1_result = "";
         }
         else
         {
            aP1_result = restCliCreatePage.GetBodyString("result");
         }
         /* CreatePage Constructor */
      }

      public void gxep_createcontentpage( Guid aP0_PageId ,
                                          out string aP1_result )
      {
         restCliCreateContentPage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/create-content-page";
         restCliCreateContentPage.Location = restLocation;
         restCliCreateContentPage.HttpMethod = "POST";
         restCliCreateContentPage.AddBodyVar("PageId", (Guid)(aP0_PageId));
         restCliCreateContentPage.RestExecute();
         if ( restCliCreateContentPage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreateContentPage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreateContentPage.ErrorMessage;
            gxProperties.StatusCode = restCliCreateContentPage.StatusCode;
            aP1_result = "";
         }
         else
         {
            aP1_result = restCliCreateContentPage.GetBodyString("result");
         }
         /* CreateContentPage Constructor */
      }

      public void gxep_savepage( Guid aP0_PageId ,
                                 string aP1_PageJsonContent ,
                                 string aP2_PageGJSHtml ,
                                 string aP3_PageGJSJson ,
                                 SdtSDT_Page aP4_SDT_Page ,
                                 out string aP5_result )
      {
         restCliSavePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/save-page";
         restCliSavePage.Location = restLocation;
         restCliSavePage.HttpMethod = "POST";
         restCliSavePage.AddBodyVar("PageId", (Guid)(aP0_PageId));
         restCliSavePage.AddBodyVar("PageJsonContent", (string)(aP1_PageJsonContent));
         restCliSavePage.AddBodyVar("PageGJSHtml", (string)(aP2_PageGJSHtml));
         restCliSavePage.AddBodyVar("PageGJSJson", (string)(aP3_PageGJSJson));
         restCliSavePage.AddBodyVar("SDT_Page", aP4_SDT_Page);
         restCliSavePage.RestExecute();
         if ( restCliSavePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSavePage.ErrorCode;
            gxProperties.ErrorMessage = restCliSavePage.ErrorMessage;
            gxProperties.StatusCode = restCliSavePage.StatusCode;
            aP5_result = "";
         }
         else
         {
            aP5_result = restCliSavePage.GetBodyString("result");
         }
         /* SavePage Constructor */
      }

      public void gxep_updatepage( Guid aP0_PageId ,
                                   string aP1_PageJsonContent ,
                                   string aP2_PageGJSHtml ,
                                   string aP3_PageGJSJson ,
                                   bool aP4_PageIsPublished ,
                                   out string aP5_result )
      {
         restCliUpdatePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/update-page";
         restCliUpdatePage.Location = restLocation;
         restCliUpdatePage.HttpMethod = "POST";
         restCliUpdatePage.AddBodyVar("PageId", (Guid)(aP0_PageId));
         restCliUpdatePage.AddBodyVar("PageJsonContent", (string)(aP1_PageJsonContent));
         restCliUpdatePage.AddBodyVar("PageGJSHtml", (string)(aP2_PageGJSHtml));
         restCliUpdatePage.AddBodyVar("PageGJSJson", (string)(aP3_PageGJSJson));
         restCliUpdatePage.AddBodyVar("PageIsPublished", aP4_PageIsPublished);
         restCliUpdatePage.RestExecute();
         if ( restCliUpdatePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdatePage.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdatePage.ErrorMessage;
            gxProperties.StatusCode = restCliUpdatePage.StatusCode;
            aP5_result = "";
         }
         else
         {
            aP5_result = restCliUpdatePage.GetBodyString("result");
         }
         /* UpdatePage Constructor */
      }

      public void gxep_addpagecildren( Guid aP0_ParentPageId ,
                                       Guid aP1_ChildPageId ,
                                       out string aP2_result )
      {
         restCliAddPageCildren = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/add-page-children";
         restCliAddPageCildren.Location = restLocation;
         restCliAddPageCildren.HttpMethod = "POST";
         restCliAddPageCildren.AddBodyVar("ParentPageId", (Guid)(aP0_ParentPageId));
         restCliAddPageCildren.AddBodyVar("ChildPageId", (Guid)(aP1_ChildPageId));
         restCliAddPageCildren.RestExecute();
         if ( restCliAddPageCildren.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliAddPageCildren.ErrorCode;
            gxProperties.ErrorMessage = restCliAddPageCildren.ErrorMessage;
            gxProperties.StatusCode = restCliAddPageCildren.StatusCode;
            aP2_result = "";
         }
         else
         {
            aP2_result = restCliAddPageCildren.GetBodyString("result");
         }
         /* AddPageCildren Constructor */
      }

      public void gxep_updatelocationtheme( Guid aP0_ThemeId ,
                                            Guid aP1_LocationId ,
                                            Guid aP2_OrganisationId ,
                                            out SdtSDT_Theme aP3_SDT_Theme )
      {
         restCliUpdateLocationTheme = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "toolbox/update-location-theme/";
         restCliUpdateLocationTheme.Location = restLocation;
         restCliUpdateLocationTheme.HttpMethod = "POST";
         restCliUpdateLocationTheme.AddBodyVar("ThemeId", (Guid)(aP0_ThemeId));
         restCliUpdateLocationTheme.AddBodyVar("LocationId", (Guid)(aP1_LocationId));
         restCliUpdateLocationTheme.AddBodyVar("OrganisationId", (Guid)(aP2_OrganisationId));
         restCliUpdateLocationTheme.RestExecute();
         if ( restCliUpdateLocationTheme.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdateLocationTheme.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdateLocationTheme.ErrorMessage;
            gxProperties.StatusCode = restCliUpdateLocationTheme.StatusCode;
            aP3_SDT_Theme = new SdtSDT_Theme();
         }
         else
         {
            aP3_SDT_Theme = restCliUpdateLocationTheme.GetBodySdt<SdtSDT_Theme>("SDT_Theme");
         }
         /* UpdateLocationTheme Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         gxProperties = new GxObjectProperties();
         restCliGetPages = new GXRestAPIClient();
         aP2_SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>();
         restCliPagesAPI = new GXRestAPIClient();
         aP2_SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>();
         restCliContentPagesAPI = new GXRestAPIClient();
         aP2_SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>();
         restCliGetSinglePage = new GXRestAPIClient();
         aP1_SDT_Page = new SdtSDT_Page();
         restCliListPages = new GXRestAPIClient();
         aP2_SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>();
         restCliCreatePage = new GXRestAPIClient();
         aP1_result = "";
         restCliCreateContentPage = new GXRestAPIClient();
         restCliSavePage = new GXRestAPIClient();
         aP5_result = "";
         restCliUpdatePage = new GXRestAPIClient();
         restCliAddPageCildren = new GXRestAPIClient();
         aP2_result = "";
         restCliUpdateLocationTheme = new GXRestAPIClient();
         aP3_SDT_Theme = new SdtSDT_Theme();
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliGetPages ;
      protected GXRestAPIClient restCliPagesAPI ;
      protected GXRestAPIClient restCliContentPagesAPI ;
      protected GXRestAPIClient restCliGetSinglePage ;
      protected GXRestAPIClient restCliListPages ;
      protected GXRestAPIClient restCliCreatePage ;
      protected GXRestAPIClient restCliCreateContentPage ;
      protected GXRestAPIClient restCliSavePage ;
      protected GXRestAPIClient restCliUpdatePage ;
      protected GXRestAPIClient restCliAddPageCildren ;
      protected GXRestAPIClient restCliUpdateLocationTheme ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_MobilePageCollection ;
      protected GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
      protected SdtSDT_Page aP1_SDT_Page ;
      protected GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection ;
      protected string aP1_result ;
      protected string aP5_result ;
      protected string aP2_result ;
      protected SdtSDT_Theme aP3_SDT_Theme ;
   }

}
