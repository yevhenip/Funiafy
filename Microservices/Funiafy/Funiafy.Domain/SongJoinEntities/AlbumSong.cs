using Funiafy.Domain.SongCollections;

namespace Funiafy.Domain.SongJoinEntities
{
    public class AlbumSong
    {
        public string Id { get; set; }

        public Song Song { get; set; }
        public string SongId { get; set; }

        public Album Album { get; set; }
        public string AlbumId { get; set; }
    }
}