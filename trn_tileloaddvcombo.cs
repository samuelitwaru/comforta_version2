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
   public class trn_tileloaddvcombo : GXProcedure
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
            return "trn_page_Services_Execute" ;
         }

      }

      public trn_tileloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_tileloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_Trn_TileId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20Trn_TileId = aP3_Trn_TileId;
         this.AV21SearchTxtParms = aP4_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_Trn_TileId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_Trn_TileId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_Trn_TileId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20Trn_TileId = aP3_Trn_TileId;
         this.AV21SearchTxtParms = aP4_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         SubmitImpl();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV21SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV21SearchTxtParms : StringUtil.Substring( AV21SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "ProductServiceId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PRODUCTSERVICEID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SG_ToPageId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SG_TOPAGEID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_PRODUCTSERVICEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A59ProductServiceName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006A2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A59ProductServiceName = P006A2_A59ProductServiceName[0];
               A58ProductServiceId = P006A2_A58ProductServiceId[0];
               n58ProductServiceId = P006A2_n58ProductServiceId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A58ProductServiceId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A59ProductServiceName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P006A3 */
                  pr_default.execute(1, new Object[] {AV20Trn_TileId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A264Trn_TileId = P006A3_A264Trn_TileId[0];
                     A58ProductServiceId = P006A3_A58ProductServiceId[0];
                     n58ProductServiceId = P006A3_n58ProductServiceId[0];
                     A59ProductServiceName = P006A3_A59ProductServiceName[0];
                     A59ProductServiceName = P006A3_A59ProductServiceName[0];
                     AV22SelectedValue = ((Guid.Empty==A58ProductServiceId) ? "" : StringUtil.Trim( A58ProductServiceId.ToString()));
                     AV23SelectedText = A59ProductServiceName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV32ProductServiceId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P006A4 */
                  pr_default.execute(2, new Object[] {AV32ProductServiceId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A58ProductServiceId = P006A4_A58ProductServiceId[0];
                     n58ProductServiceId = P006A4_n58ProductServiceId[0];
                     A59ProductServiceName = P006A4_A59ProductServiceName[0];
                     AV23SelectedText = A59ProductServiceName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_SG_TOPAGEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom5 = AV12SkipItems;
            GXPagingTo5 = AV11MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A318Trn_PageName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006A5 */
            pr_default.execute(3, new Object[] {lV14SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A318Trn_PageName = P006A5_A318Trn_PageName[0];
               A310Trn_PageId = P006A5_A310Trn_PageId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A310Trn_PageId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A318Trn_PageName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P006A6 */
                  pr_default.execute(4, new Object[] {AV20Trn_TileId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A264Trn_TileId = P006A6_A264Trn_TileId[0];
                     A329SG_ToPageId = P006A6_A329SG_ToPageId[0];
                     AV22SelectedValue = ((Guid.Empty==A329SG_ToPageId) ? "" : StringUtil.Trim( A329SG_ToPageId.ToString()));
                     AV34Trn_PageId = A329SG_ToPageId;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV34Trn_PageId = StringUtil.StrToGuid( AV14SearchTxt);
               }
               /* Using cursor P006A7 */
               pr_default.execute(5, new Object[] {AV34Trn_PageId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A310Trn_PageId = P006A7_A310Trn_PageId[0];
                  A318Trn_PageName = P006A7_A318Trn_PageName[0];
                  AV23SelectedText = A318Trn_PageName;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(5);
            }
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
         AV22SelectedValue = "";
         AV23SelectedText = "";
         AV24Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         lV14SearchTxt = "";
         A59ProductServiceName = "";
         P006A2_A59ProductServiceName = new string[] {""} ;
         P006A2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006A2_n58ProductServiceId = new bool[] {false} ;
         A58ProductServiceId = Guid.Empty;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P006A3_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         P006A3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006A3_n58ProductServiceId = new bool[] {false} ;
         P006A3_A59ProductServiceName = new string[] {""} ;
         A264Trn_TileId = Guid.Empty;
         AV32ProductServiceId = Guid.Empty;
         P006A4_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P006A4_n58ProductServiceId = new bool[] {false} ;
         P006A4_A59ProductServiceName = new string[] {""} ;
         A318Trn_PageName = "";
         P006A5_A318Trn_PageName = new string[] {""} ;
         P006A5_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         A310Trn_PageId = Guid.Empty;
         P006A6_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         P006A6_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         A329SG_ToPageId = Guid.Empty;
         AV34Trn_PageId = Guid.Empty;
         P006A7_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P006A7_A318Trn_PageName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tileloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006A2_A59ProductServiceName, P006A2_A58ProductServiceId
               }
               , new Object[] {
               P006A3_A264Trn_TileId, P006A3_A58ProductServiceId, P006A3_n58ProductServiceId, P006A3_A59ProductServiceName
               }
               , new Object[] {
               P006A4_A58ProductServiceId, P006A4_A59ProductServiceName
               }
               , new Object[] {
               P006A5_A318Trn_PageName, P006A5_A310Trn_PageId
               }
               , new Object[] {
               P006A6_A264Trn_TileId, P006A6_A329SG_ToPageId
               }
               , new Object[] {
               P006A7_A310Trn_PageId, P006A7_A318Trn_PageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private bool n58ProductServiceId ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A59ProductServiceName ;
      private string A318Trn_PageName ;
      private Guid AV20Trn_TileId ;
      private Guid A58ProductServiceId ;
      private Guid A264Trn_TileId ;
      private Guid AV32ProductServiceId ;
      private Guid A310Trn_PageId ;
      private Guid A329SG_ToPageId ;
      private Guid AV34Trn_PageId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P006A2_A59ProductServiceName ;
      private Guid[] P006A2_A58ProductServiceId ;
      private bool[] P006A2_n58ProductServiceId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private Guid[] P006A3_A264Trn_TileId ;
      private Guid[] P006A3_A58ProductServiceId ;
      private bool[] P006A3_n58ProductServiceId ;
      private string[] P006A3_A59ProductServiceName ;
      private Guid[] P006A4_A58ProductServiceId ;
      private bool[] P006A4_n58ProductServiceId ;
      private string[] P006A4_A59ProductServiceName ;
      private string[] P006A5_A318Trn_PageName ;
      private Guid[] P006A5_A310Trn_PageId ;
      private Guid[] P006A6_A264Trn_TileId ;
      private Guid[] P006A6_A329SG_ToPageId ;
      private Guid[] P006A7_A310Trn_PageId ;
      private string[] P006A7_A318Trn_PageName ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class trn_tileloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006A2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A59ProductServiceName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ProductServiceName, ProductServiceId";
         sFromString = " FROM Trn_ProductService";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(ProductServiceName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY ProductServiceName, ProductServiceId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006A5( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A318Trn_PageName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Trn_PageName, Trn_PageId";
         sFromString = " FROM Trn_Page";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(Trn_PageName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY Trn_PageName, Trn_PageId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
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
                     return conditional_P006A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P006A5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006A3;
          prmP006A3 = new Object[] {
          new ParDef("AV20Trn_TileId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006A4;
          prmP006A4 = new Object[] {
          new ParDef("AV32ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006A6;
          prmP006A6 = new Object[] {
          new ParDef("AV20Trn_TileId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006A7;
          prmP006A7 = new Object[] {
          new ParDef("AV34Trn_PageId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006A2;
          prmP006A2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP006A5;
          prmP006A5 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006A3", "SELECT T1.Trn_TileId, T1.ProductServiceId, T2.ProductServiceName FROM (Trn_Col T1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = T1.ProductServiceId) WHERE T1.Trn_TileId = :AV20Trn_TileId ORDER BY T1.Trn_TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006A4", "SELECT ProductServiceId, ProductServiceName FROM Trn_ProductService WHERE ProductServiceId = :AV32ProductServiceId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006A5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006A6", "SELECT Trn_TileId, SG_ToPageId FROM Trn_Col WHERE Trn_TileId = :AV20Trn_TileId ORDER BY Trn_TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006A7", "SELECT Trn_PageId, Trn_PageName FROM Trn_Page WHERE Trn_PageId = :AV34Trn_PageId ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A7,1, GxCacheFrequency.OFF ,false,true )
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
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}