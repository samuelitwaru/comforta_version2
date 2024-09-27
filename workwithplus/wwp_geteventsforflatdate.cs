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
namespace GeneXus.Programs.workwithplus {
   public class wwp_geteventsforflatdate : GXProcedure
   {
      public wwp_geteventsforflatdate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_geteventsforflatdate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP0_Events ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           string aP3_EventsStyle ,
                           out GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP4_WWPDateRangePickerOptions )
      {
         this.AV13Events = aP0_Events;
         this.AV21FromDate = aP1_FromDate;
         this.AV22ToDate = aP2_ToDate;
         this.AV14EventsStyle = aP3_EventsStyle;
         this.AV20WWPDateRangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context) ;
         initialize();
         ExecuteImpl();
         aP4_WWPDateRangePickerOptions=this.AV20WWPDateRangePickerOptions;
      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions executeUdp( GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP0_Events ,
                                                                                      DateTime aP1_FromDate ,
                                                                                      DateTime aP2_ToDate ,
                                                                                      string aP3_EventsStyle )
      {
         execute(aP0_Events, aP1_FromDate, aP2_ToDate, aP3_EventsStyle, out aP4_WWPDateRangePickerOptions);
         return AV20WWPDateRangePickerOptions ;
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP0_Events ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 string aP3_EventsStyle ,
                                 out GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP4_WWPDateRangePickerOptions )
      {
         this.AV13Events = aP0_Events;
         this.AV21FromDate = aP1_FromDate;
         this.AV22ToDate = aP2_ToDate;
         this.AV14EventsStyle = aP3_EventsStyle;
         this.AV20WWPDateRangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context) ;
         SubmitImpl();
         aP4_WWPDateRangePickerOptions=this.AV20WWPDateRangePickerOptions;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         AV20WWPDateRangePickerOptions = new GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions(context);
         /* GeneXus formulas. */
      }

      private DateTime AV21FromDate ;
      private DateTime AV22ToDate ;
      private string AV14EventsStyle ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> AV13Events ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions AV20WWPDateRangePickerOptions ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPDateRangePickerOptions aP4_WWPDateRangePickerOptions ;
   }

}
