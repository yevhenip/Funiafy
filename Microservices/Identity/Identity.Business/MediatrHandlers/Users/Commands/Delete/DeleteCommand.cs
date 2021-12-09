using MediatR;

namespace Identity.Business.MediatrHandlers.Users.Commands.Delete
{
    public record DeleteCommand(string Id) : IRequest;
}