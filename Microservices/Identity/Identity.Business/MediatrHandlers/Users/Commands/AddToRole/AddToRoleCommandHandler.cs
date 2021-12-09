using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Business.MediatrHandlers.Users.Commands.AddToRole
{
    public class AddToRoleCommandHandler : IRequestHandler<AddToRoleCommand>
    {
        private readonly UserManager<User> _userManager;

        public AddToRoleCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(AddToRoleCommand request, CancellationToken cancellationToken)
        {
            var result =
                await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(request.UserId), request.Role);

            if (!result.Succeeded)
                throw new ApplicationException("Invalid add to role");

            return Unit.Value;
        }
    }
}