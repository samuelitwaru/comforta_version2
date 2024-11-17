/*
				   File: type_SdtSDT_ContentPage1_RowItem_ContentItem
			Description: Content
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
	[XmlRoot(ElementName="SDT_ContentPage1.RowItem.ContentItem")]
	[XmlType(TypeName="SDT_ContentPage1.RowItem.ContentItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ContentPage1_RowItem_ContentItem : GxUserType
	{
		public SdtSDT_ContentPage1_RowItem_ContentItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Contenttype = "";

			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Contentvalue = "";

			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionname = "";

			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionphone = "";

			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionurl = "";

			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionemail = "";

			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Backgroundcolor = "";

		}

		public SdtSDT_ContentPage1_RowItem_ContentItem(IGxContext context)
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
			AddObjectProperty("ContentType", gxTpr_Contenttype, false);


			AddObjectProperty("ContentValue", gxTpr_Contentvalue, false);


			AddObjectProperty("CallToActionId", gxTpr_Calltoactionid, false);


			AddObjectProperty("CallToActionName", gxTpr_Calltoactionname, false);


			AddObjectProperty("CallToActionPhone", gxTpr_Calltoactionphone, false);


			AddObjectProperty("CallToActionUrl", gxTpr_Calltoactionurl, false);


			AddObjectProperty("CallToActionEmail", gxTpr_Calltoactionemail, false);


			AddObjectProperty("BackgroundColor", gxTpr_Backgroundcolor, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ContentType")]
		[XmlElement(ElementName="ContentType")]
		public string gxTpr_Contenttype
		{
			get {
				return gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Contenttype; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Contenttype = value;
				SetDirty("Contenttype");
			}
		}




		[SoapElement(ElementName="ContentValue")]
		[XmlElement(ElementName="ContentValue")]
		public string gxTpr_Contentvalue
		{
			get {
				return gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Contentvalue; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Contentvalue = value;
				SetDirty("Contentvalue");
			}
		}




		[SoapElement(ElementName="CallToActionId")]
		[XmlElement(ElementName="CallToActionId")]
		public Guid gxTpr_Calltoactionid
		{
			get {
				return gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionid; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionid = value;
				SetDirty("Calltoactionid");
			}
		}




		[SoapElement(ElementName="CallToActionName")]
		[XmlElement(ElementName="CallToActionName")]
		public string gxTpr_Calltoactionname
		{
			get {
				return gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionname; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionname = value;
				SetDirty("Calltoactionname");
			}
		}




		[SoapElement(ElementName="CallToActionPhone")]
		[XmlElement(ElementName="CallToActionPhone")]
		public string gxTpr_Calltoactionphone
		{
			get {
				return gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionphone; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionphone = value;
				SetDirty("Calltoactionphone");
			}
		}




		[SoapElement(ElementName="CallToActionUrl")]
		[XmlElement(ElementName="CallToActionUrl")]
		public string gxTpr_Calltoactionurl
		{
			get {
				return gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionurl; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionurl = value;
				SetDirty("Calltoactionurl");
			}
		}




		[SoapElement(ElementName="CallToActionEmail")]
		[XmlElement(ElementName="CallToActionEmail")]
		public string gxTpr_Calltoactionemail
		{
			get {
				return gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionemail; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionemail = value;
				SetDirty("Calltoactionemail");
			}
		}




		[SoapElement(ElementName="BackgroundColor")]
		[XmlElement(ElementName="BackgroundColor")]
		public string gxTpr_Backgroundcolor
		{
			get {
				return gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Backgroundcolor; 
			}
			set {
				gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Backgroundcolor = value;
				SetDirty("Backgroundcolor");
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
			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Contenttype = "";
			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Contentvalue = "";

			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionname = "";
			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionphone = "";
			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionurl = "";
			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionemail = "";
			gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Backgroundcolor = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Contenttype;
		 

		protected string gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Contentvalue;
		 

		protected Guid gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionid;
		 

		protected string gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionname;
		 

		protected string gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionphone;
		 

		protected string gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionurl;
		 

		protected string gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Calltoactionemail;
		 

		protected string gxTv_SdtSDT_ContentPage1_RowItem_ContentItem_Backgroundcolor;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ContentPage1.RowItem.ContentItem", Namespace="Comforta_version2")]
	public class SdtSDT_ContentPage1_RowItem_ContentItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ContentPage1_RowItem_ContentItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ContentPage1_RowItem_ContentItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ContentPage1_RowItem_ContentItem_RESTInterface( SdtSDT_ContentPage1_RowItem_ContentItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ContentType", Order=0)]
		public  string gxTpr_Contenttype
		{
			get { 
				return sdt.gxTpr_Contenttype;

			}
			set { 
				 sdt.gxTpr_Contenttype = value;
			}
		}

		[DataMember(Name="ContentValue", Order=1)]
		public  string gxTpr_Contentvalue
		{
			get { 
				return sdt.gxTpr_Contentvalue;

			}
			set { 
				 sdt.gxTpr_Contentvalue = value;
			}
		}

		[DataMember(Name="CallToActionId", Order=2)]
		public Guid gxTpr_Calltoactionid
		{
			get { 
				return sdt.gxTpr_Calltoactionid;

			}
			set { 
				sdt.gxTpr_Calltoactionid = value;
			}
		}

		[DataMember(Name="CallToActionName", Order=3)]
		public  string gxTpr_Calltoactionname
		{
			get { 
				return sdt.gxTpr_Calltoactionname;

			}
			set { 
				 sdt.gxTpr_Calltoactionname = value;
			}
		}

		[DataMember(Name="CallToActionPhone", Order=4)]
		public  string gxTpr_Calltoactionphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Calltoactionphone);

			}
			set { 
				 sdt.gxTpr_Calltoactionphone = value;
			}
		}

		[DataMember(Name="CallToActionUrl", Order=5)]
		public  string gxTpr_Calltoactionurl
		{
			get { 
				return sdt.gxTpr_Calltoactionurl;

			}
			set { 
				 sdt.gxTpr_Calltoactionurl = value;
			}
		}

		[DataMember(Name="CallToActionEmail", Order=6)]
		public  string gxTpr_Calltoactionemail
		{
			get { 
				return sdt.gxTpr_Calltoactionemail;

			}
			set { 
				 sdt.gxTpr_Calltoactionemail = value;
			}
		}

		[DataMember(Name="BackgroundColor", Order=7)]
		public  string gxTpr_Backgroundcolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Backgroundcolor);

			}
			set { 
				 sdt.gxTpr_Backgroundcolor = value;
			}
		}


		#endregion

		public SdtSDT_ContentPage1_RowItem_ContentItem sdt
		{
			get { 
				return (SdtSDT_ContentPage1_RowItem_ContentItem)Sdt;
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
				sdt = new SdtSDT_ContentPage1_RowItem_ContentItem() ;
			}
		}
	}
	#endregion
}