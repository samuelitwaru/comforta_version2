gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.workwithplusmasterpagetoolbox",!1,function(){var n,i,r,u,t;this.ServerClass="wwpbaseobjects.workwithplusmasterpagetoolbox";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.workwithplusmasterpagetoolbox.aspx";this.setObjectType("web");this.IsMasterPage=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV11NotificationInfo=gx.fn.getControlValue("vNOTIFICATIONINFO_MPAGE");this.A112WWPUserExtendedId=gx.fn.getControlValue("WWPUSEREXTENDEDID_MPAGE");this.AV34Udparg1=gx.fn.getControlValue("vUDPARG1_MPAGE");this.A187WWPNotificationIsRead=gx.fn.getControlValue("WWPNOTIFICATIONISREAD_MPAGE")};this.e117u1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.UCMENU_MPAGEContainer.CollapseExpand();this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e127u2_client=function(){return this.executeServerEvent("DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE",!1,null,!0,!0)};this.e137u2_client=function(){return this.executeServerEvent("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE",!1,null,!0,!0)};this.e147u2_client=function(){return this.executeServerEvent("DDC_RUNTIMEDESIGNSETTINGS_MPAGE.ONLOADCOMPONENT_MPAGE",!1,null,!0,!0)};this.e167u2_client=function(){return this.executeServerEvent("ONMESSAGE_GX1_MPAGE",!0,null,!0,!1)};this.e187u2_client=function(){return this.executeServerEvent("ENTER_MPAGE",!0,null,!1,!1)};this.e197u2_client=function(){return this.executeServerEvent("CANCEL_MPAGE",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,20,22,24,25,26,27,28,30,31,33,34,35,36,37];this.GXLastCtrlId=37;this.DDC_NOTIFICATIONSWC_MPAGEContainer=gx.uc.getNew(this,19,0,"BootstrapDropDownOptions","DDC_NOTIFICATIONSWC_MPAGEContainer","Ddc_notificationswc","DDC_NOTIFICATIONSWC_MPAGE");i=this.DDC_NOTIFICATIONSWC_MPAGEContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("IconType","Icontype","FontIcon","str");i.setProp("Icon","Icon","far fa-bell","str");i.setProp("Caption","Caption","999","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","DropDownNotification","str");i.setProp("ComponentWidth","Componentwidth",400,"num");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","Component","str");i.setProp("Visible","Visible",!0,"bool");i.setProp("Result","Result","","char");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("ShowLoading","Showloading",!0,"bool");i.setProp("Load","Load","OnEveryClick","str");i.setProp("KeepOpened","Keepopened",!1,"bool");i.setProp("Trigger","Trigger","Click","str");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnLoadComponent",this.e127u2_client);this.setUserControl(i);this.DDC_ADMINAG_MPAGEContainer=gx.uc.getNew(this,21,0,"BootstrapDropDownOptions","DDC_ADMINAG_MPAGEContainer","Ddc_adminag","DDC_ADMINAG_MPAGE");r=this.DDC_ADMINAG_MPAGEContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("IconType","Icontype","Image","str");r.setDynProp("Icon","Icon","","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","","str");r.setProp("Cls","Cls","ActionGroupHeader ActionGroupHeaderSquare","str");r.setProp("ComponentWidth","Componentwidth",260,"num");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","Component","str");r.setProp("Visible","Visible",!0,"bool");r.setProp("Result","Result","","char");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.setProp("ShowLoading","Showloading",!0,"bool");r.setProp("Load","Load","OnEveryClick","str");r.setProp("KeepOpened","Keepopened",!1,"bool");r.setProp("Trigger","Trigger","Click","str");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnLoadComponent",this.e137u2_client);this.setUserControl(r);this.DDC_RUNTIMEDESIGNSETTINGS_MPAGEContainer=gx.uc.getNew(this,23,0,"BootstrapDropDownOptions","DDC_RUNTIMEDESIGNSETTINGS_MPAGEContainer","Ddc_runtimedesignsettings","DDC_RUNTIMEDESIGNSETTINGS_MPAGE");u=this.DDC_RUNTIMEDESIGNSETTINGS_MPAGEContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","FontIcon","str");u.setProp("Icon","Icon","fa fa-cog RuntimeSettingsIcon","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","WWP_StyleCustomizations","str");u.setProp("Cls","Cls","DropDownOptionsNoBackHover","str");u.setProp("ComponentWidth","Componentwidth",240,"num");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","Component","str");u.setProp("Visible","Visible",!0,"bool");u.setProp("Result","Result","","char");u.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.setProp("ShowLoading","Showloading",!0,"bool");u.setProp("Load","Load","OnEveryClick","str");u.setProp("KeepOpened","Keepopened",!1,"bool");u.setProp("Trigger","Trigger","Click","str");u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnLoadComponent",this.e147u2_client);this.setUserControl(u);this.UCMENU_MPAGEContainer=gx.uc.getNew(this,32,0,"BootstrapSidebarMenu","UCMENU_MPAGEContainer","Ucmenu","UCMENU_MPAGE");t=this.UCMENU_MPAGEContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("SelectedItem","Selecteditem","","char");t.setProp("SearchServiceUrl","Searchserviceurl","","str");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("SearchMinChars","Searchminchars",3,"num");t.setProp("SearchHelperDescription","Searchhelperdescription","","str");t.setProp("AllMenuItemsVisibleAtLoad","Allmenuitemsvisibleatload",!1,"bool");t.setProp("IncludeToggleButton","Includetogglebutton",!1,"bool");t.setProp("ToggleButtonPosition","Togglebuttonposition","Top","str");t.setProp("SidebarMainClass","Sidebarmainclass","page-sidebar sidebar-fixed MaterialStyle","str");t.setProp("HeaderClass","Headerclass","sidebar-header-wrapper","str");t.setProp("SearchInputClass","Searchinputclass","searchinput","str");t.setProp("SearchIconClass","Searchiconclass","searchicon fa fa-search","str");t.setProp("SearchHelperClass","Searchhelperclass","searchhelper","str");t.setProp("SidebarMenuClass","Sidebarmenuclass","nav sidebar-menu","str");t.setProp("ScrollWidth","Scrollwidth",5,"num");t.setProp("ScrollAlwaysVisible","Scrollalwaysvisible",!0,"bool");t.setProp("HideScrollInCompactMenu","Hidescrollincompactmenu",!1,"bool");t.setProp("FirstLevelIsGrouping","Firstlevelisgrouping",!1,"bool");t.setProp("ToggleButtonClass","Togglebuttonclass","fa fa-bars","str");t.addV2CFunction("AV22DVelop_Menu","vDVELOP_MENU_MPAGE","SetSidebarMenuOptionsDataOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV22DVelop_Menu=n.GetSidebarMenuOptionsDataOptionsData();gx.fn.setControlValue("vDVELOP_MENU_MPAGE",n.ParentObject.AV22DVelop_Menu)});t.addV2CFunction("AV10DVelop_Menu_UserData","vDVELOP_MENU_USERDATA_MPAGE","SetSidebarMenuUserData");t.addC2VFunction(function(n){n.ParentObject.AV10DVelop_Menu_UserData=n.GetSidebarMenuUserData();gx.fn.setControlValue("vDVELOP_MENU_USERDATA_MPAGE",n.ParentObject.AV10DVelop_Menu_UserData)});t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLEHEADER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"UNNAMEDTABLE1",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"HEADER",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"SHOWMENU",format:1,grid:0,evt:"e117u1_client",ctrltype:"textblock"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TABLEUSERROLE",grid:0};n[18]={id:18,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"TABLECONTENT",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[36]={id:36,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPICKERDUMMYVARIABLE_MPAGE",fmt:0,gxz:"ZV31PickerDummyVariable",gxold:"OV31PickerDummyVariable",gxvar:"AV31PickerDummyVariable",dp:{f:0,st:!1,wn:!1,mf:!0,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV31PickerDummyVariable=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV31PickerDummyVariable=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vPICKERDUMMYVARIABLE_MPAGE",gx.O.AV31PickerDummyVariable,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV31PickerDummyVariable=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vPICKERDUMMYVARIABLE_MPAGE")},nac:gx.falseFn};n[37]={id:37,fld:"DIV_WWPAUXWC",grid:0};this.AV31PickerDummyVariable=gx.date.nullDate();this.ZV31PickerDummyVariable=gx.date.nullDate();this.OV31PickerDummyVariable=gx.date.nullDate();this.AV22DVelop_Menu=[];this.AV31PickerDummyVariable=gx.date.nullDate();this.A187WWPNotificationIsRead=!1;this.A112WWPUserExtendedId="";this.AV11NotificationInfo={Id:"",Object:"",Message:""};this.AV34Udparg1="";this.addOnMessage("","e167u2_client",[["GeneXusServerNotificationInfo","vNOTIFICATIONINFO_MPAGE","AV11NotificationInfo"]],this.e167u2_client);this.Events={e127u2_client:["DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE",!0],e137u2_client:["DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE",!0],e147u2_client:["DDC_RUNTIMEDESIGNSETTINGS_MPAGE.ONLOADCOMPONENT_MPAGE",!0],e167u2_client:["ONMESSAGE_GX1_MPAGE",!0],e187u2_client:["ENTER_MPAGE",!0],e197u2_client:["CANCEL_MPAGE",!0],e117u1_client:["DOSHOWMENU_MPAGE",!1]};this.EvtParms.REFRESH_MPAGE=[[],[]];this.EvtParms["DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE"]=[[],[{ctrl:"WWPAUX_WC_MPAGE"}]];this.EvtParms["DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE"]=[[],[{ctrl:"WWPAUX_WC_MPAGE"}]];this.EvtParms["DDC_RUNTIMEDESIGNSETTINGS_MPAGE.ONLOADCOMPONENT_MPAGE"]=[[],[{ctrl:"WWPAUX_WC_MPAGE"}]];this.EvtParms.DOSHOWMENU_MPAGE=[[],[]];this.EvtParms.ONMESSAGE_GX1_MPAGE=[[{av:"AV11NotificationInfo",fld:"vNOTIFICATIONINFO_MPAGE"},{av:"A112WWPUserExtendedId",fld:"WWPUSEREXTENDEDID_MPAGE"},{av:"AV34Udparg1",fld:"vUDPARG1_MPAGE"},{av:"A187WWPNotificationIsRead",fld:"WWPNOTIFICATIONISREAD_MPAGE"},{av:"this.DDC_NOTIFICATIONSWC_MPAGEContainer.Icon",ctrl:"DDC_NOTIFICATIONSWC_MPAGE",prop:"Icon"}],[]];this.EvtParms.ENTER_MPAGE=[[],[]];this.setVCMap("AV11NotificationInfo","vNOTIFICATIONINFO_MPAGE",0,"GeneXusServerNotificationInfo",0,0);this.setVCMap("A112WWPUserExtendedId","WWPUSEREXTENDEDID_MPAGE",0,"char",40,0);this.setVCMap("AV34Udparg1","vUDPARG1_MPAGE",0,"char",40,0);this.setVCMap("A187WWPNotificationIsRead","WWPNOTIFICATIONISREAD_MPAGE",0,"boolean",4,0);this.setVCMap("AV11NotificationInfo","vNOTIFICATIONINFO_MPAGE",0,"GeneXusServerNotificationInfo",0,0);this.Initialize();this.setComponent({id:"WWPAUX_WC",GXClass:null,Prefix:"MPW0038",lvl:1})});gx.wi(function(){gx.createMasterPage(wwpbaseobjects.workwithplusmasterpagetoolbox)})