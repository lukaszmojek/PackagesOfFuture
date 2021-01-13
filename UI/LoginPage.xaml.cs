using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Logic;

namespace UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
      
        public LoginPage()
        {
            InitializeComponent();    
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new StartupPage());
        }

        private async void LogInButton_Click(object sender, RoutedEventArgs e)
        {

            
            if (PasswordField.Password == "" || LoginField.Text == "")
            {
                testowyLabel.Content = "Login/hasło nie może być puste!";
            }
            else
            {
                string login = LoginField.Text;
                string password = PasswordField.Password;

                var wynik = await UserManager.LogIn(login, password);
                
                if (wynik)
                {
                    var user = State.User;
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow?.ChangeView(new MainAppPage());
                }
                else
                {
                    testowyLabel.Visibility = Visibility.Visible;
                    testowyLabel.Content = "Zły login lub hasło";
                }
            }

            testowyLabel.Visibility = await Task.Delay(3000).ContinueWith(_ =>
            {
                return Visibility.Hidden;
            });
        }

        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new RecoverPasswordPage());
        }

        private void GoToNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainAppPage());
        }
    }
}
