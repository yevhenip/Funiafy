namespace Shared.Services.Interfaces.DTO.Funiafy.UserJoinEntities
{
    public class UserArtistDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public ArtistDTO Artist { get; set; }
        public string ArtistId { get; set; }
    }
}