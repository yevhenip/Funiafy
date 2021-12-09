using FluentValidation;
using Funiafy.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Server.Validation;
using Shared.Services.Implementation.Settings;

namespace Funiafy.Business.MediatorHandlers.Artist.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator(ImageSettings settings, FuniafyDbContext dbContext)
        {
            RuleFor(a => a.Name).NotEmpty()
                .WithMessage("Name is required");

            RuleFor(a => a.Cover).SetValidator(new FormFileValidator(settings));

            RuleFor(a => a.UserId).MustAsync(async (id, cancellationToken) =>
            {
                var artist = await dbContext.Artists.FirstOrDefaultAsync(a => a.UserId == id, cancellationToken);
                
                if (artist is null)
                    throw new ApplicationException("Artist associated with you not found");
                
                return true;
            });
        }
    }
}