using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using WizTechDay.IoC;
using WizTechDay.Web.Filters;
using WizTechDay.Web.Services;
using WizTechDay.Web.Services.Interfaces;
using WizTechDay.Web.Swagger;

[assembly: ApiConventionType(typeof(MyApiConventions))]
namespace WizTechDay.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(CustomExceptionFilter));
            });

            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "v1";
                document.Version = "v1";
                document.Title = "Wiz Tech Day API";
                document.Description = "API de Wiz Tech Day";
            });

            if (PlatformServices.Default.Application.ApplicationName != "testhost")
            {
                services.AddHealthChecksUI()
                .AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("wizTechDay"));
            }

            services.AddHttpContextAccessor();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            if (PlatformServices.Default.Application.ApplicationName != "testhost")
            {
                app.UseHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            }

            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #region Services

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IInsertPerson, InsertPerson>();
            services.AddScoped<IListPersonService, ListPersonService>();

            StartupIoC.RegisterServices(services);
        }

        #endregion
    }
}
