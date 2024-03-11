using System.Reflection;
using Hocon.Extensions.Configuration;

namespace be_aspnet_demo.config;

public static class HoconReaderConfig
{
    public static IHostBuilder ConfigureHoconReader(this IHostBuilder host, string[] args)
    {
        host.ConfigureAppConfiguration((hostingContext, config) =>
        {
            {
                var env = hostingContext.HostingEnvironment;

                config.AddHoconFile(
                        "appSettings.conf",
                        optional: false,
                        reloadOnChange: true
                    )
                    .AddHoconFile(
                        $"appSettings.{env.EnvironmentName}.conf",
                        optional: true,
                        reloadOnChange: true);

                if (env.IsDevelopment())
                {
                    var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                    
                    config.AddUserSecrets(appAssembly, optional: true);
                }
                
                config.AddEnvironmentVariables();
                
                config.AddCommandLine(args);
            }
        });
        return host;
    }
}