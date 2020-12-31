using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Contracts;
using Api.Contracts.Responses;
using Logic;
using Newtonsoft.Json;

namespace UI
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
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
                MessageBox.Show("Login/hasło nie może być puste!");
            }
            else
            {
                string login = LoginField.Text;
                string password = PasswordField.Password;

                var wynik = await UserManager.Loguj(login, password);
                
                if(wynik)
                {
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow?.ChangeView(new MainAppPage());
                }
                else
                {
                    MessageBox.Show("Zły login lub hasło");
                    testowyLabel.Content = "Bledne haslo lub login";
                }
            }   
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
