gx.evt.autoSkip=!1;gx.define("trn_auditgeneral",!0,function(n){this.ServerClass="trn_auditgeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="trn_auditgeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV12IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.A11OrganisationId=gx.fn.getControlValue("ORGANISATIONID");this.AV13IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE")};this.Valid_Auditid=function(){return this.validCliEvt("Valid_Auditid",0,function(){try{var n=gx.util.balloon.getNew("AUDITID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e137k2_client=function(){return this.executeServerEvent("'DOUPDATE'",!1,null,!1,!1)};this.e147k2_client=function(){return this.executeServerEvent("'DODELETE'",!1,null,!1,!1)};this.e157k2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e167k2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61];this.GXLastCtrlId=61;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEATTRIBUTES",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"guid",len:4,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Valid_Auditid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUDITID",fmt:0,gxz:"Z415AuditId",gxold:"O415AuditId",gxvar:"A415AuditId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A415AuditId=n)},v2z:function(n){n!==undefined&&(gx.O.Z415AuditId=n)},v2c:function(){gx.fn.setControlValue("AUDITID",gx.O.A415AuditId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A415AuditId=this.val())},val:function(){return gx.fn.getControlValue("AUDITID")},nac:gx.falseFn};this.declareDomainHdlr(14,function(){});t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,lvl:0,type:"dtime",len:8,dec:5,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUDITDATE",fmt:0,gxz:"Z416AuditDate",gxold:"O416AuditDate",gxvar:"A416AuditDate",dp:{f:0,st:!0,wn:!1,mf:!0,pic:"99/99/99 99:99",dec:5},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A416AuditDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z416AuditDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("AUDITDATE",gx.O.A416AuditDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A416AuditDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("AUDITDATE")},nac:gx.falseFn};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUDITTABLENAME",fmt:0,gxz:"Z417AuditTableName",gxold:"O417AuditTableName",gxvar:"A417AuditTableName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A417AuditTableName=n)},v2z:function(n){n!==undefined&&(gx.O.Z417AuditTableName=n)},v2c:function(){gx.fn.setControlValue("AUDITTABLENAME",gx.O.A417AuditTableName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A417AuditTableName=this.val())},val:function(){return gx.fn.getControlValue("AUDITTABLENAME")},nac:gx.falseFn};this.declareDomainHdlr(24,function(){});t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUDITDESCRIPTION",fmt:0,gxz:"Z418AuditDescription",gxold:"O418AuditDescription",gxvar:"A418AuditDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A418AuditDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z418AuditDescription=n)},v2c:function(){gx.fn.setControlValue("AUDITDESCRIPTION",gx.O.A418AuditDescription,0)},c2v:function(){this.val()!==undefined&&(gx.O.A418AuditDescription=this.val())},val:function(){return gx.fn.getControlValue("AUDITDESCRIPTION")},nac:gx.falseFn};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,fld:"",grid:0};t[34]={id:34,lvl:0,type:"svchar",len:400,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUDITSHORTDESCRIPTION",fmt:0,gxz:"Z419AuditShortDescription",gxold:"O419AuditShortDescription",gxvar:"A419AuditShortDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A419AuditShortDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z419AuditShortDescription=n)},v2c:function(){gx.fn.setControlValue("AUDITSHORTDESCRIPTION",gx.O.A419AuditShortDescription,0)},c2v:function(){this.val()!==undefined&&(gx.O.A419AuditShortDescription=this.val())},val:function(){return gx.fn.getControlValue("AUDITSHORTDESCRIPTION")},nac:gx.falseFn};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,fld:"",grid:0};t[39]={id:39,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"GAMUSERID",fmt:0,gxz:"Z420GAMUserId",gxold:"O420GAMUserId",gxvar:"A420GAMUserId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A420GAMUserId=n)},v2z:function(n){n!==undefined&&(gx.O.Z420GAMUserId=n)},v2c:function(){gx.fn.setControlValue("GAMUSERID",gx.O.A420GAMUserId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A420GAMUserId=this.val())},val:function(){return gx.fn.getControlValue("GAMUSERID")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"",grid:0};t[43]={id:43,fld:"",grid:0};t[44]={id:44,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUDITUSERNAME",fmt:0,gxz:"Z421AuditUserName",gxold:"O421AuditUserName",gxvar:"A421AuditUserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A421AuditUserName=n)},v2z:function(n){n!==undefined&&(gx.O.Z421AuditUserName=n)},v2c:function(){gx.fn.setControlValue("AUDITUSERNAME",gx.O.A421AuditUserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A421AuditUserName=this.val())},val:function(){return gx.fn.getControlValue("AUDITUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,fld:"",grid:0};t[49]={id:49,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AUDITACTION",fmt:0,gxz:"Z422AuditAction",gxold:"O422AuditAction",gxvar:"A422AuditAction",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A422AuditAction=n)},v2z:function(n){n!==undefined&&(gx.O.Z422AuditAction=n)},v2c:function(){gx.fn.setControlValue("AUDITACTION",gx.O.A422AuditAction,0)},c2v:function(){this.val()!==undefined&&(gx.O.A422AuditAction=this.val())},val:function(){return gx.fn.getControlValue("AUDITACTION")},nac:gx.falseFn};t[50]={id:50,fld:"",grid:0};t[51]={id:51,fld:"",grid:0};t[52]={id:52,fld:"",grid:0};t[53]={id:53,fld:"",grid:0};t[54]={id:54,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORGANISATIONNAME",fmt:0,gxz:"Z13OrganisationName",gxold:"O13OrganisationName",gxvar:"A13OrganisationName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A13OrganisationName=n)},v2z:function(n){n!==undefined&&(gx.O.Z13OrganisationName=n)},v2c:function(){gx.fn.setControlValue("ORGANISATIONNAME",gx.O.A13OrganisationName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A13OrganisationName=this.val())},val:function(){return gx.fn.getControlValue("ORGANISATIONNAME")},nac:gx.falseFn};this.declareDomainHdlr(54,function(){});t[55]={id:55,fld:"",grid:0};t[56]={id:56,fld:"",grid:0};t[57]={id:57,fld:"",grid:0};t[58]={id:58,fld:"",grid:0};t[59]={id:59,fld:"BTNUPDATE",grid:0,evt:"e137k2_client"};t[60]={id:60,fld:"",grid:0};t[61]={id:61,fld:"BTNDELETE",grid:0,evt:"e147k2_client"};this.A415AuditId="00000000-0000-0000-0000-000000000000";this.Z415AuditId="00000000-0000-0000-0000-000000000000";this.O415AuditId="00000000-0000-0000-0000-000000000000";this.A416AuditDate=gx.date.nullDate();this.Z416AuditDate=gx.date.nullDate();this.O416AuditDate=gx.date.nullDate();this.A417AuditTableName="";this.Z417AuditTableName="";this.O417AuditTableName="";this.A418AuditDescription="";this.Z418AuditDescription="";this.O418AuditDescription="";this.A419AuditShortDescription="";this.Z419AuditShortDescription="";this.O419AuditShortDescription="";this.A420GAMUserId="";this.Z420GAMUserId="";this.O420GAMUserId="";this.A421AuditUserName="";this.Z421AuditUserName="";this.O421AuditUserName="";this.A422AuditAction="";this.Z422AuditAction="";this.O422AuditAction="";this.A13OrganisationName="";this.Z13OrganisationName="";this.O13OrganisationName="";this.A415AuditId="00000000-0000-0000-0000-000000000000";this.A416AuditDate=gx.date.nullDate();this.A417AuditTableName="";this.A418AuditDescription="";this.A419AuditShortDescription="";this.A420GAMUserId="";this.A421AuditUserName="";this.A422AuditAction="";this.A13OrganisationName="";this.A11OrganisationId="00000000-0000-0000-0000-000000000000";this.AV12IsAuthorized_Update=!1;this.AV13IsAuthorized_Delete=!1;this.Events={e137k2_client:["'DOUPDATE'",!0],e147k2_client:["'DODELETE'",!0],e157k2_client:["ENTER",!0],e167k2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A415AuditId",fld:"AUDITID"},{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"A11OrganisationId",fld:"ORGANISATIONID",hsh:!0}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"A415AuditId",fld:"AUDITID"},{av:"A11OrganisationId",fld:"ORGANISATIONID",hsh:!0}],[{ctrl:"BTNUPDATE",prop:"Visible"}]];this.EvtParms["'DODELETE'"]=[[{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"A415AuditId",fld:"AUDITID"},{av:"A11OrganisationId",fld:"ORGANISATIONID",hsh:!0}],[{ctrl:"BTNDELETE",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_AUDITID=[[],[]];this.setVCMap("AV12IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("A11OrganisationId","ORGANISATIONID",0,"guid",4,0);this.setVCMap("AV13IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.Initialize()})