gx.evt.autoSkip=!1;gx.define("gam_wwroles",!1,function(){var n,t;this.ServerClass="gam_wwroles";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_wwroles.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.AV27SearchFilter=gx.fn.getControlValue("vSEARCHFILTER");this.subGridww_Recordcount=gx.fn.getIntegerValue("subGridww_Recordcount",gx.thousandSeparator)};this.e23061_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.refreshOutputs([]);this.refreshGrid("Gridww");this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e11061_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("gam_roleentry.aspx",["INS",0],null,["Mode","Id"]);this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e21062_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("gam_roleentry.aspx",["DSP",this.AV12Id],null,["Mode","Id"]);this.refreshOutputs([{av:"AV12Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]);this.OnClientEventEnd()},arguments)};this.e22062_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("gam_roleentry.aspx",["UPD",this.AV12Id],null,["Mode","Id"]);this.refreshOutputs([{av:"AV12Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]);this.OnClientEventEnd()},arguments)};this.s112_client=function(){return this.executeClientEvent(function(){this.createWebComponent("Wcmessages","GAM_Messages",[])},arguments)};this.e18061_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV8CurrentPage=gx.num.trunc(1,0);this.refreshOutputs([{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.refreshGrid("Gridww");this.refreshOutputs([{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.OnClientEventEnd()},arguments)};this.e19061_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV8CurrentPage=gx.num.trunc(this.AV8CurrentPage-1,0);this.refreshOutputs([{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.refreshGrid("Gridww");this.refreshOutputs([{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.OnClientEventEnd()},arguments)};this.e20061_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV8CurrentPage=gx.num.trunc(this.AV8CurrentPage+1,0);this.refreshOutputs([{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.refreshGrid("Gridww");this.refreshOutputs([{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.OnClientEventEnd()},arguments)};this.e12061_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("GAM_FILTERSWW","Class"),"filters-container")==0?(gx.fn.setCtrlProperty("GAM_FILTERSWW","Class",gx.text.format("%1 %2","filters-container","filters-container-floating--visible","","","","","","","")),gx.fn.setCtrlProperty("GAM_HEADERWW_TOGGLEFILTERS","Tooltiptext",gx.getMessage("GAM_Hidefilters"))):(gx.fn.setCtrlProperty("GAM_FILTERSWW","Class","filters-container"),gx.fn.setCtrlProperty("GAM_HEADERWW_TOGGLEFILTERS","Tooltiptext",gx.getMessage("GAM_Showfilters")));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('GAM_FILTERSWW','Class')",ctrl:"GAM_FILTERSWW",prop:"Class"},{av:"gx.fn.getCtrlProperty('GAM_HEADERWW_TOGGLEFILTERS','Tooltiptext')",ctrl:"GAM_HEADERWW_TOGGLEFILTERS",prop:"Tooltiptext"}]);this.OnClientEventEnd()},arguments)};this.e14061_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.refreshOutputs([]);this.refreshGrid("Gridww");this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e13061_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV24FilRoleGUID="";this.AV26FilRoleExternalId="";this.refreshOutputs([{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"}]);this.refreshGrid("Gridww");this.refreshOutputs([{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"}]);this.OnClientEventEnd()},arguments)};this.e17062_client=function(){return this.executeServerEvent("VBTNSAVEAS.CLICK",!0,arguments[0],!1,!1)};this.e24062_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e25062_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,26,27,28,29,30,31,32,33,34,35,38,40,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70];this.GXLastCtrlId=70;this.GridwwContainer=new gx.grid.grid(this,2,"WbpLvl2",25,"Gridww","Gridww","GridwwContainer",this.CmpContext,this.IsMasterPage,"gam_wwroles",[],!1,1,!0,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridwwContainer;t.addSingleLineEdit("Name",26,"vNAME",gx.getMessage("GAM_RoleName"),"","Name","char",0,"px",254,80,"start","e21062_client",[],"Name","Name",!0,0,!1,!1,"Attribute",0,"column");t.addSingleLineEdit("Btnsaveas",27,"vBTNSAVEAS","","","BtnSaveAs","char",0,"px",20,20,"start","e17062_client",[],"Btnsaveas","BtnSaveAs",!0,0,!1,!1,"TextActionAttribute",0,"WWTextActionColumn column-optional");t.addSingleLineEdit("Btnupd",28,"vBTNUPD","","","BtnUpd","char",0,"px",20,20,"start","e22062_client",[],"Btnupd","BtnUpd",!0,0,!1,!1,"TextActionAttribute",0,"WWTextActionColumn column-optional");t.addSingleLineEdit("Id",29,"vID",gx.getMessage("GAM_KeyNumericLong"),"","Id","int",0,"px",12,12,"end",null,[],"Id","Id",!1,0,!1,!1,"Attribute",0,"");this.GridwwContainer.emptyText=gx.getMessage("No results found.");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"GAM_HEADERWW",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"GAM_HEADERWW_TABLEACTIONS",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"GAM_HEADERWW_TITLE",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"GAM_HEADERWW_ADDNEW",grid:0,evt:"e11061_client"};n[14]={id:14,fld:"CELLSEARCH",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:"e23061_client",evt_cvcing:null,rgrid:[],fld:"vSEARCH",fmt:0,gxz:"ZV18Search",gxold:"OV18Search",gxvar:"AV18Search",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18Search=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18Search=n)},v2c:function(){gx.fn.setControlValue("vSEARCH",gx.O.AV18Search,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV18Search=this.val())},val:function(){return gx.fn.getControlValue("vSEARCH")},nac:gx.falseFn};this.declareDomainHdlr(16,function(){});n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GAM_HEADERWW_TOGGLEFILTERS",grid:0,evt:"e12061_client"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"SECTION1",grid:0};n[22]={id:22,fld:"GRIDCONTAINER",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[26]={id:26,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:25,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV14Name",gxold:"OV14Name",gxvar:"AV14Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(25),gx.O.AV14Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn,evt:"e21062_client"};n[27]={id:27,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:25,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNSAVEAS",fmt:0,gxz:"ZV5BtnSaveAs",gxold:"OV5BtnSaveAs",gxvar:"AV5BtnSaveAs",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV5BtnSaveAs=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5BtnSaveAs=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNSAVEAS",n||gx.fn.currentGridRowImpl(25),gx.O.AV5BtnSaveAs,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5BtnSaveAs=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNSAVEAS",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn,evt:"e17062_client"};n[28]={id:28,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:25,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNUPD",fmt:0,gxz:"ZV6BtnUpd",gxold:"OV6BtnUpd",gxvar:"AV6BtnUpd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV6BtnUpd=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6BtnUpd=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(25),gx.O.AV6BtnUpd,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV6BtnUpd=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn,evt:"e22062_client"};n[29]={id:29,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:25,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV12Id",gxold:"OV12Id",gxvar:"AV12Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV12Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(25),gx.O.AV12Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(25),gx.thousandSeparator)},nac:gx.falseFn};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"GAM_PAGINGWW",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"GAM_PAGINGWW_TBLPAGINGBUTTONS",grid:0};n[38]={id:38,fld:"GAM_PAGINGWW_BTNFIRST",grid:0,evt:"e18061_client"};n[40]={id:40,fld:"GAM_PAGINGWW_BTNPREVIOUS",grid:0,evt:"e19061_client"};n[42]={id:42,fld:"GAM_PAGINGWW_BTNNEXT",grid:0,evt:"e20061_client"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCURRENTPAGE",fmt:0,gxz:"ZV8CurrentPage",gxold:"OV8CurrentPage",gxvar:"AV8CurrentPage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8CurrentPage=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8CurrentPage=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCURRENTPAGE",gx.O.AV8CurrentPage,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8CurrentPage=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCURRENTPAGE",gx.thousandSeparator)},nac:gx.falseFn};n[47]={id:47,fld:"GAM_FILTERSWW",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"GAM_FILTERSWW_HIDEFILTERS",grid:0,evt:"e12061_client"};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"GAM_FILTERSWW_TABLEFILTERS",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILROLEGUID",fmt:0,gxz:"ZV24FilRoleGUID",gxold:"OV24FilRoleGUID",gxvar:"AV24FilRoleGUID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV24FilRoleGUID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24FilRoleGUID=n)},v2c:function(){gx.fn.setControlValue("vFILROLEGUID",gx.O.AV24FilRoleGUID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV24FilRoleGUID=this.val())},val:function(){return gx.fn.getControlValue("vFILROLEGUID")},nac:gx.falseFn};this.declareDomainHdlr(58,function(){});n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILROLEEXTERNALID",fmt:0,gxz:"ZV26FilRoleExternalId",gxold:"OV26FilRoleExternalId",gxvar:"AV26FilRoleExternalId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV26FilRoleExternalId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV26FilRoleExternalId=n)},v2c:function(){gx.fn.setControlValue("vFILROLEEXTERNALID",gx.O.AV26FilRoleExternalId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV26FilRoleExternalId=this.val())},val:function(){return gx.fn.getControlValue("vFILROLEEXTERNALID")},nac:gx.falseFn};this.declareDomainHdlr(63,function(){});n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"GAM_FILTERSWW_CLEARFILTERS",grid:0,evt:"e13061_client"};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"GAM_FILTERSWW_APPLY",grid:0,evt:"e14061_client"};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};this.AV18Search="";this.ZV18Search="";this.OV18Search="";this.ZV14Name="";this.OV14Name="";this.ZV5BtnSaveAs="";this.OV5BtnSaveAs="";this.ZV6BtnUpd="";this.OV6BtnUpd="";this.ZV12Id=0;this.OV12Id=0;this.AV8CurrentPage=0;this.ZV8CurrentPage=0;this.OV8CurrentPage=0;this.AV24FilRoleGUID="";this.ZV24FilRoleGUID="";this.OV24FilRoleGUID="";this.AV26FilRoleExternalId="";this.ZV26FilRoleExternalId="";this.OV26FilRoleExternalId="";this.AV18Search="";this.AV8CurrentPage=0;this.AV24FilRoleGUID="";this.AV26FilRoleExternalId="";this.AV14Name="";this.AV5BtnSaveAs="";this.AV6BtnUpd="";this.AV12Id=0;this.AV27SearchFilter="";this.Events={e17062_client:["VBTNSAVEAS.CLICK",!0],e24062_client:["ENTER",!0],e25062_client:["CANCEL",!0],e23061_client:["VSEARCH.CONTROLVALUECHANGED",!1],e11061_client:["'ADDNEW'",!1],e21062_client:["VNAME.CLICK",!1],e22062_client:["VBTNUPD.CLICK",!1],e18061_client:["'FIRST'",!1],e19061_client:["'PREVIOUS'",!1],e20061_client:["'NEXT'",!1],e12061_client:["'HIDE'",!1],e14061_client:["'APPLY'",!1],e13061_client:["'CLEARFILTERS'",!1]};this.EvtParms.REFRESH=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV18Search",fld:"vSEARCH"},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"},{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"},{av:"AV27SearchFilter",fld:"vSEARCHFILTER",hsh:!0}],[]];this.EvtParms["VSEARCH.CONTROLVALUECHANGED"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV18Search",fld:"vSEARCH"},{av:"AV27SearchFilter",fld:"vSEARCHFILTER",hsh:!0},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"},{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"}],[]];this.EvtParms["GRIDWW.LOAD"]=[[{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV18Search",fld:"vSEARCH"},{av:"AV27SearchFilter",fld:"vSEARCHFILTER",hsh:!0},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"},{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"}],[{av:"AV6BtnUpd",fld:"vBTNUPD"},{av:"AV5BtnSaveAs",fld:"vBTNSAVEAS"},{av:"AV12Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV14Name",fld:"vNAME"},{ctrl:"GAM_PAGINGWW_BTNNEXT",prop:"Enabled"},{ctrl:"GAM_PAGINGWW_BTNFIRST",prop:"Enabled"},{ctrl:"GAM_PAGINGWW_BTNPREVIOUS",prop:"Enabled"}]];this.EvtParms["'ADDNEW'"]=[[],[]];this.EvtParms["VNAME.CLICK"]=[[{av:"AV12Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV12Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNUPD.CLICK"]=[[{av:"AV12Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV12Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNSAVEAS.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV18Search",fld:"vSEARCH"},{av:"AV27SearchFilter",fld:"vSEARCHFILTER",hsh:!0},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"},{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"},{av:"AV12Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{ctrl:"WCMESSAGES"}]];this.EvtParms["'FIRST'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV18Search",fld:"vSEARCH"},{av:"AV27SearchFilter",fld:"vSEARCHFILTER",hsh:!0},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"},{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"}],[{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]];this.EvtParms["'PREVIOUS'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV18Search",fld:"vSEARCH"},{av:"AV27SearchFilter",fld:"vSEARCHFILTER",hsh:!0},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"},{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"}],[{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]];this.EvtParms["'NEXT'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV18Search",fld:"vSEARCH"},{av:"AV27SearchFilter",fld:"vSEARCHFILTER",hsh:!0},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"},{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"}],[{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]];this.EvtParms["'HIDE'"]=[[{av:"gx.fn.getCtrlProperty('GAM_FILTERSWW','Class')",ctrl:"GAM_FILTERSWW",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('GAM_FILTERSWW','Class')",ctrl:"GAM_FILTERSWW",prop:"Class"},{av:"gx.fn.getCtrlProperty('GAM_HEADERWW_TOGGLEFILTERS','Tooltiptext')",ctrl:"GAM_HEADERWW_TOGGLEFILTERS",prop:"Tooltiptext"}]];this.EvtParms["'APPLY'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV18Search",fld:"vSEARCH"},{av:"AV27SearchFilter",fld:"vSEARCHFILTER",hsh:!0},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"},{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"}],[]];this.EvtParms["'CLEARFILTERS'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV8CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV18Search",fld:"vSEARCH"},{av:"AV27SearchFilter",fld:"vSEARCHFILTER",hsh:!0},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"},{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"}],[{av:"AV24FilRoleGUID",fld:"vFILROLEGUID"},{av:"AV26FilRoleExternalId",fld:"vFILROLEEXTERNALID"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV27SearchFilter","vSEARCHFILTER",0,"svchar",100,60);this.setVCMap("AV27SearchFilter","vSEARCHFILTER",0,"svchar",100,60);this.setVCMap("AV27SearchFilter","vSEARCHFILTER",0,"svchar",100,60);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar({rfrVar:"AV27SearchFilter"});t.addRefreshingVar(this.GXValidFnc[63]);t.addRefreshingVar(this.GXValidFnc[58]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm({rfrVar:"AV27SearchFilter"});t.addRefreshingParm(this.GXValidFnc[63]);t.addRefreshingParm(this.GXValidFnc[58]);this.Initialize();this.setComponent({id:"WCMESSAGES",GXClass:null,Prefix:"W0071",lvl:1})});gx.wi(function(){gx.createParentObj(this.gam_wwroles)})