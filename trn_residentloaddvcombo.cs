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
   public class trn_residentloaddvcombo : GXProcedure
   {
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
            return "trn_resident_Services_Execute" ;
         }

      }

      public trn_residentloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_ResidentId ,
                           Guid aP4_LocationId ,
                           Guid aP5_OrganisationId ,
                           string aP6_SearchTxtParms ,
                           out string aP7_SelectedValue ,
                           out string aP8_SelectedText ,
                           out string aP9_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ResidentId = aP3_ResidentId;
         this.AV21LocationId = aP4_LocationId;
         this.AV22OrganisationId = aP5_OrganisationId;
         this.AV23SearchTxtParms = aP6_SearchTxtParms;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV26Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP7_SelectedValue=this.AV24SelectedValue;
         aP8_SelectedText=this.AV25SelectedText;
         aP9_Combo_DataJson=this.AV26Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_ResidentId ,
                                Guid aP4_LocationId ,
                                Guid aP5_OrganisationId ,
                                string aP6_SearchTxtParms ,
                                out string aP7_SelectedValue ,
                                out string aP8_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ResidentId, aP4_LocationId, aP5_OrganisationId, aP6_SearchTxtParms, out aP7_SelectedValue, out aP8_SelectedText, out aP9_Combo_DataJson);
         return AV26Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_ResidentId ,
                                 Guid aP4_LocationId ,
                                 Guid aP5_OrganisationId ,
                                 string aP6_SearchTxtParms ,
                                 out string aP7_SelectedValue ,
                                 out string aP8_SelectedText ,
                                 out string aP9_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ResidentId = aP3_ResidentId;
         this.AV21LocationId = aP4_LocationId;
         this.AV22OrganisationId = aP5_OrganisationId;
         this.AV23SearchTxtParms = aP6_SearchTxtParms;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV26Combo_DataJson = "" ;
         SubmitImpl();
         aP7_SelectedValue=this.AV24SelectedValue;
         aP8_SelectedText=this.AV25SelectedText;
         aP9_Combo_DataJson=this.AV26Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV23SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV23SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV23SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV23SearchTxtParms : StringUtil.Substring( AV23SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "NetworkCompanyId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_NETWORKCOMPANYID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "NetworkIndividualId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_NETWORKINDIVIDUALID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "MedicalIndicationId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_MEDICALINDICATIONID' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTTYPEID' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ResidentCountry") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RESIDENTCOUNTRY' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_NETWORKCOMPANYID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV33ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV32DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV40GXV1 = 1;
               while ( AV40GXV1 <= AV33ValuesCollection.Count )
               {
                  AV34ValueItem = ((string)AV33ValuesCollection.Item(AV40GXV1));
                  AV35NetworkCompanyId_Filter = StringUtil.StrToGuid( AV34ValueItem);
                  AV41GXLvl37 = 0;
                  /* Using cursor P007A2 */
                  pr_default.execute(0, new Object[] {AV35NetworkCompanyId_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A82NetworkCompanyId = P007A2_A82NetworkCompanyId[0];
                     A84NetworkCompanyName = P007A2_A84NetworkCompanyName[0];
                     AV41GXLvl37 = 1;
                     AV32DscsCollection.Add(A84NetworkCompanyName, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV41GXLvl37 == 0 )
                  {
                     AV32DscsCollection.Add("", 0);
                  }
                  AV40GXV1 = (int)(AV40GXV1+1);
               }
               AV26Combo_DataJson = AV32DscsCollection.ToJSonString(false);
            }
            else
            {
               GXPagingFrom3 = AV12SkipItems;
               GXPagingTo3 = AV11MaxItems;
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV14SearchTxt ,
                                                    A84NetworkCompanyName } ,
                                                    new int[]{
                                                    }
               });
               lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
               /* Using cursor P007A3 */
               pr_default.execute(1, new Object[] {lV14SearchTxt, GXPagingFrom3, GXPagingTo3, GXPagingTo3});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A84NetworkCompanyName = P007A3_A84NetworkCompanyName[0];
                  A82NetworkCompanyId = P007A3_A82NetworkCompanyId[0];
                  AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A82NetworkCompanyId.ToString());
                  AV16Combo_DataItem.gxTpr_Title = A84NetworkCompanyName;
                  AV15Combo_Data.Add(AV16Combo_DataItem, 0);
                  if ( AV15Combo_Data.Count > AV11MaxItems )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_NETWORKINDIVIDUALID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV33ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV32DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV43GXV2 = 1;
               while ( AV43GXV2 <= AV33ValuesCollection.Count )
               {
                  AV34ValueItem = ((string)AV33ValuesCollection.Item(AV43GXV2));
                  AV36NetworkIndividualId_Filter = StringUtil.StrToGuid( AV34ValueItem);
                  AV44GXLvl77 = 0;
                  /* Using cursor P007A4 */
                  pr_default.execute(2, new Object[] {AV36NetworkIndividualId_Filter});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A74NetworkIndividualId = P007A4_A74NetworkIndividualId[0];
                     A75NetworkIndividualBsnNumber = P007A4_A75NetworkIndividualBsnNumber[0];
                     AV44GXLvl77 = 1;
                     AV32DscsCollection.Add(A75NetworkIndividualBsnNumber, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  if ( AV44GXLvl77 == 0 )
                  {
                     AV32DscsCollection.Add("", 0);
                  }
                  AV43GXV2 = (int)(AV43GXV2+1);
               }
               AV26Combo_DataJson = AV32DscsCollection.ToJSonString(false);
            }
            else
            {
               GXPagingFrom5 = AV12SkipItems;
               GXPagingTo5 = AV11MaxItems;
               pr_default.dynParam(3, new Object[]{ new Object[]{
                                                    AV14SearchTxt ,
                                                    A75NetworkIndividualBsnNumber } ,
                                                    new int[]{
                                                    }
               });
               lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
               /* Using cursor P007A5 */
               pr_default.execute(3, new Object[] {lV14SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A75NetworkIndividualBsnNumber = P007A5_A75NetworkIndividualBsnNumber[0];
                  A74NetworkIndividualId = P007A5_A74NetworkIndividualId[0];
                  AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A74NetworkIndividualId.ToString());
                  AV16Combo_DataItem.gxTpr_Title = A75NetworkIndividualBsnNumber;
                  AV15Combo_Data.Add(AV16Combo_DataItem, 0);
                  if ( AV15Combo_Data.Count > AV11MaxItems )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_MEDICALINDICATIONID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom6 = AV12SkipItems;
            GXPagingTo6 = AV11MaxItems;
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A99MedicalIndicationName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P007A6 */
            pr_default.execute(4, new Object[] {lV14SearchTxt, GXPagingFrom6, GXPagingTo6, GXPagingTo6});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A99MedicalIndicationName = P007A6_A99MedicalIndicationName[0];
               A98MedicalIndicationId = P007A6_A98MedicalIndicationId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A98MedicalIndicationId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A99MedicalIndicationName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(4);
            }
            pr_default.close(4);
            AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P007A7 */
                  pr_default.execute(5, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A11OrganisationId = P007A7_A11OrganisationId[0];
                     A29LocationId = P007A7_A29LocationId[0];
                     A62ResidentId = P007A7_A62ResidentId[0];
                     A98MedicalIndicationId = P007A7_A98MedicalIndicationId[0];
                     A99MedicalIndicationName = P007A7_A99MedicalIndicationName[0];
                     A99MedicalIndicationName = P007A7_A99MedicalIndicationName[0];
                     AV24SelectedValue = ((Guid.Empty==A98MedicalIndicationId) ? "" : StringUtil.Trim( A98MedicalIndicationId.ToString()));
                     AV25SelectedText = A99MedicalIndicationName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(5);
               }
               else
               {
                  AV31MedicalIndicationId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P007A8 */
                  pr_default.execute(6, new Object[] {AV31MedicalIndicationId});
                  while ( (pr_default.getStatus(6) != 101) )
                  {
                     A98MedicalIndicationId = P007A8_A98MedicalIndicationId[0];
                     A99MedicalIndicationName = P007A8_A99MedicalIndicationName[0];
                     AV25SelectedText = A99MedicalIndicationName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(6);
               }
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTTYPEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom9 = AV12SkipItems;
            GXPagingTo9 = AV11MaxItems;
            pr_default.dynParam(7, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A97ResidentTypeName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P007A9 */
            pr_default.execute(7, new Object[] {lV14SearchTxt, GXPagingFrom9, GXPagingTo9, GXPagingTo9});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A97ResidentTypeName = P007A9_A97ResidentTypeName[0];
               A96ResidentTypeId = P007A9_A96ResidentTypeId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A96ResidentTypeId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A97ResidentTypeName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(7);
            }
            pr_default.close(7);
            AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P007A10 */
                  pr_default.execute(8, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A11OrganisationId = P007A10_A11OrganisationId[0];
                     A29LocationId = P007A10_A29LocationId[0];
                     A62ResidentId = P007A10_A62ResidentId[0];
                     A96ResidentTypeId = P007A10_A96ResidentTypeId[0];
                     A97ResidentTypeName = P007A10_A97ResidentTypeName[0];
                     A97ResidentTypeName = P007A10_A97ResidentTypeName[0];
                     AV24SelectedValue = ((Guid.Empty==A96ResidentTypeId) ? "" : StringUtil.Trim( A96ResidentTypeId.ToString()));
                     AV25SelectedText = A97ResidentTypeName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(8);
               }
               else
               {
                  AV30ResidentTypeId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P007A11 */
                  pr_default.execute(9, new Object[] {AV30ResidentTypeId});
                  while ( (pr_default.getStatus(9) != 101) )
                  {
                     A96ResidentTypeId = P007A11_A96ResidentTypeId[0];
                     A97ResidentTypeName = P007A11_A97ResidentTypeName[0];
                     AV25SelectedText = A97ResidentTypeName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(9);
               }
            }
         }
      }

      protected void S151( )
      {
         /* 'LOADCOMBOITEMS_RESIDENTCOUNTRY' Routine */
         returnInSub = false;
         AV53GXV4 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV52GXV3;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV52GXV3 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV53GXV4 <= AV52GXV3.Count )
         {
            AV39ResidentCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV52GXV3.Item(AV53GXV4));
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV39ResidentCountry_DPItem.gxTpr_Countryname;
            AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV38ComboTitles.Add(AV39ResidentCountry_DPItem.gxTpr_Countryname, 0);
            AV38ComboTitles.Add(AV39ResidentCountry_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV38ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV53GXV4 = (int)(AV53GXV4+1);
         }
         AV15Combo_Data.Sort("Title");
         AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P007A12 */
            pr_default.execute(10, new Object[] {AV20ResidentId, AV21LocationId, AV22OrganisationId});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A11OrganisationId = P007A12_A11OrganisationId[0];
               A29LocationId = P007A12_A29LocationId[0];
               A62ResidentId = P007A12_A62ResidentId[0];
               A354ResidentCountry = P007A12_A354ResidentCountry[0];
               AV24SelectedValue = A354ResidentCountry;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(10);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV55GXV5 = 1;
               while ( AV55GXV5 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV55GXV5));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV24SelectedValue) == 0 )
                  {
                     AV38ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV38ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV25SelectedText = ((string)AV38ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV55GXV5 = (int)(AV55GXV5+1);
               }
            }
         }
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV24SelectedValue = "";
         AV25SelectedText = "";
         AV26Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         AV33ValuesCollection = new GxSimpleCollection<string>();
         AV32DscsCollection = new GxSimpleCollection<string>();
         AV34ValueItem = "";
         AV35NetworkCompanyId_Filter = Guid.Empty;
         P007A2_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         P007A2_A84NetworkCompanyName = new string[] {""} ;
         A82NetworkCompanyId = Guid.Empty;
         A84NetworkCompanyName = "";
         lV14SearchTxt = "";
         P007A3_A84NetworkCompanyName = new string[] {""} ;
         P007A3_A82NetworkCompanyId = new Guid[] {Guid.Empty} ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV36NetworkIndividualId_Filter = Guid.Empty;
         P007A4_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         P007A4_A75NetworkIndividualBsnNumber = new string[] {""} ;
         A74NetworkIndividualId = Guid.Empty;
         A75NetworkIndividualBsnNumber = "";
         P007A5_A75NetworkIndividualBsnNumber = new string[] {""} ;
         P007A5_A74NetworkIndividualId = new Guid[] {Guid.Empty} ;
         A99MedicalIndicationName = "";
         P007A6_A99MedicalIndicationName = new string[] {""} ;
         P007A6_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         A98MedicalIndicationId = Guid.Empty;
         P007A7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A7_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A7_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A7_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P007A7_A99MedicalIndicationName = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         AV31MedicalIndicationId = Guid.Empty;
         P007A8_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P007A8_A99MedicalIndicationName = new string[] {""} ;
         A97ResidentTypeName = "";
         P007A9_A97ResidentTypeName = new string[] {""} ;
         P007A9_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         A96ResidentTypeId = Guid.Empty;
         P007A10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A10_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A10_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A10_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007A10_A97ResidentTypeName = new string[] {""} ;
         AV30ResidentTypeId = Guid.Empty;
         P007A11_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007A11_A97ResidentTypeName = new string[] {""} ;
         AV52GXV3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV39ResidentCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV38ComboTitles = new GxSimpleCollection<string>();
         P007A12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007A12_A29LocationId = new Guid[] {Guid.Empty} ;
         P007A12_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007A12_A354ResidentCountry = new string[] {""} ;
         A354ResidentCountry = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P007A2_A82NetworkCompanyId, P007A2_A84NetworkCompanyName
               }
               , new Object[] {
               P007A3_A84NetworkCompanyName, P007A3_A82NetworkCompanyId
               }
               , new Object[] {
               P007A4_A74NetworkIndividualId, P007A4_A75NetworkIndividualBsnNumber
               }
               , new Object[] {
               P007A5_A75NetworkIndividualBsnNumber, P007A5_A74NetworkIndividualId
               }
               , new Object[] {
               P007A6_A99MedicalIndicationName, P007A6_A98MedicalIndicationId
               }
               , new Object[] {
               P007A7_A11OrganisationId, P007A7_A29LocationId, P007A7_A62ResidentId, P007A7_A98MedicalIndicationId, P007A7_A99MedicalIndicationName
               }
               , new Object[] {
               P007A8_A98MedicalIndicationId, P007A8_A99MedicalIndicationName
               }
               , new Object[] {
               P007A9_A97ResidentTypeName, P007A9_A96ResidentTypeId
               }
               , new Object[] {
               P007A10_A11OrganisationId, P007A10_A29LocationId, P007A10_A62ResidentId, P007A10_A96ResidentTypeId, P007A10_A97ResidentTypeName
               }
               , new Object[] {
               P007A11_A96ResidentTypeId, P007A11_A97ResidentTypeName
               }
               , new Object[] {
               P007A12_A11OrganisationId, P007A12_A29LocationId, P007A12_A62ResidentId, P007A12_A354ResidentCountry
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short AV41GXLvl37 ;
      private short AV44GXLvl77 ;
      private int AV11MaxItems ;
      private int AV40GXV1 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private int AV43GXV2 ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int GXPagingFrom6 ;
      private int GXPagingTo6 ;
      private int GXPagingFrom9 ;
      private int GXPagingTo9 ;
      private int AV53GXV4 ;
      private int AV55GXV5 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV26Combo_DataJson ;
      private string AV17ComboName ;
      private string AV23SearchTxtParms ;
      private string AV24SelectedValue ;
      private string AV25SelectedText ;
      private string AV14SearchTxt ;
      private string AV34ValueItem ;
      private string A84NetworkCompanyName ;
      private string lV14SearchTxt ;
      private string A75NetworkIndividualBsnNumber ;
      private string A99MedicalIndicationName ;
      private string A97ResidentTypeName ;
      private string A354ResidentCountry ;
      private Guid AV20ResidentId ;
      private Guid AV21LocationId ;
      private Guid AV22OrganisationId ;
      private Guid AV35NetworkCompanyId_Filter ;
      private Guid A82NetworkCompanyId ;
      private Guid AV36NetworkIndividualId_Filter ;
      private Guid A74NetworkIndividualId ;
      private Guid A98MedicalIndicationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid AV31MedicalIndicationId ;
      private Guid A96ResidentTypeId ;
      private Guid AV30ResidentTypeId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV33ValuesCollection ;
      private GxSimpleCollection<string> AV32DscsCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007A2_A82NetworkCompanyId ;
      private string[] P007A2_A84NetworkCompanyName ;
      private string[] P007A3_A84NetworkCompanyName ;
      private Guid[] P007A3_A82NetworkCompanyId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private Guid[] P007A4_A74NetworkIndividualId ;
      private string[] P007A4_A75NetworkIndividualBsnNumber ;
      private string[] P007A5_A75NetworkIndividualBsnNumber ;
      private Guid[] P007A5_A74NetworkIndividualId ;
      private string[] P007A6_A99MedicalIndicationName ;
      private Guid[] P007A6_A98MedicalIndicationId ;
      private Guid[] P007A7_A11OrganisationId ;
      private Guid[] P007A7_A29LocationId ;
      private Guid[] P007A7_A62ResidentId ;
      private Guid[] P007A7_A98MedicalIndicationId ;
      private string[] P007A7_A99MedicalIndicationName ;
      private Guid[] P007A8_A98MedicalIndicationId ;
      private string[] P007A8_A99MedicalIndicationName ;
      private string[] P007A9_A97ResidentTypeName ;
      private Guid[] P007A9_A96ResidentTypeId ;
      private Guid[] P007A10_A11OrganisationId ;
      private Guid[] P007A10_A29LocationId ;
      private Guid[] P007A10_A62ResidentId ;
      private Guid[] P007A10_A96ResidentTypeId ;
      private string[] P007A10_A97ResidentTypeName ;
      private Guid[] P007A11_A96ResidentTypeId ;
      private string[] P007A11_A97ResidentTypeName ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV52GXV3 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV39ResidentCountry_DPItem ;
      private GxSimpleCollection<string> AV38ComboTitles ;
      private Guid[] P007A12_A11OrganisationId ;
      private Guid[] P007A12_A29LocationId ;
      private Guid[] P007A12_A62ResidentId ;
      private string[] P007A12_A354ResidentCountry ;
      private string aP7_SelectedValue ;
      private string aP8_SelectedText ;
      private string aP9_Combo_DataJson ;
   }

   public class trn_residentloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007A3( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A84NetworkCompanyName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " NetworkCompanyName, NetworkCompanyId";
         sFromString = " FROM Trn_NetworkCompany";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(NetworkCompanyName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         sOrderString += " ORDER BY NetworkCompanyName, NetworkCompanyId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom3" + " LIMIT CASE WHEN " + ":GXPagingTo3" + " > 0 THEN " + ":GXPagingTo3" + " ELSE 1e9 END";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P007A5( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A75NetworkIndividualBsnNumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " NetworkIndividualBsnNumber, NetworkIndividualId";
         sFromString = " FROM Trn_NetworkIndividual";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(NetworkIndividualBsnNumber like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         sOrderString += " ORDER BY NetworkIndividualBsnNumber, NetworkIndividualId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P007A6( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A99MedicalIndicationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[4];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " MedicalIndicationName, MedicalIndicationId";
         sFromString = " FROM Trn_MedicalIndication";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(MedicalIndicationName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         sOrderString += " ORDER BY MedicalIndicationName, MedicalIndicationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom6" + " LIMIT CASE WHEN " + ":GXPagingTo6" + " > 0 THEN " + ":GXPagingTo6" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P007A9( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A97ResidentTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[4];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ResidentTypeName, ResidentTypeId";
         sFromString = " FROM Trn_ResidentType";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(ResidentTypeName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         sOrderString += " ORDER BY ResidentTypeName, ResidentTypeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom9" + " LIMIT CASE WHEN " + ":GXPagingTo9" + " > 0 THEN " + ":GXPagingTo9" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P007A3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P007A5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 4 :
                     return conditional_P007A6(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 7 :
                     return conditional_P007A9(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007A2;
          prmP007A2 = new Object[] {
          new ParDef("AV35NetworkCompanyId_Filter",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A4;
          prmP007A4 = new Object[] {
          new ParDef("AV36NetworkIndividualId_Filter",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A7;
          prmP007A7 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A8;
          prmP007A8 = new Object[] {
          new ParDef("AV31MedicalIndicationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A10;
          prmP007A10 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A11;
          prmP007A11 = new Object[] {
          new ParDef("AV30ResidentTypeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A12;
          prmP007A12 = new Object[] {
          new ParDef("AV20ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007A3;
          prmP007A3 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          Object[] prmP007A5;
          prmP007A5 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP007A6;
          prmP007A6 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom6",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo6",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo6",GXType.Int32,9,0)
          };
          Object[] prmP007A9;
          prmP007A9 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom9",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo9",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo9",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007A2", "SELECT NetworkCompanyId, NetworkCompanyName FROM Trn_NetworkCompany WHERE NetworkCompanyId = :AV35NetworkCompanyId_Filter ORDER BY NetworkCompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007A4", "SELECT NetworkIndividualId, NetworkIndividualBsnNumber FROM Trn_NetworkIndividual WHERE NetworkIndividualId = :AV36NetworkIndividualId_Filter ORDER BY NetworkIndividualId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007A6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007A7", "SELECT T1.OrganisationId, T1.LocationId, T1.ResidentId, T1.MedicalIndicationId, T2.MedicalIndicationName FROM (Trn_Resident T1 INNER JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) WHERE T1.ResidentId = :AV20ResidentId and T1.LocationId = :AV21LocationId and T1.OrganisationId = :AV22OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A8", "SELECT MedicalIndicationId, MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :AV31MedicalIndicationId ORDER BY MedicalIndicationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007A10", "SELECT T1.OrganisationId, T1.LocationId, T1.ResidentId, T1.ResidentTypeId, T2.ResidentTypeName FROM (Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) WHERE T1.ResidentId = :AV20ResidentId and T1.LocationId = :AV21LocationId and T1.OrganisationId = :AV22OrganisationId ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A11", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :AV30ResidentTypeId ORDER BY ResidentTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A11,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A12", "SELECT OrganisationId, LocationId, ResidentId, ResidentCountry FROM Trn_Resident WHERE ResidentId = :AV20ResidentId and LocationId = :AV21LocationId and OrganisationId = :AV22OrganisationId ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A12,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 8 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 9 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 10 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
