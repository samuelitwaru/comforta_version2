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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TILENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTILENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TILEICON") == 0 )
         {
            /* Execute user subroutine: 'LOADTILEICONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TILEBGCOLOR") == 0 )
         {
            /* Execute user subroutine: 'LOADTILEBGCOLOROPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TILEBGIMAGEURL") == 0 )
         {
            /* Execute user subroutine: 'LOADTILEBGIMAGEURLOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TILETEXTCOLOR") == 0 )
         {
            /* Execute user subroutine: 'LOADTILETEXTCOLOROPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PRODUCTSERVICENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODUCTSERVICENAMEOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_SG_TOPAGENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSG_TOPAGENAMEOPTIONS' */
            S181 ();
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
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV64GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILENAME") == 0 )
            {
               AV50TFTileName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILENAME_SEL") == 0 )
            {
               AV51TFTileName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILEICON") == 0 )
            {
               AV52TFTileIcon = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILEICON_SEL") == 0 )
            {
               AV53TFTileIcon_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILEBGCOLOR") == 0 )
            {
               AV54TFTileBGColor = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILEBGCOLOR_SEL") == 0 )
            {
               AV55TFTileBGColor_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILEBGIMAGEURL") == 0 )
            {
               AV56TFTileBGImageUrl = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILEBGIMAGEURL_SEL") == 0 )
            {
               AV57TFTileBGImageUrl_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILETEXTCOLOR") == 0 )
            {
               AV58TFTileTextColor = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILETEXTCOLOR_SEL") == 0 )
            {
               AV59TFTileTextColor_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILETEXTALIGNMENT_SEL") == 0 )
            {
               AV60TFTileTextAlignment_SelsJson = AV27GridStateFilterValue.gxTpr_Value;
               AV61TFTileTextAlignment_Sels.FromJSonString(AV60TFTileTextAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTILEICONALIGNMENT_SEL") == 0 )
            {
               AV62TFTileIconAlignment_SelsJson = AV27GridStateFilterValue.gxTpr_Value;
               AV63TFTileIconAlignment_Sels.FromJSonString(AV62TFTileIconAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME") == 0 )
            {
               AV38TFProductServiceName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME_SEL") == 0 )
            {
               AV39TFProductServiceName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSG_TOPAGENAME") == 0 )
            {
               AV46TFSG_ToPageName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSG_TOPAGENAME_SEL") == 0 )
            {
               AV47TFSG_ToPageName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            AV64GXV1 = (int)(AV64GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTILENAMEOPTIONS' Routine */
         returnInSub = false;
         AV50TFTileName = AV13SearchTxt;
         AV51TFTileName_Sel = "";
         AV66Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV67Trn_tilewwds_2_tftilename = AV50TFTileName;
         AV68Trn_tilewwds_3_tftilename_sel = AV51TFTileName_Sel;
         AV69Trn_tilewwds_4_tftileicon = AV52TFTileIcon;
         AV70Trn_tilewwds_5_tftileicon_sel = AV53TFTileIcon_Sel;
         AV71Trn_tilewwds_6_tftilebgcolor = AV54TFTileBGColor;
         AV72Trn_tilewwds_7_tftilebgcolor_sel = AV55TFTileBGColor_Sel;
         AV73Trn_tilewwds_8_tftilebgimageurl = AV56TFTileBGImageUrl;
         AV74Trn_tilewwds_9_tftilebgimageurl_sel = AV57TFTileBGImageUrl_Sel;
         AV75Trn_tilewwds_10_tftiletextcolor = AV58TFTileTextColor;
         AV76Trn_tilewwds_11_tftiletextcolor_sel = AV59TFTileTextColor_Sel;
         AV77Trn_tilewwds_12_tftiletextalignment_sels = AV61TFTileTextAlignment_Sels;
         AV78Trn_tilewwds_13_tftileiconalignment_sels = AV63TFTileIconAlignment_Sels;
         AV79Trn_tilewwds_14_tfproductservicename = AV38TFProductServiceName;
         AV80Trn_tilewwds_15_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV81Trn_tilewwds_16_tfsg_topagename = AV46TFSG_ToPageName;
         AV82Trn_tilewwds_17_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV68Trn_tilewwds_3_tftilename_sel ,
                                              AV67Trn_tilewwds_2_tftilename ,
                                              AV70Trn_tilewwds_5_tftileicon_sel ,
                                              AV69Trn_tilewwds_4_tftileicon ,
                                              AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                              AV71Trn_tilewwds_6_tftilebgcolor ,
                                              AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                              AV73Trn_tilewwds_8_tftilebgimageurl ,
                                              AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                              AV75Trn_tilewwds_10_tftiletextcolor ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels.Count ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                              AV79Trn_tilewwds_14_tfproductservicename ,
                                              AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                              AV81Trn_tilewwds_16_tfsg_topagename ,
                                              A400TileName ,
                                              A401TileIcon ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A59ProductServiceName ,
                                              A330SG_ToPageName ,
                                              AV66Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV67Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename), "%", "");
         lV69Trn_tilewwds_4_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon), 20, "%");
         lV71Trn_tilewwds_6_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor), 20, "%");
         lV73Trn_tilewwds_8_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl), "%", "");
         lV75Trn_tilewwds_10_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor), 20, "%");
         lV79Trn_tilewwds_14_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename), "%", "");
         lV81Trn_tilewwds_16_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename), "%", "");
         /* Using cursor P00692 */
         pr_default.execute(0, new Object[] {lV67Trn_tilewwds_2_tftilename, AV68Trn_tilewwds_3_tftilename_sel, lV69Trn_tilewwds_4_tftileicon, AV70Trn_tilewwds_5_tftileicon_sel, lV71Trn_tilewwds_6_tftilebgcolor, AV72Trn_tilewwds_7_tftilebgcolor_sel, lV73Trn_tilewwds_8_tftilebgimageurl, AV74Trn_tilewwds_9_tftilebgimageurl_sel, lV75Trn_tilewwds_10_tftiletextcolor, AV76Trn_tilewwds_11_tftiletextcolor_sel, lV79Trn_tilewwds_14_tfproductservicename, AV80Trn_tilewwds_15_tfproductservicename_sel, lV81Trn_tilewwds_16_tfsg_topagename, AV82Trn_tilewwds_17_tfsg_topagename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK692 = false;
            A58ProductServiceId = P00692_A58ProductServiceId[0];
            n58ProductServiceId = P00692_n58ProductServiceId[0];
            A29LocationId = P00692_A29LocationId[0];
            n29LocationId = P00692_n29LocationId[0];
            A11OrganisationId = P00692_A11OrganisationId[0];
            n11OrganisationId = P00692_n11OrganisationId[0];
            A329SG_ToPageId = P00692_A329SG_ToPageId[0];
            A400TileName = P00692_A400TileName[0];
            A330SG_ToPageName = P00692_A330SG_ToPageName[0];
            A59ProductServiceName = P00692_A59ProductServiceName[0];
            A406TileIconAlignment = P00692_A406TileIconAlignment[0];
            A405TileTextAlignment = P00692_A405TileTextAlignment[0];
            A404TileTextColor = P00692_A404TileTextColor[0];
            A403TileBGImageUrl = P00692_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00692_n403TileBGImageUrl[0];
            A402TileBGColor = P00692_A402TileBGColor[0];
            n402TileBGColor = P00692_n402TileBGColor[0];
            A401TileIcon = P00692_A401TileIcon[0];
            n401TileIcon = P00692_n401TileIcon[0];
            A407TileId = P00692_A407TileId[0];
            A59ProductServiceName = P00692_A59ProductServiceName[0];
            A330SG_ToPageName = P00692_A330SG_ToPageName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A330SG_ToPageName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00692_A400TileName[0], A400TileName) == 0 ) )
               {
                  BRK692 = false;
                  A407TileId = P00692_A407TileId[0];
                  AV23count = (long)(AV23count+1);
                  BRK692 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A400TileName)) ? "<#Empty#>" : A400TileName);
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
         /* 'LOADTILEICONOPTIONS' Routine */
         returnInSub = false;
         AV52TFTileIcon = AV13SearchTxt;
         AV53TFTileIcon_Sel = "";
         AV66Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV67Trn_tilewwds_2_tftilename = AV50TFTileName;
         AV68Trn_tilewwds_3_tftilename_sel = AV51TFTileName_Sel;
         AV69Trn_tilewwds_4_tftileicon = AV52TFTileIcon;
         AV70Trn_tilewwds_5_tftileicon_sel = AV53TFTileIcon_Sel;
         AV71Trn_tilewwds_6_tftilebgcolor = AV54TFTileBGColor;
         AV72Trn_tilewwds_7_tftilebgcolor_sel = AV55TFTileBGColor_Sel;
         AV73Trn_tilewwds_8_tftilebgimageurl = AV56TFTileBGImageUrl;
         AV74Trn_tilewwds_9_tftilebgimageurl_sel = AV57TFTileBGImageUrl_Sel;
         AV75Trn_tilewwds_10_tftiletextcolor = AV58TFTileTextColor;
         AV76Trn_tilewwds_11_tftiletextcolor_sel = AV59TFTileTextColor_Sel;
         AV77Trn_tilewwds_12_tftiletextalignment_sels = AV61TFTileTextAlignment_Sels;
         AV78Trn_tilewwds_13_tftileiconalignment_sels = AV63TFTileIconAlignment_Sels;
         AV79Trn_tilewwds_14_tfproductservicename = AV38TFProductServiceName;
         AV80Trn_tilewwds_15_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV81Trn_tilewwds_16_tfsg_topagename = AV46TFSG_ToPageName;
         AV82Trn_tilewwds_17_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV68Trn_tilewwds_3_tftilename_sel ,
                                              AV67Trn_tilewwds_2_tftilename ,
                                              AV70Trn_tilewwds_5_tftileicon_sel ,
                                              AV69Trn_tilewwds_4_tftileicon ,
                                              AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                              AV71Trn_tilewwds_6_tftilebgcolor ,
                                              AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                              AV73Trn_tilewwds_8_tftilebgimageurl ,
                                              AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                              AV75Trn_tilewwds_10_tftiletextcolor ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels.Count ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                              AV79Trn_tilewwds_14_tfproductservicename ,
                                              AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                              AV81Trn_tilewwds_16_tfsg_topagename ,
                                              A400TileName ,
                                              A401TileIcon ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A59ProductServiceName ,
                                              A330SG_ToPageName ,
                                              AV66Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV67Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename), "%", "");
         lV69Trn_tilewwds_4_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon), 20, "%");
         lV71Trn_tilewwds_6_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor), 20, "%");
         lV73Trn_tilewwds_8_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl), "%", "");
         lV75Trn_tilewwds_10_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor), 20, "%");
         lV79Trn_tilewwds_14_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename), "%", "");
         lV81Trn_tilewwds_16_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename), "%", "");
         /* Using cursor P00693 */
         pr_default.execute(1, new Object[] {lV67Trn_tilewwds_2_tftilename, AV68Trn_tilewwds_3_tftilename_sel, lV69Trn_tilewwds_4_tftileicon, AV70Trn_tilewwds_5_tftileicon_sel, lV71Trn_tilewwds_6_tftilebgcolor, AV72Trn_tilewwds_7_tftilebgcolor_sel, lV73Trn_tilewwds_8_tftilebgimageurl, AV74Trn_tilewwds_9_tftilebgimageurl_sel, lV75Trn_tilewwds_10_tftiletextcolor, AV76Trn_tilewwds_11_tftiletextcolor_sel, lV79Trn_tilewwds_14_tfproductservicename, AV80Trn_tilewwds_15_tfproductservicename_sel, lV81Trn_tilewwds_16_tfsg_topagename, AV82Trn_tilewwds_17_tfsg_topagename_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK694 = false;
            A58ProductServiceId = P00693_A58ProductServiceId[0];
            n58ProductServiceId = P00693_n58ProductServiceId[0];
            A29LocationId = P00693_A29LocationId[0];
            n29LocationId = P00693_n29LocationId[0];
            A11OrganisationId = P00693_A11OrganisationId[0];
            n11OrganisationId = P00693_n11OrganisationId[0];
            A329SG_ToPageId = P00693_A329SG_ToPageId[0];
            A401TileIcon = P00693_A401TileIcon[0];
            n401TileIcon = P00693_n401TileIcon[0];
            A330SG_ToPageName = P00693_A330SG_ToPageName[0];
            A59ProductServiceName = P00693_A59ProductServiceName[0];
            A406TileIconAlignment = P00693_A406TileIconAlignment[0];
            A405TileTextAlignment = P00693_A405TileTextAlignment[0];
            A404TileTextColor = P00693_A404TileTextColor[0];
            A403TileBGImageUrl = P00693_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00693_n403TileBGImageUrl[0];
            A402TileBGColor = P00693_A402TileBGColor[0];
            n402TileBGColor = P00693_n402TileBGColor[0];
            A400TileName = P00693_A400TileName[0];
            A407TileId = P00693_A407TileId[0];
            A59ProductServiceName = P00693_A59ProductServiceName[0];
            A330SG_ToPageName = P00693_A330SG_ToPageName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A330SG_ToPageName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00693_A401TileIcon[0], A401TileIcon) == 0 ) )
               {
                  BRK694 = false;
                  A407TileId = P00693_A407TileId[0];
                  AV23count = (long)(AV23count+1);
                  BRK694 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A401TileIcon)) ? "<#Empty#>" : A401TileIcon);
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
         /* 'LOADTILEBGCOLOROPTIONS' Routine */
         returnInSub = false;
         AV54TFTileBGColor = AV13SearchTxt;
         AV55TFTileBGColor_Sel = "";
         AV66Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV67Trn_tilewwds_2_tftilename = AV50TFTileName;
         AV68Trn_tilewwds_3_tftilename_sel = AV51TFTileName_Sel;
         AV69Trn_tilewwds_4_tftileicon = AV52TFTileIcon;
         AV70Trn_tilewwds_5_tftileicon_sel = AV53TFTileIcon_Sel;
         AV71Trn_tilewwds_6_tftilebgcolor = AV54TFTileBGColor;
         AV72Trn_tilewwds_7_tftilebgcolor_sel = AV55TFTileBGColor_Sel;
         AV73Trn_tilewwds_8_tftilebgimageurl = AV56TFTileBGImageUrl;
         AV74Trn_tilewwds_9_tftilebgimageurl_sel = AV57TFTileBGImageUrl_Sel;
         AV75Trn_tilewwds_10_tftiletextcolor = AV58TFTileTextColor;
         AV76Trn_tilewwds_11_tftiletextcolor_sel = AV59TFTileTextColor_Sel;
         AV77Trn_tilewwds_12_tftiletextalignment_sels = AV61TFTileTextAlignment_Sels;
         AV78Trn_tilewwds_13_tftileiconalignment_sels = AV63TFTileIconAlignment_Sels;
         AV79Trn_tilewwds_14_tfproductservicename = AV38TFProductServiceName;
         AV80Trn_tilewwds_15_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV81Trn_tilewwds_16_tfsg_topagename = AV46TFSG_ToPageName;
         AV82Trn_tilewwds_17_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV68Trn_tilewwds_3_tftilename_sel ,
                                              AV67Trn_tilewwds_2_tftilename ,
                                              AV70Trn_tilewwds_5_tftileicon_sel ,
                                              AV69Trn_tilewwds_4_tftileicon ,
                                              AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                              AV71Trn_tilewwds_6_tftilebgcolor ,
                                              AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                              AV73Trn_tilewwds_8_tftilebgimageurl ,
                                              AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                              AV75Trn_tilewwds_10_tftiletextcolor ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels.Count ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                              AV79Trn_tilewwds_14_tfproductservicename ,
                                              AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                              AV81Trn_tilewwds_16_tfsg_topagename ,
                                              A400TileName ,
                                              A401TileIcon ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A59ProductServiceName ,
                                              A330SG_ToPageName ,
                                              AV66Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV67Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename), "%", "");
         lV69Trn_tilewwds_4_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon), 20, "%");
         lV71Trn_tilewwds_6_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor), 20, "%");
         lV73Trn_tilewwds_8_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl), "%", "");
         lV75Trn_tilewwds_10_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor), 20, "%");
         lV79Trn_tilewwds_14_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename), "%", "");
         lV81Trn_tilewwds_16_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename), "%", "");
         /* Using cursor P00694 */
         pr_default.execute(2, new Object[] {lV67Trn_tilewwds_2_tftilename, AV68Trn_tilewwds_3_tftilename_sel, lV69Trn_tilewwds_4_tftileicon, AV70Trn_tilewwds_5_tftileicon_sel, lV71Trn_tilewwds_6_tftilebgcolor, AV72Trn_tilewwds_7_tftilebgcolor_sel, lV73Trn_tilewwds_8_tftilebgimageurl, AV74Trn_tilewwds_9_tftilebgimageurl_sel, lV75Trn_tilewwds_10_tftiletextcolor, AV76Trn_tilewwds_11_tftiletextcolor_sel, lV79Trn_tilewwds_14_tfproductservicename, AV80Trn_tilewwds_15_tfproductservicename_sel, lV81Trn_tilewwds_16_tfsg_topagename, AV82Trn_tilewwds_17_tfsg_topagename_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK696 = false;
            A58ProductServiceId = P00694_A58ProductServiceId[0];
            n58ProductServiceId = P00694_n58ProductServiceId[0];
            A29LocationId = P00694_A29LocationId[0];
            n29LocationId = P00694_n29LocationId[0];
            A11OrganisationId = P00694_A11OrganisationId[0];
            n11OrganisationId = P00694_n11OrganisationId[0];
            A329SG_ToPageId = P00694_A329SG_ToPageId[0];
            A402TileBGColor = P00694_A402TileBGColor[0];
            n402TileBGColor = P00694_n402TileBGColor[0];
            A330SG_ToPageName = P00694_A330SG_ToPageName[0];
            A59ProductServiceName = P00694_A59ProductServiceName[0];
            A406TileIconAlignment = P00694_A406TileIconAlignment[0];
            A405TileTextAlignment = P00694_A405TileTextAlignment[0];
            A404TileTextColor = P00694_A404TileTextColor[0];
            A403TileBGImageUrl = P00694_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00694_n403TileBGImageUrl[0];
            A401TileIcon = P00694_A401TileIcon[0];
            n401TileIcon = P00694_n401TileIcon[0];
            A400TileName = P00694_A400TileName[0];
            A407TileId = P00694_A407TileId[0];
            A59ProductServiceName = P00694_A59ProductServiceName[0];
            A330SG_ToPageName = P00694_A330SG_ToPageName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A330SG_ToPageName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00694_A402TileBGColor[0], A402TileBGColor) == 0 ) )
               {
                  BRK696 = false;
                  A407TileId = P00694_A407TileId[0];
                  AV23count = (long)(AV23count+1);
                  BRK696 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A402TileBGColor)) ? "<#Empty#>" : A402TileBGColor);
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
            }
            if ( ! BRK696 )
            {
               BRK696 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADTILEBGIMAGEURLOPTIONS' Routine */
         returnInSub = false;
         AV56TFTileBGImageUrl = AV13SearchTxt;
         AV57TFTileBGImageUrl_Sel = "";
         AV66Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV67Trn_tilewwds_2_tftilename = AV50TFTileName;
         AV68Trn_tilewwds_3_tftilename_sel = AV51TFTileName_Sel;
         AV69Trn_tilewwds_4_tftileicon = AV52TFTileIcon;
         AV70Trn_tilewwds_5_tftileicon_sel = AV53TFTileIcon_Sel;
         AV71Trn_tilewwds_6_tftilebgcolor = AV54TFTileBGColor;
         AV72Trn_tilewwds_7_tftilebgcolor_sel = AV55TFTileBGColor_Sel;
         AV73Trn_tilewwds_8_tftilebgimageurl = AV56TFTileBGImageUrl;
         AV74Trn_tilewwds_9_tftilebgimageurl_sel = AV57TFTileBGImageUrl_Sel;
         AV75Trn_tilewwds_10_tftiletextcolor = AV58TFTileTextColor;
         AV76Trn_tilewwds_11_tftiletextcolor_sel = AV59TFTileTextColor_Sel;
         AV77Trn_tilewwds_12_tftiletextalignment_sels = AV61TFTileTextAlignment_Sels;
         AV78Trn_tilewwds_13_tftileiconalignment_sels = AV63TFTileIconAlignment_Sels;
         AV79Trn_tilewwds_14_tfproductservicename = AV38TFProductServiceName;
         AV80Trn_tilewwds_15_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV81Trn_tilewwds_16_tfsg_topagename = AV46TFSG_ToPageName;
         AV82Trn_tilewwds_17_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV68Trn_tilewwds_3_tftilename_sel ,
                                              AV67Trn_tilewwds_2_tftilename ,
                                              AV70Trn_tilewwds_5_tftileicon_sel ,
                                              AV69Trn_tilewwds_4_tftileicon ,
                                              AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                              AV71Trn_tilewwds_6_tftilebgcolor ,
                                              AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                              AV73Trn_tilewwds_8_tftilebgimageurl ,
                                              AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                              AV75Trn_tilewwds_10_tftiletextcolor ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels.Count ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                              AV79Trn_tilewwds_14_tfproductservicename ,
                                              AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                              AV81Trn_tilewwds_16_tfsg_topagename ,
                                              A400TileName ,
                                              A401TileIcon ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A59ProductServiceName ,
                                              A330SG_ToPageName ,
                                              AV66Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV67Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename), "%", "");
         lV69Trn_tilewwds_4_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon), 20, "%");
         lV71Trn_tilewwds_6_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor), 20, "%");
         lV73Trn_tilewwds_8_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl), "%", "");
         lV75Trn_tilewwds_10_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor), 20, "%");
         lV79Trn_tilewwds_14_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename), "%", "");
         lV81Trn_tilewwds_16_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename), "%", "");
         /* Using cursor P00695 */
         pr_default.execute(3, new Object[] {lV67Trn_tilewwds_2_tftilename, AV68Trn_tilewwds_3_tftilename_sel, lV69Trn_tilewwds_4_tftileicon, AV70Trn_tilewwds_5_tftileicon_sel, lV71Trn_tilewwds_6_tftilebgcolor, AV72Trn_tilewwds_7_tftilebgcolor_sel, lV73Trn_tilewwds_8_tftilebgimageurl, AV74Trn_tilewwds_9_tftilebgimageurl_sel, lV75Trn_tilewwds_10_tftiletextcolor, AV76Trn_tilewwds_11_tftiletextcolor_sel, lV79Trn_tilewwds_14_tfproductservicename, AV80Trn_tilewwds_15_tfproductservicename_sel, lV81Trn_tilewwds_16_tfsg_topagename, AV82Trn_tilewwds_17_tfsg_topagename_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK698 = false;
            A58ProductServiceId = P00695_A58ProductServiceId[0];
            n58ProductServiceId = P00695_n58ProductServiceId[0];
            A29LocationId = P00695_A29LocationId[0];
            n29LocationId = P00695_n29LocationId[0];
            A11OrganisationId = P00695_A11OrganisationId[0];
            n11OrganisationId = P00695_n11OrganisationId[0];
            A329SG_ToPageId = P00695_A329SG_ToPageId[0];
            A403TileBGImageUrl = P00695_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00695_n403TileBGImageUrl[0];
            A330SG_ToPageName = P00695_A330SG_ToPageName[0];
            A59ProductServiceName = P00695_A59ProductServiceName[0];
            A406TileIconAlignment = P00695_A406TileIconAlignment[0];
            A405TileTextAlignment = P00695_A405TileTextAlignment[0];
            A404TileTextColor = P00695_A404TileTextColor[0];
            A402TileBGColor = P00695_A402TileBGColor[0];
            n402TileBGColor = P00695_n402TileBGColor[0];
            A401TileIcon = P00695_A401TileIcon[0];
            n401TileIcon = P00695_n401TileIcon[0];
            A400TileName = P00695_A400TileName[0];
            A407TileId = P00695_A407TileId[0];
            A59ProductServiceName = P00695_A59ProductServiceName[0];
            A330SG_ToPageName = P00695_A330SG_ToPageName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A330SG_ToPageName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00695_A403TileBGImageUrl[0], A403TileBGImageUrl) == 0 ) )
               {
                  BRK698 = false;
                  A407TileId = P00695_A407TileId[0];
                  AV23count = (long)(AV23count+1);
                  BRK698 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A403TileBGImageUrl)) ? "<#Empty#>" : A403TileBGImageUrl);
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
         /* 'LOADTILETEXTCOLOROPTIONS' Routine */
         returnInSub = false;
         AV58TFTileTextColor = AV13SearchTxt;
         AV59TFTileTextColor_Sel = "";
         AV66Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV67Trn_tilewwds_2_tftilename = AV50TFTileName;
         AV68Trn_tilewwds_3_tftilename_sel = AV51TFTileName_Sel;
         AV69Trn_tilewwds_4_tftileicon = AV52TFTileIcon;
         AV70Trn_tilewwds_5_tftileicon_sel = AV53TFTileIcon_Sel;
         AV71Trn_tilewwds_6_tftilebgcolor = AV54TFTileBGColor;
         AV72Trn_tilewwds_7_tftilebgcolor_sel = AV55TFTileBGColor_Sel;
         AV73Trn_tilewwds_8_tftilebgimageurl = AV56TFTileBGImageUrl;
         AV74Trn_tilewwds_9_tftilebgimageurl_sel = AV57TFTileBGImageUrl_Sel;
         AV75Trn_tilewwds_10_tftiletextcolor = AV58TFTileTextColor;
         AV76Trn_tilewwds_11_tftiletextcolor_sel = AV59TFTileTextColor_Sel;
         AV77Trn_tilewwds_12_tftiletextalignment_sels = AV61TFTileTextAlignment_Sels;
         AV78Trn_tilewwds_13_tftileiconalignment_sels = AV63TFTileIconAlignment_Sels;
         AV79Trn_tilewwds_14_tfproductservicename = AV38TFProductServiceName;
         AV80Trn_tilewwds_15_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV81Trn_tilewwds_16_tfsg_topagename = AV46TFSG_ToPageName;
         AV82Trn_tilewwds_17_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV68Trn_tilewwds_3_tftilename_sel ,
                                              AV67Trn_tilewwds_2_tftilename ,
                                              AV70Trn_tilewwds_5_tftileicon_sel ,
                                              AV69Trn_tilewwds_4_tftileicon ,
                                              AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                              AV71Trn_tilewwds_6_tftilebgcolor ,
                                              AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                              AV73Trn_tilewwds_8_tftilebgimageurl ,
                                              AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                              AV75Trn_tilewwds_10_tftiletextcolor ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels.Count ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                              AV79Trn_tilewwds_14_tfproductservicename ,
                                              AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                              AV81Trn_tilewwds_16_tfsg_topagename ,
                                              A400TileName ,
                                              A401TileIcon ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A59ProductServiceName ,
                                              A330SG_ToPageName ,
                                              AV66Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV67Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename), "%", "");
         lV69Trn_tilewwds_4_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon), 20, "%");
         lV71Trn_tilewwds_6_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor), 20, "%");
         lV73Trn_tilewwds_8_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl), "%", "");
         lV75Trn_tilewwds_10_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor), 20, "%");
         lV79Trn_tilewwds_14_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename), "%", "");
         lV81Trn_tilewwds_16_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename), "%", "");
         /* Using cursor P00696 */
         pr_default.execute(4, new Object[] {lV67Trn_tilewwds_2_tftilename, AV68Trn_tilewwds_3_tftilename_sel, lV69Trn_tilewwds_4_tftileicon, AV70Trn_tilewwds_5_tftileicon_sel, lV71Trn_tilewwds_6_tftilebgcolor, AV72Trn_tilewwds_7_tftilebgcolor_sel, lV73Trn_tilewwds_8_tftilebgimageurl, AV74Trn_tilewwds_9_tftilebgimageurl_sel, lV75Trn_tilewwds_10_tftiletextcolor, AV76Trn_tilewwds_11_tftiletextcolor_sel, lV79Trn_tilewwds_14_tfproductservicename, AV80Trn_tilewwds_15_tfproductservicename_sel, lV81Trn_tilewwds_16_tfsg_topagename, AV82Trn_tilewwds_17_tfsg_topagename_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6910 = false;
            A58ProductServiceId = P00696_A58ProductServiceId[0];
            n58ProductServiceId = P00696_n58ProductServiceId[0];
            A29LocationId = P00696_A29LocationId[0];
            n29LocationId = P00696_n29LocationId[0];
            A11OrganisationId = P00696_A11OrganisationId[0];
            n11OrganisationId = P00696_n11OrganisationId[0];
            A329SG_ToPageId = P00696_A329SG_ToPageId[0];
            A404TileTextColor = P00696_A404TileTextColor[0];
            A330SG_ToPageName = P00696_A330SG_ToPageName[0];
            A59ProductServiceName = P00696_A59ProductServiceName[0];
            A406TileIconAlignment = P00696_A406TileIconAlignment[0];
            A405TileTextAlignment = P00696_A405TileTextAlignment[0];
            A403TileBGImageUrl = P00696_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00696_n403TileBGImageUrl[0];
            A402TileBGColor = P00696_A402TileBGColor[0];
            n402TileBGColor = P00696_n402TileBGColor[0];
            A401TileIcon = P00696_A401TileIcon[0];
            n401TileIcon = P00696_n401TileIcon[0];
            A400TileName = P00696_A400TileName[0];
            A407TileId = P00696_A407TileId[0];
            A59ProductServiceName = P00696_A59ProductServiceName[0];
            A330SG_ToPageName = P00696_A330SG_ToPageName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A330SG_ToPageName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00696_A404TileTextColor[0], A404TileTextColor) == 0 ) )
               {
                  BRK6910 = false;
                  A407TileId = P00696_A407TileId[0];
                  AV23count = (long)(AV23count+1);
                  BRK6910 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A404TileTextColor)) ? "<#Empty#>" : A404TileTextColor);
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
            }
            if ( ! BRK6910 )
            {
               BRK6910 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADPRODUCTSERVICENAMEOPTIONS' Routine */
         returnInSub = false;
         AV38TFProductServiceName = AV13SearchTxt;
         AV39TFProductServiceName_Sel = "";
         AV66Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV67Trn_tilewwds_2_tftilename = AV50TFTileName;
         AV68Trn_tilewwds_3_tftilename_sel = AV51TFTileName_Sel;
         AV69Trn_tilewwds_4_tftileicon = AV52TFTileIcon;
         AV70Trn_tilewwds_5_tftileicon_sel = AV53TFTileIcon_Sel;
         AV71Trn_tilewwds_6_tftilebgcolor = AV54TFTileBGColor;
         AV72Trn_tilewwds_7_tftilebgcolor_sel = AV55TFTileBGColor_Sel;
         AV73Trn_tilewwds_8_tftilebgimageurl = AV56TFTileBGImageUrl;
         AV74Trn_tilewwds_9_tftilebgimageurl_sel = AV57TFTileBGImageUrl_Sel;
         AV75Trn_tilewwds_10_tftiletextcolor = AV58TFTileTextColor;
         AV76Trn_tilewwds_11_tftiletextcolor_sel = AV59TFTileTextColor_Sel;
         AV77Trn_tilewwds_12_tftiletextalignment_sels = AV61TFTileTextAlignment_Sels;
         AV78Trn_tilewwds_13_tftileiconalignment_sels = AV63TFTileIconAlignment_Sels;
         AV79Trn_tilewwds_14_tfproductservicename = AV38TFProductServiceName;
         AV80Trn_tilewwds_15_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV81Trn_tilewwds_16_tfsg_topagename = AV46TFSG_ToPageName;
         AV82Trn_tilewwds_17_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV68Trn_tilewwds_3_tftilename_sel ,
                                              AV67Trn_tilewwds_2_tftilename ,
                                              AV70Trn_tilewwds_5_tftileicon_sel ,
                                              AV69Trn_tilewwds_4_tftileicon ,
                                              AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                              AV71Trn_tilewwds_6_tftilebgcolor ,
                                              AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                              AV73Trn_tilewwds_8_tftilebgimageurl ,
                                              AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                              AV75Trn_tilewwds_10_tftiletextcolor ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels.Count ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                              AV79Trn_tilewwds_14_tfproductservicename ,
                                              AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                              AV81Trn_tilewwds_16_tfsg_topagename ,
                                              A400TileName ,
                                              A401TileIcon ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A59ProductServiceName ,
                                              A330SG_ToPageName ,
                                              AV66Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV67Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename), "%", "");
         lV69Trn_tilewwds_4_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon), 20, "%");
         lV71Trn_tilewwds_6_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor), 20, "%");
         lV73Trn_tilewwds_8_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl), "%", "");
         lV75Trn_tilewwds_10_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor), 20, "%");
         lV79Trn_tilewwds_14_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename), "%", "");
         lV81Trn_tilewwds_16_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename), "%", "");
         /* Using cursor P00697 */
         pr_default.execute(5, new Object[] {lV67Trn_tilewwds_2_tftilename, AV68Trn_tilewwds_3_tftilename_sel, lV69Trn_tilewwds_4_tftileicon, AV70Trn_tilewwds_5_tftileicon_sel, lV71Trn_tilewwds_6_tftilebgcolor, AV72Trn_tilewwds_7_tftilebgcolor_sel, lV73Trn_tilewwds_8_tftilebgimageurl, AV74Trn_tilewwds_9_tftilebgimageurl_sel, lV75Trn_tilewwds_10_tftiletextcolor, AV76Trn_tilewwds_11_tftiletextcolor_sel, lV79Trn_tilewwds_14_tfproductservicename, AV80Trn_tilewwds_15_tfproductservicename_sel, lV81Trn_tilewwds_16_tfsg_topagename, AV82Trn_tilewwds_17_tfsg_topagename_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK6912 = false;
            A329SG_ToPageId = P00697_A329SG_ToPageId[0];
            A11OrganisationId = P00697_A11OrganisationId[0];
            n11OrganisationId = P00697_n11OrganisationId[0];
            A29LocationId = P00697_A29LocationId[0];
            n29LocationId = P00697_n29LocationId[0];
            A58ProductServiceId = P00697_A58ProductServiceId[0];
            n58ProductServiceId = P00697_n58ProductServiceId[0];
            A330SG_ToPageName = P00697_A330SG_ToPageName[0];
            A59ProductServiceName = P00697_A59ProductServiceName[0];
            A406TileIconAlignment = P00697_A406TileIconAlignment[0];
            A405TileTextAlignment = P00697_A405TileTextAlignment[0];
            A404TileTextColor = P00697_A404TileTextColor[0];
            A403TileBGImageUrl = P00697_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00697_n403TileBGImageUrl[0];
            A402TileBGColor = P00697_A402TileBGColor[0];
            n402TileBGColor = P00697_n402TileBGColor[0];
            A401TileIcon = P00697_A401TileIcon[0];
            n401TileIcon = P00697_n401TileIcon[0];
            A400TileName = P00697_A400TileName[0];
            A407TileId = P00697_A407TileId[0];
            A330SG_ToPageName = P00697_A330SG_ToPageName[0];
            A59ProductServiceName = P00697_A59ProductServiceName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A330SG_ToPageName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(5) != 101) && ( P00697_A58ProductServiceId[0] == A58ProductServiceId ) && ( P00697_A29LocationId[0] == A29LocationId ) && ( P00697_A11OrganisationId[0] == A11OrganisationId ) )
               {
                  BRK6912 = false;
                  A407TileId = P00697_A407TileId[0];
                  AV23count = (long)(AV23count+1);
                  BRK6912 = true;
                  pr_default.readNext(5);
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
            }
            if ( ! BRK6912 )
            {
               BRK6912 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
         while ( AV14SkipItems > 0 )
         {
            AV19Options.RemoveItem(1);
            AV22OptionIndexes.RemoveItem(1);
            AV14SkipItems = (short)(AV14SkipItems-1);
         }
      }

      protected void S181( )
      {
         /* 'LOADSG_TOPAGENAMEOPTIONS' Routine */
         returnInSub = false;
         AV46TFSG_ToPageName = AV13SearchTxt;
         AV47TFSG_ToPageName_Sel = "";
         AV66Trn_tilewwds_1_filterfulltext = AV35FilterFullText;
         AV67Trn_tilewwds_2_tftilename = AV50TFTileName;
         AV68Trn_tilewwds_3_tftilename_sel = AV51TFTileName_Sel;
         AV69Trn_tilewwds_4_tftileicon = AV52TFTileIcon;
         AV70Trn_tilewwds_5_tftileicon_sel = AV53TFTileIcon_Sel;
         AV71Trn_tilewwds_6_tftilebgcolor = AV54TFTileBGColor;
         AV72Trn_tilewwds_7_tftilebgcolor_sel = AV55TFTileBGColor_Sel;
         AV73Trn_tilewwds_8_tftilebgimageurl = AV56TFTileBGImageUrl;
         AV74Trn_tilewwds_9_tftilebgimageurl_sel = AV57TFTileBGImageUrl_Sel;
         AV75Trn_tilewwds_10_tftiletextcolor = AV58TFTileTextColor;
         AV76Trn_tilewwds_11_tftiletextcolor_sel = AV59TFTileTextColor_Sel;
         AV77Trn_tilewwds_12_tftiletextalignment_sels = AV61TFTileTextAlignment_Sels;
         AV78Trn_tilewwds_13_tftileiconalignment_sels = AV63TFTileIconAlignment_Sels;
         AV79Trn_tilewwds_14_tfproductservicename = AV38TFProductServiceName;
         AV80Trn_tilewwds_15_tfproductservicename_sel = AV39TFProductServiceName_Sel;
         AV81Trn_tilewwds_16_tfsg_topagename = AV46TFSG_ToPageName;
         AV82Trn_tilewwds_17_tfsg_topagename_sel = AV47TFSG_ToPageName_Sel;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV68Trn_tilewwds_3_tftilename_sel ,
                                              AV67Trn_tilewwds_2_tftilename ,
                                              AV70Trn_tilewwds_5_tftileicon_sel ,
                                              AV69Trn_tilewwds_4_tftileicon ,
                                              AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                              AV71Trn_tilewwds_6_tftilebgcolor ,
                                              AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                              AV73Trn_tilewwds_8_tftilebgimageurl ,
                                              AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                              AV75Trn_tilewwds_10_tftiletextcolor ,
                                              AV77Trn_tilewwds_12_tftiletextalignment_sels.Count ,
                                              AV78Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                              AV79Trn_tilewwds_14_tfproductservicename ,
                                              AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                              AV81Trn_tilewwds_16_tfsg_topagename ,
                                              A400TileName ,
                                              A401TileIcon ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A59ProductServiceName ,
                                              A330SG_ToPageName ,
                                              AV66Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV67Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename), "%", "");
         lV69Trn_tilewwds_4_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon), 20, "%");
         lV71Trn_tilewwds_6_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor), 20, "%");
         lV73Trn_tilewwds_8_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl), "%", "");
         lV75Trn_tilewwds_10_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor), 20, "%");
         lV79Trn_tilewwds_14_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename), "%", "");
         lV81Trn_tilewwds_16_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename), "%", "");
         /* Using cursor P00698 */
         pr_default.execute(6, new Object[] {lV67Trn_tilewwds_2_tftilename, AV68Trn_tilewwds_3_tftilename_sel, lV69Trn_tilewwds_4_tftileicon, AV70Trn_tilewwds_5_tftileicon_sel, lV71Trn_tilewwds_6_tftilebgcolor, AV72Trn_tilewwds_7_tftilebgcolor_sel, lV73Trn_tilewwds_8_tftilebgimageurl, AV74Trn_tilewwds_9_tftilebgimageurl_sel, lV75Trn_tilewwds_10_tftiletextcolor, AV76Trn_tilewwds_11_tftiletextcolor_sel, lV79Trn_tilewwds_14_tfproductservicename, AV80Trn_tilewwds_15_tfproductservicename_sel, lV81Trn_tilewwds_16_tfsg_topagename, AV82Trn_tilewwds_17_tfsg_topagename_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK6914 = false;
            A58ProductServiceId = P00698_A58ProductServiceId[0];
            n58ProductServiceId = P00698_n58ProductServiceId[0];
            A29LocationId = P00698_A29LocationId[0];
            n29LocationId = P00698_n29LocationId[0];
            A11OrganisationId = P00698_A11OrganisationId[0];
            n11OrganisationId = P00698_n11OrganisationId[0];
            A329SG_ToPageId = P00698_A329SG_ToPageId[0];
            A330SG_ToPageName = P00698_A330SG_ToPageName[0];
            A59ProductServiceName = P00698_A59ProductServiceName[0];
            A406TileIconAlignment = P00698_A406TileIconAlignment[0];
            A405TileTextAlignment = P00698_A405TileTextAlignment[0];
            A404TileTextColor = P00698_A404TileTextColor[0];
            A403TileBGImageUrl = P00698_A403TileBGImageUrl[0];
            n403TileBGImageUrl = P00698_n403TileBGImageUrl[0];
            A402TileBGColor = P00698_A402TileBGColor[0];
            n402TileBGColor = P00698_n402TileBGColor[0];
            A401TileIcon = P00698_A401TileIcon[0];
            n401TileIcon = P00698_n401TileIcon[0];
            A400TileName = P00698_A400TileName[0];
            A407TileId = P00698_A407TileId[0];
            A59ProductServiceName = P00698_A59ProductServiceName[0];
            A330SG_ToPageName = P00698_A330SG_ToPageName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, context.GetMessage( "right", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "center", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "center", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "left", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "left", "")) == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( context.GetMessage( "right", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, context.GetMessage( "right", "")) == 0 ) ) || ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A330SG_ToPageName , StringUtil.PadR( "%" + AV66Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(6) != 101) && ( P00698_A329SG_ToPageId[0] == A329SG_ToPageId ) )
               {
                  BRK6914 = false;
                  A407TileId = P00698_A407TileId[0];
                  AV23count = (long)(AV23count+1);
                  BRK6914 = true;
                  pr_default.readNext(6);
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
            }
            if ( ! BRK6914 )
            {
               BRK6914 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
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
         AV50TFTileName = "";
         AV51TFTileName_Sel = "";
         AV52TFTileIcon = "";
         AV53TFTileIcon_Sel = "";
         AV54TFTileBGColor = "";
         AV55TFTileBGColor_Sel = "";
         AV56TFTileBGImageUrl = "";
         AV57TFTileBGImageUrl_Sel = "";
         AV58TFTileTextColor = "";
         AV59TFTileTextColor_Sel = "";
         AV60TFTileTextAlignment_SelsJson = "";
         AV61TFTileTextAlignment_Sels = new GxSimpleCollection<string>();
         AV62TFTileIconAlignment_SelsJson = "";
         AV63TFTileIconAlignment_Sels = new GxSimpleCollection<string>();
         AV38TFProductServiceName = "";
         AV39TFProductServiceName_Sel = "";
         AV46TFSG_ToPageName = "";
         AV47TFSG_ToPageName_Sel = "";
         AV66Trn_tilewwds_1_filterfulltext = "";
         AV67Trn_tilewwds_2_tftilename = "";
         AV68Trn_tilewwds_3_tftilename_sel = "";
         AV69Trn_tilewwds_4_tftileicon = "";
         AV70Trn_tilewwds_5_tftileicon_sel = "";
         AV71Trn_tilewwds_6_tftilebgcolor = "";
         AV72Trn_tilewwds_7_tftilebgcolor_sel = "";
         AV73Trn_tilewwds_8_tftilebgimageurl = "";
         AV74Trn_tilewwds_9_tftilebgimageurl_sel = "";
         AV75Trn_tilewwds_10_tftiletextcolor = "";
         AV76Trn_tilewwds_11_tftiletextcolor_sel = "";
         AV77Trn_tilewwds_12_tftiletextalignment_sels = new GxSimpleCollection<string>();
         AV78Trn_tilewwds_13_tftileiconalignment_sels = new GxSimpleCollection<string>();
         AV79Trn_tilewwds_14_tfproductservicename = "";
         AV80Trn_tilewwds_15_tfproductservicename_sel = "";
         AV81Trn_tilewwds_16_tfsg_topagename = "";
         AV82Trn_tilewwds_17_tfsg_topagename_sel = "";
         lV66Trn_tilewwds_1_filterfulltext = "";
         lV67Trn_tilewwds_2_tftilename = "";
         lV69Trn_tilewwds_4_tftileicon = "";
         lV71Trn_tilewwds_6_tftilebgcolor = "";
         lV73Trn_tilewwds_8_tftilebgimageurl = "";
         lV75Trn_tilewwds_10_tftiletextcolor = "";
         lV79Trn_tilewwds_14_tfproductservicename = "";
         lV81Trn_tilewwds_16_tfsg_topagename = "";
         A405TileTextAlignment = "";
         A406TileIconAlignment = "";
         A400TileName = "";
         A401TileIcon = "";
         A402TileBGColor = "";
         A403TileBGImageUrl = "";
         A404TileTextColor = "";
         A59ProductServiceName = "";
         A330SG_ToPageName = "";
         P00692_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00692_n58ProductServiceId = new bool[] {false} ;
         P00692_A29LocationId = new Guid[] {Guid.Empty} ;
         P00692_n29LocationId = new bool[] {false} ;
         P00692_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00692_n11OrganisationId = new bool[] {false} ;
         P00692_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00692_A400TileName = new string[] {""} ;
         P00692_A330SG_ToPageName = new string[] {""} ;
         P00692_A59ProductServiceName = new string[] {""} ;
         P00692_A406TileIconAlignment = new string[] {""} ;
         P00692_A405TileTextAlignment = new string[] {""} ;
         P00692_A404TileTextColor = new string[] {""} ;
         P00692_A403TileBGImageUrl = new string[] {""} ;
         P00692_n403TileBGImageUrl = new bool[] {false} ;
         P00692_A402TileBGColor = new string[] {""} ;
         P00692_n402TileBGColor = new bool[] {false} ;
         P00692_A401TileIcon = new string[] {""} ;
         P00692_n401TileIcon = new bool[] {false} ;
         P00692_A407TileId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A329SG_ToPageId = Guid.Empty;
         A407TileId = Guid.Empty;
         AV18Option = "";
         P00693_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00693_n58ProductServiceId = new bool[] {false} ;
         P00693_A29LocationId = new Guid[] {Guid.Empty} ;
         P00693_n29LocationId = new bool[] {false} ;
         P00693_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00693_n11OrganisationId = new bool[] {false} ;
         P00693_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00693_A401TileIcon = new string[] {""} ;
         P00693_n401TileIcon = new bool[] {false} ;
         P00693_A330SG_ToPageName = new string[] {""} ;
         P00693_A59ProductServiceName = new string[] {""} ;
         P00693_A406TileIconAlignment = new string[] {""} ;
         P00693_A405TileTextAlignment = new string[] {""} ;
         P00693_A404TileTextColor = new string[] {""} ;
         P00693_A403TileBGImageUrl = new string[] {""} ;
         P00693_n403TileBGImageUrl = new bool[] {false} ;
         P00693_A402TileBGColor = new string[] {""} ;
         P00693_n402TileBGColor = new bool[] {false} ;
         P00693_A400TileName = new string[] {""} ;
         P00693_A407TileId = new Guid[] {Guid.Empty} ;
         P00694_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00694_n58ProductServiceId = new bool[] {false} ;
         P00694_A29LocationId = new Guid[] {Guid.Empty} ;
         P00694_n29LocationId = new bool[] {false} ;
         P00694_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00694_n11OrganisationId = new bool[] {false} ;
         P00694_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00694_A402TileBGColor = new string[] {""} ;
         P00694_n402TileBGColor = new bool[] {false} ;
         P00694_A330SG_ToPageName = new string[] {""} ;
         P00694_A59ProductServiceName = new string[] {""} ;
         P00694_A406TileIconAlignment = new string[] {""} ;
         P00694_A405TileTextAlignment = new string[] {""} ;
         P00694_A404TileTextColor = new string[] {""} ;
         P00694_A403TileBGImageUrl = new string[] {""} ;
         P00694_n403TileBGImageUrl = new bool[] {false} ;
         P00694_A401TileIcon = new string[] {""} ;
         P00694_n401TileIcon = new bool[] {false} ;
         P00694_A400TileName = new string[] {""} ;
         P00694_A407TileId = new Guid[] {Guid.Empty} ;
         P00695_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00695_n58ProductServiceId = new bool[] {false} ;
         P00695_A29LocationId = new Guid[] {Guid.Empty} ;
         P00695_n29LocationId = new bool[] {false} ;
         P00695_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00695_n11OrganisationId = new bool[] {false} ;
         P00695_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00695_A403TileBGImageUrl = new string[] {""} ;
         P00695_n403TileBGImageUrl = new bool[] {false} ;
         P00695_A330SG_ToPageName = new string[] {""} ;
         P00695_A59ProductServiceName = new string[] {""} ;
         P00695_A406TileIconAlignment = new string[] {""} ;
         P00695_A405TileTextAlignment = new string[] {""} ;
         P00695_A404TileTextColor = new string[] {""} ;
         P00695_A402TileBGColor = new string[] {""} ;
         P00695_n402TileBGColor = new bool[] {false} ;
         P00695_A401TileIcon = new string[] {""} ;
         P00695_n401TileIcon = new bool[] {false} ;
         P00695_A400TileName = new string[] {""} ;
         P00695_A407TileId = new Guid[] {Guid.Empty} ;
         P00696_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00696_n58ProductServiceId = new bool[] {false} ;
         P00696_A29LocationId = new Guid[] {Guid.Empty} ;
         P00696_n29LocationId = new bool[] {false} ;
         P00696_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00696_n11OrganisationId = new bool[] {false} ;
         P00696_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00696_A404TileTextColor = new string[] {""} ;
         P00696_A330SG_ToPageName = new string[] {""} ;
         P00696_A59ProductServiceName = new string[] {""} ;
         P00696_A406TileIconAlignment = new string[] {""} ;
         P00696_A405TileTextAlignment = new string[] {""} ;
         P00696_A403TileBGImageUrl = new string[] {""} ;
         P00696_n403TileBGImageUrl = new bool[] {false} ;
         P00696_A402TileBGColor = new string[] {""} ;
         P00696_n402TileBGColor = new bool[] {false} ;
         P00696_A401TileIcon = new string[] {""} ;
         P00696_n401TileIcon = new bool[] {false} ;
         P00696_A400TileName = new string[] {""} ;
         P00696_A407TileId = new Guid[] {Guid.Empty} ;
         P00697_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00697_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00697_n11OrganisationId = new bool[] {false} ;
         P00697_A29LocationId = new Guid[] {Guid.Empty} ;
         P00697_n29LocationId = new bool[] {false} ;
         P00697_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00697_n58ProductServiceId = new bool[] {false} ;
         P00697_A330SG_ToPageName = new string[] {""} ;
         P00697_A59ProductServiceName = new string[] {""} ;
         P00697_A406TileIconAlignment = new string[] {""} ;
         P00697_A405TileTextAlignment = new string[] {""} ;
         P00697_A404TileTextColor = new string[] {""} ;
         P00697_A403TileBGImageUrl = new string[] {""} ;
         P00697_n403TileBGImageUrl = new bool[] {false} ;
         P00697_A402TileBGColor = new string[] {""} ;
         P00697_n402TileBGColor = new bool[] {false} ;
         P00697_A401TileIcon = new string[] {""} ;
         P00697_n401TileIcon = new bool[] {false} ;
         P00697_A400TileName = new string[] {""} ;
         P00697_A407TileId = new Guid[] {Guid.Empty} ;
         P00698_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00698_n58ProductServiceId = new bool[] {false} ;
         P00698_A29LocationId = new Guid[] {Guid.Empty} ;
         P00698_n29LocationId = new bool[] {false} ;
         P00698_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00698_n11OrganisationId = new bool[] {false} ;
         P00698_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         P00698_A330SG_ToPageName = new string[] {""} ;
         P00698_A59ProductServiceName = new string[] {""} ;
         P00698_A406TileIconAlignment = new string[] {""} ;
         P00698_A405TileTextAlignment = new string[] {""} ;
         P00698_A404TileTextColor = new string[] {""} ;
         P00698_A403TileBGImageUrl = new string[] {""} ;
         P00698_n403TileBGImageUrl = new bool[] {false} ;
         P00698_A402TileBGColor = new string[] {""} ;
         P00698_n402TileBGColor = new bool[] {false} ;
         P00698_A401TileIcon = new string[] {""} ;
         P00698_n401TileIcon = new bool[] {false} ;
         P00698_A400TileName = new string[] {""} ;
         P00698_A407TileId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tilewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00692_A58ProductServiceId, P00692_n58ProductServiceId, P00692_A29LocationId, P00692_n29LocationId, P00692_A11OrganisationId, P00692_n11OrganisationId, P00692_A329SG_ToPageId, P00692_A400TileName, P00692_A330SG_ToPageName, P00692_A59ProductServiceName,
               P00692_A406TileIconAlignment, P00692_A405TileTextAlignment, P00692_A404TileTextColor, P00692_A403TileBGImageUrl, P00692_n403TileBGImageUrl, P00692_A402TileBGColor, P00692_n402TileBGColor, P00692_A401TileIcon, P00692_n401TileIcon, P00692_A407TileId
               }
               , new Object[] {
               P00693_A58ProductServiceId, P00693_n58ProductServiceId, P00693_A29LocationId, P00693_n29LocationId, P00693_A11OrganisationId, P00693_n11OrganisationId, P00693_A329SG_ToPageId, P00693_A401TileIcon, P00693_n401TileIcon, P00693_A330SG_ToPageName,
               P00693_A59ProductServiceName, P00693_A406TileIconAlignment, P00693_A405TileTextAlignment, P00693_A404TileTextColor, P00693_A403TileBGImageUrl, P00693_n403TileBGImageUrl, P00693_A402TileBGColor, P00693_n402TileBGColor, P00693_A400TileName, P00693_A407TileId
               }
               , new Object[] {
               P00694_A58ProductServiceId, P00694_n58ProductServiceId, P00694_A29LocationId, P00694_n29LocationId, P00694_A11OrganisationId, P00694_n11OrganisationId, P00694_A329SG_ToPageId, P00694_A402TileBGColor, P00694_n402TileBGColor, P00694_A330SG_ToPageName,
               P00694_A59ProductServiceName, P00694_A406TileIconAlignment, P00694_A405TileTextAlignment, P00694_A404TileTextColor, P00694_A403TileBGImageUrl, P00694_n403TileBGImageUrl, P00694_A401TileIcon, P00694_n401TileIcon, P00694_A400TileName, P00694_A407TileId
               }
               , new Object[] {
               P00695_A58ProductServiceId, P00695_n58ProductServiceId, P00695_A29LocationId, P00695_n29LocationId, P00695_A11OrganisationId, P00695_n11OrganisationId, P00695_A329SG_ToPageId, P00695_A403TileBGImageUrl, P00695_n403TileBGImageUrl, P00695_A330SG_ToPageName,
               P00695_A59ProductServiceName, P00695_A406TileIconAlignment, P00695_A405TileTextAlignment, P00695_A404TileTextColor, P00695_A402TileBGColor, P00695_n402TileBGColor, P00695_A401TileIcon, P00695_n401TileIcon, P00695_A400TileName, P00695_A407TileId
               }
               , new Object[] {
               P00696_A58ProductServiceId, P00696_n58ProductServiceId, P00696_A29LocationId, P00696_n29LocationId, P00696_A11OrganisationId, P00696_n11OrganisationId, P00696_A329SG_ToPageId, P00696_A404TileTextColor, P00696_A330SG_ToPageName, P00696_A59ProductServiceName,
               P00696_A406TileIconAlignment, P00696_A405TileTextAlignment, P00696_A403TileBGImageUrl, P00696_n403TileBGImageUrl, P00696_A402TileBGColor, P00696_n402TileBGColor, P00696_A401TileIcon, P00696_n401TileIcon, P00696_A400TileName, P00696_A407TileId
               }
               , new Object[] {
               P00697_A329SG_ToPageId, P00697_A11OrganisationId, P00697_n11OrganisationId, P00697_A29LocationId, P00697_n29LocationId, P00697_A58ProductServiceId, P00697_n58ProductServiceId, P00697_A330SG_ToPageName, P00697_A59ProductServiceName, P00697_A406TileIconAlignment,
               P00697_A405TileTextAlignment, P00697_A404TileTextColor, P00697_A403TileBGImageUrl, P00697_n403TileBGImageUrl, P00697_A402TileBGColor, P00697_n402TileBGColor, P00697_A401TileIcon, P00697_n401TileIcon, P00697_A400TileName, P00697_A407TileId
               }
               , new Object[] {
               P00698_A58ProductServiceId, P00698_n58ProductServiceId, P00698_A29LocationId, P00698_n29LocationId, P00698_A11OrganisationId, P00698_n11OrganisationId, P00698_A329SG_ToPageId, P00698_A330SG_ToPageName, P00698_A59ProductServiceName, P00698_A406TileIconAlignment,
               P00698_A405TileTextAlignment, P00698_A404TileTextColor, P00698_A403TileBGImageUrl, P00698_n403TileBGImageUrl, P00698_A402TileBGColor, P00698_n402TileBGColor, P00698_A401TileIcon, P00698_n401TileIcon, P00698_A400TileName, P00698_A407TileId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private int AV64GXV1 ;
      private int AV77Trn_tilewwds_12_tftiletextalignment_sels_Count ;
      private int AV78Trn_tilewwds_13_tftileiconalignment_sels_Count ;
      private int AV17InsertIndex ;
      private long AV23count ;
      private string AV52TFTileIcon ;
      private string AV53TFTileIcon_Sel ;
      private string AV54TFTileBGColor ;
      private string AV55TFTileBGColor_Sel ;
      private string AV58TFTileTextColor ;
      private string AV59TFTileTextColor_Sel ;
      private string AV69Trn_tilewwds_4_tftileicon ;
      private string AV70Trn_tilewwds_5_tftileicon_sel ;
      private string AV71Trn_tilewwds_6_tftilebgcolor ;
      private string AV72Trn_tilewwds_7_tftilebgcolor_sel ;
      private string AV75Trn_tilewwds_10_tftiletextcolor ;
      private string AV76Trn_tilewwds_11_tftiletextcolor_sel ;
      private string lV69Trn_tilewwds_4_tftileicon ;
      private string lV71Trn_tilewwds_6_tftilebgcolor ;
      private string lV75Trn_tilewwds_10_tftiletextcolor ;
      private string A405TileTextAlignment ;
      private string A406TileIconAlignment ;
      private string A401TileIcon ;
      private string A402TileBGColor ;
      private string A404TileTextColor ;
      private bool returnInSub ;
      private bool BRK692 ;
      private bool n58ProductServiceId ;
      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private bool n403TileBGImageUrl ;
      private bool n402TileBGColor ;
      private bool n401TileIcon ;
      private bool BRK694 ;
      private bool BRK696 ;
      private bool BRK698 ;
      private bool BRK6910 ;
      private bool BRK6912 ;
      private bool BRK6914 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV60TFTileTextAlignment_SelsJson ;
      private string AV62TFTileIconAlignment_SelsJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV50TFTileName ;
      private string AV51TFTileName_Sel ;
      private string AV56TFTileBGImageUrl ;
      private string AV57TFTileBGImageUrl_Sel ;
      private string AV38TFProductServiceName ;
      private string AV39TFProductServiceName_Sel ;
      private string AV46TFSG_ToPageName ;
      private string AV47TFSG_ToPageName_Sel ;
      private string AV66Trn_tilewwds_1_filterfulltext ;
      private string AV67Trn_tilewwds_2_tftilename ;
      private string AV68Trn_tilewwds_3_tftilename_sel ;
      private string AV73Trn_tilewwds_8_tftilebgimageurl ;
      private string AV74Trn_tilewwds_9_tftilebgimageurl_sel ;
      private string AV79Trn_tilewwds_14_tfproductservicename ;
      private string AV80Trn_tilewwds_15_tfproductservicename_sel ;
      private string AV81Trn_tilewwds_16_tfsg_topagename ;
      private string AV82Trn_tilewwds_17_tfsg_topagename_sel ;
      private string lV66Trn_tilewwds_1_filterfulltext ;
      private string lV67Trn_tilewwds_2_tftilename ;
      private string lV73Trn_tilewwds_8_tftilebgimageurl ;
      private string lV79Trn_tilewwds_14_tfproductservicename ;
      private string lV81Trn_tilewwds_16_tfsg_topagename ;
      private string A400TileName ;
      private string A403TileBGImageUrl ;
      private string A59ProductServiceName ;
      private string A330SG_ToPageName ;
      private string AV18Option ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A329SG_ToPageId ;
      private Guid A407TileId ;
      private IGxSession AV24Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV21OptionsDesc ;
      private GxSimpleCollection<string> AV22OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV26GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private GxSimpleCollection<string> AV61TFTileTextAlignment_Sels ;
      private GxSimpleCollection<string> AV63TFTileIconAlignment_Sels ;
      private GxSimpleCollection<string> AV77Trn_tilewwds_12_tftiletextalignment_sels ;
      private GxSimpleCollection<string> AV78Trn_tilewwds_13_tftileiconalignment_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00692_A58ProductServiceId ;
      private bool[] P00692_n58ProductServiceId ;
      private Guid[] P00692_A29LocationId ;
      private bool[] P00692_n29LocationId ;
      private Guid[] P00692_A11OrganisationId ;
      private bool[] P00692_n11OrganisationId ;
      private Guid[] P00692_A329SG_ToPageId ;
      private string[] P00692_A400TileName ;
      private string[] P00692_A330SG_ToPageName ;
      private string[] P00692_A59ProductServiceName ;
      private string[] P00692_A406TileIconAlignment ;
      private string[] P00692_A405TileTextAlignment ;
      private string[] P00692_A404TileTextColor ;
      private string[] P00692_A403TileBGImageUrl ;
      private bool[] P00692_n403TileBGImageUrl ;
      private string[] P00692_A402TileBGColor ;
      private bool[] P00692_n402TileBGColor ;
      private string[] P00692_A401TileIcon ;
      private bool[] P00692_n401TileIcon ;
      private Guid[] P00692_A407TileId ;
      private Guid[] P00693_A58ProductServiceId ;
      private bool[] P00693_n58ProductServiceId ;
      private Guid[] P00693_A29LocationId ;
      private bool[] P00693_n29LocationId ;
      private Guid[] P00693_A11OrganisationId ;
      private bool[] P00693_n11OrganisationId ;
      private Guid[] P00693_A329SG_ToPageId ;
      private string[] P00693_A401TileIcon ;
      private bool[] P00693_n401TileIcon ;
      private string[] P00693_A330SG_ToPageName ;
      private string[] P00693_A59ProductServiceName ;
      private string[] P00693_A406TileIconAlignment ;
      private string[] P00693_A405TileTextAlignment ;
      private string[] P00693_A404TileTextColor ;
      private string[] P00693_A403TileBGImageUrl ;
      private bool[] P00693_n403TileBGImageUrl ;
      private string[] P00693_A402TileBGColor ;
      private bool[] P00693_n402TileBGColor ;
      private string[] P00693_A400TileName ;
      private Guid[] P00693_A407TileId ;
      private Guid[] P00694_A58ProductServiceId ;
      private bool[] P00694_n58ProductServiceId ;
      private Guid[] P00694_A29LocationId ;
      private bool[] P00694_n29LocationId ;
      private Guid[] P00694_A11OrganisationId ;
      private bool[] P00694_n11OrganisationId ;
      private Guid[] P00694_A329SG_ToPageId ;
      private string[] P00694_A402TileBGColor ;
      private bool[] P00694_n402TileBGColor ;
      private string[] P00694_A330SG_ToPageName ;
      private string[] P00694_A59ProductServiceName ;
      private string[] P00694_A406TileIconAlignment ;
      private string[] P00694_A405TileTextAlignment ;
      private string[] P00694_A404TileTextColor ;
      private string[] P00694_A403TileBGImageUrl ;
      private bool[] P00694_n403TileBGImageUrl ;
      private string[] P00694_A401TileIcon ;
      private bool[] P00694_n401TileIcon ;
      private string[] P00694_A400TileName ;
      private Guid[] P00694_A407TileId ;
      private Guid[] P00695_A58ProductServiceId ;
      private bool[] P00695_n58ProductServiceId ;
      private Guid[] P00695_A29LocationId ;
      private bool[] P00695_n29LocationId ;
      private Guid[] P00695_A11OrganisationId ;
      private bool[] P00695_n11OrganisationId ;
      private Guid[] P00695_A329SG_ToPageId ;
      private string[] P00695_A403TileBGImageUrl ;
      private bool[] P00695_n403TileBGImageUrl ;
      private string[] P00695_A330SG_ToPageName ;
      private string[] P00695_A59ProductServiceName ;
      private string[] P00695_A406TileIconAlignment ;
      private string[] P00695_A405TileTextAlignment ;
      private string[] P00695_A404TileTextColor ;
      private string[] P00695_A402TileBGColor ;
      private bool[] P00695_n402TileBGColor ;
      private string[] P00695_A401TileIcon ;
      private bool[] P00695_n401TileIcon ;
      private string[] P00695_A400TileName ;
      private Guid[] P00695_A407TileId ;
      private Guid[] P00696_A58ProductServiceId ;
      private bool[] P00696_n58ProductServiceId ;
      private Guid[] P00696_A29LocationId ;
      private bool[] P00696_n29LocationId ;
      private Guid[] P00696_A11OrganisationId ;
      private bool[] P00696_n11OrganisationId ;
      private Guid[] P00696_A329SG_ToPageId ;
      private string[] P00696_A404TileTextColor ;
      private string[] P00696_A330SG_ToPageName ;
      private string[] P00696_A59ProductServiceName ;
      private string[] P00696_A406TileIconAlignment ;
      private string[] P00696_A405TileTextAlignment ;
      private string[] P00696_A403TileBGImageUrl ;
      private bool[] P00696_n403TileBGImageUrl ;
      private string[] P00696_A402TileBGColor ;
      private bool[] P00696_n402TileBGColor ;
      private string[] P00696_A401TileIcon ;
      private bool[] P00696_n401TileIcon ;
      private string[] P00696_A400TileName ;
      private Guid[] P00696_A407TileId ;
      private Guid[] P00697_A329SG_ToPageId ;
      private Guid[] P00697_A11OrganisationId ;
      private bool[] P00697_n11OrganisationId ;
      private Guid[] P00697_A29LocationId ;
      private bool[] P00697_n29LocationId ;
      private Guid[] P00697_A58ProductServiceId ;
      private bool[] P00697_n58ProductServiceId ;
      private string[] P00697_A330SG_ToPageName ;
      private string[] P00697_A59ProductServiceName ;
      private string[] P00697_A406TileIconAlignment ;
      private string[] P00697_A405TileTextAlignment ;
      private string[] P00697_A404TileTextColor ;
      private string[] P00697_A403TileBGImageUrl ;
      private bool[] P00697_n403TileBGImageUrl ;
      private string[] P00697_A402TileBGColor ;
      private bool[] P00697_n402TileBGColor ;
      private string[] P00697_A401TileIcon ;
      private bool[] P00697_n401TileIcon ;
      private string[] P00697_A400TileName ;
      private Guid[] P00697_A407TileId ;
      private Guid[] P00698_A58ProductServiceId ;
      private bool[] P00698_n58ProductServiceId ;
      private Guid[] P00698_A29LocationId ;
      private bool[] P00698_n29LocationId ;
      private Guid[] P00698_A11OrganisationId ;
      private bool[] P00698_n11OrganisationId ;
      private Guid[] P00698_A329SG_ToPageId ;
      private string[] P00698_A330SG_ToPageName ;
      private string[] P00698_A59ProductServiceName ;
      private string[] P00698_A406TileIconAlignment ;
      private string[] P00698_A405TileTextAlignment ;
      private string[] P00698_A404TileTextColor ;
      private string[] P00698_A403TileBGImageUrl ;
      private bool[] P00698_n403TileBGImageUrl ;
      private string[] P00698_A402TileBGColor ;
      private bool[] P00698_n402TileBGColor ;
      private string[] P00698_A401TileIcon ;
      private bool[] P00698_n401TileIcon ;
      private string[] P00698_A400TileName ;
      private Guid[] P00698_A407TileId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_tilewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00692( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV68Trn_tilewwds_3_tftilename_sel ,
                                             string AV67Trn_tilewwds_2_tftilename ,
                                             string AV70Trn_tilewwds_5_tftileicon_sel ,
                                             string AV69Trn_tilewwds_4_tftileicon ,
                                             string AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                             string AV71Trn_tilewwds_6_tftilebgcolor ,
                                             string AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                             string AV73Trn_tilewwds_8_tftilebgimageurl ,
                                             string AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                             string AV75Trn_tilewwds_10_tftiletextcolor ,
                                             int AV77Trn_tilewwds_12_tftiletextalignment_sels_Count ,
                                             int AV78Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                             string AV79Trn_tilewwds_14_tfproductservicename ,
                                             string AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                             string AV81Trn_tilewwds_16_tfsg_topagename ,
                                             string A400TileName ,
                                             string A401TileIcon ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A59ProductServiceName ,
                                             string A330SG_ToPageName ,
                                             string AV66Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceId, T1.LocationId, T1.OrganisationId, T1.SG_ToPageId AS SG_ToPageId, T1.TileName, T3.Trn_PageName AS SG_ToPageName, T2.ProductServiceName, T1.TileIconAlignment, T1.TileTextAlignment, T1.TileTextColor, T1.TileBGImageUrl, T1.TileBGColor, T1.TileIcon, T1.TileId FROM ((Trn_Tile T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId AND T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T1.SG_ToPageId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T1.TileName like :lV67Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileName = ( :AV68Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon like :lV69Trn_tilewwds_4_tftileicon)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon = ( :AV70Trn_tilewwds_5_tftileicon_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileIcon IS NULL or (char_length(trim(trailing ' ' from T1.TileIcon))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor like :lV71Trn_tilewwds_6_tftilebgcolor)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor = ( :AV72Trn_tilewwds_7_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGColor IS NULL or (char_length(trim(trailing ' ' from T1.TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl like :lV73Trn_tilewwds_8_tftilebgimageurl)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl = ( :AV74Trn_tilewwds_9_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from T1.TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor like :lV75Trn_tilewwds_10_tftiletextcolor)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor = ( :AV76Trn_tilewwds_11_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileTextColor))=0))");
         }
         if ( AV77Trn_tilewwds_12_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Trn_tilewwds_12_tftiletextalignment_sels, "T1.TileTextAlignment IN (", ")")+")");
         }
         if ( AV78Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Trn_tilewwds_13_tftileiconalignment_sels, "T1.TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName like :lV79Trn_tilewwds_14_tfproductservicename)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName = ( :AV80Trn_tilewwds_15_tfproductservicename_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName like :lV81Trn_tilewwds_16_tfsg_topagename)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName = ( :AV82Trn_tilewwds_17_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TileName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00693( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV68Trn_tilewwds_3_tftilename_sel ,
                                             string AV67Trn_tilewwds_2_tftilename ,
                                             string AV70Trn_tilewwds_5_tftileicon_sel ,
                                             string AV69Trn_tilewwds_4_tftileicon ,
                                             string AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                             string AV71Trn_tilewwds_6_tftilebgcolor ,
                                             string AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                             string AV73Trn_tilewwds_8_tftilebgimageurl ,
                                             string AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                             string AV75Trn_tilewwds_10_tftiletextcolor ,
                                             int AV77Trn_tilewwds_12_tftiletextalignment_sels_Count ,
                                             int AV78Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                             string AV79Trn_tilewwds_14_tfproductservicename ,
                                             string AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                             string AV81Trn_tilewwds_16_tfsg_topagename ,
                                             string A400TileName ,
                                             string A401TileIcon ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A59ProductServiceName ,
                                             string A330SG_ToPageName ,
                                             string AV66Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceId, T1.LocationId, T1.OrganisationId, T1.SG_ToPageId AS SG_ToPageId, T1.TileIcon, T3.Trn_PageName AS SG_ToPageName, T2.ProductServiceName, T1.TileIconAlignment, T1.TileTextAlignment, T1.TileTextColor, T1.TileBGImageUrl, T1.TileBGColor, T1.TileName, T1.TileId FROM ((Trn_Tile T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId AND T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T1.SG_ToPageId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T1.TileName like :lV67Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileName = ( :AV68Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon like :lV69Trn_tilewwds_4_tftileicon)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon = ( :AV70Trn_tilewwds_5_tftileicon_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileIcon IS NULL or (char_length(trim(trailing ' ' from T1.TileIcon))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor like :lV71Trn_tilewwds_6_tftilebgcolor)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor = ( :AV72Trn_tilewwds_7_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGColor IS NULL or (char_length(trim(trailing ' ' from T1.TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl like :lV73Trn_tilewwds_8_tftilebgimageurl)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl = ( :AV74Trn_tilewwds_9_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from T1.TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor like :lV75Trn_tilewwds_10_tftiletextcolor)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor = ( :AV76Trn_tilewwds_11_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileTextColor))=0))");
         }
         if ( AV77Trn_tilewwds_12_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Trn_tilewwds_12_tftiletextalignment_sels, "T1.TileTextAlignment IN (", ")")+")");
         }
         if ( AV78Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Trn_tilewwds_13_tftileiconalignment_sels, "T1.TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName like :lV79Trn_tilewwds_14_tfproductservicename)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName = ( :AV80Trn_tilewwds_15_tfproductservicename_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName like :lV81Trn_tilewwds_16_tfsg_topagename)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName = ( :AV82Trn_tilewwds_17_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TileIcon";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00694( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV68Trn_tilewwds_3_tftilename_sel ,
                                             string AV67Trn_tilewwds_2_tftilename ,
                                             string AV70Trn_tilewwds_5_tftileicon_sel ,
                                             string AV69Trn_tilewwds_4_tftileicon ,
                                             string AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                             string AV71Trn_tilewwds_6_tftilebgcolor ,
                                             string AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                             string AV73Trn_tilewwds_8_tftilebgimageurl ,
                                             string AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                             string AV75Trn_tilewwds_10_tftiletextcolor ,
                                             int AV77Trn_tilewwds_12_tftiletextalignment_sels_Count ,
                                             int AV78Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                             string AV79Trn_tilewwds_14_tfproductservicename ,
                                             string AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                             string AV81Trn_tilewwds_16_tfsg_topagename ,
                                             string A400TileName ,
                                             string A401TileIcon ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A59ProductServiceName ,
                                             string A330SG_ToPageName ,
                                             string AV66Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceId, T1.LocationId, T1.OrganisationId, T1.SG_ToPageId AS SG_ToPageId, T1.TileBGColor, T3.Trn_PageName AS SG_ToPageName, T2.ProductServiceName, T1.TileIconAlignment, T1.TileTextAlignment, T1.TileTextColor, T1.TileBGImageUrl, T1.TileIcon, T1.TileName, T1.TileId FROM ((Trn_Tile T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId AND T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T1.SG_ToPageId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T1.TileName like :lV67Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileName = ( :AV68Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon like :lV69Trn_tilewwds_4_tftileicon)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon = ( :AV70Trn_tilewwds_5_tftileicon_sel))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileIcon IS NULL or (char_length(trim(trailing ' ' from T1.TileIcon))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor like :lV71Trn_tilewwds_6_tftilebgcolor)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor = ( :AV72Trn_tilewwds_7_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGColor IS NULL or (char_length(trim(trailing ' ' from T1.TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl like :lV73Trn_tilewwds_8_tftilebgimageurl)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl = ( :AV74Trn_tilewwds_9_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from T1.TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor like :lV75Trn_tilewwds_10_tftiletextcolor)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor = ( :AV76Trn_tilewwds_11_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileTextColor))=0))");
         }
         if ( AV77Trn_tilewwds_12_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Trn_tilewwds_12_tftiletextalignment_sels, "T1.TileTextAlignment IN (", ")")+")");
         }
         if ( AV78Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Trn_tilewwds_13_tftileiconalignment_sels, "T1.TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName like :lV79Trn_tilewwds_14_tfproductservicename)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName = ( :AV80Trn_tilewwds_15_tfproductservicename_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName like :lV81Trn_tilewwds_16_tfsg_topagename)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName = ( :AV82Trn_tilewwds_17_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TileBGColor";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00695( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV68Trn_tilewwds_3_tftilename_sel ,
                                             string AV67Trn_tilewwds_2_tftilename ,
                                             string AV70Trn_tilewwds_5_tftileicon_sel ,
                                             string AV69Trn_tilewwds_4_tftileicon ,
                                             string AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                             string AV71Trn_tilewwds_6_tftilebgcolor ,
                                             string AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                             string AV73Trn_tilewwds_8_tftilebgimageurl ,
                                             string AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                             string AV75Trn_tilewwds_10_tftiletextcolor ,
                                             int AV77Trn_tilewwds_12_tftiletextalignment_sels_Count ,
                                             int AV78Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                             string AV79Trn_tilewwds_14_tfproductservicename ,
                                             string AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                             string AV81Trn_tilewwds_16_tfsg_topagename ,
                                             string A400TileName ,
                                             string A401TileIcon ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A59ProductServiceName ,
                                             string A330SG_ToPageName ,
                                             string AV66Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[14];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceId, T1.LocationId, T1.OrganisationId, T1.SG_ToPageId AS SG_ToPageId, T1.TileBGImageUrl, T3.Trn_PageName AS SG_ToPageName, T2.ProductServiceName, T1.TileIconAlignment, T1.TileTextAlignment, T1.TileTextColor, T1.TileBGColor, T1.TileIcon, T1.TileName, T1.TileId FROM ((Trn_Tile T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId AND T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T1.SG_ToPageId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T1.TileName like :lV67Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileName = ( :AV68Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon like :lV69Trn_tilewwds_4_tftileicon)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon = ( :AV70Trn_tilewwds_5_tftileicon_sel))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileIcon IS NULL or (char_length(trim(trailing ' ' from T1.TileIcon))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor like :lV71Trn_tilewwds_6_tftilebgcolor)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor = ( :AV72Trn_tilewwds_7_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGColor IS NULL or (char_length(trim(trailing ' ' from T1.TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl like :lV73Trn_tilewwds_8_tftilebgimageurl)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl = ( :AV74Trn_tilewwds_9_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from T1.TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor like :lV75Trn_tilewwds_10_tftiletextcolor)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor = ( :AV76Trn_tilewwds_11_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileTextColor))=0))");
         }
         if ( AV77Trn_tilewwds_12_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Trn_tilewwds_12_tftiletextalignment_sels, "T1.TileTextAlignment IN (", ")")+")");
         }
         if ( AV78Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Trn_tilewwds_13_tftileiconalignment_sels, "T1.TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName like :lV79Trn_tilewwds_14_tfproductservicename)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName = ( :AV80Trn_tilewwds_15_tfproductservicename_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName like :lV81Trn_tilewwds_16_tfsg_topagename)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName = ( :AV82Trn_tilewwds_17_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TileBGImageUrl";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00696( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV68Trn_tilewwds_3_tftilename_sel ,
                                             string AV67Trn_tilewwds_2_tftilename ,
                                             string AV70Trn_tilewwds_5_tftileicon_sel ,
                                             string AV69Trn_tilewwds_4_tftileicon ,
                                             string AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                             string AV71Trn_tilewwds_6_tftilebgcolor ,
                                             string AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                             string AV73Trn_tilewwds_8_tftilebgimageurl ,
                                             string AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                             string AV75Trn_tilewwds_10_tftiletextcolor ,
                                             int AV77Trn_tilewwds_12_tftiletextalignment_sels_Count ,
                                             int AV78Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                             string AV79Trn_tilewwds_14_tfproductservicename ,
                                             string AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                             string AV81Trn_tilewwds_16_tfsg_topagename ,
                                             string A400TileName ,
                                             string A401TileIcon ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A59ProductServiceName ,
                                             string A330SG_ToPageName ,
                                             string AV66Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[14];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceId, T1.LocationId, T1.OrganisationId, T1.SG_ToPageId AS SG_ToPageId, T1.TileTextColor, T3.Trn_PageName AS SG_ToPageName, T2.ProductServiceName, T1.TileIconAlignment, T1.TileTextAlignment, T1.TileBGImageUrl, T1.TileBGColor, T1.TileIcon, T1.TileName, T1.TileId FROM ((Trn_Tile T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId AND T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T1.SG_ToPageId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T1.TileName like :lV67Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileName = ( :AV68Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon like :lV69Trn_tilewwds_4_tftileicon)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon = ( :AV70Trn_tilewwds_5_tftileicon_sel))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileIcon IS NULL or (char_length(trim(trailing ' ' from T1.TileIcon))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor like :lV71Trn_tilewwds_6_tftilebgcolor)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor = ( :AV72Trn_tilewwds_7_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGColor IS NULL or (char_length(trim(trailing ' ' from T1.TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl like :lV73Trn_tilewwds_8_tftilebgimageurl)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl = ( :AV74Trn_tilewwds_9_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from T1.TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor like :lV75Trn_tilewwds_10_tftiletextcolor)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor = ( :AV76Trn_tilewwds_11_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileTextColor))=0))");
         }
         if ( AV77Trn_tilewwds_12_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Trn_tilewwds_12_tftiletextalignment_sels, "T1.TileTextAlignment IN (", ")")+")");
         }
         if ( AV78Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Trn_tilewwds_13_tftileiconalignment_sels, "T1.TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName like :lV79Trn_tilewwds_14_tfproductservicename)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName = ( :AV80Trn_tilewwds_15_tfproductservicename_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName like :lV81Trn_tilewwds_16_tfsg_topagename)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName = ( :AV82Trn_tilewwds_17_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TileTextColor";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00697( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV68Trn_tilewwds_3_tftilename_sel ,
                                             string AV67Trn_tilewwds_2_tftilename ,
                                             string AV70Trn_tilewwds_5_tftileicon_sel ,
                                             string AV69Trn_tilewwds_4_tftileicon ,
                                             string AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                             string AV71Trn_tilewwds_6_tftilebgcolor ,
                                             string AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                             string AV73Trn_tilewwds_8_tftilebgimageurl ,
                                             string AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                             string AV75Trn_tilewwds_10_tftiletextcolor ,
                                             int AV77Trn_tilewwds_12_tftiletextalignment_sels_Count ,
                                             int AV78Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                             string AV79Trn_tilewwds_14_tfproductservicename ,
                                             string AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                             string AV81Trn_tilewwds_16_tfsg_topagename ,
                                             string A400TileName ,
                                             string A401TileIcon ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A59ProductServiceName ,
                                             string A330SG_ToPageName ,
                                             string AV66Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[14];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.SG_ToPageId AS SG_ToPageId, T1.OrganisationId, T1.LocationId, T1.ProductServiceId, T2.Trn_PageName AS SG_ToPageName, T3.ProductServiceName, T1.TileIconAlignment, T1.TileTextAlignment, T1.TileTextColor, T1.TileBGImageUrl, T1.TileBGColor, T1.TileIcon, T1.TileName, T1.TileId FROM ((Trn_Tile T1 INNER JOIN Trn_Page T2 ON T2.Trn_PageId = T1.SG_ToPageId) LEFT JOIN Trn_ProductService T3 ON T3.ProductServiceId = T1.ProductServiceId AND T3.LocationId = T1.LocationId AND T3.OrganisationId = T1.OrganisationId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T1.TileName like :lV67Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileName = ( :AV68Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon like :lV69Trn_tilewwds_4_tftileicon)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon = ( :AV70Trn_tilewwds_5_tftileicon_sel))");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileIcon IS NULL or (char_length(trim(trailing ' ' from T1.TileIcon))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor like :lV71Trn_tilewwds_6_tftilebgcolor)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor = ( :AV72Trn_tilewwds_7_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGColor IS NULL or (char_length(trim(trailing ' ' from T1.TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl like :lV73Trn_tilewwds_8_tftilebgimageurl)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl = ( :AV74Trn_tilewwds_9_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from T1.TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor like :lV75Trn_tilewwds_10_tftiletextcolor)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor = ( :AV76Trn_tilewwds_11_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileTextColor))=0))");
         }
         if ( AV77Trn_tilewwds_12_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Trn_tilewwds_12_tftiletextalignment_sels, "T1.TileTextAlignment IN (", ")")+")");
         }
         if ( AV78Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Trn_tilewwds_13_tftileiconalignment_sels, "T1.TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName like :lV79Trn_tilewwds_14_tfproductservicename)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName = ( :AV80Trn_tilewwds_15_tfproductservicename_sel))");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T3.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T2.Trn_PageName like :lV81Trn_tilewwds_16_tfsg_topagename)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.Trn_PageName = ( :AV82Trn_tilewwds_17_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P00698( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV77Trn_tilewwds_12_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV78Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV68Trn_tilewwds_3_tftilename_sel ,
                                             string AV67Trn_tilewwds_2_tftilename ,
                                             string AV70Trn_tilewwds_5_tftileicon_sel ,
                                             string AV69Trn_tilewwds_4_tftileicon ,
                                             string AV72Trn_tilewwds_7_tftilebgcolor_sel ,
                                             string AV71Trn_tilewwds_6_tftilebgcolor ,
                                             string AV74Trn_tilewwds_9_tftilebgimageurl_sel ,
                                             string AV73Trn_tilewwds_8_tftilebgimageurl ,
                                             string AV76Trn_tilewwds_11_tftiletextcolor_sel ,
                                             string AV75Trn_tilewwds_10_tftiletextcolor ,
                                             int AV77Trn_tilewwds_12_tftiletextalignment_sels_Count ,
                                             int AV78Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV80Trn_tilewwds_15_tfproductservicename_sel ,
                                             string AV79Trn_tilewwds_14_tfproductservicename ,
                                             string AV82Trn_tilewwds_17_tfsg_topagename_sel ,
                                             string AV81Trn_tilewwds_16_tfsg_topagename ,
                                             string A400TileName ,
                                             string A401TileIcon ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A59ProductServiceName ,
                                             string A330SG_ToPageName ,
                                             string AV66Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[14];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceId, T1.LocationId, T1.OrganisationId, T1.SG_ToPageId AS SG_ToPageId, T3.Trn_PageName AS SG_ToPageName, T2.ProductServiceName, T1.TileIconAlignment, T1.TileTextAlignment, T1.TileTextColor, T1.TileBGImageUrl, T1.TileBGColor, T1.TileIcon, T1.TileName, T1.TileId FROM ((Trn_Tile T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId AND T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T1.SG_ToPageId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T1.TileName like :lV67Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int13[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileName = ( :AV68Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_tilewwds_3_tftilename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_tilewwds_4_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon like :lV69Trn_tilewwds_4_tftileicon)");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_tilewwds_5_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon = ( :AV70Trn_tilewwds_5_tftileicon_sel))");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_tilewwds_5_tftileicon_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileIcon IS NULL or (char_length(trim(trailing ' ' from T1.TileIcon))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_tilewwds_6_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor like :lV71Trn_tilewwds_6_tftilebgcolor)");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_tilewwds_7_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor = ( :AV72Trn_tilewwds_7_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_tilewwds_7_tftilebgcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGColor IS NULL or (char_length(trim(trailing ' ' from T1.TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_tilewwds_8_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl like :lV73Trn_tilewwds_8_tftilebgimageurl)");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_9_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl = ( :AV74Trn_tilewwds_9_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_tilewwds_9_tftilebgimageurl_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from T1.TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_10_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor like :lV75Trn_tilewwds_10_tftiletextcolor)");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_11_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor = ( :AV76Trn_tilewwds_11_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Trn_tilewwds_11_tftiletextcolor_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileTextColor))=0))");
         }
         if ( AV77Trn_tilewwds_12_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Trn_tilewwds_12_tftiletextalignment_sels, "T1.TileTextAlignment IN (", ")")+")");
         }
         if ( AV78Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Trn_tilewwds_13_tftileiconalignment_sels, "T1.TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_14_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName like :lV79Trn_tilewwds_14_tfproductservicename)");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_15_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName = ( :AV80Trn_tilewwds_15_tfproductservicename_sel))");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Trn_tilewwds_15_tfproductservicename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "(T2.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T2.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_16_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName like :lV81Trn_tilewwds_16_tfsg_topagename)");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_17_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.Trn_PageName = ( :AV82Trn_tilewwds_17_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( StringUtil.StrCmp(AV82Trn_tilewwds_17_tfsg_topagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SG_ToPageId";
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
                     return conditional_P00692(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 1 :
                     return conditional_P00693(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 2 :
                     return conditional_P00694(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 3 :
                     return conditional_P00695(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 4 :
                     return conditional_P00696(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 5 :
                     return conditional_P00697(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 6 :
                     return conditional_P00698(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
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
          Object[] prmP00692;
          prmP00692 = new Object[] {
          new ParDef("lV67Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV68Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_tilewwds_4_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV70Trn_tilewwds_5_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV71Trn_tilewwds_6_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV72Trn_tilewwds_7_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_tilewwds_8_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV74Trn_tilewwds_9_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV75Trn_tilewwds_10_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV76Trn_tilewwds_11_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV79Trn_tilewwds_14_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV80Trn_tilewwds_15_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Trn_tilewwds_16_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV82Trn_tilewwds_17_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00693;
          prmP00693 = new Object[] {
          new ParDef("lV67Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV68Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_tilewwds_4_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV70Trn_tilewwds_5_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV71Trn_tilewwds_6_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV72Trn_tilewwds_7_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_tilewwds_8_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV74Trn_tilewwds_9_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV75Trn_tilewwds_10_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV76Trn_tilewwds_11_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV79Trn_tilewwds_14_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV80Trn_tilewwds_15_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Trn_tilewwds_16_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV82Trn_tilewwds_17_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00694;
          prmP00694 = new Object[] {
          new ParDef("lV67Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV68Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_tilewwds_4_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV70Trn_tilewwds_5_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV71Trn_tilewwds_6_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV72Trn_tilewwds_7_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_tilewwds_8_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV74Trn_tilewwds_9_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV75Trn_tilewwds_10_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV76Trn_tilewwds_11_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV79Trn_tilewwds_14_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV80Trn_tilewwds_15_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Trn_tilewwds_16_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV82Trn_tilewwds_17_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00695;
          prmP00695 = new Object[] {
          new ParDef("lV67Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV68Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_tilewwds_4_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV70Trn_tilewwds_5_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV71Trn_tilewwds_6_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV72Trn_tilewwds_7_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_tilewwds_8_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV74Trn_tilewwds_9_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV75Trn_tilewwds_10_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV76Trn_tilewwds_11_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV79Trn_tilewwds_14_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV80Trn_tilewwds_15_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Trn_tilewwds_16_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV82Trn_tilewwds_17_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00696;
          prmP00696 = new Object[] {
          new ParDef("lV67Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV68Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_tilewwds_4_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV70Trn_tilewwds_5_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV71Trn_tilewwds_6_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV72Trn_tilewwds_7_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_tilewwds_8_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV74Trn_tilewwds_9_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV75Trn_tilewwds_10_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV76Trn_tilewwds_11_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV79Trn_tilewwds_14_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV80Trn_tilewwds_15_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Trn_tilewwds_16_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV82Trn_tilewwds_17_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00697;
          prmP00697 = new Object[] {
          new ParDef("lV67Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV68Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_tilewwds_4_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV70Trn_tilewwds_5_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV71Trn_tilewwds_6_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV72Trn_tilewwds_7_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_tilewwds_8_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV74Trn_tilewwds_9_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV75Trn_tilewwds_10_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV76Trn_tilewwds_11_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV79Trn_tilewwds_14_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV80Trn_tilewwds_15_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Trn_tilewwds_16_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV82Trn_tilewwds_17_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00698;
          prmP00698 = new Object[] {
          new ParDef("lV67Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV68Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Trn_tilewwds_4_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV70Trn_tilewwds_5_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV71Trn_tilewwds_6_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV72Trn_tilewwds_7_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV73Trn_tilewwds_8_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV74Trn_tilewwds_9_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV75Trn_tilewwds_10_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV76Trn_tilewwds_11_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV79Trn_tilewwds_14_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV80Trn_tilewwds_15_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV81Trn_tilewwds_16_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV82Trn_tilewwds_17_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00692", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00692,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00693", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00693,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00694", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00694,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00695", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00695,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00696", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00696,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00697", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00697,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00698", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00698,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((Guid[]) buf[6])[0] = rslt.getGuid(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 20);
                ((string[]) buf[11])[0] = rslt.getString(9, 20);
                ((string[]) buf[12])[0] = rslt.getString(10, 20);
                ((string[]) buf[13])[0] = rslt.getVarchar(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((string[]) buf[15])[0] = rslt.getString(12, 20);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((string[]) buf[17])[0] = rslt.getString(13, 20);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((Guid[]) buf[19])[0] = rslt.getGuid(14);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((Guid[]) buf[6])[0] = rslt.getGuid(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 20);
                ((string[]) buf[12])[0] = rslt.getString(9, 20);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((string[]) buf[14])[0] = rslt.getVarchar(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 20);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((Guid[]) buf[19])[0] = rslt.getGuid(14);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((Guid[]) buf[6])[0] = rslt.getGuid(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 20);
                ((string[]) buf[12])[0] = rslt.getString(9, 20);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((string[]) buf[14])[0] = rslt.getVarchar(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 20);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((Guid[]) buf[19])[0] = rslt.getGuid(14);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((Guid[]) buf[6])[0] = rslt.getGuid(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 20);
                ((string[]) buf[12])[0] = rslt.getString(9, 20);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 20);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((Guid[]) buf[19])[0] = rslt.getGuid(14);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((Guid[]) buf[6])[0] = rslt.getGuid(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 20);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 20);
                ((string[]) buf[11])[0] = rslt.getString(9, 20);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 20);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((Guid[]) buf[19])[0] = rslt.getGuid(14);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((string[]) buf[10])[0] = rslt.getString(8, 20);
                ((string[]) buf[11])[0] = rslt.getString(9, 20);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 20);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((Guid[]) buf[19])[0] = rslt.getGuid(14);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((Guid[]) buf[6])[0] = rslt.getGuid(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((string[]) buf[10])[0] = rslt.getString(8, 20);
                ((string[]) buf[11])[0] = rslt.getString(9, 20);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 20);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((Guid[]) buf[19])[0] = rslt.getGuid(14);
                return;
       }
    }

 }

}
