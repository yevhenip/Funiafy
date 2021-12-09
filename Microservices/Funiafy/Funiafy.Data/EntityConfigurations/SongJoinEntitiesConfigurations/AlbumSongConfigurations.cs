using Funiafy.Domain.SongJoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funiafy.Data.EntityConfigurations.SongJoinEntitiesConfigurations
{
    public class AlbumSongConfigurations : IEntityTypeConfiguration<AlbumSong>
    {
        public void Configure(EntityTypeBuilder<AlbumSong> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.SongId).IsRequired();
            builder.Property(a => a.AlbumId).IsRequired();

            builder.HasOne(@as => @as.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(@as => @as.AlbumId);

            builder.HasOne(@as => @as.Song)
                .WithMany(s => s.Albums)
                .HasForeignKey(@as => @as.SongId);
        }
    }
}