using System;
using System.Reactive;
using System.Threading.Tasks;
using front.Entities;
using front.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace front.ViewModels
{
    public class AuthorizationViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly SignInServiceModel _model = new SignInServiceModel();
        [Reactive]
        public string Password { get; set; }
        [Reactive]
        public string Email { get; set; }
        [Reactive]
        public string Address { get; set; }
        [Reactive]
        public string Phone { get; set; }
        [Reactive]
        public User CurrentUser { get; set; }
        [Reactive]
        public string SignInMessage { get; set; }
        [Reactive]
        public bool IsAuthorized { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> SignInCommand { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> LogOutCommand { get; set; }

        public AuthorizationViewModel(IScreen hostScreen)
        {
            Password = string.Empty;
            Email = string.Empty;
            CurrentUser = new User();
            SignInMessage = string.Empty;
            HostScreen = hostScreen;
            SignInCommand = ReactiveCommand.CreateFromTask(SignIn);
            LogOutCommand = ReactiveCommand.CreateFromTask(LogOut);
        }

        public async Task SignIn()
        {
            try
            {
                CurrentUser = await _model.SignIn(new Credentials(){Email = Email, Password = Password});
                Address = CurrentUser.Address;
                Phone = CurrentUser.Phone;
                SignInMessage = "Yay! Here is your data:";
                IsAuthorized = true;
            }
            catch (Exception e)
            {
                SignInMessage = e.Message;
            }
        }

        public Task LogOut()
        {
            CurrentUser = new User();
            Email = string.Empty;
            Password = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            SignInMessage = string.Empty;
            IsAuthorized = false;
            return Task.CompletedTask;
        }

        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString();
        public IScreen HostScreen { get; }
    }
}