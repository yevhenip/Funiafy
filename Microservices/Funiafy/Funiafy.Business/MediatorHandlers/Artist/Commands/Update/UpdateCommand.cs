using MediatR;
using Microsoft.AspNetCore.Http;

namespace Funiafy.Business.MediatorHandlers.Artist.Commands.Update
{
    public record UpdateCommand(string Name, IFormFile Cover, string UserId, string Id) : IRequest;
}