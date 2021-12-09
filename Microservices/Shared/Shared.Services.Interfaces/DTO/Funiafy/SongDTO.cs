using Shared.Services.Interfaces.DTO.Funiafy.SongJoinEntities;
using Shared.Services.Interfaces.DTO.Funiafy.UserJoinEntities;

namespace Shared.Services.Interfaces.DTO.Funiafy
{
    public class SongDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public uint Duration { get; set; }
        public string Url { get; set; }
        public string Cover { get; set; }
        public bool Explicit { get; set; }

        public GenreDTO Genre { get; set; }
        public string GenreId { get; set; }

        public IEnumerable<ArtistSongDTO> Artists { get; set; } = new List<ArtistSongDTO>();
        public IEnumerable<UserSongDTO> Users { get; set; } = new List<UserSongDTO>();
        public IEnumerable<AlbumSongDTO> Albums { get; set; } = new List<AlbumSongDTO>();
        public IEnumerable<PlaylistSongDTO> Playlists { get; set; } = new List<PlaylistSongDTO>();
    }
}