using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Contracts.Requests;
using Logic;

namespace UI
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            State.User = null;
            State.Password = null;

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new StartupPage());
        }

        private void ClearField()
        {
            cityField.Clear();
            houseField.Clear();
            codeField.Clear();
            streetField.Clear();
            nameField.Clear();
            lastNameField.Clear();
            emailField.Clear();
            passwordField.Clear();
            confirmPasswordField.Clear();
            accountTypeBox.SelectedIndex = -1;
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameField.Text == "" || lastNameField.Text == "" || emailField.Text == "" || passwordField.Password == "" || confirmPasswordField.Password == "" || streetField.Text == "" || houseField.Text == "" || codeField.Text == "" || cityField.Text == "" || accountTypeBox.SelectedValue is null)
            {
                MessageBox.Show("Zadne pole nie moze byc puste!!!");
                passwordField.Clear();
                confirmPasswordField.Clear();
            }
            else
            {
                if (passwordField.Password == confirmPasswordField.Password)
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
                    int type = Int32.Parse(accountTypeBox.SelectedValue.ToString()); ;
                    var wynik = await UserManager.Register(name, lastName, email, type, password, address);

                    if (wynik)
                    {
                        MessageBox.Show("Rejestracja przebiegla pomyslnie");
                        ClearField();
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

        private void CancelRegisterField_Click(object sender, RoutedEventArgs e)
        {
            ClearField();
        }
    }
}
