gx.evt.autoSkip=!1;gx.define("trn_themeiconwc",!0,function(n){var r,u,i,t,f;this.ServerClass="trn_themeiconwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="trn_themeiconwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV23Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV14OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",",");this.AV15OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV8Trn_ThemeId=gx.fn.getControlValue("vTRN_THEMEID")};this.s132_client=function(){return this.executeClientEvent(function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV14OrderedBy,4,0))+":"+(this.AV15OrderedDsc?"DSC":"ASC")},arguments)};this.e114c2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e124c2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e134c2_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e174c2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e184c2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];r=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,16,17,18,19,20,22,23,24,26];this.GXLastCtrlId=26;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",15,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"trn_themeiconwc",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);u=this.GridContainer;u.addSingleLineEdit(261,16,"ICONID","Id","","IconId","guid",0,"px",36,36,"",null,[],261,"IconId",!0,0,!1,!0,"Attribute",0,"WWColumn hidden-xs");u.addSingleLineEdit(262,17,"ICONNAME","Name","","IconName","svchar",0,"px",100,80,"start",null,[],262,"IconName",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit(263,18,"ICONSVG","SVG","","IconSVG","vchar",0,"px",2097152,80,"start",null,[],263,"IconSVG",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");this.GridContainer.emptyText="";this.setGrid(u);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,21,16,"DVelop_DVPaginationBar",this.CmpContext+"GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption","Page <CURRENT_PAGE> of <TOTAL_PAGES>","str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV20GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV20GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV20GridCurrentPage)});i.addV2CFunction("AV21GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV21GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV21GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV22GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV22GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV22GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e114c2_client);i.addEventHandler("ChangeRowsPerPage",this.e124c2_client);this.setUserControl(i);this.DDO_GRIDContainer=gx.uc.getNew(this,25,16,"DDOGridTitleSettingsM",this.CmpContext+"DDO_GRIDContainer","Ddo_grid","DDO_GRID");t=this.DDO_GRIDContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","","str");t.setProp("ActiveEventKey","Activeeventkey","","char");t.setProp("FilteredText_set","Filteredtext_set","","char");t.setProp("FilteredText_get","Filteredtext_get","","char");t.setProp("FilteredTextTo_set","Filteredtextto_set","","char");t.setProp("FilteredTextTo_get","Filteredtextto_get","","char");t.setProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("SelectedColumn","Selectedcolumn","","char");t.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("TitleControlAlign","Titlecontrolalign","","str");t.setProp("Visible","Visible","","str");t.setDynProp("GridInternalName","Gridinternalname","","str");t.setProp("ColumnIds","Columnids","0:IconId|1:IconName|2:IconSVG","str");t.setProp("ColumnsSortValues","Columnssortvalues","1|2|3","str");t.setProp("IncludeSortASC","Includesortasc","T","str");t.setProp("IncludeSortDSC","Includesortdsc","","str");t.setProp("AllowGroup","Allowgroup","","str");t.setProp("Fixable","Fixable","","str");t.setDynProp("SortedStatus","Sortedstatus","","char");t.setProp("IncludeFilter","Includefilter","","str");t.setProp("FilterType","Filtertype","","str");t.setProp("FilterIsRange","Filterisrange","","str");t.setProp("IncludeDataList","Includedatalist","","str");t.setProp("DataListType","Datalisttype","","str");t.setProp("AllowMultipleSelection","Allowmultipleselection","","str");t.setProp("DataListFixedValues","Datalistfixedvalues","","str");t.setProp("DataListProc","Datalistproc","","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");t.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("FixedFilters","Fixedfilters","","str");t.setProp("Format","Format","","str");t.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");t.setProp("SortASC","Sortasc","","str");t.setProp("SortDSC","Sortdsc","","str");t.setProp("AllowGroupText","Allowgrouptext","","str");t.setProp("LoadingData","Loadingdata","","str");t.setProp("CleanFilter","Cleanfilter","","str");t.setProp("RangeFilterFrom","Rangefilterfrom","","str");t.setProp("RangeFilterTo","Rangefilterto","","str");t.setProp("NoResultsFound","Noresultsfound","","str");t.setProp("SearchButtonText","Searchbuttontext","","str");t.addV2CFunction("AV17DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV17DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV17DDO_TitleSettingsIcons)});t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e134c2_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,27,26,"WWP_GridEmpowerer",this.CmpContext+"GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");f=this.GRID_EMPOWERERContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setDynProp("GridInternalName","Gridinternalname","","char");f.setProp("HasCategories","Hascategories",!1,"bool");f.setProp("InfiniteScrolling","Infinitescrolling","False","str");f.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");f.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");f.setProp("HasRowGroups","Hasrowgroups",!1,"bool");f.setProp("FixedColumns","Fixedcolumns","","str");f.setProp("PopoversInGrid","Popoversingrid","","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);r[2]={id:2,fld:"",grid:0};r[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};r[4]={id:4,fld:"",grid:0};r[5]={id:5,fld:"",grid:0};r[6]={id:6,fld:"TABLEGRIDHEADER",grid:0};r[7]={id:7,fld:"",grid:0};r[8]={id:8,fld:"",grid:0};r[10]={id:10,fld:"",grid:0};r[11]={id:11,fld:"",grid:0};r[12]={id:12,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};r[13]={id:13,fld:"",grid:0};r[14]={id:14,fld:"",grid:0};r[16]={id:16,lvl:2,type:"guid",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ICONID",fmt:0,gxz:"Z261IconId",gxold:"O261IconId",gxvar:"A261IconId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A261IconId=n)},v2z:function(n){n!==undefined&&(gx.O.Z261IconId=n)},v2c:function(n){gx.fn.setGridControlValue("ICONID",n||gx.fn.currentGridRowImpl(15),gx.O.A261IconId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A261IconId=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ICONID",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};r[17]={id:17,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ICONNAME",fmt:0,gxz:"Z262IconName",gxold:"O262IconName",gxvar:"A262IconName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A262IconName=n)},v2z:function(n){n!==undefined&&(gx.O.Z262IconName=n)},v2c:function(n){gx.fn.setGridControlValue("ICONNAME",n||gx.fn.currentGridRowImpl(15),gx.O.A262IconName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A262IconName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ICONNAME",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};r[18]={id:18,lvl:2,type:"vchar",len:2097152,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ICONSVG",fmt:0,gxz:"Z263IconSVG",gxold:"O263IconSVG",gxvar:"A263IconSVG",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A263IconSVG=n)},v2z:function(n){n!==undefined&&(gx.O.Z263IconSVG=n)},v2c:function(n){gx.fn.setGridControlValue("ICONSVG",n||gx.fn.currentGridRowImpl(15),gx.O.A263IconSVG,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A263IconSVG=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ICONSVG",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};r[19]={id:19,fld:"",grid:0};r[20]={id:20,fld:"",grid:0};r[22]={id:22,fld:"",grid:0};r[23]={id:23,fld:"",grid:0};r[24]={id:24,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};r[26]={id:26,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_THEMEID",fmt:0,gxz:"Z247Trn_ThemeId",gxold:"O247Trn_ThemeId",gxvar:"A247Trn_ThemeId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A247Trn_ThemeId=n)},v2z:function(n){n!==undefined&&(gx.O.Z247Trn_ThemeId=n)},v2c:function(){gx.fn.setControlValue("TRN_THEMEID",gx.O.A247Trn_ThemeId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A247Trn_ThemeId=this.val())},val:function(){return gx.fn.getControlValue("TRN_THEMEID")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});this.Z261IconId="00000000-0000-0000-0000-000000000000";this.O261IconId="00000000-0000-0000-0000-000000000000";this.Z262IconName="";this.O262IconName="";this.Z263IconSVG="";this.O263IconSVG="";this.A247Trn_ThemeId="00000000-0000-0000-0000-000000000000";this.Z247Trn_ThemeId="00000000-0000-0000-0000-000000000000";this.O247Trn_ThemeId="00000000-0000-0000-0000-000000000000";this.AV20GridCurrentPage=0;this.AV17DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.A247Trn_ThemeId="00000000-0000-0000-0000-000000000000";this.AV8Trn_ThemeId="00000000-0000-0000-0000-000000000000";this.A261IconId="00000000-0000-0000-0000-000000000000";this.A262IconName="";this.A263IconSVG="";this.AV23Pgmname="";this.AV14OrderedBy=0;this.AV15OrderedDsc=!1;this.Events={e114c2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e124c2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e134c2_client:["DDO_GRID.ONOPTIONCLICKED",!0],e174c2_client:["ENTER",!0],e184c2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV8Trn_ThemeId",fld:"vTRN_THEMEID"},{av:"sPrefix"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV23Pgmname",fld:"vPGMNAME",hsh:!0}],[{av:"AV20GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV21GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV22GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV8Trn_ThemeId",fld:"vTRN_THEMEID"},{av:"AV23Pgmname",fld:"vPGMNAME",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV8Trn_ThemeId",fld:"vTRN_THEMEID"},{av:"AV23Pgmname",fld:"vPGMNAME",hsh:!0},{av:"sPrefix"},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{av:"",ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"AV8Trn_ThemeId",fld:"vTRN_THEMEID"},{av:"AV23Pgmname",fld:"vPGMNAME",hsh:!0},{av:"sPrefix"},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"}],[{av:"AV14OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV15OrderedDsc",fld:"vORDEREDDSC"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV23Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8Trn_ThemeId","vTRN_THEMEID",0,"guid",8,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8Trn_ThemeId","vTRN_THEMEID",0,"guid",8,0);this.setVCMap("AV23Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV14OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV15OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8Trn_ThemeId","vTRN_THEMEID",0,"guid",8,0);this.setVCMap("AV23Pgmname","vPGMNAME",0,"char",129,0);u.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});u.addRefreshingVar({rfrVar:"AV14OrderedBy"});u.addRefreshingVar({rfrVar:"AV15OrderedDsc"});u.addRefreshingVar({rfrVar:"AV8Trn_ThemeId"});u.addRefreshingVar({rfrVar:"AV23Pgmname"});u.addRefreshingParm({rfrVar:"AV14OrderedBy"});u.addRefreshingParm({rfrVar:"AV15OrderedDsc"});u.addRefreshingParm({rfrVar:"AV8Trn_ThemeId"});u.addRefreshingParm({rfrVar:"AV23Pgmname"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}})})