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
   public class trn_managerloaddvcombo : GXProcedure
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
            return "trn_manager_Services_Execute" ;
         }

      }

      public trn_managerloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_managerloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_ManagerId ,
                           Guid aP4_OrganisationId ,
                           string aP5_SearchTxtParms ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ManagerId = aP3_ManagerId;
         this.AV21OrganisationId = aP4_OrganisationId;
         this.AV22SearchTxtParms = aP5_SearchTxtParms;
         this.AV23SelectedValue = "" ;
         this.AV24SelectedText = "" ;
         this.AV25Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP6_SelectedValue=this.AV23SelectedValue;
         aP7_SelectedText=this.AV24SelectedText;
         aP8_Combo_DataJson=this.AV25Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_ManagerId ,
                                Guid aP4_OrganisationId ,
                                string aP5_SearchTxtParms ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ManagerId, aP4_OrganisationId, aP5_SearchTxtParms, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV25Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_ManagerId ,
                                 Guid aP4_OrganisationId ,
                                 string aP5_SearchTxtParms ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ManagerId = aP3_ManagerId;
         this.AV21OrganisationId = aP4_OrganisationId;
         this.AV22SearchTxtParms = aP5_SearchTxtParms;
         this.AV23SelectedValue = "" ;
         this.AV24SelectedText = "" ;
         this.AV25Combo_DataJson = "" ;
         SubmitImpl();
         aP6_SelectedValue=this.AV23SelectedValue;
         aP7_SelectedText=this.AV24SelectedText;
         aP8_Combo_DataJson=this.AV25Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV22SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV22SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV22SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV22SearchTxtParms : StringUtil.Substring( AV22SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "OrganisationId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ORGANISATIONID' */
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
         /* 'LOADCOMBOITEMS_ORGANISATIONID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A12OrganisationKvkNumber } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P005K2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A12OrganisationKvkNumber = P005K2_A12OrganisationKvkNumber[0];
               A11OrganisationId = P005K2_A11OrganisationId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A11OrganisationId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A12OrganisationKvkNumber;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV25Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               /* Using cursor P005K3 */
               pr_default.execute(1, new Object[] {AV20ManagerId, AV21OrganisationId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A11OrganisationId = P005K3_A11OrganisationId[0];
                  A21ManagerId = P005K3_A21ManagerId[0];
                  A12OrganisationKvkNumber = P005K3_A12OrganisationKvkNumber[0];
                  A12OrganisationKvkNumber = P005K3_A12OrganisationKvkNumber[0];
                  AV23SelectedValue = ((Guid.Empty==A11OrganisationId) ? "" : StringUtil.Trim( A11OrganisationId.ToString()));
                  AV24SelectedText = A12OrganisationKvkNumber;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! (Guid.Empty==AV21OrganisationId) )
               {
                  AV23SelectedValue = StringUtil.Trim( AV21OrganisationId.ToString());
                  /* Using cursor P005K4 */
                  pr_default.execute(2, new Object[] {AV21OrganisationId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A11OrganisationId = P005K4_A11OrganisationId[0];
                     A12OrganisationKvkNumber = P005K4_A12OrganisationKvkNumber[0];
                     AV24SelectedText = A12OrganisationKvkNumber;
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
         AV23SelectedValue = "";
         AV24SelectedText = "";
         AV25Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         lV14SearchTxt = "";
         A12OrganisationKvkNumber = "";
         P005K2_A12OrganisationKvkNumber = new string[] {""} ;
         P005K2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P005K3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005K3_A21ManagerId = new Guid[] {Guid.Empty} ;
         P005K3_A12OrganisationKvkNumber = new string[] {""} ;
         A21ManagerId = Guid.Empty;
         P005K4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P005K4_A12OrganisationKvkNumber = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_managerloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P005K2_A12OrganisationKvkNumber, P005K2_A11OrganisationId
               }
               , new Object[] {
               P005K3_A11OrganisationId, P005K3_A21ManagerId, P005K3_A12OrganisationKvkNumber
               }
               , new Object[] {
               P005K4_A11OrganisationId, P005K4_A12OrganisationKvkNumber
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
      private string AV18TrnMode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV25Combo_DataJson ;
      private string AV17ComboName ;
      private string AV22SearchTxtParms ;
      private string AV23SelectedValue ;
      private string AV24SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A12OrganisationKvkNumber ;
      private Guid AV20ManagerId ;
      private Guid AV21OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A21ManagerId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P005K2_A12OrganisationKvkNumber ;
      private Guid[] P005K2_A11OrganisationId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private Guid[] P005K3_A11OrganisationId ;
      private Guid[] P005K3_A21ManagerId ;
      private string[] P005K3_A12OrganisationKvkNumber ;
      private Guid[] P005K4_A11OrganisationId ;
      private string[] P005K4_A12OrganisationKvkNumber ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
   }

   public class trn_managerloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005K2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A12OrganisationKvkNumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " OrganisationKvkNumber, OrganisationId";
         sFromString = " FROM Trn_Organisation";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(OrganisationKvkNumber like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY OrganisationKvkNumber, OrganisationId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
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
                     return conditional_P005K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005K3;
          prmP005K3 = new Object[] {
          new ParDef("AV20ManagerId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP005K4;
          prmP005K4 = new Object[] {
          new ParDef("AV21OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP005K2;
          prmP005K2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005K3", "SELECT T1.OrganisationId, T1.ManagerId, T2.OrganisationKvkNumber FROM (Trn_Manager T1 INNER JOIN Trn_Organisation T2 ON T2.OrganisationId = T1.OrganisationId) WHERE T1.ManagerId = :AV20ManagerId and T1.OrganisationId = :AV21OrganisationId ORDER BY T1.ManagerId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005K4", "SELECT OrganisationId, OrganisationKvkNumber FROM Trn_Organisation WHERE OrganisationId = :AV21OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K4,1, GxCacheFrequency.OFF ,false,true )
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
       }
    }

 }

}
