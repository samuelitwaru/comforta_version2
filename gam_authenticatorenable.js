gx.evt.autoSkip=!1;gx.define("gam_authenticatorenable",!1,function(){this.ServerClass="gam_authenticatorenable";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_authenticatorenable.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){};this.s122_client=function(){return this.executeClientEvent(function(){this.createWebComponent("Wcmessages","GAM_Messages",[])},arguments)};this.e113a1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("gam_myaccount.aspx",["DSP"],null,["Mode"]);this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e133a2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e153a2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,38,39,40,41,42,43,44,45,46,47];this.GXLastCtrlId=47;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TXTUSER",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"GAM_DATACARD",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"GAM_DATACARD_TABLEGENERALTITLE",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GAM_DATACARD_TBTITLEGENERAL",format:0,grid:0,ctrltype:"textblock"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"GAM_DATACARD_TABLEDATAGENERAL",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"QRIMAGE",format:1,grid:0,ctrltype:"textblock"};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"svchar",len:256,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSECRETKEY",fmt:0,gxz:"ZV14SecretKey",gxold:"OV14SecretKey",gxvar:"AV14SecretKey",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14SecretKey=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14SecretKey=n)},v2c:function(){gx.fn.setControlValue("vSECRETKEY",gx.O.AV14SecretKey,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14SecretKey=this.val())},val:function(){return gx.fn.getControlValue("vSECRETKEY")},nac:gx.falseFn};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"svchar",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTOTPCODE",fmt:0,gxz:"ZV15TOTPCode",gxold:"OV15TOTPCode",gxvar:"AV15TOTPCode",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15TOTPCode=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15TOTPCode=n)},v2c:function(){gx.fn.setControlValue("vTOTPCODE",gx.O.AV15TOTPCode,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15TOTPCode=this.val())},val:function(){return gx.fn.getControlValue("vTOTPCODE")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"GAM_FOOTERENTRY",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"GAM_FOOTERENTRY_TABLEBUTTONS",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"GAM_FOOTERENTRY_BTNCANCEL",grid:0,evt:"e113a1_client"};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"GAM_FOOTERENTRY_BTNCONFIRM",grid:0,evt:"e133a2_client",std:"ENTER"};this.AV14SecretKey="";this.ZV14SecretKey="";this.OV14SecretKey="";this.AV15TOTPCode="";this.ZV15TOTPCode="";this.OV15TOTPCode="";this.AV14SecretKey="";this.AV15TOTPCode="";this.Events={e133a2_client:["ENTER",!0],e153a2_client:["CANCEL",!0],e113a1_client:["'CANCEL'",!1]};this.EvtParms.REFRESH=[[{av:"AV14SecretKey",fld:"vSECRETKEY"}],[]];this.EvtParms.ENTER=[[{av:"AV15TOTPCode",fld:"vTOTPCODE"}],[{av:"gx.fn.getCtrlProperty('vTOTPCODE','Enabled')",ctrl:"vTOTPCODE",prop:"Enabled"},{ctrl:"GAM_FOOTERENTRY_BTNCONFIRM",prop:"Visible"},{ctrl:"GAM_FOOTERENTRY_BTNCANCEL",prop:"Caption"},{ctrl:"WCMESSAGES"}]];this.EvtParms["'CANCEL'"]=[[],[]];this.EnterCtrl=["GAM_FOOTERENTRY_BTNCONFIRM"];this.Initialize();this.setComponent({id:"WCMESSAGES",GXClass:null,Prefix:"W0037",lvl:1})});gx.wi(function(){gx.createParentObj(this.gam_authenticatorenable)})