using Azure.Storage.Blobs;
using Funiafy.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Funiafy.Business.MediatorHandlers.Artist.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand>
    {
        private readonly BlobContainerClient _containerClient;
        private readonly FuniafyDbContext _dbContext;

        public UpdateCommandHandler(BlobContainerClient containerClient, FuniafyDbContext dbContext)
        {
            _containerClient = containerClient;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var artist = await _dbContext.Artists.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (artist is null)
                throw new ApplicationException("Artist Not Found");

            if (request.Cover is not null)
            {
                await using var image = new MemoryStream();
                
                await request.Cover.CopyToAsync(image, cancellationToken);
                await _containerClient.UploadBlobAsync(request.Id, image, cancellationToken);
            }

            _dbContext.Artists.Update(artist);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}