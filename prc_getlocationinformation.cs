using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_getlocationinformation : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "prc_getlocationinformation_Services_Execute" ;
         }

      }

      public prc_getlocationinformation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getlocationinformation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           out string aP1_response )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV13response = "" ;
         initialize();
         ExecuteImpl();
         aP1_response=this.AV13response;
      }

      public string executeUdp( Guid aP0_LocationId )
      {
         execute(aP0_LocationId, out aP1_response);
         return AV13response ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 out string aP1_response )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV13response = "" ;
         SubmitImpl();
         aP1_response=this.AV13response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15GXLvl1 = 0;
         /* Using cursor P007S2 */
         pr_default.execute(0, new Object[] {AV9LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P007S2_A29LocationId[0];
            A11OrganisationId = P007S2_A11OrganisationId[0];
            A31LocationName = P007S2_A31LocationName[0];
            A34LocationEmail = P007S2_A34LocationEmail[0];
            A35LocationPhone = P007S2_A35LocationPhone[0];
            A359LocationCountry = P007S2_A359LocationCountry[0];
            A338LocationCity = P007S2_A338LocationCity[0];
            A339LocationZipCode = P007S2_A339LocationZipCode[0];
            A340LocationAddressLine1 = P007S2_A340LocationAddressLine1[0];
            A341LocationAddressLine2 = P007S2_A341LocationAddressLine2[0];
            A36LocationDescription = P007S2_A36LocationDescription[0];
            AV15GXLvl1 = 1;
            AV10LocationDetails.gxTpr_Locationid = A29LocationId;
            AV10LocationDetails.gxTpr_Organisationid = A11OrganisationId;
            AV10LocationDetails.gxTpr_Locationname = A31LocationName;
            AV10LocationDetails.gxTpr_Locationemail = A34LocationEmail;
            AV10LocationDetails.gxTpr_Locationphone = A35LocationPhone;
            AV10LocationDetails.gxTpr_Locationcountry = A359LocationCountry;
            AV10LocationDetails.gxTpr_Locationcity = A338LocationCity;
            AV10LocationDetails.gxTpr_Locationzipcode = A339LocationZipCode;
            AV10LocationDetails.gxTpr_Locationaddressline1 = A340LocationAddressLine1;
            AV10LocationDetails.gxTpr_Locationaddressline2 = A341LocationAddressLine2;
            AV10LocationDetails.gxTpr_Locationdescription = A36LocationDescription;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV15GXLvl1 == 0 )
         {
            AV8isNotFound = true;
         }
         if ( AV8isNotFound )
         {
            AV13response = context.GetMessage( "No location record found!", "");
         }
         else
         {
            AV13response = AV10LocationDetails.ToJSonString(false, true);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV13response = "";
         P007S2_A29LocationId = new Guid[] {Guid.Empty} ;
         P007S2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P007S2_A31LocationName = new string[] {""} ;
         P007S2_A34LocationEmail = new string[] {""} ;
         P007S2_A35LocationPhone = new string[] {""} ;
         P007S2_A359LocationCountry = new string[] {""} ;
         P007S2_A338LocationCity = new string[] {""} ;
         P007S2_A339LocationZipCode = new string[] {""} ;
         P007S2_A340LocationAddressLine1 = new string[] {""} ;
         P007S2_A341LocationAddressLine2 = new string[] {""} ;
         P007S2_A36LocationDescription = new string[] {""} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A31LocationName = "";
         A34LocationEmail = "";
         A35LocationPhone = "";
         A359LocationCountry = "";
         A338LocationCity = "";
         A339LocationZipCode = "";
         A340LocationAddressLine1 = "";
         A341LocationAddressLine2 = "";
         A36LocationDescription = "";
         AV10LocationDetails = new SdtSDT_Location(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getlocationinformation__default(),
            new Object[][] {
                new Object[] {
               P007S2_A29LocationId, P007S2_A11OrganisationId, P007S2_A31LocationName, P007S2_A34LocationEmail, P007S2_A35LocationPhone, P007S2_A359LocationCountry, P007S2_A338LocationCity, P007S2_A339LocationZipCode, P007S2_A340LocationAddressLine1, P007S2_A341LocationAddressLine2,
               P007S2_A36LocationDescription
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15GXLvl1 ;
      private string A35LocationPhone ;
      private bool AV8isNotFound ;
      private string AV13response ;
      private string A36LocationDescription ;
      private string A31LocationName ;
      private string A34LocationEmail ;
      private string A359LocationCountry ;
      private string A338LocationCity ;
      private string A339LocationZipCode ;
      private string A340LocationAddressLine1 ;
      private string A341LocationAddressLine2 ;
      private Guid AV9LocationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007S2_A29LocationId ;
      private Guid[] P007S2_A11OrganisationId ;
      private string[] P007S2_A31LocationName ;
      private string[] P007S2_A34LocationEmail ;
      private string[] P007S2_A35LocationPhone ;
      private string[] P007S2_A359LocationCountry ;
      private string[] P007S2_A338LocationCity ;
      private string[] P007S2_A339LocationZipCode ;
      private string[] P007S2_A340LocationAddressLine1 ;
      private string[] P007S2_A341LocationAddressLine2 ;
      private string[] P007S2_A36LocationDescription ;
      private SdtSDT_Location AV10LocationDetails ;
      private string aP1_response ;
   }

   public class prc_getlocationinformation__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007S2;
          prmP007S2 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007S2", "SELECT LocationId, OrganisationId, LocationName, LocationEmail, LocationPhone, LocationCountry, LocationCity, LocationZipCode, LocationAddressLine1, LocationAddressLine2, LocationDescription FROM Trn_Location WHERE LocationId = :AV9LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007S2,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(11);
                return;
       }
    }

 }

}
