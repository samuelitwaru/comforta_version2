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
         ReadRow0Z81( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0Z81( ) ;
         standaloneModal( ) ;
         AddRow0Z81( ) ;
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
               Z407TileId = A407TileId;
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
         BeforeValidate0Z81( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Z81( ) ;
            }
            else
            {
               CheckExtendedTable0Z81( ) ;
               if ( AnyError == 0 )
               {
                  ZM0Z81( 13) ;
                  ZM0Z81( 14) ;
                  ZM0Z81( 15) ;
               }
               CloseExtendedTableCursors0Z81( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV59Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV60GXV1 = 1;
            while ( AV60GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV21TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV60GXV1));
               if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV46Insert_OrganisationId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "SG_ToPageId") == 0 )
               {
                  AV48Insert_SG_ToPageId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
               }
               AV60GXV1 = (int)(AV60GXV1+1);
            }
         }
      }

      protected void E110Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0Z81( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z400TileName = A400TileName;
            Z402TileBGColor = A402TileBGColor;
            Z403TileBGImageUrl = A403TileBGImageUrl;
            Z404TileTextColor = A404TileTextColor;
            Z405TileTextAlignment = A405TileTextAlignment;
            Z401TileIcon = A401TileIcon;
            Z406TileIconAlignment = A406TileIconAlignment;
            Z438TileIconColor = A438TileIconColor;
            Z11OrganisationId = A11OrganisationId;
            Z329SG_ToPageId = A329SG_ToPageId;
            Z58ProductServiceId = A58ProductServiceId;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z330SG_ToPageName = A330SG_ToPageName;
            Z29LocationId = A29LocationId;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z59ProductServiceName = A59ProductServiceName;
         }
         if ( GX_JID == -12 )
         {
            Z407TileId = A407TileId;
            Z400TileName = A400TileName;
            Z402TileBGColor = A402TileBGColor;
            Z403TileBGImageUrl = A403TileBGImageUrl;
            Z404TileTextColor = A404TileTextColor;
            Z405TileTextAlignment = A405TileTextAlignment;
            Z401TileIcon = A401TileIcon;
            Z406TileIconAlignment = A406TileIconAlignment;
            Z438TileIconColor = A438TileIconColor;
            Z436TileAction = A436TileAction;
            Z11OrganisationId = A11OrganisationId;
            Z329SG_ToPageId = A329SG_ToPageId;
            Z58ProductServiceId = A58ProductServiceId;
            Z330SG_ToPageName = A330SG_ToPageName;
            Z29LocationId = A29LocationId;
            Z59ProductServiceName = A59ProductServiceName;
            Z60ProductServiceDescription = A60ProductServiceDescription;
            Z61ProductServiceImage = A61ProductServiceImage;
            Z40000ProductServiceImage_GXI = A40000ProductServiceImage_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         AV59Pgmname = "Trn_Tile_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A58ProductServiceId) )
         {
            A58ProductServiceId = Guid.NewGuid( );
            n58ProductServiceId = false;
         }
         if ( IsIns( )  && (Guid.Empty==A407TileId) )
         {
            A407TileId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z81( )
      {
         /* Using cursor BC000Z7 */
         pr_default.execute(5, new Object[] {A407TileId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound81 = 1;
            A400TileName = BC000Z7_A400TileName[0];
            A402TileBGColor = BC000Z7_A402TileBGColor[0];
            n402TileBGColor = BC000Z7_n402TileBGColor[0];
            A403TileBGImageUrl = BC000Z7_A403TileBGImageUrl[0];
            n403TileBGImageUrl = BC000Z7_n403TileBGImageUrl[0];
            A404TileTextColor = BC000Z7_A404TileTextColor[0];
            A405TileTextAlignment = BC000Z7_A405TileTextAlignment[0];
            A401TileIcon = BC000Z7_A401TileIcon[0];
            n401TileIcon = BC000Z7_n401TileIcon[0];
            A406TileIconAlignment = BC000Z7_A406TileIconAlignment[0];
            A438TileIconColor = BC000Z7_A438TileIconColor[0];
            A59ProductServiceName = BC000Z7_A59ProductServiceName[0];
            A60ProductServiceDescription = BC000Z7_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC000Z7_A40000ProductServiceImage_GXI[0];
            A436TileAction = BC000Z7_A436TileAction[0];
            A330SG_ToPageName = BC000Z7_A330SG_ToPageName[0];
            A11OrganisationId = BC000Z7_A11OrganisationId[0];
            n11OrganisationId = BC000Z7_n11OrganisationId[0];
            A329SG_ToPageId = BC000Z7_A329SG_ToPageId[0];
            n329SG_ToPageId = BC000Z7_n329SG_ToPageId[0];
            A29LocationId = BC000Z7_A29LocationId[0];
            n29LocationId = BC000Z7_n29LocationId[0];
            A58ProductServiceId = BC000Z7_A58ProductServiceId[0];
            n58ProductServiceId = BC000Z7_n58ProductServiceId[0];
            A61ProductServiceImage = BC000Z7_A61ProductServiceImage[0];
            ZM0Z81( -12) ;
         }
         pr_default.close(5);
         OnLoadActions0Z81( ) ;
      }

      protected void OnLoadActions0Z81( )
      {
      }

      protected void CheckExtendedTable0Z81( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A403TileBGImageUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A403TileBGImageUrl)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Tile BGImage Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A405TileTextAlignment, "center") == 0 ) || ( StringUtil.StrCmp(A405TileTextAlignment, "left") == 0 ) || ( StringUtil.StrCmp(A405TileTextAlignment, "right") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Tile Text Alignment", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A406TileIconAlignment, "center") == 0 ) || ( StringUtil.StrCmp(A406TileIconAlignment, "left") == 0 ) || ( StringUtil.StrCmp(A406TileIconAlignment, "right") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Tile Icon Alignment", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000Z4 */
         pr_default.execute(2, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor BC000Z5 */
         pr_default.execute(3, new Object[] {n329SG_ToPageId, A329SG_ToPageId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A329SG_ToPageId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_To Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_TOPAGEID");
               AnyError = 1;
            }
         }
         A330SG_ToPageName = BC000Z5_A330SG_ToPageName[0];
         A29LocationId = BC000Z5_A29LocationId[0];
         n29LocationId = BC000Z5_n29LocationId[0];
         pr_default.close(3);
         /* Using cursor BC000Z6 */
         pr_default.execute(4, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         A59ProductServiceName = BC000Z6_A59ProductServiceName[0];
         A60ProductServiceDescription = BC000Z6_A60ProductServiceDescription[0];
         A40000ProductServiceImage_GXI = BC000Z6_A40000ProductServiceImage_GXI[0];
         A61ProductServiceImage = BC000Z6_A61ProductServiceImage[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0Z81( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Z81( )
      {
         /* Using cursor BC000Z8 */
         pr_default.execute(6, new Object[] {A407TileId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound81 = 1;
         }
         else
         {
            RcdFound81 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000Z3 */
         pr_default.execute(1, new Object[] {A407TileId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z81( 12) ;
            RcdFound81 = 1;
            A407TileId = BC000Z3_A407TileId[0];
            A400TileName = BC000Z3_A400TileName[0];
            A402TileBGColor = BC000Z3_A402TileBGColor[0];
            n402TileBGColor = BC000Z3_n402TileBGColor[0];
            A403TileBGImageUrl = BC000Z3_A403TileBGImageUrl[0];
            n403TileBGImageUrl = BC000Z3_n403TileBGImageUrl[0];
            A404TileTextColor = BC000Z3_A404TileTextColor[0];
            A405TileTextAlignment = BC000Z3_A405TileTextAlignment[0];
            A401TileIcon = BC000Z3_A401TileIcon[0];
            n401TileIcon = BC000Z3_n401TileIcon[0];
            A406TileIconAlignment = BC000Z3_A406TileIconAlignment[0];
            A438TileIconColor = BC000Z3_A438TileIconColor[0];
            A436TileAction = BC000Z3_A436TileAction[0];
            A11OrganisationId = BC000Z3_A11OrganisationId[0];
            n11OrganisationId = BC000Z3_n11OrganisationId[0];
            A329SG_ToPageId = BC000Z3_A329SG_ToPageId[0];
            n329SG_ToPageId = BC000Z3_n329SG_ToPageId[0];
            A58ProductServiceId = BC000Z3_A58ProductServiceId[0];
            n58ProductServiceId = BC000Z3_n58ProductServiceId[0];
            Z407TileId = A407TileId;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0Z81( ) ;
            if ( AnyError == 1 )
            {
               RcdFound81 = 0;
               InitializeNonKey0Z81( ) ;
            }
            Gx_mode = sMode81;
         }
         else
         {
            RcdFound81 = 0;
            InitializeNonKey0Z81( ) ;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode81;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Z81( ) ;
         if ( RcdFound81 == 0 )
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

      protected void CheckOptimisticConcurrency0Z81( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Z2 */
            pr_default.execute(0, new Object[] {A407TileId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z400TileName, BC000Z2_A400TileName[0]) != 0 ) || ( StringUtil.StrCmp(Z402TileBGColor, BC000Z2_A402TileBGColor[0]) != 0 ) || ( StringUtil.StrCmp(Z403TileBGImageUrl, BC000Z2_A403TileBGImageUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z404TileTextColor, BC000Z2_A404TileTextColor[0]) != 0 ) || ( StringUtil.StrCmp(Z405TileTextAlignment, BC000Z2_A405TileTextAlignment[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z401TileIcon, BC000Z2_A401TileIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z406TileIconAlignment, BC000Z2_A406TileIconAlignment[0]) != 0 ) || ( StringUtil.StrCmp(Z438TileIconColor, BC000Z2_A438TileIconColor[0]) != 0 ) || ( Z11OrganisationId != BC000Z2_A11OrganisationId[0] ) || ( Z329SG_ToPageId != BC000Z2_A329SG_ToPageId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z58ProductServiceId != BC000Z2_A58ProductServiceId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Tile"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z81( )
      {
         BeforeValidate0Z81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z81( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z81( 0) ;
            CheckOptimisticConcurrency0Z81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z9 */
                     pr_default.execute(7, new Object[] {A407TileId, A400TileName, n402TileBGColor, A402TileBGColor, n403TileBGImageUrl, A403TileBGImageUrl, A404TileTextColor, A405TileTextAlignment, n401TileIcon, A401TileIcon, A406TileIconAlignment, A438TileIconColor, A436TileAction, n11OrganisationId, A11OrganisationId, n329SG_ToPageId, A329SG_ToPageId, n58ProductServiceId, A58ProductServiceId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( (pr_default.getStatus(7) == 1) )
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
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
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
               Load0Z81( ) ;
            }
            EndLevel0Z81( ) ;
         }
         CloseExtendedTableCursors0Z81( ) ;
      }

      protected void Update0Z81( )
      {
         BeforeValidate0Z81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z81( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z10 */
                     pr_default.execute(8, new Object[] {A400TileName, n402TileBGColor, A402TileBGColor, n403TileBGImageUrl, A403TileBGImageUrl, A404TileTextColor, A405TileTextAlignment, n401TileIcon, A401TileIcon, A406TileIconAlignment, A438TileIconColor, A436TileAction, n11OrganisationId, A11OrganisationId, n329SG_ToPageId, A329SG_ToPageId, n58ProductServiceId, A58ProductServiceId, A407TileId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z81( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
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
            EndLevel0Z81( ) ;
         }
         CloseExtendedTableCursors0Z81( ) ;
      }

      protected void DeferredUpdate0Z81( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Z81( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z81( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z81( ) ;
            AfterConfirm0Z81( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z81( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Z11 */
                  pr_default.execute(9, new Object[] {A407TileId});
                  pr_default.close(9);
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
         sMode81 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Z81( ) ;
         Gx_mode = sMode81;
      }

      protected void OnDeleteControls0Z81( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000Z12 */
            pr_default.execute(10, new Object[] {n329SG_ToPageId, A329SG_ToPageId});
            A330SG_ToPageName = BC000Z12_A330SG_ToPageName[0];
            A29LocationId = BC000Z12_A29LocationId[0];
            n29LocationId = BC000Z12_n29LocationId[0];
            pr_default.close(10);
            /* Using cursor BC000Z13 */
            pr_default.execute(11, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            A59ProductServiceName = BC000Z13_A59ProductServiceName[0];
            A60ProductServiceDescription = BC000Z13_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC000Z13_A40000ProductServiceImage_GXI[0];
            A61ProductServiceImage = BC000Z13_A61ProductServiceImage[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000Z14 */
            pr_default.execute(12, new Object[] {A407TileId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Col", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0Z81( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Z81( ) ;
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

      public void ScanKeyStart0Z81( )
      {
         /* Scan By routine */
         /* Using cursor BC000Z15 */
         pr_default.execute(13, new Object[] {A407TileId});
         RcdFound81 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound81 = 1;
            A407TileId = BC000Z15_A407TileId[0];
            A400TileName = BC000Z15_A400TileName[0];
            A402TileBGColor = BC000Z15_A402TileBGColor[0];
            n402TileBGColor = BC000Z15_n402TileBGColor[0];
            A403TileBGImageUrl = BC000Z15_A403TileBGImageUrl[0];
            n403TileBGImageUrl = BC000Z15_n403TileBGImageUrl[0];
            A404TileTextColor = BC000Z15_A404TileTextColor[0];
            A405TileTextAlignment = BC000Z15_A405TileTextAlignment[0];
            A401TileIcon = BC000Z15_A401TileIcon[0];
            n401TileIcon = BC000Z15_n401TileIcon[0];
            A406TileIconAlignment = BC000Z15_A406TileIconAlignment[0];
            A438TileIconColor = BC000Z15_A438TileIconColor[0];
            A59ProductServiceName = BC000Z15_A59ProductServiceName[0];
            A60ProductServiceDescription = BC000Z15_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC000Z15_A40000ProductServiceImage_GXI[0];
            A436TileAction = BC000Z15_A436TileAction[0];
            A330SG_ToPageName = BC000Z15_A330SG_ToPageName[0];
            A11OrganisationId = BC000Z15_A11OrganisationId[0];
            n11OrganisationId = BC000Z15_n11OrganisationId[0];
            A329SG_ToPageId = BC000Z15_A329SG_ToPageId[0];
            n329SG_ToPageId = BC000Z15_n329SG_ToPageId[0];
            A29LocationId = BC000Z15_A29LocationId[0];
            n29LocationId = BC000Z15_n29LocationId[0];
            A58ProductServiceId = BC000Z15_A58ProductServiceId[0];
            n58ProductServiceId = BC000Z15_n58ProductServiceId[0];
            A61ProductServiceImage = BC000Z15_A61ProductServiceImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Z81( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound81 = 0;
         ScanKeyLoad0Z81( ) ;
      }

      protected void ScanKeyLoad0Z81( )
      {
         sMode81 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound81 = 1;
            A407TileId = BC000Z15_A407TileId[0];
            A400TileName = BC000Z15_A400TileName[0];
            A402TileBGColor = BC000Z15_A402TileBGColor[0];
            n402TileBGColor = BC000Z15_n402TileBGColor[0];
            A403TileBGImageUrl = BC000Z15_A403TileBGImageUrl[0];
            n403TileBGImageUrl = BC000Z15_n403TileBGImageUrl[0];
            A404TileTextColor = BC000Z15_A404TileTextColor[0];
            A405TileTextAlignment = BC000Z15_A405TileTextAlignment[0];
            A401TileIcon = BC000Z15_A401TileIcon[0];
            n401TileIcon = BC000Z15_n401TileIcon[0];
            A406TileIconAlignment = BC000Z15_A406TileIconAlignment[0];
            A438TileIconColor = BC000Z15_A438TileIconColor[0];
            A59ProductServiceName = BC000Z15_A59ProductServiceName[0];
            A60ProductServiceDescription = BC000Z15_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC000Z15_A40000ProductServiceImage_GXI[0];
            A436TileAction = BC000Z15_A436TileAction[0];
            A330SG_ToPageName = BC000Z15_A330SG_ToPageName[0];
            A11OrganisationId = BC000Z15_A11OrganisationId[0];
            n11OrganisationId = BC000Z15_n11OrganisationId[0];
            A329SG_ToPageId = BC000Z15_A329SG_ToPageId[0];
            n329SG_ToPageId = BC000Z15_n329SG_ToPageId[0];
            A29LocationId = BC000Z15_A29LocationId[0];
            n29LocationId = BC000Z15_n29LocationId[0];
            A58ProductServiceId = BC000Z15_A58ProductServiceId[0];
            n58ProductServiceId = BC000Z15_n58ProductServiceId[0];
            A61ProductServiceImage = BC000Z15_A61ProductServiceImage[0];
         }
         Gx_mode = sMode81;
      }

      protected void ScanKeyEnd0Z81( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0Z81( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z81( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z81( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z81( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z81( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z81( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z81( )
      {
      }

      protected void send_integrity_lvl_hashes0Z81( )
      {
      }

      protected void AddRow0Z81( )
      {
         VarsToRow81( bcTrn_Tile) ;
      }

      protected void ReadRow0Z81( )
      {
         RowToVars81( bcTrn_Tile, 1) ;
      }

      protected void InitializeNonKey0Z81( )
      {
         A400TileName = "";
         A402TileBGColor = "";
         n402TileBGColor = false;
         A403TileBGImageUrl = "";
         n403TileBGImageUrl = false;
         A404TileTextColor = "";
         A405TileTextAlignment = "";
         A401TileIcon = "";
         n401TileIcon = false;
         A406TileIconAlignment = "";
         A438TileIconColor = "";
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         A29LocationId = Guid.Empty;
         n29LocationId = false;
         A59ProductServiceName = "";
         A60ProductServiceDescription = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         A436TileAction = "";
         A329SG_ToPageId = Guid.Empty;
         n329SG_ToPageId = false;
         A330SG_ToPageName = "";
         A58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         Z400TileName = "";
         Z402TileBGColor = "";
         Z403TileBGImageUrl = "";
         Z404TileTextColor = "";
         Z405TileTextAlignment = "";
         Z401TileIcon = "";
         Z406TileIconAlignment = "";
         Z438TileIconColor = "";
         Z11OrganisationId = Guid.Empty;
         Z329SG_ToPageId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
      }

      protected void InitAll0Z81( )
      {
         A407TileId = Guid.NewGuid( );
         InitializeNonKey0Z81( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A58ProductServiceId = i58ProductServiceId;
         n58ProductServiceId = false;
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

      public void VarsToRow81( SdtTrn_Tile obj81 )
      {
         obj81.gxTpr_Mode = Gx_mode;
         obj81.gxTpr_Tilename = A400TileName;
         obj81.gxTpr_Tilebgcolor = A402TileBGColor;
         obj81.gxTpr_Tilebgimageurl = A403TileBGImageUrl;
         obj81.gxTpr_Tiletextcolor = A404TileTextColor;
         obj81.gxTpr_Tiletextalignment = A405TileTextAlignment;
         obj81.gxTpr_Tileicon = A401TileIcon;
         obj81.gxTpr_Tileiconalignment = A406TileIconAlignment;
         obj81.gxTpr_Tileiconcolor = A438TileIconColor;
         obj81.gxTpr_Organisationid = A11OrganisationId;
         obj81.gxTpr_Locationid = A29LocationId;
         obj81.gxTpr_Productservicename = A59ProductServiceName;
         obj81.gxTpr_Productservicedescription = A60ProductServiceDescription;
         obj81.gxTpr_Productserviceimage = A61ProductServiceImage;
         obj81.gxTpr_Productserviceimage_gxi = A40000ProductServiceImage_GXI;
         obj81.gxTpr_Tileaction = A436TileAction;
         obj81.gxTpr_Sg_topageid = A329SG_ToPageId;
         obj81.gxTpr_Sg_topagename = A330SG_ToPageName;
         obj81.gxTpr_Productserviceid = A58ProductServiceId;
         obj81.gxTpr_Tileid = A407TileId;
         obj81.gxTpr_Tileid_Z = Z407TileId;
         obj81.gxTpr_Tilename_Z = Z400TileName;
         obj81.gxTpr_Tilebgcolor_Z = Z402TileBGColor;
         obj81.gxTpr_Tilebgimageurl_Z = Z403TileBGImageUrl;
         obj81.gxTpr_Tiletextcolor_Z = Z404TileTextColor;
         obj81.gxTpr_Tiletextalignment_Z = Z405TileTextAlignment;
         obj81.gxTpr_Tileicon_Z = Z401TileIcon;
         obj81.gxTpr_Tileiconalignment_Z = Z406TileIconAlignment;
         obj81.gxTpr_Tileiconcolor_Z = Z438TileIconColor;
         obj81.gxTpr_Productserviceid_Z = Z58ProductServiceId;
         obj81.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj81.gxTpr_Locationid_Z = Z29LocationId;
         obj81.gxTpr_Productservicename_Z = Z59ProductServiceName;
         obj81.gxTpr_Sg_topageid_Z = Z329SG_ToPageId;
         obj81.gxTpr_Sg_topagename_Z = Z330SG_ToPageName;
         obj81.gxTpr_Productserviceimage_gxi_Z = Z40000ProductServiceImage_GXI;
         obj81.gxTpr_Tilebgcolor_N = (short)(Convert.ToInt16(n402TileBGColor));
         obj81.gxTpr_Tilebgimageurl_N = (short)(Convert.ToInt16(n403TileBGImageUrl));
         obj81.gxTpr_Tileicon_N = (short)(Convert.ToInt16(n401TileIcon));
         obj81.gxTpr_Productserviceid_N = (short)(Convert.ToInt16(n58ProductServiceId));
         obj81.gxTpr_Organisationid_N = (short)(Convert.ToInt16(n11OrganisationId));
         obj81.gxTpr_Locationid_N = (short)(Convert.ToInt16(n29LocationId));
         obj81.gxTpr_Sg_topageid_N = (short)(Convert.ToInt16(n329SG_ToPageId));
         obj81.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow81( SdtTrn_Tile obj81 )
      {
         obj81.gxTpr_Tileid = A407TileId;
         return  ;
      }

      public void RowToVars81( SdtTrn_Tile obj81 ,
                               int forceLoad )
      {
         Gx_mode = obj81.gxTpr_Mode;
         A400TileName = obj81.gxTpr_Tilename;
         A402TileBGColor = obj81.gxTpr_Tilebgcolor;
         n402TileBGColor = false;
         A403TileBGImageUrl = obj81.gxTpr_Tilebgimageurl;
         n403TileBGImageUrl = false;
         A404TileTextColor = obj81.gxTpr_Tiletextcolor;
         A405TileTextAlignment = obj81.gxTpr_Tiletextalignment;
         A401TileIcon = obj81.gxTpr_Tileicon;
         n401TileIcon = false;
         A406TileIconAlignment = obj81.gxTpr_Tileiconalignment;
         A438TileIconColor = obj81.gxTpr_Tileiconcolor;
         A11OrganisationId = obj81.gxTpr_Organisationid;
         n11OrganisationId = false;
         A29LocationId = obj81.gxTpr_Locationid;
         n29LocationId = false;
         A59ProductServiceName = obj81.gxTpr_Productservicename;
         A60ProductServiceDescription = obj81.gxTpr_Productservicedescription;
         A61ProductServiceImage = obj81.gxTpr_Productserviceimage;
         A40000ProductServiceImage_GXI = obj81.gxTpr_Productserviceimage_gxi;
         A436TileAction = obj81.gxTpr_Tileaction;
         A329SG_ToPageId = obj81.gxTpr_Sg_topageid;
         n329SG_ToPageId = false;
         A330SG_ToPageName = obj81.gxTpr_Sg_topagename;
         A58ProductServiceId = obj81.gxTpr_Productserviceid;
         n58ProductServiceId = false;
         A407TileId = obj81.gxTpr_Tileid;
         Z407TileId = obj81.gxTpr_Tileid_Z;
         Z400TileName = obj81.gxTpr_Tilename_Z;
         Z402TileBGColor = obj81.gxTpr_Tilebgcolor_Z;
         Z403TileBGImageUrl = obj81.gxTpr_Tilebgimageurl_Z;
         Z404TileTextColor = obj81.gxTpr_Tiletextcolor_Z;
         Z405TileTextAlignment = obj81.gxTpr_Tiletextalignment_Z;
         Z401TileIcon = obj81.gxTpr_Tileicon_Z;
         Z406TileIconAlignment = obj81.gxTpr_Tileiconalignment_Z;
         Z438TileIconColor = obj81.gxTpr_Tileiconcolor_Z;
         Z58ProductServiceId = obj81.gxTpr_Productserviceid_Z;
         Z11OrganisationId = obj81.gxTpr_Organisationid_Z;
         Z29LocationId = obj81.gxTpr_Locationid_Z;
         Z59ProductServiceName = obj81.gxTpr_Productservicename_Z;
         Z329SG_ToPageId = obj81.gxTpr_Sg_topageid_Z;
         Z330SG_ToPageName = obj81.gxTpr_Sg_topagename_Z;
         Z40000ProductServiceImage_GXI = obj81.gxTpr_Productserviceimage_gxi_Z;
         n402TileBGColor = (bool)(Convert.ToBoolean(obj81.gxTpr_Tilebgcolor_N));
         n403TileBGImageUrl = (bool)(Convert.ToBoolean(obj81.gxTpr_Tilebgimageurl_N));
         n401TileIcon = (bool)(Convert.ToBoolean(obj81.gxTpr_Tileicon_N));
         n58ProductServiceId = (bool)(Convert.ToBoolean(obj81.gxTpr_Productserviceid_N));
         n11OrganisationId = (bool)(Convert.ToBoolean(obj81.gxTpr_Organisationid_N));
         n29LocationId = (bool)(Convert.ToBoolean(obj81.gxTpr_Locationid_N));
         n329SG_ToPageId = (bool)(Convert.ToBoolean(obj81.gxTpr_Sg_topageid_N));
         Gx_mode = obj81.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A407TileId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0Z81( ) ;
         ScanKeyStart0Z81( ) ;
         if ( RcdFound81 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z407TileId = A407TileId;
         }
         ZM0Z81( -12) ;
         OnLoadActions0Z81( ) ;
         AddRow0Z81( ) ;
         ScanKeyEnd0Z81( ) ;
         if ( RcdFound81 == 0 )
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
         RowToVars81( bcTrn_Tile, 0) ;
         ScanKeyStart0Z81( ) ;
         if ( RcdFound81 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z407TileId = A407TileId;
         }
         ZM0Z81( -12) ;
         OnLoadActions0Z81( ) ;
         AddRow0Z81( ) ;
         ScanKeyEnd0Z81( ) ;
         if ( RcdFound81 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0Z81( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0Z81( ) ;
         }
         else
         {
            if ( RcdFound81 == 1 )
            {
               if ( A407TileId != Z407TileId )
               {
                  A407TileId = Z407TileId;
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
                  Update0Z81( ) ;
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
                  if ( A407TileId != Z407TileId )
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
                        Insert0Z81( ) ;
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
                        Insert0Z81( ) ;
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
         RowToVars81( bcTrn_Tile, 1) ;
         SaveImpl( ) ;
         VarsToRow81( bcTrn_Tile) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars81( bcTrn_Tile, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Z81( ) ;
         AfterTrn( ) ;
         VarsToRow81( bcTrn_Tile) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow81( bcTrn_Tile) ;
         }
         else
         {
            SdtTrn_Tile auxBC = new SdtTrn_Tile(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A407TileId);
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
         RowToVars81( bcTrn_Tile, 1) ;
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
         RowToVars81( bcTrn_Tile, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Z81( ) ;
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
               VarsToRow81( bcTrn_Tile) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow81( bcTrn_Tile) ;
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
         RowToVars81( bcTrn_Tile, 0) ;
         GetKey0Z81( ) ;
         if ( RcdFound81 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A407TileId != Z407TileId )
            {
               A407TileId = Z407TileId;
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
            if ( A407TileId != Z407TileId )
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
         VarsToRow81( bcTrn_Tile) ;
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
               VarsToRow81( bcTrn_Tile) ;
            }
            else
            {
               RowToVars81( bcTrn_Tile, 1) ;
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
         RowToVars81( bcTrn_Tile, 1) ;
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
         pr_default.close(10);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z407TileId = Guid.Empty;
         A407TileId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV59Pgmname = "";
         AV21TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV46Insert_OrganisationId = Guid.Empty;
         AV48Insert_SG_ToPageId = Guid.Empty;
         Z400TileName = "";
         A400TileName = "";
         Z402TileBGColor = "";
         A402TileBGColor = "";
         Z403TileBGImageUrl = "";
         A403TileBGImageUrl = "";
         Z404TileTextColor = "";
         A404TileTextColor = "";
         Z405TileTextAlignment = "";
         A405TileTextAlignment = "";
         Z401TileIcon = "";
         A401TileIcon = "";
         Z406TileIconAlignment = "";
         A406TileIconAlignment = "";
         Z438TileIconColor = "";
         A438TileIconColor = "";
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z329SG_ToPageId = Guid.Empty;
         A329SG_ToPageId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         Z330SG_ToPageName = "";
         A330SG_ToPageName = "";
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z59ProductServiceName = "";
         A59ProductServiceName = "";
         Z436TileAction = "";
         A436TileAction = "";
         Z60ProductServiceDescription = "";
         A60ProductServiceDescription = "";
         Z61ProductServiceImage = "";
         A61ProductServiceImage = "";
         Z40000ProductServiceImage_GXI = "";
         A40000ProductServiceImage_GXI = "";
         BC000Z7_A407TileId = new Guid[] {Guid.Empty} ;
         BC000Z7_A400TileName = new string[] {""} ;
         BC000Z7_A402TileBGColor = new string[] {""} ;
         BC000Z7_n402TileBGColor = new bool[] {false} ;
         BC000Z7_A403TileBGImageUrl = new string[] {""} ;
         BC000Z7_n403TileBGImageUrl = new bool[] {false} ;
         BC000Z7_A404TileTextColor = new string[] {""} ;
         BC000Z7_A405TileTextAlignment = new string[] {""} ;
         BC000Z7_A401TileIcon = new string[] {""} ;
         BC000Z7_n401TileIcon = new bool[] {false} ;
         BC000Z7_A406TileIconAlignment = new string[] {""} ;
         BC000Z7_A438TileIconColor = new string[] {""} ;
         BC000Z7_A59ProductServiceName = new string[] {""} ;
         BC000Z7_A60ProductServiceDescription = new string[] {""} ;
         BC000Z7_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC000Z7_A436TileAction = new string[] {""} ;
         BC000Z7_A330SG_ToPageName = new string[] {""} ;
         BC000Z7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z7_n11OrganisationId = new bool[] {false} ;
         BC000Z7_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         BC000Z7_n329SG_ToPageId = new bool[] {false} ;
         BC000Z7_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Z7_n29LocationId = new bool[] {false} ;
         BC000Z7_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000Z7_n58ProductServiceId = new bool[] {false} ;
         BC000Z7_A61ProductServiceImage = new string[] {""} ;
         BC000Z4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z4_n11OrganisationId = new bool[] {false} ;
         BC000Z5_A330SG_ToPageName = new string[] {""} ;
         BC000Z5_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Z5_n29LocationId = new bool[] {false} ;
         BC000Z6_A59ProductServiceName = new string[] {""} ;
         BC000Z6_A60ProductServiceDescription = new string[] {""} ;
         BC000Z6_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC000Z6_A61ProductServiceImage = new string[] {""} ;
         BC000Z8_A407TileId = new Guid[] {Guid.Empty} ;
         BC000Z3_A407TileId = new Guid[] {Guid.Empty} ;
         BC000Z3_A400TileName = new string[] {""} ;
         BC000Z3_A402TileBGColor = new string[] {""} ;
         BC000Z3_n402TileBGColor = new bool[] {false} ;
         BC000Z3_A403TileBGImageUrl = new string[] {""} ;
         BC000Z3_n403TileBGImageUrl = new bool[] {false} ;
         BC000Z3_A404TileTextColor = new string[] {""} ;
         BC000Z3_A405TileTextAlignment = new string[] {""} ;
         BC000Z3_A401TileIcon = new string[] {""} ;
         BC000Z3_n401TileIcon = new bool[] {false} ;
         BC000Z3_A406TileIconAlignment = new string[] {""} ;
         BC000Z3_A438TileIconColor = new string[] {""} ;
         BC000Z3_A436TileAction = new string[] {""} ;
         BC000Z3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z3_n11OrganisationId = new bool[] {false} ;
         BC000Z3_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         BC000Z3_n329SG_ToPageId = new bool[] {false} ;
         BC000Z3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000Z3_n58ProductServiceId = new bool[] {false} ;
         sMode81 = "";
         BC000Z2_A407TileId = new Guid[] {Guid.Empty} ;
         BC000Z2_A400TileName = new string[] {""} ;
         BC000Z2_A402TileBGColor = new string[] {""} ;
         BC000Z2_n402TileBGColor = new bool[] {false} ;
         BC000Z2_A403TileBGImageUrl = new string[] {""} ;
         BC000Z2_n403TileBGImageUrl = new bool[] {false} ;
         BC000Z2_A404TileTextColor = new string[] {""} ;
         BC000Z2_A405TileTextAlignment = new string[] {""} ;
         BC000Z2_A401TileIcon = new string[] {""} ;
         BC000Z2_n401TileIcon = new bool[] {false} ;
         BC000Z2_A406TileIconAlignment = new string[] {""} ;
         BC000Z2_A438TileIconColor = new string[] {""} ;
         BC000Z2_A436TileAction = new string[] {""} ;
         BC000Z2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z2_n11OrganisationId = new bool[] {false} ;
         BC000Z2_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         BC000Z2_n329SG_ToPageId = new bool[] {false} ;
         BC000Z2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000Z2_n58ProductServiceId = new bool[] {false} ;
         BC000Z12_A330SG_ToPageName = new string[] {""} ;
         BC000Z12_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Z12_n29LocationId = new bool[] {false} ;
         BC000Z13_A59ProductServiceName = new string[] {""} ;
         BC000Z13_A60ProductServiceDescription = new string[] {""} ;
         BC000Z13_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC000Z13_A61ProductServiceImage = new string[] {""} ;
         BC000Z14_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         BC000Z15_A407TileId = new Guid[] {Guid.Empty} ;
         BC000Z15_A400TileName = new string[] {""} ;
         BC000Z15_A402TileBGColor = new string[] {""} ;
         BC000Z15_n402TileBGColor = new bool[] {false} ;
         BC000Z15_A403TileBGImageUrl = new string[] {""} ;
         BC000Z15_n403TileBGImageUrl = new bool[] {false} ;
         BC000Z15_A404TileTextColor = new string[] {""} ;
         BC000Z15_A405TileTextAlignment = new string[] {""} ;
         BC000Z15_A401TileIcon = new string[] {""} ;
         BC000Z15_n401TileIcon = new bool[] {false} ;
         BC000Z15_A406TileIconAlignment = new string[] {""} ;
         BC000Z15_A438TileIconColor = new string[] {""} ;
         BC000Z15_A59ProductServiceName = new string[] {""} ;
         BC000Z15_A60ProductServiceDescription = new string[] {""} ;
         BC000Z15_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC000Z15_A436TileAction = new string[] {""} ;
         BC000Z15_A330SG_ToPageName = new string[] {""} ;
         BC000Z15_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z15_n11OrganisationId = new bool[] {false} ;
         BC000Z15_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         BC000Z15_n329SG_ToPageId = new bool[] {false} ;
         BC000Z15_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Z15_n29LocationId = new bool[] {false} ;
         BC000Z15_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000Z15_n58ProductServiceId = new bool[] {false} ;
         BC000Z15_A61ProductServiceImage = new string[] {""} ;
         i58ProductServiceId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_tile_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tile_bc__default(),
            new Object[][] {
                new Object[] {
               BC000Z2_A407TileId, BC000Z2_A400TileName, BC000Z2_A402TileBGColor, BC000Z2_n402TileBGColor, BC000Z2_A403TileBGImageUrl, BC000Z2_n403TileBGImageUrl, BC000Z2_A404TileTextColor, BC000Z2_A405TileTextAlignment, BC000Z2_A401TileIcon, BC000Z2_n401TileIcon,
               BC000Z2_A406TileIconAlignment, BC000Z2_A438TileIconColor, BC000Z2_A436TileAction, BC000Z2_A11OrganisationId, BC000Z2_n11OrganisationId, BC000Z2_A329SG_ToPageId, BC000Z2_n329SG_ToPageId, BC000Z2_A58ProductServiceId, BC000Z2_n58ProductServiceId
               }
               , new Object[] {
               BC000Z3_A407TileId, BC000Z3_A400TileName, BC000Z3_A402TileBGColor, BC000Z3_n402TileBGColor, BC000Z3_A403TileBGImageUrl, BC000Z3_n403TileBGImageUrl, BC000Z3_A404TileTextColor, BC000Z3_A405TileTextAlignment, BC000Z3_A401TileIcon, BC000Z3_n401TileIcon,
               BC000Z3_A406TileIconAlignment, BC000Z3_A438TileIconColor, BC000Z3_A436TileAction, BC000Z3_A11OrganisationId, BC000Z3_n11OrganisationId, BC000Z3_A329SG_ToPageId, BC000Z3_n329SG_ToPageId, BC000Z3_A58ProductServiceId, BC000Z3_n58ProductServiceId
               }
               , new Object[] {
               BC000Z4_A11OrganisationId
               }
               , new Object[] {
               BC000Z5_A330SG_ToPageName, BC000Z5_A29LocationId, BC000Z5_n29LocationId
               }
               , new Object[] {
               BC000Z6_A59ProductServiceName, BC000Z6_A60ProductServiceDescription, BC000Z6_A40000ProductServiceImage_GXI, BC000Z6_A61ProductServiceImage
               }
               , new Object[] {
               BC000Z7_A407TileId, BC000Z7_A400TileName, BC000Z7_A402TileBGColor, BC000Z7_n402TileBGColor, BC000Z7_A403TileBGImageUrl, BC000Z7_n403TileBGImageUrl, BC000Z7_A404TileTextColor, BC000Z7_A405TileTextAlignment, BC000Z7_A401TileIcon, BC000Z7_n401TileIcon,
               BC000Z7_A406TileIconAlignment, BC000Z7_A438TileIconColor, BC000Z7_A59ProductServiceName, BC000Z7_A60ProductServiceDescription, BC000Z7_A40000ProductServiceImage_GXI, BC000Z7_A436TileAction, BC000Z7_A330SG_ToPageName, BC000Z7_A11OrganisationId, BC000Z7_n11OrganisationId, BC000Z7_A329SG_ToPageId,
               BC000Z7_n329SG_ToPageId, BC000Z7_A29LocationId, BC000Z7_n29LocationId, BC000Z7_A58ProductServiceId, BC000Z7_n58ProductServiceId, BC000Z7_A61ProductServiceImage
               }
               , new Object[] {
               BC000Z8_A407TileId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Z12_A330SG_ToPageName, BC000Z12_A29LocationId, BC000Z12_n29LocationId
               }
               , new Object[] {
               BC000Z13_A59ProductServiceName, BC000Z13_A60ProductServiceDescription, BC000Z13_A40000ProductServiceImage_GXI, BC000Z13_A61ProductServiceImage
               }
               , new Object[] {
               BC000Z14_A328Trn_ColId
               }
               , new Object[] {
               BC000Z15_A407TileId, BC000Z15_A400TileName, BC000Z15_A402TileBGColor, BC000Z15_n402TileBGColor, BC000Z15_A403TileBGImageUrl, BC000Z15_n403TileBGImageUrl, BC000Z15_A404TileTextColor, BC000Z15_A405TileTextAlignment, BC000Z15_A401TileIcon, BC000Z15_n401TileIcon,
               BC000Z15_A406TileIconAlignment, BC000Z15_A438TileIconColor, BC000Z15_A59ProductServiceName, BC000Z15_A60ProductServiceDescription, BC000Z15_A40000ProductServiceImage_GXI, BC000Z15_A436TileAction, BC000Z15_A330SG_ToPageName, BC000Z15_A11OrganisationId, BC000Z15_n11OrganisationId, BC000Z15_A329SG_ToPageId,
               BC000Z15_n329SG_ToPageId, BC000Z15_A29LocationId, BC000Z15_n29LocationId, BC000Z15_A58ProductServiceId, BC000Z15_n58ProductServiceId, BC000Z15_A61ProductServiceImage
               }
            }
         );
         Z58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         A58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         i58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         Z407TileId = Guid.NewGuid( );
         A407TileId = Guid.NewGuid( );
         AV59Pgmname = "Trn_Tile_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120Z2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound81 ;
      private int trnEnded ;
      private int AV60GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV59Pgmname ;
      private string Z402TileBGColor ;
      private string A402TileBGColor ;
      private string Z404TileTextColor ;
      private string A404TileTextColor ;
      private string Z405TileTextAlignment ;
      private string A405TileTextAlignment ;
      private string Z401TileIcon ;
      private string A401TileIcon ;
      private string Z406TileIconAlignment ;
      private string A406TileIconAlignment ;
      private string Z438TileIconColor ;
      private string A438TileIconColor ;
      private string sMode81 ;
      private bool returnInSub ;
      private bool n58ProductServiceId ;
      private bool n402TileBGColor ;
      private bool n403TileBGImageUrl ;
      private bool n401TileIcon ;
      private bool n11OrganisationId ;
      private bool n329SG_ToPageId ;
      private bool n29LocationId ;
      private bool Gx_longc ;
      private string Z436TileAction ;
      private string A436TileAction ;
      private string Z60ProductServiceDescription ;
      private string A60ProductServiceDescription ;
      private string Z400TileName ;
      private string A400TileName ;
      private string Z403TileBGImageUrl ;
      private string A403TileBGImageUrl ;
      private string Z330SG_ToPageName ;
      private string A330SG_ToPageName ;
      private string Z59ProductServiceName ;
      private string A59ProductServiceName ;
      private string Z40000ProductServiceImage_GXI ;
      private string A40000ProductServiceImage_GXI ;
      private string Z61ProductServiceImage ;
      private string A61ProductServiceImage ;
      private Guid Z407TileId ;
      private Guid A407TileId ;
      private Guid AV46Insert_OrganisationId ;
      private Guid AV48Insert_SG_ToPageId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z329SG_ToPageId ;
      private Guid A329SG_ToPageId ;
      private Guid Z58ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid i58ProductServiceId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV21TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000Z7_A407TileId ;
      private string[] BC000Z7_A400TileName ;
      private string[] BC000Z7_A402TileBGColor ;
      private bool[] BC000Z7_n402TileBGColor ;
      private string[] BC000Z7_A403TileBGImageUrl ;
      private bool[] BC000Z7_n403TileBGImageUrl ;
      private string[] BC000Z7_A404TileTextColor ;
      private string[] BC000Z7_A405TileTextAlignment ;
      private string[] BC000Z7_A401TileIcon ;
      private bool[] BC000Z7_n401TileIcon ;
      private string[] BC000Z7_A406TileIconAlignment ;
      private string[] BC000Z7_A438TileIconColor ;
      private string[] BC000Z7_A59ProductServiceName ;
      private string[] BC000Z7_A60ProductServiceDescription ;
      private string[] BC000Z7_A40000ProductServiceImage_GXI ;
      private string[] BC000Z7_A436TileAction ;
      private string[] BC000Z7_A330SG_ToPageName ;
      private Guid[] BC000Z7_A11OrganisationId ;
      private bool[] BC000Z7_n11OrganisationId ;
      private Guid[] BC000Z7_A329SG_ToPageId ;
      private bool[] BC000Z7_n329SG_ToPageId ;
      private Guid[] BC000Z7_A29LocationId ;
      private bool[] BC000Z7_n29LocationId ;
      private Guid[] BC000Z7_A58ProductServiceId ;
      private bool[] BC000Z7_n58ProductServiceId ;
      private string[] BC000Z7_A61ProductServiceImage ;
      private Guid[] BC000Z4_A11OrganisationId ;
      private bool[] BC000Z4_n11OrganisationId ;
      private string[] BC000Z5_A330SG_ToPageName ;
      private Guid[] BC000Z5_A29LocationId ;
      private bool[] BC000Z5_n29LocationId ;
      private string[] BC000Z6_A59ProductServiceName ;
      private string[] BC000Z6_A60ProductServiceDescription ;
      private string[] BC000Z6_A40000ProductServiceImage_GXI ;
      private string[] BC000Z6_A61ProductServiceImage ;
      private Guid[] BC000Z8_A407TileId ;
      private Guid[] BC000Z3_A407TileId ;
      private string[] BC000Z3_A400TileName ;
      private string[] BC000Z3_A402TileBGColor ;
      private bool[] BC000Z3_n402TileBGColor ;
      private string[] BC000Z3_A403TileBGImageUrl ;
      private bool[] BC000Z3_n403TileBGImageUrl ;
      private string[] BC000Z3_A404TileTextColor ;
      private string[] BC000Z3_A405TileTextAlignment ;
      private string[] BC000Z3_A401TileIcon ;
      private bool[] BC000Z3_n401TileIcon ;
      private string[] BC000Z3_A406TileIconAlignment ;
      private string[] BC000Z3_A438TileIconColor ;
      private string[] BC000Z3_A436TileAction ;
      private Guid[] BC000Z3_A11OrganisationId ;
      private bool[] BC000Z3_n11OrganisationId ;
      private Guid[] BC000Z3_A329SG_ToPageId ;
      private bool[] BC000Z3_n329SG_ToPageId ;
      private Guid[] BC000Z3_A58ProductServiceId ;
      private bool[] BC000Z3_n58ProductServiceId ;
      private Guid[] BC000Z2_A407TileId ;
      private string[] BC000Z2_A400TileName ;
      private string[] BC000Z2_A402TileBGColor ;
      private bool[] BC000Z2_n402TileBGColor ;
      private string[] BC000Z2_A403TileBGImageUrl ;
      private bool[] BC000Z2_n403TileBGImageUrl ;
      private string[] BC000Z2_A404TileTextColor ;
      private string[] BC000Z2_A405TileTextAlignment ;
      private string[] BC000Z2_A401TileIcon ;
      private bool[] BC000Z2_n401TileIcon ;
      private string[] BC000Z2_A406TileIconAlignment ;
      private string[] BC000Z2_A438TileIconColor ;
      private string[] BC000Z2_A436TileAction ;
      private Guid[] BC000Z2_A11OrganisationId ;
      private bool[] BC000Z2_n11OrganisationId ;
      private Guid[] BC000Z2_A329SG_ToPageId ;
      private bool[] BC000Z2_n329SG_ToPageId ;
      private Guid[] BC000Z2_A58ProductServiceId ;
      private bool[] BC000Z2_n58ProductServiceId ;
      private string[] BC000Z12_A330SG_ToPageName ;
      private Guid[] BC000Z12_A29LocationId ;
      private bool[] BC000Z12_n29LocationId ;
      private string[] BC000Z13_A59ProductServiceName ;
      private string[] BC000Z13_A60ProductServiceDescription ;
      private string[] BC000Z13_A40000ProductServiceImage_GXI ;
      private string[] BC000Z13_A61ProductServiceImage ;
      private Guid[] BC000Z14_A328Trn_ColId ;
      private Guid[] BC000Z15_A407TileId ;
      private string[] BC000Z15_A400TileName ;
      private string[] BC000Z15_A402TileBGColor ;
      private bool[] BC000Z15_n402TileBGColor ;
      private string[] BC000Z15_A403TileBGImageUrl ;
      private bool[] BC000Z15_n403TileBGImageUrl ;
      private string[] BC000Z15_A404TileTextColor ;
      private string[] BC000Z15_A405TileTextAlignment ;
      private string[] BC000Z15_A401TileIcon ;
      private bool[] BC000Z15_n401TileIcon ;
      private string[] BC000Z15_A406TileIconAlignment ;
      private string[] BC000Z15_A438TileIconColor ;
      private string[] BC000Z15_A59ProductServiceName ;
      private string[] BC000Z15_A60ProductServiceDescription ;
      private string[] BC000Z15_A40000ProductServiceImage_GXI ;
      private string[] BC000Z15_A436TileAction ;
      private string[] BC000Z15_A330SG_ToPageName ;
      private Guid[] BC000Z15_A11OrganisationId ;
      private bool[] BC000Z15_n11OrganisationId ;
      private Guid[] BC000Z15_A329SG_ToPageId ;
      private bool[] BC000Z15_n329SG_ToPageId ;
      private Guid[] BC000Z15_A29LocationId ;
      private bool[] BC000Z15_n29LocationId ;
      private Guid[] BC000Z15_A58ProductServiceId ;
      private bool[] BC000Z15_n58ProductServiceId ;
      private string[] BC000Z15_A61ProductServiceImage ;
      private SdtTrn_Tile bcTrn_Tile ;
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000Z2;
        prmBC000Z2 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z3;
        prmBC000Z3 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z4;
        prmBC000Z4 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000Z5;
        prmBC000Z5 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000Z6;
        prmBC000Z6 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000Z7;
        prmBC000Z7 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z8;
        prmBC000Z8 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z9;
        prmBC000Z9 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TileName",GXType.VarChar,100,0) ,
        new ParDef("TileBGColor",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileBGImageUrl",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("TileTextColor",GXType.Char,20,0) ,
        new ParDef("TileTextAlignment",GXType.Char,20,0) ,
        new ParDef("TileIcon",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileIconAlignment",GXType.Char,20,0) ,
        new ParDef("TileIconColor",GXType.Char,20,0) ,
        new ParDef("TileAction",GXType.LongVarChar,2097152,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000Z10;
        prmBC000Z10 = new Object[] {
        new ParDef("TileName",GXType.VarChar,100,0) ,
        new ParDef("TileBGColor",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileBGImageUrl",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("TileTextColor",GXType.Char,20,0) ,
        new ParDef("TileTextAlignment",GXType.Char,20,0) ,
        new ParDef("TileIcon",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileIconAlignment",GXType.Char,20,0) ,
        new ParDef("TileIconColor",GXType.Char,20,0) ,
        new ParDef("TileAction",GXType.LongVarChar,2097152,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z11;
        prmBC000Z11 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z12;
        prmBC000Z12 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000Z13;
        prmBC000Z13 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000Z14;
        prmBC000Z14 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Z15;
        prmBC000Z15 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000Z2", "SELECT TileId, TileName, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIcon, TileIconAlignment, TileIconColor, TileAction, OrganisationId, SG_ToPageId, ProductServiceId FROM Trn_Tile WHERE TileId = :TileId  FOR UPDATE OF Trn_Tile",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z3", "SELECT TileId, TileName, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIcon, TileIconAlignment, TileIconColor, TileAction, OrganisationId, SG_ToPageId, ProductServiceId FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z5", "SELECT Trn_PageName AS SG_ToPageName, LocationId FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z6", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z7", "SELECT TM1.TileId, TM1.TileName, TM1.TileBGColor, TM1.TileBGImageUrl, TM1.TileTextColor, TM1.TileTextAlignment, TM1.TileIcon, TM1.TileIconAlignment, TM1.TileIconColor, T3.ProductServiceName, T3.ProductServiceDescription, T3.ProductServiceImage_GXI, TM1.TileAction, T2.Trn_PageName AS SG_ToPageName, TM1.OrganisationId, TM1.SG_ToPageId AS SG_ToPageId, T2.LocationId, TM1.ProductServiceId, T3.ProductServiceImage FROM ((Trn_Tile TM1 LEFT JOIN Trn_Page T2 ON T2.Trn_PageId = TM1.SG_ToPageId) LEFT JOIN Trn_ProductService T3 ON T3.ProductServiceId = TM1.ProductServiceId AND T3.LocationId = T2.LocationId AND T3.OrganisationId = TM1.OrganisationId) WHERE TM1.TileId = :TileId ORDER BY TM1.TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z8", "SELECT TileId FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z9", "SAVEPOINT gxupdate;INSERT INTO Trn_Tile(TileId, TileName, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIcon, TileIconAlignment, TileIconColor, TileAction, OrganisationId, SG_ToPageId, ProductServiceId) VALUES(:TileId, :TileName, :TileBGColor, :TileBGImageUrl, :TileTextColor, :TileTextAlignment, :TileIcon, :TileIconAlignment, :TileIconColor, :TileAction, :OrganisationId, :SG_ToPageId, :ProductServiceId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z9)
           ,new CursorDef("BC000Z10", "SAVEPOINT gxupdate;UPDATE Trn_Tile SET TileName=:TileName, TileBGColor=:TileBGColor, TileBGImageUrl=:TileBGImageUrl, TileTextColor=:TileTextColor, TileTextAlignment=:TileTextAlignment, TileIcon=:TileIcon, TileIconAlignment=:TileIconAlignment, TileIconColor=:TileIconColor, TileAction=:TileAction, OrganisationId=:OrganisationId, SG_ToPageId=:SG_ToPageId, ProductServiceId=:ProductServiceId  WHERE TileId = :TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z10)
           ,new CursorDef("BC000Z11", "SAVEPOINT gxupdate;DELETE FROM Trn_Tile  WHERE TileId = :TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z11)
           ,new CursorDef("BC000Z12", "SELECT Trn_PageName AS SG_ToPageName, LocationId FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z13", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Z14", "SELECT Trn_ColId FROM Trn_Col WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000Z15", "SELECT TM1.TileId, TM1.TileName, TM1.TileBGColor, TM1.TileBGImageUrl, TM1.TileTextColor, TM1.TileTextAlignment, TM1.TileIcon, TM1.TileIconAlignment, TM1.TileIconColor, T3.ProductServiceName, T3.ProductServiceDescription, T3.ProductServiceImage_GXI, TM1.TileAction, T2.Trn_PageName AS SG_ToPageName, TM1.OrganisationId, TM1.SG_ToPageId AS SG_ToPageId, T2.LocationId, TM1.ProductServiceId, T3.ProductServiceImage FROM ((Trn_Tile TM1 LEFT JOIN Trn_Page T2 ON T2.Trn_PageId = TM1.SG_ToPageId) LEFT JOIN Trn_ProductService T3 ON T3.ProductServiceId = TM1.ProductServiceId AND T3.LocationId = T2.LocationId AND T3.OrganisationId = TM1.OrganisationId) WHERE TM1.TileId = :TileId ORDER BY TM1.TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 20);
              ((string[]) buf[7])[0] = rslt.getString(6, 20);
              ((string[]) buf[8])[0] = rslt.getString(7, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(10);
              ((Guid[]) buf[13])[0] = rslt.getGuid(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((Guid[]) buf[15])[0] = rslt.getGuid(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((Guid[]) buf[17])[0] = rslt.getGuid(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 20);
              ((string[]) buf[7])[0] = rslt.getString(6, 20);
              ((string[]) buf[8])[0] = rslt.getString(7, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(10);
              ((Guid[]) buf[13])[0] = rslt.getGuid(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((Guid[]) buf[15])[0] = rslt.getGuid(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((Guid[]) buf[17])[0] = rslt.getGuid(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 20);
              ((string[]) buf[7])[0] = rslt.getString(6, 20);
              ((string[]) buf[8])[0] = rslt.getString(7, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              ((string[]) buf[12])[0] = rslt.getVarchar(10);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(11);
              ((string[]) buf[14])[0] = rslt.getMultimediaUri(12);
              ((string[]) buf[15])[0] = rslt.getLongVarchar(13);
              ((string[]) buf[16])[0] = rslt.getVarchar(14);
              ((Guid[]) buf[17])[0] = rslt.getGuid(15);
              ((bool[]) buf[18])[0] = rslt.wasNull(15);
              ((Guid[]) buf[19])[0] = rslt.getGuid(16);
              ((bool[]) buf[20])[0] = rslt.wasNull(16);
              ((Guid[]) buf[21])[0] = rslt.getGuid(17);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((Guid[]) buf[23])[0] = rslt.getGuid(18);
              ((bool[]) buf[24])[0] = rslt.wasNull(18);
              ((string[]) buf[25])[0] = rslt.getMultimediaFile(19, rslt.getVarchar(12));
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 20);
              ((string[]) buf[7])[0] = rslt.getString(6, 20);
              ((string[]) buf[8])[0] = rslt.getString(7, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              ((string[]) buf[12])[0] = rslt.getVarchar(10);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(11);
              ((string[]) buf[14])[0] = rslt.getMultimediaUri(12);
              ((string[]) buf[15])[0] = rslt.getLongVarchar(13);
              ((string[]) buf[16])[0] = rslt.getVarchar(14);
              ((Guid[]) buf[17])[0] = rslt.getGuid(15);
              ((bool[]) buf[18])[0] = rslt.wasNull(15);
              ((Guid[]) buf[19])[0] = rslt.getGuid(16);
              ((bool[]) buf[20])[0] = rslt.wasNull(16);
              ((Guid[]) buf[21])[0] = rslt.getGuid(17);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((Guid[]) buf[23])[0] = rslt.getGuid(18);
              ((bool[]) buf[24])[0] = rslt.wasNull(18);
              ((string[]) buf[25])[0] = rslt.getMultimediaFile(19, rslt.getVarchar(12));
              return;
     }
  }

}

}
