using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Shared.Server.Base
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected string Email => User.Claims.SingleOrDefault(c => c.Type == "Email")?.Value;
        protected string Id => User.Claims.SingleOrDefault(c => c.Type == "Id")?.Value;
    }
}