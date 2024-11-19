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
   public class prc_agendarecurringevent : GXProcedure
   {
      public prc_agendarecurringevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_agendarecurringevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_IsSearching ,
                           string aP1_TitleFilter ,
                           DateTime aP2_LoadFromDate ,
                           DateTime aP3_LoadToDate ,
                           out GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_CalendarEvents )
      {
         this.AV8IsSearching = aP0_IsSearching;
         this.AV16TitleFilter = aP1_TitleFilter;
         this.AV15LoadFromDate = aP2_LoadFromDate;
         this.AV10LoadToDate = aP3_LoadToDate;
         this.AV14CalendarEvents = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP4_CalendarEvents=this.AV14CalendarEvents;
      }

      public GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> executeUdp( bool aP0_IsSearching ,
                                                                                                     string aP1_TitleFilter ,
                                                                                                     DateTime aP2_LoadFromDate ,
                                                                                                     DateTime aP3_LoadToDate )
      {
         execute(aP0_IsSearching, aP1_TitleFilter, aP2_LoadFromDate, aP3_LoadToDate, out aP4_CalendarEvents);
         return AV14CalendarEvents ;
      }

      public void executeSubmit( bool aP0_IsSearching ,
                                 string aP1_TitleFilter ,
                                 DateTime aP2_LoadFromDate ,
                                 DateTime aP3_LoadToDate ,
                                 out GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_CalendarEvents )
      {
         this.AV8IsSearching = aP0_IsSearching;
         this.AV16TitleFilter = aP1_TitleFilter;
         this.AV15LoadFromDate = aP2_LoadFromDate;
         this.AV10LoadToDate = aP3_LoadToDate;
         this.AV14CalendarEvents = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2") ;
         SubmitImpl();
         aP4_CalendarEvents=this.AV14CalendarEvents;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV8IsSearching )
         {
            AV9RealLoadToDate = AV10LoadToDate;
         }
         else
         {
            AV9RealLoadToDate = DateTimeUtil.DAdd( AV10LoadToDate, (1));
         }
         AV18Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor P00942 */
         pr_default.execute(0, new Object[] {AV18Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A451AgendaCalendarRecurringType = P00942_A451AgendaCalendarRecurringType[0];
            A450AgendaCalendarRecurring = P00942_A450AgendaCalendarRecurring[0];
            A29LocationId = P00942_A29LocationId[0];
            A305AgendaCalendarStartDate = P00942_A305AgendaCalendarStartDate[0];
            A303AgendaCalendarId = P00942_A303AgendaCalendarId[0];
            A307AgendaCalendarAllDay = P00942_A307AgendaCalendarAllDay[0];
            A304AgendaCalendarTitle = P00942_A304AgendaCalendarTitle[0];
            AV11Day = A305AgendaCalendarStartDate;
            while ( AV11Day <= AV9RealLoadToDate )
            {
               AV12CalendarEvent = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
               AV12CalendarEvent.gxTpr_Id = A303AgendaCalendarId.ToString();
               AV12CalendarEvent.gxTpr_Allday = A307AgendaCalendarAllDay;
               AV12CalendarEvent.gxTpr_Start = AV11Day;
               AV12CalendarEvent.gxTpr_End = AV11Day;
               AV12CalendarEvent.gxTpr_Title = A304AgendaCalendarTitle;
               AV14CalendarEvents.Add(AV12CalendarEvent, 0);
               AV11Day = DateTimeUtil.TAdd( AV11Day, 86400*(1));
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV14CalendarEvents = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2");
         AV9RealLoadToDate = DateTime.MinValue;
         AV18Udparg1 = Guid.Empty;
         P00942_A451AgendaCalendarRecurringType = new string[] {""} ;
         P00942_A450AgendaCalendarRecurring = new bool[] {false} ;
         P00942_A29LocationId = new Guid[] {Guid.Empty} ;
         P00942_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         P00942_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P00942_A307AgendaCalendarAllDay = new bool[] {false} ;
         P00942_A304AgendaCalendarTitle = new string[] {""} ;
         A451AgendaCalendarRecurringType = "";
         A29LocationId = Guid.Empty;
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A303AgendaCalendarId = Guid.Empty;
         A304AgendaCalendarTitle = "";
         AV11Day = (DateTime)(DateTime.MinValue);
         AV12CalendarEvent = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_agendarecurringevent__default(),
            new Object[][] {
                new Object[] {
               P00942_A451AgendaCalendarRecurringType, P00942_A450AgendaCalendarRecurring, P00942_A29LocationId, P00942_A305AgendaCalendarStartDate, P00942_A303AgendaCalendarId, P00942_A307AgendaCalendarAllDay, P00942_A304AgendaCalendarTitle
               }
            }
         );
         /* GeneXus formulas. */
      }

      private DateTime A305AgendaCalendarStartDate ;
      private DateTime AV11Day ;
      private DateTime AV15LoadFromDate ;
      private DateTime AV10LoadToDate ;
      private DateTime AV9RealLoadToDate ;
      private bool AV8IsSearching ;
      private bool A450AgendaCalendarRecurring ;
      private bool A307AgendaCalendarAllDay ;
      private string AV16TitleFilter ;
      private string A451AgendaCalendarRecurringType ;
      private string A304AgendaCalendarTitle ;
      private Guid AV18Udparg1 ;
      private Guid A29LocationId ;
      private Guid A303AgendaCalendarId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> AV14CalendarEvents ;
      private IDataStoreProvider pr_default ;
      private string[] P00942_A451AgendaCalendarRecurringType ;
      private bool[] P00942_A450AgendaCalendarRecurring ;
      private Guid[] P00942_A29LocationId ;
      private DateTime[] P00942_A305AgendaCalendarStartDate ;
      private Guid[] P00942_A303AgendaCalendarId ;
      private bool[] P00942_A307AgendaCalendarAllDay ;
      private string[] P00942_A304AgendaCalendarTitle ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item AV12CalendarEvent ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_CalendarEvents ;
   }

   public class prc_agendarecurringevent__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00942;
          prmP00942 = new Object[] {
          new ParDef("AV18Udparg1",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00942", "SELECT AgendaCalendarRecurringType, AgendaCalendarRecurring, LocationId, AgendaCalendarStartDate, AgendaCalendarId, AgendaCalendarAllDay, AgendaCalendarTitle FROM Trn_AgendaCalendar WHERE (LocationId = :AV18Udparg1) AND (AgendaCalendarRecurring = TRUE) AND (AgendaCalendarRecurringType = ( 'EveryDay')) ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00942,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
       }
    }

 }

}
