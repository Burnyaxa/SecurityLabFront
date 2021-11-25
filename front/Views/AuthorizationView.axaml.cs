using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using front.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace front.Views
{
    [DoNotNotify]
    public class AuthorizationView : ReactiveUserControl<AuthorizationViewModel>
    {
        public AuthorizationView()
        {
            this.WhenActivated(disposables => { });
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}