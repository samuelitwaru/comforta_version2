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
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_page_bc( IGxContext context )
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
         ReadRow1768( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1768( ) ;
         standaloneModal( ) ;
         AddRow1768( ) ;
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
         BeforeValidate1768( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1768( ) ;
            }
            else
            {
               CheckExtendedTable1768( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1768( ) ;
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11172( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1768( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z29LocationId = A29LocationId;
            Z318Trn_PageName = A318Trn_PageName;
            Z434PageIsPublished = A434PageIsPublished;
         }
         if ( GX_JID == -6 )
         {
            Z310Trn_PageId = A310Trn_PageId;
            Z29LocationId = A29LocationId;
            Z318Trn_PageName = A318Trn_PageName;
            Z431PageJsonContent = A431PageJsonContent;
            Z432PageGJSHtml = A432PageGJSHtml;
            Z433PageGJSJson = A433PageGJSJson;
            Z434PageIsPublished = A434PageIsPublished;
            Z437PageChildren = A437PageChildren;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A29LocationId) )
         {
            A29LocationId = Guid.NewGuid( );
            n29LocationId = false;
         }
         if ( IsIns( )  && (Guid.Empty==A310Trn_PageId) )
         {
            A310Trn_PageId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A434PageIsPublished) && ( Gx_BScreen == 0 ) )
         {
            A434PageIsPublished = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1768( )
      {
         /* Using cursor BC00174 */
         pr_default.execute(2, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound68 = 1;
            A29LocationId = BC00174_A29LocationId[0];
            n29LocationId = BC00174_n29LocationId[0];
            A318Trn_PageName = BC00174_A318Trn_PageName[0];
            A431PageJsonContent = BC00174_A431PageJsonContent[0];
            A432PageGJSHtml = BC00174_A432PageGJSHtml[0];
            A433PageGJSJson = BC00174_A433PageGJSJson[0];
            A434PageIsPublished = BC00174_A434PageIsPublished[0];
            A437PageChildren = BC00174_A437PageChildren[0];
            n437PageChildren = BC00174_n437PageChildren[0];
            ZM1768( -6) ;
         }
         pr_default.close(2);
         OnLoadActions1768( ) ;
      }

      protected void OnLoadActions1768( )
      {
      }

      protected void CheckExtendedTable1768( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1768( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1768( )
      {
         /* Using cursor BC00175 */
         pr_default.execute(3, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound68 = 1;
         }
         else
         {
            RcdFound68 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00173 */
         pr_default.execute(1, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1768( 6) ;
            RcdFound68 = 1;
            A310Trn_PageId = BC00173_A310Trn_PageId[0];
            A29LocationId = BC00173_A29LocationId[0];
            n29LocationId = BC00173_n29LocationId[0];
            A318Trn_PageName = BC00173_A318Trn_PageName[0];
            A431PageJsonContent = BC00173_A431PageJsonContent[0];
            A432PageGJSHtml = BC00173_A432PageGJSHtml[0];
            A433PageGJSJson = BC00173_A433PageGJSJson[0];
            A434PageIsPublished = BC00173_A434PageIsPublished[0];
            A437PageChildren = BC00173_A437PageChildren[0];
            n437PageChildren = BC00173_n437PageChildren[0];
            Z310Trn_PageId = A310Trn_PageId;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1768( ) ;
            if ( AnyError == 1 )
            {
               RcdFound68 = 0;
               InitializeNonKey1768( ) ;
            }
            Gx_mode = sMode68;
         }
         else
         {
            RcdFound68 = 0;
            InitializeNonKey1768( ) ;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode68;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1768( ) ;
         if ( RcdFound68 == 0 )
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

      protected void CheckOptimisticConcurrency1768( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00172 */
            pr_default.execute(0, new Object[] {A310Trn_PageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Page"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z29LocationId != BC00172_A29LocationId[0] ) || ( StringUtil.StrCmp(Z318Trn_PageName, BC00172_A318Trn_PageName[0]) != 0 ) || ( Z434PageIsPublished != BC00172_A434PageIsPublished[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Page"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1768( )
      {
         BeforeValidate1768( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1768( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1768( 0) ;
            CheckOptimisticConcurrency1768( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1768( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1768( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00176 */
                     pr_default.execute(4, new Object[] {A310Trn_PageId, n29LocationId, A29LocationId, A318Trn_PageName, A431PageJsonContent, A432PageGJSHtml, A433PageGJSJson, A434PageIsPublished, n437PageChildren, A437PageChildren});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load1768( ) ;
            }
            EndLevel1768( ) ;
         }
         CloseExtendedTableCursors1768( ) ;
      }

      protected void Update1768( )
      {
         BeforeValidate1768( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1768( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1768( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1768( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1768( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00177 */
                     pr_default.execute(5, new Object[] {n29LocationId, A29LocationId, A318Trn_PageName, A431PageJsonContent, A432PageGJSHtml, A433PageGJSJson, A434PageIsPublished, n437PageChildren, A437PageChildren, A310Trn_PageId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Page"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1768( ) ;
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
            EndLevel1768( ) ;
         }
         CloseExtendedTableCursors1768( ) ;
      }

      protected void DeferredUpdate1768( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1768( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1768( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1768( ) ;
            AfterConfirm1768( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1768( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00178 */
                  pr_default.execute(6, new Object[] {A310Trn_PageId});
                  pr_default.close(6);
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
         sMode68 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1768( ) ;
         Gx_mode = sMode68;
      }

      protected void OnDeleteControls1768( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC00179 */
            pr_default.execute(7, new Object[] {A310Trn_PageId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Tile", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
            /* Using cursor BC001710 */
            pr_default.execute(8, new Object[] {A310Trn_PageId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Row", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel1768( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1768( ) ;
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

      public void ScanKeyStart1768( )
      {
         /* Scan By routine */
         /* Using cursor BC001711 */
         pr_default.execute(9, new Object[] {A310Trn_PageId});
         RcdFound68 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound68 = 1;
            A310Trn_PageId = BC001711_A310Trn_PageId[0];
            A29LocationId = BC001711_A29LocationId[0];
            n29LocationId = BC001711_n29LocationId[0];
            A318Trn_PageName = BC001711_A318Trn_PageName[0];
            A431PageJsonContent = BC001711_A431PageJsonContent[0];
            A432PageGJSHtml = BC001711_A432PageGJSHtml[0];
            A433PageGJSJson = BC001711_A433PageGJSJson[0];
            A434PageIsPublished = BC001711_A434PageIsPublished[0];
            A437PageChildren = BC001711_A437PageChildren[0];
            n437PageChildren = BC001711_n437PageChildren[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1768( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound68 = 0;
         ScanKeyLoad1768( ) ;
      }

      protected void ScanKeyLoad1768( )
      {
         sMode68 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound68 = 1;
            A310Trn_PageId = BC001711_A310Trn_PageId[0];
            A29LocationId = BC001711_A29LocationId[0];
            n29LocationId = BC001711_n29LocationId[0];
            A318Trn_PageName = BC001711_A318Trn_PageName[0];
            A431PageJsonContent = BC001711_A431PageJsonContent[0];
            A432PageGJSHtml = BC001711_A432PageGJSHtml[0];
            A433PageGJSJson = BC001711_A433PageGJSJson[0];
            A434PageIsPublished = BC001711_A434PageIsPublished[0];
            A437PageChildren = BC001711_A437PageChildren[0];
            n437PageChildren = BC001711_n437PageChildren[0];
         }
         Gx_mode = sMode68;
      }

      protected void ScanKeyEnd1768( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1768( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1768( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1768( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1768( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1768( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1768( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1768( )
      {
      }

      protected void send_integrity_lvl_hashes1768( )
      {
      }

      protected void AddRow1768( )
      {
         VarsToRow68( bcTrn_Page) ;
      }

      protected void ReadRow1768( )
      {
         RowToVars68( bcTrn_Page, 1) ;
      }

      protected void InitializeNonKey1768( )
      {
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         A437PageChildren = "";
         n437PageChildren = false;
         A29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         A434PageIsPublished = false;
         Z29LocationId = Guid.Empty;
         Z318Trn_PageName = "";
         Z434PageIsPublished = false;
      }

      protected void InitAll1768( )
      {
         A310Trn_PageId = Guid.NewGuid( );
         InitializeNonKey1768( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A29LocationId = i29LocationId;
         n29LocationId = false;
         A434PageIsPublished = i434PageIsPublished;
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

      public void VarsToRow68( SdtTrn_Page obj68 )
      {
         obj68.gxTpr_Mode = Gx_mode;
         obj68.gxTpr_Trn_pagename = A318Trn_PageName;
         obj68.gxTpr_Pagejsoncontent = A431PageJsonContent;
         obj68.gxTpr_Pagegjshtml = A432PageGJSHtml;
         obj68.gxTpr_Pagegjsjson = A433PageGJSJson;
         obj68.gxTpr_Pagechildren = A437PageChildren;
         obj68.gxTpr_Locationid = A29LocationId;
         obj68.gxTpr_Pageispublished = A434PageIsPublished;
         obj68.gxTpr_Trn_pageid = A310Trn_PageId;
         obj68.gxTpr_Trn_pageid_Z = Z310Trn_PageId;
         obj68.gxTpr_Trn_pagename_Z = Z318Trn_PageName;
         obj68.gxTpr_Pageispublished_Z = Z434PageIsPublished;
         obj68.gxTpr_Locationid_Z = Z29LocationId;
         obj68.gxTpr_Locationid_N = (short)(Convert.ToInt16(n29LocationId));
         obj68.gxTpr_Pagechildren_N = (short)(Convert.ToInt16(n437PageChildren));
         obj68.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow68( SdtTrn_Page obj68 )
      {
         obj68.gxTpr_Trn_pageid = A310Trn_PageId;
         return  ;
      }

      public void RowToVars68( SdtTrn_Page obj68 ,
                               int forceLoad )
      {
         Gx_mode = obj68.gxTpr_Mode;
         A318Trn_PageName = obj68.gxTpr_Trn_pagename;
         A431PageJsonContent = obj68.gxTpr_Pagejsoncontent;
         A432PageGJSHtml = obj68.gxTpr_Pagegjshtml;
         A433PageGJSJson = obj68.gxTpr_Pagegjsjson;
         A437PageChildren = obj68.gxTpr_Pagechildren;
         n437PageChildren = false;
         A29LocationId = obj68.gxTpr_Locationid;
         n29LocationId = false;
         A434PageIsPublished = obj68.gxTpr_Pageispublished;
         A310Trn_PageId = obj68.gxTpr_Trn_pageid;
         Z310Trn_PageId = obj68.gxTpr_Trn_pageid_Z;
         Z318Trn_PageName = obj68.gxTpr_Trn_pagename_Z;
         Z434PageIsPublished = obj68.gxTpr_Pageispublished_Z;
         Z29LocationId = obj68.gxTpr_Locationid_Z;
         n29LocationId = (bool)(Convert.ToBoolean(obj68.gxTpr_Locationid_N));
         n437PageChildren = (bool)(Convert.ToBoolean(obj68.gxTpr_Pagechildren_N));
         Gx_mode = obj68.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A310Trn_PageId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1768( ) ;
         ScanKeyStart1768( ) ;
         if ( RcdFound68 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z310Trn_PageId = A310Trn_PageId;
         }
         ZM1768( -6) ;
         OnLoadActions1768( ) ;
         AddRow1768( ) ;
         ScanKeyEnd1768( ) ;
         if ( RcdFound68 == 0 )
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
         RowToVars68( bcTrn_Page, 0) ;
         ScanKeyStart1768( ) ;
         if ( RcdFound68 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z310Trn_PageId = A310Trn_PageId;
         }
         ZM1768( -6) ;
         OnLoadActions1768( ) ;
         AddRow1768( ) ;
         ScanKeyEnd1768( ) ;
         if ( RcdFound68 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1768( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1768( ) ;
         }
         else
         {
            if ( RcdFound68 == 1 )
            {
               if ( A310Trn_PageId != Z310Trn_PageId )
               {
                  A310Trn_PageId = Z310Trn_PageId;
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
                  Update1768( ) ;
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
                  if ( A310Trn_PageId != Z310Trn_PageId )
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
                        Insert1768( ) ;
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
                        Insert1768( ) ;
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
         RowToVars68( bcTrn_Page, 1) ;
         SaveImpl( ) ;
         VarsToRow68( bcTrn_Page) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars68( bcTrn_Page, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1768( ) ;
         AfterTrn( ) ;
         VarsToRow68( bcTrn_Page) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow68( bcTrn_Page) ;
         }
         else
         {
            SdtTrn_Page auxBC = new SdtTrn_Page(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A310Trn_PageId);
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
         RowToVars68( bcTrn_Page, 1) ;
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
         RowToVars68( bcTrn_Page, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1768( ) ;
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
               VarsToRow68( bcTrn_Page) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow68( bcTrn_Page) ;
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
         RowToVars68( bcTrn_Page, 0) ;
         GetKey1768( ) ;
         if ( RcdFound68 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A310Trn_PageId != Z310Trn_PageId )
            {
               A310Trn_PageId = Z310Trn_PageId;
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
            if ( A310Trn_PageId != Z310Trn_PageId )
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
         VarsToRow68( bcTrn_Page) ;
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
               VarsToRow68( bcTrn_Page) ;
            }
            else
            {
               RowToVars68( bcTrn_Page, 1) ;
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
         RowToVars68( bcTrn_Page, 1) ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z318Trn_PageName = "";
         A318Trn_PageName = "";
         Z431PageJsonContent = "";
         A431PageJsonContent = "";
         Z432PageGJSHtml = "";
         A432PageGJSHtml = "";
         Z433PageGJSJson = "";
         A433PageGJSJson = "";
         Z437PageChildren = "";
         A437PageChildren = "";
         BC00174_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00174_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00174_n29LocationId = new bool[] {false} ;
         BC00174_A318Trn_PageName = new string[] {""} ;
         BC00174_A431PageJsonContent = new string[] {""} ;
         BC00174_A432PageGJSHtml = new string[] {""} ;
         BC00174_A433PageGJSJson = new string[] {""} ;
         BC00174_A434PageIsPublished = new bool[] {false} ;
         BC00174_A437PageChildren = new string[] {""} ;
         BC00174_n437PageChildren = new bool[] {false} ;
         BC00175_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00173_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00173_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00173_n29LocationId = new bool[] {false} ;
         BC00173_A318Trn_PageName = new string[] {""} ;
         BC00173_A431PageJsonContent = new string[] {""} ;
         BC00173_A432PageGJSHtml = new string[] {""} ;
         BC00173_A433PageGJSJson = new string[] {""} ;
         BC00173_A434PageIsPublished = new bool[] {false} ;
         BC00173_A437PageChildren = new string[] {""} ;
         BC00173_n437PageChildren = new bool[] {false} ;
         sMode68 = "";
         BC00172_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00172_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00172_n29LocationId = new bool[] {false} ;
         BC00172_A318Trn_PageName = new string[] {""} ;
         BC00172_A431PageJsonContent = new string[] {""} ;
         BC00172_A432PageGJSHtml = new string[] {""} ;
         BC00172_A433PageGJSJson = new string[] {""} ;
         BC00172_A434PageIsPublished = new bool[] {false} ;
         BC00172_A437PageChildren = new string[] {""} ;
         BC00172_n437PageChildren = new bool[] {false} ;
         BC00179_A407TileId = new Guid[] {Guid.Empty} ;
         BC001710_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         BC001711_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         BC001711_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001711_n29LocationId = new bool[] {false} ;
         BC001711_A318Trn_PageName = new string[] {""} ;
         BC001711_A431PageJsonContent = new string[] {""} ;
         BC001711_A432PageGJSHtml = new string[] {""} ;
         BC001711_A433PageGJSJson = new string[] {""} ;
         BC001711_A434PageIsPublished = new bool[] {false} ;
         BC001711_A437PageChildren = new string[] {""} ;
         BC001711_n437PageChildren = new bool[] {false} ;
         i29LocationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_page_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_page_bc__default(),
            new Object[][] {
                new Object[] {
               BC00172_A310Trn_PageId, BC00172_A29LocationId, BC00172_n29LocationId, BC00172_A318Trn_PageName, BC00172_A431PageJsonContent, BC00172_A432PageGJSHtml, BC00172_A433PageGJSJson, BC00172_A434PageIsPublished, BC00172_A437PageChildren, BC00172_n437PageChildren
               }
               , new Object[] {
               BC00173_A310Trn_PageId, BC00173_A29LocationId, BC00173_n29LocationId, BC00173_A318Trn_PageName, BC00173_A431PageJsonContent, BC00173_A432PageGJSHtml, BC00173_A433PageGJSJson, BC00173_A434PageIsPublished, BC00173_A437PageChildren, BC00173_n437PageChildren
               }
               , new Object[] {
               BC00174_A310Trn_PageId, BC00174_A29LocationId, BC00174_n29LocationId, BC00174_A318Trn_PageName, BC00174_A431PageJsonContent, BC00174_A432PageGJSHtml, BC00174_A433PageGJSJson, BC00174_A434PageIsPublished, BC00174_A437PageChildren, BC00174_n437PageChildren
               }
               , new Object[] {
               BC00175_A310Trn_PageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00179_A407TileId
               }
               , new Object[] {
               BC001710_A319Trn_RowId
               }
               , new Object[] {
               BC001711_A310Trn_PageId, BC001711_A29LocationId, BC001711_n29LocationId, BC001711_A318Trn_PageName, BC001711_A431PageJsonContent, BC001711_A432PageGJSHtml, BC001711_A433PageGJSJson, BC001711_A434PageIsPublished, BC001711_A437PageChildren, BC001711_n437PageChildren
               }
            }
         );
         Z29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         A29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         i29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         Z434PageIsPublished = false;
         A434PageIsPublished = false;
         i434PageIsPublished = false;
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
      private short RcdFound68 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode68 ;
      private bool returnInSub ;
      private bool Z434PageIsPublished ;
      private bool A434PageIsPublished ;
      private bool n29LocationId ;
      private bool n437PageChildren ;
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
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid i29LocationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00174_A310Trn_PageId ;
      private Guid[] BC00174_A29LocationId ;
      private bool[] BC00174_n29LocationId ;
      private string[] BC00174_A318Trn_PageName ;
      private string[] BC00174_A431PageJsonContent ;
      private string[] BC00174_A432PageGJSHtml ;
      private string[] BC00174_A433PageGJSJson ;
      private bool[] BC00174_A434PageIsPublished ;
      private string[] BC00174_A437PageChildren ;
      private bool[] BC00174_n437PageChildren ;
      private Guid[] BC00175_A310Trn_PageId ;
      private Guid[] BC00173_A310Trn_PageId ;
      private Guid[] BC00173_A29LocationId ;
      private bool[] BC00173_n29LocationId ;
      private string[] BC00173_A318Trn_PageName ;
      private string[] BC00173_A431PageJsonContent ;
      private string[] BC00173_A432PageGJSHtml ;
      private string[] BC00173_A433PageGJSJson ;
      private bool[] BC00173_A434PageIsPublished ;
      private string[] BC00173_A437PageChildren ;
      private bool[] BC00173_n437PageChildren ;
      private Guid[] BC00172_A310Trn_PageId ;
      private Guid[] BC00172_A29LocationId ;
      private bool[] BC00172_n29LocationId ;
      private string[] BC00172_A318Trn_PageName ;
      private string[] BC00172_A431PageJsonContent ;
      private string[] BC00172_A432PageGJSHtml ;
      private string[] BC00172_A433PageGJSJson ;
      private bool[] BC00172_A434PageIsPublished ;
      private string[] BC00172_A437PageChildren ;
      private bool[] BC00172_n437PageChildren ;
      private Guid[] BC00179_A407TileId ;
      private Guid[] BC001710_A319Trn_RowId ;
      private Guid[] BC001711_A310Trn_PageId ;
      private Guid[] BC001711_A29LocationId ;
      private bool[] BC001711_n29LocationId ;
      private string[] BC001711_A318Trn_PageName ;
      private string[] BC001711_A431PageJsonContent ;
      private string[] BC001711_A432PageGJSHtml ;
      private string[] BC001711_A433PageGJSJson ;
      private bool[] BC001711_A434PageIsPublished ;
      private string[] BC001711_A437PageChildren ;
      private bool[] BC001711_n437PageChildren ;
      private SdtTrn_Page bcTrn_Page ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
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
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
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
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00173;
        prmBC00173 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00174;
        prmBC00174 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00175;
        prmBC00175 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00176;
        prmBC00176 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
        new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageIsPublished",GXType.Boolean,4,0) ,
        new ParDef("PageChildren",GXType.LongVarChar,2097152,0){Nullable=true}
        };
        Object[] prmBC00177;
        prmBC00177 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
        new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageIsPublished",GXType.Boolean,4,0) ,
        new ParDef("PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00178;
        prmBC00178 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00179;
        prmBC00179 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001710;
        prmBC001710 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001711;
        prmBC001711 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00172", "SELECT Trn_PageId, LocationId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageChildren FROM Trn_Page WHERE Trn_PageId = :Trn_PageId  FOR UPDATE OF Trn_Page",true, GxErrorMask.GX_NOMASK, false, this,prmBC00172,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00173", "SELECT Trn_PageId, LocationId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageChildren FROM Trn_Page WHERE Trn_PageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00173,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00174", "SELECT TM1.Trn_PageId, TM1.LocationId, TM1.Trn_PageName, TM1.PageJsonContent, TM1.PageGJSHtml, TM1.PageGJSJson, TM1.PageIsPublished, TM1.PageChildren FROM Trn_Page TM1 WHERE TM1.Trn_PageId = :Trn_PageId ORDER BY TM1.Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00174,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00175", "SELECT Trn_PageId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00175,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00176", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, LocationId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageChildren) VALUES(:Trn_PageId, :LocationId, :Trn_PageName, :PageJsonContent, :PageGJSHtml, :PageGJSJson, :PageIsPublished, :PageChildren);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00176)
           ,new CursorDef("BC00177", "SAVEPOINT gxupdate;UPDATE Trn_Page SET LocationId=:LocationId, Trn_PageName=:Trn_PageName, PageJsonContent=:PageJsonContent, PageGJSHtml=:PageGJSHtml, PageGJSJson=:PageGJSJson, PageIsPublished=:PageIsPublished, PageChildren=:PageChildren  WHERE Trn_PageId = :Trn_PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00177)
           ,new CursorDef("BC00178", "SAVEPOINT gxupdate;DELETE FROM Trn_Page  WHERE Trn_PageId = :Trn_PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00178)
           ,new CursorDef("BC00179", "SELECT TileId FROM Trn_Tile WHERE SG_ToPageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00179,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001710", "SELECT Trn_RowId FROM Trn_Row WHERE Trn_PageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001710,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001711", "SELECT TM1.Trn_PageId, TM1.LocationId, TM1.Trn_PageName, TM1.PageJsonContent, TM1.PageGJSHtml, TM1.PageGJSJson, TM1.PageIsPublished, TM1.PageChildren FROM Trn_Page TM1 WHERE TM1.Trn_PageId = :Trn_PageId ORDER BY TM1.Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001711,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[7])[0] = rslt.getBool(7);
              ((string[]) buf[8])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[7])[0] = rslt.getBool(7);
              ((string[]) buf[8])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[7])[0] = rslt.getBool(7);
              ((string[]) buf[8])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[7])[0] = rslt.getBool(7);
              ((string[]) buf[8])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              return;
     }
  }

}

}
