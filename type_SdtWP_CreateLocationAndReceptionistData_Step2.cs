/*
				   File: type_SdtWP_CreateLocationAndReceptionistData_Step2
			Description: Step2
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
	[XmlRoot(ElementName="WP_CreateLocationAndReceptionistData.Step2")]
	[XmlType(TypeName="WP_CreateLocationAndReceptionistData.Step2" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWP_CreateLocationAndReceptionistData_Step2 : GxUserType
	{
		public SdtWP_CreateLocationAndReceptionistData_Step2( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgivenname = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistlastname = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistemail = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphone = "";

		}

		public SdtWP_CreateLocationAndReceptionistData_Step2(IGxContext context)
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
			AddObjectProperty("ReceptionistId", gxTpr_Receptionistid, false);


			AddObjectProperty("ReceptionistGivenName", gxTpr_Receptionistgivenname, false);


			AddObjectProperty("ReceptionistLastName", gxTpr_Receptionistlastname, false);


			AddObjectProperty("ReceptionistEmail", gxTpr_Receptionistemail, false);


			AddObjectProperty("ReceptionistPhone", gxTpr_Receptionistphone, false);

			if (gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists != null)
			{
				AddObjectProperty("SDT_Receptionists", gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ReceptionistId")]
		[XmlElement(ElementName="ReceptionistId")]
		public Guid gxTpr_Receptionistid
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistid; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistid = value;
				SetDirty("Receptionistid");
			}
		}




		[SoapElement(ElementName="ReceptionistGivenName")]
		[XmlElement(ElementName="ReceptionistGivenName")]
		public string gxTpr_Receptionistgivenname
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgivenname; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgivenname = value;
				SetDirty("Receptionistgivenname");
			}
		}




		[SoapElement(ElementName="ReceptionistLastName")]
		[XmlElement(ElementName="ReceptionistLastName")]
		public string gxTpr_Receptionistlastname
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistlastname; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistlastname = value;
				SetDirty("Receptionistlastname");
			}
		}




		[SoapElement(ElementName="ReceptionistEmail")]
		[XmlElement(ElementName="ReceptionistEmail")]
		public string gxTpr_Receptionistemail
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistemail; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistemail = value;
				SetDirty("Receptionistemail");
			}
		}




		[SoapElement(ElementName="ReceptionistPhone")]
		[XmlElement(ElementName="ReceptionistPhone")]
		public string gxTpr_Receptionistphone
		{
			get {
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphone; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphone = value;
				SetDirty("Receptionistphone");
			}
		}




		[SoapElement(ElementName="SDT_Receptionists" )]
		[XmlArray(ElementName="SDT_Receptionists"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Receptionist> gxTpr_Sdt_receptionists_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists == null )
				{
					gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = new GXBaseCollection<GeneXus.Programs.SdtSDT_Receptionist>( context, "SDT_Receptionist", "");
				}
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists;
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N = false;
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Receptionist> gxTpr_Sdt_receptionists
		{
			get {
				if ( gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists == null )
				{
					gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = new GXBaseCollection<GeneXus.Programs.SdtSDT_Receptionist>( context, "SDT_Receptionist", "");
				}
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N = false;
				return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists ;
			}
			set {
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N = false;
				gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = value;
				SetDirty("Sdt_receptionists");
			}
		}

		public void gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_SetNull()
		{
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N = true;
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = null;
		}

		public bool gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_IsNull()
		{
			return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists == null;
		}
		public bool ShouldSerializegxTpr_Sdt_receptionists_GXBaseCollection_Json()
		{
			return gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists != null && gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists.Count > 0;

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
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgivenname = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistlastname = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistemail = "";
			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphone = "";

			gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistid;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistgivenname;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistlastname;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistemail;
		 

		protected string gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Receptionistphone;
		 
		protected bool gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_Receptionist> gxTv_SdtWP_CreateLocationAndReceptionistData_Step2_Sdt_receptionists = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateLocationAndReceptionistData.Step2", Namespace="Comforta_version2")]
	public class SdtWP_CreateLocationAndReceptionistData_Step2_RESTInterface : GxGenericCollectionItem<SdtWP_CreateLocationAndReceptionistData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateLocationAndReceptionistData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateLocationAndReceptionistData_Step2_RESTInterface( SdtWP_CreateLocationAndReceptionistData_Step2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ReceptionistId", Order=0)]
		public Guid gxTpr_Receptionistid
		{
			get { 
				return sdt.gxTpr_Receptionistid;

			}
			set { 
				sdt.gxTpr_Receptionistid = value;
			}
		}

		[DataMember(Name="ReceptionistGivenName", Order=1)]
		public  string gxTpr_Receptionistgivenname
		{
			get { 
				return sdt.gxTpr_Receptionistgivenname;

			}
			set { 
				 sdt.gxTpr_Receptionistgivenname = value;
			}
		}

		[DataMember(Name="ReceptionistLastName", Order=2)]
		public  string gxTpr_Receptionistlastname
		{
			get { 
				return sdt.gxTpr_Receptionistlastname;

			}
			set { 
				 sdt.gxTpr_Receptionistlastname = value;
			}
		}

		[DataMember(Name="ReceptionistEmail", Order=3)]
		public  string gxTpr_Receptionistemail
		{
			get { 
				return sdt.gxTpr_Receptionistemail;

			}
			set { 
				 sdt.gxTpr_Receptionistemail = value;
			}
		}

		[DataMember(Name="ReceptionistPhone", Order=4)]
		public  string gxTpr_Receptionistphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Receptionistphone);

			}
			set { 
				 sdt.gxTpr_Receptionistphone = value;
			}
		}

		[DataMember(Name="SDT_Receptionists", Order=5, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_Receptionist_RESTInterface> gxTpr_Sdt_receptionists
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Sdt_receptionists_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_Receptionist_RESTInterface>(sdt.gxTpr_Sdt_receptionists);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Sdt_receptionists);
			}
		}


		#endregion

		public SdtWP_CreateLocationAndReceptionistData_Step2 sdt
		{
			get { 
				return (SdtWP_CreateLocationAndReceptionistData_Step2)Sdt;
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
				sdt = new SdtWP_CreateLocationAndReceptionistData_Step2() ;
			}
		}
	}
	#endregion
}