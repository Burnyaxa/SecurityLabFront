using Newtonsoft.Json;
using ReactiveUI.Fody.Helpers;

namespace front.Entities
{
    public class Credentials
    {
        [Reactive]
        [JsonProperty("email")]
        public string Email { get; set; }
        [Reactive]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}