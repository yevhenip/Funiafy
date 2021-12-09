using Shared.Services.Interfaces.DTO.Funiafy.SongCollections;

namespace Shared.Services.Interfaces.DTO.Funiafy.UserJoinEntities
{
    public class UserPlaylistDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public PlaylistDTO Playlist { get; set; }
        public string PlaylistId { get; set; }
    }
}