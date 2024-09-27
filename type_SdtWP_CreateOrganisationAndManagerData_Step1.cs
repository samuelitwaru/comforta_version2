/*
				   File: type_SdtWP_CreateOrganisationAndManagerData_Step1
			Description: Step1
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
	[XmlRoot(ElementName="WP_CreateOrganisationAndManagerData.Step1")]
	[XmlType(TypeName="WP_CreateOrganisationAndManagerData.Step1" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWP_CreateOrganisationAndManagerData_Step1 : GxUserType
	{
		public SdtWP_CreateOrganisationAndManagerData_Step1( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationname = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationkvknumber = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationemail = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationphone = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresscountry = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresscity = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresszipcode = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddressline1 = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddressline2 = "";

		}

		public SdtWP_CreateOrganisationAndManagerData_Step1(IGxContext context)
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
			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("OrganisationName", gxTpr_Organisationname, false);


			AddObjectProperty("OrganisationTypeId", gxTpr_Organisationtypeid, false);


			AddObjectProperty("OrganisationKvkNumber", gxTpr_Organisationkvknumber, false);


			AddObjectProperty("OrganisationEmail", gxTpr_Organisationemail, false);


			AddObjectProperty("OrganisationPhone", gxTpr_Organisationphone, false);


			AddObjectProperty("OrganisationVATNumber", gxTpr_Organisationvatnumber, false);


			AddObjectProperty("OrganisationAddressCountry", gxTpr_Organisationaddresscountry, false);


			AddObjectProperty("OrganisationAddressCity", gxTpr_Organisationaddresscity, false);


			AddObjectProperty("OrganisationAddressZipCode", gxTpr_Organisationaddresszipcode, false);


			AddObjectProperty("OrganisationAddressLine1", gxTpr_Organisationaddressline1, false);


			AddObjectProperty("OrganisationAddressLine2", gxTpr_Organisationaddressline2, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationid; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="OrganisationName")]
		[XmlElement(ElementName="OrganisationName")]
		public string gxTpr_Organisationname
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationname; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationname = value;
				SetDirty("Organisationname");
			}
		}




		[SoapElement(ElementName="OrganisationTypeId")]
		[XmlElement(ElementName="OrganisationTypeId")]
		public Guid gxTpr_Organisationtypeid
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationtypeid; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationtypeid = value;
				SetDirty("Organisationtypeid");
			}
		}




		[SoapElement(ElementName="OrganisationKvkNumber")]
		[XmlElement(ElementName="OrganisationKvkNumber")]
		public string gxTpr_Organisationkvknumber
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationkvknumber; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationkvknumber = value;
				SetDirty("Organisationkvknumber");
			}
		}




		[SoapElement(ElementName="OrganisationEmail")]
		[XmlElement(ElementName="OrganisationEmail")]
		public string gxTpr_Organisationemail
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationemail; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationemail = value;
				SetDirty("Organisationemail");
			}
		}




		[SoapElement(ElementName="OrganisationPhone")]
		[XmlElement(ElementName="OrganisationPhone")]
		public string gxTpr_Organisationphone
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationphone; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationphone = value;
				SetDirty("Organisationphone");
			}
		}




		[SoapElement(ElementName="OrganisationVATNumber")]
		[XmlElement(ElementName="OrganisationVATNumber")]
		public int gxTpr_Organisationvatnumber
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationvatnumber; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationvatnumber = value;
				SetDirty("Organisationvatnumber");
			}
		}




		[SoapElement(ElementName="OrganisationAddressCountry")]
		[XmlElement(ElementName="OrganisationAddressCountry")]
		public string gxTpr_Organisationaddresscountry
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresscountry; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresscountry = value;
				SetDirty("Organisationaddresscountry");
			}
		}




		[SoapElement(ElementName="OrganisationAddressCity")]
		[XmlElement(ElementName="OrganisationAddressCity")]
		public string gxTpr_Organisationaddresscity
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresscity; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresscity = value;
				SetDirty("Organisationaddresscity");
			}
		}




		[SoapElement(ElementName="OrganisationAddressZipCode")]
		[XmlElement(ElementName="OrganisationAddressZipCode")]
		public string gxTpr_Organisationaddresszipcode
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresszipcode; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresszipcode = value;
				SetDirty("Organisationaddresszipcode");
			}
		}




		[SoapElement(ElementName="OrganisationAddressLine1")]
		[XmlElement(ElementName="OrganisationAddressLine1")]
		public string gxTpr_Organisationaddressline1
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddressline1; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddressline1 = value;
				SetDirty("Organisationaddressline1");
			}
		}




		[SoapElement(ElementName="OrganisationAddressLine2")]
		[XmlElement(ElementName="OrganisationAddressLine2")]
		public string gxTpr_Organisationaddressline2
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddressline2; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddressline2 = value;
				SetDirty("Organisationaddressline2");
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
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationname = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationkvknumber = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationemail = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationphone = "";

			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresscountry = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresscity = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresszipcode = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddressline1 = "";
			gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddressline2 = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationid;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationname;
		 

		protected Guid gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationtypeid;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationkvknumber;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationemail;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationphone;
		 

		protected int gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationvatnumber;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresscountry;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresscity;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddresszipcode;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddressline1;
		 

		protected string gxTv_SdtWP_CreateOrganisationAndManagerData_Step1_Organisationaddressline2;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateOrganisationAndManagerData.Step1", Namespace="Comforta_version2")]
	public class SdtWP_CreateOrganisationAndManagerData_Step1_RESTInterface : GxGenericCollectionItem<SdtWP_CreateOrganisationAndManagerData_Step1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateOrganisationAndManagerData_Step1_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateOrganisationAndManagerData_Step1_RESTInterface( SdtWP_CreateOrganisationAndManagerData_Step1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="OrganisationId", Order=0)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="OrganisationName", Order=1)]
		public  string gxTpr_Organisationname
		{
			get { 
				return sdt.gxTpr_Organisationname;

			}
			set { 
				 sdt.gxTpr_Organisationname = value;
			}
		}

		[DataMember(Name="OrganisationTypeId", Order=2)]
		public Guid gxTpr_Organisationtypeid
		{
			get { 
				return sdt.gxTpr_Organisationtypeid;

			}
			set { 
				sdt.gxTpr_Organisationtypeid = value;
			}
		}

		[DataMember(Name="OrganisationKvkNumber", Order=3)]
		public  string gxTpr_Organisationkvknumber
		{
			get { 
				return sdt.gxTpr_Organisationkvknumber;

			}
			set { 
				 sdt.gxTpr_Organisationkvknumber = value;
			}
		}

		[DataMember(Name="OrganisationEmail", Order=4)]
		public  string gxTpr_Organisationemail
		{
			get { 
				return sdt.gxTpr_Organisationemail;

			}
			set { 
				 sdt.gxTpr_Organisationemail = value;
			}
		}

		[DataMember(Name="OrganisationPhone", Order=5)]
		public  string gxTpr_Organisationphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Organisationphone);

			}
			set { 
				 sdt.gxTpr_Organisationphone = value;
			}
		}

		[DataMember(Name="OrganisationVATNumber", Order=6)]
		public  string gxTpr_Organisationvatnumber
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Organisationvatnumber, 8, 0));

			}
			set { 
				sdt.gxTpr_Organisationvatnumber = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="OrganisationAddressCountry", Order=7)]
		public  string gxTpr_Organisationaddresscountry
		{
			get { 
				return sdt.gxTpr_Organisationaddresscountry;

			}
			set { 
				 sdt.gxTpr_Organisationaddresscountry = value;
			}
		}

		[DataMember(Name="OrganisationAddressCity", Order=8)]
		public  string gxTpr_Organisationaddresscity
		{
			get { 
				return sdt.gxTpr_Organisationaddresscity;

			}
			set { 
				 sdt.gxTpr_Organisationaddresscity = value;
			}
		}

		[DataMember(Name="OrganisationAddressZipCode", Order=9)]
		public  string gxTpr_Organisationaddresszipcode
		{
			get { 
				return sdt.gxTpr_Organisationaddresszipcode;

			}
			set { 
				 sdt.gxTpr_Organisationaddresszipcode = value;
			}
		}

		[DataMember(Name="OrganisationAddressLine1", Order=10)]
		public  string gxTpr_Organisationaddressline1
		{
			get { 
				return sdt.gxTpr_Organisationaddressline1;

			}
			set { 
				 sdt.gxTpr_Organisationaddressline1 = value;
			}
		}

		[DataMember(Name="OrganisationAddressLine2", Order=11)]
		public  string gxTpr_Organisationaddressline2
		{
			get { 
				return sdt.gxTpr_Organisationaddressline2;

			}
			set { 
				 sdt.gxTpr_Organisationaddressline2 = value;
			}
		}


		#endregion

		public SdtWP_CreateOrganisationAndManagerData_Step1 sdt
		{
			get { 
				return (SdtWP_CreateOrganisationAndManagerData_Step1)Sdt;
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
				sdt = new SdtWP_CreateOrganisationAndManagerData_Step1() ;
			}
		}
	}
	#endregion
}