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
   public class trn_mediawwgetfilterdata : GXProcedure
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
            return "trn_mediaww_Services_Execute" ;
         }

      }

      public trn_mediawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_mediawwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_TRN_MEDIANAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_MEDIANAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_TRN_MEDIAURL") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_MEDIAURLOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV26Session.Get("Trn_MediaWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_MediaWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Trn_MediaWWGridState"), null, "", "");
         }
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTRN_MEDIANAME") == 0 )
            {
               AV11TFTrn_MediaName = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTRN_MEDIANAME_SEL") == 0 )
            {
               AV12TFTrn_MediaName_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTRN_MEDIAURL") == 0 )
            {
               AV13TFTrn_MediaUrl = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFTRN_MEDIAURL_SEL") == 0 )
            {
               AV14TFTrn_MediaUrl_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRN_MEDIANAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTrn_MediaName = AV15SearchTxt;
         AV12TFTrn_MediaName_Sel = "";
         AV40Trn_mediawwds_1_filterfulltext = AV37FilterFullText;
         AV41Trn_mediawwds_2_tftrn_medianame = AV11TFTrn_MediaName;
         AV42Trn_mediawwds_3_tftrn_medianame_sel = AV12TFTrn_MediaName_Sel;
         AV43Trn_mediawwds_4_tftrn_mediaurl = AV13TFTrn_MediaUrl;
         AV44Trn_mediawwds_5_tftrn_mediaurl_sel = AV14TFTrn_MediaUrl_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Trn_mediawwds_1_filterfulltext ,
                                              AV42Trn_mediawwds_3_tftrn_medianame_sel ,
                                              AV41Trn_mediawwds_2_tftrn_medianame ,
                                              AV44Trn_mediawwds_5_tftrn_mediaurl_sel ,
                                              AV43Trn_mediawwds_4_tftrn_mediaurl ,
                                              A253Trn_MediaName ,
                                              A254Trn_MediaUrl } ,
                                              new int[]{
                                              }
         });
         lV40Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_mediawwds_1_filterfulltext), "%", "");
         lV40Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_mediawwds_1_filterfulltext), "%", "");
         lV41Trn_mediawwds_2_tftrn_medianame = StringUtil.Concat( StringUtil.RTrim( AV41Trn_mediawwds_2_tftrn_medianame), "%", "");
         lV43Trn_mediawwds_4_tftrn_mediaurl = StringUtil.Concat( StringUtil.RTrim( AV43Trn_mediawwds_4_tftrn_mediaurl), "%", "");
         /* Using cursor P005W2 */
         pr_default.execute(0, new Object[] {lV40Trn_mediawwds_1_filterfulltext, lV40Trn_mediawwds_1_filterfulltext, lV41Trn_mediawwds_2_tftrn_medianame, AV42Trn_mediawwds_3_tftrn_medianame_sel, lV43Trn_mediawwds_4_tftrn_mediaurl, AV44Trn_mediawwds_5_tftrn_mediaurl_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5W2 = false;
            A253Trn_MediaName = P005W2_A253Trn_MediaName[0];
            A254Trn_MediaUrl = P005W2_A254Trn_MediaUrl[0];
            A252Trn_MediaId = P005W2_A252Trn_MediaId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005W2_A253Trn_MediaName[0], A253Trn_MediaName) == 0 ) )
            {
               BRK5W2 = false;
               A252Trn_MediaId = P005W2_A252Trn_MediaId[0];
               AV25count = (long)(AV25count+1);
               BRK5W2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A253Trn_MediaName)) ? "<#Empty#>" : A253Trn_MediaName);
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
            if ( ! BRK5W2 )
            {
               BRK5W2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTRN_MEDIAURLOPTIONS' Routine */
         returnInSub = false;
         AV13TFTrn_MediaUrl = AV15SearchTxt;
         AV14TFTrn_MediaUrl_Sel = "";
         AV40Trn_mediawwds_1_filterfulltext = AV37FilterFullText;
         AV41Trn_mediawwds_2_tftrn_medianame = AV11TFTrn_MediaName;
         AV42Trn_mediawwds_3_tftrn_medianame_sel = AV12TFTrn_MediaName_Sel;
         AV43Trn_mediawwds_4_tftrn_mediaurl = AV13TFTrn_MediaUrl;
         AV44Trn_mediawwds_5_tftrn_mediaurl_sel = AV14TFTrn_MediaUrl_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV40Trn_mediawwds_1_filterfulltext ,
                                              AV42Trn_mediawwds_3_tftrn_medianame_sel ,
                                              AV41Trn_mediawwds_2_tftrn_medianame ,
                                              AV44Trn_mediawwds_5_tftrn_mediaurl_sel ,
                                              AV43Trn_mediawwds_4_tftrn_mediaurl ,
                                              A253Trn_MediaName ,
                                              A254Trn_MediaUrl } ,
                                              new int[]{
                                              }
         });
         lV40Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_mediawwds_1_filterfulltext), "%", "");
         lV40Trn_mediawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Trn_mediawwds_1_filterfulltext), "%", "");
         lV41Trn_mediawwds_2_tftrn_medianame = StringUtil.Concat( StringUtil.RTrim( AV41Trn_mediawwds_2_tftrn_medianame), "%", "");
         lV43Trn_mediawwds_4_tftrn_mediaurl = StringUtil.Concat( StringUtil.RTrim( AV43Trn_mediawwds_4_tftrn_mediaurl), "%", "");
         /* Using cursor P005W3 */
         pr_default.execute(1, new Object[] {lV40Trn_mediawwds_1_filterfulltext, lV40Trn_mediawwds_1_filterfulltext, lV41Trn_mediawwds_2_tftrn_medianame, AV42Trn_mediawwds_3_tftrn_medianame_sel, lV43Trn_mediawwds_4_tftrn_mediaurl, AV44Trn_mediawwds_5_tftrn_mediaurl_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5W4 = false;
            A254Trn_MediaUrl = P005W3_A254Trn_MediaUrl[0];
            A253Trn_MediaName = P005W3_A253Trn_MediaName[0];
            A252Trn_MediaId = P005W3_A252Trn_MediaId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005W3_A254Trn_MediaUrl[0], A254Trn_MediaUrl) == 0 ) )
            {
               BRK5W4 = false;
               A252Trn_MediaId = P005W3_A252Trn_MediaId[0];
               AV25count = (long)(AV25count+1);
               BRK5W4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A254Trn_MediaUrl)) ? "<#Empty#>" : A254Trn_MediaUrl);
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
            if ( ! BRK5W4 )
            {
               BRK5W4 = true;
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
         AV11TFTrn_MediaName = "";
         AV12TFTrn_MediaName_Sel = "";
         AV13TFTrn_MediaUrl = "";
         AV14TFTrn_MediaUrl_Sel = "";
         AV40Trn_mediawwds_1_filterfulltext = "";
         AV41Trn_mediawwds_2_tftrn_medianame = "";
         AV42Trn_mediawwds_3_tftrn_medianame_sel = "";
         AV43Trn_mediawwds_4_tftrn_mediaurl = "";
         AV44Trn_mediawwds_5_tftrn_mediaurl_sel = "";
         lV40Trn_mediawwds_1_filterfulltext = "";
         lV41Trn_mediawwds_2_tftrn_medianame = "";
         lV43Trn_mediawwds_4_tftrn_mediaurl = "";
         A253Trn_MediaName = "";
         A254Trn_MediaUrl = "";
         P005W2_A253Trn_MediaName = new string[] {""} ;
         P005W2_A254Trn_MediaUrl = new string[] {""} ;
         P005W2_A252Trn_MediaId = new Guid[] {Guid.Empty} ;
         A252Trn_MediaId = Guid.Empty;
         AV20Option = "";
         P005W3_A254Trn_MediaUrl = new string[] {""} ;
         P005W3_A253Trn_MediaName = new string[] {""} ;
         P005W3_A252Trn_MediaId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_mediawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005W2_A253Trn_MediaName, P005W2_A254Trn_MediaUrl, P005W2_A252Trn_MediaId
               }
               , new Object[] {
               P005W3_A254Trn_MediaUrl, P005W3_A253Trn_MediaName, P005W3_A252Trn_MediaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV38GXV1 ;
      private long AV25count ;
      private bool returnInSub ;
      private bool BRK5W2 ;
      private bool BRK5W4 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFTrn_MediaName ;
      private string AV12TFTrn_MediaName_Sel ;
      private string AV13TFTrn_MediaUrl ;
      private string AV14TFTrn_MediaUrl_Sel ;
      private string AV40Trn_mediawwds_1_filterfulltext ;
      private string AV41Trn_mediawwds_2_tftrn_medianame ;
      private string AV42Trn_mediawwds_3_tftrn_medianame_sel ;
      private string AV43Trn_mediawwds_4_tftrn_mediaurl ;
      private string AV44Trn_mediawwds_5_tftrn_mediaurl_sel ;
      private string lV40Trn_mediawwds_1_filterfulltext ;
      private string lV41Trn_mediawwds_2_tftrn_medianame ;
      private string lV43Trn_mediawwds_4_tftrn_mediaurl ;
      private string A253Trn_MediaName ;
      private string A254Trn_MediaUrl ;
      private string AV20Option ;
      private Guid A252Trn_MediaId ;
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
      private string[] P005W2_A253Trn_MediaName ;
      private string[] P005W2_A254Trn_MediaUrl ;
      private Guid[] P005W2_A252Trn_MediaId ;
      private string[] P005W3_A254Trn_MediaUrl ;
      private string[] P005W3_A253Trn_MediaName ;
      private Guid[] P005W3_A252Trn_MediaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_mediawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005W2( IGxContext context ,
                                             string AV40Trn_mediawwds_1_filterfulltext ,
                                             string AV42Trn_mediawwds_3_tftrn_medianame_sel ,
                                             string AV41Trn_mediawwds_2_tftrn_medianame ,
                                             string AV44Trn_mediawwds_5_tftrn_mediaurl_sel ,
                                             string AV43Trn_mediawwds_4_tftrn_mediaurl ,
                                             string A253Trn_MediaName ,
                                             string A254Trn_MediaUrl )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_MediaName, Trn_MediaUrl, Trn_MediaId FROM Trn_Media";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Trn_mediawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Trn_MediaName like '%' || :lV40Trn_mediawwds_1_filterfulltext) or ( Trn_MediaUrl like '%' || :lV40Trn_mediawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_mediawwds_3_tftrn_medianame_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_mediawwds_2_tftrn_medianame)) ) )
         {
            AddWhere(sWhereString, "(Trn_MediaName like :lV41Trn_mediawwds_2_tftrn_medianame)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_mediawwds_3_tftrn_medianame_sel)) && ! ( StringUtil.StrCmp(AV42Trn_mediawwds_3_tftrn_medianame_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_MediaName = ( :AV42Trn_mediawwds_3_tftrn_medianame_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Trn_mediawwds_3_tftrn_medianame_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_MediaName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_mediawwds_5_tftrn_mediaurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_mediawwds_4_tftrn_mediaurl)) ) )
         {
            AddWhere(sWhereString, "(Trn_MediaUrl like :lV43Trn_mediawwds_4_tftrn_mediaurl)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_mediawwds_5_tftrn_mediaurl_sel)) && ! ( StringUtil.StrCmp(AV44Trn_mediawwds_5_tftrn_mediaurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_MediaUrl = ( :AV44Trn_mediawwds_5_tftrn_mediaurl_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_mediawwds_5_tftrn_mediaurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_MediaUrl))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_MediaName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005W3( IGxContext context ,
                                             string AV40Trn_mediawwds_1_filterfulltext ,
                                             string AV42Trn_mediawwds_3_tftrn_medianame_sel ,
                                             string AV41Trn_mediawwds_2_tftrn_medianame ,
                                             string AV44Trn_mediawwds_5_tftrn_mediaurl_sel ,
                                             string AV43Trn_mediawwds_4_tftrn_mediaurl ,
                                             string A253Trn_MediaName ,
                                             string A254Trn_MediaUrl )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT Trn_MediaUrl, Trn_MediaName, Trn_MediaId FROM Trn_Media";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Trn_mediawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( Trn_MediaName like '%' || :lV40Trn_mediawwds_1_filterfulltext) or ( Trn_MediaUrl like '%' || :lV40Trn_mediawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_mediawwds_3_tftrn_medianame_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Trn_mediawwds_2_tftrn_medianame)) ) )
         {
            AddWhere(sWhereString, "(Trn_MediaName like :lV41Trn_mediawwds_2_tftrn_medianame)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trn_mediawwds_3_tftrn_medianame_sel)) && ! ( StringUtil.StrCmp(AV42Trn_mediawwds_3_tftrn_medianame_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_MediaName = ( :AV42Trn_mediawwds_3_tftrn_medianame_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Trn_mediawwds_3_tftrn_medianame_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_MediaName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_mediawwds_5_tftrn_mediaurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Trn_mediawwds_4_tftrn_mediaurl)) ) )
         {
            AddWhere(sWhereString, "(Trn_MediaUrl like :lV43Trn_mediawwds_4_tftrn_mediaurl)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Trn_mediawwds_5_tftrn_mediaurl_sel)) && ! ( StringUtil.StrCmp(AV44Trn_mediawwds_5_tftrn_mediaurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_MediaUrl = ( :AV44Trn_mediawwds_5_tftrn_mediaurl_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Trn_mediawwds_5_tftrn_mediaurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_MediaUrl))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_MediaUrl";
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
                     return conditional_P005W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P005W3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
          Object[] prmP005W2;
          prmP005W2 = new Object[] {
          new ParDef("lV40Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_mediawwds_2_tftrn_medianame",GXType.VarChar,100,0) ,
          new ParDef("AV42Trn_mediawwds_3_tftrn_medianame_sel",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_mediawwds_4_tftrn_mediaurl",GXType.VarChar,1000,0) ,
          new ParDef("AV44Trn_mediawwds_5_tftrn_mediaurl_sel",GXType.VarChar,1000,0)
          };
          Object[] prmP005W3;
          prmP005W3 = new Object[] {
          new ParDef("lV40Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Trn_mediawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Trn_mediawwds_2_tftrn_medianame",GXType.VarChar,100,0) ,
          new ParDef("AV42Trn_mediawwds_3_tftrn_medianame_sel",GXType.VarChar,100,0) ,
          new ParDef("lV43Trn_mediawwds_4_tftrn_mediaurl",GXType.VarChar,1000,0) ,
          new ParDef("AV44Trn_mediawwds_5_tftrn_mediaurl_sel",GXType.VarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W3,100, GxCacheFrequency.OFF ,true,false )
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
