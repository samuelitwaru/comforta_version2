gx.evt.autoSkip=!1;gx.define("gamwweventsubscriptions",!1,function(){var t,r,i,n,u,f;this.ServerClass="gamwweventsubscriptions";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamwweventsubscriptions.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV50ColumnsSelector=gx.fn.getControlValue("vCOLUMNSSELECTOR");this.AV68Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV63IsAuthorized_Display=gx.fn.getControlValue("vISAUTHORIZED_DISPLAY");this.AV65IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV66IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE");this.AV29IsAuthorized_Description=gx.fn.getControlValue("vISAUTHORIZED_DESCRIPTION");this.AV67IsAuthorized_Insert=gx.fn.getControlValue("vISAUTHORIZED_INSERT");this.subGrid_Recordcount=gx.fn.getIntegerValue("subGrid_Recordcount",gx.thousandSeparator)};this.Validv_Event=function(){var n=gx.fn.currentGridRowImpl(32);return this.validCliEvt("Validv_Event",32,function(){try{var n=gx.util.balloon.getNew("vEVENT");if(this.AnyError=0,!(gx.text.compare(this.AV10Event,"user-update")==0||gx.text.compare(this.AV10Event,"user-insert")==0||gx.text.compare(this.AV10Event,"user-delete")==0||gx.text.compare(this.AV10Event,"user-updateroles")==0||gx.text.compare(this.AV10Event,"user-getcustominfo")==0||gx.text.compare(this.AV10Event,"user-savecustominfo")==0||gx.text.compare(this.AV10Event,"role-insert")==0||gx.text.compare(this.AV10Event,"role-update")==0||gx.text.compare(this.AV10Event,"role-delete")==0||gx.text.compare(this.AV10Event,"repository-login")==0||gx.text.compare(this.AV10Event,"repository-loginfailed")==0||gx.text.compare(this.AV10Event,"reposiotry-rememberauthentication")==0||gx.text.compare(this.AV10Event,"repository-logout")==0||gx.text.compare(this.AV10Event,"externalauthentication-response")==0||gx.text.compare(this.AV10Event,"application-checkprmfail")==0||gx.text.compare(this.AV10Event,"user-otp-validateuser")==0||gx.text.compare(this.AV10Event,"user-otp-generatecode")==0||gx.text.compare(this.AV10Event,"user-otp-sendcode")==0||gx.text.compare(this.AV10Event,"user-otp-validatecode")==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Event"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e119g2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e129g2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e139g2_client=function(){return this.executeServerEvent("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",!1,null,!0,!0)};this.e149g2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e189g2_client=function(){return this.executeServerEvent("VSUBSCRIBE.CLICK",!0,arguments[0],!1,!1)};this.e199g2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e209g2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,24,25,27,28,29,30,31,33,34,35,36,37,38,39,40,41,42,43,44,45,47,48,49];this.GXLastCtrlId=49;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",32,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"gamwweventsubscriptions",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridContainer;r.addSingleLineEdit("Display",33,"vDISPLAY","",gx.getMessage("GXM_display"),"Display","char",0,"px",20,20,"start",null,[],"Display","Display",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addSingleLineEdit("Update",34,"vUPDATE","",gx.getMessage("GXM_update"),"Update","char",0,"px",20,20,"start",null,[],"Update","Update",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addSingleLineEdit("Delete",35,"vDELETE","",gx.getMessage("GX_BtnDelete"),"Delete","char",0,"px",20,20,"start",null,[],"Delete","Delete",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addSingleLineEdit("Description",36,"vDESCRIPTION",gx.getMessage("WWP_GAM_EventDescription"),"","Description","char",570,"px",254,80,"start",null,[],"Description","Description",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addComboBox("Status",37,"vSTATUS",gx.getMessage("WWP_GAM_Status"),"Status","char",null,0,!0,!1,0,"px","WWColumn");r.addSingleLineEdit("Subscribe",38,"vSUBSCRIBE","","","Subscribe","char",0,"px",20,20,"start","e189g2_client",[],"Subscribe","Subscribe",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addComboBox("Event",39,"vEVENT",gx.getMessage("WWP_GAM_Entity"),"Event","char",null,0,!0,!1,0,"px","WWColumn");r.addSingleLineEdit("Filename",40,"vFILENAME",gx.getMessage("WWP_GAM_FileName"),"","FileName","char",570,"px",254,80,"start",null,[],"Filename","FileName",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("Classname",41,"vCLASSNAME",gx.getMessage("WWP_GAM_ClassName"),"","ClassName","char",0,"px",60,60,"start",null,[],"Classname","ClassName",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("Methodname",42,"vMETHODNAME",gx.getMessage("WWP_GAM_MethodName"),"","MethodName","char",0,"px",60,60,"start",null,[],"Methodname","MethodName",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("Id",43,"vID","","","Id","char",0,"px",40,40,"start",null,[],"Id","Id",!1,0,!1,!1,"Attribute",0,"WWColumn");this.GridContainer.emptyText=gx.getMessage("");this.setGrid(r);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,46,33,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption",gx.getMessage("WWP_PagingCaption"),"str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV57GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV57GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV57GridCurrentPage)});i.addV2CFunction("AV58GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV58GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV58GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV61GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV61GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV61GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e119g2_client);i.addEventHandler("ChangeRowsPerPage",this.e129g2_client);this.setUserControl(i);this.DDO_GRIDContainer=gx.uc.getNew(this,50,33,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","3:Description|4:Status|6:Event|7:FileName|8:ClassName|9:MethodName","str");n.setProp("ColumnsSortValues","Columnssortvalues","|||||","str");n.setProp("IncludeSortASC","Includesortasc","","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","T","str");n.setProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","","str");n.setProp("FilterType","Filtertype","","str");n.setProp("FilterIsRange","Filterisrange","","str");n.setProp("IncludeDataList","Includedatalist","","str");n.setProp("DataListType","Datalisttype","","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("Format","Format","","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV56DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV56DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV56DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);this.DDO_GRIDCOLUMNSSELECTORContainer=gx.uc.getNew(this,51,33,"BootstrapDropDownOptions","DDO_GRIDCOLUMNSSELECTORContainer","Ddo_gridcolumnsselector","DDO_GRIDCOLUMNSSELECTOR");u=this.DDO_GRIDCOLUMNSSELECTORContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","FontIcon","str");u.setProp("Icon","Icon","fas fa-cog","str");u.setProp("Caption","Caption",gx.getMessage("WWP_EditColumnsCaption"),"str");u.setProp("Tooltip","Tooltip","WWP_EditColumnsTooltip","str");u.setProp("Cls","Cls","ColumnsSelector hidden-xs","str");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","GridColumnsSelector","str");u.setProp("Visible","Visible",!0,"bool");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setDynProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("ColumnsSelectorValues","Columnsselectorvalues","","char");u.setProp("UpdateButtonText","Updatebuttontext","","str");u.addV2CFunction("AV56DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");u.addC2VFunction(function(n){n.ParentObject.AV56DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV56DDO_TitleSettingsIcons)});u.addV2CFunction("AV50ColumnsSelector","vCOLUMNSSELECTOR","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV50ColumnsSelector=n.GetDropDownOptionsData();gx.fn.setControlValue("vCOLUMNSSELECTOR",n.ParentObject.AV50ColumnsSelector)});u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnColumnsChanged",this.e139g2_client);this.setUserControl(u);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,52,33,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");f=this.GRID_EMPOWERERContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setDynProp("GridInternalName","Gridinternalname","","char");f.setProp("HasCategories","Hascategories",!1,"bool");f.setProp("InfiniteScrolling","Infinitescrolling","False","str");f.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");f.setProp("HasColumnsSelector","Hascolumnsselector",!0,"bool");f.setProp("HasRowGroups","Hasrowgroups",!1,"bool");f.setProp("FixedColumns","Fixedcolumns","","str");f.setProp("PopoversInGrid","Popoversingrid","","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLEHEADER",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLEACTIONS",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"BTNINSERT",grid:0,evt:"e149g2_client"};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"BTNEDITCOLUMNS",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"TABLERIGHTHEADER",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[33]={id:33,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAY",fmt:1,gxz:"ZV62Display",gxold:"OV62Display",gxvar:"AV62Display",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV62Display=n)},v2z:function(n){n!==undefined&&(gx.O.ZV62Display=n)},v2c:function(n){gx.fn.setGridControlValue("vDISPLAY",n||gx.fn.currentGridRowImpl(32),gx.O.AV62Display,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV62Display=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDISPLAY",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[34]={id:34,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:1,gxz:"ZV64Update",gxold:"OV64Update",gxvar:"AV64Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV64Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV64Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(32),gx.O.AV64Update,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV64Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[35]={id:35,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:1,gxz:"ZV5Delete",gxold:"OV5Delete",gxvar:"AV5Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV5Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(32),gx.O.AV5Delete,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[36]={id:36,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDESCRIPTION",fmt:0,gxz:"ZV8Description",gxold:"OV8Description",gxvar:"AV8Description",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV8Description=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8Description=n)},v2c:function(n){gx.fn.setGridControlValue("vDESCRIPTION",n||gx.fn.currentGridRowImpl(32),gx.O.AV8Description,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8Description=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDESCRIPTION",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[37]={id:37,lvl:2,type:"char",len:1,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSTATUS",fmt:0,gxz:"ZV16Status",gxold:"OV16Status",gxvar:"AV16Status",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV16Status=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16Status=n)},v2c:function(n){gx.fn.setGridComboBoxValue("vSTATUS",n||gx.fn.currentGridRowImpl(32),gx.O.AV16Status)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV16Status=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSTATUS",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[38]={id:38,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBSCRIBE",fmt:1,gxz:"ZV24Subscribe",gxold:"OV24Subscribe",gxvar:"AV24Subscribe",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV24Subscribe=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24Subscribe=n)},v2c:function(n){gx.fn.setGridControlValue("vSUBSCRIBE",n||gx.fn.currentGridRowImpl(32),gx.O.AV24Subscribe,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV24Subscribe=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSUBSCRIBE",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn,evt:"e189g2_client"};t[39]={id:39,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:this.Validv_Event,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEVENT",fmt:0,gxz:"ZV10Event",gxold:"OV10Event",gxvar:"AV10Event",ucs:[],op:[39],ip:[39],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV10Event=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10Event=n)},v2c:function(n){gx.fn.setGridComboBoxValue("vEVENT",n||gx.fn.currentGridRowImpl(32),gx.O.AV10Event)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10Event=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vEVENT",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[40]={id:40,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILENAME",fmt:0,gxz:"ZV13FileName",gxold:"OV13FileName",gxvar:"AV13FileName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13FileName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13FileName=n)},v2c:function(n){gx.fn.setGridControlValue("vFILENAME",n||gx.fn.currentGridRowImpl(32),gx.O.AV13FileName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13FileName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vFILENAME",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[41]={id:41,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCLASSNAME",fmt:0,gxz:"ZV7ClassName",gxold:"OV7ClassName",gxvar:"AV7ClassName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV7ClassName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7ClassName=n)},v2c:function(n){gx.fn.setGridControlValue("vCLASSNAME",n||gx.fn.currentGridRowImpl(32),gx.O.AV7ClassName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV7ClassName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vCLASSNAME",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[42]={id:42,lvl:2,type:"char",len:60,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMETHODNAME",fmt:0,gxz:"ZV15MethodName",gxold:"OV15MethodName",gxvar:"AV15MethodName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV15MethodName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15MethodName=n)},v2c:function(n){gx.fn.setGridControlValue("vMETHODNAME",n||gx.fn.currentGridRowImpl(32),gx.O.AV15MethodName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV15MethodName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vMETHODNAME",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[43]={id:43,lvl:2,type:"char",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:32,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV14Id",gxold:"OV14Id",gxvar:"AV14Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV14Id=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Id=n)},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(32),gx.O.AV14Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Id=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vID",n||gx.fn.currentGridRowImpl(32))},nac:gx.falseFn};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,fld:"",grid:0};t[49]={id:49,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.ZV62Display="";this.OV62Display="";this.ZV64Update="";this.OV64Update="";this.ZV5Delete="";this.OV5Delete="";this.ZV8Description="";this.OV8Description="";this.ZV16Status="";this.OV16Status="";this.ZV24Subscribe="";this.OV24Subscribe="";this.ZV10Event="";this.OV10Event="";this.ZV13FileName="";this.OV13FileName="";this.ZV7ClassName="";this.OV7ClassName="";this.ZV15MethodName="";this.OV15MethodName="";this.ZV14Id="";this.OV14Id="";this.AV57GridCurrentPage=0;this.AV56DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV62Display="";this.AV64Update="";this.AV5Delete="";this.AV8Description="";this.AV16Status="";this.AV24Subscribe="";this.AV10Event="";this.AV13FileName="";this.AV7ClassName="";this.AV15MethodName="";this.AV14Id="";this.AV50ColumnsSelector={Columns:[]};this.AV68Pgmname="";this.AV63IsAuthorized_Display=!1;this.AV65IsAuthorized_Update=!1;this.AV66IsAuthorized_Delete=!1;this.AV29IsAuthorized_Description=!1;this.AV67IsAuthorized_Insert=!1;this.Events={e119g2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e129g2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e139g2_client:["DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",!0],e149g2_client:["'DOINSERT'",!0],e189g2_client:["VSUBSCRIBE.CLICK",!0],e199g2_client:["ENTER",!0],e209g2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV50ColumnsSelector",fld:"vCOLUMNSSELECTOR"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV68Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV29IsAuthorized_Description",fld:"vISAUTHORIZED_DESCRIPTION",hsh:!0},{av:"AV67IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0}],[{av:"AV50ColumnsSelector",fld:"vCOLUMNSSELECTOR"},{av:"gx.fn.getCtrlProperty('vDESCRIPTION','Visible')",ctrl:"vDESCRIPTION",prop:"Visible"},{ctrl:"vSTATUS"},{ctrl:"vEVENT"},{av:"gx.fn.getCtrlProperty('vFILENAME','Visible')",ctrl:"vFILENAME",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vCLASSNAME','Visible')",ctrl:"vCLASSNAME",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vMETHODNAME','Visible')",ctrl:"vMETHODNAME",prop:"Visible"},{av:"AV57GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV61GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"gx.fn.getCtrlProperty('vDISPLAY','Visible')",ctrl:"vDISPLAY",prop:"Visible"},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"gx.fn.getCtrlProperty('vUPDATE','Visible')",ctrl:"vUPDATE",prop:"Visible"},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV67IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV50ColumnsSelector",fld:"vCOLUMNSSELECTOR"},{av:"AV68Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV29IsAuthorized_Description",fld:"vISAUTHORIZED_DESCRIPTION",hsh:!0},{av:"AV67IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV50ColumnsSelector",fld:"vCOLUMNSSELECTOR"},{av:"AV68Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV29IsAuthorized_Description",fld:"vISAUTHORIZED_DESCRIPTION",hsh:!0},{av:"AV67IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{av:"",ctrl:"GRID",prop:"Rows"}]];this.EvtParms["GRID.LOAD"]=[[{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV29IsAuthorized_Description",fld:"vISAUTHORIZED_DESCRIPTION",hsh:!0}],[{av:"AV58GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV14Id",fld:"vID",hsh:!0},{av:"AV8Description",fld:"vDESCRIPTION",hsh:!0},{ctrl:"vSTATUS"},{av:"AV16Status",fld:"vSTATUS"},{ctrl:"vEVENT"},{av:"AV10Event",fld:"vEVENT"},{av:"AV13FileName",fld:"vFILENAME"},{av:"AV7ClassName",fld:"vCLASSNAME"},{av:"AV15MethodName",fld:"vMETHODNAME"},{av:"AV62Display",fld:"vDISPLAY"},{av:"gx.fn.getCtrlProperty('vDISPLAY','Link')",ctrl:"vDISPLAY",prop:"Link"},{av:"AV64Update",fld:"vUPDATE"},{av:"gx.fn.getCtrlProperty('vUPDATE','Link')",ctrl:"vUPDATE",prop:"Link"},{av:"AV5Delete",fld:"vDELETE"},{av:"gx.fn.getCtrlProperty('vDELETE','Link')",ctrl:"vDELETE",prop:"Link"},{av:"AV24Subscribe",fld:"vSUBSCRIBE"},{av:"gx.fn.getCtrlProperty('vDESCRIPTION','Link')",ctrl:"vDESCRIPTION",prop:"Link"},{av:"gx.fn.getCtrlProperty('vSUBSCRIBE','Tooltiptext')",ctrl:"vSUBSCRIBE",prop:"Tooltiptext"}]];this.EvtParms["DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV50ColumnsSelector",fld:"vCOLUMNSSELECTOR"},{av:"AV68Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV29IsAuthorized_Description",fld:"vISAUTHORIZED_DESCRIPTION",hsh:!0},{av:"AV67IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{av:"this.DDO_GRIDCOLUMNSSELECTORContainer.ColumnsSelectorValues",ctrl:"DDO_GRIDCOLUMNSSELECTOR",prop:"ColumnsSelectorValues"}],[{av:"AV50ColumnsSelector",fld:"vCOLUMNSSELECTOR"},{av:"gx.fn.getCtrlProperty('vDESCRIPTION','Visible')",ctrl:"vDESCRIPTION",prop:"Visible"},{ctrl:"vSTATUS"},{ctrl:"vEVENT"},{av:"gx.fn.getCtrlProperty('vFILENAME','Visible')",ctrl:"vFILENAME",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vCLASSNAME','Visible')",ctrl:"vCLASSNAME",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vMETHODNAME','Visible')",ctrl:"vMETHODNAME",prop:"Visible"},{av:"AV57GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV61GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"gx.fn.getCtrlProperty('vDISPLAY','Visible')",ctrl:"vDISPLAY",prop:"Visible"},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"gx.fn.getCtrlProperty('vUPDATE','Visible')",ctrl:"vUPDATE",prop:"Visible"},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV67IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"}]];this.EvtParms["'DOINSERT'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV50ColumnsSelector",fld:"vCOLUMNSSELECTOR"},{av:"AV68Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV29IsAuthorized_Description",fld:"vISAUTHORIZED_DESCRIPTION",hsh:!0},{av:"AV67IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0}],[{av:"AV50ColumnsSelector",fld:"vCOLUMNSSELECTOR"},{av:"gx.fn.getCtrlProperty('vDESCRIPTION','Visible')",ctrl:"vDESCRIPTION",prop:"Visible"},{ctrl:"vSTATUS"},{ctrl:"vEVENT"},{av:"gx.fn.getCtrlProperty('vFILENAME','Visible')",ctrl:"vFILENAME",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vCLASSNAME','Visible')",ctrl:"vCLASSNAME",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vMETHODNAME','Visible')",ctrl:"vMETHODNAME",prop:"Visible"},{av:"AV57GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV61GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"gx.fn.getCtrlProperty('vDISPLAY','Visible')",ctrl:"vDISPLAY",prop:"Visible"},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"gx.fn.getCtrlProperty('vUPDATE','Visible')",ctrl:"vUPDATE",prop:"Visible"},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV67IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"}]];this.EvtParms["VSUBSCRIBE.CLICK"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV50ColumnsSelector",fld:"vCOLUMNSSELECTOR"},{av:"AV68Pgmname",fld:"vPGMNAME",hsh:!0},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"AV29IsAuthorized_Description",fld:"vISAUTHORIZED_DESCRIPTION",hsh:!0},{av:"AV67IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"vSTATUS"},{av:"AV16Status",fld:"vSTATUS"},{av:"AV14Id",fld:"vID",hsh:!0},{av:"AV8Description",fld:"vDESCRIPTION",hsh:!0}],[{ctrl:"vSTATUS"},{av:"AV16Status",fld:"vSTATUS"},{av:"AV50ColumnsSelector",fld:"vCOLUMNSSELECTOR"},{av:"gx.fn.getCtrlProperty('vDESCRIPTION','Visible')",ctrl:"vDESCRIPTION",prop:"Visible"},{ctrl:"vEVENT"},{av:"gx.fn.getCtrlProperty('vFILENAME','Visible')",ctrl:"vFILENAME",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vCLASSNAME','Visible')",ctrl:"vCLASSNAME",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vMETHODNAME','Visible')",ctrl:"vMETHODNAME",prop:"Visible"},{av:"AV57GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV61GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS"},{av:"AV63IsAuthorized_Display",fld:"vISAUTHORIZED_DISPLAY",hsh:!0},{av:"gx.fn.getCtrlProperty('vDISPLAY','Visible')",ctrl:"vDISPLAY",prop:"Visible"},{av:"AV65IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",hsh:!0},{av:"gx.fn.getCtrlProperty('vUPDATE','Visible')",ctrl:"vUPDATE",prop:"Visible"},{av:"AV66IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",hsh:!0},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV67IsAuthorized_Insert",fld:"vISAUTHORIZED_INSERT",hsh:!0},{ctrl:"BTNINSERT",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_EVENT=[[{ctrl:"vEVENT"},{av:"AV10Event",fld:"vEVENT"}],[{ctrl:"vEVENT"},{av:"AV10Event",fld:"vEVENT"}]];this.setVCMap("AV50ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV68Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV63IsAuthorized_Display","vISAUTHORIZED_DISPLAY",0,"boolean",4,0);this.setVCMap("AV65IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV66IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV29IsAuthorized_Description","vISAUTHORIZED_DESCRIPTION",0,"boolean",4,0);this.setVCMap("AV67IsAuthorized_Insert","vISAUTHORIZED_INSERT",0,"boolean",4,0);this.setVCMap("AV50ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV68Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV63IsAuthorized_Display","vISAUTHORIZED_DISPLAY",0,"boolean",4,0);this.setVCMap("AV65IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV66IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV29IsAuthorized_Description","vISAUTHORIZED_DESCRIPTION",0,"boolean",4,0);this.setVCMap("AV50ColumnsSelector","vCOLUMNSSELECTOR",0,"WWPBaseObjectsWWPColumnsSelector",0,0);this.setVCMap("AV68Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV63IsAuthorized_Display","vISAUTHORIZED_DISPLAY",0,"boolean",4,0);this.setVCMap("AV65IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV66IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV29IsAuthorized_Description","vISAUTHORIZED_DESCRIPTION",0,"boolean",4,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});r.addRefreshingVar({rfrVar:"AV50ColumnsSelector"});r.addRefreshingVar({rfrVar:"AV68Pgmname"});r.addRefreshingVar({rfrVar:"AV63IsAuthorized_Display"});r.addRefreshingVar({rfrVar:"AV65IsAuthorized_Update"});r.addRefreshingVar({rfrVar:"AV66IsAuthorized_Delete"});r.addRefreshingVar({rfrVar:"AV29IsAuthorized_Description"});r.addRefreshingVar({rfrVar:"AV67IsAuthorized_Insert"});r.addRefreshingParm({rfrVar:"AV50ColumnsSelector"});r.addRefreshingParm({rfrVar:"AV68Pgmname"});r.addRefreshingParm({rfrVar:"AV63IsAuthorized_Display"});r.addRefreshingParm({rfrVar:"AV65IsAuthorized_Update"});r.addRefreshingParm({rfrVar:"AV66IsAuthorized_Delete"});r.addRefreshingParm({rfrVar:"AV29IsAuthorized_Description"});r.addRefreshingParm({rfrVar:"AV67IsAuthorized_Insert"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"}});this.setSDTMapping("GeneXusSecurity\\GAMRepository",{Email:{sdt:"GeneXusSecurity\\GAMRepositoryEmail"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector",{Columns:{sdt:"WWPBaseObjects\\WWPColumnsSelector.Column"}});this.setSDTMapping("WWPBaseObjects\\WWPColumnsSelector.Column",{ColumnName:{extr:"C"},IsVisible:{extr:"V"},DisplayName:{extr:"D"},Order:{extr:"O"},Category:{extr:"G"},Fixed:{extr:"F"}})});gx.wi(function(){gx.createParentObj(this.gamwweventsubscriptions)})