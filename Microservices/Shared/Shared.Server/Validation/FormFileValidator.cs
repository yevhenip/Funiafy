using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shared.Services.Implementation.Settings;

namespace Shared.Server.Validation
{
    public class FormFileValidator : AbstractValidator<IFormFile>
    {
        public FormFileValidator(ImageSettings settings)
        {

            RuleFor(f => f.Length).ExclusiveBetween(0, settings.MaxBytes)
                .WithMessage(
                    $"File length should be greater than 0 and less than {settings.MaxBytes / 1024 / 1024} MB")
                .When(p => p != null);

            RuleFor(f => f.FileName).Must(settings.IsSupported)
                .WithMessage("Unsupported file extension!")
                .When(p => p != null);
        }
    }
}
