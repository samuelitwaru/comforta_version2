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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_automaticnotificationdefinitionstoload : GXProcedure
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

      public wwp_automaticnotificationdefinitionstoload( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_automaticnotificationdefinitionstoload( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> aP0_Gxm3rootcol )
      {
         this.Gxm3rootcol = new GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition>( context, "WWP_NotificationDefinition", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm3rootcol=this.Gxm3rootcol;
      }

      public GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> executeUdp( )
      {
         execute(out aP0_Gxm3rootcol);
         return Gxm3rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> aP0_Gxm3rootcol )
      {
         this.Gxm3rootcol = new GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition>( context, "WWP_NotificationDefinition", "Comforta_version2") ;
         SubmitImpl();
         aP0_Gxm3rootcol=this.Gxm3rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: Sub1subgroup_1 */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* Sub1subgroup_1 Routine */
         returnInSub = false;
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "GeneralDiscussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "General", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "fas fa-comment-dots NotificationFontIconSuccess";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = context.GetMessage( "Subscribe to the general discussion", "");
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
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
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         /* GeneXus formulas. */
      }

      private long GXt_int1 ;
      private bool returnInSub ;
      private GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> Gxm3rootcol ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition Gxm2wwp_notificationdefinition ;
      private GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> aP0_Gxm3rootcol ;
   }

}
