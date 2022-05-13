using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SmartContract.Infrastructure.Data.ConnectionContext;
using SmartContract.Infrastructure.Data.ConnectionContextEbudget;
using SmartContract.Infrastructure.Data.Mapping;
using SmartContract.Infrastructure.Helpers;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Interfaces.Authenticate;
using SmartContract.Infrastructure.Interfaces.Share;
using SmartContract.Infrastructure.Repositorys;
using SmartContract.Infrastructure.Repositorys.Authenticate;
using SmartContract.Infrastructure.Repositorys.Share;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Wrapper;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;

namespace SmartContract.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews();

            services.AddRouting(options => options.LowercaseUrls = true);
            //แก้ Refresh Page View ไม่เปลี่ยน
            //Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDbContext<smartContractContext>(options =>
              options.UseOracle(Configuration.GetConnectionString("smartContractContext"), options =>
              options.UseOracleSQLCompatibility("11")));

            //services.AddDbContext<smartContractContextEbudget>(options =>
            //  options.UseOracle(Configuration.GetConnectionString("smartContractContextEbudget"), options =>
            //  options.UseOracleSQLCompatibility("11")));

            //configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // แก้ Ajax Error when Including related data EF Core
            //Nuget Microsoft.AspNetCore.Mvc.NewtonsoftJson
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).AddXmlSerializerFormatters();

            //บังคับ json response ตัวเล็กตัวใหญ่เหมือน original
            services.AddMvc(setupAction =>
            {
                setupAction.EnableEndpointRouting = false;
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //.SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSingleton<HttpClient>();
            services.AddAutoMapper(typeof(AutoMapping));
            services.AddTransient<smartContractContext>();
            //services.AddTransient<smartContractContextEbudget>();
            services.AddScoped<IRepositoryBase, RepositoryBase>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IGeneralRepo, GeneralRepo>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddTransient<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use((context, next) =>
            //{
            //    context.Request.PathBase = "/smct";
            //    return next();
            //});
            //app.UsePathBase("/smct");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //app.UseStaticFiles("/smct");

            app.UseSession();

            app.UseRouting();

            // global cors policy
            //app.UseCors(x => x
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .SetIsOriginAllowed(origin => true) // allow any origin
            //    .AllowCredentials()); // allow credentials

            app.UseAuthorization();

            var culture = CultureInfo.CreateSpecificCulture("en-US");
            var dateformat = new DateTimeFormatInfo
            {
                ShortDatePattern = "dd/MM/yyyy",
                LongDatePattern = "dd/MM/yyyy"
            };
            culture.DateTimeFormat = dateformat;

            var supportedCultures = new[]
            {
                culture
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Authorize}/{action=Local}/{id?}");
                endpoints.MapHub<UserCount>("/usercount");
            });
        }
    }
}
