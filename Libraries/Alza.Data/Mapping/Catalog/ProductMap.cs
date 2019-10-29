using Alza.Data.Domain.Catalog;
using Alza.Extensions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alza.Data.Mapping.Catalog
{
    internal class ProductMap : DbEntityConfiguration<ProductDataModel>
    {
        public override void Configure(EntityTypeBuilder<ProductDataModel> e)
        {
            e.ToTable("Product");
            e.HasKey(c => c.Id);
            e.Property(c => c.Name).HasMaxLength(200).IsRequired();
            e.Property(c => c.Description).HasMaxLength(500);

            e.HasOne(c => c.Picture)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.PictureId);

            e.HasOne(c => c.Manufacturer)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.ManufacturerId);
        }
    }
}
