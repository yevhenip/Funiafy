using Funiafy.Domain.SongCollections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funiafy.Data.EntityConfigurations.SongCollectionsConfigurations
{
    public class AlbumConfigurations : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ArtistId).IsRequired();
            builder.Property(a => a.GenreId).IsRequired();

            builder.HasOne(a => a.Artist)
                .WithMany(g => g.Albums)
                .HasForeignKey(a => a.ArtistId);

            builder.HasOne(a => a.Genre)
                .WithMany(g => g.Albums)
                .HasForeignKey(a => a.GenreId);
        }
    }
}