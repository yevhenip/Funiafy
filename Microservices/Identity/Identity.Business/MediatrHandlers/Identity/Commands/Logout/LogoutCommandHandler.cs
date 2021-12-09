using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Business.MediatrHandlers.Identity.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutCommandHandler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();

            return Unit.Value;
        }
    }
}