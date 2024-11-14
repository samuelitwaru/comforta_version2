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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_listpages : GXProcedure
   {
      public prc_listpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_listpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           out GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageCollection )
      {
         this.AV2LocationId = aP0_LocationId;
         this.AV3OrganisationId = aP1_OrganisationId;
         this.AV4SDT_PageCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP2_SDT_PageCollection=this.AV4SDT_PageCollection;
      }

      public GXBaseCollection<SdtSDT_PageStructure> executeUdp( Guid aP0_LocationId ,
                                                                Guid aP1_OrganisationId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, out aP2_SDT_PageCollection);
         return AV4SDT_PageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageCollection )
      {
         this.AV2LocationId = aP0_LocationId;
         this.AV3OrganisationId = aP1_OrganisationId;
         this.AV4SDT_PageCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2") ;
         SubmitImpl();
         aP2_SDT_PageCollection=this.AV4SDT_PageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2LocationId,(Guid)AV3OrganisationId,(GXBaseCollection<SdtSDT_PageStructure>)AV4SDT_PageCollection} ;
         ClassLoader.Execute("aprc_listpages","GeneXus.Programs","aprc_listpages", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV4SDT_PageCollection = (GXBaseCollection<SdtSDT_PageStructure>)(args[2]) ;
         }
         cleanup();
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
         AV4SDT_PageCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         /* GeneXus formulas. */
      }

      private Guid AV2LocationId ;
      private Guid AV3OrganisationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_PageStructure> AV4SDT_PageCollection ;
      private Object[] args ;
      private GXBaseCollection<SdtSDT_PageStructure> aP2_SDT_PageCollection ;
   }

}
