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
   public class prc_updategamuseraccount : GXProcedure
   {
      public prc_updategamuseraccount( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updategamuseraccount( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserGAMGUID ,
                           string aP1_GivenName ,
                           string aP2_LastName ,
                           out string aP3_GAMErrorResponse )
      {
         this.AV12UserGAMGUID = aP0_UserGAMGUID;
         this.AV10GivenName = aP1_GivenName;
         this.AV11LastName = aP2_LastName;
         this.AV8GAMErrorResponse = "" ;
         initialize();
         ExecuteImpl();
         aP3_GAMErrorResponse=this.AV8GAMErrorResponse;
      }

      public string executeUdp( string aP0_UserGAMGUID ,
                                string aP1_GivenName ,
                                string aP2_LastName )
      {
         execute(aP0_UserGAMGUID, aP1_GivenName, aP2_LastName, out aP3_GAMErrorResponse);
         return AV8GAMErrorResponse ;
      }

      public void executeSubmit( string aP0_UserGAMGUID ,
                                 string aP1_GivenName ,
                                 string aP2_LastName ,
                                 out string aP3_GAMErrorResponse )
      {
         this.AV12UserGAMGUID = aP0_UserGAMGUID;
         this.AV10GivenName = aP1_GivenName;
         this.AV11LastName = aP2_LastName;
         this.AV8GAMErrorResponse = "" ;
         SubmitImpl();
         aP3_GAMErrorResponse=this.AV8GAMErrorResponse;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GAMUser.load( AV12UserGAMGUID);
         AV9GAMUser.gxTpr_Firstname = AV10GivenName;
         AV9GAMUser.gxTpr_Lastname = AV11LastName;
         AV9GAMUser.save();
         if ( AV9GAMUser.success() )
         {
            context.CommitDataStores("prc_updategamuseraccount",pr_default);
         }
         else
         {
            AV8GAMErrorResponse = AV9GAMUser.geterrors().ToJSonString(false);
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
         AV8GAMErrorResponse = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updategamuseraccount__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updategamuseraccount__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV8GAMErrorResponse ;
      private string AV12UserGAMGUID ;
      private string AV10GivenName ;
      private string AV11LastName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private IDataStoreProvider pr_default ;
      private string aP3_GAMErrorResponse ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updategamuseraccount__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updategamuseraccount__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
