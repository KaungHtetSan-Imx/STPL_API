using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using STPL_API.BusinessLogic;

namespace STPL_API.DataAccessLayer
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, IConfiguration config)
        {
            
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod(); 
            corsBuilder.WithOrigins((Environment.GetEnvironmentVariable("ALLOW_ORIGIN") ?? config["appSettings:AllowedOrigins"]).Split(","));

            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAllPolicy", corsBuilder.Build());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
       
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            try
            {
                var connectionString = Environment.GetEnvironmentVariable("DBSTRING") ?? config["ConnectionStrings:DefaultConnection"];
                services.AddDbContext<AppDb>(o => o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            }
            catch(Exception ex)
            {
                Log.Error(ex, "ConfigureMySqlContext" + Environment.NewLine + ex.StackTrace);
            }
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            //services.AddSingleton<IRepositoryWrapper, RepositoryWrapper>();

        }
    }
}
