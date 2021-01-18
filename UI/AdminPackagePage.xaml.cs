using Contracts.Dtos;
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
    /// Logika interakcji dla klasy AdminPackagePage.xaml
    /// </summary>
    public partial class AdminPackagePage : Page
    {

        ObservableCollection<PackageDto> listOfPackages = new ObservableCollection<PackageDto>();
        public AdminPackagePage()
        {
            InitializeComponent();

            LoadPackages();
        }

        private async void LoadPackages()
        {
            if (await PackageManager.GetAdminPackage())
            {
                listOfPackages = new ObservableCollection<PackageDto>();

                foreach (var package in State.AdminPackages)
                {
                    listOfPackages.Add(package);
                }
            }

            PackagesListView.ItemsSource = listOfPackages;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            State.AdminPackages = null;
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AdminPage());
        }
    }
}
