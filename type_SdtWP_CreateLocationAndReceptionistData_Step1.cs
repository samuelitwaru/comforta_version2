/*
				   File: type_SdtWP_CreateLocationAndReceptionistData_Step1
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
	[XmlRoot(ElementName="WP_CreateLocationAndReceptionistData.Step1")]
	[XmlType(TypeName="WP_CreateLocationAndReceptionistData.Step1" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWP_CreateLocationAndReceptionistData_Step1 : GxUserType
	{
		public SdtWP_CreateLocationAndReceptionistData_Step1( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationname = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationemail = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphone = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcountry = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcity = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationzipcode = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline1 = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline2 = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationdescription = "";

		}

		public SdtWP_CreateLocationAndReceptionistData_Step1(IGxContext context)
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
			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("LocationName", gxTpr_Locationname, false);


			AddObjectProperty("LocationEmail", gxTpr_Locationemail, false);


			AddObjectProperty("LocationPhone", gxTpr_Locationphone, false);


			AddObjectProperty("LocationCountry", gxTpr_Locationcountry, false);


			AddObjectProperty("LocationCity", gxTpr_Locationcity, false);


			AddObjectProperty("LocationZipCode", gxTpr_Locationzipcode, false);


			AddObjectProperty("LocationAddressLine1", gxTpr_Locationaddressline1, false);


			AddObjectProperty("LocationAddressLine2", gxTpr_Locationaddressline2, false);


			AddObjectProperty("LocationDescription", gxTpr_Locationdescription, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationid; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="LocationName")]
		[XmlElement(ElementName="LocationName")]
		public string gxTpr_Locationname
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationname; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationname = value;
				SetDirty("Locationname");
			}
		}




		[SoapElement(ElementName="LocationEmail")]
		[XmlElement(ElementName="LocationEmail")]
		public string gxTpr_Locationemail
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationemail; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationemail = value;
				SetDirty("Locationemail");
			}
		}




		[SoapElement(ElementName="LocationPhone")]
		[XmlElement(ElementName="LocationPhone")]
		public string gxTpr_Locationphone
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphone; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphone = value;
				SetDirty("Locationphone");
			}
		}




		[SoapElement(ElementName="LocationCountry")]
		[XmlElement(ElementName="LocationCountry")]
		public string gxTpr_Locationcountry
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcountry; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcountry = value;
				SetDirty("Locationcountry");
			}
		}




		[SoapElement(ElementName="LocationCity")]
		[XmlElement(ElementName="LocationCity")]
		public string gxTpr_Locationcity
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcity; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcity = value;
				SetDirty("Locationcity");
			}
		}




		[SoapElement(ElementName="LocationZipCode")]
		[XmlElement(ElementName="LocationZipCode")]
		public string gxTpr_Locationzipcode
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationzipcode; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationzipcode = value;
				SetDirty("Locationzipcode");
			}
		}




		[SoapElement(ElementName="LocationAddressLine1")]
		[XmlElement(ElementName="LocationAddressLine1")]
		public string gxTpr_Locationaddressline1
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline1; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline1 = value;
				SetDirty("Locationaddressline1");
			}
		}




		[SoapElement(ElementName="LocationAddressLine2")]
		[XmlElement(ElementName="LocationAddressLine2")]
		public string gxTpr_Locationaddressline2
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline2; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline2 = value;
				SetDirty("Locationaddressline2");
			}
		}




		[SoapElement(ElementName="LocationDescription")]
		[XmlElement(ElementName="LocationDescription")]
		public string gxTpr_Locationdescription
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationdescription; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationdescription = value;
				SetDirty("Locationdescription");
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
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationname = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationemail = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphone = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcountry = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcity = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationzipcode = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline1 = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline2 = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationdescription = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationid;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationname;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationemail;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationphone;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcountry;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationcity;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationzipcode;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline1;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationaddressline2;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step1_Locationdescription;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateLocationAndReceptionistData.Step1", Namespace="Comforta_version2")]
	public class SdtWP_CreateLocationAndReceptionistData_Step1_RESTInterface : GxGenericCollectionItem<SdtWP_CreateLocationAndReceptionistData_Step1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateLocationAndReceptionistData_Step1_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateLocationAndReceptionistData_Step1_RESTInterface( SdtWP_CreateLocationAndReceptionistData_Step1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="LocationId", Order=0)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="LocationName", Order=1)]
		public  string gxTpr_Locationname
		{
			get { 
				return sdt.gxTpr_Locationname;

			}
			set { 
				 sdt.gxTpr_Locationname = value;
			}
		}

		[DataMember(Name="LocationEmail", Order=2)]
		public  string gxTpr_Locationemail
		{
			get { 
				return sdt.gxTpr_Locationemail;

			}
			set { 
				 sdt.gxTpr_Locationemail = value;
			}
		}

		[DataMember(Name="LocationPhone", Order=3)]
		public  string gxTpr_Locationphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Locationphone);

			}
			set { 
				 sdt.gxTpr_Locationphone = value;
			}
		}

		[DataMember(Name="LocationCountry", Order=4)]
		public  string gxTpr_Locationcountry
		{
			get { 
				return sdt.gxTpr_Locationcountry;

			}
			set { 
				 sdt.gxTpr_Locationcountry = value;
			}
		}

		[DataMember(Name="LocationCity", Order=5)]
		public  string gxTpr_Locationcity
		{
			get { 
				return sdt.gxTpr_Locationcity;

			}
			set { 
				 sdt.gxTpr_Locationcity = value;
			}
		}

		[DataMember(Name="LocationZipCode", Order=6)]
		public  string gxTpr_Locationzipcode
		{
			get { 
				return sdt.gxTpr_Locationzipcode;

			}
			set { 
				 sdt.gxTpr_Locationzipcode = value;
			}
		}

		[DataMember(Name="LocationAddressLine1", Order=7)]
		public  string gxTpr_Locationaddressline1
		{
			get { 
				return sdt.gxTpr_Locationaddressline1;

			}
			set { 
				 sdt.gxTpr_Locationaddressline1 = value;
			}
		}

		[DataMember(Name="LocationAddressLine2", Order=8)]
		public  string gxTpr_Locationaddressline2
		{
			get { 
				return sdt.gxTpr_Locationaddressline2;

			}
			set { 
				 sdt.gxTpr_Locationaddressline2 = value;
			}
		}

		[DataMember(Name="LocationDescription", Order=9)]
		public  string gxTpr_Locationdescription
		{
			get { 
				return sdt.gxTpr_Locationdescription;

			}
			set { 
				 sdt.gxTpr_Locationdescription = value;
			}
		}


		#endregion

		public SdtWP_CreateLocationAndReceptionistData_Step1 sdt
		{
			get { 
				return (SdtWP_CreateLocationAndReceptionistData_Step1)Sdt;
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
				sdt = new SdtWP_CreateLocationAndReceptionistData_Step1() ;
			}
		}
	}
	#endregion
}