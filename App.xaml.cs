using System;
using System.Windows;
using System.Text;
namespace ProSwapperFOV
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}
