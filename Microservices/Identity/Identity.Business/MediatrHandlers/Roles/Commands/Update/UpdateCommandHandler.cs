using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Roles.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, RoleDTO>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UpdateCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<RoleDTO> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Role.Id);
            role.Name = request.Role.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
                throw new ApplicationException("Provide correct role");

            return request.Role;
        }
    }
}