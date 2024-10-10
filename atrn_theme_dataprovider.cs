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
   public class atrn_theme_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new atrn_theme_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol = new GXBCCollection<SdtTrn_Theme>()  ;
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

      public atrn_theme_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atrn_theme_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtTrn_Theme> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themename = context.GetMessage( "Modern", "");
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = context.GetMessage( "Helvetica", "");
         Gxm3trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm3trn_theme_icon, 0);
         Gxm3trn_theme_icon.gxTpr_Iconname = context.GetMessage( "PrimaryColor", "");
         Gxm3trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "Warm Coral", "");
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "PrimaryColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#ff6f61";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "SecondaryColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#56c8d8";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "BackgroundColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#f0f4f8";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "TextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#343a40";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "ButtonBgColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#f6d365";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "ButtonTextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#ffffff";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "CardBgColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#ffffff";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "CardTextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#343a40";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "AccentColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#6a5acd";
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themename = context.GetMessage( "Calm", "");
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = context.GetMessage( "Arial", "");
         Gxm3trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm3trn_theme_icon, 0);
         Gxm3trn_theme_icon.gxTpr_Iconname = context.GetMessage( "PrimaryColor", "");
         Gxm3trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "Soft Blue", "");
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "PrimaryColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#89c2d9";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "SecondaryColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#f7f2e7";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "BackgroundColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#d4a373";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "TextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#4e5166";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "ButtonBgColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#bcdff0";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "ButtonTextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#4e5166";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "CardBgColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#f7f2e7";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "CardTextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#4e5166";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "AccentColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#d8e2dc";
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themename = context.GetMessage( "Vibrant", "");
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = context.GetMessage( "Comic Sans MS", "");
         Gxm3trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm3trn_theme_icon, 0);
         Gxm3trn_theme_icon.gxTpr_Iconname = context.GetMessage( "PrimaryColor", "");
         Gxm3trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "Bright Red-Orange", "");
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "PrimaryColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#ff5733";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "SecondaryColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#ffd700";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "BackgroundColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#900c3f";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "TextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#f7f7f7";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "ButtonBgColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#1e8449";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "ButtonTextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#ffffff";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "CardBgColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#581845";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "CardTextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#f7f7f7";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "AccentColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#ffbd69";
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm2rootcol.Add(Gxm1trn_theme, 0);
         Gxm1trn_theme.gxTpr_Trn_themename = context.GetMessage( "Minimal", "");
         Gxm1trn_theme.gxTpr_Trn_themefontfamily = context.GetMessage( "Merriweather, serif", "");
         Gxm3trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm1trn_theme.gxTpr_Icon.Add(Gxm3trn_theme_icon, 0);
         Gxm3trn_theme_icon.gxTpr_Iconname = context.GetMessage( "PrimaryColor", "");
         Gxm3trn_theme_icon.gxTpr_Iconsvg = context.GetMessage( "Muted Sky Blue", "");
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "PrimaryColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#2e86de";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "SecondaryColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#58d68d";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "BackgroundColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#f9f9f9";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "TextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#2f3640";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "ButtonBgColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#4a4e69";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "ButtonTextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#ffffff";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "CardBgColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#ffffff";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "CardTextColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#2f3640";
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         Gxm1trn_theme.gxTpr_Color.Add(Gxm4trn_theme_color, 0);
         Gxm4trn_theme_color.gxTpr_Colorname = context.GetMessage( "AccentColor", "");
         Gxm4trn_theme_color.gxTpr_Colorcode = "#f4a261";
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
         Gxm1trn_theme = new SdtTrn_Theme(context);
         Gxm3trn_theme_icon = new SdtTrn_Theme_Icon(context);
         Gxm4trn_theme_color = new SdtTrn_Theme_Color(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtTrn_Theme> Gxm2rootcol ;
      private SdtTrn_Theme Gxm1trn_theme ;
      private SdtTrn_Theme_Icon Gxm3trn_theme_icon ;
      private SdtTrn_Theme_Color Gxm4trn_theme_color ;
      private GXBCCollection<SdtTrn_Theme> aP0_Gxm2rootcol ;
   }

}
