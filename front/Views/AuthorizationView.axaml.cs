using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using front.ViewModels;
using ReactiveUI;

namespace front.Views
{
    public partial class AuthorizationView : ReactiveUserControl<AuthorizationViewModel>
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