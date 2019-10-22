using Alza.Data;
using Alza.Services;
using Alza.Services.Catalog;
using Alza.Services.InitialData;
using Alza.Services.Media;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AlzaWebApi
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public static class DependencyRegistrar
    {
        /// <summary>
        /// Registering all services used in the program.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(IServiceCollection services)
        {
            #region Transient

            services.AddTransient<InitialDataService>();

            #endregion

            #region Scoped

            services.AddScoped<IDbContext, ApplicationDbContext>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPictureService, PictureService>();

            #endregion

            #region Singleton

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion
        }
    }
}
