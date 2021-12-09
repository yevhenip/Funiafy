using AutoMapper;
using Funiafy.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Services.Interfaces.DTO.Funiafy;

namespace Funiafy.Business.MediatorHandlers.Artist.Queries.Get
{
    public class GetQueryHandler : IRequestHandler<GetQuery, ArtistDTO>
    {
        private readonly FuniafyDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetQueryHandler(FuniafyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ArtistDTO> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var artist = await _dbContext.Artists.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            return artist is null ? throw new ApplicationException("Artist not found") : _mapper.Map<ArtistDTO>(artist);
        }
    }
}