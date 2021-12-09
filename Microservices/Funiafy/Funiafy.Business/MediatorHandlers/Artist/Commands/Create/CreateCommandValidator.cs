using FluentValidation;
using Funiafy.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Server.Validation;
using Shared.Services.Implementation.Settings;

namespace Funiafy.Business.MediatorHandlers.Artist.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator(ImageSettings settings, FuniafyDbContext dbContext)
        {
            RuleFor(a => a.Name).NotEmpty()
                .WithMessage("Name is required");

            RuleFor(a => a.Cover).SetValidator(new FormFileValidator(settings));

            RuleFor(a => a.UserId).MustAsync(async (id, cancellationToken) =>
            {
                var artist = await dbContext.Artists.FirstOrDefaultAsync(a => a.UserId == id, cancellationToken);

                if (artist is not null)
                    throw new ApplicationException("You have already had artist");

                return true;
            });
        }
    }
}