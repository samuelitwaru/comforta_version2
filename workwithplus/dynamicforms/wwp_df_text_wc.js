gx.evt.autoSkip=!1;gx.define("workwithplus.dynamicforms.wwp_df_text_wc",!0,function(n){this.ServerClass="workwithplus.dynamicforms.wwp_df_text_wc";this.PackageName="GeneXus.Programs";this.ServerFullClass="workwithplus.dynamicforms.wwp_df_text_wc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV36DataControlValueChanged=gx.fn.getControlValue("vDATACONTROLVALUECHANGED");this.AV13HasReferenceId=gx.fn.getControlValue("vHASREFERENCEID");this.AV21SessionId=gx.fn.getIntegerValue("vSESSIONID",",");this.AV32WWPFormInstance=gx.fn.getControlValue("vWWPFORMINSTANCE");this.AV29WWPFormElementId=gx.fn.getIntegerValue("vWWPFORMELEMENTID",",");this.AV34WWPFormInstanceElementId=gx.fn.getIntegerValue("vWWPFORMINSTANCEELEMENTID",",");this.AV26WWP_DF_CharMetadata=gx.fn.getControlValue("vWWP_DF_CHARMETADATA");this.AV35ErrorMessage=gx.fn.getControlValue("vERRORMESSAGE");this.AV28WWPFormElementDataType=gx.fn.getIntegerValue("vWWPFORMELEMENTDATATYPE",",");this.AV31WWPFormElementTitle=gx.fn.getControlValue("vWWPFORMELEMENTTITLE");this.AV33WWPFormInstanceElement=gx.fn.getControlValue("vWWPFORMINSTANCEELEMENT");this.AV39ErrorIds=gx.fn.getControlValue("vERRORIDS");this.AV6AuxSessionId=gx.fn.getIntegerValue("vAUXSESSIONID",",");this.AV12ExistElement=gx.fn.getControlValue("vEXISTELEMENT");this.AV24VisibleCondition=gx.fn.getControlValue("vVISIBLECONDITION");this.AV27WWPDynamicFormMode=gx.fn.getControlValue("vWWPDYNAMICFORMMODE")};this.s192_client=function(){return this.executeClientEvent(function(){this.AV5WWPFormElementCaption==2?(gx.fn.setCtrlProperty("DATATITLE","Caption",this.AV31WWPFormElementTitle),gx.fn.setCtrlProperty("DATATITLECELL","Visible",!0)):gx.fn.setCtrlProperty("DATATITLECELL","Visible",!1);this.AV9DataCellNameClass="DataContentCell DscTop";this.AV5WWPFormElementCaption!=1&&(this.AV9DataCellNameClass=this.AV9DataCellNameClass+" DataContentCellNoLabel");gx.fn.setCtrlProperty("vDATA","Caption",this.AV31WWPFormElementTitle);gx.json.SDTFromJson(this.AV26WWP_DF_CharMetadata,"WorkWithPlus_DynamicForms\\\\WWP_DF_CharMetadata",this.AV30WWPFormElementMetadata);this.AV26WWP_DF_CharMetadata.IsRequired&&(this.AV9DataCellNameClass="Required"+this.AV9DataCellNameClass);gx.fn.setCtrlProperty("DATACELLNAME","Class",this.AV9DataCellNameClass);gx.fn.setCtrlProperty("DATATITLECELL","Class",this.AV9DataCellNameClass)},arguments)};this.s112_client=function(){return this.executeClientEvent(function(){this.AV8Data=this.AV7CurrentWWPFormInstanceElement.WWPFormInstanceElemChar;this.AV28WWPFormElementDataType=gx.num.trunc(this.AV7CurrentWWPFormInstanceElement.WWPFormElementDataType,0)},arguments)};this.s132_client=function(){return this.executeClientEvent(function(){gx.fn.usrSetFocus("vDATA")},arguments)};this.s182_client=function(){return this.executeClientEvent(function(){this.AV33WWPFormInstanceElement.WWPFormInstanceElemChar=this.AV8Data},arguments)};this.e122e2_client=function(){return this.executeServerEvent("'DOFIXCONTROLVALUECHANGED'",!1,null,!1,!1)};this.e132e2_client=function(){return this.setEventParameters([["AuxSessionId","vAUXSESSIONID","AV6AuxSessionId"],["ErrorIds","vERRORIDS","AV39ErrorIds"]],arguments[2]),this.executeServerEvent("GLOBALEVENTS.DYNAMICFORM_VALIDATE",!0,null,!0,!0)};this.e142e2_client=function(){return this.setEventParameters([["AuxSessionId","vAUXSESSIONID","AV6AuxSessionId"]],arguments[2]),this.executeServerEvent("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",!0,null,!0,!0)};this.e152e2_client=function(){return this.executeServerEvent("VDATA.CONTROLVALUECHANGED",!0,null,!1,!0)};this.e172e2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e182e2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17];this.GXLastCtrlId=17;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"DATATITLECELL",grid:0};t[9]={id:9,fld:"DATATITLE",format:0,grid:0,ctrltype:"textblock"};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"DATACELLNAME",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"svchar",len:150,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:"e152e2_client",evt_cvcing:null,rgrid:[],fld:"vDATA",fmt:0,gxz:"ZV8Data",gxold:"OV8Data",gxvar:"AV8Data",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8Data=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8Data=n)},v2c:function(){gx.fn.setControlValue("vDATA",gx.O.AV8Data,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8Data=this.val())},val:function(){return gx.fn.getControlValue("vDATA")},nac:gx.falseFn};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"BTNFIXCONTROLVALUECHANGED",grid:0,evt:"e122e2_client"};this.AV8Data="";this.ZV8Data="";this.OV8Data="";this.AV8Data="";this.AV27WWPDynamicFormMode="";this.AV29WWPFormElementId=0;this.AV34WWPFormInstanceElementId=0;this.AV21SessionId=0;this.AV32WWPFormInstance={WWPFormInstanceId:0,WWPFormInstanceDate:gx.date.nullDate(),WWPFormId:0,WWPFormVersionNumber:0,WWPFormTitle:"",WWPUserExtendedId:"",WWPUserExtendedFullName:"",WWPFormResume:0,WWPFormValidations:"",WWPFormInstanceRecordKey:"",Element:[],Mode:"",Initialized:0,WWPFormInstanceId_Z:0,WWPFormInstanceDate_Z:gx.date.nullDate(),WWPFormId_Z:0,WWPFormVersionNumber_Z:0,WWPFormTitle_Z:"",WWPUserExtendedId_Z:"",WWPUserExtendedFullName_Z:"",WWPFormResume_Z:0,WWPFormValidations_Z:"",WWPFormInstanceRecordKey_Z:""};this.AV36DataControlValueChanged="";this.AV13HasReferenceId=!1;this.AV26WWP_DF_CharMetadata={ControlType:0,Length:0,IsRequired:!1,DefaultValue:"",VisibleCondition:{Expression:"",MentionedFields:[]},Validations:[],MultipleOptions:{ControlType:0,AllowMultipleSelection:!1,HasDynamicOptions:!1,Options:[],ComboBox:{IncludeEmptyValue:!1,EmptyText:""},RadioButton:{DirectionVertical:!1},Dynamic:{GetOptionsService:""}}};this.AV35ErrorMessage="";this.AV28WWPFormElementDataType=0;this.AV31WWPFormElementTitle="";this.AV33WWPFormInstanceElement={WWPFormElementId:0,WWPFormInstanceElementId:0,WWPFormElementTitle:"",WWPFormElementReferenceId:"",WWPFormElementDataType:0,WWPFormElementParentId:0,WWPFormElementParentType:0,WWPFormElementType:0,WWPFormElementMetadata:"",WWPFormElementCaption:0,WWPFormInstanceElemChar:"",WWPFormInstanceElemDate:gx.date.nullDate(),WWPFormInstanceElemDateTime:gx.date.nullDate(),WWPFormInstanceElemNumeric:0,WWPFormInstanceElemBlob:"",WWPFormInstanceElemBlobFileName:"",WWPFormInstanceElemBlobFileType:"",WWPFormInstanceElemBoolean:!1,Mode:"",Modified:0,Initialized:0,WWPFormElementId_Z:0,WWPFormInstanceElementId_Z:0,WWPFormElementTitle_Z:"",WWPFormElementReferenceId_Z:"",WWPFormElementDataType_Z:0,WWPFormElementParentId_Z:0,WWPFormElementParentType_Z:0,WWPFormElementType_Z:0,WWPFormElementMetadata_Z:"",WWPFormElementCaption_Z:0,WWPFormInstanceElemChar_Z:"",WWPFormInstanceElemDate_Z:gx.date.nullDate(),WWPFormInstanceElemDateTime_Z:gx.date.nullDate(),WWPFormInstanceElemNumeric_Z:0,WWPFormInstanceElemBlob_Z:"",WWPFormInstanceElemBlobFileName_Z:"",WWPFormInstanceElemBlobFileType_Z:"",WWPFormInstanceElemBoolean_Z:!1};this.AV39ErrorIds="";this.AV6AuxSessionId=0;this.AV12ExistElement=!1;this.AV24VisibleCondition={Expression:"",MentionedFields:[]};this.AV30WWPFormElementMetadata="";this.AV9DataCellNameClass="";this.AV5WWPFormElementCaption=0;this.AV7CurrentWWPFormInstanceElement={WWPFormElementId:0,WWPFormInstanceElementId:0,WWPFormElementTitle:"",WWPFormElementReferenceId:"",WWPFormElementDataType:0,WWPFormElementParentId:0,WWPFormElementParentType:0,WWPFormElementType:0,WWPFormElementMetadata:"",WWPFormElementCaption:0,WWPFormInstanceElemChar:"",WWPFormInstanceElemDate:gx.date.nullDate(),WWPFormInstanceElemDateTime:gx.date.nullDate(),WWPFormInstanceElemNumeric:0,WWPFormInstanceElemBlob:"",WWPFormInstanceElemBlobFileName:"",WWPFormInstanceElemBlobFileType:"",WWPFormInstanceElemBoolean:!1,Mode:"",Modified:0,Initialized:0,WWPFormElementId_Z:0,WWPFormInstanceElementId_Z:0,WWPFormElementTitle_Z:"",WWPFormElementReferenceId_Z:"",WWPFormElementDataType_Z:0,WWPFormElementParentId_Z:0,WWPFormElementParentType_Z:0,WWPFormElementType_Z:0,WWPFormElementMetadata_Z:"",WWPFormElementCaption_Z:0,WWPFormInstanceElemChar_Z:"",WWPFormInstanceElemDate_Z:gx.date.nullDate(),WWPFormInstanceElemDateTime_Z:gx.date.nullDate(),WWPFormInstanceElemNumeric_Z:0,WWPFormInstanceElemBlob_Z:"",WWPFormInstanceElemBlobFileName_Z:"",WWPFormInstanceElemBlobFileType_Z:"",WWPFormInstanceElemBoolean_Z:!1};this.Events={e122e2_client:["'DOFIXCONTROLVALUECHANGED'",!0],e132e2_client:["GLOBALEVENTS.DYNAMICFORM_VALIDATE",!0],e142e2_client:["GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",!0],e152e2_client:["VDATA.CONTROLVALUECHANGED",!0],e172e2_client:["ENTER",!0],e182e2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV13HasReferenceId",fld:"vHASREFERENCEID",hsh:!0},{av:"AV26WWP_DF_CharMetadata",fld:"vWWP_DF_CHARMETADATA",hsh:!0},{av:"AV35ErrorMessage",fld:"vERRORMESSAGE",hsh:!0},{av:"AV28WWPFormElementDataType",fld:"vWWPFORMELEMENTDATATYPE",pic:"Z9",hsh:!0},{av:"AV31WWPFormElementTitle",fld:"vWWPFORMELEMENTTITLE",hsh:!0}],[]];this.EvtParms["'DOFIXCONTROLVALUECHANGED'"]=[[{av:"AV36DataControlValueChanged",fld:"vDATACONTROLVALUECHANGED"},{av:"AV8Data",fld:"vDATA"},{av:"AV13HasReferenceId",fld:"vHASREFERENCEID",hsh:!0},{av:"AV21SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"AV32WWPFormInstance",fld:"vWWPFORMINSTANCE"},{av:"AV29WWPFormElementId",fld:"vWWPFORMELEMENTID",pic:"ZZZ9"},{av:"AV34WWPFormInstanceElementId",fld:"vWWPFORMINSTANCEELEMENTID",pic:"ZZZ9"},{av:"AV26WWP_DF_CharMetadata",fld:"vWWP_DF_CHARMETADATA",hsh:!0},{av:"AV35ErrorMessage",fld:"vERRORMESSAGE",hsh:!0},{av:"AV28WWPFormElementDataType",fld:"vWWPFORMELEMENTDATATYPE",pic:"Z9",hsh:!0},{av:"AV31WWPFormElementTitle",fld:"vWWPFORMELEMENTTITLE",hsh:!0},{av:"AV33WWPFormInstanceElement",fld:"vWWPFORMINSTANCEELEMENT"}],[{av:"AV36DataControlValueChanged",fld:"vDATACONTROLVALUECHANGED"},{av:"AV12ExistElement",fld:"vEXISTELEMENT"},{av:"AV33WWPFormInstanceElement",fld:"vWWPFORMINSTANCEELEMENT"},{av:"AV32WWPFormInstance",fld:"vWWPFORMINSTANCE"}]];this.EvtParms["GLOBALEVENTS.DYNAMICFORM_VALIDATE"]=[[{av:"AV39ErrorIds",fld:"vERRORIDS"},{av:"AV6AuxSessionId",fld:"vAUXSESSIONID",pic:"ZZZ9"},{av:"AV21SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"gx.fn.getCtrlProperty('LAYOUTMAINTABLE','Class')",ctrl:"LAYOUTMAINTABLE",prop:"Class"},{av:"AV29WWPFormElementId",fld:"vWWPFORMELEMENTID",pic:"ZZZ9"},{av:"AV34WWPFormInstanceElementId",fld:"vWWPFORMINSTANCEELEMENTID",pic:"ZZZ9"},{av:"AV12ExistElement",fld:"vEXISTELEMENT"},{av:"AV32WWPFormInstance",fld:"vWWPFORMINSTANCE"},{av:"AV26WWP_DF_CharMetadata",fld:"vWWP_DF_CHARMETADATA",hsh:!0},{av:"AV8Data",fld:"vDATA"},{av:"AV35ErrorMessage",fld:"vERRORMESSAGE",hsh:!0},{av:"AV28WWPFormElementDataType",fld:"vWWPFORMELEMENTDATATYPE",pic:"Z9",hsh:!0},{av:"AV31WWPFormElementTitle",fld:"vWWPFORMELEMENTTITLE",hsh:!0},{av:"AV33WWPFormInstanceElement",fld:"vWWPFORMINSTANCEELEMENT"}],[{av:"AV12ExistElement",fld:"vEXISTELEMENT"},{av:"AV33WWPFormInstanceElement",fld:"vWWPFORMINSTANCEELEMENT"},{av:"AV32WWPFormInstance",fld:"vWWPFORMINSTANCE"}]];this.addExoEventHandler("DynamicForm_Validate",this.e132e2_client);this.EvtParms["GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES"]=[[{av:"AV6AuxSessionId",fld:"vAUXSESSIONID",pic:"ZZZ9"},{av:"AV21SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"AV24VisibleCondition",fld:"vVISIBLECONDITION"},{av:"AV26WWP_DF_CharMetadata",fld:"vWWP_DF_CHARMETADATA",hsh:!0},{av:"AV34WWPFormInstanceElementId",fld:"vWWPFORMINSTANCEELEMENTID",pic:"ZZZ9"},{av:"AV32WWPFormInstance",fld:"vWWPFORMINSTANCE"}],[{av:"AV32WWPFormInstance",fld:"vWWPFORMINSTANCE"},{av:"AV24VisibleCondition",fld:"vVISIBLECONDITION"},{av:"gx.fn.getCtrlProperty('LAYOUTMAINTABLE','Class')",ctrl:"LAYOUTMAINTABLE",prop:"Class"}]];this.addExoEventHandler("DynamicForm_UpdateVisibilities",this.e142e2_client);this.EvtParms["VDATA.CONTROLVALUECHANGED"]=[[{av:"AV8Data",fld:"vDATA"},{av:"AV13HasReferenceId",fld:"vHASREFERENCEID",hsh:!0},{av:"AV21SessionId",fld:"vSESSIONID",pic:"ZZZ9"},{av:"AV32WWPFormInstance",fld:"vWWPFORMINSTANCE"},{av:"AV29WWPFormElementId",fld:"vWWPFORMELEMENTID",pic:"ZZZ9"},{av:"AV34WWPFormInstanceElementId",fld:"vWWPFORMINSTANCEELEMENTID",pic:"ZZZ9"},{av:"AV26WWP_DF_CharMetadata",fld:"vWWP_DF_CHARMETADATA",hsh:!0},{av:"AV35ErrorMessage",fld:"vERRORMESSAGE",hsh:!0},{av:"AV28WWPFormElementDataType",fld:"vWWPFORMELEMENTDATATYPE",pic:"Z9",hsh:!0},{av:"AV31WWPFormElementTitle",fld:"vWWPFORMELEMENTTITLE",hsh:!0},{av:"AV33WWPFormInstanceElement",fld:"vWWPFORMINSTANCEELEMENT"}],[{av:"AV36DataControlValueChanged",fld:"vDATACONTROLVALUECHANGED"},{av:"AV12ExistElement",fld:"vEXISTELEMENT"},{av:"AV33WWPFormInstanceElement",fld:"vWWPFORMINSTANCEELEMENT"},{av:"AV32WWPFormInstance",fld:"vWWPFORMINSTANCE"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV36DataControlValueChanged","vDATACONTROLVALUECHANGED",0,"svchar",150,0);this.setVCMap("AV13HasReferenceId","vHASREFERENCEID",0,"boolean",4,0);this.setVCMap("AV21SessionId","vSESSIONID",0,"int",4,0);this.setVCMap("AV32WWPFormInstance","vWWPFORMINSTANCE",0,"WorkWithPlusDynamicFormsWWP_FormInstance",0,0);this.setVCMap("AV29WWPFormElementId","vWWPFORMELEMENTID",0,"int",4,0);this.setVCMap("AV34WWPFormInstanceElementId","vWWPFORMINSTANCEELEMENTID",0,"int",4,0);this.setVCMap("AV26WWP_DF_CharMetadata","vWWP_DF_CHARMETADATA",0,"WorkWithPlus_DynamicFormsWWP_DF_CharMetadata",0,0);this.setVCMap("AV35ErrorMessage","vERRORMESSAGE",0,"svchar",40,0);this.setVCMap("AV28WWPFormElementDataType","vWWPFORMELEMENTDATATYPE",0,"int",2,0);this.setVCMap("AV31WWPFormElementTitle","vWWPFORMELEMENTTITLE",0,"vchar",2097152,0);this.setVCMap("AV33WWPFormInstanceElement","vWWPFORMINSTANCEELEMENT",0,"WorkWithPlusDynamicFormsWWP_FormInstance.Element",0,0);this.setVCMap("AV39ErrorIds","vERRORIDS",0,"svchar",40,0);this.setVCMap("AV6AuxSessionId","vAUXSESSIONID",0,"int",4,0);this.setVCMap("AV12ExistElement","vEXISTELEMENT",0,"boolean",4,0);this.setVCMap("AV24VisibleCondition","vVISIBLECONDITION",0,"WorkWithPlus_DynamicFormsWWP_DF_ConditionExpression",0,0);this.setVCMap("AV27WWPDynamicFormMode","vWWPDYNAMICFORMMODE",0,"char",3,0);this.Initialize()})