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
namespace GeneXus.Programs.workwithplus {
   public class wwp_calendar_editevent : GXProcedure
   {
      public wwp_calendar_editevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_editevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_Title ,
                           DateTime aP2_Date ,
                           DateTime aP3_FromTime ,
                           DateTime aP4_ToTime ,
                           bool aP5_AllDay ,
                           DateTime aP6_EndDate ,
                           string aP7_CalendarEventId ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP8_ErrorMessages ,
                           out bool aP9_EventCreated )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV20Title = aP1_Title;
         this.AV11Date = aP2_Date;
         this.AV18FromTime = aP3_FromTime;
         this.AV21ToTime = aP4_ToTime;
         this.AV8AllDay = aP5_AllDay;
         this.AV12EndDate = aP6_EndDate;
         this.AV10CalendarEventId = aP7_CalendarEventId;
         this.AV13ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV14EventCreated = false ;
         initialize();
         ExecuteImpl();
         aP8_ErrorMessages=this.AV13ErrorMessages;
         aP9_EventCreated=this.AV14EventCreated;
      }

      public bool executeUdp( string aP0_Gx_mode ,
                              string aP1_Title ,
                              DateTime aP2_Date ,
                              DateTime aP3_FromTime ,
                              DateTime aP4_ToTime ,
                              bool aP5_AllDay ,
                              DateTime aP6_EndDate ,
                              string aP7_CalendarEventId ,
                              out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP8_ErrorMessages )
      {
         execute(aP0_Gx_mode, aP1_Title, aP2_Date, aP3_FromTime, aP4_ToTime, aP5_AllDay, aP6_EndDate, aP7_CalendarEventId, out aP8_ErrorMessages, out aP9_EventCreated);
         return AV14EventCreated ;
      }

      public void executeSubmit( string aP0_Gx_mode ,
                                 string aP1_Title ,
                                 DateTime aP2_Date ,
                                 DateTime aP3_FromTime ,
                                 DateTime aP4_ToTime ,
                                 bool aP5_AllDay ,
                                 DateTime aP6_EndDate ,
                                 string aP7_CalendarEventId ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP8_ErrorMessages ,
                                 out bool aP9_EventCreated )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV20Title = aP1_Title;
         this.AV11Date = aP2_Date;
         this.AV18FromTime = aP3_FromTime;
         this.AV21ToTime = aP4_ToTime;
         this.AV8AllDay = aP5_AllDay;
         this.AV12EndDate = aP6_EndDate;
         this.AV10CalendarEventId = aP7_CalendarEventId;
         this.AV13ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV14EventCreated = false ;
         SubmitImpl();
         aP8_ErrorMessages=this.AV13ErrorMessages;
         aP9_EventCreated=this.AV14EventCreated;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV8AllDay )
         {
            AV17EventStartDate = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV11Date)), (short)(DateTimeUtil.Month( AV11Date)), (short)(DateTimeUtil.Day( AV11Date)), 0, 0, 0);
            AV15EventEndDate = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV12EndDate)), (short)(DateTimeUtil.Month( AV12EndDate)), (short)(DateTimeUtil.Day( AV12EndDate)), 0, 0, 0);
         }
         else
         {
            AV17EventStartDate = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV11Date)), (short)(DateTimeUtil.Month( AV11Date)), (short)(DateTimeUtil.Day( AV11Date)), (short)(DateTimeUtil.Hour( AV18FromTime)), (short)(DateTimeUtil.Minute( AV18FromTime)), 0);
            AV15EventEndDate = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV12EndDate)), (short)(DateTimeUtil.Month( AV12EndDate)), (short)(DateTimeUtil.Day( AV12EndDate)), (short)(DateTimeUtil.Hour( AV21ToTime)), (short)(DateTimeUtil.Minute( AV21ToTime)), 0);
         }
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV19Message.gxTpr_Description = context.GetMessage( "In order to add events, you need to add the code in the procedures that are in WorkWithPlus Module / UCCalendar / CalendarUser folder", "");
         AV13ErrorMessages.Add(AV19Message, 0);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV9CalendarEventGUID = StringUtil.StrToGuid( AV10CalendarEventId);
            AV22Trn_AgendCalendar.Load(AV9CalendarEventGUID);
         }
         else
         {
         }
         AV22Trn_AgendCalendar.gxTpr_Agendacalendarallday = AV8AllDay;
         GXt_guid1 = Guid.Empty;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV22Trn_AgendCalendar.gxTpr_Locationid = GXt_guid1;
         AV22Trn_AgendCalendar.gxTpr_Agendacalendarstartdate = AV17EventStartDate;
         AV22Trn_AgendCalendar.gxTpr_Agendacalendarenddate = AV15EventEndDate;
         AV22Trn_AgendCalendar.gxTpr_Agendacalendartitle = AV20Title;
         AV22Trn_AgendCalendar.Save();
         if ( AV22Trn_AgendCalendar.Success() )
         {
            context.CommitDataStores("workwithplus.wwp_calendar_editevent",pr_default);
            AV14EventCreated = true;
         }
         else
         {
            AV13ErrorMessages = AV22Trn_AgendCalendar.GetMessages();
            context.RollbackDataStores("workwithplus.wwp_calendar_editevent",pr_default);
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
         AV13ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17EventStartDate = (DateTime)(DateTime.MinValue);
         AV15EventEndDate = (DateTime)(DateTime.MinValue);
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV9CalendarEventGUID = Guid.Empty;
         AV22Trn_AgendCalendar = new SdtTrn_AgendaCalendar(context);
         GXt_guid1 = Guid.Empty;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_editevent__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_editevent__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string Gx_mode ;
      private DateTime AV18FromTime ;
      private DateTime AV21ToTime ;
      private DateTime AV17EventStartDate ;
      private DateTime AV15EventEndDate ;
      private DateTime AV11Date ;
      private DateTime AV12EndDate ;
      private bool AV8AllDay ;
      private bool AV14EventCreated ;
      private string AV20Title ;
      private string AV10CalendarEventId ;
      private Guid AV9CalendarEventGUID ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13ErrorMessages ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private SdtTrn_AgendaCalendar AV22Trn_AgendCalendar ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP8_ErrorMessages ;
      private bool aP9_EventCreated ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_calendar_editevent__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class wwp_calendar_editevent__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
