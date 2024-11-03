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
   public class prc_createpage : GXProcedure
   {
      public prc_createpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_createpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PageName ,
                           ref string aP1_Response )
      {
         this.AV2PageName = aP0_PageName;
         this.AV3Response = aP1_Response;
         initialize();
         ExecuteImpl();
         aP1_Response=this.AV3Response;
      }

      public string executeUdp( string aP0_PageName )
      {
         execute(aP0_PageName, ref aP1_Response);
         return AV3Response ;
      }

      public void executeSubmit( string aP0_PageName ,
                                 ref string aP1_Response )
      {
         this.AV2PageName = aP0_PageName;
         this.AV3Response = aP1_Response;
         SubmitImpl();
         aP1_Response=this.AV3Response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2PageName,(string)AV3Response} ;
         ClassLoader.Execute("aprc_createpage","GeneXus.Programs","aprc_createpage", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV3Response = (string)(args[1]) ;
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
         /* GeneXus formulas. */
      }

      private string AV3Response ;
      private string AV2PageName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP1_Response ;
      private Object[] args ;
   }

}
