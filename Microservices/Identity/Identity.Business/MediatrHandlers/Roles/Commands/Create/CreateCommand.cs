using MediatR;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Business.MediatrHandlers.Roles.Commands.Create
{
    public record CreateCommand(string Name) : IRequest<RoleDTO>;
}