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
   public class prc_pagesapi : GXProcedure
   {
      public prc_pagesapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_pagesapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_Trn_PageId ,
                           out string aP1_response )
      {
         this.AV2Trn_PageId = aP0_Trn_PageId;
         this.AV3response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV3response;
      }

      public string executeUdp( Guid aP0_Trn_PageId )
      {
         execute(aP0_Trn_PageId, out aP1_response);
         return AV3response ;
      }

      public void executeSubmit( Guid aP0_Trn_PageId ,
                                 out string aP1_response )
      {
         this.AV2Trn_PageId = aP0_Trn_PageId;
         this.AV3response = "" ;
         SubmitImpl();
         aP1_response=this.AV3response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2Trn_PageId,(string)AV3response} ;
         ClassLoader.Execute("aprc_pagesapi","GeneXus.Programs","aprc_pagesapi", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV3response = (string)(args[1]) ;
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
         AV3response = "";
         /* GeneXus formulas. */
      }

      private string AV3response ;
      private Guid AV2Trn_PageId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP1_response ;
   }

}
