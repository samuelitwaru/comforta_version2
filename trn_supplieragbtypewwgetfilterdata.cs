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
   public class trn_supplieragbtypewwgetfilterdata : GXProcedure
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
            return "trn_supplieragbtypeww_Services_Execute" ;
         }

      }

      public trn_supplieragbtypewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_supplieragbtypewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_SUPPLIERAGBTYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSUPPLIERAGBTYPENAMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV24Session.Get("Trn_SupplierAgbTypeWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_SupplierAgbTypeWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("Trn_SupplierAgbTypeWWGridState"), null, "", "");
         }
         AV36GXV1 = 1;
         while ( AV36GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV36GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME") == 0 )
            {
               AV11TFSupplierAgbTypeName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFSUPPLIERAGBTYPENAME_SEL") == 0 )
            {
               AV12TFSupplierAgbTypeName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            AV36GXV1 = (int)(AV36GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSUPPLIERAGBTYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFSupplierAgbTypeName = AV13SearchTxt;
         AV12TFSupplierAgbTypeName_Sel = "";
         AV38Trn_supplieragbtypewwds_1_filterfulltext = AV35FilterFullText;
         AV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename = AV11TFSupplierAgbTypeName;
         AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel = AV12TFSupplierAgbTypeName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV38Trn_supplieragbtypewwds_1_filterfulltext ,
                                              AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel ,
                                              AV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename ,
                                              A291SupplierAgbTypeName } ,
                                              new int[]{
                                              }
         });
         lV38Trn_supplieragbtypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV38Trn_supplieragbtypewwds_1_filterfulltext), "%", "");
         lV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename = StringUtil.Concat( StringUtil.RTrim( AV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename), "%", "");
         /* Using cursor P006N2 */
         pr_default.execute(0, new Object[] {lV38Trn_supplieragbtypewwds_1_filterfulltext, lV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename, AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6N2 = false;
            A291SupplierAgbTypeName = P006N2_A291SupplierAgbTypeName[0];
            A283SupplierAgbTypeId = P006N2_A283SupplierAgbTypeId[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006N2_A291SupplierAgbTypeName[0], A291SupplierAgbTypeName) == 0 ) )
            {
               BRK6N2 = false;
               A283SupplierAgbTypeId = P006N2_A283SupplierAgbTypeId[0];
               AV23count = (long)(AV23count+1);
               BRK6N2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A291SupplierAgbTypeName)) ? "<#Empty#>" : A291SupplierAgbTypeName);
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
            if ( ! BRK6N2 )
            {
               BRK6N2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV11TFSupplierAgbTypeName = "";
         AV12TFSupplierAgbTypeName_Sel = "";
         AV38Trn_supplieragbtypewwds_1_filterfulltext = "";
         AV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename = "";
         AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel = "";
         lV38Trn_supplieragbtypewwds_1_filterfulltext = "";
         lV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename = "";
         A291SupplierAgbTypeName = "";
         P006N2_A291SupplierAgbTypeName = new string[] {""} ;
         P006N2_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         A283SupplierAgbTypeId = Guid.Empty;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbtypewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006N2_A291SupplierAgbTypeName, P006N2_A283SupplierAgbTypeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private int AV36GXV1 ;
      private long AV23count ;
      private bool returnInSub ;
      private bool BRK6N2 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV11TFSupplierAgbTypeName ;
      private string AV12TFSupplierAgbTypeName_Sel ;
      private string AV38Trn_supplieragbtypewwds_1_filterfulltext ;
      private string AV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename ;
      private string AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel ;
      private string lV38Trn_supplieragbtypewwds_1_filterfulltext ;
      private string lV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename ;
      private string A291SupplierAgbTypeName ;
      private string AV18Option ;
      private Guid A283SupplierAgbTypeId ;
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
      private string[] P006N2_A291SupplierAgbTypeName ;
      private Guid[] P006N2_A283SupplierAgbTypeId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_supplieragbtypewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006N2( IGxContext context ,
                                             string AV38Trn_supplieragbtypewwds_1_filterfulltext ,
                                             string AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel ,
                                             string AV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename ,
                                             string A291SupplierAgbTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SupplierAgbTypeName, SupplierAgbTypeId FROM Trn_SupplierAgbType";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Trn_supplieragbtypewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SupplierAgbTypeName like '%' || :lV38Trn_supplieragbtypewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename)) ) )
         {
            AddWhere(sWhereString, "(SupplierAgbTypeName like :lV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel)) && ! ( StringUtil.StrCmp(AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SupplierAgbTypeName = ( :AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SupplierAgbTypeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierAgbTypeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006N2;
          prmP006N2 = new Object[] {
          new ParDef("lV38Trn_supplieragbtypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV39Trn_supplieragbtypewwds_2_tfsupplieragbtypename",GXType.VarChar,100,0) ,
          new ParDef("AV40Trn_supplieragbtypewwds_3_tfsupplieragbtypename_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N2,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}