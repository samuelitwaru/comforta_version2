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
   [XmlRoot(ElementName = "Trn_Theme" )]
   [XmlType(TypeName =  "Trn_Theme" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Theme : GxSilentTrnSdt
   {
      public SdtTrn_Theme( )
      {
      }

      public SdtTrn_Theme( IGxContext context )
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

      public void Load( Guid AV247Trn_ThemeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV247Trn_ThemeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"Trn_ThemeId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Theme");
         metadata.Set("BT", "Trn_Theme");
         metadata.Set("PK", "[ \"Trn_ThemeId\" ]");
         metadata.Set("PKAssigned", "[ \"Trn_ThemeId\" ]");
         metadata.Set("Levels", "[ \"Color\",\"Icon\" ]");
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
         state.Add("gxTpr_Trn_themeid_Z");
         state.Add("gxTpr_Trn_themename_Z");
         state.Add("gxTpr_Trn_themefontfamily_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Theme sdt;
         sdt = (SdtTrn_Theme)(source);
         gxTv_SdtTrn_Theme_Trn_themeid = sdt.gxTv_SdtTrn_Theme_Trn_themeid ;
         gxTv_SdtTrn_Theme_Trn_themename = sdt.gxTv_SdtTrn_Theme_Trn_themename ;
         gxTv_SdtTrn_Theme_Trn_themefontfamily = sdt.gxTv_SdtTrn_Theme_Trn_themefontfamily ;
         gxTv_SdtTrn_Theme_Icon = sdt.gxTv_SdtTrn_Theme_Icon ;
         gxTv_SdtTrn_Theme_Color = sdt.gxTv_SdtTrn_Theme_Color ;
         gxTv_SdtTrn_Theme_Mode = sdt.gxTv_SdtTrn_Theme_Mode ;
         gxTv_SdtTrn_Theme_Initialized = sdt.gxTv_SdtTrn_Theme_Initialized ;
         gxTv_SdtTrn_Theme_Trn_themeid_Z = sdt.gxTv_SdtTrn_Theme_Trn_themeid_Z ;
         gxTv_SdtTrn_Theme_Trn_themename_Z = sdt.gxTv_SdtTrn_Theme_Trn_themename_Z ;
         gxTv_SdtTrn_Theme_Trn_themefontfamily_Z = sdt.gxTv_SdtTrn_Theme_Trn_themefontfamily_Z ;
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
         AddObjectProperty("Trn_ThemeId", gxTv_SdtTrn_Theme_Trn_themeid, false, includeNonInitialized);
         AddObjectProperty("Trn_ThemeName", gxTv_SdtTrn_Theme_Trn_themename, false, includeNonInitialized);
         AddObjectProperty("Trn_ThemeFontFamily", gxTv_SdtTrn_Theme_Trn_themefontfamily, false, includeNonInitialized);
         if ( gxTv_SdtTrn_Theme_Icon != null )
         {
            AddObjectProperty("Icon", gxTv_SdtTrn_Theme_Icon, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtTrn_Theme_Color != null )
         {
            AddObjectProperty("Color", gxTv_SdtTrn_Theme_Color, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Theme_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Theme_Initialized, false, includeNonInitialized);
            AddObjectProperty("Trn_ThemeId_Z", gxTv_SdtTrn_Theme_Trn_themeid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_ThemeName_Z", gxTv_SdtTrn_Theme_Trn_themename_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_ThemeFontFamily_Z", gxTv_SdtTrn_Theme_Trn_themefontfamily_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Theme sdt )
      {
         if ( sdt.IsDirty("Trn_ThemeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Trn_themeid = sdt.gxTv_SdtTrn_Theme_Trn_themeid ;
         }
         if ( sdt.IsDirty("Trn_ThemeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Trn_themename = sdt.gxTv_SdtTrn_Theme_Trn_themename ;
         }
         if ( sdt.IsDirty("Trn_ThemeFontFamily") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Trn_themefontfamily = sdt.gxTv_SdtTrn_Theme_Trn_themefontfamily ;
         }
         if ( gxTv_SdtTrn_Theme_Icon != null )
         {
            GXBCLevelCollection<SdtTrn_Theme_Icon> newCollectionIcon = sdt.gxTpr_Icon;
            SdtTrn_Theme_Icon currItemIcon;
            SdtTrn_Theme_Icon newItemIcon;
            short idx = 1;
            while ( idx <= newCollectionIcon.Count )
            {
               newItemIcon = ((SdtTrn_Theme_Icon)newCollectionIcon.Item(idx));
               currItemIcon = gxTv_SdtTrn_Theme_Icon.GetByKey(newItemIcon.gxTpr_Iconid);
               if ( StringUtil.StrCmp(currItemIcon.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemIcon.UpdateDirties(newItemIcon);
                  if ( StringUtil.StrCmp(newItemIcon.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemIcon.gxTpr_Mode = "DLT";
                  }
                  currItemIcon.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtTrn_Theme_Icon.Add(newItemIcon, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtTrn_Theme_Color != null )
         {
            GXBCLevelCollection<SdtTrn_Theme_Color> newCollectionColor = sdt.gxTpr_Color;
            SdtTrn_Theme_Color currItemColor;
            SdtTrn_Theme_Color newItemColor;
            short idx = 1;
            while ( idx <= newCollectionColor.Count )
            {
               newItemColor = ((SdtTrn_Theme_Color)newCollectionColor.Item(idx));
               currItemColor = gxTv_SdtTrn_Theme_Color.GetByKey(newItemColor.gxTpr_Colorid);
               if ( StringUtil.StrCmp(currItemColor.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemColor.UpdateDirties(newItemColor);
                  if ( StringUtil.StrCmp(newItemColor.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemColor.gxTpr_Mode = "DLT";
                  }
                  currItemColor.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtTrn_Theme_Color.Add(newItemColor, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "Trn_ThemeId" )]
      [  XmlElement( ElementName = "Trn_ThemeId"   )]
      public Guid gxTpr_Trn_themeid
      {
         get {
            return gxTv_SdtTrn_Theme_Trn_themeid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Theme_Trn_themeid != value )
            {
               gxTv_SdtTrn_Theme_Mode = "INS";
               this.gxTv_SdtTrn_Theme_Trn_themeid_Z_SetNull( );
               this.gxTv_SdtTrn_Theme_Trn_themename_Z_SetNull( );
               this.gxTv_SdtTrn_Theme_Trn_themefontfamily_Z_SetNull( );
               if ( gxTv_SdtTrn_Theme_Icon != null )
               {
                  GXBCLevelCollection<SdtTrn_Theme_Icon> collectionIcon = gxTv_SdtTrn_Theme_Icon;
                  SdtTrn_Theme_Icon currItemIcon;
                  short idx = 1;
                  while ( idx <= collectionIcon.Count )
                  {
                     currItemIcon = ((SdtTrn_Theme_Icon)collectionIcon.Item(idx));
                     currItemIcon.gxTpr_Mode = "INS";
                     currItemIcon.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtTrn_Theme_Color != null )
               {
                  GXBCLevelCollection<SdtTrn_Theme_Color> collectionColor = gxTv_SdtTrn_Theme_Color;
                  SdtTrn_Theme_Color currItemColor;
                  short idx = 1;
                  while ( idx <= collectionColor.Count )
                  {
                     currItemColor = ((SdtTrn_Theme_Color)collectionColor.Item(idx));
                     currItemColor.gxTpr_Mode = "INS";
                     currItemColor.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtTrn_Theme_Trn_themeid = value;
            SetDirty("Trn_themeid");
         }

      }

      [  SoapElement( ElementName = "Trn_ThemeName" )]
      [  XmlElement( ElementName = "Trn_ThemeName"   )]
      public string gxTpr_Trn_themename
      {
         get {
            return gxTv_SdtTrn_Theme_Trn_themename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Trn_themename = value;
            SetDirty("Trn_themename");
         }

      }

      [  SoapElement( ElementName = "Trn_ThemeFontFamily" )]
      [  XmlElement( ElementName = "Trn_ThemeFontFamily"   )]
      public string gxTpr_Trn_themefontfamily
      {
         get {
            return gxTv_SdtTrn_Theme_Trn_themefontfamily ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Trn_themefontfamily = value;
            SetDirty("Trn_themefontfamily");
         }

      }

      [  SoapElement( ElementName = "Icon" )]
      [  XmlArray( ElementName = "Icon"  )]
      [  XmlArrayItemAttribute( ElementName= "Trn_Theme.Icon"  , IsNullable=false)]
      public GXBCLevelCollection<SdtTrn_Theme_Icon> gxTpr_Icon_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtTrn_Theme_Icon == null )
            {
               gxTv_SdtTrn_Theme_Icon = new GXBCLevelCollection<SdtTrn_Theme_Icon>( context, "Trn_Theme.Icon", "Comforta_version2");
            }
            return gxTv_SdtTrn_Theme_Icon ;
         }

         set {
            if ( gxTv_SdtTrn_Theme_Icon == null )
            {
               gxTv_SdtTrn_Theme_Icon = new GXBCLevelCollection<SdtTrn_Theme_Icon>( context, "Trn_Theme.Icon", "Comforta_version2");
            }
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtTrn_Theme_Icon> gxTpr_Icon
      {
         get {
            if ( gxTv_SdtTrn_Theme_Icon == null )
            {
               gxTv_SdtTrn_Theme_Icon = new GXBCLevelCollection<SdtTrn_Theme_Icon>( context, "Trn_Theme.Icon", "Comforta_version2");
            }
            sdtIsNull = 0;
            return gxTv_SdtTrn_Theme_Icon ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Icon = value;
            SetDirty("Icon");
         }

      }

      public void gxTv_SdtTrn_Theme_Icon_SetNull( )
      {
         gxTv_SdtTrn_Theme_Icon = null;
         SetDirty("Icon");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Icon_IsNull( )
      {
         if ( gxTv_SdtTrn_Theme_Icon == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Color" )]
      [  XmlArray( ElementName = "Color"  )]
      [  XmlArrayItemAttribute( ElementName= "Trn_Theme.Color"  , IsNullable=false)]
      public GXBCLevelCollection<SdtTrn_Theme_Color> gxTpr_Color_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtTrn_Theme_Color == null )
            {
               gxTv_SdtTrn_Theme_Color = new GXBCLevelCollection<SdtTrn_Theme_Color>( context, "Trn_Theme.Color", "Comforta_version2");
            }
            return gxTv_SdtTrn_Theme_Color ;
         }

         set {
            if ( gxTv_SdtTrn_Theme_Color == null )
            {
               gxTv_SdtTrn_Theme_Color = new GXBCLevelCollection<SdtTrn_Theme_Color>( context, "Trn_Theme.Color", "Comforta_version2");
            }
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtTrn_Theme_Color> gxTpr_Color
      {
         get {
            if ( gxTv_SdtTrn_Theme_Color == null )
            {
               gxTv_SdtTrn_Theme_Color = new GXBCLevelCollection<SdtTrn_Theme_Color>( context, "Trn_Theme.Color", "Comforta_version2");
            }
            sdtIsNull = 0;
            return gxTv_SdtTrn_Theme_Color ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Color = value;
            SetDirty("Color");
         }

      }

      public void gxTv_SdtTrn_Theme_Color_SetNull( )
      {
         gxTv_SdtTrn_Theme_Color = null;
         SetDirty("Color");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Color_IsNull( )
      {
         if ( gxTv_SdtTrn_Theme_Color == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Theme_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Theme_Mode_SetNull( )
      {
         gxTv_SdtTrn_Theme_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Theme_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Theme_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Theme_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_ThemeId_Z" )]
      [  XmlElement( ElementName = "Trn_ThemeId_Z"   )]
      public Guid gxTpr_Trn_themeid_Z
      {
         get {
            return gxTv_SdtTrn_Theme_Trn_themeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Trn_themeid_Z = value;
            SetDirty("Trn_themeid_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_Trn_themeid_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_Trn_themeid_Z = Guid.Empty;
         SetDirty("Trn_themeid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Trn_themeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_ThemeName_Z" )]
      [  XmlElement( ElementName = "Trn_ThemeName_Z"   )]
      public string gxTpr_Trn_themename_Z
      {
         get {
            return gxTv_SdtTrn_Theme_Trn_themename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Trn_themename_Z = value;
            SetDirty("Trn_themename_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_Trn_themename_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_Trn_themename_Z = "";
         SetDirty("Trn_themename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Trn_themename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_ThemeFontFamily_Z" )]
      [  XmlElement( ElementName = "Trn_ThemeFontFamily_Z"   )]
      public string gxTpr_Trn_themefontfamily_Z
      {
         get {
            return gxTv_SdtTrn_Theme_Trn_themefontfamily_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Theme_Trn_themefontfamily_Z = value;
            SetDirty("Trn_themefontfamily_Z");
         }

      }

      public void gxTv_SdtTrn_Theme_Trn_themefontfamily_Z_SetNull( )
      {
         gxTv_SdtTrn_Theme_Trn_themefontfamily_Z = "";
         SetDirty("Trn_themefontfamily_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Theme_Trn_themefontfamily_Z_IsNull( )
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
         gxTv_SdtTrn_Theme_Trn_themeid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Theme_Trn_themename = "";
         gxTv_SdtTrn_Theme_Trn_themefontfamily = "";
         gxTv_SdtTrn_Theme_Mode = "";
         gxTv_SdtTrn_Theme_Trn_themeid_Z = Guid.Empty;
         gxTv_SdtTrn_Theme_Trn_themename_Z = "";
         gxTv_SdtTrn_Theme_Trn_themefontfamily_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_theme", "GeneXus.Programs.trn_theme_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Theme_Initialized ;
      private string gxTv_SdtTrn_Theme_Mode ;
      private string gxTv_SdtTrn_Theme_Trn_themename ;
      private string gxTv_SdtTrn_Theme_Trn_themefontfamily ;
      private string gxTv_SdtTrn_Theme_Trn_themename_Z ;
      private string gxTv_SdtTrn_Theme_Trn_themefontfamily_Z ;
      private Guid gxTv_SdtTrn_Theme_Trn_themeid ;
      private Guid gxTv_SdtTrn_Theme_Trn_themeid_Z ;
      private GXBCLevelCollection<SdtTrn_Theme_Icon> gxTv_SdtTrn_Theme_Icon=null ;
      private GXBCLevelCollection<SdtTrn_Theme_Color> gxTv_SdtTrn_Theme_Color=null ;
   }

   [DataContract(Name = @"Trn_Theme", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Theme_RESTInterface : GxGenericCollectionItem<SdtTrn_Theme>
   {
      public SdtTrn_Theme_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Theme_RESTInterface( SdtTrn_Theme psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_ThemeId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Trn_themeid
      {
         get {
            return sdt.gxTpr_Trn_themeid ;
         }

         set {
            sdt.gxTpr_Trn_themeid = value;
         }

      }

      [DataMember( Name = "Trn_ThemeName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Trn_themename
      {
         get {
            return sdt.gxTpr_Trn_themename ;
         }

         set {
            sdt.gxTpr_Trn_themename = value;
         }

      }

      [DataMember( Name = "Trn_ThemeFontFamily" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Trn_themefontfamily
      {
         get {
            return sdt.gxTpr_Trn_themefontfamily ;
         }

         set {
            sdt.gxTpr_Trn_themefontfamily = value;
         }

      }

      [DataMember( Name = "Icon" , Order = 3 )]
      public GxGenericCollection<SdtTrn_Theme_Icon_RESTInterface> gxTpr_Icon
      {
         get {
            return new GxGenericCollection<SdtTrn_Theme_Icon_RESTInterface>(sdt.gxTpr_Icon) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Icon);
         }

      }

      [DataMember( Name = "Color" , Order = 4 )]
      public GxGenericCollection<SdtTrn_Theme_Color_RESTInterface> gxTpr_Color
      {
         get {
            return new GxGenericCollection<SdtTrn_Theme_Color_RESTInterface>(sdt.gxTpr_Color) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Color);
         }

      }

      public SdtTrn_Theme sdt
      {
         get {
            return (SdtTrn_Theme)Sdt ;
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
            sdt = new SdtTrn_Theme() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"Trn_Theme", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Theme_RESTLInterface : GxGenericCollectionItem<SdtTrn_Theme>
   {
      public SdtTrn_Theme_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Theme_RESTLInterface( SdtTrn_Theme psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_ThemeName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Trn_themename
      {
         get {
            return sdt.gxTpr_Trn_themename ;
         }

         set {
            sdt.gxTpr_Trn_themename = value;
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

      public SdtTrn_Theme sdt
      {
         get {
            return (SdtTrn_Theme)Sdt ;
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
            sdt = new SdtTrn_Theme() ;
         }
      }

   }

}
