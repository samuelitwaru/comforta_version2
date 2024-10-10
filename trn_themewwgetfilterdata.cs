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
   public class trn_themewwgetfilterdata : GXProcedure
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
            return "trn_themeww_Services_Execute" ;
         }

      }

      public trn_themewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_themewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TRN_THEMENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_THEMENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TRN_THEMEFONTFAMILY") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_THEMEFONTFAMILYOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV24Session.Get("Trn_ThemeWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_ThemeWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("Trn_ThemeWWGridState"), null, "", "");
         }
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_THEMENAME") == 0 )
            {
               AV11TFTrn_ThemeName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_THEMENAME_SEL") == 0 )
            {
               AV12TFTrn_ThemeName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_THEMEFONTFAMILY") == 0 )
            {
               AV36TFTrn_ThemeFontFamily = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_THEMEFONTFAMILY_SEL") == 0 )
            {
               AV37TFTrn_ThemeFontFamily_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRN_THEMENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTrn_ThemeName = AV13SearchTxt;
         AV12TFTrn_ThemeName_Sel = "";
         AV40Trn_themewwds_1_filterfulltext = AV35FilterFullText;
         AV41Trn_themewwds_2_tftrn_themename = AV11TFTrn_ThemeName;
         AV42Trn_themewwds_3_tftrn_themename_sel = AV12TFTrn_ThemeName_Sel;
         AV43Trn_themewwds_4_tftrn_themefontfamily = AV36TFTrn_ThemeFontFamily;
         AV44Trn_themewwds_5_tftrn_themefontfamily_sel = AV37TFTrn_ThemeFontFamily_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Trn_themewwds_1_filterfulltext ,
                                              AV42Trn_themewwds_3_tftrn_themename_sel ,
                                              AV41Trn_themewwds_2_tftrn_themename ,
                                              AV44Trn_themewwds_5_tftrn_themefontfamily_sel ,
                                              AV43Trn_themewwds_4_tftrn_themefontfamily ,
                                              A248Trn_ThemeName ,
                                              A260Trn_ThemeFontFamily } ,
                                              new int[]{
                                              }
         });
         lV40Trn_themewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_themewwds_1_filterfulltext), "%", "");
         lV40Trn_themewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_themewwds_1_filterfulltext), "%", "");
         lV41Trn_themewwds_2_tftrn_themename = StringUtil.Concat( StringUtil.RTrim( AV41Trn_themewwds_2_tftrn_themename), "%", "");
         lV43Trn_themewwds_4_tftrn_themefontfamily = StringUtil.Concat( StringUtil.RTrim( AV43Trn_themewwds_4_tftrn_themefontfamily), "%", "");
         /* Using cursor P005V2 */
         pr_default.execute(0, new Object[] {lV40Trn_themewwds_1_filterfulltext, lV40Trn_themewwds_1_filterfulltext, lV41Trn_themewwds_2_tftrn_themename, AV42Trn_themewwds_3_tftrn_themename_sel, lV43Trn_themewwds_4_tftrn_themefontfamily, AV44Trn_themewwds_5_tftrn_themefontfamily_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5V2 = false;
            A248Trn_ThemeName = P005V2_A248Trn_ThemeName[0];
            A260Trn_ThemeFontFamily = P005V2_A260Trn_ThemeFontFamily[0];
            A247Trn_ThemeId = P005V2_A247Trn_ThemeId[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005V2_A248Trn_ThemeName[0], A248Trn_ThemeName) == 0 ) )
            {
               BRK5V2 = false;
               A247Trn_ThemeId = P005V2_A247Trn_ThemeId[0];
               AV23count = (long)(AV23count+1);
               BRK5V2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A248Trn_ThemeName)) ? "<#Empty#>" : A248Trn_ThemeName);
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
            if ( ! BRK5V2 )
            {
               BRK5V2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTRN_THEMEFONTFAMILYOPTIONS' Routine */
         returnInSub = false;
         AV36TFTrn_ThemeFontFamily = AV13SearchTxt;
         AV37TFTrn_ThemeFontFamily_Sel = "";
         AV40Trn_themewwds_1_filterfulltext = AV35FilterFullText;
         AV41Trn_themewwds_2_tftrn_themename = AV11TFTrn_ThemeName;
         AV42Trn_themewwds_3_tftrn_themename_sel = AV12TFTrn_ThemeName_Sel;
         AV43Trn_themewwds_4_tftrn_themefontfamily = AV36TFTrn_ThemeFontFamily;
         AV44Trn_themewwds_5_tftrn_themefontfamily_sel = AV37TFTrn_ThemeFontFamily_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV40Trn_themewwds_1_filterfulltext ,
                                              AV42Trn_themewwds_3_tftrn_themename_sel ,
                                              AV41Trn_themewwds_2_tftrn_themename ,
                                              AV44Trn_themewwds_5_tftrn_themefontfamily_sel ,
                                              AV43Trn_themewwds_4_tftrn_themefontfamily ,
                                              A248Trn_ThemeName ,
                                              A260Trn_ThemeFontFamily } ,
                                              new int[]{
                                              }
         });
         lV40Trn_themewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_themewwds_1_filterfulltext), "%", "");
         lV40Trn_themewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_themewwds_1_filterfulltext), "%", "");
         lV41Trn_themewwds_2_tftrn_themename = StringUtil.Concat( StringUtil.RTrim( AV41Trn_themewwds_2_tftrn_themename), "%", "");
         lV43Trn_themewwds_4_tftrn_themefontfamily = StringUtil.Concat( StringUtil.RTrim( AV43Trn_themewwds_4_tftrn_themefontfamily), "%", "");
         /* Using cursor P005V3 */
         pr_default.execute(1, new Object[] {lV40Trn_themewwds_1_filterfulltext, lV40Trn_themewwds_1_filterfulltext, lV41Trn_themewwds_2_tftrn_themename, AV42Trn_themewwds_3_tftrn_themename_sel, lV43Trn_themewwds_4_tftrn_themefontfamily, AV44Trn_themewwds_5_tftrn_themefontfamily_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5V4 = false;
            A260Trn_ThemeFontFamily = P005V3_A260Trn_ThemeFontFamily[0];
            A248Trn_ThemeName = P005V3_A248Trn_ThemeName[0];
            A247Trn_ThemeId = P005V3_A247Trn_ThemeId[0];
            AV23count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005V3_A260Trn_ThemeFontFamily[0], A260Trn_ThemeFontFamily) == 0 ) )
            {
               BRK5V4 = false;
               A247Trn_ThemeId = P005V3_A247Trn_ThemeId[0];
               AV23count = (long)(AV23count+1);
               BRK5V4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A260Trn_ThemeFontFamily)) ? "<#Empty#>" : A260Trn_ThemeFontFamily);
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
            if ( ! BRK5V4 )
            {
               BRK5V4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV11TFTrn_ThemeName = "";
         AV12TFTrn_ThemeName_Sel = "";
         AV36TFTrn_ThemeFontFamily = "";
         AV37TFTrn_ThemeFontFamily_Sel = "";
         AV40Trn_themewwds_1_filterfulltext = "";
         AV41Trn_themewwds_2_tftrn_themename = "";
         AV42Trn_themewwds_3_tftrn_themename_sel = "";
         AV43Trn_themewwds_4_tftrn_themefontfamily = "";
         AV44Trn_themewwds_5_tftrn_themefontfamily_sel = "";
         lV40Trn_themewwds_1_filterfulltext = "";
         lV41Trn_themewwds_2_tftrn_themename = "";
         lV43Trn_themewwds_4_tftrn_themefontfamily = "";
         A248Trn_ThemeName = "";
         A260Trn_ThemeFontFamily = "";
         P005V2_A248Trn_ThemeName = new string[] {""} ;
         P005V2_A260Trn_ThemeFontFamily = new string[] {""} ;
         P005V2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A247Trn_ThemeId = Guid.Empty;
         AV18Option = "";
         P005V3_A260Trn_ThemeFontFamily = new string[] {""} ;
         P005V3_A248Trn_ThemeName = new string[] {""} ;
         P005V3_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_themewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005V2_A248Trn_ThemeName, P005V2_A260Trn_ThemeFontFamily, P005V2_A247Trn_ThemeId
               }
               , new Object[] {
               P005V3_A260Trn_ThemeFontFamily, P005V3_A248Trn_ThemeName, P005V3_A247Trn_ThemeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private int AV38GXV1 ;
      private long AV23count ;
      private bool returnInSub ;
      private bool BRK5V2 ;
      private bool BRK5V4 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV11TFTrn_ThemeName ;
      private string AV12TFTrn_ThemeName_Sel ;
      private string AV36TFTrn_ThemeFontFamily ;
      private string AV37TFTrn_ThemeFontFamily_Sel ;
      private string AV40Trn_themewwds_1_filterfulltext ;
      private string AV41Trn_themewwds_2_tftrn_themename ;
      private string AV42Trn_themewwds_3_tftrn_themename_sel ;
      private string AV43Trn_themewwds_4_tftrn_themefontfamily ;
      private string AV44Trn_themewwds_5_tftrn_themefontfamily_sel ;
      private string lV40Trn_themewwds_1_filterfulltext ;
      private string lV41Trn_themewwds_2_tftrn_themename ;
      private string lV43Trn_themewwds_4_tftrn_themefontfamily ;
      private string A248Trn_ThemeName ;
      private string A260Trn_ThemeFontFamily ;
      private string AV18Option ;
      private Guid A247Trn_ThemeId ;
      private IGxSession AV24Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV21OptionsDesc ;
      private GxSimpleCollection<string> AV22OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV26GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P005V2_A248Trn_ThemeName ;
      private string[] P005V2_A260Trn_ThemeFontFamily ;
      private Guid[] P005V2_A247Trn_ThemeId ;
      private string[] P005V3_A260Trn_ThemeFontFamily ;
      private string[] P005V3_A248Trn_ThemeName ;
      private Guid[] P005V3_A247Trn_ThemeId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_themewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005V2( IGxContext context ,
                                             string AV40Trn_themewwds_1_filterfulltext ,
                                             string AV42Trn_themewwds_3_tftrn_themename_sel ,
                                             string AV41Trn_themewwds_2_tftrn_themename ,
                                             string AV44Trn_themewwds_5_tftrn_themefontfamily_sel ,
                                             string AV43Trn_themewwds_4_tftrn_themefontfamily ,
                                             string A248Trn_ThemeName ,
                                             string A260Trn_ThemeFontFamily )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeId FROM Trn_Theme";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Trn_themewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Trn_ThemeName like '%' || :lV40Trn_themewwds_1_filterfulltext) or ( Trn_ThemeFontFamily like '%' || :lV40Trn_themewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_themewwds_3_tftrn_themename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_themewwds_2_tftrn_themename)) ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeName like :lV41Trn_themewwds_2_tftrn_themename)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_themewwds_3_tftrn_themename_sel)) && ! ( StringUtil.StrCmp(AV42Trn_themewwds_3_tftrn_themename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeName = ( :AV42Trn_themewwds_3_tftrn_themename_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Trn_themewwds_3_tftrn_themename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_ThemeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_themewwds_5_tftrn_themefontfamily_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_themewwds_4_tftrn_themefontfamily)) ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontFamily like :lV43Trn_themewwds_4_tftrn_themefontfamily)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_themewwds_5_tftrn_themefontfamily_sel)) && ! ( StringUtil.StrCmp(AV44Trn_themewwds_5_tftrn_themefontfamily_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontFamily = ( :AV44Trn_themewwds_5_tftrn_themefontfamily_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_themewwds_5_tftrn_themefontfamily_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_ThemeFontFamily))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_ThemeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005V3( IGxContext context ,
                                             string AV40Trn_themewwds_1_filterfulltext ,
                                             string AV42Trn_themewwds_3_tftrn_themename_sel ,
                                             string AV41Trn_themewwds_2_tftrn_themename ,
                                             string AV44Trn_themewwds_5_tftrn_themefontfamily_sel ,
                                             string AV43Trn_themewwds_4_tftrn_themefontfamily ,
                                             string A248Trn_ThemeName ,
                                             string A260Trn_ThemeFontFamily )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT Trn_ThemeFontFamily, Trn_ThemeName, Trn_ThemeId FROM Trn_Theme";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Trn_themewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Trn_ThemeName like '%' || :lV40Trn_themewwds_1_filterfulltext) or ( Trn_ThemeFontFamily like '%' || :lV40Trn_themewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_themewwds_3_tftrn_themename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_themewwds_2_tftrn_themename)) ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeName like :lV41Trn_themewwds_2_tftrn_themename)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_themewwds_3_tftrn_themename_sel)) && ! ( StringUtil.StrCmp(AV42Trn_themewwds_3_tftrn_themename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeName = ( :AV42Trn_themewwds_3_tftrn_themename_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Trn_themewwds_3_tftrn_themename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_ThemeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_themewwds_5_tftrn_themefontfamily_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_themewwds_4_tftrn_themefontfamily)) ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontFamily like :lV43Trn_themewwds_4_tftrn_themefontfamily)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_themewwds_5_tftrn_themefontfamily_sel)) && ! ( StringUtil.StrCmp(AV44Trn_themewwds_5_tftrn_themefontfamily_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_ThemeFontFamily = ( :AV44Trn_themewwds_5_tftrn_themefontfamily_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_themewwds_5_tftrn_themefontfamily_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_ThemeFontFamily))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_ThemeFontFamily";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P005V2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P005V3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005V2;
          prmP005V2 = new Object[] {
          new ParDef("lV40Trn_themewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Trn_themewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_themewwds_2_tftrn_themename",GXType.VarChar,100,0) ,
          new ParDef("AV42Trn_themewwds_3_tftrn_themename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_themewwds_4_tftrn_themefontfamily",GXType.VarChar,40,0) ,
          new ParDef("AV44Trn_themewwds_5_tftrn_themefontfamily_sel",GXType.VarChar,40,0)
          };
          Object[] prmP005V3;
          prmP005V3 = new Object[] {
          new ParDef("lV40Trn_themewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Trn_themewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_themewwds_2_tftrn_themename",GXType.VarChar,100,0) ,
          new ParDef("AV42Trn_themewwds_3_tftrn_themename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_themewwds_4_tftrn_themefontfamily",GXType.VarChar,40,0) ,
          new ParDef("AV44Trn_themewwds_5_tftrn_themefontfamily_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005V2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005V3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
