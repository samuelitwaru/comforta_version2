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
   public class trn_theme_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_theme_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_theme_bc( IGxContext context )
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
         ReadRow0W46( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0W46( ) ;
         standaloneModal( ) ;
         AddRow0W46( ) ;
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
            E110W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
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

      protected void CONFIRM_0W0( )
      {
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0W46( ) ;
            }
            else
            {
               CheckExtendedTable0W46( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0W46( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode46 = Gx_mode;
            CONFIRM_0W49( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0W47( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode46;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode46;
         }
      }

      protected void CONFIRM_0W47( )
      {
         nGXsfl_47_idx = 0;
         while ( nGXsfl_47_idx < bcTrn_Theme.gxTpr_Color.Count )
         {
            ReadRow0W47( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound47 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_47 != 0 ) )
            {
               GetKey0W47( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound47 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0W47( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0W47( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0W47( ) ;
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
                  if ( RcdFound47 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0W47( ) ;
                        Load0W47( ) ;
                        BeforeValidate0W47( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0W47( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_47 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0W47( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0W47( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0W47( ) ;
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
               VarsToRow47( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_47_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0W49( )
      {
         nGXsfl_49_idx = 0;
         while ( nGXsfl_49_idx < bcTrn_Theme.gxTpr_Icon.Count )
         {
            ReadRow0W49( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound49 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_49 != 0 ) )
            {
               GetKey0W49( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound49 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0W49( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0W49( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0W49( ) ;
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
                  if ( RcdFound49 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0W49( ) ;
                        Load0W49( ) ;
                        BeforeValidate0W49( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0W49( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_49 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0W49( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0W49( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0W49( ) ;
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
               VarsToRow49( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_49_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0W46( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z248Trn_ThemeName = A248Trn_ThemeName;
            Z260Trn_ThemeFontFamily = A260Trn_ThemeFontFamily;
         }
         if ( GX_JID == -7 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z248Trn_ThemeName = A248Trn_ThemeName;
            Z260Trn_ThemeFontFamily = A260Trn_ThemeFontFamily;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) )
         {
            A247Trn_ThemeId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W46( )
      {
         /* Using cursor BC000W8 */
         pr_default.execute(6, new Object[] {A247Trn_ThemeId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound46 = 1;
            A248Trn_ThemeName = BC000W8_A248Trn_ThemeName[0];
            A260Trn_ThemeFontFamily = BC000W8_A260Trn_ThemeFontFamily[0];
            ZM0W46( -7) ;
         }
         pr_default.close(6);
         OnLoadActions0W46( ) ;
      }

      protected void OnLoadActions0W46( )
      {
      }

      protected void CheckExtendedTable0W46( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0W46( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0W46( )
      {
         /* Using cursor BC000W9 */
         pr_default.execute(7, new Object[] {A247Trn_ThemeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000W7 */
         pr_default.execute(5, new Object[] {A247Trn_ThemeId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0W46( 7) ;
            RcdFound46 = 1;
            A247Trn_ThemeId = BC000W7_A247Trn_ThemeId[0];
            A248Trn_ThemeName = BC000W7_A248Trn_ThemeName[0];
            A260Trn_ThemeFontFamily = BC000W7_A260Trn_ThemeFontFamily[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0W46( ) ;
            if ( AnyError == 1 )
            {
               RcdFound46 = 0;
               InitializeNonKey0W46( ) ;
            }
            Gx_mode = sMode46;
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey0W46( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode46;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W46( ) ;
         if ( RcdFound46 == 0 )
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
         CONFIRM_0W0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0W46( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000W6 */
            pr_default.execute(4, new Object[] {A247Trn_ThemeId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z248Trn_ThemeName, BC000W6_A248Trn_ThemeName[0]) != 0 ) || ( StringUtil.StrCmp(Z260Trn_ThemeFontFamily, BC000W6_A260Trn_ThemeFontFamily[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Theme"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W46( )
      {
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W46( 0) ;
            CheckOptimisticConcurrency0W46( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W46( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W46( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W10 */
                     pr_default.execute(8, new Object[] {A247Trn_ThemeId, A248Trn_ThemeName, A260Trn_ThemeFontFamily});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ProcessLevel0W46( ) ;
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
               Load0W46( ) ;
            }
            EndLevel0W46( ) ;
         }
         CloseExtendedTableCursors0W46( ) ;
      }

      protected void Update0W46( )
      {
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W46( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W46( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W46( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W11 */
                     pr_default.execute(9, new Object[] {A248Trn_ThemeName, A260Trn_ThemeFontFamily, A247Trn_ThemeId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W46( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0W46( ) ;
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
            EndLevel0W46( ) ;
         }
         CloseExtendedTableCursors0W46( ) ;
      }

      protected void DeferredUpdate0W46( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W46( ) ;
            AfterConfirm0W46( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W46( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0W49( ) ;
                  while ( RcdFound49 != 0 )
                  {
                     getByPrimaryKey0W49( ) ;
                     Delete0W49( ) ;
                     ScanKeyNext0W49( ) ;
                  }
                  ScanKeyEnd0W49( ) ;
                  ScanKeyStart0W47( ) ;
                  while ( RcdFound47 != 0 )
                  {
                     getByPrimaryKey0W47( ) ;
                     Delete0W47( ) ;
                     ScanKeyNext0W47( ) ;
                  }
                  ScanKeyEnd0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W12 */
                     pr_default.execute(10, new Object[] {A247Trn_ThemeId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
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
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0W46( ) ;
         Gx_mode = sMode46;
      }

      protected void OnDeleteControls0W46( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel0W49( )
      {
         nGXsfl_49_idx = 0;
         while ( nGXsfl_49_idx < bcTrn_Theme.gxTpr_Icon.Count )
         {
            ReadRow0W49( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound49 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_49 != 0 ) )
            {
               standaloneNotModal0W49( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0W49( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0W49( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0W49( ) ;
                  }
               }
            }
            KeyVarsToRow49( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_49_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_49_idx = 0;
            while ( nGXsfl_49_idx < bcTrn_Theme.gxTpr_Icon.Count )
            {
               ReadRow0W49( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound49 == 0 )
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
                  bcTrn_Theme.gxTpr_Icon.RemoveElement(nGXsfl_49_idx);
                  nGXsfl_49_idx = (int)(nGXsfl_49_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0W49( ) ;
                  VarsToRow49( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_49_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0W49( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_49 = 0;
         nIsMod_49 = 0;
      }

      protected void ProcessNestedLevel0W47( )
      {
         nGXsfl_47_idx = 0;
         while ( nGXsfl_47_idx < bcTrn_Theme.gxTpr_Color.Count )
         {
            ReadRow0W47( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound47 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_47 != 0 ) )
            {
               standaloneNotModal0W47( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0W47( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0W47( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0W47( ) ;
                  }
               }
            }
            KeyVarsToRow47( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_47_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_47_idx = 0;
            while ( nGXsfl_47_idx < bcTrn_Theme.gxTpr_Color.Count )
            {
               ReadRow0W47( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound47 == 0 )
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
                  bcTrn_Theme.gxTpr_Color.RemoveElement(nGXsfl_47_idx);
                  nGXsfl_47_idx = (int)(nGXsfl_47_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0W47( ) ;
                  VarsToRow47( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_47_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0W47( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_47 = 0;
         nIsMod_47 = 0;
      }

      protected void ProcessLevel0W46( )
      {
         /* Save parent mode. */
         sMode46 = Gx_mode;
         ProcessNestedLevel0W49( ) ;
         ProcessNestedLevel0W47( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode46;
         /* ' Update level parameters */
      }

      protected void EndLevel0W46( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W46( ) ;
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

      public void ScanKeyStart0W46( )
      {
         /* Scan By routine */
         /* Using cursor BC000W13 */
         pr_default.execute(11, new Object[] {A247Trn_ThemeId});
         RcdFound46 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound46 = 1;
            A247Trn_ThemeId = BC000W13_A247Trn_ThemeId[0];
            A248Trn_ThemeName = BC000W13_A248Trn_ThemeName[0];
            A260Trn_ThemeFontFamily = BC000W13_A260Trn_ThemeFontFamily[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0W46( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound46 = 0;
         ScanKeyLoad0W46( ) ;
      }

      protected void ScanKeyLoad0W46( )
      {
         sMode46 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound46 = 1;
            A247Trn_ThemeId = BC000W13_A247Trn_ThemeId[0];
            A248Trn_ThemeName = BC000W13_A248Trn_ThemeName[0];
            A260Trn_ThemeFontFamily = BC000W13_A260Trn_ThemeFontFamily[0];
         }
         Gx_mode = sMode46;
      }

      protected void ScanKeyEnd0W46( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0W46( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W46( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W46( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W46( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W46( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W46( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W46( )
      {
      }

      protected void ZM0W49( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z262IconName = A262IconName;
         }
         if ( GX_JID == -8 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z261IconId = A261IconId;
            Z262IconName = A262IconName;
            Z263IconSVG = A263IconSVG;
         }
      }

      protected void standaloneNotModal0W49( )
      {
      }

      protected void standaloneModal0W49( )
      {
         if ( IsIns( )  && (Guid.Empty==A261IconId) )
         {
            A261IconId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W49( )
      {
         /* Using cursor BC000W14 */
         pr_default.execute(12, new Object[] {A247Trn_ThemeId, A261IconId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound49 = 1;
            A262IconName = BC000W14_A262IconName[0];
            A263IconSVG = BC000W14_A263IconSVG[0];
            ZM0W49( -8) ;
         }
         pr_default.close(12);
         OnLoadActions0W49( ) ;
      }

      protected void OnLoadActions0W49( )
      {
      }

      protected void CheckExtendedTable0W49( )
      {
         Gx_BScreen = 1;
         standaloneModal0W49( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0W49( )
      {
      }

      protected void enableDisable0W49( )
      {
      }

      protected void GetKey0W49( )
      {
         /* Using cursor BC000W15 */
         pr_default.execute(13, new Object[] {A247Trn_ThemeId, A261IconId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey0W49( )
      {
         /* Using cursor BC000W5 */
         pr_default.execute(3, new Object[] {A247Trn_ThemeId, A261IconId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0W49( 8) ;
            RcdFound49 = 1;
            InitializeNonKey0W49( ) ;
            A261IconId = BC000W5_A261IconId[0];
            A262IconName = BC000W5_A262IconName[0];
            A263IconSVG = BC000W5_A263IconSVG[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z261IconId = A261IconId;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0W49( ) ;
            Load0W49( ) ;
            Gx_mode = sMode49;
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey0W49( ) ;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0W49( ) ;
            Gx_mode = sMode49;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0W49( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency0W49( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000W4 */
            pr_default.execute(2, new Object[] {A247Trn_ThemeId, A261IconId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeIcon"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z262IconName, BC000W4_A262IconName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeIcon"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W49( )
      {
         BeforeValidate0W49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W49( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W49( 0) ;
            CheckOptimisticConcurrency0W49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W16 */
                     pr_default.execute(14, new Object[] {A247Trn_ThemeId, A261IconId, A262IconName, A263IconSVG});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                     if ( (pr_default.getStatus(14) == 1) )
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
               Load0W49( ) ;
            }
            EndLevel0W49( ) ;
         }
         CloseExtendedTableCursors0W49( ) ;
      }

      protected void Update0W49( )
      {
         BeforeValidate0W49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W49( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W17 */
                     pr_default.execute(15, new Object[] {A262IconName, A263IconSVG, A247Trn_ThemeId, A261IconId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeIcon"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W49( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0W49( ) ;
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
            EndLevel0W49( ) ;
         }
         CloseExtendedTableCursors0W49( ) ;
      }

      protected void DeferredUpdate0W49( )
      {
      }

      protected void Delete0W49( )
      {
         Gx_mode = "DLT";
         BeforeValidate0W49( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W49( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W49( ) ;
            AfterConfirm0W49( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W49( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000W18 */
                  pr_default.execute(16, new Object[] {A247Trn_ThemeId, A261IconId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
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
         sMode49 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0W49( ) ;
         Gx_mode = sMode49;
      }

      protected void OnDeleteControls0W49( )
      {
         standaloneModal0W49( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W49( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0W49( )
      {
         /* Scan By routine */
         /* Using cursor BC000W19 */
         pr_default.execute(17, new Object[] {A247Trn_ThemeId});
         RcdFound49 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound49 = 1;
            A261IconId = BC000W19_A261IconId[0];
            A262IconName = BC000W19_A262IconName[0];
            A263IconSVG = BC000W19_A263IconSVG[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0W49( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound49 = 0;
         ScanKeyLoad0W49( ) ;
      }

      protected void ScanKeyLoad0W49( )
      {
         sMode49 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound49 = 1;
            A261IconId = BC000W19_A261IconId[0];
            A262IconName = BC000W19_A262IconName[0];
            A263IconSVG = BC000W19_A263IconSVG[0];
         }
         Gx_mode = sMode49;
      }

      protected void ScanKeyEnd0W49( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0W49( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W49( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W49( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W49( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W49( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W49( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W49( )
      {
      }

      protected void send_integrity_lvl_hashes0W49( )
      {
      }

      protected void ZM0W47( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z250ColorName = A250ColorName;
            Z251ColorCode = A251ColorCode;
         }
         if ( GX_JID == -9 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z249ColorId = A249ColorId;
            Z250ColorName = A250ColorName;
            Z251ColorCode = A251ColorCode;
         }
      }

      protected void standaloneNotModal0W47( )
      {
      }

      protected void standaloneModal0W47( )
      {
         if ( IsIns( )  && (Guid.Empty==A249ColorId) )
         {
            A249ColorId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W47( )
      {
         /* Using cursor BC000W20 */
         pr_default.execute(18, new Object[] {A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound47 = 1;
            A250ColorName = BC000W20_A250ColorName[0];
            A251ColorCode = BC000W20_A251ColorCode[0];
            ZM0W47( -9) ;
         }
         pr_default.close(18);
         OnLoadActions0W47( ) ;
      }

      protected void OnLoadActions0W47( )
      {
      }

      protected void CheckExtendedTable0W47( )
      {
         Gx_BScreen = 1;
         standaloneModal0W47( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0W47( )
      {
      }

      protected void enableDisable0W47( )
      {
      }

      protected void GetKey0W47( )
      {
         /* Using cursor BC000W21 */
         pr_default.execute(19, new Object[] {A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey0W47( )
      {
         /* Using cursor BC000W3 */
         pr_default.execute(1, new Object[] {A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W47( 9) ;
            RcdFound47 = 1;
            InitializeNonKey0W47( ) ;
            A249ColorId = BC000W3_A249ColorId[0];
            A250ColorName = BC000W3_A250ColorName[0];
            A251ColorCode = BC000W3_A251ColorCode[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z249ColorId = A249ColorId;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0W47( ) ;
            Load0W47( ) ;
            Gx_mode = sMode47;
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey0W47( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0W47( ) ;
            Gx_mode = sMode47;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0W47( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0W47( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000W2 */
            pr_default.execute(0, new Object[] {A247Trn_ThemeId, A249ColorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z250ColorName, BC000W2_A250ColorName[0]) != 0 ) || ( StringUtil.StrCmp(Z251ColorCode, BC000W2_A251ColorCode[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeColor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W47( )
      {
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W47( 0) ;
            CheckOptimisticConcurrency0W47( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W47( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W22 */
                     pr_default.execute(20, new Object[] {A247Trn_ThemeId, A249ColorId, A250ColorName, A251ColorCode});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(20) == 1) )
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
               Load0W47( ) ;
            }
            EndLevel0W47( ) ;
         }
         CloseExtendedTableCursors0W47( ) ;
      }

      protected void Update0W47( )
      {
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W47( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W47( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W23 */
                     pr_default.execute(21, new Object[] {A250ColorName, A251ColorCode, A247Trn_ThemeId, A249ColorId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W47( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0W47( ) ;
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
            EndLevel0W47( ) ;
         }
         CloseExtendedTableCursors0W47( ) ;
      }

      protected void DeferredUpdate0W47( )
      {
      }

      protected void Delete0W47( )
      {
         Gx_mode = "DLT";
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W47( ) ;
            AfterConfirm0W47( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W47( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000W24 */
                  pr_default.execute(22, new Object[] {A247Trn_ThemeId, A249ColorId});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
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
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0W47( ) ;
         Gx_mode = sMode47;
      }

      protected void OnDeleteControls0W47( )
      {
         standaloneModal0W47( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W47( )
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

      public void ScanKeyStart0W47( )
      {
         /* Scan By routine */
         /* Using cursor BC000W25 */
         pr_default.execute(23, new Object[] {A247Trn_ThemeId});
         RcdFound47 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound47 = 1;
            A249ColorId = BC000W25_A249ColorId[0];
            A250ColorName = BC000W25_A250ColorName[0];
            A251ColorCode = BC000W25_A251ColorCode[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0W47( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound47 = 0;
         ScanKeyLoad0W47( ) ;
      }

      protected void ScanKeyLoad0W47( )
      {
         sMode47 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound47 = 1;
            A249ColorId = BC000W25_A249ColorId[0];
            A250ColorName = BC000W25_A250ColorName[0];
            A251ColorCode = BC000W25_A251ColorCode[0];
         }
         Gx_mode = sMode47;
      }

      protected void ScanKeyEnd0W47( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm0W47( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W47( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W47( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W47( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W47( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W47( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W47( )
      {
      }

      protected void send_integrity_lvl_hashes0W47( )
      {
      }

      protected void send_integrity_lvl_hashes0W46( )
      {
      }

      protected void AddRow0W46( )
      {
         VarsToRow46( bcTrn_Theme) ;
      }

      protected void ReadRow0W46( )
      {
         RowToVars46( bcTrn_Theme, 1) ;
      }

      protected void AddRow0W49( )
      {
         SdtTrn_Theme_Icon obj49;
         obj49 = new SdtTrn_Theme_Icon(context);
         VarsToRow49( obj49) ;
         bcTrn_Theme.gxTpr_Icon.Add(obj49, 0);
         obj49.gxTpr_Mode = "UPD";
         obj49.gxTpr_Modified = 0;
      }

      protected void ReadRow0W49( )
      {
         nGXsfl_49_idx = (int)(nGXsfl_49_idx+1);
         RowToVars49( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_49_idx)), 1) ;
      }

      protected void AddRow0W47( )
      {
         SdtTrn_Theme_Color obj47;
         obj47 = new SdtTrn_Theme_Color(context);
         VarsToRow47( obj47) ;
         bcTrn_Theme.gxTpr_Color.Add(obj47, 0);
         obj47.gxTpr_Mode = "UPD";
         obj47.gxTpr_Modified = 0;
      }

      protected void ReadRow0W47( )
      {
         nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
         RowToVars47( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_47_idx)), 1) ;
      }

      protected void InitializeNonKey0W46( )
      {
         A248Trn_ThemeName = "";
         A260Trn_ThemeFontFamily = "";
         Z248Trn_ThemeName = "";
         Z260Trn_ThemeFontFamily = "";
      }

      protected void InitAll0W46( )
      {
         A247Trn_ThemeId = Guid.NewGuid( );
         InitializeNonKey0W46( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0W49( )
      {
         A262IconName = "";
         A263IconSVG = "";
         Z262IconName = "";
      }

      protected void InitAll0W49( )
      {
         A261IconId = Guid.NewGuid( );
         InitializeNonKey0W49( ) ;
      }

      protected void StandaloneModalInsert0W49( )
      {
      }

      protected void InitializeNonKey0W47( )
      {
         A250ColorName = "";
         A251ColorCode = "";
         Z250ColorName = "";
         Z251ColorCode = "";
      }

      protected void InitAll0W47( )
      {
         A249ColorId = Guid.NewGuid( );
         InitializeNonKey0W47( ) ;
      }

      protected void StandaloneModalInsert0W47( )
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

      public void VarsToRow46( SdtTrn_Theme obj46 )
      {
         obj46.gxTpr_Mode = Gx_mode;
         obj46.gxTpr_Trn_themename = A248Trn_ThemeName;
         obj46.gxTpr_Trn_themefontfamily = A260Trn_ThemeFontFamily;
         obj46.gxTpr_Trn_themeid = A247Trn_ThemeId;
         obj46.gxTpr_Trn_themeid_Z = Z247Trn_ThemeId;
         obj46.gxTpr_Trn_themename_Z = Z248Trn_ThemeName;
         obj46.gxTpr_Trn_themefontfamily_Z = Z260Trn_ThemeFontFamily;
         obj46.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow46( SdtTrn_Theme obj46 )
      {
         obj46.gxTpr_Trn_themeid = A247Trn_ThemeId;
         return  ;
      }

      public void RowToVars46( SdtTrn_Theme obj46 ,
                               int forceLoad )
      {
         Gx_mode = obj46.gxTpr_Mode;
         A248Trn_ThemeName = obj46.gxTpr_Trn_themename;
         A260Trn_ThemeFontFamily = obj46.gxTpr_Trn_themefontfamily;
         A247Trn_ThemeId = obj46.gxTpr_Trn_themeid;
         Z247Trn_ThemeId = obj46.gxTpr_Trn_themeid_Z;
         Z248Trn_ThemeName = obj46.gxTpr_Trn_themename_Z;
         Z260Trn_ThemeFontFamily = obj46.gxTpr_Trn_themefontfamily_Z;
         Gx_mode = obj46.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow49( SdtTrn_Theme_Icon obj49 )
      {
         obj49.gxTpr_Mode = Gx_mode;
         obj49.gxTpr_Iconname = A262IconName;
         obj49.gxTpr_Iconsvg = A263IconSVG;
         obj49.gxTpr_Iconid = A261IconId;
         obj49.gxTpr_Iconid_Z = Z261IconId;
         obj49.gxTpr_Iconname_Z = Z262IconName;
         obj49.gxTpr_Modified = nIsMod_49;
         return  ;
      }

      public void KeyVarsToRow49( SdtTrn_Theme_Icon obj49 )
      {
         obj49.gxTpr_Iconid = A261IconId;
         return  ;
      }

      public void RowToVars49( SdtTrn_Theme_Icon obj49 ,
                               int forceLoad )
      {
         Gx_mode = obj49.gxTpr_Mode;
         A262IconName = obj49.gxTpr_Iconname;
         A263IconSVG = obj49.gxTpr_Iconsvg;
         A261IconId = obj49.gxTpr_Iconid;
         Z261IconId = obj49.gxTpr_Iconid_Z;
         Z262IconName = obj49.gxTpr_Iconname_Z;
         nIsMod_49 = obj49.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow47( SdtTrn_Theme_Color obj47 )
      {
         obj47.gxTpr_Mode = Gx_mode;
         obj47.gxTpr_Colorname = A250ColorName;
         obj47.gxTpr_Colorcode = A251ColorCode;
         obj47.gxTpr_Colorid = A249ColorId;
         obj47.gxTpr_Colorid_Z = Z249ColorId;
         obj47.gxTpr_Colorname_Z = Z250ColorName;
         obj47.gxTpr_Colorcode_Z = Z251ColorCode;
         obj47.gxTpr_Modified = nIsMod_47;
         return  ;
      }

      public void KeyVarsToRow47( SdtTrn_Theme_Color obj47 )
      {
         obj47.gxTpr_Colorid = A249ColorId;
         return  ;
      }

      public void RowToVars47( SdtTrn_Theme_Color obj47 ,
                               int forceLoad )
      {
         Gx_mode = obj47.gxTpr_Mode;
         A250ColorName = obj47.gxTpr_Colorname;
         A251ColorCode = obj47.gxTpr_Colorcode;
         A249ColorId = obj47.gxTpr_Colorid;
         Z249ColorId = obj47.gxTpr_Colorid_Z;
         Z250ColorName = obj47.gxTpr_Colorname_Z;
         Z251ColorCode = obj47.gxTpr_Colorcode_Z;
         nIsMod_47 = obj47.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A247Trn_ThemeId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0W46( ) ;
         ScanKeyStart0W46( ) ;
         if ( RcdFound46 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z247Trn_ThemeId = A247Trn_ThemeId;
         }
         ZM0W46( -7) ;
         OnLoadActions0W46( ) ;
         AddRow0W46( ) ;
         bcTrn_Theme.gxTpr_Icon.ClearCollection();
         if ( RcdFound46 == 1 )
         {
            ScanKeyStart0W49( ) ;
            nGXsfl_49_idx = 1;
            while ( RcdFound49 != 0 )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
               Z261IconId = A261IconId;
               ZM0W49( -8) ;
               OnLoadActions0W49( ) ;
               nRcdExists_49 = 1;
               nIsMod_49 = 0;
               AddRow0W49( ) ;
               nGXsfl_49_idx = (int)(nGXsfl_49_idx+1);
               ScanKeyNext0W49( ) ;
            }
            ScanKeyEnd0W49( ) ;
         }
         bcTrn_Theme.gxTpr_Color.ClearCollection();
         if ( RcdFound46 == 1 )
         {
            ScanKeyStart0W47( ) ;
            nGXsfl_47_idx = 1;
            while ( RcdFound47 != 0 )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
               Z249ColorId = A249ColorId;
               ZM0W47( -9) ;
               OnLoadActions0W47( ) ;
               nRcdExists_47 = 1;
               nIsMod_47 = 0;
               AddRow0W47( ) ;
               nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
               ScanKeyNext0W47( ) ;
            }
            ScanKeyEnd0W47( ) ;
         }
         ScanKeyEnd0W46( ) ;
         if ( RcdFound46 == 0 )
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
         RowToVars46( bcTrn_Theme, 0) ;
         ScanKeyStart0W46( ) ;
         if ( RcdFound46 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z247Trn_ThemeId = A247Trn_ThemeId;
         }
         ZM0W46( -7) ;
         OnLoadActions0W46( ) ;
         AddRow0W46( ) ;
         bcTrn_Theme.gxTpr_Icon.ClearCollection();
         if ( RcdFound46 == 1 )
         {
            ScanKeyStart0W49( ) ;
            nGXsfl_49_idx = 1;
            while ( RcdFound49 != 0 )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
               Z261IconId = A261IconId;
               ZM0W49( -8) ;
               OnLoadActions0W49( ) ;
               nRcdExists_49 = 1;
               nIsMod_49 = 0;
               AddRow0W49( ) ;
               nGXsfl_49_idx = (int)(nGXsfl_49_idx+1);
               ScanKeyNext0W49( ) ;
            }
            ScanKeyEnd0W49( ) ;
         }
         bcTrn_Theme.gxTpr_Color.ClearCollection();
         if ( RcdFound46 == 1 )
         {
            ScanKeyStart0W47( ) ;
            nGXsfl_47_idx = 1;
            while ( RcdFound47 != 0 )
            {
               Z247Trn_ThemeId = A247Trn_ThemeId;
               Z249ColorId = A249ColorId;
               ZM0W47( -9) ;
               OnLoadActions0W47( ) ;
               nRcdExists_47 = 1;
               nIsMod_47 = 0;
               AddRow0W47( ) ;
               nGXsfl_47_idx = (int)(nGXsfl_47_idx+1);
               ScanKeyNext0W47( ) ;
            }
            ScanKeyEnd0W47( ) ;
         }
         ScanKeyEnd0W46( ) ;
         if ( RcdFound46 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0W46( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0W46( ) ;
         }
         else
         {
            if ( RcdFound46 == 1 )
            {
               if ( A247Trn_ThemeId != Z247Trn_ThemeId )
               {
                  A247Trn_ThemeId = Z247Trn_ThemeId;
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
                  Update0W46( ) ;
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
                  if ( A247Trn_ThemeId != Z247Trn_ThemeId )
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
                        Insert0W46( ) ;
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
                        Insert0W46( ) ;
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
         RowToVars46( bcTrn_Theme, 1) ;
         SaveImpl( ) ;
         VarsToRow46( bcTrn_Theme) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars46( bcTrn_Theme, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0W46( ) ;
         AfterTrn( ) ;
         VarsToRow46( bcTrn_Theme) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow46( bcTrn_Theme) ;
         }
         else
         {
            SdtTrn_Theme auxBC = new SdtTrn_Theme(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A247Trn_ThemeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Theme);
               auxBC.Save();
               bcTrn_Theme.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars46( bcTrn_Theme, 1) ;
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
         RowToVars46( bcTrn_Theme, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0W46( ) ;
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
               VarsToRow46( bcTrn_Theme) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow46( bcTrn_Theme) ;
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
         RowToVars46( bcTrn_Theme, 0) ;
         GetKey0W46( ) ;
         if ( RcdFound46 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A247Trn_ThemeId != Z247Trn_ThemeId )
            {
               A247Trn_ThemeId = Z247Trn_ThemeId;
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
            if ( A247Trn_ThemeId != Z247Trn_ThemeId )
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
         context.RollbackDataStores("trn_theme_bc",pr_default);
         VarsToRow46( bcTrn_Theme) ;
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
         Gx_mode = bcTrn_Theme.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Theme.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Theme )
         {
            bcTrn_Theme = (SdtTrn_Theme)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Theme.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Theme.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow46( bcTrn_Theme) ;
            }
            else
            {
               RowToVars46( bcTrn_Theme, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Theme.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Theme.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars46( bcTrn_Theme, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Theme Trn_Theme_BC
      {
         get {
            return bcTrn_Theme ;
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
            return "trn_theme_Execute" ;
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
         pr_default.close(3);
         pr_default.close(5);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z247Trn_ThemeId = Guid.Empty;
         A247Trn_ThemeId = Guid.Empty;
         sMode46 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z248Trn_ThemeName = "";
         A248Trn_ThemeName = "";
         Z260Trn_ThemeFontFamily = "";
         A260Trn_ThemeFontFamily = "";
         BC000W8_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W8_A248Trn_ThemeName = new string[] {""} ;
         BC000W8_A260Trn_ThemeFontFamily = new string[] {""} ;
         BC000W9_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W7_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W7_A248Trn_ThemeName = new string[] {""} ;
         BC000W7_A260Trn_ThemeFontFamily = new string[] {""} ;
         BC000W6_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W6_A248Trn_ThemeName = new string[] {""} ;
         BC000W6_A260Trn_ThemeFontFamily = new string[] {""} ;
         BC000W13_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W13_A248Trn_ThemeName = new string[] {""} ;
         BC000W13_A260Trn_ThemeFontFamily = new string[] {""} ;
         Z262IconName = "";
         A262IconName = "";
         Z261IconId = Guid.Empty;
         A261IconId = Guid.Empty;
         Z263IconSVG = "";
         A263IconSVG = "";
         BC000W14_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W14_A261IconId = new Guid[] {Guid.Empty} ;
         BC000W14_A262IconName = new string[] {""} ;
         BC000W14_A263IconSVG = new string[] {""} ;
         BC000W15_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W15_A261IconId = new Guid[] {Guid.Empty} ;
         BC000W5_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W5_A261IconId = new Guid[] {Guid.Empty} ;
         BC000W5_A262IconName = new string[] {""} ;
         BC000W5_A263IconSVG = new string[] {""} ;
         sMode49 = "";
         BC000W4_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W4_A261IconId = new Guid[] {Guid.Empty} ;
         BC000W4_A262IconName = new string[] {""} ;
         BC000W4_A263IconSVG = new string[] {""} ;
         BC000W19_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W19_A261IconId = new Guid[] {Guid.Empty} ;
         BC000W19_A262IconName = new string[] {""} ;
         BC000W19_A263IconSVG = new string[] {""} ;
         Z250ColorName = "";
         A250ColorName = "";
         Z251ColorCode = "";
         A251ColorCode = "";
         Z249ColorId = Guid.Empty;
         A249ColorId = Guid.Empty;
         BC000W20_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W20_A249ColorId = new Guid[] {Guid.Empty} ;
         BC000W20_A250ColorName = new string[] {""} ;
         BC000W20_A251ColorCode = new string[] {""} ;
         BC000W21_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W21_A249ColorId = new Guid[] {Guid.Empty} ;
         BC000W3_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W3_A249ColorId = new Guid[] {Guid.Empty} ;
         BC000W3_A250ColorName = new string[] {""} ;
         BC000W3_A251ColorCode = new string[] {""} ;
         sMode47 = "";
         BC000W2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W2_A249ColorId = new Guid[] {Guid.Empty} ;
         BC000W2_A250ColorName = new string[] {""} ;
         BC000W2_A251ColorCode = new string[] {""} ;
         BC000W25_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000W25_A249ColorId = new Guid[] {Guid.Empty} ;
         BC000W25_A250ColorName = new string[] {""} ;
         BC000W25_A251ColorCode = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_theme_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_theme_bc__default(),
            new Object[][] {
                new Object[] {
               BC000W2_A247Trn_ThemeId, BC000W2_A249ColorId, BC000W2_A250ColorName, BC000W2_A251ColorCode
               }
               , new Object[] {
               BC000W3_A247Trn_ThemeId, BC000W3_A249ColorId, BC000W3_A250ColorName, BC000W3_A251ColorCode
               }
               , new Object[] {
               BC000W4_A247Trn_ThemeId, BC000W4_A261IconId, BC000W4_A262IconName, BC000W4_A263IconSVG
               }
               , new Object[] {
               BC000W5_A247Trn_ThemeId, BC000W5_A261IconId, BC000W5_A262IconName, BC000W5_A263IconSVG
               }
               , new Object[] {
               BC000W6_A247Trn_ThemeId, BC000W6_A248Trn_ThemeName, BC000W6_A260Trn_ThemeFontFamily
               }
               , new Object[] {
               BC000W7_A247Trn_ThemeId, BC000W7_A248Trn_ThemeName, BC000W7_A260Trn_ThemeFontFamily
               }
               , new Object[] {
               BC000W8_A247Trn_ThemeId, BC000W8_A248Trn_ThemeName, BC000W8_A260Trn_ThemeFontFamily
               }
               , new Object[] {
               BC000W9_A247Trn_ThemeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W13_A247Trn_ThemeId, BC000W13_A248Trn_ThemeName, BC000W13_A260Trn_ThemeFontFamily
               }
               , new Object[] {
               BC000W14_A247Trn_ThemeId, BC000W14_A261IconId, BC000W14_A262IconName, BC000W14_A263IconSVG
               }
               , new Object[] {
               BC000W15_A247Trn_ThemeId, BC000W15_A261IconId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W19_A247Trn_ThemeId, BC000W19_A261IconId, BC000W19_A262IconName, BC000W19_A263IconSVG
               }
               , new Object[] {
               BC000W20_A247Trn_ThemeId, BC000W20_A249ColorId, BC000W20_A250ColorName, BC000W20_A251ColorCode
               }
               , new Object[] {
               BC000W21_A247Trn_ThemeId, BC000W21_A249ColorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W25_A247Trn_ThemeId, BC000W25_A249ColorId, BC000W25_A250ColorName, BC000W25_A251ColorCode
               }
            }
         );
         Z249ColorId = Guid.NewGuid( );
         A249ColorId = Guid.NewGuid( );
         Z261IconId = Guid.NewGuid( );
         A261IconId = Guid.NewGuid( );
         Z247Trn_ThemeId = Guid.NewGuid( );
         A247Trn_ThemeId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120W2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_47 ;
      private short RcdFound47 ;
      private short nIsMod_49 ;
      private short RcdFound49 ;
      private short Gx_BScreen ;
      private short RcdFound46 ;
      private short nRcdExists_49 ;
      private short nRcdExists_47 ;
      private short Gxremove49 ;
      private short Gxremove47 ;
      private int trnEnded ;
      private int nGXsfl_47_idx=1 ;
      private int nGXsfl_49_idx=1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode46 ;
      private string sMode49 ;
      private string sMode47 ;
      private bool returnInSub ;
      private string Z263IconSVG ;
      private string A263IconSVG ;
      private string Z248Trn_ThemeName ;
      private string A248Trn_ThemeName ;
      private string Z260Trn_ThemeFontFamily ;
      private string A260Trn_ThemeFontFamily ;
      private string Z262IconName ;
      private string A262IconName ;
      private string Z250ColorName ;
      private string A250ColorName ;
      private string Z251ColorCode ;
      private string A251ColorCode ;
      private Guid Z247Trn_ThemeId ;
      private Guid A247Trn_ThemeId ;
      private Guid Z261IconId ;
      private Guid A261IconId ;
      private Guid Z249ColorId ;
      private Guid A249ColorId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Theme bcTrn_Theme ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000W8_A247Trn_ThemeId ;
      private string[] BC000W8_A248Trn_ThemeName ;
      private string[] BC000W8_A260Trn_ThemeFontFamily ;
      private Guid[] BC000W9_A247Trn_ThemeId ;
      private Guid[] BC000W7_A247Trn_ThemeId ;
      private string[] BC000W7_A248Trn_ThemeName ;
      private string[] BC000W7_A260Trn_ThemeFontFamily ;
      private Guid[] BC000W6_A247Trn_ThemeId ;
      private string[] BC000W6_A248Trn_ThemeName ;
      private string[] BC000W6_A260Trn_ThemeFontFamily ;
      private Guid[] BC000W13_A247Trn_ThemeId ;
      private string[] BC000W13_A248Trn_ThemeName ;
      private string[] BC000W13_A260Trn_ThemeFontFamily ;
      private Guid[] BC000W14_A247Trn_ThemeId ;
      private Guid[] BC000W14_A261IconId ;
      private string[] BC000W14_A262IconName ;
      private string[] BC000W14_A263IconSVG ;
      private Guid[] BC000W15_A247Trn_ThemeId ;
      private Guid[] BC000W15_A261IconId ;
      private Guid[] BC000W5_A247Trn_ThemeId ;
      private Guid[] BC000W5_A261IconId ;
      private string[] BC000W5_A262IconName ;
      private string[] BC000W5_A263IconSVG ;
      private Guid[] BC000W4_A247Trn_ThemeId ;
      private Guid[] BC000W4_A261IconId ;
      private string[] BC000W4_A262IconName ;
      private string[] BC000W4_A263IconSVG ;
      private Guid[] BC000W19_A247Trn_ThemeId ;
      private Guid[] BC000W19_A261IconId ;
      private string[] BC000W19_A262IconName ;
      private string[] BC000W19_A263IconSVG ;
      private Guid[] BC000W20_A247Trn_ThemeId ;
      private Guid[] BC000W20_A249ColorId ;
      private string[] BC000W20_A250ColorName ;
      private string[] BC000W20_A251ColorCode ;
      private Guid[] BC000W21_A247Trn_ThemeId ;
      private Guid[] BC000W21_A249ColorId ;
      private Guid[] BC000W3_A247Trn_ThemeId ;
      private Guid[] BC000W3_A249ColorId ;
      private string[] BC000W3_A250ColorName ;
      private string[] BC000W3_A251ColorCode ;
      private Guid[] BC000W2_A247Trn_ThemeId ;
      private Guid[] BC000W2_A249ColorId ;
      private string[] BC000W2_A250ColorName ;
      private string[] BC000W2_A251ColorCode ;
      private Guid[] BC000W25_A247Trn_ThemeId ;
      private Guid[] BC000W25_A249ColorId ;
      private string[] BC000W25_A250ColorName ;
      private string[] BC000W25_A251ColorCode ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_theme_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_theme_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000W2;
        prmBC000W2 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W3;
        prmBC000W3 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W4;
        prmBC000W4 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("IconId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W5;
        prmBC000W5 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("IconId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W6;
        prmBC000W6 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W7;
        prmBC000W7 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W8;
        prmBC000W8 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W9;
        prmBC000W9 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W10;
        prmBC000W10 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
        new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0)
        };
        Object[] prmBC000W11;
        prmBC000W11 = new Object[] {
        new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
        new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W12;
        prmBC000W12 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W13;
        prmBC000W13 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W14;
        prmBC000W14 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("IconId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W15;
        prmBC000W15 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("IconId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W16;
        prmBC000W16 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("IconId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("IconName",GXType.VarChar,100,0) ,
        new ParDef("IconSVG",GXType.LongVarChar,2097152,0)
        };
        Object[] prmBC000W17;
        prmBC000W17 = new Object[] {
        new ParDef("IconName",GXType.VarChar,100,0) ,
        new ParDef("IconSVG",GXType.LongVarChar,2097152,0) ,
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("IconId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W18;
        prmBC000W18 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("IconId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W19;
        prmBC000W19 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W20;
        prmBC000W20 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W21;
        prmBC000W21 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W22;
        prmBC000W22 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorName",GXType.VarChar,100,0) ,
        new ParDef("ColorCode",GXType.VarChar,100,0)
        };
        Object[] prmBC000W23;
        prmBC000W23 = new Object[] {
        new ParDef("ColorName",GXType.VarChar,100,0) ,
        new ParDef("ColorCode",GXType.VarChar,100,0) ,
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W24;
        prmBC000W24 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000W25;
        prmBC000W25 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000W2", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId  FOR UPDATE OF Trn_ThemeColor",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W3", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W4", "SELECT Trn_ThemeId, IconId, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId  FOR UPDATE OF Trn_ThemeIcon",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W5", "SELECT Trn_ThemeId, IconId, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W6", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId  FOR UPDATE OF Trn_Theme",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W7", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W8", "SELECT TM1.Trn_ThemeId, TM1.Trn_ThemeName, TM1.Trn_ThemeFontFamily FROM Trn_Theme TM1 WHERE TM1.Trn_ThemeId = :Trn_ThemeId ORDER BY TM1.Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W9", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W10", "SAVEPOINT gxupdate;INSERT INTO Trn_Theme(Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily) VALUES(:Trn_ThemeId, :Trn_ThemeName, :Trn_ThemeFontFamily);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000W10)
           ,new CursorDef("BC000W11", "SAVEPOINT gxupdate;UPDATE Trn_Theme SET Trn_ThemeName=:Trn_ThemeName, Trn_ThemeFontFamily=:Trn_ThemeFontFamily  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W11)
           ,new CursorDef("BC000W12", "SAVEPOINT gxupdate;DELETE FROM Trn_Theme  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W12)
           ,new CursorDef("BC000W13", "SELECT TM1.Trn_ThemeId, TM1.Trn_ThemeName, TM1.Trn_ThemeFontFamily FROM Trn_Theme TM1 WHERE TM1.Trn_ThemeId = :Trn_ThemeId ORDER BY TM1.Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W14", "SELECT Trn_ThemeId, IconId, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId and IconId = :IconId ORDER BY Trn_ThemeId, IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W14,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W15", "SELECT Trn_ThemeId, IconId FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W16", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeIcon(Trn_ThemeId, IconId, IconName, IconSVG) VALUES(:Trn_ThemeId, :IconId, :IconName, :IconSVG);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000W16)
           ,new CursorDef("BC000W17", "SAVEPOINT gxupdate;UPDATE Trn_ThemeIcon SET IconName=:IconName, IconSVG=:IconSVG  WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W17)
           ,new CursorDef("BC000W18", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeIcon  WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W18)
           ,new CursorDef("BC000W19", "SELECT Trn_ThemeId, IconId, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W19,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W20", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W20,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W21", "SELECT Trn_ThemeId, ColorId FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000W22", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeColor(Trn_ThemeId, ColorId, ColorName, ColorCode) VALUES(:Trn_ThemeId, :ColorId, :ColorName, :ColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000W22)
           ,new CursorDef("BC000W23", "SAVEPOINT gxupdate;UPDATE Trn_ThemeColor SET ColorName=:ColorName, ColorCode=:ColorCode  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W23)
           ,new CursorDef("BC000W24", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeColor  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W24)
           ,new CursorDef("BC000W25", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W25,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 17 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              return;
           case 18 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 19 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 23 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
     }
  }

}

}