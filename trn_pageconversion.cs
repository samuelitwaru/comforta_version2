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
   public class trn_pageconversion : GXProcedure
   {
      public trn_pageconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_pageconversion( IGxContext context )
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
         /* Using cursor TRN_PAGECO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A434PageIsPublished = TRN_PAGECO2_A434PageIsPublished[0];
            A433PageGJSJson = TRN_PAGECO2_A433PageGJSJson[0];
            A432PageGJSHtml = TRN_PAGECO2_A432PageGJSHtml[0];
            A431PageJsonContent = TRN_PAGECO2_A431PageJsonContent[0];
            A318Trn_PageName = TRN_PAGECO2_A318Trn_PageName[0];
            A310Trn_PageId = TRN_PAGECO2_A310Trn_PageId[0];
            AV9GXV29 = Guid.Empty;
            /* Using cursor TRN_PAGECO3 */
            pr_default.execute(1, new Object[] {A310Trn_PageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A329SG_ToPageId = TRN_PAGECO3_A329SG_ToPageId[0];
               n329SG_ToPageId = TRN_PAGECO3_n329SG_ToPageId[0];
               A29LocationId = TRN_PAGECO3_A29LocationId[0];
               n29LocationId = TRN_PAGECO3_n29LocationId[0];
               A407TileId = TRN_PAGECO3_A407TileId[0];
               AV9GXV29 = A29LocationId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /*
               INSERT RECORD ON TABLE GXA0068

            */
            AV2Trn_PageId = A310Trn_PageId;
            AV3Trn_PageName = A318Trn_PageName;
            AV4PageJsonContent = A431PageJsonContent;
            AV5PageGJSHtml = A432PageGJSHtml;
            AV6PageGJSJson = A433PageGJSJson;
            AV7PageIsPublished = A434PageIsPublished;
            if ( (Guid.Empty==AV9GXV29) )
            {
               AV8LocationId = Guid.Empty;
               nV8LocationId = false;
               nV8LocationId = true;
            }
            else
            {
               AV8LocationId = AV9GXV29;
               nV8LocationId = false;
            }
            /* Using cursor TRN_PAGECO4 */
            pr_default.execute(2, new Object[] {AV2Trn_PageId, AV3Trn_PageName, AV4PageJsonContent, AV5PageGJSHtml, AV6PageGJSJson, AV7PageIsPublished, nV8LocationId, AV8LocationId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("GXA0068");
            if ( (pr_default.getStatus(2) == 1) )
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
         TRN_PAGECO2_A434PageIsPublished = new bool[] {false} ;
         TRN_PAGECO2_A433PageGJSJson = new string[] {""} ;
         TRN_PAGECO2_A432PageGJSHtml = new string[] {""} ;
         TRN_PAGECO2_A431PageJsonContent = new string[] {""} ;
         TRN_PAGECO2_A318Trn_PageName = new string[] {""} ;
         TRN_PAGECO2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         A433PageGJSJson = "";
         A432PageGJSHtml = "";
         A431PageJsonContent = "";
         A318Trn_PageName = "";
         A310Trn_PageId = Guid.Empty;
         AV9GXV29 = Guid.Empty;
         TRN_PAGECO3_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         TRN_PAGECO3_n329SG_ToPageId = new bool[] {false} ;
         TRN_PAGECO3_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_PAGECO3_n29LocationId = new bool[] {false} ;
         TRN_PAGECO3_A407TileId = new Guid[] {Guid.Empty} ;
         A329SG_ToPageId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A407TileId = Guid.Empty;
         AV2Trn_PageId = Guid.Empty;
         AV3Trn_PageName = "";
         AV4PageJsonContent = "";
         AV5PageGJSHtml = "";
         AV6PageGJSJson = "";
         AV8LocationId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_pageconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_PAGECO2_A434PageIsPublished, TRN_PAGECO2_A433PageGJSJson, TRN_PAGECO2_A432PageGJSHtml, TRN_PAGECO2_A431PageJsonContent, TRN_PAGECO2_A318Trn_PageName, TRN_PAGECO2_A310Trn_PageId
               }
               , new Object[] {
               TRN_PAGECO3_A329SG_ToPageId, TRN_PAGECO3_n329SG_ToPageId, TRN_PAGECO3_A29LocationId, TRN_PAGECO3_n29LocationId, TRN_PAGECO3_A407TileId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0068 ;
      private string Gx_emsg ;
      private bool A434PageIsPublished ;
      private bool n329SG_ToPageId ;
      private bool n29LocationId ;
      private bool AV7PageIsPublished ;
      private bool nV8LocationId ;
      private string A433PageGJSJson ;
      private string A432PageGJSHtml ;
      private string A431PageJsonContent ;
      private string AV4PageJsonContent ;
      private string AV5PageGJSHtml ;
      private string AV6PageGJSJson ;
      private string A318Trn_PageName ;
      private string AV3Trn_PageName ;
      private Guid A310Trn_PageId ;
      private Guid AV9GXV29 ;
      private Guid A329SG_ToPageId ;
      private Guid A29LocationId ;
      private Guid A407TileId ;
      private Guid AV2Trn_PageId ;
      private Guid AV8LocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] TRN_PAGECO2_A434PageIsPublished ;
      private string[] TRN_PAGECO2_A433PageGJSJson ;
      private string[] TRN_PAGECO2_A432PageGJSHtml ;
      private string[] TRN_PAGECO2_A431PageJsonContent ;
      private string[] TRN_PAGECO2_A318Trn_PageName ;
      private Guid[] TRN_PAGECO2_A310Trn_PageId ;
      private Guid[] TRN_PAGECO3_A329SG_ToPageId ;
      private bool[] TRN_PAGECO3_n329SG_ToPageId ;
      private Guid[] TRN_PAGECO3_A29LocationId ;
      private bool[] TRN_PAGECO3_n29LocationId ;
      private Guid[] TRN_PAGECO3_A407TileId ;
   }

   public class trn_pageconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTRN_PAGECO2;
          prmTRN_PAGECO2 = new Object[] {
          };
          Object[] prmTRN_PAGECO3;
          prmTRN_PAGECO3 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTRN_PAGECO4;
          prmTRN_PAGECO4 = new Object[] {
          new ParDef("AV2Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3Trn_PageName",GXType.VarChar,100,0) ,
          new ParDef("AV4PageJsonContent",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV5PageGJSHtml",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV6PageGJSJson",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV7PageIsPublished",GXType.Boolean,4,0) ,
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TRN_PAGECO2", "SELECT PageIsPublished, PageGJSJson, PageGJSHtml, PageJsonContent, Trn_PageName, Trn_PageId FROM Trn_Page ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_PAGECO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_PAGECO3", "SELECT SG_ToPageId, LocationId, TileId FROM Trn_Tile WHERE SG_ToPageId = :Trn_PageId ORDER BY SG_ToPageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_PAGECO3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("TRN_PAGECO4", "INSERT INTO GXA0068(Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, LocationId) VALUES(:AV2Trn_PageId, :AV3Trn_PageName, :AV4PageJsonContent, :AV5PageGJSHtml, :AV6PageGJSJson, :AV7PageIsPublished, :AV8LocationId)", GxErrorMask.GX_NOMASK,prmTRN_PAGECO4)
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
