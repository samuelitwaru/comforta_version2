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
   public class trn_organisationloaddvcombo : GXProcedure
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
            return "trn_organisation_Services_Execute" ;
         }

      }

      public trn_organisationloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_OrganisationId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20OrganisationId = aP3_OrganisationId;
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
                                Guid aP3_OrganisationId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_OrganisationId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_OrganisationId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20OrganisationId = aP3_OrganisationId;
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
         if ( StringUtil.StrCmp(AV17ComboName, "OrganisationTypeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ORGANISATIONTYPEID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "OrganisationAddressCountry") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ORGANISATIONADDRESSCOUNTRY' */
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
         /* 'LOADCOMBOITEMS_ORGANISATIONTYPEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A20OrganisationTypeName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P00642 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A20OrganisationTypeName = P00642_A20OrganisationTypeName[0];
               A19OrganisationTypeId = P00642_A19OrganisationTypeId[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A19OrganisationTypeId.ToString());
               AV16Combo_DataItem.gxTpr_Title = A20OrganisationTypeName;
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
                  /* Using cursor P00643 */
                  pr_default.execute(1, new Object[] {AV20OrganisationId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A11OrganisationId = P00643_A11OrganisationId[0];
                     A19OrganisationTypeId = P00643_A19OrganisationTypeId[0];
                     A20OrganisationTypeName = P00643_A20OrganisationTypeName[0];
                     A20OrganisationTypeName = P00643_A20OrganisationTypeName[0];
                     AV22SelectedValue = ((Guid.Empty==A19OrganisationTypeId) ? "" : StringUtil.Trim( A19OrganisationTypeId.ToString()));
                     AV23SelectedText = A20OrganisationTypeName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV28OrganisationTypeId = StringUtil.StrToGuid( AV14SearchTxt);
                  /* Using cursor P00644 */
                  pr_default.execute(2, new Object[] {AV28OrganisationTypeId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A19OrganisationTypeId = P00644_A19OrganisationTypeId[0];
                     A20OrganisationTypeName = P00644_A20OrganisationTypeName[0];
                     AV23SelectedText = A20OrganisationTypeName;
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
         /* 'LOADCOMBOITEMS_ORGANISATIONADDRESSCOUNTRY' Routine */
         returnInSub = false;
         AV36GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = AV35GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem1) ;
         AV35GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem1;
         while ( AV36GXV2 <= AV35GXV1.Count )
         {
            AV31OrganisationAddressCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV35GXV1.Item(AV36GXV2));
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = AV31OrganisationAddressCountry_DPItem.gxTpr_Countryname;
            AV30ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV30ComboTitles.Add(AV31OrganisationAddressCountry_DPItem.gxTpr_Countryname, 0);
            AV30ComboTitles.Add(AV31OrganisationAddressCountry_DPItem.gxTpr_Countryflag, 0);
            AV16Combo_DataItem.gxTpr_Title = AV30ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            AV36GXV2 = (int)(AV36GXV2+1);
         }
         AV15Combo_Data.Sort("Title");
         AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P00645 */
            pr_default.execute(3, new Object[] {AV20OrganisationId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A11OrganisationId = P00645_A11OrganisationId[0];
               A331OrganisationAddressCountry = P00645_A331OrganisationAddressCountry[0];
               AV22SelectedValue = A331OrganisationAddressCountry;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV38GXV3 = 1;
               while ( AV38GXV3 <= AV15Combo_Data.Count )
               {
                  AV16Combo_DataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV15Combo_Data.Item(AV38GXV3));
                  if ( StringUtil.StrCmp(AV16Combo_DataItem.gxTpr_Id, AV22SelectedValue) == 0 )
                  {
                     AV30ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV30ComboTitles.FromJSonString(AV16Combo_DataItem.gxTpr_Title, null);
                     AV23SelectedText = ((string)AV30ComboTitles.Item(1));
                     if (true) break;
                  }
                  AV38GXV3 = (int)(AV38GXV3+1);
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
         A20OrganisationTypeName = "";
         P00642_A20OrganisationTypeName = new string[] {""} ;
         P00642_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         A19OrganisationTypeId = Guid.Empty;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00643_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00643_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         P00643_A20OrganisationTypeName = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         AV28OrganisationTypeId = Guid.Empty;
         P00644_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         P00644_A20OrganisationTypeName = new string[] {""} ;
         AV35GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV31OrganisationAddressCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV30ComboTitles = new GxSimpleCollection<string>();
         P00645_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00645_A331OrganisationAddressCountry = new string[] {""} ;
         A331OrganisationAddressCountry = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00642_A20OrganisationTypeName, P00642_A19OrganisationTypeId
               }
               , new Object[] {
               P00643_A11OrganisationId, P00643_A19OrganisationTypeId, P00643_A20OrganisationTypeName
               }
               , new Object[] {
               P00644_A19OrganisationTypeId, P00644_A20OrganisationTypeName
               }
               , new Object[] {
               P00645_A11OrganisationId, P00645_A331OrganisationAddressCountry
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
      private int AV36GXV2 ;
      private int AV38GXV3 ;
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
      private string A20OrganisationTypeName ;
      private string A331OrganisationAddressCountry ;
      private Guid AV20OrganisationId ;
      private Guid A19OrganisationTypeId ;
      private Guid A11OrganisationId ;
      private Guid AV28OrganisationTypeId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00642_A20OrganisationTypeName ;
      private Guid[] P00642_A19OrganisationTypeId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private Guid[] P00643_A11OrganisationId ;
      private Guid[] P00643_A19OrganisationTypeId ;
      private string[] P00643_A20OrganisationTypeName ;
      private Guid[] P00644_A19OrganisationTypeId ;
      private string[] P00644_A20OrganisationTypeName ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV35GXV1 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem1 ;
      private SdtSDT_Country_SDT_CountryItem AV31OrganisationAddressCountry_DPItem ;
      private GxSimpleCollection<string> AV30ComboTitles ;
      private Guid[] P00645_A11OrganisationId ;
      private string[] P00645_A331OrganisationAddressCountry ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class trn_organisationloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00642( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A20OrganisationTypeName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " OrganisationTypeName, OrganisationTypeId";
         sFromString = " FROM Trn_OrganisationType";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(OrganisationTypeName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         sOrderString += " ORDER BY OrganisationTypeName, OrganisationTypeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00642(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00643;
          prmP00643 = new Object[] {
          new ParDef("AV20OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00644;
          prmP00644 = new Object[] {
          new ParDef("AV28OrganisationTypeId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00645;
          prmP00645 = new Object[] {
          new ParDef("AV20OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00642;
          prmP00642 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00642", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00642,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00643", "SELECT T1.OrganisationId, T1.OrganisationTypeId, T2.OrganisationTypeName FROM (Trn_Organisation T1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = T1.OrganisationTypeId) WHERE T1.OrganisationId = :AV20OrganisationId ORDER BY T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00643,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00644", "SELECT OrganisationTypeId, OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :AV28OrganisationTypeId ORDER BY OrganisationTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00644,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00645", "SELECT OrganisationId, OrganisationAddressCountry FROM Trn_Organisation WHERE OrganisationId = :AV20OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00645,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}