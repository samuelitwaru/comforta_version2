/*
				   File: type_SdtSDT_Receptionist
			Description: SDT_Receptionist
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDT_Receptionist")]
	[XmlType(TypeName="SDT_Receptionist" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Receptionist : GxUserType
	{
		public SdtSDT_Receptionist( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Receptionist_Receptionistgivenname = "";

			gxTv_SdtSDT_Receptionist_Receptionistlastname = "";

			gxTv_SdtSDT_Receptionist_Receptionistemail = "";

			gxTv_SdtSDT_Receptionist_Receptionistphone = "";

			gxTv_SdtSDT_Receptionist_Receptionistphonecode = "";

			gxTv_SdtSDT_Receptionist_Receptionistphonenumber = "";

			gxTv_SdtSDT_Receptionist_Receptioniststatus = "";

			gxTv_SdtSDT_Receptionist_Receptionistgamguid = "";

		}

		public SdtSDT_Receptionist(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("ReceptionistId", gxTpr_Receptionistid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("ReceptionistGivenName", gxTpr_Receptionistgivenname, false);


			AddObjectProperty("ReceptionistLastName", gxTpr_Receptionistlastname, false);


			AddObjectProperty("ReceptionistEmail", gxTpr_Receptionistemail, false);


			AddObjectProperty("ReceptionistPhone", gxTpr_Receptionistphone, false);


			AddObjectProperty("ReceptionistPhoneCode", gxTpr_Receptionistphonecode, false);


			AddObjectProperty("ReceptionistPhoneNumber", gxTpr_Receptionistphonenumber, false);


			AddObjectProperty("ReceptionistStatus", gxTpr_Receptioniststatus, false);


			AddObjectProperty("ReceptionistIsActive", gxTpr_Receptionistisactive, false);


			AddObjectProperty("ReceptionistGAMGUID", gxTpr_Receptionistgamguid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ReceptionistId")]
		[XmlElement(ElementName="ReceptionistId")]
		public Guid gxTpr_Receptionistid
		{
			get {
				return gxTv_SdtSDT_Receptionist_Receptionistid; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Receptionistid = value;
				SetDirty("Receptionistid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_Receptionist_Organisationid; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_Receptionist_Locationid; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="ReceptionistGivenName")]
		[XmlElement(ElementName="ReceptionistGivenName")]
		public string gxTpr_Receptionistgivenname
		{
			get {
				return gxTv_SdtSDT_Receptionist_Receptionistgivenname; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Receptionistgivenname = value;
				SetDirty("Receptionistgivenname");
			}
		}




		[SoapElement(ElementName="ReceptionistLastName")]
		[XmlElement(ElementName="ReceptionistLastName")]
		public string gxTpr_Receptionistlastname
		{
			get {
				return gxTv_SdtSDT_Receptionist_Receptionistlastname; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Receptionistlastname = value;
				SetDirty("Receptionistlastname");
			}
		}




		[SoapElement(ElementName="ReceptionistEmail")]
		[XmlElement(ElementName="ReceptionistEmail")]
		public string gxTpr_Receptionistemail
		{
			get {
				return gxTv_SdtSDT_Receptionist_Receptionistemail; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Receptionistemail = value;
				SetDirty("Receptionistemail");
			}
		}




		[SoapElement(ElementName="ReceptionistPhone")]
		[XmlElement(ElementName="ReceptionistPhone")]
		public string gxTpr_Receptionistphone
		{
			get {
				return gxTv_SdtSDT_Receptionist_Receptionistphone; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Receptionistphone = value;
				SetDirty("Receptionistphone");
			}
		}




		[SoapElement(ElementName="ReceptionistPhoneCode")]
		[XmlElement(ElementName="ReceptionistPhoneCode")]
		public string gxTpr_Receptionistphonecode
		{
			get {
				return gxTv_SdtSDT_Receptionist_Receptionistphonecode; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Receptionistphonecode = value;
				SetDirty("Receptionistphonecode");
			}
		}




		[SoapElement(ElementName="ReceptionistPhoneNumber")]
		[XmlElement(ElementName="ReceptionistPhoneNumber")]
		public string gxTpr_Receptionistphonenumber
		{
			get {
				return gxTv_SdtSDT_Receptionist_Receptionistphonenumber; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Receptionistphonenumber = value;
				SetDirty("Receptionistphonenumber");
			}
		}




		[SoapElement(ElementName="ReceptionistStatus")]
		[XmlElement(ElementName="ReceptionistStatus")]
		public string gxTpr_Receptioniststatus
		{
			get {
				return gxTv_SdtSDT_Receptionist_Receptioniststatus; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Receptioniststatus = value;
				SetDirty("Receptioniststatus");
			}
		}




		[SoapElement(ElementName="ReceptionistIsActive")]
		[XmlElement(ElementName="ReceptionistIsActive")]
		public bool gxTpr_Receptionistisactive
		{
			get {
				return gxTv_SdtSDT_Receptionist_Receptionistisactive; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Receptionistisactive = value;
				SetDirty("Receptionistisactive");
			}
		}




		[SoapElement(ElementName="ReceptionistGAMGUID")]
		[XmlElement(ElementName="ReceptionistGAMGUID")]
		public string gxTpr_Receptionistgamguid
		{
			get {
				return gxTv_SdtSDT_Receptionist_Receptionistgamguid; 
			}
			set {
				gxTv_SdtSDT_Receptionist_Receptionistgamguid = value;
				SetDirty("Receptionistgamguid");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDT_Receptionist_Receptionistgivenname = "";
			gxTv_SdtSDT_Receptionist_Receptionistlastname = "";
			gxTv_SdtSDT_Receptionist_Receptionistemail = "";
			gxTv_SdtSDT_Receptionist_Receptionistphone = "";
			gxTv_SdtSDT_Receptionist_Receptionistphonecode = "";
			gxTv_SdtSDT_Receptionist_Receptionistphonenumber = "";
			gxTv_SdtSDT_Receptionist_Receptioniststatus = "";

			gxTv_SdtSDT_Receptionist_Receptionistgamguid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Receptionist_Receptionistid;
		 

		protected Guid gxTv_SdtSDT_Receptionist_Organisationid;
		 

		protected Guid gxTv_SdtSDT_Receptionist_Locationid;
		 

		protected string gxTv_SdtSDT_Receptionist_Receptionistgivenname;
		 

		protected string gxTv_SdtSDT_Receptionist_Receptionistlastname;
		 

		protected string gxTv_SdtSDT_Receptionist_Receptionistemail;
		 

		protected string gxTv_SdtSDT_Receptionist_Receptionistphone;
		 

		protected string gxTv_SdtSDT_Receptionist_Receptionistphonecode;
		 

		protected string gxTv_SdtSDT_Receptionist_Receptionistphonenumber;
		 

		protected string gxTv_SdtSDT_Receptionist_Receptioniststatus;
		 

		protected bool gxTv_SdtSDT_Receptionist_Receptionistisactive;
		 

		protected string gxTv_SdtSDT_Receptionist_Receptionistgamguid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Receptionist", Namespace="Comforta_version2")]
	public class SdtSDT_Receptionist_RESTInterface : GxGenericCollectionItem<SdtSDT_Receptionist>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Receptionist_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Receptionist_RESTInterface( SdtSDT_Receptionist psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ReceptionistId", Order=0)]
		public Guid gxTpr_Receptionistid
		{
			get { 
				return sdt.gxTpr_Receptionistid;

			}
			set { 
				sdt.gxTpr_Receptionistid = value;
			}
		}

		[DataMember(Name="OrganisationId", Order=1)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="LocationId", Order=2)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="ReceptionistGivenName", Order=3)]
		public  string gxTpr_Receptionistgivenname
		{
			get { 
				return sdt.gxTpr_Receptionistgivenname;

			}
			set { 
				 sdt.gxTpr_Receptionistgivenname = value;
			}
		}

		[DataMember(Name="ReceptionistLastName", Order=4)]
		public  string gxTpr_Receptionistlastname
		{
			get { 
				return sdt.gxTpr_Receptionistlastname;

			}
			set { 
				 sdt.gxTpr_Receptionistlastname = value;
			}
		}

		[DataMember(Name="ReceptionistEmail", Order=5)]
		public  string gxTpr_Receptionistemail
		{
			get { 
				return sdt.gxTpr_Receptionistemail;

			}
			set { 
				 sdt.gxTpr_Receptionistemail = value;
			}
		}

		[DataMember(Name="ReceptionistPhone", Order=6)]
		public  string gxTpr_Receptionistphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Receptionistphone);

			}
			set { 
				 sdt.gxTpr_Receptionistphone = value;
			}
		}

		[DataMember(Name="ReceptionistPhoneCode", Order=7)]
		public  string gxTpr_Receptionistphonecode
		{
			get { 
				return sdt.gxTpr_Receptionistphonecode;

			}
			set { 
				 sdt.gxTpr_Receptionistphonecode = value;
			}
		}

		[DataMember(Name="ReceptionistPhoneNumber", Order=8)]
		public  string gxTpr_Receptionistphonenumber
		{
			get { 
				return sdt.gxTpr_Receptionistphonenumber;

			}
			set { 
				 sdt.gxTpr_Receptionistphonenumber = value;
			}
		}

		[DataMember(Name="ReceptionistStatus", Order=9)]
		public  string gxTpr_Receptioniststatus
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Receptioniststatus);

			}
			set { 
				 sdt.gxTpr_Receptioniststatus = value;
			}
		}

		[DataMember(Name="ReceptionistIsActive", Order=10)]
		public bool gxTpr_Receptionistisactive
		{
			get { 
				return sdt.gxTpr_Receptionistisactive;

			}
			set { 
				sdt.gxTpr_Receptionistisactive = value;
			}
		}

		[DataMember(Name="ReceptionistGAMGUID", Order=11)]
		public  string gxTpr_Receptionistgamguid
		{
			get { 
				return sdt.gxTpr_Receptionistgamguid;

			}
			set { 
				 sdt.gxTpr_Receptionistgamguid = value;
			}
		}


		#endregion

		public SdtSDT_Receptionist sdt
		{
			get { 
				return (SdtSDT_Receptionist)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDT_Receptionist() ;
			}
		}
	}
	#endregion
}