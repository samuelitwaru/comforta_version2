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
      }

      public api_toolboxservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
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

      public void gxep_getpages( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV10OrganisationId = aP1_OrganisationId;
         initialize();
         /* GetPages Constructor */
         new prc_getpages(context ).execute(  AV9LocationId,  AV10OrganisationId, out  AV11SDT_PageCollection) ;
         aP2_SDT_PageCollection=this.AV11SDT_PageCollection;
      }

      public void gxep_pagesapi( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_MobilePageCollection )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV10OrganisationId = aP1_OrganisationId;
         initialize();
         /* PagesAPI Constructor */
         new prc_pagesapi(context ).execute(  AV9LocationId,  AV10OrganisationId, out  AV27SDT_MobilePageCollection) ;
         aP2_SDT_MobilePageCollection=this.AV27SDT_MobilePageCollection;
      }

      public void gxep_contentpagesapi( Guid aP0_LocationId ,
                                        Guid aP1_OrganisationId ,
                                        out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV10OrganisationId = aP1_OrganisationId;
         initialize();
         /* ContentPagesAPI Constructor */
         new prc_contentpagesapi(context ).execute(  AV9LocationId,  AV10OrganisationId, out  AV26SDT_ContentPageCollection) ;
         aP2_SDT_ContentPageCollection=this.AV26SDT_ContentPageCollection;
      }

      public void gxep_getsinglepage( Guid aP0_PageId ,
                                      out SdtSDT_Page aP1_SDT_Page )
      {
         this.AV12PageId = aP0_PageId;
         initialize();
         /* GetSinglePage Constructor */
         new prc_getsinglepage(context ).execute(  AV12PageId, out  AV28SDT_Page) ;
         aP1_SDT_Page=this.AV28SDT_Page;
      }

      public void gxep_listpages( Guid aP0_LocationId ,
                                  Guid aP1_OrganisationId ,
                                  out GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV10OrganisationId = aP1_OrganisationId;
         initialize();
         /* ListPages Constructor */
         new prc_listpages(context ).execute(  AV9LocationId,  AV10OrganisationId, out  AV29SDT_PageStructureCollection) ;
         aP2_SDT_PageStructureCollection=this.AV29SDT_PageStructureCollection;
      }

      public void gxep_createpage( string aP0_PageName ,
                                   out string aP1_result )
      {
         this.AV30PageName = aP0_PageName;
         initialize();
         /* CreatePage Constructor */
         new prc_createpage(context ).execute(  AV30PageName, ref  AV17result) ;
         aP1_result=this.AV17result;
      }

      public void gxep_createcontentpage( Guid aP0_PageId ,
                                          out string aP1_result )
      {
         this.AV12PageId = aP0_PageId;
         initialize();
         /* CreateContentPage Constructor */
         new prc_createcontentpage(context ).execute(  AV12PageId, out  AV17result) ;
         aP1_result=this.AV17result;
      }

      public void gxep_savepage( Guid aP0_PageId ,
                                 string aP1_PageJsonContent ,
                                 string aP2_PageGJSHtml ,
                                 string aP3_PageGJSJson ,
                                 SdtSDT_Page aP4_SDT_Page ,
                                 out string aP5_result )
      {
         this.AV12PageId = aP0_PageId;
         this.AV13PageJsonContent = aP1_PageJsonContent;
         this.AV14PageGJSHtml = aP2_PageGJSHtml;
         this.AV15PageGJSJson = aP3_PageGJSJson;
         this.AV28SDT_Page = aP4_SDT_Page;
         initialize();
         /* SavePage Constructor */
         new prc_savepage(context ).execute(  AV12PageId,  AV13PageJsonContent,  AV14PageGJSHtml,  AV15PageGJSJson,  AV28SDT_Page, ref  AV17result) ;
         aP5_result=this.AV17result;
      }

      public void gxep_updatepage( Guid aP0_PageId ,
                                   string aP1_PageJsonContent ,
                                   string aP2_PageGJSHtml ,
                                   string aP3_PageGJSJson ,
                                   bool aP4_PageIsPublished ,
                                   out string aP5_result )
      {
         this.AV12PageId = aP0_PageId;
         this.AV13PageJsonContent = aP1_PageJsonContent;
         this.AV14PageGJSHtml = aP2_PageGJSHtml;
         this.AV15PageGJSJson = aP3_PageGJSJson;
         this.AV16PageIsPublished = aP4_PageIsPublished;
         initialize();
         /* UpdatePage Constructor */
         new prc_updatepage(context ).execute( ref  AV12PageId, ref  AV13PageJsonContent, ref  AV14PageGJSHtml, ref  AV15PageGJSJson, ref  AV16PageIsPublished, out  AV17result) ;
         aP5_result=this.AV17result;
      }

      public void gxep_addpagecildren( Guid aP0_ParentPageId ,
                                       Guid aP1_ChildPageId ,
                                       out string aP2_result )
      {
         this.AV18ParentPageId = aP0_ParentPageId;
         this.AV19ChildPageId = aP1_ChildPageId;
         initialize();
         /* AddPageCildren Constructor */
         new prc_addpagechildren(context ).execute(  AV18ParentPageId,  AV19ChildPageId, out  AV17result) ;
         aP2_result=this.AV17result;
      }

      public void gxep_updatelocationtheme( Guid aP0_ThemeId ,
                                            Guid aP1_LocationId ,
                                            Guid aP2_OrganisationId ,
                                            out SdtSDT_Theme aP3_SDT_Theme )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         initialize();
         /* UpdateLocationTheme Constructor */
         new prc_updatelocationtheme(context ).execute(  AV8ThemeId,  AV9LocationId,  AV10OrganisationId,  AV7SDT_Theme) ;
         aP3_SDT_Theme=this.AV7SDT_Theme;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV11SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         AV27SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version2");
         AV26SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version2");
         AV29SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV17result = "";
         AV7SDT_Theme = new SdtSDT_Theme(context);
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected bool AV16PageIsPublished ;
      protected string AV17result ;
      protected string AV13PageJsonContent ;
      protected string AV14PageGJSHtml ;
      protected string AV15PageGJSJson ;
      protected string AV30PageName ;
      protected Guid AV9LocationId ;
      protected Guid AV10OrganisationId ;
      protected Guid AV12PageId ;
      protected Guid AV18ParentPageId ;
      protected Guid AV19ChildPageId ;
      protected Guid AV8ThemeId ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GXBaseCollection<SdtSDT_Page> AV11SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> AV27SDT_MobilePageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> aP2_SDT_MobilePageCollection ;
      protected GXBaseCollection<SdtSDT_ContentPage> AV26SDT_ContentPageCollection ;
      protected GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
      protected SdtSDT_Page AV28SDT_Page ;
      protected SdtSDT_Page aP1_SDT_Page ;
      protected GXBaseCollection<SdtSDT_PageStructure> AV29SDT_PageStructureCollection ;
      protected GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageStructureCollection ;
      protected string aP1_result ;
      protected string aP5_result ;
      protected string aP2_result ;
      protected SdtSDT_Theme AV7SDT_Theme ;
      protected SdtSDT_Theme aP3_SDT_Theme ;
   }

}
