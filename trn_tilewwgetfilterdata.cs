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
   public class trn_tilewwgetfilterdata : GXProcedure
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
            return "trn_tileww_Services_Execute" ;
         }

      }

      public trn_tilewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_tilewwgetfilterdata( IGxContext context )
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
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV34OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV16MaxItems = 10;
         AV15PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV30SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? "" : StringUtil.Substring( AV30SearchTxtParms, 3, -1));
         AV14SkipItems = (short)(AV15PageIndex*AV16MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TRN_TILENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_TILENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TRN_TILEBGIMAGEURL") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_TILEBGIMAGEURLOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PRODUCTSERVICENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICENAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PRODUCTSERVICEDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICEDESCRIPTIONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_SG_TOPAGENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSG_TOPAGENAMEOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV32OptionsJson = AV19Options.ToJSonString(false);
         AV33OptionsDescJson = AV21OptionsDesc.ToJSonString(false);
         AV34OptionIndexesJson = AV22OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24Session.Get("Trn_TileWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_TileWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("Trn_TileWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_TILENAME") == 0 )
            {
               AV11TFTrn_TileName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_TILENAME_SEL") == 0 )
            {
               AV12TFTrn_TileName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_TILEWIDTH_SEL") == 0 )
            {
               AV36TFTrn_TileWidth_SelsJson = AV27GridStateFilterValue.gxTpr_Value;
               AV37TFTrn_TileWidth_Sels.FromJSonString(AV36TFTrn_TileWidth_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_TILECOLOR_SEL") == 0 )
            {
               AV42TFTrn_TileColor_SelsJson = AV27GridStateFilterValue.gxTpr_Value;
               AV43TFTrn_TileColor_Sels.FromJSonString(AV42TFTrn_TileColor_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_TILEBGIMAGEURL") == 0 )
            {
               AV44TFTrn_TileBGImageUrl = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_TILEBGIMAGEURL_SEL") == 0 )
            {
               AV45TFTrn_TileBGImageUrl_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME") == 0 )
            {
               AV38TFProductServiceName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME_SEL") == 0 )
            {
               AV39TFProductServiceName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICEDESCRIPTION") == 0 )
            {
               AV40TFProductServiceDescription = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICEDESCRIPTION_SEL") == 0 )
            {
               AV41TFProductServiceDescription_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSG_TOPAGENAME") == 0 )
            {
               AV46TFSG_ToPageName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSG_TOPAGENAME_SEL") == 0 )
            {
               AV47TFSG_ToPageName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRN_TILENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTrn_TileName = AV13SearchTxt;
         AV12TFTrn_TileName_Sel = "";
         AV50Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV51Trn_tilewwds_2_tftrn_tilename = AV11TFTrn_TileName;
         AV52Trn_tilewwds_3_tftrn_tilename_sel = AV12TFTrn_TileName_Sel;
         AV53Trn_tilewwds_4_tftrn_tilewidth_sels = AV37TFTrn_TileWidth_Sels;
         AV54Trn_tilewwds_5_tftrn_tilecolor_sels = AV43TFTrn_TileColor_Sels;
         AV55Trn_tilewwds_6_tftrn_tilebgimageurl = AV44TFTrn_TileBGImageUrl;
         AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel = AV45TFTrn_TileBGImageUrl_Sel;
         AV57Trn_tilewwds_8_tfproductservicename = AV38TFProductServiceName;
         AV58Trn_tilewwds_9_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV59Trn_tilewwds_10_tfproductservicedescription = AV40TFProductServiceDescription;
         AV60Trn_tilewwds_11_tfproductservicedescription_sel = AV41TFProductServiceDescription_Sel;
         AV61Trn_tilewwds_12_tfsg_topagename = AV46TFSG_ToPageName;
         AV62Trn_tilewwds_13_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A268Trn_TileWidth ,
                                              AV53Trn_tilewwds_4_tftrn_tilewidth_sels ,
                                              A270Trn_TileColor ,
                                              AV54Trn_tilewwds_5_tftrn_tilecolor_sels ,
                                              AV50Trn_tilewwds_1_filterfulltext ,
                                              AV52Trn_tilewwds_3_tftrn_tilename_sel ,
                                              AV51Trn_tilewwds_2_tftrn_tilename ,
                                              AV53Trn_tilewwds_4_tftrn_tilewidth_sels.Count ,
                                              AV54Trn_tilewwds_5_tftrn_tilecolor_sels.Count ,
                                              AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ,
                                              AV55Trn_tilewwds_6_tftrn_tilebgimageurl ,
                                              AV58Trn_tilewwds_9_tfproductservicename_sel ,
                                              AV57Trn_tilewwds_8_tfproductservicename ,
                                              AV60Trn_tilewwds_11_tfproductservicedescription_sel ,
                                              AV59Trn_tilewwds_10_tfproductservicedescription ,
                                              AV62Trn_tilewwds_13_tfsg_topagename_sel ,
                                              AV61Trn_tilewwds_12_tfsg_topagename ,
                                              A265Trn_TileName ,
                                              A271Trn_TileBGImageUrl ,
                                              A59ProductServiceName ,
                                              A60ProductServiceDescription ,
                                              A330SG_ToPageName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV51Trn_tilewwds_2_tftrn_tilename = StringUtil.Concat( StringUtil.RTrim( AV51Trn_tilewwds_2_tftrn_tilename), "%", "");
         lV55Trn_tilewwds_6_tftrn_tilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_6_tftrn_tilebgimageurl), "%", "");
         lV57Trn_tilewwds_8_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV57Trn_tilewwds_8_tfproductservicename), "%", "");
         lV59Trn_tilewwds_10_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_10_tfproductservicedescription), "%", "");
         lV61Trn_tilewwds_12_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV61Trn_tilewwds_12_tfsg_topagename), "%", "");
         /* Using cursor P00692 */
         pr_default.execute(0, new Object[] {lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV51Trn_tilewwds_2_tftrn_tilename, AV52Trn_tilewwds_3_tftrn_tilename_sel, lV55Trn_tilewwds_6_tftrn_tilebgimageurl, AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, lV57Trn_tilewwds_8_tfproductservicename, AV58Trn_tilewwds_9_tfproductservicename_sel, lV59Trn_tilewwds_10_tfproductservicedescription, AV60Trn_tilewwds_11_tfproductservicedescription_sel, lV61Trn_tilewwds_12_tfsg_topagename, AV62Trn_tilewwds_13_tfsg_topagename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK692 = false;
            A58ProductServiceId = P00692_A58ProductServiceId[0];
            n58ProductServiceId = P00692_n58ProductServiceId[0];
            A329SG_ToPageId = P00692_A329SG_ToPageId[0];
            A265Trn_TileName = P00692_A265Trn_TileName[0];
            A330SG_ToPageName = P00692_A330SG_ToPageName[0];
            A60ProductServiceDescription = P00692_A60ProductServiceDescription[0];
            A59ProductServiceName = P00692_A59ProductServiceName[0];
            A271Trn_TileBGImageUrl = P00692_A271Trn_TileBGImageUrl[0];
            A270Trn_TileColor = P00692_A270Trn_TileColor[0];
            A268Trn_TileWidth = P00692_A268Trn_TileWidth[0];
            A264Trn_TileId = P00692_A264Trn_TileId[0];
            A60ProductServiceDescription = P00692_A60ProductServiceDescription[0];
            A59ProductServiceName = P00692_A59ProductServiceName[0];
            A330SG_ToPageName = P00692_A330SG_ToPageName[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00692_A265Trn_TileName[0], A265Trn_TileName) == 0 ) )
            {
               BRK692 = false;
               A264Trn_TileId = P00692_A264Trn_TileId[0];
               AV23count = (long)(AV23count+1);
               BRK692 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A265Trn_TileName)) ? "<#Empty#>" : A265Trn_TileName);
               AV19Options.Add(AV18Option, 0);
               AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV14SkipItems = (short)(AV14SkipItems-1);
            }
            if ( ! BRK692 )
            {
               BRK692 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTRN_TILEBGIMAGEURLOPTIONS' Routine */
         returnInSub = false;
         AV44TFTrn_TileBGImageUrl = AV13SearchTxt;
         AV45TFTrn_TileBGImageUrl_Sel = "";
         AV50Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV51Trn_tilewwds_2_tftrn_tilename = AV11TFTrn_TileName;
         AV52Trn_tilewwds_3_tftrn_tilename_sel = AV12TFTrn_TileName_Sel;
         AV53Trn_tilewwds_4_tftrn_tilewidth_sels = AV37TFTrn_TileWidth_Sels;
         AV54Trn_tilewwds_5_tftrn_tilecolor_sels = AV43TFTrn_TileColor_Sels;
         AV55Trn_tilewwds_6_tftrn_tilebgimageurl = AV44TFTrn_TileBGImageUrl;
         AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel = AV45TFTrn_TileBGImageUrl_Sel;
         AV57Trn_tilewwds_8_tfproductservicename = AV38TFProductServiceName;
         AV58Trn_tilewwds_9_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV59Trn_tilewwds_10_tfproductservicedescription = AV40TFProductServiceDescription;
         AV60Trn_tilewwds_11_tfproductservicedescription_sel = AV41TFProductServiceDescription_Sel;
         AV61Trn_tilewwds_12_tfsg_topagename = AV46TFSG_ToPageName;
         AV62Trn_tilewwds_13_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A268Trn_TileWidth ,
                                              AV53Trn_tilewwds_4_tftrn_tilewidth_sels ,
                                              A270Trn_TileColor ,
                                              AV54Trn_tilewwds_5_tftrn_tilecolor_sels ,
                                              AV50Trn_tilewwds_1_filterfulltext ,
                                              AV52Trn_tilewwds_3_tftrn_tilename_sel ,
                                              AV51Trn_tilewwds_2_tftrn_tilename ,
                                              AV53Trn_tilewwds_4_tftrn_tilewidth_sels.Count ,
                                              AV54Trn_tilewwds_5_tftrn_tilecolor_sels.Count ,
                                              AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ,
                                              AV55Trn_tilewwds_6_tftrn_tilebgimageurl ,
                                              AV58Trn_tilewwds_9_tfproductservicename_sel ,
                                              AV57Trn_tilewwds_8_tfproductservicename ,
                                              AV60Trn_tilewwds_11_tfproductservicedescription_sel ,
                                              AV59Trn_tilewwds_10_tfproductservicedescription ,
                                              AV62Trn_tilewwds_13_tfsg_topagename_sel ,
                                              AV61Trn_tilewwds_12_tfsg_topagename ,
                                              A265Trn_TileName ,
                                              A271Trn_TileBGImageUrl ,
                                              A59ProductServiceName ,
                                              A60ProductServiceDescription ,
                                              A330SG_ToPageName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV51Trn_tilewwds_2_tftrn_tilename = StringUtil.Concat( StringUtil.RTrim( AV51Trn_tilewwds_2_tftrn_tilename), "%", "");
         lV55Trn_tilewwds_6_tftrn_tilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_6_tftrn_tilebgimageurl), "%", "");
         lV57Trn_tilewwds_8_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV57Trn_tilewwds_8_tfproductservicename), "%", "");
         lV59Trn_tilewwds_10_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_10_tfproductservicedescription), "%", "");
         lV61Trn_tilewwds_12_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV61Trn_tilewwds_12_tfsg_topagename), "%", "");
         /* Using cursor P00693 */
         pr_default.execute(1, new Object[] {lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV51Trn_tilewwds_2_tftrn_tilename, AV52Trn_tilewwds_3_tftrn_tilename_sel, lV55Trn_tilewwds_6_tftrn_tilebgimageurl, AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, lV57Trn_tilewwds_8_tfproductservicename, AV58Trn_tilewwds_9_tfproductservicename_sel, lV59Trn_tilewwds_10_tfproductservicedescription, AV60Trn_tilewwds_11_tfproductservicedescription_sel, lV61Trn_tilewwds_12_tfsg_topagename, AV62Trn_tilewwds_13_tfsg_topagename_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK694 = false;
            A58ProductServiceId = P00693_A58ProductServiceId[0];
            n58ProductServiceId = P00693_n58ProductServiceId[0];
            A329SG_ToPageId = P00693_A329SG_ToPageId[0];
            A271Trn_TileBGImageUrl = P00693_A271Trn_TileBGImageUrl[0];
            A330SG_ToPageName = P00693_A330SG_ToPageName[0];
            A60ProductServiceDescription = P00693_A60ProductServiceDescription[0];
            A59ProductServiceName = P00693_A59ProductServiceName[0];
            A270Trn_TileColor = P00693_A270Trn_TileColor[0];
            A268Trn_TileWidth = P00693_A268Trn_TileWidth[0];
            A265Trn_TileName = P00693_A265Trn_TileName[0];
            A264Trn_TileId = P00693_A264Trn_TileId[0];
            A60ProductServiceDescription = P00693_A60ProductServiceDescription[0];
            A59ProductServiceName = P00693_A59ProductServiceName[0];
            A330SG_ToPageName = P00693_A330SG_ToPageName[0];
            AV23count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00693_A271Trn_TileBGImageUrl[0], A271Trn_TileBGImageUrl) == 0 ) )
            {
               BRK694 = false;
               A264Trn_TileId = P00693_A264Trn_TileId[0];
               AV23count = (long)(AV23count+1);
               BRK694 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A271Trn_TileBGImageUrl)) ? "<#Empty#>" : A271Trn_TileBGImageUrl);
               AV19Options.Add(AV18Option, 0);
               AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV14SkipItems = (short)(AV14SkipItems-1);
            }
            if ( ! BRK694 )
            {
               BRK694 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPRODUCTSERVICENAMEOPTIONS' Routine */
         returnInSub = false;
         AV38TFProductServiceName = AV13SearchTxt;
         AV39TFProductServiceName_Sel = "";
         AV50Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV51Trn_tilewwds_2_tftrn_tilename = AV11TFTrn_TileName;
         AV52Trn_tilewwds_3_tftrn_tilename_sel = AV12TFTrn_TileName_Sel;
         AV53Trn_tilewwds_4_tftrn_tilewidth_sels = AV37TFTrn_TileWidth_Sels;
         AV54Trn_tilewwds_5_tftrn_tilecolor_sels = AV43TFTrn_TileColor_Sels;
         AV55Trn_tilewwds_6_tftrn_tilebgimageurl = AV44TFTrn_TileBGImageUrl;
         AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel = AV45TFTrn_TileBGImageUrl_Sel;
         AV57Trn_tilewwds_8_tfproductservicename = AV38TFProductServiceName;
         AV58Trn_tilewwds_9_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV59Trn_tilewwds_10_tfproductservicedescription = AV40TFProductServiceDescription;
         AV60Trn_tilewwds_11_tfproductservicedescription_sel = AV41TFProductServiceDescription_Sel;
         AV61Trn_tilewwds_12_tfsg_topagename = AV46TFSG_ToPageName;
         AV62Trn_tilewwds_13_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A268Trn_TileWidth ,
                                              AV53Trn_tilewwds_4_tftrn_tilewidth_sels ,
                                              A270Trn_TileColor ,
                                              AV54Trn_tilewwds_5_tftrn_tilecolor_sels ,
                                              AV50Trn_tilewwds_1_filterfulltext ,
                                              AV52Trn_tilewwds_3_tftrn_tilename_sel ,
                                              AV51Trn_tilewwds_2_tftrn_tilename ,
                                              AV53Trn_tilewwds_4_tftrn_tilewidth_sels.Count ,
                                              AV54Trn_tilewwds_5_tftrn_tilecolor_sels.Count ,
                                              AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ,
                                              AV55Trn_tilewwds_6_tftrn_tilebgimageurl ,
                                              AV58Trn_tilewwds_9_tfproductservicename_sel ,
                                              AV57Trn_tilewwds_8_tfproductservicename ,
                                              AV60Trn_tilewwds_11_tfproductservicedescription_sel ,
                                              AV59Trn_tilewwds_10_tfproductservicedescription ,
                                              AV62Trn_tilewwds_13_tfsg_topagename_sel ,
                                              AV61Trn_tilewwds_12_tfsg_topagename ,
                                              A265Trn_TileName ,
                                              A271Trn_TileBGImageUrl ,
                                              A59ProductServiceName ,
                                              A60ProductServiceDescription ,
                                              A330SG_ToPageName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV51Trn_tilewwds_2_tftrn_tilename = StringUtil.Concat( StringUtil.RTrim( AV51Trn_tilewwds_2_tftrn_tilename), "%", "");
         lV55Trn_tilewwds_6_tftrn_tilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_6_tftrn_tilebgimageurl), "%", "");
         lV57Trn_tilewwds_8_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV57Trn_tilewwds_8_tfproductservicename), "%", "");
         lV59Trn_tilewwds_10_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_10_tfproductservicedescription), "%", "");
         lV61Trn_tilewwds_12_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV61Trn_tilewwds_12_tfsg_topagename), "%", "");
         /* Using cursor P00694 */
         pr_default.execute(2, new Object[] {lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV51Trn_tilewwds_2_tftrn_tilename, AV52Trn_tilewwds_3_tftrn_tilename_sel, lV55Trn_tilewwds_6_tftrn_tilebgimageurl, AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, lV57Trn_tilewwds_8_tfproductservicename, AV58Trn_tilewwds_9_tfproductservicename_sel, lV59Trn_tilewwds_10_tfproductservicedescription, AV60Trn_tilewwds_11_tfproductservicedescription_sel, lV61Trn_tilewwds_12_tfsg_topagename, AV62Trn_tilewwds_13_tfsg_topagename_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK696 = false;
            A329SG_ToPageId = P00694_A329SG_ToPageId[0];
            A58ProductServiceId = P00694_A58ProductServiceId[0];
            n58ProductServiceId = P00694_n58ProductServiceId[0];
            A330SG_ToPageName = P00694_A330SG_ToPageName[0];
            A60ProductServiceDescription = P00694_A60ProductServiceDescription[0];
            A59ProductServiceName = P00694_A59ProductServiceName[0];
            A271Trn_TileBGImageUrl = P00694_A271Trn_TileBGImageUrl[0];
            A270Trn_TileColor = P00694_A270Trn_TileColor[0];
            A268Trn_TileWidth = P00694_A268Trn_TileWidth[0];
            A265Trn_TileName = P00694_A265Trn_TileName[0];
            A264Trn_TileId = P00694_A264Trn_TileId[0];
            A330SG_ToPageName = P00694_A330SG_ToPageName[0];
            A60ProductServiceDescription = P00694_A60ProductServiceDescription[0];
            A59ProductServiceName = P00694_A59ProductServiceName[0];
            AV23count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00694_A58ProductServiceId[0] == A58ProductServiceId ) )
            {
               BRK696 = false;
               A264Trn_TileId = P00694_A264Trn_TileId[0];
               AV23count = (long)(AV23count+1);
               BRK696 = true;
               pr_default.readNext(2);
            }
            AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A59ProductServiceName)) ? "<#Empty#>" : A59ProductServiceName);
            AV17InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV18Option, "<#Empty#>") != 0 ) && ( AV17InsertIndex <= AV19Options.Count ) && ( ( StringUtil.StrCmp(((string)AV19Options.Item(AV17InsertIndex)), AV18Option) < 0 ) || ( StringUtil.StrCmp(((string)AV19Options.Item(AV17InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV17InsertIndex = (int)(AV17InsertIndex+1);
            }
            AV19Options.Add(AV18Option, AV17InsertIndex);
            AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), AV17InsertIndex);
            if ( AV19Options.Count == AV14SkipItems + 11 )
            {
               AV19Options.RemoveItem(AV19Options.Count);
               AV22OptionIndexes.RemoveItem(AV22OptionIndexes.Count);
            }
            if ( ! BRK696 )
            {
               BRK696 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV14SkipItems > 0 )
         {
            AV19Options.RemoveItem(1);
            AV22OptionIndexes.RemoveItem(1);
            AV14SkipItems = (short)(AV14SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADPRODUCTSERVICEDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV40TFProductServiceDescription = AV13SearchTxt;
         AV41TFProductServiceDescription_Sel = "";
         AV50Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV51Trn_tilewwds_2_tftrn_tilename = AV11TFTrn_TileName;
         AV52Trn_tilewwds_3_tftrn_tilename_sel = AV12TFTrn_TileName_Sel;
         AV53Trn_tilewwds_4_tftrn_tilewidth_sels = AV37TFTrn_TileWidth_Sels;
         AV54Trn_tilewwds_5_tftrn_tilecolor_sels = AV43TFTrn_TileColor_Sels;
         AV55Trn_tilewwds_6_tftrn_tilebgimageurl = AV44TFTrn_TileBGImageUrl;
         AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel = AV45TFTrn_TileBGImageUrl_Sel;
         AV57Trn_tilewwds_8_tfproductservicename = AV38TFProductServiceName;
         AV58Trn_tilewwds_9_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV59Trn_tilewwds_10_tfproductservicedescription = AV40TFProductServiceDescription;
         AV60Trn_tilewwds_11_tfproductservicedescription_sel = AV41TFProductServiceDescription_Sel;
         AV61Trn_tilewwds_12_tfsg_topagename = AV46TFSG_ToPageName;
         AV62Trn_tilewwds_13_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A268Trn_TileWidth ,
                                              AV53Trn_tilewwds_4_tftrn_tilewidth_sels ,
                                              A270Trn_TileColor ,
                                              AV54Trn_tilewwds_5_tftrn_tilecolor_sels ,
                                              AV50Trn_tilewwds_1_filterfulltext ,
                                              AV52Trn_tilewwds_3_tftrn_tilename_sel ,
                                              AV51Trn_tilewwds_2_tftrn_tilename ,
                                              AV53Trn_tilewwds_4_tftrn_tilewidth_sels.Count ,
                                              AV54Trn_tilewwds_5_tftrn_tilecolor_sels.Count ,
                                              AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ,
                                              AV55Trn_tilewwds_6_tftrn_tilebgimageurl ,
                                              AV58Trn_tilewwds_9_tfproductservicename_sel ,
                                              AV57Trn_tilewwds_8_tfproductservicename ,
                                              AV60Trn_tilewwds_11_tfproductservicedescription_sel ,
                                              AV59Trn_tilewwds_10_tfproductservicedescription ,
                                              AV62Trn_tilewwds_13_tfsg_topagename_sel ,
                                              AV61Trn_tilewwds_12_tfsg_topagename ,
                                              A265Trn_TileName ,
                                              A271Trn_TileBGImageUrl ,
                                              A59ProductServiceName ,
                                              A60ProductServiceDescription ,
                                              A330SG_ToPageName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV51Trn_tilewwds_2_tftrn_tilename = StringUtil.Concat( StringUtil.RTrim( AV51Trn_tilewwds_2_tftrn_tilename), "%", "");
         lV55Trn_tilewwds_6_tftrn_tilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_6_tftrn_tilebgimageurl), "%", "");
         lV57Trn_tilewwds_8_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV57Trn_tilewwds_8_tfproductservicename), "%", "");
         lV59Trn_tilewwds_10_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_10_tfproductservicedescription), "%", "");
         lV61Trn_tilewwds_12_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV61Trn_tilewwds_12_tfsg_topagename), "%", "");
         /* Using cursor P00695 */
         pr_default.execute(3, new Object[] {lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV51Trn_tilewwds_2_tftrn_tilename, AV52Trn_tilewwds_3_tftrn_tilename_sel, lV55Trn_tilewwds_6_tftrn_tilebgimageurl, AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, lV57Trn_tilewwds_8_tfproductservicename, AV58Trn_tilewwds_9_tfproductservicename_sel, lV59Trn_tilewwds_10_tfproductservicedescription, AV60Trn_tilewwds_11_tfproductservicedescription_sel, lV61Trn_tilewwds_12_tfsg_topagename, AV62Trn_tilewwds_13_tfsg_topagename_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK698 = false;
            A58ProductServiceId = P00695_A58ProductServiceId[0];
            n58ProductServiceId = P00695_n58ProductServiceId[0];
            A329SG_ToPageId = P00695_A329SG_ToPageId[0];
            A60ProductServiceDescription = P00695_A60ProductServiceDescription[0];
            A330SG_ToPageName = P00695_A330SG_ToPageName[0];
            A59ProductServiceName = P00695_A59ProductServiceName[0];
            A271Trn_TileBGImageUrl = P00695_A271Trn_TileBGImageUrl[0];
            A270Trn_TileColor = P00695_A270Trn_TileColor[0];
            A268Trn_TileWidth = P00695_A268Trn_TileWidth[0];
            A265Trn_TileName = P00695_A265Trn_TileName[0];
            A264Trn_TileId = P00695_A264Trn_TileId[0];
            A60ProductServiceDescription = P00695_A60ProductServiceDescription[0];
            A59ProductServiceName = P00695_A59ProductServiceName[0];
            A330SG_ToPageName = P00695_A330SG_ToPageName[0];
            AV23count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00695_A60ProductServiceDescription[0], A60ProductServiceDescription) == 0 ) )
            {
               BRK698 = false;
               A58ProductServiceId = P00695_A58ProductServiceId[0];
               n58ProductServiceId = P00695_n58ProductServiceId[0];
               A264Trn_TileId = P00695_A264Trn_TileId[0];
               AV23count = (long)(AV23count+1);
               BRK698 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A60ProductServiceDescription)) ? "<#Empty#>" : A60ProductServiceDescription);
               AV19Options.Add(AV18Option, 0);
               AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV14SkipItems = (short)(AV14SkipItems-1);
            }
            if ( ! BRK698 )
            {
               BRK698 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSG_TOPAGENAMEOPTIONS' Routine */
         returnInSub = false;
         AV46TFSG_ToPageName = AV13SearchTxt;
         AV47TFSG_ToPageName_Sel = "";
         AV50Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV51Trn_tilewwds_2_tftrn_tilename = AV11TFTrn_TileName;
         AV52Trn_tilewwds_3_tftrn_tilename_sel = AV12TFTrn_TileName_Sel;
         AV53Trn_tilewwds_4_tftrn_tilewidth_sels = AV37TFTrn_TileWidth_Sels;
         AV54Trn_tilewwds_5_tftrn_tilecolor_sels = AV43TFTrn_TileColor_Sels;
         AV55Trn_tilewwds_6_tftrn_tilebgimageurl = AV44TFTrn_TileBGImageUrl;
         AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel = AV45TFTrn_TileBGImageUrl_Sel;
         AV57Trn_tilewwds_8_tfproductservicename = AV38TFProductServiceName;
         AV58Trn_tilewwds_9_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV59Trn_tilewwds_10_tfproductservicedescription = AV40TFProductServiceDescription;
         AV60Trn_tilewwds_11_tfproductservicedescription_sel = AV41TFProductServiceDescription_Sel;
         AV61Trn_tilewwds_12_tfsg_topagename = AV46TFSG_ToPageName;
         AV62Trn_tilewwds_13_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A268Trn_TileWidth ,
                                              AV53Trn_tilewwds_4_tftrn_tilewidth_sels ,
                                              A270Trn_TileColor ,
                                              AV54Trn_tilewwds_5_tftrn_tilecolor_sels ,
                                              AV50Trn_tilewwds_1_filterfulltext ,
                                              AV52Trn_tilewwds_3_tftrn_tilename_sel ,
                                              AV51Trn_tilewwds_2_tftrn_tilename ,
                                              AV53Trn_tilewwds_4_tftrn_tilewidth_sels.Count ,
                                              AV54Trn_tilewwds_5_tftrn_tilecolor_sels.Count ,
                                              AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ,
                                              AV55Trn_tilewwds_6_tftrn_tilebgimageurl ,
                                              AV58Trn_tilewwds_9_tfproductservicename_sel ,
                                              AV57Trn_tilewwds_8_tfproductservicename ,
                                              AV60Trn_tilewwds_11_tfproductservicedescription_sel ,
                                              AV59Trn_tilewwds_10_tfproductservicedescription ,
                                              AV62Trn_tilewwds_13_tfsg_topagename_sel ,
                                              AV61Trn_tilewwds_12_tfsg_topagename ,
                                              A265Trn_TileName ,
                                              A271Trn_TileBGImageUrl ,
                                              A59ProductServiceName ,
                                              A60ProductServiceDescription ,
                                              A330SG_ToPageName } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV50Trn_tilewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext), "%", "");
         lV51Trn_tilewwds_2_tftrn_tilename = StringUtil.Concat( StringUtil.RTrim( AV51Trn_tilewwds_2_tftrn_tilename), "%", "");
         lV55Trn_tilewwds_6_tftrn_tilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV55Trn_tilewwds_6_tftrn_tilebgimageurl), "%", "");
         lV57Trn_tilewwds_8_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV57Trn_tilewwds_8_tfproductservicename), "%", "");
         lV59Trn_tilewwds_10_tfproductservicedescription = StringUtil.Concat( StringUtil.RTrim( AV59Trn_tilewwds_10_tfproductservicedescription), "%", "");
         lV61Trn_tilewwds_12_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV61Trn_tilewwds_12_tfsg_topagename), "%", "");
         /* Using cursor P00696 */
         pr_default.execute(4, new Object[] {lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV50Trn_tilewwds_1_filterfulltext, lV51Trn_tilewwds_2_tftrn_tilename, AV52Trn_tilewwds_3_tftrn_tilename_sel, lV55Trn_tilewwds_6_tftrn_tilebgimageurl, AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, lV57Trn_tilewwds_8_tfproductservicename, AV58Trn_tilewwds_9_tfproductservicename_sel, lV59Trn_tilewwds_10_tfproductservicedescription, AV60Trn_tilewwds_11_tfproductservicedescription_sel, lV61Trn_tilewwds_12_tfsg_topagename, AV62Trn_tilewwds_13_tfsg_topagename_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6910 = false;
            A58ProductServiceId = P00696_A58ProductServiceId[0];
            n58ProductServiceId = P00696_n58ProductServiceId[0];
            A329SG_ToPageId = P00696_A329SG_ToPageId[0];
            A330SG_ToPageName = P00696_A330SG_ToPageName[0];
            A60ProductServiceDescription = P00696_A60ProductServiceDescription[0];
            A59ProductServiceName = P00696_A59ProductServiceName[0];
            A271Trn_TileBGImageUrl = P00696_A271Trn_TileBGImageUrl[0];
            A270Trn_TileColor = P00696_A270Trn_TileColor[0];
            A268Trn_TileWidth = P00696_A268Trn_TileWidth[0];
            A265Trn_TileName = P00696_A265Trn_TileName[0];
            A264Trn_TileId = P00696_A264Trn_TileId[0];
            A60ProductServiceDescription = P00696_A60ProductServiceDescription[0];
            A59ProductServiceName = P00696_A59ProductServiceName[0];
            A330SG_ToPageName = P00696_A330SG_ToPageName[0];
            AV23count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( P00696_A329SG_ToPageId[0] == A329SG_ToPageId ) )
            {
               BRK6910 = false;
               A264Trn_TileId = P00696_A264Trn_TileId[0];
               AV23count = (long)(AV23count+1);
               BRK6910 = true;
               pr_default.readNext(4);
            }
            AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A330SG_ToPageName)) ? "<#Empty#>" : A330SG_ToPageName);
            AV17InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV18Option, "<#Empty#>") != 0 ) && ( AV17InsertIndex <= AV19Options.Count ) && ( ( StringUtil.StrCmp(((string)AV19Options.Item(AV17InsertIndex)), AV18Option) < 0 ) || ( StringUtil.StrCmp(((string)AV19Options.Item(AV17InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV17InsertIndex = (int)(AV17InsertIndex+1);
            }
            AV19Options.Add(AV18Option, AV17InsertIndex);
            AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), AV17InsertIndex);
            if ( AV19Options.Count == AV14SkipItems + 11 )
            {
               AV19Options.RemoveItem(AV19Options.Count);
               AV22OptionIndexes.RemoveItem(AV22OptionIndexes.Count);
            }
            if ( ! BRK6910 )
            {
               BRK6910 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
         while ( AV14SkipItems > 0 )
         {
            AV19Options.RemoveItem(1);
            AV22OptionIndexes.RemoveItem(1);
            AV14SkipItems = (short)(AV14SkipItems-1);
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
         AV32OptionsJson = "";
         AV33OptionsDescJson = "";
         AV34OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV21OptionsDesc = new GxSimpleCollection<string>();
         AV22OptionIndexes = new GxSimpleCollection<string>();
         AV13SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24Session = context.GetSession();
         AV26GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV35FilterFullText = "";
         AV11TFTrn_TileName = "";
         AV12TFTrn_TileName_Sel = "";
         AV36TFTrn_TileWidth_SelsJson = "";
         AV37TFTrn_TileWidth_Sels = new GxSimpleCollection<short>();
         AV42TFTrn_TileColor_SelsJson = "";
         AV43TFTrn_TileColor_Sels = new GxSimpleCollection<string>();
         AV44TFTrn_TileBGImageUrl = "";
         AV45TFTrn_TileBGImageUrl_Sel = "";
         AV38TFProductServiceName = "";
         AV39TFProductServiceName_Sel = "";
         AV40TFProductServiceDescription = "";
         AV41TFProductServiceDescription_Sel = "";
         AV46TFSG_ToPageName = "";
         AV47TFSG_ToPageName_Sel = "";
         AV50Trn_tilewwds_1_filterfulltext = "";
         AV51Trn_tilewwds_2_tftrn_tilename = "";
         AV52Trn_tilewwds_3_tftrn_tilename_sel = "";
         AV53Trn_tilewwds_4_tftrn_tilewidth_sels = new GxSimpleCollection<short>();
         AV54Trn_tilewwds_5_tftrn_tilecolor_sels = new GxSimpleCollection<string>();
         AV55Trn_tilewwds_6_tftrn_tilebgimageurl = "";
         AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel = "";
         AV57Trn_tilewwds_8_tfproductservicename = "";
         AV58Trn_tilewwds_9_tfproductservicename_sel = "";
         AV59Trn_tilewwds_10_tfproductservicedescription = "";
         AV60Trn_tilewwds_11_tfproductservicedescription_sel = "";
         AV61Trn_tilewwds_12_tfsg_topagename = "";
         AV62Trn_tilewwds_13_tfsg_topagename_sel = "";
         lV50Trn_tilewwds_1_filterfulltext = "";
         lV51Trn_tilewwds_2_tftrn_tilename = "";
         lV55Trn_tilewwds_6_tftrn_tilebgimageurl = "";
         lV57Trn_tilewwds_8_tfproductservicename = "";
         lV59Trn_tilewwds_10_tfproductservicedescription = "";
         lV61Trn_tilewwds_12_tfsg_topagename = "";
         A270Trn_TileColor = "";
         A265Trn_TileName = "";
         A271Trn_TileBGImageUrl = "";
         A59ProductServiceName = "";
         A60ProductServiceDescription = "";
         A330SG_ToPageName = "";
         P00692_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00692_n58ProductServiceId = new bool[] {false} ;
         P00692_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00692_A265Trn_TileName = new string[] {""} ;
         P00692_A330SG_ToPageName = new string[] {""} ;
         P00692_A60ProductServiceDescription = new string[] {""} ;
         P00692_A59ProductServiceName = new string[] {""} ;
         P00692_A271Trn_TileBGImageUrl = new string[] {""} ;
         P00692_A270Trn_TileColor = new string[] {""} ;
         P00692_A268Trn_TileWidth = new short[1] ;
         P00692_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         A329SG_ToPageId = Guid.Empty;
         A264Trn_TileId = Guid.Empty;
         AV18Option = "";
         P00693_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00693_n58ProductServiceId = new bool[] {false} ;
         P00693_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00693_A271Trn_TileBGImageUrl = new string[] {""} ;
         P00693_A330SG_ToPageName = new string[] {""} ;
         P00693_A60ProductServiceDescription = new string[] {""} ;
         P00693_A59ProductServiceName = new string[] {""} ;
         P00693_A270Trn_TileColor = new string[] {""} ;
         P00693_A268Trn_TileWidth = new short[1] ;
         P00693_A265Trn_TileName = new string[] {""} ;
         P00693_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         P00694_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00694_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00694_n58ProductServiceId = new bool[] {false} ;
         P00694_A330SG_ToPageName = new string[] {""} ;
         P00694_A60ProductServiceDescription = new string[] {""} ;
         P00694_A59ProductServiceName = new string[] {""} ;
         P00694_A271Trn_TileBGImageUrl = new string[] {""} ;
         P00694_A270Trn_TileColor = new string[] {""} ;
         P00694_A268Trn_TileWidth = new short[1] ;
         P00694_A265Trn_TileName = new string[] {""} ;
         P00694_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         P00695_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00695_n58ProductServiceId = new bool[] {false} ;
         P00695_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00695_A60ProductServiceDescription = new string[] {""} ;
         P00695_A330SG_ToPageName = new string[] {""} ;
         P00695_A59ProductServiceName = new string[] {""} ;
         P00695_A271Trn_TileBGImageUrl = new string[] {""} ;
         P00695_A270Trn_TileColor = new string[] {""} ;
         P00695_A268Trn_TileWidth = new short[1] ;
         P00695_A265Trn_TileName = new string[] {""} ;
         P00695_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         P00696_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00696_n58ProductServiceId = new bool[] {false} ;
         P00696_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00696_A330SG_ToPageName = new string[] {""} ;
         P00696_A60ProductServiceDescription = new string[] {""} ;
         P00696_A59ProductServiceName = new string[] {""} ;
         P00696_A271Trn_TileBGImageUrl = new string[] {""} ;
         P00696_A270Trn_TileColor = new string[] {""} ;
         P00696_A268Trn_TileWidth = new short[1] ;
         P00696_A265Trn_TileName = new string[] {""} ;
         P00696_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tilewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00692_A58ProductServiceId, P00692_n58ProductServiceId, P00692_A329SG_ToPageId, P00692_A265Trn_TileName, P00692_A330SG_ToPageName, P00692_A60ProductServiceDescription, P00692_A59ProductServiceName, P00692_A271Trn_TileBGImageUrl, P00692_A270Trn_TileColor, P00692_A268Trn_TileWidth,
               P00692_A264Trn_TileId
               }
               , new Object[] {
               P00693_A58ProductServiceId, P00693_n58ProductServiceId, P00693_A329SG_ToPageId, P00693_A271Trn_TileBGImageUrl, P00693_A330SG_ToPageName, P00693_A60ProductServiceDescription, P00693_A59ProductServiceName, P00693_A270Trn_TileColor, P00693_A268Trn_TileWidth, P00693_A265Trn_TileName,
               P00693_A264Trn_TileId
               }
               , new Object[] {
               P00694_A329SG_ToPageId, P00694_A58ProductServiceId, P00694_n58ProductServiceId, P00694_A330SG_ToPageName, P00694_A60ProductServiceDescription, P00694_A59ProductServiceName, P00694_A271Trn_TileBGImageUrl, P00694_A270Trn_TileColor, P00694_A268Trn_TileWidth, P00694_A265Trn_TileName,
               P00694_A264Trn_TileId
               }
               , new Object[] {
               P00695_A58ProductServiceId, P00695_n58ProductServiceId, P00695_A329SG_ToPageId, P00695_A60ProductServiceDescription, P00695_A330SG_ToPageName, P00695_A59ProductServiceName, P00695_A271Trn_TileBGImageUrl, P00695_A270Trn_TileColor, P00695_A268Trn_TileWidth, P00695_A265Trn_TileName,
               P00695_A264Trn_TileId
               }
               , new Object[] {
               P00696_A58ProductServiceId, P00696_n58ProductServiceId, P00696_A329SG_ToPageId, P00696_A330SG_ToPageName, P00696_A60ProductServiceDescription, P00696_A59ProductServiceName, P00696_A271Trn_TileBGImageUrl, P00696_A270Trn_TileColor, P00696_A268Trn_TileWidth, P00696_A265Trn_TileName,
               P00696_A264Trn_TileId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short A268Trn_TileWidth ;
      private int AV48GXV1 ;
      private int AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count ;
      private int AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count ;
      private int AV17InsertIndex ;
      private long AV23count ;
      private string A270Trn_TileColor ;
      private bool returnInSub ;
      private bool BRK692 ;
      private bool n58ProductServiceId ;
      private bool BRK694 ;
      private bool BRK696 ;
      private bool BRK698 ;
      private bool BRK6910 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV36TFTrn_TileWidth_SelsJson ;
      private string AV42TFTrn_TileColor_SelsJson ;
      private string AV40TFProductServiceDescription ;
      private string AV41TFProductServiceDescription_Sel ;
      private string AV59Trn_tilewwds_10_tfproductservicedescription ;
      private string AV60Trn_tilewwds_11_tfproductservicedescription_sel ;
      private string lV59Trn_tilewwds_10_tfproductservicedescription ;
      private string A60ProductServiceDescription ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV11TFTrn_TileName ;
      private string AV12TFTrn_TileName_Sel ;
      private string AV44TFTrn_TileBGImageUrl ;
      private string AV45TFTrn_TileBGImageUrl_Sel ;
      private string AV38TFProductServiceName ;
      private string AV39TFProductServiceName_Sel ;
      private string AV46TFSG_ToPageName ;
      private string AV47TFSG_ToPageName_Sel ;
      private string AV50Trn_tilewwds_1_filterfulltext ;
      private string AV51Trn_tilewwds_2_tftrn_tilename ;
      private string AV52Trn_tilewwds_3_tftrn_tilename_sel ;
      private string AV55Trn_tilewwds_6_tftrn_tilebgimageurl ;
      private string AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ;
      private string AV57Trn_tilewwds_8_tfproductservicename ;
      private string AV58Trn_tilewwds_9_tfproductservicename_sel ;
      private string AV61Trn_tilewwds_12_tfsg_topagename ;
      private string AV62Trn_tilewwds_13_tfsg_topagename_sel ;
      private string lV50Trn_tilewwds_1_filterfulltext ;
      private string lV51Trn_tilewwds_2_tftrn_tilename ;
      private string lV55Trn_tilewwds_6_tftrn_tilebgimageurl ;
      private string lV57Trn_tilewwds_8_tfproductservicename ;
      private string lV61Trn_tilewwds_12_tfsg_topagename ;
      private string A265Trn_TileName ;
      private string A271Trn_TileBGImageUrl ;
      private string A59ProductServiceName ;
      private string A330SG_ToPageName ;
      private string AV18Option ;
      private Guid A58ProductServiceId ;
      private Guid A329SG_ToPageId ;
      private Guid A264Trn_TileId ;
      private IGxSession AV24Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV21OptionsDesc ;
      private GxSimpleCollection<string> AV22OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV26GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private GxSimpleCollection<short> AV37TFTrn_TileWidth_Sels ;
      private GxSimpleCollection<string> AV43TFTrn_TileColor_Sels ;
      private GxSimpleCollection<short> AV53Trn_tilewwds_4_tftrn_tilewidth_sels ;
      private GxSimpleCollection<string> AV54Trn_tilewwds_5_tftrn_tilecolor_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00692_A58ProductServiceId ;
      private bool[] P00692_n58ProductServiceId ;
      private Guid[] P00692_A329SG_ToPageId ;
      private string[] P00692_A265Trn_TileName ;
      private string[] P00692_A330SG_ToPageName ;
      private string[] P00692_A60ProductServiceDescription ;
      private string[] P00692_A59ProductServiceName ;
      private string[] P00692_A271Trn_TileBGImageUrl ;
      private string[] P00692_A270Trn_TileColor ;
      private short[] P00692_A268Trn_TileWidth ;
      private Guid[] P00692_A264Trn_TileId ;
      private Guid[] P00693_A58ProductServiceId ;
      private bool[] P00693_n58ProductServiceId ;
      private Guid[] P00693_A329SG_ToPageId ;
      private string[] P00693_A271Trn_TileBGImageUrl ;
      private string[] P00693_A330SG_ToPageName ;
      private string[] P00693_A60ProductServiceDescription ;
      private string[] P00693_A59ProductServiceName ;
      private string[] P00693_A270Trn_TileColor ;
      private short[] P00693_A268Trn_TileWidth ;
      private string[] P00693_A265Trn_TileName ;
      private Guid[] P00693_A264Trn_TileId ;
      private Guid[] P00694_A329SG_ToPageId ;
      private Guid[] P00694_A58ProductServiceId ;
      private bool[] P00694_n58ProductServiceId ;
      private string[] P00694_A330SG_ToPageName ;
      private string[] P00694_A60ProductServiceDescription ;
      private string[] P00694_A59ProductServiceName ;
      private string[] P00694_A271Trn_TileBGImageUrl ;
      private string[] P00694_A270Trn_TileColor ;
      private short[] P00694_A268Trn_TileWidth ;
      private string[] P00694_A265Trn_TileName ;
      private Guid[] P00694_A264Trn_TileId ;
      private Guid[] P00695_A58ProductServiceId ;
      private bool[] P00695_n58ProductServiceId ;
      private Guid[] P00695_A329SG_ToPageId ;
      private string[] P00695_A60ProductServiceDescription ;
      private string[] P00695_A330SG_ToPageName ;
      private string[] P00695_A59ProductServiceName ;
      private string[] P00695_A271Trn_TileBGImageUrl ;
      private string[] P00695_A270Trn_TileColor ;
      private short[] P00695_A268Trn_TileWidth ;
      private string[] P00695_A265Trn_TileName ;
      private Guid[] P00695_A264Trn_TileId ;
      private Guid[] P00696_A58ProductServiceId ;
      private bool[] P00696_n58ProductServiceId ;
      private Guid[] P00696_A329SG_ToPageId ;
      private string[] P00696_A330SG_ToPageName ;
      private string[] P00696_A60ProductServiceDescription ;
      private string[] P00696_A59ProductServiceName ;
      private string[] P00696_A271Trn_TileBGImageUrl ;
      private string[] P00696_A270Trn_TileColor ;
      private short[] P00696_A268Trn_TileWidth ;
      private string[] P00696_A265Trn_TileName ;
      private Guid[] P00696_A264Trn_TileId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_tilewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00692( IGxContext context ,
                                             short A268Trn_TileWidth ,
                                             GxSimpleCollection<short> AV53Trn_tilewwds_4_tftrn_tilewidth_sels ,
                                             string A270Trn_TileColor ,
                                             GxSimpleCollection<string> AV54Trn_tilewwds_5_tftrn_tilecolor_sels ,
                                             string AV50Trn_tilewwds_1_filterfulltext ,
                                             string AV52Trn_tilewwds_3_tftrn_tilename_sel ,
                                             string AV51Trn_tilewwds_2_tftrn_tilename ,
                                             int AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count ,
                                             int AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count ,
                                             string AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ,
                                             string AV55Trn_tilewwds_6_tftrn_tilebgimageurl ,
                                             string AV58Trn_tilewwds_9_tfproductservicename_sel ,
                                             string AV57Trn_tilewwds_8_tfproductservicename ,
                                             string AV60Trn_tilewwds_11_tfproductservicedescription_sel ,
                                             string AV59Trn_tilewwds_10_tfproductservicedescription ,
                                             string AV62Trn_tilewwds_13_tfsg_topagename_sel ,
                                             string AV61Trn_tilewwds_12_tfsg_topagename ,
                                             string A265Trn_TileName ,
                                             string A271Trn_TileBGImageUrl ,
                                             string A59ProductServiceName ,
                                             string A60ProductServiceDescription ,
                                             string A330SG_ToPageName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[19];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceId, T1.SG_ToPageId AS SG_ToPageId, T1.Trn_TileName, T3.Trn_PageName AS SG_ToPageName, T2.ProductServiceDescription, T2.ProductServiceName, T1.Trn_TileBGImageUrl, T1.Trn_TileColor, T1.Trn_TileWidth, T1.Trn_TileId FROM ((Trn_Col T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T1.SG_ToPageId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.Trn_TileName like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( 'small' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 1) or ( 'medium' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 2) or ( 'large' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 3) or ( T1.Trn_TileColor like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T1.Trn_TileBGImageUrl like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T2.ProductServiceName like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T2.ProductServiceDescription like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T3.Trn_PageName like '%' || :lV50Trn_tilewwds_1_filterfulltext))");
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
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_tilewwds_3_tftrn_tilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_tilewwds_2_tftrn_tilename)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileName like :lV51Trn_tilewwds_2_tftrn_tilename)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_tilewwds_3_tftrn_tilename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_tilewwds_3_tftrn_tilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileName = ( :AV52Trn_tilewwds_3_tftrn_tilename_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_tilewwds_3_tftrn_tilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_TileName))=0))");
         }
         if ( AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV53Trn_tilewwds_4_tftrn_tilewidth_sels, "T1.Trn_TileWidth IN (", ")")+")");
         }
         if ( AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54Trn_tilewwds_5_tftrn_tilecolor_sels, "T1.Trn_TileColor IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_6_tftrn_tilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileBGImageUrl like :lV55Trn_tilewwds_6_tftrn_tilebgimageurl)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileBGImageUrl = ( :AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_9_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_8_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName like :lV57Trn_tilewwds_8_tfproductservicename)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_9_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_9_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName = ( :AV58Trn_tilewwds_9_tfproductservicename_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_9_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_11_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_10_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription like :lV59Trn_tilewwds_10_tfproductservicedescription)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_11_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_11_tfproductservicedescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription = ( :AV60Trn_tilewwds_11_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_11_tfproductservicedescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_13_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_12_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName like :lV61Trn_tilewwds_12_tfsg_topagename)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_13_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_13_tfsg_topagename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName = ( :AV62Trn_tilewwds_13_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_13_tfsg_topagename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.Trn_TileName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00693( IGxContext context ,
                                             short A268Trn_TileWidth ,
                                             GxSimpleCollection<short> AV53Trn_tilewwds_4_tftrn_tilewidth_sels ,
                                             string A270Trn_TileColor ,
                                             GxSimpleCollection<string> AV54Trn_tilewwds_5_tftrn_tilecolor_sels ,
                                             string AV50Trn_tilewwds_1_filterfulltext ,
                                             string AV52Trn_tilewwds_3_tftrn_tilename_sel ,
                                             string AV51Trn_tilewwds_2_tftrn_tilename ,
                                             int AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count ,
                                             int AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count ,
                                             string AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ,
                                             string AV55Trn_tilewwds_6_tftrn_tilebgimageurl ,
                                             string AV58Trn_tilewwds_9_tfproductservicename_sel ,
                                             string AV57Trn_tilewwds_8_tfproductservicename ,
                                             string AV60Trn_tilewwds_11_tfproductservicedescription_sel ,
                                             string AV59Trn_tilewwds_10_tfproductservicedescription ,
                                             string AV62Trn_tilewwds_13_tfsg_topagename_sel ,
                                             string AV61Trn_tilewwds_12_tfsg_topagename ,
                                             string A265Trn_TileName ,
                                             string A271Trn_TileBGImageUrl ,
                                             string A59ProductServiceName ,
                                             string A60ProductServiceDescription ,
                                             string A330SG_ToPageName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[19];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceId, T1.SG_ToPageId AS SG_ToPageId, T1.Trn_TileBGImageUrl, T3.Trn_PageName AS SG_ToPageName, T2.ProductServiceDescription, T2.ProductServiceName, T1.Trn_TileColor, T1.Trn_TileWidth, T1.Trn_TileName, T1.Trn_TileId FROM ((Trn_Col T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T1.SG_ToPageId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.Trn_TileName like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( 'small' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 1) or ( 'medium' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 2) or ( 'large' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 3) or ( T1.Trn_TileColor like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T1.Trn_TileBGImageUrl like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T2.ProductServiceName like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T2.ProductServiceDescription like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T3.Trn_PageName like '%' || :lV50Trn_tilewwds_1_filterfulltext))");
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
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_tilewwds_3_tftrn_tilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_tilewwds_2_tftrn_tilename)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileName like :lV51Trn_tilewwds_2_tftrn_tilename)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_tilewwds_3_tftrn_tilename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_tilewwds_3_tftrn_tilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileName = ( :AV52Trn_tilewwds_3_tftrn_tilename_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_tilewwds_3_tftrn_tilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_TileName))=0))");
         }
         if ( AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV53Trn_tilewwds_4_tftrn_tilewidth_sels, "T1.Trn_TileWidth IN (", ")")+")");
         }
         if ( AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54Trn_tilewwds_5_tftrn_tilecolor_sels, "T1.Trn_TileColor IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_6_tftrn_tilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileBGImageUrl like :lV55Trn_tilewwds_6_tftrn_tilebgimageurl)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileBGImageUrl = ( :AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_9_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_8_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName like :lV57Trn_tilewwds_8_tfproductservicename)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_9_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_9_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName = ( :AV58Trn_tilewwds_9_tfproductservicename_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_9_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_11_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_10_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription like :lV59Trn_tilewwds_10_tfproductservicedescription)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_11_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_11_tfproductservicedescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription = ( :AV60Trn_tilewwds_11_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_11_tfproductservicedescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_13_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_12_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName like :lV61Trn_tilewwds_12_tfsg_topagename)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_13_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_13_tfsg_topagename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName = ( :AV62Trn_tilewwds_13_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_13_tfsg_topagename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.Trn_TileBGImageUrl";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00694( IGxContext context ,
                                             short A268Trn_TileWidth ,
                                             GxSimpleCollection<short> AV53Trn_tilewwds_4_tftrn_tilewidth_sels ,
                                             string A270Trn_TileColor ,
                                             GxSimpleCollection<string> AV54Trn_tilewwds_5_tftrn_tilecolor_sels ,
                                             string AV50Trn_tilewwds_1_filterfulltext ,
                                             string AV52Trn_tilewwds_3_tftrn_tilename_sel ,
                                             string AV51Trn_tilewwds_2_tftrn_tilename ,
                                             int AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count ,
                                             int AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count ,
                                             string AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ,
                                             string AV55Trn_tilewwds_6_tftrn_tilebgimageurl ,
                                             string AV58Trn_tilewwds_9_tfproductservicename_sel ,
                                             string AV57Trn_tilewwds_8_tfproductservicename ,
                                             string AV60Trn_tilewwds_11_tfproductservicedescription_sel ,
                                             string AV59Trn_tilewwds_10_tfproductservicedescription ,
                                             string AV62Trn_tilewwds_13_tfsg_topagename_sel ,
                                             string AV61Trn_tilewwds_12_tfsg_topagename ,
                                             string A265Trn_TileName ,
                                             string A271Trn_TileBGImageUrl ,
                                             string A59ProductServiceName ,
                                             string A60ProductServiceDescription ,
                                             string A330SG_ToPageName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[19];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SG_ToPageId AS SG_ToPageId, T1.ProductServiceId, T2.Trn_PageName AS SG_ToPageName, T3.ProductServiceDescription, T3.ProductServiceName, T1.Trn_TileBGImageUrl, T1.Trn_TileColor, T1.Trn_TileWidth, T1.Trn_TileName, T1.Trn_TileId FROM ((Trn_Col T1 INNER JOIN Trn_Page T2 ON T2.Trn_PageId = T1.SG_ToPageId) LEFT JOIN Trn_ProductService T3 ON T3.ProductServiceId = T1.ProductServiceId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.Trn_TileName like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( 'small' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 1) or ( 'medium' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 2) or ( 'large' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 3) or ( T1.Trn_TileColor like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T1.Trn_TileBGImageUrl like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T3.ProductServiceName like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T3.ProductServiceDescription like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T2.Trn_PageName like '%' || :lV50Trn_tilewwds_1_filterfulltext))");
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
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_tilewwds_3_tftrn_tilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_tilewwds_2_tftrn_tilename)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileName like :lV51Trn_tilewwds_2_tftrn_tilename)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_tilewwds_3_tftrn_tilename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_tilewwds_3_tftrn_tilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileName = ( :AV52Trn_tilewwds_3_tftrn_tilename_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_tilewwds_3_tftrn_tilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_TileName))=0))");
         }
         if ( AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV53Trn_tilewwds_4_tftrn_tilewidth_sels, "T1.Trn_TileWidth IN (", ")")+")");
         }
         if ( AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54Trn_tilewwds_5_tftrn_tilecolor_sels, "T1.Trn_TileColor IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_6_tftrn_tilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileBGImageUrl like :lV55Trn_tilewwds_6_tftrn_tilebgimageurl)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileBGImageUrl = ( :AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_9_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_8_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName like :lV57Trn_tilewwds_8_tfproductservicename)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_9_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_9_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName = ( :AV58Trn_tilewwds_9_tfproductservicename_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_9_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T3.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_11_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_10_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(T3.ProductServiceDescription like :lV59Trn_tilewwds_10_tfproductservicedescription)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_11_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_11_tfproductservicedescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProductServiceDescription = ( :AV60Trn_tilewwds_11_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_11_tfproductservicedescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ProductServiceDescription IS NULL or (char_length(trim(trailing ' ' from T3.ProductServiceDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_13_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_12_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T2.Trn_PageName like :lV61Trn_tilewwds_12_tfsg_topagename)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_13_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_13_tfsg_topagename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.Trn_PageName = ( :AV62Trn_tilewwds_13_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_13_tfsg_topagename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProductServiceId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00695( IGxContext context ,
                                             short A268Trn_TileWidth ,
                                             GxSimpleCollection<short> AV53Trn_tilewwds_4_tftrn_tilewidth_sels ,
                                             string A270Trn_TileColor ,
                                             GxSimpleCollection<string> AV54Trn_tilewwds_5_tftrn_tilecolor_sels ,
                                             string AV50Trn_tilewwds_1_filterfulltext ,
                                             string AV52Trn_tilewwds_3_tftrn_tilename_sel ,
                                             string AV51Trn_tilewwds_2_tftrn_tilename ,
                                             int AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count ,
                                             int AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count ,
                                             string AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ,
                                             string AV55Trn_tilewwds_6_tftrn_tilebgimageurl ,
                                             string AV58Trn_tilewwds_9_tfproductservicename_sel ,
                                             string AV57Trn_tilewwds_8_tfproductservicename ,
                                             string AV60Trn_tilewwds_11_tfproductservicedescription_sel ,
                                             string AV59Trn_tilewwds_10_tfproductservicedescription ,
                                             string AV62Trn_tilewwds_13_tfsg_topagename_sel ,
                                             string AV61Trn_tilewwds_12_tfsg_topagename ,
                                             string A265Trn_TileName ,
                                             string A271Trn_TileBGImageUrl ,
                                             string A59ProductServiceName ,
                                             string A60ProductServiceDescription ,
                                             string A330SG_ToPageName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[19];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceId, T1.SG_ToPageId AS SG_ToPageId, T2.ProductServiceDescription, T3.Trn_PageName AS SG_ToPageName, T2.ProductServiceName, T1.Trn_TileBGImageUrl, T1.Trn_TileColor, T1.Trn_TileWidth, T1.Trn_TileName, T1.Trn_TileId FROM ((Trn_Col T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T1.SG_ToPageId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.Trn_TileName like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( 'small' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 1) or ( 'medium' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 2) or ( 'large' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 3) or ( T1.Trn_TileColor like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T1.Trn_TileBGImageUrl like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T2.ProductServiceName like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T2.ProductServiceDescription like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T3.Trn_PageName like '%' || :lV50Trn_tilewwds_1_filterfulltext))");
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
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_tilewwds_3_tftrn_tilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_tilewwds_2_tftrn_tilename)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileName like :lV51Trn_tilewwds_2_tftrn_tilename)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_tilewwds_3_tftrn_tilename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_tilewwds_3_tftrn_tilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileName = ( :AV52Trn_tilewwds_3_tftrn_tilename_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_tilewwds_3_tftrn_tilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_TileName))=0))");
         }
         if ( AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV53Trn_tilewwds_4_tftrn_tilewidth_sels, "T1.Trn_TileWidth IN (", ")")+")");
         }
         if ( AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54Trn_tilewwds_5_tftrn_tilecolor_sels, "T1.Trn_TileColor IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_6_tftrn_tilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileBGImageUrl like :lV55Trn_tilewwds_6_tftrn_tilebgimageurl)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileBGImageUrl = ( :AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_9_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_8_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName like :lV57Trn_tilewwds_8_tfproductservicename)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_9_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_9_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName = ( :AV58Trn_tilewwds_9_tfproductservicename_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_9_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_11_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_10_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription like :lV59Trn_tilewwds_10_tfproductservicedescription)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_11_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_11_tfproductservicedescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription = ( :AV60Trn_tilewwds_11_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_11_tfproductservicedescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_13_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_12_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName like :lV61Trn_tilewwds_12_tfsg_topagename)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_13_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_13_tfsg_topagename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName = ( :AV62Trn_tilewwds_13_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_13_tfsg_topagename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.ProductServiceDescription";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00696( IGxContext context ,
                                             short A268Trn_TileWidth ,
                                             GxSimpleCollection<short> AV53Trn_tilewwds_4_tftrn_tilewidth_sels ,
                                             string A270Trn_TileColor ,
                                             GxSimpleCollection<string> AV54Trn_tilewwds_5_tftrn_tilecolor_sels ,
                                             string AV50Trn_tilewwds_1_filterfulltext ,
                                             string AV52Trn_tilewwds_3_tftrn_tilename_sel ,
                                             string AV51Trn_tilewwds_2_tftrn_tilename ,
                                             int AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count ,
                                             int AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count ,
                                             string AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel ,
                                             string AV55Trn_tilewwds_6_tftrn_tilebgimageurl ,
                                             string AV58Trn_tilewwds_9_tfproductservicename_sel ,
                                             string AV57Trn_tilewwds_8_tfproductservicename ,
                                             string AV60Trn_tilewwds_11_tfproductservicedescription_sel ,
                                             string AV59Trn_tilewwds_10_tfproductservicedescription ,
                                             string AV62Trn_tilewwds_13_tfsg_topagename_sel ,
                                             string AV61Trn_tilewwds_12_tfsg_topagename ,
                                             string A265Trn_TileName ,
                                             string A271Trn_TileBGImageUrl ,
                                             string A59ProductServiceName ,
                                             string A60ProductServiceDescription ,
                                             string A330SG_ToPageName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[19];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceId, T1.SG_ToPageId AS SG_ToPageId, T3.Trn_PageName AS SG_ToPageName, T2.ProductServiceDescription, T2.ProductServiceName, T1.Trn_TileBGImageUrl, T1.Trn_TileColor, T1.Trn_TileWidth, T1.Trn_TileName, T1.Trn_TileId FROM ((Trn_Col T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T1.SG_ToPageId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Trn_tilewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.Trn_TileName like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( 'small' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 1) or ( 'medium' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 2) or ( 'large' like '%' || LOWER(:lV50Trn_tilewwds_1_filterfulltext) and T1.Trn_TileWidth = 3) or ( T1.Trn_TileColor like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T1.Trn_TileBGImageUrl like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T2.ProductServiceName like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T2.ProductServiceDescription like '%' || :lV50Trn_tilewwds_1_filterfulltext) or ( T3.Trn_PageName like '%' || :lV50Trn_tilewwds_1_filterfulltext))");
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
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_tilewwds_3_tftrn_tilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Trn_tilewwds_2_tftrn_tilename)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileName like :lV51Trn_tilewwds_2_tftrn_tilename)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Trn_tilewwds_3_tftrn_tilename_sel)) && ! ( StringUtil.StrCmp(AV52Trn_tilewwds_3_tftrn_tilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileName = ( :AV52Trn_tilewwds_3_tftrn_tilename_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Trn_tilewwds_3_tftrn_tilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_TileName))=0))");
         }
         if ( AV53Trn_tilewwds_4_tftrn_tilewidth_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV53Trn_tilewwds_4_tftrn_tilewidth_sels, "T1.Trn_TileWidth IN (", ")")+")");
         }
         if ( AV54Trn_tilewwds_5_tftrn_tilecolor_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54Trn_tilewwds_5_tftrn_tilecolor_sels, "T1.Trn_TileColor IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Trn_tilewwds_6_tftrn_tilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileBGImageUrl like :lV55Trn_tilewwds_6_tftrn_tilebgimageurl)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.Trn_TileBGImageUrl = ( :AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.Trn_TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_9_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_tilewwds_8_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName like :lV57Trn_tilewwds_8_tfproductservicename)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_tilewwds_9_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV58Trn_tilewwds_9_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName = ( :AV58Trn_tilewwds_9_tfproductservicename_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV58Trn_tilewwds_9_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_11_tfproductservicedescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_tilewwds_10_tfproductservicedescription)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription like :lV59Trn_tilewwds_10_tfproductservicedescription)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_tilewwds_11_tfproductservicedescription_sel)) && ! ( StringUtil.StrCmp(AV60Trn_tilewwds_11_tfproductservicedescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription = ( :AV60Trn_tilewwds_11_tfproductservicedescription_sel))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV60Trn_tilewwds_11_tfproductservicedescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceDescription IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_13_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_tilewwds_12_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName like :lV61Trn_tilewwds_12_tfsg_topagename)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_tilewwds_13_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV62Trn_tilewwds_13_tfsg_topagename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName = ( :AV62Trn_tilewwds_13_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV62Trn_tilewwds_13_tfsg_topagename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SG_ToPageId";
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
                     return conditional_P00692(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 1 :
                     return conditional_P00693(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 2 :
                     return conditional_P00694(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 3 :
                     return conditional_P00695(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 4 :
                     return conditional_P00696(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
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
          Object[] prmP00692;
          prmP00692 = new Object[] {
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_tilewwds_2_tftrn_tilename",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_tilewwds_3_tftrn_tilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_tilewwds_6_tftrn_tilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV57Trn_tilewwds_8_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_tilewwds_9_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_tilewwds_10_tfproductservicedescription",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV60Trn_tilewwds_11_tfproductservicedescription_sel",GXType.LongVarChar,2097152,0) ,
          new ParDef("lV61Trn_tilewwds_12_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_tilewwds_13_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00693;
          prmP00693 = new Object[] {
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_tilewwds_2_tftrn_tilename",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_tilewwds_3_tftrn_tilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_tilewwds_6_tftrn_tilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV57Trn_tilewwds_8_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_tilewwds_9_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_tilewwds_10_tfproductservicedescription",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV60Trn_tilewwds_11_tfproductservicedescription_sel",GXType.LongVarChar,2097152,0) ,
          new ParDef("lV61Trn_tilewwds_12_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_tilewwds_13_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00694;
          prmP00694 = new Object[] {
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_tilewwds_2_tftrn_tilename",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_tilewwds_3_tftrn_tilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_tilewwds_6_tftrn_tilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV57Trn_tilewwds_8_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_tilewwds_9_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_tilewwds_10_tfproductservicedescription",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV60Trn_tilewwds_11_tfproductservicedescription_sel",GXType.LongVarChar,2097152,0) ,
          new ParDef("lV61Trn_tilewwds_12_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_tilewwds_13_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00695;
          prmP00695 = new Object[] {
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_tilewwds_2_tftrn_tilename",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_tilewwds_3_tftrn_tilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_tilewwds_6_tftrn_tilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV57Trn_tilewwds_8_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_tilewwds_9_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_tilewwds_10_tfproductservicedescription",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV60Trn_tilewwds_11_tfproductservicedescription_sel",GXType.LongVarChar,2097152,0) ,
          new ParDef("lV61Trn_tilewwds_12_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_tilewwds_13_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00696;
          prmP00696 = new Object[] {
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Trn_tilewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV51Trn_tilewwds_2_tftrn_tilename",GXType.VarChar,100,0) ,
          new ParDef("AV52Trn_tilewwds_3_tftrn_tilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV55Trn_tilewwds_6_tftrn_tilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV56Trn_tilewwds_7_tftrn_tilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV57Trn_tilewwds_8_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV58Trn_tilewwds_9_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV59Trn_tilewwds_10_tfproductservicedescription",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV60Trn_tilewwds_11_tfproductservicedescription_sel",GXType.LongVarChar,2097152,0) ,
          new ParDef("lV61Trn_tilewwds_12_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV62Trn_tilewwds_13_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00692", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00692,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00693", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00693,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00694", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00694,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00695", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00695,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00696", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00696,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                return;
       }
    }

 }

}
