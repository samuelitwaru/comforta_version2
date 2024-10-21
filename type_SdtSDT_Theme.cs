/*
				   File: type_SdtSDT_Theme
			Description: SDT_Theme
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
	[XmlRoot(ElementName="SDT_Theme")]
	[XmlType(TypeName="SDT_Theme" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Theme : GxUserType
	{
		public SdtSDT_Theme( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Theme_Trn_themename = "";

			gxTv_SdtSDT_Theme_Trn_themefontfamily = "";

		}

		public SdtSDT_Theme(IGxContext context)
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
			AddObjectProperty("Trn_ThemeId", gxTpr_Trn_themeid, false);


			AddObjectProperty("Trn_ThemeName", gxTpr_Trn_themename, false);


			AddObjectProperty("Trn_ThemeFontFamily", gxTpr_Trn_themefontfamily, false);


			AddObjectProperty("Trn_ThemeFontSize", gxTpr_Trn_themefontsize, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Trn_ThemeId")]
		[XmlElement(ElementName="Trn_ThemeId")]
		public Guid gxTpr_Trn_themeid
		{
			get {
				return gxTv_SdtSDT_Theme_Trn_themeid; 
			}
			set {
				gxTv_SdtSDT_Theme_Trn_themeid = value;
				SetDirty("Trn_themeid");
			}
		}




		[SoapElement(ElementName="Trn_ThemeName")]
		[XmlElement(ElementName="Trn_ThemeName")]
		public string gxTpr_Trn_themename
		{
			get {
				return gxTv_SdtSDT_Theme_Trn_themename; 
			}
			set {
				gxTv_SdtSDT_Theme_Trn_themename = value;
				SetDirty("Trn_themename");
			}
		}




		[SoapElement(ElementName="Trn_ThemeFontFamily")]
		[XmlElement(ElementName="Trn_ThemeFontFamily")]
		public string gxTpr_Trn_themefontfamily
		{
			get {
				return gxTv_SdtSDT_Theme_Trn_themefontfamily; 
			}
			set {
				gxTv_SdtSDT_Theme_Trn_themefontfamily = value;
				SetDirty("Trn_themefontfamily");
			}
		}




		[SoapElement(ElementName="Trn_ThemeFontSize")]
		[XmlElement(ElementName="Trn_ThemeFontSize")]
		public short gxTpr_Trn_themefontsize
		{
			get {
				return gxTv_SdtSDT_Theme_Trn_themefontsize; 
			}
			set {
				gxTv_SdtSDT_Theme_Trn_themefontsize = value;
				SetDirty("Trn_themefontsize");
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
			gxTv_SdtSDT_Theme_Trn_themename = "";
			gxTv_SdtSDT_Theme_Trn_themefontfamily = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Theme_Trn_themeid;
		 

		protected string gxTv_SdtSDT_Theme_Trn_themename;
		 

		protected string gxTv_SdtSDT_Theme_Trn_themefontfamily;
		 

		protected short gxTv_SdtSDT_Theme_Trn_themefontsize;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Theme", Namespace="Comforta_version2")]
	public class SdtSDT_Theme_RESTInterface : GxGenericCollectionItem<SdtSDT_Theme>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Theme_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Theme_RESTInterface( SdtSDT_Theme psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Trn_ThemeId", Order=0)]
		public Guid gxTpr_Trn_themeid
		{
			get { 
				return sdt.gxTpr_Trn_themeid;

			}
			set { 
				sdt.gxTpr_Trn_themeid = value;
			}
		}

		[DataMember(Name="Trn_ThemeName", Order=1)]
		public  string gxTpr_Trn_themename
		{
			get { 
				return sdt.gxTpr_Trn_themename;

			}
			set { 
				 sdt.gxTpr_Trn_themename = value;
			}
		}

		[DataMember(Name="Trn_ThemeFontFamily", Order=2)]
		public  string gxTpr_Trn_themefontfamily
		{
			get { 
				return sdt.gxTpr_Trn_themefontfamily;

			}
			set { 
				 sdt.gxTpr_Trn_themefontfamily = value;
			}
		}

		[DataMember(Name="Trn_ThemeFontSize", Order=3)]
		public short gxTpr_Trn_themefontsize
		{
			get { 
				return sdt.gxTpr_Trn_themefontsize;

			}
			set { 
				sdt.gxTpr_Trn_themefontsize = value;
			}
		}


		#endregion

		public SdtSDT_Theme sdt
		{
			get { 
				return (SdtSDT_Theme)Sdt;
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
				sdt = new SdtSDT_Theme() ;
			}
		}
	}
	#endregion
}