var __awaiter=this&&this.__awaiter||function(t,e,i,n){function r(t){return t instanceof i?t:new i((function(e){e(t)}))}return new(i||(i=Promise))((function(i,o){function s(t){try{a(n.next(t))}catch(t){o(t)}}function c(t){try{a(n["throw"](t))}catch(t){o(t)}}function a(t){t.done?i(t.value):r(t.value).then(s,c)}a((n=n.apply(t,e||[])).next())}))};var __generator=this&&this.__generator||function(t,e){var i={label:0,sent:function(){if(o[0]&1)throw o[1];return o[1]},trys:[],ops:[]},n,r,o,s;return s={next:c(0),throw:c(1),return:c(2)},typeof Symbol==="function"&&(s[Symbol.iterator]=function(){return this}),s;function c(t){return function(e){return a([t,e])}}function a(c){if(n)throw new TypeError("Generator is already executing.");while(s&&(s=0,c[0]&&(i=0)),i)try{if(n=1,r&&(o=c[0]&2?r["return"]:c[0]?r["throw"]||((o=r["return"])&&o.call(r),0):r.next)&&!(o=o.call(r,c[1])).done)return o;if(r=0,o)c=[c[0]&2,o.value];switch(c[0]){case 0:case 1:o=c;break;case 4:i.label++;return{value:c[1],done:false};case 5:i.label++;r=c[1];c=[0];continue;case 7:c=i.ops.pop();i.trys.pop();continue;default:if(!(o=i.trys,o=o.length>0&&o[o.length-1])&&(c[0]===6||c[0]===2)){i=0;continue}if(c[0]===3&&(!o||c[1]>o[0]&&c[1]<o[3])){i.label=c[1];break}if(c[0]===6&&i.label<o[1]){i.label=o[1];o=c;break}if(o&&i.label<o[2]){i.label=o[2];i.ops.push(c);break}if(o[2])i.ops.pop();i.trys.pop();continue}c=e.call(t,i)}catch(t){c=[6,t];r=0}finally{n=o=0}if(c[0]&5)throw c[1];return{value:c[0]?c[1]:void 0,done:true}}};System.register(["./p-62fc4e49.system.js"],(function(t){"use strict";var e,i,n;return{setters:[function(t){e=t.h;i=t.r;n=t.H}],execute:function(){var r=function(t){var e={suggestItems:null,suggestLists:[]};if(t.length){t.forEach((function(t){var i={label:t.name,items:[]};t.items.forEach((function(t){var e={value:t.id,description:t.description,icon:t.icon};i.items.push(e)}));e.suggestLists.push(i)}))}return e};var o=function(t){if(t===null||t===void 0?void 0:t.suggestLists.length){var i=Math.random();var n=t.suggestLists.map((function(t){return e("ch-suggest-list",{label:t.label,key:i},t.items.map((function(t){return s(t)})))}));return n}return null};var s=function(t){return e("ch-suggest-list-item",{value:t.value},[t.description||t.value])};var c=':host{display:block}:root{--highlight-color:rgb(163, 25, 161)}ch-suggest{display:block}ch-suggest::part(title){display:block;font-weight:bold}ch-suggest::part(label){font-weight:500}ch-suggest[label-position="start"]::part(label){-webkit-margin-end:8px;margin-inline-end:8px;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}ch-suggest[label-position="above"]::part(label){-webkit-margin-after:4px;margin-block-end:4px}ch-suggest::part(close-button){display:block;width:16px;height:16px}ch-suggest::part(close-button)::after{content:"✖";line-height:8px;height:100%;display:block;border:1px solid black;cursor:pointer;text-align:center;line-height:16px}ch-suggest::part(header){display:-ms-flexbox;display:flex;-ms-flex-pack:justify;justify-content:space-between;-ms-flex-align:center;align-items:center;-webkit-margin-after:8px;margin-block-end:8px}ch-suggest::part(ch-window-close){width:10px;height:10px}ch-suggest::part(input){padding:4px 8px;border:1px solid black}ch-suggest::part(input):focus{outline:2px solid var(--highlight-color);border-color:var(--highlight-color)}ch-suggest-list{background-color:rgba(234, 234, 234, 0.224);border:1px solid rgba(128, 128, 128, 0.275);border-radius:4px;padding:8px;-webkit-margin-after:4px;margin-block-end:4px}ch-suggest-list::part(title){font-size:14px;font-weight:bold;text-transform:uppercase;margin:4px 0 8px 0}ch-suggest-list-item::part(button){padding:4px 8px;cursor:pointer;gap:4px}ch-suggest-list-item ch-icon{--icon-size:16px;-webkit-margin-end:2px;margin-inline-end:2px}ch-suggest-list-item:hover{background-color:var(--ch-color--violet-100)}ch-suggest-list-item:focus,ch-suggest-list-item[selected]:focus{outline:2px solid var(--highlight-color)}ch-suggest-list-item[selected]{background-color:rgba(241, 184, 243, 0.42);outline:none}ch-suggest-list-item::part(button):focus{outline:2px solid var(--highlight-color);border-color:var(--highlight-color)}ch-suggest-list-item::part(content-wrapper){display:-ms-flexbox;display:flex;gap:8px}ch-suggest::part(dropdown){-webkit-margin-before:4px;margin-block-start:4px;border:1px solid black;background-color:white;padding:8px}:focus{outline-style:none !important}';var a=c;var l=t("ch_test_suggest",function(){function t(t){var e=this;this.selectObjectValueChangedHandler=function(t){return __awaiter(e,void 0,void 0,(function(){var e;var i=this;return __generator(this,(function(n){e=t.detail;this.selectorSourceCallback(e).then((function(t){i.objectsSuggestions=r(t)})).catch((function(){}));return[2]}))}))};i(this,t);this.objectsSuggestions=undefined;this.selectorSourceCallback=undefined}t.prototype.render=function(){return e(n,{key:"5c902fec5f0eb4f62e1b4b19fe3ecf7ee3e2b252"},e("ch-suggest",{key:"d32a36ba6f42483b22d395d206cdc7b1f75a19ba",onValueChanged:this.selectObjectValueChangedHandler,part:"object-selector-suggest",exportparts:"dropdown:select-object-dropdown"},o(this.objectsSuggestions)))};return t}());l.style=a}}}));
//# sourceMappingURL=p-fd4c20ad.system.entry.js.map