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

      public void execute( Guid aP0_LocationId ,
                           out string aP1_SDT_AgendaLocationJson )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV12SDT_AgendaLocationJson = "" ;
         initialize();
         ExecuteImpl();
         aP1_SDT_AgendaLocationJson=this.AV12SDT_AgendaLocationJson;
      }

      public string executeUdp( Guid aP0_LocationId )
      {
         execute(aP0_LocationId, out aP1_SDT_AgendaLocationJson);
         return AV12SDT_AgendaLocationJson ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 out string aP1_SDT_AgendaLocationJson )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV12SDT_AgendaLocationJson = "" ;
         SubmitImpl();
         aP1_SDT_AgendaLocationJson=this.AV12SDT_AgendaLocationJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SDT_AgendaLocationColection = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         AV13GXLvl2 = 0;
         /* Using cursor P008T2 */
         pr_default.execute(0, new Object[] {AV9LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P008T2_A29LocationId[0];
            A303AgendaCalendarId = P008T2_A303AgendaCalendarId[0];
            A305AgendaCalendarStartDate = P008T2_A305AgendaCalendarStartDate[0];
            A306AgendaCalendarEndDate = P008T2_A306AgendaCalendarEndDate[0];
            A307AgendaCalendarAllDay = P008T2_A307AgendaCalendarAllDay[0];
            A304AgendaCalendarTitle = P008T2_A304AgendaCalendarTitle[0];
            A11OrganisationId = P008T2_A11OrganisationId[0];
            AV13GXLvl2 = 1;
            AV10SDT_AgendaLocation = new SdtSDT_AgendaLocation(context);
            AV10SDT_AgendaLocation.gxTpr_Agendacalendarid = A303AgendaCalendarId;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendarstartdate = A305AgendaCalendarStartDate;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendarenddate = A306AgendaCalendarEndDate;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendarallday = A307AgendaCalendarAllDay;
            AV10SDT_AgendaLocation.gxTpr_Agendacalendartitle = A304AgendaCalendarTitle;
            AV10SDT_AgendaLocation.gxTpr_Locationid = A29LocationId;
            AV10SDT_AgendaLocation.gxTpr_Organisationid = A11OrganisationId;
            AV11SDT_AgendaLocationColection.Add(AV10SDT_AgendaLocation, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl2 == 0 )
         {
            AV11SDT_AgendaLocationColection.Clear();
         }
         AV12SDT_AgendaLocationJson = AV11SDT_AgendaLocationColection.ToJSonString(false);
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
         AV11SDT_AgendaLocationColection = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         P008T2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008T2_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P008T2_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         P008T2_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         P008T2_A307AgendaCalendarAllDay = new bool[] {false} ;
         P008T2_A304AgendaCalendarTitle = new string[] {""} ;
         P008T2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A303AgendaCalendarId = Guid.Empty;
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A304AgendaCalendarTitle = "";
         A11OrganisationId = Guid.Empty;
         AV10SDT_AgendaLocation = new SdtSDT_AgendaLocation(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_agendalocationapi__default(),
            new Object[][] {
                new Object[] {
               P008T2_A29LocationId, P008T2_A303AgendaCalendarId, P008T2_A305AgendaCalendarStartDate, P008T2_A306AgendaCalendarEndDate, P008T2_A307AgendaCalendarAllDay, P008T2_A304AgendaCalendarTitle, P008T2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13GXLvl2 ;
      private DateTime A305AgendaCalendarStartDate ;
      private DateTime A306AgendaCalendarEndDate ;
      private bool A307AgendaCalendarAllDay ;
      private string AV12SDT_AgendaLocationJson ;
      private string A304AgendaCalendarTitle ;
      private Guid AV9LocationId ;
      private Guid A29LocationId ;
      private Guid A303AgendaCalendarId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_AgendaLocation> AV11SDT_AgendaLocationColection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008T2_A29LocationId ;
      private Guid[] P008T2_A303AgendaCalendarId ;
      private DateTime[] P008T2_A305AgendaCalendarStartDate ;
      private DateTime[] P008T2_A306AgendaCalendarEndDate ;
      private bool[] P008T2_A307AgendaCalendarAllDay ;
      private string[] P008T2_A304AgendaCalendarTitle ;
      private Guid[] P008T2_A11OrganisationId ;
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008T2;
          prmP008T2 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008T2", "SELECT LocationId, AgendaCalendarId, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarAllDay, AgendaCalendarTitle, OrganisationId FROM Trn_AgendaCalendar WHERE LocationId = :AV9LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008T2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
