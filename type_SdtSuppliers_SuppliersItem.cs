/*
				   File: type_SdtSuppliers_SuppliersItem
			Description: Suppliers
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
	[XmlRoot(ElementName="SuppliersItem")]
	[XmlType(TypeName="SuppliersItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSuppliers_SuppliersItem : GxUserType
	{
		public SdtSuppliers_SuppliersItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSuppliers_SuppliersItem_Suppliersname = "";

		}

		public SdtSuppliers_SuppliersItem(IGxContext context)
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
			AddObjectProperty("SupplierAgbId", gxTpr_Supplieragbid, false);


			AddObjectProperty("SuppliersName", gxTpr_Suppliersname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SupplierAgbId")]
		[XmlElement(ElementName="SupplierAgbId")]
		public Guid gxTpr_Supplieragbid
		{
			get {
				return gxTv_SdtSuppliers_SuppliersItem_Supplieragbid; 
			}
			set {
				gxTv_SdtSuppliers_SuppliersItem_Supplieragbid = value;
				SetDirty("Supplieragbid");
			}
		}




		[SoapElement(ElementName="SuppliersName")]
		[XmlElement(ElementName="SuppliersName")]
		public string gxTpr_Suppliersname
		{
			get {
				return gxTv_SdtSuppliers_SuppliersItem_Suppliersname; 
			}
			set {
				gxTv_SdtSuppliers_SuppliersItem_Suppliersname = value;
				SetDirty("Suppliersname");
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
			gxTv_SdtSuppliers_SuppliersItem_Suppliersname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSuppliers_SuppliersItem_Supplieragbid;
		 

		protected string gxTv_SdtSuppliers_SuppliersItem_Suppliersname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SuppliersItem", Namespace="Comforta_version2")]
	public class SdtSuppliers_SuppliersItem_RESTInterface : GxGenericCollectionItem<SdtSuppliers_SuppliersItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSuppliers_SuppliersItem_RESTInterface( ) : base()
		{	
		}

		public SdtSuppliers_SuppliersItem_RESTInterface( SdtSuppliers_SuppliersItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SupplierAgbId", Order=0)]
		public Guid gxTpr_Supplieragbid
		{
			get { 
				return sdt.gxTpr_Supplieragbid;

			}
			set { 
				sdt.gxTpr_Supplieragbid = value;
			}
		}

		[DataMember(Name="SuppliersName", Order=1)]
		public  string gxTpr_Suppliersname
		{
			get { 
				return sdt.gxTpr_Suppliersname;

			}
			set { 
				 sdt.gxTpr_Suppliersname = value;
			}
		}


		#endregion

		public SdtSuppliers_SuppliersItem sdt
		{
			get { 
				return (SdtSuppliers_SuppliersItem)Sdt;
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
				sdt = new SdtSuppliers_SuppliersItem() ;
			}
		}
	}
	#endregion
}