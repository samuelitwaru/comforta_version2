gx.evt.autoSkip=!1;gx.define("wp_createorganisationandmanagerstep1",!0,function(n){var t,i,r,u;this.ServerClass="wp_createorganisationandmanagerstep1";this.PackageName="GeneXus.Programs";this.ServerFullClass="wp_createorganisationandmanagerstep1.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7GoingBack=gx.fn.getControlValue("vGOINGBACK");this.AV22CheckRequiredFieldsResult=gx.fn.getControlValue("vCHECKREQUIREDFIELDSRESULT");this.AV10HasValidationErrors=gx.fn.getControlValue("vHASVALIDATIONERRORS");this.AV6WebSessionKey=gx.fn.getControlValue("vWEBSESSIONKEY");this.AV8PreviousStep=gx.fn.getControlValue("vPREVIOUSSTEP")};this.Validv_Organisationtypeid=function(){return this.validCliEvt("Validv_Organisationtypeid",0,function(){try{var n=gx.util.balloon.getNew("vORGANISATIONTYPEID");if(this.AnyError=0,!gx.util.regExp.isMatch(this.AV21OrganisationTypeId,"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}|^\\s*$)"))try{n.setError("GXM_InvalidGUID");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Organisationemail=function(){return this.validCliEvt("Validv_Organisationemail",0,function(){try{var n=gx.util.balloon.getNew("vORGANISATIONEMAIL");if(this.AnyError=0,!gx.util.regExp.isMatch(this.AV13OrganisationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError("Field Organisation Email does not match the specified pattern");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Organisationid=function(){return this.validCliEvt("Validv_Organisationid",0,function(){try{var n=gx.util.balloon.getNew("vORGANISATIONID");if(this.AnyError=0,!gx.util.regExp.isMatch(this.AV14OrganisationId,"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}|^\\s*$)"))try{n.setError("GXM_InvalidGUID");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s132_client=function(){return this.executeClientEvent(function(){!this.AV7GoingBack||(this.BTNWIZARDFIRSTPREVIOUSContainer.Visible=!1)},arguments)};this.e164g1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV27OrganisationAddressCountry=this.COMBO_ORGANISATIONADDRESSCOUNTRYContainer.SelectedValue_get;this.refreshOutputs([{av:"AV27OrganisationAddressCountry",fld:"vORGANISATIONADDRESSCOUNTRY"}]);this.OnClientEventEnd()},arguments)};this.e134g2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e144g2_client=function(){return this.executeServerEvent("'WIZARDPREVIOUS'",!0,null,!1,!1)};this.e174g2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,74,76,77,78,79,80];this.GXLastCtrlId=80;this.COMBO_ORGANISATIONADDRESSCOUNTRYContainer=gx.uc.getNew(this,50,20,"BootstrapDropDownOptions",this.CmpContext+"COMBO_ORGANISATIONADDRESSCOUNTRYContainer","Combo_organisationaddresscountry","COMBO_ORGANISATIONADDRESSCOUNTRY");i=this.COMBO_ORGANISATIONADDRESSCOUNTRYContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo Attribute ExtendedComboWithImage","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setDynProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");i.setProp("RemoteServicesParameters","Remoteservicesparameters","","str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!1,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setDynProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","char");i.setProp("NoResultsFound","Noresultsfound","","char");i.setProp("EmptyItemText","Emptyitemtext","","char");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.addV2CFunction("AV29DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");i.addC2VFunction(function(n){n.ParentObject.AV29DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV29DDO_TitleSettingsIcons)});i.addV2CFunction("AV28OrganisationAddressCountry_Data","vORGANISATIONADDRESSCOUNTRY_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV28OrganisationAddressCountry_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vORGANISATIONADDRESSCOUNTRY_DATA",n.ParentObject.AV28OrganisationAddressCountry_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e164g1_client);this.setUserControl(i);this.BTNWIZARDFIRSTPREVIOUSContainer=gx.uc.getNew(this,73,20,"WWP_IconButton",this.CmpContext+"BTNWIZARDFIRSTPREVIOUSContainer","Btnwizardfirstprevious","BTNWIZARDFIRSTPREVIOUS");r=this.BTNWIZARDFIRSTPREVIOUSContainer;r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("TooltipText","Tooltiptext","","str");r.setProp("BeforeIconClass","Beforeiconclass","","str");r.setProp("AfterIconClass","Aftericonclass","","str");r.addEventHandler("Event",this.e144g2_client);r.setProp("Caption","Caption","Cancel","str");r.setProp("Class","Class","ButtonMaterialDefault ButtonWizard","str");r.setDynProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.BTNWIZARDNEXTContainer=gx.uc.getNew(this,75,20,"WWP_IconButton",this.CmpContext+"BTNWIZARDNEXTContainer","Btnwizardnext","BTNWIZARDNEXT");u=this.BTNWIZARDNEXTContainer;u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("TooltipText","Tooltiptext","","str");u.setProp("BeforeIconClass","Beforeiconclass","","str");u.setProp("AfterIconClass","Aftericonclass","","str");u.addEventHandler("Event",this.e134g2_client);u.setProp("Caption","Caption","Next","str");u.setProp("Class","Class","ButtonMaterial ButtonWizard","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TABLECONTENT",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"TABLEATTRIBUTES",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONNAME",fmt:0,gxz:"ZV16OrganisationName",gxold:"OV16OrganisationName",gxvar:"AV16OrganisationName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16OrganisationName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16OrganisationName=n)},v2c:function(){gx.fn.setControlValue("vORGANISATIONNAME",gx.O.AV16OrganisationName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16OrganisationName=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONNAME")},nac:gx.falseFn};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Organisationtypeid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONTYPEID",fmt:0,gxz:"ZV21OrganisationTypeId",gxold:"OV21OrganisationTypeId",gxvar:"AV21OrganisationTypeId",ucs:[],op:[],ip:[24],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV21OrganisationTypeId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21OrganisationTypeId=n)},v2c:function(){gx.fn.setComboBoxValue("vORGANISATIONTYPEID",gx.O.AV21OrganisationTypeId)},c2v:function(){this.val()!==undefined&&(gx.O.AV21OrganisationTypeId=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONTYPEID")},nac:gx.falseFn,hasRVFmt:!0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONKVKNUMBER",fmt:0,gxz:"ZV15OrganisationKvkNumber",gxold:"OV15OrganisationKvkNumber",gxvar:"AV15OrganisationKvkNumber",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15OrganisationKvkNumber=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15OrganisationKvkNumber=n)},v2c:function(){gx.fn.setControlValue("vORGANISATIONKVKNUMBER",gx.O.AV15OrganisationKvkNumber,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15OrganisationKvkNumber=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONKVKNUMBER")},nac:gx.falseFn};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Organisationemail,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONEMAIL",fmt:0,gxz:"ZV13OrganisationEmail",gxold:"OV13OrganisationEmail",gxvar:"AV13OrganisationEmail",ucs:[],op:[],ip:[33],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13OrganisationEmail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13OrganisationEmail=n)},v2c:function(){gx.fn.setControlValue("vORGANISATIONEMAIL",gx.O.AV13OrganisationEmail,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13OrganisationEmail=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONEMAIL")},nac:gx.falseFn,hasRVFmt:!0};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONPHONE",fmt:0,gxz:"ZV17OrganisationPhone",gxold:"OV17OrganisationPhone",gxvar:"AV17OrganisationPhone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17OrganisationPhone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17OrganisationPhone=n)},v2c:function(){gx.fn.setControlValue("vORGANISATIONPHONE",gx.O.AV17OrganisationPhone,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17OrganisationPhone=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONPHONE")},nac:gx.falseFn};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONVATNUMBER",fmt:0,gxz:"ZV19OrganisationVATNumber",gxold:"OV19OrganisationVATNumber",gxvar:"AV19OrganisationVATNumber",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV19OrganisationVATNumber=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV19OrganisationVATNumber=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vORGANISATIONVATNUMBER",gx.O.AV19OrganisationVATNumber,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV19OrganisationVATNumber=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vORGANISATIONVATNUMBER",",")},nac:gx.falseFn};t[43]={id:43,fld:"",grid:0};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"TABLESPLITTEDORGANISATIONADDRESSCOUNTRY",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,fld:"TEXTBLOCKCOMBO_ORGANISATIONADDRESSCOUNTRY",format:0,grid:0,ctrltype:"textblock"};t[49]={id:49,fld:"",grid:0};t[51]={id:51,fld:"",grid:0};t[52]={id:52,fld:"",grid:0};t[53]={id:53,fld:"",grid:0};t[54]={id:54,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONADDRESSCITY",fmt:0,gxz:"ZV23OrganisationAddressCity",gxold:"OV23OrganisationAddressCity",gxvar:"AV23OrganisationAddressCity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV23OrganisationAddressCity=n)},v2z:function(n){n!==undefined&&(gx.O.ZV23OrganisationAddressCity=n)},v2c:function(){gx.fn.setControlValue("vORGANISATIONADDRESSCITY",gx.O.AV23OrganisationAddressCity,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV23OrganisationAddressCity=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONADDRESSCITY")},nac:gx.falseFn};t[55]={id:55,fld:"",grid:0};t[56]={id:56,fld:"",grid:0};t[57]={id:57,fld:"",grid:0};t[58]={id:58,fld:"",grid:0};t[59]={id:59,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONADDRESSZIPCODE",fmt:0,gxz:"ZV26OrganisationAddressZipCode",gxold:"OV26OrganisationAddressZipCode",gxvar:"AV26OrganisationAddressZipCode",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV26OrganisationAddressZipCode=n)},v2z:function(n){n!==undefined&&(gx.O.ZV26OrganisationAddressZipCode=n)},v2c:function(){gx.fn.setControlValue("vORGANISATIONADDRESSZIPCODE",gx.O.AV26OrganisationAddressZipCode,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV26OrganisationAddressZipCode=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONADDRESSZIPCODE")},nac:gx.falseFn};t[60]={id:60,fld:"",grid:0};t[61]={id:61,fld:"",grid:0};t[62]={id:62,fld:"",grid:0};t[63]={id:63,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONADDRESSLINE1",fmt:0,gxz:"ZV34OrganisationAddressLine1",gxold:"OV34OrganisationAddressLine1",gxvar:"AV34OrganisationAddressLine1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV34OrganisationAddressLine1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV34OrganisationAddressLine1=n)},v2c:function(){gx.fn.setControlValue("vORGANISATIONADDRESSLINE1",gx.O.AV34OrganisationAddressLine1,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV34OrganisationAddressLine1=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONADDRESSLINE1")},nac:gx.falseFn};t[64]={id:64,fld:"",grid:0};t[65]={id:65,fld:"",grid:0};t[66]={id:66,fld:"",grid:0};t[67]={id:67,fld:"",grid:0};t[68]={id:68,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONADDRESSLINE2",fmt:0,gxz:"ZV35OrganisationAddressLine2",gxold:"OV35OrganisationAddressLine2",gxvar:"AV35OrganisationAddressLine2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV35OrganisationAddressLine2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV35OrganisationAddressLine2=n)},v2c:function(){gx.fn.setControlValue("vORGANISATIONADDRESSLINE2",gx.O.AV35OrganisationAddressLine2,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV35OrganisationAddressLine2=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONADDRESSLINE2")},nac:gx.falseFn};t[69]={id:69,fld:"",grid:0};t[70]={id:70,fld:"",grid:0};t[71]={id:71,fld:"TABLEACTIONS",grid:0};t[72]={id:72,fld:"",grid:0};t[74]={id:74,fld:"",grid:0};t[76]={id:76,fld:"",grid:0};t[77]={id:77,fld:"",grid:0};t[78]={id:78,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[79]={id:79,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONADDRESSCOUNTRY",fmt:0,gxz:"ZV27OrganisationAddressCountry",gxold:"OV27OrganisationAddressCountry",gxvar:"AV27OrganisationAddressCountry",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV27OrganisationAddressCountry=n)},v2z:function(n){n!==undefined&&(gx.O.ZV27OrganisationAddressCountry=n)},v2c:function(){gx.fn.setControlValue("vORGANISATIONADDRESSCOUNTRY",gx.O.AV27OrganisationAddressCountry,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV27OrganisationAddressCountry=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONADDRESSCOUNTRY")},nac:gx.falseFn};t[80]={id:80,lvl:0,type:"guid",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Organisationid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vORGANISATIONID",fmt:0,gxz:"ZV14OrganisationId",gxold:"OV14OrganisationId",gxvar:"AV14OrganisationId",ucs:[],op:[],ip:[80],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV14OrganisationId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14OrganisationId=n)},v2c:function(){gx.fn.setComboBoxValue("vORGANISATIONID",gx.O.AV14OrganisationId)},c2v:function(){this.val()!==undefined&&(gx.O.AV14OrganisationId=this.val())},val:function(){return gx.fn.getControlValue("vORGANISATIONID")},nac:gx.falseFn,hasRVFmt:!0};this.AV16OrganisationName="";this.ZV16OrganisationName="";this.OV16OrganisationName="";this.AV21OrganisationTypeId="00000000-0000-0000-0000-000000000000";this.ZV21OrganisationTypeId="00000000-0000-0000-0000-000000000000";this.OV21OrganisationTypeId="00000000-0000-0000-0000-000000000000";this.AV15OrganisationKvkNumber="";this.ZV15OrganisationKvkNumber="";this.OV15OrganisationKvkNumber="";this.AV13OrganisationEmail="";this.ZV13OrganisationEmail="";this.OV13OrganisationEmail="";this.AV17OrganisationPhone="";this.ZV17OrganisationPhone="";this.OV17OrganisationPhone="";this.AV19OrganisationVATNumber=0;this.ZV19OrganisationVATNumber=0;this.OV19OrganisationVATNumber=0;this.AV23OrganisationAddressCity="";this.ZV23OrganisationAddressCity="";this.OV23OrganisationAddressCity="";this.AV26OrganisationAddressZipCode="";this.ZV26OrganisationAddressZipCode="";this.OV26OrganisationAddressZipCode="";this.AV34OrganisationAddressLine1="";this.ZV34OrganisationAddressLine1="";this.OV34OrganisationAddressLine1="";this.AV35OrganisationAddressLine2="";this.ZV35OrganisationAddressLine2="";this.OV35OrganisationAddressLine2="";this.AV27OrganisationAddressCountry="";this.ZV27OrganisationAddressCountry="";this.OV27OrganisationAddressCountry="";this.AV14OrganisationId="00000000-0000-0000-0000-000000000000";this.ZV14OrganisationId="00000000-0000-0000-0000-000000000000";this.OV14OrganisationId="00000000-0000-0000-0000-000000000000";this.AV16OrganisationName="";this.AV21OrganisationTypeId="00000000-0000-0000-0000-000000000000";this.AV15OrganisationKvkNumber="";this.AV13OrganisationEmail="";this.AV17OrganisationPhone="";this.AV19OrganisationVATNumber=0;this.AV29DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV23OrganisationAddressCity="";this.AV26OrganisationAddressZipCode="";this.AV34OrganisationAddressLine1="";this.AV35OrganisationAddressLine2="";this.AV27OrganisationAddressCountry="";this.AV14OrganisationId="00000000-0000-0000-0000-000000000000";this.AV6WebSessionKey="";this.AV8PreviousStep="";this.AV7GoingBack=!1;this.AV22CheckRequiredFieldsResult=!1;this.AV10HasValidationErrors=!1;this.Events={e134g2_client:["ENTER",!0],e144g2_client:["'WIZARDPREVIOUS'",!0],e174g2_client:["CANCEL",!0],e164g1_client:["COMBO_ORGANISATIONADDRESSCOUNTRY.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[{av:"AV7GoingBack",fld:"vGOINGBACK"},{ctrl:"vORGANISATIONID"},{av:"AV14OrganisationId",fld:"vORGANISATIONID"},{ctrl:"vORGANISATIONTYPEID"},{av:"AV21OrganisationTypeId",fld:"vORGANISATIONTYPEID"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0}],[{av:"this.BTNWIZARDFIRSTPREVIOUSContainer.Visible",ctrl:"BTNWIZARDFIRSTPREVIOUS",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"AV22CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT"},{av:"AV10HasValidationErrors",fld:"vHASVALIDATIONERRORS",hsh:!0},{av:"AV16OrganisationName",fld:"vORGANISATIONNAME"},{ctrl:"vORGANISATIONTYPEID"},{av:"AV21OrganisationTypeId",fld:"vORGANISATIONTYPEID"},{av:"AV15OrganisationKvkNumber",fld:"vORGANISATIONKVKNUMBER"},{av:"AV19OrganisationVATNumber",fld:"vORGANISATIONVATNUMBER",pic:"ZZZZZZZ9"},{av:"AV6WebSessionKey",fld:"vWEBSESSIONKEY"},{av:"AV13OrganisationEmail",fld:"vORGANISATIONEMAIL"},{av:"AV17OrganisationPhone",fld:"vORGANISATIONPHONE"},{av:"AV27OrganisationAddressCountry",fld:"vORGANISATIONADDRESSCOUNTRY"},{av:"AV23OrganisationAddressCity",fld:"vORGANISATIONADDRESSCITY"},{av:"AV26OrganisationAddressZipCode",fld:"vORGANISATIONADDRESSZIPCODE"},{av:"AV34OrganisationAddressLine1",fld:"vORGANISATIONADDRESSLINE1"},{av:"AV35OrganisationAddressLine2",fld:"vORGANISATIONADDRESSLINE2"}],[{av:"AV22CheckRequiredFieldsResult",fld:"vCHECKREQUIREDFIELDSRESULT"},{ctrl:"vORGANISATIONID"},{av:"AV14OrganisationId",fld:"vORGANISATIONID"}]];this.EvtParms["'WIZARDPREVIOUS'"]=[[],[]];this.EvtParms["COMBO_ORGANISATIONADDRESSCOUNTRY.ONOPTIONCLICKED"]=[[{av:"this.COMBO_ORGANISATIONADDRESSCOUNTRYContainer.SelectedValue_get",ctrl:"COMBO_ORGANISATIONADDRESSCOUNTRY",prop:"SelectedValue_get"}],[{av:"AV27OrganisationAddressCountry",fld:"vORGANISATIONADDRESSCOUNTRY"}]];this.EvtParms.VALIDV_ORGANISATIONTYPEID=[[],[]];this.EvtParms.VALIDV_ORGANISATIONEMAIL=[[],[]];this.EvtParms.VALIDV_ORGANISATIONID=[[],[]];this.EnterCtrl=["BTNWIZARDNEXT"];this.setVCMap("AV7GoingBack","vGOINGBACK",0,"boolean",4,0);this.setVCMap("AV22CheckRequiredFieldsResult","vCHECKREQUIREDFIELDSRESULT",0,"boolean",4,0);this.setVCMap("AV10HasValidationErrors","vHASVALIDATIONERRORS",0,"boolean",4,0);this.setVCMap("AV6WebSessionKey","vWEBSESSIONKEY",0,"svchar",40,0);this.setVCMap("AV8PreviousStep","vPREVIOUSSTEP",0,"svchar",40,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}});this.setSDTMapping("WP_CreateOrganisationAndManagerData",{Step1:{sdt:"WP_CreateOrganisationAndManagerData.Step1"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}})})