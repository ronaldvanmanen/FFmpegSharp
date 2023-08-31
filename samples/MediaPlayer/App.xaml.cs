using System.Windows;

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var viewModel = new MainWindowViewModel();
            var view = new MainWindow
            {
                DataContext = viewModel
            };
            view.Show();
        }
    }
}
