using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using SignalRTeste.Models;

namespace SignalRTeste
{
    public class MyHub1 : Hub
    {
        public void Conectar()
        {                       
            // Call the addNewMessageToPage method to update clients.
            HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];

            if (cookie != null)
            {
                Conexao obj = JsonConvert.DeserializeObject<Conexao>(cookie.Value);


                Clients.User(obj.ConnectionId).hello(obj.ConnectionId.ToString());
            }

        }

        public void EnviarMensagem(string mensagem, string conexao)
        {
            var data = new { 
                Conexao = conexao,
                Mensagem = mensagem,
                Hora = DateTime.Now
            };

            Clients.All.receber(data);
        }
    }
}