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
using Contracts.Requests;
using System.Text.RegularExpressions;
using ResourceEnums;

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

            
            var user = State.User;
            if (user?.Type == UserType.Administrator)
            {

            }
            else
            {
                TypeOfAccount.SelectedIndex = 0;
                TypeOfAccount.IsEnabled = false;
            }


        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            var user = State.User;
            if (user?.Type == UserType.Administrator)
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new AdminPage());
            }
            else
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new StartupPage());
            }


        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if(nameField.Text == "" || lastNameField.Text == "" || emailField.Text == "" || passwordField.Password == "" || confirmPasswordField.Password == "" || streetField.Text == "" || houseField.Text == "" || codeField.Text == "" || cityField.Text == "")
            {
                MessageBox.Show("Zadne pole nie moze byc puste!!!");
            }
            else
            {
                RegisterButton.IsEnabled = false;
                if(passwordField.Password == confirmPasswordField.Password)
                {
                    CreateAddressDto address = new CreateAddressDto();
                    address.City = cityField.Text;
                    address.HouseAndFlatNumber = houseField.Text;
                    address.PostalCode = codeField.Text;
                    address.Street = streetField.Text;
                    string name = nameField.Text;
                    string lastName = lastNameField.Text;
                    string email = emailField.Text;
                    string password = passwordField.Password;
                    int type = Int32.Parse(TypeOfAccount.SelectedValue.ToString());
                    var wynik = await UserManager.Register(name, lastName, email, type, password, address);
                    
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
                        RegisterButton.IsEnabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Hasla musza byc takie same");
                    RegisterButton.IsEnabled = true;
                    passwordField.Clear();
                    confirmPasswordField.Clear();
                }
            }
        }
    }
}
