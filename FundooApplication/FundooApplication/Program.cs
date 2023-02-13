using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace FundooApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "LoggerFiles");
            NLog.GlobalDiagnosticsContext.Set("LogDirectory", logPath);
            var Logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            try
            {
                Logger.Debug("Logger Debugging");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                NLog.LogManager.Shutdown(); 
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
        .ConfigureLogging(Logging => {
            Logging.ClearProviders();
            Logging.SetMinimumLevel(LogLevel.Debug);
        }).UseNLog();
    }
}
