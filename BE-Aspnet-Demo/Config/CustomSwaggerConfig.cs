using System.Reflection;
using Microsoft.OpenApi.Models;

namespace be_aspnet_demo.config;

public static class CustomSwaggerConfig
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(cfg =>
        {
            cfg.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "BE ASP.NET Core API",
                Version = "v0.1",
                Description = "Project phục vụ mục đích tìm hiểu các tính năng của ASP.NET 8.0",
            });
        });
        return services;
    }

    public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger().UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "BE ASP.NET Core API");
            options.DocumentTitle = "BE ASP.NET Core API";
        });
        return app;
    }
}