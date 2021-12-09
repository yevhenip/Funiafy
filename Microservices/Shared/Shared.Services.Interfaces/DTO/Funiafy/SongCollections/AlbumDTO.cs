using Shared.Services.Interfaces.DTO.Funiafy.SongJoinEntities;
using Shared.Services.Interfaces.DTO.Funiafy.UserJoinEntities;

namespace Shared.Services.Interfaces.DTO.Funiafy.SongCollections
{
    public class AlbumDTO : SongCollectionDTO
    {
        public ArtistDTO Artist { get; set; }
        public string ArtistId { get; set; }

        public GenreDTO Genre { get; set; }
        public string GenreId { get; set; }

        public IEnumerable<AlbumSongDTO> Songs { get; set; } = new List<AlbumSongDTO>();
        public IEnumerable<UserAlbumDTO> Users { get; set; } = new List<UserAlbumDTO>();
    }
}