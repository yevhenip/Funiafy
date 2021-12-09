using MediatR;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Roles.Commands.Update
{
    public record UpdateCommand(RoleDTO Role) : IRequest<RoleDTO>;
}