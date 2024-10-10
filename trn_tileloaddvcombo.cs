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
         if ( StringUtil.StrCmp(AV17ComboName, "SG_TileId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SG_TILEID' */
            S111 ();
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
         /* 'LOADCOMBOITEMS_SG_TILEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV29ValuesCollection.FromJSonString(AV14SearchTxt, null);
               AV28DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV33GXV1 = 1;
               while ( AV33GXV1 <= AV29ValuesCollection.Count )
               {
                  AV30ValueItem = ((string)AV29ValuesCollection.Item(AV33GXV1));
                  AV31Trn_TileId_Filter = StringUtil.StrToGuid( AV30ValueItem);
                  AV34GXLvl29 = 0;
                  /* Using cursor P006A2 */
                  pr_default.execute(0, new Object[] {AV31Trn_TileId_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A264Trn_TileId = P006A2_A264Trn_TileId[0];
                     A265Trn_TileName = P006A2_A265Trn_TileName[0];
                     AV34GXLvl29 = 1;
                     AV28DscsCollection.Add(A265Trn_TileName, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV34GXLvl29 == 0 )
                  {
                     AV28DscsCollection.Add("", 0);
                  }
                  AV33GXV1 = (int)(AV33GXV1+1);
               }
               AV24Combo_DataJson = AV28DscsCollection.ToJSonString(false);
            }
            else
            {
               GXPagingFrom3 = AV12SkipItems;
               GXPagingTo3 = AV11MaxItems;
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV14SearchTxt ,
                                                    A265Trn_TileName } ,
                                                    new int[]{
                                                    }
               });
               lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
               /* Using cursor P006A3 */
               pr_default.execute(1, new Object[] {lV14SearchTxt, GXPagingFrom3, GXPagingTo3, GXPagingTo3});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A265Trn_TileName = P006A3_A265Trn_TileName[0];
                  A264Trn_TileId = P006A3_A264Trn_TileId[0];
                  AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A264Trn_TileId.ToString());
                  AV16Combo_DataItem.gxTpr_Title = A265Trn_TileName;
                  AV15Combo_Data.Add(AV16Combo_DataItem, 0);
                  if ( AV15Combo_Data.Count > AV11MaxItems )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
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
         AV29ValuesCollection = new GxSimpleCollection<string>();
         AV28DscsCollection = new GxSimpleCollection<string>();
         AV30ValueItem = "";
         AV31Trn_TileId_Filter = Guid.Empty;
         P006A2_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         P006A2_A265Trn_TileName = new string[] {""} ;
         A264Trn_TileId = Guid.Empty;
         A265Trn_TileName = "";
         lV14SearchTxt = "";
         P006A3_A265Trn_TileName = new string[] {""} ;
         P006A3_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tileloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006A2_A264Trn_TileId, P006A2_A265Trn_TileName
               }
               , new Object[] {
               P006A3_A265Trn_TileName, P006A3_A264Trn_TileId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short AV34GXLvl29 ;
      private int AV11MaxItems ;
      private int AV33GXV1 ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string AV30ValueItem ;
      private string A265Trn_TileName ;
      private string lV14SearchTxt ;
      private Guid AV20Trn_TileId ;
      private Guid AV31Trn_TileId_Filter ;
      private Guid A264Trn_TileId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV29ValuesCollection ;
      private GxSimpleCollection<string> AV28DscsCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006A2_A264Trn_TileId ;
      private string[] P006A2_A265Trn_TileName ;
      private string[] P006A3_A265Trn_TileName ;
      private Guid[] P006A3_A264Trn_TileId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class trn_tileloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006A3( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A265Trn_TileName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
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
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY Trn_TileName, Trn_TileId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom3" + " LIMIT CASE WHEN " + ":GXPagingTo3" + " > 0 THEN " + ":GXPagingTo3" + " ELSE 1e9 END";
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
               case 1 :
                     return conditional_P006A3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP006A2;
          prmP006A2 = new Object[] {
          new ParDef("AV31Trn_TileId_Filter",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006A3;
          prmP006A3 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo3",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006A2", "SELECT Trn_TileId, Trn_TileName FROM Trn_Tile WHERE Trn_TileId = :AV31Trn_TileId_Filter ORDER BY Trn_TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A3,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
