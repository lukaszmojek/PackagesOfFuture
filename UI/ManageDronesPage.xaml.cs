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
    /// Logika interakcji dla klasy ManageDronesPage.xaml
    /// </summary>
    public partial class ManageDronesPage : Page
    {

        ObservableCollection<DroneDto> listOfDrones = new ObservableCollection<DroneDto>();

        public ManageDronesPage()
        {
            InitializeComponent();
            LoadComboBox();
            LoadDrones();

            AddDronButton.IsEnabled = false;
            SelectSortButton.IsEnabled = false;
            DeleteDronButton.IsEnabled = false;

            

        }

        ObservableCollection<string> test2 = new ObservableCollection<string>() { "raz", "dwa", "trzy" };
        private void LoadComboBox()
        {
            TypeOfSorting.ItemsSource = test2;
        }

        private async void LoadDrones()
        {
            if (await DroneManager.GetDrones())
            {
                foreach (var drones in State.AdminDrones)
                {
                    listOfDrones.Add(drones);
                }
            }
            DroneListView.ItemsSource = listOfDrones;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            State.AdminDrones = null;
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AdminPage());
        }

        private void DroneListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DroneListView.SelectedIndex == -1)
            {
                TypeOfSorting.IsEnabled = false;
                TypeOfSorting.SelectedIndex = -1;
                DeleteDronButton.IsEnabled = false;
            }
            else
            {
                TypeOfSorting.IsEnabled = true;
                DeleteDronButton.IsEnabled = true;
            } 
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeOfSorting.SelectedIndex == -1)
                SelectSortButton.IsEnabled = false;
            else
                SelectSortButton.IsEnabled = true;
        }

        private void SelectSortButton_Click(object sender, RoutedEventArgs e)
        {
            string miasto = TypeOfSorting.SelectedItem.ToString();

            TypeOfSorting.SelectedIndex = -1;
            DroneListView.SelectedIndex = -1;
        }

        private void DeleteDronButton_Click(object sender, RoutedEventArgs e)
        {
            DroneListView.SelectedIndex = -1;
        }


        private void AddDronButton_Click(object sender, RoutedEventArgs e)
        {
            if(ModelField.Text == "" || RangeField.Text == "")
            {
                MessageBox.Show("Pola nei moga byc puste");
            }
            else
            {
                ModelField.Text = "";
                RangeField.Text = "";
            }
        }

        private void TextFieldChanged(object sender, TextChangedEventArgs e)
        {
            if (ModelField.Text != "" || RangeField.Text != "")
                DroneListView.SelectedIndex = -1;

            if (ModelField.Text == "" && RangeField.Text == "")
                AddDronButton.IsEnabled = false;
            else
                AddDronButton.IsEnabled = true;
        }
    }
}
