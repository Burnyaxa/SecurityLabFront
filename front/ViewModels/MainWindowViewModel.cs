using System;
using System.Reactive;
using ReactiveUI;

namespace front.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public string Greeting => "Welcome to Avalonia!";
        public readonly AuthorizationViewModel AuthorizationViewModel;
        public readonly RegistrationViewModel RegistrationViewModel;
        public RoutingState Router { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoToRegistrationCommand { get; set; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToAuthorizationCommand { get; set; }

        public MainWindowViewModel()
        {
            Router = new RoutingState();
            AuthorizationViewModel = new AuthorizationViewModel(this);
            RegistrationViewModel = new RegistrationViewModel(this);
            GoToRegistrationCommand = ReactiveCommand.CreateFromObservable(GoToRegistration);
            GoToAuthorizationCommand = ReactiveCommand.CreateFromObservable(GoToAuthorization);
            GoToRegistrationCommand.Execute();
        }

        public IObservable<IRoutableViewModel> GoToRegistration() => Router.Navigate.Execute(RegistrationViewModel);
        public IObservable<IRoutableViewModel> GoToAuthorization() => Router.Navigate.Execute(AuthorizationViewModel);


    }
}