gx.evt.autoSkip=!1;gx.define("trn_organisationsetting",!1,function(){var n,t,i,r,u;this.ServerClass="trn_organisationsetting";this.PackageName="GeneXus.Programs";this.ServerFullClass="trn_organisationsetting.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7OrganisationSettingid=gx.fn.getControlValue("vORGANISATIONSETTINGID");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.AV13Insert_OrganisationId=gx.fn.getControlValue("vINSERT_ORGANISATIONID");this.A40000OrganisationSettingLogo_GXI=gx.fn.getControlValue("ORGANISATIONSETTINGLOGO_GXI");this.A40001OrganisationSettingFavicon_GXI=gx.fn.getControlValue("ORGANISATIONSETTINGFAVICON_GXI");this.AV28Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Organisationsettingid=function(){return this.validCliEvt("Valid_Organisationsettingid",0,function(){try{var n=gx.util.balloon.getNew("ORGANISATIONSETTINGID");if(this.AnyError=0,!gx.util.regExp.isMatch(this.A100OrganisationSettingid,"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}|^\\s*$)"))try{n.setError("GXM_InvalidGUID");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Comboorganisationsettinglanguage=function(){return this.validCliEvt("Validv_Comboorganisationsettinglanguage",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOORGANISATIONSETTINGLANGUAGE");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Comboorganisationsettingfontsize=function(){return this.validCliEvt("Validv_Comboorganisationsettingfontsize",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOORGANISATIONSETTINGFONTSIZE");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Organisationid=function(){return this.validSrvEvt("Valid_Organisationid",0).then(function(n){return n}.closure(this))};this.e140f25_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV26ComboOrganisationSettingFontSize=this.COMBO_ORGANISATIONSETTINGFONTSIZEContainer.SelectedValue_get;this.refreshOutputs([{av:"AV26ComboOrganisationSettingFontSize",fld:"vCOMBOORGANISATIONSETTINGFONTSIZE"}]);this.OnClientEventEnd()},arguments)};this.e150f25_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV24ComboOrganisationSettingLanguage=this.COMBO_ORGANISATIONSETTINGLANGUAGEContainer.SelectedValue_get;this.refreshOutputs([{av:"AV24ComboOrganisationSettingLanguage",fld:"vCOMBOORGANISATIONSETTINGLANGUAGE"}]);this.OnClientEventEnd()},arguments)};this.e130f2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e120f2_client=function(){return this.executeServerEvent("DDC_SELECTCOLOR.ONLOADCOMPONENT",!1,null,!0,!0)};this.e160f25_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e170f25_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51,52,53,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74];this.GXLastCtrlId=74;this.COMBO_ORGANISATIONSETTINGLANGUAGEContainer=gx.uc.getNew(this,34,22,"BootstrapDropDownOptions","COMBO_ORGANISATIONSETTINGLANGUAGEContainer","Combo_organisationsettinglanguage","COMBO_ORGANISATIONSETTINGLANGUAGE");t=this.COMBO_ORGANISATIONSETTINGLANGUAGEContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo Attribute","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setDynProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","FixedValues","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!0,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","English:English,Dutch:Dutch,Spanish:Spanish","str");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","","char");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","char");t.setProp("RemoteServicesParameters","Remoteservicesparameters","","char");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!0,"bool");t.setProp("IncludeSelectAllOption","Includeselectalloption",!0,"bool");t.setProp("EmptyItem","Emptyitem",!0,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Tags","str");t.setProp("LoadingData","Loadingdata","","char");t.setProp("NoResultsFound","Noresultsfound","","char");t.setProp("EmptyItemText","Emptyitemtext","Select Languages","str");t.setProp("OnlySelectedValues","Onlyselectedvalues","","str");t.setProp("SelectAllText","Selectalltext","","str");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.addV2CFunction("AV16DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV16DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV16DDO_TitleSettingsIcons)});t.addV2CFunction("AV23OrganisationSettingLanguage_Data","vORGANISATIONSETTINGLANGUAGE_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV23OrganisationSettingLanguage_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vORGANISATIONSETTINGLANGUAGE_DATA",n.ParentObject.AV23OrganisationSettingLanguage_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e150f25_client);this.setUserControl(t);this.COMBO_ORGANISATIONSETTINGFONTSIZEContainer=gx.uc.getNew(this,44,22,"BootstrapDropDownOptions","COMBO_ORGANISATIONSETTINGFONTSIZEContainer","Combo_organisationsettingfontsize","COMBO_ORGANISATIONSETTINGFONTSIZE");i=this.COMBO_ORGANISATIONSETTINGFONTSIZEContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo Attribute","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setDynProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","FixedValues","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","Small:Small,Medium:Medium,Large:Large","str");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","","char");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","char");i.setProp("RemoteServicesParameters","Remoteservicesparameters","","char");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!0,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","char");i.setProp("NoResultsFound","Noresultsfound","","char");i.setProp("EmptyItemText","Emptyitemtext","Select FontSize","str");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.addV2CFunction("AV16DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");i.addC2VFunction(function(n){n.ParentObject.AV16DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV16DDO_TitleSettingsIcons)});i.addV2CFunction("AV25OrganisationSettingFontSize_Data","vORGANISATIONSETTINGFONTSIZE_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV25OrganisationSettingFontSize_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vORGANISATIONSETTINGFONTSIZE_DATA",n.ParentObject.AV25OrganisationSettingFontSize_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e140f25_client);this.setUserControl(i);this.DDC_SELECTCOLORContainer=gx.uc.getNew(this,54,22,"BootstrapDropDownOptions","DDC_SELECTCOLORContainer","Ddc_selectcolor","DDC_SELECTCOLOR");r=this.DDC_SELECTCOLORContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("IconType","Icontype","Image","str");r.setProp("Icon","Icon","","str");r.setProp("Caption","Caption","Select Base Color","str");r.setProp("Tooltip","Tooltip","","str");r.setProp("Cls","Cls","","str");r.setProp("ComponentWidth","Componentwidth",300,"num");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","Component","str");r.setProp("Visible","Visible",!0,"bool");r.setProp("Result","Result","","char");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.setProp("ShowLoading","Showloading",!0,"bool");r.setProp("Load","Load","OnEveryClick","str");r.setProp("KeepOpened","Keepopened",!1,"bool");r.setProp("Trigger","Trigger","Click","str");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnLoadComponent",this.e120f2_client);this.setUserControl(r);this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");u=this.DVPANEL_TABLEATTRIBUTESContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("Width","Width","100%","str");u.setProp("Height","Height","100","str");u.setProp("AutoWidth","Autowidth",!1,"bool");u.setProp("AutoHeight","Autoheight",!0,"bool");u.setProp("Cls","Cls","PanelWithBorder Panel_BaseColor","str");u.setProp("ShowHeader","Showheader",!0,"bool");u.setProp("Title","Title","General Information","str");u.setProp("Collapsible","Collapsible",!1,"bool");u.setProp("Collapsed","Collapsed",!1,"bool");u.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");u.setProp("IconPosition","Iconposition","Right","str");u.setProp("AutoScroll","Autoscroll",!1,"bool");u.setProp("Visible","Visible",!0,"bool");u.setProp("Gx Control Type","Gxcontroltype","","int");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORGANISATIONSETTINGLOGO",fmt:0,gxz:"Z101OrganisationSettingLogo",gxold:"O101OrganisationSettingLogo",gxvar:"A101OrganisationSettingLogo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A101OrganisationSettingLogo=n)},v2z:function(n){n!==undefined&&(gx.O.Z101OrganisationSettingLogo=n)},v2c:function(){gx.fn.setMultimediaValue("ORGANISATIONSETTINGLOGO",gx.O.A101OrganisationSettingLogo,gx.O.A40000OrganisationSettingLogo_GXI)},c2v:function(){gx.O.A40000OrganisationSettingLogo_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A101OrganisationSettingLogo=this.val())},val:function(){return gx.fn.getBlobValue("ORGANISATIONSETTINGLOGO")},val_GXI:function(){return gx.fn.getControlValue("ORGANISATIONSETTINGLOGO_GXI")},gxvar_GXI:"A40000OrganisationSettingLogo_GXI",nac:gx.falseFn};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORGANISATIONSETTINGFAVICON",fmt:0,gxz:"Z102OrganisationSettingFavicon",gxold:"O102OrganisationSettingFavicon",gxvar:"A102OrganisationSettingFavicon",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A102OrganisationSettingFavicon=n)},v2z:function(n){n!==undefined&&(gx.O.Z102OrganisationSettingFavicon=n)},v2c:function(){gx.fn.setMultimediaValue("ORGANISATIONSETTINGFAVICON",gx.O.A102OrganisationSettingFavicon,gx.O.A40001OrganisationSettingFavicon_GXI)},c2v:function(){gx.O.A40001OrganisationSettingFavicon_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A102OrganisationSettingFavicon=this.val())},val:function(){return gx.fn.getBlobValue("ORGANISATIONSETTINGFAVICON")},val_GXI:function(){return gx.fn.getControlValue("ORGANISATIONSETTINGFAVICON_GXI")},gxvar_GXI:"A40001OrganisationSettingFavicon_GXI",nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"TABLESPLITTEDORGANISATIONSETTINGLANGUAGE",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"TEXTBLOCKORGANISATIONSETTINGLANGUAGE",format:0,grid:0,ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORGANISATIONSETTINGLANGUAGE",fmt:0,gxz:"Z105OrganisationSettingLanguage",gxold:"O105OrganisationSettingLanguage",gxvar:"A105OrganisationSettingLanguage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A105OrganisationSettingLanguage=n)},v2z:function(n){n!==undefined&&(gx.O.Z105OrganisationSettingLanguage=n)},v2c:function(){gx.fn.setControlValue("ORGANISATIONSETTINGLANGUAGE",gx.O.A105OrganisationSettingLanguage,0)},c2v:function(){this.val()!==undefined&&(gx.O.A105OrganisationSettingLanguage=this.val())},val:function(){return gx.fn.getControlValue("ORGANISATIONSETTINGLANGUAGE")},nac:gx.falseFn};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"TABLESPLITTEDORGANISATIONSETTINGFONTSIZE",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"TEXTBLOCKORGANISATIONSETTINGFONTSIZE",format:0,grid:0,ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORGANISATIONSETTINGFONTSIZE",fmt:0,gxz:"Z104OrganisationSettingFontSize",gxold:"O104OrganisationSettingFontSize",gxvar:"A104OrganisationSettingFontSize",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A104OrganisationSettingFontSize=n)},v2z:function(n){n!==undefined&&(gx.O.Z104OrganisationSettingFontSize=n)},v2c:function(){gx.fn.setControlValue("ORGANISATIONSETTINGFONTSIZE",gx.O.A104OrganisationSettingFontSize,0)},c2v:function(){this.val()!==undefined&&(gx.O.A104OrganisationSettingFontSize=this.val())},val:function(){return gx.fn.getControlValue("ORGANISATIONSETTINGFONTSIZE")},nac:gx.falseFn};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"UNNAMEDTABLE1",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"BASECOLOR",format:0,grid:0,ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"BTNTRN_ENTER",grid:0,evt:"e160f25_client",std:"ENTER"};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"BTNTRN_CANCEL",grid:0,evt:"e170f25_client"};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"BTNTRN_DELETE",grid:0,evt:"e180f25_client",std:"DELETE"};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[67]={id:67,fld:"SECTIONATTRIBUTE_ORGANISATIONSETTINGLANGUAGE",grid:0};n[68]={id:68,lvl:0,type:"vchar",len:2097152,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:this.Validv_Comboorganisationsettinglanguage,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOORGANISATIONSETTINGLANGUAGE",fmt:0,gxz:"ZV24ComboOrganisationSettingLanguage",gxold:"OV24ComboOrganisationSettingLanguage",gxvar:"AV24ComboOrganisationSettingLanguage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV24ComboOrganisationSettingLanguage=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24ComboOrganisationSettingLanguage=n)},v2c:function(){gx.fn.setControlValue("vCOMBOORGANISATIONSETTINGLANGUAGE",gx.O.AV24ComboOrganisationSettingLanguage,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV24ComboOrganisationSettingLanguage=this.val())},val:function(){return gx.fn.getControlValue("vCOMBOORGANISATIONSETTINGLANGUAGE")},nac:gx.falseFn};n[69]={id:69,fld:"SECTIONATTRIBUTE_ORGANISATIONSETTINGFONTSIZE",grid:0};n[70]={id:70,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Validv_Comboorganisationsettingfontsize,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOORGANISATIONSETTINGFONTSIZE",fmt:0,gxz:"ZV26ComboOrganisationSettingFontSize",gxold:"OV26ComboOrganisationSettingFontSize",gxvar:"AV26ComboOrganisationSettingFontSize",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV26ComboOrganisationSettingFontSize=n)},v2z:function(n){n!==undefined&&(gx.O.ZV26ComboOrganisationSettingFontSize=n)},v2c:function(){gx.fn.setControlValue("vCOMBOORGANISATIONSETTINGFONTSIZE",gx.O.AV26ComboOrganisationSettingFontSize,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV26ComboOrganisationSettingFontSize=this.val())},val:function(){return gx.fn.getControlValue("vCOMBOORGANISATIONSETTINGFONTSIZE")},nac:gx.falseFn};n[71]={id:71,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Organisationid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORGANISATIONID",fmt:0,gxz:"Z11OrganisationId",gxold:"O11OrganisationId",gxvar:"A11OrganisationId",ucs:[],op:[],ip:[71],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A11OrganisationId=n)},v2z:function(n){n!==undefined&&(gx.O.Z11OrganisationId=n)},v2c:function(){gx.fn.setControlValue("ORGANISATIONID",gx.O.A11OrganisationId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A11OrganisationId=this.val())},val:function(){return gx.fn.getControlValue("ORGANISATIONID")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(gx.text.compare("00000000-0000-0000-0000-000000000000",this.AV13Insert_OrganisationId)==0)}};this.declareDomainHdlr(71,function(){});n[72]={id:72,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Organisationsettingid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORGANISATIONSETTINGID",fmt:0,gxz:"Z100OrganisationSettingid",gxold:"O100OrganisationSettingid",gxvar:"A100OrganisationSettingid",ucs:[],op:[],ip:[72],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A100OrganisationSettingid=n)},v2z:function(n){n!==undefined&&(gx.O.Z100OrganisationSettingid=n)},v2c:function(){gx.fn.setControlValue("ORGANISATIONSETTINGID",gx.O.A100OrganisationSettingid,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A100OrganisationSettingid=this.val())},val:function(){return gx.fn.getControlValue("ORGANISATIONSETTINGID")},nac:function(){return!(gx.text.compare("00000000-0000-0000-0000-000000000000",this.AV7OrganisationSettingid)==0)}};this.declareDomainHdlr(72,function(){});n[73]={id:73,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORGANISATIONSETTINGBASECOLOR",fmt:0,gxz:"Z103OrganisationSettingBaseColor",gxold:"O103OrganisationSettingBaseColor",gxvar:"A103OrganisationSettingBaseColor",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A103OrganisationSettingBaseColor=n)},v2z:function(n){n!==undefined&&(gx.O.Z103OrganisationSettingBaseColor=n)},v2c:function(){gx.fn.setControlValue("ORGANISATIONSETTINGBASECOLOR",gx.O.A103OrganisationSettingBaseColor,0)},c2v:function(){this.val()!==undefined&&(gx.O.A103OrganisationSettingBaseColor=this.val())},val:function(){return gx.fn.getControlValue("ORGANISATIONSETTINGBASECOLOR")},nac:gx.falseFn};n[74]={id:74,fld:"DIV_WWPAUXWC",grid:0};this.A40000OrganisationSettingLogo_GXI="";this.A101OrganisationSettingLogo="";this.Z101OrganisationSettingLogo="";this.O101OrganisationSettingLogo="";this.A40001OrganisationSettingFavicon_GXI="";this.A102OrganisationSettingFavicon="";this.Z102OrganisationSettingFavicon="";this.O102OrganisationSettingFavicon="";this.A105OrganisationSettingLanguage="";this.Z105OrganisationSettingLanguage="";this.O105OrganisationSettingLanguage="";this.A104OrganisationSettingFontSize="";this.Z104OrganisationSettingFontSize="";this.O104OrganisationSettingFontSize="";this.AV24ComboOrganisationSettingLanguage="";this.ZV24ComboOrganisationSettingLanguage="";this.OV24ComboOrganisationSettingLanguage="";this.AV26ComboOrganisationSettingFontSize="";this.ZV26ComboOrganisationSettingFontSize="";this.OV26ComboOrganisationSettingFontSize="";this.A11OrganisationId="00000000-0000-0000-0000-000000000000";this.Z11OrganisationId="00000000-0000-0000-0000-000000000000";this.O11OrganisationId="00000000-0000-0000-0000-000000000000";this.A100OrganisationSettingid="00000000-0000-0000-0000-000000000000";this.Z100OrganisationSettingid="00000000-0000-0000-0000-000000000000";this.O100OrganisationSettingid="00000000-0000-0000-0000-000000000000";this.A103OrganisationSettingBaseColor="";this.Z103OrganisationSettingBaseColor="";this.O103OrganisationSettingBaseColor="";this.A40000OrganisationSettingLogo_GXI="";this.A40001OrganisationSettingFavicon_GXI="";this.AV8WWPContext={UserId:0,UserName:""};this.AV26ComboOrganisationSettingFontSize="";this.AV24ComboOrganisationSettingLanguage="";this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV29GXV1=0;this.AV13Insert_OrganisationId="00000000-0000-0000-0000-000000000000";this.AV14TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV7OrganisationSettingid="00000000-0000-0000-0000-000000000000";this.AV12WebSession={};this.A100OrganisationSettingid="00000000-0000-0000-0000-000000000000";this.A11OrganisationId="00000000-0000-0000-0000-000000000000";this.A105OrganisationSettingLanguage="";this.A104OrganisationSettingFontSize="";this.A103OrganisationSettingBaseColor="";this.Gx_BScreen=0;this.AV28Pgmname="";this.A101OrganisationSettingLogo="";this.A102OrganisationSettingFavicon="";this.AV16DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV23OrganisationSettingLanguage_Data=[];this.AV25OrganisationSettingFontSize_Data=[];this.Gx_mode="";this.Events={e130f2_client:["AFTER TRN",!0],e120f2_client:["DDC_SELECTCOLOR.ONLOADCOMPONENT",!0],e160f25_client:["ENTER",!0],e170f25_client:["CANCEL",!0],e140f25_client:["COMBO_ORGANISATIONSETTINGFONTSIZE.ONOPTIONCLICKED",!1],e150f25_client:["COMBO_ORGANISATIONSETTINGLANGUAGE.ONOPTIONCLICKED",!1]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7OrganisationSettingid",fld:"vORGANISATIONSETTINGID",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",hsh:!0},{av:"AV7OrganisationSettingid",fld:"vORGANISATIONSETTINGID",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",hsh:!0}],[]];this.EvtParms["DDC_SELECTCOLOR.ONLOADCOMPONENT"]=[[],[{ctrl:"WWPAUX_WC"}]];this.EvtParms["COMBO_ORGANISATIONSETTINGFONTSIZE.ONOPTIONCLICKED"]=[[{av:"this.COMBO_ORGANISATIONSETTINGFONTSIZEContainer.SelectedValue_get",ctrl:"COMBO_ORGANISATIONSETTINGFONTSIZE",prop:"SelectedValue_get"}],[{av:"AV26ComboOrganisationSettingFontSize",fld:"vCOMBOORGANISATIONSETTINGFONTSIZE"}]];this.EvtParms["COMBO_ORGANISATIONSETTINGLANGUAGE.ONOPTIONCLICKED"]=[[{av:"this.COMBO_ORGANISATIONSETTINGLANGUAGEContainer.SelectedValue_get",ctrl:"COMBO_ORGANISATIONSETTINGLANGUAGE",prop:"SelectedValue_get"}],[{av:"AV24ComboOrganisationSettingLanguage",fld:"vCOMBOORGANISATIONSETTINGLANGUAGE"}]];this.EvtParms.VALIDV_COMBOORGANISATIONSETTINGLANGUAGE=[[],[]];this.EvtParms.VALIDV_COMBOORGANISATIONSETTINGFONTSIZE=[[],[]];this.EvtParms.VALID_ORGANISATIONID=[[{av:"A11OrganisationId",fld:"ORGANISATIONID"}],[]];this.EvtParms.VALID_ORGANISATIONSETTINGID=[[{av:"A100OrganisationSettingid",fld:"ORGANISATIONSETTINGID"}],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7OrganisationSettingid","vORGANISATIONSETTINGID",0,"guid",8,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("AV13Insert_OrganisationId","vINSERT_ORGANISATIONID",0,"guid",8,0);this.setVCMap("A40000OrganisationSettingLogo_GXI","ORGANISATIONSETTINGLOGO_GXI",0,"svchar",2048,0);this.setVCMap("A40001OrganisationSettingFavicon_GXI","ORGANISATIONSETTINGFAVICON_GXI",0,"svchar",2048,0);this.setVCMap("AV28Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize();this.setComponent({id:"WWPAUX_WC",GXClass:null,Prefix:"W0075",lvl:25});this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.trn_organisationsetting)})