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
    public class RegistrationViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly RegistrationServiceModel _model = new RegistrationServiceModel();
        
        public User CurrentUser { get; set; }
        public string RegistrationStatus { get; set; }
        
        public ReactiveCommand<Unit, Unit> RegisterCommand { get; set; }

        public RegistrationViewModel(IScreen hostScreen)
        {
            CurrentUser = new User();
            RegistrationStatus = string.Empty;
            HostScreen = hostScreen;
            RegisterCommand = ReactiveCommand.CreateFromTask(Register);
        }

        public async Task Register()
        {
            RegistrationStatus = await _model.Register(CurrentUser);
        }

        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString();
        public IScreen HostScreen { get; }
    }
}