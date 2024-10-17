using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class atrn_template_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new atrn_template_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtTrn_Template> aP0_Gxm2rootcol = new GXBCCollection<SdtTrn_Template>()  ;
         execute(out aP0_Gxm2rootcol);
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

      public atrn_template_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atrn_template_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtTrn_Template> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_Template>( context, "Trn_Template", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtTrn_Template> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtTrn_Template> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_Template>( context, "Trn_Template", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1trn_template = new SdtTrn_Template(context);
         Gxm2rootcol.Add(Gxm1trn_template, 0);
         Gxm1trn_template.gxTpr_Trn_templatename = context.GetMessage( "Template 1", "");
         Gxm1trn_template.gxTpr_Trn_templatemedia = context.GetMessage( "<img src=\"/Resources/UCGrapes/new-design/img/template-1.png\" style=\"width: 100%; height: 100%;\" />", "");
         Gxm1trn_template.gxTpr_Trn_templatecontent = "1, 2, 1, 3";
         Gxm1trn_template = new SdtTrn_Template(context);
         Gxm2rootcol.Add(Gxm1trn_template, 0);
         Gxm1trn_template.gxTpr_Trn_templatename = context.GetMessage( "Template 2", "");
         Gxm1trn_template.gxTpr_Trn_templatemedia = context.GetMessage( "<img src=\"/Resources/UCGrapes/new-design/img/template-2.png\" style=\"width: 100%; height: 100%;\" />", "");
         Gxm1trn_template.gxTpr_Trn_templatecontent = "1,1,1";
         Gxm1trn_template = new SdtTrn_Template(context);
         Gxm2rootcol.Add(Gxm1trn_template, 0);
         Gxm1trn_template.gxTpr_Trn_templatename = context.GetMessage( "Template 3", "");
         Gxm1trn_template.gxTpr_Trn_templatemedia = context.GetMessage( "<img src=\"/Resources/UCGrapes/new-design/img/template-3.png\" style=\"width: 100%; height: 100%;\" />", "");
         Gxm1trn_template.gxTpr_Trn_templatecontent = "2, 1, 2, 2";
         Gxm1trn_template = new SdtTrn_Template(context);
         Gxm2rootcol.Add(Gxm1trn_template, 0);
         Gxm1trn_template.gxTpr_Trn_templatename = context.GetMessage( "Template 4", "");
         Gxm1trn_template.gxTpr_Trn_templatemedia = context.GetMessage( "<img src=\"/Resources/UCGrapes/new-design/img/template-4.png\" style=\"width: 100%; height: 100%;\" />", "");
         Gxm1trn_template.gxTpr_Trn_templatecontent = "1, 2, 2";
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
         Gxm1trn_template = new SdtTrn_Template(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtTrn_Template> Gxm2rootcol ;
      private SdtTrn_Template Gxm1trn_template ;
      private GXBCCollection<SdtTrn_Template> aP0_Gxm2rootcol ;
   }

}
