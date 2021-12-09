using Funiafy.Domain.SongJoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funiafy.Data.EntityConfigurations.SongJoinEntitiesConfigurations
{
    public class PlaylistSongConfigurations : IEntityTypeConfiguration<PlaylistSong>
    {
        public void Configure(EntityTypeBuilder<PlaylistSong> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.SongId).IsRequired();
            builder.Property(a => a.PlaylistId).IsRequired();

            builder.HasOne(ps => ps.Playlist)
                .WithMany(s => s.Songs)
                .HasForeignKey(ps => ps.PlaylistId);

            builder.HasOne(ps => ps.Song)
                .WithMany(s => s.Playlists)
                .HasForeignKey(ps => ps.SongId);
        }
    }
}