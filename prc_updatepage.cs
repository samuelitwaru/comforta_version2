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
   public class prc_updatepage : GXProcedure
   {
      public prc_updatepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_PageId ,
                           ref string aP1_PageJsonContent ,
                           ref string aP2_PageGJSHtml ,
                           ref string aP3_PageGJSJson ,
                           ref bool aP4_PageIsPublished ,
                           out string aP5_Response )
      {
         this.AV8PageId = aP0_PageId;
         this.AV12PageJsonContent = aP1_PageJsonContent;
         this.AV13PageGJSHtml = aP2_PageGJSHtml;
         this.AV11PageGJSJson = aP3_PageGJSJson;
         this.AV17PageIsPublished = aP4_PageIsPublished;
         this.AV10Response = "" ;
         initialize();
         ExecuteImpl();
         aP0_PageId=this.AV8PageId;
         aP1_PageJsonContent=this.AV12PageJsonContent;
         aP2_PageGJSHtml=this.AV13PageGJSHtml;
         aP3_PageGJSJson=this.AV11PageGJSJson;
         aP4_PageIsPublished=this.AV17PageIsPublished;
         aP5_Response=this.AV10Response;
      }

      public string executeUdp( ref Guid aP0_PageId ,
                                ref string aP1_PageJsonContent ,
                                ref string aP2_PageGJSHtml ,
                                ref string aP3_PageGJSJson ,
                                ref bool aP4_PageIsPublished )
      {
         execute(ref aP0_PageId, ref aP1_PageJsonContent, ref aP2_PageGJSHtml, ref aP3_PageGJSJson, ref aP4_PageIsPublished, out aP5_Response);
         return AV10Response ;
      }

      public void executeSubmit( ref Guid aP0_PageId ,
                                 ref string aP1_PageJsonContent ,
                                 ref string aP2_PageGJSHtml ,
                                 ref string aP3_PageGJSJson ,
                                 ref bool aP4_PageIsPublished ,
                                 out string aP5_Response )
      {
         this.AV8PageId = aP0_PageId;
         this.AV12PageJsonContent = aP1_PageJsonContent;
         this.AV13PageGJSHtml = aP2_PageGJSHtml;
         this.AV11PageGJSJson = aP3_PageGJSJson;
         this.AV17PageIsPublished = aP4_PageIsPublished;
         this.AV10Response = "" ;
         SubmitImpl();
         aP0_PageId=this.AV8PageId;
         aP1_PageJsonContent=this.AV12PageJsonContent;
         aP2_PageGJSHtml=this.AV13PageGJSHtml;
         aP3_PageGJSJson=this.AV11PageGJSJson;
         aP4_PageIsPublished=this.AV17PageIsPublished;
         aP5_Response=this.AV10Response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9BC_Trn_Page.Load(AV8PageId);
         new prc_logtofile(context ).execute(  ">>>>>>"+AV12PageJsonContent) ;
         if ( ! (Guid.Empty==AV9BC_Trn_Page.gxTpr_Trn_pageid) )
         {
            AV9BC_Trn_Page.gxTpr_Pagegjsjson = AV11PageGJSJson;
            if ( AV17PageIsPublished )
            {
               AV9BC_Trn_Page.gxTpr_Pagejsoncontent = AV12PageJsonContent;
               AV9BC_Trn_Page.gxTpr_Pageispublished = AV17PageIsPublished;
            }
            AV9BC_Trn_Page.gxTpr_Pagegjshtml = AV13PageGJSHtml;
            AV9BC_Trn_Page.Save();
            if ( AV9BC_Trn_Page.Success() )
            {
               AV10Response = context.GetMessage( "Page Save Successfully", "");
               context.CommitDataStores("prc_updatepage",pr_default);
            }
            else
            {
               AV19GXV2 = 1;
               AV18GXV1 = AV9BC_Trn_Page.GetMessages();
               while ( AV19GXV2 <= AV18GXV1.Count )
               {
                  AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV18GXV1.Item(AV19GXV2));
                  new prc_logtofile(context ).execute(  AV14Message.gxTpr_Description) ;
                  AV19GXV2 = (int)(AV19GXV2+1);
               }
            }
         }
         else
         {
            AV10Response = context.GetMessage( "Page Not Found", "");
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
         AV10Response = "";
         AV9BC_Trn_Page = new SdtTrn_Page(context);
         AV18GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepage__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV19GXV2 ;
      private bool AV17PageIsPublished ;
      private string AV12PageJsonContent ;
      private string AV13PageGJSHtml ;
      private string AV11PageGJSJson ;
      private string AV10Response ;
      private Guid AV8PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_PageId ;
      private string aP1_PageJsonContent ;
      private string aP2_PageGJSHtml ;
      private string aP3_PageGJSJson ;
      private bool aP4_PageIsPublished ;
      private SdtTrn_Page AV9BC_Trn_Page ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV18GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private string aP5_Response ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatepage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
       return "DATASTORE1";
    }

 }

 public class prc_updatepage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updatepage__default : DataStoreHelperBase, IDataStoreHelper
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
