using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AdvancedWebForms
{
    public static class ScriptConfig
    {
        public static void RegisterScripts(ScriptResourceMapping mapping)
        {
            // Map jquery definition to the Google CDN
            mapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-1.7.2.min.js",
                DebugPath = "~/Scripts/jquery-1.7.2.js",
                CdnPath = "http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js",
                CdnDebugPath = "https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });

            // Map jquery ui definition to the Google CDN
            mapping.AddDefinition("jquery.ui.combined", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-ui-1.8.20.min.js",
                DebugPath = "~/Scripts/jquery-ui-1.8.20.js",
                CdnPath = "http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.20/jquery-ui.min.js",
                CdnDebugPath = "http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.20/jquery-ui.js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery && window.jQuery.ui && window.jQuery.ui.version === '1.8.20'"
            });
        }
    }
}