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
         initialize();
      }

      public api_residentservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         initialize();
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

      public void InitLocation( )
      {
         restLocation = new GxLocation();
         restLocation.Host = "localhost";
         restLocation.Port = 8082;
         restLocation.BaseUrl = "staging.comforta.yukon.software/api";
         gxProperties = new GxObjectProperties();
      }

      public GxObjectProperties ObjProperties
      {
         get {
            return gxProperties ;
         }

         set {
            gxProperties = value ;
         }

      }

      public void SetObjectProperties( GxObjectProperties gxobjppt )
      {
         gxProperties = gxobjppt ;
         restLocation = gxobjppt.Location ;
      }

      public void gxep_loginwithqrcode( string aP0_secretKey ,
                                        out SdtSDT_LoginResidentResponse aP1_loginResult )
      {
         restCliLoginWithQrCode = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident-login";
         restCliLoginWithQrCode.Location = restLocation;
         restCliLoginWithQrCode.HttpMethod = "POST";
         restCliLoginWithQrCode.AddBodyVar("secretKey", (string)(aP0_secretKey));
         restCliLoginWithQrCode.RestExecute();
         if ( restCliLoginWithQrCode.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliLoginWithQrCode.ErrorCode;
            gxProperties.ErrorMessage = restCliLoginWithQrCode.ErrorMessage;
            gxProperties.StatusCode = restCliLoginWithQrCode.StatusCode;
            aP1_loginResult = new SdtSDT_LoginResidentResponse();
         }
         else
         {
            aP1_loginResult = restCliLoginWithQrCode.GetBodySdt<SdtSDT_LoginResidentResponse>("loginResult");
         }
         /* LoginWithQrCode Constructor */
      }

      public void gxep_getresidentinformation( string aP0_userId ,
                                               out SdtSDT_Resident aP1_SDT_Resident )
      {
         restCliGetResidentInformation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident";
         restCliGetResidentInformation.Location = restLocation;
         restCliGetResidentInformation.HttpMethod = "GET";
         restCliGetResidentInformation.AddQueryVar("Userid", (string)(aP0_userId));
         restCliGetResidentInformation.RestExecute();
         if ( restCliGetResidentInformation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetResidentInformation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetResidentInformation.ErrorMessage;
            gxProperties.StatusCode = restCliGetResidentInformation.StatusCode;
            aP1_SDT_Resident = new SdtSDT_Resident();
         }
         else
         {
            aP1_SDT_Resident = restCliGetResidentInformation.GetBodySdt<SdtSDT_Resident>("SDT_Resident");
         }
         /* GetResidentInformation Constructor */
      }

      public void gxep_getorganisationinformation( Guid aP0_organisationId ,
                                                   out SdtSDT_Organisation aP1_SDT_Organisation )
      {
         restCliGetOrganisationInformation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/organisation";
         restCliGetOrganisationInformation.Location = restLocation;
         restCliGetOrganisationInformation.HttpMethod = "GET";
         restCliGetOrganisationInformation.AddQueryVar("Organisationid", (Guid)(aP0_organisationId));
         restCliGetOrganisationInformation.RestExecute();
         if ( restCliGetOrganisationInformation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetOrganisationInformation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetOrganisationInformation.ErrorMessage;
            gxProperties.StatusCode = restCliGetOrganisationInformation.StatusCode;
            aP1_SDT_Organisation = new SdtSDT_Organisation();
         }
         else
         {
            aP1_SDT_Organisation = restCliGetOrganisationInformation.GetBodySdt<SdtSDT_Organisation>("SDT_Organisation");
         }
         /* GetOrganisationInformation Constructor */
      }

      public void gxep_getlocationinformation( Guid aP0_locationId ,
                                               out SdtSDT_Location aP1_SDT_Location )
      {
         restCliGetLocationInformation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/location";
         restCliGetLocationInformation.Location = restLocation;
         restCliGetLocationInformation.HttpMethod = "GET";
         restCliGetLocationInformation.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliGetLocationInformation.RestExecute();
         if ( restCliGetLocationInformation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetLocationInformation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetLocationInformation.ErrorMessage;
            gxProperties.StatusCode = restCliGetLocationInformation.StatusCode;
            aP1_SDT_Location = new SdtSDT_Location();
         }
         else
         {
            aP1_SDT_Location = restCliGetLocationInformation.GetBodySdt<SdtSDT_Location>("SDT_Location");
         }
         /* GetLocationInformation Constructor */
      }

      public void gxep_registerdevice( string aP0_DeviceToken ,
                                       string aP1_DeviceID ,
                                       short aP2_DeviceType ,
                                       string aP3_NotificationPlatform ,
                                       string aP4_NotificationPlatformId ,
                                       string aP5_userId ,
                                       out string aP6_result )
      {
         restCliRegisterDevice = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/mobile/register-device";
         restCliRegisterDevice.Location = restLocation;
         restCliRegisterDevice.HttpMethod = "POST";
         restCliRegisterDevice.AddBodyVar("DeviceToken", (string)(aP0_DeviceToken));
         restCliRegisterDevice.AddBodyVar("DeviceID", (string)(aP1_DeviceID));
         restCliRegisterDevice.AddBodyVar("DeviceType", (short)(aP2_DeviceType));
         restCliRegisterDevice.AddBodyVar("NotificationPlatform", (string)(aP3_NotificationPlatform));
         restCliRegisterDevice.AddBodyVar("NotificationPlatformId", (string)(aP4_NotificationPlatformId));
         restCliRegisterDevice.AddBodyVar("userId", (string)(aP5_userId));
         restCliRegisterDevice.RestExecute();
         if ( restCliRegisterDevice.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliRegisterDevice.ErrorCode;
            gxProperties.ErrorMessage = restCliRegisterDevice.ErrorMessage;
            gxProperties.StatusCode = restCliRegisterDevice.StatusCode;
            aP6_result = "";
         }
         else
         {
            aP6_result = restCliRegisterDevice.GetBodyString("result");
         }
         /* RegisterDevice Constructor */
      }

      public void gxep_sendnotification( string aP0_title ,
                                         string aP1_message ,
                                         out string aP2_result )
      {
         restCliSendNotification = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/mobile/send-notification";
         restCliSendNotification.Location = restLocation;
         restCliSendNotification.HttpMethod = "POST";
         restCliSendNotification.AddBodyVar("title", (string)(aP0_title));
         restCliSendNotification.AddBodyVar("message", (string)(aP1_message));
         restCliSendNotification.RestExecute();
         if ( restCliSendNotification.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSendNotification.ErrorCode;
            gxProperties.ErrorMessage = restCliSendNotification.ErrorMessage;
            gxProperties.StatusCode = restCliSendNotification.StatusCode;
            aP2_result = "";
         }
         else
         {
            aP2_result = restCliSendNotification.GetBodyString("result");
         }
         /* SendNotification Constructor */
      }

      public void gxep_agendalocation( Guid aP0_locationId ,
                                       out GXBaseCollection<SdtSDT_AgendaLocation> aP1_SDT_AgendaLocation )
      {
         restCliAgendaLocation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/location/agenda";
         restCliAgendaLocation.Location = restLocation;
         restCliAgendaLocation.HttpMethod = "POST";
         restCliAgendaLocation.AddBodyVar("locationId", (Guid)(aP0_locationId));
         restCliAgendaLocation.RestExecute();
         if ( restCliAgendaLocation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliAgendaLocation.ErrorCode;
            gxProperties.ErrorMessage = restCliAgendaLocation.ErrorMessage;
            gxProperties.StatusCode = restCliAgendaLocation.StatusCode;
            aP1_SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>();
         }
         else
         {
            aP1_SDT_AgendaLocation = restCliAgendaLocation.GetBodySdtCollection<SdtSDT_AgendaLocation>("SDT_AgendaLocation");
         }
         /* AgendaLocation Constructor */
      }

      public void gxep_senddynamicform( out string aP0_result )
      {
         restCliSendDynamicForm = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/form/dynamic-form";
         restCliSendDynamicForm.Location = restLocation;
         restCliSendDynamicForm.HttpMethod = "GET";
         restCliSendDynamicForm.RestExecute();
         if ( restCliSendDynamicForm.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSendDynamicForm.ErrorCode;
            gxProperties.ErrorMessage = restCliSendDynamicForm.ErrorMessage;
            gxProperties.StatusCode = restCliSendDynamicForm.StatusCode;
            aP0_result = "";
         }
         else
         {
            aP0_result = restCliSendDynamicForm.GetBodyString("result");
         }
         /* SendDynamicForm Constructor */
      }

      public void gxep_uploadmedia( Guid aP0_MediaId ,
                                    string aP1_MediaName ,
                                    string aP2_MediaImageData ,
                                    int aP3_MediaSize ,
                                    string aP4_MediaType ,
                                    out SdtTrn_Media aP5_BC_Trn_Media )
      {
         restCliUploadMedia = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/media/upload";
         restCliUploadMedia.Location = restLocation;
         restCliUploadMedia.HttpMethod = "POST";
         restCliUploadMedia.AddBodyVar("MediaId", (Guid)(aP0_MediaId));
         restCliUploadMedia.AddBodyVar("MediaName", (string)(aP1_MediaName));
         restCliUploadMedia.AddBodyVar("MediaImageData", (string)(aP2_MediaImageData));
         restCliUploadMedia.AddBodyVar("MediaSize", (int)(aP3_MediaSize));
         restCliUploadMedia.AddBodyVar("MediaType", (string)(aP4_MediaType));
         restCliUploadMedia.RestExecute();
         if ( restCliUploadMedia.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUploadMedia.ErrorCode;
            gxProperties.ErrorMessage = restCliUploadMedia.ErrorMessage;
            gxProperties.StatusCode = restCliUploadMedia.StatusCode;
            aP5_BC_Trn_Media = new SdtTrn_Media();
         }
         else
         {
            aP5_BC_Trn_Media = restCliUploadMedia.GetBodySdt<SdtTrn_Media>("BC_Trn_Media");
         }
         /* UploadMedia Constructor */
      }

      public void gxep_productsericeapi( Guid aP0_ProductServiceId ,
                                         Guid aP1_locationId ,
                                         Guid aP2_organisationId ,
                                         out SdtSDT_ProductService aP3_SDT_ProductService )
      {
         restCliProductSericeAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/productservice/";
         restCliProductSericeAPI.Location = restLocation;
         restCliProductSericeAPI.HttpMethod = "GET";
         restCliProductSericeAPI.AddQueryVar("Productserviceid", (Guid)(aP0_ProductServiceId));
         restCliProductSericeAPI.AddQueryVar("Locationid", (Guid)(aP1_locationId));
         restCliProductSericeAPI.AddQueryVar("Organisationid", (Guid)(aP2_organisationId));
         restCliProductSericeAPI.RestExecute();
         if ( restCliProductSericeAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliProductSericeAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliProductSericeAPI.ErrorMessage;
            gxProperties.StatusCode = restCliProductSericeAPI.StatusCode;
            aP3_SDT_ProductService = new SdtSDT_ProductService();
         }
         else
         {
            aP3_SDT_ProductService = restCliProductSericeAPI.GetBodySdt<SdtSDT_ProductService>("SDT_ProductService");
         }
         /* ProductSericeAPI Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         gxProperties = new GxObjectProperties();
         restCliLoginWithQrCode = new GXRestAPIClient();
         aP1_loginResult = new SdtSDT_LoginResidentResponse();
         restCliGetResidentInformation = new GXRestAPIClient();
         aP1_SDT_Resident = new SdtSDT_Resident();
         restCliGetOrganisationInformation = new GXRestAPIClient();
         aP1_SDT_Organisation = new SdtSDT_Organisation();
         restCliGetLocationInformation = new GXRestAPIClient();
         aP1_SDT_Location = new SdtSDT_Location();
         restCliRegisterDevice = new GXRestAPIClient();
         aP6_result = "";
         restCliSendNotification = new GXRestAPIClient();
         aP2_result = "";
         restCliAgendaLocation = new GXRestAPIClient();
         aP1_SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>();
         restCliSendDynamicForm = new GXRestAPIClient();
         aP0_result = "";
         restCliUploadMedia = new GXRestAPIClient();
         aP5_BC_Trn_Media = new SdtTrn_Media();
         restCliProductSericeAPI = new GXRestAPIClient();
         aP3_SDT_ProductService = new SdtSDT_ProductService();
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliLoginWithQrCode ;
      protected GXRestAPIClient restCliGetResidentInformation ;
      protected GXRestAPIClient restCliGetOrganisationInformation ;
      protected GXRestAPIClient restCliGetLocationInformation ;
      protected GXRestAPIClient restCliRegisterDevice ;
      protected GXRestAPIClient restCliSendNotification ;
      protected GXRestAPIClient restCliAgendaLocation ;
      protected GXRestAPIClient restCliSendDynamicForm ;
      protected GXRestAPIClient restCliUploadMedia ;
      protected GXRestAPIClient restCliProductSericeAPI ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected SdtSDT_LoginResidentResponse aP1_loginResult ;
      protected SdtSDT_Resident aP1_SDT_Resident ;
      protected SdtSDT_Organisation aP1_SDT_Organisation ;
      protected SdtSDT_Location aP1_SDT_Location ;
      protected string aP6_result ;
      protected string aP2_result ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> aP1_SDT_AgendaLocation ;
      protected string aP0_result ;
      protected SdtTrn_Media aP5_BC_Trn_Media ;
      protected SdtSDT_ProductService aP3_SDT_ProductService ;
   }

}
