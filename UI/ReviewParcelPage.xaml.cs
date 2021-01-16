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
using Logic;

namespace UI
{

    
    /// <summary>
    /// Interaction logic for ReviewParcelPage.xaml
    /// </summary>
    public partial class ReviewParcelPage : Page
    {

        ObservableCollection<PackageDto> listOfPackages = new ObservableCollection<PackageDto>();

        public ReviewParcelPage()
        {
            InitializeComponent();

            LoadPackages();
        }

        private async void LoadPackages()
        {
            if (await PackageManager.GetUserPackage(State.User.Id))
            {
                foreach (var package in State.UserPackages)
                {
                    listOfPackages.Add(package);
                }
            }

            PackagesListView.ItemsSource = listOfPackages;
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainAppPage());
        }

        private void PackagesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
