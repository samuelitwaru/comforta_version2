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
   public class trn_suppliergenloaddvcombo : GXProcedure
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
            return "trn_suppliergen_Services_Execute" ;
         }

      }

      public trn_suppliergenloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergenloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_SupplierGenId ,
                           out string aP3_SelectedValue ,
                           out string aP4_SelectedText ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20SupplierGenId = aP2_SupplierGenId;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP3_SelectedValue=this.AV22SelectedValue;
         aP4_SelectedText=this.AV23SelectedText;
         aP5_Combo_Data=this.AV15Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    Guid aP2_SupplierGenId ,
                                                                                                    out string aP3_SelectedValue ,
                                                                                                    out string aP4_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_SupplierGenId, out aP3_SelectedValue, out aP4_SelectedText, out aP5_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_SupplierGenId ,
                                 out string aP3_SelectedValue ,
                                 out string aP4_SelectedText ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20SupplierGenId = aP2_SupplierGenId;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP3_SelectedValue=this.AV22SelectedValue;
         aP4_SelectedText=this.AV23SelectedText;
         aP5_Combo_Data=this.AV15Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV17ComboName, "SupplierGenTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGENTYPEID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "SupplierGenAddressCountry") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUPPLIERGENADDRESSCOUNTRY' */
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
         /* 'LOADCOMBOITEMS_SUPPLIERGENTYPEID' Routine */
         returnInSub = false;
         /* Using cursor P006J2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A282SupplierGenTypeId = P006J2_A282SupplierGenTypeId[0];
            A290SupplierGenTypeName = P006J2_A290SupplierGenTypeName[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A282SupplierGenTypeId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A290SupplierGenTypeName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006J3 */
            pr_default.execute(1, new Object[] {AV20SupplierGenId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A42SupplierGenId = P006J3_A42SupplierGenId[0];
               A282SupplierGenTypeId = P006J3_A282SupplierGenTypeId[0];
               AV22SelectedValue = ((Guid.Empty==A282SupplierGenTypeId) ? "" : StringUtil.Trim( A282SupplierGenTypeId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERGENADDRESSCOUNTRY' Routine */
         returnInSub = false;
         AV34GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV33GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV33GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV34GXV2 <= AV33GXV1.Count )
         {
            AV30SupplierGenAddressCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV33GXV1.Item(AV34GXV2));
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV30SupplierGenAddressCountry_DPItem.gxTpr_Countryname;
            AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV29ComboTitles.Add(AV30SupplierGenAddressCountry_DPItem.gxTpr_Countryname, 0);
            AV29ComboTitles.Add(AV30SupplierGenAddressCountry_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV29ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV34GXV2 = (int)(AV34GXV2+1);
         }
         AV15Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006J4 */
            pr_default.execute(2, new Object[] {AV20SupplierGenId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A42SupplierGenId = P006J4_A42SupplierGenId[0];
               A335SupplierGenAddressCountry = P006J4_A335SupplierGenAddressCountry[0];
               AV22SelectedValue = A335SupplierGenAddressCountry;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV36GXV3 = 1;
               while ( AV36GXV3 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV36GXV3));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV22SelectedValue) == 0 )
                  {
                     AV29ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV29ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV23SelectedText = ((string)AV29ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV36GXV3 = (int)(AV36GXV3+1);
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
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P006J2_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         P006J2_A290SupplierGenTypeName = new string[] {""} ;
         A282SupplierGenTypeId = Guid.Empty;
         A290SupplierGenTypeName = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P006J3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006J3_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         A42SupplierGenId = Guid.Empty;
         AV33GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV30SupplierGenAddressCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV29ComboTitles = new GxSimpleCollection<string>();
         P006J4_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P006J4_A335SupplierGenAddressCountry = new string[] {""} ;
         A335SupplierGenAddressCountry = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergenloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006J2_A282SupplierGenTypeId, P006J2_A290SupplierGenTypeName
               }
               , new Object[] {
               P006J3_A42SupplierGenId, P006J3_A282SupplierGenTypeId
               }
               , new Object[] {
               P006J4_A42SupplierGenId, P006J4_A335SupplierGenAddressCountry
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV34GXV2 ;
      private int AV36GXV3 ;
      private string AV18TrnMode ;
      private bool returnInSub ;
      private string AV17ComboName ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string A290SupplierGenTypeName ;
      private string A335SupplierGenAddressCountry ;
      private Guid AV20SupplierGenId ;
      private Guid A282SupplierGenTypeId ;
      private Guid A42SupplierGenId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006J2_A282SupplierGenTypeId ;
      private string[] P006J2_A290SupplierGenTypeName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private Guid[] P006J3_A42SupplierGenId ;
      private Guid[] P006J3_A282SupplierGenTypeId ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV33GXV1 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV30SupplierGenAddressCountry_DPItem ;
      private GxSimpleCollection<string> AV29ComboTitles ;
      private Guid[] P006J4_A42SupplierGenId ;
      private string[] P006J4_A335SupplierGenAddressCountry ;
      private string aP3_SelectedValue ;
      private string aP4_SelectedText ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP5_Combo_Data ;
   }

   public class trn_suppliergenloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP006J2;
          prmP006J2 = new Object[] {
          };
          Object[] prmP006J3;
          prmP006J3 = new Object[] {
          new ParDef("AV20SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006J4;
          prmP006J4 = new Object[] {
          new ParDef("AV20SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006J2", "SELECT SupplierGenTypeId, SupplierGenTypeName FROM Trn_SupplierGenType ORDER BY SupplierGenTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J3", "SELECT SupplierGenId, SupplierGenTypeId FROM Trn_SupplierGen WHERE SupplierGenId = :AV20SupplierGenId ORDER BY SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006J4", "SELECT SupplierGenId, SupplierGenAddressCountry FROM Trn_SupplierGen WHERE SupplierGenId = :AV20SupplierGenId ORDER BY SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J4,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}