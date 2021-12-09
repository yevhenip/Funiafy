using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Business.MediatrHandlers.Users.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        private readonly UserManager<User> _userManager;

        public DeleteCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            await _userManager.DeleteAsync(await _userManager.FindByIdAsync(request.Id));

            return Unit.Value;
        }
    }
}