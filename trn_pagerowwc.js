gx.evt.autoSkip=!1;gx.define("trn_pagerowwc",!0,function(n){var r,f,i,t,u;this.ServerClass="trn_pagerowwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="trn_pagerowwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV23Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV22OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",",");this.AV14OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV8Trn_PageId=gx.fn.getControlValue("vTRN_PAGEID")};this.s132_client=function(){return this.executeClientEvent(function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV22OrderedBy,4,0))+":"+(this.AV14OrderedDsc?"DSC":"ASC")},arguments)};this.e115k2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e125k2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e135k2_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e175k2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e185k2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];r=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,16,17,18,19,21,22,23,25];this.GXLastCtrlId=25;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",15,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"trn_pagerowwc",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);f=this.GridContainer;f.addSingleLineEdit(312,16,"ROWID","Id","","RowId","guid",0,"px",36,36,"",null,[],312,"RowId",!0,0,!1,!0,"Attribute",0,"WWColumn hidden-xs");f.addSingleLineEdit(314,17,"ROWNAME","Name","","RowName","svchar",0,"px",100,80,"start",null,[],314,"RowName",!0,0,!1,!1,"Attribute",0,"WWColumn");this.GridContainer.emptyText="";this.setGrid(f);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,20,16,"DVelop_DVPaginationBar",this.CmpContext+"GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption","Page <CURRENT_PAGE> of <TOTAL_PAGES>","str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV19GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV19GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV19GridCurrentPage)});i.addV2CFunction("AV20GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV20GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV20GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV21GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV21GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV21GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e115k2_client);i.addEventHandler("ChangeRowsPerPage",this.e125k2_client);this.setUserControl(i);this.DDO_GRIDContainer=gx.uc.getNew(this,24,16,"DDOGridTitleSettingsM",this.CmpContext+"DDO_GRIDContainer","Ddo_grid","DDO_GRID");t=this.DDO_GRIDContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","","str");t.setProp("ActiveEventKey","Activeeventkey","","char");t.setProp("FilteredText_set","Filteredtext_set","","char");t.setProp("FilteredText_get","Filteredtext_get","","char");t.setProp("FilteredTextTo_set","Filteredtextto_set","","char");t.setProp("FilteredTextTo_get","Filteredtextto_get","","char");t.setProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("SelectedColumn","Selectedcolumn","","char");t.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("TitleControlAlign","Titlecontrolalign","","str");t.setProp("Visible","Visible","","str");t.setDynProp("GridInternalName","Gridinternalname","","str");t.setProp("ColumnIds","Columnids","0:RowId|1:RowName","str");t.setProp("ColumnsSortValues","Columnssortvalues","1|2","str");t.setProp("IncludeSortASC","Includesortasc","T","str");t.setProp("IncludeSortDSC","Includesortdsc","","str");t.setProp("AllowGroup","Allowgroup","","str");t.setProp("Fixable","Fixable","","str");t.setDynProp("SortedStatus","Sortedstatus","","char");t.setProp("IncludeFilter","Includefilter","","str");t.setProp("FilterType","Filtertype","","str");t.setProp("FilterIsRange","Filterisrange","","str");t.setProp("IncludeDataList","Includedatalist","","str");t.setProp("DataListType","Datalisttype","","str");t.setProp("AllowMultipleSelection","Allowmultipleselection","","str");t.setProp("DataListFixedValues","Datalistfixedvalues","","str");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("FixedFilters","Fixedfilters","","str");t.setProp("Format","Format","","str");t.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");t.setProp("SortASC","Sortasc","","str");t.setProp("SortDSC","Sortdsc","","str");t.setProp("AllowGroupText","Allowgrouptext","","str");t.setProp("LoadingData","Loadingdata","","str");t.setProp("CleanFilter","Cleanfilter","","str");t.setProp("RangeFilterFrom","Rangefilterfrom","","str");t.setProp("RangeFilterTo","Rangefilterto","","str");t.setProp("NoResultsFound","Noresultsfound","","str");t.setProp("SearchButtonText","Searchbuttontext","","str");t.addV2CFunction("AV16DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV16DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV16DDO_TitleSettingsIcons)});t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e135k2_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,26,25,"WWP_GridEmpowerer",this.CmpContext+"GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");u=this.GRID_EMPOWERERContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setProp("HasCategories","Hascategories",!1,"bool");u.setProp("InfiniteScrolling","Infinitescrolling","False","str");u.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");u.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");u.setProp("HasRowGroups","Hasrowgroups",!1,"bool");u.setProp("FixedColumns","Fixedcolumns","","str");u.setProp("PopoversInGrid","Popoversingrid","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);r[2]={id:2,fld:"",grid:0};r[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};r[4]={id:4,fld:"",grid:0};r[5]={id:5,fld:"",grid:0};r[6]={id:6,fld:"TABLEGRIDHEADER",grid:0};r[7]={id:7,fld:"",grid:0};r[8]={id:8,fld:"",grid:0};r[10]={id:10,fld:"",grid:0};r[11]={id:11,fld:"",grid:0};r[12]={id:12,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};r[13]={id:13,fld:"",grid:0};r[14]={id:14,fld:"",grid:0};r[16]={id:16,lvl:2,type:"guid",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROWID",fmt:0,gxz:"Z312RowId",gxold:"O312RowId",gxvar:"A312RowId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A312RowId=n)},v2z:function(n){n!==undefined&&(gx.O.Z312RowId=n)},v2c:function(n){gx.fn.setGridControlValue("ROWID",n||gx.fn.currentGridRowImpl(15),gx.O.A312RowId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A312RowId=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ROWID",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};r[17]={id:17,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROWNAME",fmt:0,gxz:"Z314RowName",gxold:"O314RowName",gxvar:"A314RowName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A314RowName=n)},v2z:function(n){n!==undefined&&(gx.O.Z314RowName=n)},v2c:function(n){gx.fn.setGridControlValue("ROWNAME",n||gx.fn.currentGridRowImpl(15),gx.O.A314RowName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A314RowName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ROWNAME",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};r[18]={id:18,fld:"",grid:0};r[19]={id:19,fld:"",grid:0};r[21]={id:21,fld:"",grid:0};r[22]={id:22,fld:"",grid:0};r[23]={id:23,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};r[25]={id:25,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_PAGEID",fmt:0,gxz:"Z310Trn_PageId",gxold:"O310Trn_PageId",gxvar:"A310Trn_PageId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A310Trn_PageId=n)},v2z:function(n){n!==undefined&&(gx.O.Z310Trn_PageId=n)},v2c:function(){gx.fn.setControlValue("TRN_PAGEID",gx.O.A310Trn_PageId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A310Trn_PageId=this.val())},val:function(){return gx.fn.getControlValue("TRN_PAGEID")},nac:gx.falseFn};this.declareDomainHdlr(25,function(){});this.Z312RowId="00000000-0000-0000-0000-000000000000";this.O312RowId="00000000-0000-0000-0000-000000000000";this.Z314RowName="";this.O314RowName="";this.A310Trn_PageId="00000000-0000-0000-0000-000000000000";this.Z310Trn_PageId="00000000-0000-0000-0000-000000000000";this.O310Trn_PageId="00000000-0000-0000-0000-000000000000";this.AV19GridCurrentPage=0;this.AV16DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.A310Trn_PageId="00000000-0000-0000-0000-000000000000";this.AV8Trn_PageId="00000000-0000-0000-0000-000000000000";this.A312RowId="00000000-0000-0000-0000-000000000000";this.A314RowName="";this.AV23Pgmname="";this.AV22OrderedBy=0;this.AV14OrderedDsc=!1;this.Events={e115k2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e125k2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e135k2_client:["DDO_GRID.ONOPTIONCLICKED",!0],e175k2_client:["ENTER",!0],e185k2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV8Trn_PageId",fld:"vTRN_PAGEID"},{av:"sPrefix"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV22OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC"},{av:"AV23Pgmname",fld:"vPGMNAME",hsh:!0}],[{av:"AV19GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV20GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV21GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV22OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC"},{av:"AV8Trn_PageId",fld:"vTRN_PAGEID"},{av:"AV23Pgmname",fld:"vPGMNAME",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV22OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC"},{av:"AV8Trn_PageId",fld:"vTRN_PAGEID"},{av:"AV23Pgmname",fld:"vPGMNAME",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{av:"",ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV22OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC"},{av:"AV8Trn_PageId",fld:"vTRN_PAGEID"},{av:"AV23Pgmname",fld:"vPGMNAME",hsh:!0},{av:"sPrefix"},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"}],[{av:"AV22OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV14OrderedDsc",fld:"vORDEREDDSC"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV23Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV22OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8Trn_PageId","vTRN_PAGEID",0,"guid",8,0);this.setVCMap("AV22OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8Trn_PageId","vTRN_PAGEID",0,"guid",8,0);this.setVCMap("AV23Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV22OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV14OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8Trn_PageId","vTRN_PAGEID",0,"guid",8,0);this.setVCMap("AV23Pgmname","vPGMNAME",0,"char",129,0);f.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});f.addRefreshingVar({rfrVar:"AV22OrderedBy"});f.addRefreshingVar({rfrVar:"AV14OrderedDsc"});f.addRefreshingVar({rfrVar:"AV8Trn_PageId"});f.addRefreshingVar({rfrVar:"AV23Pgmname"});f.addRefreshingParm({rfrVar:"AV22OrderedBy"});f.addRefreshingParm({rfrVar:"AV14OrderedDsc"});f.addRefreshingParm({rfrVar:"AV8Trn_PageId"});f.addRefreshingParm({rfrVar:"AV23Pgmname"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}})})