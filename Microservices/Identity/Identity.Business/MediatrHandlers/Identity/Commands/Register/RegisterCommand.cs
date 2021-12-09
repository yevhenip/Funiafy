using MediatR;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.Register
{
    public record RegisterCommand(RegisterDTO Register) : IRequest;
}