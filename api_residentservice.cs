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
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel ApiIntegratedSecurityLevel( string permissionMethod )
      {
         if ( StringUtil.StrCmp(permissionMethod, "gxep_loginwithqrcode") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getresidentinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getorganisationinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getlocationinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_registerdevice") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_sendnotification") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getpagesinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_uploadmedia") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getpages") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_listpages") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createpage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_savepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updatepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_addpagecildren") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         return GAMSecurityLevel.SecurityLow ;
      }

      protected override string ApiExecutePermissionPrefix( string permissionMethod )
      {
         return "" ;
      }

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
         /* Getpagesinformation_After Routine */
         returnInSub = false;
         if ( AV44SDT_PageCollection.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E17012( )
      {
         /* Getpages_After Routine */
         returnInSub = false;
         if ( AV44SDT_PageCollection.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E18012( )
      {
         /* Listpages_After Routine */
         returnInSub = false;
         if ( AV64SDT_PageStructureCollection.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E19012( )
      {
         /* Uploadmedia_After Routine */
         returnInSub = false;
         if ( AV50BC_Trn_Media.FromJSonString(AV17result, null) )
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

      public void gxep_getpagesinformation( Guid aP0_Trn_PageId ,
                                            out GXBaseCollection<SdtSDT_Page> aP1_SDT_PageCollection )
      {
         this.AV43Trn_PageId = aP0_Trn_PageId;
         AV44SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         initialize();
         /* GetPagesInformation Constructor */
         new prc_pagesapi(context ).execute(  AV43Trn_PageId, out  AV17result) ;
         /* Execute user event: Getpagesinformation.After */
         E16012 ();
         if ( returnInSub )
         {
            aP1_SDT_PageCollection=this.AV44SDT_PageCollection;
            return;
         }
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP1_SDT_PageCollection=this.AV44SDT_PageCollection;
            return;
         }
         aP1_SDT_PageCollection=this.AV44SDT_PageCollection;
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
         AV50BC_Trn_Media = new SdtTrn_Media(context);
         initialize();
         /* UploadMedia Constructor */
         new prc_uploadmedia(context ).execute(  AV46MediaId,  AV47MediaName,  AV49MediaImageData,  AV51MediaSize,  AV52MediaType, out  AV17result) ;
         /* Execute user event: Uploadmedia.After */
         E19012 ();
         if ( returnInSub )
         {
            aP5_BC_Trn_Media=this.AV50BC_Trn_Media;
            return;
         }
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP5_BC_Trn_Media=this.AV50BC_Trn_Media;
            return;
         }
         aP5_BC_Trn_Media=this.AV50BC_Trn_Media;
      }

      public void gxep_getpages( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection )
      {
         AV44SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         initialize();
         /* GetPages Constructor */
         new prc_getpages(context ).execute( out  AV17result) ;
         /* Execute user event: Getpages.After */
         E17012 ();
         if ( returnInSub )
         {
            aP0_SDT_PageCollection=this.AV44SDT_PageCollection;
            return;
         }
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP0_SDT_PageCollection=this.AV44SDT_PageCollection;
            return;
         }
         aP0_SDT_PageCollection=this.AV44SDT_PageCollection;
      }

      public void gxep_listpages( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection )
      {
         AV64SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         initialize();
         /* ListPages Constructor */
         new prc_listpages(context ).execute( out  AV17result) ;
         /* Execute user event: Listpages.After */
         E18012 ();
         if ( returnInSub )
         {
            aP0_SDT_PageStructureCollection=this.AV64SDT_PageStructureCollection;
            return;
         }
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP0_SDT_PageStructureCollection=this.AV64SDT_PageStructureCollection;
            return;
         }
         aP0_SDT_PageStructureCollection=this.AV64SDT_PageStructureCollection;
      }

      public void gxep_createpage( string aP0_PageName ,
                                   out string aP1_result )
      {
         this.AV60PageName = aP0_PageName;
         initialize();
         /* CreatePage Constructor */
         new prc_createpage(context ).execute(  AV60PageName, ref  AV17result) ;
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP1_result=this.AV17result;
            return;
         }
         aP1_result=this.AV17result;
      }

      public void gxep_savepage( Guid aP0_PageId ,
                                 string aP1_PageJsonContent ,
                                 string aP2_PageGJSHtml ,
                                 string aP3_PageGJSJson ,
                                 SdtSDT_Page aP4_SDT_Page ,
                                 out string aP5_result )
      {
         this.AV54PageId = aP0_PageId;
         this.AV58PageJsonContent = aP1_PageJsonContent;
         this.AV56PageGJSHtml = aP2_PageGJSHtml;
         this.AV57PageGJSJson = aP3_PageGJSJson;
         this.AV55SDT_Page = aP4_SDT_Page;
         initialize();
         /* SavePage Constructor */
         new prc_savepage(context ).execute(  AV54PageId,  AV58PageJsonContent,  AV56PageGJSHtml,  AV57PageGJSJson,  AV55SDT_Page, ref  AV17result) ;
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP5_result=this.AV17result;
            return;
         }
         aP5_result=this.AV17result;
      }

      public void gxep_updatepage( Guid aP0_PageId ,
                                   string aP1_PageJsonContent ,
                                   string aP2_PageGJSHtml ,
                                   string aP3_PageGJSJson ,
                                   bool aP4_PageIsPublished ,
                                   out string aP5_result )
      {
         this.AV54PageId = aP0_PageId;
         this.AV58PageJsonContent = aP1_PageJsonContent;
         this.AV56PageGJSHtml = aP2_PageGJSHtml;
         this.AV57PageGJSJson = aP3_PageGJSJson;
         this.AV65PageIsPublished = aP4_PageIsPublished;
         initialize();
         /* UpdatePage Constructor */
         new prc_updatepage(context ).execute( ref  AV54PageId, ref  AV58PageJsonContent, ref  AV56PageGJSHtml, ref  AV57PageGJSJson, ref  AV65PageIsPublished, out  AV17result) ;
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP5_result=this.AV17result;
            return;
         }
         aP5_result=this.AV17result;
      }

      public void gxep_addpagecildren( Guid aP0_ParentPageId ,
                                       Guid aP1_ChildPageId ,
                                       out string aP2_result )
      {
         this.AV61ParentPageId = aP0_ParentPageId;
         this.AV62ChildPageId = aP1_ChildPageId;
         initialize();
         /* AddPageCildren Constructor */
         new prc_addpagechildren(context ).execute(  AV61ParentPageId,  AV62ChildPageId, out  AV17result) ;
         /* Execute user event: After */
         E11012 ();
         if ( returnInSub )
         {
            aP2_result=this.AV17result;
            return;
         }
         aP2_result=this.AV17result;
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
         AV44SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         AV64SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV50BC_Trn_Media = new SdtTrn_Media(context);
         /* GeneXus formulas. */
      }

      protected short AV11DeviceType ;
      protected int AV51MediaSize ;
      protected string Gx_restmethod ;
      protected string AV10DeviceToken ;
      protected string AV9DeviceID ;
      protected string AV52MediaType ;
      protected bool returnInSub ;
      protected bool AV65PageIsPublished ;
      protected string AV17result ;
      protected string AV7secretKey ;
      protected string AV49MediaImageData ;
      protected string AV58PageJsonContent ;
      protected string AV56PageGJSHtml ;
      protected string AV57PageGJSJson ;
      protected string AV8userId ;
      protected string AV14NotificationPlatform ;
      protected string AV15NotificationPlatformId ;
      protected string AV19title ;
      protected string AV13message ;
      protected string AV47MediaName ;
      protected string AV60PageName ;
      protected Guid AV16organisationId ;
      protected Guid AV12locationId ;
      protected Guid AV43Trn_PageId ;
      protected Guid AV46MediaId ;
      protected Guid AV54PageId ;
      protected Guid AV61ParentPageId ;
      protected Guid AV62ChildPageId ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected SdtSDT_LoginResidentResponse AV20SDT_LoginResidentResponse ;
      protected SdtSDT_LoginResidentResponse AV21loginResult ;
      protected SdtSDT_Resident AV22SDT_Resident ;
      protected SdtSDT_Organisation AV23SDT_Organisation ;
      protected SdtSDT_Location AV18SDT_Location ;
      protected GXBaseCollection<SdtSDT_Page> AV44SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_PageStructure> AV64SDT_PageStructureCollection ;
      protected SdtTrn_Media AV50BC_Trn_Media ;
      protected SdtSDT_LoginResidentResponse aP1_loginResult ;
      protected SdtSDT_Resident aP1_SDT_Resident ;
      protected SdtSDT_Organisation aP1_SDT_Organisation ;
      protected SdtSDT_Location aP1_SDT_Location ;
      protected string aP6_result ;
      protected string aP2_result ;
      protected GXBaseCollection<SdtSDT_Page> aP1_SDT_PageCollection ;
      protected SdtTrn_Media aP5_BC_Trn_Media ;
      protected GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ;
      protected string aP1_result ;
      protected SdtSDT_Page AV55SDT_Page ;
      protected string aP5_result ;
   }

}
