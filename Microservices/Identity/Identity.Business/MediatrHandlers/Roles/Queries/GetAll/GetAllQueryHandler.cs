using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Roles.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<RoleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetAllQueryHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<RoleDTO>>(await _roleManager.Roles.ToListAsync(cancellationToken));
        }
    }
}