namespace Shared.Services.Implementation.Settings
{
    public class ImageSettings
    {
        public int MaxBytes { get; set; }
        private IEnumerable<string> AcceptedFileTypes { get; set; } = new List<string>();
        
        public bool IsSupported(string fileName)
        {
            return AcceptedFileTypes.Any(s => s == Path.GetExtension(fileName).ToLower());
        }
    }
}