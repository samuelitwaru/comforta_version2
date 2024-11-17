/*
				   File: type_SdtSDT_ContentPage1
			Description: SDT_ContentPage1
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
	[XmlRoot(ElementName="SDT_ContentPage1")]
	[XmlType(TypeName="SDT_ContentPage1" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ContentPage1 : GxUserType
	{
		public SdtSDT_ContentPage1( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ContentPage1_Pagename = "";

			gxTv_SdtSDT_ContentPage1_Productserviceimage = "";
			gxTv_SdtSDT_ContentPage1_Productserviceimage_gxi = "";
			gxTv_SdtSDT_ContentPage1_Productservicedescription = "";

		}

		public SdtSDT_ContentPage1(IGxContext context)
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
			AddObjectProperty("PageId", gxTpr_Pageid, false);


			AddObjectProperty("PageName", gxTpr_Pagename, false);


			AddObjectProperty("ProductServiceImage", gxTpr_Productserviceimage, false);
			AddObjectProperty("ProductServiceImage_GXI", gxTpr_Productserviceimage_gxi, false);



			AddObjectProperty("ProductServiceDescription", gxTpr_Productservicedescription, false);

			if (gxTv_SdtSDT_ContentPage1_Row != null)
			{
				AddObjectProperty("Row", gxTv_SdtSDT_ContentPage1_Row, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PageId")]
		[XmlElement(ElementName="PageId")]
		public Guid gxTpr_Pageid
		{
			get {
				return gxTv_SdtSDT_ContentPage1_Pageid; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_ContentPage1_Pagename; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_Pagename = value;
				SetDirty("Pagename");
			}
		}




		[SoapElement(ElementName="ProductServiceImage")]
		[XmlElement(ElementName="ProductServiceImage")]
		[GxUpload()]

		public string gxTpr_Productserviceimage
		{
			get {
				return gxTv_SdtSDT_ContentPage1_Productserviceimage; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_Productserviceimage = value;
				SetDirty("Productserviceimage");
			}
		}


		[SoapElement(ElementName="ProductServiceImage_GXI" )]
		[XmlElement(ElementName="ProductServiceImage_GXI" )]
		public string gxTpr_Productserviceimage_gxi
		{
			get {
				return gxTv_SdtSDT_ContentPage1_Productserviceimage_gxi ;
			}
			set {
				gxTv_SdtSDT_ContentPage1_Productserviceimage_gxi = value;
				SetDirty("Productserviceimage_gxi");
			}
		}

		[SoapElement(ElementName="ProductServiceDescription")]
		[XmlElement(ElementName="ProductServiceDescription")]
		public string gxTpr_Productservicedescription
		{
			get {
				return gxTv_SdtSDT_ContentPage1_Productservicedescription; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_Productservicedescription = value;
				SetDirty("Productservicedescription");
			}
		}




		[SoapElement(ElementName="Row" )]
		[XmlArray(ElementName="Row"  )]
		[XmlArrayItemAttribute(ElementName="RowItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_ContentPage1_RowItem> gxTpr_Row
		{
			get {
				if ( gxTv_SdtSDT_ContentPage1_Row == null )
				{
					gxTv_SdtSDT_ContentPage1_Row = new GXBaseCollection<SdtSDT_ContentPage1_RowItem>( context, "SDT_ContentPage1.RowItem", "");
				}
				return gxTv_SdtSDT_ContentPage1_Row;
			}
			set {
				gxTv_SdtSDT_ContentPage1_Row_N = false;
				gxTv_SdtSDT_ContentPage1_Row = value;
				SetDirty("Row");
			}
		}

		public void gxTv_SdtSDT_ContentPage1_Row_SetNull()
		{
			gxTv_SdtSDT_ContentPage1_Row_N = true;
			gxTv_SdtSDT_ContentPage1_Row = null;
		}

		public bool gxTv_SdtSDT_ContentPage1_Row_IsNull()
		{
			return gxTv_SdtSDT_ContentPage1_Row == null;
		}
		public bool ShouldSerializegxTpr_Row_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_ContentPage1_Row != null && gxTv_SdtSDT_ContentPage1_Row.Count > 0;

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
			gxTv_SdtSDT_ContentPage1_Pagename = "";
			gxTv_SdtSDT_ContentPage1_Productserviceimage = "";gxTv_SdtSDT_ContentPage1_Productserviceimage_gxi = "";
			gxTv_SdtSDT_ContentPage1_Productservicedescription = "";

			gxTv_SdtSDT_ContentPage1_Row_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_ContentPage1_Pageid;
		 

		protected string gxTv_SdtSDT_ContentPage1_Pagename;
		 
		protected string gxTv_SdtSDT_ContentPage1_Productserviceimage_gxi;
		protected string gxTv_SdtSDT_ContentPage1_Productserviceimage;
		 

		protected string gxTv_SdtSDT_ContentPage1_Productservicedescription;
		 
		protected bool gxTv_SdtSDT_ContentPage1_Row_N;
		protected GXBaseCollection<SdtSDT_ContentPage1_RowItem> gxTv_SdtSDT_ContentPage1_Row = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_ContentPage1", Namespace="Comforta_version2")]
	public class SdtSDT_ContentPage1_RESTInterface : GxGenericCollectionItem<SdtSDT_ContentPage1>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ContentPage1_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ContentPage1_RESTInterface( SdtSDT_ContentPage1 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PageId", Order=0)]
		public Guid gxTpr_Pageid
		{
			get { 
				return sdt.gxTpr_Pageid;

			}
			set { 
				sdt.gxTpr_Pageid = value;
			}
		}

		[DataMember(Name="PageName", Order=1)]
		public  string gxTpr_Pagename
		{
			get { 
				return sdt.gxTpr_Pagename;

			}
			set { 
				 sdt.gxTpr_Pagename = value;
			}
		}

		[DataMember(Name="ProductServiceImage", Order=2)]
		[GxUpload()]
		public  string gxTpr_Productserviceimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productserviceimage)) ? PathUtil.RelativePath( sdt.gxTpr_Productserviceimage) : StringUtil.RTrim( sdt.gxTpr_Productserviceimage_gxi));

			}
			set { 
				 sdt.gxTpr_Productserviceimage = value;
			}
		}

		[DataMember(Name="ProductServiceDescription", Order=3)]
		public  string gxTpr_Productservicedescription
		{
			get { 
				return sdt.gxTpr_Productservicedescription;

			}
			set { 
				 sdt.gxTpr_Productservicedescription = value;
			}
		}

		[DataMember(Name="Row", Order=4, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_ContentPage1_RowItem_RESTInterface> gxTpr_Row
		{
			get {
				if (sdt.ShouldSerializegxTpr_Row_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_ContentPage1_RowItem_RESTInterface>(sdt.gxTpr_Row);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Row);
			}
		}


		#endregion

		public SdtSDT_ContentPage1 sdt
		{
			get { 
				return (SdtSDT_ContentPage1)Sdt;
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
				sdt = new SdtSDT_ContentPage1() ;
			}
		}
	}
	#endregion
}