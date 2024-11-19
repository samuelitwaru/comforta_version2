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
   public class prc_createpage : GXProcedure
   {
      public prc_createpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_createpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PageName ,
                           ref string aP1_Response )
      {
         this.AV16PageName = aP0_PageName;
         this.AV17Response = aP1_Response;
         initialize();
         ExecuteImpl();
         aP1_Response=this.AV17Response;
      }

      public string executeUdp( string aP0_PageName )
      {
         execute(aP0_PageName, ref aP1_Response);
         return AV17Response ;
      }

      public void executeSubmit( string aP0_PageName ,
                                 ref string aP1_Response )
      {
         this.AV16PageName = aP0_PageName;
         this.AV17Response = aP1_Response;
         SubmitImpl();
         aP1_Response=this.AV17Response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV19UserName;
         new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
         AV19UserName = GXt_char1;
         /* Using cursor P008V2 */
         pr_default.execute(0, new Object[] {AV19UserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A93ReceptionistEmail = P008V2_A93ReceptionistEmail[0];
            A29LocationId = P008V2_A29LocationId[0];
            A11OrganisationId = P008V2_A11OrganisationId[0];
            A89ReceptionistId = P008V2_A89ReceptionistId[0];
            AV20LocationId = A29LocationId;
            AV21OrganisationId = A11OrganisationId;
            new prc_logtofile(context ).execute(  "LocationId: "+AV20LocationId.ToString()) ;
            new prc_logtofile(context ).execute(  "&OrganisationId: "+AV21OrganisationId.ToString()) ;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new prc_logtofile(context ).execute(  "Location Info: "+new prc_getlocationinformation(context).executeUdp(  Guid.Empty)) ;
         new prc_logtofile(context ).execute(  "User Info: "+new prc_getloggedinusername(context).executeUdp( )) ;
         new prc_logtofile(context ).execute(  "Org Info: "+new prc_getorganisationinformation(context).executeUdp(  Guid.Empty)) ;
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         AV8BC_Trn_Page.gxTpr_Trn_pagename = AV16PageName;
         AV8BC_Trn_Page.gxTpr_Pageispublished = false;
         AV8BC_Trn_Page.gxTpr_Locationid = AV20LocationId;
         AV8BC_Trn_Page.gxTpr_Organisationid = AV21OrganisationId;
         AV8BC_Trn_Page.gxTpr_Pagegjshtml = "";
         AV8BC_Trn_Page.gxTpr_Pagegjsjson = "";
         AV8BC_Trn_Page.gxTpr_Pageiscontentpage = false;
         AV8BC_Trn_Page.gxTv_SdtTrn_Page_Pagechildren_SetNull();
         AV8BC_Trn_Page.gxTv_SdtTrn_Page_Productserviceid_SetNull();
         AV8BC_Trn_Page.Save();
         new prc_logtofile(context ).execute(  "Something") ;
         if ( AV8BC_Trn_Page.Success() )
         {
            context.CommitDataStores("prc_createpage",pr_default);
         }
         else
         {
            AV24GXV2 = 1;
            AV23GXV1 = AV8BC_Trn_Page.GetMessages();
            while ( AV24GXV2 <= AV23GXV1.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV23GXV1.Item(AV24GXV2));
               new prc_logtofile(context ).execute(  AV9Message.gxTpr_Description) ;
               AV24GXV2 = (int)(AV24GXV2+1);
            }
         }
         AV17Response = AV8BC_Trn_Page.ToJSonString(true, true);
         new prc_logtofile(context ).execute(  AV17Response) ;
         cleanup();
         if (true) return;
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
         AV19UserName = "";
         GXt_char1 = "";
         P008V2_A93ReceptionistEmail = new string[] {""} ;
         P008V2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008V2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008V2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         A93ReceptionistEmail = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         AV20LocationId = Guid.Empty;
         AV21OrganisationId = Guid.Empty;
         AV8BC_Trn_Page = new SdtTrn_Page(context);
         AV23GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_createpage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_createpage__default(),
            new Object[][] {
                new Object[] {
               P008V2_A93ReceptionistEmail, P008V2_A29LocationId, P008V2_A11OrganisationId, P008V2_A89ReceptionistId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV24GXV2 ;
      private string GXt_char1 ;
      private string AV17Response ;
      private string AV16PageName ;
      private string AV19UserName ;
      private string A93ReceptionistEmail ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A89ReceptionistId ;
      private Guid AV20LocationId ;
      private Guid AV21OrganisationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP1_Response ;
      private IDataStoreProvider pr_default ;
      private string[] P008V2_A93ReceptionistEmail ;
      private Guid[] P008V2_A29LocationId ;
      private Guid[] P008V2_A11OrganisationId ;
      private Guid[] P008V2_A89ReceptionistId ;
      private SdtTrn_Page AV8BC_Trn_Page ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV23GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_createpage__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class prc_createpage__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP008V2;
        prmP008V2 = new Object[] {
        new ParDef("AV19UserName",GXType.VarChar,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("P008V2", "SELECT ReceptionistEmail, LocationId, OrganisationId, ReceptionistId FROM Trn_Receptionist WHERE ReceptionistEmail = ( RTRIM(LTRIM(:AV19UserName))) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V2,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              return;
     }
  }

}

}
