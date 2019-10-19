using Alza.Data.Domain.Category;
using Alza.Data.Extension;
using Alza.Data.Mapping.Category;
using Microsoft.EntityFrameworkCore;

namespace Alza.Data
{
    public partial class ApplicationDbContext : DbContext, IDbContext
    {
        #region Ctor

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #endregion

        #region Override method

        /// <summary>
        /// Mapping entities
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Entities mapping configuration

            builder.AddConfiguration(new CategoryMap());

            #endregion
        }

        #endregion

        #region Adding entities

        public DbSet<CategoryDataModel> Categories { get; set; }

        #endregion
    }
}
