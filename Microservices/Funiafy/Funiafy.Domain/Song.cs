using Funiafy.Domain.SongJoinEntities;
using Funiafy.Domain.UserJoinEntities;

namespace Funiafy.Domain
{
    public class Song
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public uint Duration { get; set; }
        public string Url { get; set; }
        public string Cover { get; set; }
        public bool Explicit { get; set; }

        public Genre Genre { get; set; }
        public string GenreId { get; set; }

        public IEnumerable<ArtistSong> Artists { get; set; } = new List<ArtistSong>();
        public IEnumerable<UserSong> Users { get; set; } = new List<UserSong>();
        public IEnumerable<AlbumSong> Albums { get; set; } = new List<AlbumSong>();
        public IEnumerable<PlaylistSong> Playlists { get; set; } = new List<PlaylistSong>();
    }
}