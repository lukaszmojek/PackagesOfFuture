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
using Contracts;
using Contracts.Requests;
using ResourceEnums;

namespace UI
{
    /// <summary>
    /// Interaction logic for SendParcelPage.xaml
    /// </summary>
    public partial class SendParcelPage : Page
    {
        public SendParcelPage()
        {
            InitializeComponent();

            streetSenderField.Text = State.User.Address.Street;
            houseSenderField.Text = State.User.Address.HouseAndFlatNumber;
            codeSenderField.Text = State.User.Address.PostalCode;
            citySenderField.Text = State.User.Address.City;

            streetSenderField.IsEnabled = false;
            houseSenderField.IsEnabled = false;
            codeSenderField.IsEnabled = false;
            citySenderField.IsEnabled = false;
        }

        int[,] cennik = new int[3, 3] { { 10, 15, 20 }, { 12, 17, 22 }, { 15, 20, 25 } };

        private int ValueOfParcel()
        {
            if (TypeOfParcel.SelectedValue is not null && TypeOfCourier.SelectedValue is not null)
            {
                int parcel = Int32.Parse(TypeOfParcel.SelectedValue.ToString());
                int courier = Int32.Parse(TypeOfCourier.SelectedValue.ToString());
                int price = cennik[courier, parcel];

                priceLabel.Content = price;

                return price;
            }
            return 0;
        }

        private int[] DimensionsPackage()
        {
            int parcel = Int32.Parse(TypeOfParcel.SelectedValue.ToString());

            int[] wymiary = new int[3];

            switch(parcel)
            {
                case 0:
                    wymiary = new int[] {10, 15, 20, 5};
                    break;
                case 1:
                    wymiary = new int[] {30, 40, 50, 10};
                    break;
                case 2:
                    wymiary = new int[] {100, 100, 100, 20};
                    break;
                default:
                    break;
            }
            return wymiary;
        }

        private PaymentType paymentType()
        {
            int payment = Int32.Parse(TypeOfPayment.SelectedValue.ToString());
            
            if(payment == 0)
            {
                return PaymentType.BankTransfer;
            }
            else if(payment == 1)
            {
                return PaymentType.Blik;
            }
            else if(payment == 2)
            {
                return PaymentType.Cash;
            }
            else
            {
                return PaymentType.Check;
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

        private async void SendParcelButton_Click(object sender, RoutedEventArgs e)
        {
            if(TypeOfParcel.SelectedValue is null || TypeOfCourier is null)
            {
                MessageBox.Show("Musisz wybrac rodzaj paczki!");
            }
            else
            {
                if (TypeOfPayment is null)
                {
                    MessageBox.Show("Wybierz rodzaj platnosci!!");
                }
                else
                {
                    if (streetSenderField.Text == "" || houseSenderField.Text == "" || codeSenderField.Text == "" || citySenderField.Text == "" || streetReceiverField.Text == "" || houseReceiverField.Text == "" || codeReceiverField.Text == "" || cityReceiverField.Text == "")
                    {
                        MessageBox.Show("Pola adresowe nie mogą być puste!");
                    }
                    else
                    {
                        AddressDto deliveryAddress = new AddressDto();
                        AddressDto pickUpAddress = new AddressDto();
                        PackageDetailsDto package = new PackageDetailsDto();
                        int serviceID;
                        CreatePaymentDto payment = new CreatePaymentDto();

                        pickUpAddress.Street = streetSenderField.Text;
                        pickUpAddress.HouseAndFlatNumber = houseSenderField.Text;
                        pickUpAddress.PostalCode = codeSenderField.Text;
                        pickUpAddress.City = citySenderField.Text;

                        deliveryAddress.Street = streetReceiverField.Text;
                        deliveryAddress.HouseAndFlatNumber = houseReceiverField.Text;
                        deliveryAddress.PostalCode = codeReceiverField.Text;
                        deliveryAddress.City = cityReceiverField.Text;

                        int[] wymiary = DimensionsPackage();

                        package.Height = wymiary[0];
                        package.Width = wymiary[1];
                        package.Length = wymiary[2];
                        package.Weight = wymiary[3];

                        serviceID = Int32.Parse(TypeOfCourier.SelectedValue.ToString());


                        payment.Amount = ValueOfParcel();
                        payment.Type = paymentType();

                        var wynik = await PackageManager.AddPackage(deliveryAddress, pickUpAddress, package, serviceID, payment);

                        if(wynik)
                        {
                            MessageBox.Show("Paczka nadana pomyślnie");
                            var mainWindow = (MainWindow)Application.Current.MainWindow;
                            mainWindow?.ChangeView(new MainAppPage());
                            //streetSenderField.Clear();
                            //houseSenderField.Clear();
                            //codeSenderField.Clear();
                            //citySenderField.Clear();
                            //streetReceiverField.Clear();
                            //houseReceiverField.Clear();
                            //codeReceiverField.Clear();
                            //cityReceiverField.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Blad");
                        }
                    }
                }
            }
        }
    }
}
