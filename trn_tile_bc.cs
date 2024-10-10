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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_tile_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_tile_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_tile_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0Z71( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0Z71( ) ;
         standaloneModal( ) ;
         AddRow0Z71( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E110Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z264Trn_TileId = A264Trn_TileId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0Z0( )
      {
         BeforeValidate0Z71( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Z71( ) ;
            }
            else
            {
               CheckExtendedTable0Z71( ) ;
               if ( AnyError == 0 )
               {
                  ZM0Z71( 14) ;
               }
               CloseExtendedTableCursors0Z71( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode71 = Gx_mode;
            CONFIRM_0Z52( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0Z77( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode71;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode71;
         }
      }

      protected void CONFIRM_0Z77( )
      {
         nGXsfl_77_idx = 0;
         while ( nGXsfl_77_idx < bcTrn_Tile.gxTpr_Childtile.Count )
         {
            ReadRow0Z77( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound77 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_77 != 0 ) )
            {
               GetKey0Z77( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound77 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0Z77( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z77( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0Z77( 17) ;
                        }
                        CloseExtendedTableCursors0Z77( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound77 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0Z77( ) ;
                        Load0Z77( ) ;
                        BeforeValidate0Z77( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z77( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_77 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0Z77( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z77( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0Z77( 17) ;
                              }
                              CloseExtendedTableCursors0Z77( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow77( ((SdtTrn_Tile_ChildTile)bcTrn_Tile.gxTpr_Childtile.Item(nGXsfl_77_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0Z52( )
      {
         nGXsfl_52_idx = 0;
         while ( nGXsfl_52_idx < bcTrn_Tile.gxTpr_Attribute.Count )
         {
            ReadRow0Z52( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound52 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_52 != 0 ) )
            {
               GetKey0Z52( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound52 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0Z52( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z52( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0Z52( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound52 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0Z52( ) ;
                        Load0Z52( ) ;
                        BeforeValidate0Z52( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z52( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_52 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0Z52( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z52( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0Z52( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow52( ((SdtTrn_Tile_Attribute)bcTrn_Tile.gxTpr_Attribute.Item(nGXsfl_52_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV48Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV49GXV1 = 1;
            while ( AV49GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV21TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV49GXV1));
               if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "ProductServiceId") == 0 )
               {
                  AV20Insert_ProductServiceId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV46Insert_OrganisationId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "LocationId") == 0 )
               {
                  AV47Insert_LocationId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
               }
               AV49GXV1 = (int)(AV49GXV1+1);
            }
         }
      }

      protected void E110Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0Z71( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z265Trn_TileName = A265Trn_TileName;
            Z268Trn_TileWidth = A268Trn_TileWidth;
            Z270Trn_TileColor = A270Trn_TileColor;
            Z271Trn_TileBGImageUrl = A271Trn_TileBGImageUrl;
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z59ProductServiceName = A59ProductServiceName;
         }
         if ( GX_JID == -13 )
         {
            Z264Trn_TileId = A264Trn_TileId;
            Z265Trn_TileName = A265Trn_TileName;
            Z268Trn_TileWidth = A268Trn_TileWidth;
            Z270Trn_TileColor = A270Trn_TileColor;
            Z271Trn_TileBGImageUrl = A271Trn_TileBGImageUrl;
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z59ProductServiceName = A59ProductServiceName;
            Z60ProductServiceDescription = A60ProductServiceDescription;
            Z61ProductServiceImage = A61ProductServiceImage;
            Z40000ProductServiceImage_GXI = A40000ProductServiceImage_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         AV48Pgmname = "Trn_Tile_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A264Trn_TileId) )
         {
            A264Trn_TileId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z71( )
      {
         /* Using cursor BC000Z10 */
         pr_default.execute(8, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound71 = 1;
            A265Trn_TileName = BC000Z10_A265Trn_TileName[0];
            A268Trn_TileWidth = BC000Z10_A268Trn_TileWidth[0];
            A270Trn_TileColor = BC000Z10_A270Trn_TileColor[0];
            A271Trn_TileBGImageUrl = BC000Z10_A271Trn_TileBGImageUrl[0];
            A59ProductServiceName = BC000Z10_A59ProductServiceName[0];
            A60ProductServiceDescription = BC000Z10_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC000Z10_A40000ProductServiceImage_GXI[0];
            A58ProductServiceId = BC000Z10_A58ProductServiceId[0];
            A29LocationId = BC000Z10_A29LocationId[0];
            A11OrganisationId = BC000Z10_A11OrganisationId[0];
            A61ProductServiceImage = BC000Z10_A61ProductServiceImage[0];
            ZM0Z71( -13) ;
         }
         pr_default.close(8);
         OnLoadActions0Z71( ) ;
      }

      protected void OnLoadActions0Z71( )
      {
      }

      protected void CheckExtendedTable0Z71( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A268Trn_TileWidth == 1 ) || ( A268Trn_TileWidth == 2 ) || ( A268Trn_TileWidth == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Trn_Tile Width", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A271Trn_TileBGImageUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Trn_Tile BGImage Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000Z9 */
         pr_default.execute(7, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         A59ProductServiceName = BC000Z9_A59ProductServiceName[0];
         A60ProductServiceDescription = BC000Z9_A60ProductServiceDescription[0];
         A40000ProductServiceImage_GXI = BC000Z9_A40000ProductServiceImage_GXI[0];
         A61ProductServiceImage = BC000Z9_A61ProductServiceImage[0];
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors0Z71( )
      {
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Z71( )
      {
         /* Using cursor BC000Z11 */
         pr_default.execute(9, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound71 = 1;
         }
         else
         {
            RcdFound71 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000Z8 */
         pr_default.execute(6, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM0Z71( 13) ;
            RcdFound71 = 1;
            A264Trn_TileId = BC000Z8_A264Trn_TileId[0];
            A265Trn_TileName = BC000Z8_A265Trn_TileName[0];
            A268Trn_TileWidth = BC000Z8_A268Trn_TileWidth[0];
            A270Trn_TileColor = BC000Z8_A270Trn_TileColor[0];
            A271Trn_TileBGImageUrl = BC000Z8_A271Trn_TileBGImageUrl[0];
            A58ProductServiceId = BC000Z8_A58ProductServiceId[0];
            A29LocationId = BC000Z8_A29LocationId[0];
            A11OrganisationId = BC000Z8_A11OrganisationId[0];
            Z264Trn_TileId = A264Trn_TileId;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0Z71( ) ;
            if ( AnyError == 1 )
            {
               RcdFound71 = 0;
               InitializeNonKey0Z71( ) ;
            }
            Gx_mode = sMode71;
         }
         else
         {
            RcdFound71 = 0;
            InitializeNonKey0Z71( ) ;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode71;
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Z71( ) ;
         if ( RcdFound71 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0Z0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0Z71( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Z7 */
            pr_default.execute(5, new Object[] {A264Trn_TileId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(5) == 101) || ( StringUtil.StrCmp(Z265Trn_TileName, BC000Z7_A265Trn_TileName[0]) != 0 ) || ( Z268Trn_TileWidth != BC000Z7_A268Trn_TileWidth[0] ) || ( StringUtil.StrCmp(Z270Trn_TileColor, BC000Z7_A270Trn_TileColor[0]) != 0 ) || ( StringUtil.StrCmp(Z271Trn_TileBGImageUrl, BC000Z7_A271Trn_TileBGImageUrl[0]) != 0 ) || ( Z58ProductServiceId != BC000Z7_A58ProductServiceId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z29LocationId != BC000Z7_A29LocationId[0] ) || ( Z11OrganisationId != BC000Z7_A11OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Tile"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z71( )
      {
         BeforeValidate0Z71( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z71( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z71( 0) ;
            CheckOptimisticConcurrency0Z71( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z71( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z71( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z12 */
                     pr_default.execute(10, new Object[] {A264Trn_TileId, A265Trn_TileName, A268Trn_TileWidth, A270Trn_TileColor, A271Trn_TileBGImageUrl, A58ProductServiceId, A29LocationId, A11OrganisationId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( (pr_default.getStatus(10) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Z71( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0Z71( ) ;
            }
            EndLevel0Z71( ) ;
         }
         CloseExtendedTableCursors0Z71( ) ;
      }

      protected void Update0Z71( )
      {
         BeforeValidate0Z71( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z71( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z71( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z71( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z71( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z13 */
                     pr_default.execute(11, new Object[] {A265Trn_TileName, A268Trn_TileWidth, A270Trn_TileColor, A271Trn_TileBGImageUrl, A58ProductServiceId, A29LocationId, A11OrganisationId, A264Trn_TileId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z71( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Z71( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0Z71( ) ;
         }
         CloseExtendedTableCursors0Z71( ) ;
      }

      protected void DeferredUpdate0Z71( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Z71( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z71( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z71( ) ;
            AfterConfirm0Z71( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z71( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0Z77( ) ;
                  while ( RcdFound77 != 0 )
                  {
                     getByPrimaryKey0Z77( ) ;
                     Delete0Z77( ) ;
                     ScanKeyNext0Z77( ) ;
                  }
                  ScanKeyEnd0Z77( ) ;
                  ScanKeyStart0Z52( ) ;
                  while ( RcdFound52 != 0 )
                  {
                     getByPrimaryKey0Z52( ) ;
                     Delete0Z52( ) ;
                     ScanKeyNext0Z52( ) ;
                  }
                  ScanKeyEnd0Z52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z14 */
                     pr_default.execute(12, new Object[] {A264Trn_TileId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode71 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Z71( ) ;
         Gx_mode = sMode71;
      }

      protected void OnDeleteControls0Z71( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000Z15 */
            pr_default.execute(13, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
            A59ProductServiceName = BC000Z15_A59ProductServiceName[0];
            A60ProductServiceDescription = BC000Z15_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC000Z15_A40000ProductServiceImage_GXI[0];
            A61ProductServiceImage = BC000Z15_A61ProductServiceImage[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000Z16 */
            pr_default.execute(14, new Object[] {A264Trn_TileId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Col", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC000Z17 */
            pr_default.execute(15, new Object[] {A264Trn_TileId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_TileChildTile", "")+" ("+context.GetMessage( "SG_Tile", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void ProcessNestedLevel0Z52( )
      {
         nGXsfl_52_idx = 0;
         while ( nGXsfl_52_idx < bcTrn_Tile.gxTpr_Attribute.Count )
         {
            ReadRow0Z52( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound52 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_52 != 0 ) )
            {
               standaloneNotModal0Z52( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0Z52( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0Z52( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0Z52( ) ;
                  }
               }
            }
            KeyVarsToRow52( ((SdtTrn_Tile_Attribute)bcTrn_Tile.gxTpr_Attribute.Item(nGXsfl_52_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_52_idx = 0;
            while ( nGXsfl_52_idx < bcTrn_Tile.gxTpr_Attribute.Count )
            {
               ReadRow0Z52( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound52 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcTrn_Tile.gxTpr_Attribute.RemoveElement(nGXsfl_52_idx);
                  nGXsfl_52_idx = (int)(nGXsfl_52_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0Z52( ) ;
                  VarsToRow52( ((SdtTrn_Tile_Attribute)bcTrn_Tile.gxTpr_Attribute.Item(nGXsfl_52_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z52( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_52 = 0;
         nIsMod_52 = 0;
      }

      protected void ProcessNestedLevel0Z77( )
      {
         nGXsfl_77_idx = 0;
         while ( nGXsfl_77_idx < bcTrn_Tile.gxTpr_Childtile.Count )
         {
            ReadRow0Z77( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound77 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_77 != 0 ) )
            {
               standaloneNotModal0Z77( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0Z77( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0Z77( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0Z77( ) ;
                  }
               }
            }
            KeyVarsToRow77( ((SdtTrn_Tile_ChildTile)bcTrn_Tile.gxTpr_Childtile.Item(nGXsfl_77_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_77_idx = 0;
            while ( nGXsfl_77_idx < bcTrn_Tile.gxTpr_Childtile.Count )
            {
               ReadRow0Z77( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound77 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcTrn_Tile.gxTpr_Childtile.RemoveElement(nGXsfl_77_idx);
                  nGXsfl_77_idx = (int)(nGXsfl_77_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0Z77( ) ;
                  VarsToRow77( ((SdtTrn_Tile_ChildTile)bcTrn_Tile.gxTpr_Childtile.Item(nGXsfl_77_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z77( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_77 = 0;
         nIsMod_77 = 0;
      }

      protected void ProcessLevel0Z71( )
      {
         /* Save parent mode. */
         sMode71 = Gx_mode;
         ProcessNestedLevel0Z52( ) ;
         ProcessNestedLevel0Z77( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode71;
         /* ' Update level parameters */
      }

      protected void EndLevel0Z71( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Z71( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0Z71( )
      {
         /* Scan By routine */
         /* Using cursor BC000Z18 */
         pr_default.execute(16, new Object[] {A264Trn_TileId});
         RcdFound71 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound71 = 1;
            A264Trn_TileId = BC000Z18_A264Trn_TileId[0];
            A265Trn_TileName = BC000Z18_A265Trn_TileName[0];
            A268Trn_TileWidth = BC000Z18_A268Trn_TileWidth[0];
            A270Trn_TileColor = BC000Z18_A270Trn_TileColor[0];
            A271Trn_TileBGImageUrl = BC000Z18_A271Trn_TileBGImageUrl[0];
            A59ProductServiceName = BC000Z18_A59ProductServiceName[0];
            A60ProductServiceDescription = BC000Z18_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC000Z18_A40000ProductServiceImage_GXI[0];
            A58ProductServiceId = BC000Z18_A58ProductServiceId[0];
            A29LocationId = BC000Z18_A29LocationId[0];
            A11OrganisationId = BC000Z18_A11OrganisationId[0];
            A61ProductServiceImage = BC000Z18_A61ProductServiceImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Z71( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound71 = 0;
         ScanKeyLoad0Z71( ) ;
      }

      protected void ScanKeyLoad0Z71( )
      {
         sMode71 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound71 = 1;
            A264Trn_TileId = BC000Z18_A264Trn_TileId[0];
            A265Trn_TileName = BC000Z18_A265Trn_TileName[0];
            A268Trn_TileWidth = BC000Z18_A268Trn_TileWidth[0];
            A270Trn_TileColor = BC000Z18_A270Trn_TileColor[0];
            A271Trn_TileBGImageUrl = BC000Z18_A271Trn_TileBGImageUrl[0];
            A59ProductServiceName = BC000Z18_A59ProductServiceName[0];
            A60ProductServiceDescription = BC000Z18_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC000Z18_A40000ProductServiceImage_GXI[0];
            A58ProductServiceId = BC000Z18_A58ProductServiceId[0];
            A29LocationId = BC000Z18_A29LocationId[0];
            A11OrganisationId = BC000Z18_A11OrganisationId[0];
            A61ProductServiceImage = BC000Z18_A61ProductServiceImage[0];
         }
         Gx_mode = sMode71;
      }

      protected void ScanKeyEnd0Z71( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0Z71( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z71( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z71( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z71( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z71( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z71( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z71( )
      {
      }

      protected void ZM0Z52( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z273AttributeName = A273AttributeName;
            Z274AttrbuteValue = A274AttrbuteValue;
         }
         if ( GX_JID == -15 )
         {
            Z264Trn_TileId = A264Trn_TileId;
            Z272AttributeId = A272AttributeId;
            Z273AttributeName = A273AttributeName;
            Z274AttrbuteValue = A274AttrbuteValue;
         }
      }

      protected void standaloneNotModal0Z52( )
      {
      }

      protected void standaloneModal0Z52( )
      {
         if ( IsIns( )  && (Guid.Empty==A272AttributeId) )
         {
            A272AttributeId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z52( )
      {
         /* Using cursor BC000Z19 */
         pr_default.execute(17, new Object[] {A264Trn_TileId, A272AttributeId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound52 = 1;
            A273AttributeName = BC000Z19_A273AttributeName[0];
            A274AttrbuteValue = BC000Z19_A274AttrbuteValue[0];
            ZM0Z52( -15) ;
         }
         pr_default.close(17);
         OnLoadActions0Z52( ) ;
      }

      protected void OnLoadActions0Z52( )
      {
      }

      protected void CheckExtendedTable0Z52( )
      {
         Gx_BScreen = 1;
         standaloneModal0Z52( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0Z52( )
      {
      }

      protected void enableDisable0Z52( )
      {
      }

      protected void GetKey0Z52( )
      {
         /* Using cursor BC000Z20 */
         pr_default.execute(18, new Object[] {A264Trn_TileId, A272AttributeId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound52 = 1;
         }
         else
         {
            RcdFound52 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey0Z52( )
      {
         /* Using cursor BC000Z6 */
         pr_default.execute(4, new Object[] {A264Trn_TileId, A272AttributeId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0Z52( 15) ;
            RcdFound52 = 1;
            InitializeNonKey0Z52( ) ;
            A272AttributeId = BC000Z6_A272AttributeId[0];
            A273AttributeName = BC000Z6_A273AttributeName[0];
            A274AttrbuteValue = BC000Z6_A274AttrbuteValue[0];
            Z264Trn_TileId = A264Trn_TileId;
            Z272AttributeId = A272AttributeId;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Z52( ) ;
            Load0Z52( ) ;
            Gx_mode = sMode52;
         }
         else
         {
            RcdFound52 = 0;
            InitializeNonKey0Z52( ) ;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Z52( ) ;
            Gx_mode = sMode52;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z52( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency0Z52( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Z5 */
            pr_default.execute(3, new Object[] {A264Trn_TileId, A272AttributeId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_TileAttribute"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z273AttributeName, BC000Z5_A273AttributeName[0]) != 0 ) || ( StringUtil.StrCmp(Z274AttrbuteValue, BC000Z5_A274AttrbuteValue[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_TileAttribute"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z52( )
      {
         BeforeValidate0Z52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z52( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z52( 0) ;
            CheckOptimisticConcurrency0Z52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z21 */
                     pr_default.execute(19, new Object[] {A264Trn_TileId, A272AttributeId, A273AttributeName, A274AttrbuteValue});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_TileAttribute");
                     if ( (pr_default.getStatus(19) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0Z52( ) ;
            }
            EndLevel0Z52( ) ;
         }
         CloseExtendedTableCursors0Z52( ) ;
      }

      protected void Update0Z52( )
      {
         BeforeValidate0Z52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z52( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z22 */
                     pr_default.execute(20, new Object[] {A273AttributeName, A274AttrbuteValue, A264Trn_TileId, A272AttributeId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_TileAttribute");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_TileAttribute"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z52( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0Z52( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0Z52( ) ;
         }
         CloseExtendedTableCursors0Z52( ) ;
      }

      protected void DeferredUpdate0Z52( )
      {
      }

      protected void Delete0Z52( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Z52( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z52( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z52( ) ;
            AfterConfirm0Z52( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z52( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Z23 */
                  pr_default.execute(21, new Object[] {A264Trn_TileId, A272AttributeId});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_TileAttribute");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode52 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Z52( ) ;
         Gx_mode = sMode52;
      }

      protected void OnDeleteControls0Z52( )
      {
         standaloneModal0Z52( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Z52( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0Z52( )
      {
         /* Scan By routine */
         /* Using cursor BC000Z24 */
         pr_default.execute(22, new Object[] {A264Trn_TileId});
         RcdFound52 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound52 = 1;
            A272AttributeId = BC000Z24_A272AttributeId[0];
            A273AttributeName = BC000Z24_A273AttributeName[0];
            A274AttrbuteValue = BC000Z24_A274AttrbuteValue[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Z52( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound52 = 0;
         ScanKeyLoad0Z52( ) ;
      }

      protected void ScanKeyLoad0Z52( )
      {
         sMode52 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound52 = 1;
            A272AttributeId = BC000Z24_A272AttributeId[0];
            A273AttributeName = BC000Z24_A273AttributeName[0];
            A274AttrbuteValue = BC000Z24_A274AttrbuteValue[0];
         }
         Gx_mode = sMode52;
      }

      protected void ScanKeyEnd0Z52( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm0Z52( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z52( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z52( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z52( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z52( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z52( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z52( )
      {
      }

      protected void send_integrity_lvl_hashes0Z52( )
      {
      }

      protected void ZM0Z77( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z269ChildTileOrder = A269ChildTileOrder;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z267SG_TileName = A267SG_TileName;
            Z275SG_TileWidth = A275SG_TileWidth;
            Z276SG_TileColor = A276SG_TileColor;
            Z277SG_TileBGImageUrl = A277SG_TileBGImageUrl;
         }
         if ( GX_JID == -16 )
         {
            Z264Trn_TileId = A264Trn_TileId;
            Z269ChildTileOrder = A269ChildTileOrder;
            Z266SG_TileId = A266SG_TileId;
            Z267SG_TileName = A267SG_TileName;
            Z275SG_TileWidth = A275SG_TileWidth;
            Z276SG_TileColor = A276SG_TileColor;
            Z277SG_TileBGImageUrl = A277SG_TileBGImageUrl;
         }
      }

      protected void standaloneNotModal0Z77( )
      {
      }

      protected void standaloneModal0Z77( )
      {
      }

      protected void Load0Z77( )
      {
         /* Using cursor BC000Z25 */
         pr_default.execute(23, new Object[] {A264Trn_TileId, A266SG_TileId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound77 = 1;
            A267SG_TileName = BC000Z25_A267SG_TileName[0];
            A275SG_TileWidth = BC000Z25_A275SG_TileWidth[0];
            A276SG_TileColor = BC000Z25_A276SG_TileColor[0];
            A277SG_TileBGImageUrl = BC000Z25_A277SG_TileBGImageUrl[0];
            A269ChildTileOrder = BC000Z25_A269ChildTileOrder[0];
            ZM0Z77( -16) ;
         }
         pr_default.close(23);
         OnLoadActions0Z77( ) ;
      }

      protected void OnLoadActions0Z77( )
      {
      }

      protected void CheckExtendedTable0Z77( )
      {
         Gx_BScreen = 1;
         standaloneModal0Z77( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000Z4 */
         pr_default.execute(2, new Object[] {A266SG_TileId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Tile", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_TILEID");
            AnyError = 1;
         }
         A267SG_TileName = BC000Z4_A267SG_TileName[0];
         A275SG_TileWidth = BC000Z4_A275SG_TileWidth[0];
         A276SG_TileColor = BC000Z4_A276SG_TileColor[0];
         A277SG_TileBGImageUrl = BC000Z4_A277SG_TileBGImageUrl[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0Z77( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0Z77( )
      {
      }

      protected void GetKey0Z77( )
      {
         /* Using cursor BC000Z26 */
         pr_default.execute(24, new Object[] {A264Trn_TileId, A266SG_TileId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound77 = 1;
         }
         else
         {
            RcdFound77 = 0;
         }
         pr_default.close(24);
      }

      protected void getByPrimaryKey0Z77( )
      {
         /* Using cursor BC000Z3 */
         pr_default.execute(1, new Object[] {A264Trn_TileId, A266SG_TileId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z77( 16) ;
            RcdFound77 = 1;
            InitializeNonKey0Z77( ) ;
            A269ChildTileOrder = BC000Z3_A269ChildTileOrder[0];
            A266SG_TileId = BC000Z3_A266SG_TileId[0];
            Z264Trn_TileId = A264Trn_TileId;
            Z266SG_TileId = A266SG_TileId;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Z77( ) ;
            Load0Z77( ) ;
            Gx_mode = sMode77;
         }
         else
         {
            RcdFound77 = 0;
            InitializeNonKey0Z77( ) ;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Z77( ) ;
            Gx_mode = sMode77;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z77( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Z77( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Z2 */
            pr_default.execute(0, new Object[] {A264Trn_TileId, A266SG_TileId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_TileChildTile"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z269ChildTileOrder != BC000Z2_A269ChildTileOrder[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_TileChildTile"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z77( )
      {
         BeforeValidate0Z77( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z77( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z77( 0) ;
            CheckOptimisticConcurrency0Z77( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z77( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z77( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z27 */
                     pr_default.execute(25, new Object[] {A264Trn_TileId, A269ChildTileOrder, A266SG_TileId});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_TileChildTile");
                     if ( (pr_default.getStatus(25) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0Z77( ) ;
            }
            EndLevel0Z77( ) ;
         }
         CloseExtendedTableCursors0Z77( ) ;
      }

      protected void Update0Z77( )
      {
         BeforeValidate0Z77( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z77( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z77( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z77( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z77( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z28 */
                     pr_default.execute(26, new Object[] {A269ChildTileOrder, A264Trn_TileId, A266SG_TileId});
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_TileChildTile");
                     if ( (pr_default.getStatus(26) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_TileChildTile"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z77( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0Z77( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0Z77( ) ;
         }
         CloseExtendedTableCursors0Z77( ) ;
      }

      protected void DeferredUpdate0Z77( )
      {
      }

      protected void Delete0Z77( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Z77( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z77( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z77( ) ;
            AfterConfirm0Z77( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z77( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Z29 */
                  pr_default.execute(27, new Object[] {A264Trn_TileId, A266SG_TileId});
                  pr_default.close(27);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_TileChildTile");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode77 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Z77( ) ;
         Gx_mode = sMode77;
      }

      protected void OnDeleteControls0Z77( )
      {
         standaloneModal0Z77( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000Z30 */
            pr_default.execute(28, new Object[] {A266SG_TileId});
            A267SG_TileName = BC000Z30_A267SG_TileName[0];
            A275SG_TileWidth = BC000Z30_A275SG_TileWidth[0];
            A276SG_TileColor = BC000Z30_A276SG_TileColor[0];
            A277SG_TileBGImageUrl = BC000Z30_A277SG_TileBGImageUrl[0];
            pr_default.close(28);
         }
      }

      protected void EndLevel0Z77( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0Z77( )
      {
         /* Scan By routine */
         /* Using cursor BC000Z31 */
         pr_default.execute(29, new Object[] {A264Trn_TileId});
         RcdFound77 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound77 = 1;
            A267SG_TileName = BC000Z31_A267SG_TileName[0];
            A275SG_TileWidth = BC000Z31_A275SG_TileWidth[0];
            A276SG_TileColor = BC000Z31_A276SG_TileColor[0];
            A277SG_TileBGImageUrl = BC000Z31_A277SG_TileBGImageUrl[0];
            A269ChildTileOrder = BC000Z31_A269ChildTileOrder[0];
            A266SG_TileId = BC000Z31_A266SG_TileId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Z77( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound77 = 0;
         ScanKeyLoad0Z77( ) ;
      }

      protected void ScanKeyLoad0Z77( )
      {
         sMode77 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound77 = 1;
            A267SG_TileName = BC000Z31_A267SG_TileName[0];
            A275SG_TileWidth = BC000Z31_A275SG_TileWidth[0];
            A276SG_TileColor = BC000Z31_A276SG_TileColor[0];
            A277SG_TileBGImageUrl = BC000Z31_A277SG_TileBGImageUrl[0];
            A269ChildTileOrder = BC000Z31_A269ChildTileOrder[0];
            A266SG_TileId = BC000Z31_A266SG_TileId[0];
         }
         Gx_mode = sMode77;
      }

      protected void ScanKeyEnd0Z77( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm0Z77( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z77( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z77( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z77( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z77( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z77( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z77( )
      {
      }

      protected void send_integrity_lvl_hashes0Z77( )
      {
      }

      protected void send_integrity_lvl_hashes0Z71( )
      {
      }

      protected void AddRow0Z71( )
      {
         VarsToRow71( bcTrn_Tile) ;
      }

      protected void ReadRow0Z71( )
      {
         RowToVars71( bcTrn_Tile, 1) ;
      }

      protected void AddRow0Z52( )
      {
         SdtTrn_Tile_Attribute obj52;
         obj52 = new SdtTrn_Tile_Attribute(context);
         VarsToRow52( obj52) ;
         bcTrn_Tile.gxTpr_Attribute.Add(obj52, 0);
         obj52.gxTpr_Mode = "UPD";
         obj52.gxTpr_Modified = 0;
      }

      protected void ReadRow0Z52( )
      {
         nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
         RowToVars52( ((SdtTrn_Tile_Attribute)bcTrn_Tile.gxTpr_Attribute.Item(nGXsfl_52_idx)), 1) ;
      }

      protected void AddRow0Z77( )
      {
         SdtTrn_Tile_ChildTile obj77;
         obj77 = new SdtTrn_Tile_ChildTile(context);
         VarsToRow77( obj77) ;
         bcTrn_Tile.gxTpr_Childtile.Add(obj77, 0);
         obj77.gxTpr_Mode = "UPD";
         obj77.gxTpr_Modified = 0;
      }

      protected void ReadRow0Z77( )
      {
         nGXsfl_77_idx = (int)(nGXsfl_77_idx+1);
         RowToVars77( ((SdtTrn_Tile_ChildTile)bcTrn_Tile.gxTpr_Childtile.Item(nGXsfl_77_idx)), 1) ;
      }

      protected void InitializeNonKey0Z71( )
      {
         A265Trn_TileName = "";
         A268Trn_TileWidth = 0;
         A270Trn_TileColor = "";
         A271Trn_TileBGImageUrl = "";
         A58ProductServiceId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A59ProductServiceName = "";
         A60ProductServiceDescription = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         Z265Trn_TileName = "";
         Z268Trn_TileWidth = 0;
         Z270Trn_TileColor = "";
         Z271Trn_TileBGImageUrl = "";
         Z58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll0Z71( )
      {
         A264Trn_TileId = Guid.NewGuid( );
         InitializeNonKey0Z71( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0Z52( )
      {
         A273AttributeName = "";
         A274AttrbuteValue = "";
         Z273AttributeName = "";
         Z274AttrbuteValue = "";
      }

      protected void InitAll0Z52( )
      {
         A272AttributeId = Guid.NewGuid( );
         InitializeNonKey0Z52( ) ;
      }

      protected void StandaloneModalInsert0Z52( )
      {
      }

      protected void InitializeNonKey0Z77( )
      {
         A267SG_TileName = "";
         A275SG_TileWidth = 0;
         A276SG_TileColor = "";
         A277SG_TileBGImageUrl = "";
         A269ChildTileOrder = 0;
         Z269ChildTileOrder = 0;
      }

      protected void InitAll0Z77( )
      {
         A266SG_TileId = Guid.Empty;
         InitializeNonKey0Z77( ) ;
      }

      protected void StandaloneModalInsert0Z77( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow71( SdtTrn_Tile obj71 )
      {
         obj71.gxTpr_Mode = Gx_mode;
         obj71.gxTpr_Trn_tilename = A265Trn_TileName;
         obj71.gxTpr_Trn_tilewidth = A268Trn_TileWidth;
         obj71.gxTpr_Trn_tilecolor = A270Trn_TileColor;
         obj71.gxTpr_Trn_tilebgimageurl = A271Trn_TileBGImageUrl;
         obj71.gxTpr_Productserviceid = A58ProductServiceId;
         obj71.gxTpr_Organisationid = A11OrganisationId;
         obj71.gxTpr_Locationid = A29LocationId;
         obj71.gxTpr_Productservicename = A59ProductServiceName;
         obj71.gxTpr_Productservicedescription = A60ProductServiceDescription;
         obj71.gxTpr_Productserviceimage = A61ProductServiceImage;
         obj71.gxTpr_Productserviceimage_gxi = A40000ProductServiceImage_GXI;
         obj71.gxTpr_Trn_tileid = A264Trn_TileId;
         obj71.gxTpr_Trn_tileid_Z = Z264Trn_TileId;
         obj71.gxTpr_Trn_tilename_Z = Z265Trn_TileName;
         obj71.gxTpr_Trn_tilewidth_Z = Z268Trn_TileWidth;
         obj71.gxTpr_Trn_tilecolor_Z = Z270Trn_TileColor;
         obj71.gxTpr_Trn_tilebgimageurl_Z = Z271Trn_TileBGImageUrl;
         obj71.gxTpr_Productserviceid_Z = Z58ProductServiceId;
         obj71.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj71.gxTpr_Locationid_Z = Z29LocationId;
         obj71.gxTpr_Productservicename_Z = Z59ProductServiceName;
         obj71.gxTpr_Productserviceimage_gxi_Z = Z40000ProductServiceImage_GXI;
         obj71.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow71( SdtTrn_Tile obj71 )
      {
         obj71.gxTpr_Trn_tileid = A264Trn_TileId;
         return  ;
      }

      public void RowToVars71( SdtTrn_Tile obj71 ,
                               int forceLoad )
      {
         Gx_mode = obj71.gxTpr_Mode;
         A265Trn_TileName = obj71.gxTpr_Trn_tilename;
         A268Trn_TileWidth = obj71.gxTpr_Trn_tilewidth;
         A270Trn_TileColor = obj71.gxTpr_Trn_tilecolor;
         A271Trn_TileBGImageUrl = obj71.gxTpr_Trn_tilebgimageurl;
         A58ProductServiceId = obj71.gxTpr_Productserviceid;
         A11OrganisationId = obj71.gxTpr_Organisationid;
         A29LocationId = obj71.gxTpr_Locationid;
         A59ProductServiceName = obj71.gxTpr_Productservicename;
         A60ProductServiceDescription = obj71.gxTpr_Productservicedescription;
         A61ProductServiceImage = obj71.gxTpr_Productserviceimage;
         A40000ProductServiceImage_GXI = obj71.gxTpr_Productserviceimage_gxi;
         A264Trn_TileId = obj71.gxTpr_Trn_tileid;
         Z264Trn_TileId = obj71.gxTpr_Trn_tileid_Z;
         Z265Trn_TileName = obj71.gxTpr_Trn_tilename_Z;
         Z268Trn_TileWidth = obj71.gxTpr_Trn_tilewidth_Z;
         Z270Trn_TileColor = obj71.gxTpr_Trn_tilecolor_Z;
         Z271Trn_TileBGImageUrl = obj71.gxTpr_Trn_tilebgimageurl_Z;
         Z58ProductServiceId = obj71.gxTpr_Productserviceid_Z;
         Z11OrganisationId = obj71.gxTpr_Organisationid_Z;
         Z29LocationId = obj71.gxTpr_Locationid_Z;
         Z59ProductServiceName = obj71.gxTpr_Productservicename_Z;
         Z40000ProductServiceImage_GXI = obj71.gxTpr_Productserviceimage_gxi_Z;
         Gx_mode = obj71.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow52( SdtTrn_Tile_Attribute obj52 )
      {
         obj52.gxTpr_Mode = Gx_mode;
         obj52.gxTpr_Attributename = A273AttributeName;
         obj52.gxTpr_Attrbutevalue = A274AttrbuteValue;
         obj52.gxTpr_Attributeid = A272AttributeId;
         obj52.gxTpr_Attributeid_Z = Z272AttributeId;
         obj52.gxTpr_Attributename_Z = Z273AttributeName;
         obj52.gxTpr_Attrbutevalue_Z = Z274AttrbuteValue;
         obj52.gxTpr_Modified = nIsMod_52;
         return  ;
      }

      public void KeyVarsToRow52( SdtTrn_Tile_Attribute obj52 )
      {
         obj52.gxTpr_Attributeid = A272AttributeId;
         return  ;
      }

      public void RowToVars52( SdtTrn_Tile_Attribute obj52 ,
                               int forceLoad )
      {
         Gx_mode = obj52.gxTpr_Mode;
         A273AttributeName = obj52.gxTpr_Attributename;
         A274AttrbuteValue = obj52.gxTpr_Attrbutevalue;
         A272AttributeId = obj52.gxTpr_Attributeid;
         Z272AttributeId = obj52.gxTpr_Attributeid_Z;
         Z273AttributeName = obj52.gxTpr_Attributename_Z;
         Z274AttrbuteValue = obj52.gxTpr_Attrbutevalue_Z;
         nIsMod_52 = obj52.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow77( SdtTrn_Tile_ChildTile obj77 )
      {
         obj77.gxTpr_Mode = Gx_mode;
         obj77.gxTpr_Sg_tilename = A267SG_TileName;
         obj77.gxTpr_Sg_tilewidth = A275SG_TileWidth;
         obj77.gxTpr_Sg_tilecolor = A276SG_TileColor;
         obj77.gxTpr_Sg_tilebgimageurl = A277SG_TileBGImageUrl;
         obj77.gxTpr_Childtileorder = A269ChildTileOrder;
         obj77.gxTpr_Sg_tileid = A266SG_TileId;
         obj77.gxTpr_Sg_tileid_Z = Z266SG_TileId;
         obj77.gxTpr_Sg_tilename_Z = Z267SG_TileName;
         obj77.gxTpr_Sg_tilewidth_Z = Z275SG_TileWidth;
         obj77.gxTpr_Sg_tilecolor_Z = Z276SG_TileColor;
         obj77.gxTpr_Sg_tilebgimageurl_Z = Z277SG_TileBGImageUrl;
         obj77.gxTpr_Childtileorder_Z = Z269ChildTileOrder;
         obj77.gxTpr_Modified = nIsMod_77;
         return  ;
      }

      public void KeyVarsToRow77( SdtTrn_Tile_ChildTile obj77 )
      {
         obj77.gxTpr_Sg_tileid = A266SG_TileId;
         return  ;
      }

      public void RowToVars77( SdtTrn_Tile_ChildTile obj77 ,
                               int forceLoad )
      {
         Gx_mode = obj77.gxTpr_Mode;
         A267SG_TileName = obj77.gxTpr_Sg_tilename;
         A275SG_TileWidth = obj77.gxTpr_Sg_tilewidth;
         A276SG_TileColor = obj77.gxTpr_Sg_tilecolor;
         A277SG_TileBGImageUrl = obj77.gxTpr_Sg_tilebgimageurl;
         A269ChildTileOrder = obj77.gxTpr_Childtileorder;
         A266SG_TileId = obj77.gxTpr_Sg_tileid;
         Z266SG_TileId = obj77.gxTpr_Sg_tileid_Z;
         Z267SG_TileName = obj77.gxTpr_Sg_tilename_Z;
         Z275SG_TileWidth = obj77.gxTpr_Sg_tilewidth_Z;
         Z276SG_TileColor = obj77.gxTpr_Sg_tilecolor_Z;
         Z277SG_TileBGImageUrl = obj77.gxTpr_Sg_tilebgimageurl_Z;
         Z269ChildTileOrder = obj77.gxTpr_Childtileorder_Z;
         nIsMod_77 = obj77.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A264Trn_TileId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0Z71( ) ;
         ScanKeyStart0Z71( ) ;
         if ( RcdFound71 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z264Trn_TileId = A264Trn_TileId;
         }
         ZM0Z71( -13) ;
         OnLoadActions0Z71( ) ;
         AddRow0Z71( ) ;
         bcTrn_Tile.gxTpr_Attribute.ClearCollection();
         if ( RcdFound71 == 1 )
         {
            ScanKeyStart0Z52( ) ;
            nGXsfl_52_idx = 1;
            while ( RcdFound52 != 0 )
            {
               Z264Trn_TileId = A264Trn_TileId;
               Z272AttributeId = A272AttributeId;
               ZM0Z52( -15) ;
               OnLoadActions0Z52( ) ;
               nRcdExists_52 = 1;
               nIsMod_52 = 0;
               AddRow0Z52( ) ;
               nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
               ScanKeyNext0Z52( ) ;
            }
            ScanKeyEnd0Z52( ) ;
         }
         bcTrn_Tile.gxTpr_Childtile.ClearCollection();
         if ( RcdFound71 == 1 )
         {
            ScanKeyStart0Z77( ) ;
            nGXsfl_77_idx = 1;
            while ( RcdFound77 != 0 )
            {
               Z264Trn_TileId = A264Trn_TileId;
               Z266SG_TileId = A266SG_TileId;
               ZM0Z77( -16) ;
               OnLoadActions0Z77( ) ;
               nRcdExists_77 = 1;
               nIsMod_77 = 0;
               AddRow0Z77( ) ;
               nGXsfl_77_idx = (int)(nGXsfl_77_idx+1);
               ScanKeyNext0Z77( ) ;
            }
            ScanKeyEnd0Z77( ) ;
         }
         ScanKeyEnd0Z71( ) ;
         if ( RcdFound71 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars71( bcTrn_Tile, 0) ;
         ScanKeyStart0Z71( ) ;
         if ( RcdFound71 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z264Trn_TileId = A264Trn_TileId;
         }
         ZM0Z71( -13) ;
         OnLoadActions0Z71( ) ;
         AddRow0Z71( ) ;
         bcTrn_Tile.gxTpr_Attribute.ClearCollection();
         if ( RcdFound71 == 1 )
         {
            ScanKeyStart0Z52( ) ;
            nGXsfl_52_idx = 1;
            while ( RcdFound52 != 0 )
            {
               Z264Trn_TileId = A264Trn_TileId;
               Z272AttributeId = A272AttributeId;
               ZM0Z52( -15) ;
               OnLoadActions0Z52( ) ;
               nRcdExists_52 = 1;
               nIsMod_52 = 0;
               AddRow0Z52( ) ;
               nGXsfl_52_idx = (int)(nGXsfl_52_idx+1);
               ScanKeyNext0Z52( ) ;
            }
            ScanKeyEnd0Z52( ) ;
         }
         bcTrn_Tile.gxTpr_Childtile.ClearCollection();
         if ( RcdFound71 == 1 )
         {
            ScanKeyStart0Z77( ) ;
            nGXsfl_77_idx = 1;
            while ( RcdFound77 != 0 )
            {
               Z264Trn_TileId = A264Trn_TileId;
               Z266SG_TileId = A266SG_TileId;
               ZM0Z77( -16) ;
               OnLoadActions0Z77( ) ;
               nRcdExists_77 = 1;
               nIsMod_77 = 0;
               AddRow0Z77( ) ;
               nGXsfl_77_idx = (int)(nGXsfl_77_idx+1);
               ScanKeyNext0Z77( ) ;
            }
            ScanKeyEnd0Z77( ) ;
         }
         ScanKeyEnd0Z71( ) ;
         if ( RcdFound71 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0Z71( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0Z71( ) ;
         }
         else
         {
            if ( RcdFound71 == 1 )
            {
               if ( A264Trn_TileId != Z264Trn_TileId )
               {
                  A264Trn_TileId = Z264Trn_TileId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0Z71( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A264Trn_TileId != Z264Trn_TileId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0Z71( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0Z71( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars71( bcTrn_Tile, 1) ;
         SaveImpl( ) ;
         VarsToRow71( bcTrn_Tile) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars71( bcTrn_Tile, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Z71( ) ;
         AfterTrn( ) ;
         VarsToRow71( bcTrn_Tile) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow71( bcTrn_Tile) ;
         }
         else
         {
            SdtTrn_Tile auxBC = new SdtTrn_Tile(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A264Trn_TileId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Tile);
               auxBC.Save();
               bcTrn_Tile.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars71( bcTrn_Tile, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars71( bcTrn_Tile, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Z71( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow71( bcTrn_Tile) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow71( bcTrn_Tile) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars71( bcTrn_Tile, 0) ;
         GetKey0Z71( ) ;
         if ( RcdFound71 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A264Trn_TileId != Z264Trn_TileId )
            {
               A264Trn_TileId = Z264Trn_TileId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A264Trn_TileId != Z264Trn_TileId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("trn_tile_bc",pr_default);
         VarsToRow71( bcTrn_Tile) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcTrn_Tile.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Tile.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Tile )
         {
            bcTrn_Tile = (SdtTrn_Tile)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Tile.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Tile.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow71( bcTrn_Tile) ;
            }
            else
            {
               RowToVars71( bcTrn_Tile, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Tile.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Tile.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars71( bcTrn_Tile, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Tile Trn_Tile_BC
      {
         get {
            return bcTrn_Tile ;
         }

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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_page_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(28);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z264Trn_TileId = Guid.Empty;
         A264Trn_TileId = Guid.Empty;
         sMode71 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV48Pgmname = "";
         AV21TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV20Insert_ProductServiceId = Guid.Empty;
         AV46Insert_OrganisationId = Guid.Empty;
         AV47Insert_LocationId = Guid.Empty;
         Z265Trn_TileName = "";
         A265Trn_TileName = "";
         Z270Trn_TileColor = "";
         A270Trn_TileColor = "";
         Z271Trn_TileBGImageUrl = "";
         A271Trn_TileBGImageUrl = "";
         Z58ProductServiceId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z59ProductServiceName = "";
         A59ProductServiceName = "";
         Z60ProductServiceDescription = "";
         A60ProductServiceDescription = "";
         Z61ProductServiceImage = "";
         A61ProductServiceImage = "";
         Z40000ProductServiceImage_GXI = "";
         A40000ProductServiceImage_GXI = "";
         BC000Z10_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z10_A265Trn_TileName = new string[] {""} ;
         BC000Z10_A268Trn_TileWidth = new short[1] ;
         BC000Z10_A270Trn_TileColor = new string[] {""} ;
         BC000Z10_A271Trn_TileBGImageUrl = new string[] {""} ;
         BC000Z10_A59ProductServiceName = new string[] {""} ;
         BC000Z10_A60ProductServiceDescription = new string[] {""} ;
         BC000Z10_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC000Z10_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000Z10_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Z10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z10_A61ProductServiceImage = new string[] {""} ;
         BC000Z9_A59ProductServiceName = new string[] {""} ;
         BC000Z9_A60ProductServiceDescription = new string[] {""} ;
         BC000Z9_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC000Z9_A61ProductServiceImage = new string[] {""} ;
         BC000Z11_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z8_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z8_A265Trn_TileName = new string[] {""} ;
         BC000Z8_A268Trn_TileWidth = new short[1] ;
         BC000Z8_A270Trn_TileColor = new string[] {""} ;
         BC000Z8_A271Trn_TileBGImageUrl = new string[] {""} ;
         BC000Z8_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000Z8_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Z8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z7_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z7_A265Trn_TileName = new string[] {""} ;
         BC000Z7_A268Trn_TileWidth = new short[1] ;
         BC000Z7_A270Trn_TileColor = new string[] {""} ;
         BC000Z7_A271Trn_TileBGImageUrl = new string[] {""} ;
         BC000Z7_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000Z7_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Z7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z15_A59ProductServiceName = new string[] {""} ;
         BC000Z15_A60ProductServiceDescription = new string[] {""} ;
         BC000Z15_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC000Z15_A61ProductServiceImage = new string[] {""} ;
         BC000Z16_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         BC000Z17_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z17_A266SG_TileId = new Guid[] {Guid.Empty} ;
         BC000Z18_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z18_A265Trn_TileName = new string[] {""} ;
         BC000Z18_A268Trn_TileWidth = new short[1] ;
         BC000Z18_A270Trn_TileColor = new string[] {""} ;
         BC000Z18_A271Trn_TileBGImageUrl = new string[] {""} ;
         BC000Z18_A59ProductServiceName = new string[] {""} ;
         BC000Z18_A60ProductServiceDescription = new string[] {""} ;
         BC000Z18_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC000Z18_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000Z18_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Z18_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z18_A61ProductServiceImage = new string[] {""} ;
         Z273AttributeName = "";
         A273AttributeName = "";
         Z274AttrbuteValue = "";
         A274AttrbuteValue = "";
         Z272AttributeId = Guid.Empty;
         A272AttributeId = Guid.Empty;
         BC000Z19_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z19_A272AttributeId = new Guid[] {Guid.Empty} ;
         BC000Z19_A273AttributeName = new string[] {""} ;
         BC000Z19_A274AttrbuteValue = new string[] {""} ;
         BC000Z20_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z20_A272AttributeId = new Guid[] {Guid.Empty} ;
         BC000Z6_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z6_A272AttributeId = new Guid[] {Guid.Empty} ;
         BC000Z6_A273AttributeName = new string[] {""} ;
         BC000Z6_A274AttrbuteValue = new string[] {""} ;
         sMode52 = "";
         BC000Z5_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z5_A272AttributeId = new Guid[] {Guid.Empty} ;
         BC000Z5_A273AttributeName = new string[] {""} ;
         BC000Z5_A274AttrbuteValue = new string[] {""} ;
         BC000Z24_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z24_A272AttributeId = new Guid[] {Guid.Empty} ;
         BC000Z24_A273AttributeName = new string[] {""} ;
         BC000Z24_A274AttrbuteValue = new string[] {""} ;
         Z267SG_TileName = "";
         A267SG_TileName = "";
         Z276SG_TileColor = "";
         A276SG_TileColor = "";
         Z277SG_TileBGImageUrl = "";
         A277SG_TileBGImageUrl = "";
         Z266SG_TileId = Guid.Empty;
         A266SG_TileId = Guid.Empty;
         BC000Z25_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z25_A267SG_TileName = new string[] {""} ;
         BC000Z25_A275SG_TileWidth = new short[1] ;
         BC000Z25_A276SG_TileColor = new string[] {""} ;
         BC000Z25_A277SG_TileBGImageUrl = new string[] {""} ;
         BC000Z25_A269ChildTileOrder = new short[1] ;
         BC000Z25_A266SG_TileId = new Guid[] {Guid.Empty} ;
         BC000Z4_A267SG_TileName = new string[] {""} ;
         BC000Z4_A275SG_TileWidth = new short[1] ;
         BC000Z4_A276SG_TileColor = new string[] {""} ;
         BC000Z4_A277SG_TileBGImageUrl = new string[] {""} ;
         BC000Z26_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z26_A266SG_TileId = new Guid[] {Guid.Empty} ;
         BC000Z3_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z3_A269ChildTileOrder = new short[1] ;
         BC000Z3_A266SG_TileId = new Guid[] {Guid.Empty} ;
         sMode77 = "";
         BC000Z2_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z2_A269ChildTileOrder = new short[1] ;
         BC000Z2_A266SG_TileId = new Guid[] {Guid.Empty} ;
         BC000Z30_A267SG_TileName = new string[] {""} ;
         BC000Z30_A275SG_TileWidth = new short[1] ;
         BC000Z30_A276SG_TileColor = new string[] {""} ;
         BC000Z30_A277SG_TileBGImageUrl = new string[] {""} ;
         BC000Z31_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000Z31_A267SG_TileName = new string[] {""} ;
         BC000Z31_A275SG_TileWidth = new short[1] ;
         BC000Z31_A276SG_TileColor = new string[] {""} ;
         BC000Z31_A277SG_TileBGImageUrl = new string[] {""} ;
         BC000Z31_A269ChildTileOrder = new short[1] ;
         BC000Z31_A266SG_TileId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_tile_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tile_bc__default(),
            new Object[][] {
                new Object[] {
               BC000Z2_A264Trn_TileId, BC000Z2_A269ChildTileOrder, BC000Z2_A266SG_TileId
               }
               , new Object[] {
               BC000Z3_A264Trn_TileId, BC000Z3_A269ChildTileOrder, BC000Z3_A266SG_TileId
               }
               , new Object[] {
               BC000Z4_A267SG_TileName, BC000Z4_A275SG_TileWidth, BC000Z4_A276SG_TileColor, BC000Z4_A277SG_TileBGImageUrl
               }
               , new Object[] {
               BC000Z5_A264Trn_TileId, BC000Z5_A272AttributeId, BC000Z5_A273AttributeName, BC000Z5_A274AttrbuteValue
               }
               , new Object[] {
               BC000Z6_A264Trn_TileId, BC000Z6_A272AttributeId, BC000Z6_A273AttributeName, BC000Z6_A274AttrbuteValue
               }
               , new Object[] {
               BC000Z7_A264Trn_TileId, BC000Z7_A265Trn_TileName, BC000Z7_A268Trn_TileWidth, BC000Z7_A270Trn_TileColor, BC000Z7_A271Trn_TileBGImageUrl, BC000Z7_A58ProductServiceId, BC000Z7_A29LocationId, BC000Z7_A11OrganisationId
               }
               , new Object[] {
               BC000Z8_A264Trn_TileId, BC000Z8_A265Trn_TileName, BC000Z8_A268Trn_TileWidth, BC000Z8_A270Trn_TileColor, BC000Z8_A271Trn_TileBGImageUrl, BC000Z8_A58ProductServiceId, BC000Z8_A29LocationId, BC000Z8_A11OrganisationId
               }
               , new Object[] {
               BC000Z9_A59ProductServiceName, BC000Z9_A60ProductServiceDescription, BC000Z9_A40000ProductServiceImage_GXI, BC000Z9_A61ProductServiceImage
               }
               , new Object[] {
               BC000Z10_A264Trn_TileId, BC000Z10_A265Trn_TileName, BC000Z10_A268Trn_TileWidth, BC000Z10_A270Trn_TileColor, BC000Z10_A271Trn_TileBGImageUrl, BC000Z10_A59ProductServiceName, BC000Z10_A60ProductServiceDescription, BC000Z10_A40000ProductServiceImage_GXI, BC000Z10_A58ProductServiceId, BC000Z10_A29LocationId,
               BC000Z10_A11OrganisationId, BC000Z10_A61ProductServiceImage
               }
               , new Object[] {
               BC000Z11_A264Trn_TileId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Z15_A59ProductServiceName, BC000Z15_A60ProductServiceDescription, BC000Z15_A40000ProductServiceImage_GXI, BC000Z15_A61ProductServiceImage
               }
               , new Object[] {
               BC000Z16_A328Trn_ColId
               }
               , new Object[] {
               BC000Z17_A264Trn_TileId, BC000Z17_A266SG_TileId
               }
               , new Object[] {
               BC000Z18_A264Trn_TileId, BC000Z18_A265Trn_TileName, BC000Z18_A268Trn_TileWidth, BC000Z18_A270Trn_TileColor, BC000Z18_A271Trn_TileBGImageUrl, BC000Z18_A59ProductServiceName, BC000Z18_A60ProductServiceDescription, BC000Z18_A40000ProductServiceImage_GXI, BC000Z18_A58ProductServiceId, BC000Z18_A29LocationId,
               BC000Z18_A11OrganisationId, BC000Z18_A61ProductServiceImage
               }
               , new Object[] {
               BC000Z19_A264Trn_TileId, BC000Z19_A272AttributeId, BC000Z19_A273AttributeName, BC000Z19_A274AttrbuteValue
               }
               , new Object[] {
               BC000Z20_A264Trn_TileId, BC000Z20_A272AttributeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Z24_A264Trn_TileId, BC000Z24_A272AttributeId, BC000Z24_A273AttributeName, BC000Z24_A274AttrbuteValue
               }
               , new Object[] {
               BC000Z25_A264Trn_TileId, BC000Z25_A267SG_TileName, BC000Z25_A275SG_TileWidth, BC000Z25_A276SG_TileColor, BC000Z25_A277SG_TileBGImageUrl, BC000Z25_A269ChildTileOrder, BC000Z25_A266SG_TileId
               }
               , new Object[] {
               BC000Z26_A264Trn_TileId, BC000Z26_A266SG_TileId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Z30_A267SG_TileName, BC000Z30_A275SG_TileWidth, BC000Z30_A276SG_TileColor, BC000Z30_A277SG_TileBGImageUrl
               }
               , new Object[] {
               BC000Z31_A264Trn_TileId, BC000Z31_A267SG_TileName, BC000Z31_A275SG_TileWidth, BC000Z31_A276SG_TileColor, BC000Z31_A277SG_TileBGImageUrl, BC000Z31_A269ChildTileOrder, BC000Z31_A266SG_TileId
               }
            }
         );
         Z272AttributeId = Guid.NewGuid( );
         A272AttributeId = Guid.NewGuid( );
         Z264Trn_TileId = Guid.NewGuid( );
         A264Trn_TileId = Guid.NewGuid( );
         AV48Pgmname = "Trn_Tile_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120Z2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_77 ;
      private short RcdFound77 ;
      private short nIsMod_52 ;
      private short RcdFound52 ;
      private short Z268Trn_TileWidth ;
      private short A268Trn_TileWidth ;
      private short Gx_BScreen ;
      private short RcdFound71 ;
      private short nRcdExists_52 ;
      private short nRcdExists_77 ;
      private short Gxremove52 ;
      private short Z269ChildTileOrder ;
      private short A269ChildTileOrder ;
      private short Z275SG_TileWidth ;
      private short A275SG_TileWidth ;
      private short Gxremove77 ;
      private int trnEnded ;
      private int nGXsfl_77_idx=1 ;
      private int nGXsfl_52_idx=1 ;
      private int AV49GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode71 ;
      private string AV48Pgmname ;
      private string Z270Trn_TileColor ;
      private string A270Trn_TileColor ;
      private string sMode52 ;
      private string Z276SG_TileColor ;
      private string A276SG_TileColor ;
      private string sMode77 ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z60ProductServiceDescription ;
      private string A60ProductServiceDescription ;
      private string Z265Trn_TileName ;
      private string A265Trn_TileName ;
      private string Z271Trn_TileBGImageUrl ;
      private string A271Trn_TileBGImageUrl ;
      private string Z59ProductServiceName ;
      private string A59ProductServiceName ;
      private string Z40000ProductServiceImage_GXI ;
      private string A40000ProductServiceImage_GXI ;
      private string Z273AttributeName ;
      private string A273AttributeName ;
      private string Z274AttrbuteValue ;
      private string A274AttrbuteValue ;
      private string Z267SG_TileName ;
      private string A267SG_TileName ;
      private string Z277SG_TileBGImageUrl ;
      private string A277SG_TileBGImageUrl ;
      private string Z61ProductServiceImage ;
      private string A61ProductServiceImage ;
      private Guid Z264Trn_TileId ;
      private Guid A264Trn_TileId ;
      private Guid AV20Insert_ProductServiceId ;
      private Guid AV46Insert_OrganisationId ;
      private Guid AV47Insert_LocationId ;
      private Guid Z58ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z272AttributeId ;
      private Guid A272AttributeId ;
      private Guid Z266SG_TileId ;
      private Guid A266SG_TileId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Tile bcTrn_Tile ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV21TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000Z10_A264Trn_TileId ;
      private string[] BC000Z10_A265Trn_TileName ;
      private short[] BC000Z10_A268Trn_TileWidth ;
      private string[] BC000Z10_A270Trn_TileColor ;
      private string[] BC000Z10_A271Trn_TileBGImageUrl ;
      private string[] BC000Z10_A59ProductServiceName ;
      private string[] BC000Z10_A60ProductServiceDescription ;
      private string[] BC000Z10_A40000ProductServiceImage_GXI ;
      private Guid[] BC000Z10_A58ProductServiceId ;
      private Guid[] BC000Z10_A29LocationId ;
      private Guid[] BC000Z10_A11OrganisationId ;
      private string[] BC000Z10_A61ProductServiceImage ;
      private string[] BC000Z9_A59ProductServiceName ;
      private string[] BC000Z9_A60ProductServiceDescription ;
      private string[] BC000Z9_A40000ProductServiceImage_GXI ;
      private string[] BC000Z9_A61ProductServiceImage ;
      private Guid[] BC000Z11_A264Trn_TileId ;
      private Guid[] BC000Z8_A264Trn_TileId ;
      private string[] BC000Z8_A265Trn_TileName ;
      private short[] BC000Z8_A268Trn_TileWidth ;
      private string[] BC000Z8_A270Trn_TileColor ;
      private string[] BC000Z8_A271Trn_TileBGImageUrl ;
      private Guid[] BC000Z8_A58ProductServiceId ;
      private Guid[] BC000Z8_A29LocationId ;
      private Guid[] BC000Z8_A11OrganisationId ;
      private Guid[] BC000Z7_A264Trn_TileId ;
      private string[] BC000Z7_A265Trn_TileName ;
      private short[] BC000Z7_A268Trn_TileWidth ;
      private string[] BC000Z7_A270Trn_TileColor ;
      private string[] BC000Z7_A271Trn_TileBGImageUrl ;
      private Guid[] BC000Z7_A58ProductServiceId ;
      private Guid[] BC000Z7_A29LocationId ;
      private Guid[] BC000Z7_A11OrganisationId ;
      private string[] BC000Z15_A59ProductServiceName ;
      private string[] BC000Z15_A60ProductServiceDescription ;
      private string[] BC000Z15_A40000ProductServiceImage_GXI ;
      private string[] BC000Z15_A61ProductServiceImage ;
      private Guid[] BC000Z16_A328Trn_ColId ;
      private Guid[] BC000Z17_A264Trn_TileId ;
      private Guid[] BC000Z17_A266SG_TileId ;
      private Guid[] BC000Z18_A264Trn_TileId ;
      private string[] BC000Z18_A265Trn_TileName ;
      private short[] BC000Z18_A268Trn_TileWidth ;
      private string[] BC000Z18_A270Trn_TileColor ;
      private string[] BC000Z18_A271Trn_TileBGImageUrl ;
      private string[] BC000Z18_A59ProductServiceName ;
      private string[] BC000Z18_A60ProductServiceDescription ;
      private string[] BC000Z18_A40000ProductServiceImage_GXI ;
      private Guid[] BC000Z18_A58ProductServiceId ;
      private Guid[] BC000Z18_A29LocationId ;
      private Guid[] BC000Z18_A11OrganisationId ;
      private string[] BC000Z18_A61ProductServiceImage ;
      private Guid[] BC000Z19_A264Trn_TileId ;
      private Guid[] BC000Z19_A272AttributeId ;
      private string[] BC000Z19_A273AttributeName ;
      private string[] BC000Z19_A274AttrbuteValue ;
      private Guid[] BC000Z20_A264Trn_TileId ;
      private Guid[] BC000Z20_A272AttributeId ;
      private Guid[] BC000Z6_A264Trn_TileId ;
      private Guid[] BC000Z6_A272AttributeId ;
      private string[] BC000Z6_A273AttributeName ;
      private string[] BC000Z6_A274AttrbuteValue ;
      private Guid[] BC000Z5_A264Trn_TileId ;
      private Guid[] BC000Z5_A272AttributeId ;
      private string[] BC000Z5_A273AttributeName ;
      private string[] BC000Z5_A274AttrbuteValue ;
      private Guid[] BC000Z24_A264Trn_TileId ;
      private Guid[] BC000Z24_A272AttributeId ;
      private string[] BC000Z24_A273AttributeName ;
      private string[] BC000Z24_A274AttrbuteValue ;
      private Guid[] BC000Z25_A264Trn_TileId ;
      private string[] BC000Z25_A267SG_TileName ;
      private short[] BC000Z25_A275SG_TileWidth ;
      private string[] BC000Z25_A276SG_TileColor ;
      private string[] BC000Z25_A277SG_TileBGImageUrl ;
      private short[] BC000Z25_A269ChildTileOrder ;
      private Guid[] BC000Z25_A266SG_TileId ;
      private string[] BC000Z4_A267SG_TileName ;
      private short[] BC000Z4_A275SG_TileWidth ;
      private string[] BC000Z4_A276SG_TileColor ;
      private string[] BC000Z4_A277SG_TileBGImageUrl ;
      private Guid[] BC000Z26_A264Trn_TileId ;
      private Guid[] BC000Z26_A266SG_TileId ;
      private Guid[] BC000Z3_A264Trn_TileId ;
      private short[] BC000Z3_A269ChildTileOrder ;
      private Guid[] BC000Z3_A266SG_TileId ;
      private Guid[] BC000Z2_A264Trn_TileId ;
      private short[] BC000Z2_A269ChildTileOrder ;
      private Guid[] BC000Z2_A266SG_TileId ;
      private string[] BC000Z30_A267SG_TileName ;
      private short[] BC000Z30_A275SG_TileWidth ;
      private string[] BC000Z30_A276SG_TileColor ;
      private string[] BC000Z30_A277SG_TileBGImageUrl ;
      private Guid[] BC000Z31_A264Trn_TileId ;
      private string[] BC000Z31_A267SG_TileName ;
      private short[] BC000Z31_A275SG_TileWidth ;
      private string[] BC000Z31_A276SG_TileColor ;
      private string[] BC000Z31_A277SG_TileBGImageUrl ;
      private short[] BC000Z31_A269ChildTileOrder ;
      private Guid[] BC000Z31_A266SG_TileId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_tile_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_tile_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000Z2;
        prmBC000Z2 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z3;
        prmBC000Z3 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z4;
        prmBC000Z4 = new Object[] {
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z5;
        prmBC000Z5 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z6;
        prmBC000Z6 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z7;
        prmBC000Z7 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z8;
        prmBC000Z8 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z9;
        prmBC000Z9 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z10;
        prmBC000Z10 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z11;
        prmBC000Z11 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z12;
        prmBC000Z12 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_TileName",GXType.VarChar,100,0) ,
        new ParDef("Trn_TileWidth",GXType.Int16,4,0) ,
        new ParDef("Trn_TileColor",GXType.Char,20,0) ,
        new ParDef("Trn_TileBGImageUrl",GXType.VarChar,1000,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z13;
        prmBC000Z13 = new Object[] {
        new ParDef("Trn_TileName",GXType.VarChar,100,0) ,
        new ParDef("Trn_TileWidth",GXType.Int16,4,0) ,
        new ParDef("Trn_TileColor",GXType.Char,20,0) ,
        new ParDef("Trn_TileBGImageUrl",GXType.VarChar,1000,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z14;
        prmBC000Z14 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z15;
        prmBC000Z15 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z16;
        prmBC000Z16 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z17;
        prmBC000Z17 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z18;
        prmBC000Z18 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z19;
        prmBC000Z19 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z20;
        prmBC000Z20 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z21;
        prmBC000Z21 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeName",GXType.VarChar,100,0) ,
        new ParDef("AttrbuteValue",GXType.VarChar,100,0)
        };
        Object[] prmBC000Z22;
        prmBC000Z22 = new Object[] {
        new ParDef("AttributeName",GXType.VarChar,100,0) ,
        new ParDef("AttrbuteValue",GXType.VarChar,100,0) ,
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z23;
        prmBC000Z23 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z24;
        prmBC000Z24 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z25;
        prmBC000Z25 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z26;
        prmBC000Z26 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z27;
        prmBC000Z27 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ChildTileOrder",GXType.Int16,4,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z28;
        prmBC000Z28 = new Object[] {
        new ParDef("ChildTileOrder",GXType.Int16,4,0) ,
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z29;
        prmBC000Z29 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z30;
        prmBC000Z30 = new Object[] {
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z31;
        prmBC000Z31 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000Z2", "SELECT Trn_TileId, ChildTileOrder, SG_TileId FROM Trn_TileChildTile WHERE Trn_TileId = :Trn_TileId AND SG_TileId = :SG_TileId  FOR UPDATE OF Trn_TileChildTile",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z3", "SELECT Trn_TileId, ChildTileOrder, SG_TileId FROM Trn_TileChildTile WHERE Trn_TileId = :Trn_TileId AND SG_TileId = :SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z4", "SELECT Trn_TileName AS SG_TileName, Trn_TileWidth AS SG_TileWidth, Trn_TileColor AS SG_TileColor, Trn_TileBGImageUrl AS SG_TileBGImageUrl FROM Trn_Tile WHERE Trn_TileId = :SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z5", "SELECT Trn_TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId  FOR UPDATE OF Trn_TileAttribute",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z6", "SELECT Trn_TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z7", "SELECT Trn_TileId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, ProductServiceId, LocationId, OrganisationId FROM Trn_Tile WHERE Trn_TileId = :Trn_TileId  FOR UPDATE OF Trn_Tile",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z8", "SELECT Trn_TileId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, ProductServiceId, LocationId, OrganisationId FROM Trn_Tile WHERE Trn_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z9", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z10", "SELECT TM1.Trn_TileId, TM1.Trn_TileName, TM1.Trn_TileWidth, TM1.Trn_TileColor, TM1.Trn_TileBGImageUrl, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceImage_GXI, TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId, T2.ProductServiceImage FROM (Trn_Tile TM1 INNER JOIN Trn_ProductService T2 ON T2.ProductServiceId = TM1.ProductServiceId AND T2.LocationId = TM1.LocationId AND T2.OrganisationId = TM1.OrganisationId) WHERE TM1.Trn_TileId = :Trn_TileId ORDER BY TM1.Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z11", "SELECT Trn_TileId FROM Trn_Tile WHERE Trn_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z12", "SAVEPOINT gxupdate;INSERT INTO Trn_Tile(Trn_TileId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, ProductServiceId, LocationId, OrganisationId) VALUES(:Trn_TileId, :Trn_TileName, :Trn_TileWidth, :Trn_TileColor, :Trn_TileBGImageUrl, :ProductServiceId, :LocationId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Z12)
           ,new CursorDef("BC000Z13", "SAVEPOINT gxupdate;UPDATE Trn_Tile SET Trn_TileName=:Trn_TileName, Trn_TileWidth=:Trn_TileWidth, Trn_TileColor=:Trn_TileColor, Trn_TileBGImageUrl=:Trn_TileBGImageUrl, ProductServiceId=:ProductServiceId, LocationId=:LocationId, OrganisationId=:OrganisationId  WHERE Trn_TileId = :Trn_TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z13)
           ,new CursorDef("BC000Z14", "SAVEPOINT gxupdate;DELETE FROM Trn_Tile  WHERE Trn_TileId = :Trn_TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z14)
           ,new CursorDef("BC000Z15", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z16", "SELECT Trn_ColId FROM Trn_Col1 WHERE Trn_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000Z17", "SELECT Trn_TileId, SG_TileId FROM Trn_TileChildTile WHERE SG_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000Z18", "SELECT TM1.Trn_TileId, TM1.Trn_TileName, TM1.Trn_TileWidth, TM1.Trn_TileColor, TM1.Trn_TileBGImageUrl, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceImage_GXI, TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId, T2.ProductServiceImage FROM (Trn_Tile TM1 INNER JOIN Trn_ProductService T2 ON T2.ProductServiceId = TM1.ProductServiceId AND T2.LocationId = TM1.LocationId AND T2.OrganisationId = TM1.OrganisationId) WHERE TM1.Trn_TileId = :Trn_TileId ORDER BY TM1.Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z19", "SELECT Trn_TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId and AttributeId = :AttributeId ORDER BY Trn_TileId, AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z19,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z20", "SELECT Trn_TileId, AttributeId FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z21", "SAVEPOINT gxupdate;INSERT INTO Trn_TileAttribute(Trn_TileId, AttributeId, AttributeName, AttrbuteValue) VALUES(:Trn_TileId, :AttributeId, :AttributeName, :AttrbuteValue);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Z21)
           ,new CursorDef("BC000Z22", "SAVEPOINT gxupdate;UPDATE Trn_TileAttribute SET AttributeName=:AttributeName, AttrbuteValue=:AttrbuteValue  WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z22)
           ,new CursorDef("BC000Z23", "SAVEPOINT gxupdate;DELETE FROM Trn_TileAttribute  WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z23)
           ,new CursorDef("BC000Z24", "SELECT Trn_TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId ORDER BY Trn_TileId, AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z24,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z25", "SELECT T1.Trn_TileId, T2.Trn_TileName AS SG_TileName, T2.Trn_TileWidth AS SG_TileWidth, T2.Trn_TileColor AS SG_TileColor, T2.Trn_TileBGImageUrl AS SG_TileBGImageUrl, T1.ChildTileOrder, T1.SG_TileId AS SG_TileId FROM (Trn_TileChildTile T1 INNER JOIN Trn_Tile T2 ON T2.Trn_TileId = T1.SG_TileId) WHERE T1.Trn_TileId = :Trn_TileId and T1.SG_TileId = :SG_TileId ORDER BY T1.Trn_TileId, T1.SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z25,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z26", "SELECT Trn_TileId, SG_TileId FROM Trn_TileChildTile WHERE Trn_TileId = :Trn_TileId AND SG_TileId = :SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z27", "SAVEPOINT gxupdate;INSERT INTO Trn_TileChildTile(Trn_TileId, ChildTileOrder, SG_TileId) VALUES(:Trn_TileId, :ChildTileOrder, :SG_TileId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Z27)
           ,new CursorDef("BC000Z28", "SAVEPOINT gxupdate;UPDATE Trn_TileChildTile SET ChildTileOrder=:ChildTileOrder  WHERE Trn_TileId = :Trn_TileId AND SG_TileId = :SG_TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z28)
           ,new CursorDef("BC000Z29", "SAVEPOINT gxupdate;DELETE FROM Trn_TileChildTile  WHERE Trn_TileId = :Trn_TileId AND SG_TileId = :SG_TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z29)
           ,new CursorDef("BC000Z30", "SELECT Trn_TileName AS SG_TileName, Trn_TileWidth AS SG_TileWidth, Trn_TileColor AS SG_TileColor, Trn_TileBGImageUrl AS SG_TileBGImageUrl FROM Trn_Tile WHERE Trn_TileId = :SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z31", "SELECT T1.Trn_TileId, T2.Trn_TileName AS SG_TileName, T2.Trn_TileWidth AS SG_TileWidth, T2.Trn_TileColor AS SG_TileColor, T2.Trn_TileBGImageUrl AS SG_TileBGImageUrl, T1.ChildTileOrder, T1.SG_TileId AS SG_TileId FROM (Trn_TileChildTile T1 INNER JOIN Trn_Tile T2 ON T2.Trn_TileId = T1.SG_TileId) WHERE T1.Trn_TileId = :Trn_TileId ORDER BY T1.Trn_TileId, T1.SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z31,11, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((Guid[]) buf[5])[0] = rslt.getGuid(6);
              ((Guid[]) buf[6])[0] = rslt.getGuid(7);
              ((Guid[]) buf[7])[0] = rslt.getGuid(8);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((Guid[]) buf[5])[0] = rslt.getGuid(6);
              ((Guid[]) buf[6])[0] = rslt.getGuid(7);
              ((Guid[]) buf[7])[0] = rslt.getGuid(8);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
              ((Guid[]) buf[8])[0] = rslt.getGuid(9);
              ((Guid[]) buf[9])[0] = rslt.getGuid(10);
              ((Guid[]) buf[10])[0] = rslt.getGuid(11);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(8));
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 15 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 16 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
              ((Guid[]) buf[8])[0] = rslt.getGuid(9);
              ((Guid[]) buf[9])[0] = rslt.getGuid(10);
              ((Guid[]) buf[10])[0] = rslt.getGuid(11);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(8));
              return;
           case 17 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 18 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 22 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 23 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((Guid[]) buf[6])[0] = rslt.getGuid(7);
              return;
           case 24 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 29 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((Guid[]) buf[6])[0] = rslt.getGuid(7);
              return;
     }
  }

}

}
