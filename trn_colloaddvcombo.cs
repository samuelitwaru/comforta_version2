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
   public class trn_colloaddvcombo : GXProcedure
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
            return "trn_col_Services_Execute" ;
         }

      }

      public trn_colloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_colloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_Trn_ColId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20Trn_ColId = aP3_Trn_ColId;
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
                                Guid aP3_Trn_ColId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_Trn_ColId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_Trn_ColId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20Trn_ColId = aP3_Trn_ColId;
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
         if ( StringUtil.StrCmp(AV17ComboName, "Trn_RowId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TRN_ROWID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "Trn_TileId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TRN_TILEID' */
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
         /* 'LOADCOMBOITEMS_TRN_ROWID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A320Trn_RowName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P00742 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A320Trn_RowName = P00742_A320Trn_RowName[0];
               A319Trn_RowId = P00742_A319Trn_RowId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A319Trn_RowId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A320Trn_RowName;
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
                  /* Using cursor P00743 */
                  pr_default.execute(1, new Object[] {AV20Trn_ColId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A328Trn_ColId = P00743_A328Trn_ColId[0];
                     A319Trn_RowId = P00743_A319Trn_RowId[0];
                     A320Trn_RowName = P00743_A320Trn_RowName[0];
                     A320Trn_RowName = P00743_A320Trn_RowName[0];
                     AV22SelectedValue = ((Guid.Empty==A319Trn_RowId) ? "" : StringUtil.Trim( A319Trn_RowId.ToString()));
                     AV23SelectedText = A320Trn_RowName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV28Trn_RowId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P00744 */
                  pr_default.execute(2, new Object[] {AV28Trn_RowId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A319Trn_RowId = P00744_A319Trn_RowId[0];
                     A320Trn_RowName = P00744_A320Trn_RowName[0];
                     AV23SelectedText = A320Trn_RowName;
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
         /* 'LOADCOMBOITEMS_TRN_TILEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom5 = AV12SkipItems;
            GXPagingTo5 = AV11MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A265Trn_TileName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P00745 */
            pr_default.execute(3, new Object[] {lV14SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A265Trn_TileName = P00745_A265Trn_TileName[0];
               A264Trn_TileId = P00745_A264Trn_TileId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A264Trn_TileId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A265Trn_TileName;
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
                  /* Using cursor P00746 */
                  pr_default.execute(4, new Object[] {AV20Trn_ColId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A328Trn_ColId = P00746_A328Trn_ColId[0];
                     A264Trn_TileId = P00746_A264Trn_TileId[0];
                     A265Trn_TileName = P00746_A265Trn_TileName[0];
                     A265Trn_TileName = P00746_A265Trn_TileName[0];
                     AV22SelectedValue = ((Guid.Empty==A264Trn_TileId) ? "" : StringUtil.Trim( A264Trn_TileId.ToString()));
                     AV23SelectedText = A265Trn_TileName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV29Trn_TileId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P00747 */
                  pr_default.execute(5, new Object[] {AV29Trn_TileId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A264Trn_TileId = P00747_A264Trn_TileId[0];
                     A265Trn_TileName = P00747_A265Trn_TileName[0];
                     AV23SelectedText = A265Trn_TileName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(5);
               }
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
         A320Trn_RowName = "";
         P00742_A320Trn_RowName = new string[] {""} ;
         P00742_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         A319Trn_RowId = Guid.Empty;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00743_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         P00743_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         P00743_A320Trn_RowName = new string[] {""} ;
         A328Trn_ColId = Guid.Empty;
         AV28Trn_RowId = Guid.Empty;
         P00744_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         P00744_A320Trn_RowName = new string[] {""} ;
         A265Trn_TileName = "";
         P00745_A265Trn_TileName = new string[] {""} ;
         P00745_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         A264Trn_TileId = Guid.Empty;
         P00746_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         P00746_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         P00746_A265Trn_TileName = new string[] {""} ;
         AV29Trn_TileId = Guid.Empty;
         P00747_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         P00747_A265Trn_TileName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_colloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00742_A320Trn_RowName, P00742_A319Trn_RowId
               }
               , new Object[] {
               P00743_A328Trn_ColId, P00743_A319Trn_RowId, P00743_A320Trn_RowName
               }
               , new Object[] {
               P00744_A319Trn_RowId, P00744_A320Trn_RowName
               }
               , new Object[] {
               P00745_A265Trn_TileName, P00745_A264Trn_TileId
               }
               , new Object[] {
               P00746_A328Trn_ColId, P00746_A264Trn_TileId, P00746_A265Trn_TileName
               }
               , new Object[] {
               P00747_A264Trn_TileId, P00747_A265Trn_TileName
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
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A320Trn_RowName ;
      private string A265Trn_TileName ;
      private Guid AV20Trn_ColId ;
      private Guid A319Trn_RowId ;
      private Guid A328Trn_ColId ;
      private Guid AV28Trn_RowId ;
      private Guid A264Trn_TileId ;
      private Guid AV29Trn_TileId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00742_A320Trn_RowName ;
      private Guid[] P00742_A319Trn_RowId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private Guid[] P00743_A328Trn_ColId ;
      private Guid[] P00743_A319Trn_RowId ;
      private string[] P00743_A320Trn_RowName ;
      private Guid[] P00744_A319Trn_RowId ;
      private string[] P00744_A320Trn_RowName ;
      private string[] P00745_A265Trn_TileName ;
      private Guid[] P00745_A264Trn_TileId ;
      private Guid[] P00746_A328Trn_ColId ;
      private Guid[] P00746_A264Trn_TileId ;
      private string[] P00746_A265Trn_TileName ;
      private Guid[] P00747_A264Trn_TileId ;
      private string[] P00747_A265Trn_TileName ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class trn_colloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00742( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A320Trn_RowName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Trn_RowName, Trn_RowId";
         sFromString = " FROM Trn_Row";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(Trn_RowName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY Trn_RowName, Trn_RowId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00745( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A265Trn_TileName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " Trn_TileName, Trn_TileId";
         sFromString = " FROM Trn_Tile";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(Trn_TileName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY Trn_TileName, Trn_TileId";
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
                     return conditional_P00742(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P00745(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00743;
          prmP00743 = new Object[] {
          new ParDef("AV20Trn_ColId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00744;
          prmP00744 = new Object[] {
          new ParDef("AV28Trn_RowId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00746;
          prmP00746 = new Object[] {
          new ParDef("AV20Trn_ColId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00747;
          prmP00747 = new Object[] {
          new ParDef("AV29Trn_TileId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00742;
          prmP00742 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00745;
          prmP00745 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00742", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00742,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00743", "SELECT T1.Trn_ColId, T1.Trn_RowId, T2.Trn_RowName FROM (Trn_Col1 T1 INNER JOIN Trn_Row T2 ON T2.Trn_RowId = T1.Trn_RowId) WHERE T1.Trn_ColId = :AV20Trn_ColId ORDER BY T1.Trn_ColId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00743,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00744", "SELECT Trn_RowId, Trn_RowName FROM Trn_Row WHERE Trn_RowId = :AV28Trn_RowId ORDER BY Trn_RowId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00744,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00745", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00745,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00746", "SELECT T1.Trn_ColId, T1.Trn_TileId, T2.Trn_TileName FROM (Trn_Col1 T1 INNER JOIN Trn_Tile T2 ON T2.Trn_TileId = T1.Trn_TileId) WHERE T1.Trn_ColId = :AV20Trn_ColId ORDER BY T1.Trn_ColId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00746,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00747", "SELECT Trn_TileId, Trn_TileName FROM Trn_Tile WHERE Trn_TileId = :AV29Trn_TileId ORDER BY Trn_TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00747,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
