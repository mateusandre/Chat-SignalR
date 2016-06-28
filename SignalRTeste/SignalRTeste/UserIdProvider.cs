using Microsoft.AspNet.SignalR;
using SignalRTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using Newtonsoft.Json;

namespace SignalRTeste
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            var id = Guid.NewGuid();

            HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];

            if (cookie != null)
            {
                Conexao obj = JsonConvert.DeserializeObject<Conexao>(cookie.Value);

                return obj.ConnectionId.ToString();
            }
            else
            {
                HttpCookie cookieN = new HttpCookie("user", JsonConvert.SerializeObject(new Conexao() { usuarioId = 1, ConnectionId = id.ToString() }));
                cookieN.Expires.AddDays(365);
                HttpContext.Current.Response.SetCookie(cookieN);

                return id.ToString();
            }

        }
    }
}