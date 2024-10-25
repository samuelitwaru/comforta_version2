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
   public class prc_uploadmedia : GXProcedure
   {
      public prc_uploadmedia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_uploadmedia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MediaId ,
                           string aP1_MediaName ,
                           string aP2_MediaImageData ,
                           int aP3_MediaSize ,
                           string aP4_MediaType ,
                           out string aP5_response )
      {
         this.AV2MediaId = aP0_MediaId;
         this.AV3MediaName = aP1_MediaName;
         this.AV4MediaImageData = aP2_MediaImageData;
         this.AV5MediaSize = aP3_MediaSize;
         this.AV6MediaType = aP4_MediaType;
         this.AV7response = "" ;
         initialize();
         ExecuteImpl();
         aP5_response=this.AV7response;
      }

      public string executeUdp( Guid aP0_MediaId ,
                                string aP1_MediaName ,
                                string aP2_MediaImageData ,
                                int aP3_MediaSize ,
                                string aP4_MediaType )
      {
         execute(aP0_MediaId, aP1_MediaName, aP2_MediaImageData, aP3_MediaSize, aP4_MediaType, out aP5_response);
         return AV7response ;
      }

      public void executeSubmit( Guid aP0_MediaId ,
                                 string aP1_MediaName ,
                                 string aP2_MediaImageData ,
                                 int aP3_MediaSize ,
                                 string aP4_MediaType ,
                                 out string aP5_response )
      {
         this.AV2MediaId = aP0_MediaId;
         this.AV3MediaName = aP1_MediaName;
         this.AV4MediaImageData = aP2_MediaImageData;
         this.AV5MediaSize = aP3_MediaSize;
         this.AV6MediaType = aP4_MediaType;
         this.AV7response = "" ;
         SubmitImpl();
         aP5_response=this.AV7response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(Guid)AV2MediaId,(string)AV3MediaName,(string)AV4MediaImageData,(int)AV5MediaSize,(string)AV6MediaType,(string)AV7response} ;
         ClassLoader.Execute("aprc_uploadmedia","GeneXus.Programs","aprc_uploadmedia", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 6 ) )
         {
            AV7response = (string)(args[5]) ;
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
         AV7response = "";
         /* GeneXus formulas. */
      }

      private int AV5MediaSize ;
      private string AV6MediaType ;
      private string AV4MediaImageData ;
      private string AV7response ;
      private string AV3MediaName ;
      private Guid AV2MediaId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP5_response ;
   }

}
