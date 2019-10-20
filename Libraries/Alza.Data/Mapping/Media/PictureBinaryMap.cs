using Alza.Data.Domain.Media;
using Alza.Data.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alza.Data.Mapping.Media
{
    internal class PictureBinaryMap : DbEntityConfiguration<PictureBinaryDataModel>
    {
        public override void Configure(EntityTypeBuilder<PictureBinaryDataModel> e)
        {
            e.ToTable("PictureBinary");
            e.HasKey(c => c.Id);

            e.HasOne(c => c.Picture)
                .WithOne(c => c.PictureBinary)
                .HasForeignKey<PictureBinaryDataModel>(c => c.PictureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
