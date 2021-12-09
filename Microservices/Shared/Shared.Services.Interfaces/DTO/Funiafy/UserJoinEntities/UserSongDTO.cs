namespace Shared.Services.Interfaces.DTO.Funiafy.UserJoinEntities
{
    public class UserSongDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public SongDTO Song { get; set; }
        public string SongId { get; set; }
    }
}