gx.evt.autoSkip=!1;gx.define("wp_createorganisationandmanager",!1,function(){this.ServerClass="wp_createorganisationandmanager";this.PackageName="GeneXus.Programs";this.ServerFullClass="wp_createorganisationandmanager.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV10PreviousStep=gx.fn.getControlValue("vPREVIOUSSTEP");this.AV11CurrentStep=gx.fn.getControlValue("vCURRENTSTEP");this.AV9GoingBack=gx.fn.getControlValue("vGOINGBACK")};this.e134e2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e144e2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6];this.GXLastCtrlId=6;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};this.AV10PreviousStep="";this.AV11CurrentStep="";this.AV9GoingBack=!1;this.Events={e134e2_client:["ENTER",!0],e144e2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV10PreviousStep",fld:"vPREVIOUSSTEP",hsh:!0},{av:"AV11CurrentStep",fld:"vCURRENTSTEP",hsh:!0},{av:"AV9GoingBack",fld:"vGOINGBACK",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV10PreviousStep","vPREVIOUSSTEP",0,"svchar",40,0);this.setVCMap("AV11CurrentStep","vCURRENTSTEP",0,"svchar",40,0);this.setVCMap("AV9GoingBack","vGOINGBACK",0,"boolean",4,0);this.Initialize();this.setComponent({id:"STEPTITLES",GXClass:null,Prefix:"W0009",lvl:1});this.setComponent({id:"WIZARDSTEPWC",GXClass:null,Prefix:"W0012",lvl:1})});gx.wi(function(){gx.createParentObj(this.wp_createorganisationandmanager)})