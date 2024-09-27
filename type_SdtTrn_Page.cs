using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Trn_Page" )]
   [XmlType(TypeName =  "Trn_Page" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Page : GxSilentTrnSdt
   {
      public SdtTrn_Page( )
      {
      }

      public SdtTrn_Page( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( Guid AV310Trn_PageId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV310Trn_PageId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"Trn_PageId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Page");
         metadata.Set("BT", "Trn_Page");
         metadata.Set("PK", "[ \"Trn_PageId\" ]");
         metadata.Set("PKAssigned", "[ \"Trn_PageId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Trn_pageid_Z");
         state.Add("gxTpr_Trn_pagename_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Page sdt;
         sdt = (SdtTrn_Page)(source);
         gxTv_SdtTrn_Page_Trn_pageid = sdt.gxTv_SdtTrn_Page_Trn_pageid ;
         gxTv_SdtTrn_Page_Trn_pagename = sdt.gxTv_SdtTrn_Page_Trn_pagename ;
         gxTv_SdtTrn_Page_Mode = sdt.gxTv_SdtTrn_Page_Mode ;
         gxTv_SdtTrn_Page_Initialized = sdt.gxTv_SdtTrn_Page_Initialized ;
         gxTv_SdtTrn_Page_Trn_pageid_Z = sdt.gxTv_SdtTrn_Page_Trn_pageid_Z ;
         gxTv_SdtTrn_Page_Trn_pagename_Z = sdt.gxTv_SdtTrn_Page_Trn_pagename_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("Trn_PageId", gxTv_SdtTrn_Page_Trn_pageid, false, includeNonInitialized);
         AddObjectProperty("Trn_PageName", gxTv_SdtTrn_Page_Trn_pagename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Page_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Page_Initialized, false, includeNonInitialized);
            AddObjectProperty("Trn_PageId_Z", gxTv_SdtTrn_Page_Trn_pageid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_PageName_Z", gxTv_SdtTrn_Page_Trn_pagename_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Page sdt )
      {
         if ( sdt.IsDirty("Trn_PageId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Trn_pageid = sdt.gxTv_SdtTrn_Page_Trn_pageid ;
         }
         if ( sdt.IsDirty("Trn_PageName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Trn_pagename = sdt.gxTv_SdtTrn_Page_Trn_pagename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "Trn_PageId" )]
      [  XmlElement( ElementName = "Trn_PageId"   )]
      public Guid gxTpr_Trn_pageid
      {
         get {
            return gxTv_SdtTrn_Page_Trn_pageid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Page_Trn_pageid != value )
            {
               gxTv_SdtTrn_Page_Mode = "INS";
               this.gxTv_SdtTrn_Page_Trn_pageid_Z_SetNull( );
               this.gxTv_SdtTrn_Page_Trn_pagename_Z_SetNull( );
            }
            gxTv_SdtTrn_Page_Trn_pageid = value;
            SetDirty("Trn_pageid");
         }

      }

      [  SoapElement( ElementName = "Trn_PageName" )]
      [  XmlElement( ElementName = "Trn_PageName"   )]
      public string gxTpr_Trn_pagename
      {
         get {
            return gxTv_SdtTrn_Page_Trn_pagename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Trn_pagename = value;
            SetDirty("Trn_pagename");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Page_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Page_Mode_SetNull( )
      {
         gxTv_SdtTrn_Page_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Page_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Page_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Page_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_PageId_Z" )]
      [  XmlElement( ElementName = "Trn_PageId_Z"   )]
      public Guid gxTpr_Trn_pageid_Z
      {
         get {
            return gxTv_SdtTrn_Page_Trn_pageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Trn_pageid_Z = value;
            SetDirty("Trn_pageid_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Trn_pageid_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Trn_pageid_Z = Guid.Empty;
         SetDirty("Trn_pageid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Trn_pageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_PageName_Z" )]
      [  XmlElement( ElementName = "Trn_PageName_Z"   )]
      public string gxTpr_Trn_pagename_Z
      {
         get {
            return gxTv_SdtTrn_Page_Trn_pagename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Page_Trn_pagename_Z = value;
            SetDirty("Trn_pagename_Z");
         }

      }

      public void gxTv_SdtTrn_Page_Trn_pagename_Z_SetNull( )
      {
         gxTv_SdtTrn_Page_Trn_pagename_Z = "";
         SetDirty("Trn_pagename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Page_Trn_pagename_Z_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         gxTv_SdtTrn_Page_Trn_pageid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Page_Trn_pagename = "";
         gxTv_SdtTrn_Page_Mode = "";
         gxTv_SdtTrn_Page_Trn_pageid_Z = Guid.Empty;
         gxTv_SdtTrn_Page_Trn_pagename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_page", "GeneXus.Programs.trn_page_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_Page_Initialized ;
      private string gxTv_SdtTrn_Page_Mode ;
      private string gxTv_SdtTrn_Page_Trn_pagename ;
      private string gxTv_SdtTrn_Page_Trn_pagename_Z ;
      private Guid gxTv_SdtTrn_Page_Trn_pageid ;
      private Guid gxTv_SdtTrn_Page_Trn_pageid_Z ;
   }

   [DataContract(Name = @"Trn_Page", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Page_RESTInterface : GxGenericCollectionItem<SdtTrn_Page>
   {
      public SdtTrn_Page_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Page_RESTInterface( SdtTrn_Page psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_PageId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Trn_pageid
      {
         get {
            return sdt.gxTpr_Trn_pageid ;
         }

         set {
            sdt.gxTpr_Trn_pageid = value;
         }

      }

      [DataMember( Name = "Trn_PageName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Trn_pagename
      {
         get {
            return sdt.gxTpr_Trn_pagename ;
         }

         set {
            sdt.gxTpr_Trn_pagename = value;
         }

      }

      public SdtTrn_Page sdt
      {
         get {
            return (SdtTrn_Page)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrn_Page() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Trn_Page", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Page_RESTLInterface : GxGenericCollectionItem<SdtTrn_Page>
   {
      public SdtTrn_Page_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Page_RESTLInterface( SdtTrn_Page psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_PageName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Trn_pagename
      {
         get {
            return sdt.gxTpr_Trn_pagename ;
         }

         set {
            sdt.gxTpr_Trn_pagename = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_Page sdt
      {
         get {
            return (SdtTrn_Page)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrn_Page() ;
         }
      }

   }

}
