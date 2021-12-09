using MediatR;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.Login
{
    public record LoginCommand(LoginDTO Login) : IRequest<AuthenticatedUserDTO>;
}