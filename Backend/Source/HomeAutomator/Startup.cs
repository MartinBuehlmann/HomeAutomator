using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using HomeAutomator.Devices.Persistence;
using HomeAutomator.FileStorage;
using HomeAutomator.Hue.Bridge;
using HomeAutomator.Hue.Persistence;
using HomeAutomator.NfcTags.Persistence;
using Microsoft.AspNetCore.HttpOverrides;

namespace HomeAutomator
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
            services.AddFileStorage();
            services.AddHueBridge();
            services.AddHuePersistence();
            services.AddDevicesPersistence();
            services.AddNfcTagsPersistence();

            services.AddControllers();
            services.AddCommonServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("api", new OpenApiInfo { Title = "HomeAutomator MobileApp API" });
                c.SwaggerDoc("web", new OpenApiInfo { Title = "HomeAutomator WebClient API" });
                c.ResolveConflictingActions(x => x.First());
            });

            services.Configure<ForwardedHeadersOptions>(
                options =>
                {
                    options.ForwardedHeaders =
                        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto |
                        ForwardedHeaders.XForwardedHost | ForwardedHeaders.XForwardedHost;
                    options.ForwardedHostHeaderName = "X-Original-Host";

                    options.KnownNetworks.Clear(); // its loopback by default
                    options.KnownProxies.Clear();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();

                app.UseSwagger(o =>
                {
                    o.RouteTemplate = "swagger/{documentName}/swagger.json";
                    o.SerializeAsV2 = true;
                });
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/api/swagger.json", "HomeAutomator MobileApp API");
                    c.SwaggerEndpoint("/swagger/web/swagger.json", "HomeAutomator WebClient API");
                    c.RoutePrefix = "swagger";
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseForwardedHeaders();
            //app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}