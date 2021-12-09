using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.VerifyPassword
{
    public class VerifyPasswordCommandHandler : IRequestHandler<VerifyPasswordCommand>
    {
        private const string ErrorMessage = "Invalid verification attempt";
        private readonly UserManager<User> _userManager;

        public VerifyPasswordCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(VerifyPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Dto.Email);
            if (user is null)
                throw new ApplicationException(ErrorMessage);

            var result = await _userManager.ResetPasswordAsync(user, request.Dto.Token, request.Dto.Password);
            return result.Succeeded ? Unit.Value : throw new ApplicationException(ErrorMessage);
        }
    }
}