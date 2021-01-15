using Contracts.Requests;
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
    /// Interaction logic for ReviewParcelPage.xaml
    /// </summary>
    public partial class ReviewParcelPage : Page
    {

        ObservableCollection<PackageDto> listOfPackages = new ObservableCollection<PackageDto>();

        public ReviewParcelPage()
        {
            InitializeComponent();


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
