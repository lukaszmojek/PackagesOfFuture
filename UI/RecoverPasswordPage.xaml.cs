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
    /// Logika interakcji dla klasy RecoverPasswordPage.xaml
    /// </summary>
    public partial class RecoverPasswordPage : Page
    {
        public RecoverPasswordPage()
        {
            InitializeComponent();

            LoadUsers();
        }

        private async void LoadUsers()
        {
            var wynik = await UserManager.GetUsers();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            State.DeleteData();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new LoginPage());
        }

  

        private void RecoverPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if(emailField.Text == "" || nameField.Text == "" || lastNameField.Text == "")
            {
                MessageBox.Show("Zadne pole nie moze byc puste!");
            }
            else
            {
                String email = emailField.Text;
                String name = nameField.Text;
                String lastName = lastNameField.Text;
                String password = "";

                foreach (var user in State.Users)
                {
                    if(user.Email == email && user.FirstName == name && user.LastName== lastName)
                    {
                        password = user.Password;
                        break;
                    }
                }

                if(password != "")
                {
                    recoverPasswordLabel.Content = "Hasło: " + password;
                    RecoverPasswordButton.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Wprowadziles niepoprawne dane");
                    emailField.Clear();
                    nameField.Clear();
                    lastNameField.Clear();
                }
            }    
        }
    }
}
