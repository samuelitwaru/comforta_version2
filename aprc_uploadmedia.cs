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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_uploadmedia : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_uploadmedia().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         Guid aP0_MediaId = new Guid()  ;
         string aP1_MediaName = new string(' ',0)  ;
         string aP2_MediaImageData = new string(' ',0)  ;
          int aP3_MediaSize ;
         string aP4_MediaType = new string(' ',0)  ;
         string aP5_response = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_MediaId=((Guid)(StringUtil.StrToGuid( (string)(args[0]))));
         }
         else
         {
            aP0_MediaId=Guid.Empty;
         }
         if ( 1 < args.Length )
         {
            aP1_MediaName=((string)(args[1]));
         }
         else
         {
            aP1_MediaName="";
         }
         if ( 2 < args.Length )
         {
            aP2_MediaImageData=((string)(args[2]));
         }
         else
         {
            aP2_MediaImageData="";
         }
         if ( 3 < args.Length )
         {
            aP3_MediaSize=((int)(NumberUtil.Val( (string)(args[3]), ".")));
         }
         else
         {
            aP3_MediaSize=0;
         }
         if ( 4 < args.Length )
         {
            aP4_MediaType=((string)(args[4]));
         }
         else
         {
            aP4_MediaType="";
         }
         if ( 5 < args.Length )
         {
            aP5_response=((string)(args[5]));
         }
         else
         {
            aP5_response="";
         }
         execute(aP0_MediaId, aP1_MediaName, aP2_MediaImageData, aP3_MediaSize, aP4_MediaType, out aP5_response);
         return GX.GXRuntime.ExitCode ;
      }

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

      public aprc_uploadmedia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_uploadmedia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MediaId ,
                           string aP1_MediaName ,
                           string aP2_MediaImageData ,
                           int aP3_MediaSize ,
                           string aP4_MediaType ,
                           out string aP5_response )
      {
         this.AV11MediaId = aP0_MediaId;
         this.AV12MediaName = aP1_MediaName;
         this.AV18MediaImageData = aP2_MediaImageData;
         this.AV20MediaSize = aP3_MediaSize;
         this.AV21MediaType = aP4_MediaType;
         this.AV10response = "" ;
         initialize();
         ExecuteImpl();
         aP5_response=this.AV10response;
      }

      public string executeUdp( Guid aP0_MediaId ,
                                string aP1_MediaName ,
                                string aP2_MediaImageData ,
                                int aP3_MediaSize ,
                                string aP4_MediaType )
      {
         execute(aP0_MediaId, aP1_MediaName, aP2_MediaImageData, aP3_MediaSize, aP4_MediaType, out aP5_response);
         return AV10response ;
      }

      public void executeSubmit( Guid aP0_MediaId ,
                                 string aP1_MediaName ,
                                 string aP2_MediaImageData ,
                                 int aP3_MediaSize ,
                                 string aP4_MediaType ,
                                 out string aP5_response )
      {
         this.AV11MediaId = aP0_MediaId;
         this.AV12MediaName = aP1_MediaName;
         this.AV18MediaImageData = aP2_MediaImageData;
         this.AV20MediaSize = aP3_MediaSize;
         this.AV21MediaType = aP4_MediaType;
         this.AV10response = "" ;
         SubmitImpl();
         aP5_response=this.AV10response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14BC_Trn_Media = new SdtTrn_Media(context);
         AV14BC_Trn_Media.gxTpr_Medianame = AV12MediaName;
         AV14BC_Trn_Media.gxTpr_Mediasize = AV20MediaSize;
         AV14BC_Trn_Media.gxTpr_Mediatype = AV21MediaType;
         AV23MediaUrl = StringUtil.StringReplace( AV8HttpRequest.BaseURL, context.GetMessage( "api/media/", ""), context.GetMessage( "media/", "")+AV12MediaName);
         if ( StringUtil.StartsWith( AV8HttpRequest.BaseURL, context.GetMessage( "http://localhost", "")) )
         {
         }
         else
         {
            AV23MediaUrl = StringUtil.StringReplace( AV23MediaUrl, context.GetMessage( "http://", ""), context.GetMessage( "https://", ""));
         }
         new prc_logtofile(context ).execute(  ">>>>>>>>>>>>>>>>>>>>>>>>>"+AV23MediaUrl) ;
         AV14BC_Trn_Media.gxTpr_Mediaurl = AV23MediaUrl;
         AV14BC_Trn_Media.Save();
         if ( AV14BC_Trn_Media.Success() )
         {
            AV22Path = "";
            if ( StringUtil.StartsWith( AV8HttpRequest.BaseURL, context.GetMessage( "http", "")) )
            {
               AV22Path = context.GetMessage( "C:\\KBs\\Comforta_version2\\Data018\\Web\\media\\", "");
            }
            new SdtEO_Base64Image(context).saveimage(AV18MediaImageData, AV22Path+AV12MediaName) ;
            new prc_logtofile(context ).execute(  AV22Path+AV12MediaName) ;
            AV10response = AV14BC_Trn_Media.ToJSonString(true, true);
            context.CommitDataStores("prc_uploadmedia",pr_default);
         }
         else
         {
            AV25GXV2 = 1;
            AV24GXV1 = AV14BC_Trn_Media.GetMessages();
            while ( AV25GXV2 <= AV24GXV1.Count )
            {
               AV17Message = ((GeneXus.Utils.SdtMessages_Message)AV24GXV1.Item(AV25GXV2));
               new prc_logtofile(context ).execute(  AV17Message.gxTpr_Description) ;
               AV25GXV2 = (int)(AV25GXV2+1);
            }
            AV10response = context.GetMessage( "Insert ERROR", "");
            context.RollbackDataStores("prc_uploadmedia",pr_default);
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
         AV10response = "";
         AV14BC_Trn_Media = new SdtTrn_Media(context);
         AV23MediaUrl = "";
         AV8HttpRequest = new GxHttpRequest( context);
         AV22Path = "";
         AV24GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_uploadmedia__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_uploadmedia__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV20MediaSize ;
      private int AV25GXV2 ;
      private string AV21MediaType ;
      private string AV18MediaImageData ;
      private string AV10response ;
      private string AV12MediaName ;
      private string AV23MediaUrl ;
      private string AV22Path ;
      private Guid AV11MediaId ;
      private GxHttpRequest AV8HttpRequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Media AV14BC_Trn_Media ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV24GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV17Message ;
      private string aP5_response ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_uploadmedia__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_uploadmedia__default : DataStoreHelperBase, IDataStoreHelper
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
