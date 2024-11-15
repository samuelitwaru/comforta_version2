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
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_agendalocationapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ResidentId ,
                           out string aP1_SDT_AgendaLocationJson )
      {
         this.AV8ResidentId = aP0_ResidentId;
         this.AV12SDT_AgendaLocationJson = "" ;
         initialize();
         ExecuteImpl();
         aP1_SDT_AgendaLocationJson=this.AV12SDT_AgendaLocationJson;
      }

      public string executeUdp( Guid aP0_ResidentId )
      {
         execute(aP0_ResidentId, out aP1_SDT_AgendaLocationJson);
         return AV12SDT_AgendaLocationJson ;
      }

      public void executeSubmit( Guid aP0_ResidentId ,
                                 out string aP1_SDT_AgendaLocationJson )
      {
         this.AV8ResidentId = aP0_ResidentId;
         this.AV12SDT_AgendaLocationJson = "" ;
         SubmitImpl();
         aP1_SDT_AgendaLocationJson=this.AV12SDT_AgendaLocationJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13SDT_AgendaLocationCollection = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         /* Using cursor P008T2 */
         pr_default.execute(0, new Object[] {AV8ResidentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A304AgendaCalendarTitle = P008T2_A304AgendaCalendarTitle[0];
            A454AgendaCalendarType = P008T2_A454AgendaCalendarType[0];
            A305AgendaCalendarStartDate = P008T2_A305AgendaCalendarStartDate[0];
            A306AgendaCalendarEndDate = P008T2_A306AgendaCalendarEndDate[0];
            A307AgendaCalendarAllDay = P008T2_A307AgendaCalendarAllDay[0];
            A450AgendaCalendarRecurring = P008T2_A450AgendaCalendarRecurring[0];
            A451AgendaCalendarRecurringType = P008T2_A451AgendaCalendarRecurringType[0];
            A452AgendaCalendarAddRSVP = P008T2_A452AgendaCalendarAddRSVP[0];
            A29LocationId = P008T2_A29LocationId[0];
            A11OrganisationId = P008T2_A11OrganisationId[0];
            A62ResidentId = P008T2_A62ResidentId[0];
            A303AgendaCalendarId = P008T2_A303AgendaCalendarId[0];
            A304AgendaCalendarTitle = P008T2_A304AgendaCalendarTitle[0];
            A454AgendaCalendarType = P008T2_A454AgendaCalendarType[0];
            A305AgendaCalendarStartDate = P008T2_A305AgendaCalendarStartDate[0];
            A306AgendaCalendarEndDate = P008T2_A306AgendaCalendarEndDate[0];
            A307AgendaCalendarAllDay = P008T2_A307AgendaCalendarAllDay[0];
            A450AgendaCalendarRecurring = P008T2_A450AgendaCalendarRecurring[0];
            A451AgendaCalendarRecurringType = P008T2_A451AgendaCalendarRecurringType[0];
            A452AgendaCalendarAddRSVP = P008T2_A452AgendaCalendarAddRSVP[0];
            A29LocationId = P008T2_A29LocationId[0];
            A11OrganisationId = P008T2_A11OrganisationId[0];
            AV14AgendaCalendaId = A303AgendaCalendarId;
            /* Using cursor P008T3 */
            pr_default.execute(1, new Object[] {AV14AgendaCalendaId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A303AgendaCalendarId = P008T3_A303AgendaCalendarId[0];
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
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P008T2_A304AgendaCalendarTitle = new string[] {""} ;
         P008T2_A454AgendaCalendarType = new string[] {""} ;
         P008T2_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         P008T2_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         P008T2_A307AgendaCalendarAllDay = new bool[] {false} ;
         P008T2_A450AgendaCalendarRecurring = new bool[] {false} ;
         P008T2_A451AgendaCalendarRecurringType = new string[] {""} ;
         P008T2_A452AgendaCalendarAddRSVP = new bool[] {false} ;
         P008T2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008T2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008T2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008T2_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         A304AgendaCalendarTitle = "";
         A454AgendaCalendarType = "";
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A451AgendaCalendarRecurringType = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A303AgendaCalendarId = Guid.Empty;
         AV14AgendaCalendaId = Guid.Empty;
         P008T3_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         AV10SDT_AgendaLocation = new SdtSDT_AgendaLocation(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_agendalocationapi__default(),
            new Object[][] {
                new Object[] {
               P008T2_A304AgendaCalendarTitle, P008T2_A454AgendaCalendarType, P008T2_A305AgendaCalendarStartDate, P008T2_A306AgendaCalendarEndDate, P008T2_A307AgendaCalendarAllDay, P008T2_A450AgendaCalendarRecurring, P008T2_A451AgendaCalendarRecurringType, P008T2_A452AgendaCalendarAddRSVP, P008T2_A29LocationId, P008T2_A11OrganisationId,
               P008T2_A62ResidentId, P008T2_A303AgendaCalendarId
               }
               , new Object[] {
               P008T3_A303AgendaCalendarId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private DateTime A305AgendaCalendarStartDate ;
      private DateTime A306AgendaCalendarEndDate ;
      private bool A307AgendaCalendarAllDay ;
      private bool A450AgendaCalendarRecurring ;
      private bool A452AgendaCalendarAddRSVP ;
      private string AV12SDT_AgendaLocationJson ;
      private string A304AgendaCalendarTitle ;
      private string A454AgendaCalendarType ;
      private string A451AgendaCalendarRecurringType ;
      private Guid AV8ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A62ResidentId ;
      private Guid A303AgendaCalendarId ;
      private Guid AV14AgendaCalendaId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_AgendaLocation> AV13SDT_AgendaLocationCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P008T2_A304AgendaCalendarTitle ;
      private string[] P008T2_A454AgendaCalendarType ;
      private DateTime[] P008T2_A305AgendaCalendarStartDate ;
      private DateTime[] P008T2_A306AgendaCalendarEndDate ;
      private bool[] P008T2_A307AgendaCalendarAllDay ;
      private bool[] P008T2_A450AgendaCalendarRecurring ;
      private string[] P008T2_A451AgendaCalendarRecurringType ;
      private bool[] P008T2_A452AgendaCalendarAddRSVP ;
      private Guid[] P008T2_A29LocationId ;
      private Guid[] P008T2_A11OrganisationId ;
      private Guid[] P008T2_A62ResidentId ;
      private Guid[] P008T2_A303AgendaCalendarId ;
      private Guid[] P008T3_A303AgendaCalendarId ;
      private SdtSDT_AgendaLocation AV10SDT_AgendaLocation ;
      private string aP1_SDT_AgendaLocationJson ;
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
          new ParDef("AV8ResidentId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008T3;
          prmP008T3 = new Object[] {
          new ParDef("AV14AgendaCalendaId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008T2", "SELECT T2.AgendaCalendarTitle, T2.AgendaCalendarType, T2.AgendaCalendarStartDate, T2.AgendaCalendarEndDate, T2.AgendaCalendarAllDay, T2.AgendaCalendarRecurring, T2.AgendaCalendarRecurringType, T2.AgendaCalendarAddRSVP, T2.LocationId, T2.OrganisationId, T1.ResidentId, T1.AgendaCalendarId FROM (Trn_AgendaEventGroup T1 INNER JOIN Trn_AgendaCalendar T2 ON T2.AgendaCalendarId = T1.AgendaCalendarId) WHERE T1.ResidentId = :AV8ResidentId ORDER BY T1.AgendaCalendarId, T1.ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008T2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008T3", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AV14AgendaCalendaId ORDER BY AgendaCalendarId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008T3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                ((Guid[]) buf[9])[0] = rslt.getGuid(10);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                ((Guid[]) buf[11])[0] = rslt.getGuid(12);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
