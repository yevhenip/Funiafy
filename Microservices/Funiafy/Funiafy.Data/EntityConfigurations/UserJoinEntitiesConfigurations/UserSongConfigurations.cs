using Funiafy.Domain.UserJoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funiafy.Data.EntityConfigurations.UserJoinEntitiesConfigurations
{
    public class UserSongConfigurations : IEntityTypeConfiguration<UserSong>
    {
        public void Configure(EntityTypeBuilder<UserSong> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.SongId).IsRequired();

            builder.HasOne(us => us.Song)
                .WithMany(s => s.Users)
                .HasForeignKey(us => us.SongId);
        }
    }
}