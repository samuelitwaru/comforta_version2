gx.evt.autoSkip=!1;gx.define("trn_col",!1,function(){var n,t,i,r;this.ServerClass="trn_col";this.PackageName="GeneXus.Programs";this.ServerFullClass="trn_col.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7Trn_ColId=gx.fn.getControlValue("vTRN_COLID");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.AV13Insert_Trn_RowId=gx.fn.getControlValue("vINSERT_TRN_ROWID");this.AV23Insert_Trn_TileId=gx.fn.getControlValue("vINSERT_TRN_TILEID");this.AV26Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Trn_colid=function(){return this.validCliEvt("Valid_Trn_colid",0,function(){try{var n=gx.util.balloon.getNew("TRN_COLID");if(this.AnyError=0,!gx.util.regExp.isMatch(this.A328Trn_ColId,"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}|^\\s*$)"))try{n.setError("GXM_InvalidGUID");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Trn_rowid=function(){return this.validSrvEvt("Valid_Trn_rowid",0).then(function(n){return n}.closure(this))};this.Valid_Trn_tileid=function(){return this.validSrvEvt("Valid_Trn_tileid",0).then(function(n){return n}.closure(this))};this.Validv_Combotrn_rowid=function(){return this.validCliEvt("Validv_Combotrn_rowid",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOTRN_ROWID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Combotrn_tileid=function(){return this.validCliEvt("Validv_Combotrn_tileid",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOTRN_TILEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e14192_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13192_client=function(){return this.executeServerEvent("COMBO_TRN_TILEID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e12192_client=function(){return this.executeServerEvent("COMBO_TRN_ROWID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e151972_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e161972_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,30,31,32,33,34,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63];this.GXLastCtrlId=63;this.COMBO_TRN_ROWIDContainer=gx.uc.getNew(this,29,22,"BootstrapDropDownOptions","COMBO_TRN_ROWIDContainer","Combo_trn_rowid","COMBO_TRN_ROWID");t=this.COMBO_TRN_ROWIDContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo Attribute","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setDynProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setDynProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","Trn_ColLoadDVCombo","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "Trn_RowId", "TrnMode": "INS", "IsDynamicCall": true, "Trn_ColId": "00000000-0000-0000-0000-000000000000"',"str");t.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!1,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","str");t.setProp("NoResultsFound","Noresultsfound","","str");t.setProp("EmptyItemText","Emptyitemtext","","char");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.addV2CFunction("AV16DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV16DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV16DDO_TitleSettingsIcons)});t.addV2CFunction("AV15Trn_RowId_Data","vTRN_ROWID_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV15Trn_RowId_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vTRN_ROWID_DATA",n.ParentObject.AV15Trn_RowId_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e12192_client);this.setUserControl(t);this.COMBO_TRN_TILEIDContainer=gx.uc.getNew(this,44,22,"BootstrapDropDownOptions","COMBO_TRN_TILEIDContainer","Combo_trn_tileid","COMBO_TRN_TILEID");i=this.COMBO_TRN_TILEIDContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo Attribute","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setDynProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setDynProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","Trn_ColLoadDVCombo","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "Trn_TileId", "TrnMode": "INS", "IsDynamicCall": true, "Trn_ColId": "00000000-0000-0000-0000-000000000000"',"str");i.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!1,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","str");i.setProp("NoResultsFound","Noresultsfound","","str");i.setProp("EmptyItemText","Emptyitemtext","","char");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.addV2CFunction("AV16DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");i.addC2VFunction(function(n){n.ParentObject.AV16DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV16DDO_TitleSettingsIcons)});i.addV2CFunction("AV24Trn_TileId_Data","vTRN_TILEID_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV24Trn_TileId_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vTRN_TILEID_DATA",n.ParentObject.AV24Trn_TileId_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e13192_client);this.setUserControl(i);this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");r=this.DVPANEL_TABLEATTRIBUTESContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelWithBorder Panel_BaseColor","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","General Information","str");r.setProp("Collapsible","Collapsible",!1,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Trn_colid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_COLID",fmt:0,gxz:"Z328Trn_ColId",gxold:"O328Trn_ColId",gxvar:"A328Trn_ColId",ucs:[],op:[],ip:[22],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A328Trn_ColId=n)},v2z:function(n){n!==undefined&&(gx.O.Z328Trn_ColId=n)},v2c:function(){gx.fn.setControlValue("TRN_COLID",gx.O.A328Trn_ColId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A328Trn_ColId=this.val())},val:function(){return gx.fn.getControlValue("TRN_COLID")},nac:function(){return!(gx.text.compare("00000000-0000-0000-0000-000000000000",this.AV7Trn_ColId)==0)}};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"TABLESPLITTEDTRN_ROWID",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"TEXTBLOCKTRN_ROWID",format:0,grid:0,ctrltype:"textblock"};n[28]={id:28,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Trn_rowid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_ROWID",fmt:0,gxz:"Z319Trn_RowId",gxold:"O319Trn_RowId",gxvar:"A319Trn_RowId",ucs:[],op:[],ip:[32],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A319Trn_RowId=n)},v2z:function(n){n!==undefined&&(gx.O.Z319Trn_RowId=n)},v2c:function(){gx.fn.setControlValue("TRN_ROWID",gx.O.A319Trn_RowId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A319Trn_RowId=this.val())},val:function(){return gx.fn.getControlValue("TRN_ROWID")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(gx.text.compare("00000000-0000-0000-0000-000000000000",this.AV13Insert_Trn_RowId)==0)}};this.declareDomainHdlr(32,function(){});n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_COLNAME",fmt:0,gxz:"Z327Trn_ColName",gxold:"O327Trn_ColName",gxvar:"A327Trn_ColName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A327Trn_ColName=n)},v2z:function(n){n!==undefined&&(gx.O.Z327Trn_ColName=n)},v2c:function(){gx.fn.setControlValue("TRN_COLNAME",gx.O.A327Trn_ColName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A327Trn_ColName=this.val())},val:function(){return gx.fn.getControlValue("TRN_COLNAME")},nac:gx.falseFn};this.declareDomainHdlr(37,function(){});n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"TABLESPLITTEDTRN_TILEID",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"TEXTBLOCKTRN_TILEID",format:0,grid:0,ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Trn_tileid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRN_TILEID",fmt:0,gxz:"Z264Trn_TileId",gxold:"O264Trn_TileId",gxvar:"A264Trn_TileId",ucs:[],op:[],ip:[47],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A264Trn_TileId=n)},v2z:function(n){n!==undefined&&(gx.O.Z264Trn_TileId=n)},v2c:function(){gx.fn.setControlValue("TRN_TILEID",gx.O.A264Trn_TileId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A264Trn_TileId=this.val())},val:function(){return gx.fn.getControlValue("TRN_TILEID")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(gx.text.compare("00000000-0000-0000-0000-000000000000",this.AV23Insert_Trn_TileId)==0)}};this.declareDomainHdlr(47,function(){});n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"BTNTRN_ENTER",grid:0,evt:"e151972_client",std:"ENTER"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"BTNTRN_CANCEL",grid:0,evt:"e161972_client"};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"BTNTRN_DELETE",grid:0,evt:"e171972_client",std:"DELETE"};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[60]={id:60,fld:"SECTIONATTRIBUTE_TRN_ROWID",grid:0};n[61]={id:61,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combotrn_rowid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOTRN_ROWID",fmt:0,gxz:"ZV20ComboTrn_RowId",gxold:"OV20ComboTrn_RowId",gxvar:"AV20ComboTrn_RowId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV20ComboTrn_RowId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20ComboTrn_RowId=n)},v2c:function(){gx.fn.setControlValue("vCOMBOTRN_ROWID",gx.O.AV20ComboTrn_RowId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV20ComboTrn_RowId=this.val())},val:function(){return gx.fn.getControlValue("vCOMBOTRN_ROWID")},nac:gx.falseFn,hasRVFmt:!0};n[62]={id:62,fld:"SECTIONATTRIBUTE_TRN_TILEID",grid:0};n[63]={id:63,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combotrn_tileid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOTRN_TILEID",fmt:0,gxz:"ZV25ComboTrn_TileId",gxold:"OV25ComboTrn_TileId",gxvar:"AV25ComboTrn_TileId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV25ComboTrn_TileId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV25ComboTrn_TileId=n)},v2c:function(){gx.fn.setControlValue("vCOMBOTRN_TILEID",gx.O.AV25ComboTrn_TileId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV25ComboTrn_TileId=this.val())},val:function(){return gx.fn.getControlValue("vCOMBOTRN_TILEID")},nac:gx.falseFn,hasRVFmt:!0};this.A328Trn_ColId="00000000-0000-0000-0000-000000000000";this.Z328Trn_ColId="00000000-0000-0000-0000-000000000000";this.O328Trn_ColId="00000000-0000-0000-0000-000000000000";this.A319Trn_RowId="00000000-0000-0000-0000-000000000000";this.Z319Trn_RowId="00000000-0000-0000-0000-000000000000";this.O319Trn_RowId="00000000-0000-0000-0000-000000000000";this.A327Trn_ColName="";this.Z327Trn_ColName="";this.O327Trn_ColName="";this.A264Trn_TileId="00000000-0000-0000-0000-000000000000";this.Z264Trn_TileId="00000000-0000-0000-0000-000000000000";this.O264Trn_TileId="00000000-0000-0000-0000-000000000000";this.AV20ComboTrn_RowId="00000000-0000-0000-0000-000000000000";this.ZV20ComboTrn_RowId="00000000-0000-0000-0000-000000000000";this.OV20ComboTrn_RowId="00000000-0000-0000-0000-000000000000";this.AV25ComboTrn_TileId="00000000-0000-0000-0000-000000000000";this.ZV25ComboTrn_TileId="00000000-0000-0000-0000-000000000000";this.OV25ComboTrn_TileId="00000000-0000-0000-0000-000000000000";this.AV8WWPContext={UserId:0,UserName:""};this.AV21GAMSession={};this.AV25ComboTrn_TileId="00000000-0000-0000-0000-000000000000";this.AV20ComboTrn_RowId="00000000-0000-0000-0000-000000000000";this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV27GXV1=0;this.AV13Insert_Trn_RowId="00000000-0000-0000-0000-000000000000";this.AV19Combo_DataJson="";this.AV23Insert_Trn_TileId="00000000-0000-0000-0000-000000000000";this.AV14TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV18ComboSelectedText="";this.AV17ComboSelectedValue="";this.AV7Trn_ColId="00000000-0000-0000-0000-000000000000";this.AV12WebSession={};this.A328Trn_ColId="00000000-0000-0000-0000-000000000000";this.A319Trn_RowId="00000000-0000-0000-0000-000000000000";this.A264Trn_TileId="00000000-0000-0000-0000-000000000000";this.A327Trn_ColName="";this.Gx_BScreen=0;this.AV26Pgmname="";this.AV16DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV15Trn_RowId_Data=[];this.AV24Trn_TileId_Data=[];this.Gx_mode="";this.Events={e14192_client:["AFTER TRN",!0],e13192_client:["COMBO_TRN_TILEID.ONOPTIONCLICKED",!0],e12192_client:["COMBO_TRN_ROWID.ONOPTIONCLICKED",!0],e151972_client:["ENTER",!0],e161972_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7Trn_ColId",fld:"vTRN_COLID",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",hsh:!0},{av:"AV7Trn_ColId",fld:"vTRN_COLID",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",hsh:!0}],[]];this.EvtParms["COMBO_TRN_TILEID.ONOPTIONCLICKED"]=[[{av:"this.COMBO_TRN_TILEIDContainer.SelectedValue_get",ctrl:"COMBO_TRN_TILEID",prop:"SelectedValue_get"}],[{av:"AV25ComboTrn_TileId",fld:"vCOMBOTRN_TILEID"}]];this.EvtParms["COMBO_TRN_ROWID.ONOPTIONCLICKED"]=[[{av:"this.COMBO_TRN_ROWIDContainer.SelectedValue_get",ctrl:"COMBO_TRN_ROWID",prop:"SelectedValue_get"}],[{av:"AV20ComboTrn_RowId",fld:"vCOMBOTRN_ROWID"}]];this.EvtParms.VALID_TRN_COLID=[[{av:"A328Trn_ColId",fld:"TRN_COLID"}],[]];this.EvtParms.VALID_TRN_ROWID=[[{av:"A319Trn_RowId",fld:"TRN_ROWID"}],[]];this.EvtParms.VALID_TRN_TILEID=[[{av:"A264Trn_TileId",fld:"TRN_TILEID"}],[]];this.EvtParms.VALIDV_COMBOTRN_ROWID=[[],[]];this.EvtParms.VALIDV_COMBOTRN_TILEID=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7Trn_ColId","vTRN_COLID",0,"guid",8,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("AV13Insert_Trn_RowId","vINSERT_TRN_ROWID",0,"guid",8,0);this.setVCMap("AV23Insert_Trn_TileId","vINSERT_TRN_TILEID",0,"guid",8,0);this.setVCMap("AV26Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}})});gx.wi(function(){gx.createParentObj(this.trn_col)})