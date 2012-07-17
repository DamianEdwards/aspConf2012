using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Async
{
    public partial class AsyncDataBind : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var customersJson = await client.GetStringAsync("http://localhost:64247/Customers.ashx");
                var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(customersJson);
                results.DataSource = customers;
                results.DataBind();
            }
        }
    }
}