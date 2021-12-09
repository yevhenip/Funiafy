using Funiafy.Domain.SongCollections;

namespace Funiafy.Domain.UserJoinEntities
{
    public class UserPlaylist
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public Playlist Playlist { get; set; }
        public string PlaylistId { get; set; }
    }
}