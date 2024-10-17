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
         new prc_logtofile(context ).execute(  ">>>>>>>>>>>>>>>>"+AV13Trn_PageId.ToString()) ;
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
                  A264Trn_TileId = P007W4_A264Trn_TileId[0];
                  A265Trn_TileName = P007W4_A265Trn_TileName[0];
                  A329SG_ToPageId = P007W4_A329SG_ToPageId[0];
                  A330SG_ToPageName = P007W4_A330SG_ToPageName[0];
                  A265Trn_TileName = P007W4_A265Trn_TileName[0];
                  A329SG_ToPageId = P007W4_A329SG_ToPageId[0];
                  A330SG_ToPageName = P007W4_A330SG_ToPageName[0];
                  AV11SDT_Col = new SdtSDT_Col(context);
                  AV12SDT_Tile = new SdtSDT_Tile(context);
                  AV11SDT_Col.gxTpr_Colid = A328Trn_ColId;
                  AV11SDT_Col.gxTpr_Colname = A327Trn_ColName;
                  AV12SDT_Tile.gxTpr_Tileid = A264Trn_TileId;
                  AV12SDT_Tile.gxTpr_Tilename = A265Trn_TileName;
                  AV12SDT_Tile.gxTpr_Topageid = A329SG_ToPageId;
                  AV12SDT_Tile.gxTpr_Topagename = A330SG_ToPageName;
                  AV11SDT_Col.gxTpr_Tile = AV12SDT_Tile;
                  AV10SDT_Row.gxTpr_Col.Add(AV11SDT_Col, 0);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV9SDT_PageCollection.Add(AV8SDT_Page, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new prc_logtofile(context ).execute(  ">>>>>>>"+AV9SDT_PageCollection.ToJSonString(false)) ;
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
         P007W4_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         P007W4_A265Trn_TileName = new string[] {""} ;
         P007W4_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P007W4_A330SG_ToPageName = new string[] {""} ;
         A328Trn_ColId = Guid.Empty;
         A327Trn_ColName = "";
         A264Trn_TileId = Guid.Empty;
         A265Trn_TileName = "";
         A329SG_ToPageId = Guid.Empty;
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
               P007W4_A319Trn_RowId, P007W4_A328Trn_ColId, P007W4_A327Trn_ColName, P007W4_A264Trn_TileId, P007W4_A265Trn_TileName, P007W4_A329SG_ToPageId, P007W4_A330SG_ToPageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV14response ;
      private string A318Trn_PageName ;
      private string A320Trn_RowName ;
      private string A327Trn_ColName ;
      private string A265Trn_TileName ;
      private string A330SG_ToPageName ;
      private Guid AV13Trn_PageId ;
      private Guid A310Trn_PageId ;
      private Guid A319Trn_RowId ;
      private Guid A328Trn_ColId ;
      private Guid A264Trn_TileId ;
      private Guid A329SG_ToPageId ;
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
      private Guid[] P007W4_A264Trn_TileId ;
      private string[] P007W4_A265Trn_TileName ;
      private Guid[] P007W4_A329SG_ToPageId ;
      private string[] P007W4_A330SG_ToPageName ;
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
          Object[] prmP007W2;
          prmP007W2 = new Object[] {
          new ParDef("AV13Trn_PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007W3", "SELECT Trn_PageId, Trn_RowId, Trn_RowName FROM Trn_Row WHERE Trn_PageId = :Trn_PageId ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007W4", "SELECT T1.Trn_RowId, T1.Trn_ColId, T1.Trn_ColName, T1.Trn_TileId, T2.Trn_TileName, T2.SG_ToPageId AS SG_ToPageId, T3.Trn_PageName AS SG_ToPageName FROM ((Trn_Col1 T1 INNER JOIN Trn_Tile T2 ON T2.Trn_TileId = T1.Trn_TileId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T2.SG_ToPageId) WHERE T1.Trn_RowId = :Trn_RowId ORDER BY T1.Trn_RowId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W4,100, GxCacheFrequency.OFF ,false,false )
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
       }
    }

 }

}
