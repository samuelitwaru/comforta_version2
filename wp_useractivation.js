gx.evt.autoSkip=!1;gx.define("wp_useractivation",!1,function(){this.ServerClass="wp_useractivation";this.PackageName="GeneXus.Programs";this.ServerFullClass="wp_useractivation.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV10GamGuid=gx.fn.getControlValue("vGAMGUID");this.AV9ActivationKey=gx.fn.getControlValue("vACTIVATIONKEY")};this.e124f2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e134f2_client=function(){return this.executeServerEvent("'GOTOLOGIN'",!0,null,!1,!1)};this.e154f2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,38,40];this.GXLastCtrlId=40;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLELOGINCONTENT",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLELOGIN",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"LOGOLOGIN",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"UNNAMEDTABLE1",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"CURRENTREPOSITORYCELL",grid:0};n[21]={id:21,fld:"CURRENTREPOSITORY",format:0,grid:0,ctrltype:"textblock"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV7UserPassword",gxold:"OV7UserPassword",gxvar:"AV7UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV7UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV7UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(25,function(){});n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORDCOMFIRMATION",fmt:0,gxz:"ZV8UserPasswordComfirmation",gxold:"OV8UserPasswordComfirmation",gxvar:"AV8UserPasswordComfirmation",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8UserPasswordComfirmation=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8UserPasswordComfirmation=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORDCOMFIRMATION",gx.O.AV8UserPasswordComfirmation,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV8UserPasswordComfirmation=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORDCOMFIRMATION")},nac:gx.falseFn};this.declareDomainHdlr(29,function(){});n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"BTNENTER",grid:0,evt:"e124f2_client",std:"ENTER"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"UNNAMEDTABLE2",grid:0};n[38]={id:38,fld:"NOACCOUNT",format:0,grid:0,ctrltype:"textblock"};n[40]={id:40,fld:"REGISTERUSER",format:0,grid:0,evt:"e134f2_client",ctrltype:"textblock"};this.AV7UserPassword="";this.ZV7UserPassword="";this.OV7UserPassword="";this.AV8UserPasswordComfirmation="";this.ZV8UserPasswordComfirmation="";this.OV8UserPasswordComfirmation="";this.AV7UserPassword="";this.AV8UserPasswordComfirmation="";this.AV9ActivationKey="";this.AV10GamGuid="";this.Events={e124f2_client:["ENTER",!0],e134f2_client:["'GOTOLOGIN'",!0],e154f2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV10GamGuid",fld:"vGAMGUID",hsh:!0},{av:"AV9ActivationKey",fld:"vACTIVATIONKEY",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV8UserPasswordComfirmation",fld:"vUSERPASSWORDCOMFIRMATION"},{av:"AV7UserPassword",fld:"vUSERPASSWORD"},{av:"AV10GamGuid",fld:"vGAMGUID",hsh:!0},{av:"AV9ActivationKey",fld:"vACTIVATIONKEY",hsh:!0}],[]];this.EvtParms["'GOTOLOGIN'"]=[[],[]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV10GamGuid","vGAMGUID",0,"svchar",100,60);this.setVCMap("AV9ActivationKey","vACTIVATIONKEY",0,"char",254,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wp_useractivation)})