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
using Logic;

namespace UI
{
    /// <summary>
    /// Logika interakcji dla klasy ChangeDataPage.xaml
    /// </summary>
    public partial class ChangeDataPage : Page
    {
        public ChangeDataPage()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            nameField.Text = State.User.FirstName;
            lastNameField.Text = State.User.LastName;
            streetField.Text = State.User.Address.Street;
            houseField.Text = State.User.Address.HouseAndFlatNumber;
            codeField.Text = State.User.Address.PostalCode;
            cityField.Text = State.User.Address.City;

            ChangeButton.IsEnabled = false;
        }

        private void CheckData()
        {
            if( (nameField.Text != State.User.FirstName) || (lastNameField.Text != State.User.LastName) || (streetField.Text != State.User.Address.Street) || (houseField.Text != State.User.Address.HouseAndFlatNumber) || (codeField.Text != State.User.Address.PostalCode) || (cityField.Text != State.User.Address.City))
            {
                ChangeButton.IsEnabled = true;
            }
            else
            {
                ChangeButton.IsEnabled = false;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainAppPage());
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            String name = nameField.Text;
            String lastName = lastNameField.Text;
            String street = streetField.Text;
            String house = houseField.Text;
            String code = codeField.Text;
            String city = cityField.Text;

            State.User.FirstName = name;
            State.User.LastName = lastName;
            State.User.Address.Street = street;
            State.User.Address.HouseAndFlatNumber = house;
            State.User.Address.PostalCode = code;
            State.User.Address.City = city;
        }

        private void TextChangedFunction(object sender, TextChangedEventArgs e)
        {
            CheckData();
        }
    }
}
