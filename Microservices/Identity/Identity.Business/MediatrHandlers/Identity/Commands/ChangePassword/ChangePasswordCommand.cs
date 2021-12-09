using MediatR;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.ChangePassword
{
    public record ChangePasswordCommand(ChangePasswordDTO Dto) : IRequest;
}