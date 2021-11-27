using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using front.ViewModels;
using ReactiveUI;

namespace front.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.WhenActivated(disposables => { });
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}