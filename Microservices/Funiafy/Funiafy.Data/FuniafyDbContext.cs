using Funiafy.Domain;
using Funiafy.Domain.SongCollections;
using Funiafy.Domain.SongJoinEntities;
using Funiafy.Domain.UserJoinEntities;
using Microsoft.EntityFrameworkCore;

namespace Funiafy.Data
{
    public class FuniafyDbContext : DbContext
    {
        public FuniafyDbContext(DbContextOptions<FuniafyDbContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Ep> Eps { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<ArtistSong> ArtistSongs { get; set; }
        public DbSet<AlbumSong> AlbumSongs { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public DbSet<UserAlbum> UserAlbums { get; set; }
        public DbSet<UserPlaylist> UserPlaylists { get; set; }
        public DbSet<UserSong> UserSongs { get; set; }
        public DbSet<UserArtist> UserArtists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}