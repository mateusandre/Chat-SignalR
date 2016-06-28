using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
//[assembly: OwinStartup(typeof(SignalRTeste.Startup))]
namespace SignalRTeste
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var idProvider = new UserIdProvider();

            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);

            app.MapSignalR();
        }
    }
}