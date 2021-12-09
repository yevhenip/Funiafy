using MediatR;
using Microsoft.AspNetCore.Http;

namespace Funiafy.Business.MediatorHandlers.Artist.Commands.Create
{
    public record CreateCommand(string Name, IFormFile Cover, string UserId) : IRequest;
}