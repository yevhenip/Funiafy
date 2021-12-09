using Funiafy.Business.MediatorHandlers.Artist.Commands.Create;
using Funiafy.Business.MediatorHandlers.Artist.Commands.Update;
using Funiafy.Business.MediatorHandlers.Artist.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Server.Base;

namespace Funiafy.Server.Controllers
{
    [Authorize]
    public class ArtistController : ApiControllerBase
    {
        public ArtistController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetQuery(id.ToString())));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommand command)
        {
            return Ok(await Mediator.Send(command with { UserId = Id }));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateCommand command)
        {
            return Ok(await Mediator.Send(command with { UserId = Id, Id = id.ToString() }));
        }
    }
}