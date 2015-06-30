using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Klein.Wort.Composition;
using Klein.Wort.ViewModel;
using WpfAppBar;

namespace Klein.Wort
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var root = new CompositionRoot())
            {
                var window = root.Resolve<IWindow>();

                window.ShowDialog();
            }
        }
    }
}
