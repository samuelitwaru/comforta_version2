gx.evt.autoSkip=!1;gx.define("gamremotelogin",!1,function(){var n,t;this.ServerClass="gamremotelogin";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamremotelogin.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV17IDP_State=gx.fn.getControlValue("vIDP_STATE");this.AV24Language=gx.fn.getControlValue("vLANGUAGE");this.AV38UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",",")};this.e120y2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140y2_client=function(){return this.executeServerEvent("VLOGONTO.CLICK",!0,null,!1,!0)};this.e150y2_client=function(){return this.executeServerEvent("'FORGOTPASSWORD'",!0,null,!1,!1)};this.e170y2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,55,56,57,58];this.GXLastCtrlId=58;this.WWPUTILITIESContainer=gx.uc.getNew(this,54,22,"DVelop_WorkWithPlusUtilities","WWPUTILITIESContainer","Wwputilities","WWPUTILITIES");t=this.WWPUTILITIESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("EnableAutoUpdateFromDocumentTitle","Enableautoupdatefromdocumenttitle",!1,"bool");t.setProp("EnableFixObjectFitCover","Enablefixobjectfitcover",!0,"bool");t.setProp("EnableFloatingLabels","Enablefloatinglabels",!1,"bool");t.setProp("EmpowerTabs","Empowertabs",!1,"bool");t.setProp("EnableUpdateRowSelectionStatus","Enableupdaterowselectionstatus",!1,"bool");t.setProp("CurrentTab_ReturnUrl","Currenttab_returnurl","","char");t.setProp("EnableConvertComboToBootstrapSelect","Enableconvertcombotobootstrapselect",!0,"bool");t.setProp("AllowColumnResizing","Allowcolumnresizing",!0,"bool");t.setProp("AllowColumnReordering","Allowcolumnreordering",!0,"bool");t.setProp("AllowColumnDragging","Allowcolumndragging",!1,"bool");t.setProp("AllowColumnsRestore","Allowcolumnsrestore",!0,"bool");t.setProp("RestoreColumnsIconClass","Restorecolumnsiconclass","fas fa-undo","str");t.setProp("PagBarIncludeGoTo","Pagbarincludegoto",!1,"bool");t.setProp("ComboLoadType","Comboloadtype","InfiniteScrolling","str");t.setProp("InfiniteScrollingPage","Infinitescrollingpage",10,"num");t.setProp("UpdateButtonText","Updatebuttontext","WWP_ColumnsSelectorButton","str");t.setProp("AddNewOption","Addnewoption","WWP_AddNewOption","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","WWP_OnlySelectedValues","str");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");t.setProp("SelectAll","Selectall","WWP_SelectAll","str");t.setProp("SortASC","Sortasc","WWP_TSSortASC","str");t.setProp("SortDSC","Sortdsc","WWP_TSSortDSC","str");t.setProp("AllowGroupText","Allowgrouptext","WWP_GroupByOption","str");t.setProp("FixLeftText","Fixlefttext","WWP_TSFixLeft","str");t.setProp("FixRightText","Fixrighttext","WWP_TSFixRight","str");t.setProp("LoadingData","Loadingdata","WWP_TSLoading","str");t.setProp("CleanFilter","Cleanfilter","WWP_TSCleanFilter","str");t.setProp("RangeFilterFrom","Rangefilterfrom","WWP_TSFrom","str");t.setProp("RangeFilterTo","Rangefilterto","WWP_TSTo","str");t.setProp("RangePickerInviteMessage","Rangepickerinvitemessage","WWP_TSRangePickerInviteMessage","str");t.setProp("NoResultsFound","Noresultsfound","WWP_TSNoResults","str");t.setProp("SearchButtonText","Searchbuttontext","WWP_TSSearchButtonCaption","str");t.setProp("SearchMultipleValuesButtonText","Searchmultiplevaluesbuttontext","WWP_FilterSelected","str");t.setProp("ColumnSelectorFixedLeftCategory","Columnselectorfixedleftcategory","WWP_ColumnSelectorFixedLeftCategory","str");t.setProp("ColumnSelectorFixedRightCategory","Columnselectorfixedrightcategory","WWP_ColumnSelectorFixedRightCategory","str");t.setProp("ColumnSelectorNotFixedCategory","Columnselectornotfixedcategory","WWP_ColumnSelectorNotFixedCategory","str");t.setProp("ColumnSelectorNoCategoryText","Columnselectornocategorytext","WWP_ColumnSelectorNoCategoryText","str");t.setProp("ColumnSelectorFixedEmpty","Columnselectorfixedempty","WWP_ColumnSelectorFixedEmpty","str");t.setProp("ColumnSelectorRestoreTooltip","Columnselectorrestoretooltip","WWP_SelectColumns_RestoreDefault","str");t.setProp("PagBarGoToCaption","Pagbargotocaption","WWP_PaginationBarGoToCaption","str");t.setProp("PagBarGoToIconClass","Pagbargotoiconclass","fas fa-redo","str");t.setProp("PagBarGoToTooltip","Pagbargototooltip","WWP_PaginationBarGoToTooltip","str");t.setProp("PagBarEmptyFilteredGridCaption","Pagbaremptyfilteredgridcaption","WWP_PaginationBarEmptyFilteredGridCaption","str");t.setProp("IncludeLineSeparator","Includelineseparator",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLELOGINCONTENT",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLELOGIN",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"LOGOLOGIN",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"UNNAMEDTABLE1",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"LOGOAPPCLIENT_CELL",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOGOAPPCLIENT",fmt:0,gxz:"ZV26LogoAppClient",gxold:"OV26LogoAppClient",gxvar:"AV26LogoAppClient",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV26LogoAppClient=n)},v2z:function(n){n!==undefined&&(gx.O.ZV26LogoAppClient=n)},v2c:function(){gx.fn.setMultimediaValue("vLOGOAPPCLIENT",gx.O.AV26LogoAppClient,gx.O.AV76Logoappclient_GXI)},c2v:function(){gx.O.AV76Logoappclient_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.AV26LogoAppClient=this.val())},val:function(){return gx.fn.getBlobValue("vLOGOAPPCLIENT")},val_GXI:function(){return gx.fn.getControlValue("vLOGOAPPCLIENT_GXI")},gxvar_GXI:"AV76Logoappclient_GXI",nac:gx.falseFn};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"TBAPPNAME",format:0,grid:0,ctrltype:"textblock"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLOGONTO",fmt:0,gxz:"ZV27LogOnTo",gxold:"OV27LogOnTo",gxvar:"AV27LogOnTo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV27LogOnTo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV27LogOnTo=n)},v2c:function(){gx.fn.setComboBoxValue("vLOGONTO",gx.O.AV27LogOnTo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV27LogOnTo=this.val())},val:function(){return gx.fn.getControlValue("vLOGONTO")},nac:gx.falseFn,evt:"e140y2_client"};this.declareDomainHdlr(29,function(){});n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV36UserName",gxold:"OV36UserName",gxvar:"AV36UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV36UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV36UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV36UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV36UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV37UserPassword",gxold:"OV37UserPassword",gxvar:"AV37UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV37UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV37UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV37UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV37UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(37,function(){});n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TBFORGOTPWD",format:1,grid:0,ctrltype:"textblock"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"KEEPMELOGGEDIN_CELL",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vKEEPMELOGGEDIN",fmt:0,gxz:"ZV23KeepMeLoggedIn",gxold:"OV23KeepMeLoggedIn",gxvar:"AV23KeepMeLoggedIn",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV23KeepMeLoggedIn=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV23KeepMeLoggedIn=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vKEEPMELOGGEDIN",gx.O.AV23KeepMeLoggedIn,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV23KeepMeLoggedIn=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vKEEPMELOGGEDIN")},nac:gx.falseFn,values:["true","false"]};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"REMEMBERME_CELL",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vREMEMBERME",fmt:0,gxz:"ZV29RememberMe",gxold:"OV29RememberMe",gxvar:"AV29RememberMe",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV29RememberMe=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV29RememberMe=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vREMEMBERME",gx.O.AV29RememberMe,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV29RememberMe=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vREMEMBERME")},nac:gx.falseFn,values:["true","false"]};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNENTER",grid:0,evt:"e120y2_client",std:"ENTER"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[58]={id:58,lvl:0,type:"svchar",len:2048,dec:250,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vURL",fmt:0,gxz:"ZV35URL",gxold:"OV35URL",gxvar:"AV35URL",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV35URL=n)},v2z:function(n){n!==undefined&&(gx.O.ZV35URL=n)},v2c:function(){gx.fn.setControlValue("vURL",gx.O.AV35URL,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV35URL=this.val())},val:function(){return gx.fn.getControlValue("vURL")},nac:gx.falseFn};this.declareDomainHdlr(58,function(){});this.AV76Logoappclient_GXI="";this.AV26LogoAppClient="";this.ZV26LogoAppClient="";this.OV26LogoAppClient="";this.AV27LogOnTo="";this.ZV27LogOnTo="";this.OV27LogOnTo="";this.AV36UserName="";this.ZV36UserName="";this.OV36UserName="";this.AV37UserPassword="";this.ZV37UserPassword="";this.OV37UserPassword="";this.AV23KeepMeLoggedIn=!1;this.ZV23KeepMeLoggedIn=!1;this.OV23KeepMeLoggedIn=!1;this.AV29RememberMe=!1;this.ZV29RememberMe=!1;this.OV29RememberMe=!1;this.AV35URL="";this.ZV35URL="";this.OV35URL="";this.AV26LogoAppClient="";this.AV27LogOnTo="";this.AV36UserName="";this.AV37UserPassword="";this.AV23KeepMeLoggedIn=!1;this.AV29RememberMe=!1;this.AV35URL="";this.AV17IDP_State="";this.AV24Language="";this.AV38UserRememberMe=0;this.Events={e120y2_client:["ENTER",!0],e140y2_client:["VLOGONTO.CLICK",!0],e150y2_client:["'FORGOTPASSWORD'",!0],e170y2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV17IDP_State",fld:"vIDP_STATE"},{av:"AV36UserName",fld:"vUSERNAME"},{av:"AV23KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN"},{av:"AV29RememberMe",fld:"vREMEMBERME"},{av:"AV24Language",fld:"vLANGUAGE",hsh:!0},{av:"AV38UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0}],[{av:"AV17IDP_State",fld:"vIDP_STATE"},{av:"AV37UserPassword",fld:"vUSERPASSWORD"},{av:"gx.fn.getCtrlProperty('TABLELOGIN','Visible')",ctrl:"TABLELOGIN",prop:"Visible"},{av:"AV35URL",fld:"vURL"},{ctrl:"vLOGONTO"},{av:"AV27LogOnTo",fld:"vLOGONTO"},{av:"AV29RememberMe",fld:"vREMEMBERME"},{av:"gx.fn.getCtrlProperty('vKEEPMELOGGEDIN','Visible')",ctrl:"vKEEPMELOGGEDIN",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vREMEMBERME','Visible')",ctrl:"vREMEMBERME",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"AV23KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN"},{av:"AV29RememberMe",fld:"vREMEMBERME"},{av:"AV17IDP_State",fld:"vIDP_STATE"},{ctrl:"vLOGONTO"},{av:"AV27LogOnTo",fld:"vLOGONTO"},{av:"AV36UserName",fld:"vUSERNAME"},{av:"AV37UserPassword",fld:"vUSERPASSWORD"}],[{av:"AV17IDP_State",fld:"vIDP_STATE"},{av:"AV37UserPassword",fld:"vUSERPASSWORD"}]];this.EvtParms["VLOGONTO.CLICK"]=[[{av:"AV24Language",fld:"vLANGUAGE",hsh:!0},{ctrl:"vLOGONTO"},{av:"AV27LogOnTo",fld:"vLOGONTO"}],[{av:"gx.fn.getCtrlProperty('vUSERPASSWORD','Visible')",ctrl:"vUSERPASSWORD",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vUSERPASSWORD','Invitemessage')",ctrl:"vUSERPASSWORD",prop:"Invitemessage"},{ctrl:"BTNENTER",prop:"Caption"},{av:"gx.fn.getCtrlProperty('TBFORGOTPWD','Visible')",ctrl:"TBFORGOTPWD",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vREMEMBERME','Visible')",ctrl:"vREMEMBERME",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vKEEPMELOGGEDIN','Visible')",ctrl:"vKEEPMELOGGEDIN",prop:"Visible"}]];this.EvtParms["'FORGOTPASSWORD'"]=[[{av:"AV17IDP_State",fld:"vIDP_STATE"}],[{av:"AV17IDP_State",fld:"vIDP_STATE"}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV17IDP_State","vIDP_STATE",0,"char",60,0);this.setVCMap("AV24Language","vLANGUAGE",0,"char",15,0);this.setVCMap("AV38UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamremotelogin)})