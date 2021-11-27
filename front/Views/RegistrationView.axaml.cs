using System.Reactive.Disposables;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using front.ViewModels;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;

namespace front.Views
{
    public class RegistrationView : ReactiveUserControl<RegistrationViewModel>
    {
        public TextBlock PasswordValidation => this.FindControl<TextBlock>("PasswordValidation");
        public TextBlock EmailValidation => this.FindControl<TextBlock>("EmailValidation");
        public TextBox Password => this.FindControl<TextBox>("Password");
        public TextBlock ConfirmPasswordValidation => this.FindControl<TextBlock>("ConfirmPasswordValidation");
        public TextBox ConfirmPassword => this.FindControl<TextBox>("ConfirmPassword");

        public RegistrationView()
        {
            this.WhenActivated(disposables =>
            {
                  this.Bind(ViewModel, vm => vm.Password, view => view.Password.Text)
                      .DisposeWith(disposables);
                  this.Bind(ViewModel, vm => vm.ConfirmPassword, view => view.ConfirmPassword.Text)
                      .DisposeWith(disposables);
                 this.BindValidation(ViewModel, vm => vm.Password, v => v.PasswordValidation.Text)
                     .DisposeWith(disposables);
                  this.BindValidation(ViewModel, vm => vm.ConfirmPassword, v => v.ConfirmPasswordValidation.Text)
                      .DisposeWith(disposables);
                  this.BindValidation(ViewModel, vm => vm.Email, v => v.EmailValidation.Text)
                      .DisposeWith(disposables);
            });
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}