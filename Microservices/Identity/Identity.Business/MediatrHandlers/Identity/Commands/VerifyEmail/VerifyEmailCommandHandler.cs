using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.VerifyEmail
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand>
    {
        private const string ErrorMessage = "Invalid verification attempt";
        private readonly UserManager<User> _userManager;

        public VerifyEmailCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Dto.Email);
            if (user is null)
                throw new ApplicationException(ErrorMessage);

            var result = await _userManager.ConfirmEmailAsync(user, request.Dto.Token);

            return result.Succeeded ? Unit.Value : throw new ApplicationException(ErrorMessage);
        }
    }
}