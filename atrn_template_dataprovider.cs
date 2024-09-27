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
         Gxm1trn_template.gxTpr_Trn_templatename = "Template 1";
         Gxm1trn_template.gxTpr_Trn_templatemedia = "<img src=\"img/template-1.png\" style=\"width: 100%; height: 100%;\" />";
         Gxm1trn_template.gxTpr_Trn_templatecontent = "<div class=\"custom-template\" style=\"display: flex; flex-direction: column; gap: 10px; padding: 10px; border: 1.5px dashed #d6d3d3;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div class=\"header\" style=\"background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid\" style=\"display: flex; gap: 10px;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div></div><div class=\"grid\" style=\"margin-top: 10px;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div class=\"grid-item\" style=\"background-color: transparent; width: 100%; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div></div><div class=\"grid\" style=\"display: flex; gap: 10px; margin-top: 10px;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div class=\"grid-item\" style=\"flex: 1 1 32%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid-item\" style=\"flex: 1 1 32%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid-item\" style=\"flex: 1 1 32%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div></div></div>";
         Gxm1trn_template = new SdtTrn_Template(context);
         Gxm2rootcol.Add(Gxm1trn_template, 0);
         Gxm1trn_template.gxTpr_Trn_templatename = "Template 2";
         Gxm1trn_template.gxTpr_Trn_templatemedia = "<img src=\"img/template-2.png\" style=\"width: 100%; height: 100%;\" />";
         Gxm1trn_template.gxTpr_Trn_templatecontent = "<div class=\"custom-template\" style=\"display: flex; flex-direction: column; gap: 10px; padding: 10px; border: 1.5px dashed #d6d3d3;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div style=\"background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div style=\"background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div style=\"background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div></div>";
         Gxm1trn_template = new SdtTrn_Template(context);
         Gxm2rootcol.Add(Gxm1trn_template, 0);
         Gxm1trn_template.gxTpr_Trn_templatename = "Template 3";
         Gxm1trn_template.gxTpr_Trn_templatemedia = "<img src=\"img/template-3.png\" style=\"width: 100%; height: 100%;\" />";
         Gxm1trn_template.gxTpr_Trn_templatecontent = "<div class=\"custom-template\" style=\"display: flex; flex-direction: column; gap: 10px; padding: 10px; border: 1.5px dashed #d6d3d3;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div class=\"grid\" style=\"display: flex; gap: 10px;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div></div><div style=\"background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid\" style=\"display: flex; gap: 10px;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div></div><div class=\"grid\" style=\"display: flex; gap: 10px;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div></div></div>";
         Gxm1trn_template = new SdtTrn_Template(context);
         Gxm2rootcol.Add(Gxm1trn_template, 0);
         Gxm1trn_template.gxTpr_Trn_templatename = "Template 4";
         Gxm1trn_template.gxTpr_Trn_templatemedia = "<img src=\"img/template-4.png\" style=\"width: 100%; height: 100%;\" />";
         Gxm1trn_template.gxTpr_Trn_templatecontent = "<div class=\"custom-template\" style=\"display: flex; flex-direction: column; gap: 10px; padding: 10px; border: 1.5px dashed #d6d3d3;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div style=\"background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid\" style=\"display: flex; gap: 10px;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div></div><div class=\"grid\" style=\"display: flex; gap: 10px;\" data-gjs-droppable=\"false\" data-gjs-draggable=\"false\"><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div><div class=\"grid-item\" style=\"flex: 1 1 49%; background-color: transparent; height: 100px; border-radius: 5px; border: 1.5px dashed #d6d3d3;\" data-gjs-draggable=\"false\"></div></div></div>";
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
