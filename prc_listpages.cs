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

      public void execute( out string aP0_response )
      {
         this.AV2response = "" ;
         initialize();
         ExecuteImpl();
         aP0_response=this.AV2response;
      }

      public string executeUdp( )
      {
         execute(out aP0_response);
         return AV2response ;
      }

      public void executeSubmit( out string aP0_response )
      {
         this.AV2response = "" ;
         SubmitImpl();
         aP0_response=this.AV2response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2response} ;
         ClassLoader.Execute("aprc_listpages","GeneXus.Programs","aprc_listpages", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2response = (string)(args[0]) ;
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
         AV2response = "";
         /* GeneXus formulas. */
      }

      private string AV2response ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP0_response ;
   }

}
