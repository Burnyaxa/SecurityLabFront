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
        public Credentials CurrentCredentials { get; set; }
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
            CurrentCredentials = new Credentials();
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
                CurrentUser = await _model.SignIn(CurrentCredentials);
                SignInMessage = "Yay! Here is your data:";
            }
            catch (Exception e)
            {
                SignInMessage = e.Message;
            }
        }

        public Task LogOut()
        {
            CurrentUser = new User();
            SignInMessage = string.Empty;
            IsAuthorized = false;
            return Task.CompletedTask;
        }

        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString();
        public IScreen HostScreen { get; }
    }
}