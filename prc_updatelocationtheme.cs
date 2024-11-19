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
   public class prc_updatelocationtheme : GXProcedure
   {
      public prc_updatelocationtheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatelocationtheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ThemeId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId ,
                           SdtSDT_Theme aP3_SDT_Theme )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         this.AV11SDT_Theme = aP3_SDT_Theme;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_ThemeId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 SdtSDT_Theme aP3_SDT_Theme )
      {
         this.AV8ThemeId = aP0_ThemeId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         this.AV11SDT_Theme = aP3_SDT_Theme;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12BC_Trn_Location.Load(AV9LocationId, AV10OrganisationId);
         new prc_logtofile(context ).execute(  AV12BC_Trn_Location.ToJSonString(true, true)) ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12BC_Trn_Location.gxTpr_Locationname)) )
         {
            AV12BC_Trn_Location.gxTpr_Trn_themeid = AV8ThemeId;
            AV12BC_Trn_Location.Save();
            if ( AV12BC_Trn_Location.Success() )
            {
               context.CommitDataStores("prc_updatelocationtheme",pr_default);
               new prc_logtofile(context ).execute(  "Saved") ;
            }
            else
            {
               AV15GXV2 = 1;
               AV14GXV1 = AV12BC_Trn_Location.GetMessages();
               while ( AV15GXV2 <= AV14GXV1.Count )
               {
                  AV13Message = ((GeneXus.Utils.SdtMessages_Message)AV14GXV1.Item(AV15GXV2));
                  new prc_logtofile(context ).execute(  AV13Message.gxTpr_Description) ;
                  AV15GXV2 = (int)(AV15GXV2+1);
               }
            }
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
         AV12BC_Trn_Location = new SdtTrn_Location(context);
         AV14GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV13Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationtheme__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatelocationtheme__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV15GXV2 ;
      private Guid AV8ThemeId ;
      private Guid AV9LocationId ;
      private Guid AV10OrganisationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Theme AV11SDT_Theme ;
      private SdtTrn_Location AV12BC_Trn_Location ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV14GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV13Message ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatelocationtheme__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updatelocationtheme__default : DataStoreHelperBase, IDataStoreHelper
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
