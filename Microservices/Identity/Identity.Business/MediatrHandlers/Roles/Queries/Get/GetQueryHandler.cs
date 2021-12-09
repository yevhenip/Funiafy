using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Roles.Queries.Get
{
    public class GetQueryHandler : IRequestHandler<GetQuery, RoleDTO>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetQueryHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<RoleDTO> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<RoleDTO>(await _roleManager.FindByIdAsync(request.Id));
        }
    }
}