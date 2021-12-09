using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Business.MediatrHandlers.Users.Commands.RemoveFromRole
{
    public class RemoveFromRoleCommandHandler : IRequestHandler<RemoveFromRoleCommand>
    {
        private readonly UserManager<User> _userManager;

        public RemoveFromRoleCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RemoveFromRoleCommand request, CancellationToken cancellationToken)
        {
            var result =
                await _userManager.RemoveFromRoleAsync(await _userManager.FindByIdAsync(request.UserId), request.Role);

            if (!result.Succeeded)
                throw new Exception("Invalid add to role");

            return Unit.Value;
        }
    }
}