gx.evt.autoSkip=!1;gx.define("workwithplus.dynamicforms.wwp_dfc_label_wc",!0,function(n){var r,t,i,u,f,e,o;this.ServerClass="workwithplus.dynamicforms.wwp_dfc_label_wc";this.PackageName="GeneXus.Programs";this.ServerFullClass="workwithplus.dynamicforms.wwp_dfc_label_wc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV5IsFirstElement=gx.fn.getControlValue("vISFIRSTELEMENT");this.AV6IsLastElement=gx.fn.getControlValue("vISLASTELEMENT");this.AV7SessionId=gx.fn.getIntegerValue("vSESSIONID",",");this.AV11WWPFormElementId=gx.fn.getIntegerValue("vWWPFORMELEMENTID",",");this.AV12NeedToReloadWC=gx.fn.getControlValue("vNEEDTORELOADWC");this.AV10WWPFormElement=gx.fn.getControlValue("vWWPFORMELEMENT");this.AV14ParentIsGridMultipleData=gx.fn.getControlValue("vPARENTISGRIDMULTIPLEDATA");this.AV13WWP_DynamicFormDataType=gx.fn.getIntegerValue("vWWP_DYNAMICFORMDATATYPE",",");this.AV8WWPDynamicFormMode=gx.fn.getControlValue("vWWPDYNAMICFORMMODE");this.AV9WWPForm=gx.fn.getControlValue("vWWPFORM")};this.s112_client=function(){return this.executeClientEvent(function(){gx.fn.setCtrlProperty("LABEL","Caption",this.AV10WWPFormElement.WWPFormElementTitle);gx.json.SDTFromJson(this.AV15WWP_DF_LabelMetadata,"WorkWithPlus_DynamicForms\\\\WWP_DF_LabelMetadata",this.AV10WWPFormElement.WWPFormElementMetadata);this.AV15WWP_DF_LabelMetadata.Style==0?gx.fn.setCtrlProperty("LABEL","Class","DynFormDataDescription"):(gx.fn.setCtrlProperty("LABEL","Class","LabelElementTitle"),gx.fn.setCtrlProperty("LABELCELL","Class","col-xs-12 LabelElementTitleCell"))},arguments)};this.s122_client=function(){return this.executeClientEvent(function(){gx.fn.setCtrlProperty("TABLEACTIONS","Visible",gx.text.compare(this.AV8WWPDynamicFormMode,"DSP")!=0)},arguments)};this.s132_client=function(){return this.executeClientEvent(function(){!this.AV5IsFirstElement||(this.BTNMOVEUPContainer.Visible=!1);!this.AV6IsLastElement||(this.BTNMOVEDOWNContainer.Visible=!1)},arguments)};this.e19371_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer.Confirm();this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e20371_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.SETTINGS_MODALContainer.Confirm();this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.s142_client=function(){return this.executeClientEvent(function(){this.AV12NeedToReloadWC=this.AV14ParentIsGridMultipleData||this.AV10WWPFormElement.WWPFormElementDataType!=this.AV13WWP_DynamicFormDataType},arguments)};this.e16372_client=function(){return this.executeServerEvent("'DOMOVEUP'",!0,null,!1,!1)};this.e17372_client=function(){return this.executeServerEvent("'DOMOVEDOWN'",!0,null,!1,!1)};this.e11372_client=function(){return this.executeServerEvent("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE",!1,null,!0,!0)};this.e13372_client=function(){return this.executeServerEvent("SETTINGS_MODAL.ONLOADCOMPONENT",!1,null,!0,!0)};this.e12372_client=function(){return this.executeServerEvent("SETTINGS_MODAL.CLOSE",!1,null,!0,!0)};this.e21372_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e22372_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];r=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,22,23,24,25,30,35];this.GXLastCtrlId=35;this.SETTINGS_MODALContainer=gx.uc.getNew(this,33,0,"BootstrapConfirmPanel",this.CmpContext+"SETTINGS_MODALContainer","Settings_modal","SETTINGS_MODAL");t=this.SETTINGS_MODALContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","800","str");t.setProp("Height","Height","100","str");t.setProp("Class","Class","","str");t.setProp("Title","Title","Element settings","str");t.setProp("ConfirmationText","Confirmationtext","","str");t.setProp("YesButtonCaption","Yesbuttoncaption","","str");t.setProp("NoButtonCaption","Nobuttoncaption","","str");t.setProp("CancelButtonCaption","Cancelbuttoncaption","","str");t.setProp("YesButtonPosition","Yesbuttonposition","right","str");t.setProp("ConfirmType","Confirmtype","","str");t.setProp("Comment","Comment","No","str");t.setProp("BodyType","Bodytype","WebComponent","str");t.setProp("BodyContentInternalName","Bodycontentinternalname","","char");t.setProp("Result","Result","","char");t.setProp("TextType","Texttype","1","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("Close",this.e12372_client);t.addEventHandler("OnLoadComponent",this.e13372_client);this.setUserControl(t);this.DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer=gx.uc.getNew(this,28,0,"BootstrapConfirmPanel",this.CmpContext+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer","Dvelop_confirmpanel_btndeleteelement","DVELOP_CONFIRMPANEL_BTNDELETEELEMENT");i=this.DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100","str");i.setProp("Height","Height","100","str");i.setProp("Class","Class","","str");i.setProp("Title","Title","Delete","str");i.setProp("ConfirmationText","Confirmationtext","DF_ConfirmCurrentElementDeletion","str");i.setProp("YesButtonCaption","Yesbuttoncaption","WWP_ConfirmTextYes","str");i.setProp("NoButtonCaption","Nobuttoncaption","WWP_ConfirmTextNo","str");i.setProp("CancelButtonCaption","Cancelbuttoncaption","WWP_ConfirmTextCancel","str");i.setProp("YesButtonPosition","Yesbuttonposition","left","str");i.setProp("ConfirmType","Confirmtype","1","str");i.setProp("Comment","Comment","No","str");i.setProp("BodyType","Bodytype","No","str");i.setProp("BodyContentInternalName","Bodycontentinternalname","","char");i.setProp("Result","Result","","char");i.setProp("TextType","Texttype","1","str");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("Close",this.e11372_client);this.setUserControl(i);this.BTNMOVEUPContainer=gx.uc.getNew(this,15,0,"WWP_IconButton",this.CmpContext+"BTNMOVEUPContainer","Btnmoveup","BTNMOVEUP");u=this.BTNMOVEUPContainer;u.setProp("Enabled","Enabled",!0,"boolean");u.setDynProp("TooltipText","Tooltiptext","Move up","str");u.setDynProp("BeforeIconClass","Beforeiconclass","fas fa-arrow-up","str");u.setProp("AfterIconClass","Aftericonclass","","str");u.addEventHandler("Event",this.e16372_client);u.setDynProp("Caption","Caption","Move up","str");u.setProp("Class","Class","ButtonGray","str");u.setDynProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);this.BTNMOVEDOWNContainer=gx.uc.getNew(this,17,0,"WWP_IconButton",this.CmpContext+"BTNMOVEDOWNContainer","Btnmovedown","BTNMOVEDOWN");f=this.BTNMOVEDOWNContainer;f.setProp("Enabled","Enabled",!0,"boolean");f.setDynProp("TooltipText","Tooltiptext","Move down","str");f.setDynProp("BeforeIconClass","Beforeiconclass","fas fa-arrow-down","str");f.setProp("AfterIconClass","Aftericonclass","","str");f.addEventHandler("Event",this.e17372_client);f.setDynProp("Caption","Caption","Move down","str");f.setProp("Class","Class","ButtonGray","str");f.setDynProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.BTNDELETEELEMENTContainer=gx.uc.getNew(this,19,0,"WWP_IconButton",this.CmpContext+"BTNDELETEELEMENTContainer","Btndeleteelement","BTNDELETEELEMENT");e=this.BTNDELETEELEMENTContainer;e.setProp("Enabled","Enabled",!0,"boolean");e.setProp("TooltipText","Tooltiptext","Delete","str");e.setProp("BeforeIconClass","Beforeiconclass","fa-trash-can far","str");e.setProp("AfterIconClass","Aftericonclass","","str");e.addEventHandler("Event",this.e19371_client);e.setDynProp("Caption","Caption","Delete","str");e.setProp("Class","Class","ButtonGray","str");e.setProp("Visible","Visible",!0,"bool");e.setC2ShowFunction(function(n){n.show()});this.setUserControl(e);this.BTNSETTINGSContainer=gx.uc.getNew(this,21,0,"WWP_IconButton",this.CmpContext+"BTNSETTINGSContainer","Btnsettings","BTNSETTINGS");o=this.BTNSETTINGSContainer;o.setProp("Enabled","Enabled",!0,"boolean");o.setProp("TooltipText","Tooltiptext","Settings","str");o.setProp("BeforeIconClass","Beforeiconclass","fas fa-gear","str");o.setProp("AfterIconClass","Aftericonclass","","str");o.addEventHandler("Event",this.e20371_client);o.setDynProp("Caption","Caption","Settings","str");o.setProp("Class","Class","ButtonGray","str");o.setProp("Visible","Visible",!0,"bool");o.setC2ShowFunction(function(n){n.show()});this.setUserControl(o);r[2]={id:2,fld:"",grid:0};r[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};r[4]={id:4,fld:"",grid:0};r[5]={id:5,fld:"",grid:0};r[6]={id:6,fld:"TABLEMAIN",grid:0};r[7]={id:7,fld:"",grid:0};r[8]={id:8,fld:"LABELCELL",grid:0};r[9]={id:9,fld:"LABEL",format:0,grid:0,ctrltype:"textblock"};r[10]={id:10,fld:"",grid:0};r[11]={id:11,fld:"",grid:0};r[12]={id:12,fld:"TABLEACTIONS",grid:0};r[22]={id:22,fld:"",grid:0};r[23]={id:23,fld:"",grid:0};r[24]={id:24,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};r[25]={id:25,fld:"TABLEDVELOP_CONFIRMPANEL_BTNDELETEELEMENT",grid:0};r[30]={id:30,fld:"TABLESETTINGS_MODAL",grid:0};r[35]={id:35,fld:"DIV_WWPAUXWC",grid:0};this.AV8WWPDynamicFormMode="";this.AV11WWPFormElementId=0;this.AV7SessionId=0;this.AV9WWPForm={WWPFormId:0,WWPFormVersionNumber:0,WWPFormReferenceName:"",WWPFormTitle:"",WWPFormDate:gx.date.nullDate(),WWPFormIsWizard:!1,WWPFormResume:0,WWPFormResumeMessage:"",WWPFormValidations:"",WWPFormInstantiated:!1,WWPFormLatestVersionNumber:0,WWPFormType:0,WWPFormSectionRefElements:"",WWPFormIsForDynamicValidations:!1,Element:[],Mode:"",Initialized:0,WWPFormId_Z:0,WWPFormVersionNumber_Z:0,WWPFormReferenceName_Z:"",WWPFormTitle_Z:"",WWPFormDate_Z:gx.date.nullDate(),WWPFormIsWizard_Z:!1,WWPFormResume_Z:0,WWPFormResumeMessage_Z:"",WWPFormValidations_Z:"",WWPFormInstantiated_Z:!1,WWPFormLatestVersionNumber_Z:0,WWPFormType_Z:0,WWPFormSectionRefElements_Z:"",WWPFormIsForDynamicValidations_Z:!1};this.AV5IsFirstElement=!1;this.AV6IsLastElement=!1;this.AV12NeedToReloadWC=!1;this.AV10WWPFormElement={WWPFormElementId:0,WWPFormElementTitle:"",WWPFormElementType:0,WWPFormElementOrderIndex:0,WWPFormElementDataType:0,WWPFormElementParentId:0,WWPFormElementParentName:"",WWPFormElementParentType:0,WWPFormElementMetadata:"",WWPFormElementCaption:0,WWPFormElementReferenceId:"",WWPFormElementExcludeFromExport:!1,Mode:"",Modified:0,Initialized:0,WWPFormElementId_Z:0,WWPFormElementTitle_Z:"",WWPFormElementType_Z:0,WWPFormElementOrderIndex_Z:0,WWPFormElementDataType_Z:0,WWPFormElementParentId_Z:0,WWPFormElementParentName_Z:"",WWPFormElementParentType_Z:0,WWPFormElementMetadata_Z:"",WWPFormElementCaption_Z:0,WWPFormElementReferenceId_Z:"",WWPFormElementExcludeFromExport_Z:!1};this.AV14ParentIsGridMultipleData=!1;this.AV13WWP_DynamicFormDataType=0;this.AV15WWP_DF_LabelMetadata={Style:0,VisibleCondition:{Expression:"",MentionedFields:[]}};this.Events={e16372_client:["'DOMOVEUP'",!0],e17372_client:["'DOMOVEDOWN'",!0],e11372_client:["DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE",!0],e13372_client:["SETTINGS_MODAL.ONLOADCOMPONENT",!0],e12372_client:["SETTINGS_MODAL.CLOSE",!0],e21372_client:["ENTER",!0],e22372_client:["CANCEL",!0],e19371_client:["'DODELETEELEMENT'",!1],e20371_client:["'DOSETTINGS'",!1]};this.EvtParms.REFRESH=[[{av:"AV5IsFirstElement",fld:"vISFIRSTELEMENT",hsh:!0},{av:"AV6IsLastElement",fld:"vISLASTELEMENT",hsh:!0},{av:"AV14ParentIsGridMultipleData",fld:"vPARENTISGRIDMULTIPLEDATA",hsh:!0},{av:"AV13WWP_DynamicFormDataType",fld:"vWWP_DYNAMICFORMDATATYPE",pic:"Z9",hsh:!0}],[{av:"this.BTNMOVEUPContainer.Visible",ctrl:"BTNMOVEUP",prop:"Visible"},{av:"this.BTNMOVEDOWNContainer.Visible",ctrl:"BTNMOVEDOWN",prop:"Visible"}]];this.EvtParms["'DOMOVEUP'"]=[[{av:"AV7SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"AV11WWPFormElementId",fld:"vWWPFORMELEMENTID",pic:"ZZZ9"}],[]];this.EvtParms["'DOMOVEDOWN'"]=[[{av:"AV7SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"AV11WWPFormElementId",fld:"vWWPFORMELEMENTID",pic:"ZZZ9"}],[]];this.EvtParms["'DODELETEELEMENT'"]=[[],[]];this.EvtParms["DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE"]=[[{av:"this.DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer.Result",ctrl:"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT",prop:"Result"},{av:"AV7SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"AV11WWPFormElementId",fld:"vWWPFORMELEMENTID",pic:"ZZZ9"}],[{av:"AV9WWPForm",fld:"vWWPFORM"},{av:"AV10WWPFormElement",fld:"vWWPFORMELEMENT"}]];this.EvtParms["'DOSETTINGS'"]=[[],[]];this.EvtParms["SETTINGS_MODAL.ONLOADCOMPONENT"]=[[{av:"AV11WWPFormElementId",fld:"vWWPFORMELEMENTID",pic:"ZZZ9"},{av:"AV7SessionId",fld:"vSESSIONID",pic:"ZZZ9"}],[{ctrl:"WWPAUX_WC"}]];this.EvtParms["SETTINGS_MODAL.CLOSE"]=[[{av:"this.SETTINGS_MODALContainer.Result",ctrl:"SETTINGS_MODAL",prop:"Result"},{av:"AV7SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"AV11WWPFormElementId",fld:"vWWPFORMELEMENTID",pic:"ZZZ9"},{av:"AV12NeedToReloadWC",fld:"vNEEDTORELOADWC"},{av:"AV10WWPFormElement",fld:"vWWPFORMELEMENT"},{av:"AV14ParentIsGridMultipleData",fld:"vPARENTISGRIDMULTIPLEDATA",hsh:!0},{av:"AV13WWP_DynamicFormDataType",fld:"vWWP_DYNAMICFORMDATATYPE",pic:"Z9",hsh:!0}],[{av:"AV9WWPForm",fld:"vWWPFORM"},{av:"AV10WWPFormElement",fld:"vWWPFORMELEMENT"},{av:"AV12NeedToReloadWC",fld:"vNEEDTORELOADWC"},{av:"gx.fn.getCtrlProperty('LABEL','Caption')",ctrl:"LABEL",prop:"Caption"},{av:"gx.fn.getCtrlProperty('LABELCELL','Class')",ctrl:"LABELCELL",prop:"Class"},{av:"gx.fn.getCtrlProperty('LABEL','Class')",ctrl:"LABEL",prop:"Class"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV5IsFirstElement","vISFIRSTELEMENT",0,"boolean",4,0);this.setVCMap("AV6IsLastElement","vISLASTELEMENT",0,"boolean",4,0);this.setVCMap("AV7SessionId","vSESSIONID",0,"int",4,0);this.setVCMap("AV11WWPFormElementId","vWWPFORMELEMENTID",0,"int",4,0);this.setVCMap("AV12NeedToReloadWC","vNEEDTORELOADWC",0,"boolean",4,0);this.setVCMap("AV10WWPFormElement","vWWPFORMELEMENT",0,"WorkWithPlusDynamicFormsWWP_Form.Element",0,0);this.setVCMap("AV14ParentIsGridMultipleData","vPARENTISGRIDMULTIPLEDATA",0,"boolean",4,0);this.setVCMap("AV13WWP_DynamicFormDataType","vWWP_DYNAMICFORMDATATYPE",0,"int",2,0);this.setVCMap("AV8WWPDynamicFormMode","vWWPDYNAMICFORMMODE",0,"char",3,0);this.setVCMap("AV9WWPForm","vWWPFORM",0,"WorkWithPlusDynamicFormsWWP_Form",0,0);this.Initialize();this.setComponent({id:"WWPAUX_WC",GXClass:null,Prefix:"W0036",lvl:1})})