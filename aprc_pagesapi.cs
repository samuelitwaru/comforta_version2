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
   public class aprc_pagesapi : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_pagesapi().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         Guid aP0_Trn_PageId = new Guid()  ;
         string aP1_response = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_Trn_PageId=((Guid)(StringUtil.StrToGuid( (string)(args[0]))));
         }
         else
         {
            aP0_Trn_PageId=Guid.Empty;
         }
         if ( 1 < args.Length )
         {
            aP1_response=((string)(args[1]));
         }
         else
         {
            aP1_response="";
         }
         execute(aP0_Trn_PageId, out aP1_response);
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

      public aprc_pagesapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_pagesapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_Trn_PageId ,
                           out string aP1_response )
      {
         this.AV13Trn_PageId = aP0_Trn_PageId;
         this.AV14response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV14response;
      }

      public string executeUdp( Guid aP0_Trn_PageId )
      {
         execute(aP0_Trn_PageId, out aP1_response);
         return AV14response ;
      }

      public void executeSubmit( Guid aP0_Trn_PageId ,
                                 out string aP1_response )
      {
         this.AV13Trn_PageId = aP0_Trn_PageId;
         this.AV14response = "" ;
         SubmitImpl();
         aP1_response=this.AV14response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13Trn_PageId ,
                                              A310Trn_PageId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P007W2 */
         pr_default.execute(0, new Object[] {AV13Trn_PageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A310Trn_PageId = P007W2_A310Trn_PageId[0];
            A318Trn_PageName = P007W2_A318Trn_PageName[0];
            AV8SDT_Page = new SdtSDT_Page(context);
            AV8SDT_Page.gxTpr_Pageid = A310Trn_PageId;
            AV8SDT_Page.gxTpr_Pagename = A318Trn_PageName;
            /* Using cursor P007W3 */
            pr_default.execute(1, new Object[] {A310Trn_PageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A319Trn_RowId = P007W3_A319Trn_RowId[0];
               A320Trn_RowName = P007W3_A320Trn_RowName[0];
               AV10SDT_Row = new SdtSDT_Row(context);
               AV10SDT_Row.gxTpr_Rowid = A319Trn_RowId;
               AV10SDT_Row.gxTpr_Rowname = A320Trn_RowName;
               AV8SDT_Page.gxTpr_Row.Add(AV10SDT_Row, 0);
               /* Using cursor P007W4 */
               pr_default.execute(2, new Object[] {A319Trn_RowId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A328Trn_ColId = P007W4_A328Trn_ColId[0];
                  A327Trn_ColName = P007W4_A327Trn_ColName[0];
                  A407TileId = P007W4_A407TileId[0];
                  /* Using cursor P007W5 */
                  pr_default.execute(3, new Object[] {A407TileId});
                  A400TileName = P007W5_A400TileName[0];
                  A404TileTextColor = P007W5_A404TileTextColor[0];
                  A405TileTextAlignment = P007W5_A405TileTextAlignment[0];
                  A401TileIcon = P007W5_A401TileIcon[0];
                  n401TileIcon = P007W5_n401TileIcon[0];
                  A406TileIconAlignment = P007W5_A406TileIconAlignment[0];
                  A402TileBGColor = P007W5_A402TileBGColor[0];
                  n402TileBGColor = P007W5_n402TileBGColor[0];
                  A403TileBGImageUrl = P007W5_A403TileBGImageUrl[0];
                  n403TileBGImageUrl = P007W5_n403TileBGImageUrl[0];
                  A329SG_ToPageId = P007W5_A329SG_ToPageId[0];
                  A58ProductServiceId = P007W5_A58ProductServiceId[0];
                  n58ProductServiceId = P007W5_n58ProductServiceId[0];
                  /* Using cursor P007W6 */
                  pr_default.execute(4, new Object[] {A329SG_ToPageId});
                  A330SG_ToPageName = P007W6_A330SG_ToPageName[0];
                  AV11SDT_Col = new SdtSDT_Col(context);
                  AV12SDT_Tile = new SdtSDT_Tile(context);
                  AV11SDT_Col.gxTpr_Colid = A328Trn_ColId;
                  AV11SDT_Col.gxTpr_Colname = A327Trn_ColName;
                  AV12SDT_Tile.gxTpr_Tileid = A407TileId;
                  AV12SDT_Tile.gxTpr_Tilename = A400TileName;
                  AV12SDT_Tile.gxTpr_Tiletextcolor = A404TileTextColor;
                  AV12SDT_Tile.gxTpr_Tiletextalignment = A405TileTextAlignment;
                  AV12SDT_Tile.gxTpr_Tileicon = A401TileIcon;
                  AV12SDT_Tile.gxTpr_Tileiconalignment = A406TileIconAlignment;
                  AV12SDT_Tile.gxTpr_Tilebgcolor = A402TileBGColor;
                  AV12SDT_Tile.gxTpr_Tilebgimageurl = A403TileBGImageUrl;
                  AV12SDT_Tile.gxTpr_Topageid = A329SG_ToPageId;
                  AV12SDT_Tile.gxTpr_Topagename = A330SG_ToPageName;
                  if ( (Guid.Empty==A58ProductServiceId) )
                  {
                     A58ProductServiceId = Guid.Empty;
                     n58ProductServiceId = false;
                     n58ProductServiceId = true;
                     AV12SDT_Tile.gxTpr_Productserviceid = A58ProductServiceId;
                  }
                  else
                  {
                     AV12SDT_Tile.gxTpr_Productserviceid = A58ProductServiceId;
                  }
                  AV11SDT_Col.gxTpr_Tile = AV12SDT_Tile;
                  AV10SDT_Row.gxTpr_Col.Add(AV11SDT_Col, 0);
                  /* Using cursor P007W7 */
                  pr_default.execute(5, new Object[] {n58ProductServiceId, A58ProductServiceId, A407TileId});
                  pr_default.close(5);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               pr_default.close(3);
               pr_default.close(4);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV9SDT_PageCollection.Add(AV8SDT_Page, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9SDT_PageCollection.Count == 0 )
         {
            AV14response = "No pages found";
         }
         else
         {
            AV14response = AV9SDT_PageCollection.ToJSonString(false);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_pagesapi",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV14response = "";
         A310Trn_PageId = Guid.Empty;
         P007W2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P007W2_A318Trn_PageName = new string[] {""} ;
         A318Trn_PageName = "";
         AV8SDT_Page = new SdtSDT_Page(context);
         P007W3_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P007W3_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         P007W3_A320Trn_RowName = new string[] {""} ;
         A319Trn_RowId = Guid.Empty;
         A320Trn_RowName = "";
         AV10SDT_Row = new SdtSDT_Row(context);
         P007W4_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         P007W4_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         P007W4_A327Trn_ColName = new string[] {""} ;
         P007W4_A407TileId = new Guid[] {Guid.Empty} ;
         A328Trn_ColId = Guid.Empty;
         A327Trn_ColName = "";
         A407TileId = Guid.Empty;
         P007W5_A400TileName = new string[] {""} ;
         P007W5_A404TileTextColor = new string[] {""} ;
         P007W5_A405TileTextAlignment = new string[] {""} ;
         P007W5_A401TileIcon = new string[] {""} ;
         P007W5_n401TileIcon = new bool[] {false} ;
         P007W5_A406TileIconAlignment = new string[] {""} ;
         P007W5_A402TileBGColor = new string[] {""} ;
         P007W5_n402TileBGColor = new bool[] {false} ;
         P007W5_A403TileBGImageUrl = new string[] {""} ;
         P007W5_n403TileBGImageUrl = new bool[] {false} ;
         P007W5_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P007W5_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P007W5_n58ProductServiceId = new bool[] {false} ;
         A400TileName = "";
         A404TileTextColor = "";
         A405TileTextAlignment = "";
         A401TileIcon = "";
         A406TileIconAlignment = "";
         A402TileBGColor = "";
         A403TileBGImageUrl = "";
         A329SG_ToPageId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         P007W6_A330SG_ToPageName = new string[] {""} ;
         A330SG_ToPageName = "";
         AV11SDT_Col = new SdtSDT_Col(context);
         AV12SDT_Tile = new SdtSDT_Tile(context);
         AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_pagesapi__default(),
            new Object[][] {
                new Object[] {
               P007W2_A310Trn_PageId, P007W2_A318Trn_PageName
               }
               , new Object[] {
               P007W3_A310Trn_PageId, P007W3_A319Trn_RowId, P007W3_A320Trn_RowName
               }
               , new Object[] {
               P007W4_A319Trn_RowId, P007W4_A328Trn_ColId, P007W4_A327Trn_ColName, P007W4_A407TileId
               }
               , new Object[] {
               P007W5_A400TileName, P007W5_A404TileTextColor, P007W5_A405TileTextAlignment, P007W5_A401TileIcon, P007W5_n401TileIcon, P007W5_A406TileIconAlignment, P007W5_A402TileBGColor, P007W5_n402TileBGColor, P007W5_A403TileBGImageUrl, P007W5_n403TileBGImageUrl,
               P007W5_A329SG_ToPageId, P007W5_A58ProductServiceId, P007W5_n58ProductServiceId
               }
               , new Object[] {
               P007W6_A330SG_ToPageName
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A404TileTextColor ;
      private string A405TileTextAlignment ;
      private string A401TileIcon ;
      private string A406TileIconAlignment ;
      private string A402TileBGColor ;
      private bool n401TileIcon ;
      private bool n402TileBGColor ;
      private bool n403TileBGImageUrl ;
      private bool n58ProductServiceId ;
      private string AV14response ;
      private string A318Trn_PageName ;
      private string A320Trn_RowName ;
      private string A327Trn_ColName ;
      private string A400TileName ;
      private string A403TileBGImageUrl ;
      private string A330SG_ToPageName ;
      private Guid AV13Trn_PageId ;
      private Guid A310Trn_PageId ;
      private Guid A319Trn_RowId ;
      private Guid A328Trn_ColId ;
      private Guid A407TileId ;
      private Guid A329SG_ToPageId ;
      private Guid A58ProductServiceId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007W2_A310Trn_PageId ;
      private string[] P007W2_A318Trn_PageName ;
      private SdtSDT_Page AV8SDT_Page ;
      private Guid[] P007W3_A310Trn_PageId ;
      private Guid[] P007W3_A319Trn_RowId ;
      private string[] P007W3_A320Trn_RowName ;
      private SdtSDT_Row AV10SDT_Row ;
      private Guid[] P007W4_A319Trn_RowId ;
      private Guid[] P007W4_A328Trn_ColId ;
      private string[] P007W4_A327Trn_ColName ;
      private Guid[] P007W4_A407TileId ;
      private string[] P007W5_A400TileName ;
      private string[] P007W5_A404TileTextColor ;
      private string[] P007W5_A405TileTextAlignment ;
      private string[] P007W5_A401TileIcon ;
      private bool[] P007W5_n401TileIcon ;
      private string[] P007W5_A406TileIconAlignment ;
      private string[] P007W5_A402TileBGColor ;
      private bool[] P007W5_n402TileBGColor ;
      private string[] P007W5_A403TileBGImageUrl ;
      private bool[] P007W5_n403TileBGImageUrl ;
      private Guid[] P007W5_A329SG_ToPageId ;
      private Guid[] P007W5_A58ProductServiceId ;
      private bool[] P007W5_n58ProductServiceId ;
      private string[] P007W6_A330SG_ToPageName ;
      private SdtSDT_Col AV11SDT_Col ;
      private SdtSDT_Tile AV12SDT_Tile ;
      private GXBaseCollection<SdtSDT_Page> AV9SDT_PageCollection ;
      private string aP1_response ;
   }

   public class aprc_pagesapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007W2( IGxContext context ,
                                             Guid AV13Trn_PageId ,
                                             Guid A310Trn_PageId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_PageId, Trn_PageName FROM Trn_Page";
         if ( ! (Guid.Empty==AV13Trn_PageId) )
         {
            AddWhere(sWhereString, "(Trn_PageId = :AV13Trn_PageId)");
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
                     return conditional_P007W2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] );
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
         ,new ForEachCursor(def[4])
         ,new UpdateCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007W3;
          prmP007W3 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007W4;
          prmP007W4 = new Object[] {
          new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007W5;
          prmP007W5 = new Object[] {
          new ParDef("TileId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007W6;
          prmP007W6 = new Object[] {
          new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007W7;
          prmP007W7 = new Object[] {
          new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("TileId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007W2;
          prmP007W2 = new Object[] {
          new ParDef("AV13Trn_PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007W3", "SELECT Trn_PageId, Trn_RowId, Trn_RowName FROM Trn_Row WHERE Trn_PageId = :Trn_PageId ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007W4", "SELECT Trn_RowId, Trn_ColId, Trn_ColName, TileId FROM Trn_Col WHERE (Trn_RowId = :Trn_RowId) AND (Trn_RowId = :Trn_RowId) ORDER BY Trn_RowId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007W5", "SELECT TileName, TileTextColor, TileTextAlignment, TileIcon, TileIconAlignment, TileBGColor, TileBGImageUrl, SG_ToPageId, ProductServiceId FROM Trn_Tile WHERE TileId = :TileId  FOR UPDATE OF Trn_Tile",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007W6", "SELECT Trn_PageName AS SG_ToPageName FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007W7", "SAVEPOINT gxupdate;UPDATE Trn_Tile SET ProductServiceId=:ProductServiceId  WHERE TileId = :TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007W7)
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
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((Guid[]) buf[10])[0] = rslt.getGuid(8);
                ((Guid[]) buf[11])[0] = rslt.getGuid(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
