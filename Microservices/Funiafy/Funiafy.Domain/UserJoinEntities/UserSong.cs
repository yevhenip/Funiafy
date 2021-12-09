namespace Funiafy.Domain.UserJoinEntities
{
    public class UserSong
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public Song Song { get; set; }
        public string SongId { get; set; }
    }
}