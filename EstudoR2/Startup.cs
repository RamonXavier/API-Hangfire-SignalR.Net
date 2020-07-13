using System.Web.Http;
using CaveWeb;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace CaveWeb
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