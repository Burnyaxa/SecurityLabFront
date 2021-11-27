using System;
using Newtonsoft.Json;
using ReactiveUI.Fody.Helpers;

namespace front.Entities
{
    public class User
    {
        [Reactive]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Reactive]
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;
        [Reactive]
        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;
        [Reactive]
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;
        [Reactive]
        [JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;
        [Reactive]
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        [Reactive]
        [JsonProperty("lastAuthDate")]
        public DateTime LastAuthDate { get; set; }
    }
}