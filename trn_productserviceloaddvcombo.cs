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
                           Guid aP2_ProductServiceId ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20ProductServiceId = aP2_ProductServiceId;
         this.AV22SelectedValue = "" ;
         this.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP3_SelectedValue=this.AV22SelectedValue;
         aP4_Combo_Data=this.AV15Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    Guid aP2_ProductServiceId ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ProductServiceId, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_ProductServiceId ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20ProductServiceId = aP2_ProductServiceId;
         this.AV22SelectedValue = "" ;
         this.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP3_SelectedValue=this.AV22SelectedValue;
         aP4_Combo_Data=this.AV15Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
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
         /* Using cursor P00782 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A49SupplierAgbId = P00782_A49SupplierAgbId[0];
            n49SupplierAgbId = P00782_n49SupplierAgbId[0];
            A51SupplierAgbName = P00782_A51SupplierAgbName[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P00783 */
            pr_default.execute(1, new Object[] {AV20ProductServiceId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A58ProductServiceId = P00783_A58ProductServiceId[0];
               A49SupplierAgbId = P00783_A49SupplierAgbId[0];
               n49SupplierAgbId = P00783_n49SupplierAgbId[0];
               AV22SelectedValue = ((Guid.Empty==A49SupplierAgbId) ? "" : StringUtil.Trim( A49SupplierAgbId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_SUPPLIERGENID' Routine */
         returnInSub = false;
         /* Using cursor P00784 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A42SupplierGenId = P00784_A42SupplierGenId[0];
            n42SupplierGenId = P00784_n42SupplierGenId[0];
            A44SupplierGenCompanyName = P00784_A44SupplierGenCompanyName[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
            AV16Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P00785 */
            pr_default.execute(3, new Object[] {AV20ProductServiceId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A58ProductServiceId = P00785_A58ProductServiceId[0];
               A42SupplierGenId = P00785_A42SupplierGenId[0];
               n42SupplierGenId = P00785_n42SupplierGenId[0];
               AV22SelectedValue = ((Guid.Empty==A42SupplierGenId) ? "" : StringUtil.Trim( A42SupplierGenId.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
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
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00782_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00782_n49SupplierAgbId = new bool[] {false} ;
         P00782_A51SupplierAgbName = new string[] {""} ;
         A49SupplierAgbId = Guid.Empty;
         A51SupplierAgbName = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P00783_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00783_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         P00783_n49SupplierAgbId = new bool[] {false} ;
         A58ProductServiceId = Guid.Empty;
         P00784_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00784_n42SupplierGenId = new bool[] {false} ;
         P00784_A44SupplierGenCompanyName = new string[] {""} ;
         A42SupplierGenId = Guid.Empty;
         A44SupplierGenCompanyName = "";
         P00785_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00785_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         P00785_n42SupplierGenId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productserviceloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00782_A49SupplierAgbId, P00782_A51SupplierAgbName
               }
               , new Object[] {
               P00783_A58ProductServiceId, P00783_A49SupplierAgbId, P00783_n49SupplierAgbId
               }
               , new Object[] {
               P00784_A42SupplierGenId, P00784_A44SupplierGenCompanyName
               }
               , new Object[] {
               P00785_A58ProductServiceId, P00785_A42SupplierGenId, P00785_n42SupplierGenId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV18TrnMode ;
      private bool returnInSub ;
      private bool n49SupplierAgbId ;
      private bool n42SupplierGenId ;
      private string AV17ComboName ;
      private string AV22SelectedValue ;
      private string A51SupplierAgbName ;
      private string A44SupplierGenCompanyName ;
      private Guid AV20ProductServiceId ;
      private Guid A49SupplierAgbId ;
      private Guid A58ProductServiceId ;
      private Guid A42SupplierGenId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00782_A49SupplierAgbId ;
      private bool[] P00782_n49SupplierAgbId ;
      private string[] P00782_A51SupplierAgbName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private Guid[] P00783_A58ProductServiceId ;
      private Guid[] P00783_A49SupplierAgbId ;
      private bool[] P00783_n49SupplierAgbId ;
      private Guid[] P00784_A42SupplierGenId ;
      private bool[] P00784_n42SupplierGenId ;
      private string[] P00784_A44SupplierGenCompanyName ;
      private Guid[] P00785_A58ProductServiceId ;
      private Guid[] P00785_A42SupplierGenId ;
      private bool[] P00785_n42SupplierGenId ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
   }

   public class trn_productserviceloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00782;
          prmP00782 = new Object[] {
          };
          Object[] prmP00783;
          prmP00783 = new Object[] {
          new ParDef("AV20ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00784;
          prmP00784 = new Object[] {
          };
          Object[] prmP00785;
          prmP00785 = new Object[] {
          new ParDef("AV20ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00782", "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB ORDER BY SupplierAgbName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00782,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00783", "SELECT ProductServiceId, SupplierAgbId FROM Trn_ProductService WHERE ProductServiceId = :AV20ProductServiceId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00783,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00784", "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen ORDER BY SupplierGenCompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00784,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00785", "SELECT ProductServiceId, SupplierGenId FROM Trn_ProductService WHERE ProductServiceId = :AV20ProductServiceId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00785,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
