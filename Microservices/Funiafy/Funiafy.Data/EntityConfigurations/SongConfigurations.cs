using Funiafy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funiafy.Data.EntityConfigurations
{
    public class SongConfigurations : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(s => s.Name).HasMaxLength(256).IsRequired();
            builder.Property(s => s.Cover).HasMaxLength(512);
            builder.Property(s => s.Url).HasMaxLength(512).IsRequired();
            builder.Property(s => s.Duration).IsRequired();
            builder.Property(a => a.GenreId).IsRequired();


            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId);
        }
    }
}