gx.evt.autoSkip=!1;gx.define("trn_mediageneral",!0,function(n){this.ServerClass="trn_mediageneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="trn_mediageneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV12IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV13IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE")};this.Valid_Trn_mediaid=function(){return this.validCliEvt("Valid_Trn_mediaid",0,function(){try{var n=gx.util.balloon.getNew("TRN_MEDIAID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e133o2_client=function(){return this.executeServerEvent("'DOUPDATE'",!1,null,!1,!1)};this.e143o2_client=function(){return this.executeServerEvent("'DODELETE'",!1,null,!1,!1)};this.e153o2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e163o2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30];this.GXLastCtrlId=30;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEATTRIBUTES",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Valid_Trn_mediaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_MEDIAID",fmt:0,gxz:"Z252Trn_MediaId",gxold:"O252Trn_MediaId",gxvar:"A252Trn_MediaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A252Trn_MediaId=n)},v2z:function(n){n!==undefined&&(gx.O.Z252Trn_MediaId=n)},v2c:function(){gx.fn.setControlValue("TRN_MEDIAID",gx.O.A252Trn_MediaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A252Trn_MediaId=this.val())},val:function(){return gx.fn.getControlValue("TRN_MEDIAID")},nac:gx.falseFn};this.declareDomainHdlr(14,function(){});t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_MEDIANAME",fmt:0,gxz:"Z253Trn_MediaName",gxold:"O253Trn_MediaName",gxvar:"A253Trn_MediaName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A253Trn_MediaName=n)},v2z:function(n){n!==undefined&&(gx.O.Z253Trn_MediaName=n)},v2c:function(){gx.fn.setControlValue("TRN_MEDIANAME",gx.O.A253Trn_MediaName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A253Trn_MediaName=this.val())},val:function(){return gx.fn.getControlValue("TRN_MEDIANAME")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"svchar",len:1e3,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_MEDIAURL",fmt:0,gxz:"Z254Trn_MediaUrl",gxold:"O254Trn_MediaUrl",gxvar:"A254Trn_MediaUrl",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A254Trn_MediaUrl=n)},v2z:function(n){n!==undefined&&(gx.O.Z254Trn_MediaUrl=n)},v2c:function(){gx.fn.setControlValue("TRN_MEDIAURL",gx.O.A254Trn_MediaUrl,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A254Trn_MediaUrl=this.val())},val:function(){return gx.fn.getControlValue("TRN_MEDIAURL")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"BTNUPDATE",grid:0,evt:"e133o2_client"};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"BTNDELETE",grid:0,evt:"e143o2_client"};this.A252Trn_MediaId="00000000-0000-0000-0000-000000000000";this.Z252Trn_MediaId="00000000-0000-0000-0000-000000000000";this.O252Trn_MediaId="00000000-0000-0000-0000-000000000000";this.A253Trn_MediaName="";this.Z253Trn_MediaName="";this.O253Trn_MediaName="";this.A254Trn_MediaUrl="";this.Z254Trn_MediaUrl="";this.O254Trn_MediaUrl="";this.A252Trn_MediaId="00000000-0000-0000-0000-000000000000";this.A253Trn_MediaName="";this.A254Trn_MediaUrl="";this.AV12IsAuthorized_Update=!1;this.AV13IsAuthorized_Delete=!1;this.Events={e133o2_client:["'DOUPDATE'",!0],e143o2_client:["'DODELETE'",!0],e153o2_client:["ENTER",!0],e163o2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A252Trn_MediaId",fld:"TRN_MEDIAID"},{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"A254Trn_MediaUrl",fld:"TRN_MEDIAURL"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"A252Trn_MediaId",fld:"TRN_MEDIAID"}],[{ctrl:"BTNUPDATE",prop:"Visible"}]];this.EvtParms["'DODELETE'"]=[[{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"A252Trn_MediaId",fld:"TRN_MEDIAID"}],[{ctrl:"BTNDELETE",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_TRN_MEDIAID=[[],[]];this.setVCMap("AV12IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV13IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.Initialize()})