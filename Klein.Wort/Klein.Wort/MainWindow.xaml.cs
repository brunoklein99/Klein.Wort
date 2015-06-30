using System;
using System.Windows;
using Klein.Wort.ViewModel;
using WpfAppBar;

namespace Klein.Wort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            InitializeComponent();

            DataContext = viewModel;
        }

        public void MainWindow_OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            AppBarFunctions.SetAppBar(this, ABEdge.Top);
        }
    }
}
