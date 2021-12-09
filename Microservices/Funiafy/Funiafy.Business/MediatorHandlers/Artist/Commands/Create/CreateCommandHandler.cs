using Azure.Storage.Blobs;
using Funiafy.Data;
using MediatR;

namespace Funiafy.Business.MediatorHandlers.Artist.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand>
    {
        private readonly BlobContainerClient _containerClient;
        private readonly FuniafyDbContext _dbContext;

        public CreateCommandHandler(BlobContainerClient containerClient, FuniafyDbContext dbContext)
        {
            _containerClient = containerClient;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid().ToString();
            var artist = new Domain.Artist { Id = id, UserId = request.UserId };
            
            if (request.Cover is not null)
            {
                await using var image = new MemoryStream();
                
                await request.Cover.CopyToAsync(image, cancellationToken);
                await _containerClient.UploadBlobAsync(id, image, cancellationToken);
                
                artist.Cover = id;
            }

            await _dbContext.Artists.AddAsync(artist, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}