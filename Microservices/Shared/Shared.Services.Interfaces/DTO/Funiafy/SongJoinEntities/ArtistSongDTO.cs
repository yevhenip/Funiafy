namespace Shared.Services.Interfaces.DTO.Funiafy.SongJoinEntities
{
    public class ArtistSongDTO
    {
        public string Id { get; set; }

        public SongDTO Song { get; set; }
        public string SongId { get; set; }

        public ArtistDTO Artist { get; set; }
        public string ArtistId { get; set; }
    }
}