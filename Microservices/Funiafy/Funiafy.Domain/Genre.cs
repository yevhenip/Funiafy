using Funiafy.Domain.SongCollections;

namespace Funiafy.Domain
{
    public class Genre
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Song> Songs { get; set; }
    }
}