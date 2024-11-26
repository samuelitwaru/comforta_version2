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
   public class prc_agendalocationapi : GXProcedure
   {
      public prc_agendalocationapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_agendalocationapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ResidentId ,
                           string aP1_StartDateString ,
                           string aP2_EndDateString ,
                           out string aP3_SDT_AgendaLocationJson )
      {
         this.AV8ResidentId = aP0_ResidentId;
         this.AV20StartDateString = aP1_StartDateString;
         this.AV21EndDateString = aP2_EndDateString;
         this.AV12SDT_AgendaLocationJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_SDT_AgendaLocationJson=this.AV12SDT_AgendaLocationJson;
      }

      public string executeUdp( string aP0_ResidentId ,
                                string aP1_StartDateString ,
                                string aP2_EndDateString )
      {
         execute(aP0_ResidentId, aP1_StartDateString, aP2_EndDateString, out aP3_SDT_AgendaLocationJson);
         return AV12SDT_AgendaLocationJson ;
      }

      public void executeSubmit( string aP0_ResidentId ,
                                 string aP1_StartDateString ,
                                 string aP2_EndDateString ,
                                 out string aP3_SDT_AgendaLocationJson )
      {
         this.AV8ResidentId = aP0_ResidentId;
         this.AV20StartDateString = aP1_StartDateString;
         this.AV21EndDateString = aP2_EndDateString;
         this.AV12SDT_AgendaLocationJson = "" ;
         SubmitImpl();
         aP3_SDT_AgendaLocationJson=this.AV12SDT_AgendaLocationJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13SDT_AgendaLocationCollection = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         AV23GXLvl4 = 0;
         /* Using cursor P008T2 */
         pr_default.execute(0, new Object[] {AV8ResidentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P008T2_A71ResidentGUID[0];
            A62ResidentId = P008T2_A62ResidentId[0];
            A29LocationId = P008T2_A29LocationId[0];
            A11OrganisationId = P008T2_A11OrganisationId[0];
            AV23GXLvl4 = 1;
            AV15AgendaResidentId = A62ResidentId;
            AV9LocationId = A29LocationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV23GXLvl4 == 0 )
         {
            AV13SDT_AgendaLocationCollection.Clear();
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20StartDateString)) )
         {
            AV18DateToStart = DateTimeUtil.DAdd( Gx_date, (-1));
         }
         else
         {
            AV22DateSplit = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV22DateSplit = GxRegex.Split(AV20StartDateString,"-");
            if ( ( AV22DateSplit.Count == 3 ) && ( StringUtil.Len( AV22DateSplit.GetString(1)) == 4 ) )
            {
               AV18DateToStart = context.localUtil.YMDToD( (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(1), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(2), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(3), "."), 18, MidpointRounding.ToEven)));
            }
            else
            {
               AV18DateToStart = DateTime.MinValue;
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21EndDateString)) )
         {
            AV19DateToEnd = DateTimeUtil.DAdd( Gx_date, (1));
         }
         else
         {
            AV22DateSplit = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV22DateSplit = GxRegex.Split(AV21EndDateString,"-");
            if ( ( AV22DateSplit.Count == 3 ) && ( StringUtil.Len( AV22DateSplit.GetString(1)) == 4 ) )
            {
               AV19DateToEnd = context.localUtil.YMDToD( (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(1), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(2), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(3), "."), 18, MidpointRounding.ToEven)));
            }
            else
            {
               AV19DateToEnd = DateTime.MinValue;
            }
         }
         /* Using cursor P008T3 */
         pr_default.execute(1, new Object[] {AV9LocationId, AV18DateToStart, AV19DateToEnd});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A306AgendaCalendarEndDate = P008T3_A306AgendaCalendarEndDate[0];
            A305AgendaCalendarStartDate = P008T3_A305AgendaCalendarStartDate[0];
            A29LocationId = P008T3_A29LocationId[0];
            A303AgendaCalendarId = P008T3_A303AgendaCalendarId[0];
            A304AgendaCalendarTitle = P008T3_A304AgendaCalendarTitle[0];
            A454AgendaCalendarType = P008T3_A454AgendaCalendarType[0];
            A307AgendaCalendarAllDay = P008T3_A307AgendaCalendarAllDay[0];
            A450AgendaCalendarRecurring = P008T3_A450AgendaCalendarRecurring[0];
            A451AgendaCalendarRecurringType = P008T3_A451AgendaCalendarRecurringType[0];
            A452AgendaCalendarAddRSVP = P008T3_A452AgendaCalendarAddRSVP[0];
            A11OrganisationId = P008T3_A11OrganisationId[0];
            AV10SDT_AgendaLocation = new SdtSDT_AgendaLocation(context);
            AV10SDT_AgendaLocation.gxTpr_Agendacalendarid = A303AgendaCalendarId;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendartitle = A304AgendaCalendarTitle;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendartype = A454AgendaCalendarType;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendarstartdate = A305AgendaCalendarStartDate;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendarenddate = A306AgendaCalendarEndDate;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendarallday = A307AgendaCalendarAllDay;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendarrecurring = A450AgendaCalendarRecurring;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendarrecurringtype = A451AgendaCalendarRecurringType;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendaraddrsvp = A452AgendaCalendarAddRSVP;
            AV10SDT_AgendaLocation.gxTpr_Locationid = A29LocationId;
            AV10SDT_AgendaLocation.gxTpr_Organisationid = A11OrganisationId;
            AV13SDT_AgendaLocationCollection.Add(AV10SDT_AgendaLocation, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV12SDT_AgendaLocationJson = AV13SDT_AgendaLocationCollection.ToJSonString(false);
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
         AV12SDT_AgendaLocationJson = "";
         AV13SDT_AgendaLocationCollection = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         P008T2_A71ResidentGUID = new string[] {""} ;
         P008T2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008T2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008T2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV15AgendaResidentId = Guid.Empty;
         AV9LocationId = Guid.Empty;
         AV18DateToStart = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV22DateSplit = new GxSimpleCollection<string>();
         AV19DateToEnd = DateTime.MinValue;
         P008T3_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         P008T3_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         P008T3_A29LocationId = new Guid[] {Guid.Empty} ;
         P008T3_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P008T3_A304AgendaCalendarTitle = new string[] {""} ;
         P008T3_A454AgendaCalendarType = new string[] {""} ;
         P008T3_A307AgendaCalendarAllDay = new bool[] {false} ;
         P008T3_A450AgendaCalendarRecurring = new bool[] {false} ;
         P008T3_A451AgendaCalendarRecurringType = new string[] {""} ;
         P008T3_A452AgendaCalendarAddRSVP = new bool[] {false} ;
         P008T3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A303AgendaCalendarId = Guid.Empty;
         A304AgendaCalendarTitle = "";
         A454AgendaCalendarType = "";
         A451AgendaCalendarRecurringType = "";
         AV10SDT_AgendaLocation = new SdtSDT_AgendaLocation(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_agendalocationapi__default(),
            new Object[][] {
                new Object[] {
               P008T2_A71ResidentGUID, P008T2_A62ResidentId, P008T2_A29LocationId, P008T2_A11OrganisationId
               }
               , new Object[] {
               P008T3_A306AgendaCalendarEndDate, P008T3_A305AgendaCalendarStartDate, P008T3_A29LocationId, P008T3_A303AgendaCalendarId, P008T3_A304AgendaCalendarTitle, P008T3_A454AgendaCalendarType, P008T3_A307AgendaCalendarAllDay, P008T3_A450AgendaCalendarRecurring, P008T3_A451AgendaCalendarRecurringType, P008T3_A452AgendaCalendarAddRSVP,
               P008T3_A11OrganisationId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV23GXLvl4 ;
      private DateTime A306AgendaCalendarEndDate ;
      private DateTime A305AgendaCalendarStartDate ;
      private DateTime AV18DateToStart ;
      private DateTime Gx_date ;
      private DateTime AV19DateToEnd ;
      private bool A307AgendaCalendarAllDay ;
      private bool A450AgendaCalendarRecurring ;
      private bool A452AgendaCalendarAddRSVP ;
      private string AV12SDT_AgendaLocationJson ;
      private string AV8ResidentId ;
      private string AV20StartDateString ;
      private string AV21EndDateString ;
      private string A71ResidentGUID ;
      private string A304AgendaCalendarTitle ;
      private string A454AgendaCalendarType ;
      private string A451AgendaCalendarRecurringType ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV15AgendaResidentId ;
      private Guid AV9LocationId ;
      private Guid A303AgendaCalendarId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_AgendaLocation> AV13SDT_AgendaLocationCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P008T2_A71ResidentGUID ;
      private Guid[] P008T2_A62ResidentId ;
      private Guid[] P008T2_A29LocationId ;
      private Guid[] P008T2_A11OrganisationId ;
      private GxSimpleCollection<string> AV22DateSplit ;
      private DateTime[] P008T3_A306AgendaCalendarEndDate ;
      private DateTime[] P008T3_A305AgendaCalendarStartDate ;
      private Guid[] P008T3_A29LocationId ;
      private Guid[] P008T3_A303AgendaCalendarId ;
      private string[] P008T3_A304AgendaCalendarTitle ;
      private string[] P008T3_A454AgendaCalendarType ;
      private bool[] P008T3_A307AgendaCalendarAllDay ;
      private bool[] P008T3_A450AgendaCalendarRecurring ;
      private string[] P008T3_A451AgendaCalendarRecurringType ;
      private bool[] P008T3_A452AgendaCalendarAddRSVP ;
      private Guid[] P008T3_A11OrganisationId ;
      private SdtSDT_AgendaLocation AV10SDT_AgendaLocation ;
      private string aP3_SDT_AgendaLocationJson ;
   }

   public class prc_agendalocationapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008T2;
          prmP008T2 = new Object[] {
          new ParDef("AV8ResidentId",GXType.VarChar,100,60)
          };
          Object[] prmP008T3;
          prmP008T3 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18DateToStart",GXType.Date,8,0) ,
          new ParDef("AV19DateToEnd",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008T2", "SELECT ResidentGUID, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV8ResidentId) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008T2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008T3", "SELECT AgendaCalendarEndDate, AgendaCalendarStartDate, LocationId, AgendaCalendarId, AgendaCalendarTitle, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, OrganisationId FROM Trn_AgendaCalendar WHERE (LocationId = :AV9LocationId) AND (AgendaCalendarStartDate >= :AV18DateToStart) AND (AgendaCalendarEndDate <= :AV19DateToEnd) ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008T3,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                return;
       }
    }

 }

}
