gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.notifications.common.wwp_notification",!1,function(){this.ServerClass="wwpbaseobjects.notifications.common.wwp_notification";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.notifications.common.wwp_notification.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",")};this.Valid_Wwpnotificationid=function(){return this.validSrvEvt("Valid_Wwpnotificationid",0).then(function(n){return n}.closure(this))};this.Valid_Wwpnotificationdefinitionid=function(){return this.validSrvEvt("Valid_Wwpnotificationdefinitionid",0).then(function(n){return n}.closure(this))};this.Valid_Wwpnotificationlink=function(){return this.validCliEvt("Valid_Wwpnotificationlink",0,function(){try{var n=gx.util.balloon.getNew("WWPNOTIFICATIONLINK");if(this.AnyError=0,!gx.util.regExp.isMatch(this.A184WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$"))try{n.setError("Field Notification Link does not match the specified pattern");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Wwpuserextendedid=function(){return this.validSrvEvt("Valid_Wwpuserextendedid",0).then(function(n){return n}.closure(this))};this.e110o34_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e120o34_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98];this.GXLastCtrlId=98;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e130o34_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e140o34_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e150o34_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e160o34_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e170o34_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONID",fmt:0,gxz:"Z127WWPNotificationId",gxold:"O127WWPNotificationId",gxvar:"A127WWPNotificationId",ucs:[],op:[79,39,89,74,69,64,59,54,49],ip:[79,39,89,74,69,64,59,54,49,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A127WWPNotificationId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z127WWPNotificationId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONID",gx.O.A127WWPNotificationId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A127WWPNotificationId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONID",",")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationdefinitionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONID",fmt:0,gxz:"Z128WWPNotificationDefinitionId",gxold:"O128WWPNotificationDefinitionId",gxvar:"A128WWPNotificationDefinitionId",ucs:[],op:[44],ip:[44,39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A128WWPNotificationDefinitionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z128WWPNotificationDefinitionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONID",gx.O.A128WWPNotificationDefinitionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A128WWPNotificationDefinitionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WWPNOTIFICATIONDEFINITIONID",",")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONDEFINITIONNAME",fmt:0,gxz:"Z164WWPNotificationDefinitionName",gxold:"O164WWPNotificationDefinitionName",gxvar:"A164WWPNotificationDefinitionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A164WWPNotificationDefinitionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z164WWPNotificationDefinitionName=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONDEFINITIONNAME",gx.O.A164WWPNotificationDefinitionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A164WWPNotificationDefinitionName=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONDEFINITIONNAME")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"dtime",len:10,dec:12,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONCREATED",fmt:0,gxz:"Z129WWPNotificationCreated",gxold:"O129WWPNotificationCreated",gxvar:"A129WWPNotificationCreated",dp:{f:0,st:!0,wn:!1,mf:!0,pic:"99/99/9999 99:99:99.999",dec:12},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A129WWPNotificationCreated=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z129WWPNotificationCreated=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONCREATED",gx.O.A129WWPNotificationCreated,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A129WWPNotificationCreated=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getDateTimeValue("WWPNOTIFICATIONCREATED")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONICON",fmt:0,gxz:"Z181WWPNotificationIcon",gxold:"O181WWPNotificationIcon",gxvar:"A181WWPNotificationIcon",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A181WWPNotificationIcon=n)},v2z:function(n){n!==undefined&&(gx.O.Z181WWPNotificationIcon=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONICON",gx.O.A181WWPNotificationIcon,0)},c2v:function(){this.val()!==undefined&&(gx.O.A181WWPNotificationIcon=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONICON")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONTITLE",fmt:0,gxz:"Z182WWPNotificationTitle",gxold:"O182WWPNotificationTitle",gxvar:"A182WWPNotificationTitle",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A182WWPNotificationTitle=n)},v2z:function(n){n!==undefined&&(gx.O.Z182WWPNotificationTitle=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONTITLE",gx.O.A182WWPNotificationTitle,0)},c2v:function(){this.val()!==undefined&&(gx.O.A182WWPNotificationTitle=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONTITLE")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONSHORTDESCRIPTIO",fmt:0,gxz:"Z183WWPNotificationShortDescriptio",gxold:"O183WWPNotificationShortDescriptio",gxvar:"A183WWPNotificationShortDescriptio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A183WWPNotificationShortDescriptio=n)},v2z:function(n){n!==undefined&&(gx.O.Z183WWPNotificationShortDescriptio=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONSHORTDESCRIPTIO",gx.O.A183WWPNotificationShortDescriptio,0)},c2v:function(){this.val()!==undefined&&(gx.O.A183WWPNotificationShortDescriptio=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONSHORTDESCRIPTIO")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"svchar",len:1e3,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpnotificationlink,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONLINK",fmt:0,gxz:"Z184WWPNotificationLink",gxold:"O184WWPNotificationLink",gxvar:"A184WWPNotificationLink",ucs:[],op:[],ip:[69],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A184WWPNotificationLink=n)},v2z:function(n){n!==undefined&&(gx.O.Z184WWPNotificationLink=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONLINK",gx.O.A184WWPNotificationLink,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A184WWPNotificationLink=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONLINK")},nac:gx.falseFn};this.declareDomainHdlr(69,function(){});n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONISREAD",fmt:0,gxz:"Z187WWPNotificationIsRead",gxold:"O187WWPNotificationIsRead",gxvar:"A187WWPNotificationIsRead",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.A187WWPNotificationIsRead=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z187WWPNotificationIsRead=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("WWPNOTIFICATIONISREAD",gx.O.A187WWPNotificationIsRead,!0)},c2v:function(){this.val()!==undefined&&(gx.O.A187WWPNotificationIsRead=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONISREAD")},nac:gx.falseFn,values:["true","false"]};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Wwpuserextendedid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDID",fmt:0,gxz:"Z112WWPUserExtendedId",gxold:"O112WWPUserExtendedId",gxvar:"A112WWPUserExtendedId",ucs:[],op:[84],ip:[84,79],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A112WWPUserExtendedId=n)},v2z:function(n){n!==undefined&&(gx.O.Z112WWPUserExtendedId=n)},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDID",gx.O.A112WWPUserExtendedId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A112WWPUserExtendedId=this.val())},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDID")},nac:gx.falseFn};this.declareDomainHdlr(79,function(){});n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPUSEREXTENDEDFULLNAME",fmt:0,gxz:"Z113WWPUserExtendedFullName",gxold:"O113WWPUserExtendedFullName",gxvar:"A113WWPUserExtendedFullName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A113WWPUserExtendedFullName=n)},v2z:function(n){n!==undefined&&(gx.O.Z113WWPUserExtendedFullName=n)},v2c:function(){gx.fn.setControlValue("WWPUSEREXTENDEDFULLNAME",gx.O.A113WWPUserExtendedFullName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A113WWPUserExtendedFullName=this.val())},val:function(){return gx.fn.getControlValue("WWPUSEREXTENDEDFULLNAME")},nac:gx.falseFn};this.declareDomainHdlr(84,function(){});n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,fld:"",grid:0};n[89]={id:89,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWPNOTIFICATIONMETADATA",fmt:0,gxz:"Z165WWPNotificationMetadata",gxold:"O165WWPNotificationMetadata",gxvar:"A165WWPNotificationMetadata",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A165WWPNotificationMetadata=n)},v2z:function(n){n!==undefined&&(gx.O.Z165WWPNotificationMetadata=n)},v2c:function(){gx.fn.setControlValue("WWPNOTIFICATIONMETADATA",gx.O.A165WWPNotificationMetadata,0)},c2v:function(){this.val()!==undefined&&(gx.O.A165WWPNotificationMetadata=this.val())},val:function(){return gx.fn.getControlValue("WWPNOTIFICATIONMETADATA")},nac:gx.falseFn};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"BTN_ENTER",grid:0,evt:"e110o34_client",std:"ENTER"};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"BTN_CANCEL",grid:0,evt:"e120o34_client"};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"BTN_DELETE",grid:0,evt:"e180o34_client",std:"DELETE"};this.A127WWPNotificationId=0;this.Z127WWPNotificationId=0;this.O127WWPNotificationId=0;this.A128WWPNotificationDefinitionId=0;this.Z128WWPNotificationDefinitionId=0;this.O128WWPNotificationDefinitionId=0;this.A164WWPNotificationDefinitionName="";this.Z164WWPNotificationDefinitionName="";this.O164WWPNotificationDefinitionName="";this.A129WWPNotificationCreated=gx.date.nullDate();this.Z129WWPNotificationCreated=gx.date.nullDate();this.O129WWPNotificationCreated=gx.date.nullDate();this.A181WWPNotificationIcon="";this.Z181WWPNotificationIcon="";this.O181WWPNotificationIcon="";this.A182WWPNotificationTitle="";this.Z182WWPNotificationTitle="";this.O182WWPNotificationTitle="";this.A183WWPNotificationShortDescriptio="";this.Z183WWPNotificationShortDescriptio="";this.O183WWPNotificationShortDescriptio="";this.A184WWPNotificationLink="";this.Z184WWPNotificationLink="";this.O184WWPNotificationLink="";this.A187WWPNotificationIsRead=!1;this.Z187WWPNotificationIsRead=!1;this.O187WWPNotificationIsRead=!1;this.A112WWPUserExtendedId="";this.Z112WWPUserExtendedId="";this.O112WWPUserExtendedId="";this.A113WWPUserExtendedFullName="";this.Z113WWPUserExtendedFullName="";this.O113WWPUserExtendedFullName="";this.A165WWPNotificationMetadata="";this.Z165WWPNotificationMetadata="";this.O165WWPNotificationMetadata="";this.A127WWPNotificationId=0;this.Gx_BScreen=0;this.A128WWPNotificationDefinitionId=0;this.A164WWPNotificationDefinitionName="";this.A129WWPNotificationCreated=gx.date.nullDate();this.A181WWPNotificationIcon="";this.A182WWPNotificationTitle="";this.A183WWPNotificationShortDescriptio="";this.A184WWPNotificationLink="";this.A187WWPNotificationIsRead=!1;this.A112WWPUserExtendedId="";this.A113WWPUserExtendedFullName="";this.A165WWPNotificationMetadata="";this.Events={e110o34_client:["ENTER",!0],e120o34_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}],[{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}]];this.EvtParms.REFRESH=[[{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}],[{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}]];this.EvtParms.VALID_WWPNOTIFICATIONID=[[{av:"A127WWPNotificationId",fld:"WWPNOTIFICATIONID",pic:"ZZZZZZZZZ9"},{av:"Gx_BScreen",fld:"vGXBSCREEN",pic:"9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"A129WWPNotificationCreated",fld:"WWPNOTIFICATIONCREATED",pic:"99/99/9999 99:99:99.999"},{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}],[{av:"A128WWPNotificationDefinitionId",fld:"WWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"A129WWPNotificationCreated",fld:"WWPNOTIFICATIONCREATED",pic:"99/99/9999 99:99:99.999"},{av:"A181WWPNotificationIcon",fld:"WWPNOTIFICATIONICON"},{av:"A182WWPNotificationTitle",fld:"WWPNOTIFICATIONTITLE"},{av:"A183WWPNotificationShortDescriptio",fld:"WWPNOTIFICATIONSHORTDESCRIPTIO"},{av:"A184WWPNotificationLink",fld:"WWPNOTIFICATIONLINK"},{av:"A112WWPUserExtendedId",fld:"WWPUSEREXTENDEDID"},{av:"A165WWPNotificationMetadata",fld:"WWPNOTIFICATIONMETADATA"},{av:"A164WWPNotificationDefinitionName",fld:"WWPNOTIFICATIONDEFINITIONNAME"},{av:"A113WWPUserExtendedFullName",fld:"WWPUSEREXTENDEDFULLNAME"},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z127WWPNotificationId"},{av:"Z128WWPNotificationDefinitionId"},{av:"Z129WWPNotificationCreated"},{av:"Z181WWPNotificationIcon"},{av:"Z182WWPNotificationTitle"},{av:"Z183WWPNotificationShortDescriptio"},{av:"Z184WWPNotificationLink"},{av:"Z187WWPNotificationIsRead"},{av:"Z112WWPUserExtendedId"},{av:"Z165WWPNotificationMetadata"},{av:"Z164WWPNotificationDefinitionName"},{av:"Z113WWPUserExtendedFullName"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"},{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}]];this.EvtParms.VALID_WWPNOTIFICATIONDEFINITIONID=[[{av:"A128WWPNotificationDefinitionId",fld:"WWPNOTIFICATIONDEFINITIONID",pic:"ZZZZZZZZZ9"},{av:"A164WWPNotificationDefinitionName",fld:"WWPNOTIFICATIONDEFINITIONNAME"},{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}],[{av:"A164WWPNotificationDefinitionName",fld:"WWPNOTIFICATIONDEFINITIONNAME"},{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}]];this.EvtParms.VALID_WWPNOTIFICATIONLINK=[[{av:"A184WWPNotificationLink",fld:"WWPNOTIFICATIONLINK"},{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}],[{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}]];this.EvtParms.VALID_WWPUSEREXTENDEDID=[[{av:"A112WWPUserExtendedId",fld:"WWPUSEREXTENDEDID"},{av:"A113WWPUserExtendedFullName",fld:"WWPUSEREXTENDEDFULLNAME"},{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}],[{av:"A113WWPUserExtendedFullName",fld:"WWPUSEREXTENDEDFULLNAME"},{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD"}]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwpbaseobjects.notifications.common.wwp_notification)})