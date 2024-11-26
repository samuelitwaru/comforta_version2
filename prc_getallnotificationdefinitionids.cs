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
   public class prc_getallnotificationdefinitionids : GXProcedure
   {
      public prc_getallnotificationdefinitionids( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getallnotificationdefinitionids( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GxSimpleCollection<short> aP0_AgendaNotificationDefinitionIdCollection ,
                           out GxSimpleCollection<short> aP1_DynamicFormNotificationDefinitionIdCollection ,
                           out GxSimpleCollection<short> aP2_DiscussionNotificationDefinitionIdCollection ,
                           out GxSimpleCollection<short> aP3_MentionNotificationDefinitionIdCollection )
      {
         this.AV8AgendaNotificationDefinitionIdCollection = new GxSimpleCollection<short>() ;
         this.AV10DynamicFormNotificationDefinitionIdCollection = new GxSimpleCollection<short>() ;
         this.AV9DiscussionNotificationDefinitionIdCollection = new GxSimpleCollection<short>() ;
         this.AV12MentionNotificationDefinitionIdCollection = new GxSimpleCollection<short>() ;
         initialize();
         ExecuteImpl();
         aP0_AgendaNotificationDefinitionIdCollection=this.AV8AgendaNotificationDefinitionIdCollection;
         aP1_DynamicFormNotificationDefinitionIdCollection=this.AV10DynamicFormNotificationDefinitionIdCollection;
         aP2_DiscussionNotificationDefinitionIdCollection=this.AV9DiscussionNotificationDefinitionIdCollection;
         aP3_MentionNotificationDefinitionIdCollection=this.AV12MentionNotificationDefinitionIdCollection;
      }

      public GxSimpleCollection<short> executeUdp( out GxSimpleCollection<short> aP0_AgendaNotificationDefinitionIdCollection ,
                                                   out GxSimpleCollection<short> aP1_DynamicFormNotificationDefinitionIdCollection ,
                                                   out GxSimpleCollection<short> aP2_DiscussionNotificationDefinitionIdCollection )
      {
         execute(out aP0_AgendaNotificationDefinitionIdCollection, out aP1_DynamicFormNotificationDefinitionIdCollection, out aP2_DiscussionNotificationDefinitionIdCollection, out aP3_MentionNotificationDefinitionIdCollection);
         return AV12MentionNotificationDefinitionIdCollection ;
      }

      public void executeSubmit( out GxSimpleCollection<short> aP0_AgendaNotificationDefinitionIdCollection ,
                                 out GxSimpleCollection<short> aP1_DynamicFormNotificationDefinitionIdCollection ,
                                 out GxSimpleCollection<short> aP2_DiscussionNotificationDefinitionIdCollection ,
                                 out GxSimpleCollection<short> aP3_MentionNotificationDefinitionIdCollection )
      {
         this.AV8AgendaNotificationDefinitionIdCollection = new GxSimpleCollection<short>() ;
         this.AV10DynamicFormNotificationDefinitionIdCollection = new GxSimpleCollection<short>() ;
         this.AV9DiscussionNotificationDefinitionIdCollection = new GxSimpleCollection<short>() ;
         this.AV12MentionNotificationDefinitionIdCollection = new GxSimpleCollection<short>() ;
         SubmitImpl();
         aP0_AgendaNotificationDefinitionIdCollection=this.AV8AgendaNotificationDefinitionIdCollection;
         aP1_DynamicFormNotificationDefinitionIdCollection=this.AV10DynamicFormNotificationDefinitionIdCollection;
         aP2_DiscussionNotificationDefinitionIdCollection=this.AV9DiscussionNotificationDefinitionIdCollection;
         aP3_MentionNotificationDefinitionIdCollection=this.AV12MentionNotificationDefinitionIdCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9DiscussionNotificationDefinitionIdCollection = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         /* Using cursor P009M2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A164WWPNotificationDefinitionName = P009M2_A164WWPNotificationDefinitionName[0];
            A128WWPNotificationDefinitionId = P009M2_A128WWPNotificationDefinitionId[0];
            if ( StringUtil.Contains( A164WWPNotificationDefinitionName, context.GetMessage( "Discussion", "")) )
            {
               AV9DiscussionNotificationDefinitionIdCollection.Add(A128WWPNotificationDefinitionId, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV12MentionNotificationDefinitionIdCollection = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         /* Using cursor P009M3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A164WWPNotificationDefinitionName = P009M3_A164WWPNotificationDefinitionName[0];
            A128WWPNotificationDefinitionId = P009M3_A128WWPNotificationDefinitionId[0];
            if ( StringUtil.StrCmp(A164WWPNotificationDefinitionName, context.GetMessage( "Mention", "")) == 0 )
            {
               AV12MentionNotificationDefinitionIdCollection.Add(A128WWPNotificationDefinitionId, 0);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV10DynamicFormNotificationDefinitionIdCollection = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         /* Using cursor P009M4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A164WWPNotificationDefinitionName = P009M4_A164WWPNotificationDefinitionName[0];
            A128WWPNotificationDefinitionId = P009M4_A128WWPNotificationDefinitionId[0];
            if ( StringUtil.StrCmp(A164WWPNotificationDefinitionName, context.GetMessage( "DynamicFormNotification", "")) == 0 )
            {
               AV10DynamicFormNotificationDefinitionIdCollection.Add(A128WWPNotificationDefinitionId, 0);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV8AgendaNotificationDefinitionIdCollection = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         /* Using cursor P009M5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A164WWPNotificationDefinitionName = P009M5_A164WWPNotificationDefinitionName[0];
            A128WWPNotificationDefinitionId = P009M5_A128WWPNotificationDefinitionId[0];
            if ( StringUtil.StrCmp(A164WWPNotificationDefinitionName, context.GetMessage( "AgendaNotification", "")) == 0 )
            {
               AV8AgendaNotificationDefinitionIdCollection.Add(A128WWPNotificationDefinitionId, 0);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV11InsertNotificationDefinitionIdCollection = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         /* Using cursor P009M6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A164WWPNotificationDefinitionName = P009M6_A164WWPNotificationDefinitionName[0];
            A128WWPNotificationDefinitionId = P009M6_A128WWPNotificationDefinitionId[0];
            if ( StringUtil.StrCmp(A164WWPNotificationDefinitionName, context.GetMessage( "InsertRecord", "")) == 0 )
            {
               AV11InsertNotificationDefinitionIdCollection.Add(A128WWPNotificationDefinitionId, 0);
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
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
         AV8AgendaNotificationDefinitionIdCollection = new GxSimpleCollection<short>();
         AV10DynamicFormNotificationDefinitionIdCollection = new GxSimpleCollection<short>();
         AV9DiscussionNotificationDefinitionIdCollection = new GxSimpleCollection<short>();
         AV12MentionNotificationDefinitionIdCollection = new GxSimpleCollection<short>();
         P009M2_A164WWPNotificationDefinitionName = new string[] {""} ;
         P009M2_A128WWPNotificationDefinitionId = new long[1] ;
         A164WWPNotificationDefinitionName = "";
         P009M3_A164WWPNotificationDefinitionName = new string[] {""} ;
         P009M3_A128WWPNotificationDefinitionId = new long[1] ;
         P009M4_A164WWPNotificationDefinitionName = new string[] {""} ;
         P009M4_A128WWPNotificationDefinitionId = new long[1] ;
         P009M5_A164WWPNotificationDefinitionName = new string[] {""} ;
         P009M5_A128WWPNotificationDefinitionId = new long[1] ;
         AV11InsertNotificationDefinitionIdCollection = new GxSimpleCollection<short>();
         P009M6_A164WWPNotificationDefinitionName = new string[] {""} ;
         P009M6_A128WWPNotificationDefinitionId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getallnotificationdefinitionids__default(),
            new Object[][] {
                new Object[] {
               P009M2_A164WWPNotificationDefinitionName, P009M2_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               P009M3_A164WWPNotificationDefinitionName, P009M3_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               P009M4_A164WWPNotificationDefinitionName, P009M4_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               P009M5_A164WWPNotificationDefinitionName, P009M5_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               P009M6_A164WWPNotificationDefinitionName, P009M6_A128WWPNotificationDefinitionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A128WWPNotificationDefinitionId ;
      private string A164WWPNotificationDefinitionName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<short> AV8AgendaNotificationDefinitionIdCollection ;
      private GxSimpleCollection<short> AV10DynamicFormNotificationDefinitionIdCollection ;
      private GxSimpleCollection<short> AV9DiscussionNotificationDefinitionIdCollection ;
      private GxSimpleCollection<short> AV12MentionNotificationDefinitionIdCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P009M2_A164WWPNotificationDefinitionName ;
      private long[] P009M2_A128WWPNotificationDefinitionId ;
      private string[] P009M3_A164WWPNotificationDefinitionName ;
      private long[] P009M3_A128WWPNotificationDefinitionId ;
      private string[] P009M4_A164WWPNotificationDefinitionName ;
      private long[] P009M4_A128WWPNotificationDefinitionId ;
      private string[] P009M5_A164WWPNotificationDefinitionName ;
      private long[] P009M5_A128WWPNotificationDefinitionId ;
      private GxSimpleCollection<short> AV11InsertNotificationDefinitionIdCollection ;
      private string[] P009M6_A164WWPNotificationDefinitionName ;
      private long[] P009M6_A128WWPNotificationDefinitionId ;
      private GxSimpleCollection<short> aP0_AgendaNotificationDefinitionIdCollection ;
      private GxSimpleCollection<short> aP1_DynamicFormNotificationDefinitionIdCollection ;
      private GxSimpleCollection<short> aP2_DiscussionNotificationDefinitionIdCollection ;
      private GxSimpleCollection<short> aP3_MentionNotificationDefinitionIdCollection ;
   }

   public class prc_getallnotificationdefinitionids__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009M2;
          prmP009M2 = new Object[] {
          };
          Object[] prmP009M3;
          prmP009M3 = new Object[] {
          };
          Object[] prmP009M4;
          prmP009M4 = new Object[] {
          };
          Object[] prmP009M5;
          prmP009M5 = new Object[] {
          };
          Object[] prmP009M6;
          prmP009M6 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P009M2", "SELECT WWPNotificationDefinitionName, WWPNotificationDefinitionId FROM WWP_NotificationDefinition ORDER BY WWPNotificationDefinitionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009M2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009M3", "SELECT WWPNotificationDefinitionName, WWPNotificationDefinitionId FROM WWP_NotificationDefinition ORDER BY WWPNotificationDefinitionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009M3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009M4", "SELECT WWPNotificationDefinitionName, WWPNotificationDefinitionId FROM WWP_NotificationDefinition ORDER BY WWPNotificationDefinitionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009M4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009M5", "SELECT WWPNotificationDefinitionName, WWPNotificationDefinitionId FROM WWP_NotificationDefinition ORDER BY WWPNotificationDefinitionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009M5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009M6", "SELECT WWPNotificationDefinitionName, WWPNotificationDefinitionId FROM WWP_NotificationDefinition ORDER BY WWPNotificationDefinitionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009M6,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
