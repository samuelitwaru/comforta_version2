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
   public class aprc_pagesapi : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_pagesapi().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         Guid aP0_Trn_PageId = new Guid()  ;
         string aP1_response = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_Trn_PageId=((Guid)(StringUtil.StrToGuid( (string)(args[0]))));
         }
         else
         {
            aP0_Trn_PageId=Guid.Empty;
         }
         if ( 1 < args.Length )
         {
            aP1_response=((string)(args[1]));
         }
         else
         {
            aP1_response="";
         }
         execute(aP0_Trn_PageId, out aP1_response);
         return GX.GXRuntime.ExitCode ;
      }

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

      public aprc_pagesapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_pagesapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_Trn_PageId ,
                           out string aP1_response )
      {
         this.AV13Trn_PageId = aP0_Trn_PageId;
         this.AV14response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV14response;
      }

      public string executeUdp( Guid aP0_Trn_PageId )
      {
         execute(aP0_Trn_PageId, out aP1_response);
         return AV14response ;
      }

      public void executeSubmit( Guid aP0_Trn_PageId ,
                                 out string aP1_response )
      {
         this.AV13Trn_PageId = aP0_Trn_PageId;
         this.AV14response = "" ;
         SubmitImpl();
         aP1_response=this.AV14response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13Trn_PageId ,
                                              A310Trn_PageId } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P007W2 */
         pr_default.execute(0, new Object[] {AV13Trn_PageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A310Trn_PageId = P007W2_A310Trn_PageId[0];
            A431PageJsonContent = P007W2_A431PageJsonContent[0];
            A318Trn_PageName = P007W2_A318Trn_PageName[0];
            A29LocationId = P007W2_A29LocationId[0];
            n29LocationId = P007W2_n29LocationId[0];
            AV8SDT_Page = new SdtSDT_MobilePage(context);
            AV8SDT_Page.FromJSonString(A431PageJsonContent, null);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A431PageJsonContent))) )
            {
               AV8SDT_Page.gxTpr_Pageid = A310Trn_PageId;
               AV8SDT_Page.gxTpr_Pagename = A318Trn_PageName;
               AV8SDT_Page.gxTpr_Locationid = A29LocationId;
            }
            AV9SDT_PageCollection.Add(AV8SDT_Page, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9SDT_PageCollection.Count == 0 )
         {
            AV14response = "No pages found";
         }
         else
         {
            AV14response = AV9SDT_PageCollection.ToJSonString(false);
         }
         cleanup();
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
         AV14response = "";
         A310Trn_PageId = Guid.Empty;
         P007W2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P007W2_A431PageJsonContent = new string[] {""} ;
         P007W2_A318Trn_PageName = new string[] {""} ;
         P007W2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007W2_n29LocationId = new bool[] {false} ;
         A431PageJsonContent = "";
         A318Trn_PageName = "";
         A29LocationId = Guid.Empty;
         AV8SDT_Page = new SdtSDT_MobilePage(context);
         AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version2");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_pagesapi__default(),
            new Object[][] {
                new Object[] {
               P007W2_A310Trn_PageId, P007W2_A431PageJsonContent, P007W2_A318Trn_PageName, P007W2_A29LocationId, P007W2_n29LocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n29LocationId ;
      private string AV14response ;
      private string A431PageJsonContent ;
      private string A318Trn_PageName ;
      private Guid AV13Trn_PageId ;
      private Guid A310Trn_PageId ;
      private Guid A29LocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007W2_A310Trn_PageId ;
      private string[] P007W2_A431PageJsonContent ;
      private string[] P007W2_A318Trn_PageName ;
      private Guid[] P007W2_A29LocationId ;
      private bool[] P007W2_n29LocationId ;
      private SdtSDT_MobilePage AV8SDT_Page ;
      private GXBaseCollection<SdtSDT_MobilePage> AV9SDT_PageCollection ;
      private string aP1_response ;
   }

   public class aprc_pagesapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007W2( IGxContext context ,
                                             Guid AV13Trn_PageId ,
                                             Guid A310Trn_PageId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT Trn_PageId, PageJsonContent, Trn_PageName, LocationId FROM Trn_Page";
         if ( ! (Guid.Empty==AV13Trn_PageId) )
         {
            AddWhere(sWhereString, "(Trn_PageId = :AV13Trn_PageId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY Trn_PageId";
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
                     return conditional_P007W2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] );
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
          Object[] prmP007W2;
          prmP007W2 = new Object[] {
          new ParDef("AV13Trn_PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
