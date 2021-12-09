using Funiafy.Domain.SongJoinEntities;
using Funiafy.Domain.UserJoinEntities;

namespace Funiafy.Domain.SongCollections
{
    public class Album : SongCollection
    {
        public Artist Artist { get; set; }
        public string ArtistId { get; set; }

        public Genre Genre { get; set; }
        public string GenreId { get; set; }

        public IEnumerable<AlbumSong> Songs { get; set; } = new List<AlbumSong>();
        public IEnumerable<UserAlbum> Users { get; set; } = new List<UserAlbum>();
    }
}