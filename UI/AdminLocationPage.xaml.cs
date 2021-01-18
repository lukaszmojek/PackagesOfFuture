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
using Contracts.Dtos;

namespace UI
{
    /// <summary>
    /// Logika interakcji dla klasy AdminLocationPage.xaml
    /// </summary>
    public partial class AdminLocationPage : Page
    {
        ObservableCollection<SortingDto> listOfLocations = new ObservableCollection<SortingDto>();

        public AdminLocationPage()
        {
            InitializeComponent();
            LoadLocations();

            //DeleteButton.IsEnabled = false;
            AddLocation.IsEnabled = false;
        }

        private async void LoadLocations()
        {
            if (await SortingManager.Get())
            {
                listOfLocations = new ObservableCollection<SortingDto>();
                
                foreach (var location in State.AdminSortings)
                {
                    listOfLocations.Add(location);
                }
                
                LocationListView.ItemsSource = listOfLocations;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AdminPage());
        }

        private void LocationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LocationListView.SelectedIndex == -1)
            {
                //DeleteButton.IsEnabled = false;
                State.LocationSelectedForEditing = null;
                AddLocation.Content = "Dodaj";
                CancelButton.IsEnabled = true;
            }
            else
            {
                //DeleteButton.IsEnabled = true;
                State.LocationSelectedForEditing = LocationListView.SelectedValue as SortingDto;
                AddLocation.Content = "Edytuj";
                CancelButton.IsEnabled = true;
                ShowLocationDetails();
            }
        }

        private async void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            if (State.LocationSelectedForEditing == null)
            {
                var sortingDto = new RegisterSortingDto()
                {
                    Name = NameLocationField.Text,
                    Address = new CreateAddressDto()
                    {
                        Street = NameLocationField_Copy.Text,
                        HouseAndFlatNumber = NameLocationField_Copy1.Text,
                        City = NameLocationField_Copy2.Text,
                        PostalCode = NameLocationField_Copy3.Text,
                    }
                };

                if (await SortingManager.Register(sortingDto))
                {
                    LoadLocations();

                    ResetListView();
                }
            }
            else
            {
                var sortingDto = new ChangeSortingDetailsDto()
                {
                    Id = State.LocationSelectedForEditing.Id,
                    Name = NameLocationField.Text,
                    Address = new AddressDto()
                    {
                        Street = NameLocationField_Copy.Text,
                        HouseAndFlatNumber = NameLocationField_Copy1.Text,
                        City = NameLocationField_Copy2.Text,
                        PostalCode = NameLocationField_Copy3.Text,
                    }
                };

                if (await SortingManager.Change(sortingDto))
                {
                    LoadLocations();

                    ResetListView();
                }
            }
        }

        private void NameLocationField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (State.LocationSelectedForEditing == null)
            {
                if (NameLocationField.Text == string.Empty || NameLocationField_Copy.Text == string.Empty || NameLocationField_Copy1.Text == string.Empty || NameLocationField_Copy2.Text == string.Empty || NameLocationField_Copy3.Text == string.Empty)
                {
                    AddLocation.IsEnabled = false;
                }
                else
                {
                    AddLocation.IsEnabled = true;
                    LocationListView.SelectedIndex = -1;
                }
            }
            else
            {
                if (NameLocationField.Text != State.LocationSelectedForEditing.Name || NameLocationField_Copy.Text != State.LocationSelectedForEditing.Address.Street || NameLocationField_Copy1.Text != State.LocationSelectedForEditing.Address.HouseAndFlatNumber || NameLocationField_Copy2.Text != State.LocationSelectedForEditing.Address.City || NameLocationField_Copy3.Text != State.LocationSelectedForEditing.Address.PostalCode)
                {
                    AddLocation.IsEnabled = true;
                }
                else
                {
                    AddLocation.IsEnabled = false;
                }
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (await SortingManager.Delete(State.LocationSelectedForEditing.Id))
            {
                LoadLocations();

                ResetListView();
            }
        }

        private void CancelLocation_Click(object sender, RoutedEventArgs e)
        {
            State.LocationSelectedForEditing = null;
            CancelButton.IsEnabled = false;
            ResetListView();
        }

        private void ResetListView()
        {
            LocationListView.SelectedIndex = -1;
            NameLocationField.Clear();
            NameLocationField_Copy.Clear();
            NameLocationField_Copy1.Clear();
            NameLocationField_Copy2.Clear();
            NameLocationField_Copy3.Clear();
        }

        private void ShowLocationDetails()
        {
            NameLocationField.Text = State.LocationSelectedForEditing.Name;
            NameLocationField_Copy.Text = State.LocationSelectedForEditing.Address.Street;
            NameLocationField_Copy1.Text = State.LocationSelectedForEditing.Address.HouseAndFlatNumber;
            NameLocationField_Copy2.Text = State.LocationSelectedForEditing.Address.City;
            NameLocationField_Copy3.Text = State.LocationSelectedForEditing.Address.PostalCode;
        }
    }
}
