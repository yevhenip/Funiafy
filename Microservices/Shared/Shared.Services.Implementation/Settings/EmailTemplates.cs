using System.Reflection;

namespace Shared.Services.Implementation.Settings
{
    public class EmailTemplates
    {
        private const string Template = "Identity.Server.wwwroot.";

        public EmailTemplates()
        {
            VerificationEmail = ReadTemplate(Template + "verificationEmail.html");
            ResetPasswordEmail = ReadTemplate(Template + "resetPasswordEmail.html");
        }

        public string VerificationEmail { get; }
        public string ResetPasswordEmail { get; }

        private static string ReadTemplate(string resourceName)
        {
            using var reader = new StreamReader(Assembly.GetEntryAssembly()?.GetManifestResourceStream(resourceName)!);
            return reader.ReadToEnd();
        }
    }
}