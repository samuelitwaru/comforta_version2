gx.evt.autoSkip=!1;gx.define("gamconfiguration",!1,function(){var n,t;this.ServerClass="gamconfiguration";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamconfiguration.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){};this.Validv_Enabletracing=function(){return this.validCliEvt("Validv_Enabletracing",0,function(){try{var n=gx.util.balloon.getNew("vENABLETRACING");if(this.AnyError=0,!(this.AV7EnableTracing==0||this.AV7EnableTracing==1))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Enable tracing"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e129m2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e149m1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49];this.GXLastCtrlId=49;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelWithBorder Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title",gx.getMessage("GAM Configuration"),"str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGAMDATABASEVERSION",fmt:0,gxz:"ZV12GAMDatabaseVersion",gxold:"OV12GAMDatabaseVersion",gxvar:"AV12GAMDatabaseVersion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12GAMDatabaseVersion=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12GAMDatabaseVersion=n)},v2c:function(){gx.fn.setControlValue("vGAMDATABASEVERSION",gx.O.AV12GAMDatabaseVersion,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12GAMDatabaseVersion=this.val())},val:function(){return gx.fn.getControlValue("vGAMDATABASEVERSION")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGAMAPIVERSION",fmt:0,gxz:"ZV11GAMAPIVersion",gxold:"OV11GAMAPIVersion",gxvar:"AV11GAMAPIVersion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11GAMAPIVersion=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11GAMAPIVersion=n)},v2c:function(){gx.fn.setControlValue("vGAMAPIVERSION",gx.O.AV11GAMAPIVersion,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV11GAMAPIVersion=this.val())},val:function(){return gx.fn.getControlValue("vGAMAPIVERSION")},nac:gx.falseFn};this.declareDomainHdlr(27,function(){});n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"DEFAULTREPOSITORY_CELL",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDEFAULTREPOSITORY",fmt:0,gxz:"ZV5DefaultRepository",gxold:"OV5DefaultRepository",gxvar:"AV5DefaultRepository",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV5DefaultRepository=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5DefaultRepository=n)},v2c:function(){gx.fn.setComboBoxValue("vDEFAULTREPOSITORY",gx.O.AV5DefaultRepository);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV5DefaultRepository=this.val())},val:function(){return gx.fn.getControlValue("vDEFAULTREPOSITORY")},nac:gx.falseFn};this.declareDomainHdlr(32,function(){});n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"EMAILREGULAREXPRESSION_CELL",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEMAILREGULAREXPRESSION",fmt:0,gxz:"ZV6EmailRegularExpression",gxold:"OV6EmailRegularExpression",gxvar:"AV6EmailRegularExpression",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6EmailRegularExpression=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6EmailRegularExpression=n)},v2c:function(){gx.fn.setControlValue("vEMAILREGULAREXPRESSION",gx.O.AV6EmailRegularExpression,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6EmailRegularExpression=this.val())},val:function(){return gx.fn.getControlValue("vEMAILREGULAREXPRESSION")},nac:gx.falseFn};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Validv_Enabletracing,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vENABLETRACING",fmt:0,gxz:"ZV7EnableTracing",gxold:"OV7EnableTracing",gxvar:"AV7EnableTracing",ucs:[],op:[42],ip:[42],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV7EnableTracing=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7EnableTracing=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vENABLETRACING",gx.O.AV7EnableTracing);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV7EnableTracing=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vENABLETRACING",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(42,function(){});n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"BTNENTER",grid:0,evt:"e129m2_client",std:"ENTER"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTNCANCEL",grid:0,evt:"e149m1_client"};this.AV12GAMDatabaseVersion="";this.ZV12GAMDatabaseVersion="";this.OV12GAMDatabaseVersion="";this.AV11GAMAPIVersion="";this.ZV11GAMAPIVersion="";this.OV11GAMAPIVersion="";this.AV5DefaultRepository="";this.ZV5DefaultRepository="";this.OV5DefaultRepository="";this.AV6EmailRegularExpression="";this.ZV6EmailRegularExpression="";this.OV6EmailRegularExpression="";this.AV7EnableTracing=0;this.ZV7EnableTracing=0;this.OV7EnableTracing=0;this.AV12GAMDatabaseVersion="";this.AV11GAMAPIVersion="";this.AV5DefaultRepository="";this.AV6EmailRegularExpression="";this.AV7EnableTracing=0;this.Events={e129m2_client:["ENTER",!0],e149m1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV12GAMDatabaseVersion",fld:"vGAMDATABASEVERSION"}],[]];this.EvtParms.ENTER=[[{ctrl:"vENABLETRACING"},{av:"AV7EnableTracing",fld:"vENABLETRACING",pic:"ZZZ9"},{av:"AV6EmailRegularExpression",fld:"vEMAILREGULAREXPRESSION"},{ctrl:"vDEFAULTREPOSITORY"},{av:"AV5DefaultRepository",fld:"vDEFAULTREPOSITORY"}],[]];this.EvtParms.VALIDV_ENABLETRACING=[[],[]];this.EnterCtrl=["BTNENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamconfiguration)})