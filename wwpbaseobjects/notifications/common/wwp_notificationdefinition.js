gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.notifications.common.wwp_notificationdefinition",!1,function(){this.ServerClass="wwpbaseobjects.notifications.common.wwp_notificationdefinition";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.notifications.common.wwp_notificationdefinition.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){};this.Valid_Wwpnotificationdefinitionid=function(){return this.validSrvEvt("Valid_Wwpnotificationdefinitionid",0).then(function(n){return n}.closure(this))};this.Valid_Wwpnotificationdefinitionappli=function(){return this.validCliEvt("Valid_Wwpnotificationdefinitionappli",0,function(){try{var n=gx.util.balloon.getNew("WWPNOTIFICATIONDEFINITIONAPPLI");if(this.AnyError=0,!(this.A135WWPNotificationDefinitionAppli==1||this.A135WWPNotificationDefinitionAppli==2))try{n.setError("Field Notification Definition Applies To is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Wwpnotificationdefinitionlink=function(){return this.validCliEvt("Valid_Wwpnotificationdefinitionlink",0,function(){try{var n=gx.util.balloon.getNew("WWPNOTIFICATIONDEFINITIONLINK");if(this.AnyError=0,!gx.util.regExp.isMatch(this.A171WWPNotificationDefinitionLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$"))try{n.setError("Field Notification Definition Default Link does not match the specified pattern");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Wwpentityid=function(){return this.validSrvEvt("Valid_Wwpentityid",0).then(function(n){return n}.closure(this))};this.Valid_Wwpnotificationdefinitionsecfu=function(){return this.validSrvEvt("Valid_Wwpnotificationdefinitionsecfu",0).then(function(n){return n}.closure(this))};this.e110n33_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e120n33_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108];this.GXLastCtrlId=108;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e130n33_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e140n33_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e150n33_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e160n33_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e170n33_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationdefinitionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONID",fmt:0,gxz:"Z128WWPNotificationDefinitionId",gxold:"O128WWPNotificationDefinitionId",gxvar:"A128WWPNotificationDefinitionId",ucs:[],op:[84,94,79,74,69,64,59,54,49,44,39],ip:[84,94,79,74,69,64,59,54,49,44,39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A128WWPNotificationDefinitionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z128WWPNotificationDefinitionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONID",gx.O.A128WWPNotificationDefinitionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A128WWPNotificationDefinitionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONID",",")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONNAME",fmt:0,gxz:"Z164WWPNotificationDefinitionName",gxold:"O164WWPNotificationDefinitionName",gxvar:"A164WWPNotificationDefinitionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A164WWPNotificationDefinitionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z164WWPNotificationDefinitionName=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONNAME",gx.O.A164WWPNotificationDefinitionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A164WWPNotificationDefinitionName=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONNAME")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:1,dec:0,sign:!1,pic:"9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationdefinitionappli,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONAPPLI",fmt:0,gxz:"Z135WWPNotificationDefinitionAppli",gxold:"O135WWPNotificationDefinitionAppli",gxvar:"A135WWPNotificationDefinitionAppli",ucs:[],op:[44],ip:[44],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A135WWPNotificationDefinitionAppli=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z135WWPNotificationDefinitionAppli=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("WWPNOTIFICATIONDEFINITIONAPPLI",gx.O.A135WWPNotificationDefinitionAppli);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A135WWPNotificationDefinitionAppli=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONAPPLI",",")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONALLOW",fmt:0,gxz:"Z136WWPNotificationDefinitionAllow",gxold:"O136WWPNotificationDefinitionAllow",gxvar:"A136WWPNotificationDefinitionAllow",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.A136WWPNotificationDefinitionAllow=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z136WWPNotificationDefinitionAllow=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("WWPNOTIFICATIONDEFINITIONALLOW",gx.O.A136WWPNotificationDefinitionAllow,!0)},c2v:function(){this.val()!==undefined&&(gx.O.A136WWPNotificationDefinitionAllow=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONALLOW")},nac:gx.falseFn,values:["true","false"]};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONDESCR",fmt:0,gxz:"Z134WWPNotificationDefinitionDescr",gxold:"O134WWPNotificationDefinitionDescr",gxvar:"A134WWPNotificationDefinitionDescr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A134WWPNotificationDefinitionDescr=n)},v2z:function(n){n!==undefined&&(gx.O.Z134WWPNotificationDefinitionDescr=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONDESCR",gx.O.A134WWPNotificationDefinitionDescr,0)},c2v:function(){this.val()!==undefined&&(gx.O.A134WWPNotificationDefinitionDescr=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONDESCR")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONICON",fmt:0,gxz:"Z167WWPNotificationDefinitionIcon",gxold:"O167WWPNotificationDefinitionIcon",gxvar:"A167WWPNotificationDefinitionIcon",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A167WWPNotificationDefinitionIcon=n)},v2z:function(n){n!==undefined&&(gx.O.Z167WWPNotificationDefinitionIcon=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONICON",gx.O.A167WWPNotificationDefinitionIcon,0)},c2v:function(){this.val()!==undefined&&(gx.O.A167WWPNotificationDefinitionIcon=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONICON")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONTITLE",fmt:0,gxz:"Z168WWPNotificationDefinitionTitle",gxold:"O168WWPNotificationDefinitionTitle",gxvar:"A168WWPNotificationDefinitionTitle",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A168WWPNotificationDefinitionTitle=n)},v2z:function(n){n!==undefined&&(gx.O.Z168WWPNotificationDefinitionTitle=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONTITLE",gx.O.A168WWPNotificationDefinitionTitle,0)},c2v:function(){this.val()!==undefined&&(gx.O.A168WWPNotificationDefinitionTitle=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONTITLE")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONSHORT",fmt:0,gxz:"Z169WWPNotificationDefinitionShort",gxold:"O169WWPNotificationDefinitionShort",gxvar:"A169WWPNotificationDefinitionShort",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A169WWPNotificationDefinitionShort=n)},v2z:function(n){n!==undefined&&(gx.O.Z169WWPNotificationDefinitionShort=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONSHORT",gx.O.A169WWPNotificationDefinitionShort,0)},c2v:function(){this.val()!==undefined&&(gx.O.A169WWPNotificationDefinitionShort=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONSHORT")},nac:gx.falseFn};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"svchar",len:1e3,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONLONGD",fmt:0,gxz:"Z170WWPNotificationDefinitionLongD",gxold:"O170WWPNotificationDefinitionLongD",gxvar:"A170WWPNotificationDefinitionLongD",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A170WWPNotificationDefinitionLongD=n)},v2z:function(n){n!==undefined&&(gx.O.Z170WWPNotificationDefinitionLongD=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONLONGD",gx.O.A170WWPNotificationDefinitionLongD,0)},c2v:function(){this.val()!==undefined&&(gx.O.A170WWPNotificationDefinitionLongD=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONLONGD")},nac:gx.falseFn};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,lvl:0,type:"svchar",len:1e3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationdefinitionlink,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONLINK",fmt:0,gxz:"Z171WWPNotificationDefinitionLink",gxold:"O171WWPNotificationDefinitionLink",gxvar:"A171WWPNotificationDefinitionLink",ucs:[],op:[],ip:[79],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A171WWPNotificationDefinitionLink=n)},v2z:function(n){n!==undefined&&(gx.O.Z171WWPNotificationDefinitionLink=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONLINK",gx.O.A171WWPNotificationDefinitionLink,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A171WWPNotificationDefinitionLink=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONLINK")},nac:gx.falseFn};this.declareDomainHdlr(79,function(){});n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpentityid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPENTITYID",fmt:0,gxz:"Z125WWPEntityId",gxold:"O125WWPEntityId",gxvar:"A125WWPEntityId",ucs:[],op:[89],ip:[89,84],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A125WWPEntityId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z125WWPEntityId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("WWPENTITYID",gx.O.A125WWPEntityId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A125WWPEntityId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPENTITYID",",")},nac:gx.falseFn};this.declareDomainHdlr(84,function(){});n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPENTITYNAME",fmt:0,gxz:"Z126WWPEntityName",gxold:"O126WWPEntityName",gxvar:"A126WWPEntityName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A126WWPEntityName=n)},v2z:function(n){n!==undefined&&(gx.O.Z126WWPEntityName=n)},v2c:function(){gx.fn.setControlValue("WWPENTITYNAME",gx.O.A126WWPEntityName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A126WWPEntityName=this.val())},val:function(){return gx.fn.getControlValue("WWPENTITYNAME")},nac:gx.falseFn};this.declareDomainHdlr(89,function(){});n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationdefinitionsecfu,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONSECFU",fmt:0,gxz:"Z172WWPNotificationDefinitionSecFu",gxold:"O172WWPNotificationDefinitionSecFu",gxvar:"A172WWPNotificationDefinitionSecFu",ucs:[],op:[99],ip:[99,94],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A172WWPNotificationDefinitionSecFu=n)},v2z:function(n){n!==undefined&&(gx.O.Z172WWPNotificationDefinitionSecFu=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONSECFU",gx.O.A172WWPNotificationDefinitionSecFu,0)},c2v:function(){this.val()!==undefined&&(gx.O.A172WWPNotificationDefinitionSecFu=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONSECFU")},nac:gx.falseFn};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"",grid:0};n[99]={id:99,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONISAUT",fmt:0,gxz:"Z173WWPNotificationDefinitionIsAut",gxold:"O173WWPNotificationDefinitionIsAut",gxvar:"A173WWPNotificationDefinitionIsAut",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.A173WWPNotificationDefinitionIsAut=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z173WWPNotificationDefinitionIsAut=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("WWPNOTIFICATIONDEFINITIONISAUT",gx.O.A173WWPNotificationDefinitionIsAut,!0)},c2v:function(){this.val()!==undefined&&(gx.O.A173WWPNotificationDefinitionIsAut=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONISAUT")},nac:gx.falseFn,values:["true","false"]};n[100]={id:100,fld:"",grid:0};n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"",grid:0};n[103]={id:103,fld:"",grid:0};n[104]={id:104,fld:"BTN_ENTER",grid:0,evt:"e110n33_client",std:"ENTER"};n[105]={id:105,fld:"",grid:0};n[106]={id:106,fld:"BTN_CANCEL",grid:0,evt:"e120n33_client"};n[107]={id:107,fld:"",grid:0};n[108]={id:108,fld:"BTN_DELETE",grid:0,evt:"e180n33_client",std:"DELETE"};this.A128WWPNotificationDefinitionId=0;this.Z128WWPNotificationDefinitionId=0;this.O128WWPNotificationDefinitionId=0;this.A164WWPNotificationDefinitionName="";this.Z164WWPNotificationDefinitionName="";this.O164WWPNotificationDefinitionName="";this.A135WWPNotificationDefinitionAppli=0;this.Z135WWPNotificationDefinitionAppli=0;this.O135WWPNotificationDefinitionAppli=0;this.A136WWPNotificationDefinitionAllow=!1;this.Z136WWPNotificationDefinitionAllow=!1;this.O136WWPNotificationDefinitionAllow=!1;this.A134WWPNotificationDefinitionDescr="";this.Z134WWPNotificationDefinitionDescr="";this.O134WWPNotificationDefinitionDescr="";this.A167WWPNotificationDefinitionIcon="";this.Z167WWPNotificationDefinitionIcon="";this.O167WWPNotificationDefinitionIcon="";this.A168WWPNotificationDefinitionTitle="";this.Z168WWPNotificationDefinitionTitle="";this.O168WWPNotificationDefinitionTitle="";this.A169WWPNotificationDefinitionShort="";this.Z169WWPNotificationDefinitionShort="";this.O169WWPNotificationDefinitionShort="";this.A170WWPNotificationDefinitionLongD="";this.Z170WWPNotificationDefinitionLongD="";this.O170WWPNotificationDefinitionLongD="";this.A171WWPNotificationDefinitionLink="";this.Z171WWPNotificationDefinitionLink="";this.O171WWPNotificationDefinitionLink="";this.A125WWPEntityId=0;this.Z125WWPEntityId=0;this.O125WWPEntityId=0;this.A126WWPEntityName="";this.Z126WWPEntityName="";this.O126WWPEntityName="";this.A172WWPNotificationDefinitionSecFu="";this.Z172WWPNotificationDefinitionSecFu="";this.O172WWPNotificationDefinitionSecFu="";this.A173WWPNotificationDefinitionIsAut=!1;this.Z173WWPNotificationDefinitionIsAut=!1;this.O173WWPNotificationDefinitionIsAut=!1;this.A128WWPNotificationDefinitionId=0;this.A173WWPNotificationDefinitionIsAut=!1;this.A164WWPNotificationDefinitionName="";this.A135WWPNotificationDefinitionAppli=0;this.A136WWPNotificationDefinitionAllow=!1;this.A134WWPNotificationDefinitionDescr="";this.A167WWPNotificationDefinitionIcon="";this.A168WWPNotificationDefinitionTitle="";this.A169WWPNotificationDefinitionShort="";this.A170WWPNotificationDefinitionLongD="";this.A171WWPNotificationDefinitionLink="";this.A125WWPEntityId=0;this.A126WWPEntityName="";this.A172WWPNotificationDefinitionSecFu="";this.Events={e110n33_client:["ENTER",!0],e120n33_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}],[{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}]];this.EvtParms.REFRESH=[[{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}],[{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}]];this.EvtParms.VALID_WWPNOTIFICATIONDEFINITIONID=[[{ctrl:"WWPNOTIFICATIONDEFINITIONAPPLI"},{av:"A135WWPNotificationDefinitionAppli",fld:"WWPNOTIFICATIONDEFINITIONAPPLI",pic:"9"},{av:"A128WWPNotificationDefinitionId",fld:"WWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}],[{av:"A164WWPNotificationDefinitionName",fld:"WWPNOTIFICATIONDEFINITIONNAME"},{ctrl:"WWPNOTIFICATIONDEFINITIONAPPLI"},{av:"A135WWPNotificationDefinitionAppli",fld:"WWPNOTIFICATIONDEFINITIONAPPLI",pic:"9"},{av:"A134WWPNotificationDefinitionDescr",fld:"WWPNOTIFICATIONDEFINITIONDESCR"},{av:"A167WWPNotificationDefinitionIcon",fld:"WWPNOTIFICATIONDEFINITIONICON"},{av:"A168WWPNotificationDefinitionTitle",fld:"WWPNOTIFICATIONDEFINITIONTITLE"},{av:"A169WWPNotificationDefinitionShort",fld:"WWPNOTIFICATIONDEFINITIONSHORT"},{av:"A170WWPNotificationDefinitionLongD",fld:"WWPNOTIFICATIONDEFINITIONLONGD"},{av:"A171WWPNotificationDefinitionLink",fld:"WWPNOTIFICATIONDEFINITIONLINK"},{av:"A125WWPEntityId",fld:"WWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"A172WWPNotificationDefinitionSecFu",fld:"WWPNOTIFICATIONDEFINITIONSECFU"},{av:"A126WWPEntityName",fld:"WWPENTITYNAME"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z128WWPNotificationDefinitionId"},{av:"Z164WWPNotificationDefinitionName"},{av:"Z135WWPNotificationDefinitionAppli"},{av:"Z136WWPNotificationDefinitionAllow"},{av:"Z134WWPNotificationDefinitionDescr"},{av:"Z167WWPNotificationDefinitionIcon"},{av:"Z168WWPNotificationDefinitionTitle"},{av:"Z169WWPNotificationDefinitionShort"},{av:"Z170WWPNotificationDefinitionLongD"},{av:"Z171WWPNotificationDefinitionLink"},{av:"Z125WWPEntityId"},{av:"Z172WWPNotificationDefinitionSecFu"},{av:"Z126WWPEntityName"},{av:"Z173WWPNotificationDefinitionIsAut"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}]];this.EvtParms.VALID_WWPNOTIFICATIONDEFINITIONAPPLI=[[{ctrl:"WWPNOTIFICATIONDEFINITIONAPPLI"},{av:"A135WWPNotificationDefinitionAppli",fld:"WWPNOTIFICATIONDEFINITIONAPPLI",pic:"9"},{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}],[{ctrl:"WWPNOTIFICATIONDEFINITIONAPPLI"},{av:"A135WWPNotificationDefinitionAppli",fld:"WWPNOTIFICATIONDEFINITIONAPPLI",pic:"9"},{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}]];this.EvtParms.VALID_WWPNOTIFICATIONDEFINITIONLINK=[[{av:"A171WWPNotificationDefinitionLink",fld:"WWPNOTIFICATIONDEFINITIONLINK"},{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}],[{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}]];this.EvtParms.VALID_WWPENTITYID=[[{av:"A125WWPEntityId",fld:"WWPENTITYID",pic:"ZZZZZZZZZ9"},{av:"A126WWPEntityName",fld:"WWPENTITYNAME"},{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}],[{av:"A126WWPEntityName",fld:"WWPENTITYNAME"},{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}]];this.EvtParms.VALID_WWPNOTIFICATIONDEFINITIONSECFU=[[{av:"A172WWPNotificationDefinitionSecFu",fld:"WWPNOTIFICATIONDEFINITIONSECFU"},{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}],[{av:"A136WWPNotificationDefinitionAllow",fld:"WWPNOTIFICATIONDEFINITIONALLOW"},{av:"A173WWPNotificationDefinitionIsAut",fld:"WWPNOTIFICATIONDEFINITIONISAUT"}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwpbaseobjects.notifications.common.wwp_notificationdefinition)})