/*
				   File: type_SdtWP_ProductServiceData_Step1
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
	[XmlRoot(ElementName="WP_ProductServiceData.Step1")]
	[XmlType(TypeName="WP_ProductServiceData.Step1" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWP_ProductServiceData_Step1 : GxUserType
	{
		public SdtWP_ProductServiceData_Step1( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_ProductServiceData_Step1_Productserviceclass = "";

			gxTv_SdtWP_ProductServiceData_Step1_Productservicegroup = "";

			gxTv_SdtWP_ProductServiceData_Step1_Productservicedescription = "";

			gxTv_SdtWP_ProductServiceData_Step1_Productservicename = "";

			gxTv_SdtWP_ProductServiceData_Step1_Productservicetilename = "";

			gxTv_SdtWP_ProductServiceData_Step1_Productserviceimagevar = "";

			gxTv_SdtWP_ProductServiceData_Step1_Filename = "";

		}

		public SdtWP_ProductServiceData_Step1(IGxContext context)
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
			AddObjectProperty("ProductServiceClass", gxTpr_Productserviceclass, false);


			AddObjectProperty("ProductServiceGroup", gxTpr_Productservicegroup, false);


			AddObjectProperty("ProductServiceDescription", gxTpr_Productservicedescription, false);


			AddObjectProperty("SupplierGenId", gxTpr_Suppliergenid, false);


			AddObjectProperty("SupplierAgbId", gxTpr_Supplieragbid, false);


			AddObjectProperty("ProductServiceId", gxTpr_Productserviceid, false);


			AddObjectProperty("ProductServiceName", gxTpr_Productservicename, false);


			AddObjectProperty("ProductServiceTileName", gxTpr_Productservicetilename, false);


			AddObjectProperty("ProductServiceImageVar", gxTpr_Productserviceimagevar, false);


			AddObjectProperty("FileName", gxTpr_Filename, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProductServiceClass")]
		[XmlElement(ElementName="ProductServiceClass")]
		public string gxTpr_Productserviceclass
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step1_Productserviceclass; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_Productserviceclass = value;
				SetDirty("Productserviceclass");
			}
		}




		[SoapElement(ElementName="ProductServiceGroup")]
		[XmlElement(ElementName="ProductServiceGroup")]
		public string gxTpr_Productservicegroup
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step1_Productservicegroup; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_Productservicegroup = value;
				SetDirty("Productservicegroup");
			}
		}




		[SoapElement(ElementName="ProductServiceDescription")]
		[XmlElement(ElementName="ProductServiceDescription")]
		public string gxTpr_Productservicedescription
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step1_Productservicedescription; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_Productservicedescription = value;
				SetDirty("Productservicedescription");
			}
		}




		[SoapElement(ElementName="SupplierGenId")]
		[XmlElement(ElementName="SupplierGenId")]
		public Guid gxTpr_Suppliergenid
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step1_Suppliergenid; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_Suppliergenid = value;
				SetDirty("Suppliergenid");
			}
		}




		[SoapElement(ElementName="SupplierAgbId")]
		[XmlElement(ElementName="SupplierAgbId")]
		public Guid gxTpr_Supplieragbid
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step1_Supplieragbid; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_Supplieragbid = value;
				SetDirty("Supplieragbid");
			}
		}




		[SoapElement(ElementName="ProductServiceId")]
		[XmlElement(ElementName="ProductServiceId")]
		public Guid gxTpr_Productserviceid
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step1_Productserviceid; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_Productserviceid = value;
				SetDirty("Productserviceid");
			}
		}




		[SoapElement(ElementName="ProductServiceName")]
		[XmlElement(ElementName="ProductServiceName")]
		public string gxTpr_Productservicename
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step1_Productservicename; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_Productservicename = value;
				SetDirty("Productservicename");
			}
		}




		[SoapElement(ElementName="ProductServiceTileName")]
		[XmlElement(ElementName="ProductServiceTileName")]
		public string gxTpr_Productservicetilename
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step1_Productservicetilename; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_Productservicetilename = value;
				SetDirty("Productservicetilename");
			}
		}




		[SoapElement(ElementName="ProductServiceImageVar")]
		[XmlElement(ElementName="ProductServiceImageVar")]
		public string gxTpr_Productserviceimagevar
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step1_Productserviceimagevar; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_Productserviceimagevar = value;
				SetDirty("Productserviceimagevar");
			}
		}




		[SoapElement(ElementName="FileName")]
		[XmlElement(ElementName="FileName")]
		public string gxTpr_Filename
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step1_Filename; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step1_Filename = value;
				SetDirty("Filename");
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
			gxTv_SdtWP_ProductServiceData_Step1_Productserviceclass = "";
			gxTv_SdtWP_ProductServiceData_Step1_Productservicegroup = "";
			gxTv_SdtWP_ProductServiceData_Step1_Productservicedescription = "";



			gxTv_SdtWP_ProductServiceData_Step1_Productservicename = "";
			gxTv_SdtWP_ProductServiceData_Step1_Productservicetilename = "";
			gxTv_SdtWP_ProductServiceData_Step1_Productserviceimagevar = "";
			gxTv_SdtWP_ProductServiceData_Step1_Filename = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWP_ProductServiceData_Step1_Productserviceclass;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step1_Productservicegroup;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step1_Productservicedescription;
		 

		protected Guid gxTv_SdtWP_ProductServiceData_Step1_Suppliergenid;
		 

		protected Guid gxTv_SdtWP_ProductServiceData_Step1_Supplieragbid;
		 

		protected Guid gxTv_SdtWP_ProductServiceData_Step1_Productserviceid;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step1_Productservicename;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step1_Productservicetilename;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step1_Productserviceimagevar;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step1_Filename;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_ProductServiceData.Step1", Namespace="Comforta_version2")]
	public class SdtWP_ProductServiceData_Step1_RESTInterface : GxGenericCollectionItem<SdtWP_ProductServiceData_Step1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_ProductServiceData_Step1_RESTInterface( ) : base()
		{	
		}

		public SdtWP_ProductServiceData_Step1_RESTInterface( SdtWP_ProductServiceData_Step1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProductServiceClass", Order=0)]
		public  string gxTpr_Productserviceclass
		{
			get { 
				return sdt.gxTpr_Productserviceclass;

			}
			set { 
				 sdt.gxTpr_Productserviceclass = value;
			}
		}

		[DataMember(Name="ProductServiceGroup", Order=1)]
		public  string gxTpr_Productservicegroup
		{
			get { 
				return sdt.gxTpr_Productservicegroup;

			}
			set { 
				 sdt.gxTpr_Productservicegroup = value;
			}
		}

		[DataMember(Name="ProductServiceDescription", Order=2)]
		public  string gxTpr_Productservicedescription
		{
			get { 
				return sdt.gxTpr_Productservicedescription;

			}
			set { 
				 sdt.gxTpr_Productservicedescription = value;
			}
		}

		[DataMember(Name="SupplierGenId", Order=3)]
		public Guid gxTpr_Suppliergenid
		{
			get { 
				return sdt.gxTpr_Suppliergenid;

			}
			set { 
				sdt.gxTpr_Suppliergenid = value;
			}
		}

		[DataMember(Name="SupplierAgbId", Order=4)]
		public Guid gxTpr_Supplieragbid
		{
			get { 
				return sdt.gxTpr_Supplieragbid;

			}
			set { 
				sdt.gxTpr_Supplieragbid = value;
			}
		}

		[DataMember(Name="ProductServiceId", Order=5)]
		public Guid gxTpr_Productserviceid
		{
			get { 
				return sdt.gxTpr_Productserviceid;

			}
			set { 
				sdt.gxTpr_Productserviceid = value;
			}
		}

		[DataMember(Name="ProductServiceName", Order=6)]
		public  string gxTpr_Productservicename
		{
			get { 
				return sdt.gxTpr_Productservicename;

			}
			set { 
				 sdt.gxTpr_Productservicename = value;
			}
		}

		[DataMember(Name="ProductServiceTileName", Order=7)]
		public  string gxTpr_Productservicetilename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Productservicetilename);

			}
			set { 
				 sdt.gxTpr_Productservicetilename = value;
			}
		}

		[DataMember(Name="ProductServiceImageVar", Order=8)]
		public  string gxTpr_Productserviceimagevar
		{
			get { 
				return sdt.gxTpr_Productserviceimagevar;

			}
			set { 
				 sdt.gxTpr_Productserviceimagevar = value;
			}
		}

		[DataMember(Name="FileName", Order=9)]
		public  string gxTpr_Filename
		{
			get { 
				return sdt.gxTpr_Filename;

			}
			set { 
				 sdt.gxTpr_Filename = value;
			}
		}


		#endregion

		public SdtWP_ProductServiceData_Step1 sdt
		{
			get { 
				return (SdtWP_ProductServiceData_Step1)Sdt;
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
				sdt = new SdtWP_ProductServiceData_Step1() ;
			}
		}
	}
	#endregion
}