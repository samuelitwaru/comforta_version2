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
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_saveformdefinition : GXProcedure
   {
      public wwp_df_saveformdefinition( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_saveformdefinition( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_SessionId ,
                           GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP1_WWPForm )
      {
         this.AV8SessionId = aP0_SessionId;
         this.AV10WWPForm = aP1_WWPForm;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( int aP0_SessionId ,
                                 GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP1_WWPForm )
      {
         this.AV8SessionId = aP0_SessionId;
         this.AV10WWPForm = aP1_WWPForm;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9WebSession.Set(StringUtil.Format( "WWP_DynamicFormDef_%1", StringUtil.Trim( StringUtil.Str( (decimal)(AV8SessionId), 6, 0)), "", "", "", "", "", "", "", ""), AV10WWPForm.ToJSonString(true, true));
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
         AV9WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private int AV8SessionId ;
      private IGxSession AV9WebSession ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV10WWPForm ;
   }

}