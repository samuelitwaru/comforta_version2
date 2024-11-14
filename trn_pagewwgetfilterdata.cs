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
   public class trn_pagewwgetfilterdata : GXProcedure
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
            return "trn_pageww_Services_Execute" ;
         }

      }

      public trn_pagewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_pagewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_TRN_PAGENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRN_PAGENAMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV24Session.Get("Trn_PageWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Trn_PageWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("Trn_PageWWGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_PAGENAME") == 0 )
            {
               AV11TFTrn_PageName = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFTRN_PAGENAME_SEL") == 0 )
            {
               AV12TFTrn_PageName_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPAGEISCONTENTPAGE_SEL") == 0 )
            {
               AV42TFPageIsContentPage_Sel = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRN_PAGENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFTrn_PageName = AV13SearchTxt;
         AV12TFTrn_PageName_Sel = "";
         AV45Trn_pagewwds_1_filterfulltext = AV35FilterFullText;
         AV46Trn_pagewwds_2_tftrn_pagename = AV11TFTrn_PageName;
         AV47Trn_pagewwds_3_tftrn_pagename_sel = AV12TFTrn_PageName_Sel;
         AV48Trn_pagewwds_4_tfpageiscontentpage_sel = AV42TFPageIsContentPage_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47Trn_pagewwds_3_tftrn_pagename_sel ,
                                              AV46Trn_pagewwds_2_tftrn_pagename ,
                                              AV48Trn_pagewwds_4_tfpageiscontentpage_sel ,
                                              A318Trn_PageName ,
                                              A439PageIsContentPage ,
                                              AV45Trn_pagewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV46Trn_pagewwds_2_tftrn_pagename = StringUtil.Concat( StringUtil.RTrim( AV46Trn_pagewwds_2_tftrn_pagename), "%", "");
         /* Using cursor P006Y2 */
         pr_default.execute(0, new Object[] {lV46Trn_pagewwds_2_tftrn_pagename, AV47Trn_pagewwds_3_tftrn_pagename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6Y2 = false;
            A318Trn_PageName = P006Y2_A318Trn_PageName[0];
            A439PageIsContentPage = P006Y2_A439PageIsContentPage[0];
            A310Trn_PageId = P006Y2_A310Trn_PageId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Trn_pagewwds_1_filterfulltext)) || ( ( StringUtil.Like( A318Trn_PageName , StringUtil.PadR( "%" + AV45Trn_pagewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "true", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A439PageIsContentPage ) ) || ( StringUtil.Like( context.GetMessage( context.GetMessage( "false", ""), "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45Trn_pagewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A439PageIsContentPage ) ) )
            {
               AV23count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006Y2_A318Trn_PageName[0], A318Trn_PageName) == 0 ) )
               {
                  BRK6Y2 = false;
                  A310Trn_PageId = P006Y2_A310Trn_PageId[0];
                  AV23count = (long)(AV23count+1);
                  BRK6Y2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV14SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A318Trn_PageName)) ? "<#Empty#>" : A318Trn_PageName);
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
            if ( ! BRK6Y2 )
            {
               BRK6Y2 = true;
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
         AV11TFTrn_PageName = "";
         AV12TFTrn_PageName_Sel = "";
         AV45Trn_pagewwds_1_filterfulltext = "";
         AV46Trn_pagewwds_2_tftrn_pagename = "";
         AV47Trn_pagewwds_3_tftrn_pagename_sel = "";
         lV46Trn_pagewwds_2_tftrn_pagename = "";
         A318Trn_PageName = "";
         P006Y2_A318Trn_PageName = new string[] {""} ;
         P006Y2_A439PageIsContentPage = new bool[] {false} ;
         P006Y2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         A310Trn_PageId = Guid.Empty;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_pagewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006Y2_A318Trn_PageName, P006Y2_A439PageIsContentPage, P006Y2_A310Trn_PageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV42TFPageIsContentPage_Sel ;
      private short AV48Trn_pagewwds_4_tfpageiscontentpage_sel ;
      private int AV43GXV1 ;
      private long AV23count ;
      private bool returnInSub ;
      private bool A439PageIsContentPage ;
      private bool BRK6Y2 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV11TFTrn_PageName ;
      private string AV12TFTrn_PageName_Sel ;
      private string AV45Trn_pagewwds_1_filterfulltext ;
      private string AV46Trn_pagewwds_2_tftrn_pagename ;
      private string AV47Trn_pagewwds_3_tftrn_pagename_sel ;
      private string lV46Trn_pagewwds_2_tftrn_pagename ;
      private string A318Trn_PageName ;
      private string AV18Option ;
      private Guid A310Trn_PageId ;
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
      private string[] P006Y2_A318Trn_PageName ;
      private bool[] P006Y2_A439PageIsContentPage ;
      private Guid[] P006Y2_A310Trn_PageId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trn_pagewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006Y2( IGxContext context ,
                                             string AV47Trn_pagewwds_3_tftrn_pagename_sel ,
                                             string AV46Trn_pagewwds_2_tftrn_pagename ,
                                             short AV48Trn_pagewwds_4_tfpageiscontentpage_sel ,
                                             string A318Trn_PageName ,
                                             bool A439PageIsContentPage ,
                                             string AV45Trn_pagewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_PageName, PageIsContentPage, Trn_PageId FROM Trn_Page";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_pagewwds_3_tftrn_pagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trn_pagewwds_2_tftrn_pagename)) ) )
         {
            AddWhere(sWhereString, "(Trn_PageName like :lV46Trn_pagewwds_2_tftrn_pagename)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Trn_pagewwds_3_tftrn_pagename_sel)) && ! ( StringUtil.StrCmp(AV47Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(Trn_PageName = ( :AV47Trn_pagewwds_3_tftrn_pagename_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV47Trn_pagewwds_3_tftrn_pagename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from Trn_PageName))=0))");
         }
         if ( AV48Trn_pagewwds_4_tfpageiscontentpage_sel == 1 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = TRUE)");
         }
         if ( AV48Trn_pagewwds_4_tfpageiscontentpage_sel == 2 )
         {
            AddWhere(sWhereString, "(PageIsContentPage = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_PageName";
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
                     return conditional_P006Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] );
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
          Object[] prmP006Y2;
          prmP006Y2 = new Object[] {
          new ParDef("lV46Trn_pagewwds_2_tftrn_pagename",GXType.VarChar,100,0) ,
          new ParDef("AV47Trn_pagewwds_3_tftrn_pagename_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
