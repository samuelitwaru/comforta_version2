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
            A329SG_ToPageId = TRN_TILECO2_A329SG_ToPageId[0];
            A29LocationId = TRN_TILECO2_A29LocationId[0];
            n29LocationId = TRN_TILECO2_n29LocationId[0];
            A11OrganisationId = TRN_TILECO2_A11OrganisationId[0];
            n11OrganisationId = TRN_TILECO2_n11OrganisationId[0];
            A58ProductServiceId = TRN_TILECO2_A58ProductServiceId[0];
            n58ProductServiceId = TRN_TILECO2_n58ProductServiceId[0];
            A264Trn_TileId = TRN_TILECO2_A264Trn_TileId[0];
            /*
               INSERT RECORD ON TABLE GXA0081

            */
            AV2TileId = Guid.Empty;
            AV3TileName = " ";
            AV4TileIcon = "";
            nV4TileIcon = false;
            nV4TileIcon = true;
            AV5TileBGColor = "";
            nV5TileBGColor = false;
            nV5TileBGColor = true;
            AV6TileBGImageUrl = "";
            nV6TileBGImageUrl = false;
            nV6TileBGImageUrl = true;
            AV7TileTextColor = " ";
            AV8TileTextAlignment = " ";
            AV9TileIconAlignment = " ";
            if ( TRN_TILECO2_n58ProductServiceId[0] )
            {
               AV10ProductServiceId = Guid.Empty;
               nV10ProductServiceId = false;
               nV10ProductServiceId = true;
            }
            else
            {
               AV10ProductServiceId = A58ProductServiceId;
               nV10ProductServiceId = false;
            }
            if ( TRN_TILECO2_n11OrganisationId[0] )
            {
               AV11OrganisationId = Guid.Empty;
               nV11OrganisationId = false;
               nV11OrganisationId = true;
            }
            else
            {
               AV11OrganisationId = A11OrganisationId;
               nV11OrganisationId = false;
            }
            if ( TRN_TILECO2_n29LocationId[0] )
            {
               AV12LocationId = Guid.Empty;
               nV12LocationId = false;
               nV12LocationId = true;
            }
            else
            {
               AV12LocationId = A29LocationId;
               nV12LocationId = false;
            }
            AV13SG_ToPageId = A329SG_ToPageId;
            /* Using cursor TRN_TILECO3 */
            pr_default.execute(1, new Object[] {AV2TileId});
            if ( (pr_default.getStatus(1) != 101) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
               /* Using cursor TRN_TILECO4 */
               pr_default.execute(2, new Object[] {AV2TileId, AV3TileName, nV4TileIcon, AV4TileIcon, nV5TileBGColor, AV5TileBGColor, nV6TileBGImageUrl, AV6TileBGImageUrl, AV7TileTextColor, AV8TileTextAlignment, AV9TileIconAlignment, nV10ProductServiceId, AV10ProductServiceId, nV11OrganisationId, AV11OrganisationId, nV12LocationId, AV12LocationId, AV13SG_ToPageId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("GXA0081");
            }
            /* End Insert */
            pr_default.close(1);
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
         TRN_TILECO2_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_n29LocationId = new bool[] {false} ;
         TRN_TILECO2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_n11OrganisationId = new bool[] {false} ;
         TRN_TILECO2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         TRN_TILECO2_n58ProductServiceId = new bool[] {false} ;
         TRN_TILECO2_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         A329SG_ToPageId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A264Trn_TileId = Guid.Empty;
         AV2TileId = Guid.Empty;
         AV3TileName = "";
         AV4TileIcon = "";
         AV5TileBGColor = "";
         AV6TileBGImageUrl = "";
         AV7TileTextColor = "";
         AV8TileTextAlignment = "";
         AV9TileIconAlignment = "";
         AV10ProductServiceId = Guid.Empty;
         AV11OrganisationId = Guid.Empty;
         AV12LocationId = Guid.Empty;
         AV13SG_ToPageId = Guid.Empty;
         TRN_TILECO3_AV2TileId = new Guid[] {Guid.Empty} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tileconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_TILECO2_A329SG_ToPageId, TRN_TILECO2_A29LocationId, TRN_TILECO2_n29LocationId, TRN_TILECO2_A11OrganisationId, TRN_TILECO2_n11OrganisationId, TRN_TILECO2_A58ProductServiceId, TRN_TILECO2_n58ProductServiceId, TRN_TILECO2_A264Trn_TileId
               }
               , new Object[] {
               TRN_TILECO3_AV2TileId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0081 ;
      private string AV4TileIcon ;
      private string AV5TileBGColor ;
      private string AV7TileTextColor ;
      private string AV8TileTextAlignment ;
      private string AV9TileIconAlignment ;
      private string Gx_emsg ;
      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private bool n58ProductServiceId ;
      private bool nV4TileIcon ;
      private bool nV5TileBGColor ;
      private bool nV6TileBGImageUrl ;
      private bool nV10ProductServiceId ;
      private bool nV11OrganisationId ;
      private bool nV12LocationId ;
      private string AV3TileName ;
      private string AV6TileBGImageUrl ;
      private Guid A329SG_ToPageId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A58ProductServiceId ;
      private Guid A264Trn_TileId ;
      private Guid AV2TileId ;
      private Guid AV10ProductServiceId ;
      private Guid AV11OrganisationId ;
      private Guid AV12LocationId ;
      private Guid AV13SG_ToPageId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_TILECO2_A329SG_ToPageId ;
      private Guid[] TRN_TILECO2_A29LocationId ;
      private bool[] TRN_TILECO2_n29LocationId ;
      private Guid[] TRN_TILECO2_A11OrganisationId ;
      private bool[] TRN_TILECO2_n11OrganisationId ;
      private Guid[] TRN_TILECO2_A58ProductServiceId ;
      private bool[] TRN_TILECO2_n58ProductServiceId ;
      private Guid[] TRN_TILECO2_A264Trn_TileId ;
      private Guid[] TRN_TILECO3_AV2TileId ;
   }

   public class trn_tileconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
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
          new ParDef("AV2TileId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTRN_TILECO4;
          prmTRN_TILECO4 = new Object[] {
          new ParDef("AV2TileId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3TileName",GXType.VarChar,100,0) ,
          new ParDef("AV4TileIcon",GXType.Char,20,0){Nullable=true} ,
          new ParDef("AV5TileBGColor",GXType.Char,20,0){Nullable=true} ,
          new ParDef("AV6TileBGImageUrl",GXType.VarChar,1000,0){Nullable=true} ,
          new ParDef("AV7TileTextColor",GXType.Char,20,0) ,
          new ParDef("AV8TileTextAlignment",GXType.Char,20,0) ,
          new ParDef("AV9TileIconAlignment",GXType.Char,20,0) ,
          new ParDef("AV10ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV11OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV12LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV13SG_ToPageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_TILECO2", "SELECT SG_ToPageId, LocationId, OrganisationId, ProductServiceId, Trn_TileId FROM Trn_Tile ORDER BY Trn_TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_TILECO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_TILECO3", "SELECT TileId FROM GXA0081 WHERE TileId = :AV2TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_TILECO3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_TILECO4", "INSERT INTO GXA0081(TileId, TileName, TileIcon, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIconAlignment, ProductServiceId, OrganisationId, LocationId, SG_ToPageId) VALUES(:AV2TileId, :AV3TileName, :AV4TileIcon, :AV5TileBGColor, :AV6TileBGImageUrl, :AV7TileTextColor, :AV8TileTextAlignment, :AV9TileIconAlignment, :AV10ProductServiceId, :AV11OrganisationId, :AV12LocationId, :AV13SG_ToPageId)", GxErrorMask.GX_NOMASK,prmTRN_TILECO4)
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((Guid[]) buf[7])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
