using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using front.Entities;
using front.Helper;
using front.Models;
using PropertyChanged;
using ReactiveUI;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;

namespace front.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class RegistrationViewModel : ReactiveObject, IRoutableViewModel, IValidatableViewModel
    {
        private readonly RegistrationServiceModel _model = new RegistrationServiceModel();
        private readonly PasswordValidator _validator = new PasswordValidator();

        public User CurrentUser { get; set; }

        public string Password
        {
            get => CurrentUser.Password;
            set => CurrentUser.Password = value;
        }
        public ObservableCollection<string> PasswordIssues { get; set; }
        public string ConfirmPassword { get; set; }
        public string RegistrationStatus { get; set; }
        public bool IsPasswordValid { get; set; }

        public ReactiveCommand<Unit, Unit> RegisterCommand { get; set; }

        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString();
        public IScreen HostScreen { get; }
        public ValidationContext ValidationContext { get; }

        public RegistrationViewModel(IScreen hostScreen)
        {
            ValidationContext = new ValidationContext();
            CurrentUser = new User();
            Password = string.Empty;
            RegistrationStatus = string.Empty;
            ConfirmPassword = string.Empty;
            PasswordIssues = new ObservableCollection<string>();
            HostScreen = hostScreen;
            RegisterCommand = ReactiveCommand.CreateFromTask(Register);

            this.ValidationRule(x => x.Password,
                x => _validator.Validate(x),
                "Password must contain minimum 8 and maximum 64 characters, at least one uppercase letter, one lowercase letter, one number and one special character");

            this.ValidationRule(x => x.ConfirmPassword,
                x => x == Password,
                "Passwords must match");
        }

        public async Task Register()
        {
            RegistrationStatus = await _model.Register(CurrentUser);
        }
    }
}