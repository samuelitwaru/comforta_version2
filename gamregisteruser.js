gx.evt.autoSkip=!1;gx.define("gamregisteruser",!1,function(){this.ServerClass="gamregisteruser";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamregisteruser.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV118CheckRequiredFieldsResult=gx.fn.getControlValue("vCHECKREQUIREDFIELDSRESULT");this.AV22Birthday=gx.fn.getDateValue("vBIRTHDAY");this.AV23Gender=gx.fn.getControlValue("vGENDER");this.AV117UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",",")};this.e120w2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140w1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49];this.GXLastCtrlId=49;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLECONTENT",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"HEADERORIGINAL",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TABLELOGIN",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"SIGNIN",format:0,grid:0,ctrltype:"textblock"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"UNNAMEDTABLE1",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"NAME_CELL",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV18Name",gxold:"OV18Name",gxvar:"AV18Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18Name=n)},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV18Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV18Name=this.val())},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};this.declareDomainHdlr(25,function(){});n[26]={id:26,fld:"EMAIL_CELL",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEMAIL",fmt:0,gxz:"ZV5EMail",gxold:"OV5EMail",gxvar:"AV5EMail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5EMail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5EMail=n)},v2c:function(){gx.fn.setControlValue("vEMAIL",gx.O.AV5EMail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV5EMail=this.val())},val:function(){return gx.fn.getControlValue("vEMAIL")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"PASSWORD_CELL",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPASSWORD",fmt:0,gxz:"ZV19Password",gxold:"OV19Password",gxvar:"AV19Password",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV19Password=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19Password=n)},v2c:function(){gx.fn.setControlValue("vPASSWORD",gx.O.AV19Password,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV19Password=this.val())},val:function(){return gx.fn.getControlValue("vPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(32,function(){});n[33]={id:33,fld:"PASSWORDCONF_CELL",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPASSWORDCONF",fmt:0,gxz:"ZV20PasswordConf",gxold:"OV20PasswordConf",gxvar:"AV20PasswordConf",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV20PasswordConf=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20PasswordConf=n)},v2c:function(){gx.fn.setControlValue("vPASSWORDCONF",gx.O.AV20PasswordConf,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV20PasswordConf=this.val())},val:function(){return gx.fn.getControlValue("vPASSWORDCONF")},nac:gx.falseFn};this.declareDomainHdlr(35,function(){});n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"FIRSTNAME_CELL",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFIRSTNAME",fmt:0,gxz:"ZV6FirstName",gxold:"OV6FirstName",gxvar:"AV6FirstName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6FirstName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6FirstName=n)},v2c:function(){gx.fn.setControlValue("vFIRSTNAME",gx.O.AV6FirstName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV6FirstName=this.val())},val:function(){return gx.fn.getControlValue("vFIRSTNAME")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"LASTNAME_CELL",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLASTNAME",fmt:0,gxz:"ZV13LastName",gxold:"OV13LastName",gxvar:"AV13LastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13LastName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13LastName=n)},v2c:function(){gx.fn.setControlValue("vLASTNAME",gx.O.AV13LastName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13LastName=this.val())},val:function(){return gx.fn.getControlValue("vLASTNAME")},nac:gx.falseFn};this.declareDomainHdlr(42,function(){});n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"ACTIONS",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"BTNENTER",grid:0,evt:"e120w2_client",std:"ENTER"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTN_CANCEL",grid:0,evt:"e140w1_client"};this.AV18Name="";this.ZV18Name="";this.OV18Name="";this.AV5EMail="";this.ZV5EMail="";this.OV5EMail="";this.AV19Password="";this.ZV19Password="";this.OV19Password="";this.AV20PasswordConf="";this.ZV20PasswordConf="";this.OV20PasswordConf="";this.AV6FirstName="";this.ZV6FirstName="";this.OV6FirstName="";this.AV13LastName="";this.ZV13LastName="";this.OV13LastName="";this.AV18Name="";this.AV5EMail="";this.AV19Password="";this.AV20PasswordConf="";this.AV6FirstName="";this.AV13LastName="";this.AV118CheckRequiredFieldsResult=!1;this.AV22Birthday=gx.date.nullDate();this.AV23Gender="";this.AV117UserRememberMe=0;this.Events={e120w2_client:["ENTER",!0],e140w1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV22Birthday",fld:"vBIRTHDAY",hsh:!0},{av:"AV23Gender",fld:"vGENDER",hsh:!0},{av:"AV117UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV118CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT"},{av:"AV19Password",fld:"vPASSWORD"},{av:"AV20PasswordConf",fld:"vPASSWORDCONF"},{av:"AV18Name",fld:"vNAME"},{av:"AV5EMail",fld:"vEMAIL"},{av:"AV6FirstName",fld:"vFIRSTNAME"},{av:"AV13LastName",fld:"vLASTNAME"},{av:"AV22Birthday",fld:"vBIRTHDAY",hsh:!0},{av:"AV23Gender",fld:"vGENDER",hsh:!0},{av:"AV117UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0}],[{av:"AV118CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT"}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV118CheckRequiredFieldsResult","vCHECKREQUIREDFIELDSRESULT",0,"boolean",4,0);this.setVCMap("AV22Birthday","vBIRTHDAY",0,"date",8,0);this.setVCMap("AV23Gender","vGENDER",0,"char",1,0);this.setVCMap("AV117UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamregisteruser)})