using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Hangfire;
using Owin;

namespace HangFire2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage(@"Data Source = EULONWL10052\DSI;  initial catalog = Hangfire; Integrated Security = True;");

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate(
                () => Write(),
                Cron.Hourly);
        }

        public void Write()
        {
            string lines = "First line.\r\nSecond line.\r\nThird line.";

            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter("e:\\input.txt");
            file.WriteLine(lines);

            file.Close();
        }
    }
}