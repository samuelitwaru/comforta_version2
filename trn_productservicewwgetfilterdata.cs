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
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_SUPPLIERGENCOMPANYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERGENCOMPANYNAMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_SUPPLIERAGBNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBNAMEOPTIONS' */
            S161 ();
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
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV48GXV1));
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
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICEGROUP_SEL") == 0 )
            {
               AV46TFProductServiceGroup_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV47TFProductServiceGroup_Sels.FromJSonString(AV46TFProductServiceGroup_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME") == 0 )
            {
               AV39TFSupplierGenCompanyName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME_SEL") == 0 )
            {
               AV40TFSupplierGenCompanyName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME") == 0 )
            {
               AV41TFSupplierAgbName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBNAME_SEL") == 0 )
            {
               AV42TFSupplierAgbName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPRODUCTSERVICENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFProductServiceName = AV15SearchTxt;
         AV12TFProductServiceName_Sel = "";
         AV50Trn_productservicewwds_1_filterfulltext = AV37FilterFullText;
         AV51Trn_productservicewwds_2_tfproductservicename = AV11TFProductServiceName;
         AV52Trn_productservicewwds_3_tfproductservicename_sel = AV12TFProductServiceName_Sel;
         AV53Trn_productservicewwds_4_tfproductservicetilename = AV44TFProductServiceTileName;
         AV54Trn_productservicewwds_5_tfproductservicetilename_sel = AV45TFProductServiceTileName_Sel;
         AV55Trn_productservicewwds_6_tfproductservicedescription = AV13TFProductServiceDescription;
         AV56Trn_productservicewwds_7_tfproductservicedescription_sel = AV14TFProductServiceDescription_Sel;
         AV57Trn_productservicewwds_8_tfproductservicegroup_sels = AV47TFProductServiceGroup_Sels;
         AV58Trn_productservicewwds_9_tfsuppliergencompanyname = AV39TFSupplierGenCompanyName;
         AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel = AV40TFSupplierGenCompanyName_Sel;
         AV60Trn_productservicewwds_11_tfsupplieragbname = AV41TFSupplierAgbName;
         AV61Trn_productservicewwds_12_tfsupplieragbname_sel = AV42TFSupplierAgbName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A366ProductServiceGroup ,
                                              AV57Trn_productservicewwds_8_tfproductservicegroup_sels ,
                                              AV52Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV51Trn_productservicewwds_2_tfproductservicename ,
                                              AV54Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV53Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV56Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                              AV55Trn_productservicewwds_6_tfproductservicedescription ,
                                              AV57Trn_productservicewwds_8_tfproductservicegroup_sels.Count ,
                                              AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ,
                                              AV58Trn_productservicewwds_9_tfsuppliergencompanyname ,
                                              AV61Trn_productservicewwds_12_tfsupplieragbname_sel ,
                                              AV60Trn_productservicewwds_11_tfsupplieragbname ,
                                              A59ProductServiceName ,
                                              A301ProductServiceTileName ,
                                              A60ProductServiceDescription ,
                                              A44SupplierGenCompanyName ,
                                              A51SupplierAgbName ,
                                              AV50Trn_productservicewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV51Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV51Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV53Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV53Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         lV55Trn_productservicewwds_6_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV55Trn_productservicewwds_6_tfproductservicedescription), "%", "");
         lV58Trn_productservicewwds_9_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_productservicewwds_9_tfsuppliergencompanyname), "%", "");
         lV60Trn_productservicewwds_11_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_productservicewwds_11_tfsupplieragbname), "%", "");
         /* Using cursor P006Q2 */
         pr_default.execute(0, new Object[] {lV51Trn_productservicewwds_2_tfproductservicename, AV52Trn_productservicewwds_3_tfproductservicename_sel, lV53Trn_productservicewwds_4_tfproductservicetilename, AV54Trn_productservicewwds_5_tfproductservicetilename_sel, lV55Trn_productservicewwds_6_tfproductservicedescription, AV56Trn_productservicewwds_7_tfproductservicedescription_sel, lV58Trn_productservicewwds_9_tfsuppliergencompanyname, AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, lV60Trn_productservicewwds_11_tfsupplieragbname, AV61Trn_productservicewwds_12_tfsupplieragbname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6Q2 = false;
            A42SupplierGenId = P006Q2_A42SupplierGenId[0];
            n42SupplierGenId = P006Q2_n42SupplierGenId[0];
            A49SupplierAgbId = P006Q2_A49SupplierAgbId[0];
            n49SupplierAgbId = P006Q2_n49SupplierAgbId[0];
            A59ProductServiceName = P006Q2_A59ProductServiceName[0];
            A51SupplierAgbName = P006Q2_A51SupplierAgbName[0];
            A44SupplierGenCompanyName = P006Q2_A44SupplierGenCompanyName[0];
            A366ProductServiceGroup = P006Q2_A366ProductServiceGroup[0];
            A60ProductServiceDescription = P006Q2_A60ProductServiceDescription[0];
            A301ProductServiceTileName = P006Q2_A301ProductServiceTileName[0];
            A58ProductServiceId = P006Q2_A58ProductServiceId[0];
            A29LocationId = P006Q2_A29LocationId[0];
            A11OrganisationId = P006Q2_A11OrganisationId[0];
            A44SupplierGenCompanyName = P006Q2_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = P006Q2_A51SupplierAgbName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A301ProductServiceTileName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A60ProductServiceDescription , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "location", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( "Location", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "agb supplier", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( " AGB Supplier", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "general supplier", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( "General Supplier", "")) == 0 ) ) || ( StringUtil.Like( A44SupplierGenCompanyName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A51SupplierAgbName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006Q2_A59ProductServiceName[0], A59ProductServiceName) == 0 ) )
               {
                  BRK6Q2 = false;
                  A58ProductServiceId = P006Q2_A58ProductServiceId[0];
                  A29LocationId = P006Q2_A29LocationId[0];
                  A11OrganisationId = P006Q2_A11OrganisationId[0];
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
         AV50Trn_productservicewwds_1_filterfulltext = AV37FilterFullText;
         AV51Trn_productservicewwds_2_tfproductservicename = AV11TFProductServiceName;
         AV52Trn_productservicewwds_3_tfproductservicename_sel = AV12TFProductServiceName_Sel;
         AV53Trn_productservicewwds_4_tfproductservicetilename = AV44TFProductServiceTileName;
         AV54Trn_productservicewwds_5_tfproductservicetilename_sel = AV45TFProductServiceTileName_Sel;
         AV55Trn_productservicewwds_6_tfproductservicedescription = AV13TFProductServiceDescription;
         AV56Trn_productservicewwds_7_tfproductservicedescription_sel = AV14TFProductServiceDescription_Sel;
         AV57Trn_productservicewwds_8_tfproductservicegroup_sels = AV47TFProductServiceGroup_Sels;
         AV58Trn_productservicewwds_9_tfsuppliergencompanyname = AV39TFSupplierGenCompanyName;
         AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel = AV40TFSupplierGenCompanyName_Sel;
         AV60Trn_productservicewwds_11_tfsupplieragbname = AV41TFSupplierAgbName;
         AV61Trn_productservicewwds_12_tfsupplieragbname_sel = AV42TFSupplierAgbName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A366ProductServiceGroup ,
                                              AV57Trn_productservicewwds_8_tfproductservicegroup_sels ,
                                              AV52Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV51Trn_productservicewwds_2_tfproductservicename ,
                                              AV54Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV53Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV56Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                              AV55Trn_productservicewwds_6_tfproductservicedescription ,
                                              AV57Trn_productservicewwds_8_tfproductservicegroup_sels.Count ,
                                              AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ,
                                              AV58Trn_productservicewwds_9_tfsuppliergencompanyname ,
                                              AV61Trn_productservicewwds_12_tfsupplieragbname_sel ,
                                              AV60Trn_productservicewwds_11_tfsupplieragbname ,
                                              A59ProductServiceName ,
                                              A301ProductServiceTileName ,
                                              A60ProductServiceDescription ,
                                              A44SupplierGenCompanyName ,
                                              A51SupplierAgbName ,
                                              AV50Trn_productservicewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV51Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV51Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV53Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV53Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         lV55Trn_productservicewwds_6_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV55Trn_productservicewwds_6_tfproductservicedescription), "%", "");
         lV58Trn_productservicewwds_9_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_productservicewwds_9_tfsuppliergencompanyname), "%", "");
         lV60Trn_productservicewwds_11_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_productservicewwds_11_tfsupplieragbname), "%", "");
         /* Using cursor P006Q3 */
         pr_default.execute(1, new Object[] {lV51Trn_productservicewwds_2_tfproductservicename, AV52Trn_productservicewwds_3_tfproductservicename_sel, lV53Trn_productservicewwds_4_tfproductservicetilename, AV54Trn_productservicewwds_5_tfproductservicetilename_sel, lV55Trn_productservicewwds_6_tfproductservicedescription, AV56Trn_productservicewwds_7_tfproductservicedescription_sel, lV58Trn_productservicewwds_9_tfsuppliergencompanyname, AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, lV60Trn_productservicewwds_11_tfsupplieragbname, AV61Trn_productservicewwds_12_tfsupplieragbname_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6Q4 = false;
            A42SupplierGenId = P006Q3_A42SupplierGenId[0];
            n42SupplierGenId = P006Q3_n42SupplierGenId[0];
            A49SupplierAgbId = P006Q3_A49SupplierAgbId[0];
            n49SupplierAgbId = P006Q3_n49SupplierAgbId[0];
            A301ProductServiceTileName = P006Q3_A301ProductServiceTileName[0];
            A51SupplierAgbName = P006Q3_A51SupplierAgbName[0];
            A44SupplierGenCompanyName = P006Q3_A44SupplierGenCompanyName[0];
            A366ProductServiceGroup = P006Q3_A366ProductServiceGroup[0];
            A60ProductServiceDescription = P006Q3_A60ProductServiceDescription[0];
            A59ProductServiceName = P006Q3_A59ProductServiceName[0];
            A58ProductServiceId = P006Q3_A58ProductServiceId[0];
            A29LocationId = P006Q3_A29LocationId[0];
            A11OrganisationId = P006Q3_A11OrganisationId[0];
            A44SupplierGenCompanyName = P006Q3_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = P006Q3_A51SupplierAgbName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A301ProductServiceTileName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A60ProductServiceDescription , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "location", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( "Location", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "agb supplier", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( " AGB Supplier", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "general supplier", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( "General Supplier", "")) == 0 ) ) || ( StringUtil.Like( A44SupplierGenCompanyName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A51SupplierAgbName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006Q3_A301ProductServiceTileName[0], A301ProductServiceTileName) == 0 ) )
               {
                  BRK6Q4 = false;
                  A58ProductServiceId = P006Q3_A58ProductServiceId[0];
                  A29LocationId = P006Q3_A29LocationId[0];
                  A11OrganisationId = P006Q3_A11OrganisationId[0];
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
         AV50Trn_productservicewwds_1_filterfulltext = AV37FilterFullText;
         AV51Trn_productservicewwds_2_tfproductservicename = AV11TFProductServiceName;
         AV52Trn_productservicewwds_3_tfproductservicename_sel = AV12TFProductServiceName_Sel;
         AV53Trn_productservicewwds_4_tfproductservicetilename = AV44TFProductServiceTileName;
         AV54Trn_productservicewwds_5_tfproductservicetilename_sel = AV45TFProductServiceTileName_Sel;
         AV55Trn_productservicewwds_6_tfproductservicedescription = AV13TFProductServiceDescription;
         AV56Trn_productservicewwds_7_tfproductservicedescription_sel = AV14TFProductServiceDescription_Sel;
         AV57Trn_productservicewwds_8_tfproductservicegroup_sels = AV47TFProductServiceGroup_Sels;
         AV58Trn_productservicewwds_9_tfsuppliergencompanyname = AV39TFSupplierGenCompanyName;
         AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel = AV40TFSupplierGenCompanyName_Sel;
         AV60Trn_productservicewwds_11_tfsupplieragbname = AV41TFSupplierAgbName;
         AV61Trn_productservicewwds_12_tfsupplieragbname_sel = AV42TFSupplierAgbName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A366ProductServiceGroup ,
                                              AV57Trn_productservicewwds_8_tfproductservicegroup_sels ,
                                              AV52Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV51Trn_productservicewwds_2_tfproductservicename ,
                                              AV54Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV53Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV56Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                              AV55Trn_productservicewwds_6_tfproductservicedescription ,
                                              AV57Trn_productservicewwds_8_tfproductservicegroup_sels.Count ,
                                              AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ,
                                              AV58Trn_productservicewwds_9_tfsuppliergencompanyname ,
                                              AV61Trn_productservicewwds_12_tfsupplieragbname_sel ,
                                              AV60Trn_productservicewwds_11_tfsupplieragbname ,
                                              A59ProductServiceName ,
                                              A301ProductServiceTileName ,
                                              A60ProductServiceDescription ,
                                              A44SupplierGenCompanyName ,
                                              A51SupplierAgbName ,
                                              AV50Trn_productservicewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV51Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV51Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV53Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV53Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         lV55Trn_productservicewwds_6_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV55Trn_productservicewwds_6_tfproductservicedescription), "%", "");
         lV58Trn_productservicewwds_9_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_productservicewwds_9_tfsuppliergencompanyname), "%", "");
         lV60Trn_productservicewwds_11_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_productservicewwds_11_tfsupplieragbname), "%", "");
         /* Using cursor P006Q4 */
         pr_default.execute(2, new Object[] {lV51Trn_productservicewwds_2_tfproductservicename, AV52Trn_productservicewwds_3_tfproductservicename_sel, lV53Trn_productservicewwds_4_tfproductservicetilename, AV54Trn_productservicewwds_5_tfproductservicetilename_sel, lV55Trn_productservicewwds_6_tfproductservicedescription, AV56Trn_productservicewwds_7_tfproductservicedescription_sel, lV58Trn_productservicewwds_9_tfsuppliergencompanyname, AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, lV60Trn_productservicewwds_11_tfsupplieragbname, AV61Trn_productservicewwds_12_tfsupplieragbname_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6Q6 = false;
            A42SupplierGenId = P006Q4_A42SupplierGenId[0];
            n42SupplierGenId = P006Q4_n42SupplierGenId[0];
            A49SupplierAgbId = P006Q4_A49SupplierAgbId[0];
            n49SupplierAgbId = P006Q4_n49SupplierAgbId[0];
            A60ProductServiceDescription = P006Q4_A60ProductServiceDescription[0];
            A51SupplierAgbName = P006Q4_A51SupplierAgbName[0];
            A44SupplierGenCompanyName = P006Q4_A44SupplierGenCompanyName[0];
            A366ProductServiceGroup = P006Q4_A366ProductServiceGroup[0];
            A301ProductServiceTileName = P006Q4_A301ProductServiceTileName[0];
            A59ProductServiceName = P006Q4_A59ProductServiceName[0];
            A58ProductServiceId = P006Q4_A58ProductServiceId[0];
            A29LocationId = P006Q4_A29LocationId[0];
            A11OrganisationId = P006Q4_A11OrganisationId[0];
            A44SupplierGenCompanyName = P006Q4_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = P006Q4_A51SupplierAgbName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A301ProductServiceTileName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A60ProductServiceDescription , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "location", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( "Location", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "agb supplier", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( " AGB Supplier", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "general supplier", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( "General Supplier", "")) == 0 ) ) || ( StringUtil.Like( A44SupplierGenCompanyName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A51SupplierAgbName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006Q4_A60ProductServiceDescription[0], A60ProductServiceDescription) == 0 ) )
               {
                  BRK6Q6 = false;
                  A58ProductServiceId = P006Q4_A58ProductServiceId[0];
                  A29LocationId = P006Q4_A29LocationId[0];
                  A11OrganisationId = P006Q4_A11OrganisationId[0];
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
            }
            if ( ! BRK6Q6 )
            {
               BRK6Q6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSUPPLIERGENCOMPANYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV39TFSupplierGenCompanyName = AV15SearchTxt;
         AV40TFSupplierGenCompanyName_Sel = "";
         AV50Trn_productservicewwds_1_filterfulltext = AV37FilterFullText;
         AV51Trn_productservicewwds_2_tfproductservicename = AV11TFProductServiceName;
         AV52Trn_productservicewwds_3_tfproductservicename_sel = AV12TFProductServiceName_Sel;
         AV53Trn_productservicewwds_4_tfproductservicetilename = AV44TFProductServiceTileName;
         AV54Trn_productservicewwds_5_tfproductservicetilename_sel = AV45TFProductServiceTileName_Sel;
         AV55Trn_productservicewwds_6_tfproductservicedescription = AV13TFProductServiceDescription;
         AV56Trn_productservicewwds_7_tfproductservicedescription_sel = AV14TFProductServiceDescription_Sel;
         AV57Trn_productservicewwds_8_tfproductservicegroup_sels = AV47TFProductServiceGroup_Sels;
         AV58Trn_productservicewwds_9_tfsuppliergencompanyname = AV39TFSupplierGenCompanyName;
         AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel = AV40TFSupplierGenCompanyName_Sel;
         AV60Trn_productservicewwds_11_tfsupplieragbname = AV41TFSupplierAgbName;
         AV61Trn_productservicewwds_12_tfsupplieragbname_sel = AV42TFSupplierAgbName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A366ProductServiceGroup ,
                                              AV57Trn_productservicewwds_8_tfproductservicegroup_sels ,
                                              AV52Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV51Trn_productservicewwds_2_tfproductservicename ,
                                              AV54Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV53Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV56Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                              AV55Trn_productservicewwds_6_tfproductservicedescription ,
                                              AV57Trn_productservicewwds_8_tfproductservicegroup_sels.Count ,
                                              AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ,
                                              AV58Trn_productservicewwds_9_tfsuppliergencompanyname ,
                                              AV61Trn_productservicewwds_12_tfsupplieragbname_sel ,
                                              AV60Trn_productservicewwds_11_tfsupplieragbname ,
                                              A59ProductServiceName ,
                                              A301ProductServiceTileName ,
                                              A60ProductServiceDescription ,
                                              A44SupplierGenCompanyName ,
                                              A51SupplierAgbName ,
                                              AV50Trn_productservicewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV51Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV51Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV53Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV53Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         lV55Trn_productservicewwds_6_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV55Trn_productservicewwds_6_tfproductservicedescription), "%", "");
         lV58Trn_productservicewwds_9_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_productservicewwds_9_tfsuppliergencompanyname), "%", "");
         lV60Trn_productservicewwds_11_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_productservicewwds_11_tfsupplieragbname), "%", "");
         /* Using cursor P006Q5 */
         pr_default.execute(3, new Object[] {lV51Trn_productservicewwds_2_tfproductservicename, AV52Trn_productservicewwds_3_tfproductservicename_sel, lV53Trn_productservicewwds_4_tfproductservicetilename, AV54Trn_productservicewwds_5_tfproductservicetilename_sel, lV55Trn_productservicewwds_6_tfproductservicedescription, AV56Trn_productservicewwds_7_tfproductservicedescription_sel, lV58Trn_productservicewwds_9_tfsuppliergencompanyname, AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, lV60Trn_productservicewwds_11_tfsupplieragbname, AV61Trn_productservicewwds_12_tfsupplieragbname_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6Q8 = false;
            A49SupplierAgbId = P006Q5_A49SupplierAgbId[0];
            n49SupplierAgbId = P006Q5_n49SupplierAgbId[0];
            A42SupplierGenId = P006Q5_A42SupplierGenId[0];
            n42SupplierGenId = P006Q5_n42SupplierGenId[0];
            A51SupplierAgbName = P006Q5_A51SupplierAgbName[0];
            A44SupplierGenCompanyName = P006Q5_A44SupplierGenCompanyName[0];
            A366ProductServiceGroup = P006Q5_A366ProductServiceGroup[0];
            A60ProductServiceDescription = P006Q5_A60ProductServiceDescription[0];
            A301ProductServiceTileName = P006Q5_A301ProductServiceTileName[0];
            A59ProductServiceName = P006Q5_A59ProductServiceName[0];
            A58ProductServiceId = P006Q5_A58ProductServiceId[0];
            A29LocationId = P006Q5_A29LocationId[0];
            A11OrganisationId = P006Q5_A11OrganisationId[0];
            A51SupplierAgbName = P006Q5_A51SupplierAgbName[0];
            A44SupplierGenCompanyName = P006Q5_A44SupplierGenCompanyName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A301ProductServiceTileName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A60ProductServiceDescription , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "location", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( "Location", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "agb supplier", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( " AGB Supplier", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "general supplier", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( "General Supplier", "")) == 0 ) ) || ( StringUtil.Like( A44SupplierGenCompanyName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A51SupplierAgbName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( P006Q5_A42SupplierGenId[0] == A42SupplierGenId ) )
               {
                  BRK6Q8 = false;
                  A58ProductServiceId = P006Q5_A58ProductServiceId[0];
                  A29LocationId = P006Q5_A29LocationId[0];
                  A11OrganisationId = P006Q5_A11OrganisationId[0];
                  AV25count = (long)(AV25count+1);
                  BRK6Q8 = true;
                  pr_default.readNext(3);
               }
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A44SupplierGenCompanyName)) ? "<#Empty#>" : A44SupplierGenCompanyName);
               AV19InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV20Option, "<#Empty#>") != 0 ) && ( AV19InsertIndex <= AV21Options.Count ) && ( ( StringUtil.StrCmp(((string)AV21Options.Item(AV19InsertIndex)), AV20Option) < 0 ) || ( StringUtil.StrCmp(((string)AV21Options.Item(AV19InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV19InsertIndex = (int)(AV19InsertIndex+1);
               }
               AV21Options.Add(AV20Option, AV19InsertIndex);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), AV19InsertIndex);
               if ( AV21Options.Count == AV16SkipItems + 11 )
               {
                  AV21Options.RemoveItem(AV21Options.Count);
                  AV24OptionIndexes.RemoveItem(AV24OptionIndexes.Count);
               }
            }
            if ( ! BRK6Q8 )
            {
               BRK6Q8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
         while ( AV16SkipItems > 0 )
         {
            AV21Options.RemoveItem(1);
            AV24OptionIndexes.RemoveItem(1);
            AV16SkipItems = (short)(AV16SkipItems-1);
         }
      }

      protected void S161( )
      {
         /* 'LOADSUPPLIERAGBNAMEOPTIONS' Routine */
         returnInSub = false;
         AV41TFSupplierAgbName = AV15SearchTxt;
         AV42TFSupplierAgbName_Sel = "";
         AV50Trn_productservicewwds_1_filterfulltext = AV37FilterFullText;
         AV51Trn_productservicewwds_2_tfproductservicename = AV11TFProductServiceName;
         AV52Trn_productservicewwds_3_tfproductservicename_sel = AV12TFProductServiceName_Sel;
         AV53Trn_productservicewwds_4_tfproductservicetilename = AV44TFProductServiceTileName;
         AV54Trn_productservicewwds_5_tfproductservicetilename_sel = AV45TFProductServiceTileName_Sel;
         AV55Trn_productservicewwds_6_tfproductservicedescription = AV13TFProductServiceDescription;
         AV56Trn_productservicewwds_7_tfproductservicedescription_sel = AV14TFProductServiceDescription_Sel;
         AV57Trn_productservicewwds_8_tfproductservicegroup_sels = AV47TFProductServiceGroup_Sels;
         AV58Trn_productservicewwds_9_tfsuppliergencompanyname = AV39TFSupplierGenCompanyName;
         AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel = AV40TFSupplierGenCompanyName_Sel;
         AV60Trn_productservicewwds_11_tfsupplieragbname = AV41TFSupplierAgbName;
         AV61Trn_productservicewwds_12_tfsupplieragbname_sel = AV42TFSupplierAgbName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A366ProductServiceGroup ,
                                              AV57Trn_productservicewwds_8_tfproductservicegroup_sels ,
                                              AV52Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV51Trn_productservicewwds_2_tfproductservicename ,
                                              AV54Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV53Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV56Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                              AV55Trn_productservicewwds_6_tfproductservicedescription ,
                                              AV57Trn_productservicewwds_8_tfproductservicegroup_sels.Count ,
                                              AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ,
                                              AV58Trn_productservicewwds_9_tfsuppliergencompanyname ,
                                              AV61Trn_productservicewwds_12_tfsupplieragbname_sel ,
                                              AV60Trn_productservicewwds_11_tfsupplieragbname ,
                                              A59ProductServiceName ,
                                              A301ProductServiceTileName ,
                                              A60ProductServiceDescription ,
                                              A44SupplierGenCompanyName ,
                                              A51SupplierAgbName ,
                                              AV50Trn_productservicewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         lV51Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV51Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV53Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV53Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         lV55Trn_productservicewwds_6_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV55Trn_productservicewwds_6_tfproductservicedescription), "%", "");
         lV58Trn_productservicewwds_9_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_productservicewwds_9_tfsuppliergencompanyname), "%", "");
         lV60Trn_productservicewwds_11_tfsupplieragbname = StringUtil.Concat( StringUtil.RTrim( AV60Trn_productservicewwds_11_tfsupplieragbname), "%", "");
         /* Using cursor P006Q6 */
         pr_default.execute(4, new Object[] {lV51Trn_productservicewwds_2_tfproductservicename, AV52Trn_productservicewwds_3_tfproductservicename_sel, lV53Trn_productservicewwds_4_tfproductservicetilename, AV54Trn_productservicewwds_5_tfproductservicetilename_sel, lV55Trn_productservicewwds_6_tfproductservicedescription, AV56Trn_productservicewwds_7_tfproductservicedescription_sel, lV58Trn_productservicewwds_9_tfsuppliergencompanyname, AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, lV60Trn_productservicewwds_11_tfsupplieragbname, AV61Trn_productservicewwds_12_tfsupplieragbname_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6Q10 = false;
            A42SupplierGenId = P006Q6_A42SupplierGenId[0];
            n42SupplierGenId = P006Q6_n42SupplierGenId[0];
            A49SupplierAgbId = P006Q6_A49SupplierAgbId[0];
            n49SupplierAgbId = P006Q6_n49SupplierAgbId[0];
            A51SupplierAgbName = P006Q6_A51SupplierAgbName[0];
            A44SupplierGenCompanyName = P006Q6_A44SupplierGenCompanyName[0];
            A366ProductServiceGroup = P006Q6_A366ProductServiceGroup[0];
            A60ProductServiceDescription = P006Q6_A60ProductServiceDescription[0];
            A301ProductServiceTileName = P006Q6_A301ProductServiceTileName[0];
            A59ProductServiceName = P006Q6_A59ProductServiceName[0];
            A58ProductServiceId = P006Q6_A58ProductServiceId[0];
            A29LocationId = P006Q6_A29LocationId[0];
            A11OrganisationId = P006Q6_A11OrganisationId[0];
            A44SupplierGenCompanyName = P006Q6_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = P006Q6_A51SupplierAgbName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_productservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A301ProductServiceTileName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A60ProductServiceDescription , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "location", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( "Location", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "agb supplier", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( " AGB Supplier", "")) == 0 ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "general supplier", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, context.GetMessage( "General Supplier", "")) == 0 ) ) || ( StringUtil.Like( A44SupplierGenCompanyName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A51SupplierAgbName , StringUtil.PadR( "%" + AV50Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( P006Q6_A49SupplierAgbId[0] == A49SupplierAgbId ) )
               {
                  BRK6Q10 = false;
                  A58ProductServiceId = P006Q6_A58ProductServiceId[0];
                  A29LocationId = P006Q6_A29LocationId[0];
                  A11OrganisationId = P006Q6_A11OrganisationId[0];
                  AV25count = (long)(AV25count+1);
                  BRK6Q10 = true;
                  pr_default.readNext(4);
               }
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A51SupplierAgbName)) ? "<#Empty#>" : A51SupplierAgbName);
               AV19InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV20Option, "<#Empty#>") != 0 ) && ( AV19InsertIndex <= AV21Options.Count ) && ( ( StringUtil.StrCmp(((string)AV21Options.Item(AV19InsertIndex)), AV20Option) < 0 ) || ( StringUtil.StrCmp(((string)AV21Options.Item(AV19InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV19InsertIndex = (int)(AV19InsertIndex+1);
               }
               AV21Options.Add(AV20Option, AV19InsertIndex);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), AV19InsertIndex);
               if ( AV21Options.Count == AV16SkipItems + 11 )
               {
                  AV21Options.RemoveItem(AV21Options.Count);
                  AV24OptionIndexes.RemoveItem(AV24OptionIndexes.Count);
               }
            }
            if ( ! BRK6Q10 )
            {
               BRK6Q10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
         while ( AV16SkipItems > 0 )
         {
            AV21Options.RemoveItem(1);
            AV24OptionIndexes.RemoveItem(1);
            AV16SkipItems = (short)(AV16SkipItems-1);
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
         AV46TFProductServiceGroup_SelsJson = "";
         AV47TFProductServiceGroup_Sels = new GxSimpleCollection<string>();
         AV39TFSupplierGenCompanyName = "";
         AV40TFSupplierGenCompanyName_Sel = "";
         AV41TFSupplierAgbName = "";
         AV42TFSupplierAgbName_Sel = "";
         AV50Trn_productservicewwds_1_filterfulltext = "";
         AV51Trn_productservicewwds_2_tfproductservicename = "";
         AV52Trn_productservicewwds_3_tfproductservicename_sel = "";
         AV53Trn_productservicewwds_4_tfproductservicetilename = "";
         AV54Trn_productservicewwds_5_tfproductservicetilename_sel = "";
         AV55Trn_productservicewwds_6_tfproductservicedescription = "";
         AV56Trn_productservicewwds_7_tfproductservicedescription_sel = "";
         AV57Trn_productservicewwds_8_tfproductservicegroup_sels = new GxSimpleCollection<string>();
         AV58Trn_productservicewwds_9_tfsuppliergencompanyname = "";
         AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel = "";
         AV60Trn_productservicewwds_11_tfsupplieragbname = "";
         AV61Trn_productservicewwds_12_tfsupplieragbname_sel = "";
         lV50Trn_productservicewwds_1_filterfulltext = "";
         lV51Trn_productservicewwds_2_tfproductservicename = "";
         lV53Trn_productservicewwds_4_tfproductservicetilename = "";
         lV55Trn_productservicewwds_6_tfproductservicedescription = "";
         lV58Trn_productservicewwds_9_tfsuppliergencompanyname = "";
         lV60Trn_productservicewwds_11_tfsupplieragbname = "";
         A366ProductServiceGroup = "";
         A59ProductServiceName = "";
         A301ProductServiceTileName = "";
         A60ProductServiceDescription = "";
         A44SupplierGenCompanyName = "";
         A51SupplierAgbName = "";
         P006Q2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006Q2_n42SupplierGenId = new bool[] {false} ;
         P006Q2_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006Q2_n49SupplierAgbId = new bool[] {false} ;
         P006Q2_A59ProductServiceName = new string[] {""} ;
         P006Q2_A51SupplierAgbName = new string[] {""} ;
         P006Q2_A44SupplierGenCompanyName = new string[] {""} ;
         P006Q2_A366ProductServiceGroup = new string[] {""} ;
         P006Q2_A60ProductServiceDescription = new string[] {""} ;
         P006Q2_A301ProductServiceTileName = new string[] {""} ;
         P006Q2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006Q2_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A42SupplierGenId = Guid.Empty;
         A49SupplierAgbId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV20Option = "";
         P006Q3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006Q3_n42SupplierGenId = new bool[] {false} ;
         P006Q3_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006Q3_n49SupplierAgbId = new bool[] {false} ;
         P006Q3_A301ProductServiceTileName = new string[] {""} ;
         P006Q3_A51SupplierAgbName = new string[] {""} ;
         P006Q3_A44SupplierGenCompanyName = new string[] {""} ;
         P006Q3_A366ProductServiceGroup = new string[] {""} ;
         P006Q3_A60ProductServiceDescription = new string[] {""} ;
         P006Q3_A59ProductServiceName = new string[] {""} ;
         P006Q3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006Q3_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006Q4_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006Q4_n42SupplierGenId = new bool[] {false} ;
         P006Q4_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006Q4_n49SupplierAgbId = new bool[] {false} ;
         P006Q4_A60ProductServiceDescription = new string[] {""} ;
         P006Q4_A51SupplierAgbName = new string[] {""} ;
         P006Q4_A44SupplierGenCompanyName = new string[] {""} ;
         P006Q4_A366ProductServiceGroup = new string[] {""} ;
         P006Q4_A301ProductServiceTileName = new string[] {""} ;
         P006Q4_A59ProductServiceName = new string[] {""} ;
         P006Q4_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006Q4_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006Q5_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006Q5_n49SupplierAgbId = new bool[] {false} ;
         P006Q5_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006Q5_n42SupplierGenId = new bool[] {false} ;
         P006Q5_A51SupplierAgbName = new string[] {""} ;
         P006Q5_A44SupplierGenCompanyName = new string[] {""} ;
         P006Q5_A366ProductServiceGroup = new string[] {""} ;
         P006Q5_A60ProductServiceDescription = new string[] {""} ;
         P006Q5_A301ProductServiceTileName = new string[] {""} ;
         P006Q5_A59ProductServiceName = new string[] {""} ;
         P006Q5_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006Q5_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P006Q6_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006Q6_n42SupplierGenId = new bool[] {false} ;
         P006Q6_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P006Q6_n49SupplierAgbId = new bool[] {false} ;
         P006Q6_A51SupplierAgbName = new string[] {""} ;
         P006Q6_A44SupplierGenCompanyName = new string[] {""} ;
         P006Q6_A366ProductServiceGroup = new string[] {""} ;
         P006Q6_A60ProductServiceDescription = new string[] {""} ;
         P006Q6_A301ProductServiceTileName = new string[] {""} ;
         P006Q6_A59ProductServiceName = new string[] {""} ;
         P006Q6_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006Q6_A29LocationId = new Guid[] {Guid.Empty} ;
         P006Q6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productservicewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006Q2_A42SupplierGenId, P006Q2_n42SupplierGenId, P006Q2_A49SupplierAgbId, P006Q2_n49SupplierAgbId, P006Q2_A59ProductServiceName, P006Q2_A51SupplierAgbName, P006Q2_A44SupplierGenCompanyName, P006Q2_A366ProductServiceGroup, P006Q2_A60ProductServiceDescription, P006Q2_A301ProductServiceTileName,
               P006Q2_A58ProductServiceId, P006Q2_A29LocationId, P006Q2_A11OrganisationId
               }
               , new Object[] {
               P006Q3_A42SupplierGenId, P006Q3_n42SupplierGenId, P006Q3_A49SupplierAgbId, P006Q3_n49SupplierAgbId, P006Q3_A301ProductServiceTileName, P006Q3_A51SupplierAgbName, P006Q3_A44SupplierGenCompanyName, P006Q3_A366ProductServiceGroup, P006Q3_A60ProductServiceDescription, P006Q3_A59ProductServiceName,
               P006Q3_A58ProductServiceId, P006Q3_A29LocationId, P006Q3_A11OrganisationId
               }
               , new Object[] {
               P006Q4_A42SupplierGenId, P006Q4_n42SupplierGenId, P006Q4_A49SupplierAgbId, P006Q4_n49SupplierAgbId, P006Q4_A60ProductServiceDescription, P006Q4_A51SupplierAgbName, P006Q4_A44SupplierGenCompanyName, P006Q4_A366ProductServiceGroup, P006Q4_A301ProductServiceTileName, P006Q4_A59ProductServiceName,
               P006Q4_A58ProductServiceId, P006Q4_A29LocationId, P006Q4_A11OrganisationId
               }
               , new Object[] {
               P006Q5_A49SupplierAgbId, P006Q5_n49SupplierAgbId, P006Q5_A42SupplierGenId, P006Q5_n42SupplierGenId, P006Q5_A51SupplierAgbName, P006Q5_A44SupplierGenCompanyName, P006Q5_A366ProductServiceGroup, P006Q5_A60ProductServiceDescription, P006Q5_A301ProductServiceTileName, P006Q5_A59ProductServiceName,
               P006Q5_A58ProductServiceId, P006Q5_A29LocationId, P006Q5_A11OrganisationId
               }
               , new Object[] {
               P006Q6_A42SupplierGenId, P006Q6_n42SupplierGenId, P006Q6_A49SupplierAgbId, P006Q6_n49SupplierAgbId, P006Q6_A51SupplierAgbName, P006Q6_A44SupplierGenCompanyName, P006Q6_A366ProductServiceGroup, P006Q6_A60ProductServiceDescription, P006Q6_A301ProductServiceTileName, P006Q6_A59ProductServiceName,
               P006Q6_A58ProductServiceId, P006Q6_A29LocationId, P006Q6_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV48GXV1 ;
      private int AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count ;
      private int AV19InsertIndex ;
      private long AV25count ;
      private string AV44TFProductServiceTileName ;
      private string AV45TFProductServiceTileName_Sel ;
      private string AV53Trn_productservicewwds_4_tfproductservicetilename ;
      private string AV54Trn_productservicewwds_5_tfproductservicetilename_sel ;
      private string lV53Trn_productservicewwds_4_tfproductservicetilename ;
      private string A301ProductServiceTileName ;
      private bool returnInSub ;
      private bool BRK6Q2 ;
      private bool n42SupplierGenId ;
      private bool n49SupplierAgbId ;
      private bool BRK6Q4 ;
      private bool BRK6Q6 ;
      private bool BRK6Q8 ;
      private bool BRK6Q10 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV46TFProductServiceGroup_SelsJson ;
      private string A60ProductServiceDescription ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFProductServiceName ;
      private string AV12TFProductServiceName_Sel ;
      private string AV13TFProductServiceDescription ;
      private string AV14TFProductServiceDescription_Sel ;
      private string AV39TFSupplierGenCompanyName ;
      private string AV40TFSupplierGenCompanyName_Sel ;
      private string AV41TFSupplierAgbName ;
      private string AV42TFSupplierAgbName_Sel ;
      private string AV50Trn_productservicewwds_1_filterfulltext ;
      private string AV51Trn_productservicewwds_2_tfproductservicename ;
      private string AV52Trn_productservicewwds_3_tfproductservicename_sel ;
      private string AV55Trn_productservicewwds_6_tfproductservicedescription ;
      private string AV56Trn_productservicewwds_7_tfproductservicedescription_sel ;
      private string AV58Trn_productservicewwds_9_tfsuppliergencompanyname ;
      private string AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ;
      private string AV60Trn_productservicewwds_11_tfsupplieragbname ;
      private string AV61Trn_productservicewwds_12_tfsupplieragbname_sel ;
      private string lV50Trn_productservicewwds_1_filterfulltext ;
      private string lV51Trn_productservicewwds_2_tfproductservicename ;
      private string lV55Trn_productservicewwds_6_tfproductservicedescription ;
      private string lV58Trn_productservicewwds_9_tfsuppliergencompanyname ;
      private string lV60Trn_productservicewwds_11_tfsupplieragbname ;
      private string A366ProductServiceGroup ;
      private string A59ProductServiceName ;
      private string A44SupplierGenCompanyName ;
      private string A51SupplierAgbName ;
      private string AV20Option ;
      private Guid A42SupplierGenId ;
      private Guid A49SupplierAgbId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV26Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GxSimpleCollection<string> AV47TFProductServiceGroup_Sels ;
      private GxSimpleCollection<string> AV57Trn_productservicewwds_8_tfproductservicegroup_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006Q2_A42SupplierGenId ;
      private bool[] P006Q2_n42SupplierGenId ;
      private Guid[] P006Q2_A49SupplierAgbId ;
      private bool[] P006Q2_n49SupplierAgbId ;
      private string[] P006Q2_A59ProductServiceName ;
      private string[] P006Q2_A51SupplierAgbName ;
      private string[] P006Q2_A44SupplierGenCompanyName ;
      private string[] P006Q2_A366ProductServiceGroup ;
      private string[] P006Q2_A60ProductServiceDescription ;
      private string[] P006Q2_A301ProductServiceTileName ;
      private Guid[] P006Q2_A58ProductServiceId ;
      private Guid[] P006Q2_A29LocationId ;
      private Guid[] P006Q2_A11OrganisationId ;
      private Guid[] P006Q3_A42SupplierGenId ;
      private bool[] P006Q3_n42SupplierGenId ;
      private Guid[] P006Q3_A49SupplierAgbId ;
      private bool[] P006Q3_n49SupplierAgbId ;
      private string[] P006Q3_A301ProductServiceTileName ;
      private string[] P006Q3_A51SupplierAgbName ;
      private string[] P006Q3_A44SupplierGenCompanyName ;
      private string[] P006Q3_A366ProductServiceGroup ;
      private string[] P006Q3_A60ProductServiceDescription ;
      private string[] P006Q3_A59ProductServiceName ;
      private Guid[] P006Q3_A58ProductServiceId ;
      private Guid[] P006Q3_A29LocationId ;
      private Guid[] P006Q3_A11OrganisationId ;
      private Guid[] P006Q4_A42SupplierGenId ;
      private bool[] P006Q4_n42SupplierGenId ;
      private Guid[] P006Q4_A49SupplierAgbId ;
      private bool[] P006Q4_n49SupplierAgbId ;
      private string[] P006Q4_A60ProductServiceDescription ;
      private string[] P006Q4_A51SupplierAgbName ;
      private string[] P006Q4_A44SupplierGenCompanyName ;
      private string[] P006Q4_A366ProductServiceGroup ;
      private string[] P006Q4_A301ProductServiceTileName ;
      private string[] P006Q4_A59ProductServiceName ;
      private Guid[] P006Q4_A58ProductServiceId ;
      private Guid[] P006Q4_A29LocationId ;
      private Guid[] P006Q4_A11OrganisationId ;
      private Guid[] P006Q5_A49SupplierAgbId ;
      private bool[] P006Q5_n49SupplierAgbId ;
      private Guid[] P006Q5_A42SupplierGenId ;
      private bool[] P006Q5_n42SupplierGenId ;
      private string[] P006Q5_A51SupplierAgbName ;
      private string[] P006Q5_A44SupplierGenCompanyName ;
      private string[] P006Q5_A366ProductServiceGroup ;
      private string[] P006Q5_A60ProductServiceDescription ;
      private string[] P006Q5_A301ProductServiceTileName ;
      private string[] P006Q5_A59ProductServiceName ;
      private Guid[] P006Q5_A58ProductServiceId ;
      private Guid[] P006Q5_A29LocationId ;
      private Guid[] P006Q5_A11OrganisationId ;
      private Guid[] P006Q6_A42SupplierGenId ;
      private bool[] P006Q6_n42SupplierGenId ;
      private Guid[] P006Q6_A49SupplierAgbId ;
      private bool[] P006Q6_n49SupplierAgbId ;
      private string[] P006Q6_A51SupplierAgbName ;
      private string[] P006Q6_A44SupplierGenCompanyName ;
      private string[] P006Q6_A366ProductServiceGroup ;
      private string[] P006Q6_A60ProductServiceDescription ;
      private string[] P006Q6_A301ProductServiceTileName ;
      private string[] P006Q6_A59ProductServiceName ;
      private Guid[] P006Q6_A58ProductServiceId ;
      private Guid[] P006Q6_A29LocationId ;
      private Guid[] P006Q6_A11OrganisationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_productservicewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006Q2( IGxContext context ,
                                             string A366ProductServiceGroup ,
                                             GxSimpleCollection<string> AV57Trn_productservicewwds_8_tfproductservicegroup_sels ,
                                             string AV52Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV51Trn_productservicewwds_2_tfproductservicename ,
                                             string AV54Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV53Trn_productservicewwds_4_tfproductservicetilename ,
                                             string AV56Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                             string AV55Trn_productservicewwds_6_tfproductservicedescription ,
                                             int AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count ,
                                             string AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ,
                                             string AV58Trn_productservicewwds_9_tfsuppliergencompanyname ,
                                             string AV61Trn_productservicewwds_12_tfsupplieragbname_sel ,
                                             string AV60Trn_productservicewwds_11_tfsupplieragbname ,
                                             string A59ProductServiceName ,
                                             string A301ProductServiceTileName ,
                                             string A60ProductServiceDescription ,
                                             string A44SupplierGenCompanyName ,
                                             string A51SupplierAgbName ,
                                             string AV50Trn_productservicewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenId, T1.SupplierAgbId, T1.ProductServiceName, T3.SupplierAgbName, T2.SupplierGenCompanyName, T1.ProductServiceGroup, T1.ProductServiceDescription, T1.ProductServiceTileName, T1.ProductServiceId, T1.LocationId, T1.OrganisationId FROM ((Trn_ProductService T1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = T1.SupplierGenId) LEFT JOIN Trn_SupplierAGB T3 ON T3.SupplierAgbId = T1.SupplierAgbId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV51Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV52Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName like :lV53Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV54Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName = ( :AV54Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceTileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_productservicewwds_7_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_productservicewwds_6_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceDescription like :lV55Trn_productservicewwds_6_tfproductservicedescription)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_productservicewwds_7_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV56Trn_productservicewwds_7_tfproductservicedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceDescription = ( :AV56Trn_productservicewwds_7_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_productservicewwds_7_tfproductservicedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceDescription))=0))");
         }
         if ( AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_productservicewwds_8_tfproductservicegroup_sels, "T1.ProductServiceGroup IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_productservicewwds_9_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName like :lV58Trn_productservicewwds_9_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName = ( :AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName IS NULL or (char_length(trim(trailing ' ' from T2.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_12_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_11_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName like :lV60Trn_productservicewwds_11_tfsupplieragbname)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_12_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_productservicewwds_12_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName = ( :AV61Trn_productservicewwds_12_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_productservicewwds_12_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName IS NULL or (char_length(trim(trailing ' ' from T3.SupplierAgbName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProductServiceName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006Q3( IGxContext context ,
                                             string A366ProductServiceGroup ,
                                             GxSimpleCollection<string> AV57Trn_productservicewwds_8_tfproductservicegroup_sels ,
                                             string AV52Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV51Trn_productservicewwds_2_tfproductservicename ,
                                             string AV54Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV53Trn_productservicewwds_4_tfproductservicetilename ,
                                             string AV56Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                             string AV55Trn_productservicewwds_6_tfproductservicedescription ,
                                             int AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count ,
                                             string AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ,
                                             string AV58Trn_productservicewwds_9_tfsuppliergencompanyname ,
                                             string AV61Trn_productservicewwds_12_tfsupplieragbname_sel ,
                                             string AV60Trn_productservicewwds_11_tfsupplieragbname ,
                                             string A59ProductServiceName ,
                                             string A301ProductServiceTileName ,
                                             string A60ProductServiceDescription ,
                                             string A44SupplierGenCompanyName ,
                                             string A51SupplierAgbName ,
                                             string AV50Trn_productservicewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenId, T1.SupplierAgbId, T1.ProductServiceTileName, T3.SupplierAgbName, T2.SupplierGenCompanyName, T1.ProductServiceGroup, T1.ProductServiceDescription, T1.ProductServiceName, T1.ProductServiceId, T1.LocationId, T1.OrganisationId FROM ((Trn_ProductService T1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = T1.SupplierGenId) LEFT JOIN Trn_SupplierAGB T3 ON T3.SupplierAgbId = T1.SupplierAgbId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV51Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV52Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName like :lV53Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV54Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName = ( :AV54Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceTileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_productservicewwds_7_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_productservicewwds_6_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceDescription like :lV55Trn_productservicewwds_6_tfproductservicedescription)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_productservicewwds_7_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV56Trn_productservicewwds_7_tfproductservicedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceDescription = ( :AV56Trn_productservicewwds_7_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_productservicewwds_7_tfproductservicedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceDescription))=0))");
         }
         if ( AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_productservicewwds_8_tfproductservicegroup_sels, "T1.ProductServiceGroup IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_productservicewwds_9_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName like :lV58Trn_productservicewwds_9_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName = ( :AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName IS NULL or (char_length(trim(trailing ' ' from T2.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_12_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_11_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName like :lV60Trn_productservicewwds_11_tfsupplieragbname)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_12_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_productservicewwds_12_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName = ( :AV61Trn_productservicewwds_12_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_productservicewwds_12_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName IS NULL or (char_length(trim(trailing ' ' from T3.SupplierAgbName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProductServiceTileName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006Q4( IGxContext context ,
                                             string A366ProductServiceGroup ,
                                             GxSimpleCollection<string> AV57Trn_productservicewwds_8_tfproductservicegroup_sels ,
                                             string AV52Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV51Trn_productservicewwds_2_tfproductservicename ,
                                             string AV54Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV53Trn_productservicewwds_4_tfproductservicetilename ,
                                             string AV56Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                             string AV55Trn_productservicewwds_6_tfproductservicedescription ,
                                             int AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count ,
                                             string AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ,
                                             string AV58Trn_productservicewwds_9_tfsuppliergencompanyname ,
                                             string AV61Trn_productservicewwds_12_tfsupplieragbname_sel ,
                                             string AV60Trn_productservicewwds_11_tfsupplieragbname ,
                                             string A59ProductServiceName ,
                                             string A301ProductServiceTileName ,
                                             string A60ProductServiceDescription ,
                                             string A44SupplierGenCompanyName ,
                                             string A51SupplierAgbName ,
                                             string AV50Trn_productservicewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[10];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenId, T1.SupplierAgbId, T1.ProductServiceDescription, T3.SupplierAgbName, T2.SupplierGenCompanyName, T1.ProductServiceGroup, T1.ProductServiceTileName, T1.ProductServiceName, T1.ProductServiceId, T1.LocationId, T1.OrganisationId FROM ((Trn_ProductService T1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = T1.SupplierGenId) LEFT JOIN Trn_SupplierAGB T3 ON T3.SupplierAgbId = T1.SupplierAgbId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV51Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV52Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName like :lV53Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV54Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName = ( :AV54Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceTileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_productservicewwds_7_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_productservicewwds_6_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceDescription like :lV55Trn_productservicewwds_6_tfproductservicedescription)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_productservicewwds_7_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV56Trn_productservicewwds_7_tfproductservicedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceDescription = ( :AV56Trn_productservicewwds_7_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_productservicewwds_7_tfproductservicedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceDescription))=0))");
         }
         if ( AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_productservicewwds_8_tfproductservicegroup_sels, "T1.ProductServiceGroup IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_productservicewwds_9_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName like :lV58Trn_productservicewwds_9_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName = ( :AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName IS NULL or (char_length(trim(trailing ' ' from T2.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_12_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_11_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName like :lV60Trn_productservicewwds_11_tfsupplieragbname)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_12_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_productservicewwds_12_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName = ( :AV61Trn_productservicewwds_12_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_productservicewwds_12_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName IS NULL or (char_length(trim(trailing ' ' from T3.SupplierAgbName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProductServiceDescription";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006Q5( IGxContext context ,
                                             string A366ProductServiceGroup ,
                                             GxSimpleCollection<string> AV57Trn_productservicewwds_8_tfproductservicegroup_sels ,
                                             string AV52Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV51Trn_productservicewwds_2_tfproductservicename ,
                                             string AV54Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV53Trn_productservicewwds_4_tfproductservicetilename ,
                                             string AV56Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                             string AV55Trn_productservicewwds_6_tfproductservicedescription ,
                                             int AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count ,
                                             string AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ,
                                             string AV58Trn_productservicewwds_9_tfsuppliergencompanyname ,
                                             string AV61Trn_productservicewwds_12_tfsupplieragbname_sel ,
                                             string AV60Trn_productservicewwds_11_tfsupplieragbname ,
                                             string A59ProductServiceName ,
                                             string A301ProductServiceTileName ,
                                             string A60ProductServiceDescription ,
                                             string A44SupplierGenCompanyName ,
                                             string A51SupplierAgbName ,
                                             string AV50Trn_productservicewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[10];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.SupplierAgbId, T1.SupplierGenId, T2.SupplierAgbName, T3.SupplierGenCompanyName, T1.ProductServiceGroup, T1.ProductServiceDescription, T1.ProductServiceTileName, T1.ProductServiceName, T1.ProductServiceId, T1.LocationId, T1.OrganisationId FROM ((Trn_ProductService T1 LEFT JOIN Trn_SupplierAGB T2 ON T2.SupplierAgbId = T1.SupplierAgbId) LEFT JOIN Trn_SupplierGen T3 ON T3.SupplierGenId = T1.SupplierGenId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV51Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV52Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName like :lV53Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV54Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName = ( :AV54Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceTileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_productservicewwds_7_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_productservicewwds_6_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceDescription like :lV55Trn_productservicewwds_6_tfproductservicedescription)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_productservicewwds_7_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV56Trn_productservicewwds_7_tfproductservicedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceDescription = ( :AV56Trn_productservicewwds_7_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_productservicewwds_7_tfproductservicedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceDescription))=0))");
         }
         if ( AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_productservicewwds_8_tfproductservicegroup_sels, "T1.ProductServiceGroup IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_productservicewwds_9_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SupplierGenCompanyName like :lV58Trn_productservicewwds_9_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SupplierGenCompanyName = ( :AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T3.SupplierGenCompanyName IS NULL or (char_length(trim(trailing ' ' from T3.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_12_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_11_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbName like :lV60Trn_productservicewwds_11_tfsupplieragbname)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_12_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_productservicewwds_12_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbName = ( :AV61Trn_productservicewwds_12_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_productservicewwds_12_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.SupplierAgbName IS NULL or (char_length(trim(trailing ' ' from T2.SupplierAgbName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierGenId";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P006Q6( IGxContext context ,
                                             string A366ProductServiceGroup ,
                                             GxSimpleCollection<string> AV57Trn_productservicewwds_8_tfproductservicegroup_sels ,
                                             string AV52Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV51Trn_productservicewwds_2_tfproductservicename ,
                                             string AV54Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV53Trn_productservicewwds_4_tfproductservicetilename ,
                                             string AV56Trn_productservicewwds_7_tfproductservicedescription_sel ,
                                             string AV55Trn_productservicewwds_6_tfproductservicedescription ,
                                             int AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count ,
                                             string AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel ,
                                             string AV58Trn_productservicewwds_9_tfsuppliergencompanyname ,
                                             string AV61Trn_productservicewwds_12_tfsupplieragbname_sel ,
                                             string AV60Trn_productservicewwds_11_tfsupplieragbname ,
                                             string A59ProductServiceName ,
                                             string A301ProductServiceTileName ,
                                             string A60ProductServiceDescription ,
                                             string A44SupplierGenCompanyName ,
                                             string A51SupplierAgbName ,
                                             string AV50Trn_productservicewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[10];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.SupplierGenId, T1.SupplierAgbId, T3.SupplierAgbName, T2.SupplierGenCompanyName, T1.ProductServiceGroup, T1.ProductServiceDescription, T1.ProductServiceTileName, T1.ProductServiceName, T1.ProductServiceId, T1.LocationId, T1.OrganisationId FROM ((Trn_ProductService T1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = T1.SupplierGenId) LEFT JOIN Trn_SupplierAGB T3 ON T3.SupplierAgbId = T1.SupplierAgbId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV51Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV52Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_productservicewwds_3_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName like :lV53Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV54Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName = ( :AV54Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV54Trn_productservicewwds_5_tfproductservicetilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceTileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_productservicewwds_7_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_productservicewwds_6_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceDescription like :lV55Trn_productservicewwds_6_tfproductservicedescription)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_productservicewwds_7_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV56Trn_productservicewwds_7_tfproductservicedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceDescription = ( :AV56Trn_productservicewwds_7_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_productservicewwds_7_tfproductservicedescription_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceDescription))=0))");
         }
         if ( AV57Trn_productservicewwds_8_tfproductservicegroup_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57Trn_productservicewwds_8_tfproductservicegroup_sels, "T1.ProductServiceGroup IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_productservicewwds_9_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName like :lV58Trn_productservicewwds_9_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName = ( :AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.SupplierGenCompanyName IS NULL or (char_length(trim(trailing ' ' from T2.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_12_tfsupplieragbname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_11_tfsupplieragbname)) ) )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName like :lV60Trn_productservicewwds_11_tfsupplieragbname)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_12_tfsupplieragbname_sel)) && ! ( StringUtil.StrCmp(AV61Trn_productservicewwds_12_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName = ( :AV61Trn_productservicewwds_12_tfsupplieragbname_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_productservicewwds_12_tfsupplieragbname_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T3.SupplierAgbName IS NULL or (char_length(trim(trailing ' ' from T3.SupplierAgbName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SupplierAgbId";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006Q2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 1 :
                     return conditional_P006Q3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 2 :
                     return conditional_P006Q4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 3 :
                     return conditional_P006Q5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 4 :
                     return conditional_P006Q6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006Q2;
          prmP006Q2 = new Object[] {
          new ParDef("lV51Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV54Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0) ,
          new ParDef("lV55Trn_productservicewwds_6_tfproductservicedescription",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_productservicewwds_7_tfproductservicedescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV58Trn_productservicewwds_9_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_productservicewwds_11_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_productservicewwds_12_tfsupplieragbname_sel",GXType.VarChar,100,0)
          };
          Object[] prmP006Q3;
          prmP006Q3 = new Object[] {
          new ParDef("lV51Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV54Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0) ,
          new ParDef("lV55Trn_productservicewwds_6_tfproductservicedescription",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_productservicewwds_7_tfproductservicedescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV58Trn_productservicewwds_9_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_productservicewwds_11_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_productservicewwds_12_tfsupplieragbname_sel",GXType.VarChar,100,0)
          };
          Object[] prmP006Q4;
          prmP006Q4 = new Object[] {
          new ParDef("lV51Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV54Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0) ,
          new ParDef("lV55Trn_productservicewwds_6_tfproductservicedescription",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_productservicewwds_7_tfproductservicedescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV58Trn_productservicewwds_9_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_productservicewwds_11_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_productservicewwds_12_tfsupplieragbname_sel",GXType.VarChar,100,0)
          };
          Object[] prmP006Q5;
          prmP006Q5 = new Object[] {
          new ParDef("lV51Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV54Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0) ,
          new ParDef("lV55Trn_productservicewwds_6_tfproductservicedescription",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_productservicewwds_7_tfproductservicedescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV58Trn_productservicewwds_9_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_productservicewwds_11_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_productservicewwds_12_tfsupplieragbname_sel",GXType.VarChar,100,0)
          };
          Object[] prmP006Q6;
          prmP006Q6 = new Object[] {
          new ParDef("lV51Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV54Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0) ,
          new ParDef("lV55Trn_productservicewwds_6_tfproductservicedescription",GXType.VarChar,200,0) ,
          new ParDef("AV56Trn_productservicewwds_7_tfproductservicedescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV58Trn_productservicewwds_9_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_productservicewwds_10_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_productservicewwds_11_tfsupplieragbname",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_productservicewwds_12_tfsupplieragbname_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Q4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Q5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Q6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q6,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                return;
       }
    }

 }

}
