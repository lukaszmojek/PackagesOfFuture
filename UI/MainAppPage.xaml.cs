using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainAppPage.xaml
    /// </summary>
    public partial class MainAppPage : Page
    {
        public MainAppPage()
        {
            InitializeComponent();
            
            string name = State.User?.FirstName;
            string lastName = State.User?.LastName;
            welcomeLabel.Content = "Witaj " + name + " " + lastName;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            State.User = null;
            State.Password = null;

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new StartupPage());
        }

        private void SendParcel_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new SendParcelPage());
        }

        private void ParcelReview_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ReviewParcelPage());
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ChangePasswordPage());
        }

        private void ReviewNotify_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ReviewNotifyPage());
        }

        private void NewNotify_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new NewNotifyPage());
        }
    }
}
