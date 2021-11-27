using Newtonsoft.Json;
using ReactiveUI.Fody.Helpers;

namespace front.Entities
{
    public class RegistrationErrorResponse
    {
        [Reactive]
        [JsonProperty("code")]
        public int Code { get; set; }
        [Reactive]
        [JsonProperty("type")]
        public string Type { get; set; }
        [Reactive]
        [JsonProperty("title")]
        public string Title { get; set; }
        [Reactive]
        [JsonProperty("description")]
        public string Description { get; set; }
        [Reactive]
        [JsonProperty("stack")]
        public string Stack { get; set; }
    }
}