using Funiafy.Domain.SongCollections;
using Funiafy.Domain.SongJoinEntities;
using Funiafy.Domain.UserJoinEntities;

namespace Funiafy.Domain
{
    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public bool Verified { get; set; }

        public string UserId { get; set; }

        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<ArtistSong> Songs { get; set; }
        public IEnumerable<UserArtist> Users { get; set; }
    }
}