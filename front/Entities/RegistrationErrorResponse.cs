﻿using PropertyChanged;

namespace front.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class RegistrationErrorResponse
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Stack { get; set; }
    }
}