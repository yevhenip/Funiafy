using Identity.Business.MediatrHandlers.Roles.Commands.Create;
using Identity.Business.MediatrHandlers.Roles.Commands.Delete;
using Identity.Business.MediatrHandlers.Roles.Commands.Update;
using Identity.Business.MediatrHandlers.Roles.Queries.Get;
using Identity.Business.MediatrHandlers.Roles.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Server.Base;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Server.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : ApiControllerBase
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllQuery()));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetQuery(id.ToString())));
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleDTO dto)
        {
            return Ok(await Mediator.Send(new CreateCommand(dto.Name)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, RoleDTO dto)
        {
            return Ok(await Mediator.Send(new UpdateCommand(dto with { Id = id.ToString() })));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteCommand(id.ToString())));
        }
    }
}