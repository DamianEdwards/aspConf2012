using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Async
{
    public class Customers : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            context.Response.Write(JsonConvert.SerializeObject(new [] {
               new Customer { Id = 1, FirstName = "Damian", LastName = "Edwards" },
               new Customer { Id = 2, FirstName = "Levi", LastName = "Broderick" },
               new Customer { Id = 3, FirstName = "Brad", LastName = "Wilson" },
               new Customer { Id = 4, FirstName = "David", LastName = "Fowler" },
               new Customer { Id = 5, FirstName = "Scott", LastName = "Hunter" },
               new Customer { Id = 6, FirstName = "Scott", LastName = "Hanselman" }
            }));
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}