gx.evt.autoSkip=!1;gx.define("gam_appmenuentry",!1,function(){this.ServerClass="gam_appmenuentry";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_appmenuentry.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.AV7ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV6isOK=gx.fn.getControlValue("vISOK")};this.s112_client=function(){return this.executeClientEvent(function(){this.createWebComponent("Wcmessages","GAM_Messages",[])},arguments)};this.e112h1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("gam_appmenuentry.aspx",["UPD",this.AV7ApplicationId,this.AV13Id],null,["Mode","ApplicationId","Id"]);this.refreshOutputs([{av:"AV13Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]);this.OnClientEventEnd()},arguments)};this.e182h1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("gam_wwappmenus.aspx",[this.AV7ApplicationId],null,["ApplicationId"]);this.refreshOutputs([{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]);this.OnClientEventEnd()},arguments)};this.e132h2_client=function(){return this.executeServerEvent("'CONFIRM'",!1,null,!1,!1)};this.e142h2_client=function(){return this.executeServerEvent("'CANCEL'",!1,null,!1,!1)};this.e152h2_client=function(){return this.executeServerEvent("'TRANSLATIONS'",!0,null,!1,!1)};this.e162h2_client=function(){return this.executeServerEvent("'CUSTOMPROPERTIES'",!0,null,!1,!1)};this.e192h2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e202h2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,81,82,83,84,85,86,87,88,89,90];this.GXLastCtrlId=90;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"GAM_HEADERENTRY",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"GAM_HEADERENTRY_TBLBACKCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"GAM_HEADERENTRY_TABLEBACK",grid:0,evt:"e182h1_client"};n[15]={id:15,fld:"GAM_HEADERENTRY_TXTBACK",format:0,grid:0,ctrltype:"textblock"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GAM_HEADERENTRY_TABLETITLEACTIONS",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"GAM_HEADERENTRY_TITLE",format:0,grid:0,ctrltype:"textblock"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"GAM_HEADERENTRY_TXTSTATUS",format:0,grid:0,ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"GAM_HEADERENTRY_TBLTOOLBARS",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",format:0,grid:0,ctrltype:"textblock"};n[29]={id:29,fld:"GAM_HEADERENTRY_BUTTONSTOOLBAR_INNER",grid:0};n[30]={id:30,fld:"BUTTONEDIT",format:0,grid:0,evt:"e112h1_client",ctrltype:"textblock"};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"GAM_HEADERENTRY_MENUTABLE",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",format:0,grid:0,ctrltype:"textblock"};n[37]={id:37,fld:"GAM_HEADERENTRY_MENUTOOLBAR_INNER",grid:0};n[38]={id:38,fld:"",format:0,grid:0,ctrltype:"textblock"};n[39]={id:39,fld:"BUTTONCUSTOMPROPERTIES",format:0,grid:0,evt:"e162h2_client",ctrltype:"textblock"};n[40]={id:40,fld:"BUTTONTRANSLATIONS",format:0,grid:0,evt:"e152h2_client",ctrltype:"textblock"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"GAM_DATACARD",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"GAM_DATACARD_TABLEGENERALTITLE",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"GAM_DATACARD_TBTITLEGENERAL",format:0,grid:0,ctrltype:"textblock"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"GAM_DATACARD_TABLEDATAGENERAL",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLNAME",fmt:0,gxz:"ZV19GXV1",gxold:"OV19GXV1",gxvar:"GXV1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19GXV1=n)},v2c:function(){gx.fn.setControlValue("CTLNAME",gx.O.GXV1,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV1=this.val())},val:function(){return gx.fn.getControlValue("CTLNAME")},nac:gx.falseFn};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGUID",fmt:0,gxz:"ZV12GUID",gxold:"OV12GUID",gxvar:"AV12GUID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12GUID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12GUID=n)},v2c:function(){gx.fn.setControlValue("vGUID",gx.O.AV12GUID,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12GUID=this.val())},val:function(){return gx.fn.getControlValue("vGUID")},nac:gx.falseFn};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV13Id",gxold:"OV13Id",gxvar:"AV13Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV13Id=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vID",gx.O.AV13Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13Id=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vID",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(67,function(){});n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV14Name",gxold:"OV14Name",gxvar:"AV14Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Name=n)},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV14Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14Name=this.val())},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};this.declareDomainHdlr(72,function(){});n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDSC",fmt:0,gxz:"ZV9Dsc",gxold:"OV9Dsc",gxvar:"AV9Dsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9Dsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9Dsc=n)},v2c:function(){gx.fn.setControlValue("vDSC",gx.O.AV9Dsc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV9Dsc=this.val())},val:function(){return gx.fn.getControlValue("vDSC")},nac:gx.falseFn};this.declareDomainHdlr(77,function(){});n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"GAM_FOOTERENTRY",grid:0};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"GAM_FOOTERENTRY_TABLEBUTTONS",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"GAM_FOOTERENTRY_BTNCANCEL",grid:0,evt:"e142h2_client"};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"GAM_FOOTERENTRY_BTNCONFIRM",grid:0,evt:"e132h2_client"};this.GXV1="";this.ZV19GXV1="";this.OV19GXV1="";this.AV12GUID="";this.ZV12GUID="";this.OV12GUID="";this.AV13Id=0;this.ZV13Id=0;this.OV13Id=0;this.AV14Name="";this.ZV14Name="";this.OV14Name="";this.AV9Dsc="";this.ZV9Dsc="";this.OV9Dsc="";this.GXV1="";this.AV12GUID="";this.AV13Id=0;this.AV14Name="";this.AV9Dsc="";this.AV7ApplicationId=0;this.Gx_mode="";this.AV6isOK=!1;this.AV5GAMApplication={};this.Events={e132h2_client:["'CONFIRM'",!0],e142h2_client:["'CANCEL'",!0],e152h2_client:["'TRANSLATIONS'",!0],e162h2_client:["'CUSTOMPROPERTIES'",!0],e192h2_client:["ENTER",!0],e202h2_client:["CANCEL",!0],e112h1_client:["'EDIT'",!1],e182h1_client:["GAM_HEADERENTRY_TABLEBACK.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[]];this.EvtParms["'CONFIRM'"]=[[{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV14Name",fld:"vNAME"},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV12GUID",fld:"vGUID"},{av:"AV9Dsc",fld:"vDSC"},{av:"AV13Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6isOK",fld:"vISOK"}],[{av:"AV6isOK",fld:"vISOK"},{ctrl:"WCMESSAGES"}]];this.EvtParms["'CANCEL'"]=[[{av:"AV13Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[]];this.EvtParms["'EDIT'"]=[[{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV13Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV13Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["'TRANSLATIONS'"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV14Name",fld:"vNAME"},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV13Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms["'CUSTOMPROPERTIES'"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV14Name",fld:"vNAME"},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV13Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms["GAM_HEADERENTRY_TABLEBACK.CLICK"]=[[{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV7ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV6isOK","vISOK",0,"boolean",4,0);this.setVCMap("AV7ApplicationId","vAPPLICATIONID",0,"int",12,0);this.addBCProperty("Gamapplication",["Name"],this.GXValidFnc[57],"AV5GAMApplication");this.Initialize();this.setComponent({id:"WCMESSAGES",GXClass:null,Prefix:"W0080",lvl:1})});gx.wi(function(){gx.createParentObj(this.gam_appmenuentry)})