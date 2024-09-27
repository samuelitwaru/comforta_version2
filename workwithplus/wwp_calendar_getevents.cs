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
   public class wwp_calendar_getevents : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public wwp_calendar_getevents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_calendar_getevents( IGxContext context )
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
                           out GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_Gxm2rootcol )
      {
         this.AV5IsSearching = aP0_IsSearching;
         this.AV8TitleFilter = aP1_TitleFilter;
         this.AV6LoadFromDate = aP2_LoadFromDate;
         this.AV7LoadToDate = aP3_LoadToDate;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> executeUdp( bool aP0_IsSearching ,
                                                                                                     string aP1_TitleFilter ,
                                                                                                     DateTime aP2_LoadFromDate ,
                                                                                                     DateTime aP3_LoadToDate )
      {
         execute(aP0_IsSearching, aP1_TitleFilter, aP2_LoadFromDate, aP3_LoadToDate, out aP4_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( bool aP0_IsSearching ,
                                 string aP1_TitleFilter ,
                                 DateTime aP2_LoadFromDate ,
                                 DateTime aP3_LoadToDate ,
                                 out GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_Gxm2rootcol )
      {
         this.AV5IsSearching = aP0_IsSearching;
         this.AV8TitleFilter = aP1_TitleFilter;
         this.AV6LoadFromDate = aP2_LoadFromDate;
         this.AV7LoadToDate = aP3_LoadToDate;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2") ;
         SubmitImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! AV5IsSearching )
         {
            AV9RealLoadToDate = DateTimeUtil.DAdd( AV7LoadToDate, (1));
         }
         if ( AV5IsSearching )
         {
            AV9RealLoadToDate = AV7LoadToDate;
         }
         AV13Udparg3 = new prc_getuserlocationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV6LoadFromDate ,
                                              AV9RealLoadToDate ,
                                              AV8TitleFilter ,
                                              A305AgendaCalendarStartDate ,
                                              A306AgendaCalendarEndDate ,
                                              A304AgendaCalendarTitle ,
                                              A29LocationId ,
                                              AV13Udparg3 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV8TitleFilter = StringUtil.Concat( StringUtil.RTrim( AV8TitleFilter), "%", "");
         /* Using cursor P000E2 */
         pr_default.execute(0, new Object[] {AV13Udparg3, AV6LoadFromDate, AV9RealLoadToDate, AV6LoadFromDate, AV6LoadFromDate, lV8TitleFilter});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A304AgendaCalendarTitle = P000E2_A304AgendaCalendarTitle[0];
            A306AgendaCalendarEndDate = P000E2_A306AgendaCalendarEndDate[0];
            A305AgendaCalendarStartDate = P000E2_A305AgendaCalendarStartDate[0];
            A29LocationId = P000E2_A29LocationId[0];
            A303AgendaCalendarId = P000E2_A303AgendaCalendarId[0];
            A307AgendaCalendarAllDay = P000E2_A307AgendaCalendarAllDay[0];
            Gxm1wwp_calendar_events = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
            Gxm2rootcol.Add(Gxm1wwp_calendar_events, 0);
            Gxm1wwp_calendar_events.gxTpr_Id = A303AgendaCalendarId.ToString();
            Gxm1wwp_calendar_events.gxTpr_Allday = A307AgendaCalendarAllDay;
            Gxm1wwp_calendar_events.gxTpr_Start = A305AgendaCalendarStartDate;
            Gxm1wwp_calendar_events.gxTpr_End = A306AgendaCalendarEndDate;
            Gxm1wwp_calendar_events.gxTpr_Title = A304AgendaCalendarTitle;
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
         AV9RealLoadToDate = DateTime.MinValue;
         AV13Udparg3 = Guid.Empty;
         lV8TitleFilter = "";
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A304AgendaCalendarTitle = "";
         A29LocationId = Guid.Empty;
         P000E2_A304AgendaCalendarTitle = new string[] {""} ;
         P000E2_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         P000E2_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         P000E2_A29LocationId = new Guid[] {Guid.Empty} ;
         P000E2_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P000E2_A307AgendaCalendarAllDay = new bool[] {false} ;
         A303AgendaCalendarId = Guid.Empty;
         Gxm1wwp_calendar_events = new GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_calendar_getevents__default(),
            new Object[][] {
                new Object[] {
               P000E2_A304AgendaCalendarTitle, P000E2_A306AgendaCalendarEndDate, P000E2_A305AgendaCalendarStartDate, P000E2_A29LocationId, P000E2_A303AgendaCalendarId, P000E2_A307AgendaCalendarAllDay
               }
            }
         );
         /* GeneXus formulas. */
      }

      private DateTime AV6LoadFromDate ;
      private DateTime A305AgendaCalendarStartDate ;
      private DateTime A306AgendaCalendarEndDate ;
      private DateTime AV7LoadToDate ;
      private DateTime AV9RealLoadToDate ;
      private bool AV5IsSearching ;
      private bool A307AgendaCalendarAllDay ;
      private string AV8TitleFilter ;
      private string lV8TitleFilter ;
      private string A304AgendaCalendarTitle ;
      private Guid AV13Udparg3 ;
      private Guid A29LocationId ;
      private Guid A303AgendaCalendarId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private string[] P000E2_A304AgendaCalendarTitle ;
      private DateTime[] P000E2_A306AgendaCalendarEndDate ;
      private DateTime[] P000E2_A305AgendaCalendarStartDate ;
      private Guid[] P000E2_A29LocationId ;
      private Guid[] P000E2_A303AgendaCalendarId ;
      private bool[] P000E2_A307AgendaCalendarAllDay ;
      private GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item Gxm1wwp_calendar_events ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.SdtWWP_Calendar_Events_Item> aP4_Gxm2rootcol ;
   }

   public class wwp_calendar_getevents__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000E2( IGxContext context ,
                                             DateTime AV6LoadFromDate ,
                                             DateTime AV9RealLoadToDate ,
                                             string AV8TitleFilter ,
                                             DateTime A305AgendaCalendarStartDate ,
                                             DateTime A306AgendaCalendarEndDate ,
                                             string A304AgendaCalendarTitle ,
                                             Guid A29LocationId ,
                                             Guid AV13Udparg3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT AgendaCalendarTitle, AgendaCalendarEndDate, AgendaCalendarStartDate, LocationId, AgendaCalendarId, AgendaCalendarAllDay FROM Trn_AgendaCalendar";
         AddWhere(sWhereString, "(LocationId = :AV13Udparg3)");
         if ( ! (DateTime.MinValue==AV6LoadFromDate) && ! (DateTime.MinValue==AV9RealLoadToDate) )
         {
            AddWhere(sWhereString, "(AgendaCalendarStartDate >= :AV6LoadFromDate and AgendaCalendarStartDate < :AV9RealLoadToDate or AgendaCalendarStartDate < :AV6LoadFromDate and AgendaCalendarEndDate >= :AV6LoadFromDate)");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8TitleFilter)) )
         {
            AddWhere(sWhereString, "(AgendaCalendarTitle like '%' || :lV8TitleFilter)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AgendaCalendarId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000E2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (Guid)dynConstraints[6] , (Guid)dynConstraints[7] );
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
          Object[] prmP000E2;
          prmP000E2 = new Object[] {
          new ParDef("AV13Udparg3",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV6LoadFromDate",GXType.DateTime,8,5) ,
          new ParDef("AV9RealLoadToDate",GXType.Date,8,0) ,
          new ParDef("AV6LoadFromDate",GXType.DateTime,8,5) ,
          new ParDef("AV6LoadFromDate",GXType.DateTime,8,5) ,
          new ParDef("lV8TitleFilter",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                return;
       }
    }

 }

}
