using Funiafy.Domain.UserJoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funiafy.Data.EntityConfigurations.UserJoinEntitiesConfigurations
{
    public class UserAlbumConfigurations : IEntityTypeConfiguration<UserAlbum>
    {
        public void Configure(EntityTypeBuilder<UserAlbum> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.AlbumId).IsRequired();

            builder.HasOne(ua => ua.Album)
                .WithMany(a => a.Users)
                .HasForeignKey(ua => ua.AlbumId);
        }
    }
}