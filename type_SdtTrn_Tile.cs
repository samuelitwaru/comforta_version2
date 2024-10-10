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
   [XmlRoot(ElementName = "Trn_Tile" )]
   [XmlType(TypeName =  "Trn_Tile" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_Tile : GxSilentTrnSdt
   {
      public SdtTrn_Tile( )
      {
      }

      public SdtTrn_Tile( IGxContext context )
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

      public void Load( Guid AV264Trn_TileId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV264Trn_TileId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"Trn_TileId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Tile");
         metadata.Set("BT", "Trn_Tile");
         metadata.Set("PK", "[ \"Trn_TileId\" ]");
         metadata.Set("PKAssigned", "[ \"Trn_TileId\" ]");
         metadata.Set("Levels", "[ \"Attribute\",\"ChildTile\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProductServiceId\",\"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Productserviceimage_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Trn_tileid_Z");
         state.Add("gxTpr_Trn_tilename_Z");
         state.Add("gxTpr_Trn_tilewidth_Z");
         state.Add("gxTpr_Trn_tilecolor_Z");
         state.Add("gxTpr_Trn_tilebgimageurl_Z");
         state.Add("gxTpr_Productserviceid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Productservicename_Z");
         state.Add("gxTpr_Productserviceimage_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Tile sdt;
         sdt = (SdtTrn_Tile)(source);
         gxTv_SdtTrn_Tile_Trn_tileid = sdt.gxTv_SdtTrn_Tile_Trn_tileid ;
         gxTv_SdtTrn_Tile_Trn_tilename = sdt.gxTv_SdtTrn_Tile_Trn_tilename ;
         gxTv_SdtTrn_Tile_Trn_tilewidth = sdt.gxTv_SdtTrn_Tile_Trn_tilewidth ;
         gxTv_SdtTrn_Tile_Trn_tilecolor = sdt.gxTv_SdtTrn_Tile_Trn_tilecolor ;
         gxTv_SdtTrn_Tile_Trn_tilebgimageurl = sdt.gxTv_SdtTrn_Tile_Trn_tilebgimageurl ;
         gxTv_SdtTrn_Tile_Productserviceid = sdt.gxTv_SdtTrn_Tile_Productserviceid ;
         gxTv_SdtTrn_Tile_Organisationid = sdt.gxTv_SdtTrn_Tile_Organisationid ;
         gxTv_SdtTrn_Tile_Locationid = sdt.gxTv_SdtTrn_Tile_Locationid ;
         gxTv_SdtTrn_Tile_Productservicename = sdt.gxTv_SdtTrn_Tile_Productservicename ;
         gxTv_SdtTrn_Tile_Productservicedescription = sdt.gxTv_SdtTrn_Tile_Productservicedescription ;
         gxTv_SdtTrn_Tile_Productserviceimage = sdt.gxTv_SdtTrn_Tile_Productserviceimage ;
         gxTv_SdtTrn_Tile_Productserviceimage_gxi = sdt.gxTv_SdtTrn_Tile_Productserviceimage_gxi ;
         gxTv_SdtTrn_Tile_Attribute = sdt.gxTv_SdtTrn_Tile_Attribute ;
         gxTv_SdtTrn_Tile_Childtile = sdt.gxTv_SdtTrn_Tile_Childtile ;
         gxTv_SdtTrn_Tile_Mode = sdt.gxTv_SdtTrn_Tile_Mode ;
         gxTv_SdtTrn_Tile_Initialized = sdt.gxTv_SdtTrn_Tile_Initialized ;
         gxTv_SdtTrn_Tile_Trn_tileid_Z = sdt.gxTv_SdtTrn_Tile_Trn_tileid_Z ;
         gxTv_SdtTrn_Tile_Trn_tilename_Z = sdt.gxTv_SdtTrn_Tile_Trn_tilename_Z ;
         gxTv_SdtTrn_Tile_Trn_tilewidth_Z = sdt.gxTv_SdtTrn_Tile_Trn_tilewidth_Z ;
         gxTv_SdtTrn_Tile_Trn_tilecolor_Z = sdt.gxTv_SdtTrn_Tile_Trn_tilecolor_Z ;
         gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z = sdt.gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z ;
         gxTv_SdtTrn_Tile_Productserviceid_Z = sdt.gxTv_SdtTrn_Tile_Productserviceid_Z ;
         gxTv_SdtTrn_Tile_Organisationid_Z = sdt.gxTv_SdtTrn_Tile_Organisationid_Z ;
         gxTv_SdtTrn_Tile_Locationid_Z = sdt.gxTv_SdtTrn_Tile_Locationid_Z ;
         gxTv_SdtTrn_Tile_Productservicename_Z = sdt.gxTv_SdtTrn_Tile_Productservicename_Z ;
         gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z = sdt.gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z ;
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
         AddObjectProperty("Trn_TileId", gxTv_SdtTrn_Tile_Trn_tileid, false, includeNonInitialized);
         AddObjectProperty("Trn_TileName", gxTv_SdtTrn_Tile_Trn_tilename, false, includeNonInitialized);
         AddObjectProperty("Trn_TileWidth", gxTv_SdtTrn_Tile_Trn_tilewidth, false, includeNonInitialized);
         AddObjectProperty("Trn_TileColor", gxTv_SdtTrn_Tile_Trn_tilecolor, false, includeNonInitialized);
         AddObjectProperty("Trn_TileBGImageUrl", gxTv_SdtTrn_Tile_Trn_tilebgimageurl, false, includeNonInitialized);
         AddObjectProperty("ProductServiceId", gxTv_SdtTrn_Tile_Productserviceid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Tile_Organisationid, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_Tile_Locationid, false, includeNonInitialized);
         AddObjectProperty("ProductServiceName", gxTv_SdtTrn_Tile_Productservicename, false, includeNonInitialized);
         AddObjectProperty("ProductServiceDescription", gxTv_SdtTrn_Tile_Productservicedescription, false, includeNonInitialized);
         AddObjectProperty("ProductServiceImage", gxTv_SdtTrn_Tile_Productserviceimage, false, includeNonInitialized);
         if ( gxTv_SdtTrn_Tile_Attribute != null )
         {
            AddObjectProperty("Attribute", gxTv_SdtTrn_Tile_Attribute, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtTrn_Tile_Childtile != null )
         {
            AddObjectProperty("ChildTile", gxTv_SdtTrn_Tile_Childtile, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("ProductServiceImage_GXI", gxTv_SdtTrn_Tile_Productserviceimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_Tile_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Tile_Initialized, false, includeNonInitialized);
            AddObjectProperty("Trn_TileId_Z", gxTv_SdtTrn_Tile_Trn_tileid_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_TileName_Z", gxTv_SdtTrn_Tile_Trn_tilename_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_TileWidth_Z", gxTv_SdtTrn_Tile_Trn_tilewidth_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_TileColor_Z", gxTv_SdtTrn_Tile_Trn_tilecolor_Z, false, includeNonInitialized);
            AddObjectProperty("Trn_TileBGImageUrl_Z", gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceId_Z", gxTv_SdtTrn_Tile_Productserviceid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Tile_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_Tile_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceName_Z", gxTv_SdtTrn_Tile_Productservicename_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceImage_GXI_Z", gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Tile sdt )
      {
         if ( sdt.IsDirty("Trn_TileId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tileid = sdt.gxTv_SdtTrn_Tile_Trn_tileid ;
         }
         if ( sdt.IsDirty("Trn_TileName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilename = sdt.gxTv_SdtTrn_Tile_Trn_tilename ;
         }
         if ( sdt.IsDirty("Trn_TileWidth") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilewidth = sdt.gxTv_SdtTrn_Tile_Trn_tilewidth ;
         }
         if ( sdt.IsDirty("Trn_TileColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilecolor = sdt.gxTv_SdtTrn_Tile_Trn_tilecolor ;
         }
         if ( sdt.IsDirty("Trn_TileBGImageUrl") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilebgimageurl = sdt.gxTv_SdtTrn_Tile_Trn_tilebgimageurl ;
         }
         if ( sdt.IsDirty("ProductServiceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceid = sdt.gxTv_SdtTrn_Tile_Productserviceid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Organisationid = sdt.gxTv_SdtTrn_Tile_Organisationid ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Locationid = sdt.gxTv_SdtTrn_Tile_Locationid ;
         }
         if ( sdt.IsDirty("ProductServiceName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productservicename = sdt.gxTv_SdtTrn_Tile_Productservicename ;
         }
         if ( sdt.IsDirty("ProductServiceDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productservicedescription = sdt.gxTv_SdtTrn_Tile_Productservicedescription ;
         }
         if ( sdt.IsDirty("ProductServiceImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceimage = sdt.gxTv_SdtTrn_Tile_Productserviceimage ;
         }
         if ( sdt.IsDirty("ProductServiceImage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceimage_gxi = sdt.gxTv_SdtTrn_Tile_Productserviceimage_gxi ;
         }
         if ( gxTv_SdtTrn_Tile_Attribute != null )
         {
            GXBCLevelCollection<SdtTrn_Tile_Attribute> newCollectionAttribute = sdt.gxTpr_Attribute;
            SdtTrn_Tile_Attribute currItemAttribute;
            SdtTrn_Tile_Attribute newItemAttribute;
            short idx = 1;
            while ( idx <= newCollectionAttribute.Count )
            {
               newItemAttribute = ((SdtTrn_Tile_Attribute)newCollectionAttribute.Item(idx));
               currItemAttribute = gxTv_SdtTrn_Tile_Attribute.GetByKey(newItemAttribute.gxTpr_Attributeid);
               if ( StringUtil.StrCmp(currItemAttribute.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemAttribute.UpdateDirties(newItemAttribute);
                  if ( StringUtil.StrCmp(newItemAttribute.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemAttribute.gxTpr_Mode = "DLT";
                  }
                  currItemAttribute.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtTrn_Tile_Attribute.Add(newItemAttribute, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtTrn_Tile_Childtile != null )
         {
            GXBCLevelCollection<SdtTrn_Tile_ChildTile> newCollectionChildtile = sdt.gxTpr_Childtile;
            SdtTrn_Tile_ChildTile currItemChildtile;
            SdtTrn_Tile_ChildTile newItemChildtile;
            short idx = 1;
            while ( idx <= newCollectionChildtile.Count )
            {
               newItemChildtile = ((SdtTrn_Tile_ChildTile)newCollectionChildtile.Item(idx));
               currItemChildtile = gxTv_SdtTrn_Tile_Childtile.GetByKey(newItemChildtile.gxTpr_Sg_tileid);
               if ( StringUtil.StrCmp(currItemChildtile.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemChildtile.UpdateDirties(newItemChildtile);
                  if ( StringUtil.StrCmp(newItemChildtile.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemChildtile.gxTpr_Mode = "DLT";
                  }
                  currItemChildtile.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtTrn_Tile_Childtile.Add(newItemChildtile, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "Trn_TileId" )]
      [  XmlElement( ElementName = "Trn_TileId"   )]
      public Guid gxTpr_Trn_tileid
      {
         get {
            return gxTv_SdtTrn_Tile_Trn_tileid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Tile_Trn_tileid != value )
            {
               gxTv_SdtTrn_Tile_Mode = "INS";
               this.gxTv_SdtTrn_Tile_Trn_tileid_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Trn_tilename_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Trn_tilewidth_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Trn_tilecolor_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Productserviceid_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Productservicename_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z_SetNull( );
               if ( gxTv_SdtTrn_Tile_Attribute != null )
               {
                  GXBCLevelCollection<SdtTrn_Tile_Attribute> collectionAttribute = gxTv_SdtTrn_Tile_Attribute;
                  SdtTrn_Tile_Attribute currItemAttribute;
                  short idx = 1;
                  while ( idx <= collectionAttribute.Count )
                  {
                     currItemAttribute = ((SdtTrn_Tile_Attribute)collectionAttribute.Item(idx));
                     currItemAttribute.gxTpr_Mode = "INS";
                     currItemAttribute.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtTrn_Tile_Childtile != null )
               {
                  GXBCLevelCollection<SdtTrn_Tile_ChildTile> collectionChildtile = gxTv_SdtTrn_Tile_Childtile;
                  SdtTrn_Tile_ChildTile currItemChildtile;
                  short idx = 1;
                  while ( idx <= collectionChildtile.Count )
                  {
                     currItemChildtile = ((SdtTrn_Tile_ChildTile)collectionChildtile.Item(idx));
                     currItemChildtile.gxTpr_Mode = "INS";
                     currItemChildtile.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtTrn_Tile_Trn_tileid = value;
            SetDirty("Trn_tileid");
         }

      }

      [  SoapElement( ElementName = "Trn_TileName" )]
      [  XmlElement( ElementName = "Trn_TileName"   )]
      public string gxTpr_Trn_tilename
      {
         get {
            return gxTv_SdtTrn_Tile_Trn_tilename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilename = value;
            SetDirty("Trn_tilename");
         }

      }

      [  SoapElement( ElementName = "Trn_TileWidth" )]
      [  XmlElement( ElementName = "Trn_TileWidth"   )]
      public short gxTpr_Trn_tilewidth
      {
         get {
            return gxTv_SdtTrn_Tile_Trn_tilewidth ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilewidth = value;
            SetDirty("Trn_tilewidth");
         }

      }

      [  SoapElement( ElementName = "Trn_TileColor" )]
      [  XmlElement( ElementName = "Trn_TileColor"   )]
      public string gxTpr_Trn_tilecolor
      {
         get {
            return gxTv_SdtTrn_Tile_Trn_tilecolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilecolor = value;
            SetDirty("Trn_tilecolor");
         }

      }

      [  SoapElement( ElementName = "Trn_TileBGImageUrl" )]
      [  XmlElement( ElementName = "Trn_TileBGImageUrl"   )]
      public string gxTpr_Trn_tilebgimageurl
      {
         get {
            return gxTv_SdtTrn_Tile_Trn_tilebgimageurl ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilebgimageurl = value;
            SetDirty("Trn_tilebgimageurl");
         }

      }

      [  SoapElement( ElementName = "ProductServiceId" )]
      [  XmlElement( ElementName = "ProductServiceId"   )]
      public Guid gxTpr_Productserviceid
      {
         get {
            return gxTv_SdtTrn_Tile_Productserviceid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceid = value;
            SetDirty("Productserviceid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Tile_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_Tile_Locationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "ProductServiceName" )]
      [  XmlElement( ElementName = "ProductServiceName"   )]
      public string gxTpr_Productservicename
      {
         get {
            return gxTv_SdtTrn_Tile_Productservicename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productservicename = value;
            SetDirty("Productservicename");
         }

      }

      [  SoapElement( ElementName = "ProductServiceDescription" )]
      [  XmlElement( ElementName = "ProductServiceDescription"   )]
      public string gxTpr_Productservicedescription
      {
         get {
            return gxTv_SdtTrn_Tile_Productservicedescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productservicedescription = value;
            SetDirty("Productservicedescription");
         }

      }

      [  SoapElement( ElementName = "ProductServiceImage" )]
      [  XmlElement( ElementName = "ProductServiceImage"   )]
      [GxUpload()]
      public string gxTpr_Productserviceimage
      {
         get {
            return gxTv_SdtTrn_Tile_Productserviceimage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceimage = value;
            SetDirty("Productserviceimage");
         }

      }

      [  SoapElement( ElementName = "ProductServiceImage_GXI" )]
      [  XmlElement( ElementName = "ProductServiceImage_GXI"   )]
      public string gxTpr_Productserviceimage_gxi
      {
         get {
            return gxTv_SdtTrn_Tile_Productserviceimage_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceimage_gxi = value;
            SetDirty("Productserviceimage_gxi");
         }

      }

      [  SoapElement( ElementName = "Attribute" )]
      [  XmlArray( ElementName = "Attribute"  )]
      [  XmlArrayItemAttribute( ElementName= "Trn_Tile.Attribute"  , IsNullable=false)]
      public GXBCLevelCollection<SdtTrn_Tile_Attribute> gxTpr_Attribute_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtTrn_Tile_Attribute == null )
            {
               gxTv_SdtTrn_Tile_Attribute = new GXBCLevelCollection<SdtTrn_Tile_Attribute>( context, "Trn_Tile.Attribute", "Comforta_version2");
            }
            return gxTv_SdtTrn_Tile_Attribute ;
         }

         set {
            if ( gxTv_SdtTrn_Tile_Attribute == null )
            {
               gxTv_SdtTrn_Tile_Attribute = new GXBCLevelCollection<SdtTrn_Tile_Attribute>( context, "Trn_Tile.Attribute", "Comforta_version2");
            }
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtTrn_Tile_Attribute> gxTpr_Attribute
      {
         get {
            if ( gxTv_SdtTrn_Tile_Attribute == null )
            {
               gxTv_SdtTrn_Tile_Attribute = new GXBCLevelCollection<SdtTrn_Tile_Attribute>( context, "Trn_Tile.Attribute", "Comforta_version2");
            }
            sdtIsNull = 0;
            return gxTv_SdtTrn_Tile_Attribute ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Attribute = value;
            SetDirty("Attribute");
         }

      }

      public void gxTv_SdtTrn_Tile_Attribute_SetNull( )
      {
         gxTv_SdtTrn_Tile_Attribute = null;
         SetDirty("Attribute");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Attribute_IsNull( )
      {
         if ( gxTv_SdtTrn_Tile_Attribute == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "ChildTile" )]
      [  XmlArray( ElementName = "ChildTile"  )]
      [  XmlArrayItemAttribute( ElementName= "Trn_Tile.ChildTile"  , IsNullable=false)]
      public GXBCLevelCollection<SdtTrn_Tile_ChildTile> gxTpr_Childtile_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtTrn_Tile_Childtile == null )
            {
               gxTv_SdtTrn_Tile_Childtile = new GXBCLevelCollection<SdtTrn_Tile_ChildTile>( context, "Trn_Tile.ChildTile", "Comforta_version2");
            }
            return gxTv_SdtTrn_Tile_Childtile ;
         }

         set {
            if ( gxTv_SdtTrn_Tile_Childtile == null )
            {
               gxTv_SdtTrn_Tile_Childtile = new GXBCLevelCollection<SdtTrn_Tile_ChildTile>( context, "Trn_Tile.ChildTile", "Comforta_version2");
            }
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Childtile = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtTrn_Tile_ChildTile> gxTpr_Childtile
      {
         get {
            if ( gxTv_SdtTrn_Tile_Childtile == null )
            {
               gxTv_SdtTrn_Tile_Childtile = new GXBCLevelCollection<SdtTrn_Tile_ChildTile>( context, "Trn_Tile.ChildTile", "Comforta_version2");
            }
            sdtIsNull = 0;
            return gxTv_SdtTrn_Tile_Childtile ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Childtile = value;
            SetDirty("Childtile");
         }

      }

      public void gxTv_SdtTrn_Tile_Childtile_SetNull( )
      {
         gxTv_SdtTrn_Tile_Childtile = null;
         SetDirty("Childtile");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Childtile_IsNull( )
      {
         if ( gxTv_SdtTrn_Tile_Childtile == null )
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
            return gxTv_SdtTrn_Tile_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Tile_Mode_SetNull( )
      {
         gxTv_SdtTrn_Tile_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Tile_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Tile_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Tile_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_TileId_Z" )]
      [  XmlElement( ElementName = "Trn_TileId_Z"   )]
      public Guid gxTpr_Trn_tileid_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Trn_tileid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tileid_Z = value;
            SetDirty("Trn_tileid_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Trn_tileid_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Trn_tileid_Z = Guid.Empty;
         SetDirty("Trn_tileid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Trn_tileid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_TileName_Z" )]
      [  XmlElement( ElementName = "Trn_TileName_Z"   )]
      public string gxTpr_Trn_tilename_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Trn_tilename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilename_Z = value;
            SetDirty("Trn_tilename_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Trn_tilename_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Trn_tilename_Z = "";
         SetDirty("Trn_tilename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Trn_tilename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_TileWidth_Z" )]
      [  XmlElement( ElementName = "Trn_TileWidth_Z"   )]
      public short gxTpr_Trn_tilewidth_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Trn_tilewidth_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilewidth_Z = value;
            SetDirty("Trn_tilewidth_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Trn_tilewidth_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Trn_tilewidth_Z = 0;
         SetDirty("Trn_tilewidth_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Trn_tilewidth_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_TileColor_Z" )]
      [  XmlElement( ElementName = "Trn_TileColor_Z"   )]
      public string gxTpr_Trn_tilecolor_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Trn_tilecolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilecolor_Z = value;
            SetDirty("Trn_tilecolor_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Trn_tilecolor_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Trn_tilecolor_Z = "";
         SetDirty("Trn_tilecolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Trn_tilecolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Trn_TileBGImageUrl_Z" )]
      [  XmlElement( ElementName = "Trn_TileBGImageUrl_Z"   )]
      public string gxTpr_Trn_tilebgimageurl_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z = value;
            SetDirty("Trn_tilebgimageurl_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z = "";
         SetDirty("Trn_tilebgimageurl_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceId_Z" )]
      [  XmlElement( ElementName = "ProductServiceId_Z"   )]
      public Guid gxTpr_Productserviceid_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Productserviceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceid_Z = value;
            SetDirty("Productserviceid_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Productserviceid_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Productserviceid_Z = Guid.Empty;
         SetDirty("Productserviceid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Productserviceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceName_Z" )]
      [  XmlElement( ElementName = "ProductServiceName_Z"   )]
      public string gxTpr_Productservicename_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Productservicename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productservicename_Z = value;
            SetDirty("Productservicename_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Productservicename_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Productservicename_Z = "";
         SetDirty("Productservicename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Productservicename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceImage_GXI_Z" )]
      [  XmlElement( ElementName = "ProductServiceImage_GXI_Z"   )]
      public string gxTpr_Productserviceimage_gxi_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z = value;
            SetDirty("Productserviceimage_gxi_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z = "";
         SetDirty("Productserviceimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z_IsNull( )
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
         gxTv_SdtTrn_Tile_Trn_tileid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Tile_Trn_tilename = "";
         gxTv_SdtTrn_Tile_Trn_tilecolor = "";
         gxTv_SdtTrn_Tile_Trn_tilebgimageurl = "";
         gxTv_SdtTrn_Tile_Productserviceid = Guid.Empty;
         gxTv_SdtTrn_Tile_Organisationid = Guid.Empty;
         gxTv_SdtTrn_Tile_Locationid = Guid.Empty;
         gxTv_SdtTrn_Tile_Productservicename = "";
         gxTv_SdtTrn_Tile_Productservicedescription = "";
         gxTv_SdtTrn_Tile_Productserviceimage = "";
         gxTv_SdtTrn_Tile_Productserviceimage_gxi = "";
         gxTv_SdtTrn_Tile_Mode = "";
         gxTv_SdtTrn_Tile_Trn_tileid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Trn_tilename_Z = "";
         gxTv_SdtTrn_Tile_Trn_tilecolor_Z = "";
         gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z = "";
         gxTv_SdtTrn_Tile_Productserviceid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Productservicename_Z = "";
         gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_tile", "GeneXus.Programs.trn_tile_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_Tile_Trn_tilewidth ;
      private short gxTv_SdtTrn_Tile_Initialized ;
      private short gxTv_SdtTrn_Tile_Trn_tilewidth_Z ;
      private string gxTv_SdtTrn_Tile_Trn_tilecolor ;
      private string gxTv_SdtTrn_Tile_Mode ;
      private string gxTv_SdtTrn_Tile_Trn_tilecolor_Z ;
      private string gxTv_SdtTrn_Tile_Productservicedescription ;
      private string gxTv_SdtTrn_Tile_Trn_tilename ;
      private string gxTv_SdtTrn_Tile_Trn_tilebgimageurl ;
      private string gxTv_SdtTrn_Tile_Productservicename ;
      private string gxTv_SdtTrn_Tile_Productserviceimage_gxi ;
      private string gxTv_SdtTrn_Tile_Trn_tilename_Z ;
      private string gxTv_SdtTrn_Tile_Trn_tilebgimageurl_Z ;
      private string gxTv_SdtTrn_Tile_Productservicename_Z ;
      private string gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z ;
      private string gxTv_SdtTrn_Tile_Productserviceimage ;
      private Guid gxTv_SdtTrn_Tile_Trn_tileid ;
      private Guid gxTv_SdtTrn_Tile_Productserviceid ;
      private Guid gxTv_SdtTrn_Tile_Organisationid ;
      private Guid gxTv_SdtTrn_Tile_Locationid ;
      private Guid gxTv_SdtTrn_Tile_Trn_tileid_Z ;
      private Guid gxTv_SdtTrn_Tile_Productserviceid_Z ;
      private Guid gxTv_SdtTrn_Tile_Organisationid_Z ;
      private Guid gxTv_SdtTrn_Tile_Locationid_Z ;
      private GXBCLevelCollection<SdtTrn_Tile_Attribute> gxTv_SdtTrn_Tile_Attribute=null ;
      private GXBCLevelCollection<SdtTrn_Tile_ChildTile> gxTv_SdtTrn_Tile_Childtile=null ;
   }

   [DataContract(Name = @"Trn_Tile", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Tile_RESTInterface : GxGenericCollectionItem<SdtTrn_Tile>
   {
      public SdtTrn_Tile_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Tile_RESTInterface( SdtTrn_Tile psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_TileId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Trn_tileid
      {
         get {
            return sdt.gxTpr_Trn_tileid ;
         }

         set {
            sdt.gxTpr_Trn_tileid = value;
         }

      }

      [DataMember( Name = "Trn_TileName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Trn_tilename
      {
         get {
            return sdt.gxTpr_Trn_tilename ;
         }

         set {
            sdt.gxTpr_Trn_tilename = value;
         }

      }

      [DataMember( Name = "Trn_TileWidth" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Trn_tilewidth
      {
         get {
            return sdt.gxTpr_Trn_tilewidth ;
         }

         set {
            sdt.gxTpr_Trn_tilewidth = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Trn_TileColor" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Trn_tilecolor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Trn_tilecolor) ;
         }

         set {
            sdt.gxTpr_Trn_tilecolor = value;
         }

      }

      [DataMember( Name = "Trn_TileBGImageUrl" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Trn_tilebgimageurl
      {
         get {
            return sdt.gxTpr_Trn_tilebgimageurl ;
         }

         set {
            sdt.gxTpr_Trn_tilebgimageurl = value;
         }

      }

      [DataMember( Name = "ProductServiceId" , Order = 5 )]
      [GxSeudo()]
      public Guid gxTpr_Productserviceid
      {
         get {
            return sdt.gxTpr_Productserviceid ;
         }

         set {
            sdt.gxTpr_Productserviceid = value;
         }

      }

      [DataMember( Name = "OrganisationId" , Order = 6 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationid
      {
         get {
            return sdt.gxTpr_Organisationid ;
         }

         set {
            sdt.gxTpr_Organisationid = value;
         }

      }

      [DataMember( Name = "LocationId" , Order = 7 )]
      [GxSeudo()]
      public Guid gxTpr_Locationid
      {
         get {
            return sdt.gxTpr_Locationid ;
         }

         set {
            sdt.gxTpr_Locationid = value;
         }

      }

      [DataMember( Name = "ProductServiceName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Productservicename
      {
         get {
            return sdt.gxTpr_Productservicename ;
         }

         set {
            sdt.gxTpr_Productservicename = value;
         }

      }

      [DataMember( Name = "ProductServiceDescription" , Order = 9 )]
      public string gxTpr_Productservicedescription
      {
         get {
            return sdt.gxTpr_Productservicedescription ;
         }

         set {
            sdt.gxTpr_Productservicedescription = value;
         }

      }

      [DataMember( Name = "ProductServiceImage" , Order = 10 )]
      [GxUpload()]
      public string gxTpr_Productserviceimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productserviceimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Productserviceimage) : StringUtil.RTrim( sdt.gxTpr_Productserviceimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Productserviceimage = value;
         }

      }

      [DataMember( Name = "Attribute" , Order = 11 )]
      public GxGenericCollection<SdtTrn_Tile_Attribute_RESTInterface> gxTpr_Attribute
      {
         get {
            return new GxGenericCollection<SdtTrn_Tile_Attribute_RESTInterface>(sdt.gxTpr_Attribute) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Attribute);
         }

      }

      [DataMember( Name = "ChildTile" , Order = 12 )]
      public GxGenericCollection<SdtTrn_Tile_ChildTile_RESTInterface> gxTpr_Childtile
      {
         get {
            return new GxGenericCollection<SdtTrn_Tile_ChildTile_RESTInterface>(sdt.gxTpr_Childtile) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Childtile);
         }

      }

      public SdtTrn_Tile sdt
      {
         get {
            return (SdtTrn_Tile)Sdt ;
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
            sdt = new SdtTrn_Tile() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 13 )]
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

   [DataContract(Name = @"Trn_Tile", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Tile_RESTLInterface : GxGenericCollectionItem<SdtTrn_Tile>
   {
      public SdtTrn_Tile_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Tile_RESTLInterface( SdtTrn_Tile psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Trn_TileName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Trn_tilename
      {
         get {
            return sdt.gxTpr_Trn_tilename ;
         }

         set {
            sdt.gxTpr_Trn_tilename = value;
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

      public SdtTrn_Tile sdt
      {
         get {
            return (SdtTrn_Tile)Sdt ;
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
            sdt = new SdtTrn_Tile() ;
         }
      }

   }

}
