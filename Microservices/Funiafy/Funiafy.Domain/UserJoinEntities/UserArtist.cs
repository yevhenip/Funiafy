namespace Funiafy.Domain.UserJoinEntities
{
    public class UserArtist
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public Artist Artist { get; set; }
        public string ArtistId { get; set; }
    }
}