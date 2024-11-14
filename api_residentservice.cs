using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class api_residentservice : GXProcedure
   {
      public api_residentservice( )
      {
         context = new GxContext(  );
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
      }

      public api_residentservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         if ( context.HttpContext != null )
         {
            Gx_restmethod = (string)(context.HttpContext.Request.Method);
         }
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      protected void E11012( )
      {
         /* After Routine */
         returnInSub = false;
         new prc_logtofile(context ).execute(  context.GetMessage( "After Event Response ========", "")+AV17result) ;
         AV17result = StringUtil.StringReplace( AV17result, "\\", "");
         new prc_logtofile(context ).execute(  context.GetMessage( "After Event Formated Response ========", "")+AV17result) ;
      }

      protected void E12012( )
      {
         /* Loginwithqrcode_After Routine */
         returnInSub = false;
         if ( AV20SDT_LoginResidentResponse.FromJSonString(AV17result, null) )
         {
            AV21loginResult = AV20SDT_LoginResidentResponse;
         }
      }

      protected void E13012( )
      {
         /* Getresidentinformation_After Routine */
         returnInSub = false;
         if ( AV22SDT_Resident.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E14012( )
      {
         /* Getorganisationinformation_After Routine */
         returnInSub = false;
         if ( AV23SDT_Organisation.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E15012( )
      {
         /* Getlocationinformation_After Routine */
         returnInSub = false;
         if ( AV18SDT_Location.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E16012( )
      {
         /* Agendalocation_After Routine */
         returnInSub = false;
         if ( AV59SDT_AgendaLocation.FromJSonString(AV17result, null) )
         {
         }
      }

      public void gxep_loginwithqrcode( string aP0_secretKey ,
                                        out SdtSDT_LoginResidentResponse aP1_loginResult )
      {
         this.AV7secretKey = aP0_secretKey;
         AV21loginResult = new SdtSDT_LoginResidentResponse(context);
         initialize();
         /* LoginWithQrCode Constructor */
         new prc_loginresident(context ).execute(  AV7secretKey, out  AV17result) ;
         /* Execute user event: Loginwithqrcode.After */
         E12012 ();
         if ( returnInSub )
         {
            aP1_loginResult=this.AV21loginResult;
            return;
         }
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP1_loginResult=this.AV21loginResult;
            return;
         }
         aP1_loginResult=this.AV21loginResult;
      }

      public void gxep_getresidentinformation( string aP0_userId ,
                                               out SdtSDT_Resident aP1_SDT_Resident )
      {
         this.AV8userId = aP0_userId;
         AV22SDT_Resident = new SdtSDT_Resident(context);
         initialize();
         /* GetResidentInformation Constructor */
         new prc_getresidentinformation(context ).execute(  AV8userId, out  AV17result) ;
         /* Execute user event: Getresidentinformation.After */
         E13012 ();
         if ( returnInSub )
         {
            aP1_SDT_Resident=this.AV22SDT_Resident;
            return;
         }
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP1_SDT_Resident=this.AV22SDT_Resident;
            return;
         }
         aP1_SDT_Resident=this.AV22SDT_Resident;
      }

      public void gxep_getorganisationinformation( Guid aP0_organisationId ,
                                                   out SdtSDT_Organisation aP1_SDT_Organisation )
      {
         this.AV16organisationId = aP0_organisationId;
         AV23SDT_Organisation = new SdtSDT_Organisation(context);
         initialize();
         /* GetOrganisationInformation Constructor */
         new prc_getorganisationinformation(context ).execute(  AV16organisationId, out  AV17result) ;
         /* Execute user event: Getorganisationinformation.After */
         E14012 ();
         if ( returnInSub )
         {
            aP1_SDT_Organisation=this.AV23SDT_Organisation;
            return;
         }
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP1_SDT_Organisation=this.AV23SDT_Organisation;
            return;
         }
         aP1_SDT_Organisation=this.AV23SDT_Organisation;
      }

      public void gxep_getlocationinformation( Guid aP0_locationId ,
                                               out SdtSDT_Location aP1_SDT_Location )
      {
         this.AV12locationId = aP0_locationId;
         AV18SDT_Location = new SdtSDT_Location(context);
         initialize();
         /* GetLocationInformation Constructor */
         new prc_getlocationinformation(context ).execute(  AV12locationId, out  AV17result) ;
         /* Execute user event: Getlocationinformation.After */
         E15012 ();
         if ( returnInSub )
         {
            aP1_SDT_Location=this.AV18SDT_Location;
            return;
         }
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP1_SDT_Location=this.AV18SDT_Location;
            return;
         }
         aP1_SDT_Location=this.AV18SDT_Location;
      }

      public void gxep_registerdevice( string aP0_DeviceToken ,
                                       string aP1_DeviceID ,
                                       short aP2_DeviceType ,
                                       string aP3_NotificationPlatform ,
                                       string aP4_NotificationPlatformId ,
                                       string aP5_userId ,
                                       out string aP6_result )
      {
         this.AV10DeviceToken = aP0_DeviceToken;
         this.AV9DeviceID = aP1_DeviceID;
         this.AV11DeviceType = aP2_DeviceType;
         this.AV14NotificationPlatform = aP3_NotificationPlatform;
         this.AV15NotificationPlatformId = aP4_NotificationPlatformId;
         this.AV8userId = aP5_userId;
         initialize();
         /* RegisterDevice Constructor */
         new prc_registermobiledevice(context ).execute(  AV10DeviceToken,  AV9DeviceID,  AV11DeviceType,  AV14NotificationPlatform,  AV15NotificationPlatformId,  AV8userId, out  AV17result) ;
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP6_result=this.AV17result;
            return;
         }
         aP6_result=this.AV17result;
      }

      public void gxep_sendnotification( string aP0_title ,
                                         string aP1_message ,
                                         out string aP2_result )
      {
         this.AV19title = aP0_title;
         this.AV13message = aP1_message;
         initialize();
         /* SendNotification Constructor */
         new prc_sendnotification(context ).execute(  AV19title,  AV13message, out  AV17result) ;
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP2_result=this.AV17result;
            return;
         }
         aP2_result=this.AV17result;
      }

      public void gxep_agendalocation( Guid aP0_locationId ,
                                       out GXBaseCollection<SdtSDT_AgendaLocation> aP1_SDT_AgendaLocation )
      {
         this.AV12locationId = aP0_locationId;
         AV59SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         initialize();
         /* AgendaLocation Constructor */
         new prc_agendalocationapi(context ).execute(  AV12locationId, out  AV17result) ;
         /* Execute user event: Agendalocation.After */
         E16012 ();
         if ( returnInSub )
         {
            aP1_SDT_AgendaLocation=this.AV59SDT_AgendaLocation;
            return;
         }
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP1_SDT_AgendaLocation=this.AV59SDT_AgendaLocation;
            return;
         }
         aP1_SDT_AgendaLocation=this.AV59SDT_AgendaLocation;
      }

      public void gxep_senddynamicform( out string aP0_result )
      {
         initialize();
         /* SendDynamicForm Constructor */
         new prc_dynamicformapi(context ).execute( out  AV17result) ;
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP0_result=this.AV17result;
            return;
         }
         aP0_result=this.AV17result;
      }

      public void gxep_uploadmedia( Guid aP0_MediaId ,
                                    string aP1_MediaName ,
                                    string aP2_MediaImageData ,
                                    int aP3_MediaSize ,
                                    string aP4_MediaType ,
                                    out SdtTrn_Media aP5_BC_Trn_Media )
      {
         this.AV46MediaId = aP0_MediaId;
         this.AV47MediaName = aP1_MediaName;
         this.AV49MediaImageData = aP2_MediaImageData;
         this.AV51MediaSize = aP3_MediaSize;
         this.AV52MediaType = aP4_MediaType;
         initialize();
         /* UploadMedia Constructor */
         new prc_uploadmedia(context ).execute(  AV46MediaId,  AV47MediaName,  AV49MediaImageData,  AV51MediaSize,  AV52MediaType, out  AV50BC_Trn_Media) ;
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP5_BC_Trn_Media=this.AV50BC_Trn_Media;
            return;
         }
         aP5_BC_Trn_Media=this.AV50BC_Trn_Media;
      }

      public void gxep_productsericeapi( Guid aP0_ProductServiceId ,
                                         Guid aP1_locationId ,
                                         Guid aP2_organisationId ,
                                         out SdtSDT_ProductService aP3_SDT_ProductService )
      {
         this.AV66ProductServiceId = aP0_ProductServiceId;
         this.AV12locationId = aP1_locationId;
         this.AV16organisationId = aP2_organisationId;
         initialize();
         /* ProductSericeAPI Constructor */
         new prc_productserviceapi(context ).execute(  AV66ProductServiceId,  AV12locationId,  AV16organisationId, ref  AV67SDT_ProductService) ;
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP3_SDT_ProductService=this.AV67SDT_ProductService;
            return;
         }
         aP3_SDT_ProductService=this.AV67SDT_ProductService;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV17result = "";
         AV20SDT_LoginResidentResponse = new SdtSDT_LoginResidentResponse(context);
         AV21loginResult = new SdtSDT_LoginResidentResponse(context);
         AV22SDT_Resident = new SdtSDT_Resident(context);
         AV23SDT_Organisation = new SdtSDT_Organisation(context);
         AV18SDT_Location = new SdtSDT_Location(context);
         AV59SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         AV50BC_Trn_Media = new SdtTrn_Media(context);
         AV67SDT_ProductService = new SdtSDT_ProductService(context);
         /* GeneXus formulas. */
      }

      protected short AV11DeviceType ;
      protected int AV51MediaSize ;
      protected string Gx_restmethod ;
      protected string AV10DeviceToken ;
      protected string AV9DeviceID ;
      protected string AV52MediaType ;
      protected bool returnInSub ;
      protected string AV17result ;
      protected string AV7secretKey ;
      protected string AV49MediaImageData ;
      protected string AV8userId ;
      protected string AV14NotificationPlatform ;
      protected string AV15NotificationPlatformId ;
      protected string AV19title ;
      protected string AV13message ;
      protected string AV47MediaName ;
      protected Guid AV16organisationId ;
      protected Guid AV12locationId ;
      protected Guid AV46MediaId ;
      protected Guid AV66ProductServiceId ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected SdtSDT_LoginResidentResponse AV20SDT_LoginResidentResponse ;
      protected SdtSDT_LoginResidentResponse AV21loginResult ;
      protected SdtSDT_Resident AV22SDT_Resident ;
      protected SdtSDT_Organisation AV23SDT_Organisation ;
      protected SdtSDT_Location AV18SDT_Location ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> AV59SDT_AgendaLocation ;
      protected SdtSDT_LoginResidentResponse aP1_loginResult ;
      protected SdtSDT_Resident aP1_SDT_Resident ;
      protected SdtSDT_Organisation aP1_SDT_Organisation ;
      protected SdtSDT_Location aP1_SDT_Location ;
      protected string aP6_result ;
      protected string aP2_result ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> aP1_SDT_AgendaLocation ;
      protected string aP0_result ;
      protected SdtTrn_Media AV50BC_Trn_Media ;
      protected SdtTrn_Media aP5_BC_Trn_Media ;
      protected SdtSDT_ProductService AV67SDT_ProductService ;
      protected SdtSDT_ProductService aP3_SDT_ProductService ;
   }

}
