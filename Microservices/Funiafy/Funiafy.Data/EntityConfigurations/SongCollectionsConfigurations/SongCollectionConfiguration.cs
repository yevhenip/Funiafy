using Funiafy.Domain.SongCollections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funiafy.Data.EntityConfigurations.SongCollectionsConfigurations
{
    public class SongCollectionConfiguration : IEntityTypeConfiguration<SongCollection>
    {
        public void Configure(EntityTypeBuilder<SongCollection> builder)
        {
            builder.ToTable("SongCollections");

            builder.HasKey(sc => sc.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(sc => sc.Name).HasMaxLength(256).IsRequired();
            builder.Property(sc => sc.Cover).HasMaxLength(512);
            builder.Property(sc => sc.Duration).IsRequired();
            builder.Property(sc => sc.Description).HasMaxLength(1024);
            builder.Property(sc => sc.Type).HasMaxLength(8).IsRequired();

            builder.HasDiscriminator(sc => sc.Type)
                .HasValue<Playlist>("Playlist")
                .HasValue<Album>("Album")
                .HasValue<Ep>("Ep");
        }
    }
}