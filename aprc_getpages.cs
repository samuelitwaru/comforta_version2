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
   public class aprc_getpages : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_getpages().MainImpl(args); ;
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

      public aprc_getpages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_getpages( IGxContext context )
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
         /* Using cursor P008Y2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A310Trn_PageId = P008Y2_A310Trn_PageId[0];
            A318Trn_PageName = P008Y2_A318Trn_PageName[0];
            A431PageJsonContent = P008Y2_A431PageJsonContent[0];
            A432PageGJSHtml = P008Y2_A432PageGJSHtml[0];
            A433PageGJSJson = P008Y2_A433PageGJSJson[0];
            AV8SDT_Page = new SdtSDT_Page(context);
            AV8SDT_Page.gxTpr_Pageid = A310Trn_PageId;
            AV8SDT_Page.gxTpr_Pagename = A318Trn_PageName;
            AV8SDT_Page.gxTpr_Pagejsoncontent = A431PageJsonContent;
            AV8SDT_Page.gxTpr_Pagegjshtml = A432PageGJSHtml;
            AV8SDT_Page.gxTpr_Pagegjsjson = A433PageGJSJson;
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
         P008Y2_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         P008Y2_A318Trn_PageName = new string[] {""} ;
         P008Y2_A431PageJsonContent = new string[] {""} ;
         P008Y2_A432PageGJSHtml = new string[] {""} ;
         P008Y2_A433PageGJSJson = new string[] {""} ;
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         AV8SDT_Page = new SdtSDT_Page(context);
         AV9SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_getpages__default(),
            new Object[][] {
                new Object[] {
               P008Y2_A310Trn_PageId, P008Y2_A318Trn_PageName, P008Y2_A431PageJsonContent, P008Y2_A432PageGJSHtml, P008Y2_A433PageGJSJson
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV14response ;
      private string A431PageJsonContent ;
      private string A432PageGJSHtml ;
      private string A433PageGJSJson ;
      private string A318Trn_PageName ;
      private Guid A310Trn_PageId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P008Y2_A310Trn_PageId ;
      private string[] P008Y2_A318Trn_PageName ;
      private string[] P008Y2_A431PageJsonContent ;
      private string[] P008Y2_A432PageGJSHtml ;
      private string[] P008Y2_A433PageGJSJson ;
      private SdtSDT_Page AV8SDT_Page ;
      private GXBaseCollection<SdtSDT_Page> AV9SDT_PageCollection ;
      private string aP0_response ;
   }

   public class aprc_getpages__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008Y2;
          prmP008Y2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P008Y2", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson FROM Trn_Page ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Y2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
       }
    }

 }

}
