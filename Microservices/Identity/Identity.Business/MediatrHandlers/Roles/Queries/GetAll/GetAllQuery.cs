using MediatR;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Roles.Queries.GetAll
{
    public record GetAllQuery : IRequest<IEnumerable<RoleDTO>>;
}