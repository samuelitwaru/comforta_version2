gx.evt.autoSkip=!1;gx.define("gamotpauthentication",!1,function(){var t,n;this.ServerClass="gamotpauthentication";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamotpauthentication.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7AuthenticationTypeName=gx.fn.getControlValue("vAUTHENTICATIONTYPENAME");this.AV16UseTwoFactorAuthentication=gx.fn.getControlValue("vUSETWOFACTORAUTHENTICATION");this.AV10IDP_State=gx.fn.getControlValue("vIDP_STATE")};this.e120u2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e130u2_client=function(){return this.executeServerEvent("BACKTOLOGIN.CLICK",!0,null,!1,!0)};this.e150u2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,36,37,38,39];this.GXLastCtrlId=39;this.WWPUTILITIESContainer=gx.uc.getNew(this,35,22,"DVelop_WorkWithPlusUtilities","WWPUTILITIESContainer","Wwputilities","WWPUTILITIES");n=this.WWPUTILITIESContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("EnableAutoUpdateFromDocumentTitle","Enableautoupdatefromdocumenttitle",!1,"bool");n.setProp("EnableFixObjectFitCover","Enablefixobjectfitcover",!0,"bool");n.setProp("EnableFloatingLabels","Enablefloatinglabels",!1,"bool");n.setProp("EmpowerTabs","Empowertabs",!1,"bool");n.setProp("EnableUpdateRowSelectionStatus","Enableupdaterowselectionstatus",!1,"bool");n.setProp("CurrentTab_ReturnUrl","Currenttab_returnurl","","char");n.setProp("EnableConvertComboToBootstrapSelect","Enableconvertcombotobootstrapselect",!0,"bool");n.setProp("AllowColumnResizing","Allowcolumnresizing",!0,"bool");n.setProp("AllowColumnReordering","Allowcolumnreordering",!0,"bool");n.setProp("AllowColumnDragging","Allowcolumndragging",!1,"bool");n.setProp("AllowColumnsRestore","Allowcolumnsrestore",!0,"bool");n.setProp("RestoreColumnsIconClass","Restorecolumnsiconclass","fas fa-undo","str");n.setProp("PagBarIncludeGoTo","Pagbarincludegoto",!1,"bool");n.setProp("ComboLoadType","Comboloadtype","InfiniteScrolling","str");n.setProp("InfiniteScrollingPage","Infinitescrollingpage",10,"num");n.setProp("UpdateButtonText","Updatebuttontext","WWP_ColumnsSelectorButton","str");n.setProp("AddNewOption","Addnewoption","WWP_AddNewOption","str");n.setProp("OnlySelectedValues","Onlyselectedvalues","WWP_OnlySelectedValues","str");n.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");n.setProp("SelectAll","Selectall","WWP_SelectAll","str");n.setProp("SortASC","Sortasc","WWP_TSSortASC","str");n.setProp("SortDSC","Sortdsc","WWP_TSSortDSC","str");n.setProp("AllowGroupText","Allowgrouptext","WWP_GroupByOption","str");n.setProp("FixLeftText","Fixlefttext","WWP_TSFixLeft","str");n.setProp("FixRightText","Fixrighttext","WWP_TSFixRight","str");n.setProp("LoadingData","Loadingdata","WWP_TSLoading","str");n.setProp("CleanFilter","Cleanfilter","WWP_TSCleanFilter","str");n.setProp("RangeFilterFrom","Rangefilterfrom","WWP_TSFrom","str");n.setProp("RangeFilterTo","Rangefilterto","WWP_TSTo","str");n.setProp("RangePickerInviteMessage","Rangepickerinvitemessage","WWP_TSRangePickerInviteMessage","str");n.setProp("NoResultsFound","Noresultsfound","WWP_TSNoResults","str");n.setProp("SearchButtonText","Searchbuttontext","WWP_TSSearchButtonCaption","str");n.setProp("SearchMultipleValuesButtonText","Searchmultiplevaluesbuttontext","WWP_FilterSelected","str");n.setProp("ColumnSelectorFixedLeftCategory","Columnselectorfixedleftcategory","WWP_ColumnSelectorFixedLeftCategory","str");n.setProp("ColumnSelectorFixedRightCategory","Columnselectorfixedrightcategory","WWP_ColumnSelectorFixedRightCategory","str");n.setProp("ColumnSelectorNotFixedCategory","Columnselectornotfixedcategory","WWP_ColumnSelectorNotFixedCategory","str");n.setProp("ColumnSelectorNoCategoryText","Columnselectornocategorytext","WWP_ColumnSelectorNoCategoryText","str");n.setProp("ColumnSelectorFixedEmpty","Columnselectorfixedempty","WWP_ColumnSelectorFixedEmpty","str");n.setProp("ColumnSelectorRestoreTooltip","Columnselectorrestoretooltip","WWP_SelectColumns_RestoreDefault","str");n.setProp("PagBarGoToCaption","Pagbargotocaption","WWP_PaginationBarGoToCaption","str");n.setProp("PagBarGoToIconClass","Pagbargotoiconclass","fas fa-redo","str");n.setProp("PagBarGoToTooltip","Pagbargototooltip","WWP_PaginationBarGoToTooltip","str");n.setProp("PagBarEmptyFilteredGridCaption","Pagbaremptyfilteredgridcaption","WWP_PaginationBarEmptyFilteredGridCaption","str");n.setProp("IncludeLineSeparator","Includelineseparator",!1,"bool");n.setProp("Visible","Visible",!0,"bool");n.setProp("Gx Control Type","Gxcontroltype","","int");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLELOGINCONTENT",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLELOGIN",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"LOGOLOGIN",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"UNNAMEDTABLE1",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV14UserName",gxold:"OV14UserName",gxvar:"AV14UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV14UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV15UserPassword",gxold:"OV15UserPassword",gxvar:"AV15UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV15UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV15UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"BTNENTER",grid:0,evt:"e120u2_client",std:"ENTER"};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"BACKTOLOGIN",format:0,grid:0,evt:"e130u2_client",ctrltype:"textblock"};t[33]={id:33,fld:"",grid:0};t[34]={id:34,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[39]={id:39,lvl:0,type:"svchar",len:2048,dec:250,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vURL",fmt:0,gxz:"ZV12URL",gxold:"OV12URL",gxvar:"AV12URL",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12URL=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12URL=n)},v2c:function(){gx.fn.setControlValue("vURL",gx.O.AV12URL,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12URL=this.val())},val:function(){return gx.fn.getControlValue("vURL")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});this.AV14UserName="";this.ZV14UserName="";this.OV14UserName="";this.AV15UserPassword="";this.ZV15UserPassword="";this.OV15UserPassword="";this.AV12URL="";this.ZV12URL="";this.OV12URL="";this.AV14UserName="";this.AV15UserPassword="";this.AV12URL="";this.AV10IDP_State="";this.AV7AuthenticationTypeName="";this.AV16UseTwoFactorAuthentication=!1;this.Events={e120u2_client:["ENTER",!0],e130u2_client:["BACKTOLOGIN.CLICK",!0],e150u2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV7AuthenticationTypeName",fld:"vAUTHENTICATIONTYPENAME",hsh:!0},{av:"AV16UseTwoFactorAuthentication",fld:"vUSETWOFACTORAUTHENTICATION",hsh:!0},{av:"AV14UserName",fld:"vUSERNAME",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV7AuthenticationTypeName",fld:"vAUTHENTICATIONTYPENAME",hsh:!0},{av:"AV16UseTwoFactorAuthentication",fld:"vUSETWOFACTORAUTHENTICATION",hsh:!0},{av:"AV10IDP_State",fld:"vIDP_STATE"},{av:"AV14UserName",fld:"vUSERNAME",hsh:!0},{av:"AV15UserPassword",fld:"vUSERPASSWORD"}],[{av:"AV12URL",fld:"vURL"},{av:"AV10IDP_State",fld:"vIDP_STATE"},{av:"AV15UserPassword",fld:"vUSERPASSWORD"}]];this.EvtParms["BACKTOLOGIN.CLICK"]=[[{av:"AV10IDP_State",fld:"vIDP_STATE"}],[{av:"AV10IDP_State",fld:"vIDP_STATE"}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV7AuthenticationTypeName","vAUTHENTICATIONTYPENAME",0,"char",60,0);this.setVCMap("AV16UseTwoFactorAuthentication","vUSETWOFACTORAUTHENTICATION",0,"boolean",1,0);this.setVCMap("AV10IDP_State","vIDP_STATE",0,"char",60,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamotpauthentication)})