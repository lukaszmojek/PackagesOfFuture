using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Logic;
using ResourceEnums;

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
            if (passwordField.Password == "" || loginField.Text == "")
            {
                MessageBox.Show("Pola nie moga byc puste!!!");
            }
            else
            {
                string login = loginField.Text;
                string password = passwordField.Password;

                var wynik = await UserManager.LogIn(login, password);
                
                if (wynik)
                {
                    var user = State.User;
                    if(user.Type == UserType.Administrator)
                    {
                        var mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow?.ChangeView(new AdminPage());
                    }
                    else
                    {
                        var mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow?.ChangeView(new MainAppPage());
                    }
                }
                else
                {
                    MessageBox.Show("Zły login lub haslo");
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
