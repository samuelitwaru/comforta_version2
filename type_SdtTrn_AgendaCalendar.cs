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
   [XmlRoot(ElementName = "Trn_AgendaCalendar" )]
   [XmlType(TypeName =  "Trn_AgendaCalendar" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_AgendaCalendar : GxSilentTrnSdt
   {
      public SdtTrn_AgendaCalendar( )
      {
      }

      public SdtTrn_AgendaCalendar( IGxContext context )
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

      public void Load( Guid AV303AgendaCalendarId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV303AgendaCalendarId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AgendaCalendarId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_AgendaCalendar");
         metadata.Set("BT", "Trn_AgendaCalendar");
         metadata.Set("PK", "[ \"AgendaCalendarId\" ]");
         metadata.Set("PKAssigned", "[ \"AgendaCalendarId\" ]");
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
         state.Add("gxTpr_Agendacalendarid_Z");
         state.Add("gxTpr_Agendacalendartitle_Z");
         state.Add("gxTpr_Agendacalendarstartdate_Z_Nullable");
         state.Add("gxTpr_Agendacalendarenddate_Z_Nullable");
         state.Add("gxTpr_Agendacalendarallday_Z");
         state.Add("gxTpr_Locationid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_AgendaCalendar sdt;
         sdt = (SdtTrn_AgendaCalendar)(source);
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarid = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarid ;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle ;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate ;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate ;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday ;
         gxTv_SdtTrn_AgendaCalendar_Locationid = sdt.gxTv_SdtTrn_AgendaCalendar_Locationid ;
         gxTv_SdtTrn_AgendaCalendar_Mode = sdt.gxTv_SdtTrn_AgendaCalendar_Mode ;
         gxTv_SdtTrn_AgendaCalendar_Initialized = sdt.gxTv_SdtTrn_AgendaCalendar_Initialized ;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z ;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z ;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z ;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z ;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday_Z = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday_Z ;
         gxTv_SdtTrn_AgendaCalendar_Locationid_Z = sdt.gxTv_SdtTrn_AgendaCalendar_Locationid_Z ;
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
         AddObjectProperty("AgendaCalendarId", gxTv_SdtTrn_AgendaCalendar_Agendacalendarid, false, includeNonInitialized);
         AddObjectProperty("AgendaCalendarTitle", gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("AgendaCalendarStartDate", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("AgendaCalendarEndDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AgendaCalendarAllDay", gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_AgendaCalendar_Locationid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_AgendaCalendar_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_AgendaCalendar_Initialized, false, includeNonInitialized);
            AddObjectProperty("AgendaCalendarId_Z", gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z, false, includeNonInitialized);
            AddObjectProperty("AgendaCalendarTitle_Z", gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("AgendaCalendarStartDate_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("AgendaCalendarEndDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AgendaCalendarAllDay_Z", gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_AgendaCalendar_Locationid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_AgendaCalendar sdt )
      {
         if ( sdt.IsDirty("AgendaCalendarId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarid = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarid ;
         }
         if ( sdt.IsDirty("AgendaCalendarTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle ;
         }
         if ( sdt.IsDirty("AgendaCalendarStartDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate ;
         }
         if ( sdt.IsDirty("AgendaCalendarEndDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate ;
         }
         if ( sdt.IsDirty("AgendaCalendarAllDay") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday = sdt.gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Locationid = sdt.gxTv_SdtTrn_AgendaCalendar_Locationid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AgendaCalendarId" )]
      [  XmlElement( ElementName = "AgendaCalendarId"   )]
      public Guid gxTpr_Agendacalendarid
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Agendacalendarid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_AgendaCalendar_Agendacalendarid != value )
            {
               gxTv_SdtTrn_AgendaCalendar_Mode = "INS";
               this.gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday_Z_SetNull( );
               this.gxTv_SdtTrn_AgendaCalendar_Locationid_Z_SetNull( );
            }
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarid = value;
            SetDirty("Agendacalendarid");
         }

      }

      [  SoapElement( ElementName = "AgendaCalendarTitle" )]
      [  XmlElement( ElementName = "AgendaCalendarTitle"   )]
      public string gxTpr_Agendacalendartitle
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle = value;
            SetDirty("Agendacalendartitle");
         }

      }

      [  SoapElement( ElementName = "AgendaCalendarStartDate" )]
      [  XmlElement( ElementName = "AgendaCalendarStartDate"  , IsNullable=true )]
      public string gxTpr_Agendacalendarstartdate_Nullable
      {
         get {
            if ( gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate = DateTime.MinValue;
            else
               gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Agendacalendarstartdate
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate = value;
            SetDirty("Agendacalendarstartdate");
         }

      }

      [  SoapElement( ElementName = "AgendaCalendarEndDate" )]
      [  XmlElement( ElementName = "AgendaCalendarEndDate"  , IsNullable=true )]
      public string gxTpr_Agendacalendarenddate_Nullable
      {
         get {
            if ( gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate = DateTime.MinValue;
            else
               gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Agendacalendarenddate
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate = value;
            SetDirty("Agendacalendarenddate");
         }

      }

      [  SoapElement( ElementName = "AgendaCalendarAllDay" )]
      [  XmlElement( ElementName = "AgendaCalendarAllDay"   )]
      public bool gxTpr_Agendacalendarallday
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday = value;
            SetDirty("Agendacalendarallday");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Locationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_AgendaCalendar_Mode_SetNull( )
      {
         gxTv_SdtTrn_AgendaCalendar_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaCalendar_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_AgendaCalendar_Initialized_SetNull( )
      {
         gxTv_SdtTrn_AgendaCalendar_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaCalendar_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgendaCalendarId_Z" )]
      [  XmlElement( ElementName = "AgendaCalendarId_Z"   )]
      public Guid gxTpr_Agendacalendarid_Z
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z = value;
            SetDirty("Agendacalendarid_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z = Guid.Empty;
         SetDirty("Agendacalendarid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgendaCalendarTitle_Z" )]
      [  XmlElement( ElementName = "AgendaCalendarTitle_Z"   )]
      public string gxTpr_Agendacalendartitle_Z
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z = value;
            SetDirty("Agendacalendartitle_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z = "";
         SetDirty("Agendacalendartitle_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgendaCalendarStartDate_Z" )]
      [  XmlElement( ElementName = "AgendaCalendarStartDate_Z"  , IsNullable=true )]
      public string gxTpr_Agendacalendarstartdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Agendacalendarstartdate_Z
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z = value;
            SetDirty("Agendacalendarstartdate_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Agendacalendarstartdate_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgendaCalendarEndDate_Z" )]
      [  XmlElement( ElementName = "AgendaCalendarEndDate_Z"  , IsNullable=true )]
      public string gxTpr_Agendacalendarenddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Agendacalendarenddate_Z
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z = value;
            SetDirty("Agendacalendarenddate_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Agendacalendarenddate_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgendaCalendarAllDay_Z" )]
      [  XmlElement( ElementName = "AgendaCalendarAllDay_Z"   )]
      public bool gxTpr_Agendacalendarallday_Z
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday_Z = value;
            SetDirty("Agendacalendarallday_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday_Z = false;
         SetDirty("Agendacalendarallday_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_AgendaCalendar_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_AgendaCalendar_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_AgendaCalendar_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_AgendaCalendar_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_AgendaCalendar_Locationid_Z_IsNull( )
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
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle = "";
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_AgendaCalendar_Locationid = Guid.Empty;
         gxTv_SdtTrn_AgendaCalendar_Mode = "";
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z = Guid.Empty;
         gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z = "";
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_AgendaCalendar_Locationid_Z = Guid.Empty;
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_agendacalendar", "GeneXus.Programs.trn_agendacalendar_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_AgendaCalendar_Initialized ;
      private string gxTv_SdtTrn_AgendaCalendar_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate ;
      private DateTime gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate ;
      private DateTime gxTv_SdtTrn_AgendaCalendar_Agendacalendarstartdate_Z ;
      private DateTime gxTv_SdtTrn_AgendaCalendar_Agendacalendarenddate_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday ;
      private bool gxTv_SdtTrn_AgendaCalendar_Agendacalendarallday_Z ;
      private string gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle ;
      private string gxTv_SdtTrn_AgendaCalendar_Agendacalendartitle_Z ;
      private Guid gxTv_SdtTrn_AgendaCalendar_Agendacalendarid ;
      private Guid gxTv_SdtTrn_AgendaCalendar_Locationid ;
      private Guid gxTv_SdtTrn_AgendaCalendar_Agendacalendarid_Z ;
      private Guid gxTv_SdtTrn_AgendaCalendar_Locationid_Z ;
   }

   [DataContract(Name = @"Trn_AgendaCalendar", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_AgendaCalendar_RESTInterface : GxGenericCollectionItem<SdtTrn_AgendaCalendar>
   {
      public SdtTrn_AgendaCalendar_RESTInterface( ) : base()
      {
      }

      public SdtTrn_AgendaCalendar_RESTInterface( SdtTrn_AgendaCalendar psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AgendaCalendarId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Agendacalendarid
      {
         get {
            return sdt.gxTpr_Agendacalendarid ;
         }

         set {
            sdt.gxTpr_Agendacalendarid = value;
         }

      }

      [DataMember( Name = "AgendaCalendarTitle" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Agendacalendartitle
      {
         get {
            return sdt.gxTpr_Agendacalendartitle ;
         }

         set {
            sdt.gxTpr_Agendacalendartitle = value;
         }

      }

      [DataMember( Name = "AgendaCalendarStartDate" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Agendacalendarstartdate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Agendacalendarstartdate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Agendacalendarstartdate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AgendaCalendarEndDate" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Agendacalendarenddate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Agendacalendarenddate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Agendacalendarenddate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AgendaCalendarAllDay" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Agendacalendarallday
      {
         get {
            return sdt.gxTpr_Agendacalendarallday ;
         }

         set {
            sdt.gxTpr_Agendacalendarallday = value;
         }

      }

      [DataMember( Name = "LocationId" , Order = 5 )]
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

      public SdtTrn_AgendaCalendar sdt
      {
         get {
            return (SdtTrn_AgendaCalendar)Sdt ;
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
            sdt = new SdtTrn_AgendaCalendar() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
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

   [DataContract(Name = @"Trn_AgendaCalendar", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_AgendaCalendar_RESTLInterface : GxGenericCollectionItem<SdtTrn_AgendaCalendar>
   {
      public SdtTrn_AgendaCalendar_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_AgendaCalendar_RESTLInterface( SdtTrn_AgendaCalendar psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AgendaCalendarTitle" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Agendacalendartitle
      {
         get {
            return sdt.gxTpr_Agendacalendartitle ;
         }

         set {
            sdt.gxTpr_Agendacalendartitle = value;
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

      public SdtTrn_AgendaCalendar sdt
      {
         get {
            return (SdtTrn_AgendaCalendar)Sdt ;
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
            sdt = new SdtTrn_AgendaCalendar() ;
         }
      }

   }

}