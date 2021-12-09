using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Roles.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, RoleDTO>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateCommandHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<RoleDTO> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole { Name = request.Name });

            if (!result.Succeeded)
                throw new ApplicationException("Invalid creation attempt");

            return _mapper.Map<RoleDTO>(await _roleManager.FindByNameAsync(request.Name));
        }
    }
}