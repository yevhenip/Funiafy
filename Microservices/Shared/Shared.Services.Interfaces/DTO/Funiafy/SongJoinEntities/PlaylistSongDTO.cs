using Shared.Services.Interfaces.DTO.Funiafy.SongCollections;

namespace Shared.Services.Interfaces.DTO.Funiafy.SongJoinEntities
{
    public class PlaylistSongDTO
    {
        public string Id { get; set; }

        public SongDTO Song { get; set; }
        public string SongId { get; set; }

        public PlaylistDTO Playlist { get; set; }
        public string PlaylistId { get; set; }
    }
}