using MediatR;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Roles.Queries.Get
{
    public record GetQuery(string Id) : IRequest<RoleDTO>;
}