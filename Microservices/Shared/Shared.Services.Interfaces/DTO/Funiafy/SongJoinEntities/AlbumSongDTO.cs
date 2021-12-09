using Shared.Services.Interfaces.DTO.Funiafy.SongCollections;

namespace Shared.Services.Interfaces.DTO.Funiafy.SongJoinEntities
{
    public class AlbumSongDTO
    {
        public string Id { get; set; }

        public SongDTO Song { get; set; }
        public string SongId { get; set; }

        public AlbumDTO Album { get; set; }
        public string AlbumId { get; set; }
    }
}