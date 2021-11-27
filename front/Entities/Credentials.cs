using ReactiveUI.Fody.Helpers;

namespace front.Entities
{
    public class Credentials
    {
        [Reactive]
        public string Email { get; set; }
        [Reactive]
        public string Password { get; set; }
    }
}