/*
				   File: type_SdtSDT_Page
			Description: SDT_Page
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
	[XmlRoot(ElementName="SDT_Page")]
	[XmlType(TypeName="SDT_Page" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Page : GxUserType
	{
		public SdtSDT_Page( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Page_Pagename = "";

		}

		public SdtSDT_Page(IGxContext context)
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

			if (gxTv_SdtSDT_Page_Row != null)
			{
				AddObjectProperty("Row", gxTv_SdtSDT_Page_Row, false);
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
				return gxTv_SdtSDT_Page_Pageid; 
			}
			set {
				gxTv_SdtSDT_Page_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_Page_Pagename; 
			}
			set {
				gxTv_SdtSDT_Page_Pagename = value;
				SetDirty("Pagename");
			}
		}




		[SoapElement(ElementName="Row" )]
		[XmlArray(ElementName="Row"  )]
		[XmlArrayItemAttribute(ElementName="RowItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Row> gxTpr_Row_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_Page_Row == null )
				{
					gxTv_SdtSDT_Page_Row = new GXBaseCollection<GeneXus.Programs.SdtSDT_Row>( context, "SDT_Row", "");
				}
				return gxTv_SdtSDT_Page_Row;
			}
			set {
				gxTv_SdtSDT_Page_Row_N = false;
				gxTv_SdtSDT_Page_Row = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Row> gxTpr_Row
		{
			get {
				if ( gxTv_SdtSDT_Page_Row == null )
				{
					gxTv_SdtSDT_Page_Row = new GXBaseCollection<GeneXus.Programs.SdtSDT_Row>( context, "SDT_Row", "");
				}
				gxTv_SdtSDT_Page_Row_N = false;
				return gxTv_SdtSDT_Page_Row ;
			}
			set {
				gxTv_SdtSDT_Page_Row_N = false;
				gxTv_SdtSDT_Page_Row = value;
				SetDirty("Row");
			}
		}

		public void gxTv_SdtSDT_Page_Row_SetNull()
		{
			gxTv_SdtSDT_Page_Row_N = true;
			gxTv_SdtSDT_Page_Row = null;
		}

		public bool gxTv_SdtSDT_Page_Row_IsNull()
		{
			return gxTv_SdtSDT_Page_Row == null;
		}
		public bool ShouldSerializegxTpr_Row_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_Page_Row != null && gxTv_SdtSDT_Page_Row.Count > 0;

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
			gxTv_SdtSDT_Page_Pagename = "";

			gxTv_SdtSDT_Page_Row_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Page_Pageid;
		 

		protected string gxTv_SdtSDT_Page_Pagename;
		 
		protected bool gxTv_SdtSDT_Page_Row_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_Row> gxTv_SdtSDT_Page_Row = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Page", Namespace="Comforta_version2")]
	public class SdtSDT_Page_RESTInterface : GxGenericCollectionItem<SdtSDT_Page>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Page_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Page_RESTInterface( SdtSDT_Page psdt ) : base(psdt)
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

		[DataMember(Name="Row", Order=2, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_Row_RESTInterface> gxTpr_Row
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Row_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_Row_RESTInterface>(sdt.gxTpr_Row);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Row);
			}
		}


		#endregion

		public SdtSDT_Page sdt
		{
			get { 
				return (SdtSDT_Page)Sdt;
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
				sdt = new SdtSDT_Page() ;
			}
		}
	}
	#endregion
}