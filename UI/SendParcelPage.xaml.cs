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

namespace UI
{
    /// <summary>
    /// Logika interakcji dla klasy SendParcelPage.xaml
    /// </summary>
    public partial class SendParcelPage : Page
    {
        public SendParcelPage()
        {
            InitializeComponent();
        }

        int[,] cennik = new int[3, 3] { { 10, 15, 20 }, { 12, 17, 22 }, { 15, 20, 25 } };

        void ValueOfParcel()
        {
            if (TypeOfParcel.SelectedValue is not null && TypeOfCourier.SelectedValue is not null)
            {
                int parcel = Int32.Parse(TypeOfParcel.SelectedValue.ToString());
                int courier = Int32.Parse(TypeOfCourier.SelectedValue.ToString());
                int price = cennik[courier, parcel];

                priceLabel.Content = price;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainAppPage());
        }

        private void TypeOfParcel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValueOfParcel();
        }

        private void TypeOfCourier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValueOfParcel();
        }

        private void TypeOfPayment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TestLabel.Content = TypeOfPayment.SelectedValue;
        }

        private void SendParcelButton_Click(object sender, RoutedEventArgs e)
        {
               
        }
    }
}
