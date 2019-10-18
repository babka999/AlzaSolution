using Alza.Data;
using Alza.Data.InitialData;
using Microsoft.Extensions.DependencyInjection;

namespace Alza.Service
{
    /// <summary>
    /// Service registration class.
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

            services.AddTransient<Initializer>();
            #endregion

            #region Scoped

            services.AddScoped<IDbContext, ApplicationDbContext>();

            #endregion
        }
    }
}
