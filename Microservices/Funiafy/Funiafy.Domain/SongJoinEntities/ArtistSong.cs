namespace Funiafy.Domain.SongJoinEntities
{
    public class ArtistSong
    {
        public string Id { get; set; }

        public Song Song { get; set; }
        public string SongId { get; set; }

        public Artist Artist { get; set; }
        public string ArtistId { get; set; }
    }
}