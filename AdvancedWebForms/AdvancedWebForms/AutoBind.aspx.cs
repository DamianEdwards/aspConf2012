using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvancedWebForms
{
    public partial class AutoBind : System.Web.UI.Page
    {
        protected bool SomeCondition
        {
            get
            {
                return (bool)(ViewState["SomeCondition"] ?? false);
            }
            private set
            {
                ViewState["SomeCondition"] = value;
            }
        }

        protected void toggleContent_Click(object sender, EventArgs e)
        {
            SomeCondition = !SomeCondition;
        }
    }
}