using Shared.Services.Interfaces.DTO.Funiafy.SongCollections;

namespace Shared.Services.Interfaces.DTO.Funiafy.UserJoinEntities
{
    public class UserAlbumDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public AlbumDTO Album { get; set; }
        public string AlbumId { get; set; }
    }
}