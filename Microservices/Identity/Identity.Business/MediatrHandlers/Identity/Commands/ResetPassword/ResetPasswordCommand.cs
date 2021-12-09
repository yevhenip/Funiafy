using MediatR;

namespace Identity.Business.MediatrHandlers.Identity.Commands.ResetPassword
{
    public record ResetPasswordCommand(string UsernameOrEmail) : IRequest;
}