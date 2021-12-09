using MediatR;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.VerifyEmail
{
    public record VerifyEmailCommand(VerificationEmailDTO Dto) : IRequest;
}