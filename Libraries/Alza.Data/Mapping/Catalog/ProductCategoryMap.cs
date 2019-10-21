using Alza.Data.Domain.Catalog;
using Alza.Data.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alza.Data.Mapping.Catalog
{
    internal class ProductCategoryMap : DbEntityConfiguration<ProductCategoryDataModel>
    {
        public override void Configure(EntityTypeBuilder<ProductCategoryDataModel> e)
        {
            e.ToTable("Product_Category_Mapping");
            e.HasKey(c => c.Id);

            e.HasOne(c => c.Category)
                .WithMany(c=>c.CategoryProducts)
                .HasForeignKey(c => c.CategoryId)
                .IsRequired();

            e.HasOne(c => c.Product)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(c => c.ProductId)
                .IsRequired();
        }
    }
}
