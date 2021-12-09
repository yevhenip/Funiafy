using Shared.Services.Interfaces.DTO.Funiafy.SongCollections;
using Shared.Services.Interfaces.DTO.Funiafy.SongJoinEntities;
using Shared.Services.Interfaces.DTO.Funiafy.UserJoinEntities;

namespace Shared.Services.Interfaces.DTO.Funiafy
{
    public class ArtistDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public bool Verified { get; set; }

        public string UserId { get; set; }

        public IEnumerable<AlbumDTO> Albums { get; set; }
        public IEnumerable<ArtistSongDTO> Songs { get; set; }
        public IEnumerable<UserArtistDTO> Users { get; set; }
    }
}