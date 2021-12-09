using Funiafy.Domain.SongCollections;

namespace Funiafy.Domain.UserJoinEntities
{
    public class UserAlbum
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public Album Album { get; set; }
        public string AlbumId { get; set; }
    }
}