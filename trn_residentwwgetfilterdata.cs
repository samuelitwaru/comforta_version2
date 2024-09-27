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
   public class trn_residentwwgetfilterdata : GXProcedure
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
            return "trn_residentww_Services_Execute" ;
         }

      }

      public trn_residentwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentwwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV52OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34MaxItems = 10;
         AV33PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV48SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV31SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? "" : StringUtil.Substring( AV48SearchTxtParms, 3, -1));
         AV32SkipItems = (short)(AV33PageIndex*AV34MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTGIVENNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTGIVENNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTLASTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTLASTNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTBSNNUMBER") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTBSNNUMBEROPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTEMAILOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTPHONEOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_RESIDENTTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESIDENTTYPENAMEOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_MEDICALINDICATIONNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADMEDICALINDICATIONNAMEOPTIONS' */
            S181 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV50OptionsJson = AV37Options.ToJSonString(false);
         AV51OptionsDescJson = AV39OptionsDesc.ToJSonString(false);
         AV52OptionIndexesJson = AV40OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get("Trn_ResidentWWGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_ResidentWWGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("Trn_ResidentWWGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTSALUTATION_SEL") == 0 )
            {
               AV11TFResidentSalutation_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV12TFResidentSalutation_Sels.FromJSonString(AV11TFResidentSalutation_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME") == 0 )
            {
               AV13TFResidentGivenName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME_SEL") == 0 )
            {
               AV14TFResidentGivenName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME") == 0 )
            {
               AV15TFResidentLastName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME_SEL") == 0 )
            {
               AV16TFResidentLastName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTBSNNUMBER") == 0 )
            {
               AV17TFResidentBsnNumber = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTBSNNUMBER_SEL") == 0 )
            {
               AV18TFResidentBsnNumber_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL") == 0 )
            {
               AV19TFResidentEmail = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL_SEL") == 0 )
            {
               AV20TFResidentEmail_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTGENDER_SEL") == 0 )
            {
               AV21TFResidentGender_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV22TFResidentGender_Sels.FromJSonString(AV21TFResidentGender_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE") == 0 )
            {
               AV23TFResidentPhone = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE_SEL") == 0 )
            {
               AV24TFResidentPhone_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTBIRTHDATE") == 0 )
            {
               AV25TFResidentBirthDate = context.localUtil.CToD( AV45GridStateFilterValue.gxTpr_Value, 1);
               AV26TFResidentBirthDate_To = context.localUtil.CToD( AV45GridStateFilterValue.gxTpr_Valueto, 1);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME") == 0 )
            {
               AV27TFResidentTypeName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME_SEL") == 0 )
            {
               AV28TFResidentTypeName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFMEDICALINDICATIONNAME") == 0 )
            {
               AV29TFMedicalIndicationName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFMEDICALINDICATIONNAME_SEL") == 0 )
            {
               AV30TFMedicalIndicationName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRESIDENTGIVENNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFResidentGivenName = AV31SearchTxt;
         AV14TFResidentGivenName_Sel = "";
         AV56Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV57Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV58Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV59Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV60Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV61Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV62Trn_residentwwds_7_tfresidentbsnnumber = AV17TFResidentBsnNumber;
         AV63Trn_residentwwds_8_tfresidentbsnnumber_sel = AV18TFResidentBsnNumber_Sel;
         AV64Trn_residentwwds_9_tfresidentemail = AV19TFResidentEmail;
         AV65Trn_residentwwds_10_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV66Trn_residentwwds_11_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV67Trn_residentwwds_12_tfresidentphone = AV23TFResidentPhone;
         AV68Trn_residentwwds_13_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV69Trn_residentwwds_14_tfresidentbirthdate = AV25TFResidentBirthDate;
         AV70Trn_residentwwds_15_tfresidentbirthdate_to = AV26TFResidentBirthDate_To;
         AV71Trn_residentwwds_16_tfresidenttypename = AV27TFResidentTypeName;
         AV72Trn_residentwwds_17_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         AV73Trn_residentwwds_18_tfmedicalindicationname = AV29TFMedicalIndicationName;
         AV74Trn_residentwwds_19_tfmedicalindicationname_sel = AV30TFMedicalIndicationName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                              AV56Trn_residentwwds_1_filterfulltext ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV58Trn_residentwwds_3_tfresidentgivenname ,
                                              AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV60Trn_residentwwds_5_tfresidentlastname ,
                                              AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                              AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                              AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                              AV64Trn_residentwwds_9_tfresidentemail ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels.Count ,
                                              AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                              AV67Trn_residentwwds_12_tfresidentphone ,
                                              AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                              AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                              AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                              AV71Trn_residentwwds_16_tfresidenttypename ,
                                              AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                              AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A63ResidentBsnNumber ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              A99MedicalIndicationName ,
                                              A73ResidentBirthDate } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV58Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV60Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV62Trn_residentwwds_7_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber), "%", "");
         lV64Trn_residentwwds_9_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail), "%", "");
         lV67Trn_residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone), 20, "%");
         lV71Trn_residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename), "%", "");
         lV73Trn_residentwwds_18_tfmedicalindicationname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname), "%", "");
         /* Using cursor P007B2 */
         pr_default.execute(0, new Object[] {lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV58Trn_residentwwds_3_tfresidentgivenname, AV59Trn_residentwwds_4_tfresidentgivenname_sel, lV60Trn_residentwwds_5_tfresidentlastname, AV61Trn_residentwwds_6_tfresidentlastname_sel, lV62Trn_residentwwds_7_tfresidentbsnnumber, AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, lV64Trn_residentwwds_9_tfresidentemail, AV65Trn_residentwwds_10_tfresidentemail_sel, lV67Trn_residentwwds_12_tfresidentphone, AV68Trn_residentwwds_13_tfresidentphone_sel, AV69Trn_residentwwds_14_tfresidentbirthdate, AV70Trn_residentwwds_15_tfresidentbirthdate_to, lV71Trn_residentwwds_16_tfresidenttypename, AV72Trn_residentwwds_17_tfresidenttypename_sel, lV73Trn_residentwwds_18_tfmedicalindicationname, AV74Trn_residentwwds_19_tfmedicalindicationname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7B2 = false;
            A96ResidentTypeId = P007B2_A96ResidentTypeId[0];
            A98MedicalIndicationId = P007B2_A98MedicalIndicationId[0];
            A64ResidentGivenName = P007B2_A64ResidentGivenName[0];
            A73ResidentBirthDate = P007B2_A73ResidentBirthDate[0];
            A99MedicalIndicationName = P007B2_A99MedicalIndicationName[0];
            A97ResidentTypeName = P007B2_A97ResidentTypeName[0];
            A70ResidentPhone = P007B2_A70ResidentPhone[0];
            A68ResidentGender = P007B2_A68ResidentGender[0];
            A67ResidentEmail = P007B2_A67ResidentEmail[0];
            A63ResidentBsnNumber = P007B2_A63ResidentBsnNumber[0];
            A65ResidentLastName = P007B2_A65ResidentLastName[0];
            A72ResidentSalutation = P007B2_A72ResidentSalutation[0];
            A62ResidentId = P007B2_A62ResidentId[0];
            A29LocationId = P007B2_A29LocationId[0];
            A11OrganisationId = P007B2_A11OrganisationId[0];
            A97ResidentTypeName = P007B2_A97ResidentTypeName[0];
            A99MedicalIndicationName = P007B2_A99MedicalIndicationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007B2_A64ResidentGivenName[0], A64ResidentGivenName) == 0 ) )
            {
               BRK7B2 = false;
               A62ResidentId = P007B2_A62ResidentId[0];
               A29LocationId = P007B2_A29LocationId[0];
               A11OrganisationId = P007B2_A11OrganisationId[0];
               AV41count = (long)(AV41count+1);
               BRK7B2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A64ResidentGivenName)) ? "<#Empty#>" : A64ResidentGivenName);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7B2 )
            {
               BRK7B2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRESIDENTLASTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFResidentLastName = AV31SearchTxt;
         AV16TFResidentLastName_Sel = "";
         AV56Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV57Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV58Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV59Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV60Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV61Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV62Trn_residentwwds_7_tfresidentbsnnumber = AV17TFResidentBsnNumber;
         AV63Trn_residentwwds_8_tfresidentbsnnumber_sel = AV18TFResidentBsnNumber_Sel;
         AV64Trn_residentwwds_9_tfresidentemail = AV19TFResidentEmail;
         AV65Trn_residentwwds_10_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV66Trn_residentwwds_11_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV67Trn_residentwwds_12_tfresidentphone = AV23TFResidentPhone;
         AV68Trn_residentwwds_13_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV69Trn_residentwwds_14_tfresidentbirthdate = AV25TFResidentBirthDate;
         AV70Trn_residentwwds_15_tfresidentbirthdate_to = AV26TFResidentBirthDate_To;
         AV71Trn_residentwwds_16_tfresidenttypename = AV27TFResidentTypeName;
         AV72Trn_residentwwds_17_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         AV73Trn_residentwwds_18_tfmedicalindicationname = AV29TFMedicalIndicationName;
         AV74Trn_residentwwds_19_tfmedicalindicationname_sel = AV30TFMedicalIndicationName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                              AV56Trn_residentwwds_1_filterfulltext ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV58Trn_residentwwds_3_tfresidentgivenname ,
                                              AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV60Trn_residentwwds_5_tfresidentlastname ,
                                              AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                              AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                              AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                              AV64Trn_residentwwds_9_tfresidentemail ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels.Count ,
                                              AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                              AV67Trn_residentwwds_12_tfresidentphone ,
                                              AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                              AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                              AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                              AV71Trn_residentwwds_16_tfresidenttypename ,
                                              AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                              AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A63ResidentBsnNumber ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              A99MedicalIndicationName ,
                                              A73ResidentBirthDate } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV58Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV60Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV62Trn_residentwwds_7_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber), "%", "");
         lV64Trn_residentwwds_9_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail), "%", "");
         lV67Trn_residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone), 20, "%");
         lV71Trn_residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename), "%", "");
         lV73Trn_residentwwds_18_tfmedicalindicationname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname), "%", "");
         /* Using cursor P007B3 */
         pr_default.execute(1, new Object[] {lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV58Trn_residentwwds_3_tfresidentgivenname, AV59Trn_residentwwds_4_tfresidentgivenname_sel, lV60Trn_residentwwds_5_tfresidentlastname, AV61Trn_residentwwds_6_tfresidentlastname_sel, lV62Trn_residentwwds_7_tfresidentbsnnumber, AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, lV64Trn_residentwwds_9_tfresidentemail, AV65Trn_residentwwds_10_tfresidentemail_sel, lV67Trn_residentwwds_12_tfresidentphone, AV68Trn_residentwwds_13_tfresidentphone_sel, AV69Trn_residentwwds_14_tfresidentbirthdate, AV70Trn_residentwwds_15_tfresidentbirthdate_to, lV71Trn_residentwwds_16_tfresidenttypename, AV72Trn_residentwwds_17_tfresidenttypename_sel, lV73Trn_residentwwds_18_tfmedicalindicationname, AV74Trn_residentwwds_19_tfmedicalindicationname_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7B4 = false;
            A96ResidentTypeId = P007B3_A96ResidentTypeId[0];
            A98MedicalIndicationId = P007B3_A98MedicalIndicationId[0];
            A65ResidentLastName = P007B3_A65ResidentLastName[0];
            A73ResidentBirthDate = P007B3_A73ResidentBirthDate[0];
            A99MedicalIndicationName = P007B3_A99MedicalIndicationName[0];
            A97ResidentTypeName = P007B3_A97ResidentTypeName[0];
            A70ResidentPhone = P007B3_A70ResidentPhone[0];
            A68ResidentGender = P007B3_A68ResidentGender[0];
            A67ResidentEmail = P007B3_A67ResidentEmail[0];
            A63ResidentBsnNumber = P007B3_A63ResidentBsnNumber[0];
            A64ResidentGivenName = P007B3_A64ResidentGivenName[0];
            A72ResidentSalutation = P007B3_A72ResidentSalutation[0];
            A62ResidentId = P007B3_A62ResidentId[0];
            A29LocationId = P007B3_A29LocationId[0];
            A11OrganisationId = P007B3_A11OrganisationId[0];
            A97ResidentTypeName = P007B3_A97ResidentTypeName[0];
            A99MedicalIndicationName = P007B3_A99MedicalIndicationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007B3_A65ResidentLastName[0], A65ResidentLastName) == 0 ) )
            {
               BRK7B4 = false;
               A62ResidentId = P007B3_A62ResidentId[0];
               A29LocationId = P007B3_A29LocationId[0];
               A11OrganisationId = P007B3_A11OrganisationId[0];
               AV41count = (long)(AV41count+1);
               BRK7B4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A65ResidentLastName)) ? "<#Empty#>" : A65ResidentLastName);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7B4 )
            {
               BRK7B4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRESIDENTBSNNUMBEROPTIONS' Routine */
         returnInSub = false;
         AV17TFResidentBsnNumber = AV31SearchTxt;
         AV18TFResidentBsnNumber_Sel = "";
         AV56Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV57Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV58Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV59Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV60Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV61Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV62Trn_residentwwds_7_tfresidentbsnnumber = AV17TFResidentBsnNumber;
         AV63Trn_residentwwds_8_tfresidentbsnnumber_sel = AV18TFResidentBsnNumber_Sel;
         AV64Trn_residentwwds_9_tfresidentemail = AV19TFResidentEmail;
         AV65Trn_residentwwds_10_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV66Trn_residentwwds_11_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV67Trn_residentwwds_12_tfresidentphone = AV23TFResidentPhone;
         AV68Trn_residentwwds_13_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV69Trn_residentwwds_14_tfresidentbirthdate = AV25TFResidentBirthDate;
         AV70Trn_residentwwds_15_tfresidentbirthdate_to = AV26TFResidentBirthDate_To;
         AV71Trn_residentwwds_16_tfresidenttypename = AV27TFResidentTypeName;
         AV72Trn_residentwwds_17_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         AV73Trn_residentwwds_18_tfmedicalindicationname = AV29TFMedicalIndicationName;
         AV74Trn_residentwwds_19_tfmedicalindicationname_sel = AV30TFMedicalIndicationName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                              AV56Trn_residentwwds_1_filterfulltext ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV58Trn_residentwwds_3_tfresidentgivenname ,
                                              AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV60Trn_residentwwds_5_tfresidentlastname ,
                                              AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                              AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                              AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                              AV64Trn_residentwwds_9_tfresidentemail ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels.Count ,
                                              AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                              AV67Trn_residentwwds_12_tfresidentphone ,
                                              AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                              AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                              AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                              AV71Trn_residentwwds_16_tfresidenttypename ,
                                              AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                              AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A63ResidentBsnNumber ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              A99MedicalIndicationName ,
                                              A73ResidentBirthDate } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV58Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV60Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV62Trn_residentwwds_7_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber), "%", "");
         lV64Trn_residentwwds_9_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail), "%", "");
         lV67Trn_residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone), 20, "%");
         lV71Trn_residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename), "%", "");
         lV73Trn_residentwwds_18_tfmedicalindicationname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname), "%", "");
         /* Using cursor P007B4 */
         pr_default.execute(2, new Object[] {lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV58Trn_residentwwds_3_tfresidentgivenname, AV59Trn_residentwwds_4_tfresidentgivenname_sel, lV60Trn_residentwwds_5_tfresidentlastname, AV61Trn_residentwwds_6_tfresidentlastname_sel, lV62Trn_residentwwds_7_tfresidentbsnnumber, AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, lV64Trn_residentwwds_9_tfresidentemail, AV65Trn_residentwwds_10_tfresidentemail_sel, lV67Trn_residentwwds_12_tfresidentphone, AV68Trn_residentwwds_13_tfresidentphone_sel, AV69Trn_residentwwds_14_tfresidentbirthdate, AV70Trn_residentwwds_15_tfresidentbirthdate_to, lV71Trn_residentwwds_16_tfresidenttypename, AV72Trn_residentwwds_17_tfresidenttypename_sel, lV73Trn_residentwwds_18_tfmedicalindicationname, AV74Trn_residentwwds_19_tfmedicalindicationname_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7B6 = false;
            A96ResidentTypeId = P007B4_A96ResidentTypeId[0];
            A98MedicalIndicationId = P007B4_A98MedicalIndicationId[0];
            A63ResidentBsnNumber = P007B4_A63ResidentBsnNumber[0];
            A73ResidentBirthDate = P007B4_A73ResidentBirthDate[0];
            A99MedicalIndicationName = P007B4_A99MedicalIndicationName[0];
            A97ResidentTypeName = P007B4_A97ResidentTypeName[0];
            A70ResidentPhone = P007B4_A70ResidentPhone[0];
            A68ResidentGender = P007B4_A68ResidentGender[0];
            A67ResidentEmail = P007B4_A67ResidentEmail[0];
            A65ResidentLastName = P007B4_A65ResidentLastName[0];
            A64ResidentGivenName = P007B4_A64ResidentGivenName[0];
            A72ResidentSalutation = P007B4_A72ResidentSalutation[0];
            A62ResidentId = P007B4_A62ResidentId[0];
            A29LocationId = P007B4_A29LocationId[0];
            A11OrganisationId = P007B4_A11OrganisationId[0];
            A97ResidentTypeName = P007B4_A97ResidentTypeName[0];
            A99MedicalIndicationName = P007B4_A99MedicalIndicationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007B4_A63ResidentBsnNumber[0], A63ResidentBsnNumber) == 0 ) )
            {
               BRK7B6 = false;
               A62ResidentId = P007B4_A62ResidentId[0];
               A29LocationId = P007B4_A29LocationId[0];
               A11OrganisationId = P007B4_A11OrganisationId[0];
               AV41count = (long)(AV41count+1);
               BRK7B6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A63ResidentBsnNumber)) ? "<#Empty#>" : A63ResidentBsnNumber);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7B6 )
            {
               BRK7B6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADRESIDENTEMAILOPTIONS' Routine */
         returnInSub = false;
         AV19TFResidentEmail = AV31SearchTxt;
         AV20TFResidentEmail_Sel = "";
         AV56Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV57Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV58Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV59Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV60Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV61Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV62Trn_residentwwds_7_tfresidentbsnnumber = AV17TFResidentBsnNumber;
         AV63Trn_residentwwds_8_tfresidentbsnnumber_sel = AV18TFResidentBsnNumber_Sel;
         AV64Trn_residentwwds_9_tfresidentemail = AV19TFResidentEmail;
         AV65Trn_residentwwds_10_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV66Trn_residentwwds_11_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV67Trn_residentwwds_12_tfresidentphone = AV23TFResidentPhone;
         AV68Trn_residentwwds_13_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV69Trn_residentwwds_14_tfresidentbirthdate = AV25TFResidentBirthDate;
         AV70Trn_residentwwds_15_tfresidentbirthdate_to = AV26TFResidentBirthDate_To;
         AV71Trn_residentwwds_16_tfresidenttypename = AV27TFResidentTypeName;
         AV72Trn_residentwwds_17_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         AV73Trn_residentwwds_18_tfmedicalindicationname = AV29TFMedicalIndicationName;
         AV74Trn_residentwwds_19_tfmedicalindicationname_sel = AV30TFMedicalIndicationName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                              AV56Trn_residentwwds_1_filterfulltext ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV58Trn_residentwwds_3_tfresidentgivenname ,
                                              AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV60Trn_residentwwds_5_tfresidentlastname ,
                                              AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                              AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                              AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                              AV64Trn_residentwwds_9_tfresidentemail ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels.Count ,
                                              AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                              AV67Trn_residentwwds_12_tfresidentphone ,
                                              AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                              AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                              AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                              AV71Trn_residentwwds_16_tfresidenttypename ,
                                              AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                              AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A63ResidentBsnNumber ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              A99MedicalIndicationName ,
                                              A73ResidentBirthDate } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV58Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV60Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV62Trn_residentwwds_7_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber), "%", "");
         lV64Trn_residentwwds_9_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail), "%", "");
         lV67Trn_residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone), 20, "%");
         lV71Trn_residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename), "%", "");
         lV73Trn_residentwwds_18_tfmedicalindicationname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname), "%", "");
         /* Using cursor P007B5 */
         pr_default.execute(3, new Object[] {lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV58Trn_residentwwds_3_tfresidentgivenname, AV59Trn_residentwwds_4_tfresidentgivenname_sel, lV60Trn_residentwwds_5_tfresidentlastname, AV61Trn_residentwwds_6_tfresidentlastname_sel, lV62Trn_residentwwds_7_tfresidentbsnnumber, AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, lV64Trn_residentwwds_9_tfresidentemail, AV65Trn_residentwwds_10_tfresidentemail_sel, lV67Trn_residentwwds_12_tfresidentphone, AV68Trn_residentwwds_13_tfresidentphone_sel, AV69Trn_residentwwds_14_tfresidentbirthdate, AV70Trn_residentwwds_15_tfresidentbirthdate_to, lV71Trn_residentwwds_16_tfresidenttypename, AV72Trn_residentwwds_17_tfresidenttypename_sel, lV73Trn_residentwwds_18_tfmedicalindicationname, AV74Trn_residentwwds_19_tfmedicalindicationname_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK7B8 = false;
            A96ResidentTypeId = P007B5_A96ResidentTypeId[0];
            A98MedicalIndicationId = P007B5_A98MedicalIndicationId[0];
            A67ResidentEmail = P007B5_A67ResidentEmail[0];
            A73ResidentBirthDate = P007B5_A73ResidentBirthDate[0];
            A99MedicalIndicationName = P007B5_A99MedicalIndicationName[0];
            A97ResidentTypeName = P007B5_A97ResidentTypeName[0];
            A70ResidentPhone = P007B5_A70ResidentPhone[0];
            A68ResidentGender = P007B5_A68ResidentGender[0];
            A63ResidentBsnNumber = P007B5_A63ResidentBsnNumber[0];
            A65ResidentLastName = P007B5_A65ResidentLastName[0];
            A64ResidentGivenName = P007B5_A64ResidentGivenName[0];
            A72ResidentSalutation = P007B5_A72ResidentSalutation[0];
            A62ResidentId = P007B5_A62ResidentId[0];
            A29LocationId = P007B5_A29LocationId[0];
            A11OrganisationId = P007B5_A11OrganisationId[0];
            A97ResidentTypeName = P007B5_A97ResidentTypeName[0];
            A99MedicalIndicationName = P007B5_A99MedicalIndicationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P007B5_A67ResidentEmail[0], A67ResidentEmail) == 0 ) )
            {
               BRK7B8 = false;
               A62ResidentId = P007B5_A62ResidentId[0];
               A29LocationId = P007B5_A29LocationId[0];
               A11OrganisationId = P007B5_A11OrganisationId[0];
               AV41count = (long)(AV41count+1);
               BRK7B8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A67ResidentEmail)) ? "<#Empty#>" : A67ResidentEmail);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7B8 )
            {
               BRK7B8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADRESIDENTPHONEOPTIONS' Routine */
         returnInSub = false;
         AV23TFResidentPhone = AV31SearchTxt;
         AV24TFResidentPhone_Sel = "";
         AV56Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV57Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV58Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV59Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV60Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV61Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV62Trn_residentwwds_7_tfresidentbsnnumber = AV17TFResidentBsnNumber;
         AV63Trn_residentwwds_8_tfresidentbsnnumber_sel = AV18TFResidentBsnNumber_Sel;
         AV64Trn_residentwwds_9_tfresidentemail = AV19TFResidentEmail;
         AV65Trn_residentwwds_10_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV66Trn_residentwwds_11_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV67Trn_residentwwds_12_tfresidentphone = AV23TFResidentPhone;
         AV68Trn_residentwwds_13_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV69Trn_residentwwds_14_tfresidentbirthdate = AV25TFResidentBirthDate;
         AV70Trn_residentwwds_15_tfresidentbirthdate_to = AV26TFResidentBirthDate_To;
         AV71Trn_residentwwds_16_tfresidenttypename = AV27TFResidentTypeName;
         AV72Trn_residentwwds_17_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         AV73Trn_residentwwds_18_tfmedicalindicationname = AV29TFMedicalIndicationName;
         AV74Trn_residentwwds_19_tfmedicalindicationname_sel = AV30TFMedicalIndicationName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                              AV56Trn_residentwwds_1_filterfulltext ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV58Trn_residentwwds_3_tfresidentgivenname ,
                                              AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV60Trn_residentwwds_5_tfresidentlastname ,
                                              AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                              AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                              AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                              AV64Trn_residentwwds_9_tfresidentemail ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels.Count ,
                                              AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                              AV67Trn_residentwwds_12_tfresidentphone ,
                                              AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                              AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                              AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                              AV71Trn_residentwwds_16_tfresidenttypename ,
                                              AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                              AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A63ResidentBsnNumber ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              A99MedicalIndicationName ,
                                              A73ResidentBirthDate } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV58Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV60Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV62Trn_residentwwds_7_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber), "%", "");
         lV64Trn_residentwwds_9_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail), "%", "");
         lV67Trn_residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone), 20, "%");
         lV71Trn_residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename), "%", "");
         lV73Trn_residentwwds_18_tfmedicalindicationname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname), "%", "");
         /* Using cursor P007B6 */
         pr_default.execute(4, new Object[] {lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV58Trn_residentwwds_3_tfresidentgivenname, AV59Trn_residentwwds_4_tfresidentgivenname_sel, lV60Trn_residentwwds_5_tfresidentlastname, AV61Trn_residentwwds_6_tfresidentlastname_sel, lV62Trn_residentwwds_7_tfresidentbsnnumber, AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, lV64Trn_residentwwds_9_tfresidentemail, AV65Trn_residentwwds_10_tfresidentemail_sel, lV67Trn_residentwwds_12_tfresidentphone, AV68Trn_residentwwds_13_tfresidentphone_sel, AV69Trn_residentwwds_14_tfresidentbirthdate, AV70Trn_residentwwds_15_tfresidentbirthdate_to, lV71Trn_residentwwds_16_tfresidenttypename, AV72Trn_residentwwds_17_tfresidenttypename_sel, lV73Trn_residentwwds_18_tfmedicalindicationname, AV74Trn_residentwwds_19_tfmedicalindicationname_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK7B10 = false;
            A96ResidentTypeId = P007B6_A96ResidentTypeId[0];
            A98MedicalIndicationId = P007B6_A98MedicalIndicationId[0];
            A70ResidentPhone = P007B6_A70ResidentPhone[0];
            A73ResidentBirthDate = P007B6_A73ResidentBirthDate[0];
            A99MedicalIndicationName = P007B6_A99MedicalIndicationName[0];
            A97ResidentTypeName = P007B6_A97ResidentTypeName[0];
            A68ResidentGender = P007B6_A68ResidentGender[0];
            A67ResidentEmail = P007B6_A67ResidentEmail[0];
            A63ResidentBsnNumber = P007B6_A63ResidentBsnNumber[0];
            A65ResidentLastName = P007B6_A65ResidentLastName[0];
            A64ResidentGivenName = P007B6_A64ResidentGivenName[0];
            A72ResidentSalutation = P007B6_A72ResidentSalutation[0];
            A62ResidentId = P007B6_A62ResidentId[0];
            A29LocationId = P007B6_A29LocationId[0];
            A11OrganisationId = P007B6_A11OrganisationId[0];
            A97ResidentTypeName = P007B6_A97ResidentTypeName[0];
            A99MedicalIndicationName = P007B6_A99MedicalIndicationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P007B6_A70ResidentPhone[0], A70ResidentPhone) == 0 ) )
            {
               BRK7B10 = false;
               A62ResidentId = P007B6_A62ResidentId[0];
               A29LocationId = P007B6_A29LocationId[0];
               A11OrganisationId = P007B6_A11OrganisationId[0];
               AV41count = (long)(AV41count+1);
               BRK7B10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A70ResidentPhone)) ? "<#Empty#>" : A70ResidentPhone);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7B10 )
            {
               BRK7B10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADRESIDENTTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV27TFResidentTypeName = AV31SearchTxt;
         AV28TFResidentTypeName_Sel = "";
         AV56Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV57Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV58Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV59Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV60Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV61Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV62Trn_residentwwds_7_tfresidentbsnnumber = AV17TFResidentBsnNumber;
         AV63Trn_residentwwds_8_tfresidentbsnnumber_sel = AV18TFResidentBsnNumber_Sel;
         AV64Trn_residentwwds_9_tfresidentemail = AV19TFResidentEmail;
         AV65Trn_residentwwds_10_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV66Trn_residentwwds_11_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV67Trn_residentwwds_12_tfresidentphone = AV23TFResidentPhone;
         AV68Trn_residentwwds_13_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV69Trn_residentwwds_14_tfresidentbirthdate = AV25TFResidentBirthDate;
         AV70Trn_residentwwds_15_tfresidentbirthdate_to = AV26TFResidentBirthDate_To;
         AV71Trn_residentwwds_16_tfresidenttypename = AV27TFResidentTypeName;
         AV72Trn_residentwwds_17_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         AV73Trn_residentwwds_18_tfmedicalindicationname = AV29TFMedicalIndicationName;
         AV74Trn_residentwwds_19_tfmedicalindicationname_sel = AV30TFMedicalIndicationName_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                              AV56Trn_residentwwds_1_filterfulltext ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV58Trn_residentwwds_3_tfresidentgivenname ,
                                              AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV60Trn_residentwwds_5_tfresidentlastname ,
                                              AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                              AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                              AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                              AV64Trn_residentwwds_9_tfresidentemail ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels.Count ,
                                              AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                              AV67Trn_residentwwds_12_tfresidentphone ,
                                              AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                              AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                              AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                              AV71Trn_residentwwds_16_tfresidenttypename ,
                                              AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                              AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A63ResidentBsnNumber ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              A99MedicalIndicationName ,
                                              A73ResidentBirthDate } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV58Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV60Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV62Trn_residentwwds_7_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber), "%", "");
         lV64Trn_residentwwds_9_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail), "%", "");
         lV67Trn_residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone), 20, "%");
         lV71Trn_residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename), "%", "");
         lV73Trn_residentwwds_18_tfmedicalindicationname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname), "%", "");
         /* Using cursor P007B7 */
         pr_default.execute(5, new Object[] {lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV58Trn_residentwwds_3_tfresidentgivenname, AV59Trn_residentwwds_4_tfresidentgivenname_sel, lV60Trn_residentwwds_5_tfresidentlastname, AV61Trn_residentwwds_6_tfresidentlastname_sel, lV62Trn_residentwwds_7_tfresidentbsnnumber, AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, lV64Trn_residentwwds_9_tfresidentemail, AV65Trn_residentwwds_10_tfresidentemail_sel, lV67Trn_residentwwds_12_tfresidentphone, AV68Trn_residentwwds_13_tfresidentphone_sel, AV69Trn_residentwwds_14_tfresidentbirthdate, AV70Trn_residentwwds_15_tfresidentbirthdate_to, lV71Trn_residentwwds_16_tfresidenttypename, AV72Trn_residentwwds_17_tfresidenttypename_sel, lV73Trn_residentwwds_18_tfmedicalindicationname, AV74Trn_residentwwds_19_tfmedicalindicationname_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK7B12 = false;
            A98MedicalIndicationId = P007B7_A98MedicalIndicationId[0];
            A96ResidentTypeId = P007B7_A96ResidentTypeId[0];
            A73ResidentBirthDate = P007B7_A73ResidentBirthDate[0];
            A99MedicalIndicationName = P007B7_A99MedicalIndicationName[0];
            A97ResidentTypeName = P007B7_A97ResidentTypeName[0];
            A70ResidentPhone = P007B7_A70ResidentPhone[0];
            A68ResidentGender = P007B7_A68ResidentGender[0];
            A67ResidentEmail = P007B7_A67ResidentEmail[0];
            A63ResidentBsnNumber = P007B7_A63ResidentBsnNumber[0];
            A65ResidentLastName = P007B7_A65ResidentLastName[0];
            A64ResidentGivenName = P007B7_A64ResidentGivenName[0];
            A72ResidentSalutation = P007B7_A72ResidentSalutation[0];
            A62ResidentId = P007B7_A62ResidentId[0];
            A29LocationId = P007B7_A29LocationId[0];
            A11OrganisationId = P007B7_A11OrganisationId[0];
            A99MedicalIndicationName = P007B7_A99MedicalIndicationName[0];
            A97ResidentTypeName = P007B7_A97ResidentTypeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( P007B7_A96ResidentTypeId[0] == A96ResidentTypeId ) )
            {
               BRK7B12 = false;
               A62ResidentId = P007B7_A62ResidentId[0];
               A29LocationId = P007B7_A29LocationId[0];
               A11OrganisationId = P007B7_A11OrganisationId[0];
               AV41count = (long)(AV41count+1);
               BRK7B12 = true;
               pr_default.readNext(5);
            }
            AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A97ResidentTypeName)) ? "<#Empty#>" : A97ResidentTypeName);
            AV35InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV35InsertIndex = (int)(AV35InsertIndex+1);
            }
            AV37Options.Add(AV36Option, AV35InsertIndex);
            AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
            if ( AV37Options.Count == AV32SkipItems + 11 )
            {
               AV37Options.RemoveItem(AV37Options.Count);
               AV40OptionIndexes.RemoveItem(AV40OptionIndexes.Count);
            }
            if ( ! BRK7B12 )
            {
               BRK7B12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
         while ( AV32SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV40OptionIndexes.RemoveItem(1);
            AV32SkipItems = (short)(AV32SkipItems-1);
         }
      }

      protected void S181( )
      {
         /* 'LOADMEDICALINDICATIONNAMEOPTIONS' Routine */
         returnInSub = false;
         AV29TFMedicalIndicationName = AV31SearchTxt;
         AV30TFMedicalIndicationName_Sel = "";
         AV56Trn_residentwwds_1_filterfulltext = AV53FilterFullText;
         AV57Trn_residentwwds_2_tfresidentsalutation_sels = AV12TFResidentSalutation_Sels;
         AV58Trn_residentwwds_3_tfresidentgivenname = AV13TFResidentGivenName;
         AV59Trn_residentwwds_4_tfresidentgivenname_sel = AV14TFResidentGivenName_Sel;
         AV60Trn_residentwwds_5_tfresidentlastname = AV15TFResidentLastName;
         AV61Trn_residentwwds_6_tfresidentlastname_sel = AV16TFResidentLastName_Sel;
         AV62Trn_residentwwds_7_tfresidentbsnnumber = AV17TFResidentBsnNumber;
         AV63Trn_residentwwds_8_tfresidentbsnnumber_sel = AV18TFResidentBsnNumber_Sel;
         AV64Trn_residentwwds_9_tfresidentemail = AV19TFResidentEmail;
         AV65Trn_residentwwds_10_tfresidentemail_sel = AV20TFResidentEmail_Sel;
         AV66Trn_residentwwds_11_tfresidentgender_sels = AV22TFResidentGender_Sels;
         AV67Trn_residentwwds_12_tfresidentphone = AV23TFResidentPhone;
         AV68Trn_residentwwds_13_tfresidentphone_sel = AV24TFResidentPhone_Sel;
         AV69Trn_residentwwds_14_tfresidentbirthdate = AV25TFResidentBirthDate;
         AV70Trn_residentwwds_15_tfresidentbirthdate_to = AV26TFResidentBirthDate_To;
         AV71Trn_residentwwds_16_tfresidenttypename = AV27TFResidentTypeName;
         AV72Trn_residentwwds_17_tfresidenttypename_sel = AV28TFResidentTypeName_Sel;
         AV73Trn_residentwwds_18_tfmedicalindicationname = AV29TFMedicalIndicationName;
         AV74Trn_residentwwds_19_tfmedicalindicationname_sel = AV30TFMedicalIndicationName_Sel;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                              AV56Trn_residentwwds_1_filterfulltext ,
                                              AV57Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV58Trn_residentwwds_3_tfresidentgivenname ,
                                              AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV60Trn_residentwwds_5_tfresidentlastname ,
                                              AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                              AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                              AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                              AV64Trn_residentwwds_9_tfresidentemail ,
                                              AV66Trn_residentwwds_11_tfresidentgender_sels.Count ,
                                              AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                              AV67Trn_residentwwds_12_tfresidentphone ,
                                              AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                              AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                              AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                              AV71Trn_residentwwds_16_tfresidenttypename ,
                                              AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                              AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A63ResidentBsnNumber ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              A99MedicalIndicationName ,
                                              A73ResidentBirthDate } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV56Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext), "%", "");
         lV58Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV60Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV62Trn_residentwwds_7_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber), "%", "");
         lV64Trn_residentwwds_9_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail), "%", "");
         lV67Trn_residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone), 20, "%");
         lV71Trn_residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename), "%", "");
         lV73Trn_residentwwds_18_tfmedicalindicationname = StringUtil.Concat( StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname), "%", "");
         /* Using cursor P007B8 */
         pr_default.execute(6, new Object[] {lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV56Trn_residentwwds_1_filterfulltext, lV58Trn_residentwwds_3_tfresidentgivenname, AV59Trn_residentwwds_4_tfresidentgivenname_sel, lV60Trn_residentwwds_5_tfresidentlastname, AV61Trn_residentwwds_6_tfresidentlastname_sel, lV62Trn_residentwwds_7_tfresidentbsnnumber, AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, lV64Trn_residentwwds_9_tfresidentemail, AV65Trn_residentwwds_10_tfresidentemail_sel, lV67Trn_residentwwds_12_tfresidentphone, AV68Trn_residentwwds_13_tfresidentphone_sel, AV69Trn_residentwwds_14_tfresidentbirthdate, AV70Trn_residentwwds_15_tfresidentbirthdate_to, lV71Trn_residentwwds_16_tfresidenttypename, AV72Trn_residentwwds_17_tfresidenttypename_sel, lV73Trn_residentwwds_18_tfmedicalindicationname, AV74Trn_residentwwds_19_tfmedicalindicationname_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK7B14 = false;
            A96ResidentTypeId = P007B8_A96ResidentTypeId[0];
            A98MedicalIndicationId = P007B8_A98MedicalIndicationId[0];
            A73ResidentBirthDate = P007B8_A73ResidentBirthDate[0];
            A99MedicalIndicationName = P007B8_A99MedicalIndicationName[0];
            A97ResidentTypeName = P007B8_A97ResidentTypeName[0];
            A70ResidentPhone = P007B8_A70ResidentPhone[0];
            A68ResidentGender = P007B8_A68ResidentGender[0];
            A67ResidentEmail = P007B8_A67ResidentEmail[0];
            A63ResidentBsnNumber = P007B8_A63ResidentBsnNumber[0];
            A65ResidentLastName = P007B8_A65ResidentLastName[0];
            A64ResidentGivenName = P007B8_A64ResidentGivenName[0];
            A72ResidentSalutation = P007B8_A72ResidentSalutation[0];
            A62ResidentId = P007B8_A62ResidentId[0];
            A29LocationId = P007B8_A29LocationId[0];
            A11OrganisationId = P007B8_A11OrganisationId[0];
            A97ResidentTypeName = P007B8_A97ResidentTypeName[0];
            A99MedicalIndicationName = P007B8_A99MedicalIndicationName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( P007B8_A98MedicalIndicationId[0] == A98MedicalIndicationId ) )
            {
               BRK7B14 = false;
               A62ResidentId = P007B8_A62ResidentId[0];
               A29LocationId = P007B8_A29LocationId[0];
               A11OrganisationId = P007B8_A11OrganisationId[0];
               AV41count = (long)(AV41count+1);
               BRK7B14 = true;
               pr_default.readNext(6);
            }
            AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A99MedicalIndicationName)) ? "<#Empty#>" : A99MedicalIndicationName);
            AV35InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV35InsertIndex = (int)(AV35InsertIndex+1);
            }
            AV37Options.Add(AV36Option, AV35InsertIndex);
            AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
            if ( AV37Options.Count == AV32SkipItems + 11 )
            {
               AV37Options.RemoveItem(AV37Options.Count);
               AV40OptionIndexes.RemoveItem(AV40OptionIndexes.Count);
            }
            if ( ! BRK7B14 )
            {
               BRK7B14 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
         while ( AV32SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV40OptionIndexes.RemoveItem(1);
            AV32SkipItems = (short)(AV32SkipItems-1);
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
         AV50OptionsJson = "";
         AV51OptionsDescJson = "";
         AV52OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV39OptionsDesc = new GxSimpleCollection<string>();
         AV40OptionIndexes = new GxSimpleCollection<string>();
         AV31SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV42Session = context.GetSession();
         AV44GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV45GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53FilterFullText = "";
         AV11TFResidentSalutation_SelsJson = "";
         AV12TFResidentSalutation_Sels = new GxSimpleCollection<string>();
         AV13TFResidentGivenName = "";
         AV14TFResidentGivenName_Sel = "";
         AV15TFResidentLastName = "";
         AV16TFResidentLastName_Sel = "";
         AV17TFResidentBsnNumber = "";
         AV18TFResidentBsnNumber_Sel = "";
         AV19TFResidentEmail = "";
         AV20TFResidentEmail_Sel = "";
         AV21TFResidentGender_SelsJson = "";
         AV22TFResidentGender_Sels = new GxSimpleCollection<string>();
         AV23TFResidentPhone = "";
         AV24TFResidentPhone_Sel = "";
         AV25TFResidentBirthDate = DateTime.MinValue;
         AV26TFResidentBirthDate_To = DateTime.MinValue;
         AV27TFResidentTypeName = "";
         AV28TFResidentTypeName_Sel = "";
         AV29TFMedicalIndicationName = "";
         AV30TFMedicalIndicationName_Sel = "";
         AV56Trn_residentwwds_1_filterfulltext = "";
         AV57Trn_residentwwds_2_tfresidentsalutation_sels = new GxSimpleCollection<string>();
         AV58Trn_residentwwds_3_tfresidentgivenname = "";
         AV59Trn_residentwwds_4_tfresidentgivenname_sel = "";
         AV60Trn_residentwwds_5_tfresidentlastname = "";
         AV61Trn_residentwwds_6_tfresidentlastname_sel = "";
         AV62Trn_residentwwds_7_tfresidentbsnnumber = "";
         AV63Trn_residentwwds_8_tfresidentbsnnumber_sel = "";
         AV64Trn_residentwwds_9_tfresidentemail = "";
         AV65Trn_residentwwds_10_tfresidentemail_sel = "";
         AV66Trn_residentwwds_11_tfresidentgender_sels = new GxSimpleCollection<string>();
         AV67Trn_residentwwds_12_tfresidentphone = "";
         AV68Trn_residentwwds_13_tfresidentphone_sel = "";
         AV69Trn_residentwwds_14_tfresidentbirthdate = DateTime.MinValue;
         AV70Trn_residentwwds_15_tfresidentbirthdate_to = DateTime.MinValue;
         AV71Trn_residentwwds_16_tfresidenttypename = "";
         AV72Trn_residentwwds_17_tfresidenttypename_sel = "";
         AV73Trn_residentwwds_18_tfmedicalindicationname = "";
         AV74Trn_residentwwds_19_tfmedicalindicationname_sel = "";
         lV56Trn_residentwwds_1_filterfulltext = "";
         lV58Trn_residentwwds_3_tfresidentgivenname = "";
         lV60Trn_residentwwds_5_tfresidentlastname = "";
         lV62Trn_residentwwds_7_tfresidentbsnnumber = "";
         lV64Trn_residentwwds_9_tfresidentemail = "";
         lV67Trn_residentwwds_12_tfresidentphone = "";
         lV71Trn_residentwwds_16_tfresidenttypename = "";
         lV73Trn_residentwwds_18_tfmedicalindicationname = "";
         A72ResidentSalutation = "";
         A68ResidentGender = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A63ResidentBsnNumber = "";
         A67ResidentEmail = "";
         A70ResidentPhone = "";
         A97ResidentTypeName = "";
         A99MedicalIndicationName = "";
         A73ResidentBirthDate = DateTime.MinValue;
         P007B2_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B2_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P007B2_A64ResidentGivenName = new string[] {""} ;
         P007B2_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P007B2_A99MedicalIndicationName = new string[] {""} ;
         P007B2_A97ResidentTypeName = new string[] {""} ;
         P007B2_A70ResidentPhone = new string[] {""} ;
         P007B2_A68ResidentGender = new string[] {""} ;
         P007B2_A67ResidentEmail = new string[] {""} ;
         P007B2_A63ResidentBsnNumber = new string[] {""} ;
         P007B2_A65ResidentLastName = new string[] {""} ;
         P007B2_A72ResidentSalutation = new string[] {""} ;
         P007B2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A96ResidentTypeId = Guid.Empty;
         A98MedicalIndicationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV36Option = "";
         P007B3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B3_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P007B3_A65ResidentLastName = new string[] {""} ;
         P007B3_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P007B3_A99MedicalIndicationName = new string[] {""} ;
         P007B3_A97ResidentTypeName = new string[] {""} ;
         P007B3_A70ResidentPhone = new string[] {""} ;
         P007B3_A68ResidentGender = new string[] {""} ;
         P007B3_A67ResidentEmail = new string[] {""} ;
         P007B3_A63ResidentBsnNumber = new string[] {""} ;
         P007B3_A64ResidentGivenName = new string[] {""} ;
         P007B3_A72ResidentSalutation = new string[] {""} ;
         P007B3_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B3_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007B4_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B4_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P007B4_A63ResidentBsnNumber = new string[] {""} ;
         P007B4_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P007B4_A99MedicalIndicationName = new string[] {""} ;
         P007B4_A97ResidentTypeName = new string[] {""} ;
         P007B4_A70ResidentPhone = new string[] {""} ;
         P007B4_A68ResidentGender = new string[] {""} ;
         P007B4_A67ResidentEmail = new string[] {""} ;
         P007B4_A65ResidentLastName = new string[] {""} ;
         P007B4_A64ResidentGivenName = new string[] {""} ;
         P007B4_A72ResidentSalutation = new string[] {""} ;
         P007B4_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B4_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007B5_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B5_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P007B5_A67ResidentEmail = new string[] {""} ;
         P007B5_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P007B5_A99MedicalIndicationName = new string[] {""} ;
         P007B5_A97ResidentTypeName = new string[] {""} ;
         P007B5_A70ResidentPhone = new string[] {""} ;
         P007B5_A68ResidentGender = new string[] {""} ;
         P007B5_A63ResidentBsnNumber = new string[] {""} ;
         P007B5_A65ResidentLastName = new string[] {""} ;
         P007B5_A64ResidentGivenName = new string[] {""} ;
         P007B5_A72ResidentSalutation = new string[] {""} ;
         P007B5_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B5_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007B6_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B6_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P007B6_A70ResidentPhone = new string[] {""} ;
         P007B6_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P007B6_A99MedicalIndicationName = new string[] {""} ;
         P007B6_A97ResidentTypeName = new string[] {""} ;
         P007B6_A68ResidentGender = new string[] {""} ;
         P007B6_A67ResidentEmail = new string[] {""} ;
         P007B6_A63ResidentBsnNumber = new string[] {""} ;
         P007B6_A65ResidentLastName = new string[] {""} ;
         P007B6_A64ResidentGivenName = new string[] {""} ;
         P007B6_A72ResidentSalutation = new string[] {""} ;
         P007B6_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B6_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007B7_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P007B7_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B7_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P007B7_A99MedicalIndicationName = new string[] {""} ;
         P007B7_A97ResidentTypeName = new string[] {""} ;
         P007B7_A70ResidentPhone = new string[] {""} ;
         P007B7_A68ResidentGender = new string[] {""} ;
         P007B7_A67ResidentEmail = new string[] {""} ;
         P007B7_A63ResidentBsnNumber = new string[] {""} ;
         P007B7_A65ResidentLastName = new string[] {""} ;
         P007B7_A64ResidentGivenName = new string[] {""} ;
         P007B7_A72ResidentSalutation = new string[] {""} ;
         P007B7_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B7_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007B8_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         P007B8_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         P007B8_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         P007B8_A99MedicalIndicationName = new string[] {""} ;
         P007B8_A97ResidentTypeName = new string[] {""} ;
         P007B8_A70ResidentPhone = new string[] {""} ;
         P007B8_A68ResidentGender = new string[] {""} ;
         P007B8_A67ResidentEmail = new string[] {""} ;
         P007B8_A63ResidentBsnNumber = new string[] {""} ;
         P007B8_A65ResidentLastName = new string[] {""} ;
         P007B8_A64ResidentGivenName = new string[] {""} ;
         P007B8_A72ResidentSalutation = new string[] {""} ;
         P007B8_A62ResidentId = new Guid[] {Guid.Empty} ;
         P007B8_A29LocationId = new Guid[] {Guid.Empty} ;
         P007B8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007B2_A96ResidentTypeId, P007B2_A98MedicalIndicationId, P007B2_A64ResidentGivenName, P007B2_A73ResidentBirthDate, P007B2_A99MedicalIndicationName, P007B2_A97ResidentTypeName, P007B2_A70ResidentPhone, P007B2_A68ResidentGender, P007B2_A67ResidentEmail, P007B2_A63ResidentBsnNumber,
               P007B2_A65ResidentLastName, P007B2_A72ResidentSalutation, P007B2_A62ResidentId, P007B2_A29LocationId, P007B2_A11OrganisationId
               }
               , new Object[] {
               P007B3_A96ResidentTypeId, P007B3_A98MedicalIndicationId, P007B3_A65ResidentLastName, P007B3_A73ResidentBirthDate, P007B3_A99MedicalIndicationName, P007B3_A97ResidentTypeName, P007B3_A70ResidentPhone, P007B3_A68ResidentGender, P007B3_A67ResidentEmail, P007B3_A63ResidentBsnNumber,
               P007B3_A64ResidentGivenName, P007B3_A72ResidentSalutation, P007B3_A62ResidentId, P007B3_A29LocationId, P007B3_A11OrganisationId
               }
               , new Object[] {
               P007B4_A96ResidentTypeId, P007B4_A98MedicalIndicationId, P007B4_A63ResidentBsnNumber, P007B4_A73ResidentBirthDate, P007B4_A99MedicalIndicationName, P007B4_A97ResidentTypeName, P007B4_A70ResidentPhone, P007B4_A68ResidentGender, P007B4_A67ResidentEmail, P007B4_A65ResidentLastName,
               P007B4_A64ResidentGivenName, P007B4_A72ResidentSalutation, P007B4_A62ResidentId, P007B4_A29LocationId, P007B4_A11OrganisationId
               }
               , new Object[] {
               P007B5_A96ResidentTypeId, P007B5_A98MedicalIndicationId, P007B5_A67ResidentEmail, P007B5_A73ResidentBirthDate, P007B5_A99MedicalIndicationName, P007B5_A97ResidentTypeName, P007B5_A70ResidentPhone, P007B5_A68ResidentGender, P007B5_A63ResidentBsnNumber, P007B5_A65ResidentLastName,
               P007B5_A64ResidentGivenName, P007B5_A72ResidentSalutation, P007B5_A62ResidentId, P007B5_A29LocationId, P007B5_A11OrganisationId
               }
               , new Object[] {
               P007B6_A96ResidentTypeId, P007B6_A98MedicalIndicationId, P007B6_A70ResidentPhone, P007B6_A73ResidentBirthDate, P007B6_A99MedicalIndicationName, P007B6_A97ResidentTypeName, P007B6_A68ResidentGender, P007B6_A67ResidentEmail, P007B6_A63ResidentBsnNumber, P007B6_A65ResidentLastName,
               P007B6_A64ResidentGivenName, P007B6_A72ResidentSalutation, P007B6_A62ResidentId, P007B6_A29LocationId, P007B6_A11OrganisationId
               }
               , new Object[] {
               P007B7_A98MedicalIndicationId, P007B7_A96ResidentTypeId, P007B7_A73ResidentBirthDate, P007B7_A99MedicalIndicationName, P007B7_A97ResidentTypeName, P007B7_A70ResidentPhone, P007B7_A68ResidentGender, P007B7_A67ResidentEmail, P007B7_A63ResidentBsnNumber, P007B7_A65ResidentLastName,
               P007B7_A64ResidentGivenName, P007B7_A72ResidentSalutation, P007B7_A62ResidentId, P007B7_A29LocationId, P007B7_A11OrganisationId
               }
               , new Object[] {
               P007B8_A96ResidentTypeId, P007B8_A98MedicalIndicationId, P007B8_A73ResidentBirthDate, P007B8_A99MedicalIndicationName, P007B8_A97ResidentTypeName, P007B8_A70ResidentPhone, P007B8_A68ResidentGender, P007B8_A67ResidentEmail, P007B8_A63ResidentBsnNumber, P007B8_A65ResidentLastName,
               P007B8_A64ResidentGivenName, P007B8_A72ResidentSalutation, P007B8_A62ResidentId, P007B8_A29LocationId, P007B8_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private int AV54GXV1 ;
      private int AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count ;
      private int AV66Trn_residentwwds_11_tfresidentgender_sels_Count ;
      private int AV35InsertIndex ;
      private long AV41count ;
      private string AV23TFResidentPhone ;
      private string AV24TFResidentPhone_Sel ;
      private string AV67Trn_residentwwds_12_tfresidentphone ;
      private string AV68Trn_residentwwds_13_tfresidentphone_sel ;
      private string lV67Trn_residentwwds_12_tfresidentphone ;
      private string A72ResidentSalutation ;
      private string A70ResidentPhone ;
      private DateTime AV25TFResidentBirthDate ;
      private DateTime AV26TFResidentBirthDate_To ;
      private DateTime AV69Trn_residentwwds_14_tfresidentbirthdate ;
      private DateTime AV70Trn_residentwwds_15_tfresidentbirthdate_to ;
      private DateTime A73ResidentBirthDate ;
      private bool returnInSub ;
      private bool BRK7B2 ;
      private bool BRK7B4 ;
      private bool BRK7B6 ;
      private bool BRK7B8 ;
      private bool BRK7B10 ;
      private bool BRK7B12 ;
      private bool BRK7B14 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string AV11TFResidentSalutation_SelsJson ;
      private string AV21TFResidentGender_SelsJson ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string AV13TFResidentGivenName ;
      private string AV14TFResidentGivenName_Sel ;
      private string AV15TFResidentLastName ;
      private string AV16TFResidentLastName_Sel ;
      private string AV17TFResidentBsnNumber ;
      private string AV18TFResidentBsnNumber_Sel ;
      private string AV19TFResidentEmail ;
      private string AV20TFResidentEmail_Sel ;
      private string AV27TFResidentTypeName ;
      private string AV28TFResidentTypeName_Sel ;
      private string AV29TFMedicalIndicationName ;
      private string AV30TFMedicalIndicationName_Sel ;
      private string AV56Trn_residentwwds_1_filterfulltext ;
      private string AV58Trn_residentwwds_3_tfresidentgivenname ;
      private string AV59Trn_residentwwds_4_tfresidentgivenname_sel ;
      private string AV60Trn_residentwwds_5_tfresidentlastname ;
      private string AV61Trn_residentwwds_6_tfresidentlastname_sel ;
      private string AV62Trn_residentwwds_7_tfresidentbsnnumber ;
      private string AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ;
      private string AV64Trn_residentwwds_9_tfresidentemail ;
      private string AV65Trn_residentwwds_10_tfresidentemail_sel ;
      private string AV71Trn_residentwwds_16_tfresidenttypename ;
      private string AV72Trn_residentwwds_17_tfresidenttypename_sel ;
      private string AV73Trn_residentwwds_18_tfmedicalindicationname ;
      private string AV74Trn_residentwwds_19_tfmedicalindicationname_sel ;
      private string lV56Trn_residentwwds_1_filterfulltext ;
      private string lV58Trn_residentwwds_3_tfresidentgivenname ;
      private string lV60Trn_residentwwds_5_tfresidentlastname ;
      private string lV62Trn_residentwwds_7_tfresidentbsnnumber ;
      private string lV64Trn_residentwwds_9_tfresidentemail ;
      private string lV71Trn_residentwwds_16_tfresidenttypename ;
      private string lV73Trn_residentwwds_18_tfmedicalindicationname ;
      private string A68ResidentGender ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A63ResidentBsnNumber ;
      private string A67ResidentEmail ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private string AV36Option ;
      private Guid A96ResidentTypeId ;
      private Guid A98MedicalIndicationId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV42Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV39OptionsDesc ;
      private GxSimpleCollection<string> AV40OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV44GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV45GridStateFilterValue ;
      private GxSimpleCollection<string> AV12TFResidentSalutation_Sels ;
      private GxSimpleCollection<string> AV22TFResidentGender_Sels ;
      private GxSimpleCollection<string> AV57Trn_residentwwds_2_tfresidentsalutation_sels ;
      private GxSimpleCollection<string> AV66Trn_residentwwds_11_tfresidentgender_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007B2_A96ResidentTypeId ;
      private Guid[] P007B2_A98MedicalIndicationId ;
      private string[] P007B2_A64ResidentGivenName ;
      private DateTime[] P007B2_A73ResidentBirthDate ;
      private string[] P007B2_A99MedicalIndicationName ;
      private string[] P007B2_A97ResidentTypeName ;
      private string[] P007B2_A70ResidentPhone ;
      private string[] P007B2_A68ResidentGender ;
      private string[] P007B2_A67ResidentEmail ;
      private string[] P007B2_A63ResidentBsnNumber ;
      private string[] P007B2_A65ResidentLastName ;
      private string[] P007B2_A72ResidentSalutation ;
      private Guid[] P007B2_A62ResidentId ;
      private Guid[] P007B2_A29LocationId ;
      private Guid[] P007B2_A11OrganisationId ;
      private Guid[] P007B3_A96ResidentTypeId ;
      private Guid[] P007B3_A98MedicalIndicationId ;
      private string[] P007B3_A65ResidentLastName ;
      private DateTime[] P007B3_A73ResidentBirthDate ;
      private string[] P007B3_A99MedicalIndicationName ;
      private string[] P007B3_A97ResidentTypeName ;
      private string[] P007B3_A70ResidentPhone ;
      private string[] P007B3_A68ResidentGender ;
      private string[] P007B3_A67ResidentEmail ;
      private string[] P007B3_A63ResidentBsnNumber ;
      private string[] P007B3_A64ResidentGivenName ;
      private string[] P007B3_A72ResidentSalutation ;
      private Guid[] P007B3_A62ResidentId ;
      private Guid[] P007B3_A29LocationId ;
      private Guid[] P007B3_A11OrganisationId ;
      private Guid[] P007B4_A96ResidentTypeId ;
      private Guid[] P007B4_A98MedicalIndicationId ;
      private string[] P007B4_A63ResidentBsnNumber ;
      private DateTime[] P007B4_A73ResidentBirthDate ;
      private string[] P007B4_A99MedicalIndicationName ;
      private string[] P007B4_A97ResidentTypeName ;
      private string[] P007B4_A70ResidentPhone ;
      private string[] P007B4_A68ResidentGender ;
      private string[] P007B4_A67ResidentEmail ;
      private string[] P007B4_A65ResidentLastName ;
      private string[] P007B4_A64ResidentGivenName ;
      private string[] P007B4_A72ResidentSalutation ;
      private Guid[] P007B4_A62ResidentId ;
      private Guid[] P007B4_A29LocationId ;
      private Guid[] P007B4_A11OrganisationId ;
      private Guid[] P007B5_A96ResidentTypeId ;
      private Guid[] P007B5_A98MedicalIndicationId ;
      private string[] P007B5_A67ResidentEmail ;
      private DateTime[] P007B5_A73ResidentBirthDate ;
      private string[] P007B5_A99MedicalIndicationName ;
      private string[] P007B5_A97ResidentTypeName ;
      private string[] P007B5_A70ResidentPhone ;
      private string[] P007B5_A68ResidentGender ;
      private string[] P007B5_A63ResidentBsnNumber ;
      private string[] P007B5_A65ResidentLastName ;
      private string[] P007B5_A64ResidentGivenName ;
      private string[] P007B5_A72ResidentSalutation ;
      private Guid[] P007B5_A62ResidentId ;
      private Guid[] P007B5_A29LocationId ;
      private Guid[] P007B5_A11OrganisationId ;
      private Guid[] P007B6_A96ResidentTypeId ;
      private Guid[] P007B6_A98MedicalIndicationId ;
      private string[] P007B6_A70ResidentPhone ;
      private DateTime[] P007B6_A73ResidentBirthDate ;
      private string[] P007B6_A99MedicalIndicationName ;
      private string[] P007B6_A97ResidentTypeName ;
      private string[] P007B6_A68ResidentGender ;
      private string[] P007B6_A67ResidentEmail ;
      private string[] P007B6_A63ResidentBsnNumber ;
      private string[] P007B6_A65ResidentLastName ;
      private string[] P007B6_A64ResidentGivenName ;
      private string[] P007B6_A72ResidentSalutation ;
      private Guid[] P007B6_A62ResidentId ;
      private Guid[] P007B6_A29LocationId ;
      private Guid[] P007B6_A11OrganisationId ;
      private Guid[] P007B7_A98MedicalIndicationId ;
      private Guid[] P007B7_A96ResidentTypeId ;
      private DateTime[] P007B7_A73ResidentBirthDate ;
      private string[] P007B7_A99MedicalIndicationName ;
      private string[] P007B7_A97ResidentTypeName ;
      private string[] P007B7_A70ResidentPhone ;
      private string[] P007B7_A68ResidentGender ;
      private string[] P007B7_A67ResidentEmail ;
      private string[] P007B7_A63ResidentBsnNumber ;
      private string[] P007B7_A65ResidentLastName ;
      private string[] P007B7_A64ResidentGivenName ;
      private string[] P007B7_A72ResidentSalutation ;
      private Guid[] P007B7_A62ResidentId ;
      private Guid[] P007B7_A29LocationId ;
      private Guid[] P007B7_A11OrganisationId ;
      private Guid[] P007B8_A96ResidentTypeId ;
      private Guid[] P007B8_A98MedicalIndicationId ;
      private DateTime[] P007B8_A73ResidentBirthDate ;
      private string[] P007B8_A99MedicalIndicationName ;
      private string[] P007B8_A97ResidentTypeName ;
      private string[] P007B8_A70ResidentPhone ;
      private string[] P007B8_A68ResidentGender ;
      private string[] P007B8_A67ResidentEmail ;
      private string[] P007B8_A63ResidentBsnNumber ;
      private string[] P007B8_A65ResidentLastName ;
      private string[] P007B8_A64ResidentGivenName ;
      private string[] P007B8_A72ResidentSalutation ;
      private Guid[] P007B8_A62ResidentId ;
      private Guid[] P007B8_A29LocationId ;
      private Guid[] P007B8_A11OrganisationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_residentwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007B2( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                             string AV56Trn_residentwwds_1_filterfulltext ,
                                             int AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV58Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV60Trn_residentwwds_5_tfresidentlastname ,
                                             string AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                             string AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                             string AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                             string AV64Trn_residentwwds_9_tfresidentemail ,
                                             int AV66Trn_residentwwds_11_tfresidentgender_sels_Count ,
                                             string AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                             string AV67Trn_residentwwds_12_tfresidentphone ,
                                             DateTime AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                             DateTime AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                             string AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                             string AV71Trn_residentwwds_16_tfresidenttypename ,
                                             string AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                             string AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A63ResidentBsnNumber ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string A99MedicalIndicationName ,
                                             DateTime A73ResidentBirthDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[30];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.MedicalIndicationId, T1.ResidentGivenName, T1.ResidentBirthDate, T3.MedicalIndicationName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentGender, T1.ResidentEmail, T1.ResidentBsnNumber, T1.ResidentLastName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM ((Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) INNER JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'mr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mr')) or ( 'mrs' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mrs')) or ( 'dr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Dr')) or ( 'miss' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Miss')) or ( T1.ResidentGivenName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Other')) or ( T1.ResidentPhone like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T3.MedicalIndicationName like '%' || :lV56Trn_residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
            GXv_int1[12] = 1;
            GXv_int1[13] = 1;
         }
         if ( AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV58Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV59Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV60Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV61Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV62Trn_residentwwds_7_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV63Trn_residentwwds_8_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV64Trn_residentwwds_9_tfresidentemail)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV65Trn_residentwwds_10_tfresidentemail_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( AV66Trn_residentwwds_11_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_residentwwds_11_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV67Trn_residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV68Trn_residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Trn_residentwwds_14_tfresidentbirthdate) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate >= :AV69Trn_residentwwds_14_tfresidentbirthdate)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Trn_residentwwds_15_tfresidentbirthdate_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate <= :AV70Trn_residentwwds_15_tfresidentbirthdate_to)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV71Trn_residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV72Trn_residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname)) ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName like :lV73Trn_residentwwds_18_tfmedicalindicationname)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName = ( :AV74Trn_residentwwds_19_tfmedicalindicationname_sel))");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.MedicalIndicationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentGivenName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007B3( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                             string AV56Trn_residentwwds_1_filterfulltext ,
                                             int AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV58Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV60Trn_residentwwds_5_tfresidentlastname ,
                                             string AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                             string AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                             string AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                             string AV64Trn_residentwwds_9_tfresidentemail ,
                                             int AV66Trn_residentwwds_11_tfresidentgender_sels_Count ,
                                             string AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                             string AV67Trn_residentwwds_12_tfresidentphone ,
                                             DateTime AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                             DateTime AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                             string AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                             string AV71Trn_residentwwds_16_tfresidenttypename ,
                                             string AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                             string AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A63ResidentBsnNumber ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string A99MedicalIndicationName ,
                                             DateTime A73ResidentBirthDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[30];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.MedicalIndicationId, T1.ResidentLastName, T1.ResidentBirthDate, T3.MedicalIndicationName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentGender, T1.ResidentEmail, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM ((Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) INNER JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'mr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mr')) or ( 'mrs' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mrs')) or ( 'dr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Dr')) or ( 'miss' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Miss')) or ( T1.ResidentGivenName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Other')) or ( T1.ResidentPhone like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T3.MedicalIndicationName like '%' || :lV56Trn_residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
            GXv_int3[10] = 1;
            GXv_int3[11] = 1;
            GXv_int3[12] = 1;
            GXv_int3[13] = 1;
         }
         if ( AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV58Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV59Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV60Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV61Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV62Trn_residentwwds_7_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV63Trn_residentwwds_8_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV64Trn_residentwwds_9_tfresidentemail)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV65Trn_residentwwds_10_tfresidentemail_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( AV66Trn_residentwwds_11_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_residentwwds_11_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV67Trn_residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV68Trn_residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Trn_residentwwds_14_tfresidentbirthdate) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate >= :AV69Trn_residentwwds_14_tfresidentbirthdate)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Trn_residentwwds_15_tfresidentbirthdate_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate <= :AV70Trn_residentwwds_15_tfresidentbirthdate_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV71Trn_residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV72Trn_residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname)) ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName like :lV73Trn_residentwwds_18_tfmedicalindicationname)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName = ( :AV74Trn_residentwwds_19_tfmedicalindicationname_sel))");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.MedicalIndicationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentLastName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007B4( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                             string AV56Trn_residentwwds_1_filterfulltext ,
                                             int AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV58Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV60Trn_residentwwds_5_tfresidentlastname ,
                                             string AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                             string AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                             string AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                             string AV64Trn_residentwwds_9_tfresidentemail ,
                                             int AV66Trn_residentwwds_11_tfresidentgender_sels_Count ,
                                             string AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                             string AV67Trn_residentwwds_12_tfresidentphone ,
                                             DateTime AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                             DateTime AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                             string AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                             string AV71Trn_residentwwds_16_tfresidenttypename ,
                                             string AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                             string AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A63ResidentBsnNumber ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string A99MedicalIndicationName ,
                                             DateTime A73ResidentBirthDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[30];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.MedicalIndicationId, T1.ResidentBsnNumber, T1.ResidentBirthDate, T3.MedicalIndicationName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentGender, T1.ResidentEmail, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM ((Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) INNER JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'mr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mr')) or ( 'mrs' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mrs')) or ( 'dr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Dr')) or ( 'miss' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Miss')) or ( T1.ResidentGivenName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Other')) or ( T1.ResidentPhone like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T3.MedicalIndicationName like '%' || :lV56Trn_residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
            GXv_int5[13] = 1;
         }
         if ( AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV58Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV59Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV60Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV61Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV62Trn_residentwwds_7_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV63Trn_residentwwds_8_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV64Trn_residentwwds_9_tfresidentemail)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV65Trn_residentwwds_10_tfresidentemail_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( AV66Trn_residentwwds_11_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_residentwwds_11_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV67Trn_residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV68Trn_residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Trn_residentwwds_14_tfresidentbirthdate) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate >= :AV69Trn_residentwwds_14_tfresidentbirthdate)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Trn_residentwwds_15_tfresidentbirthdate_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate <= :AV70Trn_residentwwds_15_tfresidentbirthdate_to)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV71Trn_residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV72Trn_residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname)) ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName like :lV73Trn_residentwwds_18_tfmedicalindicationname)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName = ( :AV74Trn_residentwwds_19_tfmedicalindicationname_sel))");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.MedicalIndicationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentBsnNumber";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P007B5( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                             string AV56Trn_residentwwds_1_filterfulltext ,
                                             int AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV58Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV60Trn_residentwwds_5_tfresidentlastname ,
                                             string AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                             string AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                             string AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                             string AV64Trn_residentwwds_9_tfresidentemail ,
                                             int AV66Trn_residentwwds_11_tfresidentgender_sels_Count ,
                                             string AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                             string AV67Trn_residentwwds_12_tfresidentphone ,
                                             DateTime AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                             DateTime AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                             string AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                             string AV71Trn_residentwwds_16_tfresidenttypename ,
                                             string AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                             string AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A63ResidentBsnNumber ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string A99MedicalIndicationName ,
                                             DateTime A73ResidentBirthDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[30];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.MedicalIndicationId, T1.ResidentEmail, T1.ResidentBirthDate, T3.MedicalIndicationName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentGender, T1.ResidentBsnNumber, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM ((Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) INNER JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'mr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mr')) or ( 'mrs' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mrs')) or ( 'dr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Dr')) or ( 'miss' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Miss')) or ( T1.ResidentGivenName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Other')) or ( T1.ResidentPhone like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T3.MedicalIndicationName like '%' || :lV56Trn_residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
            GXv_int7[10] = 1;
            GXv_int7[11] = 1;
            GXv_int7[12] = 1;
            GXv_int7[13] = 1;
         }
         if ( AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV58Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV59Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV60Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV61Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV62Trn_residentwwds_7_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV63Trn_residentwwds_8_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV64Trn_residentwwds_9_tfresidentemail)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV65Trn_residentwwds_10_tfresidentemail_sel))");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( AV66Trn_residentwwds_11_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_residentwwds_11_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV67Trn_residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV68Trn_residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Trn_residentwwds_14_tfresidentbirthdate) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate >= :AV69Trn_residentwwds_14_tfresidentbirthdate)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Trn_residentwwds_15_tfresidentbirthdate_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate <= :AV70Trn_residentwwds_15_tfresidentbirthdate_to)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV71Trn_residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV72Trn_residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname)) ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName like :lV73Trn_residentwwds_18_tfmedicalindicationname)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName = ( :AV74Trn_residentwwds_19_tfmedicalindicationname_sel))");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.MedicalIndicationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentEmail";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P007B6( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                             string AV56Trn_residentwwds_1_filterfulltext ,
                                             int AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV58Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV60Trn_residentwwds_5_tfresidentlastname ,
                                             string AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                             string AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                             string AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                             string AV64Trn_residentwwds_9_tfresidentemail ,
                                             int AV66Trn_residentwwds_11_tfresidentgender_sels_Count ,
                                             string AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                             string AV67Trn_residentwwds_12_tfresidentphone ,
                                             DateTime AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                             DateTime AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                             string AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                             string AV71Trn_residentwwds_16_tfresidenttypename ,
                                             string AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                             string AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A63ResidentBsnNumber ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string A99MedicalIndicationName ,
                                             DateTime A73ResidentBirthDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[30];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.MedicalIndicationId, T1.ResidentPhone, T1.ResidentBirthDate, T3.MedicalIndicationName, T2.ResidentTypeName, T1.ResidentGender, T1.ResidentEmail, T1.ResidentBsnNumber, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM ((Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) INNER JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'mr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mr')) or ( 'mrs' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mrs')) or ( 'dr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Dr')) or ( 'miss' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Miss')) or ( T1.ResidentGivenName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Other')) or ( T1.ResidentPhone like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T3.MedicalIndicationName like '%' || :lV56Trn_residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
            GXv_int9[9] = 1;
            GXv_int9[10] = 1;
            GXv_int9[11] = 1;
            GXv_int9[12] = 1;
            GXv_int9[13] = 1;
         }
         if ( AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV58Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV59Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV60Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV61Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV62Trn_residentwwds_7_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV63Trn_residentwwds_8_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV64Trn_residentwwds_9_tfresidentemail)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV65Trn_residentwwds_10_tfresidentemail_sel))");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( AV66Trn_residentwwds_11_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_residentwwds_11_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV67Trn_residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV68Trn_residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Trn_residentwwds_14_tfresidentbirthdate) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate >= :AV69Trn_residentwwds_14_tfresidentbirthdate)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Trn_residentwwds_15_tfresidentbirthdate_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate <= :AV70Trn_residentwwds_15_tfresidentbirthdate_to)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV71Trn_residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV72Trn_residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname)) ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName like :lV73Trn_residentwwds_18_tfmedicalindicationname)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName = ( :AV74Trn_residentwwds_19_tfmedicalindicationname_sel))");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.MedicalIndicationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentPhone";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P007B7( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                             string AV56Trn_residentwwds_1_filterfulltext ,
                                             int AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV58Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV60Trn_residentwwds_5_tfresidentlastname ,
                                             string AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                             string AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                             string AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                             string AV64Trn_residentwwds_9_tfresidentemail ,
                                             int AV66Trn_residentwwds_11_tfresidentgender_sels_Count ,
                                             string AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                             string AV67Trn_residentwwds_12_tfresidentphone ,
                                             DateTime AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                             DateTime AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                             string AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                             string AV71Trn_residentwwds_16_tfresidenttypename ,
                                             string AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                             string AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A63ResidentBsnNumber ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string A99MedicalIndicationName ,
                                             DateTime A73ResidentBirthDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[30];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.MedicalIndicationId, T1.ResidentTypeId, T1.ResidentBirthDate, T2.MedicalIndicationName, T3.ResidentTypeName, T1.ResidentPhone, T1.ResidentGender, T1.ResidentEmail, T1.ResidentBsnNumber, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM ((Trn_Resident T1 INNER JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) INNER JOIN Trn_ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'mr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mr')) or ( 'mrs' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mrs')) or ( 'dr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Dr')) or ( 'miss' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Miss')) or ( T1.ResidentGivenName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Other')) or ( T1.ResidentPhone like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T3.ResidentTypeName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T2.MedicalIndicationName like '%' || :lV56Trn_residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
            GXv_int11[8] = 1;
            GXv_int11[9] = 1;
            GXv_int11[10] = 1;
            GXv_int11[11] = 1;
            GXv_int11[12] = 1;
            GXv_int11[13] = 1;
         }
         if ( AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV58Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV59Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV60Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV61Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV62Trn_residentwwds_7_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV63Trn_residentwwds_8_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV64Trn_residentwwds_9_tfresidentemail)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV65Trn_residentwwds_10_tfresidentemail_sel))");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( AV66Trn_residentwwds_11_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_residentwwds_11_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV67Trn_residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV68Trn_residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Trn_residentwwds_14_tfresidentbirthdate) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate >= :AV69Trn_residentwwds_14_tfresidentbirthdate)");
         }
         else
         {
            GXv_int11[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Trn_residentwwds_15_tfresidentbirthdate_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate <= :AV70Trn_residentwwds_15_tfresidentbirthdate_to)");
         }
         else
         {
            GXv_int11[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T3.ResidentTypeName like :lV71Trn_residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int11[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ResidentTypeName = ( :AV72Trn_residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int11[27] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ResidentTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname)) ) )
         {
            AddWhere(sWhereString, "(T2.MedicalIndicationName like :lV73Trn_residentwwds_18_tfmedicalindicationname)");
         }
         else
         {
            GXv_int11[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.MedicalIndicationName = ( :AV74Trn_residentwwds_19_tfmedicalindicationname_sel))");
         }
         else
         {
            GXv_int11[29] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.MedicalIndicationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentTypeId";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P007B8( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV57Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV66Trn_residentwwds_11_tfresidentgender_sels ,
                                             string AV56Trn_residentwwds_1_filterfulltext ,
                                             int AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV59Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV58Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV61Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV60Trn_residentwwds_5_tfresidentlastname ,
                                             string AV63Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                             string AV62Trn_residentwwds_7_tfresidentbsnnumber ,
                                             string AV65Trn_residentwwds_10_tfresidentemail_sel ,
                                             string AV64Trn_residentwwds_9_tfresidentemail ,
                                             int AV66Trn_residentwwds_11_tfresidentgender_sels_Count ,
                                             string AV68Trn_residentwwds_13_tfresidentphone_sel ,
                                             string AV67Trn_residentwwds_12_tfresidentphone ,
                                             DateTime AV69Trn_residentwwds_14_tfresidentbirthdate ,
                                             DateTime AV70Trn_residentwwds_15_tfresidentbirthdate_to ,
                                             string AV72Trn_residentwwds_17_tfresidenttypename_sel ,
                                             string AV71Trn_residentwwds_16_tfresidenttypename ,
                                             string AV74Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                             string AV73Trn_residentwwds_18_tfmedicalindicationname ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A63ResidentBsnNumber ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string A99MedicalIndicationName ,
                                             DateTime A73ResidentBirthDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[30];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.ResidentTypeId, T1.MedicalIndicationId, T1.ResidentBirthDate, T3.MedicalIndicationName, T2.ResidentTypeName, T1.ResidentPhone, T1.ResidentGender, T1.ResidentEmail, T1.ResidentBsnNumber, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM ((Trn_Resident T1 INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId) INNER JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'mr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mr')) or ( 'mrs' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mrs')) or ( 'dr' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Dr')) or ( 'miss' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Miss')) or ( T1.ResidentGivenName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV56Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Other')) or ( T1.ResidentPhone like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV56Trn_residentwwds_1_filterfulltext) or ( T3.MedicalIndicationName like '%' || :lV56Trn_residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int13[0] = 1;
            GXv_int13[1] = 1;
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
            GXv_int13[6] = 1;
            GXv_int13[7] = 1;
            GXv_int13[8] = 1;
            GXv_int13[9] = 1;
            GXv_int13[10] = 1;
            GXv_int13[11] = 1;
            GXv_int13[12] = 1;
            GXv_int13[13] = 1;
         }
         if ( AV57Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV58Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV59Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV60Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV61Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_7_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV62Trn_residentwwds_7_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV63Trn_residentwwds_8_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_9_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV64Trn_residentwwds_9_tfresidentemail)");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_10_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV65Trn_residentwwds_10_tfresidentemail_sel))");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( AV66Trn_residentwwds_11_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Trn_residentwwds_11_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV67Trn_residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV68Trn_residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( ! (DateTime.MinValue==AV69Trn_residentwwds_14_tfresidentbirthdate) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate >= :AV69Trn_residentwwds_14_tfresidentbirthdate)");
         }
         else
         {
            GXv_int13[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Trn_residentwwds_15_tfresidentbirthdate_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate <= :AV70Trn_residentwwds_15_tfresidentbirthdate_to)");
         }
         else
         {
            GXv_int13[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV71Trn_residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int13[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV72Trn_residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int13[27] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_18_tfmedicalindicationname)) ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName like :lV73Trn_residentwwds_18_tfmedicalindicationname)");
         }
         else
         {
            GXv_int13[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_19_tfmedicalindicationname_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName = ( :AV74Trn_residentwwds_19_tfmedicalindicationname_sel))");
         }
         else
         {
            GXv_int13[29] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.MedicalIndicationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.MedicalIndicationId";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007B2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] );
               case 1 :
                     return conditional_P007B3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] );
               case 2 :
                     return conditional_P007B4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] );
               case 3 :
                     return conditional_P007B5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] );
               case 4 :
                     return conditional_P007B6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] );
               case 5 :
                     return conditional_P007B7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] );
               case 6 :
                     return conditional_P007B8(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007B2;
          prmP007B2 = new Object[] {
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_7_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV63Trn_residentwwds_8_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV64Trn_residentwwds_9_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_10_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Trn_residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV68Trn_residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("AV69Trn_residentwwds_14_tfresidentbirthdate",GXType.Date,8,0) ,
          new ParDef("AV70Trn_residentwwds_15_tfresidentbirthdate_to",GXType.Date,8,0) ,
          new ParDef("lV71Trn_residentwwds_16_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_17_tfresidenttypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_18_tfmedicalindicationname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_19_tfmedicalindicationname_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B3;
          prmP007B3 = new Object[] {
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_7_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV63Trn_residentwwds_8_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV64Trn_residentwwds_9_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_10_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Trn_residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV68Trn_residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("AV69Trn_residentwwds_14_tfresidentbirthdate",GXType.Date,8,0) ,
          new ParDef("AV70Trn_residentwwds_15_tfresidentbirthdate_to",GXType.Date,8,0) ,
          new ParDef("lV71Trn_residentwwds_16_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_17_tfresidenttypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_18_tfmedicalindicationname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_19_tfmedicalindicationname_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B4;
          prmP007B4 = new Object[] {
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_7_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV63Trn_residentwwds_8_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV64Trn_residentwwds_9_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_10_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Trn_residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV68Trn_residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("AV69Trn_residentwwds_14_tfresidentbirthdate",GXType.Date,8,0) ,
          new ParDef("AV70Trn_residentwwds_15_tfresidentbirthdate_to",GXType.Date,8,0) ,
          new ParDef("lV71Trn_residentwwds_16_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_17_tfresidenttypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_18_tfmedicalindicationname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_19_tfmedicalindicationname_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B5;
          prmP007B5 = new Object[] {
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_7_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV63Trn_residentwwds_8_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV64Trn_residentwwds_9_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_10_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Trn_residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV68Trn_residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("AV69Trn_residentwwds_14_tfresidentbirthdate",GXType.Date,8,0) ,
          new ParDef("AV70Trn_residentwwds_15_tfresidentbirthdate_to",GXType.Date,8,0) ,
          new ParDef("lV71Trn_residentwwds_16_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_17_tfresidenttypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_18_tfmedicalindicationname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_19_tfmedicalindicationname_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B6;
          prmP007B6 = new Object[] {
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_7_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV63Trn_residentwwds_8_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV64Trn_residentwwds_9_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_10_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Trn_residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV68Trn_residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("AV69Trn_residentwwds_14_tfresidentbirthdate",GXType.Date,8,0) ,
          new ParDef("AV70Trn_residentwwds_15_tfresidentbirthdate_to",GXType.Date,8,0) ,
          new ParDef("lV71Trn_residentwwds_16_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_17_tfresidenttypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_18_tfmedicalindicationname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_19_tfmedicalindicationname_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B7;
          prmP007B7 = new Object[] {
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_7_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV63Trn_residentwwds_8_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV64Trn_residentwwds_9_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_10_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Trn_residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV68Trn_residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("AV69Trn_residentwwds_14_tfresidentbirthdate",GXType.Date,8,0) ,
          new ParDef("AV70Trn_residentwwds_15_tfresidentbirthdate_to",GXType.Date,8,0) ,
          new ParDef("lV71Trn_residentwwds_16_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_17_tfresidenttypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_18_tfmedicalindicationname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_19_tfmedicalindicationname_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B8;
          prmP007B8 = new Object[] {
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_7_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV63Trn_residentwwds_8_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV64Trn_residentwwds_9_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_10_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV67Trn_residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV68Trn_residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("AV69Trn_residentwwds_14_tfresidentbirthdate",GXType.Date,8,0) ,
          new ParDef("AV70Trn_residentwwds_15_tfresidentbirthdate_to",GXType.Date,8,0) ,
          new ParDef("lV71Trn_residentwwds_16_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_residentwwds_17_tfresidenttypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_18_tfmedicalindicationname",GXType.VarChar,100,0) ,
          new ParDef("AV74Trn_residentwwds_19_tfmedicalindicationname_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B8,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((Guid[]) buf[12])[0] = rslt.getGuid(13);
                ((Guid[]) buf[13])[0] = rslt.getGuid(14);
                ((Guid[]) buf[14])[0] = rslt.getGuid(15);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((Guid[]) buf[12])[0] = rslt.getGuid(13);
                ((Guid[]) buf[13])[0] = rslt.getGuid(14);
                ((Guid[]) buf[14])[0] = rslt.getGuid(15);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((Guid[]) buf[12])[0] = rslt.getGuid(13);
                ((Guid[]) buf[13])[0] = rslt.getGuid(14);
                ((Guid[]) buf[14])[0] = rslt.getGuid(15);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((Guid[]) buf[12])[0] = rslt.getGuid(13);
                ((Guid[]) buf[13])[0] = rslt.getGuid(14);
                ((Guid[]) buf[14])[0] = rslt.getGuid(15);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((Guid[]) buf[12])[0] = rslt.getGuid(13);
                ((Guid[]) buf[13])[0] = rslt.getGuid(14);
                ((Guid[]) buf[14])[0] = rslt.getGuid(15);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((Guid[]) buf[12])[0] = rslt.getGuid(13);
                ((Guid[]) buf[13])[0] = rslt.getGuid(14);
                ((Guid[]) buf[14])[0] = rslt.getGuid(15);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((Guid[]) buf[12])[0] = rslt.getGuid(13);
                ((Guid[]) buf[13])[0] = rslt.getGuid(14);
                ((Guid[]) buf[14])[0] = rslt.getGuid(15);
                return;
       }
    }

 }

}
