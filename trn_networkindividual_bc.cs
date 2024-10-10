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
   public class trn_networkindividual_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_networkindividual_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_networkindividual_bc( IGxContext context )
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
         ReadRow0A17( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0A17( ) ;
         standaloneModal( ) ;
         AddRow0A17( ) ;
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
               Z74NetworkIndividualId = A74NetworkIndividualId;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A17( ) ;
            }
            else
            {
               CheckExtendedTable0A17( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0A17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0A17( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z75NetworkIndividualBsnNumber = A75NetworkIndividualBsnNumber;
            Z76NetworkIndividualGivenName = A76NetworkIndividualGivenName;
            Z77NetworkIndividualLastName = A77NetworkIndividualLastName;
            Z78NetworkIndividualEmail = A78NetworkIndividualEmail;
            Z79NetworkIndividualPhone = A79NetworkIndividualPhone;
            Z387NetworkIndividualPhoneCode = A387NetworkIndividualPhoneCode;
            Z388NetworkIndividualPhoneNumber = A388NetworkIndividualPhoneNumber;
            Z81NetworkIndividualGender = A81NetworkIndividualGender;
            Z344NetworkIndividualCountry = A344NetworkIndividualCountry;
            Z345NetworkIndividualCity = A345NetworkIndividualCity;
            Z346NetworkIndividualZipCode = A346NetworkIndividualZipCode;
            Z347NetworkIndividualAddressLine1 = A347NetworkIndividualAddressLine1;
            Z348NetworkIndividualAddressLine2 = A348NetworkIndividualAddressLine2;
         }
         if ( GX_JID == -6 )
         {
            Z74NetworkIndividualId = A74NetworkIndividualId;
            Z75NetworkIndividualBsnNumber = A75NetworkIndividualBsnNumber;
            Z76NetworkIndividualGivenName = A76NetworkIndividualGivenName;
            Z77NetworkIndividualLastName = A77NetworkIndividualLastName;
            Z78NetworkIndividualEmail = A78NetworkIndividualEmail;
            Z79NetworkIndividualPhone = A79NetworkIndividualPhone;
            Z387NetworkIndividualPhoneCode = A387NetworkIndividualPhoneCode;
            Z388NetworkIndividualPhoneNumber = A388NetworkIndividualPhoneNumber;
            Z81NetworkIndividualGender = A81NetworkIndividualGender;
            Z344NetworkIndividualCountry = A344NetworkIndividualCountry;
            Z345NetworkIndividualCity = A345NetworkIndividualCity;
            Z346NetworkIndividualZipCode = A346NetworkIndividualZipCode;
            Z347NetworkIndividualAddressLine1 = A347NetworkIndividualAddressLine1;
            Z348NetworkIndividualAddressLine2 = A348NetworkIndividualAddressLine2;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A74NetworkIndividualId) )
         {
            A74NetworkIndividualId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0A17( )
      {
         /* Using cursor BC000A4 */
         pr_default.execute(2, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound17 = 1;
            A75NetworkIndividualBsnNumber = BC000A4_A75NetworkIndividualBsnNumber[0];
            A76NetworkIndividualGivenName = BC000A4_A76NetworkIndividualGivenName[0];
            A77NetworkIndividualLastName = BC000A4_A77NetworkIndividualLastName[0];
            A78NetworkIndividualEmail = BC000A4_A78NetworkIndividualEmail[0];
            A79NetworkIndividualPhone = BC000A4_A79NetworkIndividualPhone[0];
            A387NetworkIndividualPhoneCode = BC000A4_A387NetworkIndividualPhoneCode[0];
            A388NetworkIndividualPhoneNumber = BC000A4_A388NetworkIndividualPhoneNumber[0];
            A81NetworkIndividualGender = BC000A4_A81NetworkIndividualGender[0];
            A344NetworkIndividualCountry = BC000A4_A344NetworkIndividualCountry[0];
            A345NetworkIndividualCity = BC000A4_A345NetworkIndividualCity[0];
            A346NetworkIndividualZipCode = BC000A4_A346NetworkIndividualZipCode[0];
            A347NetworkIndividualAddressLine1 = BC000A4_A347NetworkIndividualAddressLine1[0];
            A348NetworkIndividualAddressLine2 = BC000A4_A348NetworkIndividualAddressLine2[0];
            ZM0A17( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0A17( ) ;
      }

      protected void OnLoadActions0A17( )
      {
      }

      protected void CheckExtendedTable0A17( )
      {
         standaloneModal( ) ;
         if ( StringUtil.Len( A75NetworkIndividualBsnNumber) != 9 )
         {
            GX_msglist.addItem(context.GetMessage( "BSN number contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A78NetworkIndividualEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Network Individual Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A81NetworkIndividualGender, "Male") == 0 ) || ( StringUtil.StrCmp(A81NetworkIndividualGender, "Female") == 0 ) || ( StringUtil.StrCmp(A81NetworkIndividualGender, "Other") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Network Individual Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0A17( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A17( )
      {
         /* Using cursor BC000A5 */
         pr_default.execute(3, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000A3 */
         pr_default.execute(1, new Object[] {A74NetworkIndividualId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A17( 6) ;
            RcdFound17 = 1;
            A74NetworkIndividualId = BC000A3_A74NetworkIndividualId[0];
            A75NetworkIndividualBsnNumber = BC000A3_A75NetworkIndividualBsnNumber[0];
            A76NetworkIndividualGivenName = BC000A3_A76NetworkIndividualGivenName[0];
            A77NetworkIndividualLastName = BC000A3_A77NetworkIndividualLastName[0];
            A78NetworkIndividualEmail = BC000A3_A78NetworkIndividualEmail[0];
            A79NetworkIndividualPhone = BC000A3_A79NetworkIndividualPhone[0];
            A387NetworkIndividualPhoneCode = BC000A3_A387NetworkIndividualPhoneCode[0];
            A388NetworkIndividualPhoneNumber = BC000A3_A388NetworkIndividualPhoneNumber[0];
            A81NetworkIndividualGender = BC000A3_A81NetworkIndividualGender[0];
            A344NetworkIndividualCountry = BC000A3_A344NetworkIndividualCountry[0];
            A345NetworkIndividualCity = BC000A3_A345NetworkIndividualCity[0];
            A346NetworkIndividualZipCode = BC000A3_A346NetworkIndividualZipCode[0];
            A347NetworkIndividualAddressLine1 = BC000A3_A347NetworkIndividualAddressLine1[0];
            A348NetworkIndividualAddressLine2 = BC000A3_A348NetworkIndividualAddressLine2[0];
            Z74NetworkIndividualId = A74NetworkIndividualId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0A17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0A17( ) ;
            }
            Gx_mode = sMode17;
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0A17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode17;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A17( ) ;
         if ( RcdFound17 == 0 )
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
         CONFIRM_0A0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0A17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A2 */
            pr_default.execute(0, new Object[] {A74NetworkIndividualId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_NetworkIndividual"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z75NetworkIndividualBsnNumber, BC000A2_A75NetworkIndividualBsnNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z76NetworkIndividualGivenName, BC000A2_A76NetworkIndividualGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z77NetworkIndividualLastName, BC000A2_A77NetworkIndividualLastName[0]) != 0 ) || ( StringUtil.StrCmp(Z78NetworkIndividualEmail, BC000A2_A78NetworkIndividualEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z79NetworkIndividualPhone, BC000A2_A79NetworkIndividualPhone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z387NetworkIndividualPhoneCode, BC000A2_A387NetworkIndividualPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z388NetworkIndividualPhoneNumber, BC000A2_A388NetworkIndividualPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z81NetworkIndividualGender, BC000A2_A81NetworkIndividualGender[0]) != 0 ) || ( StringUtil.StrCmp(Z344NetworkIndividualCountry, BC000A2_A344NetworkIndividualCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z345NetworkIndividualCity, BC000A2_A345NetworkIndividualCity[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z346NetworkIndividualZipCode, BC000A2_A346NetworkIndividualZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z347NetworkIndividualAddressLine1, BC000A2_A347NetworkIndividualAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z348NetworkIndividualAddressLine2, BC000A2_A348NetworkIndividualAddressLine2[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_NetworkIndividual"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A17( )
      {
         BeforeValidate0A17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A17( 0) ;
            CheckOptimisticConcurrency0A17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A6 */
                     pr_default.execute(4, new Object[] {A74NetworkIndividualId, A75NetworkIndividualBsnNumber, A76NetworkIndividualGivenName, A77NetworkIndividualLastName, A78NetworkIndividualEmail, A79NetworkIndividualPhone, A387NetworkIndividualPhoneCode, A388NetworkIndividualPhoneNumber, A81NetworkIndividualGender, A344NetworkIndividualCountry, A345NetworkIndividualCity, A346NetworkIndividualZipCode, A347NetworkIndividualAddressLine1, A348NetworkIndividualAddressLine2});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkIndividual");
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
               Load0A17( ) ;
            }
            EndLevel0A17( ) ;
         }
         CloseExtendedTableCursors0A17( ) ;
      }

      protected void Update0A17( )
      {
         BeforeValidate0A17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A7 */
                     pr_default.execute(5, new Object[] {A75NetworkIndividualBsnNumber, A76NetworkIndividualGivenName, A77NetworkIndividualLastName, A78NetworkIndividualEmail, A79NetworkIndividualPhone, A387NetworkIndividualPhoneCode, A388NetworkIndividualPhoneNumber, A81NetworkIndividualGender, A344NetworkIndividualCountry, A345NetworkIndividualCity, A346NetworkIndividualZipCode, A347NetworkIndividualAddressLine1, A348NetworkIndividualAddressLine2, A74NetworkIndividualId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkIndividual");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_NetworkIndividual"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A17( ) ;
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
            EndLevel0A17( ) ;
         }
         CloseExtendedTableCursors0A17( ) ;
      }

      protected void DeferredUpdate0A17( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A17( ) ;
            AfterConfirm0A17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A8 */
                  pr_default.execute(6, new Object[] {A74NetworkIndividualId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_NetworkIndividual");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A17( ) ;
         Gx_mode = sMode17;
      }

      protected void OnDeleteControls0A17( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000A9 */
            pr_default.execute(7, new Object[] {A74NetworkIndividualId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_ResidentNetworkIndividual", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0A17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A17( ) ;
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

      public void ScanKeyStart0A17( )
      {
         /* Using cursor BC000A10 */
         pr_default.execute(8, new Object[] {A74NetworkIndividualId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound17 = 1;
            A74NetworkIndividualId = BC000A10_A74NetworkIndividualId[0];
            A75NetworkIndividualBsnNumber = BC000A10_A75NetworkIndividualBsnNumber[0];
            A76NetworkIndividualGivenName = BC000A10_A76NetworkIndividualGivenName[0];
            A77NetworkIndividualLastName = BC000A10_A77NetworkIndividualLastName[0];
            A78NetworkIndividualEmail = BC000A10_A78NetworkIndividualEmail[0];
            A79NetworkIndividualPhone = BC000A10_A79NetworkIndividualPhone[0];
            A387NetworkIndividualPhoneCode = BC000A10_A387NetworkIndividualPhoneCode[0];
            A388NetworkIndividualPhoneNumber = BC000A10_A388NetworkIndividualPhoneNumber[0];
            A81NetworkIndividualGender = BC000A10_A81NetworkIndividualGender[0];
            A344NetworkIndividualCountry = BC000A10_A344NetworkIndividualCountry[0];
            A345NetworkIndividualCity = BC000A10_A345NetworkIndividualCity[0];
            A346NetworkIndividualZipCode = BC000A10_A346NetworkIndividualZipCode[0];
            A347NetworkIndividualAddressLine1 = BC000A10_A347NetworkIndividualAddressLine1[0];
            A348NetworkIndividualAddressLine2 = BC000A10_A348NetworkIndividualAddressLine2[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A17( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound17 = 0;
         ScanKeyLoad0A17( ) ;
      }

      protected void ScanKeyLoad0A17( )
      {
         sMode17 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound17 = 1;
            A74NetworkIndividualId = BC000A10_A74NetworkIndividualId[0];
            A75NetworkIndividualBsnNumber = BC000A10_A75NetworkIndividualBsnNumber[0];
            A76NetworkIndividualGivenName = BC000A10_A76NetworkIndividualGivenName[0];
            A77NetworkIndividualLastName = BC000A10_A77NetworkIndividualLastName[0];
            A78NetworkIndividualEmail = BC000A10_A78NetworkIndividualEmail[0];
            A79NetworkIndividualPhone = BC000A10_A79NetworkIndividualPhone[0];
            A387NetworkIndividualPhoneCode = BC000A10_A387NetworkIndividualPhoneCode[0];
            A388NetworkIndividualPhoneNumber = BC000A10_A388NetworkIndividualPhoneNumber[0];
            A81NetworkIndividualGender = BC000A10_A81NetworkIndividualGender[0];
            A344NetworkIndividualCountry = BC000A10_A344NetworkIndividualCountry[0];
            A345NetworkIndividualCity = BC000A10_A345NetworkIndividualCity[0];
            A346NetworkIndividualZipCode = BC000A10_A346NetworkIndividualZipCode[0];
            A347NetworkIndividualAddressLine1 = BC000A10_A347NetworkIndividualAddressLine1[0];
            A348NetworkIndividualAddressLine2 = BC000A10_A348NetworkIndividualAddressLine2[0];
         }
         Gx_mode = sMode17;
      }

      protected void ScanKeyEnd0A17( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0A17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A17( )
      {
      }

      protected void send_integrity_lvl_hashes0A17( )
      {
      }

      protected void AddRow0A17( )
      {
         VarsToRow17( bcTrn_NetworkIndividual) ;
      }

      protected void ReadRow0A17( )
      {
         RowToVars17( bcTrn_NetworkIndividual, 1) ;
      }

      protected void InitializeNonKey0A17( )
      {
         A75NetworkIndividualBsnNumber = "";
         A76NetworkIndividualGivenName = "";
         A77NetworkIndividualLastName = "";
         A78NetworkIndividualEmail = "";
         A79NetworkIndividualPhone = "";
         A387NetworkIndividualPhoneCode = "";
         A388NetworkIndividualPhoneNumber = "";
         A81NetworkIndividualGender = "";
         A344NetworkIndividualCountry = "";
         A345NetworkIndividualCity = "";
         A346NetworkIndividualZipCode = "";
         A347NetworkIndividualAddressLine1 = "";
         A348NetworkIndividualAddressLine2 = "";
         Z75NetworkIndividualBsnNumber = "";
         Z76NetworkIndividualGivenName = "";
         Z77NetworkIndividualLastName = "";
         Z78NetworkIndividualEmail = "";
         Z79NetworkIndividualPhone = "";
         Z387NetworkIndividualPhoneCode = "";
         Z388NetworkIndividualPhoneNumber = "";
         Z81NetworkIndividualGender = "";
         Z344NetworkIndividualCountry = "";
         Z345NetworkIndividualCity = "";
         Z346NetworkIndividualZipCode = "";
         Z347NetworkIndividualAddressLine1 = "";
         Z348NetworkIndividualAddressLine2 = "";
      }

      protected void InitAll0A17( )
      {
         A74NetworkIndividualId = Guid.NewGuid( );
         InitializeNonKey0A17( ) ;
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

      public void VarsToRow17( SdtTrn_NetworkIndividual obj17 )
      {
         obj17.gxTpr_Mode = Gx_mode;
         obj17.gxTpr_Networkindividualbsnnumber = A75NetworkIndividualBsnNumber;
         obj17.gxTpr_Networkindividualgivenname = A76NetworkIndividualGivenName;
         obj17.gxTpr_Networkindividuallastname = A77NetworkIndividualLastName;
         obj17.gxTpr_Networkindividualemail = A78NetworkIndividualEmail;
         obj17.gxTpr_Networkindividualphone = A79NetworkIndividualPhone;
         obj17.gxTpr_Networkindividualphonecode = A387NetworkIndividualPhoneCode;
         obj17.gxTpr_Networkindividualphonenumber = A388NetworkIndividualPhoneNumber;
         obj17.gxTpr_Networkindividualgender = A81NetworkIndividualGender;
         obj17.gxTpr_Networkindividualcountry = A344NetworkIndividualCountry;
         obj17.gxTpr_Networkindividualcity = A345NetworkIndividualCity;
         obj17.gxTpr_Networkindividualzipcode = A346NetworkIndividualZipCode;
         obj17.gxTpr_Networkindividualaddressline1 = A347NetworkIndividualAddressLine1;
         obj17.gxTpr_Networkindividualaddressline2 = A348NetworkIndividualAddressLine2;
         obj17.gxTpr_Networkindividualid = A74NetworkIndividualId;
         obj17.gxTpr_Networkindividualid_Z = Z74NetworkIndividualId;
         obj17.gxTpr_Networkindividualbsnnumber_Z = Z75NetworkIndividualBsnNumber;
         obj17.gxTpr_Networkindividualgivenname_Z = Z76NetworkIndividualGivenName;
         obj17.gxTpr_Networkindividuallastname_Z = Z77NetworkIndividualLastName;
         obj17.gxTpr_Networkindividualemail_Z = Z78NetworkIndividualEmail;
         obj17.gxTpr_Networkindividualphone_Z = Z79NetworkIndividualPhone;
         obj17.gxTpr_Networkindividualphonecode_Z = Z387NetworkIndividualPhoneCode;
         obj17.gxTpr_Networkindividualphonenumber_Z = Z388NetworkIndividualPhoneNumber;
         obj17.gxTpr_Networkindividualgender_Z = Z81NetworkIndividualGender;
         obj17.gxTpr_Networkindividualcountry_Z = Z344NetworkIndividualCountry;
         obj17.gxTpr_Networkindividualcity_Z = Z345NetworkIndividualCity;
         obj17.gxTpr_Networkindividualzipcode_Z = Z346NetworkIndividualZipCode;
         obj17.gxTpr_Networkindividualaddressline1_Z = Z347NetworkIndividualAddressLine1;
         obj17.gxTpr_Networkindividualaddressline2_Z = Z348NetworkIndividualAddressLine2;
         obj17.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow17( SdtTrn_NetworkIndividual obj17 )
      {
         obj17.gxTpr_Networkindividualid = A74NetworkIndividualId;
         return  ;
      }

      public void RowToVars17( SdtTrn_NetworkIndividual obj17 ,
                               int forceLoad )
      {
         Gx_mode = obj17.gxTpr_Mode;
         A75NetworkIndividualBsnNumber = obj17.gxTpr_Networkindividualbsnnumber;
         A76NetworkIndividualGivenName = obj17.gxTpr_Networkindividualgivenname;
         A77NetworkIndividualLastName = obj17.gxTpr_Networkindividuallastname;
         A78NetworkIndividualEmail = obj17.gxTpr_Networkindividualemail;
         A79NetworkIndividualPhone = obj17.gxTpr_Networkindividualphone;
         A387NetworkIndividualPhoneCode = obj17.gxTpr_Networkindividualphonecode;
         A388NetworkIndividualPhoneNumber = obj17.gxTpr_Networkindividualphonenumber;
         A81NetworkIndividualGender = obj17.gxTpr_Networkindividualgender;
         A344NetworkIndividualCountry = obj17.gxTpr_Networkindividualcountry;
         A345NetworkIndividualCity = obj17.gxTpr_Networkindividualcity;
         A346NetworkIndividualZipCode = obj17.gxTpr_Networkindividualzipcode;
         A347NetworkIndividualAddressLine1 = obj17.gxTpr_Networkindividualaddressline1;
         A348NetworkIndividualAddressLine2 = obj17.gxTpr_Networkindividualaddressline2;
         A74NetworkIndividualId = obj17.gxTpr_Networkindividualid;
         Z74NetworkIndividualId = obj17.gxTpr_Networkindividualid_Z;
         Z75NetworkIndividualBsnNumber = obj17.gxTpr_Networkindividualbsnnumber_Z;
         Z76NetworkIndividualGivenName = obj17.gxTpr_Networkindividualgivenname_Z;
         Z77NetworkIndividualLastName = obj17.gxTpr_Networkindividuallastname_Z;
         Z78NetworkIndividualEmail = obj17.gxTpr_Networkindividualemail_Z;
         Z79NetworkIndividualPhone = obj17.gxTpr_Networkindividualphone_Z;
         Z387NetworkIndividualPhoneCode = obj17.gxTpr_Networkindividualphonecode_Z;
         Z388NetworkIndividualPhoneNumber = obj17.gxTpr_Networkindividualphonenumber_Z;
         Z81NetworkIndividualGender = obj17.gxTpr_Networkindividualgender_Z;
         Z344NetworkIndividualCountry = obj17.gxTpr_Networkindividualcountry_Z;
         Z345NetworkIndividualCity = obj17.gxTpr_Networkindividualcity_Z;
         Z346NetworkIndividualZipCode = obj17.gxTpr_Networkindividualzipcode_Z;
         Z347NetworkIndividualAddressLine1 = obj17.gxTpr_Networkindividualaddressline1_Z;
         Z348NetworkIndividualAddressLine2 = obj17.gxTpr_Networkindividualaddressline2_Z;
         Gx_mode = obj17.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A74NetworkIndividualId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0A17( ) ;
         ScanKeyStart0A17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z74NetworkIndividualId = A74NetworkIndividualId;
         }
         ZM0A17( -6) ;
         OnLoadActions0A17( ) ;
         AddRow0A17( ) ;
         ScanKeyEnd0A17( ) ;
         if ( RcdFound17 == 0 )
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
         RowToVars17( bcTrn_NetworkIndividual, 0) ;
         ScanKeyStart0A17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z74NetworkIndividualId = A74NetworkIndividualId;
         }
         ZM0A17( -6) ;
         OnLoadActions0A17( ) ;
         AddRow0A17( ) ;
         ScanKeyEnd0A17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0A17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0A17( ) ;
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A74NetworkIndividualId != Z74NetworkIndividualId )
               {
                  A74NetworkIndividualId = Z74NetworkIndividualId;
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
                  Update0A17( ) ;
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
                  if ( A74NetworkIndividualId != Z74NetworkIndividualId )
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
                        Insert0A17( ) ;
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
                        Insert0A17( ) ;
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
         RowToVars17( bcTrn_NetworkIndividual, 1) ;
         SaveImpl( ) ;
         VarsToRow17( bcTrn_NetworkIndividual) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars17( bcTrn_NetworkIndividual, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A17( ) ;
         AfterTrn( ) ;
         VarsToRow17( bcTrn_NetworkIndividual) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow17( bcTrn_NetworkIndividual) ;
         }
         else
         {
            SdtTrn_NetworkIndividual auxBC = new SdtTrn_NetworkIndividual(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A74NetworkIndividualId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_NetworkIndividual);
               auxBC.Save();
               bcTrn_NetworkIndividual.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars17( bcTrn_NetworkIndividual, 1) ;
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
         RowToVars17( bcTrn_NetworkIndividual, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A17( ) ;
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
               VarsToRow17( bcTrn_NetworkIndividual) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow17( bcTrn_NetworkIndividual) ;
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
         RowToVars17( bcTrn_NetworkIndividual, 0) ;
         GetKey0A17( ) ;
         if ( RcdFound17 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A74NetworkIndividualId != Z74NetworkIndividualId )
            {
               A74NetworkIndividualId = Z74NetworkIndividualId;
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
            if ( A74NetworkIndividualId != Z74NetworkIndividualId )
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
         context.RollbackDataStores("trn_networkindividual_bc",pr_default);
         VarsToRow17( bcTrn_NetworkIndividual) ;
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
         Gx_mode = bcTrn_NetworkIndividual.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_NetworkIndividual.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_NetworkIndividual )
         {
            bcTrn_NetworkIndividual = (SdtTrn_NetworkIndividual)(sdt);
            if ( StringUtil.StrCmp(bcTrn_NetworkIndividual.gxTpr_Mode, "") == 0 )
            {
               bcTrn_NetworkIndividual.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow17( bcTrn_NetworkIndividual) ;
            }
            else
            {
               RowToVars17( bcTrn_NetworkIndividual, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_NetworkIndividual.gxTpr_Mode, "") == 0 )
            {
               bcTrn_NetworkIndividual.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars17( bcTrn_NetworkIndividual, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_NetworkIndividual Trn_NetworkIndividual_BC
      {
         get {
            return bcTrn_NetworkIndividual ;
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
            return "trn_networkindividual_Execute" ;
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
         Z74NetworkIndividualId = Guid.Empty;
         A74NetworkIndividualId = Guid.Empty;
         Z75NetworkIndividualBsnNumber = "";
         A75NetworkIndividualBsnNumber = "";
         Z76NetworkIndividualGivenName = "";
         A76NetworkIndividualGivenName = "";
         Z77NetworkIndividualLastName = "";
         A77NetworkIndividualLastName = "";
         Z78NetworkIndividualEmail = "";
         A78NetworkIndividualEmail = "";
         Z79NetworkIndividualPhone = "";
         A79NetworkIndividualPhone = "";
         Z387NetworkIndividualPhoneCode = "";
         A387NetworkIndividualPhoneCode = "";
         Z388NetworkIndividualPhoneNumber = "";
         A388NetworkIndividualPhoneNumber = "";
         Z81NetworkIndividualGender = "";
         A81NetworkIndividualGender = "";
         Z344NetworkIndividualCountry = "";
         A344NetworkIndividualCountry = "";
         Z345NetworkIndividualCity = "";
         A345NetworkIndividualCity = "";
         Z346NetworkIndividualZipCode = "";
         A346NetworkIndividualZipCode = "";
         Z347NetworkIndividualAddressLine1 = "";
         A347NetworkIndividualAddressLine1 = "";
         Z348NetworkIndividualAddressLine2 = "";
         A348NetworkIndividualAddressLine2 = "";
         BC000A4_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         BC000A4_A75NetworkIndividualBsnNumber = new string[] {""} ;
         BC000A4_A76NetworkIndividualGivenName = new string[] {""} ;
         BC000A4_A77NetworkIndividualLastName = new string[] {""} ;
         BC000A4_A78NetworkIndividualEmail = new string[] {""} ;
         BC000A4_A79NetworkIndividualPhone = new string[] {""} ;
         BC000A4_A387NetworkIndividualPhoneCode = new string[] {""} ;
         BC000A4_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         BC000A4_A81NetworkIndividualGender = new string[] {""} ;
         BC000A4_A344NetworkIndividualCountry = new string[] {""} ;
         BC000A4_A345NetworkIndividualCity = new string[] {""} ;
         BC000A4_A346NetworkIndividualZipCode = new string[] {""} ;
         BC000A4_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         BC000A4_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         BC000A5_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         BC000A3_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         BC000A3_A75NetworkIndividualBsnNumber = new string[] {""} ;
         BC000A3_A76NetworkIndividualGivenName = new string[] {""} ;
         BC000A3_A77NetworkIndividualLastName = new string[] {""} ;
         BC000A3_A78NetworkIndividualEmail = new string[] {""} ;
         BC000A3_A79NetworkIndividualPhone = new string[] {""} ;
         BC000A3_A387NetworkIndividualPhoneCode = new string[] {""} ;
         BC000A3_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         BC000A3_A81NetworkIndividualGender = new string[] {""} ;
         BC000A3_A344NetworkIndividualCountry = new string[] {""} ;
         BC000A3_A345NetworkIndividualCity = new string[] {""} ;
         BC000A3_A346NetworkIndividualZipCode = new string[] {""} ;
         BC000A3_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         BC000A3_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         sMode17 = "";
         BC000A2_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         BC000A2_A75NetworkIndividualBsnNumber = new string[] {""} ;
         BC000A2_A76NetworkIndividualGivenName = new string[] {""} ;
         BC000A2_A77NetworkIndividualLastName = new string[] {""} ;
         BC000A2_A78NetworkIndividualEmail = new string[] {""} ;
         BC000A2_A79NetworkIndividualPhone = new string[] {""} ;
         BC000A2_A387NetworkIndividualPhoneCode = new string[] {""} ;
         BC000A2_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         BC000A2_A81NetworkIndividualGender = new string[] {""} ;
         BC000A2_A344NetworkIndividualCountry = new string[] {""} ;
         BC000A2_A345NetworkIndividualCity = new string[] {""} ;
         BC000A2_A346NetworkIndividualZipCode = new string[] {""} ;
         BC000A2_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         BC000A2_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         BC000A9_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000A9_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000A9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000A9_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         BC000A10_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         BC000A10_A75NetworkIndividualBsnNumber = new string[] {""} ;
         BC000A10_A76NetworkIndividualGivenName = new string[] {""} ;
         BC000A10_A77NetworkIndividualLastName = new string[] {""} ;
         BC000A10_A78NetworkIndividualEmail = new string[] {""} ;
         BC000A10_A79NetworkIndividualPhone = new string[] {""} ;
         BC000A10_A387NetworkIndividualPhoneCode = new string[] {""} ;
         BC000A10_A388NetworkIndividualPhoneNumber = new string[] {""} ;
         BC000A10_A81NetworkIndividualGender = new string[] {""} ;
         BC000A10_A344NetworkIndividualCountry = new string[] {""} ;
         BC000A10_A345NetworkIndividualCity = new string[] {""} ;
         BC000A10_A346NetworkIndividualZipCode = new string[] {""} ;
         BC000A10_A347NetworkIndividualAddressLine1 = new string[] {""} ;
         BC000A10_A348NetworkIndividualAddressLine2 = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_networkindividual_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_networkindividual_bc__default(),
            new Object[][] {
                new Object[] {
               BC000A2_A74NetworkIndividualId, BC000A2_A75NetworkIndividualBsnNumber, BC000A2_A76NetworkIndividualGivenName, BC000A2_A77NetworkIndividualLastName, BC000A2_A78NetworkIndividualEmail, BC000A2_A79NetworkIndividualPhone, BC000A2_A387NetworkIndividualPhoneCode, BC000A2_A388NetworkIndividualPhoneNumber, BC000A2_A81NetworkIndividualGender, BC000A2_A344NetworkIndividualCountry,
               BC000A2_A345NetworkIndividualCity, BC000A2_A346NetworkIndividualZipCode, BC000A2_A347NetworkIndividualAddressLine1, BC000A2_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               BC000A3_A74NetworkIndividualId, BC000A3_A75NetworkIndividualBsnNumber, BC000A3_A76NetworkIndividualGivenName, BC000A3_A77NetworkIndividualLastName, BC000A3_A78NetworkIndividualEmail, BC000A3_A79NetworkIndividualPhone, BC000A3_A387NetworkIndividualPhoneCode, BC000A3_A388NetworkIndividualPhoneNumber, BC000A3_A81NetworkIndividualGender, BC000A3_A344NetworkIndividualCountry,
               BC000A3_A345NetworkIndividualCity, BC000A3_A346NetworkIndividualZipCode, BC000A3_A347NetworkIndividualAddressLine1, BC000A3_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               BC000A4_A74NetworkIndividualId, BC000A4_A75NetworkIndividualBsnNumber, BC000A4_A76NetworkIndividualGivenName, BC000A4_A77NetworkIndividualLastName, BC000A4_A78NetworkIndividualEmail, BC000A4_A79NetworkIndividualPhone, BC000A4_A387NetworkIndividualPhoneCode, BC000A4_A388NetworkIndividualPhoneNumber, BC000A4_A81NetworkIndividualGender, BC000A4_A344NetworkIndividualCountry,
               BC000A4_A345NetworkIndividualCity, BC000A4_A346NetworkIndividualZipCode, BC000A4_A347NetworkIndividualAddressLine1, BC000A4_A348NetworkIndividualAddressLine2
               }
               , new Object[] {
               BC000A5_A74NetworkIndividualId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A9_A62ResidentId, BC000A9_A29LocationId, BC000A9_A11OrganisationId, BC000A9_A74NetworkIndividualId
               }
               , new Object[] {
               BC000A10_A74NetworkIndividualId, BC000A10_A75NetworkIndividualBsnNumber, BC000A10_A76NetworkIndividualGivenName, BC000A10_A77NetworkIndividualLastName, BC000A10_A78NetworkIndividualEmail, BC000A10_A79NetworkIndividualPhone, BC000A10_A387NetworkIndividualPhoneCode, BC000A10_A388NetworkIndividualPhoneNumber, BC000A10_A81NetworkIndividualGender, BC000A10_A344NetworkIndividualCountry,
               BC000A10_A345NetworkIndividualCity, BC000A10_A346NetworkIndividualZipCode, BC000A10_A347NetworkIndividualAddressLine1, BC000A10_A348NetworkIndividualAddressLine2
               }
            }
         );
         Z74NetworkIndividualId = Guid.NewGuid( );
         A74NetworkIndividualId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound17 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z79NetworkIndividualPhone ;
      private string A79NetworkIndividualPhone ;
      private string sMode17 ;
      private bool Gx_longc ;
      private string Z75NetworkIndividualBsnNumber ;
      private string A75NetworkIndividualBsnNumber ;
      private string Z76NetworkIndividualGivenName ;
      private string A76NetworkIndividualGivenName ;
      private string Z77NetworkIndividualLastName ;
      private string A77NetworkIndividualLastName ;
      private string Z78NetworkIndividualEmail ;
      private string A78NetworkIndividualEmail ;
      private string Z387NetworkIndividualPhoneCode ;
      private string A387NetworkIndividualPhoneCode ;
      private string Z388NetworkIndividualPhoneNumber ;
      private string A388NetworkIndividualPhoneNumber ;
      private string Z81NetworkIndividualGender ;
      private string A81NetworkIndividualGender ;
      private string Z344NetworkIndividualCountry ;
      private string A344NetworkIndividualCountry ;
      private string Z345NetworkIndividualCity ;
      private string A345NetworkIndividualCity ;
      private string Z346NetworkIndividualZipCode ;
      private string A346NetworkIndividualZipCode ;
      private string Z347NetworkIndividualAddressLine1 ;
      private string A347NetworkIndividualAddressLine1 ;
      private string Z348NetworkIndividualAddressLine2 ;
      private string A348NetworkIndividualAddressLine2 ;
      private Guid Z74NetworkIndividualId ;
      private Guid A74NetworkIndividualId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000A4_A74NetworkIndividualId ;
      private string[] BC000A4_A75NetworkIndividualBsnNumber ;
      private string[] BC000A4_A76NetworkIndividualGivenName ;
      private string[] BC000A4_A77NetworkIndividualLastName ;
      private string[] BC000A4_A78NetworkIndividualEmail ;
      private string[] BC000A4_A79NetworkIndividualPhone ;
      private string[] BC000A4_A387NetworkIndividualPhoneCode ;
      private string[] BC000A4_A388NetworkIndividualPhoneNumber ;
      private string[] BC000A4_A81NetworkIndividualGender ;
      private string[] BC000A4_A344NetworkIndividualCountry ;
      private string[] BC000A4_A345NetworkIndividualCity ;
      private string[] BC000A4_A346NetworkIndividualZipCode ;
      private string[] BC000A4_A347NetworkIndividualAddressLine1 ;
      private string[] BC000A4_A348NetworkIndividualAddressLine2 ;
      private Guid[] BC000A5_A74NetworkIndividualId ;
      private Guid[] BC000A3_A74NetworkIndividualId ;
      private string[] BC000A3_A75NetworkIndividualBsnNumber ;
      private string[] BC000A3_A76NetworkIndividualGivenName ;
      private string[] BC000A3_A77NetworkIndividualLastName ;
      private string[] BC000A3_A78NetworkIndividualEmail ;
      private string[] BC000A3_A79NetworkIndividualPhone ;
      private string[] BC000A3_A387NetworkIndividualPhoneCode ;
      private string[] BC000A3_A388NetworkIndividualPhoneNumber ;
      private string[] BC000A3_A81NetworkIndividualGender ;
      private string[] BC000A3_A344NetworkIndividualCountry ;
      private string[] BC000A3_A345NetworkIndividualCity ;
      private string[] BC000A3_A346NetworkIndividualZipCode ;
      private string[] BC000A3_A347NetworkIndividualAddressLine1 ;
      private string[] BC000A3_A348NetworkIndividualAddressLine2 ;
      private Guid[] BC000A2_A74NetworkIndividualId ;
      private string[] BC000A2_A75NetworkIndividualBsnNumber ;
      private string[] BC000A2_A76NetworkIndividualGivenName ;
      private string[] BC000A2_A77NetworkIndividualLastName ;
      private string[] BC000A2_A78NetworkIndividualEmail ;
      private string[] BC000A2_A79NetworkIndividualPhone ;
      private string[] BC000A2_A387NetworkIndividualPhoneCode ;
      private string[] BC000A2_A388NetworkIndividualPhoneNumber ;
      private string[] BC000A2_A81NetworkIndividualGender ;
      private string[] BC000A2_A344NetworkIndividualCountry ;
      private string[] BC000A2_A345NetworkIndividualCity ;
      private string[] BC000A2_A346NetworkIndividualZipCode ;
      private string[] BC000A2_A347NetworkIndividualAddressLine1 ;
      private string[] BC000A2_A348NetworkIndividualAddressLine2 ;
      private Guid[] BC000A9_A62ResidentId ;
      private Guid[] BC000A9_A29LocationId ;
      private Guid[] BC000A9_A11OrganisationId ;
      private Guid[] BC000A9_A74NetworkIndividualId ;
      private Guid[] BC000A10_A74NetworkIndividualId ;
      private string[] BC000A10_A75NetworkIndividualBsnNumber ;
      private string[] BC000A10_A76NetworkIndividualGivenName ;
      private string[] BC000A10_A77NetworkIndividualLastName ;
      private string[] BC000A10_A78NetworkIndividualEmail ;
      private string[] BC000A10_A79NetworkIndividualPhone ;
      private string[] BC000A10_A387NetworkIndividualPhoneCode ;
      private string[] BC000A10_A388NetworkIndividualPhoneNumber ;
      private string[] BC000A10_A81NetworkIndividualGender ;
      private string[] BC000A10_A344NetworkIndividualCountry ;
      private string[] BC000A10_A345NetworkIndividualCity ;
      private string[] BC000A10_A346NetworkIndividualZipCode ;
      private string[] BC000A10_A347NetworkIndividualAddressLine1 ;
      private string[] BC000A10_A348NetworkIndividualAddressLine2 ;
      private SdtTrn_NetworkIndividual bcTrn_NetworkIndividual ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_networkindividual_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_networkindividual_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000A2;
        prmBC000A2 = new Object[] {
        new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000A3;
        prmBC000A3 = new Object[] {
        new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000A4;
        prmBC000A4 = new Object[] {
        new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000A5;
        prmBC000A5 = new Object[] {
        new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000A6;
        prmBC000A6 = new Object[] {
        new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NetworkIndividualBsnNumber",GXType.VarChar,9,0) ,
        new ParDef("NetworkIndividualGivenName",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualLastName",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualEmail",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualPhone",GXType.Char,20,0) ,
        new ParDef("NetworkIndividualPhoneCode",GXType.VarChar,40,0) ,
        new ParDef("NetworkIndividualPhoneNumber",GXType.VarChar,9,0) ,
        new ParDef("NetworkIndividualGender",GXType.VarChar,40,0) ,
        new ParDef("NetworkIndividualCountry",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualCity",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualZipCode",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualAddressLine1",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualAddressLine2",GXType.VarChar,100,0)
        };
        Object[] prmBC000A7;
        prmBC000A7 = new Object[] {
        new ParDef("NetworkIndividualBsnNumber",GXType.VarChar,9,0) ,
        new ParDef("NetworkIndividualGivenName",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualLastName",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualEmail",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualPhone",GXType.Char,20,0) ,
        new ParDef("NetworkIndividualPhoneCode",GXType.VarChar,40,0) ,
        new ParDef("NetworkIndividualPhoneNumber",GXType.VarChar,9,0) ,
        new ParDef("NetworkIndividualGender",GXType.VarChar,40,0) ,
        new ParDef("NetworkIndividualCountry",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualCity",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualZipCode",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualAddressLine1",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualAddressLine2",GXType.VarChar,100,0) ,
        new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000A8;
        prmBC000A8 = new Object[] {
        new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000A9;
        prmBC000A9 = new Object[] {
        new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000A10;
        prmBC000A10 = new Object[] {
        new ParDef("NetworkIndividualId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000A2", "SELECT NetworkIndividualId, NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualPhoneCode, NetworkIndividualPhoneNumber, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId  FOR UPDATE OF Trn_NetworkIndividual",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A3", "SELECT NetworkIndividualId, NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualPhoneCode, NetworkIndividualPhoneNumber, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A4", "SELECT TM1.NetworkIndividualId, TM1.NetworkIndividualBsnNumber, TM1.NetworkIndividualGivenName, TM1.NetworkIndividualLastName, TM1.NetworkIndividualEmail, TM1.NetworkIndividualPhone, TM1.NetworkIndividualPhoneCode, TM1.NetworkIndividualPhoneNumber, TM1.NetworkIndividualGender, TM1.NetworkIndividualCountry, TM1.NetworkIndividualCity, TM1.NetworkIndividualZipCode, TM1.NetworkIndividualAddressLine1, TM1.NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual TM1 WHERE TM1.NetworkIndividualId = :NetworkIndividualId ORDER BY TM1.NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A5", "SELECT NetworkIndividualId FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A6", "SAVEPOINT gxupdate;INSERT INTO Trn_NetworkIndividual(NetworkIndividualId, NetworkIndividualBsnNumber, NetworkIndividualGivenName, NetworkIndividualLastName, NetworkIndividualEmail, NetworkIndividualPhone, NetworkIndividualPhoneCode, NetworkIndividualPhoneNumber, NetworkIndividualGender, NetworkIndividualCountry, NetworkIndividualCity, NetworkIndividualZipCode, NetworkIndividualAddressLine1, NetworkIndividualAddressLine2) VALUES(:NetworkIndividualId, :NetworkIndividualBsnNumber, :NetworkIndividualGivenName, :NetworkIndividualLastName, :NetworkIndividualEmail, :NetworkIndividualPhone, :NetworkIndividualPhoneCode, :NetworkIndividualPhoneNumber, :NetworkIndividualGender, :NetworkIndividualCountry, :NetworkIndividualCity, :NetworkIndividualZipCode, :NetworkIndividualAddressLine1, :NetworkIndividualAddressLine2);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000A6)
           ,new CursorDef("BC000A7", "SAVEPOINT gxupdate;UPDATE Trn_NetworkIndividual SET NetworkIndividualBsnNumber=:NetworkIndividualBsnNumber, NetworkIndividualGivenName=:NetworkIndividualGivenName, NetworkIndividualLastName=:NetworkIndividualLastName, NetworkIndividualEmail=:NetworkIndividualEmail, NetworkIndividualPhone=:NetworkIndividualPhone, NetworkIndividualPhoneCode=:NetworkIndividualPhoneCode, NetworkIndividualPhoneNumber=:NetworkIndividualPhoneNumber, NetworkIndividualGender=:NetworkIndividualGender, NetworkIndividualCountry=:NetworkIndividualCountry, NetworkIndividualCity=:NetworkIndividualCity, NetworkIndividualZipCode=:NetworkIndividualZipCode, NetworkIndividualAddressLine1=:NetworkIndividualAddressLine1, NetworkIndividualAddressLine2=:NetworkIndividualAddressLine2  WHERE NetworkIndividualId = :NetworkIndividualId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000A7)
           ,new CursorDef("BC000A8", "SAVEPOINT gxupdate;DELETE FROM Trn_NetworkIndividual  WHERE NetworkIndividualId = :NetworkIndividualId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000A8)
           ,new CursorDef("BC000A9", "SELECT ResidentId, LocationId, OrganisationId, NetworkIndividualId FROM Trn_ResidentNetworkIndividual WHERE NetworkIndividualId = :NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000A10", "SELECT TM1.NetworkIndividualId, TM1.NetworkIndividualBsnNumber, TM1.NetworkIndividualGivenName, TM1.NetworkIndividualLastName, TM1.NetworkIndividualEmail, TM1.NetworkIndividualPhone, TM1.NetworkIndividualPhoneCode, TM1.NetworkIndividualPhoneNumber, TM1.NetworkIndividualGender, TM1.NetworkIndividualCountry, TM1.NetworkIndividualCity, TM1.NetworkIndividualZipCode, TM1.NetworkIndividualAddressLine1, TM1.NetworkIndividualAddressLine2 FROM Trn_NetworkIndividual TM1 WHERE TM1.NetworkIndividualId = :NetworkIndividualId ORDER BY TM1.NetworkIndividualId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A10,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
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
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              return;
     }
  }

}

}
