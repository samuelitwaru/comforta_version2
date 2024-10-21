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
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void ReorganizeTrn_Organisation( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Organisation */
         cmdBuffer=" ALTER TABLE Trn_Organisation ALTER COLUMN OrganisationId DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeTrn_SupplierGen( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_SupplierGen */
         cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD OrganisationId CHAR(36) DEFAULT '00000000-0000-0000-0000-000000000000' "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" UPDATE Trn_SupplierGen SET OrganisationId=T.OrganisationId FROM Trn_ProductService T WHERE Trn_SupplierGen.SupplierGenId= T.SupplierGenId "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_SupplierGen ALTER COLUMN OrganisationId DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" INSERT INTO Trn_OrganisationType (OrganisationTypeId, OrganisationTypeName) SELECT '00000000-0000-0000-0000-000000000000', ' ' FROM Trn_SupplierGen WHERE NOT EXISTS (SELECT 1 FROM Trn_OrganisationType WHERE OrganisationTypeId='00000000-0000-0000-0000-000000000000') LIMIT 1 "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" INSERT INTO Trn_Organisation (OrganisationId, OrganisationKvkNumber, OrganisationName, OrganisationEmail, OrganisationPhone, OrganisationVATNumber, OrganisationTypeId, OrganisationAddressZipCode, OrganisationAddressCity, OrganisationAddressCountry, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationPhoneCode, OrganisationPhoneNumber) SELECT '00000000-0000-0000-0000-000000000000', ' ', ' ', ' ', ' ', ' ', '00000000-0000-0000-0000-000000000000', ' ', ' ', ' ', ' ', ' ', ' ', ' ' FROM Trn_SupplierGen WHERE NOT EXISTS (SELECT 1 FROM Trn_Organisation WHERE OrganisationId='00000000-0000-0000-0000-000000000000') LIMIT 1 "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERGEN2 ON Trn_SupplierGen (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_SUPPLIERGEN2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERGEN2 ON Trn_SupplierGen (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void ReorganizeTrn_SupplierAGB( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_SupplierAGB */
         cmdBuffer=" ALTER TABLE Trn_SupplierAGB ADD OrganisationId CHAR(36) DEFAULT '00000000-0000-0000-0000-000000000000' "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" UPDATE Trn_SupplierAGB SET OrganisationId=T.OrganisationId FROM Trn_ProductService T WHERE Trn_SupplierAGB.SupplierAgbId= T.SupplierAgbId "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_SupplierAGB ALTER COLUMN OrganisationId DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" INSERT INTO Trn_OrganisationType (OrganisationTypeId, OrganisationTypeName) SELECT '00000000-0000-0000-0000-000000000000', ' ' FROM Trn_SupplierAGB WHERE NOT EXISTS (SELECT 1 FROM Trn_OrganisationType WHERE OrganisationTypeId='00000000-0000-0000-0000-000000000000') LIMIT 1 "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" INSERT INTO Trn_Organisation (OrganisationId, OrganisationKvkNumber, OrganisationName, OrganisationEmail, OrganisationPhone, OrganisationVATNumber, OrganisationTypeId, OrganisationAddressZipCode, OrganisationAddressCity, OrganisationAddressCountry, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationPhoneCode, OrganisationPhoneNumber) SELECT '00000000-0000-0000-0000-000000000000', ' ', ' ', ' ', ' ', ' ', '00000000-0000-0000-0000-000000000000', ' ', ' ', ' ', ' ', ' ', ' ', ' ' FROM Trn_SupplierAGB WHERE NOT EXISTS (SELECT 1 FROM Trn_Organisation WHERE OrganisationId='00000000-0000-0000-0000-000000000000') LIMIT 1 "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERAGB2 ON Trn_SupplierAGB (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_SUPPLIERAGB2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_SUPPLIERAGB2 ON Trn_SupplierAGB (OrganisationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void ReorganizeTrn_ProductService( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_ProductService */
         cmdBuffer=" ALTER TABLE Trn_ProductService ADD ProductServiceClass VARCHAR(400) NOT NULL DEFAULT '' "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_ProductService ALTER COLUMN ProductServiceClass DROP DEFAULT "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void RITrn_SupplierAGBTrn_Organisation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierAGB ADD CONSTRAINT ITRN_SUPPLIERAGB2 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierAGB DROP CONSTRAINT ITRN_SUPPLIERAGB2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierAGB ADD CONSTRAINT ITRN_SUPPLIERAGB2 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_SupplierGenTrn_Organisation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN2 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierGen DROP CONSTRAINT ITRN_SUPPLIERGEN2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN2 FOREIGN KEY (OrganisationId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
         if ( ! IsResumeMode( ) )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            Trn_OrganisationCount = P00012_ATrn_OrganisationCount[0];
            pr_default.close(0);
            PrintRecordCount ( "Trn_Organisation" ,  Trn_OrganisationCount );
            /* Using cursor P00023 */
            pr_default.execute(1);
            Trn_SupplierGenCount = P00023_ATrn_SupplierGenCount[0];
            pr_default.close(1);
            PrintRecordCount ( "Trn_SupplierGen" ,  Trn_SupplierGenCount );
            /* Using cursor P00034 */
            pr_default.execute(2);
            Trn_SupplierAGBCount = P00034_ATrn_SupplierAGBCount[0];
            pr_default.close(2);
            PrintRecordCount ( "Trn_SupplierAGB" ,  Trn_SupplierAGBCount );
            /* Using cursor P00045 */
            pr_default.execute(3);
            Trn_ProductServiceCount = P00045_ATrn_ProductServiceCount[0];
            pr_default.close(3);
            PrintRecordCount ( "Trn_ProductService" ,  Trn_ProductServiceCount );
         }
      }

      private bool PreviousCheck( )
      {
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = GXUtil.UserId( "Server", context, pr_default);
         if ( ColumnExist("Trn_ProductService",sSchemaVar,"ProductServiceClass") )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_column_exist", new   object[]  {"ProductServiceClass", "Trn_ProductService"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool ColumnExist( string sTableName ,
                                string sMySchemaName ,
                                string sMyColumnName )
      {
         bool result;
         result = false;
         /* Using cursor P00056 */
         pr_default.execute(4, new Object[] {sTableName, sMySchemaName, sMyColumnName});
         while ( (pr_default.getStatus(4) != 101) )
         {
            tablename = P00056_Atablename[0];
            ntablename = P00056_ntablename[0];
            schemaname = P00056_Aschemaname[0];
            nschemaname = P00056_nschemaname[0];
            columnname = P00056_Acolumnname[0];
            ncolumnname = P00056_ncolumnname[0];
            attrelid = P00056_Aattrelid[0];
            nattrelid = P00056_nattrelid[0];
            oid = P00056_Aoid[0];
            noid = P00056_noid[0];
            relname = P00056_Arelname[0];
            nrelname = P00056_nrelname[0];
            result = true;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "ReorganizeTrn_Organisation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "ReorganizeTrn_SupplierGen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "ReorganizeTrn_SupplierAGB" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "ReorganizeTrn_ProductService" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "RITrn_SupplierAGBTrn_Organisation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "RITrn_SupplierGenTrn_Organisation" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Organisation", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_SupplierGen", ""}) );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_SupplierGen" ,  "ReorganizeTrn_Organisation" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_SupplierAGB", ""}) );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_SupplierAGB" ,  "ReorganizeTrn_Organisation" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_ProductService", ""}) );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierAGB" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierAGB" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierAGB" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierAGB" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierAGB" );
         ReorgExecute.RegisterPrecedence( "ReorganizeTrn_ProductService" ,  "ReorganizeTrn_SupplierAGB" );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERAGB2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierAGBTrn_Organisation" ,  "ReorganizeTrn_SupplierAGB" );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierAGBTrn_Organisation" ,  "ReorganizeTrn_Organisation" );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERGEN2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierGenTrn_Organisation" ,  "ReorganizeTrn_SupplierGen" );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierGenTrn_Organisation" ,  "ReorganizeTrn_Organisation" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void UtilsCleanup( )
      {
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         P00012_ATrn_OrganisationCount = new int[1] ;
         P00023_ATrn_SupplierGenCount = new int[1] ;
         P00034_ATrn_SupplierAGBCount = new int[1] ;
         P00045_ATrn_ProductServiceCount = new int[1] ;
         sSchemaVar = "";
         sTableName = "";
         sMySchemaName = "";
         sMyColumnName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         columnname = "";
         ncolumnname = false;
         attrelid = "";
         nattrelid = false;
         oid = "";
         noid = false;
         relname = "";
         nrelname = false;
         P00056_Atablename = new string[] {""} ;
         P00056_ntablename = new bool[] {false} ;
         P00056_Aschemaname = new string[] {""} ;
         P00056_nschemaname = new bool[] {false} ;
         P00056_Acolumnname = new string[] {""} ;
         P00056_ncolumnname = new bool[] {false} ;
         P00056_Aattrelid = new string[] {""} ;
         P00056_nattrelid = new bool[] {false} ;
         P00056_Aoid = new string[] {""} ;
         P00056_noid = new bool[] {false} ;
         P00056_Arelname = new string[] {""} ;
         P00056_nrelname = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_ATrn_OrganisationCount
               }
               , new Object[] {
               P00023_ATrn_SupplierGenCount
               }
               , new Object[] {
               P00034_ATrn_SupplierAGBCount
               }
               , new Object[] {
               P00045_ATrn_ProductServiceCount
               }
               , new Object[] {
               P00056_Atablename, P00056_Aschemaname, P00056_Acolumnname, P00056_Aattrelid, P00056_Aoid, P00056_Arelname
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int Trn_OrganisationCount ;
      protected int Trn_SupplierGenCount ;
      protected int Trn_SupplierAGBCount ;
      protected int Trn_ProductServiceCount ;
      protected string sSchemaVar ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected string sMyColumnName ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool ncolumnname ;
      protected bool nattrelid ;
      protected bool noid ;
      protected bool nrelname ;
      protected string tablename ;
      protected string schemaname ;
      protected string columnname ;
      protected string attrelid ;
      protected string oid ;
      protected string relname ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected int[] P00012_ATrn_OrganisationCount ;
      protected int[] P00023_ATrn_SupplierGenCount ;
      protected int[] P00034_ATrn_SupplierAGBCount ;
      protected int[] P00045_ATrn_ProductServiceCount ;
      protected string[] P00056_Atablename ;
      protected bool[] P00056_ntablename ;
      protected string[] P00056_Aschemaname ;
      protected bool[] P00056_nschemaname ;
      protected string[] P00056_Acolumnname ;
      protected bool[] P00056_ncolumnname ;
      protected string[] P00056_Aattrelid ;
      protected bool[] P00056_nattrelid ;
      protected string[] P00056_Aoid ;
      protected bool[] P00056_noid ;
      protected string[] P00056_Arelname ;
      protected bool[] P00056_nrelname ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          };
          Object[] prmP00056;
          prmP00056 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0) ,
          new ParDef("sMyColumnName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT COUNT(*) FROM Trn_Organisation ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT COUNT(*) FROM Trn_SupplierGen ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT COUNT(*) FROM Trn_SupplierAGB ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT COUNT(*) FROM Trn_ProductService ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00056", "SELECT T.TABLENAME, T.TABLEOWNER, T1.ATTNAME, T1.ATTRELID, T2.OID, T2.RELNAME FROM PG_TABLES T, PG_ATTRIBUTE T1, PG_CLASS T2 WHERE (UPPER(T.TABLENAME) = ( UPPER(:sTableName))) AND (UPPER(T.TABLEOWNER) = ( UPPER(:sMySchemaName))) AND (UPPER(T1.ATTNAME) = ( UPPER(:sMyColumnName))) AND (T2.OID = ( T1.ATTRELID)) AND (T2.RELNAME = ( T.TABLENAME)) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00056,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
