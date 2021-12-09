using System.Reflection;

namespace Shared.Services.Implementation.Settings
{
    public class EventBusSettings
    {
        public Assembly[] RegistrationAssemblies { get; set; }
        public string ConnectionString { get; set; }
        public string SubscriptionPrefixId { get; set; }
    }
}