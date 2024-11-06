/*
				   File: type_SdtSDT_Col
			Description: SDT_Col
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
	[XmlRoot(ElementName="SDT_Col")]
	[XmlType(TypeName="SDT_Col" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Col : GxUserType
	{
		public SdtSDT_Col( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Col_Colname = "";

			gxTv_SdtSDT_Col_Image = "";
			gxTv_SdtSDT_Col_Image_gxi = "";
			gxTv_SdtSDT_Col_Text = "";

		}

		public SdtSDT_Col(IGxContext context)
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
			AddObjectProperty("ColId", gxTpr_Colid, false);


			AddObjectProperty("ColName", gxTpr_Colname, false);

			if (gxTv_SdtSDT_Col_Tile != null)
			{
				AddObjectProperty("Tile", gxTv_SdtSDT_Col_Tile, false);
			}

			AddObjectProperty("Image", gxTpr_Image, false);
			AddObjectProperty("Image_GXI", gxTpr_Image_gxi, false);



			AddObjectProperty("Text", gxTpr_Text, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ColId")]
		[XmlElement(ElementName="ColId")]
		public Guid gxTpr_Colid
		{
			get {
				return gxTv_SdtSDT_Col_Colid; 
			}
			set {
				gxTv_SdtSDT_Col_Colid = value;
				SetDirty("Colid");
			}
		}




		[SoapElement(ElementName="ColName")]
		[XmlElement(ElementName="ColName")]
		public string gxTpr_Colname
		{
			get {
				return gxTv_SdtSDT_Col_Colname; 
			}
			set {
				gxTv_SdtSDT_Col_Colname = value;
				SetDirty("Colname");
			}
		}



		[SoapElement(ElementName="Tile")]
		[XmlElement(ElementName="Tile")]
		public GeneXus.Programs.SdtSDT_Tile gxTpr_Tile
		{
			get {
				if ( gxTv_SdtSDT_Col_Tile == null )
				{
					gxTv_SdtSDT_Col_Tile = new GeneXus.Programs.SdtSDT_Tile(context);
				}
				return gxTv_SdtSDT_Col_Tile; 
			}
			set {
				gxTv_SdtSDT_Col_Tile = value;
				SetDirty("Tile");
			}
		}
		public void gxTv_SdtSDT_Col_Tile_SetNull()
		{
			gxTv_SdtSDT_Col_Tile_N = true;
			gxTv_SdtSDT_Col_Tile = null;
		}

		public bool gxTv_SdtSDT_Col_Tile_IsNull()
		{
			return gxTv_SdtSDT_Col_Tile == null;
		}
		public bool ShouldSerializegxTpr_Tile_Json()
		{
			return gxTv_SdtSDT_Col_Tile != null;

		}


		[SoapElement(ElementName="Image")]
		[XmlElement(ElementName="Image")]
		[GxUpload()]

		public string gxTpr_Image
		{
			get {
				return gxTv_SdtSDT_Col_Image; 
			}
			set {
				gxTv_SdtSDT_Col_Image = value;
				SetDirty("Image");
			}
		}


		[SoapElement(ElementName="Image_GXI" )]
		[XmlElement(ElementName="Image_GXI" )]
		public string gxTpr_Image_gxi
		{
			get {
				return gxTv_SdtSDT_Col_Image_gxi ;
			}
			set {
				gxTv_SdtSDT_Col_Image_gxi = value;
				SetDirty("Image_gxi");
			}
		}

		[SoapElement(ElementName="Text")]
		[XmlElement(ElementName="Text")]
		public string gxTpr_Text
		{
			get {
				return gxTv_SdtSDT_Col_Text; 
			}
			set {
				gxTv_SdtSDT_Col_Text = value;
				SetDirty("Text");
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
			gxTv_SdtSDT_Col_Colname = "";

			gxTv_SdtSDT_Col_Tile_N = true;

			gxTv_SdtSDT_Col_Image = "";gxTv_SdtSDT_Col_Image_gxi = "";
			gxTv_SdtSDT_Col_Text = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Col_Colid;
		 

		protected string gxTv_SdtSDT_Col_Colname;
		 

		protected GeneXus.Programs.SdtSDT_Tile gxTv_SdtSDT_Col_Tile = null;
		protected bool gxTv_SdtSDT_Col_Tile_N;
		 
		protected string gxTv_SdtSDT_Col_Image_gxi;
		protected string gxTv_SdtSDT_Col_Image;
		 

		protected string gxTv_SdtSDT_Col_Text;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Col", Namespace="Comforta_version2")]
	public class SdtSDT_Col_RESTInterface : GxGenericCollectionItem<SdtSDT_Col>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Col_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Col_RESTInterface( SdtSDT_Col psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ColId", Order=0)]
		public Guid gxTpr_Colid
		{
			get { 
				return sdt.gxTpr_Colid;

			}
			set { 
				sdt.gxTpr_Colid = value;
			}
		}

		[DataMember(Name="ColName", Order=1)]
		public  string gxTpr_Colname
		{
			get { 
				return sdt.gxTpr_Colname;

			}
			set { 
				 sdt.gxTpr_Colname = value;
			}
		}

		[DataMember(Name="Tile", Order=2, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_Tile_RESTInterface gxTpr_Tile
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Tile_Json())
					return new GeneXus.Programs.SdtSDT_Tile_RESTInterface(sdt.gxTpr_Tile);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Tile = value.sdt;
			}
		}

		[DataMember(Name="Image", Order=3)]
		[GxUpload()]
		public  string gxTpr_Image
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Image)) ? PathUtil.RelativePath( sdt.gxTpr_Image) : StringUtil.RTrim( sdt.gxTpr_Image_gxi));

			}
			set { 
				 sdt.gxTpr_Image = value;
			}
		}

		[DataMember(Name="Text", Order=4)]
		public  string gxTpr_Text
		{
			get { 
				return sdt.gxTpr_Text;

			}
			set { 
				 sdt.gxTpr_Text = value;
			}
		}


		#endregion

		public SdtSDT_Col sdt
		{
			get { 
				return (SdtSDT_Col)Sdt;
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
				sdt = new SdtSDT_Col() ;
			}
		}
	}
	#endregion
}