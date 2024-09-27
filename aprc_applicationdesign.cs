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
   public class aprc_applicationdesign : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_applicationdesign().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

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

      public aprc_applicationdesign( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_applicationdesign( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Trn_PageName ,
                           out SdtSDT_Page aP1_SDT_Page ,
                           out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         this.AV21Trn_PageName = aP0_Trn_PageName;
         this.AV11SDT_Page = new SdtSDT_Page(context) ;
         this.AV18SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Page=this.AV11SDT_Page;
         aP2_SDT_PageCollection=this.AV18SDT_PageCollection;
      }

      public GXBaseCollection<SdtSDT_Page> executeUdp( string aP0_Trn_PageName ,
                                                       out SdtSDT_Page aP1_SDT_Page )
      {
         execute(aP0_Trn_PageName, out aP1_SDT_Page, out aP2_SDT_PageCollection);
         return AV18SDT_PageCollection ;
      }

      public void executeSubmit( string aP0_Trn_PageName ,
                                 out SdtSDT_Page aP1_SDT_Page ,
                                 out GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection )
      {
         this.AV21Trn_PageName = aP0_Trn_PageName;
         this.AV11SDT_Page = new SdtSDT_Page(context) ;
         this.AV18SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2") ;
         SubmitImpl();
         aP1_SDT_Page=this.AV11SDT_Page;
         aP2_SDT_PageCollection=this.AV18SDT_PageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV21Trn_PageName ,
                                              A318Trn_PageName } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00712 */
         pr_default.execute(0, new Object[] {AV21Trn_PageName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A310Trn_PageId = P00712_A310Trn_PageId[0];
            A318Trn_PageName = P00712_A318Trn_PageName[0];
            AV11SDT_Page = new SdtSDT_Page(context);
            AV11SDT_Page.gxTpr_Pageid = A310Trn_PageId;
            AV11SDT_Page.gxTpr_Pagename = A318Trn_PageName;
            new prc_logtofile(context ).execute(  ">>>>>>>>>>>"+AV21Trn_PageName) ;
            /* Using cursor P00713 */
            pr_default.execute(1, new Object[] {A310Trn_PageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A319Trn_RowId = P00713_A319Trn_RowId[0];
               A320Trn_RowName = P00713_A320Trn_RowName[0];
               AV12SDT_Row = new SdtSDT_Row(context);
               AV12SDT_Row.gxTpr_Rowid = A319Trn_RowId;
               AV12SDT_Row.gxTpr_Rowname = A320Trn_RowName;
               AV11SDT_Page.gxTpr_Row.Add(AV12SDT_Row, 0);
               /* Using cursor P00714 */
               pr_default.execute(2, new Object[] {A319Trn_RowId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A264Trn_TileId = P00714_A264Trn_TileId[0];
                  A265Trn_TileName = P00714_A265Trn_TileName[0];
                  A329SG_ToPageId = P00714_A329SG_ToPageId[0];
                  A330SG_ToPageName = P00714_A330SG_ToPageName[0];
                  A328Trn_ColId = P00714_A328Trn_ColId[0];
                  A327Trn_ColName = P00714_A327Trn_ColName[0];
                  A265Trn_TileName = P00714_A265Trn_TileName[0];
                  A329SG_ToPageId = P00714_A329SG_ToPageId[0];
                  A330SG_ToPageName = P00714_A330SG_ToPageName[0];
                  AV13SDT_Col = new SdtSDT_Col(context);
                  AV13SDT_Col.gxTpr_Colid = A328Trn_ColId;
                  AV13SDT_Col.gxTpr_Colname = A327Trn_ColName;
                  AV12SDT_Row.gxTpr_Col.Add(AV13SDT_Col, 0);
                  /* Using cursor P00715 */
                  pr_default.execute(3, new Object[] {A264Trn_TileId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     AV15SDT_Tile = new SdtSDT_Tile(context);
                     AV15SDT_Tile.gxTpr_Tileid = A264Trn_TileId;
                     AV15SDT_Tile.gxTpr_Tilename = A265Trn_TileName;
                     AV15SDT_Tile.gxTpr_Topageid = A329SG_ToPageId;
                     AV15SDT_Tile.gxTpr_Topagename = A330SG_ToPageName;
                     AV13SDT_Col.gxTpr_Tile = AV15SDT_Tile;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV18SDT_PageCollection.Add(AV11SDT_Page, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new prc_logtofile(context ).execute(  AV18SDT_PageCollection.ToJSonString(false)) ;
         AV20Res = new SdtEO_Program(context).buildpagetree(AV18SDT_PageCollection.ToJSonString(false));
         new prc_logtofile(context ).execute(  AV20Res) ;
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
         AV11SDT_Page = new SdtSDT_Page(context);
         AV18SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         A318Trn_PageName = "";
         P00712_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P00712_A318Trn_PageName = new string[] {""} ;
         A310Trn_PageId = Guid.Empty;
         P00713_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P00713_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         P00713_A320Trn_RowName = new string[] {""} ;
         A319Trn_RowId = Guid.Empty;
         A320Trn_RowName = "";
         AV12SDT_Row = new SdtSDT_Row(context);
         P00714_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         P00714_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         P00714_A265Trn_TileName = new string[] {""} ;
         P00714_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00714_A330SG_ToPageName = new string[] {""} ;
         P00714_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         P00714_A327Trn_ColName = new string[] {""} ;
         A264Trn_TileId = Guid.Empty;
         A265Trn_TileName = "";
         A329SG_ToPageId = Guid.Empty;
         A330SG_ToPageName = "";
         A328Trn_ColId = Guid.Empty;
         A327Trn_ColName = "";
         AV13SDT_Col = new SdtSDT_Col(context);
         P00715_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         AV15SDT_Tile = new SdtSDT_Tile(context);
         AV20Res = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_applicationdesign__default(),
            new Object[][] {
                new Object[] {
               P00712_A310Trn_PageId, P00712_A318Trn_PageName
               }
               , new Object[] {
               P00713_A310Trn_PageId, P00713_A319Trn_RowId, P00713_A320Trn_RowName
               }
               , new Object[] {
               P00714_A319Trn_RowId, P00714_A264Trn_TileId, P00714_A265Trn_TileName, P00714_A329SG_ToPageId, P00714_A330SG_ToPageName, P00714_A328Trn_ColId, P00714_A327Trn_ColName
               }
               , new Object[] {
               P00715_A264Trn_TileId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV20Res ;
      private string AV21Trn_PageName ;
      private string A318Trn_PageName ;
      private string A320Trn_RowName ;
      private string A265Trn_TileName ;
      private string A330SG_ToPageName ;
      private string A327Trn_ColName ;
      private Guid A310Trn_PageId ;
      private Guid A319Trn_RowId ;
      private Guid A264Trn_TileId ;
      private Guid A329SG_ToPageId ;
      private Guid A328Trn_ColId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV11SDT_Page ;
      private GXBaseCollection<SdtSDT_Page> AV18SDT_PageCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00712_A310Trn_PageId ;
      private string[] P00712_A318Trn_PageName ;
      private Guid[] P00713_A310Trn_PageId ;
      private Guid[] P00713_A319Trn_RowId ;
      private string[] P00713_A320Trn_RowName ;
      private SdtSDT_Row AV12SDT_Row ;
      private Guid[] P00714_A319Trn_RowId ;
      private Guid[] P00714_A264Trn_TileId ;
      private string[] P00714_A265Trn_TileName ;
      private Guid[] P00714_A329SG_ToPageId ;
      private string[] P00714_A330SG_ToPageName ;
      private Guid[] P00714_A328Trn_ColId ;
      private string[] P00714_A327Trn_ColName ;
      private SdtSDT_Col AV13SDT_Col ;
      private Guid[] P00715_A264Trn_TileId ;
      private SdtSDT_Tile AV15SDT_Tile ;
      private SdtSDT_Page aP1_SDT_Page ;
      private GXBaseCollection<SdtSDT_Page> aP2_SDT_PageCollection ;
   }

   public class aprc_applicationdesign__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00712( IGxContext context ,
                                             string AV21Trn_PageName ,
                                             string A318Trn_PageName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_PageId, Trn_PageName FROM Trn_Page";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21Trn_PageName)) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV21Trn_PageName))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_PageId";
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
                     return conditional_P00712(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00713;
          prmP00713 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00714;
          prmP00714 = new Object[] {
          new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00715;
          prmP00715 = new Object[] {
          new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00712;
          prmP00712 = new Object[] {
          new ParDef("AV21Trn_PageName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00712", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00712,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00713", "SELECT Trn_PageId, Trn_RowId, Trn_RowName FROM Trn_Row WHERE Trn_PageId = :Trn_PageId ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00713,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00714", "SELECT T1.Trn_RowId, T1.Trn_TileId, T2.Trn_TileName, T2.SG_ToPageId AS SG_ToPageId, T3.Trn_PageName AS SG_ToPageName, T1.Trn_ColId, T1.Trn_ColName FROM ((Trn_Col1 T1 INNER JOIN Trn_Col T2 ON T2.Trn_TileId = T1.Trn_TileId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T2.SG_ToPageId) WHERE T1.Trn_RowId = :Trn_RowId ORDER BY T1.Trn_RowId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00714,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00715", "SELECT Trn_TileId FROM Trn_Col WHERE Trn_TileId = :Trn_TileId ORDER BY Trn_TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00715,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
