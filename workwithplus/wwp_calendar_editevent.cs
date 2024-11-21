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
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_editevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
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
                           string aP8_EventType ,
                           bool aP9_RecurringEvent ,
                           string aP10_RecuringEventType ,
                           bool aP11_AddRSVP ,
                           GxSimpleCollection<Guid> aP12_AddressGroup ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP13_ErrorMessages ,
                           out bool aP14_EventCreated )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV20Title = aP1_Title;
         this.AV11Date = aP2_Date;
         this.AV18FromTime = aP3_FromTime;
         this.AV21ToTime = aP4_ToTime;
         this.AV8AllDay = aP5_AllDay;
         this.AV12EndDate = aP6_EndDate;
         this.AV10CalendarEventId = aP7_CalendarEventId;
         this.AV28EventType = aP8_EventType;
         this.AV25RecurringEvent = aP9_RecurringEvent;
         this.AV27RecuringEventType = aP10_RecuringEventType;
         this.AV26AddRSVP = aP11_AddRSVP;
         this.AV30AddressGroup = aP12_AddressGroup;
         this.AV13ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV14EventCreated = false ;
         initialize();
         ExecuteImpl();
         aP13_ErrorMessages=this.AV13ErrorMessages;
         aP14_EventCreated=this.AV14EventCreated;
      }

      public bool executeUdp( string aP0_Gx_mode ,
                              string aP1_Title ,
                              DateTime aP2_Date ,
                              DateTime aP3_FromTime ,
                              DateTime aP4_ToTime ,
                              bool aP5_AllDay ,
                              DateTime aP6_EndDate ,
                              string aP7_CalendarEventId ,
                              string aP8_EventType ,
                              bool aP9_RecurringEvent ,
                              string aP10_RecuringEventType ,
                              bool aP11_AddRSVP ,
                              GxSimpleCollection<Guid> aP12_AddressGroup ,
                              out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP13_ErrorMessages )
      {
         execute(aP0_Gx_mode, aP1_Title, aP2_Date, aP3_FromTime, aP4_ToTime, aP5_AllDay, aP6_EndDate, aP7_CalendarEventId, aP8_EventType, aP9_RecurringEvent, aP10_RecuringEventType, aP11_AddRSVP, aP12_AddressGroup, out aP13_ErrorMessages, out aP14_EventCreated);
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
                                 string aP8_EventType ,
                                 bool aP9_RecurringEvent ,
                                 string aP10_RecuringEventType ,
                                 bool aP11_AddRSVP ,
                                 GxSimpleCollection<Guid> aP12_AddressGroup ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP13_ErrorMessages ,
                                 out bool aP14_EventCreated )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV20Title = aP1_Title;
         this.AV11Date = aP2_Date;
         this.AV18FromTime = aP3_FromTime;
         this.AV21ToTime = aP4_ToTime;
         this.AV8AllDay = aP5_AllDay;
         this.AV12EndDate = aP6_EndDate;
         this.AV10CalendarEventId = aP7_CalendarEventId;
         this.AV28EventType = aP8_EventType;
         this.AV25RecurringEvent = aP9_RecurringEvent;
         this.AV27RecuringEventType = aP10_RecuringEventType;
         this.AV26AddRSVP = aP11_AddRSVP;
         this.AV30AddressGroup = aP12_AddressGroup;
         this.AV13ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV14EventCreated = false ;
         SubmitImpl();
         aP13_ErrorMessages=this.AV13ErrorMessages;
         aP14_EventCreated=this.AV14EventCreated;
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
            AV22Trn_AgendCalendar.gxTpr_Agendacalendarid = Guid.NewGuid( );
         }
         AV22Trn_AgendCalendar.gxTpr_Agendacalendarallday = AV8AllDay;
         GXt_guid1 = Guid.Empty;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         AV22Trn_AgendCalendar.gxTpr_Locationid = GXt_guid1;
         AV22Trn_AgendCalendar.gxTpr_Agendacalendarstartdate = AV17EventStartDate;
         AV22Trn_AgendCalendar.gxTpr_Agendacalendarenddate = AV15EventEndDate;
         AV22Trn_AgendCalendar.gxTpr_Agendacalendartitle = AV20Title;
         AV22Trn_AgendCalendar.gxTpr_Agendacalendartype = AV28EventType;
         AV22Trn_AgendCalendar.gxTpr_Agendacalendarrecurringtype = AV27RecuringEventType;
         AV22Trn_AgendCalendar.gxTpr_Agendacalendarrecurring = AV25RecurringEvent;
         AV22Trn_AgendCalendar.gxTpr_Agendacalendaraddrsvp = AV26AddRSVP;
         AV22Trn_AgendCalendar.Save();
         if ( AV22Trn_AgendCalendar.Success() )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A303AgendaCalendarId ,
                                                 AV30AddressGroup ,
                                                 AV9CalendarEventGUID } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor P006T2 */
            pr_default.execute(0, new Object[] {AV9CalendarEventGUID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A303AgendaCalendarId = P006T2_A303AgendaCalendarId[0];
               A62ResidentId = P006T2_A62ResidentId[0];
               AV31Trn_AgendaEventGroup.Load(A303AgendaCalendarId, A62ResidentId);
               AV31Trn_AgendaEventGroup.Delete();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV38GXV1 = 1;
            while ( AV38GXV1 <= AV30AddressGroup.Count )
            {
               AV32ResidentId = ((Guid)AV30AddressGroup.Item(AV38GXV1));
               AV31Trn_AgendaEventGroup = new SdtTrn_AgendaEventGroup(context);
               AV31Trn_AgendaEventGroup.gxTpr_Residentid = AV32ResidentId;
               AV31Trn_AgendaEventGroup.gxTpr_Agendacalendarid = AV22Trn_AgendCalendar.gxTpr_Agendacalendarid;
               AV31Trn_AgendaEventGroup.InsertOrUpdate();
               AV38GXV1 = (int)(AV38GXV1+1);
            }
            context.CommitDataStores("workwithplus.wwp_calendar_editevent",pr_default);
            AV14EventCreated = true;
            AV24EventDescription = "Event: " + AV20Title + context.GetMessage( " starting from ", "") + context.localUtil.Format( AV17EventStartDate, "99/99/99 99:99") + context.GetMessage( " to ", "") + context.localUtil.Format( AV15EventEndDate, "99/99/99 99:99");
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               new prc_sendagendanotification(context ).execute(  context.GetMessage( "New Calendar Event", ""),  AV24EventDescription,  AV30AddressGroup) ;
               new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "AgendaNotification",  "AgendaEvents",  "",  "",  context.GetMessage( "New Agenda Created", ""),  AV24EventDescription,  AV24EventDescription,  formatLink("wp_calendaragenda.aspx") ,  "",  "",  true) ;
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               new prc_sendagendanotification(context ).execute(  context.GetMessage( "Calendar Event Updated", ""),  AV24EventDescription,  AV30AddressGroup) ;
               new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "AgendaNotification",  "AgendaEvents",  "",  "",  context.GetMessage( "Agenda Event Updated", ""),  AV24EventDescription,  AV24EventDescription,  formatLink("wp_calendaragenda.aspx") ,  "",  "",  true) ;
            }
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
         A303AgendaCalendarId = Guid.Empty;
         P006T2_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P006T2_A62ResidentId = new Guid[] {Guid.Empty} ;
         A62ResidentId = Guid.Empty;
         AV31Trn_AgendaEventGroup = new SdtTrn_AgendaEventGroup(context);
         AV32ResidentId = Guid.Empty;
         AV24EventDescription = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_editevent__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_editevent__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_editevent__default(),
            new Object[][] {
                new Object[] {
               P006T2_A303AgendaCalendarId, P006T2_A62ResidentId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV38GXV1 ;
      private string Gx_mode ;
      private DateTime AV18FromTime ;
      private DateTime AV21ToTime ;
      private DateTime AV17EventStartDate ;
      private DateTime AV15EventEndDate ;
      private DateTime AV11Date ;
      private DateTime AV12EndDate ;
      private bool AV8AllDay ;
      private bool AV25RecurringEvent ;
      private bool AV26AddRSVP ;
      private bool AV14EventCreated ;
      private string AV20Title ;
      private string AV10CalendarEventId ;
      private string AV28EventType ;
      private string AV27RecuringEventType ;
      private string AV24EventDescription ;
      private Guid AV9CalendarEventGUID ;
      private Guid GXt_guid1 ;
      private Guid A303AgendaCalendarId ;
      private Guid A62ResidentId ;
      private Guid AV32ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<Guid> AV30AddressGroup ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13ErrorMessages ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private SdtTrn_AgendaCalendar AV22Trn_AgendCalendar ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006T2_A303AgendaCalendarId ;
      private Guid[] P006T2_A62ResidentId ;
      private SdtTrn_AgendaEventGroup AV31Trn_AgendaEventGroup ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP13_ErrorMessages ;
      private bool aP14_EventCreated ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_calendar_editevent__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
       return "DATASTORE1";
    }

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
   protected Object[] conditional_P006T2( IGxContext context ,
                                          Guid A303AgendaCalendarId ,
                                          GxSimpleCollection<Guid> AV30AddressGroup ,
                                          Guid AV9CalendarEventGUID )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int2 = new short[1];
      Object[] GXv_Object3 = new Object[2];
      scmdbuf = "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup";
      AddWhere(sWhereString, "(AgendaCalendarId = :AV9CalendarEventGUID)");
      AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV30AddressGroup, "AgendaCalendarId IN (", ")")+")");
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY AgendaCalendarId";
      GXv_Object3[0] = scmdbuf;
      GXv_Object3[1] = GXv_int2;
      return GXv_Object3 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 0 :
                  return conditional_P006T2(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (Guid)dynConstraints[2] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP006T2;
       prmP006T2 = new Object[] {
       new ParDef("AV9CalendarEventGUID",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P006T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006T2,100, GxCacheFrequency.OFF ,true,false )
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
    switch ( cursor )
    {
          case 0 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
    }
 }

}

}
