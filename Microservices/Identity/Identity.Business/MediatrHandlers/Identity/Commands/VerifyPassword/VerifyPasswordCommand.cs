using MediatR;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.VerifyPassword
{
    public record VerifyPasswordCommand(VerificationPasswordDTO Dto) : IRequest;
}