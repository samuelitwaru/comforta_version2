gx.evt.autoSkip=!1;gx.define("gamrecoverpasswordstep2",!1,function(){this.ServerClass="gamrecoverpasswordstep2";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamrecoverpasswordstep2.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV14UserAuthTypeName=gx.fn.getControlValue("vUSERAUTHTYPENAME");this.AV10KeyToChangePassword=gx.fn.getControlValue("vKEYTOCHANGEPASSWORD");this.AV18UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",",");this.AV9IDP_State=gx.fn.getControlValue("vIDP_STATE")};this.e120x2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e130x2_client=function(){return this.executeServerEvent("BACKTOLOGIN.CLICK",!0,null,!1,!0)};this.e150x2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,24,25,26,29,30,31,34,35,36,39,40,41,42,43];this.GXLastCtrlId=43;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLECONTENT",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"HEADERORIGINAL",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TABLELOGIN",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"SIGNIN",format:0,grid:0,ctrltype:"textblock"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"UNNAMEDTABLE1",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV15UserName",gxold:"OV15UserName",gxvar:"AV15UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV15UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV15UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORDNEW",fmt:0,gxz:"ZV16UserPasswordNew",gxold:"OV16UserPasswordNew",gxvar:"AV16UserPasswordNew",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16UserPasswordNew=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16UserPasswordNew=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORDNEW",gx.O.AV16UserPasswordNew,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV16UserPasswordNew=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORDNEW")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORDNEWCONF",fmt:0,gxz:"ZV17UserPasswordNewConf",gxold:"OV17UserPasswordNewConf",gxvar:"AV17UserPasswordNewConf",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17UserPasswordNewConf=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17UserPasswordNewConf=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORDNEWCONF",gx.O.AV17UserPasswordNewConf,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV17UserPasswordNewConf=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORDNEWCONF")},nac:gx.falseFn};this.declareDomainHdlr(36,function(){});n[39]={id:39,fld:"ACTIONS",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTNENTER",grid:0,evt:"e120x2_client",std:"ENTER"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"BACKTOLOGIN",format:0,grid:0,evt:"e130x2_client",ctrltype:"textblock"};this.AV15UserName="";this.ZV15UserName="";this.OV15UserName="";this.AV16UserPasswordNew="";this.ZV16UserPasswordNew="";this.OV16UserPasswordNew="";this.AV17UserPasswordNewConf="";this.ZV17UserPasswordNewConf="";this.OV17UserPasswordNewConf="";this.AV15UserName="";this.AV16UserPasswordNew="";this.AV17UserPasswordNewConf="";this.AV9IDP_State="";this.AV10KeyToChangePassword="";this.AV14UserAuthTypeName="";this.AV18UserRememberMe=0;this.Events={e120x2_client:["ENTER",!0],e130x2_client:["BACKTOLOGIN.CLICK",!0],e150x2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV14UserAuthTypeName",fld:"vUSERAUTHTYPENAME",hsh:!0},{av:"AV18UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0},{av:"AV10KeyToChangePassword",fld:"vKEYTOCHANGEPASSWORD",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV16UserPasswordNew",fld:"vUSERPASSWORDNEW"},{av:"AV17UserPasswordNewConf",fld:"vUSERPASSWORDNEWCONF"},{av:"AV14UserAuthTypeName",fld:"vUSERAUTHTYPENAME",hsh:!0},{av:"AV15UserName",fld:"vUSERNAME"},{av:"AV10KeyToChangePassword",fld:"vKEYTOCHANGEPASSWORD",hsh:!0},{av:"AV18UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0},{av:"AV9IDP_State",fld:"vIDP_STATE"}],[]];this.EvtParms["BACKTOLOGIN.CLICK"]=[[{av:"AV9IDP_State",fld:"vIDP_STATE"}],[{av:"AV9IDP_State",fld:"vIDP_STATE"}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV14UserAuthTypeName","vUSERAUTHTYPENAME",0,"char",60,0);this.setVCMap("AV10KeyToChangePassword","vKEYTOCHANGEPASSWORD",0,"char",120,0);this.setVCMap("AV18UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.setVCMap("AV9IDP_State","vIDP_STATE",0,"char",60,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamrecoverpasswordstep2)})