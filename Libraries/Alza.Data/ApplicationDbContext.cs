using Alza.Data.Domain.Catalog;
using Alza.Data.Domain.Media;
using Alza.Data.Extension;
using Alza.Data.Mapping.Catalog;
using Alza.Data.Mapping.Media;
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
            builder.AddConfiguration(new ManufacturerMap());
            builder.AddConfiguration(new PictureMap());
            builder.AddConfiguration(new PictureBinaryMap());

            #endregion
        }

        #endregion

        #region Adding entities

        public DbSet<CategoryDataModel> Categories { get; set; }
        public DbSet<ManufacturerDataModel> Manufacturers { get; set; }
        public DbSet<PictureDataModel> Pictures { get; set; }
        public DbSet<PictureBinaryDataModel> PicturesBinary { get; set; }

        #endregion
    }
}
