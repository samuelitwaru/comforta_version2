using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_getcalltoactionformurl : GXProcedure
   {
      public prc_getcalltoactionformurl( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getcalltoactionformurl( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref string aP0_CallToActionType ,
                           ref string aP1_WWPFormReferenceName ,
                           out string aP2_Url )
      {
         this.AV11CallToActionType = aP0_CallToActionType;
         this.AV10WWPFormReferenceName = aP1_WWPFormReferenceName;
         this.AV8Url = "" ;
         initialize();
         ExecuteImpl();
         aP0_CallToActionType=this.AV11CallToActionType;
         aP1_WWPFormReferenceName=this.AV10WWPFormReferenceName;
         aP2_Url=this.AV8Url;
      }

      public string executeUdp( ref string aP0_CallToActionType ,
                                ref string aP1_WWPFormReferenceName )
      {
         execute(ref aP0_CallToActionType, ref aP1_WWPFormReferenceName, out aP2_Url);
         return AV8Url ;
      }

      public void executeSubmit( ref string aP0_CallToActionType ,
                                 ref string aP1_WWPFormReferenceName ,
                                 out string aP2_Url )
      {
         this.AV11CallToActionType = aP0_CallToActionType;
         this.AV10WWPFormReferenceName = aP1_WWPFormReferenceName;
         this.AV8Url = "" ;
         SubmitImpl();
         aP0_CallToActionType=this.AV11CallToActionType;
         aP1_WWPFormReferenceName=this.AV10WWPFormReferenceName;
         aP2_Url=this.AV8Url;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV11CallToActionType, "Form") == 0 )
         {
            AV8Url = AV9HttpRequest.BaseURL + "wp_residentdynamicform.aspx?WWPFormReferenceName=" + AV10WWPFormReferenceName + "&WWPFormInstanceId=0&WWPDynamicFormMode=INS";
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
         ExitApp();
      }

      public override void initialize( )
      {
         AV8Url = "";
         AV9HttpRequest = new GxHttpRequest( context);
         /* GeneXus formulas. */
      }

      private string AV11CallToActionType ;
      private string AV10WWPFormReferenceName ;
      private string AV8Url ;
      private GxHttpRequest AV9HttpRequest ;
      private string aP0_CallToActionType ;
      private string aP1_WWPFormReferenceName ;
      private string aP2_Url ;
   }

}
