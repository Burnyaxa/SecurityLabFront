using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using front.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace front.Views
{
    [DoNotNotify]
    public class RegistrationView : ReactiveUserControl<RegistrationViewModel>
    {
        public RegistrationView()
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