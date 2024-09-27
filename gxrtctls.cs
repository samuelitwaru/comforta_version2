using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxrtctls : GXProcedure
   {
      public gxrtctls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public gxrtctls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         initialize();
         ExecuteImpl();
         aP0_Status=this.AV2Status;
      }

      public short executeUdp( )
      {
         execute(out aP0_Status);
         return AV2Status ;
      }

      public void executeSubmit( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         SubmitImpl();
         aP0_Status=this.AV2Status;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV2Status = 0;
         Console.WriteLine( "=== Starting run time controls" );
         Console.WriteLine( "Checking that table Trn_Receptionist does NOT contain records." );
         AV3NotFound = 0;
         AV4GXLvl5 = 0;
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = LTCTLS2_A29LocationId[0];
            A89ReceptionistId = LTCTLS2_A89ReceptionistId[0];
            AV4GXLvl5 = 1;
            AV5GXLvl8 = 0;
            /* Using cursor LTCTLS3 */
            pr_default.execute(1, new Object[] {A29LocationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11OrganisationId = LTCTLS3_A11OrganisationId[0];
               if ( A11OrganisationId == Guid.Empty )
               {
                  AV5GXLvl8 = 1;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV5GXLvl8 == 0 )
            {
               AV2Status = 1;
               Console.WriteLine( "Fail: Table Trn_Receptionist has records but referenced key value in table Trn_Location does _not_ exist." );
               Console.WriteLine( "Recovery: See recovery information for reorganization message rgz0029." );
               AV3NotFound = 1;
            }
            if ( AV3NotFound == 1 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV4GXLvl5 == 0 )
         {
            Console.WriteLine( "Success: Table Trn_Receptionist does NOT have records." );
            AV3NotFound = 1;
         }
         if ( AV3NotFound == 0 )
         {
            Console.WriteLine( "Success: Table Trn_Receptionisthas records but all referenced key values in table Trn_Location exist." );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( "Checking that table Trn_Amenity does NOT contain records." );
         AV3NotFound = 0;
         AV6GXLvl29 = 0;
         /* Using cursor LTCTLS4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A29LocationId = LTCTLS4_A29LocationId[0];
            A39AmenityId = LTCTLS4_A39AmenityId[0];
            AV6GXLvl29 = 1;
            AV7GXLvl32 = 0;
            /* Using cursor LTCTLS5 */
            pr_default.execute(3, new Object[] {A29LocationId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A11OrganisationId = LTCTLS5_A11OrganisationId[0];
               if ( A11OrganisationId == Guid.Empty )
               {
                  AV7GXLvl32 = 1;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV7GXLvl32 == 0 )
            {
               AV2Status = 1;
               Console.WriteLine( "Fail: Table Trn_Amenity has records but referenced key value in table Trn_Location does _not_ exist." );
               Console.WriteLine( "Recovery: See recovery information for reorganization message rgz0029." );
               AV3NotFound = 1;
            }
            if ( AV3NotFound == 1 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( AV6GXLvl29 == 0 )
         {
            Console.WriteLine( "Success: Table Trn_Amenity does NOT have records." );
            AV3NotFound = 1;
         }
         if ( AV3NotFound == 0 )
         {
            Console.WriteLine( "Success: Table Trn_Amenityhas records but all referenced key values in table Trn_Location exist." );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( "Checking that table Trn_ProductService does NOT contain records." );
         AV3NotFound = 0;
         AV8GXLvl53 = 0;
         /* Using cursor LTCTLS6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A29LocationId = LTCTLS6_A29LocationId[0];
            A58ProductServiceId = LTCTLS6_A58ProductServiceId[0];
            AV8GXLvl53 = 1;
            AV9GXLvl56 = 0;
            /* Using cursor LTCTLS7 */
            pr_default.execute(5, new Object[] {A29LocationId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A11OrganisationId = LTCTLS7_A11OrganisationId[0];
               if ( A11OrganisationId == Guid.Empty )
               {
                  AV9GXLvl56 = 1;
               }
               pr_default.readNext(5);
            }
            pr_default.close(5);
            if ( AV9GXLvl56 == 0 )
            {
               AV2Status = 1;
               Console.WriteLine( "Fail: Table Trn_ProductService has records but referenced key value in table Trn_Location does _not_ exist." );
               Console.WriteLine( "Recovery: See recovery information for reorganization message rgz0029." );
               AV3NotFound = 1;
            }
            if ( AV3NotFound == 1 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( AV8GXLvl53 == 0 )
         {
            Console.WriteLine( "Success: Table Trn_ProductService does NOT have records." );
            AV3NotFound = 1;
         }
         if ( AV3NotFound == 0 )
         {
            Console.WriteLine( "Success: Table Trn_ProductServicehas records but all referenced key values in table Trn_Location exist." );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( "=== End of run time controls" );
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
         LTCTLS2_A29LocationId = new Guid[] {Guid.Empty} ;
         LTCTLS2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         LTCTLS3_A29LocationId = new Guid[] {Guid.Empty} ;
         LTCTLS3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         LTCTLS4_A29LocationId = new Guid[] {Guid.Empty} ;
         LTCTLS4_A39AmenityId = new Guid[] {Guid.Empty} ;
         A39AmenityId = Guid.Empty;
         LTCTLS5_A29LocationId = new Guid[] {Guid.Empty} ;
         LTCTLS5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         LTCTLS6_A29LocationId = new Guid[] {Guid.Empty} ;
         LTCTLS6_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         LTCTLS7_A29LocationId = new Guid[] {Guid.Empty} ;
         LTCTLS7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A29LocationId, LTCTLS2_A89ReceptionistId
               }
               , new Object[] {
               LTCTLS3_A29LocationId, LTCTLS3_A11OrganisationId
               }
               , new Object[] {
               LTCTLS4_A29LocationId, LTCTLS4_A39AmenityId
               }
               , new Object[] {
               LTCTLS5_A29LocationId, LTCTLS5_A11OrganisationId
               }
               , new Object[] {
               LTCTLS6_A29LocationId, LTCTLS6_A58ProductServiceId
               }
               , new Object[] {
               LTCTLS7_A29LocationId, LTCTLS7_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV2Status ;
      private short AV3NotFound ;
      private short AV4GXLvl5 ;
      private short AV5GXLvl8 ;
      private short AV6GXLvl29 ;
      private short AV7GXLvl32 ;
      private short AV8GXLvl53 ;
      private short AV9GXLvl56 ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private Guid A11OrganisationId ;
      private Guid A39AmenityId ;
      private Guid A58ProductServiceId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] LTCTLS2_A29LocationId ;
      private Guid[] LTCTLS2_A89ReceptionistId ;
      private Guid[] LTCTLS3_A29LocationId ;
      private Guid[] LTCTLS3_A11OrganisationId ;
      private Guid[] LTCTLS4_A29LocationId ;
      private Guid[] LTCTLS4_A39AmenityId ;
      private Guid[] LTCTLS5_A29LocationId ;
      private Guid[] LTCTLS5_A11OrganisationId ;
      private Guid[] LTCTLS6_A29LocationId ;
      private Guid[] LTCTLS6_A58ProductServiceId ;
      private Guid[] LTCTLS7_A29LocationId ;
      private Guid[] LTCTLS7_A11OrganisationId ;
      private short aP0_Status ;
   }

   public class gxrtctls__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmLTCTLS2;
          prmLTCTLS2 = new Object[] {
          };
          Object[] prmLTCTLS3;
          prmLTCTLS3 = new Object[] {
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmLTCTLS4;
          prmLTCTLS4 = new Object[] {
          };
          Object[] prmLTCTLS5;
          prmLTCTLS5 = new Object[] {
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmLTCTLS6;
          prmLTCTLS6 = new Object[] {
          };
          Object[] prmLTCTLS7;
          prmLTCTLS7 = new Object[] {
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT DISTINCT LocationId, ReceptionistId FROM Trn_Receptionist ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LTCTLS3", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("LTCTLS4", "SELECT DISTINCT LocationId, AmenityId FROM Trn_Amenity ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LTCTLS5", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("LTCTLS6", "SELECT DISTINCT LocationId, ProductServiceId FROM Trn_ProductService ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LTCTLS7", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS7,100, GxCacheFrequency.OFF ,false,false )
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
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
