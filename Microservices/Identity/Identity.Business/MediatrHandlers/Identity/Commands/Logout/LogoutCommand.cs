using MediatR;

namespace Identity.Business.MediatrHandlers.Identity.Commands.Logout
{
    public record LogoutCommand(string Email) : IRequest;
}