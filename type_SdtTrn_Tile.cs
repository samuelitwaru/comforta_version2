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

      public void Load( Guid AV407TileId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV407TileId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TileId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Tile");
         metadata.Set("BT", "Trn_Tile");
         metadata.Set("PK", "[ \"TileId\" ]");
         metadata.Set("PKAssigned", "[ \"TileId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"OrganisationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"Trn_PageId\" ],\"FKMap\":[ \"SG_ToPageId-Trn_PageId\" ] } ]");
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
         state.Add("gxTpr_Tileid_Z");
         state.Add("gxTpr_Tilename_Z");
         state.Add("gxTpr_Tilebgcolor_Z");
         state.Add("gxTpr_Tilebgimageurl_Z");
         state.Add("gxTpr_Tiletextcolor_Z");
         state.Add("gxTpr_Tiletextalignment_Z");
         state.Add("gxTpr_Tileicon_Z");
         state.Add("gxTpr_Tileiconalignment_Z");
         state.Add("gxTpr_Tileiconcolor_Z");
         state.Add("gxTpr_Productserviceid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Productservicename_Z");
         state.Add("gxTpr_Sg_topageid_Z");
         state.Add("gxTpr_Sg_topagename_Z");
         state.Add("gxTpr_Productserviceimage_gxi_Z");
         state.Add("gxTpr_Tilebgcolor_N");
         state.Add("gxTpr_Tilebgimageurl_N");
         state.Add("gxTpr_Tileicon_N");
         state.Add("gxTpr_Productserviceid_N");
         state.Add("gxTpr_Organisationid_N");
         state.Add("gxTpr_Locationid_N");
         state.Add("gxTpr_Sg_topageid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Tile sdt;
         sdt = (SdtTrn_Tile)(source);
         gxTv_SdtTrn_Tile_Tileid = sdt.gxTv_SdtTrn_Tile_Tileid ;
         gxTv_SdtTrn_Tile_Tilename = sdt.gxTv_SdtTrn_Tile_Tilename ;
         gxTv_SdtTrn_Tile_Tilebgcolor = sdt.gxTv_SdtTrn_Tile_Tilebgcolor ;
         gxTv_SdtTrn_Tile_Tilebgimageurl = sdt.gxTv_SdtTrn_Tile_Tilebgimageurl ;
         gxTv_SdtTrn_Tile_Tiletextcolor = sdt.gxTv_SdtTrn_Tile_Tiletextcolor ;
         gxTv_SdtTrn_Tile_Tiletextalignment = sdt.gxTv_SdtTrn_Tile_Tiletextalignment ;
         gxTv_SdtTrn_Tile_Tileicon = sdt.gxTv_SdtTrn_Tile_Tileicon ;
         gxTv_SdtTrn_Tile_Tileiconalignment = sdt.gxTv_SdtTrn_Tile_Tileiconalignment ;
         gxTv_SdtTrn_Tile_Tileiconcolor = sdt.gxTv_SdtTrn_Tile_Tileiconcolor ;
         gxTv_SdtTrn_Tile_Productserviceid = sdt.gxTv_SdtTrn_Tile_Productserviceid ;
         gxTv_SdtTrn_Tile_Organisationid = sdt.gxTv_SdtTrn_Tile_Organisationid ;
         gxTv_SdtTrn_Tile_Locationid = sdt.gxTv_SdtTrn_Tile_Locationid ;
         gxTv_SdtTrn_Tile_Productservicename = sdt.gxTv_SdtTrn_Tile_Productservicename ;
         gxTv_SdtTrn_Tile_Productservicedescription = sdt.gxTv_SdtTrn_Tile_Productservicedescription ;
         gxTv_SdtTrn_Tile_Productserviceimage = sdt.gxTv_SdtTrn_Tile_Productserviceimage ;
         gxTv_SdtTrn_Tile_Productserviceimage_gxi = sdt.gxTv_SdtTrn_Tile_Productserviceimage_gxi ;
         gxTv_SdtTrn_Tile_Tileaction = sdt.gxTv_SdtTrn_Tile_Tileaction ;
         gxTv_SdtTrn_Tile_Sg_topageid = sdt.gxTv_SdtTrn_Tile_Sg_topageid ;
         gxTv_SdtTrn_Tile_Sg_topagename = sdt.gxTv_SdtTrn_Tile_Sg_topagename ;
         gxTv_SdtTrn_Tile_Mode = sdt.gxTv_SdtTrn_Tile_Mode ;
         gxTv_SdtTrn_Tile_Initialized = sdt.gxTv_SdtTrn_Tile_Initialized ;
         gxTv_SdtTrn_Tile_Tileid_Z = sdt.gxTv_SdtTrn_Tile_Tileid_Z ;
         gxTv_SdtTrn_Tile_Tilename_Z = sdt.gxTv_SdtTrn_Tile_Tilename_Z ;
         gxTv_SdtTrn_Tile_Tilebgcolor_Z = sdt.gxTv_SdtTrn_Tile_Tilebgcolor_Z ;
         gxTv_SdtTrn_Tile_Tilebgimageurl_Z = sdt.gxTv_SdtTrn_Tile_Tilebgimageurl_Z ;
         gxTv_SdtTrn_Tile_Tiletextcolor_Z = sdt.gxTv_SdtTrn_Tile_Tiletextcolor_Z ;
         gxTv_SdtTrn_Tile_Tiletextalignment_Z = sdt.gxTv_SdtTrn_Tile_Tiletextalignment_Z ;
         gxTv_SdtTrn_Tile_Tileicon_Z = sdt.gxTv_SdtTrn_Tile_Tileicon_Z ;
         gxTv_SdtTrn_Tile_Tileiconalignment_Z = sdt.gxTv_SdtTrn_Tile_Tileiconalignment_Z ;
         gxTv_SdtTrn_Tile_Tileiconcolor_Z = sdt.gxTv_SdtTrn_Tile_Tileiconcolor_Z ;
         gxTv_SdtTrn_Tile_Productserviceid_Z = sdt.gxTv_SdtTrn_Tile_Productserviceid_Z ;
         gxTv_SdtTrn_Tile_Organisationid_Z = sdt.gxTv_SdtTrn_Tile_Organisationid_Z ;
         gxTv_SdtTrn_Tile_Locationid_Z = sdt.gxTv_SdtTrn_Tile_Locationid_Z ;
         gxTv_SdtTrn_Tile_Productservicename_Z = sdt.gxTv_SdtTrn_Tile_Productservicename_Z ;
         gxTv_SdtTrn_Tile_Sg_topageid_Z = sdt.gxTv_SdtTrn_Tile_Sg_topageid_Z ;
         gxTv_SdtTrn_Tile_Sg_topagename_Z = sdt.gxTv_SdtTrn_Tile_Sg_topagename_Z ;
         gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z = sdt.gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z ;
         gxTv_SdtTrn_Tile_Tilebgcolor_N = sdt.gxTv_SdtTrn_Tile_Tilebgcolor_N ;
         gxTv_SdtTrn_Tile_Tilebgimageurl_N = sdt.gxTv_SdtTrn_Tile_Tilebgimageurl_N ;
         gxTv_SdtTrn_Tile_Tileicon_N = sdt.gxTv_SdtTrn_Tile_Tileicon_N ;
         gxTv_SdtTrn_Tile_Productserviceid_N = sdt.gxTv_SdtTrn_Tile_Productserviceid_N ;
         gxTv_SdtTrn_Tile_Organisationid_N = sdt.gxTv_SdtTrn_Tile_Organisationid_N ;
         gxTv_SdtTrn_Tile_Locationid_N = sdt.gxTv_SdtTrn_Tile_Locationid_N ;
         gxTv_SdtTrn_Tile_Sg_topageid_N = sdt.gxTv_SdtTrn_Tile_Sg_topageid_N ;
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
         AddObjectProperty("TileId", gxTv_SdtTrn_Tile_Tileid, false, includeNonInitialized);
         AddObjectProperty("TileName", gxTv_SdtTrn_Tile_Tilename, false, includeNonInitialized);
         AddObjectProperty("TileBGColor", gxTv_SdtTrn_Tile_Tilebgcolor, false, includeNonInitialized);
         AddObjectProperty("TileBGColor_N", gxTv_SdtTrn_Tile_Tilebgcolor_N, false, includeNonInitialized);
         AddObjectProperty("TileBGImageUrl", gxTv_SdtTrn_Tile_Tilebgimageurl, false, includeNonInitialized);
         AddObjectProperty("TileBGImageUrl_N", gxTv_SdtTrn_Tile_Tilebgimageurl_N, false, includeNonInitialized);
         AddObjectProperty("TileTextColor", gxTv_SdtTrn_Tile_Tiletextcolor, false, includeNonInitialized);
         AddObjectProperty("TileTextAlignment", gxTv_SdtTrn_Tile_Tiletextalignment, false, includeNonInitialized);
         AddObjectProperty("TileIcon", gxTv_SdtTrn_Tile_Tileicon, false, includeNonInitialized);
         AddObjectProperty("TileIcon_N", gxTv_SdtTrn_Tile_Tileicon_N, false, includeNonInitialized);
         AddObjectProperty("TileIconAlignment", gxTv_SdtTrn_Tile_Tileiconalignment, false, includeNonInitialized);
         AddObjectProperty("TileIconColor", gxTv_SdtTrn_Tile_Tileiconcolor, false, includeNonInitialized);
         AddObjectProperty("ProductServiceId", gxTv_SdtTrn_Tile_Productserviceid, false, includeNonInitialized);
         AddObjectProperty("ProductServiceId_N", gxTv_SdtTrn_Tile_Productserviceid_N, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Tile_Organisationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId_N", gxTv_SdtTrn_Tile_Organisationid_N, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_Tile_Locationid, false, includeNonInitialized);
         AddObjectProperty("LocationId_N", gxTv_SdtTrn_Tile_Locationid_N, false, includeNonInitialized);
         AddObjectProperty("ProductServiceName", gxTv_SdtTrn_Tile_Productservicename, false, includeNonInitialized);
         AddObjectProperty("ProductServiceDescription", gxTv_SdtTrn_Tile_Productservicedescription, false, includeNonInitialized);
         AddObjectProperty("ProductServiceImage", gxTv_SdtTrn_Tile_Productserviceimage, false, includeNonInitialized);
         AddObjectProperty("TileAction", gxTv_SdtTrn_Tile_Tileaction, false, includeNonInitialized);
         AddObjectProperty("SG_ToPageId", gxTv_SdtTrn_Tile_Sg_topageid, false, includeNonInitialized);
         AddObjectProperty("SG_ToPageId_N", gxTv_SdtTrn_Tile_Sg_topageid_N, false, includeNonInitialized);
         AddObjectProperty("SG_ToPageName", gxTv_SdtTrn_Tile_Sg_topagename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ProductServiceImage_GXI", gxTv_SdtTrn_Tile_Productserviceimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtTrn_Tile_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Tile_Initialized, false, includeNonInitialized);
            AddObjectProperty("TileId_Z", gxTv_SdtTrn_Tile_Tileid_Z, false, includeNonInitialized);
            AddObjectProperty("TileName_Z", gxTv_SdtTrn_Tile_Tilename_Z, false, includeNonInitialized);
            AddObjectProperty("TileBGColor_Z", gxTv_SdtTrn_Tile_Tilebgcolor_Z, false, includeNonInitialized);
            AddObjectProperty("TileBGImageUrl_Z", gxTv_SdtTrn_Tile_Tilebgimageurl_Z, false, includeNonInitialized);
            AddObjectProperty("TileTextColor_Z", gxTv_SdtTrn_Tile_Tiletextcolor_Z, false, includeNonInitialized);
            AddObjectProperty("TileTextAlignment_Z", gxTv_SdtTrn_Tile_Tiletextalignment_Z, false, includeNonInitialized);
            AddObjectProperty("TileIcon_Z", gxTv_SdtTrn_Tile_Tileicon_Z, false, includeNonInitialized);
            AddObjectProperty("TileIconAlignment_Z", gxTv_SdtTrn_Tile_Tileiconalignment_Z, false, includeNonInitialized);
            AddObjectProperty("TileIconColor_Z", gxTv_SdtTrn_Tile_Tileiconcolor_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceId_Z", gxTv_SdtTrn_Tile_Productserviceid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Tile_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_Tile_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceName_Z", gxTv_SdtTrn_Tile_Productservicename_Z, false, includeNonInitialized);
            AddObjectProperty("SG_ToPageId_Z", gxTv_SdtTrn_Tile_Sg_topageid_Z, false, includeNonInitialized);
            AddObjectProperty("SG_ToPageName_Z", gxTv_SdtTrn_Tile_Sg_topagename_Z, false, includeNonInitialized);
            AddObjectProperty("ProductServiceImage_GXI_Z", gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("TileBGColor_N", gxTv_SdtTrn_Tile_Tilebgcolor_N, false, includeNonInitialized);
            AddObjectProperty("TileBGImageUrl_N", gxTv_SdtTrn_Tile_Tilebgimageurl_N, false, includeNonInitialized);
            AddObjectProperty("TileIcon_N", gxTv_SdtTrn_Tile_Tileicon_N, false, includeNonInitialized);
            AddObjectProperty("ProductServiceId_N", gxTv_SdtTrn_Tile_Productserviceid_N, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_N", gxTv_SdtTrn_Tile_Organisationid_N, false, includeNonInitialized);
            AddObjectProperty("LocationId_N", gxTv_SdtTrn_Tile_Locationid_N, false, includeNonInitialized);
            AddObjectProperty("SG_ToPageId_N", gxTv_SdtTrn_Tile_Sg_topageid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Tile sdt )
      {
         if ( sdt.IsDirty("TileId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileid = sdt.gxTv_SdtTrn_Tile_Tileid ;
         }
         if ( sdt.IsDirty("TileName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilename = sdt.gxTv_SdtTrn_Tile_Tilename ;
         }
         if ( sdt.IsDirty("TileBGColor") )
         {
            gxTv_SdtTrn_Tile_Tilebgcolor_N = (short)(sdt.gxTv_SdtTrn_Tile_Tilebgcolor_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgcolor = sdt.gxTv_SdtTrn_Tile_Tilebgcolor ;
         }
         if ( sdt.IsDirty("TileBGImageUrl") )
         {
            gxTv_SdtTrn_Tile_Tilebgimageurl_N = (short)(sdt.gxTv_SdtTrn_Tile_Tilebgimageurl_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgimageurl = sdt.gxTv_SdtTrn_Tile_Tilebgimageurl ;
         }
         if ( sdt.IsDirty("TileTextColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextcolor = sdt.gxTv_SdtTrn_Tile_Tiletextcolor ;
         }
         if ( sdt.IsDirty("TileTextAlignment") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextalignment = sdt.gxTv_SdtTrn_Tile_Tiletextalignment ;
         }
         if ( sdt.IsDirty("TileIcon") )
         {
            gxTv_SdtTrn_Tile_Tileicon_N = (short)(sdt.gxTv_SdtTrn_Tile_Tileicon_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileicon = sdt.gxTv_SdtTrn_Tile_Tileicon ;
         }
         if ( sdt.IsDirty("TileIconAlignment") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconalignment = sdt.gxTv_SdtTrn_Tile_Tileiconalignment ;
         }
         if ( sdt.IsDirty("TileIconColor") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconcolor = sdt.gxTv_SdtTrn_Tile_Tileiconcolor ;
         }
         if ( sdt.IsDirty("ProductServiceId") )
         {
            gxTv_SdtTrn_Tile_Productserviceid_N = (short)(sdt.gxTv_SdtTrn_Tile_Productserviceid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceid = sdt.gxTv_SdtTrn_Tile_Productserviceid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            gxTv_SdtTrn_Tile_Organisationid_N = (short)(sdt.gxTv_SdtTrn_Tile_Organisationid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Organisationid = sdt.gxTv_SdtTrn_Tile_Organisationid ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            gxTv_SdtTrn_Tile_Locationid_N = (short)(sdt.gxTv_SdtTrn_Tile_Locationid_N);
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
         if ( sdt.IsDirty("TileAction") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileaction = sdt.gxTv_SdtTrn_Tile_Tileaction ;
         }
         if ( sdt.IsDirty("SG_ToPageId") )
         {
            gxTv_SdtTrn_Tile_Sg_topageid_N = (short)(sdt.gxTv_SdtTrn_Tile_Sg_topageid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Sg_topageid = sdt.gxTv_SdtTrn_Tile_Sg_topageid ;
         }
         if ( sdt.IsDirty("SG_ToPageName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Sg_topagename = sdt.gxTv_SdtTrn_Tile_Sg_topagename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TileId" )]
      [  XmlElement( ElementName = "TileId"   )]
      public Guid gxTpr_Tileid
      {
         get {
            return gxTv_SdtTrn_Tile_Tileid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Tile_Tileid != value )
            {
               gxTv_SdtTrn_Tile_Mode = "INS";
               this.gxTv_SdtTrn_Tile_Tileid_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tilename_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tilebgcolor_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tilebgimageurl_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tiletextcolor_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tiletextalignment_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tileicon_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tileiconalignment_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Tileiconcolor_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Productserviceid_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Productservicename_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Sg_topageid_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Sg_topagename_Z_SetNull( );
               this.gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z_SetNull( );
            }
            gxTv_SdtTrn_Tile_Tileid = value;
            SetDirty("Tileid");
         }

      }

      [  SoapElement( ElementName = "TileName" )]
      [  XmlElement( ElementName = "TileName"   )]
      public string gxTpr_Tilename
      {
         get {
            return gxTv_SdtTrn_Tile_Tilename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilename = value;
            SetDirty("Tilename");
         }

      }

      [  SoapElement( ElementName = "TileBGColor" )]
      [  XmlElement( ElementName = "TileBGColor"   )]
      public string gxTpr_Tilebgcolor
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgcolor ;
         }

         set {
            gxTv_SdtTrn_Tile_Tilebgcolor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgcolor = value;
            SetDirty("Tilebgcolor");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgcolor_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgcolor_N = 1;
         gxTv_SdtTrn_Tile_Tilebgcolor = "";
         SetDirty("Tilebgcolor");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgcolor_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_Tilebgcolor_N==1) ;
      }

      [  SoapElement( ElementName = "TileBGImageUrl" )]
      [  XmlElement( ElementName = "TileBGImageUrl"   )]
      public string gxTpr_Tilebgimageurl
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgimageurl ;
         }

         set {
            gxTv_SdtTrn_Tile_Tilebgimageurl_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgimageurl = value;
            SetDirty("Tilebgimageurl");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgimageurl_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgimageurl_N = 1;
         gxTv_SdtTrn_Tile_Tilebgimageurl = "";
         SetDirty("Tilebgimageurl");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgimageurl_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_Tilebgimageurl_N==1) ;
      }

      [  SoapElement( ElementName = "TileTextColor" )]
      [  XmlElement( ElementName = "TileTextColor"   )]
      public string gxTpr_Tiletextcolor
      {
         get {
            return gxTv_SdtTrn_Tile_Tiletextcolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextcolor = value;
            SetDirty("Tiletextcolor");
         }

      }

      [  SoapElement( ElementName = "TileTextAlignment" )]
      [  XmlElement( ElementName = "TileTextAlignment"   )]
      public string gxTpr_Tiletextalignment
      {
         get {
            return gxTv_SdtTrn_Tile_Tiletextalignment ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextalignment = value;
            SetDirty("Tiletextalignment");
         }

      }

      [  SoapElement( ElementName = "TileIcon" )]
      [  XmlElement( ElementName = "TileIcon"   )]
      public string gxTpr_Tileicon
      {
         get {
            return gxTv_SdtTrn_Tile_Tileicon ;
         }

         set {
            gxTv_SdtTrn_Tile_Tileicon_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileicon = value;
            SetDirty("Tileicon");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileicon_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileicon_N = 1;
         gxTv_SdtTrn_Tile_Tileicon = "";
         SetDirty("Tileicon");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileicon_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_Tileicon_N==1) ;
      }

      [  SoapElement( ElementName = "TileIconAlignment" )]
      [  XmlElement( ElementName = "TileIconAlignment"   )]
      public string gxTpr_Tileiconalignment
      {
         get {
            return gxTv_SdtTrn_Tile_Tileiconalignment ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconalignment = value;
            SetDirty("Tileiconalignment");
         }

      }

      [  SoapElement( ElementName = "TileIconColor" )]
      [  XmlElement( ElementName = "TileIconColor"   )]
      public string gxTpr_Tileiconcolor
      {
         get {
            return gxTv_SdtTrn_Tile_Tileiconcolor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconcolor = value;
            SetDirty("Tileiconcolor");
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
            gxTv_SdtTrn_Tile_Productserviceid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceid = value;
            SetDirty("Productserviceid");
         }

      }

      public void gxTv_SdtTrn_Tile_Productserviceid_SetNull( )
      {
         gxTv_SdtTrn_Tile_Productserviceid_N = 1;
         gxTv_SdtTrn_Tile_Productserviceid = Guid.Empty;
         SetDirty("Productserviceid");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Productserviceid_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_Productserviceid_N==1) ;
      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Tile_Organisationid ;
         }

         set {
            gxTv_SdtTrn_Tile_Organisationid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      public void gxTv_SdtTrn_Tile_Organisationid_SetNull( )
      {
         gxTv_SdtTrn_Tile_Organisationid_N = 1;
         gxTv_SdtTrn_Tile_Organisationid = Guid.Empty;
         SetDirty("Organisationid");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Organisationid_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_Organisationid_N==1) ;
      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_Tile_Locationid ;
         }

         set {
            gxTv_SdtTrn_Tile_Locationid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Locationid = value;
            SetDirty("Locationid");
         }

      }

      public void gxTv_SdtTrn_Tile_Locationid_SetNull( )
      {
         gxTv_SdtTrn_Tile_Locationid_N = 1;
         gxTv_SdtTrn_Tile_Locationid = Guid.Empty;
         SetDirty("Locationid");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Locationid_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_Locationid_N==1) ;
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

      [  SoapElement( ElementName = "TileAction" )]
      [  XmlElement( ElementName = "TileAction"   )]
      public string gxTpr_Tileaction
      {
         get {
            return gxTv_SdtTrn_Tile_Tileaction ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileaction = value;
            SetDirty("Tileaction");
         }

      }

      [  SoapElement( ElementName = "SG_ToPageId" )]
      [  XmlElement( ElementName = "SG_ToPageId"   )]
      public Guid gxTpr_Sg_topageid
      {
         get {
            return gxTv_SdtTrn_Tile_Sg_topageid ;
         }

         set {
            gxTv_SdtTrn_Tile_Sg_topageid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Sg_topageid = value;
            SetDirty("Sg_topageid");
         }

      }

      public void gxTv_SdtTrn_Tile_Sg_topageid_SetNull( )
      {
         gxTv_SdtTrn_Tile_Sg_topageid_N = 1;
         gxTv_SdtTrn_Tile_Sg_topageid = Guid.Empty;
         SetDirty("Sg_topageid");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Sg_topageid_IsNull( )
      {
         return (gxTv_SdtTrn_Tile_Sg_topageid_N==1) ;
      }

      [  SoapElement( ElementName = "SG_ToPageName" )]
      [  XmlElement( ElementName = "SG_ToPageName"   )]
      public string gxTpr_Sg_topagename
      {
         get {
            return gxTv_SdtTrn_Tile_Sg_topagename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Sg_topagename = value;
            SetDirty("Sg_topagename");
         }

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

      [  SoapElement( ElementName = "TileId_Z" )]
      [  XmlElement( ElementName = "TileId_Z"   )]
      public Guid gxTpr_Tileid_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tileid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileid_Z = value;
            SetDirty("Tileid_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileid_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileid_Z = Guid.Empty;
         SetDirty("Tileid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileName_Z" )]
      [  XmlElement( ElementName = "TileName_Z"   )]
      public string gxTpr_Tilename_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tilename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilename_Z = value;
            SetDirty("Tilename_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilename_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilename_Z = "";
         SetDirty("Tilename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileBGColor_Z" )]
      [  XmlElement( ElementName = "TileBGColor_Z"   )]
      public string gxTpr_Tilebgcolor_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgcolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgcolor_Z = value;
            SetDirty("Tilebgcolor_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgcolor_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgcolor_Z = "";
         SetDirty("Tilebgcolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgcolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileBGImageUrl_Z" )]
      [  XmlElement( ElementName = "TileBGImageUrl_Z"   )]
      public string gxTpr_Tilebgimageurl_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgimageurl_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgimageurl_Z = value;
            SetDirty("Tilebgimageurl_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgimageurl_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgimageurl_Z = "";
         SetDirty("Tilebgimageurl_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgimageurl_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileTextColor_Z" )]
      [  XmlElement( ElementName = "TileTextColor_Z"   )]
      public string gxTpr_Tiletextcolor_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tiletextcolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextcolor_Z = value;
            SetDirty("Tiletextcolor_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tiletextcolor_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tiletextcolor_Z = "";
         SetDirty("Tiletextcolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tiletextcolor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileTextAlignment_Z" )]
      [  XmlElement( ElementName = "TileTextAlignment_Z"   )]
      public string gxTpr_Tiletextalignment_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tiletextalignment_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tiletextalignment_Z = value;
            SetDirty("Tiletextalignment_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tiletextalignment_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tiletextalignment_Z = "";
         SetDirty("Tiletextalignment_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tiletextalignment_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileIcon_Z" )]
      [  XmlElement( ElementName = "TileIcon_Z"   )]
      public string gxTpr_Tileicon_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tileicon_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileicon_Z = value;
            SetDirty("Tileicon_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileicon_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileicon_Z = "";
         SetDirty("Tileicon_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileicon_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileIconAlignment_Z" )]
      [  XmlElement( ElementName = "TileIconAlignment_Z"   )]
      public string gxTpr_Tileiconalignment_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tileiconalignment_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconalignment_Z = value;
            SetDirty("Tileiconalignment_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileiconalignment_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileiconalignment_Z = "";
         SetDirty("Tileiconalignment_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileiconalignment_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileIconColor_Z" )]
      [  XmlElement( ElementName = "TileIconColor_Z"   )]
      public string gxTpr_Tileiconcolor_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Tileiconcolor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileiconcolor_Z = value;
            SetDirty("Tileiconcolor_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileiconcolor_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileiconcolor_Z = "";
         SetDirty("Tileiconcolor_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileiconcolor_Z_IsNull( )
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

      [  SoapElement( ElementName = "SG_ToPageId_Z" )]
      [  XmlElement( ElementName = "SG_ToPageId_Z"   )]
      public Guid gxTpr_Sg_topageid_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Sg_topageid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Sg_topageid_Z = value;
            SetDirty("Sg_topageid_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Sg_topageid_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Sg_topageid_Z = Guid.Empty;
         SetDirty("Sg_topageid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Sg_topageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_ToPageName_Z" )]
      [  XmlElement( ElementName = "SG_ToPageName_Z"   )]
      public string gxTpr_Sg_topagename_Z
      {
         get {
            return gxTv_SdtTrn_Tile_Sg_topagename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Sg_topagename_Z = value;
            SetDirty("Sg_topagename_Z");
         }

      }

      public void gxTv_SdtTrn_Tile_Sg_topagename_Z_SetNull( )
      {
         gxTv_SdtTrn_Tile_Sg_topagename_Z = "";
         SetDirty("Sg_topagename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Sg_topagename_Z_IsNull( )
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

      [  SoapElement( ElementName = "TileBGColor_N" )]
      [  XmlElement( ElementName = "TileBGColor_N"   )]
      public short gxTpr_Tilebgcolor_N
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgcolor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgcolor_N = value;
            SetDirty("Tilebgcolor_N");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgcolor_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgcolor_N = 0;
         SetDirty("Tilebgcolor_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgcolor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileBGImageUrl_N" )]
      [  XmlElement( ElementName = "TileBGImageUrl_N"   )]
      public short gxTpr_Tilebgimageurl_N
      {
         get {
            return gxTv_SdtTrn_Tile_Tilebgimageurl_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tilebgimageurl_N = value;
            SetDirty("Tilebgimageurl_N");
         }

      }

      public void gxTv_SdtTrn_Tile_Tilebgimageurl_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tilebgimageurl_N = 0;
         SetDirty("Tilebgimageurl_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tilebgimageurl_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TileIcon_N" )]
      [  XmlElement( ElementName = "TileIcon_N"   )]
      public short gxTpr_Tileicon_N
      {
         get {
            return gxTv_SdtTrn_Tile_Tileicon_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Tileicon_N = value;
            SetDirty("Tileicon_N");
         }

      }

      public void gxTv_SdtTrn_Tile_Tileicon_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_Tileicon_N = 0;
         SetDirty("Tileicon_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Tileicon_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductServiceId_N" )]
      [  XmlElement( ElementName = "ProductServiceId_N"   )]
      public short gxTpr_Productserviceid_N
      {
         get {
            return gxTv_SdtTrn_Tile_Productserviceid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Productserviceid_N = value;
            SetDirty("Productserviceid_N");
         }

      }

      public void gxTv_SdtTrn_Tile_Productserviceid_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_Productserviceid_N = 0;
         SetDirty("Productserviceid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Productserviceid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_N" )]
      [  XmlElement( ElementName = "OrganisationId_N"   )]
      public short gxTpr_Organisationid_N
      {
         get {
            return gxTv_SdtTrn_Tile_Organisationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Organisationid_N = value;
            SetDirty("Organisationid_N");
         }

      }

      public void gxTv_SdtTrn_Tile_Organisationid_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_Organisationid_N = 0;
         SetDirty("Organisationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Organisationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_N" )]
      [  XmlElement( ElementName = "LocationId_N"   )]
      public short gxTpr_Locationid_N
      {
         get {
            return gxTv_SdtTrn_Tile_Locationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Locationid_N = value;
            SetDirty("Locationid_N");
         }

      }

      public void gxTv_SdtTrn_Tile_Locationid_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_Locationid_N = 0;
         SetDirty("Locationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Locationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SG_ToPageId_N" )]
      [  XmlElement( ElementName = "SG_ToPageId_N"   )]
      public short gxTpr_Sg_topageid_N
      {
         get {
            return gxTv_SdtTrn_Tile_Sg_topageid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Tile_Sg_topageid_N = value;
            SetDirty("Sg_topageid_N");
         }

      }

      public void gxTv_SdtTrn_Tile_Sg_topageid_N_SetNull( )
      {
         gxTv_SdtTrn_Tile_Sg_topageid_N = 0;
         SetDirty("Sg_topageid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Tile_Sg_topageid_N_IsNull( )
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
         gxTv_SdtTrn_Tile_Tileid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Tile_Tilename = "";
         gxTv_SdtTrn_Tile_Tilebgcolor = "";
         gxTv_SdtTrn_Tile_Tilebgimageurl = "";
         gxTv_SdtTrn_Tile_Tiletextcolor = "";
         gxTv_SdtTrn_Tile_Tiletextalignment = "";
         gxTv_SdtTrn_Tile_Tileicon = "";
         gxTv_SdtTrn_Tile_Tileiconalignment = "";
         gxTv_SdtTrn_Tile_Tileiconcolor = "";
         gxTv_SdtTrn_Tile_Productserviceid = Guid.Empty;
         gxTv_SdtTrn_Tile_Organisationid = Guid.Empty;
         gxTv_SdtTrn_Tile_Locationid = Guid.Empty;
         gxTv_SdtTrn_Tile_Productservicename = "";
         gxTv_SdtTrn_Tile_Productservicedescription = "";
         gxTv_SdtTrn_Tile_Productserviceimage = "";
         gxTv_SdtTrn_Tile_Productserviceimage_gxi = "";
         gxTv_SdtTrn_Tile_Tileaction = "";
         gxTv_SdtTrn_Tile_Sg_topageid = Guid.Empty;
         gxTv_SdtTrn_Tile_Sg_topagename = "";
         gxTv_SdtTrn_Tile_Mode = "";
         gxTv_SdtTrn_Tile_Tileid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Tilename_Z = "";
         gxTv_SdtTrn_Tile_Tilebgcolor_Z = "";
         gxTv_SdtTrn_Tile_Tilebgimageurl_Z = "";
         gxTv_SdtTrn_Tile_Tiletextcolor_Z = "";
         gxTv_SdtTrn_Tile_Tiletextalignment_Z = "";
         gxTv_SdtTrn_Tile_Tileicon_Z = "";
         gxTv_SdtTrn_Tile_Tileiconalignment_Z = "";
         gxTv_SdtTrn_Tile_Tileiconcolor_Z = "";
         gxTv_SdtTrn_Tile_Productserviceid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Productservicename_Z = "";
         gxTv_SdtTrn_Tile_Sg_topageid_Z = Guid.Empty;
         gxTv_SdtTrn_Tile_Sg_topagename_Z = "";
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
      private short gxTv_SdtTrn_Tile_Initialized ;
      private short gxTv_SdtTrn_Tile_Tilebgcolor_N ;
      private short gxTv_SdtTrn_Tile_Tilebgimageurl_N ;
      private short gxTv_SdtTrn_Tile_Tileicon_N ;
      private short gxTv_SdtTrn_Tile_Productserviceid_N ;
      private short gxTv_SdtTrn_Tile_Organisationid_N ;
      private short gxTv_SdtTrn_Tile_Locationid_N ;
      private short gxTv_SdtTrn_Tile_Sg_topageid_N ;
      private string gxTv_SdtTrn_Tile_Tilebgcolor ;
      private string gxTv_SdtTrn_Tile_Tiletextcolor ;
      private string gxTv_SdtTrn_Tile_Tiletextalignment ;
      private string gxTv_SdtTrn_Tile_Tileicon ;
      private string gxTv_SdtTrn_Tile_Tileiconalignment ;
      private string gxTv_SdtTrn_Tile_Tileiconcolor ;
      private string gxTv_SdtTrn_Tile_Mode ;
      private string gxTv_SdtTrn_Tile_Tilebgcolor_Z ;
      private string gxTv_SdtTrn_Tile_Tiletextcolor_Z ;
      private string gxTv_SdtTrn_Tile_Tiletextalignment_Z ;
      private string gxTv_SdtTrn_Tile_Tileicon_Z ;
      private string gxTv_SdtTrn_Tile_Tileiconalignment_Z ;
      private string gxTv_SdtTrn_Tile_Tileiconcolor_Z ;
      private string gxTv_SdtTrn_Tile_Productservicedescription ;
      private string gxTv_SdtTrn_Tile_Tileaction ;
      private string gxTv_SdtTrn_Tile_Tilename ;
      private string gxTv_SdtTrn_Tile_Tilebgimageurl ;
      private string gxTv_SdtTrn_Tile_Productservicename ;
      private string gxTv_SdtTrn_Tile_Productserviceimage_gxi ;
      private string gxTv_SdtTrn_Tile_Sg_topagename ;
      private string gxTv_SdtTrn_Tile_Tilename_Z ;
      private string gxTv_SdtTrn_Tile_Tilebgimageurl_Z ;
      private string gxTv_SdtTrn_Tile_Productservicename_Z ;
      private string gxTv_SdtTrn_Tile_Sg_topagename_Z ;
      private string gxTv_SdtTrn_Tile_Productserviceimage_gxi_Z ;
      private string gxTv_SdtTrn_Tile_Productserviceimage ;
      private Guid gxTv_SdtTrn_Tile_Tileid ;
      private Guid gxTv_SdtTrn_Tile_Productserviceid ;
      private Guid gxTv_SdtTrn_Tile_Organisationid ;
      private Guid gxTv_SdtTrn_Tile_Locationid ;
      private Guid gxTv_SdtTrn_Tile_Sg_topageid ;
      private Guid gxTv_SdtTrn_Tile_Tileid_Z ;
      private Guid gxTv_SdtTrn_Tile_Productserviceid_Z ;
      private Guid gxTv_SdtTrn_Tile_Organisationid_Z ;
      private Guid gxTv_SdtTrn_Tile_Locationid_Z ;
      private Guid gxTv_SdtTrn_Tile_Sg_topageid_Z ;
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

      [DataMember( Name = "TileId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Tileid
      {
         get {
            return sdt.gxTpr_Tileid ;
         }

         set {
            sdt.gxTpr_Tileid = value;
         }

      }

      [DataMember( Name = "TileName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tilename
      {
         get {
            return sdt.gxTpr_Tilename ;
         }

         set {
            sdt.gxTpr_Tilename = value;
         }

      }

      [DataMember( Name = "TileBGColor" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Tilebgcolor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tilebgcolor) ;
         }

         set {
            sdt.gxTpr_Tilebgcolor = value;
         }

      }

      [DataMember( Name = "TileBGImageUrl" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Tilebgimageurl
      {
         get {
            return sdt.gxTpr_Tilebgimageurl ;
         }

         set {
            sdt.gxTpr_Tilebgimageurl = value;
         }

      }

      [DataMember( Name = "TileTextColor" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Tiletextcolor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tiletextcolor) ;
         }

         set {
            sdt.gxTpr_Tiletextcolor = value;
         }

      }

      [DataMember( Name = "TileTextAlignment" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Tiletextalignment
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tiletextalignment) ;
         }

         set {
            sdt.gxTpr_Tiletextalignment = value;
         }

      }

      [DataMember( Name = "TileIcon" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Tileicon
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tileicon) ;
         }

         set {
            sdt.gxTpr_Tileicon = value;
         }

      }

      [DataMember( Name = "TileIconAlignment" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Tileiconalignment
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tileiconalignment) ;
         }

         set {
            sdt.gxTpr_Tileiconalignment = value;
         }

      }

      [DataMember( Name = "TileIconColor" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Tileiconcolor
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tileiconcolor) ;
         }

         set {
            sdt.gxTpr_Tileiconcolor = value;
         }

      }

      [DataMember( Name = "ProductServiceId" , Order = 9 )]
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

      [DataMember( Name = "OrganisationId" , Order = 10 )]
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

      [DataMember( Name = "LocationId" , Order = 11 )]
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

      [DataMember( Name = "ProductServiceName" , Order = 12 )]
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

      [DataMember( Name = "ProductServiceDescription" , Order = 13 )]
      public string gxTpr_Productservicedescription
      {
         get {
            return sdt.gxTpr_Productservicedescription ;
         }

         set {
            sdt.gxTpr_Productservicedescription = value;
         }

      }

      [DataMember( Name = "ProductServiceImage" , Order = 14 )]
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

      [DataMember( Name = "TileAction" , Order = 15 )]
      public string gxTpr_Tileaction
      {
         get {
            return sdt.gxTpr_Tileaction ;
         }

         set {
            sdt.gxTpr_Tileaction = value;
         }

      }

      [DataMember( Name = "SG_ToPageId" , Order = 16 )]
      [GxSeudo()]
      public Guid gxTpr_Sg_topageid
      {
         get {
            return sdt.gxTpr_Sg_topageid ;
         }

         set {
            sdt.gxTpr_Sg_topageid = value;
         }

      }

      [DataMember( Name = "SG_ToPageName" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Sg_topagename
      {
         get {
            return sdt.gxTpr_Sg_topagename ;
         }

         set {
            sdt.gxTpr_Sg_topagename = value;
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

      [DataMember( Name = "gx_md5_hash", Order = 18 )]
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

      [DataMember( Name = "TileName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tilename
      {
         get {
            return sdt.gxTpr_Tilename ;
         }

         set {
            sdt.gxTpr_Tilename = value;
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
