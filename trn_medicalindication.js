gx.evt.autoSkip=!1;gx.define("trn_medicalindication",!1,function(){var n,t;this.ServerClass="trn_medicalindication";this.PackageName="GeneXus.Programs";this.ServerFullClass="trn_medicalindication.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7MedicalIndicationId=gx.fn.getControlValue("vMEDICALINDICATIONID");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Medicalindicationid=function(){return this.validCliEvt("Valid_Medicalindicationid",0,function(){try{var n=gx.util.balloon.getNew("MEDICALINDICATIONID");if(this.AnyError=0,!gx.util.regExp.isMatch(this.A98MedicalIndicationId,"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}|^\\s*$)"))try{n.setError("GXM_InvalidGUID");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e120e2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e130e24_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140e24_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35];this.GXLastCtrlId=35;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelWithBorder Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","General Information","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MEDICALINDICATIONNAME",fmt:0,gxz:"Z99MedicalIndicationName",gxold:"O99MedicalIndicationName",gxvar:"A99MedicalIndicationName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A99MedicalIndicationName=n)},v2z:function(n){n!==undefined&&(gx.O.Z99MedicalIndicationName=n)},v2c:function(){gx.fn.setControlValue("MEDICALINDICATIONNAME",gx.O.A99MedicalIndicationName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A99MedicalIndicationName=this.val())},val:function(){return gx.fn.getControlValue("MEDICALINDICATIONNAME")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTNTRN_ENTER",grid:0,evt:"e130e24_client",std:"ENTER"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTNTRN_CANCEL",grid:0,evt:"e140e24_client"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"BTNTRN_DELETE",grid:0,evt:"e150e24_client",std:"DELETE"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[35]={id:35,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Medicalindicationid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MEDICALINDICATIONID",fmt:0,gxz:"Z98MedicalIndicationId",gxold:"O98MedicalIndicationId",gxvar:"A98MedicalIndicationId",ucs:[],op:[],ip:[35],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A98MedicalIndicationId=n)},v2z:function(n){n!==undefined&&(gx.O.Z98MedicalIndicationId=n)},v2c:function(){gx.fn.setControlValue("MEDICALINDICATIONID",gx.O.A98MedicalIndicationId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A98MedicalIndicationId=this.val())},val:function(){return gx.fn.getControlValue("MEDICALINDICATIONID")},nac:function(){return!(gx.text.compare("00000000-0000-0000-0000-000000000000",this.AV7MedicalIndicationId)==0)}};this.declareDomainHdlr(35,function(){});this.A99MedicalIndicationName="";this.Z99MedicalIndicationName="";this.O99MedicalIndicationName="";this.A98MedicalIndicationId="00000000-0000-0000-0000-000000000000";this.Z98MedicalIndicationId="00000000-0000-0000-0000-000000000000";this.O98MedicalIndicationId="00000000-0000-0000-0000-000000000000";this.AV8WWPContext={UserId:0,UserName:""};this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7MedicalIndicationId="00000000-0000-0000-0000-000000000000";this.AV12WebSession={};this.A98MedicalIndicationId="00000000-0000-0000-0000-000000000000";this.Gx_BScreen=0;this.A99MedicalIndicationName="";this.Gx_mode="";this.Events={e120e2_client:["AFTER TRN",!0],e130e24_client:["ENTER",!0],e140e24_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7MedicalIndicationId",fld:"vMEDICALINDICATIONID",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",hsh:!0},{av:"AV7MedicalIndicationId",fld:"vMEDICALINDICATIONID",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",hsh:!0}],[]];this.EvtParms.VALID_MEDICALINDICATIONID=[[{av:"A98MedicalIndicationId",fld:"MEDICALINDICATIONID"}],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7MedicalIndicationId","vMEDICALINDICATIONID",0,"guid",8,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.trn_medicalindication)})