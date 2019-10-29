using Alza.Data.Domain.Catalog;
using Alza.Extensions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alza.Data.Mapping.Catalog
{
    internal class ManufacturerMap : DbEntityConfiguration<ManufacturerDataModel>
    {
        public override void Configure(EntityTypeBuilder<ManufacturerDataModel> e)
        {
            e.ToTable("Manufacturer");
            e.HasKey(c => c.Id);
            e.Property(c => c.Name).HasMaxLength(200).IsRequired();
            e.Property(c => c.Description).HasMaxLength(500);
        }
    }
}
