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
   public class aprc_createpage : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_createpage().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_PageName = new string(' ',0)  ;
         string aP1_Response = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_PageName=((string)(args[0]));
         }
         else
         {
            aP0_PageName="";
         }
         if ( 1 < args.Length )
         {
            aP1_Response=((string)(args[1]));
         }
         else
         {
            aP1_Response="";
         }
         execute(aP0_PageName, ref aP1_Response);
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

      public aprc_createpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_createpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PageName ,
                           ref string aP1_Response )
      {
         this.AV16PageName = aP0_PageName;
         this.AV17Response = aP1_Response;
         initialize();
         ExecuteImpl();
         aP1_Response=this.AV17Response;
      }

      public string executeUdp( string aP0_PageName )
      {
         execute(aP0_PageName, ref aP1_Response);
         return AV17Response ;
      }

      public void executeSubmit( string aP0_PageName ,
                                 ref string aP1_Response )
      {
         this.AV16PageName = aP0_PageName;
         this.AV17Response = aP1_Response;
         SubmitImpl();
         aP1_Response=this.AV17Response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /*
            INSERT RECORD ON TABLE Trn_Page

         */
         A318Trn_PageName = AV16PageName;
         A434PageIsPublished = false;
         A310Trn_PageId = Guid.NewGuid( );
         A29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         A439PageIsContentPage = false;
         /* Using cursor P008V2 */
         pr_default.execute(0, new Object[] {A310Trn_PageId, A318Trn_PageName, A434PageIsPublished, n29LocationId, A29LocationId, A439PageIsContentPage});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         AV17Response = AV8BC_Trn_Page.ToJSonString(true, true);
         new prc_logtofile(context ).execute(  AV17Response) ;
         cleanup();
         if (true) return;
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_createpage",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A318Trn_PageName = "";
         A310Trn_PageId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Gx_emsg = "";
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_createpage__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS68 ;
      private string Gx_emsg ;
      private bool A434PageIsPublished ;
      private bool n29LocationId ;
      private bool A439PageIsContentPage ;
      private string AV17Response ;
      private string AV16PageName ;
      private string A318Trn_PageName ;
      private Guid A310Trn_PageId ;
      private Guid A29LocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP1_Response ;
      private IDataStoreProvider pr_default ;
      private SdtTrn_Page AV8BC_Trn_Page ;
   }

   public class aprc_createpage__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008V2;
          prmP008V2 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
          new ParDef("PageIsPublished",GXType.Boolean,4,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("PageIsContentPage",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008V2", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, Trn_PageName, PageIsPublished, LocationId, PageIsContentPage, PageJsonContent, PageGJSHtml, PageGJSJson, PageChildren) VALUES(:Trn_PageId, :Trn_PageName, :PageIsPublished, :LocationId, :PageIsContentPage, '', '', '', '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP008V2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
