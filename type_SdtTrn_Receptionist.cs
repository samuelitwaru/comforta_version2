using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Trn_Receptionist" )]
   [XmlType(TypeName =  "Trn_Receptionist" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Receptionist : GxSilentTrnSdt
   {
      public SdtTrn_Receptionist( )
      {
      }

      public SdtTrn_Receptionist( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( Guid AV89ReceptionistId ,
                        Guid AV11OrganisationId ,
                        Guid AV29LocationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV89ReceptionistId,(Guid)AV11OrganisationId,(Guid)AV29LocationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ReceptionistId", typeof(Guid)}, new Object[]{"OrganisationId", typeof(Guid)}, new Object[]{"LocationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Receptionist");
         metadata.Set("BT", "Trn_Receptionist");
         metadata.Set("PK", "[ \"ReceptionistId\",\"OrganisationId\",\"LocationId\" ]");
         metadata.Set("PKAssigned", "[ \"OrganisationId\",\"ReceptionistId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"OrganisationId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Receptionistid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Receptionistgivenname_Z");
         state.Add("gxTpr_Receptionistlastname_Z");
         state.Add("gxTpr_Receptionistinitials_Z");
         state.Add("gxTpr_Receptionistemail_Z");
         state.Add("gxTpr_Receptionistphonecode_Z");
         state.Add("gxTpr_Receptionistphone_Z");
         state.Add("gxTpr_Receptionistphonenumber_Z");
         state.Add("gxTpr_Receptionistgamguid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Receptionist sdt;
         sdt = (SdtTrn_Receptionist)(source);
         gxTv_SdtTrn_Receptionist_Receptionistid = sdt.gxTv_SdtTrn_Receptionist_Receptionistid ;
         gxTv_SdtTrn_Receptionist_Organisationid = sdt.gxTv_SdtTrn_Receptionist_Organisationid ;
         gxTv_SdtTrn_Receptionist_Locationid = sdt.gxTv_SdtTrn_Receptionist_Locationid ;
         gxTv_SdtTrn_Receptionist_Receptionistgivenname = sdt.gxTv_SdtTrn_Receptionist_Receptionistgivenname ;
         gxTv_SdtTrn_Receptionist_Receptionistlastname = sdt.gxTv_SdtTrn_Receptionist_Receptionistlastname ;
         gxTv_SdtTrn_Receptionist_Receptionistinitials = sdt.gxTv_SdtTrn_Receptionist_Receptionistinitials ;
         gxTv_SdtTrn_Receptionist_Receptionistemail = sdt.gxTv_SdtTrn_Receptionist_Receptionistemail ;
         gxTv_SdtTrn_Receptionist_Receptionistphonecode = sdt.gxTv_SdtTrn_Receptionist_Receptionistphonecode ;
         gxTv_SdtTrn_Receptionist_Receptionistphone = sdt.gxTv_SdtTrn_Receptionist_Receptionistphone ;
         gxTv_SdtTrn_Receptionist_Receptionistphonenumber = sdt.gxTv_SdtTrn_Receptionist_Receptionistphonenumber ;
         gxTv_SdtTrn_Receptionist_Receptionistgamguid = sdt.gxTv_SdtTrn_Receptionist_Receptionistgamguid ;
         gxTv_SdtTrn_Receptionist_Mode = sdt.gxTv_SdtTrn_Receptionist_Mode ;
         gxTv_SdtTrn_Receptionist_Initialized = sdt.gxTv_SdtTrn_Receptionist_Initialized ;
         gxTv_SdtTrn_Receptionist_Receptionistid_Z = sdt.gxTv_SdtTrn_Receptionist_Receptionistid_Z ;
         gxTv_SdtTrn_Receptionist_Organisationid_Z = sdt.gxTv_SdtTrn_Receptionist_Organisationid_Z ;
         gxTv_SdtTrn_Receptionist_Locationid_Z = sdt.gxTv_SdtTrn_Receptionist_Locationid_Z ;
         gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z = sdt.gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z ;
         gxTv_SdtTrn_Receptionist_Receptionistlastname_Z = sdt.gxTv_SdtTrn_Receptionist_Receptionistlastname_Z ;
         gxTv_SdtTrn_Receptionist_Receptionistinitials_Z = sdt.gxTv_SdtTrn_Receptionist_Receptionistinitials_Z ;
         gxTv_SdtTrn_Receptionist_Receptionistemail_Z = sdt.gxTv_SdtTrn_Receptionist_Receptionistemail_Z ;
         gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z = sdt.gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z ;
         gxTv_SdtTrn_Receptionist_Receptionistphone_Z = sdt.gxTv_SdtTrn_Receptionist_Receptionistphone_Z ;
         gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z = sdt.gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z ;
         gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z = sdt.gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("ReceptionistId", gxTv_SdtTrn_Receptionist_Receptionistid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Receptionist_Organisationid, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_Receptionist_Locationid, false, includeNonInitialized);
         AddObjectProperty("ReceptionistGivenName", gxTv_SdtTrn_Receptionist_Receptionistgivenname, false, includeNonInitialized);
         AddObjectProperty("ReceptionistLastName", gxTv_SdtTrn_Receptionist_Receptionistlastname, false, includeNonInitialized);
         AddObjectProperty("ReceptionistInitials", gxTv_SdtTrn_Receptionist_Receptionistinitials, false, includeNonInitialized);
         AddObjectProperty("ReceptionistEmail", gxTv_SdtTrn_Receptionist_Receptionistemail, false, includeNonInitialized);
         AddObjectProperty("ReceptionistPhoneCode", gxTv_SdtTrn_Receptionist_Receptionistphonecode, false, includeNonInitialized);
         AddObjectProperty("ReceptionistPhone", gxTv_SdtTrn_Receptionist_Receptionistphone, false, includeNonInitialized);
         AddObjectProperty("ReceptionistPhoneNumber", gxTv_SdtTrn_Receptionist_Receptionistphonenumber, false, includeNonInitialized);
         AddObjectProperty("ReceptionistGAMGUID", gxTv_SdtTrn_Receptionist_Receptionistgamguid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Receptionist_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Receptionist_Initialized, false, includeNonInitialized);
            AddObjectProperty("ReceptionistId_Z", gxTv_SdtTrn_Receptionist_Receptionistid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Receptionist_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_Receptionist_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("ReceptionistGivenName_Z", gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z, false, includeNonInitialized);
            AddObjectProperty("ReceptionistLastName_Z", gxTv_SdtTrn_Receptionist_Receptionistlastname_Z, false, includeNonInitialized);
            AddObjectProperty("ReceptionistInitials_Z", gxTv_SdtTrn_Receptionist_Receptionistinitials_Z, false, includeNonInitialized);
            AddObjectProperty("ReceptionistEmail_Z", gxTv_SdtTrn_Receptionist_Receptionistemail_Z, false, includeNonInitialized);
            AddObjectProperty("ReceptionistPhoneCode_Z", gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z, false, includeNonInitialized);
            AddObjectProperty("ReceptionistPhone_Z", gxTv_SdtTrn_Receptionist_Receptionistphone_Z, false, includeNonInitialized);
            AddObjectProperty("ReceptionistPhoneNumber_Z", gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z, false, includeNonInitialized);
            AddObjectProperty("ReceptionistGAMGUID_Z", gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Receptionist sdt )
      {
         if ( sdt.IsDirty("ReceptionistId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistid = sdt.gxTv_SdtTrn_Receptionist_Receptionistid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Organisationid = sdt.gxTv_SdtTrn_Receptionist_Organisationid ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Locationid = sdt.gxTv_SdtTrn_Receptionist_Locationid ;
         }
         if ( sdt.IsDirty("ReceptionistGivenName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistgivenname = sdt.gxTv_SdtTrn_Receptionist_Receptionistgivenname ;
         }
         if ( sdt.IsDirty("ReceptionistLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistlastname = sdt.gxTv_SdtTrn_Receptionist_Receptionistlastname ;
         }
         if ( sdt.IsDirty("ReceptionistInitials") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistinitials = sdt.gxTv_SdtTrn_Receptionist_Receptionistinitials ;
         }
         if ( sdt.IsDirty("ReceptionistEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistemail = sdt.gxTv_SdtTrn_Receptionist_Receptionistemail ;
         }
         if ( sdt.IsDirty("ReceptionistPhoneCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistphonecode = sdt.gxTv_SdtTrn_Receptionist_Receptionistphonecode ;
         }
         if ( sdt.IsDirty("ReceptionistPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistphone = sdt.gxTv_SdtTrn_Receptionist_Receptionistphone ;
         }
         if ( sdt.IsDirty("ReceptionistPhoneNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistphonenumber = sdt.gxTv_SdtTrn_Receptionist_Receptionistphonenumber ;
         }
         if ( sdt.IsDirty("ReceptionistGAMGUID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistgamguid = sdt.gxTv_SdtTrn_Receptionist_Receptionistgamguid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ReceptionistId" )]
      [  XmlElement( ElementName = "ReceptionistId"   )]
      public Guid gxTpr_Receptionistid
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Receptionist_Receptionistid != value )
            {
               gxTv_SdtTrn_Receptionist_Mode = "INS";
               this.gxTv_SdtTrn_Receptionist_Receptionistid_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistlastname_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistinitials_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistemail_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistphone_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z_SetNull( );
            }
            gxTv_SdtTrn_Receptionist_Receptionistid = value;
            SetDirty("Receptionistid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Receptionist_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Receptionist_Organisationid != value )
            {
               gxTv_SdtTrn_Receptionist_Mode = "INS";
               this.gxTv_SdtTrn_Receptionist_Receptionistid_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistlastname_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistinitials_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistemail_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistphone_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z_SetNull( );
            }
            gxTv_SdtTrn_Receptionist_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_Receptionist_Locationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Receptionist_Locationid != value )
            {
               gxTv_SdtTrn_Receptionist_Mode = "INS";
               this.gxTv_SdtTrn_Receptionist_Receptionistid_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistlastname_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistinitials_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistemail_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistphone_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z_SetNull( );
               this.gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z_SetNull( );
            }
            gxTv_SdtTrn_Receptionist_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "ReceptionistGivenName" )]
      [  XmlElement( ElementName = "ReceptionistGivenName"   )]
      public string gxTpr_Receptionistgivenname
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistgivenname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistgivenname = value;
            SetDirty("Receptionistgivenname");
         }

      }

      [  SoapElement( ElementName = "ReceptionistLastName" )]
      [  XmlElement( ElementName = "ReceptionistLastName"   )]
      public string gxTpr_Receptionistlastname
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistlastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistlastname = value;
            SetDirty("Receptionistlastname");
         }

      }

      [  SoapElement( ElementName = "ReceptionistInitials" )]
      [  XmlElement( ElementName = "ReceptionistInitials"   )]
      public string gxTpr_Receptionistinitials
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistinitials ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistinitials = value;
            SetDirty("Receptionistinitials");
         }

      }

      [  SoapElement( ElementName = "ReceptionistEmail" )]
      [  XmlElement( ElementName = "ReceptionistEmail"   )]
      public string gxTpr_Receptionistemail
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistemail = value;
            SetDirty("Receptionistemail");
         }

      }

      [  SoapElement( ElementName = "ReceptionistPhoneCode" )]
      [  XmlElement( ElementName = "ReceptionistPhoneCode"   )]
      public string gxTpr_Receptionistphonecode
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistphonecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistphonecode = value;
            SetDirty("Receptionistphonecode");
         }

      }

      [  SoapElement( ElementName = "ReceptionistPhone" )]
      [  XmlElement( ElementName = "ReceptionistPhone"   )]
      public string gxTpr_Receptionistphone
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistphone = value;
            SetDirty("Receptionistphone");
         }

      }

      [  SoapElement( ElementName = "ReceptionistPhoneNumber" )]
      [  XmlElement( ElementName = "ReceptionistPhoneNumber"   )]
      public string gxTpr_Receptionistphonenumber
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistphonenumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistphonenumber = value;
            SetDirty("Receptionistphonenumber");
         }

      }

      [  SoapElement( ElementName = "ReceptionistGAMGUID" )]
      [  XmlElement( ElementName = "ReceptionistGAMGUID"   )]
      public string gxTpr_Receptionistgamguid
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistgamguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistgamguid = value;
            SetDirty("Receptionistgamguid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Receptionist_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Mode_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Receptionist_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionistId_Z" )]
      [  XmlElement( ElementName = "ReceptionistId_Z"   )]
      public Guid gxTpr_Receptionistid_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistid_Z = value;
            SetDirty("Receptionistid_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Receptionistid_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Receptionistid_Z = Guid.Empty;
         SetDirty("Receptionistid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Receptionistid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionistGivenName_Z" )]
      [  XmlElement( ElementName = "ReceptionistGivenName_Z"   )]
      public string gxTpr_Receptionistgivenname_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z = value;
            SetDirty("Receptionistgivenname_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z = "";
         SetDirty("Receptionistgivenname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionistLastName_Z" )]
      [  XmlElement( ElementName = "ReceptionistLastName_Z"   )]
      public string gxTpr_Receptionistlastname_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistlastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistlastname_Z = value;
            SetDirty("Receptionistlastname_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Receptionistlastname_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Receptionistlastname_Z = "";
         SetDirty("Receptionistlastname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Receptionistlastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionistInitials_Z" )]
      [  XmlElement( ElementName = "ReceptionistInitials_Z"   )]
      public string gxTpr_Receptionistinitials_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistinitials_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistinitials_Z = value;
            SetDirty("Receptionistinitials_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Receptionistinitials_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Receptionistinitials_Z = "";
         SetDirty("Receptionistinitials_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Receptionistinitials_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionistEmail_Z" )]
      [  XmlElement( ElementName = "ReceptionistEmail_Z"   )]
      public string gxTpr_Receptionistemail_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistemail_Z = value;
            SetDirty("Receptionistemail_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Receptionistemail_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Receptionistemail_Z = "";
         SetDirty("Receptionistemail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Receptionistemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionistPhoneCode_Z" )]
      [  XmlElement( ElementName = "ReceptionistPhoneCode_Z"   )]
      public string gxTpr_Receptionistphonecode_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z = value;
            SetDirty("Receptionistphonecode_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z = "";
         SetDirty("Receptionistphonecode_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionistPhone_Z" )]
      [  XmlElement( ElementName = "ReceptionistPhone_Z"   )]
      public string gxTpr_Receptionistphone_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistphone_Z = value;
            SetDirty("Receptionistphone_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Receptionistphone_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Receptionistphone_Z = "";
         SetDirty("Receptionistphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Receptionistphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionistPhoneNumber_Z" )]
      [  XmlElement( ElementName = "ReceptionistPhoneNumber_Z"   )]
      public string gxTpr_Receptionistphonenumber_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z = value;
            SetDirty("Receptionistphonenumber_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z = "";
         SetDirty("Receptionistphonenumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReceptionistGAMGUID_Z" )]
      [  XmlElement( ElementName = "ReceptionistGAMGUID_Z"   )]
      public string gxTpr_Receptionistgamguid_Z
      {
         get {
            return gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z = value;
            SetDirty("Receptionistgamguid_Z");
         }

      }

      public void gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z_SetNull( )
      {
         gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z = "";
         SetDirty("Receptionistgamguid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         gxTv_SdtTrn_Receptionist_Receptionistid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Receptionist_Organisationid = Guid.Empty;
         gxTv_SdtTrn_Receptionist_Locationid = Guid.Empty;
         gxTv_SdtTrn_Receptionist_Receptionistgivenname = "";
         gxTv_SdtTrn_Receptionist_Receptionistlastname = "";
         gxTv_SdtTrn_Receptionist_Receptionistinitials = "";
         gxTv_SdtTrn_Receptionist_Receptionistemail = "";
         gxTv_SdtTrn_Receptionist_Receptionistphonecode = "";
         gxTv_SdtTrn_Receptionist_Receptionistphone = "";
         gxTv_SdtTrn_Receptionist_Receptionistphonenumber = "";
         gxTv_SdtTrn_Receptionist_Receptionistgamguid = "";
         gxTv_SdtTrn_Receptionist_Mode = "";
         gxTv_SdtTrn_Receptionist_Receptionistid_Z = Guid.Empty;
         gxTv_SdtTrn_Receptionist_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Receptionist_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z = "";
         gxTv_SdtTrn_Receptionist_Receptionistlastname_Z = "";
         gxTv_SdtTrn_Receptionist_Receptionistinitials_Z = "";
         gxTv_SdtTrn_Receptionist_Receptionistemail_Z = "";
         gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z = "";
         gxTv_SdtTrn_Receptionist_Receptionistphone_Z = "";
         gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z = "";
         gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_receptionist", "GeneXus.Programs.trn_receptionist_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_Receptionist_Initialized ;
      private string gxTv_SdtTrn_Receptionist_Receptionistinitials ;
      private string gxTv_SdtTrn_Receptionist_Receptionistphone ;
      private string gxTv_SdtTrn_Receptionist_Mode ;
      private string gxTv_SdtTrn_Receptionist_Receptionistinitials_Z ;
      private string gxTv_SdtTrn_Receptionist_Receptionistphone_Z ;
      private string gxTv_SdtTrn_Receptionist_Receptionistgivenname ;
      private string gxTv_SdtTrn_Receptionist_Receptionistlastname ;
      private string gxTv_SdtTrn_Receptionist_Receptionistemail ;
      private string gxTv_SdtTrn_Receptionist_Receptionistphonecode ;
      private string gxTv_SdtTrn_Receptionist_Receptionistphonenumber ;
      private string gxTv_SdtTrn_Receptionist_Receptionistgamguid ;
      private string gxTv_SdtTrn_Receptionist_Receptionistgivenname_Z ;
      private string gxTv_SdtTrn_Receptionist_Receptionistlastname_Z ;
      private string gxTv_SdtTrn_Receptionist_Receptionistemail_Z ;
      private string gxTv_SdtTrn_Receptionist_Receptionistphonecode_Z ;
      private string gxTv_SdtTrn_Receptionist_Receptionistphonenumber_Z ;
      private string gxTv_SdtTrn_Receptionist_Receptionistgamguid_Z ;
      private Guid gxTv_SdtTrn_Receptionist_Receptionistid ;
      private Guid gxTv_SdtTrn_Receptionist_Organisationid ;
      private Guid gxTv_SdtTrn_Receptionist_Locationid ;
      private Guid gxTv_SdtTrn_Receptionist_Receptionistid_Z ;
      private Guid gxTv_SdtTrn_Receptionist_Organisationid_Z ;
      private Guid gxTv_SdtTrn_Receptionist_Locationid_Z ;
   }

   [DataContract(Name = @"Trn_Receptionist", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Receptionist_RESTInterface : GxGenericCollectionItem<SdtTrn_Receptionist>
   {
      public SdtTrn_Receptionist_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Receptionist_RESTInterface( SdtTrn_Receptionist psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReceptionistId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Receptionistid
      {
         get {
            return sdt.gxTpr_Receptionistid ;
         }

         set {
            sdt.gxTpr_Receptionistid = value;
         }

      }

      [DataMember( Name = "OrganisationId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationid
      {
         get {
            return sdt.gxTpr_Organisationid ;
         }

         set {
            sdt.gxTpr_Organisationid = value;
         }

      }

      [DataMember( Name = "LocationId" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Locationid
      {
         get {
            return sdt.gxTpr_Locationid ;
         }

         set {
            sdt.gxTpr_Locationid = value;
         }

      }

      [DataMember( Name = "ReceptionistGivenName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Receptionistgivenname
      {
         get {
            return sdt.gxTpr_Receptionistgivenname ;
         }

         set {
            sdt.gxTpr_Receptionistgivenname = value;
         }

      }

      [DataMember( Name = "ReceptionistLastName" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Receptionistlastname
      {
         get {
            return sdt.gxTpr_Receptionistlastname ;
         }

         set {
            sdt.gxTpr_Receptionistlastname = value;
         }

      }

      [DataMember( Name = "ReceptionistInitials" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Receptionistinitials
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Receptionistinitials) ;
         }

         set {
            sdt.gxTpr_Receptionistinitials = value;
         }

      }

      [DataMember( Name = "ReceptionistEmail" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Receptionistemail
      {
         get {
            return sdt.gxTpr_Receptionistemail ;
         }

         set {
            sdt.gxTpr_Receptionistemail = value;
         }

      }

      [DataMember( Name = "ReceptionistPhoneCode" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Receptionistphonecode
      {
         get {
            return sdt.gxTpr_Receptionistphonecode ;
         }

         set {
            sdt.gxTpr_Receptionistphonecode = value;
         }

      }

      [DataMember( Name = "ReceptionistPhone" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Receptionistphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Receptionistphone) ;
         }

         set {
            sdt.gxTpr_Receptionistphone = value;
         }

      }

      [DataMember( Name = "ReceptionistPhoneNumber" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Receptionistphonenumber
      {
         get {
            return sdt.gxTpr_Receptionistphonenumber ;
         }

         set {
            sdt.gxTpr_Receptionistphonenumber = value;
         }

      }

      [DataMember( Name = "ReceptionistGAMGUID" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Receptionistgamguid
      {
         get {
            return sdt.gxTpr_Receptionistgamguid ;
         }

         set {
            sdt.gxTpr_Receptionistgamguid = value;
         }

      }

      public SdtTrn_Receptionist sdt
      {
         get {
            return (SdtTrn_Receptionist)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrn_Receptionist() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 11 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Trn_Receptionist", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Receptionist_RESTLInterface : GxGenericCollectionItem<SdtTrn_Receptionist>
   {
      public SdtTrn_Receptionist_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Receptionist_RESTLInterface( SdtTrn_Receptionist psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReceptionistGivenName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Receptionistgivenname
      {
         get {
            return sdt.gxTpr_Receptionistgivenname ;
         }

         set {
            sdt.gxTpr_Receptionistgivenname = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_Receptionist sdt
      {
         get {
            return (SdtTrn_Receptionist)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrn_Receptionist() ;
         }
      }

   }

}
