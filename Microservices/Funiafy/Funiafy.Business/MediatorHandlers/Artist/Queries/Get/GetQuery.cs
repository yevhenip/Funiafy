using MediatR;
using Shared.Services.Interfaces.DTO.Funiafy;

namespace Funiafy.Business.MediatorHandlers.Artist.Queries.Get
{
    public record GetQuery(string Id) : IRequest<ArtistDTO>;
}