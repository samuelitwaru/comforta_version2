/*
				   File: type_SdtWWPContext
			Description: WWPContext
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

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlRoot(ElementName="WWPContext")]
	[XmlType(TypeName="WWPContext" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWPContext : GxUserType
	{
		public SdtWWPContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPContext_Userid = "";

			gxTv_SdtWWPContext_Username = "";

		}

		public SdtWWPContext(IGxContext context)
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
			AddObjectProperty("UserId", gxTpr_Userid, false);


			AddObjectProperty("UserName", gxTpr_Username, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UserId")]
		[XmlElement(ElementName="UserId")]
		public string gxTpr_Userid
		{
			get {
				return gxTv_SdtWWPContext_Userid; 
			}
			set {
				gxTv_SdtWWPContext_Userid = value;
				SetDirty("Userid");
			}
		}




		[SoapElement(ElementName="UserName")]
		[XmlElement(ElementName="UserName")]
		public string gxTpr_Username
		{
			get {
				return gxTv_SdtWWPContext_Username; 
			}
			set {
				gxTv_SdtWWPContext_Username = value;
				SetDirty("Username");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtWWPContext_Organisationid; 
			}
			set {
				gxTv_SdtWWPContext_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtWWPContext_Locationid; 
			}
			set {
				gxTv_SdtWWPContext_Locationid = value;
				SetDirty("Locationid");
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
			gxTv_SdtWWPContext_Userid = "";
			gxTv_SdtWWPContext_Username = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPContext_Userid;
		 

		protected string gxTv_SdtWWPContext_Username;
		 

		protected Guid gxTv_SdtWWPContext_Organisationid;
		 

		protected Guid gxTv_SdtWWPContext_Locationid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPContext", Namespace="Comforta_version2")]
	public class SdtWWPContext_RESTInterface : GxGenericCollectionItem<SdtWWPContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPContext_RESTInterface( ) : base()
		{	
		}

		public SdtWWPContext_RESTInterface( SdtWWPContext psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="UserId", Order=0)]
		public  string gxTpr_Userid
		{
			get { 
				return sdt.gxTpr_Userid;

			}
			set { 
				 sdt.gxTpr_Userid = value;
			}
		}

		[DataMember(Name="UserName", Order=1)]
		public  string gxTpr_Username
		{
			get { 
				return sdt.gxTpr_Username;

			}
			set { 
				 sdt.gxTpr_Username = value;
			}
		}

		[DataMember(Name="OrganisationId", Order=2)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="LocationId", Order=3)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}


		#endregion

		public SdtWWPContext sdt
		{
			get { 
				return (SdtWWPContext)Sdt;
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
				sdt = new SdtWWPContext() ;
			}
		}
	}
	#endregion
}