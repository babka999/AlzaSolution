using Alza.Data.Domain.Media;
using Alza.Data.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alza.Data.Mapping.Media
{
    internal class PictureMap : DbEntityConfiguration<PictureDataModel>
    {
        public override void Configure(EntityTypeBuilder<PictureDataModel> e)
        {
            e.ToTable("Picture");
            e.HasKey(c => c.Id);
            e.Property(c => c.MimeType).HasMaxLength(40).IsRequired();
            e.Property(c => c.AltAttribute).HasMaxLength(300);
            e.Property(c => c.TitleAttribute).HasMaxLength(300);
        }
    }
}
