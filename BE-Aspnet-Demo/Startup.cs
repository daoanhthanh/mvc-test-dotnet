using be_aspnet_demo.config;
using be_aspnet_demo.controllers.response;
using be_aspnet_demo.models;
using be_aspnet_demo.models.idGenerator;
using be_aspnet_demo.models.user;
using be_aspnet_demo.utils;
using Microsoft.EntityFrameworkCore;

namespace be_aspnet_demo;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration) => _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMemoryCache();

        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        services.AddControllers().ConfigureApiBehaviorOptions(options =>
        {
            // Adds a custom error response factory when ModelState is invalid
            options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.ProduceErrorResponse;
        });

        services.AddDbContext<AppDbContext>(options =>
        {
            string? server = _configuration["Database:Host"];
            string? port = _configuration["Database:Port"];
            string? userId = _configuration["Database:User"];
            string? password = _configuration["Database:Password"];
            string? database = _configuration["Database:Schema"];
            string connectionString =
                $"Server={server}; Port={port}; User ID={userId}; Password={password}; Database={database}";
            Console.WriteLine(connectionString);
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        services.AddScoped<UserRepository>();
        services.AddScoped<UserService>();
        services.AddScoped<UnitOfWork>();
        services.AddSingleton<SnowFlakeId>();

        services.AddAutoMapper(typeof(Startup));

        services.AddCustomSwagger();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsEnvironment("Local") || env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            app.UseCustomSwagger();
        }
        
        using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            context.Database.MigrateAsync();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}