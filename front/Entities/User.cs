using System;
using PropertyChanged;

namespace front.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastAuthDate { get; set; }
    }
}