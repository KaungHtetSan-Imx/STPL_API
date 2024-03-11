using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using STPL_API.BusinessLogic;
using STPL_API.DataAccessLayer;

namespace STPL_API
{
    public partial class Startup
    {
        // public SymmetricSecurityKey signingKey;
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            StaticConfiguration = Configuration;
        }

        public IConfigurationRoot Configuration { get; }

        public static IConfigurationRoot StaticConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors(Configuration);

            services.ConfigureIISIntegration();

            services.ConfigureMySqlContext(Configuration);

            services.ConfigureRepositoryWrapper();
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole(); // Add Console logger
            });

            Log._logger = loggerFactory.CreateLogger<Program>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

           
            services.AddScoped<HelloSTPLRepository>();

            //#ST added to retrieve ip addreess
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();

            // Add framework services.
            services.AddMvc()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "STPL_API", Version = "v1" });
            });
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession(options =>
            {
                // Set a short timeout for easy testdoting.
                options.IdleTimeout = TimeSpan.FromSeconds(30);
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //Set for console log
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //Set for log4net
            loggerFactory.AddLog4Net(Configuration.GetValue<string>("Log4NetConfigFile:Name"));
            // IMPORTANT: This session call MUST go before UseMvc()

            app.UseSession();

            //app.UseStaticFiles(); // For the wwwroot folder
            //app.UseS; // For the wwwroot folder
            // Serve my app-specific default file, if present.
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();

            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors("CorsAllowAllPolicy");
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            
            //loggerFactory.AddConsole(LogLevel.Warning, true).AddDebug();
            LoggerFactory.Create(builder => builder.AddConsole().AddDebug());
            app.UseRouting();
            app.UseEndpoints(builder => builder.MapControllers());
        }
    }
}
