using MediatR;

namespace Identity.Business.MediatrHandlers.Identity.Commands.ChangePhone
{
    public record ChangePhoneCommand(string Email, string Phone) : IRequest;
}