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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_manager_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_manager_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_manager_bc( IGxContext context )
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
         ReadRow035( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey035( ) ;
         standaloneModal( ) ;
         AddRow035( ) ;
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
            E11032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z21ManagerId = A21ManagerId;
               Z11OrganisationId = A11OrganisationId;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls035( ) ;
            }
            else
            {
               CheckExtendedTable035( ) ;
               if ( AnyError == 0 )
               {
                  ZM035( 24) ;
               }
               CloseExtendedTableCursors035( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12032( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV29AuditingObject,  AV30Pgmname) ;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM035( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            Z28ManagerGAMGUID = A28ManagerGAMGUID;
            Z24ManagerInitials = A24ManagerInitials;
            Z26ManagerPhone = A26ManagerPhone;
            Z22ManagerGivenName = A22ManagerGivenName;
            Z23ManagerLastName = A23ManagerLastName;
            Z25ManagerEmail = A25ManagerEmail;
            Z385ManagerPhoneCode = A385ManagerPhoneCode;
            Z386ManagerPhoneNumber = A386ManagerPhoneNumber;
            Z27ManagerGender = A27ManagerGender;
            Z360ManagerIsMainManager = A360ManagerIsMainManager;
            Z394ManagerIsActive = A394ManagerIsActive;
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -23 )
         {
            Z21ManagerId = A21ManagerId;
            Z28ManagerGAMGUID = A28ManagerGAMGUID;
            Z24ManagerInitials = A24ManagerInitials;
            Z26ManagerPhone = A26ManagerPhone;
            Z22ManagerGivenName = A22ManagerGivenName;
            Z23ManagerLastName = A23ManagerLastName;
            Z25ManagerEmail = A25ManagerEmail;
            Z385ManagerPhoneCode = A385ManagerPhoneCode;
            Z386ManagerPhoneNumber = A386ManagerPhoneNumber;
            Z27ManagerGender = A27ManagerGender;
            Z360ManagerIsMainManager = A360ManagerIsMainManager;
            Z394ManagerIsActive = A394ManagerIsActive;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV30Pgmname = "Trn_Manager_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A21ManagerId) )
         {
            A21ManagerId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A360ManagerIsMainManager) && ( Gx_BScreen == 0 ) )
         {
            A360ManagerIsMainManager = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load035( )
      {
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A21ManagerId, A11OrganisationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A28ManagerGAMGUID = BC00035_A28ManagerGAMGUID[0];
            A24ManagerInitials = BC00035_A24ManagerInitials[0];
            A26ManagerPhone = BC00035_A26ManagerPhone[0];
            A22ManagerGivenName = BC00035_A22ManagerGivenName[0];
            A23ManagerLastName = BC00035_A23ManagerLastName[0];
            A25ManagerEmail = BC00035_A25ManagerEmail[0];
            A385ManagerPhoneCode = BC00035_A385ManagerPhoneCode[0];
            A386ManagerPhoneNumber = BC00035_A386ManagerPhoneNumber[0];
            A27ManagerGender = BC00035_A27ManagerGender[0];
            A360ManagerIsMainManager = BC00035_A360ManagerIsMainManager[0];
            A394ManagerIsActive = BC00035_A394ManagerIsActive[0];
            ZM035( -23) ;
         }
         pr_default.close(3);
         OnLoadActions035( ) ;
      }

      protected void OnLoadActions035( )
      {
         GXt_char1 = A26ManagerPhone;
         new prc_concatenateintlphone(context ).execute(  A385ManagerPhoneCode,  A386ManagerPhoneNumber, out  GXt_char1) ;
         A26ManagerPhone = GXt_char1;
      }

      protected void CheckExtendedTable035( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A22ManagerGivenName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Manager Given Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         new prc_getnameinitials(context ).execute(  A22ManagerGivenName,  A23ManagerLastName, out  A24ManagerInitials) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A23ManagerLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Manager Last Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A25ManagerEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Manager Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A25ManagerEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Manager Email", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         GXt_char1 = A26ManagerPhone;
         new prc_concatenateintlphone(context ).execute(  A385ManagerPhoneCode,  A386ManagerPhoneNumber, out  GXt_char1) ;
         A26ManagerPhone = GXt_char1;
         if ( ! ( GxRegex.IsMatch(A386ManagerPhoneNumber,"\\b\\d{9}\\b") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Phone should contain 9 digits", ""), context.GetMessage( "Manager Phone Number", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A386ManagerPhoneNumber) != 9 )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A27ManagerGender, "Male") == 0 ) || ( StringUtil.StrCmp(A27ManagerGender, "Female") == 0 ) || ( StringUtil.StrCmp(A27ManagerGender, "Other") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Manager Gender", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors035( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey035( )
      {
         /* Using cursor BC00036 */
         pr_default.execute(4, new Object[] {A21ManagerId, A11OrganisationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A21ManagerId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM035( 23) ;
            RcdFound5 = 1;
            A21ManagerId = BC00033_A21ManagerId[0];
            A28ManagerGAMGUID = BC00033_A28ManagerGAMGUID[0];
            A24ManagerInitials = BC00033_A24ManagerInitials[0];
            A26ManagerPhone = BC00033_A26ManagerPhone[0];
            A22ManagerGivenName = BC00033_A22ManagerGivenName[0];
            A23ManagerLastName = BC00033_A23ManagerLastName[0];
            A25ManagerEmail = BC00033_A25ManagerEmail[0];
            A385ManagerPhoneCode = BC00033_A385ManagerPhoneCode[0];
            A386ManagerPhoneNumber = BC00033_A386ManagerPhoneNumber[0];
            A27ManagerGender = BC00033_A27ManagerGender[0];
            A360ManagerIsMainManager = BC00033_A360ManagerIsMainManager[0];
            A394ManagerIsActive = BC00033_A394ManagerIsActive[0];
            A11OrganisationId = BC00033_A11OrganisationId[0];
            Z21ManagerId = A21ManagerId;
            Z11OrganisationId = A11OrganisationId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load035( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey035( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey035( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey035( ) ;
         if ( RcdFound5 == 0 )
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
         CONFIRM_030( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency035( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A21ManagerId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Manager"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z28ManagerGAMGUID, BC00032_A28ManagerGAMGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z24ManagerInitials, BC00032_A24ManagerInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z26ManagerPhone, BC00032_A26ManagerPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z22ManagerGivenName, BC00032_A22ManagerGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z23ManagerLastName, BC00032_A23ManagerLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z25ManagerEmail, BC00032_A25ManagerEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z385ManagerPhoneCode, BC00032_A385ManagerPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z386ManagerPhoneNumber, BC00032_A386ManagerPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z27ManagerGender, BC00032_A27ManagerGender[0]) != 0 ) || ( Z360ManagerIsMainManager != BC00032_A360ManagerIsMainManager[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z394ManagerIsActive != BC00032_A394ManagerIsActive[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Manager"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM035( 0) ;
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00037 */
                     pr_default.execute(5, new Object[] {A21ManagerId, A28ManagerGAMGUID, A24ManagerInitials, A26ManagerPhone, A22ManagerGivenName, A23ManagerLastName, A25ManagerEmail, A385ManagerPhoneCode, A386ManagerPhoneNumber, A27ManagerGender, A360ManagerIsMainManager, A394ManagerIsActive, A11OrganisationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Manager");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load035( ) ;
            }
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void Update035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00038 */
                     pr_default.execute(6, new Object[] {A28ManagerGAMGUID, A24ManagerInitials, A26ManagerPhone, A22ManagerGivenName, A23ManagerLastName, A25ManagerEmail, A385ManagerPhoneCode, A386ManagerPhoneNumber, A27ManagerGender, A360ManagerIsMainManager, A394ManagerIsActive, A21ManagerId, A11OrganisationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Manager");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Manager"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate035( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        if ( IsUpd( )  )
                        {
                           new prc_updategamuseraccount(context ).execute(  A28ManagerGAMGUID,  A22ManagerGivenName,  A23ManagerLastName,  "Organisation Manager", out  AV24GAMErrorResponse) ;
                        }
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
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void DeferredUpdate035( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls035( ) ;
            AfterConfirm035( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete035( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00039 */
                  pr_default.execute(7, new Object[] {A21ManagerId, A11OrganisationId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Manager");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     if ( IsDlt( )  )
                     {
                        new prc_deletegamuseraccount(context ).execute(  A28ManagerGAMGUID, out  AV24GAMErrorResponse) ;
                     }
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel035( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls035( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( IsDlt( )  && ( StringUtil.StrCmp(A28ManagerGAMGUID, new prc_getloggedinuserid(context).executeUdp( )) == 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "Invalid Delete Action: You cannot delete you're own account.", ""), 1, "");
               AnyError = 1;
            }
         }
      }

      protected void EndLevel035( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete035( ) ;
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

      public void ScanKeyStart035( )
      {
         /* Scan By routine */
         /* Using cursor BC000310 */
         pr_default.execute(8, new Object[] {A21ManagerId, A11OrganisationId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound5 = 1;
            A21ManagerId = BC000310_A21ManagerId[0];
            A28ManagerGAMGUID = BC000310_A28ManagerGAMGUID[0];
            A24ManagerInitials = BC000310_A24ManagerInitials[0];
            A26ManagerPhone = BC000310_A26ManagerPhone[0];
            A22ManagerGivenName = BC000310_A22ManagerGivenName[0];
            A23ManagerLastName = BC000310_A23ManagerLastName[0];
            A25ManagerEmail = BC000310_A25ManagerEmail[0];
            A385ManagerPhoneCode = BC000310_A385ManagerPhoneCode[0];
            A386ManagerPhoneNumber = BC000310_A386ManagerPhoneNumber[0];
            A27ManagerGender = BC000310_A27ManagerGender[0];
            A360ManagerIsMainManager = BC000310_A360ManagerIsMainManager[0];
            A394ManagerIsActive = BC000310_A394ManagerIsActive[0];
            A11OrganisationId = BC000310_A11OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext035( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound5 = 0;
         ScanKeyLoad035( ) ;
      }

      protected void ScanKeyLoad035( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound5 = 1;
            A21ManagerId = BC000310_A21ManagerId[0];
            A28ManagerGAMGUID = BC000310_A28ManagerGAMGUID[0];
            A24ManagerInitials = BC000310_A24ManagerInitials[0];
            A26ManagerPhone = BC000310_A26ManagerPhone[0];
            A22ManagerGivenName = BC000310_A22ManagerGivenName[0];
            A23ManagerLastName = BC000310_A23ManagerLastName[0];
            A25ManagerEmail = BC000310_A25ManagerEmail[0];
            A385ManagerPhoneCode = BC000310_A385ManagerPhoneCode[0];
            A386ManagerPhoneNumber = BC000310_A386ManagerPhoneNumber[0];
            A27ManagerGender = BC000310_A27ManagerGender[0];
            A360ManagerIsMainManager = BC000310_A360ManagerIsMainManager[0];
            A394ManagerIsActive = BC000310_A394ManagerIsActive[0];
            A11OrganisationId = BC000310_A11OrganisationId[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd035( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm035( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert035( )
      {
         /* Before Insert Rules */
         new prc_creategamuseraccount(context ).execute(  A25ManagerEmail,  A22ManagerGivenName,  A23ManagerLastName,  "Organisation Manager", out  A28ManagerGAMGUID) ;
      }

      protected void BeforeUpdate035( )
      {
         /* Before Update Rules */
         new loadaudittrn_manager(context ).execute(  "Y", ref  AV29AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
      }

      protected void BeforeDelete035( )
      {
         /* Before Delete Rules */
         new loadaudittrn_manager(context ).execute(  "Y", ref  AV29AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
      }

      protected void BeforeComplete035( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new loadaudittrn_manager(context ).execute(  "N", ref  AV29AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new loadaudittrn_manager(context ).execute(  "N", ref  AV29AuditingObject,  A21ManagerId,  A11OrganisationId,  Gx_mode) ;
         }
      }

      protected void BeforeValidate035( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes035( )
      {
      }

      protected void send_integrity_lvl_hashes035( )
      {
      }

      protected void AddRow035( )
      {
         VarsToRow5( bcTrn_Manager) ;
      }

      protected void ReadRow035( )
      {
         RowToVars5( bcTrn_Manager, 1) ;
      }

      protected void InitializeNonKey035( )
      {
         AV29AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A28ManagerGAMGUID = "";
         A24ManagerInitials = "";
         AV24GAMErrorResponse = "";
         A26ManagerPhone = "";
         A22ManagerGivenName = "";
         A23ManagerLastName = "";
         A25ManagerEmail = "";
         A385ManagerPhoneCode = "";
         A386ManagerPhoneNumber = "";
         A27ManagerGender = "";
         A394ManagerIsActive = false;
         A360ManagerIsMainManager = false;
         Z28ManagerGAMGUID = "";
         Z24ManagerInitials = "";
         Z26ManagerPhone = "";
         Z22ManagerGivenName = "";
         Z23ManagerLastName = "";
         Z25ManagerEmail = "";
         Z385ManagerPhoneCode = "";
         Z386ManagerPhoneNumber = "";
         Z27ManagerGender = "";
         Z360ManagerIsMainManager = false;
         Z394ManagerIsActive = false;
      }

      protected void InitAll035( )
      {
         A21ManagerId = Guid.NewGuid( );
         A11OrganisationId = Guid.Empty;
         InitializeNonKey035( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A360ManagerIsMainManager = i360ManagerIsMainManager;
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

      public void VarsToRow5( SdtTrn_Manager obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Managergamguid = A28ManagerGAMGUID;
         obj5.gxTpr_Managerinitials = A24ManagerInitials;
         obj5.gxTpr_Managerphone = A26ManagerPhone;
         obj5.gxTpr_Managergivenname = A22ManagerGivenName;
         obj5.gxTpr_Managerlastname = A23ManagerLastName;
         obj5.gxTpr_Manageremail = A25ManagerEmail;
         obj5.gxTpr_Managerphonecode = A385ManagerPhoneCode;
         obj5.gxTpr_Managerphonenumber = A386ManagerPhoneNumber;
         obj5.gxTpr_Managergender = A27ManagerGender;
         obj5.gxTpr_Managerisactive = A394ManagerIsActive;
         obj5.gxTpr_Managerismainmanager = A360ManagerIsMainManager;
         obj5.gxTpr_Managerid = A21ManagerId;
         obj5.gxTpr_Organisationid = A11OrganisationId;
         obj5.gxTpr_Managerid_Z = Z21ManagerId;
         obj5.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj5.gxTpr_Managergivenname_Z = Z22ManagerGivenName;
         obj5.gxTpr_Managerlastname_Z = Z23ManagerLastName;
         obj5.gxTpr_Managerinitials_Z = Z24ManagerInitials;
         obj5.gxTpr_Manageremail_Z = Z25ManagerEmail;
         obj5.gxTpr_Managerphone_Z = Z26ManagerPhone;
         obj5.gxTpr_Managerphonecode_Z = Z385ManagerPhoneCode;
         obj5.gxTpr_Managerphonenumber_Z = Z386ManagerPhoneNumber;
         obj5.gxTpr_Managergender_Z = Z27ManagerGender;
         obj5.gxTpr_Managergamguid_Z = Z28ManagerGAMGUID;
         obj5.gxTpr_Managerismainmanager_Z = Z360ManagerIsMainManager;
         obj5.gxTpr_Managerisactive_Z = Z394ManagerIsActive;
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( SdtTrn_Manager obj5 )
      {
         obj5.gxTpr_Managerid = A21ManagerId;
         obj5.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars5( SdtTrn_Manager obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A28ManagerGAMGUID = obj5.gxTpr_Managergamguid;
         A24ManagerInitials = obj5.gxTpr_Managerinitials;
         A26ManagerPhone = obj5.gxTpr_Managerphone;
         A22ManagerGivenName = obj5.gxTpr_Managergivenname;
         A23ManagerLastName = obj5.gxTpr_Managerlastname;
         if ( ! ( IsUpd( )  ) || ( forceLoad == 1 ) )
         {
            A25ManagerEmail = obj5.gxTpr_Manageremail;
         }
         A385ManagerPhoneCode = obj5.gxTpr_Managerphonecode;
         A386ManagerPhoneNumber = obj5.gxTpr_Managerphonenumber;
         A27ManagerGender = obj5.gxTpr_Managergender;
         A394ManagerIsActive = obj5.gxTpr_Managerisactive;
         A360ManagerIsMainManager = obj5.gxTpr_Managerismainmanager;
         A21ManagerId = obj5.gxTpr_Managerid;
         A11OrganisationId = obj5.gxTpr_Organisationid;
         Z21ManagerId = obj5.gxTpr_Managerid_Z;
         Z11OrganisationId = obj5.gxTpr_Organisationid_Z;
         Z22ManagerGivenName = obj5.gxTpr_Managergivenname_Z;
         Z23ManagerLastName = obj5.gxTpr_Managerlastname_Z;
         Z24ManagerInitials = obj5.gxTpr_Managerinitials_Z;
         Z25ManagerEmail = obj5.gxTpr_Manageremail_Z;
         Z26ManagerPhone = obj5.gxTpr_Managerphone_Z;
         Z385ManagerPhoneCode = obj5.gxTpr_Managerphonecode_Z;
         Z386ManagerPhoneNumber = obj5.gxTpr_Managerphonenumber_Z;
         Z27ManagerGender = obj5.gxTpr_Managergender_Z;
         Z28ManagerGAMGUID = obj5.gxTpr_Managergamguid_Z;
         Z360ManagerIsMainManager = obj5.gxTpr_Managerismainmanager_Z;
         Z394ManagerIsActive = obj5.gxTpr_Managerisactive_Z;
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A21ManagerId = (Guid)getParm(obj,0);
         A11OrganisationId = (Guid)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey035( ) ;
         ScanKeyStart035( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000311 */
            pr_default.execute(9, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z21ManagerId = A21ManagerId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM035( -23) ;
         OnLoadActions035( ) ;
         AddRow035( ) ;
         ScanKeyEnd035( ) ;
         if ( RcdFound5 == 0 )
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
         RowToVars5( bcTrn_Manager, 0) ;
         ScanKeyStart035( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000311 */
            pr_default.execute(9, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z21ManagerId = A21ManagerId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM035( -23) ;
         OnLoadActions035( ) ;
         AddRow035( ) ;
         ScanKeyEnd035( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey035( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert035( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( ( A21ManagerId != Z21ManagerId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A21ManagerId = Z21ManagerId;
                  A11OrganisationId = Z11OrganisationId;
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
                  Update035( ) ;
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
                  if ( ( A21ManagerId != Z21ManagerId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
                        Insert035( ) ;
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
                        Insert035( ) ;
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
         RowToVars5( bcTrn_Manager, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bcTrn_Manager) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bcTrn_Manager, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert035( ) ;
         AfterTrn( ) ;
         VarsToRow5( bcTrn_Manager) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow5( bcTrn_Manager) ;
         }
         else
         {
            SdtTrn_Manager auxBC = new SdtTrn_Manager(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A21ManagerId, A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Manager);
               auxBC.Save();
               bcTrn_Manager.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars5( bcTrn_Manager, 1) ;
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
         RowToVars5( bcTrn_Manager, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert035( ) ;
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
               VarsToRow5( bcTrn_Manager) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow5( bcTrn_Manager) ;
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
         RowToVars5( bcTrn_Manager, 0) ;
         GetKey035( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A21ManagerId != Z21ManagerId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               A21ManagerId = Z21ManagerId;
               A11OrganisationId = Z11OrganisationId;
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
            if ( ( A21ManagerId != Z21ManagerId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
         context.RollbackDataStores("trn_manager_bc",pr_default);
         VarsToRow5( bcTrn_Manager) ;
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
         Gx_mode = bcTrn_Manager.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Manager.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Manager )
         {
            bcTrn_Manager = (SdtTrn_Manager)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Manager.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Manager.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bcTrn_Manager) ;
            }
            else
            {
               RowToVars5( bcTrn_Manager, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Manager.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Manager.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bcTrn_Manager, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Manager Trn_Manager_BC
      {
         get {
            return bcTrn_Manager ;
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
            return "trn_manager_Execute" ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z21ManagerId = Guid.Empty;
         A21ManagerId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV29AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV30Pgmname = "";
         Z28ManagerGAMGUID = "";
         A28ManagerGAMGUID = "";
         Z24ManagerInitials = "";
         A24ManagerInitials = "";
         Z26ManagerPhone = "";
         A26ManagerPhone = "";
         Z22ManagerGivenName = "";
         A22ManagerGivenName = "";
         Z23ManagerLastName = "";
         A23ManagerLastName = "";
         Z25ManagerEmail = "";
         A25ManagerEmail = "";
         Z385ManagerPhoneCode = "";
         A385ManagerPhoneCode = "";
         Z386ManagerPhoneNumber = "";
         A386ManagerPhoneNumber = "";
         Z27ManagerGender = "";
         A27ManagerGender = "";
         BC00035_A21ManagerId = new Guid[] {Guid.Empty} ;
         BC00035_A28ManagerGAMGUID = new string[] {""} ;
         BC00035_A24ManagerInitials = new string[] {""} ;
         BC00035_A26ManagerPhone = new string[] {""} ;
         BC00035_A22ManagerGivenName = new string[] {""} ;
         BC00035_A23ManagerLastName = new string[] {""} ;
         BC00035_A25ManagerEmail = new string[] {""} ;
         BC00035_A385ManagerPhoneCode = new string[] {""} ;
         BC00035_A386ManagerPhoneNumber = new string[] {""} ;
         BC00035_A27ManagerGender = new string[] {""} ;
         BC00035_A360ManagerIsMainManager = new bool[] {false} ;
         BC00035_A394ManagerIsActive = new bool[] {false} ;
         BC00035_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00034_A11OrganisationId = new Guid[] {Guid.Empty} ;
         GXt_char1 = "";
         BC00036_A21ManagerId = new Guid[] {Guid.Empty} ;
         BC00036_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00033_A21ManagerId = new Guid[] {Guid.Empty} ;
         BC00033_A28ManagerGAMGUID = new string[] {""} ;
         BC00033_A24ManagerInitials = new string[] {""} ;
         BC00033_A26ManagerPhone = new string[] {""} ;
         BC00033_A22ManagerGivenName = new string[] {""} ;
         BC00033_A23ManagerLastName = new string[] {""} ;
         BC00033_A25ManagerEmail = new string[] {""} ;
         BC00033_A385ManagerPhoneCode = new string[] {""} ;
         BC00033_A386ManagerPhoneNumber = new string[] {""} ;
         BC00033_A27ManagerGender = new string[] {""} ;
         BC00033_A360ManagerIsMainManager = new bool[] {false} ;
         BC00033_A394ManagerIsActive = new bool[] {false} ;
         BC00033_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sMode5 = "";
         BC00032_A21ManagerId = new Guid[] {Guid.Empty} ;
         BC00032_A28ManagerGAMGUID = new string[] {""} ;
         BC00032_A24ManagerInitials = new string[] {""} ;
         BC00032_A26ManagerPhone = new string[] {""} ;
         BC00032_A22ManagerGivenName = new string[] {""} ;
         BC00032_A23ManagerLastName = new string[] {""} ;
         BC00032_A25ManagerEmail = new string[] {""} ;
         BC00032_A385ManagerPhoneCode = new string[] {""} ;
         BC00032_A386ManagerPhoneNumber = new string[] {""} ;
         BC00032_A27ManagerGender = new string[] {""} ;
         BC00032_A360ManagerIsMainManager = new bool[] {false} ;
         BC00032_A394ManagerIsActive = new bool[] {false} ;
         BC00032_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV24GAMErrorResponse = "";
         BC000310_A21ManagerId = new Guid[] {Guid.Empty} ;
         BC000310_A28ManagerGAMGUID = new string[] {""} ;
         BC000310_A24ManagerInitials = new string[] {""} ;
         BC000310_A26ManagerPhone = new string[] {""} ;
         BC000310_A22ManagerGivenName = new string[] {""} ;
         BC000310_A23ManagerLastName = new string[] {""} ;
         BC000310_A25ManagerEmail = new string[] {""} ;
         BC000310_A385ManagerPhoneCode = new string[] {""} ;
         BC000310_A386ManagerPhoneNumber = new string[] {""} ;
         BC000310_A27ManagerGender = new string[] {""} ;
         BC000310_A360ManagerIsMainManager = new bool[] {false} ;
         BC000310_A394ManagerIsActive = new bool[] {false} ;
         BC000310_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000311_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_manager_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_manager_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A21ManagerId, BC00032_A28ManagerGAMGUID, BC00032_A24ManagerInitials, BC00032_A26ManagerPhone, BC00032_A22ManagerGivenName, BC00032_A23ManagerLastName, BC00032_A25ManagerEmail, BC00032_A385ManagerPhoneCode, BC00032_A386ManagerPhoneNumber, BC00032_A27ManagerGender,
               BC00032_A360ManagerIsMainManager, BC00032_A394ManagerIsActive, BC00032_A11OrganisationId
               }
               , new Object[] {
               BC00033_A21ManagerId, BC00033_A28ManagerGAMGUID, BC00033_A24ManagerInitials, BC00033_A26ManagerPhone, BC00033_A22ManagerGivenName, BC00033_A23ManagerLastName, BC00033_A25ManagerEmail, BC00033_A385ManagerPhoneCode, BC00033_A386ManagerPhoneNumber, BC00033_A27ManagerGender,
               BC00033_A360ManagerIsMainManager, BC00033_A394ManagerIsActive, BC00033_A11OrganisationId
               }
               , new Object[] {
               BC00034_A11OrganisationId
               }
               , new Object[] {
               BC00035_A21ManagerId, BC00035_A28ManagerGAMGUID, BC00035_A24ManagerInitials, BC00035_A26ManagerPhone, BC00035_A22ManagerGivenName, BC00035_A23ManagerLastName, BC00035_A25ManagerEmail, BC00035_A385ManagerPhoneCode, BC00035_A386ManagerPhoneNumber, BC00035_A27ManagerGender,
               BC00035_A360ManagerIsMainManager, BC00035_A394ManagerIsActive, BC00035_A11OrganisationId
               }
               , new Object[] {
               BC00036_A21ManagerId, BC00036_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000310_A21ManagerId, BC000310_A28ManagerGAMGUID, BC000310_A24ManagerInitials, BC000310_A26ManagerPhone, BC000310_A22ManagerGivenName, BC000310_A23ManagerLastName, BC000310_A25ManagerEmail, BC000310_A385ManagerPhoneCode, BC000310_A386ManagerPhoneNumber, BC000310_A27ManagerGender,
               BC000310_A360ManagerIsMainManager, BC000310_A394ManagerIsActive, BC000310_A11OrganisationId
               }
               , new Object[] {
               BC000311_A11OrganisationId
               }
            }
         );
         Z360ManagerIsMainManager = false;
         A360ManagerIsMainManager = false;
         i360ManagerIsMainManager = false;
         Z21ManagerId = Guid.NewGuid( );
         A21ManagerId = Guid.NewGuid( );
         AV30Pgmname = "Trn_Manager_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12032 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV30Pgmname ;
      private string Z24ManagerInitials ;
      private string A24ManagerInitials ;
      private string Z26ManagerPhone ;
      private string A26ManagerPhone ;
      private string GXt_char1 ;
      private string sMode5 ;
      private bool returnInSub ;
      private bool Z360ManagerIsMainManager ;
      private bool A360ManagerIsMainManager ;
      private bool Z394ManagerIsActive ;
      private bool A394ManagerIsActive ;
      private bool Gx_longc ;
      private bool i360ManagerIsMainManager ;
      private string AV24GAMErrorResponse ;
      private string Z28ManagerGAMGUID ;
      private string A28ManagerGAMGUID ;
      private string Z22ManagerGivenName ;
      private string A22ManagerGivenName ;
      private string Z23ManagerLastName ;
      private string A23ManagerLastName ;
      private string Z25ManagerEmail ;
      private string A25ManagerEmail ;
      private string Z385ManagerPhoneCode ;
      private string A385ManagerPhoneCode ;
      private string Z386ManagerPhoneNumber ;
      private string A386ManagerPhoneNumber ;
      private string Z27ManagerGender ;
      private string A27ManagerGender ;
      private Guid Z21ManagerId ;
      private Guid A21ManagerId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV13WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV29AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00035_A21ManagerId ;
      private string[] BC00035_A28ManagerGAMGUID ;
      private string[] BC00035_A24ManagerInitials ;
      private string[] BC00035_A26ManagerPhone ;
      private string[] BC00035_A22ManagerGivenName ;
      private string[] BC00035_A23ManagerLastName ;
      private string[] BC00035_A25ManagerEmail ;
      private string[] BC00035_A385ManagerPhoneCode ;
      private string[] BC00035_A386ManagerPhoneNumber ;
      private string[] BC00035_A27ManagerGender ;
      private bool[] BC00035_A360ManagerIsMainManager ;
      private bool[] BC00035_A394ManagerIsActive ;
      private Guid[] BC00035_A11OrganisationId ;
      private Guid[] BC00034_A11OrganisationId ;
      private Guid[] BC00036_A21ManagerId ;
      private Guid[] BC00036_A11OrganisationId ;
      private Guid[] BC00033_A21ManagerId ;
      private string[] BC00033_A28ManagerGAMGUID ;
      private string[] BC00033_A24ManagerInitials ;
      private string[] BC00033_A26ManagerPhone ;
      private string[] BC00033_A22ManagerGivenName ;
      private string[] BC00033_A23ManagerLastName ;
      private string[] BC00033_A25ManagerEmail ;
      private string[] BC00033_A385ManagerPhoneCode ;
      private string[] BC00033_A386ManagerPhoneNumber ;
      private string[] BC00033_A27ManagerGender ;
      private bool[] BC00033_A360ManagerIsMainManager ;
      private bool[] BC00033_A394ManagerIsActive ;
      private Guid[] BC00033_A11OrganisationId ;
      private Guid[] BC00032_A21ManagerId ;
      private string[] BC00032_A28ManagerGAMGUID ;
      private string[] BC00032_A24ManagerInitials ;
      private string[] BC00032_A26ManagerPhone ;
      private string[] BC00032_A22ManagerGivenName ;
      private string[] BC00032_A23ManagerLastName ;
      private string[] BC00032_A25ManagerEmail ;
      private string[] BC00032_A385ManagerPhoneCode ;
      private string[] BC00032_A386ManagerPhoneNumber ;
      private string[] BC00032_A27ManagerGender ;
      private bool[] BC00032_A360ManagerIsMainManager ;
      private bool[] BC00032_A394ManagerIsActive ;
      private Guid[] BC00032_A11OrganisationId ;
      private Guid[] BC000310_A21ManagerId ;
      private string[] BC000310_A28ManagerGAMGUID ;
      private string[] BC000310_A24ManagerInitials ;
      private string[] BC000310_A26ManagerPhone ;
      private string[] BC000310_A22ManagerGivenName ;
      private string[] BC000310_A23ManagerLastName ;
      private string[] BC000310_A25ManagerEmail ;
      private string[] BC000310_A385ManagerPhoneCode ;
      private string[] BC000310_A386ManagerPhoneNumber ;
      private string[] BC000310_A27ManagerGender ;
      private bool[] BC000310_A360ManagerIsMainManager ;
      private bool[] BC000310_A394ManagerIsActive ;
      private Guid[] BC000310_A11OrganisationId ;
      private SdtTrn_Manager bcTrn_Manager ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC000311_A11OrganisationId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_manager_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_manager_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00032;
        prmBC00032 = new Object[] {
        new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00033;
        prmBC00033 = new Object[] {
        new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00034;
        prmBC00034 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00035;
        prmBC00035 = new Object[] {
        new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00036;
        prmBC00036 = new Object[] {
        new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00037;
        prmBC00037 = new Object[] {
        new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ManagerGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("ManagerInitials",GXType.Char,20,0) ,
        new ParDef("ManagerPhone",GXType.Char,20,0) ,
        new ParDef("ManagerGivenName",GXType.VarChar,100,0) ,
        new ParDef("ManagerLastName",GXType.VarChar,100,0) ,
        new ParDef("ManagerEmail",GXType.VarChar,100,0) ,
        new ParDef("ManagerPhoneCode",GXType.VarChar,40,0) ,
        new ParDef("ManagerPhoneNumber",GXType.VarChar,9,0) ,
        new ParDef("ManagerGender",GXType.VarChar,40,0) ,
        new ParDef("ManagerIsMainManager",GXType.Boolean,4,0) ,
        new ParDef("ManagerIsActive",GXType.Boolean,4,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00038;
        prmBC00038 = new Object[] {
        new ParDef("ManagerGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("ManagerInitials",GXType.Char,20,0) ,
        new ParDef("ManagerPhone",GXType.Char,20,0) ,
        new ParDef("ManagerGivenName",GXType.VarChar,100,0) ,
        new ParDef("ManagerLastName",GXType.VarChar,100,0) ,
        new ParDef("ManagerEmail",GXType.VarChar,100,0) ,
        new ParDef("ManagerPhoneCode",GXType.VarChar,40,0) ,
        new ParDef("ManagerPhoneNumber",GXType.VarChar,9,0) ,
        new ParDef("ManagerGender",GXType.VarChar,40,0) ,
        new ParDef("ManagerIsMainManager",GXType.Boolean,4,0) ,
        new ParDef("ManagerIsActive",GXType.Boolean,4,0) ,
        new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00039;
        prmBC00039 = new Object[] {
        new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000310;
        prmBC000310 = new Object[] {
        new ParDef("ManagerId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000311;
        prmBC000311 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00032", "SELECT ManagerId, ManagerGAMGUID, ManagerInitials, ManagerPhone, ManagerGivenName, ManagerLastName, ManagerEmail, ManagerPhoneCode, ManagerPhoneNumber, ManagerGender, ManagerIsMainManager, ManagerIsActive, OrganisationId FROM Trn_Manager WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Manager",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00033", "SELECT ManagerId, ManagerGAMGUID, ManagerInitials, ManagerPhone, ManagerGivenName, ManagerLastName, ManagerEmail, ManagerPhoneCode, ManagerPhoneNumber, ManagerGender, ManagerIsMainManager, ManagerIsActive, OrganisationId FROM Trn_Manager WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00034", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00035", "SELECT TM1.ManagerId, TM1.ManagerGAMGUID, TM1.ManagerInitials, TM1.ManagerPhone, TM1.ManagerGivenName, TM1.ManagerLastName, TM1.ManagerEmail, TM1.ManagerPhoneCode, TM1.ManagerPhoneNumber, TM1.ManagerGender, TM1.ManagerIsMainManager, TM1.ManagerIsActive, TM1.OrganisationId FROM Trn_Manager TM1 WHERE TM1.ManagerId = :ManagerId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ManagerId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00036", "SELECT ManagerId, OrganisationId FROM Trn_Manager WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00037", "SAVEPOINT gxupdate;INSERT INTO Trn_Manager(ManagerId, ManagerGAMGUID, ManagerInitials, ManagerPhone, ManagerGivenName, ManagerLastName, ManagerEmail, ManagerPhoneCode, ManagerPhoneNumber, ManagerGender, ManagerIsMainManager, ManagerIsActive, OrganisationId) VALUES(:ManagerId, :ManagerGAMGUID, :ManagerInitials, :ManagerPhone, :ManagerGivenName, :ManagerLastName, :ManagerEmail, :ManagerPhoneCode, :ManagerPhoneNumber, :ManagerGender, :ManagerIsMainManager, :ManagerIsActive, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00037)
           ,new CursorDef("BC00038", "SAVEPOINT gxupdate;UPDATE Trn_Manager SET ManagerGAMGUID=:ManagerGAMGUID, ManagerInitials=:ManagerInitials, ManagerPhone=:ManagerPhone, ManagerGivenName=:ManagerGivenName, ManagerLastName=:ManagerLastName, ManagerEmail=:ManagerEmail, ManagerPhoneCode=:ManagerPhoneCode, ManagerPhoneNumber=:ManagerPhoneNumber, ManagerGender=:ManagerGender, ManagerIsMainManager=:ManagerIsMainManager, ManagerIsActive=:ManagerIsActive  WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00038)
           ,new CursorDef("BC00039", "SAVEPOINT gxupdate;DELETE FROM Trn_Manager  WHERE ManagerId = :ManagerId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00039)
           ,new CursorDef("BC000310", "SELECT TM1.ManagerId, TM1.ManagerGAMGUID, TM1.ManagerInitials, TM1.ManagerPhone, TM1.ManagerGivenName, TM1.ManagerLastName, TM1.ManagerEmail, TM1.ManagerPhoneCode, TM1.ManagerPhoneNumber, TM1.ManagerGender, TM1.ManagerIsMainManager, TM1.ManagerIsActive, TM1.OrganisationId FROM Trn_Manager TM1 WHERE TM1.ManagerId = :ManagerId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ManagerId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000310,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000311", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000311,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((Guid[]) buf[12])[0] = rslt.getGuid(13);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((Guid[]) buf[12])[0] = rslt.getGuid(13);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((Guid[]) buf[12])[0] = rslt.getGuid(13);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((Guid[]) buf[12])[0] = rslt.getGuid(13);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
