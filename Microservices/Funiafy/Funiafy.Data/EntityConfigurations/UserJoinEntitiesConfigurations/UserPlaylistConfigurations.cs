using Funiafy.Domain.UserJoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funiafy.Data.EntityConfigurations.UserJoinEntitiesConfigurations
{
    public class UserPlaylistConfigurations : IEntityTypeConfiguration<UserPlaylist>
    {
        public void Configure(EntityTypeBuilder<UserPlaylist> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.PlaylistId).IsRequired();

            builder.HasOne(up => up.Playlist)
                .WithMany(p => p.Users)
                .HasForeignKey(up => up.PlaylistId);
        }
    }
}