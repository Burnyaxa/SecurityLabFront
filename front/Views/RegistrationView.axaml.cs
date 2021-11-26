using System.Reactive.Disposables;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using front.ViewModels;
using PropertyChanged;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;

namespace front.Views
{
    [DoNotNotify]
    public class RegistrationView : ReactiveUserControl<RegistrationViewModel>
    {
        public RegistrationView()
        {
            InitializeComponent();
            
            var passwordValidation = this.FindControl<TextBox>("PasswordValidation");
            var confirmPasswordValidation = this.FindControl<TextBox>("PasswordValidation");


            this.WhenActivated(disposables =>
            {
                // this.Bind(ViewModel, vm => vm.Password, view => view.Text)
                //     .DisposeWith(disposables);
                // this.Bind(ViewModel, vm => vm.Password, view => view.ConfirmPassword.Text)
                //     .DisposeWith(disposables);
                // this.BindValidation(ViewModel, vm => vm.Password, view => passwordValidation.Text)
                //     .DisposeWith(disposables);
                // this.BindValidation(ViewModel, vm => vm.Password, view => confirmPasswordValidation.Text)
                //     .DisposeWith(disposables);
            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}