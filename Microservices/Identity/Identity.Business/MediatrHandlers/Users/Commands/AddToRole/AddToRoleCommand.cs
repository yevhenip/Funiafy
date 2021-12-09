using MediatR;

namespace Identity.Business.MediatrHandlers.Users.Commands.AddToRole
{
    public record AddToRoleCommand(string UserId, string Role) : IRequest;
}