using PropertyChanged;

namespace front.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}