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
   public class trn_productserviceconversion : GXProcedure
   {
      public trn_productserviceconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_productserviceconversion( IGxContext context )
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

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor TRN_PRODUC2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A60ProductServiceDescription = TRN_PRODUC2_A60ProductServiceDescription[0];
            A59ProductServiceName = TRN_PRODUC2_A59ProductServiceName[0];
            A40003ProductServiceImage_GXI = TRN_PRODUC2_A40003ProductServiceImage_GXI[0];
            A58ProductServiceId = TRN_PRODUC2_A58ProductServiceId[0];
            A61ProductServiceImage = TRN_PRODUC2_A61ProductServiceImage[0];
            AV11GXV42 = Guid.Empty;
            /* Using cursor TRN_PRODUC3 */
            pr_default.execute(1, new Object[] {A58ProductServiceId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A42SupplierGenId = TRN_PRODUC3_A42SupplierGenId[0];
               AV11GXV42 = A42SupplierGenId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV12GXV49 = Guid.Empty;
            /* Using cursor TRN_PRODUC4 */
            pr_default.execute(2, new Object[] {A58ProductServiceId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A49SupplierAgbId = TRN_PRODUC4_A49SupplierAgbId[0];
               AV12GXV49 = A49SupplierAgbId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /*
               INSERT RECORD ON TABLE GXA0013

            */
            AV2ProductServiceId = A58ProductServiceId;
            AV3ProductServiceName = A59ProductServiceName;
            AV4ProductServiceDescription = A60ProductServiceDescription;
            AV5ProductServiceImage = A61ProductServiceImage;
            AV6ProductServiceImage_GXI = A40003ProductServiceImage_GXI;
            AV6ProductServiceImage_GXI = A40003ProductServiceImage_GXI;
            AV7ProductServiceTileName = " ";
            if ( (Guid.Empty==AV11GXV42) )
            {
               AV8SupplierGenId = Guid.Empty;
               nV8SupplierGenId = false;
               nV8SupplierGenId = true;
            }
            else
            {
               AV8SupplierGenId = AV11GXV42;
               nV8SupplierGenId = false;
            }
            if ( (Guid.Empty==AV12GXV49) )
            {
               AV9SupplierAgbId = Guid.Empty;
               nV9SupplierAgbId = false;
               nV9SupplierAgbId = true;
            }
            else
            {
               AV9SupplierAgbId = AV12GXV49;
               nV9SupplierAgbId = false;
            }
            AV10LocationId = Guid.Empty;
            /* Using cursor TRN_PRODUC5 */
            pr_default.execute(3, new Object[] {AV2ProductServiceId, AV3ProductServiceName, AV4ProductServiceDescription, AV5ProductServiceImage, AV6ProductServiceImage_GXI, AV7ProductServiceTileName, nV8SupplierGenId, AV8SupplierGenId, nV9SupplierAgbId, AV9SupplierAgbId, AV10LocationId});
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("GXA0013");
            if ( (pr_default.getStatus(3) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         TRN_PRODUC2_A60ProductServiceDescription = new string[] {""} ;
         TRN_PRODUC2_A59ProductServiceName = new string[] {""} ;
         TRN_PRODUC2_A40003ProductServiceImage_GXI = new string[] {""} ;
         TRN_PRODUC2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         TRN_PRODUC2_A61ProductServiceImage = new string[] {""} ;
         A60ProductServiceDescription = "";
         A59ProductServiceName = "";
         A40003ProductServiceImage_GXI = "";
         A58ProductServiceId = Guid.Empty;
         A61ProductServiceImage = "";
         AV11GXV42 = Guid.Empty;
         TRN_PRODUC3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         TRN_PRODUC3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         A42SupplierGenId = Guid.Empty;
         AV12GXV49 = Guid.Empty;
         TRN_PRODUC4_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         TRN_PRODUC4_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         A49SupplierAgbId = Guid.Empty;
         AV2ProductServiceId = Guid.Empty;
         AV3ProductServiceName = "";
         AV4ProductServiceDescription = "";
         AV5ProductServiceImage = "";
         AV6ProductServiceImage_GXI = "";
         AV7ProductServiceTileName = "";
         AV8SupplierGenId = Guid.Empty;
         AV9SupplierAgbId = Guid.Empty;
         AV10LocationId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productserviceconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_PRODUC2_A60ProductServiceDescription, TRN_PRODUC2_A59ProductServiceName, TRN_PRODUC2_A40003ProductServiceImage_GXI, TRN_PRODUC2_A58ProductServiceId, TRN_PRODUC2_A61ProductServiceImage
               }
               , new Object[] {
               TRN_PRODUC3_A58ProductServiceId, TRN_PRODUC3_A42SupplierGenId
               }
               , new Object[] {
               TRN_PRODUC4_A58ProductServiceId, TRN_PRODUC4_A49SupplierAgbId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0013 ;
      private string AV7ProductServiceTileName ;
      private string Gx_emsg ;
      private bool nV8SupplierGenId ;
      private bool nV9SupplierAgbId ;
      private string A60ProductServiceDescription ;
      private string A59ProductServiceName ;
      private string A40003ProductServiceImage_GXI ;
      private string AV3ProductServiceName ;
      private string AV4ProductServiceDescription ;
      private string AV6ProductServiceImage_GXI ;
      private string A61ProductServiceImage ;
      private string AV5ProductServiceImage ;
      private Guid A58ProductServiceId ;
      private Guid AV11GXV42 ;
      private Guid A42SupplierGenId ;
      private Guid AV12GXV49 ;
      private Guid A49SupplierAgbId ;
      private Guid AV2ProductServiceId ;
      private Guid AV8SupplierGenId ;
      private Guid AV9SupplierAgbId ;
      private Guid AV10LocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TRN_PRODUC2_A60ProductServiceDescription ;
      private string[] TRN_PRODUC2_A59ProductServiceName ;
      private string[] TRN_PRODUC2_A40003ProductServiceImage_GXI ;
      private Guid[] TRN_PRODUC2_A58ProductServiceId ;
      private string[] TRN_PRODUC2_A61ProductServiceImage ;
      private Guid[] TRN_PRODUC3_A58ProductServiceId ;
      private Guid[] TRN_PRODUC3_A42SupplierGenId ;
      private Guid[] TRN_PRODUC4_A58ProductServiceId ;
      private Guid[] TRN_PRODUC4_A49SupplierAgbId ;
   }

   public class trn_productserviceconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTRN_PRODUC2;
          prmTRN_PRODUC2 = new Object[] {
          };
          Object[] prmTRN_PRODUC3;
          prmTRN_PRODUC3 = new Object[] {
          new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTRN_PRODUC4;
          prmTRN_PRODUC4 = new Object[] {
          new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTRN_PRODUC5;
          prmTRN_PRODUC5 = new Object[] {
          new ParDef("AV2ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3ProductServiceName",GXType.VarChar,100,0) ,
          new ParDef("AV4ProductServiceDescription",GXType.VarChar,200,0) ,
          new ParDef("AV5ProductServiceImage",GXType.Byte,1024,0){InDB=false} ,
          new ParDef("AV6ProductServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="GXA0013", Fld="ProductServiceImage"} ,
          new ParDef("AV7ProductServiceTileName",GXType.Char,20,0) ,
          new ParDef("AV8SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV9SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_PRODUC2", "SELECT ProductServiceDescription, ProductServiceName, ProductServiceImage_GXI, ProductServiceId, ProductServiceImage FROM Trn_ProductService ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_PRODUC2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_PRODUC3", "SELECT ProductServiceId, SupplierGenId FROM Trn_SupplierGenProductService WHERE ProductServiceId = :ProductServiceId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_PRODUC3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("TRN_PRODUC4", "SELECT ProductServiceId, SupplierAgbId FROM Trn_SupplierAGBProductService WHERE ProductServiceId = :ProductServiceId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_PRODUC4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("TRN_PRODUC5", "INSERT INTO GXA0013(ProductServiceId, ProductServiceName, ProductServiceDescription, ProductServiceImage, ProductServiceImage_GXI, ProductServiceTileName, SupplierGenId, SupplierAgbId, LocationId) VALUES(:AV2ProductServiceId, :AV3ProductServiceName, :AV4ProductServiceDescription, :AV5ProductServiceImage, :AV6ProductServiceImage_GXI, :AV7ProductServiceTileName, :AV8SupplierGenId, :AV9SupplierAgbId, :AV10LocationId)", GxErrorMask.GX_NOMASK,prmTRN_PRODUC5)
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
