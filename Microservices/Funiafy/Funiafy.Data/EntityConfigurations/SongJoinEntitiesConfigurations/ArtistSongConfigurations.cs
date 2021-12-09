using Funiafy.Domain.SongJoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funiafy.Data.EntityConfigurations.SongJoinEntitiesConfigurations
{
    public class ArtistSongConfigurations : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.SongId).IsRequired();
            builder.Property(a => a.ArtistId).IsRequired();

            builder.HasOne(@as => @as.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(@as => @as.ArtistId);

            builder.HasOne(@as => @as.Song)
                .WithMany(s => s.Artists)
                .HasForeignKey(@as => @as.SongId);
        }
    }
}