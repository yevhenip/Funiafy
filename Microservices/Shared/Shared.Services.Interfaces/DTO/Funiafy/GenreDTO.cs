using Shared.Services.Interfaces.DTO.Funiafy.SongCollections;

namespace Shared.Services.Interfaces.DTO.Funiafy
{
    public class GenreDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<AlbumDTO> Albums { get; set; }
        public IEnumerable<SongDTO> Songs { get; set; }
    }
}