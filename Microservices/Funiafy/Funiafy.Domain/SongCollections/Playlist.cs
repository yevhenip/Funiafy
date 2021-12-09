using Funiafy.Domain.SongJoinEntities;
using Funiafy.Domain.UserJoinEntities;

namespace Funiafy.Domain.SongCollections
{
    public class Playlist : SongCollection
    {
        public IEnumerable<PlaylistSong> Songs { get; set; } = new List<PlaylistSong>();
        public IEnumerable<UserPlaylist> Users { get; set; } = new List<UserPlaylist>();
    }
}