/*
				   File: type_SdtSDT_Tile
			Description: SDT_Tile
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
	[XmlRoot(ElementName="SDT_Tile")]
	[XmlType(TypeName="SDT_Tile" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Tile : GxUserType
	{
		public SdtSDT_Tile( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Tile_Tilename = "";

			gxTv_SdtSDT_Tile_Tilecolor = "";

			gxTv_SdtSDT_Tile_Tilebgimageurl = "";

			gxTv_SdtSDT_Tile_Productservicename = "";

			gxTv_SdtSDT_Tile_Productservicedescription = "";

			gxTv_SdtSDT_Tile_Productserviceimage = "";
			gxTv_SdtSDT_Tile_Productserviceimage_gxi = "";
			gxTv_SdtSDT_Tile_Topagename = "";

		}

		public SdtSDT_Tile(IGxContext context)
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
			AddObjectProperty("TileId", gxTpr_Tileid, false);


			AddObjectProperty("TileName", gxTpr_Tilename, false);


			AddObjectProperty("TileWidth", gxTpr_Tilewidth, false);


			AddObjectProperty("TileColor", gxTpr_Tilecolor, false);


			AddObjectProperty("TileBGImageUrl", gxTpr_Tilebgimageurl, false);


			AddObjectProperty("ProductServiceId", gxTpr_Productserviceid, false);


			AddObjectProperty("ProductServiceName", gxTpr_Productservicename, false);


			AddObjectProperty("ProductServiceDescription", gxTpr_Productservicedescription, false);


			AddObjectProperty("ProductServiceImage", gxTpr_Productserviceimage, false);
			AddObjectProperty("ProductServiceImage_GXI", gxTpr_Productserviceimage_gxi, false);



			AddObjectProperty("ColId", gxTpr_Colid, false);


			AddObjectProperty("ToPageId", gxTpr_Topageid, false);


			AddObjectProperty("ToPageName", gxTpr_Topagename, false);

			if (gxTv_SdtSDT_Tile_Topage != null)
			{
				AddObjectProperty("ToPage", gxTv_SdtSDT_Tile_Topage, false);
			}
			if (gxTv_SdtSDT_Tile_Attribute != null)
			{
				AddObjectProperty("Attribute", gxTv_SdtSDT_Tile_Attribute, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TileId")]
		[XmlElement(ElementName="TileId")]
		public Guid gxTpr_Tileid
		{
			get {
				return gxTv_SdtSDT_Tile_Tileid; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileid = value;
				SetDirty("Tileid");
			}
		}




		[SoapElement(ElementName="TileName")]
		[XmlElement(ElementName="TileName")]
		public string gxTpr_Tilename
		{
			get {
				return gxTv_SdtSDT_Tile_Tilename; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilename = value;
				SetDirty("Tilename");
			}
		}




		[SoapElement(ElementName="TileWidth")]
		[XmlElement(ElementName="TileWidth")]
		public short gxTpr_Tilewidth
		{
			get {
				return gxTv_SdtSDT_Tile_Tilewidth; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilewidth = value;
				SetDirty("Tilewidth");
			}
		}




		[SoapElement(ElementName="TileColor")]
		[XmlElement(ElementName="TileColor")]
		public string gxTpr_Tilecolor
		{
			get {
				return gxTv_SdtSDT_Tile_Tilecolor; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilecolor = value;
				SetDirty("Tilecolor");
			}
		}




		[SoapElement(ElementName="TileBGImageUrl")]
		[XmlElement(ElementName="TileBGImageUrl")]
		public string gxTpr_Tilebgimageurl
		{
			get {
				return gxTv_SdtSDT_Tile_Tilebgimageurl; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilebgimageurl = value;
				SetDirty("Tilebgimageurl");
			}
		}




		[SoapElement(ElementName="ProductServiceId")]
		[XmlElement(ElementName="ProductServiceId")]
		public Guid gxTpr_Productserviceid
		{
			get {
				return gxTv_SdtSDT_Tile_Productserviceid; 
			}
			set {
				gxTv_SdtSDT_Tile_Productserviceid = value;
				SetDirty("Productserviceid");
			}
		}




		[SoapElement(ElementName="ProductServiceName")]
		[XmlElement(ElementName="ProductServiceName")]
		public string gxTpr_Productservicename
		{
			get {
				return gxTv_SdtSDT_Tile_Productservicename; 
			}
			set {
				gxTv_SdtSDT_Tile_Productservicename = value;
				SetDirty("Productservicename");
			}
		}




		[SoapElement(ElementName="ProductServiceDescription")]
		[XmlElement(ElementName="ProductServiceDescription")]
		public string gxTpr_Productservicedescription
		{
			get {
				return gxTv_SdtSDT_Tile_Productservicedescription; 
			}
			set {
				gxTv_SdtSDT_Tile_Productservicedescription = value;
				SetDirty("Productservicedescription");
			}
		}




		[SoapElement(ElementName="ProductServiceImage")]
		[XmlElement(ElementName="ProductServiceImage")]
		[GxUpload()]

		public string gxTpr_Productserviceimage
		{
			get {
				return gxTv_SdtSDT_Tile_Productserviceimage; 
			}
			set {
				gxTv_SdtSDT_Tile_Productserviceimage = value;
				SetDirty("Productserviceimage");
			}
		}


		[SoapElement(ElementName="ProductServiceImage_GXI" )]
		[XmlElement(ElementName="ProductServiceImage_GXI" )]
		public string gxTpr_Productserviceimage_gxi
		{
			get {
				return gxTv_SdtSDT_Tile_Productserviceimage_gxi ;
			}
			set {
				gxTv_SdtSDT_Tile_Productserviceimage_gxi = value;
				SetDirty("Productserviceimage_gxi");
			}
		}

		[SoapElement(ElementName="ColId")]
		[XmlElement(ElementName="ColId")]
		public Guid gxTpr_Colid
		{
			get {
				return gxTv_SdtSDT_Tile_Colid; 
			}
			set {
				gxTv_SdtSDT_Tile_Colid = value;
				SetDirty("Colid");
			}
		}




		[SoapElement(ElementName="ToPageId")]
		[XmlElement(ElementName="ToPageId")]
		public Guid gxTpr_Topageid
		{
			get {
				return gxTv_SdtSDT_Tile_Topageid; 
			}
			set {
				gxTv_SdtSDT_Tile_Topageid = value;
				SetDirty("Topageid");
			}
		}




		[SoapElement(ElementName="ToPageName")]
		[XmlElement(ElementName="ToPageName")]
		public string gxTpr_Topagename
		{
			get {
				return gxTv_SdtSDT_Tile_Topagename; 
			}
			set {
				gxTv_SdtSDT_Tile_Topagename = value;
				SetDirty("Topagename");
			}
		}



		[SoapElement(ElementName="ToPage")]
		[XmlElement(ElementName="ToPage")]
		public GeneXus.Programs.SdtSDT_Page gxTpr_Topage
		{
			get {
				if ( gxTv_SdtSDT_Tile_Topage == null )
				{
					gxTv_SdtSDT_Tile_Topage = new GeneXus.Programs.SdtSDT_Page(context);
				}
				return gxTv_SdtSDT_Tile_Topage; 
			}
			set {
				gxTv_SdtSDT_Tile_Topage = value;
				SetDirty("Topage");
			}
		}
		public void gxTv_SdtSDT_Tile_Topage_SetNull()
		{
			gxTv_SdtSDT_Tile_Topage_N = true;
			gxTv_SdtSDT_Tile_Topage = null;
		}

		public bool gxTv_SdtSDT_Tile_Topage_IsNull()
		{
			return gxTv_SdtSDT_Tile_Topage == null;
		}
		public bool ShouldSerializegxTpr_Topage_Json()
		{
			return gxTv_SdtSDT_Tile_Topage != null;

		}


		[SoapElement(ElementName="Attribute" )]
		[XmlArray(ElementName="Attribute"  )]
		[XmlArrayItemAttribute(ElementName="AttributeItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_Tile_AttributeItem> gxTpr_Attribute
		{
			get {
				if ( gxTv_SdtSDT_Tile_Attribute == null )
				{
					gxTv_SdtSDT_Tile_Attribute = new GXBaseCollection<SdtSDT_Tile_AttributeItem>( context, "SDT_Tile.AttributeItem", "");
				}
				return gxTv_SdtSDT_Tile_Attribute;
			}
			set {
				gxTv_SdtSDT_Tile_Attribute_N = false;
				gxTv_SdtSDT_Tile_Attribute = value;
				SetDirty("Attribute");
			}
		}

		public void gxTv_SdtSDT_Tile_Attribute_SetNull()
		{
			gxTv_SdtSDT_Tile_Attribute_N = true;
			gxTv_SdtSDT_Tile_Attribute = null;
		}

		public bool gxTv_SdtSDT_Tile_Attribute_IsNull()
		{
			return gxTv_SdtSDT_Tile_Attribute == null;
		}
		public bool ShouldSerializegxTpr_Attribute_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_Tile_Attribute != null && gxTv_SdtSDT_Tile_Attribute.Count > 0;

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
			gxTv_SdtSDT_Tile_Tilename = "";

			gxTv_SdtSDT_Tile_Tilecolor = "";
			gxTv_SdtSDT_Tile_Tilebgimageurl = "";

			gxTv_SdtSDT_Tile_Productservicename = "";
			gxTv_SdtSDT_Tile_Productservicedescription = "";
			gxTv_SdtSDT_Tile_Productserviceimage = "";gxTv_SdtSDT_Tile_Productserviceimage_gxi = "";


			gxTv_SdtSDT_Tile_Topagename = "";

			gxTv_SdtSDT_Tile_Topage_N = true;


			gxTv_SdtSDT_Tile_Attribute_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Tile_Tileid;
		 

		protected string gxTv_SdtSDT_Tile_Tilename;
		 

		protected short gxTv_SdtSDT_Tile_Tilewidth;
		 

		protected string gxTv_SdtSDT_Tile_Tilecolor;
		 

		protected string gxTv_SdtSDT_Tile_Tilebgimageurl;
		 

		protected Guid gxTv_SdtSDT_Tile_Productserviceid;
		 

		protected string gxTv_SdtSDT_Tile_Productservicename;
		 

		protected string gxTv_SdtSDT_Tile_Productservicedescription;
		 
		protected string gxTv_SdtSDT_Tile_Productserviceimage_gxi;
		protected string gxTv_SdtSDT_Tile_Productserviceimage;
		 

		protected Guid gxTv_SdtSDT_Tile_Colid;
		 

		protected Guid gxTv_SdtSDT_Tile_Topageid;
		 

		protected string gxTv_SdtSDT_Tile_Topagename;
		 

		protected GeneXus.Programs.SdtSDT_Page gxTv_SdtSDT_Tile_Topage = null;
		protected bool gxTv_SdtSDT_Tile_Topage_N;
		 
		protected bool gxTv_SdtSDT_Tile_Attribute_N;
		protected GXBaseCollection<SdtSDT_Tile_AttributeItem> gxTv_SdtSDT_Tile_Attribute = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Tile", Namespace="Comforta_version2")]
	public class SdtSDT_Tile_RESTInterface : GxGenericCollectionItem<SdtSDT_Tile>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Tile_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Tile_RESTInterface( SdtSDT_Tile psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TileId", Order=0)]
		public Guid gxTpr_Tileid
		{
			get { 
				return sdt.gxTpr_Tileid;

			}
			set { 
				sdt.gxTpr_Tileid = value;
			}
		}

		[DataMember(Name="TileName", Order=1)]
		public  string gxTpr_Tilename
		{
			get { 
				return sdt.gxTpr_Tilename;

			}
			set { 
				 sdt.gxTpr_Tilename = value;
			}
		}

		[DataMember(Name="TileWidth", Order=2)]
		public short gxTpr_Tilewidth
		{
			get { 
				return sdt.gxTpr_Tilewidth;

			}
			set { 
				sdt.gxTpr_Tilewidth = value;
			}
		}

		[DataMember(Name="TileColor", Order=3)]
		public  string gxTpr_Tilecolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tilecolor);

			}
			set { 
				 sdt.gxTpr_Tilecolor = value;
			}
		}

		[DataMember(Name="TileBGImageUrl", Order=4)]
		public  string gxTpr_Tilebgimageurl
		{
			get { 
				return sdt.gxTpr_Tilebgimageurl;

			}
			set { 
				 sdt.gxTpr_Tilebgimageurl = value;
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

		[DataMember(Name="ProductServiceDescription", Order=7)]
		public  string gxTpr_Productservicedescription
		{
			get { 
				return sdt.gxTpr_Productservicedescription;

			}
			set { 
				 sdt.gxTpr_Productservicedescription = value;
			}
		}

		[DataMember(Name="ProductServiceImage", Order=8)]
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

		[DataMember(Name="ColId", Order=9)]
		public Guid gxTpr_Colid
		{
			get { 
				return sdt.gxTpr_Colid;

			}
			set { 
				sdt.gxTpr_Colid = value;
			}
		}

		[DataMember(Name="ToPageId", Order=10)]
		public Guid gxTpr_Topageid
		{
			get { 
				return sdt.gxTpr_Topageid;

			}
			set { 
				sdt.gxTpr_Topageid = value;
			}
		}

		[DataMember(Name="ToPageName", Order=11)]
		public  string gxTpr_Topagename
		{
			get { 
				return sdt.gxTpr_Topagename;

			}
			set { 
				 sdt.gxTpr_Topagename = value;
			}
		}

		[DataMember(Name="ToPage", Order=12, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_Page_RESTInterface gxTpr_Topage
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Topage_Json())
					return new GeneXus.Programs.SdtSDT_Page_RESTInterface(sdt.gxTpr_Topage);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Topage = value.sdt;
			}
		}

		[DataMember(Name="Attribute", Order=13, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_Tile_AttributeItem_RESTInterface> gxTpr_Attribute
		{
			get {
				if (sdt.ShouldSerializegxTpr_Attribute_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_Tile_AttributeItem_RESTInterface>(sdt.gxTpr_Attribute);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Attribute);
			}
		}


		#endregion

		public SdtSDT_Tile sdt
		{
			get { 
				return (SdtSDT_Tile)Sdt;
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
				sdt = new SdtSDT_Tile() ;
			}
		}
	}
	#endregion
}