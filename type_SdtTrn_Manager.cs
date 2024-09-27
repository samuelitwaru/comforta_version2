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
   [XmlRoot(ElementName = "Trn_Manager" )]
   [XmlType(TypeName =  "Trn_Manager" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Manager : GxSilentTrnSdt
   {
      public SdtTrn_Manager( )
      {
      }

      public SdtTrn_Manager( IGxContext context )
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

      public void Load( Guid AV21ManagerId ,
                        Guid AV11OrganisationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV21ManagerId,(Guid)AV11OrganisationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ManagerId", typeof(Guid)}, new Object[]{"OrganisationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Manager");
         metadata.Set("BT", "Trn_Manager");
         metadata.Set("PK", "[ \"ManagerId\",\"OrganisationId\" ]");
         metadata.Set("PKAssigned", "[ \"ManagerId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"OrganisationId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Managerid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Managergivenname_Z");
         state.Add("gxTpr_Managerlastname_Z");
         state.Add("gxTpr_Managerinitials_Z");
         state.Add("gxTpr_Manageremail_Z");
         state.Add("gxTpr_Managerphone_Z");
         state.Add("gxTpr_Managergender_Z");
         state.Add("gxTpr_Managergamguid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Manager sdt;
         sdt = (SdtTrn_Manager)(source);
         gxTv_SdtTrn_Manager_Managerid = sdt.gxTv_SdtTrn_Manager_Managerid ;
         gxTv_SdtTrn_Manager_Organisationid = sdt.gxTv_SdtTrn_Manager_Organisationid ;
         gxTv_SdtTrn_Manager_Managergivenname = sdt.gxTv_SdtTrn_Manager_Managergivenname ;
         gxTv_SdtTrn_Manager_Managerlastname = sdt.gxTv_SdtTrn_Manager_Managerlastname ;
         gxTv_SdtTrn_Manager_Managerinitials = sdt.gxTv_SdtTrn_Manager_Managerinitials ;
         gxTv_SdtTrn_Manager_Manageremail = sdt.gxTv_SdtTrn_Manager_Manageremail ;
         gxTv_SdtTrn_Manager_Managerphone = sdt.gxTv_SdtTrn_Manager_Managerphone ;
         gxTv_SdtTrn_Manager_Managergender = sdt.gxTv_SdtTrn_Manager_Managergender ;
         gxTv_SdtTrn_Manager_Managergamguid = sdt.gxTv_SdtTrn_Manager_Managergamguid ;
         gxTv_SdtTrn_Manager_Mode = sdt.gxTv_SdtTrn_Manager_Mode ;
         gxTv_SdtTrn_Manager_Initialized = sdt.gxTv_SdtTrn_Manager_Initialized ;
         gxTv_SdtTrn_Manager_Managerid_Z = sdt.gxTv_SdtTrn_Manager_Managerid_Z ;
         gxTv_SdtTrn_Manager_Organisationid_Z = sdt.gxTv_SdtTrn_Manager_Organisationid_Z ;
         gxTv_SdtTrn_Manager_Managergivenname_Z = sdt.gxTv_SdtTrn_Manager_Managergivenname_Z ;
         gxTv_SdtTrn_Manager_Managerlastname_Z = sdt.gxTv_SdtTrn_Manager_Managerlastname_Z ;
         gxTv_SdtTrn_Manager_Managerinitials_Z = sdt.gxTv_SdtTrn_Manager_Managerinitials_Z ;
         gxTv_SdtTrn_Manager_Manageremail_Z = sdt.gxTv_SdtTrn_Manager_Manageremail_Z ;
         gxTv_SdtTrn_Manager_Managerphone_Z = sdt.gxTv_SdtTrn_Manager_Managerphone_Z ;
         gxTv_SdtTrn_Manager_Managergender_Z = sdt.gxTv_SdtTrn_Manager_Managergender_Z ;
         gxTv_SdtTrn_Manager_Managergamguid_Z = sdt.gxTv_SdtTrn_Manager_Managergamguid_Z ;
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
         AddObjectProperty("ManagerId", gxTv_SdtTrn_Manager_Managerid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Manager_Organisationid, false, includeNonInitialized);
         AddObjectProperty("ManagerGivenName", gxTv_SdtTrn_Manager_Managergivenname, false, includeNonInitialized);
         AddObjectProperty("ManagerLastName", gxTv_SdtTrn_Manager_Managerlastname, false, includeNonInitialized);
         AddObjectProperty("ManagerInitials", gxTv_SdtTrn_Manager_Managerinitials, false, includeNonInitialized);
         AddObjectProperty("ManagerEmail", gxTv_SdtTrn_Manager_Manageremail, false, includeNonInitialized);
         AddObjectProperty("ManagerPhone", gxTv_SdtTrn_Manager_Managerphone, false, includeNonInitialized);
         AddObjectProperty("ManagerGender", gxTv_SdtTrn_Manager_Managergender, false, includeNonInitialized);
         AddObjectProperty("ManagerGAMGUID", gxTv_SdtTrn_Manager_Managergamguid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Manager_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Manager_Initialized, false, includeNonInitialized);
            AddObjectProperty("ManagerId_Z", gxTv_SdtTrn_Manager_Managerid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Manager_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("ManagerGivenName_Z", gxTv_SdtTrn_Manager_Managergivenname_Z, false, includeNonInitialized);
            AddObjectProperty("ManagerLastName_Z", gxTv_SdtTrn_Manager_Managerlastname_Z, false, includeNonInitialized);
            AddObjectProperty("ManagerInitials_Z", gxTv_SdtTrn_Manager_Managerinitials_Z, false, includeNonInitialized);
            AddObjectProperty("ManagerEmail_Z", gxTv_SdtTrn_Manager_Manageremail_Z, false, includeNonInitialized);
            AddObjectProperty("ManagerPhone_Z", gxTv_SdtTrn_Manager_Managerphone_Z, false, includeNonInitialized);
            AddObjectProperty("ManagerGender_Z", gxTv_SdtTrn_Manager_Managergender_Z, false, includeNonInitialized);
            AddObjectProperty("ManagerGAMGUID_Z", gxTv_SdtTrn_Manager_Managergamguid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Manager sdt )
      {
         if ( sdt.IsDirty("ManagerId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerid = sdt.gxTv_SdtTrn_Manager_Managerid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Organisationid = sdt.gxTv_SdtTrn_Manager_Organisationid ;
         }
         if ( sdt.IsDirty("ManagerGivenName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managergivenname = sdt.gxTv_SdtTrn_Manager_Managergivenname ;
         }
         if ( sdt.IsDirty("ManagerLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerlastname = sdt.gxTv_SdtTrn_Manager_Managerlastname ;
         }
         if ( sdt.IsDirty("ManagerInitials") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerinitials = sdt.gxTv_SdtTrn_Manager_Managerinitials ;
         }
         if ( sdt.IsDirty("ManagerEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Manageremail = sdt.gxTv_SdtTrn_Manager_Manageremail ;
         }
         if ( sdt.IsDirty("ManagerPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerphone = sdt.gxTv_SdtTrn_Manager_Managerphone ;
         }
         if ( sdt.IsDirty("ManagerGender") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managergender = sdt.gxTv_SdtTrn_Manager_Managergender ;
         }
         if ( sdt.IsDirty("ManagerGAMGUID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managergamguid = sdt.gxTv_SdtTrn_Manager_Managergamguid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ManagerId" )]
      [  XmlElement( ElementName = "ManagerId"   )]
      public Guid gxTpr_Managerid
      {
         get {
            return gxTv_SdtTrn_Manager_Managerid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Manager_Managerid != value )
            {
               gxTv_SdtTrn_Manager_Mode = "INS";
               this.gxTv_SdtTrn_Manager_Managerid_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managergivenname_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managerlastname_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managerinitials_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Manageremail_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managerphone_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managergender_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managergamguid_Z_SetNull( );
            }
            gxTv_SdtTrn_Manager_Managerid = value;
            SetDirty("Managerid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Manager_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Manager_Organisationid != value )
            {
               gxTv_SdtTrn_Manager_Mode = "INS";
               this.gxTv_SdtTrn_Manager_Managerid_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managergivenname_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managerlastname_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managerinitials_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Manageremail_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managerphone_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managergender_Z_SetNull( );
               this.gxTv_SdtTrn_Manager_Managergamguid_Z_SetNull( );
            }
            gxTv_SdtTrn_Manager_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "ManagerGivenName" )]
      [  XmlElement( ElementName = "ManagerGivenName"   )]
      public string gxTpr_Managergivenname
      {
         get {
            return gxTv_SdtTrn_Manager_Managergivenname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managergivenname = value;
            SetDirty("Managergivenname");
         }

      }

      [  SoapElement( ElementName = "ManagerLastName" )]
      [  XmlElement( ElementName = "ManagerLastName"   )]
      public string gxTpr_Managerlastname
      {
         get {
            return gxTv_SdtTrn_Manager_Managerlastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerlastname = value;
            SetDirty("Managerlastname");
         }

      }

      [  SoapElement( ElementName = "ManagerInitials" )]
      [  XmlElement( ElementName = "ManagerInitials"   )]
      public string gxTpr_Managerinitials
      {
         get {
            return gxTv_SdtTrn_Manager_Managerinitials ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerinitials = value;
            SetDirty("Managerinitials");
         }

      }

      [  SoapElement( ElementName = "ManagerEmail" )]
      [  XmlElement( ElementName = "ManagerEmail"   )]
      public string gxTpr_Manageremail
      {
         get {
            return gxTv_SdtTrn_Manager_Manageremail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Manageremail = value;
            SetDirty("Manageremail");
         }

      }

      [  SoapElement( ElementName = "ManagerPhone" )]
      [  XmlElement( ElementName = "ManagerPhone"   )]
      public string gxTpr_Managerphone
      {
         get {
            return gxTv_SdtTrn_Manager_Managerphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerphone = value;
            SetDirty("Managerphone");
         }

      }

      [  SoapElement( ElementName = "ManagerGender" )]
      [  XmlElement( ElementName = "ManagerGender"   )]
      public string gxTpr_Managergender
      {
         get {
            return gxTv_SdtTrn_Manager_Managergender ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managergender = value;
            SetDirty("Managergender");
         }

      }

      [  SoapElement( ElementName = "ManagerGAMGUID" )]
      [  XmlElement( ElementName = "ManagerGAMGUID"   )]
      public string gxTpr_Managergamguid
      {
         get {
            return gxTv_SdtTrn_Manager_Managergamguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managergamguid = value;
            SetDirty("Managergamguid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Manager_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Manager_Mode_SetNull( )
      {
         gxTv_SdtTrn_Manager_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Manager_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Manager_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Manager_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ManagerId_Z" )]
      [  XmlElement( ElementName = "ManagerId_Z"   )]
      public Guid gxTpr_Managerid_Z
      {
         get {
            return gxTv_SdtTrn_Manager_Managerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerid_Z = value;
            SetDirty("Managerid_Z");
         }

      }

      public void gxTv_SdtTrn_Manager_Managerid_Z_SetNull( )
      {
         gxTv_SdtTrn_Manager_Managerid_Z = Guid.Empty;
         SetDirty("Managerid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Managerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Manager_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Manager_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Manager_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ManagerGivenName_Z" )]
      [  XmlElement( ElementName = "ManagerGivenName_Z"   )]
      public string gxTpr_Managergivenname_Z
      {
         get {
            return gxTv_SdtTrn_Manager_Managergivenname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managergivenname_Z = value;
            SetDirty("Managergivenname_Z");
         }

      }

      public void gxTv_SdtTrn_Manager_Managergivenname_Z_SetNull( )
      {
         gxTv_SdtTrn_Manager_Managergivenname_Z = "";
         SetDirty("Managergivenname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Managergivenname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ManagerLastName_Z" )]
      [  XmlElement( ElementName = "ManagerLastName_Z"   )]
      public string gxTpr_Managerlastname_Z
      {
         get {
            return gxTv_SdtTrn_Manager_Managerlastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerlastname_Z = value;
            SetDirty("Managerlastname_Z");
         }

      }

      public void gxTv_SdtTrn_Manager_Managerlastname_Z_SetNull( )
      {
         gxTv_SdtTrn_Manager_Managerlastname_Z = "";
         SetDirty("Managerlastname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Managerlastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ManagerInitials_Z" )]
      [  XmlElement( ElementName = "ManagerInitials_Z"   )]
      public string gxTpr_Managerinitials_Z
      {
         get {
            return gxTv_SdtTrn_Manager_Managerinitials_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerinitials_Z = value;
            SetDirty("Managerinitials_Z");
         }

      }

      public void gxTv_SdtTrn_Manager_Managerinitials_Z_SetNull( )
      {
         gxTv_SdtTrn_Manager_Managerinitials_Z = "";
         SetDirty("Managerinitials_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Managerinitials_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ManagerEmail_Z" )]
      [  XmlElement( ElementName = "ManagerEmail_Z"   )]
      public string gxTpr_Manageremail_Z
      {
         get {
            return gxTv_SdtTrn_Manager_Manageremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Manageremail_Z = value;
            SetDirty("Manageremail_Z");
         }

      }

      public void gxTv_SdtTrn_Manager_Manageremail_Z_SetNull( )
      {
         gxTv_SdtTrn_Manager_Manageremail_Z = "";
         SetDirty("Manageremail_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Manageremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ManagerPhone_Z" )]
      [  XmlElement( ElementName = "ManagerPhone_Z"   )]
      public string gxTpr_Managerphone_Z
      {
         get {
            return gxTv_SdtTrn_Manager_Managerphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managerphone_Z = value;
            SetDirty("Managerphone_Z");
         }

      }

      public void gxTv_SdtTrn_Manager_Managerphone_Z_SetNull( )
      {
         gxTv_SdtTrn_Manager_Managerphone_Z = "";
         SetDirty("Managerphone_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Managerphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ManagerGender_Z" )]
      [  XmlElement( ElementName = "ManagerGender_Z"   )]
      public string gxTpr_Managergender_Z
      {
         get {
            return gxTv_SdtTrn_Manager_Managergender_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managergender_Z = value;
            SetDirty("Managergender_Z");
         }

      }

      public void gxTv_SdtTrn_Manager_Managergender_Z_SetNull( )
      {
         gxTv_SdtTrn_Manager_Managergender_Z = "";
         SetDirty("Managergender_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Managergender_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ManagerGAMGUID_Z" )]
      [  XmlElement( ElementName = "ManagerGAMGUID_Z"   )]
      public string gxTpr_Managergamguid_Z
      {
         get {
            return gxTv_SdtTrn_Manager_Managergamguid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Manager_Managergamguid_Z = value;
            SetDirty("Managergamguid_Z");
         }

      }

      public void gxTv_SdtTrn_Manager_Managergamguid_Z_SetNull( )
      {
         gxTv_SdtTrn_Manager_Managergamguid_Z = "";
         SetDirty("Managergamguid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Manager_Managergamguid_Z_IsNull( )
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
         gxTv_SdtTrn_Manager_Managerid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Manager_Organisationid = Guid.Empty;
         gxTv_SdtTrn_Manager_Managergivenname = "";
         gxTv_SdtTrn_Manager_Managerlastname = "";
         gxTv_SdtTrn_Manager_Managerinitials = "";
         gxTv_SdtTrn_Manager_Manageremail = "";
         gxTv_SdtTrn_Manager_Managerphone = "";
         gxTv_SdtTrn_Manager_Managergender = "";
         gxTv_SdtTrn_Manager_Managergamguid = "";
         gxTv_SdtTrn_Manager_Mode = "";
         gxTv_SdtTrn_Manager_Managerid_Z = Guid.Empty;
         gxTv_SdtTrn_Manager_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Manager_Managergivenname_Z = "";
         gxTv_SdtTrn_Manager_Managerlastname_Z = "";
         gxTv_SdtTrn_Manager_Managerinitials_Z = "";
         gxTv_SdtTrn_Manager_Manageremail_Z = "";
         gxTv_SdtTrn_Manager_Managerphone_Z = "";
         gxTv_SdtTrn_Manager_Managergender_Z = "";
         gxTv_SdtTrn_Manager_Managergamguid_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_manager", "GeneXus.Programs.trn_manager_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Manager_Initialized ;
      private string gxTv_SdtTrn_Manager_Managerinitials ;
      private string gxTv_SdtTrn_Manager_Managerphone ;
      private string gxTv_SdtTrn_Manager_Mode ;
      private string gxTv_SdtTrn_Manager_Managerinitials_Z ;
      private string gxTv_SdtTrn_Manager_Managerphone_Z ;
      private string gxTv_SdtTrn_Manager_Managergivenname ;
      private string gxTv_SdtTrn_Manager_Managerlastname ;
      private string gxTv_SdtTrn_Manager_Manageremail ;
      private string gxTv_SdtTrn_Manager_Managergender ;
      private string gxTv_SdtTrn_Manager_Managergamguid ;
      private string gxTv_SdtTrn_Manager_Managergivenname_Z ;
      private string gxTv_SdtTrn_Manager_Managerlastname_Z ;
      private string gxTv_SdtTrn_Manager_Manageremail_Z ;
      private string gxTv_SdtTrn_Manager_Managergender_Z ;
      private string gxTv_SdtTrn_Manager_Managergamguid_Z ;
      private Guid gxTv_SdtTrn_Manager_Managerid ;
      private Guid gxTv_SdtTrn_Manager_Organisationid ;
      private Guid gxTv_SdtTrn_Manager_Managerid_Z ;
      private Guid gxTv_SdtTrn_Manager_Organisationid_Z ;
   }

   [DataContract(Name = @"Trn_Manager", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Manager_RESTInterface : GxGenericCollectionItem<SdtTrn_Manager>
   {
      public SdtTrn_Manager_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Manager_RESTInterface( SdtTrn_Manager psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ManagerId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Managerid
      {
         get {
            return sdt.gxTpr_Managerid ;
         }

         set {
            sdt.gxTpr_Managerid = value;
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

      [DataMember( Name = "ManagerGivenName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Managergivenname
      {
         get {
            return sdt.gxTpr_Managergivenname ;
         }

         set {
            sdt.gxTpr_Managergivenname = value;
         }

      }

      [DataMember( Name = "ManagerLastName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Managerlastname
      {
         get {
            return sdt.gxTpr_Managerlastname ;
         }

         set {
            sdt.gxTpr_Managerlastname = value;
         }

      }

      [DataMember( Name = "ManagerInitials" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Managerinitials
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Managerinitials) ;
         }

         set {
            sdt.gxTpr_Managerinitials = value;
         }

      }

      [DataMember( Name = "ManagerEmail" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Manageremail
      {
         get {
            return sdt.gxTpr_Manageremail ;
         }

         set {
            sdt.gxTpr_Manageremail = value;
         }

      }

      [DataMember( Name = "ManagerPhone" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Managerphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Managerphone) ;
         }

         set {
            sdt.gxTpr_Managerphone = value;
         }

      }

      [DataMember( Name = "ManagerGender" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Managergender
      {
         get {
            return sdt.gxTpr_Managergender ;
         }

         set {
            sdt.gxTpr_Managergender = value;
         }

      }

      [DataMember( Name = "ManagerGAMGUID" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Managergamguid
      {
         get {
            return sdt.gxTpr_Managergamguid ;
         }

         set {
            sdt.gxTpr_Managergamguid = value;
         }

      }

      public SdtTrn_Manager sdt
      {
         get {
            return (SdtTrn_Manager)Sdt ;
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
            sdt = new SdtTrn_Manager() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 9 )]
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

   [DataContract(Name = @"Trn_Manager", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Manager_RESTLInterface : GxGenericCollectionItem<SdtTrn_Manager>
   {
      public SdtTrn_Manager_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Manager_RESTLInterface( SdtTrn_Manager psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ManagerGivenName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Managergivenname
      {
         get {
            return sdt.gxTpr_Managergivenname ;
         }

         set {
            sdt.gxTpr_Managergivenname = value;
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

      public SdtTrn_Manager sdt
      {
         get {
            return (SdtTrn_Manager)Sdt ;
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
            sdt = new SdtTrn_Manager() ;
         }
      }

   }

}
