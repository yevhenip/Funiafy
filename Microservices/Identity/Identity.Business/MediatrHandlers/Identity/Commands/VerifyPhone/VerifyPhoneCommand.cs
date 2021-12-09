using MediatR;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.VerifyPhone
{
    public record VerifyPhoneCommand(VerificationPhoneDTO Dto) : IRequest;
}