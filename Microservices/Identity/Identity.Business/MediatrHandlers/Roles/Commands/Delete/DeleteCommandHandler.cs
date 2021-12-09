using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Business.MediatrHandlers.Roles.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public DeleteCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var result = await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(request.Id));

            if (!result.Succeeded)
                throw new ApplicationException("Invalid deletion attempt");

            return Unit.Value;
        }
    }
}