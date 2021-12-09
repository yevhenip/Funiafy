using Identity.Business.MediatrHandlers.Users.Commands.AddToRole;
using Identity.Business.MediatrHandlers.Users.Commands.Delete;
using Identity.Business.MediatrHandlers.Users.Commands.RemoveFromRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Server.Base;

namespace Identity.Server.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteCommand(id.ToString())));
        }

        [HttpPut("{userId:guid}/{role}")]
        public async Task<IActionResult> AddToRole(Guid userId, string role)
        {
            return Ok(await Mediator.Send(new AddToRoleCommand(userId.ToString(), role)));
        }

        [HttpPatch("{userId:guid}/{role}")]
        public async Task<IActionResult> RemoveFromRole(Guid userId, string role)
        {
            return Ok(await Mediator.Send(new RemoveFromRoleCommand(userId.ToString(), role)));
        }
    }
}