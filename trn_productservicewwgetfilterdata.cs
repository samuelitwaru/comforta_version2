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
   public class trn_productservicewwgetfilterdata : GXProcedure
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
            return "trn_productserviceww_Services_Execute" ;
         }

      }

      public trn_productservicewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_productservicewwgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PRODUCTSERVICENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PRODUCTSERVICETILENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICETILENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PRODUCTSERVICEDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICEDESCRIPTIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("Trn_ProductServiceWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_ProductServiceWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Trn_ProductServiceWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME") == 0 )
            {
               AV11TFProductServiceName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME_SEL") == 0 )
            {
               AV12TFProductServiceName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETILENAME") == 0 )
            {
               AV44TFProductServiceTileName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETILENAME_SEL") == 0 )
            {
               AV45TFProductServiceTileName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICEDESCRIPTION") == 0 )
            {
               AV13TFProductServiceDescription = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICEDESCRIPTION_SEL") == 0 )
            {
               AV14TFProductServiceDescription_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPRODUCTSERVICENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFProductServiceName = AV15SearchTxt;
         AV12TFProductServiceName_Sel = "";
         AV48Trn_productservicewwds_1_filterfulltext = AV37FilterFullText;
         AV49Trn_productservicewwds_2_tfproductservicename = AV11TFProductServiceName;
         AV50Trn_productservicewwds_3_tfproductservicename_sel = AV12TFProductServiceName_Sel;
         AV51Trn_productservicewwds_4_tfproductservicetilename = AV44TFProductServiceTileName;
         AV52Trn_productservicewwds_5_tfproductservicetilename_sel = AV45TFProductServiceTileName_Sel;
         AV53Trn_productservicewwds_6_tfproductservicedescription = AV13TFProductServiceDescription;
         AV54Trn_productservicewwds_7_tfproductservicedescription_sel = AV14TFProductServiceDescription_Sel;
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV48Trn_productservicewwds_1_filterfulltext ,
                                              AV50Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV49Trn_productservicewwds_2_tfproductservicename ,
                                              AV52Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV51Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV54Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                              AV53Trn_productservicewwds_6_tfproductservicedescription ,
                                              A59ProductServiceName ,
                                              A301ProductServiceTileName ,
                                              A60ProductServiceDescription ,
                                              A29LocationId ,
                                              AV55Udparg8 } ,
                                              new int[]{
                                              }
         });
         lV48Trn_productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext), "%", "");
         lV48Trn_productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext), "%", "");
         lV48Trn_productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext), "%", "");
         lV49Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV51Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV51Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         lV53Trn_productservicewwds_6_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV53Trn_productservicewwds_6_tfproductservicedescription), "%", "");
         /* Using cursor P006Q2 */
         pr_default.execute(0, new Object[] {AV55Udparg8, lV48Trn_productservicewwds_1_filterfulltext, lV48Trn_productservicewwds_1_filterfulltext, lV48Trn_productservicewwds_1_filterfulltext, lV49Trn_productservicewwds_2_tfproductservicename, AV50Trn_productservicewwds_3_tfproductservicename_sel, lV51Trn_productservicewwds_4_tfproductservicetilename, AV52Trn_productservicewwds_5_tfproductservicetilename_sel, lV53Trn_productservicewwds_6_tfproductservicedescription, AV54Trn_productservicewwds_7_tfproductservicedescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6Q2 = false;
            A29LocationId = P006Q2_A29LocationId[0];
            A59ProductServiceName = P006Q2_A59ProductServiceName[0];
            A60ProductServiceDescription = P006Q2_A60ProductServiceDescription[0];
            A301ProductServiceTileName = P006Q2_A301ProductServiceTileName[0];
            A58ProductServiceId = P006Q2_A58ProductServiceId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006Q2_A59ProductServiceName[0], A59ProductServiceName) == 0 ) )
            {
               BRK6Q2 = false;
               A58ProductServiceId = P006Q2_A58ProductServiceId[0];
               AV25count = (long)(AV25count+1);
               BRK6Q2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A59ProductServiceName)) ? "<#Empty#>" : A59ProductServiceName);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK6Q2 )
            {
               BRK6Q2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPRODUCTSERVICETILENAMEOPTIONS' Routine */
         returnInSub = false;
         AV44TFProductServiceTileName = AV15SearchTxt;
         AV45TFProductServiceTileName_Sel = "";
         AV48Trn_productservicewwds_1_filterfulltext = AV37FilterFullText;
         AV49Trn_productservicewwds_2_tfproductservicename = AV11TFProductServiceName;
         AV50Trn_productservicewwds_3_tfproductservicename_sel = AV12TFProductServiceName_Sel;
         AV51Trn_productservicewwds_4_tfproductservicetilename = AV44TFProductServiceTileName;
         AV52Trn_productservicewwds_5_tfproductservicetilename_sel = AV45TFProductServiceTileName_Sel;
         AV53Trn_productservicewwds_6_tfproductservicedescription = AV13TFProductServiceDescription;
         AV54Trn_productservicewwds_7_tfproductservicedescription_sel = AV14TFProductServiceDescription_Sel;
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV48Trn_productservicewwds_1_filterfulltext ,
                                              AV50Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV49Trn_productservicewwds_2_tfproductservicename ,
                                              AV52Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV51Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV54Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                              AV53Trn_productservicewwds_6_tfproductservicedescription ,
                                              A59ProductServiceName ,
                                              A301ProductServiceTileName ,
                                              A60ProductServiceDescription ,
                                              A29LocationId ,
                                              AV55Udparg8 } ,
                                              new int[]{
                                              }
         });
         lV48Trn_productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext), "%", "");
         lV48Trn_productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext), "%", "");
         lV48Trn_productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext), "%", "");
         lV49Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV51Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV51Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         lV53Trn_productservicewwds_6_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV53Trn_productservicewwds_6_tfproductservicedescription), "%", "");
         /* Using cursor P006Q3 */
         pr_default.execute(1, new Object[] {AV55Udparg8, lV48Trn_productservicewwds_1_filterfulltext, lV48Trn_productservicewwds_1_filterfulltext, lV48Trn_productservicewwds_1_filterfulltext, lV49Trn_productservicewwds_2_tfproductservicename, AV50Trn_productservicewwds_3_tfproductservicename_sel, lV51Trn_productservicewwds_4_tfproductservicetilename, AV52Trn_productservicewwds_5_tfproductservicetilename_sel, lV53Trn_productservicewwds_6_tfproductservicedescription, AV54Trn_productservicewwds_7_tfproductservicedescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6Q4 = false;
            A29LocationId = P006Q3_A29LocationId[0];
            A301ProductServiceTileName = P006Q3_A301ProductServiceTileName[0];
            A60ProductServiceDescription = P006Q3_A60ProductServiceDescription[0];
            A59ProductServiceName = P006Q3_A59ProductServiceName[0];
            A58ProductServiceId = P006Q3_A58ProductServiceId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006Q3_A301ProductServiceTileName[0], A301ProductServiceTileName) == 0 ) )
            {
               BRK6Q4 = false;
               A58ProductServiceId = P006Q3_A58ProductServiceId[0];
               AV25count = (long)(AV25count+1);
               BRK6Q4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A301ProductServiceTileName)) ? "<#Empty#>" : A301ProductServiceTileName);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK6Q4 )
            {
               BRK6Q4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPRODUCTSERVICEDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV13TFProductServiceDescription = AV15SearchTxt;
         AV14TFProductServiceDescription_Sel = "";
         AV48Trn_productservicewwds_1_filterfulltext = AV37FilterFullText;
         AV49Trn_productservicewwds_2_tfproductservicename = AV11TFProductServiceName;
         AV50Trn_productservicewwds_3_tfproductservicename_sel = AV12TFProductServiceName_Sel;
         AV51Trn_productservicewwds_4_tfproductservicetilename = AV44TFProductServiceTileName;
         AV52Trn_productservicewwds_5_tfproductservicetilename_sel = AV45TFProductServiceTileName_Sel;
         AV53Trn_productservicewwds_6_tfproductservicedescription = AV13TFProductServiceDescription;
         AV54Trn_productservicewwds_7_tfproductservicedescription_sel = AV14TFProductServiceDescription_Sel;
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         AV55Udparg8 = new prc_getuserlocationid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV48Trn_productservicewwds_1_filterfulltext ,
                                              AV50Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV49Trn_productservicewwds_2_tfproductservicename ,
                                              AV52Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV51Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV54Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                              AV53Trn_productservicewwds_6_tfproductservicedescription ,
                                              A59ProductServiceName ,
                                              A301ProductServiceTileName ,
                                              A60ProductServiceDescription ,
                                              A29LocationId ,
                                              AV55Udparg8 } ,
                                              new int[]{
                                              }
         });
         lV48Trn_productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext), "%", "");
         lV48Trn_productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext), "%", "");
         lV48Trn_productservicewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext), "%", "");
         lV49Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV49Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV51Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV51Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         lV53Trn_productservicewwds_6_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV53Trn_productservicewwds_6_tfproductservicedescription), "%", "");
         /* Using cursor P006Q4 */
         pr_default.execute(2, new Object[] {AV55Udparg8, lV48Trn_productservicewwds_1_filterfulltext, lV48Trn_productservicewwds_1_filterfulltext, lV48Trn_productservicewwds_1_filterfulltext, lV49Trn_productservicewwds_2_tfproductservicename, AV50Trn_productservicewwds_3_tfproductservicename_sel, lV51Trn_productservicewwds_4_tfproductservicetilename, AV52Trn_productservicewwds_5_tfproductservicetilename_sel, lV53Trn_productservicewwds_6_tfproductservicedescription, AV54Trn_productservicewwds_7_tfproductservicedescription_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6Q6 = false;
            A29LocationId = P006Q4_A29LocationId[0];
            A60ProductServiceDescription = P006Q4_A60ProductServiceDescription[0];
            A301ProductServiceTileName = P006Q4_A301ProductServiceTileName[0];
            A59ProductServiceName = P006Q4_A59ProductServiceName[0];
            A58ProductServiceId = P006Q4_A58ProductServiceId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006Q4_A60ProductServiceDescription[0], A60ProductServiceDescription) == 0 ) )
            {
               BRK6Q6 = false;
               A58ProductServiceId = P006Q4_A58ProductServiceId[0];
               AV25count = (long)(AV25count+1);
               BRK6Q6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A60ProductServiceDescription)) ? "<#Empty#>" : A60ProductServiceDescription);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK6Q6 )
            {
               BRK6Q6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV11TFProductServiceName = "";
         AV12TFProductServiceName_Sel = "";
         AV44TFProductServiceTileName = "";
         AV45TFProductServiceTileName_Sel = "";
         AV13TFProductServiceDescription = "";
         AV14TFProductServiceDescription_Sel = "";
         AV48Trn_productservicewwds_1_filterfulltext = "";
         AV49Trn_productservicewwds_2_tfproductservicename = "";
         AV50Trn_productservicewwds_3_tfproductservicename_sel = "";
         AV51Trn_productservicewwds_4_tfproductservicetilename = "";
         AV52Trn_productservicewwds_5_tfproductservicetilename_sel = "";
         AV53Trn_productservicewwds_6_tfproductservicedescription = "";
         AV54Trn_productservicewwds_7_tfproductservicedescription_sel = "";
         AV55Udparg8 = Guid.Empty;
         lV48Trn_productservicewwds_1_filterfulltext = "";
         lV49Trn_productservicewwds_2_tfproductservicename = "";
         lV51Trn_productservicewwds_4_tfproductservicetilename = "";
         lV53Trn_productservicewwds_6_tfproductservicedescription = "";
         A59ProductServiceName = "";
         A301ProductServiceTileName = "";
         A60ProductServiceDescription = "";
         A29LocationId = Guid.Empty;
         P006Q2_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q2_A59ProductServiceName = new string[] {""} ;
         P006Q2_A60ProductServiceDescription = new string[] {""} ;
         P006Q2_A301ProductServiceTileName = new string[] {""} ;
         P006Q2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         AV20Option = "";
         P006Q3_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q3_A301ProductServiceTileName = new string[] {""} ;
         P006Q3_A60ProductServiceDescription = new string[] {""} ;
         P006Q3_A59ProductServiceName = new string[] {""} ;
         P006Q3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006Q4_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q4_A60ProductServiceDescription = new string[] {""} ;
         P006Q4_A301ProductServiceTileName = new string[] {""} ;
         P006Q4_A59ProductServiceName = new string[] {""} ;
         P006Q4_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productservicewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006Q2_A29LocationId, P006Q2_A59ProductServiceName, P006Q2_A60ProductServiceDescription, P006Q2_A301ProductServiceTileName, P006Q2_A58ProductServiceId
               }
               , new Object[] {
               P006Q3_A29LocationId, P006Q3_A301ProductServiceTileName, P006Q3_A60ProductServiceDescription, P006Q3_A59ProductServiceName, P006Q3_A58ProductServiceId
               }
               , new Object[] {
               P006Q4_A29LocationId, P006Q4_A60ProductServiceDescription, P006Q4_A301ProductServiceTileName, P006Q4_A59ProductServiceName, P006Q4_A58ProductServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV46GXV1 ;
      private long AV25count ;
      private string AV44TFProductServiceTileName ;
      private string AV45TFProductServiceTileName_Sel ;
      private string AV51Trn_productservicewwds_4_tfproductservicetilename ;
      private string AV52Trn_productservicewwds_5_tfproductservicetilename_sel ;
      private string lV51Trn_productservicewwds_4_tfproductservicetilename ;
      private string A301ProductServiceTileName ;
      private bool returnInSub ;
      private bool BRK6Q2 ;
      private bool BRK6Q4 ;
      private bool BRK6Q6 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFProductServiceName ;
      private string AV12TFProductServiceName_Sel ;
      private string AV13TFProductServiceDescription ;
      private string AV14TFProductServiceDescription_Sel ;
      private string AV48Trn_productservicewwds_1_filterfulltext ;
      private string AV49Trn_productservicewwds_2_tfproductservicename ;
      private string AV50Trn_productservicewwds_3_tfproductservicename_sel ;
      private string AV53Trn_productservicewwds_6_tfproductservicedescription ;
      private string AV54Trn_productservicewwds_7_tfproductservicedescription_sel ;
      private string lV48Trn_productservicewwds_1_filterfulltext ;
      private string lV49Trn_productservicewwds_2_tfproductservicename ;
      private string lV53Trn_productservicewwds_6_tfproductservicedescription ;
      private string A59ProductServiceName ;
      private string A60ProductServiceDescription ;
      private string AV20Option ;
      private Guid AV55Udparg8 ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private IGxSession AV26Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006Q2_A29LocationId ;
      private string[] P006Q2_A59ProductServiceName ;
      private string[] P006Q2_A60ProductServiceDescription ;
      private string[] P006Q2_A301ProductServiceTileName ;
      private Guid[] P006Q2_A58ProductServiceId ;
      private Guid[] P006Q3_A29LocationId ;
      private string[] P006Q3_A301ProductServiceTileName ;
      private string[] P006Q3_A60ProductServiceDescription ;
      private string[] P006Q3_A59ProductServiceName ;
      private Guid[] P006Q3_A58ProductServiceId ;
      private Guid[] P006Q4_A29LocationId ;
      private string[] P006Q4_A60ProductServiceDescription ;
      private string[] P006Q4_A301ProductServiceTileName ;
      private string[] P006Q4_A59ProductServiceName ;
      private Guid[] P006Q4_A58ProductServiceId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_productservicewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006Q2( IGxContext context ,
                                             string AV48Trn_productservicewwds_1_filterfulltext ,
                                             string AV50Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV49Trn_productservicewwds_2_tfproductservicename ,
                                             string AV52Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV51Trn_productservicewwds_4_tfproductservicetilename ,
                                             string AV54Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                             string AV53Trn_productservicewwds_6_tfproductservicedescription ,
                                             string A59ProductServiceName ,
                                             string A301ProductServiceTileName ,
                                             string A60ProductServiceDescription ,
                                             Guid A29LocationId ,
                                             Guid AV55Udparg8 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT LocationId, ProductServiceName, ProductServiceDescription, ProductServiceTileName, ProductServiceId FROM Trn_ProductService";
         AddWhere(sWhereString, "(LocationId = :AV55Udparg8)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ProductServiceName like '%' || :lV48Trn_productservicewwds_1_filterfulltext) or ( ProductServiceTileName like '%' || :lV48Trn_productservicewwds_1_filterfulltext) or ( ProductServiceDescription like '%' || :lV48Trn_productservicewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceName like :lV49Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceName = ( :AV50Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceTileName like :lV51Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_productservicewwds_5_tfproductservicetilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceTileName = ( :AV52Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_productservicewwds_5_tfproductservicetilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceTileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_7_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_productservicewwds_6_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceDescription like :lV53Trn_productservicewwds_6_tfproductservicedescription)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_7_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV54Trn_productservicewwds_7_tfproductservicedescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceDescription = ( :AV54Trn_productservicewwds_7_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_productservicewwds_7_tfproductservicedescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProductServiceName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006Q3( IGxContext context ,
                                             string AV48Trn_productservicewwds_1_filterfulltext ,
                                             string AV50Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV49Trn_productservicewwds_2_tfproductservicename ,
                                             string AV52Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV51Trn_productservicewwds_4_tfproductservicetilename ,
                                             string AV54Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                             string AV53Trn_productservicewwds_6_tfproductservicedescription ,
                                             string A59ProductServiceName ,
                                             string A301ProductServiceTileName ,
                                             string A60ProductServiceDescription ,
                                             Guid A29LocationId ,
                                             Guid AV55Udparg8 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT LocationId, ProductServiceTileName, ProductServiceDescription, ProductServiceName, ProductServiceId FROM Trn_ProductService";
         AddWhere(sWhereString, "(LocationId = :AV55Udparg8)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ProductServiceName like '%' || :lV48Trn_productservicewwds_1_filterfulltext) or ( ProductServiceTileName like '%' || :lV48Trn_productservicewwds_1_filterfulltext) or ( ProductServiceDescription like '%' || :lV48Trn_productservicewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceName like :lV49Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceName = ( :AV50Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceTileName like :lV51Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_productservicewwds_5_tfproductservicetilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceTileName = ( :AV52Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_productservicewwds_5_tfproductservicetilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceTileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_7_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_productservicewwds_6_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceDescription like :lV53Trn_productservicewwds_6_tfproductservicedescription)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_7_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV54Trn_productservicewwds_7_tfproductservicedescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceDescription = ( :AV54Trn_productservicewwds_7_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_productservicewwds_7_tfproductservicedescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProductServiceTileName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006Q4( IGxContext context ,
                                             string AV48Trn_productservicewwds_1_filterfulltext ,
                                             string AV50Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV49Trn_productservicewwds_2_tfproductservicename ,
                                             string AV52Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV51Trn_productservicewwds_4_tfproductservicetilename ,
                                             string AV54Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                             string AV53Trn_productservicewwds_6_tfproductservicedescription ,
                                             string A59ProductServiceName ,
                                             string A301ProductServiceTileName ,
                                             string A60ProductServiceDescription ,
                                             Guid A29LocationId ,
                                             Guid AV55Udparg8 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT LocationId, ProductServiceDescription, ProductServiceTileName, ProductServiceName, ProductServiceId FROM Trn_ProductService";
         AddWhere(sWhereString, "(LocationId = :AV55Udparg8)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Trn_productservicewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ProductServiceName like '%' || :lV48Trn_productservicewwds_1_filterfulltext) or ( ProductServiceTileName like '%' || :lV48Trn_productservicewwds_1_filterfulltext) or ( ProductServiceDescription like '%' || :lV48Trn_productservicewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceName like :lV49Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV50Trn_productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceName = ( :AV50Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV50Trn_productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceTileName like :lV51Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_productservicewwds_5_tfproductservicetilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceTileName = ( :AV52Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_productservicewwds_5_tfproductservicetilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceTileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_7_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_productservicewwds_6_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(ProductServiceDescription like :lV53Trn_productservicewwds_6_tfproductservicedescription)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_7_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV54Trn_productservicewwds_7_tfproductservicedescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ProductServiceDescription = ( :AV54Trn_productservicewwds_7_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_productservicewwds_7_tfproductservicedescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ProductServiceDescription))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProductServiceDescription";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006Q2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
               case 1 :
                     return conditional_P006Q3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
               case 2 :
                     return conditional_P006Q4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006Q2;
          prmP006Q2 = new Object[] {
          new ParDef("AV55Udparg8",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV48Trn_productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Trn_productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Trn_productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV52Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0) ,
          new ParDef("lV53Trn_productservicewwds_6_tfproductservicedescription",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_productservicewwds_7_tfproductservicedescription_sel",GXType.VarChar,200,0)
          };
          Object[] prmP006Q3;
          prmP006Q3 = new Object[] {
          new ParDef("AV55Udparg8",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV48Trn_productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Trn_productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Trn_productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV52Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0) ,
          new ParDef("lV53Trn_productservicewwds_6_tfproductservicedescription",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_productservicewwds_7_tfproductservicedescription_sel",GXType.VarChar,200,0)
          };
          Object[] prmP006Q4;
          prmP006Q4 = new Object[] {
          new ParDef("AV55Udparg8",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV48Trn_productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Trn_productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Trn_productservicewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV50Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV52Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0) ,
          new ParDef("lV53Trn_productservicewwds_6_tfproductservicedescription",GXType.VarChar,200,0) ,
          new ParDef("AV54Trn_productservicewwds_7_tfproductservicedescription_sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Q4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q4,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
