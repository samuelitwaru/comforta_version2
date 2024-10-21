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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_sendnotification : GXProcedure
   {
      public wwp_sendnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sendnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPNotificationDefinitionName ,
                           string aP1_WWPEntityName ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_pWWPNotificationDefinitionIcon ,
                           string aP4_pWWPNotificationDefinitionTitle ,
                           string aP5_pWWPNotificationDefinitionShortDescription ,
                           string aP6_pWWPNotificationDefinitionLongDescription ,
                           string aP7_pWWPNotificationDefinitionLink ,
                           string aP8_WWPNotificationMetadata ,
                           string aP9_ExcludedWWPUserExtendedIdCollectionJson ,
                           bool aP10_MakeCommit )
      {
         this.AV23WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV18WWPEntityName = aP1_WWPEntityName;
         this.AV27WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV13pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         this.AV17pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         this.AV16pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         this.AV15pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         this.AV14pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         this.AV26WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         this.AV11ExcludedWWPUserExtendedIdCollectionJson = aP9_ExcludedWWPUserExtendedIdCollectionJson;
         this.AV9MakeCommit = aP10_MakeCommit;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_pWWPNotificationDefinitionIcon ,
                                 string aP4_pWWPNotificationDefinitionTitle ,
                                 string aP5_pWWPNotificationDefinitionShortDescription ,
                                 string aP6_pWWPNotificationDefinitionLongDescription ,
                                 string aP7_pWWPNotificationDefinitionLink ,
                                 string aP8_WWPNotificationMetadata ,
                                 string aP9_ExcludedWWPUserExtendedIdCollectionJson ,
                                 bool aP10_MakeCommit )
      {
         this.AV23WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV18WWPEntityName = aP1_WWPEntityName;
         this.AV27WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV13pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         this.AV17pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         this.AV16pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         this.AV15pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         this.AV14pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         this.AV26WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         this.AV11ExcludedWWPUserExtendedIdCollectionJson = aP9_ExcludedWWPUserExtendedIdCollectionJson;
         this.AV9MakeCommit = aP10_MakeCommit;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11ExcludedWWPUserExtendedIdCollectionJson)) )
         {
            AV10ExcludedWWPUserExtendedIdCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         }
         else
         {
            AV10ExcludedWWPUserExtendedIdCollection.FromJSonString(AV11ExcludedWWPUserExtendedIdCollectionJson, null);
         }
         AV10ExcludedWWPUserExtendedIdCollection.Add(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ), 0);
         AV29Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV18WWPEntityName);
         /* Using cursor P003K2 */
         pr_default.execute(0, new Object[] {AV29Udparg1, AV23WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A128WWPNotificationDefinitionId = P003K2_A128WWPNotificationDefinitionId[0];
            A125WWPEntityId = P003K2_A125WWPEntityId[0];
            A164WWPNotificationDefinitionName = P003K2_A164WWPNotificationDefinitionName[0];
            A167WWPNotificationDefinitionIcon = P003K2_A167WWPNotificationDefinitionIcon[0];
            A168WWPNotificationDefinitionTitle = P003K2_A168WWPNotificationDefinitionTitle[0];
            A169WWPNotificationDefinitionShort = P003K2_A169WWPNotificationDefinitionShort[0];
            A170WWPNotificationDefinitionLongD = P003K2_A170WWPNotificationDefinitionLongD[0];
            A171WWPNotificationDefinitionLink = P003K2_A171WWPNotificationDefinitionLink[0];
            AV20WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13pWWPNotificationDefinitionIcon)) )
            {
               AV19WWPNotificationDefinitionIcon = A167WWPNotificationDefinitionIcon;
            }
            else
            {
               AV19WWPNotificationDefinitionIcon = AV13pWWPNotificationDefinitionIcon;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17pWWPNotificationDefinitionTitle)) )
            {
               AV25WWPNotificationDefinitionTitle = A168WWPNotificationDefinitionTitle;
            }
            else
            {
               AV25WWPNotificationDefinitionTitle = AV17pWWPNotificationDefinitionTitle;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16pWWPNotificationDefinitionShortDescription)) )
            {
               AV24WWPNotificationDefinitionShortDescription = A169WWPNotificationDefinitionShort;
            }
            else
            {
               AV24WWPNotificationDefinitionShortDescription = AV16pWWPNotificationDefinitionShortDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15pWWPNotificationDefinitionLongDescription)) )
            {
               AV22WWPNotificationDefinitionLongDescription = A170WWPNotificationDefinitionLongD;
            }
            else
            {
               AV22WWPNotificationDefinitionLongDescription = AV15pWWPNotificationDefinitionLongDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14pWWPNotificationDefinitionLink)) )
            {
               AV21WWPNotificationDefinitionLink = A171WWPNotificationDefinitionLink;
            }
            else
            {
               AV21WWPNotificationDefinitionLink = AV14pWWPNotificationDefinitionLink;
            }
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV27WWPSubscriptionEntityRecordId ,
                                                 A131WWPSubscriptionEntityRecordId ,
                                                 A128WWPNotificationDefinitionId } ,
                                                 new int[]{
                                                 TypeConstants.LONG
                                                 }
            });
            /* Using cursor P003K3 */
            pr_default.execute(1, new Object[] {A128WWPNotificationDefinitionId, AV27WWPSubscriptionEntityRecordId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A131WWPSubscriptionEntityRecordId = P003K3_A131WWPSubscriptionEntityRecordId[0];
               A112WWPUserExtendedId = P003K3_A112WWPUserExtendedId[0];
               n112WWPUserExtendedId = P003K3_n112WWPUserExtendedId[0];
               A132WWPSubscriptionSubscribed = P003K3_A132WWPSubscriptionSubscribed[0];
               A124WWPSubscriptionRoleId = P003K3_A124WWPSubscriptionRoleId[0];
               n124WWPSubscriptionRoleId = P003K3_n124WWPSubscriptionRoleId[0];
               A130WWPSubscriptionId = P003K3_A130WWPSubscriptionId[0];
               if ( ! ( (AV10ExcludedWWPUserExtendedIdCollection.IndexOf(StringUtil.RTrim( A112WWPUserExtendedId))>0) ) )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) && A132WWPSubscriptionSubscribed )
                  {
                     AV8WWPUserExtendedId = A112WWPUserExtendedId;
                     new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser(context ).execute(  AV8WWPUserExtendedId,  AV20WWPNotificationDefinitionId,  AV25WWPNotificationDefinitionTitle,  AV24WWPNotificationDefinitionShortDescription,  AV22WWPNotificationDefinitionLongDescription, ref  AV21WWPNotificationDefinitionLink,  AV26WWPNotificationMetadata,  AV19WWPNotificationDefinitionIcon,  StringUtil.StartsWith( AV23WWPNotificationDefinitionName, context.GetMessage( "Discussion", ""))) ;
                  }
                  else
                  {
                     AV32GXV2 = 1;
                     GXt_objcol_char1 = AV31GXV1;
                     new GeneXus.Programs.wwpbaseobjects.wwp_getusersfromrole(context ).execute(  A124WWPSubscriptionRoleId, out  GXt_objcol_char1) ;
                     AV31GXV1 = GXt_objcol_char1;
                     while ( AV32GXV2 <= AV31GXV1.Count )
                     {
                        AV8WWPUserExtendedId = AV31GXV1.GetString(AV32GXV2);
                        /* Execute user subroutine: 'INCLUDENOTIFICATIONTOUSER' */
                        S111 ();
                        if ( returnInSub )
                        {
                           pr_default.close(1);
                           cleanup();
                           if (true) return;
                        }
                        if ( AV12IncludeNotificationToUser )
                        {
                           new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser(context ).execute(  AV8WWPUserExtendedId,  AV20WWPNotificationDefinitionId,  AV25WWPNotificationDefinitionTitle,  AV24WWPNotificationDefinitionShortDescription,  AV22WWPNotificationDefinitionLongDescription, ref  AV21WWPNotificationDefinitionLink,  AV26WWPNotificationMetadata,  AV19WWPNotificationDefinitionIcon,  StringUtil.StartsWith( AV23WWPNotificationDefinitionName, context.GetMessage( "Discussion", ""))) ;
                        }
                        AV32GXV2 = (int)(AV32GXV2+1);
                     }
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9MakeCommit )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_sendnotification",pr_default);
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendpendingnotifications(context).executeSubmit( ) ;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'INCLUDENOTIFICATIONTOUSER' Routine */
         returnInSub = false;
         /* Using cursor P003K5 */
         pr_default.execute(2, new Object[] {AV20WWPNotificationDefinitionId, AV8WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = P003K5_A40000GXC1[0];
            n40000GXC1 = P003K5_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(2);
         AV12IncludeNotificationToUser = (bool)((A40000GXC1==0));
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

      protected override void CloseCursors( )
      {
      }

      public override void initialize( )
      {
         AV10ExcludedWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         P003K2_A128WWPNotificationDefinitionId = new long[1] ;
         P003K2_A125WWPEntityId = new long[1] ;
         P003K2_A164WWPNotificationDefinitionName = new string[] {""} ;
         P003K2_A167WWPNotificationDefinitionIcon = new string[] {""} ;
         P003K2_A168WWPNotificationDefinitionTitle = new string[] {""} ;
         P003K2_A169WWPNotificationDefinitionShort = new string[] {""} ;
         P003K2_A170WWPNotificationDefinitionLongD = new string[] {""} ;
         P003K2_A171WWPNotificationDefinitionLink = new string[] {""} ;
         A164WWPNotificationDefinitionName = "";
         A167WWPNotificationDefinitionIcon = "";
         A168WWPNotificationDefinitionTitle = "";
         A169WWPNotificationDefinitionShort = "";
         A170WWPNotificationDefinitionLongD = "";
         A171WWPNotificationDefinitionLink = "";
         AV19WWPNotificationDefinitionIcon = "";
         AV25WWPNotificationDefinitionTitle = "";
         AV24WWPNotificationDefinitionShortDescription = "";
         AV22WWPNotificationDefinitionLongDescription = "";
         AV21WWPNotificationDefinitionLink = "";
         A131WWPSubscriptionEntityRecordId = "";
         P003K3_A128WWPNotificationDefinitionId = new long[1] ;
         P003K3_A131WWPSubscriptionEntityRecordId = new string[] {""} ;
         P003K3_A112WWPUserExtendedId = new string[] {""} ;
         P003K3_n112WWPUserExtendedId = new bool[] {false} ;
         P003K3_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         P003K3_A124WWPSubscriptionRoleId = new string[] {""} ;
         P003K3_n124WWPSubscriptionRoleId = new bool[] {false} ;
         P003K3_A130WWPSubscriptionId = new long[1] ;
         A112WWPUserExtendedId = "";
         A124WWPSubscriptionRoleId = "";
         AV8WWPUserExtendedId = "";
         AV31GXV1 = new GxSimpleCollection<string>();
         GXt_objcol_char1 = new GxSimpleCollection<string>();
         P003K5_A40000GXC1 = new int[1] ;
         P003K5_n40000GXC1 = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification__default(),
            new Object[][] {
                new Object[] {
               P003K2_A128WWPNotificationDefinitionId, P003K2_A125WWPEntityId, P003K2_A164WWPNotificationDefinitionName, P003K2_A167WWPNotificationDefinitionIcon, P003K2_A168WWPNotificationDefinitionTitle, P003K2_A169WWPNotificationDefinitionShort, P003K2_A170WWPNotificationDefinitionLongD, P003K2_A171WWPNotificationDefinitionLink
               }
               , new Object[] {
               P003K3_A128WWPNotificationDefinitionId, P003K3_A131WWPSubscriptionEntityRecordId, P003K3_A112WWPUserExtendedId, P003K3_n112WWPUserExtendedId, P003K3_A132WWPSubscriptionSubscribed, P003K3_A124WWPSubscriptionRoleId, P003K3_n124WWPSubscriptionRoleId, P003K3_A130WWPSubscriptionId
               }
               , new Object[] {
               P003K5_A40000GXC1, P003K5_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV32GXV2 ;
      private int A40000GXC1 ;
      private long AV29Udparg1 ;
      private long A128WWPNotificationDefinitionId ;
      private long A125WWPEntityId ;
      private long AV20WWPNotificationDefinitionId ;
      private long A130WWPSubscriptionId ;
      private string A112WWPUserExtendedId ;
      private string A124WWPSubscriptionRoleId ;
      private string AV8WWPUserExtendedId ;
      private bool AV9MakeCommit ;
      private bool n112WWPUserExtendedId ;
      private bool A132WWPSubscriptionSubscribed ;
      private bool n124WWPSubscriptionRoleId ;
      private bool returnInSub ;
      private bool AV12IncludeNotificationToUser ;
      private bool n40000GXC1 ;
      private string AV26WWPNotificationMetadata ;
      private string AV11ExcludedWWPUserExtendedIdCollectionJson ;
      private string AV23WWPNotificationDefinitionName ;
      private string AV18WWPEntityName ;
      private string AV27WWPSubscriptionEntityRecordId ;
      private string AV13pWWPNotificationDefinitionIcon ;
      private string AV17pWWPNotificationDefinitionTitle ;
      private string AV16pWWPNotificationDefinitionShortDescription ;
      private string AV15pWWPNotificationDefinitionLongDescription ;
      private string AV14pWWPNotificationDefinitionLink ;
      private string A164WWPNotificationDefinitionName ;
      private string A167WWPNotificationDefinitionIcon ;
      private string A168WWPNotificationDefinitionTitle ;
      private string A169WWPNotificationDefinitionShort ;
      private string A170WWPNotificationDefinitionLongD ;
      private string A171WWPNotificationDefinitionLink ;
      private string AV19WWPNotificationDefinitionIcon ;
      private string AV25WWPNotificationDefinitionTitle ;
      private string AV24WWPNotificationDefinitionShortDescription ;
      private string AV22WWPNotificationDefinitionLongDescription ;
      private string AV21WWPNotificationDefinitionLink ;
      private string A131WWPSubscriptionEntityRecordId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV10ExcludedWWPUserExtendedIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P003K2_A128WWPNotificationDefinitionId ;
      private long[] P003K2_A125WWPEntityId ;
      private string[] P003K2_A164WWPNotificationDefinitionName ;
      private string[] P003K2_A167WWPNotificationDefinitionIcon ;
      private string[] P003K2_A168WWPNotificationDefinitionTitle ;
      private string[] P003K2_A169WWPNotificationDefinitionShort ;
      private string[] P003K2_A170WWPNotificationDefinitionLongD ;
      private string[] P003K2_A171WWPNotificationDefinitionLink ;
      private long[] P003K3_A128WWPNotificationDefinitionId ;
      private string[] P003K3_A131WWPSubscriptionEntityRecordId ;
      private string[] P003K3_A112WWPUserExtendedId ;
      private bool[] P003K3_n112WWPUserExtendedId ;
      private bool[] P003K3_A132WWPSubscriptionSubscribed ;
      private string[] P003K3_A124WWPSubscriptionRoleId ;
      private bool[] P003K3_n124WWPSubscriptionRoleId ;
      private long[] P003K3_A130WWPSubscriptionId ;
      private GxSimpleCollection<string> AV31GXV1 ;
      private GxSimpleCollection<string> GXt_objcol_char1 ;
      private int[] P003K5_A40000GXC1 ;
      private bool[] P003K5_n40000GXC1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_sendnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sendnotification__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P003K3( IGxContext context ,
                                           string AV27WWPSubscriptionEntityRecordId ,
                                           string A131WWPSubscriptionEntityRecordId ,
                                           long A128WWPNotificationDefinitionId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int2 = new short[2];
       Object[] GXv_Object3 = new Object[2];
       scmdbuf = "SELECT WWPNotificationDefinitionId, WWPSubscriptionEntityRecordId, WWPUserExtendedId, WWPSubscriptionSubscribed, WWPSubscriptionRoleId, WWPSubscriptionId FROM WWP_Subscription";
       AddWhere(sWhereString, "(WWPNotificationDefinitionId = :WWPNotificationDefinitionId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27WWPSubscriptionEntityRecordId)) )
       {
          AddWhere(sWhereString, "(WWPSubscriptionEntityRecordId = ( :AV27WWPSubscriptionEntityRecordId))");
       }
       else
       {
          GXv_int2[1] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY WWPNotificationDefinitionId";
       GXv_Object3[0] = scmdbuf;
       GXv_Object3[1] = GXv_int2;
       return GXv_Object3 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 1 :
                   return conditional_P003K3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP003K2;
        prmP003K2 = new Object[] {
        new ParDef("AV29Udparg1",GXType.Int64,10,0) ,
        new ParDef("AV23WWPNotificationDefinitionName",GXType.VarChar,100,0)
        };
        Object[] prmP003K5;
        prmP003K5 = new Object[] {
        new ParDef("AV20WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("AV8WWPUserExtendedId",GXType.Char,40,0)
        };
        Object[] prmP003K3;
        prmP003K3 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("AV27WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0)
        };
        def= new CursorDef[] {
            new CursorDef("P003K2", "SELECT WWPNotificationDefinitionId, WWPEntityId, WWPNotificationDefinitionName, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV29Udparg1) AND (WWPNotificationDefinitionName = ( :AV23WWPNotificationDefinitionName)) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P003K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K3,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P003K5", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM (WWP_Subscription T2 INNER JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE (T2.WWPNotificationDefinitionId = :AV20WWPNotificationDefinitionId) AND (T2.WWPUserExtendedId = ( :AV8WWPUserExtendedId)) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K5,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 40);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((long[]) buf[7])[0] = rslt.getLong(6);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
     }
  }

}

}
