var __spreadArray=this&&this.__spreadArray||function(e,n,a){if(a||arguments.length===2)for(var s=0,i=n.length,t;s<i;s++){if(t||!(s in n)){if(!t)t=Array.prototype.slice.call(n,0,s);t[s]=n[s]}}return e.concat(t||Array.prototype.slice.call(n))};System.register([],(function(e){"use strict";return{execute:function(){e("default",n);function n(e){var n="true false yes no null",a="[\\w#;/?:@&=+$,.~*'()[\\]]+",s={className:"attr",variants:[{begin:"\\w[\\w :\\/.-]*:(?=[ \t]|$)"},{begin:'"\\w[\\w :\\/.-]*":(?=[ \t]|$)'},{begin:"'\\w[\\w :\\/.-]*':(?=[ \t]|$)"}]},i={className:"template-variable",variants:[{begin:/\{\{/,end:/\}\}/},{begin:/%\{/,end:/\}/}]},t={className:"string",relevance:0,variants:[{begin:/'/,end:/'/},{begin:/"/,end:/"/},{begin:/\S+/}],contains:[e.BACKSLASH_ESCAPE,i]},r=e.inherit(t,{variants:[{begin:/'/,end:/'/},{begin:/"/,end:/"/},{begin:/[^\s,{}[\]]+/}]}),l={className:"number",begin:"\\b[0-9]{4}(-[0-9][0-9]){0,2}([Tt \\t][0-9][0-9]?(:[0-9][0-9]){2})?(\\.[0-9]*)?([ \\t])*(Z|[-+][0-9][0-9]?(:[0-9][0-9])?)?\\b"},c={end:",",endsWithParent:!0,excludeEnd:!0,keywords:n,relevance:0},b={begin:/\{/,end:/\}/,contains:[c],illegal:"\\n",relevance:0},g={begin:"\\[",end:"\\]",contains:[c],illegal:"\\n",relevance:0},m=[s,{className:"meta",begin:"^---\\s*$",relevance:10},{className:"string",begin:"[\\|>]([1-9]?[+-])?[ ]*\\n( +)[^ ][^\\n]*\\n(\\2[^\\n]+\\n?)*"},{begin:"<%[%=-]?",end:"[%-]?%>",subLanguage:"ruby",excludeBegin:!0,excludeEnd:!0,relevance:0},{className:"type",begin:"!\\w+!"+a},{className:"type",begin:"!<"+a+">"},{className:"type",begin:"!"+a},{className:"type",begin:"!!"+a},{className:"meta",begin:"&"+e.UNDERSCORE_IDENT_RE+"$"},{className:"meta",begin:"\\*"+e.UNDERSCORE_IDENT_RE+"$"},{className:"bullet",begin:"-(?=[ ]|$)",relevance:0},e.HASH_COMMENT_MODE,{beginKeywords:n,keywords:{literal:n}},l,{className:"number",begin:e.C_NUMBER_RE+"\\b",relevance:0},b,g,t],d=__spreadArray([],m,true);return d.pop(),d.push(r),c.contains=d,{name:"YAML",case_insensitive:!0,aliases:["yml"],contains:m}}}}}));
//# sourceMappingURL=p-1e99233e.system.js.map