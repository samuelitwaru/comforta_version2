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

			gxTv_SdtSDT_Tile_Tileicon = "";

			gxTv_SdtSDT_Tile_Tilebgcolor = "";

			gxTv_SdtSDT_Tile_Tilebgimageurl = "";

			gxTv_SdtSDT_Tile_Tiletextcolor = "";

			gxTv_SdtSDT_Tile_Tiletextalignment = "";

			gxTv_SdtSDT_Tile_Tileiconalignment = "";

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


			AddObjectProperty("TileIcon", gxTpr_Tileicon, false);


			AddObjectProperty("TileBGColor", gxTpr_Tilebgcolor, false);


			AddObjectProperty("TileBGImageUrl", gxTpr_Tilebgimageurl, false);


			AddObjectProperty("TileTextColor", gxTpr_Tiletextcolor, false);


			AddObjectProperty("TileTextAlignment", gxTpr_Tiletextalignment, false);


			AddObjectProperty("TileIconAlignment", gxTpr_Tileiconalignment, false);


			AddObjectProperty("ProductServiceId", gxTpr_Productserviceid, false);


			AddObjectProperty("ProductServiceName", gxTpr_Productservicename, false);


			AddObjectProperty("ProductServiceDescription", gxTpr_Productservicedescription, false);


			AddObjectProperty("ProductServiceImage", gxTpr_Productserviceimage, false);
			AddObjectProperty("ProductServiceImage_GXI", gxTpr_Productserviceimage_gxi, false);



			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("ToPageId", gxTpr_Topageid, false);


			AddObjectProperty("ToPageName", gxTpr_Topagename, false);

			if (gxTv_SdtSDT_Tile_Topage != null)
			{
				AddObjectProperty("ToPage", gxTv_SdtSDT_Tile_Topage, false);
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




		[SoapElement(ElementName="TileIcon")]
		[XmlElement(ElementName="TileIcon")]
		public string gxTpr_Tileicon
		{
			get {
				return gxTv_SdtSDT_Tile_Tileicon; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileicon = value;
				SetDirty("Tileicon");
			}
		}




		[SoapElement(ElementName="TileBGColor")]
		[XmlElement(ElementName="TileBGColor")]
		public string gxTpr_Tilebgcolor
		{
			get {
				return gxTv_SdtSDT_Tile_Tilebgcolor; 
			}
			set {
				gxTv_SdtSDT_Tile_Tilebgcolor = value;
				SetDirty("Tilebgcolor");
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




		[SoapElement(ElementName="TileTextColor")]
		[XmlElement(ElementName="TileTextColor")]
		public string gxTpr_Tiletextcolor
		{
			get {
				return gxTv_SdtSDT_Tile_Tiletextcolor; 
			}
			set {
				gxTv_SdtSDT_Tile_Tiletextcolor = value;
				SetDirty("Tiletextcolor");
			}
		}




		[SoapElement(ElementName="TileTextAlignment")]
		[XmlElement(ElementName="TileTextAlignment")]
		public string gxTpr_Tiletextalignment
		{
			get {
				return gxTv_SdtSDT_Tile_Tiletextalignment; 
			}
			set {
				gxTv_SdtSDT_Tile_Tiletextalignment = value;
				SetDirty("Tiletextalignment");
			}
		}




		[SoapElement(ElementName="TileIconAlignment")]
		[XmlElement(ElementName="TileIconAlignment")]
		public string gxTpr_Tileiconalignment
		{
			get {
				return gxTv_SdtSDT_Tile_Tileiconalignment; 
			}
			set {
				gxTv_SdtSDT_Tile_Tileiconalignment = value;
				SetDirty("Tileiconalignment");
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

		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_Tile_Organisationid; 
			}
			set {
				gxTv_SdtSDT_Tile_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_Tile_Locationid; 
			}
			set {
				gxTv_SdtSDT_Tile_Locationid = value;
				SetDirty("Locationid");
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
			gxTv_SdtSDT_Tile_Tileicon = "";
			gxTv_SdtSDT_Tile_Tilebgcolor = "";
			gxTv_SdtSDT_Tile_Tilebgimageurl = "";
			gxTv_SdtSDT_Tile_Tiletextcolor = "";
			gxTv_SdtSDT_Tile_Tiletextalignment = "";
			gxTv_SdtSDT_Tile_Tileiconalignment = "";

			gxTv_SdtSDT_Tile_Productservicename = "";
			gxTv_SdtSDT_Tile_Productservicedescription = "";
			gxTv_SdtSDT_Tile_Productserviceimage = "";gxTv_SdtSDT_Tile_Productserviceimage_gxi = "";



			gxTv_SdtSDT_Tile_Topagename = "";

			gxTv_SdtSDT_Tile_Topage_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Tile_Tileid;
		 

		protected string gxTv_SdtSDT_Tile_Tilename;
		 

		protected string gxTv_SdtSDT_Tile_Tileicon;
		 

		protected string gxTv_SdtSDT_Tile_Tilebgcolor;
		 

		protected string gxTv_SdtSDT_Tile_Tilebgimageurl;
		 

		protected string gxTv_SdtSDT_Tile_Tiletextcolor;
		 

		protected string gxTv_SdtSDT_Tile_Tiletextalignment;
		 

		protected string gxTv_SdtSDT_Tile_Tileiconalignment;
		 

		protected Guid gxTv_SdtSDT_Tile_Productserviceid;
		 

		protected string gxTv_SdtSDT_Tile_Productservicename;
		 

		protected string gxTv_SdtSDT_Tile_Productservicedescription;
		 
		protected string gxTv_SdtSDT_Tile_Productserviceimage_gxi;
		protected string gxTv_SdtSDT_Tile_Productserviceimage;
		 

		protected Guid gxTv_SdtSDT_Tile_Organisationid;
		 

		protected Guid gxTv_SdtSDT_Tile_Locationid;
		 

		protected Guid gxTv_SdtSDT_Tile_Topageid;
		 

		protected string gxTv_SdtSDT_Tile_Topagename;
		 

		protected GeneXus.Programs.SdtSDT_Page gxTv_SdtSDT_Tile_Topage = null;
		protected bool gxTv_SdtSDT_Tile_Topage_N;
		 


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

		[DataMember(Name="TileIcon", Order=2)]
		public  string gxTpr_Tileicon
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tileicon);

			}
			set { 
				 sdt.gxTpr_Tileicon = value;
			}
		}

		[DataMember(Name="TileBGColor", Order=3)]
		public  string gxTpr_Tilebgcolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tilebgcolor);

			}
			set { 
				 sdt.gxTpr_Tilebgcolor = value;
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

		[DataMember(Name="TileTextColor", Order=5)]
		public  string gxTpr_Tiletextcolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tiletextcolor);

			}
			set { 
				 sdt.gxTpr_Tiletextcolor = value;
			}
		}

		[DataMember(Name="TileTextAlignment", Order=6)]
		public  string gxTpr_Tiletextalignment
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tiletextalignment);

			}
			set { 
				 sdt.gxTpr_Tiletextalignment = value;
			}
		}

		[DataMember(Name="TileIconAlignment", Order=7)]
		public  string gxTpr_Tileiconalignment
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tileiconalignment);

			}
			set { 
				 sdt.gxTpr_Tileiconalignment = value;
			}
		}

		[DataMember(Name="ProductServiceId", Order=8)]
		public Guid gxTpr_Productserviceid
		{
			get { 
				return sdt.gxTpr_Productserviceid;

			}
			set { 
				sdt.gxTpr_Productserviceid = value;
			}
		}

		[DataMember(Name="ProductServiceName", Order=9)]
		public  string gxTpr_Productservicename
		{
			get { 
				return sdt.gxTpr_Productservicename;

			}
			set { 
				 sdt.gxTpr_Productservicename = value;
			}
		}

		[DataMember(Name="ProductServiceDescription", Order=10)]
		public  string gxTpr_Productservicedescription
		{
			get { 
				return sdt.gxTpr_Productservicedescription;

			}
			set { 
				 sdt.gxTpr_Productservicedescription = value;
			}
		}

		[DataMember(Name="ProductServiceImage", Order=11)]
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

		[DataMember(Name="OrganisationId", Order=12)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="LocationId", Order=13)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="ToPageId", Order=14)]
		public Guid gxTpr_Topageid
		{
			get { 
				return sdt.gxTpr_Topageid;

			}
			set { 
				sdt.gxTpr_Topageid = value;
			}
		}

		[DataMember(Name="ToPageName", Order=15)]
		public  string gxTpr_Topagename
		{
			get { 
				return sdt.gxTpr_Topagename;

			}
			set { 
				 sdt.gxTpr_Topagename = value;
			}
		}

		[DataMember(Name="ToPage", Order=16, EmitDefaultValue=false)]
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