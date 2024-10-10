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
            A29LocationId = TRN_TILECO2_A29LocationId[0];
            A11OrganisationId = TRN_TILECO2_A11OrganisationId[0];
            A271Trn_TileBGImageUrl = TRN_TILECO2_A271Trn_TileBGImageUrl[0];
            A270Trn_TileColor = TRN_TILECO2_A270Trn_TileColor[0];
            A268Trn_TileWidth = TRN_TILECO2_A268Trn_TileWidth[0];
            A265Trn_TileName = TRN_TILECO2_A265Trn_TileName[0];
            A58ProductServiceId = TRN_TILECO2_A58ProductServiceId[0];
            n58ProductServiceId = TRN_TILECO2_n58ProductServiceId[0];
            A264Trn_TileId = TRN_TILECO2_A264Trn_TileId[0];
            A29LocationId = TRN_TILECO2_A29LocationId[0];
            A11OrganisationId = TRN_TILECO2_A11OrganisationId[0];
            /*
               INSERT RECORD ON TABLE GXA0071

            */
            AV2Trn_TileId = A264Trn_TileId;
            if ( TRN_TILECO2_n58ProductServiceId[0] )
            {
               AV3ProductServiceId = Guid.Empty;
            }
            else
            {
               AV3ProductServiceId = A58ProductServiceId;
            }
            AV4Trn_TileName = A265Trn_TileName;
            AV5Trn_TileWidth = A268Trn_TileWidth;
            AV6Trn_TileColor = A270Trn_TileColor;
            AV7Trn_TileBGImageUrl = A271Trn_TileBGImageUrl;
            if ( TRN_TILECO2_n11OrganisationId[0] )
            {
               AV8OrganisationId = Guid.Empty;
            }
            else
            {
               AV8OrganisationId = A11OrganisationId;
            }
            if ( TRN_TILECO2_n29LocationId[0] )
            {
               AV9LocationId = Guid.Empty;
            }
            else
            {
               AV9LocationId = A29LocationId;
            }
            /* Using cursor TRN_TILECO3 */
            pr_default.execute(1, new Object[] {AV2Trn_TileId, AV3ProductServiceId, AV4Trn_TileName, AV5Trn_TileWidth, AV6Trn_TileColor, AV7Trn_TileBGImageUrl, AV8OrganisationId, AV9LocationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0071");
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
         TRN_TILECO2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_A271Trn_TileBGImageUrl = new string[] {""} ;
         TRN_TILECO2_A270Trn_TileColor = new string[] {""} ;
         TRN_TILECO2_A268Trn_TileWidth = new short[1] ;
         TRN_TILECO2_A265Trn_TileName = new string[] {""} ;
         TRN_TILECO2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_n58ProductServiceId = new bool[] {false} ;
         TRN_TILECO2_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A271Trn_TileBGImageUrl = "";
         A270Trn_TileColor = "";
         A265Trn_TileName = "";
         A58ProductServiceId = Guid.Empty;
         A264Trn_TileId = Guid.Empty;
         AV2Trn_TileId = Guid.Empty;
         AV3ProductServiceId = Guid.Empty;
         AV4Trn_TileName = "";
         AV6Trn_TileColor = "";
         AV7Trn_TileBGImageUrl = "";
         TRN_TILECO2_n11OrganisationId = new bool[] {false} ;
         AV8OrganisationId = Guid.Empty;
         TRN_TILECO2_n29LocationId = new bool[] {false} ;
         AV9LocationId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tileconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_TILECO2_A29LocationId, TRN_TILECO2_A11OrganisationId, TRN_TILECO2_A271Trn_TileBGImageUrl, TRN_TILECO2_A270Trn_TileColor, TRN_TILECO2_A268Trn_TileWidth, TRN_TILECO2_A265Trn_TileName, TRN_TILECO2_A58ProductServiceId, TRN_TILECO2_n58ProductServiceId, TRN_TILECO2_A264Trn_TileId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A268Trn_TileWidth ;
      private short AV5Trn_TileWidth ;
      private int GIGXA0071 ;
      private string A270Trn_TileColor ;
      private string AV6Trn_TileColor ;
      private string Gx_emsg ;
      private bool n58ProductServiceId ;
      private string A271Trn_TileBGImageUrl ;
      private string A265Trn_TileName ;
      private string AV4Trn_TileName ;
      private string AV7Trn_TileBGImageUrl ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid A264Trn_TileId ;
      private Guid AV2Trn_TileId ;
      private Guid AV3ProductServiceId ;
      private Guid AV8OrganisationId ;
      private Guid AV9LocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_TILECO2_A29LocationId ;
      private Guid[] TRN_TILECO2_A11OrganisationId ;
      private string[] TRN_TILECO2_A271Trn_TileBGImageUrl ;
      private string[] TRN_TILECO2_A270Trn_TileColor ;
      private short[] TRN_TILECO2_A268Trn_TileWidth ;
      private string[] TRN_TILECO2_A265Trn_TileName ;
      private Guid[] TRN_TILECO2_A58ProductServiceId ;
      private bool[] TRN_TILECO2_n58ProductServiceId ;
      private Guid[] TRN_TILECO2_A264Trn_TileId ;
      private bool[] TRN_TILECO2_n11OrganisationId ;
      private bool[] TRN_TILECO2_n29LocationId ;
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
          new ParDef("AV3ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV4Trn_TileName",GXType.VarChar,100,0) ,
          new ParDef("AV5Trn_TileWidth",GXType.Int16,4,0) ,
          new ParDef("AV6Trn_TileColor",GXType.Char,20,0) ,
          new ParDef("AV7Trn_TileBGImageUrl",GXType.VarChar,1000,0) ,
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_TILECO2", "SELECT T2.LocationId, T2.OrganisationId, T1.Trn_TileBGImageUrl, T1.Trn_TileColor, T1.Trn_TileWidth, T1.Trn_TileName, T1.ProductServiceId, T1.Trn_TileId FROM (Trn_Col T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) ORDER BY T1.Trn_TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_TILECO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_TILECO3", "INSERT INTO GXA0071(Trn_TileId, ProductServiceId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, OrganisationId, LocationId) VALUES(:AV2Trn_TileId, :AV3ProductServiceId, :AV4Trn_TileName, :AV5Trn_TileWidth, :AV6Trn_TileColor, :AV7Trn_TileBGImageUrl, :AV8OrganisationId, :AV9LocationId)", GxErrorMask.GX_NOMASK,prmTRN_TILECO3)
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((Guid[]) buf[8])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
