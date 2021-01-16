using Contracts.Requests;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy AdminLocationPage.xaml
    /// </summary>
    public partial class AdminLocationPage : Page
    {
        //ObservableCollection<LocationDto> listOfLocations = new ObservableCollection<LocationDto>();

        public AdminLocationPage()
        {
            InitializeComponent();
            //LoadLocations();

            DeleteButton.IsEnabled = false;
            AddLocation.IsEnabled = false;
        }

        //private async void LoadLocations()
        //{
        //    if (await LocationManager.GetLocations())
        //    {
        //        foreach (var location in State.Locations)
        //        {
        //            listOfLocations.Add(location);
        //        }
        //    }

        //    LocationListView.ItemsSource = listOfLocations;
        //}

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AdminPage());
        }

        private void LocationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LocationListView.SelectedIndex == -1)
                DeleteButton.IsEnabled = false;
            else
                DeleteButton.IsEnabled = true;
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            NameLocationField.Clear();
        }

        private void NameLocationField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameLocationField.Text == "")
                AddLocation.IsEnabled = false;
            else
            {
                AddLocation.IsEnabled = true;
                LocationListView.SelectedIndex = -1;
            }
                
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            LocationListView.SelectedIndex = -1;
        }
    }
}
