gx.evt.autoSkip=!1;gx.define("trn_pageww",!1,function(){var t,r,f,i,u,n,e;this.ServerClass="trn_pageww";this.PackageName="GeneXus.Programs";this.ServerFullClass="trn_pageww.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV18ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",",");this.AV41Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV19TFTrn_PageName=gx.fn.getControlValue("vTFTRN_PAGENAME");this.AV20TFTrn_PageName_Sel=gx.fn.getControlValue("vTFTRN_PAGENAME_SEL");this.AV13OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV30IsAuthorized_Display=gx.fn.getControlValue("vISAUTHORIZED_DISPLAY");this.AV32IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV34IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE");this.AV40IsAuthorized_GoToToolBox=gx.fn.getControlValue("vISAUTHORIZED_GOTOTOOLBOX");this.AV28IsAuthorized_Trn_PageName=gx.fn.getControlValue("vISAUTHORIZED_TRN_PAGENAME");this.AV11GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV35IsAuthorized_Insert=gx.fn.getControlValue("vISAUTHORIZED_INSERT")};this.s162_client=function(){return this.executeClientEvent(function(){this.DDO_GRIDContainer.SortedStatus="-1:"+(this.AV13OrderedDsc?"DSC":"ASC")},arguments)};this.s172_client=function(){return this.executeClientEvent(function(){this.AV14FilterFullText="";this.AV19TFTrn_PageName="";this.AV20TFTrn_PageName_Sel="";this.DDO_GRIDContainer.SelectedValue_set="";this.DDO_GRIDContainer.FilteredText_set=""},arguments)};this.e125m2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e135m2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e155m2_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e115m2_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e165m2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e145m2_client=function(){return this.executeServerEvent("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",!1,null,!0,!0)};this.e205m2_client=function(){return this.executeServerEvent("VDETAILWEBCOMPONENT.CLICK",!0,arguments[0],!1,!1)};this.e215m2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e225m2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29,30,32,33,34,35,36,38,39,40,41,42,43,44,45,46,48,49,51,52,53,57];this.GXLastCtrlId=57;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",37,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"trn_pageww",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridContainer;r.addSingleLineEdit(310,38,"TRN_PAGEID","Id","","Trn_PageId","guid",0,"px",36,36,"",null,[],310,"Trn_PageId",!1,0,!1,!0,"Attribute",0,"WWColumn");r.addSingleLineEdit(318,39,"TRN_PAGENAME","Name","","Trn_PageName","svchar",0,"px",100,80,"start",null,[],318,"Trn_PageName",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("Display",40,"vDISPLAY","","Display","Display","char",0,"px",20,20,"start",null,[],"Display","Display",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addSingleLineEdit("Update",41,"vUPDATE","","Update","Update","char",0,"px",20,20,"start",null,[],"Update","Update",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addSingleLineEdit("Delete",42,"vDELETE","","Delete","Delete","char",0,"px",20,20,"start",null,[],"Delete","Delete",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addSingleLineEdit("Detailwebcomponent",43,"vDETAILWEBCOMPONENT","","","DetailWebComponent","char",0,"px",20,20,"start","e205m2_client",[],"Detailwebcomponent","DetailWebComponent",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn WCD_ActionColumn");r.addSingleLineEdit("Gototoolbox",44,"vGOTOTOOLBOX","","","GoToToolBox","char",0,"px",20,20,"start",null,[],"Gototoolbox","GoToToolBox",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");this.GridContainer.emptyText="";this.setGrid(r);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,23,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");f=this.DDO_MANAGEFILTERSContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("IconType","Icontype","FontIcon","str");f.setProp("Icon","Icon","fas fa-filter","str");f.setProp("Caption","Caption","","str");f.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");f.setProp("Cls","Cls","ManageFilters","str");f.setProp("ActiveEventKey","Activeeventkey","","char");f.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");f.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");f.setProp("Visible","Visible",!0,"bool");f.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");f.addV2CFunction("AV16ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");f.addC2VFunction(function(n){n.ParentObject.AV16ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV16ManageFiltersData)});f.setProp("Gx Control Type","Gxcontroltype","","int");f.setC2ShowFunction(function(n){n.show()});f.addEventHandler("OnOptionClicked",this.e115m2_client);this.setUserControl(f);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,47,28,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption","Page <CURRENT_PAGE> of <TOTAL_PAGES>","str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV25GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV25GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV25GridCurrentPage)});i.addV2CFunction("AV26GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV26GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV26GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV27GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV27GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV27GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e125m2_client);i.addEventHandler("ChangeRowsPerPage",this.e135m2_client);this.setUserControl(i);this.DDC_SUBSCRIPTIONSContainer=gx.uc.getNew(this,54,28,"BootstrapDropDownOptions","DDC_SUBSCRIPTIONSContainer","Ddc_subscriptions","DDC_SUBSCRIPTIONS");u=this.DDC_SUBSCRIPTIONSContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","FontIcon","str");u.setProp("Icon","Icon","fas fa-rss","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","WWP_Subscriptions_Tooltip","str");u.setProp("Cls","Cls","ColumnsSelector","str");u.setProp("ComponentWidth","Componentwidth",400,"num");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","Component","str");u.setProp("Visible","Visible",!0,"bool");u.setProp("Result","Result","","char");u.setDynProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("ShowLoading","Showloading",!0,"bool");u.setProp("Load","Load","OnEveryClick","str");u.setProp("KeepOpened","Keepopened",!1,"bool");u.setProp("Trigger","Trigger","Click","str");u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnLoadComponent",this.e145m2_client);this.setUserControl(u);this.DDO_GRIDContainer=gx.uc.getNew(this,55,28,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setDynProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setDynProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","1:Trn_PageName","str");n.setProp("ColumnsSortValues","Columnssortvalues","-1","str");n.setProp("IncludeSortASC","Includesortasc","T","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","","str");n.setDynProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","T","str");n.setProp("FilterType","Filtertype","Character","str");n.setProp("FilterIsRange","Filterisrange","","str");n.setProp("IncludeDataList","Includedatalist","T","str");n.setProp("DataListType","Datalisttype","Dynamic","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","Trn_PageWWGetFilterData","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("Format","Format","","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV21DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV21DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV21DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});n.addEventHandler("OnOptionClicked",this.e155m2_client);this.setUserControl(n);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,56,28,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");e=this.GRID_EMPOWERERContainer;e.setProp("Class","Class","","char");e.setProp("Enabled","Enabled",!0,"boolean");e.setDynProp("GridInternalName","Gridinternalname","","char");e.setProp("HasCategories","Hascategories",!1,"bool");e.setProp("InfiniteScrolling","Infinitescrolling","False","str");e.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");e.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");e.setProp("HasRowGroups","Hasrowgroups",!1,"bool");e.setProp("FixedColumns","Fixedcolumns","","str");e.setProp("PopoversInGrid","Popoversingrid","","str");e.setProp("Visible","Visible",!0,"bool");e.setC2ShowFunction(function(n){n.show()});this.setUserControl(e);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLEHEADER",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"TABLEHEADERCONTENT",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"TABLEACTIONS",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"BTNINSERT",grid:0,evt:"e165m2_client"};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"BTNSUBSCRIPTIONS",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"TABLERIGHTHEADER",grid:0};t[22]={id:22,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"TABLEFILTERS",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vFILTERFULLTEXT",fmt:0,gxz:"ZV14FilterFullText",gxold:"OV14FilterFullText",gxvar:"AV14FilterFullText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14FilterFullText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14FilterFullText=n)},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV14FilterFullText,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14FilterFullText=this.val())},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,fld:"",grid:0};t[34]={id:34,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[38]={id:38,lvl:2,type:"guid",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_PAGEID",fmt:0,gxz:"Z310Trn_PageId",gxold:"O310Trn_PageId",gxvar:"A310Trn_PageId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A310Trn_PageId=n)},v2z:function(n){n!==undefined&&(gx.O.Z310Trn_PageId=n)},v2c:function(n){gx.fn.setGridControlValue("TRN_PAGEID",n||gx.fn.currentGridRowImpl(37),gx.O.A310Trn_PageId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A310Trn_PageId=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TRN_PAGEID",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};t[39]={id:39,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_PAGENAME",fmt:0,gxz:"Z318Trn_PageName",gxold:"O318Trn_PageName",gxvar:"A318Trn_PageName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A318Trn_PageName=n)},v2z:function(n){n!==undefined&&(gx.O.Z318Trn_PageName=n)},v2c:function(n){gx.fn.setGridControlValue("TRN_PAGENAME",n||gx.fn.currentGridRowImpl(37),gx.O.A318Trn_PageName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A318Trn_PageName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TRN_PAGENAME",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};t[40]={id:40,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAY",fmt:1,gxz:"ZV29Display",gxold:"OV29Display",gxvar:"AV29Display",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV29Display=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29Display=n)},v2c:function(n){gx.fn.setGridControlValue("vDISPLAY",n||gx.fn.currentGridRowImpl(37),gx.O.AV29Display,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV29Display=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDISPLAY",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};t[41]={id:41,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:1,gxz:"ZV31Update",gxold:"OV31Update",gxvar:"AV31Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV31Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV31Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(37),gx.O.AV31Update,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV31Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};t[42]={id:42,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:1,gxz:"ZV33Delete",gxold:"OV33Delete",gxvar:"AV33Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV33Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV33Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(37),gx.O.AV33Delete,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV33Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};t[43]={id:43,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDETAILWEBCOMPONENT",fmt:1,gxz:"ZV36DetailWebComponent",gxold:"OV36DetailWebComponent",gxvar:"AV36DetailWebComponent",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV36DetailWebComponent=n)},v2z:function(n){n!==undefined&&(gx.O.ZV36DetailWebComponent=n)},v2c:function(n){gx.fn.setGridControlValue("vDETAILWEBCOMPONENT",n||gx.fn.currentGridRowImpl(37),gx.O.AV36DetailWebComponent,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV36DetailWebComponent=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDETAILWEBCOMPONENT",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn,evt:"e205m2_client"};t[44]={id:44,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGOTOTOOLBOX",fmt:1,gxz:"ZV39GoToToolBox",gxold:"OV39GoToToolBox",gxvar:"AV39GoToToolBox",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV39GoToToolBox=n)},v2z:function(n){n!==undefined&&(gx.O.ZV39GoToToolBox=n)},v2c:function(n){gx.fn.setGridControlValue("vGOTOTOOLBOX",n||gx.fn.currentGridRowImpl(37),gx.O.AV39GoToToolBox,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV39GoToToolBox=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vGOTOTOOLBOX",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[48]={id:48,fld:"",grid:0};t[49]={id:49,fld:"CELL_GRID_DWC",grid:0};t[51]={id:51,fld:"",grid:0};t[52]={id:52,fld:"",grid:0};t[53]={id:53,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[57]={id:57,fld:"DIV_WWPAUXWC",grid:0};this.AV14FilterFullText="";this.ZV14FilterFullText="";this.OV14FilterFullText="";this.Z310Trn_PageId="00000000-0000-0000-0000-000000000000";this.O310Trn_PageId="00000000-0000-0000-0000-000000000000";this.Z318Trn_PageName="";this.O318Trn_PageName="";this.ZV29Display="";this.OV29Display="";this.ZV31Update="";this.OV31Update="";this.ZV33Delete="";this.OV33Delete="";this.ZV36DetailWebComponent="";this.OV36DetailWebComponent="";this.ZV39GoToToolBox="";this.OV39GoToToolBox="";this.AV16ManageFiltersData=[];this.AV14FilterFullText="";this.AV25GridCurrentPage=0;this.AV21DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.A310Trn_PageId="00000000-0000-0000-0000-000000000000";this.A318Trn_PageName="";this.AV29Display="";this.AV31Update="";this.AV33Delete="";this.AV36DetailWebComponent="";this.AV39GoToToolBox="";this.AV18ManageFiltersExecutionStep=0;this.AV41Pgmname="";this.AV19TFTrn_PageName="";this.AV20TFTrn_PageName_Sel="";this.AV13OrderedDsc=!1;this.AV30IsAuthorized_Display=!1;this.AV32IsAuthorized_Update=!1;this.AV34IsAuthorized_Delete=!1;this.AV40IsAuthorized_GoToToolBox=!1;this.AV28IsAuthorized_Trn_PageName=!1;this.AV11GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.AV35IsAuthorized_Insert=!1;this.Events={e125m2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e135m2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e155m2_client:["DDO_GRID.ONOPTIONCLICKED",!0],e115m2_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e165m2_client:["'DOINSERT'",!0],e145m2_client:["DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",!0],e205m2_client:["VDETAILWEBCOMPONENT.CLICK",!0],e215m2_client:["ENTER",!0],e225m2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV18ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV13OrderedDsc",fld:"vORDEREDDSC"},{av:"AV14FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV41Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV19TFTrn_PageName",fld:"vTFTRN_PAGENAME"},{av:"AV20TFTrn_PageName_Sel",fld:"vTFTRN_PAGENAME_SEL"},{av:"AV30IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV32IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV34IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV40IsAuthorized_GoToToolBox",fld:"vISAUTHORIZED_GOTOTOOLBOX",hsh:!0},{av:"AV28IsAuthorized_Trn_PageName",fld:"vISAUTHORIZED_TRN_PAGENAME",hsh:!0},{av:"AV35IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0}],[{av:"AV18ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV25GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV26GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV27GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"},{av:"AV30IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"gx.fn.getCtrlProperty('vDISPLAY','Visible')",ctrl:"vDISPLAY",prop:"Visible"},{av:"AV32IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"gx.fn.getCtrlProperty('vUPDATE','Visible')",ctrl:"vUPDATE",prop:"Visible"},{av:"AV34IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV40IsAuthorized_GoToToolBox",fld:"vISAUTHORIZED_GOTOTOOLBOX",hsh:!0},{av:"gx.fn.getCtrlProperty('vGOTOTOOLBOX','Visible')",ctrl:"vGOTOTOOLBOX",prop:"Visible"},{av:"AV35IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{ctrl:"BTNSUBSCRIPTIONS",prop:"Visible"},{av:"AV16ManageFiltersData",fld:"vMANAGEFILTERSDATA"},{av:"AV11GridState",fld:"vGRIDSTATE"}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV13OrderedDsc",fld:"vORDEREDDSC"},{av:"AV14FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV18ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV41Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV19TFTrn_PageName",fld:"vTFTRN_PAGENAME"},{av:"AV20TFTrn_PageName_Sel",fld:"vTFTRN_PAGENAME_SEL"},{av:"AV30IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV32IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV34IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV40IsAuthorized_GoToToolBox",fld:"vISAUTHORIZED_GOTOTOOLBOX",hsh:!0},{av:"AV28IsAuthorized_Trn_PageName",fld:"vISAUTHORIZED_TRN_PAGENAME",hsh:!0},{av:"AV35IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV13OrderedDsc",fld:"vORDEREDDSC"},{av:"AV14FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV18ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV41Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV19TFTrn_PageName",fld:"vTFTRN_PAGENAME"},{av:"AV20TFTrn_PageName_Sel",fld:"vTFTRN_PAGENAME_SEL"},{av:"AV30IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV32IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV34IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV40IsAuthorized_GoToToolBox",fld:"vISAUTHORIZED_GOTOTOOLBOX",hsh:!0},{av:"AV28IsAuthorized_Trn_PageName",fld:"vISAUTHORIZED_TRN_PAGENAME",hsh:!0},{av:"AV35IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{av:"",ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV13OrderedDsc",fld:"vORDEREDDSC"},{av:"AV14FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV18ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV41Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV19TFTrn_PageName",fld:"vTFTRN_PAGENAME"},{av:"AV20TFTrn_PageName_Sel",fld:"vTFTRN_PAGENAME_SEL"},{av:"AV30IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV32IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV34IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV40IsAuthorized_GoToToolBox",fld:"vISAUTHORIZED_GOTOTOOLBOX",hsh:!0},{av:"AV28IsAuthorized_Trn_PageName",fld:"vISAUTHORIZED_TRN_PAGENAME",hsh:!0},{av:"AV35IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedColumn",ctrl:"DDO_GRID",prop:"SelectedColumn"},{av:"this.DDO_GRIDContainer.FilteredText_get",ctrl:"DDO_GRID",prop:"FilteredText_get"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"}],[{av:"AV13OrderedDsc",fld:"vORDEREDDSC"},{av:"AV19TFTrn_PageName",fld:"vTFTRN_PAGENAME"},{av:"AV20TFTrn_PageName_Sel",fld:"vTFTRN_PAGENAME_SEL"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV30IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"A310Trn_PageId",fld:"TRN_PAGEID",hsh:!0},{av:"AV32IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV34IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV40IsAuthorized_GoToToolBox",fld:"vISAUTHORIZED_GOTOTOOLBOX",hsh:!0},{av:"AV28IsAuthorized_Trn_PageName",fld:"vISAUTHORIZED_TRN_PAGENAME",hsh:!0}],[{av:"AV29Display",fld:"vDISPLAY"},{av:"gx.fn.getCtrlProperty('vDISPLAY','Link')",ctrl:"vDISPLAY",prop:"Link"},{av:"AV31Update",fld:"vUPDATE"},{av:"gx.fn.getCtrlProperty('vUPDATE','Link')",ctrl:"vUPDATE",prop:"Link"},{av:"AV33Delete",fld:"vDELETE"},{av:"gx.fn.getCtrlProperty('vDELETE','Link')",ctrl:"vDELETE",prop:"Link"},{av:"AV36DetailWebComponent",fld:"vDETAILWEBCOMPONENT"},{av:"AV39GoToToolBox",fld:"vGOTOTOOLBOX"},{av:"gx.fn.getCtrlProperty('vGOTOTOOLBOX','Link')",ctrl:"vGOTOTOOLBOX",prop:"Link"},{av:"gx.fn.getCtrlProperty('TRN_PAGENAME','Link')",ctrl:"TRN_PAGENAME",prop:"Link"}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV13OrderedDsc",fld:"vORDEREDDSC"},{av:"AV14FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV18ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV41Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV19TFTrn_PageName",fld:"vTFTRN_PAGENAME"},{av:"AV20TFTrn_PageName_Sel",fld:"vTFTRN_PAGENAME_SEL"},{av:"AV30IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV32IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV34IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV40IsAuthorized_GoToToolBox",fld:"vISAUTHORIZED_GOTOTOOLBOX",hsh:!0},{av:"AV28IsAuthorized_Trn_PageName",fld:"vISAUTHORIZED_TRN_PAGENAME",hsh:!0},{av:"AV35IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV11GridState",fld:"vGRIDSTATE"}],[{av:"AV18ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV11GridState",fld:"vGRIDSTATE"},{av:"AV13OrderedDsc",fld:"vORDEREDDSC"},{av:"AV14FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV19TFTrn_PageName",fld:"vTFTRN_PAGENAME"},{av:"AV20TFTrn_PageName_Sel",fld:"vTFTRN_PAGENAME_SEL"},{av:"this.DDO_GRIDContainer.SelectedValue_set",ctrl:"DDO_GRID",prop:"SelectedValue_set"},{av:"this.DDO_GRIDContainer.FilteredText_set",ctrl:"DDO_GRID",prop:"FilteredText_set"},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"},{av:"AV25GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV26GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV27GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"},{av:"AV30IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"gx.fn.getCtrlProperty('vDISPLAY','Visible')",ctrl:"vDISPLAY",prop:"Visible"},{av:"AV32IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"gx.fn.getCtrlProperty('vUPDATE','Visible')",ctrl:"vUPDATE",prop:"Visible"},{av:"AV34IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV40IsAuthorized_GoToToolBox",fld:"vISAUTHORIZED_GOTOTOOLBOX",hsh:!0},{av:"gx.fn.getCtrlProperty('vGOTOTOOLBOX','Visible')",ctrl:"vGOTOTOOLBOX",prop:"Visible"},{av:"AV35IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{ctrl:"BTNSUBSCRIPTIONS",prop:"Visible"},{av:"AV16ManageFiltersData",fld:"vMANAGEFILTERSDATA"}]];this.EvtParms["'DOINSERT'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV13OrderedDsc",fld:"vORDEREDDSC"},{av:"AV14FilterFullText",fld:"vFILTERFULLTEXT"},{av:"AV18ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV41Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV19TFTrn_PageName",fld:"vTFTRN_PAGENAME"},{av:"AV20TFTrn_PageName_Sel",fld:"vTFTRN_PAGENAME_SEL"},{av:"AV30IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV32IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV34IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV40IsAuthorized_GoToToolBox",fld:"vISAUTHORIZED_GOTOTOOLBOX",hsh:!0},{av:"AV28IsAuthorized_Trn_PageName",fld:"vISAUTHORIZED_TRN_PAGENAME",hsh:!0},{av:"AV35IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"A310Trn_PageId",fld:"TRN_PAGEID",hsh:!0}],[{av:"AV18ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV25GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV26GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV27GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"},{av:"AV30IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"gx.fn.getCtrlProperty('vDISPLAY','Visible')",ctrl:"vDISPLAY",prop:"Visible"},{av:"AV32IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"gx.fn.getCtrlProperty('vUPDATE','Visible')",ctrl:"vUPDATE",prop:"Visible"},{av:"AV34IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV40IsAuthorized_GoToToolBox",fld:"vISAUTHORIZED_GOTOTOOLBOX",hsh:!0},{av:"gx.fn.getCtrlProperty('vGOTOTOOLBOX','Visible')",ctrl:"vGOTOTOOLBOX",prop:"Visible"},{av:"AV35IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"},{ctrl:"BTNSUBSCRIPTIONS",prop:"Visible"},{av:"AV16ManageFiltersData",fld:"vMANAGEFILTERSDATA"},{av:"AV11GridState",fld:"vGRIDSTATE"}]];this.EvtParms["DDC_SUBSCRIPTIONS.ONLOADCOMPONENT"]=[[],[{ctrl:"WWPAUX_WC"}]];this.EvtParms["VDETAILWEBCOMPONENT.CLICK"]=[[{av:"A310Trn_PageId",fld:"TRN_PAGEID",hsh:!0}],[{ctrl:"GRID_DWC"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV18ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV41Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV19TFTrn_PageName","vTFTRN_PAGENAME",0,"svchar",100,0);this.setVCMap("AV20TFTrn_PageName_Sel","vTFTRN_PAGENAME_SEL",0,"svchar",100,0);this.setVCMap("AV13OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV30IsAuthorized_Display","vISAUTHORIZED_DISPLAY",0,"boolean",4,0);this.setVCMap("AV32IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV34IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV40IsAuthorized_GoToToolBox","vISAUTHORIZED_GOTOTOOLBOX",0,"boolean",4,0);this.setVCMap("AV28IsAuthorized_Trn_PageName","vISAUTHORIZED_TRN_PAGENAME",0,"boolean",4,0);this.setVCMap("AV11GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV35IsAuthorized_Insert","vISAUTHORIZED_INSERT",0,"boolean",4,0);this.setVCMap("AV13OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV18ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV41Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV19TFTrn_PageName","vTFTRN_PAGENAME",0,"svchar",100,0);this.setVCMap("AV20TFTrn_PageName_Sel","vTFTRN_PAGENAME_SEL",0,"svchar",100,0);this.setVCMap("AV30IsAuthorized_Display","vISAUTHORIZED_DISPLAY",0,"boolean",4,0);this.setVCMap("AV32IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV34IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV40IsAuthorized_GoToToolBox","vISAUTHORIZED_GOTOTOOLBOX",0,"boolean",4,0);this.setVCMap("AV28IsAuthorized_Trn_PageName","vISAUTHORIZED_TRN_PAGENAME",0,"boolean",4,0);this.setVCMap("AV13OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV18ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV41Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV19TFTrn_PageName","vTFTRN_PAGENAME",0,"svchar",100,0);this.setVCMap("AV20TFTrn_PageName_Sel","vTFTRN_PAGENAME_SEL",0,"svchar",100,0);this.setVCMap("AV30IsAuthorized_Display","vISAUTHORIZED_DISPLAY",0,"boolean",4,0);this.setVCMap("AV32IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV34IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV40IsAuthorized_GoToToolBox","vISAUTHORIZED_GOTOTOOLBOX",0,"boolean",4,0);this.setVCMap("AV28IsAuthorized_Trn_PageName","vISAUTHORIZED_TRN_PAGENAME",0,"boolean",4,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});r.addRefreshingVar({rfrVar:"AV13OrderedDsc"});r.addRefreshingVar(this.GXValidFnc[28]);r.addRefreshingVar({rfrVar:"AV18ManageFiltersExecutionStep"});r.addRefreshingVar({rfrVar:"AV41Pgmname"});r.addRefreshingVar({rfrVar:"AV19TFTrn_PageName"});r.addRefreshingVar({rfrVar:"AV20TFTrn_PageName_Sel"});r.addRefreshingVar({rfrVar:"AV30IsAuthorized_Display"});r.addRefreshingVar({rfrVar:"AV32IsAuthorized_Update"});r.addRefreshingVar({rfrVar:"AV34IsAuthorized_Delete"});r.addRefreshingVar({rfrVar:"AV40IsAuthorized_GoToToolBox"});r.addRefreshingVar({rfrVar:"AV28IsAuthorized_Trn_PageName"});r.addRefreshingVar({rfrVar:"AV35IsAuthorized_Insert"});r.addRefreshingParm({rfrVar:"AV13OrderedDsc"});r.addRefreshingParm(this.GXValidFnc[28]);r.addRefreshingParm({rfrVar:"AV18ManageFiltersExecutionStep"});r.addRefreshingParm({rfrVar:"AV41Pgmname"});r.addRefreshingParm({rfrVar:"AV19TFTrn_PageName"});r.addRefreshingParm({rfrVar:"AV20TFTrn_PageName_Sel"});r.addRefreshingParm({rfrVar:"AV30IsAuthorized_Display"});r.addRefreshingParm({rfrVar:"AV32IsAuthorized_Update"});r.addRefreshingParm({rfrVar:"AV34IsAuthorized_Delete"});r.addRefreshingParm({rfrVar:"AV40IsAuthorized_GoToToolBox"});r.addRefreshingParm({rfrVar:"AV28IsAuthorized_Trn_PageName"});r.addRefreshingParm({rfrVar:"AV35IsAuthorized_Insert"});this.Initialize();this.setComponent({id:"GRID_DWC",GXClass:null,Prefix:"W0050",lvl:1});this.setComponent({id:"WWPAUX_WC",GXClass:null,Prefix:"W0058",lvl:1});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}})});gx.wi(function(){gx.createParentObj(this.trn_pageww)})