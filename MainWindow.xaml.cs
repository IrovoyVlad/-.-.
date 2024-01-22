using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp19Var.View;

namespace WpfApp19Var
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Role_OnClick(object sender, RoutedEventArgs e)
        {
            WindowRole window = new WindowRole();
            window.Show();
        }

        private void User_OnClick(object sender, RoutedEventArgs e)
        {
            WindowUser window = new WindowUser();
            window.Show();
        }

        private void Permission_OnClick(object sender, RoutedEventArgs e)
        {
            WindowPermission window = new WindowPermission();
            window.Show();
        }

        private void Assignment_OnClick(object sender, RoutedEventArgs e)
        {
            WindowAssignment window = new WindowAssignment();
            window.Show();
        }
    }
}