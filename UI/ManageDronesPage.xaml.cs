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
    /// Logika interakcji dla klasy ManageDronesPage.xaml
    /// </summary>
    public partial class ManageDronesPage : Page
    {

        ObservableCollection<DroneDto> listOfDrones = new ObservableCollection<DroneDto>();
        ObservableCollection<string> listOfLocations = new ObservableCollection<string>();

        public ManageDronesPage()
        {
            InitializeComponent();
            LoadDrones();
            LoadLocations();

            AddDronButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
            DeleteDronButton.IsEnabled = false;
        }

        private async void LoadLocations()
        {
            if (await SortingManager.Get())
            {
                listOfLocations = new ObservableCollection<string>();

                foreach (var location in State.AdminSortings)
                {
                    listOfLocations.Add(location.Name);
                }

                TypeOfSorting.ItemsSource = listOfLocations;
            }
        }

        private async void LoadDrones()
        {
            if (await DroneManager.GetDrones())
            {
                listOfDrones = new ObservableCollection<DroneDto>();

                foreach (var drones in State.AdminDrones)
                {
                    listOfDrones.Add(drones);
                }

                DroneListView.ItemsSource = listOfDrones;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            State.AdminDrones = null;
            var mainWindow = (MainWindow)Application.Current.MainWindow;
        }

        private void DroneListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DroneListView.SelectedIndex == -1)
            {
                AddDronButton.Content = "Dodaj";
                TypeOfSorting.IsEnabled = false;
                TypeOfSorting.SelectedIndex = -1;
                DeleteDronButton.IsEnabled = false;
            }
            else
            {
                TypeOfSorting.IsEnabled = true;
                DeleteDronButton.IsEnabled = true;
                State.SelectedDrone = DroneListView.SelectedItem as DroneDto;
                ShowDroneDetails();
                AddDronButton.Content = "Przenieś do innej sortowni";
                ModelField.IsEnabled = false;
                RangeField.IsEnabled = false;
            } 
        }

        private void ShowDroneDetails()
        {
            ModelField.Text = State.SelectedDrone.Model;
            RangeField.Text = State.SelectedDrone.Range.ToString();
            TypeOfSorting.SelectedItem = State.SelectedDrone.SortingName;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HasSomethingChanged();
        }

        private void HasSomethingChanged()
        {
            if (State.SelectedDrone == null)
            {
                if (ModelField.Text == string.Empty || RangeField.Text == string.Empty || TypeOfSorting.SelectedIndex == -1)
                {
                    AddDronButton.IsEnabled = false;
                }
                else
                {
                    AddDronButton.IsEnabled = true;
                }
            }
            else
            {
                if (TypeOfSorting.SelectedItem == State.SelectedDrone.SortingName)
                {
                    AddDronButton.IsEnabled = false;
                }
                else
                {
                    AddDronButton.IsEnabled = true;
                }
            }
        }

        private void SelectSortButton_Click(object sender, RoutedEventArgs e)
        {
            string miasto = TypeOfSorting.SelectedItem.ToString();

            TypeOfSorting.SelectedIndex = -1;
            DroneListView.SelectedIndex = -1;
        }

        private async void DeleteDronButton_Click(object sender, RoutedEventArgs e)
        {
            if (await DroneManager.DeleteDrone(State.SelectedDrone.Id))
            {
                DroneListView.SelectedIndex = -1;
                TypeOfSorting.SelectedIndex = -1;
                State.SelectedDrone = null;
                LoadDrones();
            }
        }


        private async void AddDronButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelField.Text == "" || RangeField.Text == "")
            {
                MessageBox.Show("Pola nei moga byc puste");
            }
            else
            {
                if (State.SelectedDrone == null)
                {
                    var range = Convert.ToInt32(RangeField.Text);
                    var sortingId = State.AdminSortings.ElementAt(TypeOfSorting.SelectedIndex).Id;

                    if (await DroneManager.AddDrone(ModelField.Text, range, sortingId))
                    {
                        LoadDrones();
                        ModelField.Text = "";
                        RangeField.Text = "";
                        TypeOfSorting.SelectedIndex = -1;
                    }
                }
                else
                {
                    if (await DroneManager.ChangeDroneLocation(State.SelectedDrone.Id, State.AdminSortings.ElementAt(TypeOfSorting.SelectedIndex).Id))
                    {
                        LoadDrones();
                        ModelField.Text = "";
                        RangeField.Text = "";
                        TypeOfSorting.SelectedIndex = -1;
                    }
                }

            }
        }

        private void TextFieldChanged(object sender, TextChangedEventArgs e)
        {
            HasSomethingChanged();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            State.SelectedDrone = null;
            ModelField.IsEnabled = true;
            RangeField.IsEnabled = true;
            DroneListView.SelectedIndex = -1;
            DeleteDronButton.IsEnabled = false;
        }
    }
}
