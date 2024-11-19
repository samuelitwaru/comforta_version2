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
   public class trn_auditwwgetfilterdata : GXProcedure
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
            return "trn_auditww_Services_Execute" ;
         }

      }

      public trn_auditwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_auditwwgetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28MaxItems = 10;
         AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
         AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITACTION") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITACTIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITTABLENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITTABLENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITUSERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITUSERNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITSHORTDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITSHORTDESCRIPTIONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("Trn_AuditWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_AuditWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("Trn_AuditWWGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITDATE") == 0 )
            {
               AV11TFAuditDate = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV12TFAuditDate_To = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITACTION") == 0 )
            {
               AV23TFAuditAction = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITACTION_SEL") == 0 )
            {
               AV24TFAuditAction_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME") == 0 )
            {
               AV13TFAuditTableName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME_SEL") == 0 )
            {
               AV14TFAuditTableName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITUSERNAME") == 0 )
            {
               AV21TFAuditUserName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITUSERNAME_SEL") == 0 )
            {
               AV22TFAuditUserName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION") == 0 )
            {
               AV17TFAuditShortDescription = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION_SEL") == 0 )
            {
               AV18TFAuditShortDescription_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADAUDITACTIONOPTIONS' Routine */
         returnInSub = false;
         AV23TFAuditAction = AV25SearchTxt;
         AV24TFAuditAction_Sel = "";
         AV52Trn_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV53Trn_auditwwds_2_tfauditdate = AV11TFAuditDate;
         AV54Trn_auditwwds_3_tfauditdate_to = AV12TFAuditDate_To;
         AV55Trn_auditwwds_4_tfauditaction = AV23TFAuditAction;
         AV56Trn_auditwwds_5_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV57Trn_auditwwds_6_tfaudittablename = AV13TFAuditTableName;
         AV58Trn_auditwwds_7_tfaudittablename_sel = AV14TFAuditTableName_Sel;
         AV59Trn_auditwwds_8_tfauditusername = AV21TFAuditUserName;
         AV60Trn_auditwwds_9_tfauditusername_sel = AV22TFAuditUserName_Sel;
         AV61Trn_auditwwds_10_tfauditshortdescription = AV17TFAuditShortDescription;
         AV62Trn_auditwwds_11_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Trn_auditwwds_1_filterfulltext ,
                                              AV53Trn_auditwwds_2_tfauditdate ,
                                              AV54Trn_auditwwds_3_tfauditdate_to ,
                                              AV56Trn_auditwwds_5_tfauditaction_sel ,
                                              AV55Trn_auditwwds_4_tfauditaction ,
                                              AV58Trn_auditwwds_7_tfaudittablename_sel ,
                                              AV57Trn_auditwwds_6_tfaudittablename ,
                                              AV60Trn_auditwwds_9_tfauditusername_sel ,
                                              AV59Trn_auditwwds_8_tfauditusername ,
                                              AV62Trn_auditwwds_11_tfauditshortdescription_sel ,
                                              AV61Trn_auditwwds_10_tfauditshortdescription ,
                                              A422AuditAction ,
                                              A417AuditTableName ,
                                              A421AuditUserName ,
                                              A419AuditShortDescription ,
                                              A416AuditDate ,
                                              A11OrganisationId ,
                                              AV63Udparg12 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV55Trn_auditwwds_4_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV55Trn_auditwwds_4_tfauditaction), "%", "");
         lV57Trn_auditwwds_6_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV57Trn_auditwwds_6_tfaudittablename), "%", "");
         lV59Trn_auditwwds_8_tfauditusername = StringUtil.Concat( StringUtil.RTrim( AV59Trn_auditwwds_8_tfauditusername), "%", "");
         lV61Trn_auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV61Trn_auditwwds_10_tfauditshortdescription), "%", "");
         /* Using cursor P008I2 */
         pr_default.execute(0, new Object[] {AV63Udparg12, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, AV53Trn_auditwwds_2_tfauditdate, AV54Trn_auditwwds_3_tfauditdate_to, lV55Trn_auditwwds_4_tfauditaction, AV56Trn_auditwwds_5_tfauditaction_sel, lV57Trn_auditwwds_6_tfaudittablename, AV58Trn_auditwwds_7_tfaudittablename_sel, lV59Trn_auditwwds_8_tfauditusername, AV60Trn_auditwwds_9_tfauditusername_sel, lV61Trn_auditwwds_10_tfauditshortdescription, AV62Trn_auditwwds_11_tfauditshortdescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8I2 = false;
            A11OrganisationId = P008I2_A11OrganisationId[0];
            A422AuditAction = P008I2_A422AuditAction[0];
            A416AuditDate = P008I2_A416AuditDate[0];
            A419AuditShortDescription = P008I2_A419AuditShortDescription[0];
            A421AuditUserName = P008I2_A421AuditUserName[0];
            A417AuditTableName = P008I2_A417AuditTableName[0];
            A415AuditId = P008I2_A415AuditId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P008I2_A422AuditAction[0], A422AuditAction) == 0 ) )
            {
               BRK8I2 = false;
               A415AuditId = P008I2_A415AuditId[0];
               AV35count = (long)(AV35count+1);
               BRK8I2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A422AuditAction)) ? "<#Empty#>" : A422AuditAction);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK8I2 )
            {
               BRK8I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADAUDITTABLENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFAuditTableName = AV25SearchTxt;
         AV14TFAuditTableName_Sel = "";
         AV52Trn_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV53Trn_auditwwds_2_tfauditdate = AV11TFAuditDate;
         AV54Trn_auditwwds_3_tfauditdate_to = AV12TFAuditDate_To;
         AV55Trn_auditwwds_4_tfauditaction = AV23TFAuditAction;
         AV56Trn_auditwwds_5_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV57Trn_auditwwds_6_tfaudittablename = AV13TFAuditTableName;
         AV58Trn_auditwwds_7_tfaudittablename_sel = AV14TFAuditTableName_Sel;
         AV59Trn_auditwwds_8_tfauditusername = AV21TFAuditUserName;
         AV60Trn_auditwwds_9_tfauditusername_sel = AV22TFAuditUserName_Sel;
         AV61Trn_auditwwds_10_tfauditshortdescription = AV17TFAuditShortDescription;
         AV62Trn_auditwwds_11_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV52Trn_auditwwds_1_filterfulltext ,
                                              AV53Trn_auditwwds_2_tfauditdate ,
                                              AV54Trn_auditwwds_3_tfauditdate_to ,
                                              AV56Trn_auditwwds_5_tfauditaction_sel ,
                                              AV55Trn_auditwwds_4_tfauditaction ,
                                              AV58Trn_auditwwds_7_tfaudittablename_sel ,
                                              AV57Trn_auditwwds_6_tfaudittablename ,
                                              AV60Trn_auditwwds_9_tfauditusername_sel ,
                                              AV59Trn_auditwwds_8_tfauditusername ,
                                              AV62Trn_auditwwds_11_tfauditshortdescription_sel ,
                                              AV61Trn_auditwwds_10_tfauditshortdescription ,
                                              A422AuditAction ,
                                              A417AuditTableName ,
                                              A421AuditUserName ,
                                              A419AuditShortDescription ,
                                              A416AuditDate ,
                                              A11OrganisationId ,
                                              AV63Udparg12 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV55Trn_auditwwds_4_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV55Trn_auditwwds_4_tfauditaction), "%", "");
         lV57Trn_auditwwds_6_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV57Trn_auditwwds_6_tfaudittablename), "%", "");
         lV59Trn_auditwwds_8_tfauditusername = StringUtil.Concat( StringUtil.RTrim( AV59Trn_auditwwds_8_tfauditusername), "%", "");
         lV61Trn_auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV61Trn_auditwwds_10_tfauditshortdescription), "%", "");
         /* Using cursor P008I3 */
         pr_default.execute(1, new Object[] {AV63Udparg12, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, AV53Trn_auditwwds_2_tfauditdate, AV54Trn_auditwwds_3_tfauditdate_to, lV55Trn_auditwwds_4_tfauditaction, AV56Trn_auditwwds_5_tfauditaction_sel, lV57Trn_auditwwds_6_tfaudittablename, AV58Trn_auditwwds_7_tfaudittablename_sel, lV59Trn_auditwwds_8_tfauditusername, AV60Trn_auditwwds_9_tfauditusername_sel, lV61Trn_auditwwds_10_tfauditshortdescription, AV62Trn_auditwwds_11_tfauditshortdescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8I4 = false;
            A11OrganisationId = P008I3_A11OrganisationId[0];
            A417AuditTableName = P008I3_A417AuditTableName[0];
            A416AuditDate = P008I3_A416AuditDate[0];
            A419AuditShortDescription = P008I3_A419AuditShortDescription[0];
            A421AuditUserName = P008I3_A421AuditUserName[0];
            A422AuditAction = P008I3_A422AuditAction[0];
            A415AuditId = P008I3_A415AuditId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008I3_A417AuditTableName[0], A417AuditTableName) == 0 ) )
            {
               BRK8I4 = false;
               A415AuditId = P008I3_A415AuditId[0];
               AV35count = (long)(AV35count+1);
               BRK8I4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A417AuditTableName)) ? "<#Empty#>" : A417AuditTableName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK8I4 )
            {
               BRK8I4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADAUDITUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV21TFAuditUserName = AV25SearchTxt;
         AV22TFAuditUserName_Sel = "";
         AV52Trn_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV53Trn_auditwwds_2_tfauditdate = AV11TFAuditDate;
         AV54Trn_auditwwds_3_tfauditdate_to = AV12TFAuditDate_To;
         AV55Trn_auditwwds_4_tfauditaction = AV23TFAuditAction;
         AV56Trn_auditwwds_5_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV57Trn_auditwwds_6_tfaudittablename = AV13TFAuditTableName;
         AV58Trn_auditwwds_7_tfaudittablename_sel = AV14TFAuditTableName_Sel;
         AV59Trn_auditwwds_8_tfauditusername = AV21TFAuditUserName;
         AV60Trn_auditwwds_9_tfauditusername_sel = AV22TFAuditUserName_Sel;
         AV61Trn_auditwwds_10_tfauditshortdescription = AV17TFAuditShortDescription;
         AV62Trn_auditwwds_11_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV52Trn_auditwwds_1_filterfulltext ,
                                              AV53Trn_auditwwds_2_tfauditdate ,
                                              AV54Trn_auditwwds_3_tfauditdate_to ,
                                              AV56Trn_auditwwds_5_tfauditaction_sel ,
                                              AV55Trn_auditwwds_4_tfauditaction ,
                                              AV58Trn_auditwwds_7_tfaudittablename_sel ,
                                              AV57Trn_auditwwds_6_tfaudittablename ,
                                              AV60Trn_auditwwds_9_tfauditusername_sel ,
                                              AV59Trn_auditwwds_8_tfauditusername ,
                                              AV62Trn_auditwwds_11_tfauditshortdescription_sel ,
                                              AV61Trn_auditwwds_10_tfauditshortdescription ,
                                              A422AuditAction ,
                                              A417AuditTableName ,
                                              A421AuditUserName ,
                                              A419AuditShortDescription ,
                                              A416AuditDate ,
                                              A11OrganisationId ,
                                              AV63Udparg12 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV55Trn_auditwwds_4_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV55Trn_auditwwds_4_tfauditaction), "%", "");
         lV57Trn_auditwwds_6_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV57Trn_auditwwds_6_tfaudittablename), "%", "");
         lV59Trn_auditwwds_8_tfauditusername = StringUtil.Concat( StringUtil.RTrim( AV59Trn_auditwwds_8_tfauditusername), "%", "");
         lV61Trn_auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV61Trn_auditwwds_10_tfauditshortdescription), "%", "");
         /* Using cursor P008I4 */
         pr_default.execute(2, new Object[] {AV63Udparg12, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, AV53Trn_auditwwds_2_tfauditdate, AV54Trn_auditwwds_3_tfauditdate_to, lV55Trn_auditwwds_4_tfauditaction, AV56Trn_auditwwds_5_tfauditaction_sel, lV57Trn_auditwwds_6_tfaudittablename, AV58Trn_auditwwds_7_tfaudittablename_sel, lV59Trn_auditwwds_8_tfauditusername, AV60Trn_auditwwds_9_tfauditusername_sel, lV61Trn_auditwwds_10_tfauditshortdescription, AV62Trn_auditwwds_11_tfauditshortdescription_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK8I6 = false;
            A11OrganisationId = P008I4_A11OrganisationId[0];
            A421AuditUserName = P008I4_A421AuditUserName[0];
            A416AuditDate = P008I4_A416AuditDate[0];
            A419AuditShortDescription = P008I4_A419AuditShortDescription[0];
            A417AuditTableName = P008I4_A417AuditTableName[0];
            A422AuditAction = P008I4_A422AuditAction[0];
            A415AuditId = P008I4_A415AuditId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008I4_A421AuditUserName[0], A421AuditUserName) == 0 ) )
            {
               BRK8I6 = false;
               A415AuditId = P008I4_A415AuditId[0];
               AV35count = (long)(AV35count+1);
               BRK8I6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A421AuditUserName)) ? "<#Empty#>" : A421AuditUserName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK8I6 )
            {
               BRK8I6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADAUDITSHORTDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV17TFAuditShortDescription = AV25SearchTxt;
         AV18TFAuditShortDescription_Sel = "";
         AV52Trn_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV53Trn_auditwwds_2_tfauditdate = AV11TFAuditDate;
         AV54Trn_auditwwds_3_tfauditdate_to = AV12TFAuditDate_To;
         AV55Trn_auditwwds_4_tfauditaction = AV23TFAuditAction;
         AV56Trn_auditwwds_5_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV57Trn_auditwwds_6_tfaudittablename = AV13TFAuditTableName;
         AV58Trn_auditwwds_7_tfaudittablename_sel = AV14TFAuditTableName_Sel;
         AV59Trn_auditwwds_8_tfauditusername = AV21TFAuditUserName;
         AV60Trn_auditwwds_9_tfauditusername_sel = AV22TFAuditUserName_Sel;
         AV61Trn_auditwwds_10_tfauditshortdescription = AV17TFAuditShortDescription;
         AV62Trn_auditwwds_11_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         AV63Udparg12 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV52Trn_auditwwds_1_filterfulltext ,
                                              AV53Trn_auditwwds_2_tfauditdate ,
                                              AV54Trn_auditwwds_3_tfauditdate_to ,
                                              AV56Trn_auditwwds_5_tfauditaction_sel ,
                                              AV55Trn_auditwwds_4_tfauditaction ,
                                              AV58Trn_auditwwds_7_tfaudittablename_sel ,
                                              AV57Trn_auditwwds_6_tfaudittablename ,
                                              AV60Trn_auditwwds_9_tfauditusername_sel ,
                                              AV59Trn_auditwwds_8_tfauditusername ,
                                              AV62Trn_auditwwds_11_tfauditshortdescription_sel ,
                                              AV61Trn_auditwwds_10_tfauditshortdescription ,
                                              A422AuditAction ,
                                              A417AuditTableName ,
                                              A421AuditUserName ,
                                              A419AuditShortDescription ,
                                              A416AuditDate ,
                                              A11OrganisationId ,
                                              AV63Udparg12 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV52Trn_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext), "%", "");
         lV55Trn_auditwwds_4_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV55Trn_auditwwds_4_tfauditaction), "%", "");
         lV57Trn_auditwwds_6_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV57Trn_auditwwds_6_tfaudittablename), "%", "");
         lV59Trn_auditwwds_8_tfauditusername = StringUtil.Concat( StringUtil.RTrim( AV59Trn_auditwwds_8_tfauditusername), "%", "");
         lV61Trn_auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV61Trn_auditwwds_10_tfauditshortdescription), "%", "");
         /* Using cursor P008I5 */
         pr_default.execute(3, new Object[] {AV63Udparg12, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, lV52Trn_auditwwds_1_filterfulltext, AV53Trn_auditwwds_2_tfauditdate, AV54Trn_auditwwds_3_tfauditdate_to, lV55Trn_auditwwds_4_tfauditaction, AV56Trn_auditwwds_5_tfauditaction_sel, lV57Trn_auditwwds_6_tfaudittablename, AV58Trn_auditwwds_7_tfaudittablename_sel, lV59Trn_auditwwds_8_tfauditusername, AV60Trn_auditwwds_9_tfauditusername_sel, lV61Trn_auditwwds_10_tfauditshortdescription, AV62Trn_auditwwds_11_tfauditshortdescription_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK8I8 = false;
            A11OrganisationId = P008I5_A11OrganisationId[0];
            A419AuditShortDescription = P008I5_A419AuditShortDescription[0];
            A416AuditDate = P008I5_A416AuditDate[0];
            A421AuditUserName = P008I5_A421AuditUserName[0];
            A417AuditTableName = P008I5_A417AuditTableName[0];
            A422AuditAction = P008I5_A422AuditAction[0];
            A415AuditId = P008I5_A415AuditId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P008I5_A419AuditShortDescription[0], A419AuditShortDescription) == 0 ) )
            {
               BRK8I8 = false;
               A415AuditId = P008I5_A415AuditId[0];
               AV35count = (long)(AV35count+1);
               BRK8I8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A419AuditShortDescription)) ? "<#Empty#>" : A419AuditShortDescription);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK8I8 )
            {
               BRK8I8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV11TFAuditDate = (DateTime)(DateTime.MinValue);
         AV12TFAuditDate_To = (DateTime)(DateTime.MinValue);
         AV23TFAuditAction = "";
         AV24TFAuditAction_Sel = "";
         AV13TFAuditTableName = "";
         AV14TFAuditTableName_Sel = "";
         AV21TFAuditUserName = "";
         AV22TFAuditUserName_Sel = "";
         AV17TFAuditShortDescription = "";
         AV18TFAuditShortDescription_Sel = "";
         AV52Trn_auditwwds_1_filterfulltext = "";
         AV53Trn_auditwwds_2_tfauditdate = (DateTime)(DateTime.MinValue);
         AV54Trn_auditwwds_3_tfauditdate_to = (DateTime)(DateTime.MinValue);
         AV55Trn_auditwwds_4_tfauditaction = "";
         AV56Trn_auditwwds_5_tfauditaction_sel = "";
         AV57Trn_auditwwds_6_tfaudittablename = "";
         AV58Trn_auditwwds_7_tfaudittablename_sel = "";
         AV59Trn_auditwwds_8_tfauditusername = "";
         AV60Trn_auditwwds_9_tfauditusername_sel = "";
         AV61Trn_auditwwds_10_tfauditshortdescription = "";
         AV62Trn_auditwwds_11_tfauditshortdescription_sel = "";
         AV63Udparg12 = Guid.Empty;
         lV52Trn_auditwwds_1_filterfulltext = "";
         lV55Trn_auditwwds_4_tfauditaction = "";
         lV57Trn_auditwwds_6_tfaudittablename = "";
         lV59Trn_auditwwds_8_tfauditusername = "";
         lV61Trn_auditwwds_10_tfauditshortdescription = "";
         A422AuditAction = "";
         A417AuditTableName = "";
         A421AuditUserName = "";
         A419AuditShortDescription = "";
         A416AuditDate = (DateTime)(DateTime.MinValue);
         A11OrganisationId = Guid.Empty;
         P008I2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008I2_A422AuditAction = new string[] {""} ;
         P008I2_A416AuditDate = new DateTime[] {DateTime.MinValue} ;
         P008I2_A419AuditShortDescription = new string[] {""} ;
         P008I2_A421AuditUserName = new string[] {""} ;
         P008I2_A417AuditTableName = new string[] {""} ;
         P008I2_A415AuditId = new Guid[] {Guid.Empty} ;
         A415AuditId = Guid.Empty;
         AV30Option = "";
         P008I3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008I3_A417AuditTableName = new string[] {""} ;
         P008I3_A416AuditDate = new DateTime[] {DateTime.MinValue} ;
         P008I3_A419AuditShortDescription = new string[] {""} ;
         P008I3_A421AuditUserName = new string[] {""} ;
         P008I3_A422AuditAction = new string[] {""} ;
         P008I3_A415AuditId = new Guid[] {Guid.Empty} ;
         P008I4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008I4_A421AuditUserName = new string[] {""} ;
         P008I4_A416AuditDate = new DateTime[] {DateTime.MinValue} ;
         P008I4_A419AuditShortDescription = new string[] {""} ;
         P008I4_A417AuditTableName = new string[] {""} ;
         P008I4_A422AuditAction = new string[] {""} ;
         P008I4_A415AuditId = new Guid[] {Guid.Empty} ;
         P008I5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008I5_A419AuditShortDescription = new string[] {""} ;
         P008I5_A416AuditDate = new DateTime[] {DateTime.MinValue} ;
         P008I5_A421AuditUserName = new string[] {""} ;
         P008I5_A417AuditTableName = new string[] {""} ;
         P008I5_A422AuditAction = new string[] {""} ;
         P008I5_A415AuditId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_auditwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008I2_A11OrganisationId, P008I2_A422AuditAction, P008I2_A416AuditDate, P008I2_A419AuditShortDescription, P008I2_A421AuditUserName, P008I2_A417AuditTableName, P008I2_A415AuditId
               }
               , new Object[] {
               P008I3_A11OrganisationId, P008I3_A417AuditTableName, P008I3_A416AuditDate, P008I3_A419AuditShortDescription, P008I3_A421AuditUserName, P008I3_A422AuditAction, P008I3_A415AuditId
               }
               , new Object[] {
               P008I4_A11OrganisationId, P008I4_A421AuditUserName, P008I4_A416AuditDate, P008I4_A419AuditShortDescription, P008I4_A417AuditTableName, P008I4_A422AuditAction, P008I4_A415AuditId
               }
               , new Object[] {
               P008I5_A11OrganisationId, P008I5_A419AuditShortDescription, P008I5_A416AuditDate, P008I5_A421AuditUserName, P008I5_A417AuditTableName, P008I5_A422AuditAction, P008I5_A415AuditId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private int AV50GXV1 ;
      private long AV35count ;
      private DateTime AV11TFAuditDate ;
      private DateTime AV12TFAuditDate_To ;
      private DateTime AV53Trn_auditwwds_2_tfauditdate ;
      private DateTime AV54Trn_auditwwds_3_tfauditdate_to ;
      private DateTime A416AuditDate ;
      private bool returnInSub ;
      private bool BRK8I2 ;
      private bool BRK8I4 ;
      private bool BRK8I6 ;
      private bool BRK8I8 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV23TFAuditAction ;
      private string AV24TFAuditAction_Sel ;
      private string AV13TFAuditTableName ;
      private string AV14TFAuditTableName_Sel ;
      private string AV21TFAuditUserName ;
      private string AV22TFAuditUserName_Sel ;
      private string AV17TFAuditShortDescription ;
      private string AV18TFAuditShortDescription_Sel ;
      private string AV52Trn_auditwwds_1_filterfulltext ;
      private string AV55Trn_auditwwds_4_tfauditaction ;
      private string AV56Trn_auditwwds_5_tfauditaction_sel ;
      private string AV57Trn_auditwwds_6_tfaudittablename ;
      private string AV58Trn_auditwwds_7_tfaudittablename_sel ;
      private string AV59Trn_auditwwds_8_tfauditusername ;
      private string AV60Trn_auditwwds_9_tfauditusername_sel ;
      private string AV61Trn_auditwwds_10_tfauditshortdescription ;
      private string AV62Trn_auditwwds_11_tfauditshortdescription_sel ;
      private string lV52Trn_auditwwds_1_filterfulltext ;
      private string lV55Trn_auditwwds_4_tfauditaction ;
      private string lV57Trn_auditwwds_6_tfaudittablename ;
      private string lV59Trn_auditwwds_8_tfauditusername ;
      private string lV61Trn_auditwwds_10_tfauditshortdescription ;
      private string A422AuditAction ;
      private string A417AuditTableName ;
      private string A421AuditUserName ;
      private string A419AuditShortDescription ;
      private string AV30Option ;
      private Guid AV63Udparg12 ;
      private Guid A11OrganisationId ;
      private Guid A415AuditId ;
      private IGxSession AV36Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008I2_A11OrganisationId ;
      private string[] P008I2_A422AuditAction ;
      private DateTime[] P008I2_A416AuditDate ;
      private string[] P008I2_A419AuditShortDescription ;
      private string[] P008I2_A421AuditUserName ;
      private string[] P008I2_A417AuditTableName ;
      private Guid[] P008I2_A415AuditId ;
      private Guid[] P008I3_A11OrganisationId ;
      private string[] P008I3_A417AuditTableName ;
      private DateTime[] P008I3_A416AuditDate ;
      private string[] P008I3_A419AuditShortDescription ;
      private string[] P008I3_A421AuditUserName ;
      private string[] P008I3_A422AuditAction ;
      private Guid[] P008I3_A415AuditId ;
      private Guid[] P008I4_A11OrganisationId ;
      private string[] P008I4_A421AuditUserName ;
      private DateTime[] P008I4_A416AuditDate ;
      private string[] P008I4_A419AuditShortDescription ;
      private string[] P008I4_A417AuditTableName ;
      private string[] P008I4_A422AuditAction ;
      private Guid[] P008I4_A415AuditId ;
      private Guid[] P008I5_A11OrganisationId ;
      private string[] P008I5_A419AuditShortDescription ;
      private DateTime[] P008I5_A416AuditDate ;
      private string[] P008I5_A421AuditUserName ;
      private string[] P008I5_A417AuditTableName ;
      private string[] P008I5_A422AuditAction ;
      private Guid[] P008I5_A415AuditId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_auditwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008I2( IGxContext context ,
                                             string AV52Trn_auditwwds_1_filterfulltext ,
                                             DateTime AV53Trn_auditwwds_2_tfauditdate ,
                                             DateTime AV54Trn_auditwwds_3_tfauditdate_to ,
                                             string AV56Trn_auditwwds_5_tfauditaction_sel ,
                                             string AV55Trn_auditwwds_4_tfauditaction ,
                                             string AV58Trn_auditwwds_7_tfaudittablename_sel ,
                                             string AV57Trn_auditwwds_6_tfaudittablename ,
                                             string AV60Trn_auditwwds_9_tfauditusername_sel ,
                                             string AV59Trn_auditwwds_8_tfauditusername ,
                                             string AV62Trn_auditwwds_11_tfauditshortdescription_sel ,
                                             string AV61Trn_auditwwds_10_tfauditshortdescription ,
                                             string A422AuditAction ,
                                             string A417AuditTableName ,
                                             string A421AuditUserName ,
                                             string A419AuditShortDescription ,
                                             DateTime A416AuditDate ,
                                             Guid A11OrganisationId ,
                                             Guid AV63Udparg12 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT OrganisationId, AuditAction, AuditDate, AuditShortDescription, AuditUserName, AuditTableName, AuditId FROM Trn_Audit";
         AddWhere(sWhereString, "(OrganisationId = :AV63Udparg12)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditAction like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditTableName like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditUserName like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV52Trn_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV53Trn_auditwwds_2_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV53Trn_auditwwds_2_tfauditdate)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV54Trn_auditwwds_3_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV54Trn_auditwwds_3_tfauditdate_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_auditwwds_5_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_auditwwds_4_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV55Trn_auditwwds_4_tfauditaction)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_auditwwds_5_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV56Trn_auditwwds_5_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV56Trn_auditwwds_5_tfauditaction_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_auditwwds_5_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV57Trn_auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV58Trn_auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV58Trn_auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_9_tfauditusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_auditwwds_8_tfauditusername)) ) )
         {
            AddWhere(sWhereString, "(AuditUserName like :lV59Trn_auditwwds_8_tfauditusername)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_9_tfauditusername_sel)) && ! ( StringUtil.StrCmp(AV60Trn_auditwwds_9_tfauditusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditUserName = ( :AV60Trn_auditwwds_9_tfauditusername_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_auditwwds_9_tfauditusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV61Trn_auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV62Trn_auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV62Trn_auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditAction";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008I3( IGxContext context ,
                                             string AV52Trn_auditwwds_1_filterfulltext ,
                                             DateTime AV53Trn_auditwwds_2_tfauditdate ,
                                             DateTime AV54Trn_auditwwds_3_tfauditdate_to ,
                                             string AV56Trn_auditwwds_5_tfauditaction_sel ,
                                             string AV55Trn_auditwwds_4_tfauditaction ,
                                             string AV58Trn_auditwwds_7_tfaudittablename_sel ,
                                             string AV57Trn_auditwwds_6_tfaudittablename ,
                                             string AV60Trn_auditwwds_9_tfauditusername_sel ,
                                             string AV59Trn_auditwwds_8_tfauditusername ,
                                             string AV62Trn_auditwwds_11_tfauditshortdescription_sel ,
                                             string AV61Trn_auditwwds_10_tfauditshortdescription ,
                                             string A422AuditAction ,
                                             string A417AuditTableName ,
                                             string A421AuditUserName ,
                                             string A419AuditShortDescription ,
                                             DateTime A416AuditDate ,
                                             Guid A11OrganisationId ,
                                             Guid AV63Udparg12 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT OrganisationId, AuditTableName, AuditDate, AuditShortDescription, AuditUserName, AuditAction, AuditId FROM Trn_Audit";
         AddWhere(sWhereString, "(OrganisationId = :AV63Udparg12)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditAction like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditTableName like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditUserName like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV52Trn_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV53Trn_auditwwds_2_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV53Trn_auditwwds_2_tfauditdate)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV54Trn_auditwwds_3_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV54Trn_auditwwds_3_tfauditdate_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_auditwwds_5_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_auditwwds_4_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV55Trn_auditwwds_4_tfauditaction)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_auditwwds_5_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV56Trn_auditwwds_5_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV56Trn_auditwwds_5_tfauditaction_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_auditwwds_5_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV57Trn_auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV58Trn_auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV58Trn_auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_9_tfauditusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_auditwwds_8_tfauditusername)) ) )
         {
            AddWhere(sWhereString, "(AuditUserName like :lV59Trn_auditwwds_8_tfauditusername)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_9_tfauditusername_sel)) && ! ( StringUtil.StrCmp(AV60Trn_auditwwds_9_tfauditusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditUserName = ( :AV60Trn_auditwwds_9_tfauditusername_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_auditwwds_9_tfauditusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV61Trn_auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV62Trn_auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV62Trn_auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditTableName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008I4( IGxContext context ,
                                             string AV52Trn_auditwwds_1_filterfulltext ,
                                             DateTime AV53Trn_auditwwds_2_tfauditdate ,
                                             DateTime AV54Trn_auditwwds_3_tfauditdate_to ,
                                             string AV56Trn_auditwwds_5_tfauditaction_sel ,
                                             string AV55Trn_auditwwds_4_tfauditaction ,
                                             string AV58Trn_auditwwds_7_tfaudittablename_sel ,
                                             string AV57Trn_auditwwds_6_tfaudittablename ,
                                             string AV60Trn_auditwwds_9_tfauditusername_sel ,
                                             string AV59Trn_auditwwds_8_tfauditusername ,
                                             string AV62Trn_auditwwds_11_tfauditshortdescription_sel ,
                                             string AV61Trn_auditwwds_10_tfauditshortdescription ,
                                             string A422AuditAction ,
                                             string A417AuditTableName ,
                                             string A421AuditUserName ,
                                             string A419AuditShortDescription ,
                                             DateTime A416AuditDate ,
                                             Guid A11OrganisationId ,
                                             Guid AV63Udparg12 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT OrganisationId, AuditUserName, AuditDate, AuditShortDescription, AuditTableName, AuditAction, AuditId FROM Trn_Audit";
         AddWhere(sWhereString, "(OrganisationId = :AV63Udparg12)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditAction like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditTableName like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditUserName like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV52Trn_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV53Trn_auditwwds_2_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV53Trn_auditwwds_2_tfauditdate)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV54Trn_auditwwds_3_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV54Trn_auditwwds_3_tfauditdate_to)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_auditwwds_5_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_auditwwds_4_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV55Trn_auditwwds_4_tfauditaction)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_auditwwds_5_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV56Trn_auditwwds_5_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV56Trn_auditwwds_5_tfauditaction_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_auditwwds_5_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV57Trn_auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV58Trn_auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV58Trn_auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_9_tfauditusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_auditwwds_8_tfauditusername)) ) )
         {
            AddWhere(sWhereString, "(AuditUserName like :lV59Trn_auditwwds_8_tfauditusername)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_9_tfauditusername_sel)) && ! ( StringUtil.StrCmp(AV60Trn_auditwwds_9_tfauditusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditUserName = ( :AV60Trn_auditwwds_9_tfauditusername_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_auditwwds_9_tfauditusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV61Trn_auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV62Trn_auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV62Trn_auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditUserName";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P008I5( IGxContext context ,
                                             string AV52Trn_auditwwds_1_filterfulltext ,
                                             DateTime AV53Trn_auditwwds_2_tfauditdate ,
                                             DateTime AV54Trn_auditwwds_3_tfauditdate_to ,
                                             string AV56Trn_auditwwds_5_tfauditaction_sel ,
                                             string AV55Trn_auditwwds_4_tfauditaction ,
                                             string AV58Trn_auditwwds_7_tfaudittablename_sel ,
                                             string AV57Trn_auditwwds_6_tfaudittablename ,
                                             string AV60Trn_auditwwds_9_tfauditusername_sel ,
                                             string AV59Trn_auditwwds_8_tfauditusername ,
                                             string AV62Trn_auditwwds_11_tfauditshortdescription_sel ,
                                             string AV61Trn_auditwwds_10_tfauditshortdescription ,
                                             string A422AuditAction ,
                                             string A417AuditTableName ,
                                             string A421AuditUserName ,
                                             string A419AuditShortDescription ,
                                             DateTime A416AuditDate ,
                                             Guid A11OrganisationId ,
                                             Guid AV63Udparg12 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[15];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT OrganisationId, AuditShortDescription, AuditDate, AuditUserName, AuditTableName, AuditAction, AuditId FROM Trn_Audit";
         AddWhere(sWhereString, "(OrganisationId = :AV63Udparg12)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditAction like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditTableName like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditUserName like '%' || :lV52Trn_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV52Trn_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV53Trn_auditwwds_2_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV53Trn_auditwwds_2_tfauditdate)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV54Trn_auditwwds_3_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV54Trn_auditwwds_3_tfauditdate_to)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_auditwwds_5_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_auditwwds_4_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV55Trn_auditwwds_4_tfauditaction)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_auditwwds_5_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV56Trn_auditwwds_5_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV56Trn_auditwwds_5_tfauditaction_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_auditwwds_5_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV57Trn_auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV58Trn_auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV58Trn_auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_9_tfauditusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_auditwwds_8_tfauditusername)) ) )
         {
            AddWhere(sWhereString, "(AuditUserName like :lV59Trn_auditwwds_8_tfauditusername)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_auditwwds_9_tfauditusername_sel)) && ! ( StringUtil.StrCmp(AV60Trn_auditwwds_9_tfauditusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditUserName = ( :AV60Trn_auditwwds_9_tfauditusername_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_auditwwds_9_tfauditusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV61Trn_auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV62Trn_auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV62Trn_auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditShortDescription";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008I2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 1 :
                     return conditional_P008I3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 2 :
                     return conditional_P008I4(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 3 :
                     return conditional_P008I5(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008I2;
          prmP008I2 = new Object[] {
          new ParDef("AV63Udparg12",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV53Trn_auditwwds_2_tfauditdate",GXType.DateTime,8,5) ,
          new ParDef("AV54Trn_auditwwds_3_tfauditdate_to",GXType.DateTime,8,5) ,
          new ParDef("lV55Trn_auditwwds_4_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV56Trn_auditwwds_5_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Trn_auditwwds_6_tfaudittablename",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_auditwwds_7_tfaudittablename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_auditwwds_8_tfauditusername",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_auditwwds_9_tfauditusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_auditwwds_10_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV62Trn_auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,400,0)
          };
          Object[] prmP008I3;
          prmP008I3 = new Object[] {
          new ParDef("AV63Udparg12",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV53Trn_auditwwds_2_tfauditdate",GXType.DateTime,8,5) ,
          new ParDef("AV54Trn_auditwwds_3_tfauditdate_to",GXType.DateTime,8,5) ,
          new ParDef("lV55Trn_auditwwds_4_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV56Trn_auditwwds_5_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Trn_auditwwds_6_tfaudittablename",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_auditwwds_7_tfaudittablename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_auditwwds_8_tfauditusername",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_auditwwds_9_tfauditusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_auditwwds_10_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV62Trn_auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,400,0)
          };
          Object[] prmP008I4;
          prmP008I4 = new Object[] {
          new ParDef("AV63Udparg12",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV53Trn_auditwwds_2_tfauditdate",GXType.DateTime,8,5) ,
          new ParDef("AV54Trn_auditwwds_3_tfauditdate_to",GXType.DateTime,8,5) ,
          new ParDef("lV55Trn_auditwwds_4_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV56Trn_auditwwds_5_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Trn_auditwwds_6_tfaudittablename",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_auditwwds_7_tfaudittablename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_auditwwds_8_tfauditusername",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_auditwwds_9_tfauditusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_auditwwds_10_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV62Trn_auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,400,0)
          };
          Object[] prmP008I5;
          prmP008I5 = new Object[] {
          new ParDef("AV63Udparg12",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Trn_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV53Trn_auditwwds_2_tfauditdate",GXType.DateTime,8,5) ,
          new ParDef("AV54Trn_auditwwds_3_tfauditdate_to",GXType.DateTime,8,5) ,
          new ParDef("lV55Trn_auditwwds_4_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV56Trn_auditwwds_5_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Trn_auditwwds_6_tfaudittablename",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_auditwwds_7_tfaudittablename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_auditwwds_8_tfauditusername",GXType.VarChar,100,0) ,
          new ParDef("AV60Trn_auditwwds_9_tfauditusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_auditwwds_10_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV62Trn_auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,400,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008I4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008I5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I5,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
