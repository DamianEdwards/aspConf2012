using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancedWebForms.Model;

namespace AdvancedWebForms
{
    public partial class CustomTemplates : System.Web.UI.Page
    {
        private const string ItemTemplate =
            "<h3>Category</h3>" +
            "<p>ID: <asp:Label runat=\"server\" ID=\"idLabel\" Text='<%# BindItem.CategoryId %>' /><br />" +
            "   Name: <asp:Label runat=\"server\" ID=\"nameLabel\" Text='<%# BindItem.Name %>' /></p>";

        protected void Page_Init()
        {
            dataListView.ItemTemplate = TemplateParser.ParseTemplate(ItemTemplate, "~/ItemTemplate", true);
        }

        public IEnumerable<Category> dataRepeater_GetData()
        {
            return new[] {
                new Category { CategoryId = 1, Name = "Tables" },
                new Category { CategoryId = 2, Name = "Chairs" }
            };
        }
    }
}