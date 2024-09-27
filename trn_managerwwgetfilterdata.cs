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
   public class trn_managerwwgetfilterdata : GXProcedure
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
            return "trn_managerww_Services_Execute" ;
         }

      }

      public trn_managerwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_managerwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_MANAGERGIVENNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADMANAGERGIVENNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_MANAGERLASTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADMANAGERLASTNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_MANAGEREMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADMANAGEREMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_MANAGERPHONE") == 0 )
         {
            /* Execute user subroutine: 'LOADMANAGERPHONEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV36Session.Get("Trn_ManagerWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_ManagerWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("Trn_ManagerWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMANAGERGIVENNAME") == 0 )
            {
               AV11TFManagerGivenName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMANAGERGIVENNAME_SEL") == 0 )
            {
               AV12TFManagerGivenName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMANAGERLASTNAME") == 0 )
            {
               AV13TFManagerLastName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMANAGERLASTNAME_SEL") == 0 )
            {
               AV14TFManagerLastName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMANAGEREMAIL") == 0 )
            {
               AV17TFManagerEmail = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMANAGEREMAIL_SEL") == 0 )
            {
               AV18TFManagerEmail_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMANAGERPHONE") == 0 )
            {
               AV19TFManagerPhone = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMANAGERPHONE_SEL") == 0 )
            {
               AV20TFManagerPhone_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMANAGERGENDER_SEL") == 0 )
            {
               AV21TFManagerGender_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV22TFManagerGender_Sels.FromJSonString(AV21TFManagerGender_SelsJson, null);
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMANAGERGIVENNAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFManagerGivenName = AV25SearchTxt;
         AV12TFManagerGivenName_Sel = "";
         AV50Trn_managerwwds_1_filterfulltext = AV47FilterFullText;
         AV51Trn_managerwwds_2_tfmanagergivenname = AV11TFManagerGivenName;
         AV52Trn_managerwwds_3_tfmanagergivenname_sel = AV12TFManagerGivenName_Sel;
         AV53Trn_managerwwds_4_tfmanagerlastname = AV13TFManagerLastName;
         AV54Trn_managerwwds_5_tfmanagerlastname_sel = AV14TFManagerLastName_Sel;
         AV55Trn_managerwwds_6_tfmanageremail = AV17TFManagerEmail;
         AV56Trn_managerwwds_7_tfmanageremail_sel = AV18TFManagerEmail_Sel;
         AV57Trn_managerwwds_8_tfmanagerphone = AV19TFManagerPhone;
         AV58Trn_managerwwds_9_tfmanagerphone_sel = AV20TFManagerPhone_Sel;
         AV59Trn_managerwwds_10_tfmanagergender_sels = AV22TFManagerGender_Sels;
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A27ManagerGender ,
                                              AV59Trn_managerwwds_10_tfmanagergender_sels ,
                                              AV50Trn_managerwwds_1_filterfulltext ,
                                              AV52Trn_managerwwds_3_tfmanagergivenname_sel ,
                                              AV51Trn_managerwwds_2_tfmanagergivenname ,
                                              AV54Trn_managerwwds_5_tfmanagerlastname_sel ,
                                              AV53Trn_managerwwds_4_tfmanagerlastname ,
                                              AV56Trn_managerwwds_7_tfmanageremail_sel ,
                                              AV55Trn_managerwwds_6_tfmanageremail ,
                                              AV58Trn_managerwwds_9_tfmanagerphone_sel ,
                                              AV57Trn_managerwwds_8_tfmanagerphone ,
                                              AV59Trn_managerwwds_10_tfmanagergender_sels.Count ,
                                              A22ManagerGivenName ,
                                              A23ManagerLastName ,
                                              A25ManagerEmail ,
                                              A26ManagerPhone ,
                                              A11OrganisationId ,
                                              AV60Udparg11 } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV51Trn_managerwwds_2_tfmanagergivenname = StringUtil.Concat( StringUtil.RTrim( AV51Trn_managerwwds_2_tfmanagergivenname), "%", "");
         lV53Trn_managerwwds_4_tfmanagerlastname = StringUtil.Concat( StringUtil.RTrim( AV53Trn_managerwwds_4_tfmanagerlastname), "%", "");
         lV55Trn_managerwwds_6_tfmanageremail = StringUtil.Concat( StringUtil.RTrim( AV55Trn_managerwwds_6_tfmanageremail), "%", "");
         lV57Trn_managerwwds_8_tfmanagerphone = StringUtil.PadR( StringUtil.RTrim( AV57Trn_managerwwds_8_tfmanagerphone), 20, "%");
         /* Using cursor P005L2 */
         pr_default.execute(0, new Object[] {AV60Udparg11, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV51Trn_managerwwds_2_tfmanagergivenname, AV52Trn_managerwwds_3_tfmanagergivenname_sel, lV53Trn_managerwwds_4_tfmanagerlastname, AV54Trn_managerwwds_5_tfmanagerlastname_sel, lV55Trn_managerwwds_6_tfmanageremail, AV56Trn_managerwwds_7_tfmanageremail_sel, lV57Trn_managerwwds_8_tfmanagerphone, AV58Trn_managerwwds_9_tfmanagerphone_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5L2 = false;
            A11OrganisationId = P005L2_A11OrganisationId[0];
            A22ManagerGivenName = P005L2_A22ManagerGivenName[0];
            A27ManagerGender = P005L2_A27ManagerGender[0];
            A26ManagerPhone = P005L2_A26ManagerPhone[0];
            A25ManagerEmail = P005L2_A25ManagerEmail[0];
            A23ManagerLastName = P005L2_A23ManagerLastName[0];
            A21ManagerId = P005L2_A21ManagerId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005L2_A22ManagerGivenName[0], A22ManagerGivenName) == 0 ) )
            {
               BRK5L2 = false;
               A11OrganisationId = P005L2_A11OrganisationId[0];
               A21ManagerId = P005L2_A21ManagerId[0];
               AV35count = (long)(AV35count+1);
               BRK5L2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A22ManagerGivenName)) ? "<#Empty#>" : A22ManagerGivenName);
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
            if ( ! BRK5L2 )
            {
               BRK5L2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMANAGERLASTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFManagerLastName = AV25SearchTxt;
         AV14TFManagerLastName_Sel = "";
         AV50Trn_managerwwds_1_filterfulltext = AV47FilterFullText;
         AV51Trn_managerwwds_2_tfmanagergivenname = AV11TFManagerGivenName;
         AV52Trn_managerwwds_3_tfmanagergivenname_sel = AV12TFManagerGivenName_Sel;
         AV53Trn_managerwwds_4_tfmanagerlastname = AV13TFManagerLastName;
         AV54Trn_managerwwds_5_tfmanagerlastname_sel = AV14TFManagerLastName_Sel;
         AV55Trn_managerwwds_6_tfmanageremail = AV17TFManagerEmail;
         AV56Trn_managerwwds_7_tfmanageremail_sel = AV18TFManagerEmail_Sel;
         AV57Trn_managerwwds_8_tfmanagerphone = AV19TFManagerPhone;
         AV58Trn_managerwwds_9_tfmanagerphone_sel = AV20TFManagerPhone_Sel;
         AV59Trn_managerwwds_10_tfmanagergender_sels = AV22TFManagerGender_Sels;
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A27ManagerGender ,
                                              AV59Trn_managerwwds_10_tfmanagergender_sels ,
                                              AV50Trn_managerwwds_1_filterfulltext ,
                                              AV52Trn_managerwwds_3_tfmanagergivenname_sel ,
                                              AV51Trn_managerwwds_2_tfmanagergivenname ,
                                              AV54Trn_managerwwds_5_tfmanagerlastname_sel ,
                                              AV53Trn_managerwwds_4_tfmanagerlastname ,
                                              AV56Trn_managerwwds_7_tfmanageremail_sel ,
                                              AV55Trn_managerwwds_6_tfmanageremail ,
                                              AV58Trn_managerwwds_9_tfmanagerphone_sel ,
                                              AV57Trn_managerwwds_8_tfmanagerphone ,
                                              AV59Trn_managerwwds_10_tfmanagergender_sels.Count ,
                                              A22ManagerGivenName ,
                                              A23ManagerLastName ,
                                              A25ManagerEmail ,
                                              A26ManagerPhone ,
                                              A11OrganisationId ,
                                              AV60Udparg11 } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV51Trn_managerwwds_2_tfmanagergivenname = StringUtil.Concat( StringUtil.RTrim( AV51Trn_managerwwds_2_tfmanagergivenname), "%", "");
         lV53Trn_managerwwds_4_tfmanagerlastname = StringUtil.Concat( StringUtil.RTrim( AV53Trn_managerwwds_4_tfmanagerlastname), "%", "");
         lV55Trn_managerwwds_6_tfmanageremail = StringUtil.Concat( StringUtil.RTrim( AV55Trn_managerwwds_6_tfmanageremail), "%", "");
         lV57Trn_managerwwds_8_tfmanagerphone = StringUtil.PadR( StringUtil.RTrim( AV57Trn_managerwwds_8_tfmanagerphone), 20, "%");
         /* Using cursor P005L3 */
         pr_default.execute(1, new Object[] {AV60Udparg11, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV51Trn_managerwwds_2_tfmanagergivenname, AV52Trn_managerwwds_3_tfmanagergivenname_sel, lV53Trn_managerwwds_4_tfmanagerlastname, AV54Trn_managerwwds_5_tfmanagerlastname_sel, lV55Trn_managerwwds_6_tfmanageremail, AV56Trn_managerwwds_7_tfmanageremail_sel, lV57Trn_managerwwds_8_tfmanagerphone, AV58Trn_managerwwds_9_tfmanagerphone_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5L4 = false;
            A11OrganisationId = P005L3_A11OrganisationId[0];
            A23ManagerLastName = P005L3_A23ManagerLastName[0];
            A27ManagerGender = P005L3_A27ManagerGender[0];
            A26ManagerPhone = P005L3_A26ManagerPhone[0];
            A25ManagerEmail = P005L3_A25ManagerEmail[0];
            A22ManagerGivenName = P005L3_A22ManagerGivenName[0];
            A21ManagerId = P005L3_A21ManagerId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005L3_A23ManagerLastName[0], A23ManagerLastName) == 0 ) )
            {
               BRK5L4 = false;
               A11OrganisationId = P005L3_A11OrganisationId[0];
               A21ManagerId = P005L3_A21ManagerId[0];
               AV35count = (long)(AV35count+1);
               BRK5L4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A23ManagerLastName)) ? "<#Empty#>" : A23ManagerLastName);
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
            if ( ! BRK5L4 )
            {
               BRK5L4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADMANAGEREMAILOPTIONS' Routine */
         returnInSub = false;
         AV17TFManagerEmail = AV25SearchTxt;
         AV18TFManagerEmail_Sel = "";
         AV50Trn_managerwwds_1_filterfulltext = AV47FilterFullText;
         AV51Trn_managerwwds_2_tfmanagergivenname = AV11TFManagerGivenName;
         AV52Trn_managerwwds_3_tfmanagergivenname_sel = AV12TFManagerGivenName_Sel;
         AV53Trn_managerwwds_4_tfmanagerlastname = AV13TFManagerLastName;
         AV54Trn_managerwwds_5_tfmanagerlastname_sel = AV14TFManagerLastName_Sel;
         AV55Trn_managerwwds_6_tfmanageremail = AV17TFManagerEmail;
         AV56Trn_managerwwds_7_tfmanageremail_sel = AV18TFManagerEmail_Sel;
         AV57Trn_managerwwds_8_tfmanagerphone = AV19TFManagerPhone;
         AV58Trn_managerwwds_9_tfmanagerphone_sel = AV20TFManagerPhone_Sel;
         AV59Trn_managerwwds_10_tfmanagergender_sels = AV22TFManagerGender_Sels;
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A27ManagerGender ,
                                              AV59Trn_managerwwds_10_tfmanagergender_sels ,
                                              AV50Trn_managerwwds_1_filterfulltext ,
                                              AV52Trn_managerwwds_3_tfmanagergivenname_sel ,
                                              AV51Trn_managerwwds_2_tfmanagergivenname ,
                                              AV54Trn_managerwwds_5_tfmanagerlastname_sel ,
                                              AV53Trn_managerwwds_4_tfmanagerlastname ,
                                              AV56Trn_managerwwds_7_tfmanageremail_sel ,
                                              AV55Trn_managerwwds_6_tfmanageremail ,
                                              AV58Trn_managerwwds_9_tfmanagerphone_sel ,
                                              AV57Trn_managerwwds_8_tfmanagerphone ,
                                              AV59Trn_managerwwds_10_tfmanagergender_sels.Count ,
                                              A22ManagerGivenName ,
                                              A23ManagerLastName ,
                                              A25ManagerEmail ,
                                              A26ManagerPhone ,
                                              A11OrganisationId ,
                                              AV60Udparg11 } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV51Trn_managerwwds_2_tfmanagergivenname = StringUtil.Concat( StringUtil.RTrim( AV51Trn_managerwwds_2_tfmanagergivenname), "%", "");
         lV53Trn_managerwwds_4_tfmanagerlastname = StringUtil.Concat( StringUtil.RTrim( AV53Trn_managerwwds_4_tfmanagerlastname), "%", "");
         lV55Trn_managerwwds_6_tfmanageremail = StringUtil.Concat( StringUtil.RTrim( AV55Trn_managerwwds_6_tfmanageremail), "%", "");
         lV57Trn_managerwwds_8_tfmanagerphone = StringUtil.PadR( StringUtil.RTrim( AV57Trn_managerwwds_8_tfmanagerphone), 20, "%");
         /* Using cursor P005L4 */
         pr_default.execute(2, new Object[] {AV60Udparg11, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV51Trn_managerwwds_2_tfmanagergivenname, AV52Trn_managerwwds_3_tfmanagergivenname_sel, lV53Trn_managerwwds_4_tfmanagerlastname, AV54Trn_managerwwds_5_tfmanagerlastname_sel, lV55Trn_managerwwds_6_tfmanageremail, AV56Trn_managerwwds_7_tfmanageremail_sel, lV57Trn_managerwwds_8_tfmanagerphone, AV58Trn_managerwwds_9_tfmanagerphone_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5L6 = false;
            A11OrganisationId = P005L4_A11OrganisationId[0];
            A25ManagerEmail = P005L4_A25ManagerEmail[0];
            A27ManagerGender = P005L4_A27ManagerGender[0];
            A26ManagerPhone = P005L4_A26ManagerPhone[0];
            A23ManagerLastName = P005L4_A23ManagerLastName[0];
            A22ManagerGivenName = P005L4_A22ManagerGivenName[0];
            A21ManagerId = P005L4_A21ManagerId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005L4_A25ManagerEmail[0], A25ManagerEmail) == 0 ) )
            {
               BRK5L6 = false;
               A11OrganisationId = P005L4_A11OrganisationId[0];
               A21ManagerId = P005L4_A21ManagerId[0];
               AV35count = (long)(AV35count+1);
               BRK5L6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A25ManagerEmail)) ? "<#Empty#>" : A25ManagerEmail);
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
            if ( ! BRK5L6 )
            {
               BRK5L6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADMANAGERPHONEOPTIONS' Routine */
         returnInSub = false;
         AV19TFManagerPhone = AV25SearchTxt;
         AV20TFManagerPhone_Sel = "";
         AV50Trn_managerwwds_1_filterfulltext = AV47FilterFullText;
         AV51Trn_managerwwds_2_tfmanagergivenname = AV11TFManagerGivenName;
         AV52Trn_managerwwds_3_tfmanagergivenname_sel = AV12TFManagerGivenName_Sel;
         AV53Trn_managerwwds_4_tfmanagerlastname = AV13TFManagerLastName;
         AV54Trn_managerwwds_5_tfmanagerlastname_sel = AV14TFManagerLastName_Sel;
         AV55Trn_managerwwds_6_tfmanageremail = AV17TFManagerEmail;
         AV56Trn_managerwwds_7_tfmanageremail_sel = AV18TFManagerEmail_Sel;
         AV57Trn_managerwwds_8_tfmanagerphone = AV19TFManagerPhone;
         AV58Trn_managerwwds_9_tfmanagerphone_sel = AV20TFManagerPhone_Sel;
         AV59Trn_managerwwds_10_tfmanagergender_sels = AV22TFManagerGender_Sels;
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         AV60Udparg11 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A27ManagerGender ,
                                              AV59Trn_managerwwds_10_tfmanagergender_sels ,
                                              AV50Trn_managerwwds_1_filterfulltext ,
                                              AV52Trn_managerwwds_3_tfmanagergivenname_sel ,
                                              AV51Trn_managerwwds_2_tfmanagergivenname ,
                                              AV54Trn_managerwwds_5_tfmanagerlastname_sel ,
                                              AV53Trn_managerwwds_4_tfmanagerlastname ,
                                              AV56Trn_managerwwds_7_tfmanageremail_sel ,
                                              AV55Trn_managerwwds_6_tfmanageremail ,
                                              AV58Trn_managerwwds_9_tfmanagerphone_sel ,
                                              AV57Trn_managerwwds_8_tfmanagerphone ,
                                              AV59Trn_managerwwds_10_tfmanagergender_sels.Count ,
                                              A22ManagerGivenName ,
                                              A23ManagerLastName ,
                                              A25ManagerEmail ,
                                              A26ManagerPhone ,
                                              A11OrganisationId ,
                                              AV60Udparg11 } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV50Trn_managerwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext), "%", "");
         lV51Trn_managerwwds_2_tfmanagergivenname = StringUtil.Concat( StringUtil.RTrim( AV51Trn_managerwwds_2_tfmanagergivenname), "%", "");
         lV53Trn_managerwwds_4_tfmanagerlastname = StringUtil.Concat( StringUtil.RTrim( AV53Trn_managerwwds_4_tfmanagerlastname), "%", "");
         lV55Trn_managerwwds_6_tfmanageremail = StringUtil.Concat( StringUtil.RTrim( AV55Trn_managerwwds_6_tfmanageremail), "%", "");
         lV57Trn_managerwwds_8_tfmanagerphone = StringUtil.PadR( StringUtil.RTrim( AV57Trn_managerwwds_8_tfmanagerphone), 20, "%");
         /* Using cursor P005L5 */
         pr_default.execute(3, new Object[] {AV60Udparg11, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV50Trn_managerwwds_1_filterfulltext, lV51Trn_managerwwds_2_tfmanagergivenname, AV52Trn_managerwwds_3_tfmanagergivenname_sel, lV53Trn_managerwwds_4_tfmanagerlastname, AV54Trn_managerwwds_5_tfmanagerlastname_sel, lV55Trn_managerwwds_6_tfmanageremail, AV56Trn_managerwwds_7_tfmanageremail_sel, lV57Trn_managerwwds_8_tfmanagerphone, AV58Trn_managerwwds_9_tfmanagerphone_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK5L8 = false;
            A11OrganisationId = P005L5_A11OrganisationId[0];
            A26ManagerPhone = P005L5_A26ManagerPhone[0];
            A27ManagerGender = P005L5_A27ManagerGender[0];
            A25ManagerEmail = P005L5_A25ManagerEmail[0];
            A23ManagerLastName = P005L5_A23ManagerLastName[0];
            A22ManagerGivenName = P005L5_A22ManagerGivenName[0];
            A21ManagerId = P005L5_A21ManagerId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P005L5_A26ManagerPhone[0], A26ManagerPhone) == 0 ) )
            {
               BRK5L8 = false;
               A11OrganisationId = P005L5_A11OrganisationId[0];
               A21ManagerId = P005L5_A21ManagerId[0];
               AV35count = (long)(AV35count+1);
               BRK5L8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A26ManagerPhone)) ? "<#Empty#>" : A26ManagerPhone);
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
            if ( ! BRK5L8 )
            {
               BRK5L8 = true;
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
         AV11TFManagerGivenName = "";
         AV12TFManagerGivenName_Sel = "";
         AV13TFManagerLastName = "";
         AV14TFManagerLastName_Sel = "";
         AV17TFManagerEmail = "";
         AV18TFManagerEmail_Sel = "";
         AV19TFManagerPhone = "";
         AV20TFManagerPhone_Sel = "";
         AV21TFManagerGender_SelsJson = "";
         AV22TFManagerGender_Sels = new GxSimpleCollection<string>();
         AV50Trn_managerwwds_1_filterfulltext = "";
         AV51Trn_managerwwds_2_tfmanagergivenname = "";
         AV52Trn_managerwwds_3_tfmanagergivenname_sel = "";
         AV53Trn_managerwwds_4_tfmanagerlastname = "";
         AV54Trn_managerwwds_5_tfmanagerlastname_sel = "";
         AV55Trn_managerwwds_6_tfmanageremail = "";
         AV56Trn_managerwwds_7_tfmanageremail_sel = "";
         AV57Trn_managerwwds_8_tfmanagerphone = "";
         AV58Trn_managerwwds_9_tfmanagerphone_sel = "";
         AV59Trn_managerwwds_10_tfmanagergender_sels = new GxSimpleCollection<string>();
         AV60Udparg11 = Guid.Empty;
         lV50Trn_managerwwds_1_filterfulltext = "";
         lV51Trn_managerwwds_2_tfmanagergivenname = "";
         lV53Trn_managerwwds_4_tfmanagerlastname = "";
         lV55Trn_managerwwds_6_tfmanageremail = "";
         lV57Trn_managerwwds_8_tfmanagerphone = "";
         A27ManagerGender = "";
         A22ManagerGivenName = "";
         A23ManagerLastName = "";
         A25ManagerEmail = "";
         A26ManagerPhone = "";
         A11OrganisationId = Guid.Empty;
         P005L2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005L2_A22ManagerGivenName = new string[] {""} ;
         P005L2_A27ManagerGender = new string[] {""} ;
         P005L2_A26ManagerPhone = new string[] {""} ;
         P005L2_A25ManagerEmail = new string[] {""} ;
         P005L2_A23ManagerLastName = new string[] {""} ;
         P005L2_A21ManagerId = new Guid[] {Guid.Empty} ;
         A21ManagerId = Guid.Empty;
         AV30Option = "";
         P005L3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005L3_A23ManagerLastName = new string[] {""} ;
         P005L3_A27ManagerGender = new string[] {""} ;
         P005L3_A26ManagerPhone = new string[] {""} ;
         P005L3_A25ManagerEmail = new string[] {""} ;
         P005L3_A22ManagerGivenName = new string[] {""} ;
         P005L3_A21ManagerId = new Guid[] {Guid.Empty} ;
         P005L4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005L4_A25ManagerEmail = new string[] {""} ;
         P005L4_A27ManagerGender = new string[] {""} ;
         P005L4_A26ManagerPhone = new string[] {""} ;
         P005L4_A23ManagerLastName = new string[] {""} ;
         P005L4_A22ManagerGivenName = new string[] {""} ;
         P005L4_A21ManagerId = new Guid[] {Guid.Empty} ;
         P005L5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005L5_A26ManagerPhone = new string[] {""} ;
         P005L5_A27ManagerGender = new string[] {""} ;
         P005L5_A25ManagerEmail = new string[] {""} ;
         P005L5_A23ManagerLastName = new string[] {""} ;
         P005L5_A22ManagerGivenName = new string[] {""} ;
         P005L5_A21ManagerId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_managerwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005L2_A11OrganisationId, P005L2_A22ManagerGivenName, P005L2_A27ManagerGender, P005L2_A26ManagerPhone, P005L2_A25ManagerEmail, P005L2_A23ManagerLastName, P005L2_A21ManagerId
               }
               , new Object[] {
               P005L3_A11OrganisationId, P005L3_A23ManagerLastName, P005L3_A27ManagerGender, P005L3_A26ManagerPhone, P005L3_A25ManagerEmail, P005L3_A22ManagerGivenName, P005L3_A21ManagerId
               }
               , new Object[] {
               P005L4_A11OrganisationId, P005L4_A25ManagerEmail, P005L4_A27ManagerGender, P005L4_A26ManagerPhone, P005L4_A23ManagerLastName, P005L4_A22ManagerGivenName, P005L4_A21ManagerId
               }
               , new Object[] {
               P005L5_A11OrganisationId, P005L5_A26ManagerPhone, P005L5_A27ManagerGender, P005L5_A25ManagerEmail, P005L5_A23ManagerLastName, P005L5_A22ManagerGivenName, P005L5_A21ManagerId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private int AV48GXV1 ;
      private int AV59Trn_managerwwds_10_tfmanagergender_sels_Count ;
      private long AV35count ;
      private string AV19TFManagerPhone ;
      private string AV20TFManagerPhone_Sel ;
      private string AV57Trn_managerwwds_8_tfmanagerphone ;
      private string AV58Trn_managerwwds_9_tfmanagerphone_sel ;
      private string lV57Trn_managerwwds_8_tfmanagerphone ;
      private string A26ManagerPhone ;
      private bool returnInSub ;
      private bool BRK5L2 ;
      private bool BRK5L4 ;
      private bool BRK5L6 ;
      private bool BRK5L8 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV21TFManagerGender_SelsJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV11TFManagerGivenName ;
      private string AV12TFManagerGivenName_Sel ;
      private string AV13TFManagerLastName ;
      private string AV14TFManagerLastName_Sel ;
      private string AV17TFManagerEmail ;
      private string AV18TFManagerEmail_Sel ;
      private string AV50Trn_managerwwds_1_filterfulltext ;
      private string AV51Trn_managerwwds_2_tfmanagergivenname ;
      private string AV52Trn_managerwwds_3_tfmanagergivenname_sel ;
      private string AV53Trn_managerwwds_4_tfmanagerlastname ;
      private string AV54Trn_managerwwds_5_tfmanagerlastname_sel ;
      private string AV55Trn_managerwwds_6_tfmanageremail ;
      private string AV56Trn_managerwwds_7_tfmanageremail_sel ;
      private string lV50Trn_managerwwds_1_filterfulltext ;
      private string lV51Trn_managerwwds_2_tfmanagergivenname ;
      private string lV53Trn_managerwwds_4_tfmanagerlastname ;
      private string lV55Trn_managerwwds_6_tfmanageremail ;
      private string A27ManagerGender ;
      private string A22ManagerGivenName ;
      private string A23ManagerLastName ;
      private string A25ManagerEmail ;
      private string AV30Option ;
      private Guid AV60Udparg11 ;
      private Guid A11OrganisationId ;
      private Guid A21ManagerId ;
      private IGxSession AV36Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GxSimpleCollection<string> AV22TFManagerGender_Sels ;
      private GxSimpleCollection<string> AV59Trn_managerwwds_10_tfmanagergender_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P005L2_A11OrganisationId ;
      private string[] P005L2_A22ManagerGivenName ;
      private string[] P005L2_A27ManagerGender ;
      private string[] P005L2_A26ManagerPhone ;
      private string[] P005L2_A25ManagerEmail ;
      private string[] P005L2_A23ManagerLastName ;
      private Guid[] P005L2_A21ManagerId ;
      private Guid[] P005L3_A11OrganisationId ;
      private string[] P005L3_A23ManagerLastName ;
      private string[] P005L3_A27ManagerGender ;
      private string[] P005L3_A26ManagerPhone ;
      private string[] P005L3_A25ManagerEmail ;
      private string[] P005L3_A22ManagerGivenName ;
      private Guid[] P005L3_A21ManagerId ;
      private Guid[] P005L4_A11OrganisationId ;
      private string[] P005L4_A25ManagerEmail ;
      private string[] P005L4_A27ManagerGender ;
      private string[] P005L4_A26ManagerPhone ;
      private string[] P005L4_A23ManagerLastName ;
      private string[] P005L4_A22ManagerGivenName ;
      private Guid[] P005L4_A21ManagerId ;
      private Guid[] P005L5_A11OrganisationId ;
      private string[] P005L5_A26ManagerPhone ;
      private string[] P005L5_A27ManagerGender ;
      private string[] P005L5_A25ManagerEmail ;
      private string[] P005L5_A23ManagerLastName ;
      private string[] P005L5_A22ManagerGivenName ;
      private Guid[] P005L5_A21ManagerId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_managerwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005L2( IGxContext context ,
                                             string A27ManagerGender ,
                                             GxSimpleCollection<string> AV59Trn_managerwwds_10_tfmanagergender_sels ,
                                             string AV50Trn_managerwwds_1_filterfulltext ,
                                             string AV52Trn_managerwwds_3_tfmanagergivenname_sel ,
                                             string AV51Trn_managerwwds_2_tfmanagergivenname ,
                                             string AV54Trn_managerwwds_5_tfmanagerlastname_sel ,
                                             string AV53Trn_managerwwds_4_tfmanagerlastname ,
                                             string AV56Trn_managerwwds_7_tfmanageremail_sel ,
                                             string AV55Trn_managerwwds_6_tfmanageremail ,
                                             string AV58Trn_managerwwds_9_tfmanagerphone_sel ,
                                             string AV57Trn_managerwwds_8_tfmanagerphone ,
                                             int AV59Trn_managerwwds_10_tfmanagergender_sels_Count ,
                                             string A22ManagerGivenName ,
                                             string A23ManagerLastName ,
                                             string A25ManagerEmail ,
                                             string A26ManagerPhone ,
                                             Guid A11OrganisationId ,
                                             Guid AV60Udparg11 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT OrganisationId, ManagerGivenName, ManagerGender, ManagerPhone, ManagerEmail, ManagerLastName, ManagerId FROM Trn_Manager";
         AddWhere(sWhereString, "(OrganisationId = :AV60Udparg11)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ManagerGivenName like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerLastName like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerEmail like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerPhone like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Other')))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_managerwwds_3_tfmanagergivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_managerwwds_2_tfmanagergivenname)) ) )
         {
            AddWhere(sWhereString, "(ManagerGivenName like :lV51Trn_managerwwds_2_tfmanagergivenname)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_managerwwds_3_tfmanagergivenname_sel)) && ! ( StringUtil.StrCmp(AV52Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerGivenName = ( :AV52Trn_managerwwds_3_tfmanagergivenname_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_managerwwds_5_tfmanagerlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_managerwwds_4_tfmanagerlastname)) ) )
         {
            AddWhere(sWhereString, "(ManagerLastName like :lV53Trn_managerwwds_4_tfmanagerlastname)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_managerwwds_5_tfmanagerlastname_sel)) && ! ( StringUtil.StrCmp(AV54Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerLastName = ( :AV54Trn_managerwwds_5_tfmanagerlastname_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_managerwwds_7_tfmanageremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_managerwwds_6_tfmanageremail)) ) )
         {
            AddWhere(sWhereString, "(ManagerEmail like :lV55Trn_managerwwds_6_tfmanageremail)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_managerwwds_7_tfmanageremail_sel)) && ! ( StringUtil.StrCmp(AV56Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerEmail = ( :AV56Trn_managerwwds_7_tfmanageremail_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_managerwwds_9_tfmanagerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_managerwwds_8_tfmanagerphone)) ) )
         {
            AddWhere(sWhereString, "(ManagerPhone like :lV57Trn_managerwwds_8_tfmanagerphone)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_managerwwds_9_tfmanagerphone_sel)) && ! ( StringUtil.StrCmp(AV58Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerPhone = ( :AV58Trn_managerwwds_9_tfmanagerphone_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerPhone))=0))");
         }
         if ( AV59Trn_managerwwds_10_tfmanagergender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV59Trn_managerwwds_10_tfmanagergender_sels, "ManagerGender IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ManagerGivenName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005L3( IGxContext context ,
                                             string A27ManagerGender ,
                                             GxSimpleCollection<string> AV59Trn_managerwwds_10_tfmanagergender_sels ,
                                             string AV50Trn_managerwwds_1_filterfulltext ,
                                             string AV52Trn_managerwwds_3_tfmanagergivenname_sel ,
                                             string AV51Trn_managerwwds_2_tfmanagergivenname ,
                                             string AV54Trn_managerwwds_5_tfmanagerlastname_sel ,
                                             string AV53Trn_managerwwds_4_tfmanagerlastname ,
                                             string AV56Trn_managerwwds_7_tfmanageremail_sel ,
                                             string AV55Trn_managerwwds_6_tfmanageremail ,
                                             string AV58Trn_managerwwds_9_tfmanagerphone_sel ,
                                             string AV57Trn_managerwwds_8_tfmanagerphone ,
                                             int AV59Trn_managerwwds_10_tfmanagergender_sels_Count ,
                                             string A22ManagerGivenName ,
                                             string A23ManagerLastName ,
                                             string A25ManagerEmail ,
                                             string A26ManagerPhone ,
                                             Guid A11OrganisationId ,
                                             Guid AV60Udparg11 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT OrganisationId, ManagerLastName, ManagerGender, ManagerPhone, ManagerEmail, ManagerGivenName, ManagerId FROM Trn_Manager";
         AddWhere(sWhereString, "(OrganisationId = :AV60Udparg11)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ManagerGivenName like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerLastName like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerEmail like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerPhone like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Other')))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_managerwwds_3_tfmanagergivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_managerwwds_2_tfmanagergivenname)) ) )
         {
            AddWhere(sWhereString, "(ManagerGivenName like :lV51Trn_managerwwds_2_tfmanagergivenname)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_managerwwds_3_tfmanagergivenname_sel)) && ! ( StringUtil.StrCmp(AV52Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerGivenName = ( :AV52Trn_managerwwds_3_tfmanagergivenname_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_managerwwds_5_tfmanagerlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_managerwwds_4_tfmanagerlastname)) ) )
         {
            AddWhere(sWhereString, "(ManagerLastName like :lV53Trn_managerwwds_4_tfmanagerlastname)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_managerwwds_5_tfmanagerlastname_sel)) && ! ( StringUtil.StrCmp(AV54Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerLastName = ( :AV54Trn_managerwwds_5_tfmanagerlastname_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_managerwwds_7_tfmanageremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_managerwwds_6_tfmanageremail)) ) )
         {
            AddWhere(sWhereString, "(ManagerEmail like :lV55Trn_managerwwds_6_tfmanageremail)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_managerwwds_7_tfmanageremail_sel)) && ! ( StringUtil.StrCmp(AV56Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerEmail = ( :AV56Trn_managerwwds_7_tfmanageremail_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_managerwwds_9_tfmanagerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_managerwwds_8_tfmanagerphone)) ) )
         {
            AddWhere(sWhereString, "(ManagerPhone like :lV57Trn_managerwwds_8_tfmanagerphone)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_managerwwds_9_tfmanagerphone_sel)) && ! ( StringUtil.StrCmp(AV58Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerPhone = ( :AV58Trn_managerwwds_9_tfmanagerphone_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerPhone))=0))");
         }
         if ( AV59Trn_managerwwds_10_tfmanagergender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV59Trn_managerwwds_10_tfmanagergender_sels, "ManagerGender IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ManagerLastName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005L4( IGxContext context ,
                                             string A27ManagerGender ,
                                             GxSimpleCollection<string> AV59Trn_managerwwds_10_tfmanagergender_sels ,
                                             string AV50Trn_managerwwds_1_filterfulltext ,
                                             string AV52Trn_managerwwds_3_tfmanagergivenname_sel ,
                                             string AV51Trn_managerwwds_2_tfmanagergivenname ,
                                             string AV54Trn_managerwwds_5_tfmanagerlastname_sel ,
                                             string AV53Trn_managerwwds_4_tfmanagerlastname ,
                                             string AV56Trn_managerwwds_7_tfmanageremail_sel ,
                                             string AV55Trn_managerwwds_6_tfmanageremail ,
                                             string AV58Trn_managerwwds_9_tfmanagerphone_sel ,
                                             string AV57Trn_managerwwds_8_tfmanagerphone ,
                                             int AV59Trn_managerwwds_10_tfmanagergender_sels_Count ,
                                             string A22ManagerGivenName ,
                                             string A23ManagerLastName ,
                                             string A25ManagerEmail ,
                                             string A26ManagerPhone ,
                                             Guid A11OrganisationId ,
                                             Guid AV60Udparg11 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT OrganisationId, ManagerEmail, ManagerGender, ManagerPhone, ManagerLastName, ManagerGivenName, ManagerId FROM Trn_Manager";
         AddWhere(sWhereString, "(OrganisationId = :AV60Udparg11)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ManagerGivenName like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerLastName like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerEmail like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerPhone like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Other')))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_managerwwds_3_tfmanagergivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_managerwwds_2_tfmanagergivenname)) ) )
         {
            AddWhere(sWhereString, "(ManagerGivenName like :lV51Trn_managerwwds_2_tfmanagergivenname)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_managerwwds_3_tfmanagergivenname_sel)) && ! ( StringUtil.StrCmp(AV52Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerGivenName = ( :AV52Trn_managerwwds_3_tfmanagergivenname_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_managerwwds_5_tfmanagerlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_managerwwds_4_tfmanagerlastname)) ) )
         {
            AddWhere(sWhereString, "(ManagerLastName like :lV53Trn_managerwwds_4_tfmanagerlastname)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_managerwwds_5_tfmanagerlastname_sel)) && ! ( StringUtil.StrCmp(AV54Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerLastName = ( :AV54Trn_managerwwds_5_tfmanagerlastname_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_managerwwds_7_tfmanageremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_managerwwds_6_tfmanageremail)) ) )
         {
            AddWhere(sWhereString, "(ManagerEmail like :lV55Trn_managerwwds_6_tfmanageremail)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_managerwwds_7_tfmanageremail_sel)) && ! ( StringUtil.StrCmp(AV56Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerEmail = ( :AV56Trn_managerwwds_7_tfmanageremail_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_managerwwds_9_tfmanagerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_managerwwds_8_tfmanagerphone)) ) )
         {
            AddWhere(sWhereString, "(ManagerPhone like :lV57Trn_managerwwds_8_tfmanagerphone)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_managerwwds_9_tfmanagerphone_sel)) && ! ( StringUtil.StrCmp(AV58Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerPhone = ( :AV58Trn_managerwwds_9_tfmanagerphone_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerPhone))=0))");
         }
         if ( AV59Trn_managerwwds_10_tfmanagergender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV59Trn_managerwwds_10_tfmanagergender_sels, "ManagerGender IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ManagerEmail";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P005L5( IGxContext context ,
                                             string A27ManagerGender ,
                                             GxSimpleCollection<string> AV59Trn_managerwwds_10_tfmanagergender_sels ,
                                             string AV50Trn_managerwwds_1_filterfulltext ,
                                             string AV52Trn_managerwwds_3_tfmanagergivenname_sel ,
                                             string AV51Trn_managerwwds_2_tfmanagergivenname ,
                                             string AV54Trn_managerwwds_5_tfmanagerlastname_sel ,
                                             string AV53Trn_managerwwds_4_tfmanagerlastname ,
                                             string AV56Trn_managerwwds_7_tfmanageremail_sel ,
                                             string AV55Trn_managerwwds_6_tfmanageremail ,
                                             string AV58Trn_managerwwds_9_tfmanagerphone_sel ,
                                             string AV57Trn_managerwwds_8_tfmanagerphone ,
                                             int AV59Trn_managerwwds_10_tfmanagergender_sels_Count ,
                                             string A22ManagerGivenName ,
                                             string A23ManagerLastName ,
                                             string A25ManagerEmail ,
                                             string A26ManagerPhone ,
                                             Guid A11OrganisationId ,
                                             Guid AV60Udparg11 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[16];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT OrganisationId, ManagerPhone, ManagerGender, ManagerEmail, ManagerLastName, ManagerGivenName, ManagerId FROM Trn_Manager";
         AddWhere(sWhereString, "(OrganisationId = :AV60Udparg11)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_managerwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ManagerGivenName like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerLastName like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerEmail like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( ManagerPhone like '%' || :lV50Trn_managerwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV50Trn_managerwwds_1_filterfulltext) and ManagerGender = ( 'Other')))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_managerwwds_3_tfmanagergivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_managerwwds_2_tfmanagergivenname)) ) )
         {
            AddWhere(sWhereString, "(ManagerGivenName like :lV51Trn_managerwwds_2_tfmanagergivenname)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_managerwwds_3_tfmanagergivenname_sel)) && ! ( StringUtil.StrCmp(AV52Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerGivenName = ( :AV52Trn_managerwwds_3_tfmanagergivenname_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_managerwwds_5_tfmanagerlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_managerwwds_4_tfmanagerlastname)) ) )
         {
            AddWhere(sWhereString, "(ManagerLastName like :lV53Trn_managerwwds_4_tfmanagerlastname)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_managerwwds_5_tfmanagerlastname_sel)) && ! ( StringUtil.StrCmp(AV54Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerLastName = ( :AV54Trn_managerwwds_5_tfmanagerlastname_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_managerwwds_7_tfmanageremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_managerwwds_6_tfmanageremail)) ) )
         {
            AddWhere(sWhereString, "(ManagerEmail like :lV55Trn_managerwwds_6_tfmanageremail)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_managerwwds_7_tfmanageremail_sel)) && ! ( StringUtil.StrCmp(AV56Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerEmail = ( :AV56Trn_managerwwds_7_tfmanageremail_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_managerwwds_9_tfmanagerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_managerwwds_8_tfmanagerphone)) ) )
         {
            AddWhere(sWhereString, "(ManagerPhone like :lV57Trn_managerwwds_8_tfmanagerphone)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_managerwwds_9_tfmanagerphone_sel)) && ! ( StringUtil.StrCmp(AV58Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ManagerPhone = ( :AV58Trn_managerwwds_9_tfmanagerphone_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerPhone))=0))");
         }
         if ( AV59Trn_managerwwds_10_tfmanagergender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV59Trn_managerwwds_10_tfmanagergender_sels, "ManagerGender IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ManagerPhone";
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
                     return conditional_P005L2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 1 :
                     return conditional_P005L3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 2 :
                     return conditional_P005L4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 3 :
                     return conditional_P005L5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
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
          Object[] prmP005L2;
          prmP005L2 = new Object[] {
          new ParDef("AV60Udparg11",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_managerwwds_2_tfmanagergivenname",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_managerwwds_3_tfmanagergivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_managerwwds_4_tfmanagerlastname",GXType.VarChar,100,0) ,
          new ParDef("AV54Trn_managerwwds_5_tfmanagerlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_managerwwds_6_tfmanageremail",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_managerwwds_7_tfmanageremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_managerwwds_8_tfmanagerphone",GXType.Char,20,0) ,
          new ParDef("AV58Trn_managerwwds_9_tfmanagerphone_sel",GXType.Char,20,0)
          };
          Object[] prmP005L3;
          prmP005L3 = new Object[] {
          new ParDef("AV60Udparg11",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_managerwwds_2_tfmanagergivenname",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_managerwwds_3_tfmanagergivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_managerwwds_4_tfmanagerlastname",GXType.VarChar,100,0) ,
          new ParDef("AV54Trn_managerwwds_5_tfmanagerlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_managerwwds_6_tfmanageremail",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_managerwwds_7_tfmanageremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_managerwwds_8_tfmanagerphone",GXType.Char,20,0) ,
          new ParDef("AV58Trn_managerwwds_9_tfmanagerphone_sel",GXType.Char,20,0)
          };
          Object[] prmP005L4;
          prmP005L4 = new Object[] {
          new ParDef("AV60Udparg11",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_managerwwds_2_tfmanagergivenname",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_managerwwds_3_tfmanagergivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_managerwwds_4_tfmanagerlastname",GXType.VarChar,100,0) ,
          new ParDef("AV54Trn_managerwwds_5_tfmanagerlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_managerwwds_6_tfmanageremail",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_managerwwds_7_tfmanageremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_managerwwds_8_tfmanagerphone",GXType.Char,20,0) ,
          new ParDef("AV58Trn_managerwwds_9_tfmanagerphone_sel",GXType.Char,20,0)
          };
          Object[] prmP005L5;
          prmP005L5 = new Object[] {
          new ParDef("AV60Udparg11",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_managerwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_managerwwds_2_tfmanagergivenname",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_managerwwds_3_tfmanagergivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_managerwwds_4_tfmanagerlastname",GXType.VarChar,100,0) ,
          new ParDef("AV54Trn_managerwwds_5_tfmanagerlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_managerwwds_6_tfmanageremail",GXType.VarChar,100,0) ,
          new ParDef("AV56Trn_managerwwds_7_tfmanageremail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_managerwwds_8_tfmanagerphone",GXType.Char,20,0) ,
          new ParDef("AV58Trn_managerwwds_9_tfmanagerphone_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005L2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005L3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005L4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005L4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005L5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005L5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
