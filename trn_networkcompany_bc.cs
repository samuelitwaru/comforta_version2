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
   public class trn_networkcompany_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_networkcompany_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_networkcompany_bc( IGxContext context )
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
         ReadRow0B19( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0B19( ) ;
         standaloneModal( ) ;
         AddRow0B19( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z82NetworkCompanyId = A82NetworkCompanyId;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B19( ) ;
            }
            else
            {
               CheckExtendedTable0B19( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0B19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0B19( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z83NetworkCompanyKvkNumber = A83NetworkCompanyKvkNumber;
            Z84NetworkCompanyName = A84NetworkCompanyName;
            Z85NetworkCompanyEmail = A85NetworkCompanyEmail;
            Z86NetworkCompanyPhone = A86NetworkCompanyPhone;
            Z391NetworkCompanyPhoneCode = A391NetworkCompanyPhoneCode;
            Z392NetworkCompanyPhoneNumber = A392NetworkCompanyPhoneNumber;
            Z349NetworkCompanyCountry = A349NetworkCompanyCountry;
            Z350NetworkCompanyCity = A350NetworkCompanyCity;
            Z351NetworkCompanyZipCode = A351NetworkCompanyZipCode;
            Z352NetworkCompanyAddressLine1 = A352NetworkCompanyAddressLine1;
            Z353NetworkCompanyAddressLine2 = A353NetworkCompanyAddressLine2;
         }
         if ( GX_JID == -6 )
         {
            Z82NetworkCompanyId = A82NetworkCompanyId;
            Z83NetworkCompanyKvkNumber = A83NetworkCompanyKvkNumber;
            Z84NetworkCompanyName = A84NetworkCompanyName;
            Z85NetworkCompanyEmail = A85NetworkCompanyEmail;
            Z86NetworkCompanyPhone = A86NetworkCompanyPhone;
            Z391NetworkCompanyPhoneCode = A391NetworkCompanyPhoneCode;
            Z392NetworkCompanyPhoneNumber = A392NetworkCompanyPhoneNumber;
            Z349NetworkCompanyCountry = A349NetworkCompanyCountry;
            Z350NetworkCompanyCity = A350NetworkCompanyCity;
            Z351NetworkCompanyZipCode = A351NetworkCompanyZipCode;
            Z352NetworkCompanyAddressLine1 = A352NetworkCompanyAddressLine1;
            Z353NetworkCompanyAddressLine2 = A353NetworkCompanyAddressLine2;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A82NetworkCompanyId) )
         {
            A82NetworkCompanyId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0B19( )
      {
         /* Using cursor BC000B4 */
         pr_default.execute(2, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A83NetworkCompanyKvkNumber = BC000B4_A83NetworkCompanyKvkNumber[0];
            A84NetworkCompanyName = BC000B4_A84NetworkCompanyName[0];
            A85NetworkCompanyEmail = BC000B4_A85NetworkCompanyEmail[0];
            A86NetworkCompanyPhone = BC000B4_A86NetworkCompanyPhone[0];
            A391NetworkCompanyPhoneCode = BC000B4_A391NetworkCompanyPhoneCode[0];
            A392NetworkCompanyPhoneNumber = BC000B4_A392NetworkCompanyPhoneNumber[0];
            A349NetworkCompanyCountry = BC000B4_A349NetworkCompanyCountry[0];
            A350NetworkCompanyCity = BC000B4_A350NetworkCompanyCity[0];
            A351NetworkCompanyZipCode = BC000B4_A351NetworkCompanyZipCode[0];
            A352NetworkCompanyAddressLine1 = BC000B4_A352NetworkCompanyAddressLine1[0];
            A353NetworkCompanyAddressLine2 = BC000B4_A353NetworkCompanyAddressLine2[0];
            ZM0B19( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0B19( ) ;
      }

      protected void OnLoadActions0B19( )
      {
      }

      protected void CheckExtendedTable0B19( )
      {
         standaloneModal( ) ;
         if ( StringUtil.Len( A83NetworkCompanyKvkNumber) != 8 )
         {
            GX_msglist.addItem(context.GetMessage( "KVK number contains 8 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A85NetworkCompanyEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Network Company Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A392NetworkCompanyPhoneNumber,"\\b\\d{9}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Phone contains 9 digits", ""), context.GetMessage( "Network Company Phone Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0B19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B19( )
      {
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {A82NetworkCompanyId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B19( 6) ;
            RcdFound19 = 1;
            A82NetworkCompanyId = BC000B3_A82NetworkCompanyId[0];
            A83NetworkCompanyKvkNumber = BC000B3_A83NetworkCompanyKvkNumber[0];
            A84NetworkCompanyName = BC000B3_A84NetworkCompanyName[0];
            A85NetworkCompanyEmail = BC000B3_A85NetworkCompanyEmail[0];
            A86NetworkCompanyPhone = BC000B3_A86NetworkCompanyPhone[0];
            A391NetworkCompanyPhoneCode = BC000B3_A391NetworkCompanyPhoneCode[0];
            A392NetworkCompanyPhoneNumber = BC000B3_A392NetworkCompanyPhoneNumber[0];
            A349NetworkCompanyCountry = BC000B3_A349NetworkCompanyCountry[0];
            A350NetworkCompanyCity = BC000B3_A350NetworkCompanyCity[0];
            A351NetworkCompanyZipCode = BC000B3_A351NetworkCompanyZipCode[0];
            A352NetworkCompanyAddressLine1 = BC000B3_A352NetworkCompanyAddressLine1[0];
            A353NetworkCompanyAddressLine2 = BC000B3_A353NetworkCompanyAddressLine2[0];
            Z82NetworkCompanyId = A82NetworkCompanyId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0B19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0B19( ) ;
            }
            Gx_mode = sMode19;
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0B19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode19;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B19( ) ;
         if ( RcdFound19 == 0 )
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
         CONFIRM_0B0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0B19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {A82NetworkCompanyId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_NetworkCompany"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z83NetworkCompanyKvkNumber, BC000B2_A83NetworkCompanyKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z84NetworkCompanyName, BC000B2_A84NetworkCompanyName[0]) != 0 ) || ( StringUtil.StrCmp(Z85NetworkCompanyEmail, BC000B2_A85NetworkCompanyEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z86NetworkCompanyPhone, BC000B2_A86NetworkCompanyPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z391NetworkCompanyPhoneCode, BC000B2_A391NetworkCompanyPhoneCode[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z392NetworkCompanyPhoneNumber, BC000B2_A392NetworkCompanyPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z349NetworkCompanyCountry, BC000B2_A349NetworkCompanyCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z350NetworkCompanyCity, BC000B2_A350NetworkCompanyCity[0]) != 0 ) || ( StringUtil.StrCmp(Z351NetworkCompanyZipCode, BC000B2_A351NetworkCompanyZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z352NetworkCompanyAddressLine1, BC000B2_A352NetworkCompanyAddressLine1[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z353NetworkCompanyAddressLine2, BC000B2_A353NetworkCompanyAddressLine2[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_NetworkCompany"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B19( )
      {
         BeforeValidate0B19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B19( 0) ;
            CheckOptimisticConcurrency0B19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B6 */
                     pr_default.execute(4, new Object[] {A82NetworkCompanyId, A83NetworkCompanyKvkNumber, A84NetworkCompanyName, A85NetworkCompanyEmail, A86NetworkCompanyPhone, A391NetworkCompanyPhoneCode, A392NetworkCompanyPhoneNumber, A349NetworkCompanyCountry, A350NetworkCompanyCity, A351NetworkCompanyZipCode, A352NetworkCompanyAddressLine1, A353NetworkCompanyAddressLine2});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkCompany");
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
               Load0B19( ) ;
            }
            EndLevel0B19( ) ;
         }
         CloseExtendedTableCursors0B19( ) ;
      }

      protected void Update0B19( )
      {
         BeforeValidate0B19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B7 */
                     pr_default.execute(5, new Object[] {A83NetworkCompanyKvkNumber, A84NetworkCompanyName, A85NetworkCompanyEmail, A86NetworkCompanyPhone, A391NetworkCompanyPhoneCode, A392NetworkCompanyPhoneNumber, A349NetworkCompanyCountry, A350NetworkCompanyCity, A351NetworkCompanyZipCode, A352NetworkCompanyAddressLine1, A353NetworkCompanyAddressLine2, A82NetworkCompanyId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkCompany");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_NetworkCompany"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B19( ) ;
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
            EndLevel0B19( ) ;
         }
         CloseExtendedTableCursors0B19( ) ;
      }

      protected void DeferredUpdate0B19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B19( ) ;
            AfterConfirm0B19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B8 */
                  pr_default.execute(6, new Object[] {A82NetworkCompanyId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkCompany");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B19( ) ;
         Gx_mode = sMode19;
      }

      protected void OnDeleteControls0B19( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000B9 */
            pr_default.execute(7, new Object[] {A82NetworkCompanyId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_ResidentNetworkCompany", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0B19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B19( ) ;
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

      public void ScanKeyStart0B19( )
      {
         /* Using cursor BC000B10 */
         pr_default.execute(8, new Object[] {A82NetworkCompanyId});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound19 = 1;
            A82NetworkCompanyId = BC000B10_A82NetworkCompanyId[0];
            A83NetworkCompanyKvkNumber = BC000B10_A83NetworkCompanyKvkNumber[0];
            A84NetworkCompanyName = BC000B10_A84NetworkCompanyName[0];
            A85NetworkCompanyEmail = BC000B10_A85NetworkCompanyEmail[0];
            A86NetworkCompanyPhone = BC000B10_A86NetworkCompanyPhone[0];
            A391NetworkCompanyPhoneCode = BC000B10_A391NetworkCompanyPhoneCode[0];
            A392NetworkCompanyPhoneNumber = BC000B10_A392NetworkCompanyPhoneNumber[0];
            A349NetworkCompanyCountry = BC000B10_A349NetworkCompanyCountry[0];
            A350NetworkCompanyCity = BC000B10_A350NetworkCompanyCity[0];
            A351NetworkCompanyZipCode = BC000B10_A351NetworkCompanyZipCode[0];
            A352NetworkCompanyAddressLine1 = BC000B10_A352NetworkCompanyAddressLine1[0];
            A353NetworkCompanyAddressLine2 = BC000B10_A353NetworkCompanyAddressLine2[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B19( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound19 = 0;
         ScanKeyLoad0B19( ) ;
      }

      protected void ScanKeyLoad0B19( )
      {
         sMode19 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound19 = 1;
            A82NetworkCompanyId = BC000B10_A82NetworkCompanyId[0];
            A83NetworkCompanyKvkNumber = BC000B10_A83NetworkCompanyKvkNumber[0];
            A84NetworkCompanyName = BC000B10_A84NetworkCompanyName[0];
            A85NetworkCompanyEmail = BC000B10_A85NetworkCompanyEmail[0];
            A86NetworkCompanyPhone = BC000B10_A86NetworkCompanyPhone[0];
            A391NetworkCompanyPhoneCode = BC000B10_A391NetworkCompanyPhoneCode[0];
            A392NetworkCompanyPhoneNumber = BC000B10_A392NetworkCompanyPhoneNumber[0];
            A349NetworkCompanyCountry = BC000B10_A349NetworkCompanyCountry[0];
            A350NetworkCompanyCity = BC000B10_A350NetworkCompanyCity[0];
            A351NetworkCompanyZipCode = BC000B10_A351NetworkCompanyZipCode[0];
            A352NetworkCompanyAddressLine1 = BC000B10_A352NetworkCompanyAddressLine1[0];
            A353NetworkCompanyAddressLine2 = BC000B10_A353NetworkCompanyAddressLine2[0];
         }
         Gx_mode = sMode19;
      }

      protected void ScanKeyEnd0B19( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0B19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B19( )
      {
      }

      protected void send_integrity_lvl_hashes0B19( )
      {
      }

      protected void AddRow0B19( )
      {
         VarsToRow19( bcTrn_NetworkCompany) ;
      }

      protected void ReadRow0B19( )
      {
         RowToVars19( bcTrn_NetworkCompany, 1) ;
      }

      protected void InitializeNonKey0B19( )
      {
         A83NetworkCompanyKvkNumber = "";
         A84NetworkCompanyName = "";
         A85NetworkCompanyEmail = "";
         A86NetworkCompanyPhone = "";
         A391NetworkCompanyPhoneCode = "";
         A392NetworkCompanyPhoneNumber = "";
         A349NetworkCompanyCountry = "";
         A350NetworkCompanyCity = "";
         A351NetworkCompanyZipCode = "";
         A352NetworkCompanyAddressLine1 = "";
         A353NetworkCompanyAddressLine2 = "";
         Z83NetworkCompanyKvkNumber = "";
         Z84NetworkCompanyName = "";
         Z85NetworkCompanyEmail = "";
         Z86NetworkCompanyPhone = "";
         Z391NetworkCompanyPhoneCode = "";
         Z392NetworkCompanyPhoneNumber = "";
         Z349NetworkCompanyCountry = "";
         Z350NetworkCompanyCity = "";
         Z351NetworkCompanyZipCode = "";
         Z352NetworkCompanyAddressLine1 = "";
         Z353NetworkCompanyAddressLine2 = "";
      }

      protected void InitAll0B19( )
      {
         A82NetworkCompanyId = Guid.NewGuid( );
         InitializeNonKey0B19( ) ;
      }

      protected void StandaloneModalInsert( )
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

      public void VarsToRow19( SdtTrn_NetworkCompany obj19 )
      {
         obj19.gxTpr_Mode = Gx_mode;
         obj19.gxTpr_Networkcompanykvknumber = A83NetworkCompanyKvkNumber;
         obj19.gxTpr_Networkcompanyname = A84NetworkCompanyName;
         obj19.gxTpr_Networkcompanyemail = A85NetworkCompanyEmail;
         obj19.gxTpr_Networkcompanyphone = A86NetworkCompanyPhone;
         obj19.gxTpr_Networkcompanyphonecode = A391NetworkCompanyPhoneCode;
         obj19.gxTpr_Networkcompanyphonenumber = A392NetworkCompanyPhoneNumber;
         obj19.gxTpr_Networkcompanycountry = A349NetworkCompanyCountry;
         obj19.gxTpr_Networkcompanycity = A350NetworkCompanyCity;
         obj19.gxTpr_Networkcompanyzipcode = A351NetworkCompanyZipCode;
         obj19.gxTpr_Networkcompanyaddressline1 = A352NetworkCompanyAddressLine1;
         obj19.gxTpr_Networkcompanyaddressline2 = A353NetworkCompanyAddressLine2;
         obj19.gxTpr_Networkcompanyid = A82NetworkCompanyId;
         obj19.gxTpr_Networkcompanyid_Z = Z82NetworkCompanyId;
         obj19.gxTpr_Networkcompanykvknumber_Z = Z83NetworkCompanyKvkNumber;
         obj19.gxTpr_Networkcompanyname_Z = Z84NetworkCompanyName;
         obj19.gxTpr_Networkcompanyemail_Z = Z85NetworkCompanyEmail;
         obj19.gxTpr_Networkcompanyphone_Z = Z86NetworkCompanyPhone;
         obj19.gxTpr_Networkcompanyphonecode_Z = Z391NetworkCompanyPhoneCode;
         obj19.gxTpr_Networkcompanyphonenumber_Z = Z392NetworkCompanyPhoneNumber;
         obj19.gxTpr_Networkcompanycountry_Z = Z349NetworkCompanyCountry;
         obj19.gxTpr_Networkcompanycity_Z = Z350NetworkCompanyCity;
         obj19.gxTpr_Networkcompanyzipcode_Z = Z351NetworkCompanyZipCode;
         obj19.gxTpr_Networkcompanyaddressline1_Z = Z352NetworkCompanyAddressLine1;
         obj19.gxTpr_Networkcompanyaddressline2_Z = Z353NetworkCompanyAddressLine2;
         obj19.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow19( SdtTrn_NetworkCompany obj19 )
      {
         obj19.gxTpr_Networkcompanyid = A82NetworkCompanyId;
         return  ;
      }

      public void RowToVars19( SdtTrn_NetworkCompany obj19 ,
                               int forceLoad )
      {
         Gx_mode = obj19.gxTpr_Mode;
         A83NetworkCompanyKvkNumber = obj19.gxTpr_Networkcompanykvknumber;
         A84NetworkCompanyName = obj19.gxTpr_Networkcompanyname;
         A85NetworkCompanyEmail = obj19.gxTpr_Networkcompanyemail;
         A86NetworkCompanyPhone = obj19.gxTpr_Networkcompanyphone;
         A391NetworkCompanyPhoneCode = obj19.gxTpr_Networkcompanyphonecode;
         A392NetworkCompanyPhoneNumber = obj19.gxTpr_Networkcompanyphonenumber;
         A349NetworkCompanyCountry = obj19.gxTpr_Networkcompanycountry;
         A350NetworkCompanyCity = obj19.gxTpr_Networkcompanycity;
         A351NetworkCompanyZipCode = obj19.gxTpr_Networkcompanyzipcode;
         A352NetworkCompanyAddressLine1 = obj19.gxTpr_Networkcompanyaddressline1;
         A353NetworkCompanyAddressLine2 = obj19.gxTpr_Networkcompanyaddressline2;
         A82NetworkCompanyId = obj19.gxTpr_Networkcompanyid;
         Z82NetworkCompanyId = obj19.gxTpr_Networkcompanyid_Z;
         Z83NetworkCompanyKvkNumber = obj19.gxTpr_Networkcompanykvknumber_Z;
         Z84NetworkCompanyName = obj19.gxTpr_Networkcompanyname_Z;
         Z85NetworkCompanyEmail = obj19.gxTpr_Networkcompanyemail_Z;
         Z86NetworkCompanyPhone = obj19.gxTpr_Networkcompanyphone_Z;
         Z391NetworkCompanyPhoneCode = obj19.gxTpr_Networkcompanyphonecode_Z;
         Z392NetworkCompanyPhoneNumber = obj19.gxTpr_Networkcompanyphonenumber_Z;
         Z349NetworkCompanyCountry = obj19.gxTpr_Networkcompanycountry_Z;
         Z350NetworkCompanyCity = obj19.gxTpr_Networkcompanycity_Z;
         Z351NetworkCompanyZipCode = obj19.gxTpr_Networkcompanyzipcode_Z;
         Z352NetworkCompanyAddressLine1 = obj19.gxTpr_Networkcompanyaddressline1_Z;
         Z353NetworkCompanyAddressLine2 = obj19.gxTpr_Networkcompanyaddressline2_Z;
         Gx_mode = obj19.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A82NetworkCompanyId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B19( ) ;
         ScanKeyStart0B19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z82NetworkCompanyId = A82NetworkCompanyId;
         }
         ZM0B19( -6) ;
         OnLoadActions0B19( ) ;
         AddRow0B19( ) ;
         ScanKeyEnd0B19( ) ;
         if ( RcdFound19 == 0 )
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
         RowToVars19( bcTrn_NetworkCompany, 0) ;
         ScanKeyStart0B19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z82NetworkCompanyId = A82NetworkCompanyId;
         }
         ZM0B19( -6) ;
         OnLoadActions0B19( ) ;
         AddRow0B19( ) ;
         ScanKeyEnd0B19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0B19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0B19( ) ;
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( A82NetworkCompanyId != Z82NetworkCompanyId )
               {
                  A82NetworkCompanyId = Z82NetworkCompanyId;
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
                  Update0B19( ) ;
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
                  if ( A82NetworkCompanyId != Z82NetworkCompanyId )
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
                        Insert0B19( ) ;
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
                        Insert0B19( ) ;
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
         RowToVars19( bcTrn_NetworkCompany, 1) ;
         SaveImpl( ) ;
         VarsToRow19( bcTrn_NetworkCompany) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars19( bcTrn_NetworkCompany, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B19( ) ;
         AfterTrn( ) ;
         VarsToRow19( bcTrn_NetworkCompany) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow19( bcTrn_NetworkCompany) ;
         }
         else
         {
            SdtTrn_NetworkCompany auxBC = new SdtTrn_NetworkCompany(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A82NetworkCompanyId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_NetworkCompany);
               auxBC.Save();
               bcTrn_NetworkCompany.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars19( bcTrn_NetworkCompany, 1) ;
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
         RowToVars19( bcTrn_NetworkCompany, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B19( ) ;
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
               VarsToRow19( bcTrn_NetworkCompany) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow19( bcTrn_NetworkCompany) ;
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
         RowToVars19( bcTrn_NetworkCompany, 0) ;
         GetKey0B19( ) ;
         if ( RcdFound19 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A82NetworkCompanyId != Z82NetworkCompanyId )
            {
               A82NetworkCompanyId = Z82NetworkCompanyId;
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
            if ( A82NetworkCompanyId != Z82NetworkCompanyId )
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
         context.RollbackDataStores("trn_networkcompany_bc",pr_default);
         VarsToRow19( bcTrn_NetworkCompany) ;
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
         Gx_mode = bcTrn_NetworkCompany.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_NetworkCompany.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_NetworkCompany )
         {
            bcTrn_NetworkCompany = (SdtTrn_NetworkCompany)(sdt);
            if ( StringUtil.StrCmp(bcTrn_NetworkCompany.gxTpr_Mode, "") == 0 )
            {
               bcTrn_NetworkCompany.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow19( bcTrn_NetworkCompany) ;
            }
            else
            {
               RowToVars19( bcTrn_NetworkCompany, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_NetworkCompany.gxTpr_Mode, "") == 0 )
            {
               bcTrn_NetworkCompany.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars19( bcTrn_NetworkCompany, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_NetworkCompany Trn_NetworkCompany_BC
      {
         get {
            return bcTrn_NetworkCompany ;
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
            return "trn_networkcompany_Execute" ;
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
         Z82NetworkCompanyId = Guid.Empty;
         A82NetworkCompanyId = Guid.Empty;
         Z83NetworkCompanyKvkNumber = "";
         A83NetworkCompanyKvkNumber = "";
         Z84NetworkCompanyName = "";
         A84NetworkCompanyName = "";
         Z85NetworkCompanyEmail = "";
         A85NetworkCompanyEmail = "";
         Z86NetworkCompanyPhone = "";
         A86NetworkCompanyPhone = "";
         Z391NetworkCompanyPhoneCode = "";
         A391NetworkCompanyPhoneCode = "";
         Z392NetworkCompanyPhoneNumber = "";
         A392NetworkCompanyPhoneNumber = "";
         Z349NetworkCompanyCountry = "";
         A349NetworkCompanyCountry = "";
         Z350NetworkCompanyCity = "";
         A350NetworkCompanyCity = "";
         Z351NetworkCompanyZipCode = "";
         A351NetworkCompanyZipCode = "";
         Z352NetworkCompanyAddressLine1 = "";
         A352NetworkCompanyAddressLine1 = "";
         Z353NetworkCompanyAddressLine2 = "";
         A353NetworkCompanyAddressLine2 = "";
         BC000B4_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         BC000B4_A83NetworkCompanyKvkNumber = new string[] {""} ;
         BC000B4_A84NetworkCompanyName = new string[] {""} ;
         BC000B4_A85NetworkCompanyEmail = new string[] {""} ;
         BC000B4_A86NetworkCompanyPhone = new string[] {""} ;
         BC000B4_A391NetworkCompanyPhoneCode = new string[] {""} ;
         BC000B4_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         BC000B4_A349NetworkCompanyCountry = new string[] {""} ;
         BC000B4_A350NetworkCompanyCity = new string[] {""} ;
         BC000B4_A351NetworkCompanyZipCode = new string[] {""} ;
         BC000B4_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         BC000B4_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         BC000B5_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         BC000B3_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         BC000B3_A83NetworkCompanyKvkNumber = new string[] {""} ;
         BC000B3_A84NetworkCompanyName = new string[] {""} ;
         BC000B3_A85NetworkCompanyEmail = new string[] {""} ;
         BC000B3_A86NetworkCompanyPhone = new string[] {""} ;
         BC000B3_A391NetworkCompanyPhoneCode = new string[] {""} ;
         BC000B3_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         BC000B3_A349NetworkCompanyCountry = new string[] {""} ;
         BC000B3_A350NetworkCompanyCity = new string[] {""} ;
         BC000B3_A351NetworkCompanyZipCode = new string[] {""} ;
         BC000B3_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         BC000B3_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         sMode19 = "";
         BC000B2_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         BC000B2_A83NetworkCompanyKvkNumber = new string[] {""} ;
         BC000B2_A84NetworkCompanyName = new string[] {""} ;
         BC000B2_A85NetworkCompanyEmail = new string[] {""} ;
         BC000B2_A86NetworkCompanyPhone = new string[] {""} ;
         BC000B2_A391NetworkCompanyPhoneCode = new string[] {""} ;
         BC000B2_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         BC000B2_A349NetworkCompanyCountry = new string[] {""} ;
         BC000B2_A350NetworkCompanyCity = new string[] {""} ;
         BC000B2_A351NetworkCompanyZipCode = new string[] {""} ;
         BC000B2_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         BC000B2_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         BC000B9_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         BC000B9_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000B9_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000B9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000B10_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         BC000B10_A83NetworkCompanyKvkNumber = new string[] {""} ;
         BC000B10_A84NetworkCompanyName = new string[] {""} ;
         BC000B10_A85NetworkCompanyEmail = new string[] {""} ;
         BC000B10_A86NetworkCompanyPhone = new string[] {""} ;
         BC000B10_A391NetworkCompanyPhoneCode = new string[] {""} ;
         BC000B10_A392NetworkCompanyPhoneNumber = new string[] {""} ;
         BC000B10_A349NetworkCompanyCountry = new string[] {""} ;
         BC000B10_A350NetworkCompanyCity = new string[] {""} ;
         BC000B10_A351NetworkCompanyZipCode = new string[] {""} ;
         BC000B10_A352NetworkCompanyAddressLine1 = new string[] {""} ;
         BC000B10_A353NetworkCompanyAddressLine2 = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_networkcompany_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_networkcompany_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A82NetworkCompanyId, BC000B2_A83NetworkCompanyKvkNumber, BC000B2_A84NetworkCompanyName, BC000B2_A85NetworkCompanyEmail, BC000B2_A86NetworkCompanyPhone, BC000B2_A391NetworkCompanyPhoneCode, BC000B2_A392NetworkCompanyPhoneNumber, BC000B2_A349NetworkCompanyCountry, BC000B2_A350NetworkCompanyCity, BC000B2_A351NetworkCompanyZipCode,
               BC000B2_A352NetworkCompanyAddressLine1, BC000B2_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               BC000B3_A82NetworkCompanyId, BC000B3_A83NetworkCompanyKvkNumber, BC000B3_A84NetworkCompanyName, BC000B3_A85NetworkCompanyEmail, BC000B3_A86NetworkCompanyPhone, BC000B3_A391NetworkCompanyPhoneCode, BC000B3_A392NetworkCompanyPhoneNumber, BC000B3_A349NetworkCompanyCountry, BC000B3_A350NetworkCompanyCity, BC000B3_A351NetworkCompanyZipCode,
               BC000B3_A352NetworkCompanyAddressLine1, BC000B3_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               BC000B4_A82NetworkCompanyId, BC000B4_A83NetworkCompanyKvkNumber, BC000B4_A84NetworkCompanyName, BC000B4_A85NetworkCompanyEmail, BC000B4_A86NetworkCompanyPhone, BC000B4_A391NetworkCompanyPhoneCode, BC000B4_A392NetworkCompanyPhoneNumber, BC000B4_A349NetworkCompanyCountry, BC000B4_A350NetworkCompanyCity, BC000B4_A351NetworkCompanyZipCode,
               BC000B4_A352NetworkCompanyAddressLine1, BC000B4_A353NetworkCompanyAddressLine2
               }
               , new Object[] {
               BC000B5_A82NetworkCompanyId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B9_A82NetworkCompanyId, BC000B9_A62ResidentId, BC000B9_A29LocationId, BC000B9_A11OrganisationId
               }
               , new Object[] {
               BC000B10_A82NetworkCompanyId, BC000B10_A83NetworkCompanyKvkNumber, BC000B10_A84NetworkCompanyName, BC000B10_A85NetworkCompanyEmail, BC000B10_A86NetworkCompanyPhone, BC000B10_A391NetworkCompanyPhoneCode, BC000B10_A392NetworkCompanyPhoneNumber, BC000B10_A349NetworkCompanyCountry, BC000B10_A350NetworkCompanyCity, BC000B10_A351NetworkCompanyZipCode,
               BC000B10_A352NetworkCompanyAddressLine1, BC000B10_A353NetworkCompanyAddressLine2
               }
            }
         );
         Z82NetworkCompanyId = Guid.NewGuid( );
         A82NetworkCompanyId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound19 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z86NetworkCompanyPhone ;
      private string A86NetworkCompanyPhone ;
      private string sMode19 ;
      private bool Gx_longc ;
      private string Z83NetworkCompanyKvkNumber ;
      private string A83NetworkCompanyKvkNumber ;
      private string Z84NetworkCompanyName ;
      private string A84NetworkCompanyName ;
      private string Z85NetworkCompanyEmail ;
      private string A85NetworkCompanyEmail ;
      private string Z391NetworkCompanyPhoneCode ;
      private string A391NetworkCompanyPhoneCode ;
      private string Z392NetworkCompanyPhoneNumber ;
      private string A392NetworkCompanyPhoneNumber ;
      private string Z349NetworkCompanyCountry ;
      private string A349NetworkCompanyCountry ;
      private string Z350NetworkCompanyCity ;
      private string A350NetworkCompanyCity ;
      private string Z351NetworkCompanyZipCode ;
      private string A351NetworkCompanyZipCode ;
      private string Z352NetworkCompanyAddressLine1 ;
      private string A352NetworkCompanyAddressLine1 ;
      private string Z353NetworkCompanyAddressLine2 ;
      private string A353NetworkCompanyAddressLine2 ;
      private Guid Z82NetworkCompanyId ;
      private Guid A82NetworkCompanyId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000B4_A82NetworkCompanyId ;
      private string[] BC000B4_A83NetworkCompanyKvkNumber ;
      private string[] BC000B4_A84NetworkCompanyName ;
      private string[] BC000B4_A85NetworkCompanyEmail ;
      private string[] BC000B4_A86NetworkCompanyPhone ;
      private string[] BC000B4_A391NetworkCompanyPhoneCode ;
      private string[] BC000B4_A392NetworkCompanyPhoneNumber ;
      private string[] BC000B4_A349NetworkCompanyCountry ;
      private string[] BC000B4_A350NetworkCompanyCity ;
      private string[] BC000B4_A351NetworkCompanyZipCode ;
      private string[] BC000B4_A352NetworkCompanyAddressLine1 ;
      private string[] BC000B4_A353NetworkCompanyAddressLine2 ;
      private Guid[] BC000B5_A82NetworkCompanyId ;
      private Guid[] BC000B3_A82NetworkCompanyId ;
      private string[] BC000B3_A83NetworkCompanyKvkNumber ;
      private string[] BC000B3_A84NetworkCompanyName ;
      private string[] BC000B3_A85NetworkCompanyEmail ;
      private string[] BC000B3_A86NetworkCompanyPhone ;
      private string[] BC000B3_A391NetworkCompanyPhoneCode ;
      private string[] BC000B3_A392NetworkCompanyPhoneNumber ;
      private string[] BC000B3_A349NetworkCompanyCountry ;
      private string[] BC000B3_A350NetworkCompanyCity ;
      private string[] BC000B3_A351NetworkCompanyZipCode ;
      private string[] BC000B3_A352NetworkCompanyAddressLine1 ;
      private string[] BC000B3_A353NetworkCompanyAddressLine2 ;
      private Guid[] BC000B2_A82NetworkCompanyId ;
      private string[] BC000B2_A83NetworkCompanyKvkNumber ;
      private string[] BC000B2_A84NetworkCompanyName ;
      private string[] BC000B2_A85NetworkCompanyEmail ;
      private string[] BC000B2_A86NetworkCompanyPhone ;
      private string[] BC000B2_A391NetworkCompanyPhoneCode ;
      private string[] BC000B2_A392NetworkCompanyPhoneNumber ;
      private string[] BC000B2_A349NetworkCompanyCountry ;
      private string[] BC000B2_A350NetworkCompanyCity ;
      private string[] BC000B2_A351NetworkCompanyZipCode ;
      private string[] BC000B2_A352NetworkCompanyAddressLine1 ;
      private string[] BC000B2_A353NetworkCompanyAddressLine2 ;
      private Guid[] BC000B9_A82NetworkCompanyId ;
      private Guid[] BC000B9_A62ResidentId ;
      private Guid[] BC000B9_A29LocationId ;
      private Guid[] BC000B9_A11OrganisationId ;
      private Guid[] BC000B10_A82NetworkCompanyId ;
      private string[] BC000B10_A83NetworkCompanyKvkNumber ;
      private string[] BC000B10_A84NetworkCompanyName ;
      private string[] BC000B10_A85NetworkCompanyEmail ;
      private string[] BC000B10_A86NetworkCompanyPhone ;
      private string[] BC000B10_A391NetworkCompanyPhoneCode ;
      private string[] BC000B10_A392NetworkCompanyPhoneNumber ;
      private string[] BC000B10_A349NetworkCompanyCountry ;
      private string[] BC000B10_A350NetworkCompanyCity ;
      private string[] BC000B10_A351NetworkCompanyZipCode ;
      private string[] BC000B10_A352NetworkCompanyAddressLine1 ;
      private string[] BC000B10_A353NetworkCompanyAddressLine2 ;
      private SdtTrn_NetworkCompany bcTrn_NetworkCompany ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_networkcompany_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_networkcompany_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000B2;
        prmBC000B2 = new Object[] {
        new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000B3;
        prmBC000B3 = new Object[] {
        new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000B4;
        prmBC000B4 = new Object[] {
        new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000B5;
        prmBC000B5 = new Object[] {
        new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000B6;
        prmBC000B6 = new Object[] {
        new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NetworkCompanyKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("NetworkCompanyName",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyEmail",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyPhone",GXType.Char,20,0) ,
        new ParDef("NetworkCompanyPhoneCode",GXType.VarChar,40,0) ,
        new ParDef("NetworkCompanyPhoneNumber",GXType.VarChar,9,0) ,
        new ParDef("NetworkCompanyCountry",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyCity",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyZipCode",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyAddressLine1",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyAddressLine2",GXType.VarChar,100,0)
        };
        Object[] prmBC000B7;
        prmBC000B7 = new Object[] {
        new ParDef("NetworkCompanyKvkNumber",GXType.VarChar,8,0) ,
        new ParDef("NetworkCompanyName",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyEmail",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyPhone",GXType.Char,20,0) ,
        new ParDef("NetworkCompanyPhoneCode",GXType.VarChar,40,0) ,
        new ParDef("NetworkCompanyPhoneNumber",GXType.VarChar,9,0) ,
        new ParDef("NetworkCompanyCountry",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyCity",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyZipCode",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyAddressLine1",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyAddressLine2",GXType.VarChar,100,0) ,
        new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000B8;
        prmBC000B8 = new Object[] {
        new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000B9;
        prmBC000B9 = new Object[] {
        new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000B10;
        prmBC000B10 = new Object[] {
        new ParDef("NetworkCompanyId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000B2", "SELECT NetworkCompanyId, NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneCode, NetworkCompanyPhoneNumber, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2 FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId  FOR UPDATE OF Trn_NetworkCompany",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B3", "SELECT NetworkCompanyId, NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneCode, NetworkCompanyPhoneNumber, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2 FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B4", "SELECT TM1.NetworkCompanyId, TM1.NetworkCompanyKvkNumber, TM1.NetworkCompanyName, TM1.NetworkCompanyEmail, TM1.NetworkCompanyPhone, TM1.NetworkCompanyPhoneCode, TM1.NetworkCompanyPhoneNumber, TM1.NetworkCompanyCountry, TM1.NetworkCompanyCity, TM1.NetworkCompanyZipCode, TM1.NetworkCompanyAddressLine1, TM1.NetworkCompanyAddressLine2 FROM Trn_NetworkCompany TM1 WHERE TM1.NetworkCompanyId = :NetworkCompanyId ORDER BY TM1.NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B5", "SELECT NetworkCompanyId FROM Trn_NetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B6", "SAVEPOINT gxupdate;INSERT INTO Trn_NetworkCompany(NetworkCompanyId, NetworkCompanyKvkNumber, NetworkCompanyName, NetworkCompanyEmail, NetworkCompanyPhone, NetworkCompanyPhoneCode, NetworkCompanyPhoneNumber, NetworkCompanyCountry, NetworkCompanyCity, NetworkCompanyZipCode, NetworkCompanyAddressLine1, NetworkCompanyAddressLine2) VALUES(:NetworkCompanyId, :NetworkCompanyKvkNumber, :NetworkCompanyName, :NetworkCompanyEmail, :NetworkCompanyPhone, :NetworkCompanyPhoneCode, :NetworkCompanyPhoneNumber, :NetworkCompanyCountry, :NetworkCompanyCity, :NetworkCompanyZipCode, :NetworkCompanyAddressLine1, :NetworkCompanyAddressLine2);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000B6)
           ,new CursorDef("BC000B7", "SAVEPOINT gxupdate;UPDATE Trn_NetworkCompany SET NetworkCompanyKvkNumber=:NetworkCompanyKvkNumber, NetworkCompanyName=:NetworkCompanyName, NetworkCompanyEmail=:NetworkCompanyEmail, NetworkCompanyPhone=:NetworkCompanyPhone, NetworkCompanyPhoneCode=:NetworkCompanyPhoneCode, NetworkCompanyPhoneNumber=:NetworkCompanyPhoneNumber, NetworkCompanyCountry=:NetworkCompanyCountry, NetworkCompanyCity=:NetworkCompanyCity, NetworkCompanyZipCode=:NetworkCompanyZipCode, NetworkCompanyAddressLine1=:NetworkCompanyAddressLine1, NetworkCompanyAddressLine2=:NetworkCompanyAddressLine2  WHERE NetworkCompanyId = :NetworkCompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B7)
           ,new CursorDef("BC000B8", "SAVEPOINT gxupdate;DELETE FROM Trn_NetworkCompany  WHERE NetworkCompanyId = :NetworkCompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B8)
           ,new CursorDef("BC000B9", "SELECT NetworkCompanyId, ResidentId, LocationId, OrganisationId FROM Trn_ResidentNetworkCompany WHERE NetworkCompanyId = :NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000B10", "SELECT TM1.NetworkCompanyId, TM1.NetworkCompanyKvkNumber, TM1.NetworkCompanyName, TM1.NetworkCompanyEmail, TM1.NetworkCompanyPhone, TM1.NetworkCompanyPhoneCode, TM1.NetworkCompanyPhoneNumber, TM1.NetworkCompanyCountry, TM1.NetworkCompanyCity, TM1.NetworkCompanyZipCode, TM1.NetworkCompanyAddressLine1, TM1.NetworkCompanyAddressLine2 FROM Trn_NetworkCompany TM1 WHERE TM1.NetworkCompanyId = :NetworkCompanyId ORDER BY TM1.NetworkCompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B10,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              return;
     }
  }

}

}
