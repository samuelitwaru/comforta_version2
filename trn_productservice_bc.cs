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
   public class trn_productservice_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_productservice_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_productservice_bc( IGxContext context )
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
         ReadRow0813( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0813( ) ;
         standaloneModal( ) ;
         AddRow0813( ) ;
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
            E11082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z58ProductServiceId = A58ProductServiceId;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate0813( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0813( ) ;
            }
            else
            {
               CheckExtendedTable0813( ) ;
               if ( AnyError == 0 )
               {
                  ZM0813( 11) ;
                  ZM0813( 12) ;
               }
               CloseExtendedTableCursors0813( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12082( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV16TrnContext.FromXml(AV18WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV16TrnContext.gxTpr_Transactionname, AV21Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV22GXV1 = 1;
            while ( AV22GXV1 <= AV16TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV16TrnContext.gxTpr_Attributes.Item(AV22GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "SupplierGenId") == 0 )
               {
                  AV10Insert_SupplierGenId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "SupplierAgbId") == 0 )
               {
                  AV9Insert_SupplierAgbId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               AV22GXV1 = (int)(AV22GXV1+1);
            }
         }
      }

      protected void E11082( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM0813( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z29LocationId = A29LocationId;
            Z59ProductServiceName = A59ProductServiceName;
            Z301ProductServiceTileName = A301ProductServiceTileName;
            Z60ProductServiceDescription = A60ProductServiceDescription;
            Z42SupplierGenId = A42SupplierGenId;
            Z49SupplierAgbId = A49SupplierAgbId;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z51SupplierAgbName = A51SupplierAgbName;
         }
         if ( GX_JID == -10 )
         {
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z59ProductServiceName = A59ProductServiceName;
            Z301ProductServiceTileName = A301ProductServiceTileName;
            Z60ProductServiceDescription = A60ProductServiceDescription;
            Z61ProductServiceImage = A61ProductServiceImage;
            Z40000ProductServiceImage_GXI = A40000ProductServiceImage_GXI;
            Z42SupplierGenId = A42SupplierGenId;
            Z49SupplierAgbId = A49SupplierAgbId;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z51SupplierAgbName = A51SupplierAgbName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV21Pgmname = "Trn_ProductService_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A58ProductServiceId) )
         {
            A58ProductServiceId = Guid.NewGuid( );
            n58ProductServiceId = false;
         }
         GXt_guid1 = A29LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         A29LocationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0813( )
      {
         /* Using cursor BC00086 */
         pr_default.execute(4, new Object[] {n58ProductServiceId, A58ProductServiceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound13 = 1;
            A29LocationId = BC00086_A29LocationId[0];
            A59ProductServiceName = BC00086_A59ProductServiceName[0];
            A301ProductServiceTileName = BC00086_A301ProductServiceTileName[0];
            A60ProductServiceDescription = BC00086_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC00086_A40000ProductServiceImage_GXI[0];
            A44SupplierGenCompanyName = BC00086_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = BC00086_A51SupplierAgbName[0];
            A42SupplierGenId = BC00086_A42SupplierGenId[0];
            n42SupplierGenId = BC00086_n42SupplierGenId[0];
            A49SupplierAgbId = BC00086_A49SupplierAgbId[0];
            n49SupplierAgbId = BC00086_n49SupplierAgbId[0];
            A61ProductServiceImage = BC00086_A61ProductServiceImage[0];
            ZM0813( -10) ;
         }
         pr_default.close(4);
         OnLoadActions0813( ) ;
      }

      protected void OnLoadActions0813( )
      {
      }

      protected void CheckExtendedTable0813( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A59ProductServiceName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Product Service Name", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00084 */
         pr_default.execute(2, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (Guid.Empty==A42SupplierGenId) ) )
            {
               GX_msglist.addItem("No matching 'Trn_SupplierGen'.", "ForeignKeyNotFound", 1, "SUPPLIERGENID");
               AnyError = 1;
            }
         }
         A44SupplierGenCompanyName = BC00084_A44SupplierGenCompanyName[0];
         pr_default.close(2);
         /* Using cursor BC00085 */
         pr_default.execute(3, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A49SupplierAgbId) ) )
            {
               GX_msglist.addItem("No matching 'Trn_SupplierAGB'.", "ForeignKeyNotFound", 1, "SUPPLIERAGBID");
               AnyError = 1;
            }
         }
         A51SupplierAgbName = BC00085_A51SupplierAgbName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0813( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0813( )
      {
         /* Using cursor BC00087 */
         pr_default.execute(5, new Object[] {n58ProductServiceId, A58ProductServiceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00083 */
         pr_default.execute(1, new Object[] {n58ProductServiceId, A58ProductServiceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0813( 10) ;
            RcdFound13 = 1;
            A58ProductServiceId = BC00083_A58ProductServiceId[0];
            n58ProductServiceId = BC00083_n58ProductServiceId[0];
            A29LocationId = BC00083_A29LocationId[0];
            A59ProductServiceName = BC00083_A59ProductServiceName[0];
            A301ProductServiceTileName = BC00083_A301ProductServiceTileName[0];
            A60ProductServiceDescription = BC00083_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC00083_A40000ProductServiceImage_GXI[0];
            A42SupplierGenId = BC00083_A42SupplierGenId[0];
            n42SupplierGenId = BC00083_n42SupplierGenId[0];
            A49SupplierAgbId = BC00083_A49SupplierAgbId[0];
            n49SupplierAgbId = BC00083_n49SupplierAgbId[0];
            A61ProductServiceImage = BC00083_A61ProductServiceImage[0];
            Z58ProductServiceId = A58ProductServiceId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0813( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0813( ) ;
            }
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0813( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode13;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0813( ) ;
         if ( RcdFound13 == 0 )
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
         CONFIRM_080( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0813( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00082 */
            pr_default.execute(0, new Object[] {n58ProductServiceId, A58ProductServiceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ProductService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z29LocationId != BC00082_A29LocationId[0] ) || ( StringUtil.StrCmp(Z59ProductServiceName, BC00082_A59ProductServiceName[0]) != 0 ) || ( StringUtil.StrCmp(Z301ProductServiceTileName, BC00082_A301ProductServiceTileName[0]) != 0 ) || ( StringUtil.StrCmp(Z60ProductServiceDescription, BC00082_A60ProductServiceDescription[0]) != 0 ) || ( Z42SupplierGenId != BC00082_A42SupplierGenId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z49SupplierAgbId != BC00082_A49SupplierAgbId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ProductService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0813( )
      {
         BeforeValidate0813( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0813( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0813( 0) ;
            CheckOptimisticConcurrency0813( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0813( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0813( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00088 */
                     pr_default.execute(6, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A59ProductServiceName, A301ProductServiceTileName, A60ProductServiceDescription, A61ProductServiceImage, A40000ProductServiceImage_GXI, n42SupplierGenId, A42SupplierGenId, n49SupplierAgbId, A49SupplierAgbId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
                     if ( (pr_default.getStatus(6) == 1) )
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
               Load0813( ) ;
            }
            EndLevel0813( ) ;
         }
         CloseExtendedTableCursors0813( ) ;
      }

      protected void Update0813( )
      {
         BeforeValidate0813( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0813( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0813( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0813( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0813( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00089 */
                     pr_default.execute(7, new Object[] {A29LocationId, A59ProductServiceName, A301ProductServiceTileName, A60ProductServiceDescription, n42SupplierGenId, A42SupplierGenId, n49SupplierAgbId, A49SupplierAgbId, n58ProductServiceId, A58ProductServiceId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ProductService"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0813( ) ;
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
            EndLevel0813( ) ;
         }
         CloseExtendedTableCursors0813( ) ;
      }

      protected void DeferredUpdate0813( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000810 */
            pr_default.execute(8, new Object[] {A61ProductServiceImage, A40000ProductServiceImage_GXI, n58ProductServiceId, A58ProductServiceId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0813( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0813( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0813( ) ;
            AfterConfirm0813( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0813( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000811 */
                  pr_default.execute(9, new Object[] {n58ProductServiceId, A58ProductServiceId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0813( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0813( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000812 */
            pr_default.execute(10, new Object[] {n42SupplierGenId, A42SupplierGenId});
            A44SupplierGenCompanyName = BC000812_A44SupplierGenCompanyName[0];
            pr_default.close(10);
            /* Using cursor BC000813 */
            pr_default.execute(11, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
            A51SupplierAgbName = BC000813_A51SupplierAgbName[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000814 */
            pr_default.execute(12, new Object[] {n58ProductServiceId, A58ProductServiceId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Trn_Col"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0813( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0813( ) ;
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

      public void ScanKeyStart0813( )
      {
         /* Scan By routine */
         /* Using cursor BC000815 */
         pr_default.execute(13, new Object[] {n58ProductServiceId, A58ProductServiceId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound13 = 1;
            A58ProductServiceId = BC000815_A58ProductServiceId[0];
            n58ProductServiceId = BC000815_n58ProductServiceId[0];
            A29LocationId = BC000815_A29LocationId[0];
            A59ProductServiceName = BC000815_A59ProductServiceName[0];
            A301ProductServiceTileName = BC000815_A301ProductServiceTileName[0];
            A60ProductServiceDescription = BC000815_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC000815_A40000ProductServiceImage_GXI[0];
            A44SupplierGenCompanyName = BC000815_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = BC000815_A51SupplierAgbName[0];
            A42SupplierGenId = BC000815_A42SupplierGenId[0];
            n42SupplierGenId = BC000815_n42SupplierGenId[0];
            A49SupplierAgbId = BC000815_A49SupplierAgbId[0];
            n49SupplierAgbId = BC000815_n49SupplierAgbId[0];
            A61ProductServiceImage = BC000815_A61ProductServiceImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0813( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound13 = 0;
         ScanKeyLoad0813( ) ;
      }

      protected void ScanKeyLoad0813( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound13 = 1;
            A58ProductServiceId = BC000815_A58ProductServiceId[0];
            n58ProductServiceId = BC000815_n58ProductServiceId[0];
            A29LocationId = BC000815_A29LocationId[0];
            A59ProductServiceName = BC000815_A59ProductServiceName[0];
            A301ProductServiceTileName = BC000815_A301ProductServiceTileName[0];
            A60ProductServiceDescription = BC000815_A60ProductServiceDescription[0];
            A40000ProductServiceImage_GXI = BC000815_A40000ProductServiceImage_GXI[0];
            A44SupplierGenCompanyName = BC000815_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = BC000815_A51SupplierAgbName[0];
            A42SupplierGenId = BC000815_A42SupplierGenId[0];
            n42SupplierGenId = BC000815_n42SupplierGenId[0];
            A49SupplierAgbId = BC000815_A49SupplierAgbId[0];
            n49SupplierAgbId = BC000815_n49SupplierAgbId[0];
            A61ProductServiceImage = BC000815_A61ProductServiceImage[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0813( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0813( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0813( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0813( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0813( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0813( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0813( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0813( )
      {
      }

      protected void send_integrity_lvl_hashes0813( )
      {
      }

      protected void AddRow0813( )
      {
         VarsToRow13( bcTrn_ProductService) ;
      }

      protected void ReadRow0813( )
      {
         RowToVars13( bcTrn_ProductService, 1) ;
      }

      protected void InitializeNonKey0813( )
      {
         A29LocationId = Guid.Empty;
         A59ProductServiceName = "";
         A301ProductServiceTileName = "";
         A60ProductServiceDescription = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         A42SupplierGenId = Guid.Empty;
         n42SupplierGenId = false;
         A44SupplierGenCompanyName = "";
         A49SupplierAgbId = Guid.Empty;
         n49SupplierAgbId = false;
         A51SupplierAgbName = "";
         Z29LocationId = Guid.Empty;
         Z59ProductServiceName = "";
         Z301ProductServiceTileName = "";
         Z60ProductServiceDescription = "";
         Z42SupplierGenId = Guid.Empty;
         Z49SupplierAgbId = Guid.Empty;
      }

      protected void InitAll0813( )
      {
         A58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         InitializeNonKey0813( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A29LocationId = i29LocationId;
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

      public void VarsToRow13( SdtTrn_ProductService obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Locationid = A29LocationId;
         obj13.gxTpr_Productservicename = A59ProductServiceName;
         obj13.gxTpr_Productservicetilename = A301ProductServiceTileName;
         obj13.gxTpr_Productservicedescription = A60ProductServiceDescription;
         obj13.gxTpr_Productserviceimage = A61ProductServiceImage;
         obj13.gxTpr_Productserviceimage_gxi = A40000ProductServiceImage_GXI;
         obj13.gxTpr_Suppliergenid = A42SupplierGenId;
         obj13.gxTpr_Suppliergencompanyname = A44SupplierGenCompanyName;
         obj13.gxTpr_Supplieragbid = A49SupplierAgbId;
         obj13.gxTpr_Supplieragbname = A51SupplierAgbName;
         obj13.gxTpr_Productserviceid = A58ProductServiceId;
         obj13.gxTpr_Productserviceid_Z = Z58ProductServiceId;
         obj13.gxTpr_Productservicename_Z = Z59ProductServiceName;
         obj13.gxTpr_Productservicetilename_Z = Z301ProductServiceTileName;
         obj13.gxTpr_Productservicedescription_Z = Z60ProductServiceDescription;
         obj13.gxTpr_Suppliergenid_Z = Z42SupplierGenId;
         obj13.gxTpr_Suppliergencompanyname_Z = Z44SupplierGenCompanyName;
         obj13.gxTpr_Supplieragbid_Z = Z49SupplierAgbId;
         obj13.gxTpr_Supplieragbname_Z = Z51SupplierAgbName;
         obj13.gxTpr_Locationid_Z = Z29LocationId;
         obj13.gxTpr_Productserviceimage_gxi_Z = Z40000ProductServiceImage_GXI;
         obj13.gxTpr_Productserviceid_N = (short)(Convert.ToInt16(n58ProductServiceId));
         obj13.gxTpr_Suppliergenid_N = (short)(Convert.ToInt16(n42SupplierGenId));
         obj13.gxTpr_Supplieragbid_N = (short)(Convert.ToInt16(n49SupplierAgbId));
         obj13.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow13( SdtTrn_ProductService obj13 )
      {
         obj13.gxTpr_Productserviceid = A58ProductServiceId;
         return  ;
      }

      public void RowToVars13( SdtTrn_ProductService obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A29LocationId = obj13.gxTpr_Locationid;
         A59ProductServiceName = obj13.gxTpr_Productservicename;
         A301ProductServiceTileName = obj13.gxTpr_Productservicetilename;
         A60ProductServiceDescription = obj13.gxTpr_Productservicedescription;
         A61ProductServiceImage = obj13.gxTpr_Productserviceimage;
         A40000ProductServiceImage_GXI = obj13.gxTpr_Productserviceimage_gxi;
         A42SupplierGenId = obj13.gxTpr_Suppliergenid;
         n42SupplierGenId = false;
         A44SupplierGenCompanyName = obj13.gxTpr_Suppliergencompanyname;
         A49SupplierAgbId = obj13.gxTpr_Supplieragbid;
         n49SupplierAgbId = false;
         A51SupplierAgbName = obj13.gxTpr_Supplieragbname;
         A58ProductServiceId = obj13.gxTpr_Productserviceid;
         n58ProductServiceId = false;
         Z58ProductServiceId = obj13.gxTpr_Productserviceid_Z;
         Z59ProductServiceName = obj13.gxTpr_Productservicename_Z;
         Z301ProductServiceTileName = obj13.gxTpr_Productservicetilename_Z;
         Z60ProductServiceDescription = obj13.gxTpr_Productservicedescription_Z;
         Z42SupplierGenId = obj13.gxTpr_Suppliergenid_Z;
         Z44SupplierGenCompanyName = obj13.gxTpr_Suppliergencompanyname_Z;
         Z49SupplierAgbId = obj13.gxTpr_Supplieragbid_Z;
         Z51SupplierAgbName = obj13.gxTpr_Supplieragbname_Z;
         Z29LocationId = obj13.gxTpr_Locationid_Z;
         Z40000ProductServiceImage_GXI = obj13.gxTpr_Productserviceimage_gxi_Z;
         n58ProductServiceId = (bool)(Convert.ToBoolean(obj13.gxTpr_Productserviceid_N));
         n42SupplierGenId = (bool)(Convert.ToBoolean(obj13.gxTpr_Suppliergenid_N));
         n49SupplierAgbId = (bool)(Convert.ToBoolean(obj13.gxTpr_Supplieragbid_N));
         Gx_mode = obj13.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A58ProductServiceId = (Guid)getParm(obj,0);
         n58ProductServiceId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0813( ) ;
         ScanKeyStart0813( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z58ProductServiceId = A58ProductServiceId;
         }
         ZM0813( -10) ;
         OnLoadActions0813( ) ;
         AddRow0813( ) ;
         ScanKeyEnd0813( ) ;
         if ( RcdFound13 == 0 )
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
         RowToVars13( bcTrn_ProductService, 0) ;
         ScanKeyStart0813( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z58ProductServiceId = A58ProductServiceId;
         }
         ZM0813( -10) ;
         OnLoadActions0813( ) ;
         AddRow0813( ) ;
         ScanKeyEnd0813( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0813( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0813( ) ;
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A58ProductServiceId != Z58ProductServiceId )
               {
                  A58ProductServiceId = Z58ProductServiceId;
                  n58ProductServiceId = false;
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
                  Update0813( ) ;
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
                  if ( A58ProductServiceId != Z58ProductServiceId )
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
                        Insert0813( ) ;
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
                        Insert0813( ) ;
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
         RowToVars13( bcTrn_ProductService, 1) ;
         SaveImpl( ) ;
         VarsToRow13( bcTrn_ProductService) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcTrn_ProductService, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0813( ) ;
         AfterTrn( ) ;
         VarsToRow13( bcTrn_ProductService) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow13( bcTrn_ProductService) ;
         }
         else
         {
            SdtTrn_ProductService auxBC = new SdtTrn_ProductService(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A58ProductServiceId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_ProductService);
               auxBC.Save();
               bcTrn_ProductService.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars13( bcTrn_ProductService, 1) ;
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
         RowToVars13( bcTrn_ProductService, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0813( ) ;
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
               VarsToRow13( bcTrn_ProductService) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow13( bcTrn_ProductService) ;
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
         RowToVars13( bcTrn_ProductService, 0) ;
         GetKey0813( ) ;
         if ( RcdFound13 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A58ProductServiceId != Z58ProductServiceId )
            {
               A58ProductServiceId = Z58ProductServiceId;
               n58ProductServiceId = false;
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
            if ( A58ProductServiceId != Z58ProductServiceId )
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
         context.RollbackDataStores("trn_productservice_bc",pr_default);
         VarsToRow13( bcTrn_ProductService) ;
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
         Gx_mode = bcTrn_ProductService.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_ProductService.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_ProductService )
         {
            bcTrn_ProductService = (SdtTrn_ProductService)(sdt);
            if ( StringUtil.StrCmp(bcTrn_ProductService.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ProductService.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow13( bcTrn_ProductService) ;
            }
            else
            {
               RowToVars13( bcTrn_ProductService, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_ProductService.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ProductService.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars13( bcTrn_ProductService, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_ProductService Trn_ProductService_BC
      {
         get {
            return bcTrn_ProductService ;
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
            return "trn_productservice_Execute" ;
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
         Z58ProductServiceId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV18WebSession = context.GetSession();
         AV21Pgmname = "";
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV10Insert_SupplierGenId = Guid.Empty;
         AV9Insert_SupplierAgbId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z59ProductServiceName = "";
         A59ProductServiceName = "";
         Z301ProductServiceTileName = "";
         A301ProductServiceTileName = "";
         Z60ProductServiceDescription = "";
         A60ProductServiceDescription = "";
         Z42SupplierGenId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         Z49SupplierAgbId = Guid.Empty;
         A49SupplierAgbId = Guid.Empty;
         Z44SupplierGenCompanyName = "";
         A44SupplierGenCompanyName = "";
         Z51SupplierAgbName = "";
         A51SupplierAgbName = "";
         Z61ProductServiceImage = "";
         A61ProductServiceImage = "";
         Z40000ProductServiceImage_GXI = "";
         A40000ProductServiceImage_GXI = "";
         GXt_guid1 = Guid.Empty;
         BC00086_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00086_n58ProductServiceId = new bool[] {false} ;
         BC00086_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00086_A59ProductServiceName = new string[] {""} ;
         BC00086_A301ProductServiceTileName = new string[] {""} ;
         BC00086_A60ProductServiceDescription = new string[] {""} ;
         BC00086_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC00086_A44SupplierGenCompanyName = new string[] {""} ;
         BC00086_A51SupplierAgbName = new string[] {""} ;
         BC00086_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00086_n42SupplierGenId = new bool[] {false} ;
         BC00086_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00086_n49SupplierAgbId = new bool[] {false} ;
         BC00086_A61ProductServiceImage = new string[] {""} ;
         BC00084_A44SupplierGenCompanyName = new string[] {""} ;
         BC00085_A51SupplierAgbName = new string[] {""} ;
         BC00087_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00087_n58ProductServiceId = new bool[] {false} ;
         BC00083_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00083_n58ProductServiceId = new bool[] {false} ;
         BC00083_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00083_A59ProductServiceName = new string[] {""} ;
         BC00083_A301ProductServiceTileName = new string[] {""} ;
         BC00083_A60ProductServiceDescription = new string[] {""} ;
         BC00083_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC00083_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00083_n42SupplierGenId = new bool[] {false} ;
         BC00083_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00083_n49SupplierAgbId = new bool[] {false} ;
         BC00083_A61ProductServiceImage = new string[] {""} ;
         sMode13 = "";
         BC00082_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00082_n58ProductServiceId = new bool[] {false} ;
         BC00082_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00082_A59ProductServiceName = new string[] {""} ;
         BC00082_A301ProductServiceTileName = new string[] {""} ;
         BC00082_A60ProductServiceDescription = new string[] {""} ;
         BC00082_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC00082_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00082_n42SupplierGenId = new bool[] {false} ;
         BC00082_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00082_n49SupplierAgbId = new bool[] {false} ;
         BC00082_A61ProductServiceImage = new string[] {""} ;
         BC000812_A44SupplierGenCompanyName = new string[] {""} ;
         BC000813_A51SupplierAgbName = new string[] {""} ;
         BC000814_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         BC000815_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000815_n58ProductServiceId = new bool[] {false} ;
         BC000815_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000815_A59ProductServiceName = new string[] {""} ;
         BC000815_A301ProductServiceTileName = new string[] {""} ;
         BC000815_A60ProductServiceDescription = new string[] {""} ;
         BC000815_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC000815_A44SupplierGenCompanyName = new string[] {""} ;
         BC000815_A51SupplierAgbName = new string[] {""} ;
         BC000815_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC000815_n42SupplierGenId = new bool[] {false} ;
         BC000815_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC000815_n49SupplierAgbId = new bool[] {false} ;
         BC000815_A61ProductServiceImage = new string[] {""} ;
         i29LocationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_productservice_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productservice_bc__default(),
            new Object[][] {
                new Object[] {
               BC00082_A58ProductServiceId, BC00082_A29LocationId, BC00082_A59ProductServiceName, BC00082_A301ProductServiceTileName, BC00082_A60ProductServiceDescription, BC00082_A40000ProductServiceImage_GXI, BC00082_A42SupplierGenId, BC00082_n42SupplierGenId, BC00082_A49SupplierAgbId, BC00082_n49SupplierAgbId,
               BC00082_A61ProductServiceImage
               }
               , new Object[] {
               BC00083_A58ProductServiceId, BC00083_A29LocationId, BC00083_A59ProductServiceName, BC00083_A301ProductServiceTileName, BC00083_A60ProductServiceDescription, BC00083_A40000ProductServiceImage_GXI, BC00083_A42SupplierGenId, BC00083_n42SupplierGenId, BC00083_A49SupplierAgbId, BC00083_n49SupplierAgbId,
               BC00083_A61ProductServiceImage
               }
               , new Object[] {
               BC00084_A44SupplierGenCompanyName
               }
               , new Object[] {
               BC00085_A51SupplierAgbName
               }
               , new Object[] {
               BC00086_A58ProductServiceId, BC00086_A29LocationId, BC00086_A59ProductServiceName, BC00086_A301ProductServiceTileName, BC00086_A60ProductServiceDescription, BC00086_A40000ProductServiceImage_GXI, BC00086_A44SupplierGenCompanyName, BC00086_A51SupplierAgbName, BC00086_A42SupplierGenId, BC00086_n42SupplierGenId,
               BC00086_A49SupplierAgbId, BC00086_n49SupplierAgbId, BC00086_A61ProductServiceImage
               }
               , new Object[] {
               BC00087_A58ProductServiceId
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
               BC000812_A44SupplierGenCompanyName
               }
               , new Object[] {
               BC000813_A51SupplierAgbName
               }
               , new Object[] {
               BC000814_A264Trn_TileId
               }
               , new Object[] {
               BC000815_A58ProductServiceId, BC000815_A29LocationId, BC000815_A59ProductServiceName, BC000815_A301ProductServiceTileName, BC000815_A60ProductServiceDescription, BC000815_A40000ProductServiceImage_GXI, BC000815_A44SupplierGenCompanyName, BC000815_A51SupplierAgbName, BC000815_A42SupplierGenId, BC000815_n42SupplierGenId,
               BC000815_A49SupplierAgbId, BC000815_n49SupplierAgbId, BC000815_A61ProductServiceImage
               }
            }
         );
         Z58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         A58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         AV21Pgmname = "Trn_ProductService_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12082 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound13 ;
      private int trnEnded ;
      private int AV22GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV21Pgmname ;
      private string Z301ProductServiceTileName ;
      private string A301ProductServiceTileName ;
      private string sMode13 ;
      private bool returnInSub ;
      private bool n58ProductServiceId ;
      private bool n42SupplierGenId ;
      private bool n49SupplierAgbId ;
      private bool Gx_longc ;
      private string Z59ProductServiceName ;
      private string A59ProductServiceName ;
      private string Z60ProductServiceDescription ;
      private string A60ProductServiceDescription ;
      private string Z44SupplierGenCompanyName ;
      private string A44SupplierGenCompanyName ;
      private string Z51SupplierAgbName ;
      private string A51SupplierAgbName ;
      private string Z40000ProductServiceImage_GXI ;
      private string A40000ProductServiceImage_GXI ;
      private string Z61ProductServiceImage ;
      private string A61ProductServiceImage ;
      private Guid Z58ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid AV10Insert_SupplierGenId ;
      private Guid AV9Insert_SupplierAgbId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z42SupplierGenId ;
      private Guid A42SupplierGenId ;
      private Guid Z49SupplierAgbId ;
      private Guid A49SupplierAgbId ;
      private Guid GXt_guid1 ;
      private Guid i29LocationId ;
      private IGxSession AV18WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV16TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00086_A58ProductServiceId ;
      private bool[] BC00086_n58ProductServiceId ;
      private Guid[] BC00086_A29LocationId ;
      private string[] BC00086_A59ProductServiceName ;
      private string[] BC00086_A301ProductServiceTileName ;
      private string[] BC00086_A60ProductServiceDescription ;
      private string[] BC00086_A40000ProductServiceImage_GXI ;
      private string[] BC00086_A44SupplierGenCompanyName ;
      private string[] BC00086_A51SupplierAgbName ;
      private Guid[] BC00086_A42SupplierGenId ;
      private bool[] BC00086_n42SupplierGenId ;
      private Guid[] BC00086_A49SupplierAgbId ;
      private bool[] BC00086_n49SupplierAgbId ;
      private string[] BC00086_A61ProductServiceImage ;
      private string[] BC00084_A44SupplierGenCompanyName ;
      private string[] BC00085_A51SupplierAgbName ;
      private Guid[] BC00087_A58ProductServiceId ;
      private bool[] BC00087_n58ProductServiceId ;
      private Guid[] BC00083_A58ProductServiceId ;
      private bool[] BC00083_n58ProductServiceId ;
      private Guid[] BC00083_A29LocationId ;
      private string[] BC00083_A59ProductServiceName ;
      private string[] BC00083_A301ProductServiceTileName ;
      private string[] BC00083_A60ProductServiceDescription ;
      private string[] BC00083_A40000ProductServiceImage_GXI ;
      private Guid[] BC00083_A42SupplierGenId ;
      private bool[] BC00083_n42SupplierGenId ;
      private Guid[] BC00083_A49SupplierAgbId ;
      private bool[] BC00083_n49SupplierAgbId ;
      private string[] BC00083_A61ProductServiceImage ;
      private Guid[] BC00082_A58ProductServiceId ;
      private bool[] BC00082_n58ProductServiceId ;
      private Guid[] BC00082_A29LocationId ;
      private string[] BC00082_A59ProductServiceName ;
      private string[] BC00082_A301ProductServiceTileName ;
      private string[] BC00082_A60ProductServiceDescription ;
      private string[] BC00082_A40000ProductServiceImage_GXI ;
      private Guid[] BC00082_A42SupplierGenId ;
      private bool[] BC00082_n42SupplierGenId ;
      private Guid[] BC00082_A49SupplierAgbId ;
      private bool[] BC00082_n49SupplierAgbId ;
      private string[] BC00082_A61ProductServiceImage ;
      private string[] BC000812_A44SupplierGenCompanyName ;
      private string[] BC000813_A51SupplierAgbName ;
      private Guid[] BC000814_A264Trn_TileId ;
      private Guid[] BC000815_A58ProductServiceId ;
      private bool[] BC000815_n58ProductServiceId ;
      private Guid[] BC000815_A29LocationId ;
      private string[] BC000815_A59ProductServiceName ;
      private string[] BC000815_A301ProductServiceTileName ;
      private string[] BC000815_A60ProductServiceDescription ;
      private string[] BC000815_A40000ProductServiceImage_GXI ;
      private string[] BC000815_A44SupplierGenCompanyName ;
      private string[] BC000815_A51SupplierAgbName ;
      private Guid[] BC000815_A42SupplierGenId ;
      private bool[] BC000815_n42SupplierGenId ;
      private Guid[] BC000815_A49SupplierAgbId ;
      private bool[] BC000815_n49SupplierAgbId ;
      private string[] BC000815_A61ProductServiceImage ;
      private SdtTrn_ProductService bcTrn_ProductService ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_productservice_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_productservice_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
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
        Object[] prmBC00082;
        prmBC00082 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC00083;
        prmBC00083 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC00084;
        prmBC00084 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC00085;
        prmBC00085 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC00086;
        prmBC00086 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC00087;
        prmBC00087 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC00088;
        prmBC00088 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ProductServiceName",GXType.VarChar,100,0) ,
        new ParDef("ProductServiceTileName",GXType.Char,20,0) ,
        new ParDef("ProductServiceDescription",GXType.VarChar,200,0) ,
        new ParDef("ProductServiceImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("ProductServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=5, Tbl="Trn_ProductService", Fld="ProductServiceImage"} ,
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC00089;
        prmBC00089 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ProductServiceName",GXType.VarChar,100,0) ,
        new ParDef("ProductServiceTileName",GXType.Char,20,0) ,
        new ParDef("ProductServiceDescription",GXType.VarChar,200,0) ,
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000810;
        prmBC000810 = new Object[] {
        new ParDef("ProductServiceImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("ProductServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_ProductService", Fld="ProductServiceImage"} ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000811;
        prmBC000811 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000812;
        prmBC000812 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000813;
        prmBC000813 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000814;
        prmBC000814 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000815;
        prmBC000815 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00082", "SELECT ProductServiceId, LocationId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceImage_GXI, SupplierGenId, SupplierAgbId, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId  FOR UPDATE OF Trn_ProductService",true, GxErrorMask.GX_NOMASK, false, this,prmBC00082,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00083", "SELECT ProductServiceId, LocationId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceImage_GXI, SupplierGenId, SupplierAgbId, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00083,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00084", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00084,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00085", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00085,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00086", "SELECT TM1.ProductServiceId, TM1.LocationId, TM1.ProductServiceName, TM1.ProductServiceTileName, TM1.ProductServiceDescription, TM1.ProductServiceImage_GXI, T2.SupplierGenCompanyName, T3.SupplierAgbName, TM1.SupplierGenId, TM1.SupplierAgbId, TM1.ProductServiceImage FROM ((Trn_ProductService TM1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = TM1.SupplierGenId) LEFT JOIN Trn_SupplierAGB T3 ON T3.SupplierAgbId = TM1.SupplierAgbId) WHERE TM1.ProductServiceId = :ProductServiceId ORDER BY TM1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00086,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00087", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00087,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00088", "SAVEPOINT gxupdate;INSERT INTO Trn_ProductService(ProductServiceId, LocationId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceImage, ProductServiceImage_GXI, SupplierGenId, SupplierAgbId) VALUES(:ProductServiceId, :LocationId, :ProductServiceName, :ProductServiceTileName, :ProductServiceDescription, :ProductServiceImage, :ProductServiceImage_GXI, :SupplierGenId, :SupplierAgbId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00088)
           ,new CursorDef("BC00089", "SAVEPOINT gxupdate;UPDATE Trn_ProductService SET LocationId=:LocationId, ProductServiceName=:ProductServiceName, ProductServiceTileName=:ProductServiceTileName, ProductServiceDescription=:ProductServiceDescription, SupplierGenId=:SupplierGenId, SupplierAgbId=:SupplierAgbId  WHERE ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00089)
           ,new CursorDef("BC000810", "SAVEPOINT gxupdate;UPDATE Trn_ProductService SET ProductServiceImage=:ProductServiceImage, ProductServiceImage_GXI=:ProductServiceImage_GXI  WHERE ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000810)
           ,new CursorDef("BC000811", "SAVEPOINT gxupdate;DELETE FROM Trn_ProductService  WHERE ProductServiceId = :ProductServiceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000811)
           ,new CursorDef("BC000812", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000812,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000813", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000813,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000814", "SELECT Trn_TileId FROM Trn_Col WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000814,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000815", "SELECT TM1.ProductServiceId, TM1.LocationId, TM1.ProductServiceName, TM1.ProductServiceTileName, TM1.ProductServiceDescription, TM1.ProductServiceImage_GXI, T2.SupplierGenCompanyName, T3.SupplierAgbName, TM1.SupplierGenId, TM1.SupplierAgbId, TM1.ProductServiceImage FROM ((Trn_ProductService TM1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = TM1.SupplierGenId) LEFT JOIN Trn_SupplierAGB T3 ON T3.SupplierAgbId = TM1.SupplierAgbId) WHERE TM1.ProductServiceId = :ProductServiceId ORDER BY TM1.ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000815,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((Guid[]) buf[6])[0] = rslt.getGuid(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((Guid[]) buf[8])[0] = rslt.getGuid(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6));
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((Guid[]) buf[6])[0] = rslt.getGuid(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((Guid[]) buf[8])[0] = rslt.getGuid(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(6));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((Guid[]) buf[8])[0] = rslt.getGuid(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((Guid[]) buf[10])[0] = rslt.getGuid(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(6));
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((Guid[]) buf[8])[0] = rslt.getGuid(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((Guid[]) buf[10])[0] = rslt.getGuid(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(6));
              return;
     }
  }

}

}
