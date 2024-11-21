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
   public class trn_locationloaddvcombo : GXProcedure
   {
      public trn_locationloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_locationloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_LocationId ,
                           Guid aP3_OrganisationId ,
                           out string aP4_SelectedValue ,
                           out string aP5_SelectedText ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP6_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15LocationId = aP2_LocationId;
         this.AV16OrganisationId = aP3_OrganisationId;
         this.AV17SelectedValue = "" ;
         this.AV18SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP4_SelectedValue=this.AV17SelectedValue;
         aP5_SelectedText=this.AV18SelectedText;
         aP6_Combo_Data=this.AV11Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    Guid aP2_LocationId ,
                                                                                                    Guid aP3_OrganisationId ,
                                                                                                    out string aP4_SelectedValue ,
                                                                                                    out string aP5_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_LocationId, aP3_OrganisationId, out aP4_SelectedValue, out aP5_SelectedText, out aP6_Combo_Data);
         return AV11Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_LocationId ,
                                 Guid aP3_OrganisationId ,
                                 out string aP4_SelectedValue ,
                                 out string aP5_SelectedText ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP6_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15LocationId = aP2_LocationId;
         this.AV16OrganisationId = aP3_OrganisationId;
         this.AV17SelectedValue = "" ;
         this.AV18SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP4_SelectedValue=this.AV17SelectedValue;
         aP5_SelectedText=this.AV18SelectedText;
         aP6_Combo_Data=this.AV11Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV13ComboName, "LocationCountry") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_LOCATIONCOUNTRY' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV13ComboName, "LocationPhoneCode") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_LOCATIONPHONECODE' */
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
         /* 'LOADCOMBOITEMS_LOCATIONCOUNTRY' Routine */
         returnInSub = false;
         AV25GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV24GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV24GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV25GXV2 <= AV24GXV1.Count )
         {
            AV23LocationCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV24GXV1.Item(AV25GXV2));
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = AV23LocationCountry_DPItem.gxTpr_Countryname;
            AV21ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV21ComboTitles.Add(AV23LocationCountry_DPItem.gxTpr_Countryname, 0);
            AV21ComboTitles.Add(AV23LocationCountry_DPItem.gxTpr_Countryflag, 0);
            AV12Combo_DataItem.gxTpr_Title = AV21ComboTitles.ToJSonString(false);
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            AV25GXV2 = (int)(AV25GXV2+1);
         }
         AV11Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
         {
            /* Using cursor P007N2 */
            pr_default.execute(0, new Object[] {AV15LocationId, AV16OrganisationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = P007N2_A11OrganisationId[0];
               A29LocationId = P007N2_A29LocationId[0];
               A359LocationCountry = P007N2_A359LocationCountry[0];
               AV17SelectedValue = A359LocationCountry;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV14TrnMode, "GET_DSC") == 0 )
            {
               AV27GXV3 = 1;
               while ( AV27GXV3 <= AV11Combo_Data.Count )
               {
                  AV12Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV11Combo_Data.Item(AV27GXV3));
                  if ( StringUtil.StrCmp(AV12Combo_DataItem.gxTpr_Id, AV17SelectedValue) == 0 )
                  {
                     AV21ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV21ComboTitles.FromJSonString(AV12Combo_DataItem.gxTpr_Title, null);
                     AV18SelectedText = ((string)AV21ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV27GXV3 = (int)(AV27GXV3+1);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_LOCATIONPHONECODE' Routine */
         returnInSub = false;
         AV29GXV5 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV28GXV4;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV28GXV4 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV29GXV5 <= AV28GXV4.Count )
         {
            AV22LocationPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV28GXV4.Item(AV29GXV5));
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = AV22LocationPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV21ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV21ComboTitles.Add(AV22LocationPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV21ComboTitles.Add(AV22LocationPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV12Combo_DataItem.gxTpr_Title = AV21ComboTitles.ToJSonString(false);
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            AV29GXV5 = (int)(AV29GXV5+1);
         }
         AV11Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
         {
            /* Using cursor P007N3 */
            pr_default.execute(1, new Object[] {AV15LocationId, AV16OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11OrganisationId = P007N3_A11OrganisationId[0];
               A29LocationId = P007N3_A29LocationId[0];
               A383LocationPhoneCode = P007N3_A383LocationPhoneCode[0];
               AV17SelectedValue = A383LocationPhoneCode;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( StringUtil.StrCmp(AV14TrnMode, "GET_DSC") == 0 )
            {
               AV31GXV6 = 1;
               while ( AV31GXV6 <= AV11Combo_Data.Count )
               {
                  AV12Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV11Combo_Data.Item(AV31GXV6));
                  if ( StringUtil.StrCmp(AV12Combo_DataItem.gxTpr_Id, AV17SelectedValue) == 0 )
                  {
                     AV21ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV21ComboTitles.FromJSonString(AV12Combo_DataItem.gxTpr_Title, null);
                     AV18SelectedText = ((string)AV21ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV31GXV6 = (int)(AV31GXV6+1);
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
         AV17SelectedValue = "";
         AV18SelectedText = "";
         AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV23LocationCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV21ComboTitles = new GxSimpleCollection<string>();
         P007N2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007N2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007N2_A359LocationCountry = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A359LocationCountry = "";
         AV28GXV4 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV22LocationPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         P007N3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007N3_A29LocationId = new Guid[] {Guid.Empty} ;
         P007N3_A383LocationPhoneCode = new string[] {""} ;
         A383LocationPhoneCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P007N2_A11OrganisationId, P007N2_A29LocationId, P007N2_A359LocationCountry
               }
               , new Object[] {
               P007N3_A11OrganisationId, P007N3_A29LocationId, P007N3_A383LocationPhoneCode
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV25GXV2 ;
      private int AV27GXV3 ;
      private int AV29GXV5 ;
      private int AV31GXV6 ;
      private string AV14TrnMode ;
      private bool returnInSub ;
      private string AV13ComboName ;
      private string AV17SelectedValue ;
      private string AV18SelectedText ;
      private string A359LocationCountry ;
      private string A383LocationPhoneCode ;
      private Guid AV15LocationId ;
      private Guid AV16OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV24GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV23LocationCountry_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private GxSimpleCollection<string> AV21ComboTitles ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007N2_A11OrganisationId ;
      private Guid[] P007N2_A29LocationId ;
      private string[] P007N2_A359LocationCountry ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV28GXV4 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV22LocationPhoneCode_DPItem ;
      private Guid[] P007N3_A11OrganisationId ;
      private Guid[] P007N3_A29LocationId ;
      private string[] P007N3_A383LocationPhoneCode ;
      private string aP4_SelectedValue ;
      private string aP5_SelectedText ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP6_Combo_Data ;
   }

   public class trn_locationloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP007N2;
          prmP007N2 = new Object[] {
          new ParDef("AV15LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV16OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007N3;
          prmP007N3 = new Object[] {
          new ParDef("AV15LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV16OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007N2", "SELECT OrganisationId, LocationId, LocationCountry FROM Trn_Location WHERE LocationId = :AV15LocationId and OrganisationId = :AV16OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007N2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007N3", "SELECT OrganisationId, LocationId, LocationPhoneCode FROM Trn_Location WHERE LocationId = :AV15LocationId and OrganisationId = :AV16OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007N3,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
