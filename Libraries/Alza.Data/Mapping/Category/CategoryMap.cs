using Alza.Data.Domain.Category;
using Alza.Data.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alza.Data.Mapping.Category
{
    internal class CategoryMap : DbEntityConfiguration<CategoryDataModel>
    {
        public override void Configure(EntityTypeBuilder<CategoryDataModel> e)
        {
            e.ToTable("Category");
            e.HasKey(c => c.Id);
            e.Property(c => c.Name).HasMaxLength(200).IsRequired();
            e.Property(c => c.Description).HasMaxLength(500);

            e.HasOne(x => x.ParentCategory)
                .WithMany()
                .HasForeignKey(x => x.ParentCategoryId);
        }
    }
}
