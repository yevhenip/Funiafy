using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.VerifyPhone
{
    public class VerifyPhoneCommandHandler : IRequestHandler<VerifyPhoneCommand>
    {
        private const string ErrorMessage = "Invalid verification attempt";
        private readonly UserManager<User> _userManager;

        public VerifyPhoneCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(VerifyPhoneCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Dto.Email);
            if (user is null)
                throw new ApplicationException(ErrorMessage);

            var result =
                await _userManager.VerifyChangePhoneNumberTokenAsync(user, request.Dto.VerifyToken, request.Dto.Phone);
            return result ? Unit.Value : throw new ApplicationException(ErrorMessage);
        }
    }
}