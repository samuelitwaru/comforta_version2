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
   public class prc_addpagechildren : GXProcedure
   {
      public prc_addpagechildren( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_addpagechildren( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ParentPageId ,
                           Guid aP1_ChildPageId ,
                           out string aP2_response )
      {
         this.AV2ParentPageId = aP0_ParentPageId;
         this.AV3ChildPageId = aP1_ChildPageId;
         this.AV4response = "" ;
         initialize();
         ExecuteImpl();
         aP2_response=this.AV4response;
      }

      public string executeUdp( Guid aP0_ParentPageId ,
                                Guid aP1_ChildPageId )
      {
         execute(aP0_ParentPageId, aP1_ChildPageId, out aP2_response);
         return AV4response ;
      }

      public void executeSubmit( Guid aP0_ParentPageId ,
                                 Guid aP1_ChildPageId ,
                                 out string aP2_response )
      {
         this.AV2ParentPageId = aP0_ParentPageId;
         this.AV3ChildPageId = aP1_ChildPageId;
         this.AV4response = "" ;
         SubmitImpl();
         aP2_response=this.AV4response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2ParentPageId,(Guid)AV3ChildPageId,(string)AV4response} ;
         ClassLoader.Execute("aprc_addpagechildren","GeneXus.Programs","aprc_addpagechildren", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV4response = (string)(args[2]) ;
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
         AV4response = "";
         /* GeneXus formulas. */
      }

      private string AV4response ;
      private Guid AV2ParentPageId ;
      private Guid AV3ChildPageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP2_response ;
   }

}
