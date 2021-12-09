using Funiafy.Domain.UserJoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funiafy.Data.EntityConfigurations.UserJoinEntitiesConfigurations
{
    public class UserArtistConfigurations : IEntityTypeConfiguration<UserArtist>
    {
        public void Configure(EntityTypeBuilder<UserArtist> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.ArtistId).IsRequired();

            builder.HasOne(ua => ua.Artist)
                .WithMany(a => a.Users)
                .HasForeignKey(ua => ua.ArtistId);
        }
    }
}