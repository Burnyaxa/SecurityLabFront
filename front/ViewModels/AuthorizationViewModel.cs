using System;
using System.Reactive;
using System.Threading.Tasks;
using front.Entities;
using front.Models;
using PropertyChanged;
using ReactiveUI;

namespace front.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AuthorizationViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly SignInServiceModel _model = new SignInServiceModel();
        
        public Credentials CurrentCredentials { get; set; }
        public User CurrentUser { get; set; }
        public string SignInMessage { get; set; }
        public bool IsAuthorized { get; set; }
        public ReactiveCommand<Unit, Unit> SignInCommand { get; set; }
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
                SignInMessage = "Oops something went wrong. Check your credentials and try again.";
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