using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using EstudoR2.Hubs;

[assembly: OwinStartup(typeof(EstudoR2.Startup))]

namespace EstudoR2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            ChatHub a = new ChatHub();

            JobStorage.Current = new SqlServerStorage("R2");

            //BackgroundJob.Enqueue(() => FireAndForget());
            //BackgroundJob.Schedule(() => Console.WriteLine("Schedule method"),TimeSpan.FromMilliseconds(100000));
            //RecurringJob.AddOrUpdate(() => Console.WriteLine("RecurringJob"),Cron.Minutely);

            RecurringJob.AddOrUpdate(() => a.RoboMensagem("Supervisor Robô", $"Te observo as: ", ""), Cron.Minutely);

            app.UseHangfireServer();
            app.UseHangfireDashboard("/hangfire");
        }

        private string GetDate()
        {
            return DateTime.Now.ToString();
        }

        public void FireAndForget()
        {
            Thread.Sleep(100000);
            Console.WriteLine("FireAndForget");
        }
    }
}
