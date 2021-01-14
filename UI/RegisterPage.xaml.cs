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
using Logic;

namespace UI
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new StartupPage());
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if(nameField.Text == "" || lastNameField.Text == "" || emailField.Text == "" || passwordField.Password == "" || confirmPasswordField.Password == "")
            {
                MessageBox.Show("Zadne pole nie moze byc puste!!!");
            }
            else
            {
                if(passwordField.Password == confirmPasswordField.Password)
                {
                    string name = nameField.Text;
                    string lastName = lastNameField.Text;
                    string email = emailField.Text;
                    string password = passwordField.Password;
                    int type = 0;
                    var wynik = await UserManager.Register(name, lastName, email, type, password);
                    
                    if(wynik)
                    {
                        MessageBox.Show("Rejestracja przebiegla pomyslnie, przeniose cie na strone logowania");

                        var mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow?.ChangeView(new LoginPage());
                    }
                    else
                    {
                        MessageBox.Show("Rejestracja niepomyslna - zajety email");
                        emailField.Clear();
                        passwordField.Clear();
                        confirmPasswordField.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Hasla musza byc takie same");
                    passwordField.Clear();
                    confirmPasswordField.Clear();
                }
            }
        }
    }
}
