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
   public class aprc_savepage : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_savepage().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
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

      public aprc_savepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_savepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           string aP1_PageJsonContent ,
                           string aP2_PageGJSHtml ,
                           string aP3_PageGJSJson ,
                           SdtSDT_Page aP4_SDT_Page ,
                           ref string aP5_Reponse )
      {
         this.AV18PageId = aP0_PageId;
         this.AV21PageJsonContent = aP1_PageJsonContent;
         this.AV20PageGJSHtml = aP2_PageGJSHtml;
         this.AV19PageGJSJson = aP3_PageGJSJson;
         this.AV8SDT_Page = aP4_SDT_Page;
         this.AV17Reponse = aP5_Reponse;
         initialize();
         ExecuteImpl();
         aP5_Reponse=this.AV17Reponse;
      }

      public string executeUdp( Guid aP0_PageId ,
                                string aP1_PageJsonContent ,
                                string aP2_PageGJSHtml ,
                                string aP3_PageGJSJson ,
                                SdtSDT_Page aP4_SDT_Page )
      {
         execute(aP0_PageId, aP1_PageJsonContent, aP2_PageGJSHtml, aP3_PageGJSJson, aP4_SDT_Page, ref aP5_Reponse);
         return AV17Reponse ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 string aP1_PageJsonContent ,
                                 string aP2_PageGJSHtml ,
                                 string aP3_PageGJSJson ,
                                 SdtSDT_Page aP4_SDT_Page ,
                                 ref string aP5_Reponse )
      {
         this.AV18PageId = aP0_PageId;
         this.AV21PageJsonContent = aP1_PageJsonContent;
         this.AV20PageGJSHtml = aP2_PageGJSHtml;
         this.AV19PageGJSJson = aP3_PageGJSJson;
         this.AV8SDT_Page = aP4_SDT_Page;
         this.AV17Reponse = aP5_Reponse;
         SubmitImpl();
         aP5_Reponse=this.AV17Reponse;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /*
            INSERT RECORD ON TABLE Trn_Page

         */
         A310Trn_PageId = AV8SDT_Page.gxTpr_Pageid;
         A318Trn_PageName = AV8SDT_Page.gxTpr_Pagename;
         A431PageJsonContent = AV21PageJsonContent;
         A432PageGJSHtml = AV20PageGJSHtml;
         A433PageGJSJson = AV19PageGJSJson;
         A434PageIsPublished = false;
         A439PageIsContentPage = true;
         A29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         /* Using cursor P008B2 */
         pr_default.execute(0, new Object[] {A310Trn_PageId, A318Trn_PageName, A431PageJsonContent, A432PageGJSHtml, A433PageGJSJson, A434PageIsPublished, n29LocationId, A29LocationId, A439PageIsContentPage});
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
         cleanup();
         if (true) return;
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_savepage",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         A29LocationId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_savepage__default(),
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
      private bool A439PageIsContentPage ;
      private bool n29LocationId ;
      private string AV21PageJsonContent ;
      private string AV20PageGJSHtml ;
      private string AV19PageGJSJson ;
      private string AV17Reponse ;
      private string A431PageJsonContent ;
      private string A432PageGJSHtml ;
      private string A433PageGJSJson ;
      private string A318Trn_PageName ;
      private Guid AV18PageId ;
      private Guid A310Trn_PageId ;
      private Guid A29LocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Page AV8SDT_Page ;
      private string aP5_Reponse ;
      private IDataStoreProvider pr_default ;
   }

   public class aprc_savepage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008B2;
          prmP008B2 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
          new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0) ,
          new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0) ,
          new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0) ,
          new ParDef("PageIsPublished",GXType.Boolean,4,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("PageIsContentPage",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008B2", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, LocationId, PageIsContentPage, PageChildren) VALUES(:Trn_PageId, :Trn_PageName, :PageJsonContent, :PageGJSHtml, :PageGJSJson, :PageIsPublished, :LocationId, :PageIsContentPage, '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP008B2)
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
