using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRTeste.Models
{
    public class SessionConfig
    {
        public static string SetId()
        {
            var id = Guid.NewGuid();
            //HttpContext.Current.Session["Id"] = id;
            return id.ToString();
        }
    }
}