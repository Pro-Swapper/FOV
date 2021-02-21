using System.Windows;
using System.Windows.Input;
using System.IO;
using ProSwapperFOV.Properties;
using System.Windows.Forms;
using System.Diagnostics;
namespace ProSwapperFOV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //Get's user's GameUserSettings.ini
            if (!File.Exists(Settings.Default.GameDir))
            {
                Settings.Default.GameDir = GameFileEditor.fndir;
                Settings.Default.Save();
            }
            fndir.Text = Settings.Default.GameDir;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void FOVSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            valuelbl.Content = "Value: " + (int)FOVSlider.Value;
        }

        private void setfov_Click(object sender, RoutedEventArgs e)
        {
            int fovval = (int)FOVSlider.Value;
            GameFileEditor.SetRes(fovval.ToString(), Screen.PrimaryScreen.Bounds.Width.ToString(), 2);
            System.Windows.Forms.MessageBox.Show("Set FOV to " + fovval, "Pro Swapper FOV", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void setresbutton_Click(object sender, RoutedEventArgs e)
        {
            GameFileEditor.SetRes(yres.Text, xres.Text, 0);
            System.Windows.Forms.MessageBox.Show("Set Resolution to " + xres.Text + " x " + yres.Text, "Pro Swapper Resolution Changer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            string XRes = Screen.PrimaryScreen.Bounds.Width.ToString();
            string YRes = Screen.PrimaryScreen.Bounds.Height.ToString();
            GameFileEditor.SetRes(YRes, XRes, 0);
            System.Windows.Forms.MessageBox.Show("Reset the resolution to normal", "Pro Swapper Resolution Changer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void launchfn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("com.epicgames.launcher://apps/Fortnite?action=launch&silent=false");
            System.Windows.Application.Current.Shutdown();
        }

        private void xres_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((System.Windows.Controls.TextBox)sender).Text + e.Text, 1, 7680);
        }

        public static bool IsValid(string str, int min, int max)
        {
            int i;
            return int.TryParse(str, out i) && i >= min && i <= max;
        }

        private void yres_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((System.Windows.Controls.TextBox)sender).Text + e.Text, 1, 4320);
        }
    }
}
