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
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "WWP_Parameter", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "WWP_Parameter", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "WWP_Form", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "WWP_Form", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "WWP_FormInstance", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "WWP_FormInstance", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Manager", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Manager", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Organisation", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Organisation", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_OrganisationType", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_OrganisationType", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_OrganisationSetting", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_OrganisationSetting", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Resident", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Resident", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_MedicalIndication", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_MedicalIndication", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Location", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Location", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Receptionist", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Receptionist", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_ResidentType", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_ResidentType", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Amenity", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Amenity", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_SupplierGen", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_SupplierGen", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_SupplierAgb", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_SupplierAgb", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_ProductService", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_ProductService", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_SupplierAgbType", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_SupplierAgbType", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_SupplierGenType", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_SupplierGenType", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Theme", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Theme", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Media", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Media", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Tile", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Tile", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Discussion";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Template", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = true;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when discussion messages are created";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality = "";
         Gxm2wwp_notificationdefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         Gxm3rootcol.Add(Gxm2wwp_notificationdefinition, 0);
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionname = "Mention";
         GXt_int1 = 0;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  "Trn_Template", out  GXt_int1) ;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpentityid = GXt_int1;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionappliesto = 2;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription = false;
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitionicon = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiontitle = "";
         Gxm2wwp_notificationdefinition.gxTpr_Wwpnotificationdefinitiondescription = "Get notified when you are mentioned in a discussion";
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