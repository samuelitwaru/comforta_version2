gx.evt.autoSkip=!1;gx.define("workwithplus.dynamicforms.wwp_df_checkbox_wc",!0,function(n){this.ServerClass="workwithplus.dynamicforms.wwp_df_checkbox_wc";this.PackageName="GeneXus.Programs";this.ServerFullClass="workwithplus.dynamicforms.wwp_df_checkbox_wc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV34ErrorIds=gx.fn.getControlValue("vERRORIDS");this.AV8AuxSessionId=gx.fn.getIntegerValue("vAUXSESSIONID",",");this.AV21SessionId=gx.fn.getIntegerValue("vSESSIONID",",");this.AV28WWPFormElementId=gx.fn.getIntegerValue("vWWPFORMELEMENTID",",");this.AV7WWPFormInstanceElementId=gx.fn.getIntegerValue("vWWPFORMINSTANCEELEMENTID",",");this.AV14ExistElement=gx.fn.getControlValue("vEXISTELEMENT");this.AV6WWPFormInstance=gx.fn.getControlValue("vWWPFORMINSTANCE");this.AV26WWP_DF_BooleanMetadata=gx.fn.getControlValue("vWWP_DF_BOOLEANMETADATA");this.AV17IsRequired=gx.fn.getControlValue("vISREQUIRED");this.AV30WWPFormElementTitle=gx.fn.getControlValue("vWWPFORMELEMENTTITLE");this.AV31WWPFormInstanceElement=gx.fn.getControlValue("vWWPFORMINSTANCEELEMENT");this.AV24VisibleCondition=gx.fn.getControlValue("vVISIBLECONDITION");this.AV15HasReferenceId=gx.fn.getControlValue("vHASREFERENCEID");this.AV27WWPDynamicFormMode=gx.fn.getControlValue("vWWPDYNAMICFORMMODE")};this.s112_client=function(){return this.executeClientEvent(function(){this.AV10Data=this.AV9CurrentWWPFormInstanceElement.WWPFormInstanceElemBoolean},arguments)};this.s132_client=function(){return this.executeClientEvent(function(){gx.fn.usrSetFocus("vDATA")},arguments)};this.s172_client=function(){return this.executeClientEvent(function(){this.AV31WWPFormInstanceElement.WWPFormInstanceElemBoolean=this.AV10Data},arguments)};this.e122l2_client=function(){return this.setEventParameters([["AuxSessionId","vAUXSESSIONID","AV8AuxSessionId"],["ErrorIds","vERRORIDS","AV34ErrorIds"]],arguments[2]),this.executeServerEvent("GLOBALEVENTS.DYNAMICFORM_VALIDATE",!0,null,!0,!0)};this.e132l2_client=function(){return this.setEventParameters([["AuxSessionId","vAUXSESSIONID","AV8AuxSessionId"]],arguments[2]),this.executeServerEvent("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",!0,null,!0,!0)};this.e142l2_client=function(){return this.executeServerEvent("VDATA.CLICK",!0,null,!1,!0)};this.e162l2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e172l2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14];this.GXLastCtrlId=14;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"DATATITLECELL",grid:0};t[9]={id:9,fld:"DATATITLE",format:0,grid:0,ctrltype:"textblock"};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"DATACELLNAME",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDATA",fmt:0,gxz:"ZV10Data",gxold:"OV10Data",gxvar:"AV10Data",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV10Data=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10Data=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vDATA",gx.O.AV10Data,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10Data=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vDATA")},nac:gx.falseFn,evt:"e142l2_client",values:["true","false"]};this.AV10Data=!1;this.AV27WWPDynamicFormMode="";this.AV28WWPFormElementId=0;this.AV7WWPFormInstanceElementId=0;this.AV21SessionId=0;this.AV6WWPFormInstance={WWPFormInstanceId:0,WWPFormInstanceDate:gx.date.nullDate(),WWPFormId:0,WWPFormVersionNumber:0,WWPFormTitle:"",WWPUserExtendedId:"",WWPUserExtendedFullName:"",WWPFormResume:0,WWPFormValidations:"",WWPFormInstanceRecordKey:"",Element:[],Mode:"",Initialized:0,WWPFormInstanceId_Z:0,WWPFormInstanceDate_Z:gx.date.nullDate(),WWPFormId_Z:0,WWPFormVersionNumber_Z:0,WWPFormTitle_Z:"",WWPUserExtendedId_Z:"",WWPUserExtendedFullName_Z:"",WWPFormResume_Z:0,WWPFormValidations_Z:"",WWPFormInstanceRecordKey_Z:""};this.AV34ErrorIds="";this.AV8AuxSessionId=0;this.AV14ExistElement=!1;this.AV26WWP_DF_BooleanMetadata={ControlType:0,DefaultValue:!1,VisibleCondition:{Expression:"",MentionedFields:[]},Validations:[],Checkbox:{ControlTitle:""}};this.AV17IsRequired=!1;this.AV30WWPFormElementTitle="";this.AV31WWPFormInstanceElement={WWPFormElementId:0,WWPFormInstanceElementId:0,WWPFormElementTitle:"",WWPFormElementReferenceId:"",WWPFormElementDataType:0,WWPFormElementParentId:0,WWPFormElementParentType:0,WWPFormElementType:0,WWPFormElementMetadata:"",WWPFormElementCaption:0,WWPFormInstanceElemChar:"",WWPFormInstanceElemDate:gx.date.nullDate(),WWPFormInstanceElemDateTime:gx.date.nullDate(),WWPFormInstanceElemNumeric:0,WWPFormInstanceElemBlob:"",WWPFormInstanceElemBlobFileName:"",WWPFormInstanceElemBlobFileType:"",WWPFormInstanceElemBoolean:!1,Mode:"",Modified:0,Initialized:0,WWPFormElementId_Z:0,WWPFormInstanceElementId_Z:0,WWPFormElementTitle_Z:"",WWPFormElementReferenceId_Z:"",WWPFormElementDataType_Z:0,WWPFormElementParentId_Z:0,WWPFormElementParentType_Z:0,WWPFormElementType_Z:0,WWPFormElementMetadata_Z:"",WWPFormElementCaption_Z:0,WWPFormInstanceElemChar_Z:"",WWPFormInstanceElemDate_Z:gx.date.nullDate(),WWPFormInstanceElemDateTime_Z:gx.date.nullDate(),WWPFormInstanceElemNumeric_Z:0,WWPFormInstanceElemBlob_Z:"",WWPFormInstanceElemBlobFileName_Z:"",WWPFormInstanceElemBlobFileType_Z:"",WWPFormInstanceElemBoolean_Z:!1};this.AV24VisibleCondition={Expression:"",MentionedFields:[]};this.AV15HasReferenceId=!1;this.AV9CurrentWWPFormInstanceElement={WWPFormElementId:0,WWPFormInstanceElementId:0,WWPFormElementTitle:"",WWPFormElementReferenceId:"",WWPFormElementDataType:0,WWPFormElementParentId:0,WWPFormElementParentType:0,WWPFormElementType:0,WWPFormElementMetadata:"",WWPFormElementCaption:0,WWPFormInstanceElemChar:"",WWPFormInstanceElemDate:gx.date.nullDate(),WWPFormInstanceElemDateTime:gx.date.nullDate(),WWPFormInstanceElemNumeric:0,WWPFormInstanceElemBlob:"",WWPFormInstanceElemBlobFileName:"",WWPFormInstanceElemBlobFileType:"",WWPFormInstanceElemBoolean:!1,Mode:"",Modified:0,Initialized:0,WWPFormElementId_Z:0,WWPFormInstanceElementId_Z:0,WWPFormElementTitle_Z:"",WWPFormElementReferenceId_Z:"",WWPFormElementDataType_Z:0,WWPFormElementParentId_Z:0,WWPFormElementParentType_Z:0,WWPFormElementType_Z:0,WWPFormElementMetadata_Z:"",WWPFormElementCaption_Z:0,WWPFormInstanceElemChar_Z:"",WWPFormInstanceElemDate_Z:gx.date.nullDate(),WWPFormInstanceElemDateTime_Z:gx.date.nullDate(),WWPFormInstanceElemNumeric_Z:0,WWPFormInstanceElemBlob_Z:"",WWPFormInstanceElemBlobFileName_Z:"",WWPFormInstanceElemBlobFileType_Z:"",WWPFormInstanceElemBoolean_Z:!1};this.Events={e122l2_client:["GLOBALEVENTS.DYNAMICFORM_VALIDATE",!0],e132l2_client:["GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",!0],e142l2_client:["VDATA.CLICK",!0],e162l2_client:["ENTER",!0],e172l2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV10Data",fld:"vDATA"},{av:"AV26WWP_DF_BooleanMetadata",fld:"vWWP_DF_BOOLEANMETADATA",hsh:!0},{av:"AV17IsRequired",fld:"vISREQUIRED",hsh:!0},{av:"AV30WWPFormElementTitle",fld:"vWWPFORMELEMENTTITLE",hsh:!0},{av:"AV15HasReferenceId",fld:"vHASREFERENCEID",hsh:!0}],[]];this.EvtParms["GLOBALEVENTS.DYNAMICFORM_VALIDATE"]=[[{av:"AV34ErrorIds",fld:"vERRORIDS"},{av:"AV8AuxSessionId",fld:"vAUXSESSIONID",pic:"ZZZ9"},{av:"AV21SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"gx.fn.getCtrlProperty('LAYOUTMAINTABLE','Class')",ctrl:"LAYOUTMAINTABLE",prop:"Class"},{av:"AV28WWPFormElementId",fld:"vWWPFORMELEMENTID",pic:"ZZZ9"},{av:"AV7WWPFormInstanceElementId",fld:"vWWPFORMINSTANCEELEMENTID",pic:"ZZZ9"},{av:"AV14ExistElement",fld:"vEXISTELEMENT"},{av:"AV6WWPFormInstance",fld:"vWWPFORMINSTANCE"},{av:"AV26WWP_DF_BooleanMetadata",fld:"vWWP_DF_BOOLEANMETADATA",hsh:!0},{av:"AV10Data",fld:"vDATA"},{av:"AV17IsRequired",fld:"vISREQUIRED",hsh:!0},{av:"AV30WWPFormElementTitle",fld:"vWWPFORMELEMENTTITLE",hsh:!0},{av:"AV31WWPFormInstanceElement",fld:"vWWPFORMINSTANCEELEMENT"}],[{av:"AV14ExistElement",fld:"vEXISTELEMENT"},{av:"AV31WWPFormInstanceElement",fld:"vWWPFORMINSTANCEELEMENT"},{av:"AV6WWPFormInstance",fld:"vWWPFORMINSTANCE"}]];this.addExoEventHandler("DynamicForm_Validate",this.e122l2_client);this.EvtParms["GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES"]=[[{av:"AV8AuxSessionId",fld:"vAUXSESSIONID",pic:"ZZZ9"},{av:"AV21SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"AV24VisibleCondition",fld:"vVISIBLECONDITION"},{av:"AV26WWP_DF_BooleanMetadata",fld:"vWWP_DF_BOOLEANMETADATA",hsh:!0},{av:"AV7WWPFormInstanceElementId",fld:"vWWPFORMINSTANCEELEMENTID",pic:"ZZZ9"},{av:"AV6WWPFormInstance",fld:"vWWPFORMINSTANCE"}],[{av:"AV6WWPFormInstance",fld:"vWWPFORMINSTANCE"},{av:"AV24VisibleCondition",fld:"vVISIBLECONDITION"},{av:"gx.fn.getCtrlProperty('LAYOUTMAINTABLE','Class')",ctrl:"LAYOUTMAINTABLE",prop:"Class"}]];this.addExoEventHandler("DynamicForm_UpdateVisibilities",this.e132l2_client);this.EvtParms["VDATA.CLICK"]=[[{av:"AV15HasReferenceId",fld:"vHASREFERENCEID",hsh:!0},{av:"AV21SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"AV6WWPFormInstance",fld:"vWWPFORMINSTANCE"},{av:"AV28WWPFormElementId",fld:"vWWPFORMELEMENTID",pic:"ZZZ9"},{av:"AV7WWPFormInstanceElementId",fld:"vWWPFORMINSTANCEELEMENTID",pic:"ZZZ9"},{av:"AV26WWP_DF_BooleanMetadata",fld:"vWWP_DF_BOOLEANMETADATA",hsh:!0},{av:"AV10Data",fld:"vDATA"},{av:"AV17IsRequired",fld:"vISREQUIRED",hsh:!0},{av:"AV30WWPFormElementTitle",fld:"vWWPFORMELEMENTTITLE",hsh:!0},{av:"AV31WWPFormInstanceElement",fld:"vWWPFORMINSTANCEELEMENT"}],[{av:"AV14ExistElement",fld:"vEXISTELEMENT"},{av:"AV31WWPFormInstanceElement",fld:"vWWPFORMINSTANCEELEMENT"},{av:"AV6WWPFormInstance",fld:"vWWPFORMINSTANCE"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV34ErrorIds","vERRORIDS",0,"svchar",40,0);this.setVCMap("AV8AuxSessionId","vAUXSESSIONID",0,"int",4,0);this.setVCMap("AV21SessionId","vSESSIONID",0,"int",4,0);this.setVCMap("AV28WWPFormElementId","vWWPFORMELEMENTID",0,"int",4,0);this.setVCMap("AV7WWPFormInstanceElementId","vWWPFORMINSTANCEELEMENTID",0,"int",4,0);this.setVCMap("AV14ExistElement","vEXISTELEMENT",0,"boolean",4,0);this.setVCMap("AV6WWPFormInstance","vWWPFORMINSTANCE",0,"WorkWithPlusDynamicFormsWWP_FormInstance",0,0);this.setVCMap("AV26WWP_DF_BooleanMetadata","vWWP_DF_BOOLEANMETADATA",0,"WorkWithPlus_DynamicFormsWWP_DF_BooleanMetadata",0,0);this.setVCMap("AV17IsRequired","vISREQUIRED",0,"boolean",4,0);this.setVCMap("AV30WWPFormElementTitle","vWWPFORMELEMENTTITLE",0,"vchar",2097152,0);this.setVCMap("AV31WWPFormInstanceElement","vWWPFORMINSTANCEELEMENT",0,"WorkWithPlusDynamicFormsWWP_FormInstance.Element",0,0);this.setVCMap("AV24VisibleCondition","vVISIBLECONDITION",0,"WorkWithPlus_DynamicFormsWWP_DF_ConditionExpression",0,0);this.setVCMap("AV15HasReferenceId","vHASREFERENCEID",0,"boolean",4,0);this.setVCMap("AV27WWPDynamicFormMode","vWWPDYNAMICFORMMODE",0,"char",3,0);this.Initialize()})