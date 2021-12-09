using Funiafy.Domain.SongCollections;

namespace Funiafy.Domain.SongJoinEntities
{
    public class PlaylistSong
    {
        public string Id { get; set; }

        public Song Song { get; set; }
        public string SongId { get; set; }

        public Playlist Playlist { get; set; }
        public string PlaylistId { get; set; }
    }
}