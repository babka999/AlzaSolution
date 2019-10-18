using Alza.Data;
using Alza.Data.InitialData;
using Alza.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace AlzaWebApi
{
    /// <summary>
    /// Application startup
    /// </summary>
    public class Startup
    {
        #region Fields

        private static string _apiVersion = "";
        private readonly string[] _xmlCommentsFilename = { "DenisaAPI.xml", "Denisa.ApiModels.xml" };

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Application configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        private static string XmlCommentsFilePath
            => Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml");

        #endregion

        #region Public methods

        /// <summary>
        /// This method is called runtime. This method and kply services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            DependencyRegistrar.RegisterServices(services);
            services.AddMvc(o => o.EnableEndpointRouting = true).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddApiVersioning();
            services.AddVersionedApiExplorer(
                c =>
                {
                    c.GroupNameFormat = "'v'VVV";
                    c.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigure>();
            services.AddSwaggerGen(c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.IncludeXmlComments(XmlCommentsFilePath);
            });
        }

        /// <summary>
        /// This method is called runtime. Use this method and configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="initializer"></param>
        /// <param name="provider"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Initializer initializer, IApiVersionDescriptionProvider provider)
        {
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    //c.DocExpansion(DocExpansion.None);
                    //c.InjectStylesheet("/documentation/documentation.css");
                    //c.InjectStylesheet("https://use.fontawesome.com/releases/v5.2.0/css/all.css");
                    //c.InjectJavascript("https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js", "text/javascript");
                    //c.InjectJavascript("/documentation/documentation.js", "text/javascript");
                });
            initializer.SeedAsync().Wait();
        }

        #endregion
    }
}
