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
   public class trn_productserviceloaddvcombo : GXProcedure
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
            return "trn_productservice_Services_Execute" ;
         }

      }

      public trn_productserviceloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_productserviceloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_ProductServiceId ,
                           Guid aP4_LocationId ,
                           Guid aP5_OrganisationId ,
                           string aP6_SearchTxtParms ,
                           out string aP7_SelectedValue ,
                           out string aP8_SelectedText ,
                           out string aP9_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ProductServiceId = aP3_ProductServiceId;
         this.AV31LocationId = aP4_LocationId;
         this.AV30OrganisationId = aP5_OrganisationId;
         this.AV21SearchTxtParms = aP6_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP7_SelectedValue=this.AV22SelectedValue;
         aP8_SelectedText=this.AV23SelectedText;
         aP9_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_ProductServiceId ,
                                Guid aP4_LocationId ,
                                Guid aP5_OrganisationId ,
                                string aP6_SearchTxtParms ,
                                out string aP7_SelectedValue ,
                                out string aP8_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ProductServiceId, aP4_LocationId, aP5_OrganisationId, aP6_SearchTxtParms, out aP7_SelectedValue, out aP8_SelectedText, out aP9_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_ProductServiceId ,
                                 Guid aP4_LocationId ,
                                 Guid aP5_OrganisationId ,
                                 string aP6_SearchTxtParms ,
                                 out string aP7_SelectedValue ,
                                 out string aP8_SelectedText ,
                                 out string aP9_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20ProductServiceId = aP3_ProductServiceId;
         this.AV31LocationId = aP4_LocationId;
         this.AV30OrganisationId = aP5_OrganisationId;
         this.AV21SearchTxtParms = aP6_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         SubmitImpl();
         aP7_SelectedValue=this.AV22SelectedValue;
         aP8_SelectedText=this.AV23SelectedText;
         aP9_Combo_DataJson=this.AV24Combo_DataJson;
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
         if ( StringUtil.StrCmp(AV17ComboName, "SupplierAgbId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERAGBID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierGenId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGENID' */
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
         /* 'LOADCOMBOITEMS_SUPPLIERAGBID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A51SupplierAgbName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P00782 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A51SupplierAgbName = P00782_A51SupplierAgbName[0];
               A49SupplierAgbId = P00782_A49SupplierAgbId[0];
               n49SupplierAgbId = P00782_n49SupplierAgbId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
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
                  /* Using cursor P00783 */
                  pr_default.execute(1, new Object[] {AV20ProductServiceId, AV31LocationId, AV30OrganisationId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A11OrganisationId = P00783_A11OrganisationId[0];
                     A29LocationId = P00783_A29LocationId[0];
                     A58ProductServiceId = P00783_A58ProductServiceId[0];
                     A49SupplierAgbId = P00783_A49SupplierAgbId[0];
                     n49SupplierAgbId = P00783_n49SupplierAgbId[0];
                     A51SupplierAgbName = P00783_A51SupplierAgbName[0];
                     A51SupplierAgbName = P00783_A51SupplierAgbName[0];
                     AV22SelectedValue = ((Guid.Empty==A49SupplierAgbId) ? "" : StringUtil.Trim( A49SupplierAgbId.ToString()));
                     AV23SelectedText = A51SupplierAgbName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV29SupplierAgbId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P00784 */
                  pr_default.execute(2, new Object[] {AV29SupplierAgbId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A49SupplierAgbId = P00784_A49SupplierAgbId[0];
                     n49SupplierAgbId = P00784_n49SupplierAgbId[0];
                     A51SupplierAgbName = P00784_A51SupplierAgbName[0];
                     AV23SelectedText = A51SupplierAgbName;
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
         /* 'LOADCOMBOITEMS_SUPPLIERGENID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom5 = AV12SkipItems;
            GXPagingTo5 = AV11MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A44SupplierGenCompanyName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P00785 */
            pr_default.execute(3, new Object[] {lV14SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A44SupplierGenCompanyName = P00785_A44SupplierGenCompanyName[0];
               A42SupplierGenId = P00785_A42SupplierGenId[0];
               n42SupplierGenId = P00785_n42SupplierGenId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
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
                  /* Using cursor P00786 */
                  pr_default.execute(4, new Object[] {AV20ProductServiceId, AV31LocationId, AV30OrganisationId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A11OrganisationId = P00786_A11OrganisationId[0];
                     A29LocationId = P00786_A29LocationId[0];
                     A58ProductServiceId = P00786_A58ProductServiceId[0];
                     A42SupplierGenId = P00786_A42SupplierGenId[0];
                     n42SupplierGenId = P00786_n42SupplierGenId[0];
                     A44SupplierGenCompanyName = P00786_A44SupplierGenCompanyName[0];
                     A44SupplierGenCompanyName = P00786_A44SupplierGenCompanyName[0];
                     AV22SelectedValue = ((Guid.Empty==A42SupplierGenId) ? "" : StringUtil.Trim( A42SupplierGenId.ToString()));
                     AV23SelectedText = A44SupplierGenCompanyName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV28SupplierGenId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P00787 */
                  pr_default.execute(5, new Object[] {AV28SupplierGenId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A42SupplierGenId = P00787_A42SupplierGenId[0];
                     n42SupplierGenId = P00787_n42SupplierGenId[0];
                     A44SupplierGenCompanyName = P00787_A44SupplierGenCompanyName[0];
                     AV23SelectedText = A44SupplierGenCompanyName;
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
         A51SupplierAgbName = "";
         P00782_A51SupplierAgbName = new string[] {""} ;
         P00782_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00782_n49SupplierAgbId = new bool[] {false} ;
         A49SupplierAgbId = Guid.Empty;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00783_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00783_A29LocationId = new Guid[] {Guid.Empty} ;
         P00783_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00783_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00783_n49SupplierAgbId = new bool[] {false} ;
         P00783_A51SupplierAgbName = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         AV29SupplierAgbId = Guid.Empty;
         P00784_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00784_n49SupplierAgbId = new bool[] {false} ;
         P00784_A51SupplierAgbName = new string[] {""} ;
         A44SupplierGenCompanyName = "";
         P00785_A44SupplierGenCompanyName = new string[] {""} ;
         P00785_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00785_n42SupplierGenId = new bool[] {false} ;
         A42SupplierGenId = Guid.Empty;
         P00786_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00786_A29LocationId = new Guid[] {Guid.Empty} ;
         P00786_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00786_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00786_n42SupplierGenId = new bool[] {false} ;
         P00786_A44SupplierGenCompanyName = new string[] {""} ;
         AV28SupplierGenId = Guid.Empty;
         P00787_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00787_n42SupplierGenId = new bool[] {false} ;
         P00787_A44SupplierGenCompanyName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productserviceloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00782_A51SupplierAgbName, P00782_A49SupplierAgbId
               }
               , new Object[] {
               P00783_A11OrganisationId, P00783_A29LocationId, P00783_A58ProductServiceId, P00783_A49SupplierAgbId, P00783_n49SupplierAgbId, P00783_A51SupplierAgbName
               }
               , new Object[] {
               P00784_A49SupplierAgbId, P00784_A51SupplierAgbName
               }
               , new Object[] {
               P00785_A44SupplierGenCompanyName, P00785_A42SupplierGenId
               }
               , new Object[] {
               P00786_A11OrganisationId, P00786_A29LocationId, P00786_A58ProductServiceId, P00786_A42SupplierGenId, P00786_n42SupplierGenId, P00786_A44SupplierGenCompanyName
               }
               , new Object[] {
               P00787_A42SupplierGenId, P00787_A44SupplierGenCompanyName
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
      private bool n49SupplierAgbId ;
      private bool n42SupplierGenId ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A51SupplierAgbName ;
      private string A44SupplierGenCompanyName ;
      private Guid AV20ProductServiceId ;
      private Guid AV31LocationId ;
      private Guid AV30OrganisationId ;
      private Guid A49SupplierAgbId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid AV29SupplierAgbId ;
      private Guid A42SupplierGenId ;
      private Guid AV28SupplierGenId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00782_A51SupplierAgbName ;
      private Guid[] P00782_A49SupplierAgbId ;
      private bool[] P00782_n49SupplierAgbId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private Guid[] P00783_A11OrganisationId ;
      private Guid[] P00783_A29LocationId ;
      private Guid[] P00783_A58ProductServiceId ;
      private Guid[] P00783_A49SupplierAgbId ;
      private bool[] P00783_n49SupplierAgbId ;
      private string[] P00783_A51SupplierAgbName ;
      private Guid[] P00784_A49SupplierAgbId ;
      private bool[] P00784_n49SupplierAgbId ;
      private string[] P00784_A51SupplierAgbName ;
      private string[] P00785_A44SupplierGenCompanyName ;
      private Guid[] P00785_A42SupplierGenId ;
      private bool[] P00785_n42SupplierGenId ;
      private Guid[] P00786_A11OrganisationId ;
      private Guid[] P00786_A29LocationId ;
      private Guid[] P00786_A58ProductServiceId ;
      private Guid[] P00786_A42SupplierGenId ;
      private bool[] P00786_n42SupplierGenId ;
      private string[] P00786_A44SupplierGenCompanyName ;
      private Guid[] P00787_A42SupplierGenId ;
      private bool[] P00787_n42SupplierGenId ;
      private string[] P00787_A44SupplierGenCompanyName ;
      private string aP7_SelectedValue ;
      private string aP8_SelectedText ;
      private string aP9_Combo_DataJson ;
   }

   public class trn_productserviceloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00782( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A51SupplierAgbName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SupplierAgbName, SupplierAgbId";
         sFromString = " FROM Trn_SupplierAGB";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(SupplierAgbName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY SupplierAgbName, SupplierAgbId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00785( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A44SupplierGenCompanyName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SupplierGenCompanyName, SupplierGenId";
         sFromString = " FROM Trn_SupplierGen";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(SupplierGenCompanyName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY SupplierGenCompanyName, SupplierGenId";
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
                     return conditional_P00782(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P00785(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00783;
          prmP00783 = new Object[] {
          new ParDef("AV20ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV31LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV30OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00784;
          prmP00784 = new Object[] {
          new ParDef("AV29SupplierAgbId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00786;
          prmP00786 = new Object[] {
          new ParDef("AV20ProductServiceId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV31LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV30OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00787;
          prmP00787 = new Object[] {
          new ParDef("AV28SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00782;
          prmP00782 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00785;
          prmP00785 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00782", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00782,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00783", "SELECT T1.OrganisationId, T1.LocationId, T1.ProductServiceId, T1.SupplierAgbId, T2.SupplierAgbName FROM (Trn_ProductService T1 LEFT JOIN Trn_SupplierAGB T2 ON T2.SupplierAgbId = T1.SupplierAgbId) WHERE T1.ProductServiceId = :AV20ProductServiceId and T1.LocationId = :AV31LocationId and T1.OrganisationId = :AV30OrganisationId ORDER BY T1.ProductServiceId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00783,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00784", "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :AV29SupplierAgbId ORDER BY SupplierAgbId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00784,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00785", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00785,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00786", "SELECT T1.OrganisationId, T1.LocationId, T1.ProductServiceId, T1.SupplierGenId, T2.SupplierGenCompanyName FROM (Trn_ProductService T1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = T1.SupplierGenId) WHERE T1.ProductServiceId = :AV20ProductServiceId and T1.LocationId = :AV31LocationId and T1.OrganisationId = :AV30OrganisationId ORDER BY T1.ProductServiceId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00786,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00787", "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :AV28SupplierGenId ORDER BY SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00787,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
