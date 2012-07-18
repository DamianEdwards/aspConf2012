using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvancedWebForms
{
    public class AutoBindControlBuilderInterceptor : ControlBuilderInterceptor
    {
        public override void PreControlBuilderInit(ControlBuilder controlBuilder, TemplateParser parser, ControlBuilder parentBuilder, Type type, string tagName, string id, IDictionary attributes, IDictionary additionalState)
        {
            if (type != typeof(Panel))
            {
                return;
            }

            var autoBind = attributes["AutoBind"];
            if (autoBind == null)
            {
                return;
            }

            attributes.Remove("AutoBind");

            bool autoBindValue;
            Boolean.TryParse(autoBind.ToString(), out autoBindValue);
            additionalState.Add("AutoBind", autoBindValue);
        }

        public override void OnProcessGeneratedCode(ControlBuilder controlBuilder, CodeCompileUnit codeCompileUnit, CodeTypeDeclaration baseType, CodeTypeDeclaration derivedType, CodeMemberMethod buildMethod, CodeMemberMethod dataBindingMethod, IDictionary additionalState)
        {
            if (buildMethod == null)
            {
                return;
            }

            var autoBind = additionalState["AutoBind"];
            if (autoBind != null && autoBind is bool && (bool)autoBind)
            {
                buildMethod.Statements.Insert(buildMethod.Statements.Count - 1, new CodeSnippetStatement("            PreRenderComplete += (s, e) => @__ctrl.DataBind();"));
            }
        }
    }
}