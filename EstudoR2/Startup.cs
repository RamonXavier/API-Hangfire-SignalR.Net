using System.Web.Http;
using EstudoR2;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace EstudoR2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
        }
    }
}