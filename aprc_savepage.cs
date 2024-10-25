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
   public class aprc_savepage : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_savepage().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
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

      public aprc_savepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_savepage( IGxContext context )
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
         AV8SDT_Page.FromJSonString(context.GetMessage( "{    \"PageId\": \"ab2f9c5e-a697-43a5-8ce6-c02b11834af1\",    \"PageName\": \"Home\",    \"Row\": [      {        \"RowId\": \"0b460cf5-3d64-4b92-8935-b2c7865d6ceb\",        \"RowName\": \"dfc60c1a-6158-47a2-a31a-c80243307c33\",        \"Col\": [          {            \"ColId\": \"71cffcb3-c060-482e-91d3-cb1b83db1929\",            \"ColName\": \"114f85a5-9747-4fc2-b114-cfb4f2a6ca74\",            \"Tile\": {              \"TileId\": \"09b58d93-d644-415f-b07d-4e388af43da7\",              \"TileName\": \"Shopping\",              \"TileIcon\": \"\",              \"TileBGColor\": \"\",              \"TileBGImageUrl\": \"\",              \"TileTextColor\": \"\",              \"TileTextAlignment\": \"center\",              \"TileIconAlignment\": \"center\",              \"ProductServiceId\": \"00000000-0000-0000-0000-000000000000\",              \"ProductServiceName\": \"\",              \"ProductServiceDescription\": \"\",              \"ProductServiceImage\": \"\",              \"ToPageId\": \"bae22878-d842-4989-9099-36353503b290\",              \"ToPageName\": \"Shopping\"            }          }        ]      },      {        \"RowId\": \"7d7428f0-0f4d-4eff-b0d6-78cac56607b1\",        \"RowName\": \"f2cf1e81-a7e2-4ebe-aa6b-995aba10e080\",        \"Col\": [          {            \"ColId\": \"7072585c-c76a-48a8-9943-e0c345640be3\",            \"ColName\": \"75d66e1e-2653-4cc1-bc70-10e707de508b\",            \"Tile\": {              \"TileId\": \"52ac25d6-4c7a-45c4-be7c-1e9734e4ff3b\",              \"TileName\": \"Clothes\",              \"TileIcon\": \"\",              \"TileBGColor\": \"\",              \"TileBGImageUrl\": \"\",              \"TileTextColor\": \"\",              \"TileTextAlignment\": \"center\",              \"TileIconAlignment\": \"center\",              \"ProductServiceId\": \"00000000-0000-0000-0000-000000000000\",              \"ProductServiceName\": \"\",              \"ProductServiceDescription\": \"\",              \"ProductServiceImage\": \"\",              \"ToPageId\": \"1565c61b-18ff-4534-bbf3-4fc6e01a982e\",              \"ToPageName\": \"Clothes\"            }          },          {            \"ColId\": \"45f30a10-cd40-4c56-a558-cc975705fc9a\",            \"ColName\": \"2a46b545-1ec9-4022-89ad-b46c995ea9fb\",            \"Tile\": {              \"TileId\": \"7f0d99e6-4941-4f42-b653-229efd863060\",              \"TileName\": \"Glosseries\",              \"TileIcon\": \"\",              \"TileBGColor\": \"\",              \"TileBGImageUrl\": \"\",              \"TileTextColor\": \"\",              \"TileTextAlignment\": \"center\",              \"TileIconAlignment\": \"center\",              \"ProductServiceId\": \"00000000-0000-0000-0000-000000000000\",              \"ProductServiceName\": \"\",              \"ProductServiceDescription\": \"\",              \"ProductServiceImage\": \"\",              \"ToPageId\": \"f73f54e9-243d-4ffb-823e-557295282c4e\",              \"ToPageName\": \"Glosseries\"            }          }        ]      },      {        \"RowId\": \"936f666b-6b75-469f-98e0-c9496b3844c2\",        \"RowName\": \"b857a289-a57f-4675-9bc9-8ecc151dfd57\",        \"Col\": [          {            \"ColId\": \"51f4aadb-8020-4228-9ba2-1a0774b35968\",            \"ColName\": \"3a885e83-04a5-436b-a5bd-bcfee3a7dc92\",            \"Tile\": {              \"TileId\": \"e0090c20-4723-4912-ab1f-cea7bfdbac31\",              \"TileName\": \"Medical\",              \"TileIcon\": \"\",              \"TileBGColor\": \"\",              \"TileBGImageUrl\": \"\",              \"TileTextColor\": \"\",              \"TileTextAlignment\": \"center\",              \"TileIconAlignment\": \"center\",              \"ProductServiceId\": \"00000000-0000-0000-0000-000000000000\",              \"ProductServiceName\": \"\",              \"ProductServiceDescription\": \"\",              \"ProductServiceImage\": \"\",              \"ToPageId\": \"696e8b17-188e-4c7b-9093-4b6252215f5f\",              \"ToPageName\": \"Medical\"            }          },          {            \"ColId\": \"2096875a-c1d0-4a91-b98f-36776dc3c4a7\",            \"ColName\": \"47d1ddb2-da42-454e-a61d-93bee8e8146b\",            \"Tile\": {              \"TileId\": \"bffd14ef-8f9d-4627-a771-92b7ddae6de0\",              \"TileName\": \"Nurse\",              \"TileIcon\": \"\",              \"TileBGColor\": \"\",              \"TileBGImageUrl\": \"\",              \"TileTextColor\": \"\",              \"TileTextAlignment\": \"center\",              \"TileIconAlignment\": \"center\",              \"ProductServiceId\": \"00000000-0000-0000-0000-000000000000\",              \"ProductServiceName\": \"\",              \"ProductServiceDescription\": \"\",              \"ProductServiceImage\": \"\",              \"ToPageId\": \"e54d6a9d-18eb-4a05-a839-ae9d7b73c28f\",              \"ToPageName\": \"Nurse\"            }          }        ]      },      {        \"RowId\": \"d9c2140c-a6f1-4195-9302-d379c11e5ee4\",        \"RowName\": \"6c7c7162-4a83-4963-a8c8-3d5185f14e2b\",        \"Col\": [          {            \"ColId\": \"d851e7f1-1e06-4e6d-b058-49595cce9914\",            \"ColName\": \"c3b84cb2-48b2-4bce-9be1-96eebecb04b9\",            \"Tile\": {              \"TileId\": \"ddf0f7ba-234d-4f10-aaa6-0e66b430b93e\",              \"TileName\": \"Transport\",              \"TileIcon\": \"\",              \"TileBGColor\": \"\",              \"TileBGImageUrl\": \"\",              \"TileTextColor\": \"\",              \"TileTextAlignment\": \"center\",              \"TileIconAlignment\": \"center\",              \"ProductServiceId\": \"00000000-0000-0000-0000-000000000000\",              \"ProductServiceName\": \"\",              \"ProductServiceDescription\": \"\",              \"ProductServiceImage\": \"\",              \"ToPageId\": \"a0deeb94-16e5-4e16-a814-6477ce33e6b8\",              \"ToPageName\": \"Transport\"            }          }        ]      },      {        \"RowId\": \"fecdc1f3-d62c-4bd4-909f-31026e0ab986\",        \"RowName\": \"94ae7cc8-f3a5-42fc-9388-f272ab6ac14b\"      }    ]  }", ""), null);
         new prc_logtofile(context ).execute(  AV8SDT_Page.gxTpr_Pageid.ToString()) ;
         AV9BC_Trn_Page.Load(AV8SDT_Page.gxTpr_Pageid);
         /* Optimized DELETE. */
         cmdBuffer=" LOCK TABLE Trn_Col IN EXCLUSIVE MODE "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_MASKLOCKERR | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor P008B2 */
         pr_default.execute(0);
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
         /* End optimized DELETE. */
         /* Optimized DELETE. */
         cmdBuffer=" LOCK TABLE Trn_Tile IN EXCLUSIVE MODE "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_MASKLOCKERR | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor P008B3 */
         pr_default.execute(1);
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
         /* End optimized DELETE. */
         /* Optimized DELETE. */
         cmdBuffer=" LOCK TABLE Trn_Row IN EXCLUSIVE MODE "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_MASKLOCKERR | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor P008B4 */
         pr_default.execute(2);
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("Trn_Row");
         /* End optimized DELETE. */
         /* Optimized DELETE. */
         cmdBuffer=" LOCK TABLE Trn_Page IN EXCLUSIVE MODE "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_MASKLOCKERR | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor P008B5 */
         pr_default.execute(3);
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
         /* End optimized DELETE. */
         AV9BC_Trn_Page = new SdtTrn_Page(context);
         AV9BC_Trn_Page.gxTpr_Trn_pageid = Guid.NewGuid( );
         AV9BC_Trn_Page.gxTpr_Trn_pagename = context.GetMessage( "To Page", "");
         AV9BC_Trn_Page.Save();
         context.CommitDataStores("prc_savepage",pr_default);
         AV21GXV2 = 1;
         AV20GXV1 = AV9BC_Trn_Page.GetMessages();
         while ( AV21GXV2 <= AV20GXV1.Count )
         {
            AV15Message = ((GeneXus.Utils.SdtMessages_Message)AV20GXV1.Item(AV21GXV2));
            new prc_logtofile(context ).execute(  context.GetMessage( "&BC_Trn_Page ", "")+AV15Message.gxTpr_Description) ;
            AV21GXV2 = (int)(AV21GXV2+1);
         }
         /*
            INSERT RECORD ON TABLE Trn_Page

         */
         A310Trn_PageId = AV8SDT_Page.gxTpr_Pageid;
         A318Trn_PageName = AV8SDT_Page.gxTpr_Pagename;
         /* Using cursor P008B6 */
         pr_default.execute(4, new Object[] {A310Trn_PageId, A318Trn_PageName});
         pr_default.close(4);
         pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
         if ( (pr_default.getStatus(4) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         context.CommitDataStores("prc_savepage",pr_default);
         AV22GXV3 = 1;
         while ( AV22GXV3 <= AV8SDT_Page.gxTpr_Row.Count )
         {
            AV10SDT_Row = ((SdtSDT_Row)AV8SDT_Page.gxTpr_Row.Item(AV22GXV3));
            /*
               INSERT RECORD ON TABLE Trn_Row

            */
            A319Trn_RowId = AV10SDT_Row.gxTpr_Rowid;
            A320Trn_RowName = AV10SDT_Row.gxTpr_Rowname;
            A310Trn_PageId = AV8SDT_Page.gxTpr_Pageid;
            /* Using cursor P008B7 */
            pr_default.execute(5, new Object[] {A319Trn_RowId, A310Trn_PageId, A320Trn_RowName});
            pr_default.close(5);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Row");
            if ( (pr_default.getStatus(5) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            new prc_logtofile(context ).execute(  AV9BC_Trn_Page.gxTpr_Trn_pageid.ToString()) ;
            AV23GXV4 = 1;
            while ( AV23GXV4 <= AV10SDT_Row.gxTpr_Col.Count )
            {
               AV13SDT_Col = ((SdtSDT_Col)AV10SDT_Row.gxTpr_Col.Item(AV23GXV4));
               /*
                  INSERT RECORD ON TABLE Trn_Tile

               */
               A407TileId = AV13SDT_Col.gxTpr_Tile.gxTpr_Tileid;
               A400TileName = AV13SDT_Col.gxTpr_Tile.gxTpr_Tilename;
               A401TileIcon = AV13SDT_Col.gxTpr_Tile.gxTpr_Tileicon;
               n401TileIcon = false;
               A402TileBGColor = AV13SDT_Col.gxTpr_Tile.gxTpr_Tilebgcolor;
               n402TileBGColor = false;
               A403TileBGImageUrl = AV13SDT_Col.gxTpr_Tile.gxTpr_Tilebgimageurl;
               n403TileBGImageUrl = false;
               A404TileTextColor = AV13SDT_Col.gxTpr_Tile.gxTpr_Tiletextcolor;
               A405TileTextAlignment = AV13SDT_Col.gxTpr_Tile.gxTpr_Tiletextalignment;
               A406TileIconAlignment = AV13SDT_Col.gxTpr_Tile.gxTpr_Tileiconalignment;
               A58ProductServiceId = Guid.Empty;
               n58ProductServiceId = false;
               n58ProductServiceId = true;
               A11OrganisationId = Guid.Empty;
               n11OrganisationId = false;
               n11OrganisationId = true;
               A29LocationId = Guid.Empty;
               n29LocationId = false;
               n29LocationId = true;
               A329SG_ToPageId = AV9BC_Trn_Page.gxTpr_Trn_pageid;
               /* Using cursor P008B8 */
               pr_default.execute(6, new Object[] {A407TileId, A400TileName, n401TileIcon, A401TileIcon, n402TileBGColor, A402TileBGColor, n403TileBGImageUrl, A403TileBGImageUrl, A404TileTextColor, A405TileTextAlignment, A406TileIconAlignment, n58ProductServiceId, A58ProductServiceId, n11OrganisationId, A11OrganisationId, n29LocationId, A29LocationId, A329SG_ToPageId});
               pr_default.close(6);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
               if ( (pr_default.getStatus(6) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               /* End Insert */
               /*
                  INSERT RECORD ON TABLE Trn_Col

               */
               A328Trn_ColId = AV13SDT_Col.gxTpr_Colid;
               A327Trn_ColName = AV13SDT_Col.gxTpr_Colname;
               A319Trn_RowId = AV10SDT_Row.gxTpr_Rowid;
               A407TileId = AV13SDT_Col.gxTpr_Tile.gxTpr_Tileid;
               /* Using cursor P008B9 */
               pr_default.execute(7, new Object[] {A328Trn_ColId, A319Trn_RowId, A327Trn_ColName, A407TileId});
               pr_default.close(7);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
               if ( (pr_default.getStatus(7) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               /* End Insert */
               AV23GXV4 = (int)(AV23GXV4+1);
            }
            AV22GXV3 = (int)(AV22GXV3+1);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_savepage",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8SDT_Page = new SdtSDT_Page(context);
         AV9BC_Trn_Page = new SdtTrn_Page(context);
         cmdBuffer = "";
         AV20GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV15Message = new GeneXus.Utils.SdtMessages_Message(context);
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         Gx_emsg = "";
         AV10SDT_Row = new SdtSDT_Row(context);
         A319Trn_RowId = Guid.Empty;
         A320Trn_RowName = "";
         AV13SDT_Col = new SdtSDT_Col(context);
         A407TileId = Guid.Empty;
         A400TileName = "";
         A401TileIcon = "";
         A402TileBGColor = "";
         A403TileBGImageUrl = "";
         A404TileTextColor = "";
         A405TileTextAlignment = "";
         A406TileIconAlignment = "";
         A58ProductServiceId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A329SG_ToPageId = Guid.Empty;
         A328Trn_ColId = Guid.Empty;
         A327Trn_ColName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_savepage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_savepage__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV21GXV2 ;
      private int GX_INS68 ;
      private int AV22GXV3 ;
      private int GX_INS70 ;
      private int AV23GXV4 ;
      private int GX_INS81 ;
      private int GX_INS72 ;
      private string cmdBuffer ;
      private string Gx_emsg ;
      private string A401TileIcon ;
      private string A402TileBGColor ;
      private string A404TileTextColor ;
      private string A405TileTextAlignment ;
      private string A406TileIconAlignment ;
      private bool n401TileIcon ;
      private bool n402TileBGColor ;
      private bool n403TileBGImageUrl ;
      private bool n58ProductServiceId ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private string A318Trn_PageName ;
      private string A320Trn_RowName ;
      private string A400TileName ;
      private string A403TileBGImageUrl ;
      private string A327Trn_ColName ;
      private Guid A310Trn_PageId ;
      private Guid A319Trn_RowId ;
      private Guid A407TileId ;
      private Guid A58ProductServiceId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A329SG_ToPageId ;
      private Guid A328Trn_ColId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV8SDT_Page ;
      private SdtTrn_Page AV9BC_Trn_Page ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV20GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV15Message ;
      private SdtSDT_Row AV10SDT_Row ;
      private SdtSDT_Col AV13SDT_Col ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_savepage__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class aprc_savepage__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP008B2;
        prmP008B2 = new Object[] {
        };
        Object[] prmP008B3;
        prmP008B3 = new Object[] {
        };
        Object[] prmP008B4;
        prmP008B4 = new Object[] {
        };
        Object[] prmP008B5;
        prmP008B5 = new Object[] {
        };
        Object[] prmP008B6;
        prmP008B6 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_PageName",GXType.VarChar,100,0)
        };
        Object[] prmP008B7;
        prmP008B7 = new Object[] {
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_RowName",GXType.VarChar,100,0)
        };
        Object[] prmP008B8;
        prmP008B8 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TileName",GXType.VarChar,100,0) ,
        new ParDef("TileIcon",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileBGColor",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileBGImageUrl",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("TileTextColor",GXType.Char,20,0) ,
        new ParDef("TileTextAlignment",GXType.Char,20,0) ,
        new ParDef("TileIconAlignment",GXType.Char,20,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmP008B9;
        prmP008B9 = new Object[] {
        new ParDef("Trn_ColId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_ColName",GXType.VarChar,100,0) ,
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("P008B2", "DELETE FROM Trn_Col ", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP008B2)
           ,new CursorDef("P008B3", "DELETE FROM Trn_Tile ", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP008B3)
           ,new CursorDef("P008B4", "DELETE FROM Trn_Row ", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP008B4)
           ,new CursorDef("P008B5", "DELETE FROM Trn_Page ", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP008B5)
           ,new CursorDef("P008B6", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, Trn_PageName) VALUES(:Trn_PageId, :Trn_PageName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP008B6)
           ,new CursorDef("P008B7", "SAVEPOINT gxupdate;INSERT INTO Trn_Row(Trn_RowId, Trn_PageId, Trn_RowName) VALUES(:Trn_RowId, :Trn_PageId, :Trn_RowName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP008B7)
           ,new CursorDef("P008B8", "SAVEPOINT gxupdate;INSERT INTO Trn_Tile(TileId, TileName, TileIcon, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIconAlignment, ProductServiceId, OrganisationId, LocationId, SG_ToPageId) VALUES(:TileId, :TileName, :TileIcon, :TileBGColor, :TileBGImageUrl, :TileTextColor, :TileTextAlignment, :TileIconAlignment, :ProductServiceId, :OrganisationId, :LocationId, :SG_ToPageId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP008B8)
           ,new CursorDef("P008B9", "SAVEPOINT gxupdate;INSERT INTO Trn_Col(Trn_ColId, Trn_RowId, Trn_ColName, TileId) VALUES(:Trn_ColId, :Trn_RowId, :Trn_ColName, :TileId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP008B9)
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
