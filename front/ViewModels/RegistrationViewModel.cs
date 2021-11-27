using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using front.Entities;
using front.Helper;
using front.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;

namespace front.ViewModels
{
    public class RegistrationViewModel : ReactiveObject, IRoutableViewModel, IValidatableViewModel
    {
        private readonly RegistrationServiceModel _model = new RegistrationServiceModel();
        private readonly EmailValidator _emailValidator = new EmailValidator();
        private readonly PasswordValidator _validator = new PasswordValidator();
        
        [Reactive]
        public string Email { get; set; }
        [Reactive]
        public string Password { get; set; }
        [Reactive]
        public string Address { get; set; }
        [Reactive]
        public string Phone { get; set; }
        [Reactive]
        public string ConfirmPassword { get; set; }
        [Reactive]
        public string RegistrationStatus { get; set; }
        
        public ReactiveCommand<Unit, Unit> RegisterCommand { get; set; }

        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString();
        public IScreen HostScreen { get; }
        public ValidationContext ValidationContext { get; }

        public RegistrationViewModel(IScreen hostScreen)
        {
            ValidationContext = new ValidationContext();
            Password = string.Empty;
            Email = string.Empty;
            RegistrationStatus = string.Empty;
            ConfirmPassword = string.Empty;
            HostScreen = hostScreen;
            RegisterCommand = ReactiveCommand.CreateFromTask(Register);

            var passwordObservable = this.WhenAnyValue(x => x.Password, x => _validator.Validate(x));
            var emailObservable = this.WhenAnyValue(x => x.Email, x => _emailValidator.Validate(x));

            var passwordConfirmObservable = this.WhenAnyValue(x => x.Password,
                x => x.ConfirmPassword,
                (p, c) => p == c);
            

            this.ValidationRule(x => x.Password,
                passwordObservable,
                "Password must contain minimum 8 and maximum 64 characters, at least one uppercase letter, one lowercase letter, one number and one special character");

            this.ValidationRule(x => x.ConfirmPassword,
                passwordConfirmObservable,
                "Passwords must match");
            this.ValidationRule(x => x.Email,
                emailObservable,
                "Email is not valid");
        }

        public async Task Register()
        {
            if (_validator.Validate(Password) && _emailValidator.Validate(Email) &&
                Password == ConfirmPassword)
            {
                RegistrationStatus = await _model.Register(new RegistrationForm(){Email = Email, Password = Password, Address = Address, Phone = Phone});
            }
        }
    }
}