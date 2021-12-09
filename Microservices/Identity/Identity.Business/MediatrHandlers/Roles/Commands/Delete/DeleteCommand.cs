using MediatR;

namespace Identity.Business.MediatrHandlers.Roles.Commands.Delete
{
    public record DeleteCommand(string Id) : IRequest;
}