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
   public class trn_tileconversion : GXProcedure
   {
      public trn_tileconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_tileconversion( IGxContext context )
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
         /* Using cursor TRN_TILECO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A319Trn_RowId = TRN_TILECO2_A319Trn_RowId[0];
            A310Trn_PageId = TRN_TILECO2_A310Trn_PageId[0];
            A328Trn_ColId = TRN_TILECO2_A328Trn_ColId[0];
            A271Trn_TileBGImageUrl = TRN_TILECO2_A271Trn_TileBGImageUrl[0];
            A270Trn_TileColor = TRN_TILECO2_A270Trn_TileColor[0];
            A58ProductServiceId = TRN_TILECO2_A58ProductServiceId[0];
            n58ProductServiceId = TRN_TILECO2_n58ProductServiceId[0];
            A268Trn_TileWidth = TRN_TILECO2_A268Trn_TileWidth[0];
            A265Trn_TileName = TRN_TILECO2_A265Trn_TileName[0];
            A264Trn_TileId = TRN_TILECO2_A264Trn_TileId[0];
            A319Trn_RowId = TRN_TILECO2_A319Trn_RowId[0];
            A310Trn_PageId = TRN_TILECO2_A310Trn_PageId[0];
            /*
               INSERT RECORD ON TABLE GXA0050

            */
            AV2Trn_TileId = A264Trn_TileId;
            AV3Trn_TileName = A265Trn_TileName;
            AV4Trn_TileWidth = A268Trn_TileWidth;
            if ( TRN_TILECO2_n58ProductServiceId[0] )
            {
               AV5ProductServiceId = Guid.Empty;
               nV5ProductServiceId = false;
               nV5ProductServiceId = true;
            }
            else
            {
               AV5ProductServiceId = A58ProductServiceId;
               nV5ProductServiceId = false;
            }
            AV6Trn_TileColor = A270Trn_TileColor;
            AV7Trn_TileBGImageUrl = A271Trn_TileBGImageUrl;
            AV8Trn_ColId = A328Trn_ColId;
            if ( TRN_TILECO2_n310Trn_PageId[0] )
            {
               AV9SG_ToPageId = Guid.Empty;
            }
            else
            {
               AV9SG_ToPageId = A310Trn_PageId;
            }
            /* Using cursor TRN_TILECO3 */
            pr_default.execute(1, new Object[] {AV2Trn_TileId, AV3Trn_TileName, AV4Trn_TileWidth, nV5ProductServiceId, AV5ProductServiceId, AV6Trn_TileColor, AV7Trn_TileBGImageUrl, AV8Trn_ColId, AV9SG_ToPageId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0050");
            if ( (pr_default.getStatus(1) == 1) )
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
         TRN_TILECO2_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_A271Trn_TileBGImageUrl = new string[] {""} ;
         TRN_TILECO2_A270Trn_TileColor = new string[] {""} ;
         TRN_TILECO2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_n58ProductServiceId = new bool[] {false} ;
         TRN_TILECO2_A268Trn_TileWidth = new short[1] ;
         TRN_TILECO2_A265Trn_TileName = new string[] {""} ;
         TRN_TILECO2_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         A319Trn_RowId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         A328Trn_ColId = Guid.Empty;
         A271Trn_TileBGImageUrl = "";
         A270Trn_TileColor = "";
         A58ProductServiceId = Guid.Empty;
         A265Trn_TileName = "";
         A264Trn_TileId = Guid.Empty;
         AV2Trn_TileId = Guid.Empty;
         AV3Trn_TileName = "";
         AV5ProductServiceId = Guid.Empty;
         AV6Trn_TileColor = "";
         AV7Trn_TileBGImageUrl = "";
         AV8Trn_ColId = Guid.Empty;
         TRN_TILECO2_n310Trn_PageId = new bool[] {false} ;
         AV9SG_ToPageId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tileconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_TILECO2_A319Trn_RowId, TRN_TILECO2_A310Trn_PageId, TRN_TILECO2_A328Trn_ColId, TRN_TILECO2_A271Trn_TileBGImageUrl, TRN_TILECO2_A270Trn_TileColor, TRN_TILECO2_A58ProductServiceId, TRN_TILECO2_n58ProductServiceId, TRN_TILECO2_A268Trn_TileWidth, TRN_TILECO2_A265Trn_TileName, TRN_TILECO2_A264Trn_TileId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A268Trn_TileWidth ;
      private short AV4Trn_TileWidth ;
      private int GIGXA0050 ;
      private string A270Trn_TileColor ;
      private string AV6Trn_TileColor ;
      private string Gx_emsg ;
      private bool n58ProductServiceId ;
      private bool nV5ProductServiceId ;
      private string A271Trn_TileBGImageUrl ;
      private string A265Trn_TileName ;
      private string AV3Trn_TileName ;
      private string AV7Trn_TileBGImageUrl ;
      private Guid A319Trn_RowId ;
      private Guid A310Trn_PageId ;
      private Guid A328Trn_ColId ;
      private Guid A58ProductServiceId ;
      private Guid A264Trn_TileId ;
      private Guid AV2Trn_TileId ;
      private Guid AV5ProductServiceId ;
      private Guid AV8Trn_ColId ;
      private Guid AV9SG_ToPageId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_TILECO2_A319Trn_RowId ;
      private Guid[] TRN_TILECO2_A310Trn_PageId ;
      private Guid[] TRN_TILECO2_A328Trn_ColId ;
      private string[] TRN_TILECO2_A271Trn_TileBGImageUrl ;
      private string[] TRN_TILECO2_A270Trn_TileColor ;
      private Guid[] TRN_TILECO2_A58ProductServiceId ;
      private bool[] TRN_TILECO2_n58ProductServiceId ;
      private short[] TRN_TILECO2_A268Trn_TileWidth ;
      private string[] TRN_TILECO2_A265Trn_TileName ;
      private Guid[] TRN_TILECO2_A264Trn_TileId ;
      private bool[] TRN_TILECO2_n310Trn_PageId ;
   }

   public class trn_tileconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTRN_TILECO2;
          prmTRN_TILECO2 = new Object[] {
          };
          Object[] prmTRN_TILECO3;
          prmTRN_TILECO3 = new Object[] {
          new ParDef("AV2Trn_TileId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3Trn_TileName",GXType.VarChar,100,0) ,
          new ParDef("AV4Trn_TileWidth",GXType.Int16,4,0) ,
          new ParDef("AV5ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV6Trn_TileColor",GXType.Char,20,0) ,
          new ParDef("AV7Trn_TileBGImageUrl",GXType.VarChar,1000,0) ,
          new ParDef("AV8Trn_ColId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9SG_ToPageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_TILECO2", "SELECT T2.Trn_RowId, T3.Trn_PageId, T1.Trn_ColId, T1.Trn_TileBGImageUrl, T1.Trn_TileColor, T1.ProductServiceId, T1.Trn_TileWidth, T1.Trn_TileName, T1.Trn_TileId FROM ((Trn_Tile T1 INNER JOIN Trn_Col T2 ON T2.Trn_ColId = T1.Trn_ColId) INNER JOIN Trn_Row T3 ON T3.Trn_RowId = T2.Trn_RowId) ORDER BY T1.Trn_TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_TILECO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_TILECO3", "INSERT INTO GXA0050(Trn_TileId, Trn_TileName, Trn_TileWidth, ProductServiceId, Trn_TileColor, Trn_TileBGImageUrl, Trn_ColId, SG_ToPageId) VALUES(:AV2Trn_TileId, :AV3Trn_TileName, :AV4Trn_TileWidth, :AV5ProductServiceId, :AV6Trn_TileColor, :AV7Trn_TileBGImageUrl, :AV8Trn_ColId, :AV9SG_ToPageId)", GxErrorMask.GX_NOMASK,prmTRN_TILECO3)
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[9])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
