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
   public class aprc_listpages : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_listpages().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_response = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_response=((string)(args[0]));
         }
         else
         {
            aP0_response="";
         }
         execute(out aP0_response);
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

      public aprc_listpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_listpages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_response )
      {
         this.AV14response = "" ;
         initialize();
         ExecuteImpl();
         aP0_response=this.AV14response;
      }

      public string executeUdp( )
      {
         execute(out aP0_response);
         return AV14response ;
      }

      public void executeSubmit( out string aP0_response )
      {
         this.AV14response = "" ;
         SubmitImpl();
         aP0_response=this.AV14response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P008W2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A310Trn_PageId = P008W2_A310Trn_PageId[0];
            A318Trn_PageName = P008W2_A318Trn_PageName[0];
            A437PageChildren = P008W2_A437PageChildren[0];
            n437PageChildren = P008W2_n437PageChildren[0];
            AV15SDT_PageStructure = new SdtSDT_PageStructure(context);
            AV15SDT_PageStructure.gxTpr_Id = A310Trn_PageId;
            AV15SDT_PageStructure.gxTpr_Name = A318Trn_PageName;
            AV15SDT_PageStructure.gxTpr_Children.FromJSonString(A437PageChildren, null);
            AV9SDT_PageCollection.Add(AV15SDT_PageStructure, 0);
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
         P008W2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P008W2_A318Trn_PageName = new string[] {""} ;
         P008W2_A437PageChildren = new string[] {""} ;
         P008W2_n437PageChildren = new bool[] {false} ;
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A437PageChildren = "";
         AV15SDT_PageStructure = new SdtSDT_PageStructure(context);
         AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_listpages__default(),
            new Object[][] {
                new Object[] {
               P008W2_A310Trn_PageId, P008W2_A318Trn_PageName, P008W2_A437PageChildren, P008W2_n437PageChildren
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n437PageChildren ;
      private string AV14response ;
      private string A437PageChildren ;
      private string A318Trn_PageName ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008W2_A310Trn_PageId ;
      private string[] P008W2_A318Trn_PageName ;
      private string[] P008W2_A437PageChildren ;
      private bool[] P008W2_n437PageChildren ;
      private SdtSDT_PageStructure AV15SDT_PageStructure ;
      private GXBaseCollection<SdtSDT_PageStructure> AV9SDT_PageCollection ;
      private string aP0_response ;
   }

   public class aprc_listpages__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP008W2;
          prmP008W2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P008W2", "SELECT Trn_PageId, Trn_PageName, PageChildren FROM Trn_Page ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008W2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
