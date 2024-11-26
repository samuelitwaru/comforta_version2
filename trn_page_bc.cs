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
   public class trn_page_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_page_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_page_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow1794( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1794( ) ;
         standaloneModal( ) ;
         AddRow1794( ) ;
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
            E11172 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z310Trn_PageId = A310Trn_PageId;
               Z318Trn_PageName = A318Trn_PageName;
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

      protected void CONFIRM_170( )
      {
         BeforeValidate1794( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1794( ) ;
            }
            else
            {
               CheckExtendedTable1794( ) ;
               if ( AnyError == 0 )
               {
                  ZM1794( 10) ;
                  ZM1794( 11) ;
               }
               CloseExtendedTableCursors1794( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12172( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11172( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1794( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z434PageIsPublished = A434PageIsPublished;
            Z439PageIsContentPage = A439PageIsContentPage;
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -9 )
         {
            Z310Trn_PageId = A310Trn_PageId;
            Z318Trn_PageName = A318Trn_PageName;
            Z431PageJsonContent = A431PageJsonContent;
            Z432PageGJSHtml = A432PageGJSHtml;
            Z433PageGJSJson = A433PageGJSJson;
            Z434PageIsPublished = A434PageIsPublished;
            Z439PageIsContentPage = A439PageIsContentPage;
            Z437PageChildren = A437PageChildren;
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A310Trn_PageId) )
         {
            A310Trn_PageId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A439PageIsContentPage) && ( Gx_BScreen == 0 ) )
         {
            A439PageIsContentPage = false;
            n439PageIsContentPage = false;
         }
         if ( IsIns( )  && (false==A434PageIsPublished) && ( Gx_BScreen == 0 ) )
         {
            A434PageIsPublished = false;
            n434PageIsPublished = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1794( )
      {
         /* Using cursor BC00176 */
         pr_default.execute(4, new Object[] {A310Trn_PageId, A318Trn_PageName});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound94 = 1;
            A431PageJsonContent = BC00176_A431PageJsonContent[0];
            n431PageJsonContent = BC00176_n431PageJsonContent[0];
            A432PageGJSHtml = BC00176_A432PageGJSHtml[0];
            n432PageGJSHtml = BC00176_n432PageGJSHtml[0];
            A433PageGJSJson = BC00176_A433PageGJSJson[0];
            n433PageGJSJson = BC00176_n433PageGJSJson[0];
            A434PageIsPublished = BC00176_A434PageIsPublished[0];
            n434PageIsPublished = BC00176_n434PageIsPublished[0];
            A439PageIsContentPage = BC00176_A439PageIsContentPage[0];
            n439PageIsContentPage = BC00176_n439PageIsContentPage[0];
            A437PageChildren = BC00176_A437PageChildren[0];
            n437PageChildren = BC00176_n437PageChildren[0];
            A58ProductServiceId = BC00176_A58ProductServiceId[0];
            n58ProductServiceId = BC00176_n58ProductServiceId[0];
            A29LocationId = BC00176_A29LocationId[0];
            A11OrganisationId = BC00176_A11OrganisationId[0];
            ZM1794( -9) ;
         }
         pr_default.close(4);
         OnLoadActions1794( ) ;
      }

      protected void OnLoadActions1794( )
      {
      }

      protected void CheckExtendedTable1794( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A318Trn_PageName)) )
         {
            GX_msglist.addItem(context.GetMessage( "Page name cannot be empty.", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00175 */
         pr_default.execute(3, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor BC00174 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1794( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1794( )
      {
         /* Using cursor BC00177 */
         pr_default.execute(5, new Object[] {A310Trn_PageId, A318Trn_PageName});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound94 = 1;
         }
         else
         {
            RcdFound94 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00173 */
         pr_default.execute(1, new Object[] {A310Trn_PageId, A318Trn_PageName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1794( 9) ;
            RcdFound94 = 1;
            A310Trn_PageId = BC00173_A310Trn_PageId[0];
            A318Trn_PageName = BC00173_A318Trn_PageName[0];
            A431PageJsonContent = BC00173_A431PageJsonContent[0];
            n431PageJsonContent = BC00173_n431PageJsonContent[0];
            A432PageGJSHtml = BC00173_A432PageGJSHtml[0];
            n432PageGJSHtml = BC00173_n432PageGJSHtml[0];
            A433PageGJSJson = BC00173_A433PageGJSJson[0];
            n433PageGJSJson = BC00173_n433PageGJSJson[0];
            A434PageIsPublished = BC00173_A434PageIsPublished[0];
            n434PageIsPublished = BC00173_n434PageIsPublished[0];
            A439PageIsContentPage = BC00173_A439PageIsContentPage[0];
            n439PageIsContentPage = BC00173_n439PageIsContentPage[0];
            A437PageChildren = BC00173_A437PageChildren[0];
            n437PageChildren = BC00173_n437PageChildren[0];
            A58ProductServiceId = BC00173_A58ProductServiceId[0];
            n58ProductServiceId = BC00173_n58ProductServiceId[0];
            A29LocationId = BC00173_A29LocationId[0];
            A11OrganisationId = BC00173_A11OrganisationId[0];
            Z310Trn_PageId = A310Trn_PageId;
            Z318Trn_PageName = A318Trn_PageName;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1794( ) ;
            if ( AnyError == 1 )
            {
               RcdFound94 = 0;
               InitializeNonKey1794( ) ;
            }
            Gx_mode = sMode94;
         }
         else
         {
            RcdFound94 = 0;
            InitializeNonKey1794( ) ;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode94;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1794( ) ;
         if ( RcdFound94 == 0 )
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
         CONFIRM_170( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1794( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00172 */
            pr_default.execute(0, new Object[] {A310Trn_PageId, A318Trn_PageName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Page"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z434PageIsPublished != BC00172_A434PageIsPublished[0] ) || ( Z439PageIsContentPage != BC00172_A439PageIsContentPage[0] ) || ( Z58ProductServiceId != BC00172_A58ProductServiceId[0] ) || ( Z29LocationId != BC00172_A29LocationId[0] ) || ( Z11OrganisationId != BC00172_A11OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Page"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1794( )
      {
         BeforeValidate1794( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1794( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1794( 0) ;
            CheckOptimisticConcurrency1794( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1794( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1794( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00178 */
                     pr_default.execute(6, new Object[] {A310Trn_PageId, A318Trn_PageName, n431PageJsonContent, A431PageJsonContent, n432PageGJSHtml, A432PageGJSHtml, n433PageGJSJson, A433PageGJSJson, n434PageIsPublished, A434PageIsPublished, n439PageIsContentPage, A439PageIsContentPage, n437PageChildren, A437PageChildren, n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
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
               Load1794( ) ;
            }
            EndLevel1794( ) ;
         }
         CloseExtendedTableCursors1794( ) ;
      }

      protected void Update1794( )
      {
         BeforeValidate1794( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1794( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1794( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1794( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1794( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00179 */
                     pr_default.execute(7, new Object[] {n431PageJsonContent, A431PageJsonContent, n432PageGJSHtml, A432PageGJSHtml, n433PageGJSJson, A433PageGJSJson, n434PageIsPublished, A434PageIsPublished, n439PageIsContentPage, A439PageIsContentPage, n437PageChildren, A437PageChildren, n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId, A310Trn_PageId, A318Trn_PageName});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Page"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1794( ) ;
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
            EndLevel1794( ) ;
         }
         CloseExtendedTableCursors1794( ) ;
      }

      protected void DeferredUpdate1794( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1794( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1794( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1794( ) ;
            AfterConfirm1794( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1794( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001710 */
                  pr_default.execute(8, new Object[] {A310Trn_PageId, A318Trn_PageName});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
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
         sMode94 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1794( ) ;
         Gx_mode = sMode94;
      }

      protected void OnDeleteControls1794( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1794( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1794( ) ;
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

      public void ScanKeyStart1794( )
      {
         /* Scan By routine */
         /* Using cursor BC001711 */
         pr_default.execute(9, new Object[] {A310Trn_PageId, A318Trn_PageName});
         RcdFound94 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound94 = 1;
            A310Trn_PageId = BC001711_A310Trn_PageId[0];
            A318Trn_PageName = BC001711_A318Trn_PageName[0];
            A431PageJsonContent = BC001711_A431PageJsonContent[0];
            n431PageJsonContent = BC001711_n431PageJsonContent[0];
            A432PageGJSHtml = BC001711_A432PageGJSHtml[0];
            n432PageGJSHtml = BC001711_n432PageGJSHtml[0];
            A433PageGJSJson = BC001711_A433PageGJSJson[0];
            n433PageGJSJson = BC001711_n433PageGJSJson[0];
            A434PageIsPublished = BC001711_A434PageIsPublished[0];
            n434PageIsPublished = BC001711_n434PageIsPublished[0];
            A439PageIsContentPage = BC001711_A439PageIsContentPage[0];
            n439PageIsContentPage = BC001711_n439PageIsContentPage[0];
            A437PageChildren = BC001711_A437PageChildren[0];
            n437PageChildren = BC001711_n437PageChildren[0];
            A58ProductServiceId = BC001711_A58ProductServiceId[0];
            n58ProductServiceId = BC001711_n58ProductServiceId[0];
            A29LocationId = BC001711_A29LocationId[0];
            A11OrganisationId = BC001711_A11OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1794( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound94 = 0;
         ScanKeyLoad1794( ) ;
      }

      protected void ScanKeyLoad1794( )
      {
         sMode94 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound94 = 1;
            A310Trn_PageId = BC001711_A310Trn_PageId[0];
            A318Trn_PageName = BC001711_A318Trn_PageName[0];
            A431PageJsonContent = BC001711_A431PageJsonContent[0];
            n431PageJsonContent = BC001711_n431PageJsonContent[0];
            A432PageGJSHtml = BC001711_A432PageGJSHtml[0];
            n432PageGJSHtml = BC001711_n432PageGJSHtml[0];
            A433PageGJSJson = BC001711_A433PageGJSJson[0];
            n433PageGJSJson = BC001711_n433PageGJSJson[0];
            A434PageIsPublished = BC001711_A434PageIsPublished[0];
            n434PageIsPublished = BC001711_n434PageIsPublished[0];
            A439PageIsContentPage = BC001711_A439PageIsContentPage[0];
            n439PageIsContentPage = BC001711_n439PageIsContentPage[0];
            A437PageChildren = BC001711_A437PageChildren[0];
            n437PageChildren = BC001711_n437PageChildren[0];
            A58ProductServiceId = BC001711_A58ProductServiceId[0];
            n58ProductServiceId = BC001711_n58ProductServiceId[0];
            A29LocationId = BC001711_A29LocationId[0];
            A11OrganisationId = BC001711_A11OrganisationId[0];
         }
         Gx_mode = sMode94;
      }

      protected void ScanKeyEnd1794( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1794( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1794( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1794( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1794( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1794( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1794( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1794( )
      {
      }

      protected void send_integrity_lvl_hashes1794( )
      {
      }

      protected void AddRow1794( )
      {
         VarsToRow94( bcTrn_Page) ;
      }

      protected void ReadRow1794( )
      {
         RowToVars94( bcTrn_Page, 1) ;
      }

      protected void InitializeNonKey1794( )
      {
         A431PageJsonContent = "";
         n431PageJsonContent = false;
         A432PageGJSHtml = "";
         n432PageGJSHtml = false;
         A433PageGJSJson = "";
         n433PageGJSJson = false;
         A437PageChildren = "";
         n437PageChildren = false;
         A58ProductServiceId = Guid.Empty;
         n58ProductServiceId = false;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A434PageIsPublished = false;
         n434PageIsPublished = false;
         A439PageIsContentPage = false;
         n439PageIsContentPage = false;
         Z434PageIsPublished = false;
         Z439PageIsContentPage = false;
         Z58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll1794( )
      {
         A310Trn_PageId = Guid.NewGuid( );
         A318Trn_PageName = "";
         InitializeNonKey1794( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A439PageIsContentPage = i439PageIsContentPage;
         n439PageIsContentPage = false;
         A434PageIsPublished = i434PageIsPublished;
         n434PageIsPublished = false;
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

      public void VarsToRow94( SdtTrn_Page obj94 )
      {
         obj94.gxTpr_Mode = Gx_mode;
         obj94.gxTpr_Pagejsoncontent = A431PageJsonContent;
         obj94.gxTpr_Pagegjshtml = A432PageGJSHtml;
         obj94.gxTpr_Pagegjsjson = A433PageGJSJson;
         obj94.gxTpr_Pagechildren = A437PageChildren;
         obj94.gxTpr_Productserviceid = A58ProductServiceId;
         obj94.gxTpr_Organisationid = A11OrganisationId;
         obj94.gxTpr_Locationid = A29LocationId;
         obj94.gxTpr_Pageispublished = A434PageIsPublished;
         obj94.gxTpr_Pageiscontentpage = A439PageIsContentPage;
         obj94.gxTpr_Trn_pageid = A310Trn_PageId;
         obj94.gxTpr_Trn_pagename = A318Trn_PageName;
         obj94.gxTpr_Trn_pageid_Z = Z310Trn_PageId;
         obj94.gxTpr_Trn_pagename_Z = Z318Trn_PageName;
         obj94.gxTpr_Pageispublished_Z = Z434PageIsPublished;
         obj94.gxTpr_Pageiscontentpage_Z = Z439PageIsContentPage;
         obj94.gxTpr_Productserviceid_Z = Z58ProductServiceId;
         obj94.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj94.gxTpr_Locationid_Z = Z29LocationId;
         obj94.gxTpr_Pagejsoncontent_N = (short)(Convert.ToInt16(n431PageJsonContent));
         obj94.gxTpr_Pagegjshtml_N = (short)(Convert.ToInt16(n432PageGJSHtml));
         obj94.gxTpr_Pagegjsjson_N = (short)(Convert.ToInt16(n433PageGJSJson));
         obj94.gxTpr_Pageispublished_N = (short)(Convert.ToInt16(n434PageIsPublished));
         obj94.gxTpr_Pageiscontentpage_N = (short)(Convert.ToInt16(n439PageIsContentPage));
         obj94.gxTpr_Pagechildren_N = (short)(Convert.ToInt16(n437PageChildren));
         obj94.gxTpr_Productserviceid_N = (short)(Convert.ToInt16(n58ProductServiceId));
         obj94.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow94( SdtTrn_Page obj94 )
      {
         obj94.gxTpr_Trn_pageid = A310Trn_PageId;
         obj94.gxTpr_Trn_pagename = A318Trn_PageName;
         return  ;
      }

      public void RowToVars94( SdtTrn_Page obj94 ,
                               int forceLoad )
      {
         Gx_mode = obj94.gxTpr_Mode;
         A431PageJsonContent = obj94.gxTpr_Pagejsoncontent;
         n431PageJsonContent = false;
         A432PageGJSHtml = obj94.gxTpr_Pagegjshtml;
         n432PageGJSHtml = false;
         A433PageGJSJson = obj94.gxTpr_Pagegjsjson;
         n433PageGJSJson = false;
         A437PageChildren = obj94.gxTpr_Pagechildren;
         n437PageChildren = false;
         A58ProductServiceId = obj94.gxTpr_Productserviceid;
         n58ProductServiceId = false;
         A11OrganisationId = obj94.gxTpr_Organisationid;
         A29LocationId = obj94.gxTpr_Locationid;
         A434PageIsPublished = obj94.gxTpr_Pageispublished;
         n434PageIsPublished = false;
         A439PageIsContentPage = obj94.gxTpr_Pageiscontentpage;
         n439PageIsContentPage = false;
         A310Trn_PageId = obj94.gxTpr_Trn_pageid;
         A318Trn_PageName = obj94.gxTpr_Trn_pagename;
         Z310Trn_PageId = obj94.gxTpr_Trn_pageid_Z;
         Z318Trn_PageName = obj94.gxTpr_Trn_pagename_Z;
         Z434PageIsPublished = obj94.gxTpr_Pageispublished_Z;
         Z439PageIsContentPage = obj94.gxTpr_Pageiscontentpage_Z;
         Z58ProductServiceId = obj94.gxTpr_Productserviceid_Z;
         Z11OrganisationId = obj94.gxTpr_Organisationid_Z;
         Z29LocationId = obj94.gxTpr_Locationid_Z;
         n431PageJsonContent = (bool)(Convert.ToBoolean(obj94.gxTpr_Pagejsoncontent_N));
         n432PageGJSHtml = (bool)(Convert.ToBoolean(obj94.gxTpr_Pagegjshtml_N));
         n433PageGJSJson = (bool)(Convert.ToBoolean(obj94.gxTpr_Pagegjsjson_N));
         n434PageIsPublished = (bool)(Convert.ToBoolean(obj94.gxTpr_Pageispublished_N));
         n439PageIsContentPage = (bool)(Convert.ToBoolean(obj94.gxTpr_Pageiscontentpage_N));
         n437PageChildren = (bool)(Convert.ToBoolean(obj94.gxTpr_Pagechildren_N));
         n58ProductServiceId = (bool)(Convert.ToBoolean(obj94.gxTpr_Productserviceid_N));
         Gx_mode = obj94.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A310Trn_PageId = (Guid)getParm(obj,0);
         A318Trn_PageName = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1794( ) ;
         ScanKeyStart1794( ) ;
         if ( RcdFound94 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z310Trn_PageId = A310Trn_PageId;
            Z318Trn_PageName = A318Trn_PageName;
         }
         ZM1794( -9) ;
         OnLoadActions1794( ) ;
         AddRow1794( ) ;
         ScanKeyEnd1794( ) ;
         if ( RcdFound94 == 0 )
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
         RowToVars94( bcTrn_Page, 0) ;
         ScanKeyStart1794( ) ;
         if ( RcdFound94 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z310Trn_PageId = A310Trn_PageId;
            Z318Trn_PageName = A318Trn_PageName;
         }
         ZM1794( -9) ;
         OnLoadActions1794( ) ;
         AddRow1794( ) ;
         ScanKeyEnd1794( ) ;
         if ( RcdFound94 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1794( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1794( ) ;
         }
         else
         {
            if ( RcdFound94 == 1 )
            {
               if ( ( A310Trn_PageId != Z310Trn_PageId ) || ( StringUtil.StrCmp(A318Trn_PageName, Z318Trn_PageName) != 0 ) )
               {
                  A310Trn_PageId = Z310Trn_PageId;
                  A318Trn_PageName = Z318Trn_PageName;
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
                  Update1794( ) ;
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
                  if ( ( A310Trn_PageId != Z310Trn_PageId ) || ( StringUtil.StrCmp(A318Trn_PageName, Z318Trn_PageName) != 0 ) )
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
                        Insert1794( ) ;
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
                        Insert1794( ) ;
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
         RowToVars94( bcTrn_Page, 1) ;
         SaveImpl( ) ;
         VarsToRow94( bcTrn_Page) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars94( bcTrn_Page, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1794( ) ;
         AfterTrn( ) ;
         VarsToRow94( bcTrn_Page) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow94( bcTrn_Page) ;
         }
         else
         {
            SdtTrn_Page auxBC = new SdtTrn_Page(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A310Trn_PageId, A318Trn_PageName);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Page);
               auxBC.Save();
               bcTrn_Page.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars94( bcTrn_Page, 1) ;
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
         RowToVars94( bcTrn_Page, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1794( ) ;
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
               VarsToRow94( bcTrn_Page) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow94( bcTrn_Page) ;
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
         RowToVars94( bcTrn_Page, 0) ;
         GetKey1794( ) ;
         if ( RcdFound94 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A310Trn_PageId != Z310Trn_PageId ) || ( StringUtil.StrCmp(A318Trn_PageName, Z318Trn_PageName) != 0 ) )
            {
               A310Trn_PageId = Z310Trn_PageId;
               A318Trn_PageName = Z318Trn_PageName;
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
            if ( ( A310Trn_PageId != Z310Trn_PageId ) || ( StringUtil.StrCmp(A318Trn_PageName, Z318Trn_PageName) != 0 ) )
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
         context.RollbackDataStores("trn_page_bc",pr_default);
         VarsToRow94( bcTrn_Page) ;
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
         Gx_mode = bcTrn_Page.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Page.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Page )
         {
            bcTrn_Page = (SdtTrn_Page)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Page.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Page.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow94( bcTrn_Page) ;
            }
            else
            {
               RowToVars94( bcTrn_Page, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Page.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Page.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars94( bcTrn_Page, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Page Trn_Page_BC
      {
         get {
            return bcTrn_Page ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z310Trn_PageId = Guid.Empty;
         A310Trn_PageId = Guid.Empty;
         Z318Trn_PageName = "";
         A318Trn_PageName = "";
         Z58ProductServiceId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z431PageJsonContent = "";
         A431PageJsonContent = "";
         Z432PageGJSHtml = "";
         A432PageGJSHtml = "";
         Z433PageGJSJson = "";
         A433PageGJSJson = "";
         Z437PageChildren = "";
         A437PageChildren = "";
         BC00176_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00176_A318Trn_PageName = new string[] {""} ;
         BC00176_A431PageJsonContent = new string[] {""} ;
         BC00176_n431PageJsonContent = new bool[] {false} ;
         BC00176_A432PageGJSHtml = new string[] {""} ;
         BC00176_n432PageGJSHtml = new bool[] {false} ;
         BC00176_A433PageGJSJson = new string[] {""} ;
         BC00176_n433PageGJSJson = new bool[] {false} ;
         BC00176_A434PageIsPublished = new bool[] {false} ;
         BC00176_n434PageIsPublished = new bool[] {false} ;
         BC00176_A439PageIsContentPage = new bool[] {false} ;
         BC00176_n439PageIsContentPage = new bool[] {false} ;
         BC00176_A437PageChildren = new string[] {""} ;
         BC00176_n437PageChildren = new bool[] {false} ;
         BC00176_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00176_n58ProductServiceId = new bool[] {false} ;
         BC00176_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00176_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00175_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00175_n58ProductServiceId = new bool[] {false} ;
         BC00174_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00177_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00177_A318Trn_PageName = new string[] {""} ;
         BC00173_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00173_A318Trn_PageName = new string[] {""} ;
         BC00173_A431PageJsonContent = new string[] {""} ;
         BC00173_n431PageJsonContent = new bool[] {false} ;
         BC00173_A432PageGJSHtml = new string[] {""} ;
         BC00173_n432PageGJSHtml = new bool[] {false} ;
         BC00173_A433PageGJSJson = new string[] {""} ;
         BC00173_n433PageGJSJson = new bool[] {false} ;
         BC00173_A434PageIsPublished = new bool[] {false} ;
         BC00173_n434PageIsPublished = new bool[] {false} ;
         BC00173_A439PageIsContentPage = new bool[] {false} ;
         BC00173_n439PageIsContentPage = new bool[] {false} ;
         BC00173_A437PageChildren = new string[] {""} ;
         BC00173_n437PageChildren = new bool[] {false} ;
         BC00173_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00173_n58ProductServiceId = new bool[] {false} ;
         BC00173_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00173_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sMode94 = "";
         BC00172_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00172_A318Trn_PageName = new string[] {""} ;
         BC00172_A431PageJsonContent = new string[] {""} ;
         BC00172_n431PageJsonContent = new bool[] {false} ;
         BC00172_A432PageGJSHtml = new string[] {""} ;
         BC00172_n432PageGJSHtml = new bool[] {false} ;
         BC00172_A433PageGJSJson = new string[] {""} ;
         BC00172_n433PageGJSJson = new bool[] {false} ;
         BC00172_A434PageIsPublished = new bool[] {false} ;
         BC00172_n434PageIsPublished = new bool[] {false} ;
         BC00172_A439PageIsContentPage = new bool[] {false} ;
         BC00172_n439PageIsContentPage = new bool[] {false} ;
         BC00172_A437PageChildren = new string[] {""} ;
         BC00172_n437PageChildren = new bool[] {false} ;
         BC00172_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00172_n58ProductServiceId = new bool[] {false} ;
         BC00172_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00172_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001711_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC001711_A318Trn_PageName = new string[] {""} ;
         BC001711_A431PageJsonContent = new string[] {""} ;
         BC001711_n431PageJsonContent = new bool[] {false} ;
         BC001711_A432PageGJSHtml = new string[] {""} ;
         BC001711_n432PageGJSHtml = new bool[] {false} ;
         BC001711_A433PageGJSJson = new string[] {""} ;
         BC001711_n433PageGJSJson = new bool[] {false} ;
         BC001711_A434PageIsPublished = new bool[] {false} ;
         BC001711_n434PageIsPublished = new bool[] {false} ;
         BC001711_A439PageIsContentPage = new bool[] {false} ;
         BC001711_n439PageIsContentPage = new bool[] {false} ;
         BC001711_A437PageChildren = new string[] {""} ;
         BC001711_n437PageChildren = new bool[] {false} ;
         BC001711_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC001711_n58ProductServiceId = new bool[] {false} ;
         BC001711_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001711_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_page_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_page_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_page_bc__default(),
            new Object[][] {
                new Object[] {
               BC00172_A310Trn_PageId, BC00172_A318Trn_PageName, BC00172_A431PageJsonContent, BC00172_n431PageJsonContent, BC00172_A432PageGJSHtml, BC00172_n432PageGJSHtml, BC00172_A433PageGJSJson, BC00172_n433PageGJSJson, BC00172_A434PageIsPublished, BC00172_n434PageIsPublished,
               BC00172_A439PageIsContentPage, BC00172_n439PageIsContentPage, BC00172_A437PageChildren, BC00172_n437PageChildren, BC00172_A58ProductServiceId, BC00172_n58ProductServiceId, BC00172_A29LocationId, BC00172_A11OrganisationId
               }
               , new Object[] {
               BC00173_A310Trn_PageId, BC00173_A318Trn_PageName, BC00173_A431PageJsonContent, BC00173_n431PageJsonContent, BC00173_A432PageGJSHtml, BC00173_n432PageGJSHtml, BC00173_A433PageGJSJson, BC00173_n433PageGJSJson, BC00173_A434PageIsPublished, BC00173_n434PageIsPublished,
               BC00173_A439PageIsContentPage, BC00173_n439PageIsContentPage, BC00173_A437PageChildren, BC00173_n437PageChildren, BC00173_A58ProductServiceId, BC00173_n58ProductServiceId, BC00173_A29LocationId, BC00173_A11OrganisationId
               }
               , new Object[] {
               BC00174_A29LocationId
               }
               , new Object[] {
               BC00175_A58ProductServiceId
               }
               , new Object[] {
               BC00176_A310Trn_PageId, BC00176_A318Trn_PageName, BC00176_A431PageJsonContent, BC00176_n431PageJsonContent, BC00176_A432PageGJSHtml, BC00176_n432PageGJSHtml, BC00176_A433PageGJSJson, BC00176_n433PageGJSJson, BC00176_A434PageIsPublished, BC00176_n434PageIsPublished,
               BC00176_A439PageIsContentPage, BC00176_n439PageIsContentPage, BC00176_A437PageChildren, BC00176_n437PageChildren, BC00176_A58ProductServiceId, BC00176_n58ProductServiceId, BC00176_A29LocationId, BC00176_A11OrganisationId
               }
               , new Object[] {
               BC00177_A310Trn_PageId, BC00177_A318Trn_PageName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001711_A310Trn_PageId, BC001711_A318Trn_PageName, BC001711_A431PageJsonContent, BC001711_n431PageJsonContent, BC001711_A432PageGJSHtml, BC001711_n432PageGJSHtml, BC001711_A433PageGJSJson, BC001711_n433PageGJSJson, BC001711_A434PageIsPublished, BC001711_n434PageIsPublished,
               BC001711_A439PageIsContentPage, BC001711_n439PageIsContentPage, BC001711_A437PageChildren, BC001711_n437PageChildren, BC001711_A58ProductServiceId, BC001711_n58ProductServiceId, BC001711_A29LocationId, BC001711_A11OrganisationId
               }
            }
         );
         Z439PageIsContentPage = false;
         n439PageIsContentPage = false;
         A439PageIsContentPage = false;
         n439PageIsContentPage = false;
         i439PageIsContentPage = false;
         n439PageIsContentPage = false;
         Z434PageIsPublished = false;
         n434PageIsPublished = false;
         A434PageIsPublished = false;
         n434PageIsPublished = false;
         i434PageIsPublished = false;
         n434PageIsPublished = false;
         Z310Trn_PageId = Guid.NewGuid( );
         A310Trn_PageId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12172 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound94 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode94 ;
      private bool returnInSub ;
      private bool Z434PageIsPublished ;
      private bool A434PageIsPublished ;
      private bool Z439PageIsContentPage ;
      private bool A439PageIsContentPage ;
      private bool n439PageIsContentPage ;
      private bool n434PageIsPublished ;
      private bool n431PageJsonContent ;
      private bool n432PageGJSHtml ;
      private bool n433PageGJSJson ;
      private bool n437PageChildren ;
      private bool n58ProductServiceId ;
      private bool i439PageIsContentPage ;
      private bool i434PageIsPublished ;
      private string Z431PageJsonContent ;
      private string A431PageJsonContent ;
      private string Z432PageGJSHtml ;
      private string A432PageGJSHtml ;
      private string Z433PageGJSJson ;
      private string A433PageGJSJson ;
      private string Z437PageChildren ;
      private string A437PageChildren ;
      private string Z318Trn_PageName ;
      private string A318Trn_PageName ;
      private Guid Z310Trn_PageId ;
      private Guid A310Trn_PageId ;
      private Guid Z58ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00176_A310Trn_PageId ;
      private string[] BC00176_A318Trn_PageName ;
      private string[] BC00176_A431PageJsonContent ;
      private bool[] BC00176_n431PageJsonContent ;
      private string[] BC00176_A432PageGJSHtml ;
      private bool[] BC00176_n432PageGJSHtml ;
      private string[] BC00176_A433PageGJSJson ;
      private bool[] BC00176_n433PageGJSJson ;
      private bool[] BC00176_A434PageIsPublished ;
      private bool[] BC00176_n434PageIsPublished ;
      private bool[] BC00176_A439PageIsContentPage ;
      private bool[] BC00176_n439PageIsContentPage ;
      private string[] BC00176_A437PageChildren ;
      private bool[] BC00176_n437PageChildren ;
      private Guid[] BC00176_A58ProductServiceId ;
      private bool[] BC00176_n58ProductServiceId ;
      private Guid[] BC00176_A29LocationId ;
      private Guid[] BC00176_A11OrganisationId ;
      private Guid[] BC00175_A58ProductServiceId ;
      private bool[] BC00175_n58ProductServiceId ;
      private Guid[] BC00174_A29LocationId ;
      private Guid[] BC00177_A310Trn_PageId ;
      private string[] BC00177_A318Trn_PageName ;
      private Guid[] BC00173_A310Trn_PageId ;
      private string[] BC00173_A318Trn_PageName ;
      private string[] BC00173_A431PageJsonContent ;
      private bool[] BC00173_n431PageJsonContent ;
      private string[] BC00173_A432PageGJSHtml ;
      private bool[] BC00173_n432PageGJSHtml ;
      private string[] BC00173_A433PageGJSJson ;
      private bool[] BC00173_n433PageGJSJson ;
      private bool[] BC00173_A434PageIsPublished ;
      private bool[] BC00173_n434PageIsPublished ;
      private bool[] BC00173_A439PageIsContentPage ;
      private bool[] BC00173_n439PageIsContentPage ;
      private string[] BC00173_A437PageChildren ;
      private bool[] BC00173_n437PageChildren ;
      private Guid[] BC00173_A58ProductServiceId ;
      private bool[] BC00173_n58ProductServiceId ;
      private Guid[] BC00173_A29LocationId ;
      private Guid[] BC00173_A11OrganisationId ;
      private Guid[] BC00172_A310Trn_PageId ;
      private string[] BC00172_A318Trn_PageName ;
      private string[] BC00172_A431PageJsonContent ;
      private bool[] BC00172_n431PageJsonContent ;
      private string[] BC00172_A432PageGJSHtml ;
      private bool[] BC00172_n432PageGJSHtml ;
      private string[] BC00172_A433PageGJSJson ;
      private bool[] BC00172_n433PageGJSJson ;
      private bool[] BC00172_A434PageIsPublished ;
      private bool[] BC00172_n434PageIsPublished ;
      private bool[] BC00172_A439PageIsContentPage ;
      private bool[] BC00172_n439PageIsContentPage ;
      private string[] BC00172_A437PageChildren ;
      private bool[] BC00172_n437PageChildren ;
      private Guid[] BC00172_A58ProductServiceId ;
      private bool[] BC00172_n58ProductServiceId ;
      private Guid[] BC00172_A29LocationId ;
      private Guid[] BC00172_A11OrganisationId ;
      private Guid[] BC001711_A310Trn_PageId ;
      private string[] BC001711_A318Trn_PageName ;
      private string[] BC001711_A431PageJsonContent ;
      private bool[] BC001711_n431PageJsonContent ;
      private string[] BC001711_A432PageGJSHtml ;
      private bool[] BC001711_n432PageGJSHtml ;
      private string[] BC001711_A433PageGJSJson ;
      private bool[] BC001711_n433PageGJSJson ;
      private bool[] BC001711_A434PageIsPublished ;
      private bool[] BC001711_n434PageIsPublished ;
      private bool[] BC001711_A439PageIsContentPage ;
      private bool[] BC001711_n439PageIsContentPage ;
      private string[] BC001711_A437PageChildren ;
      private bool[] BC001711_n437PageChildren ;
      private Guid[] BC001711_A58ProductServiceId ;
      private bool[] BC001711_n58ProductServiceId ;
      private Guid[] BC001711_A29LocationId ;
      private Guid[] BC001711_A11OrganisationId ;
      private SdtTrn_Page bcTrn_Page ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_page_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
       return "DATASTORE1";
    }

 }

 public class trn_page_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_page_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00172;
       prmBC00172 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0)
       };
       Object[] prmBC00173;
       prmBC00173 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0)
       };
       Object[] prmBC00174;
       prmBC00174 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00175;
       prmBC00175 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00176;
       prmBC00176 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0)
       };
       Object[] prmBC00177;
       prmBC00177 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0)
       };
       Object[] prmBC00178;
       prmBC00178 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageIsPublished",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageIsContentPage",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00179;
       prmBC00179 = new Object[] {
       new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageIsPublished",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageIsContentPage",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0)
       };
       Object[] prmBC001710;
       prmBC001710 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0)
       };
       Object[] prmBC001711;
       prmBC001711 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00172", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsContentPage, PageChildren, ProductServiceId, LocationId, OrganisationId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId AND Trn_PageName = :Trn_PageName  FOR UPDATE OF Trn_Page",true, GxErrorMask.GX_NOMASK, false, this,prmBC00172,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00173", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsContentPage, PageChildren, ProductServiceId, LocationId, OrganisationId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId AND Trn_PageName = :Trn_PageName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00173,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00174", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00174,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00175", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00175,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00176", "SELECT TM1.Trn_PageId, TM1.Trn_PageName, TM1.PageJsonContent, TM1.PageGJSHtml, TM1.PageGJSJson, TM1.PageIsPublished, TM1.PageIsContentPage, TM1.PageChildren, TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId FROM Trn_Page TM1 WHERE TM1.Trn_PageId = :Trn_PageId and TM1.Trn_PageName = ( :Trn_PageName) ORDER BY TM1.Trn_PageId, TM1.Trn_PageName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00176,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00177", "SELECT Trn_PageId, Trn_PageName FROM Trn_Page WHERE Trn_PageId = :Trn_PageId AND Trn_PageName = :Trn_PageName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00177,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00178", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsContentPage, PageChildren, ProductServiceId, LocationId, OrganisationId) VALUES(:Trn_PageId, :Trn_PageName, :PageJsonContent, :PageGJSHtml, :PageGJSJson, :PageIsPublished, :PageIsContentPage, :PageChildren, :ProductServiceId, :LocationId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00178)
          ,new CursorDef("BC00179", "SAVEPOINT gxupdate;UPDATE Trn_Page SET PageJsonContent=:PageJsonContent, PageGJSHtml=:PageGJSHtml, PageGJSJson=:PageGJSJson, PageIsPublished=:PageIsPublished, PageIsContentPage=:PageIsContentPage, PageChildren=:PageChildren, ProductServiceId=:ProductServiceId, LocationId=:LocationId, OrganisationId=:OrganisationId  WHERE Trn_PageId = :Trn_PageId AND Trn_PageName = :Trn_PageName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00179)
          ,new CursorDef("BC001710", "SAVEPOINT gxupdate;DELETE FROM Trn_Page  WHERE Trn_PageId = :Trn_PageId AND Trn_PageName = :Trn_PageName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001710)
          ,new CursorDef("BC001711", "SELECT TM1.Trn_PageId, TM1.Trn_PageName, TM1.PageJsonContent, TM1.PageGJSHtml, TM1.PageGJSJson, TM1.PageIsPublished, TM1.PageIsContentPage, TM1.PageChildren, TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId FROM Trn_Page TM1 WHERE TM1.Trn_PageId = :Trn_PageId and TM1.Trn_PageName = ( :Trn_PageName) ORDER BY TM1.Trn_PageId, TM1.Trn_PageName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001711,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[13])[0] = rslt.wasNull(8);
             ((Guid[]) buf[14])[0] = rslt.getGuid(9);
             ((bool[]) buf[15])[0] = rslt.wasNull(9);
             ((Guid[]) buf[16])[0] = rslt.getGuid(10);
             ((Guid[]) buf[17])[0] = rslt.getGuid(11);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[13])[0] = rslt.wasNull(8);
             ((Guid[]) buf[14])[0] = rslt.getGuid(9);
             ((bool[]) buf[15])[0] = rslt.wasNull(9);
             ((Guid[]) buf[16])[0] = rslt.getGuid(10);
             ((Guid[]) buf[17])[0] = rslt.getGuid(11);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[13])[0] = rslt.wasNull(8);
             ((Guid[]) buf[14])[0] = rslt.getGuid(9);
             ((bool[]) buf[15])[0] = rslt.wasNull(9);
             ((Guid[]) buf[16])[0] = rslt.getGuid(10);
             ((Guid[]) buf[17])[0] = rslt.getGuid(11);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[13])[0] = rslt.wasNull(8);
             ((Guid[]) buf[14])[0] = rslt.getGuid(9);
             ((bool[]) buf[15])[0] = rslt.wasNull(9);
             ((Guid[]) buf[16])[0] = rslt.getGuid(10);
             ((Guid[]) buf[17])[0] = rslt.getGuid(11);
             return;
    }
 }

}

}
