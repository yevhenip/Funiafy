using Shared.Services.Interfaces.DTO.Funiafy.SongJoinEntities;
using Shared.Services.Interfaces.DTO.Funiafy.UserJoinEntities;

namespace Shared.Services.Interfaces.DTO.Funiafy.SongCollections
{
    public class PlaylistDTO : SongCollectionDTO
    {
        public IEnumerable<PlaylistSongDTO> Songs { get; set; } = new List<PlaylistSongDTO>();
        public IEnumerable<UserPlaylistDTO> Users { get; set; } = new List<UserPlaylistDTO>();
    }
}