using MediatR;

namespace Identity.Business.MediatrHandlers.Users.Commands.RemoveFromRole
{
    public record RemoveFromRoleCommand(string UserId, string Role) : IRequest;
}