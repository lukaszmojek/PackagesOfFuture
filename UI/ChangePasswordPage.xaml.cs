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
using Logic;

namespace UI
{
    /// <summary>
    /// Logika interakcji dla klasy ChangePasswordPage.xaml
    /// </summary>
    public partial class ChangePasswordPage : Page
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainAppPage());
        }

        private async void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentPasswordField.Password == "" || newPasswordField.Password == "" || confirmNewPasswordField.Password == "")
            {
                MessageBox.Show("Pola nie mogą być puste");
                currentPasswordField.Clear();
                newPasswordField.Clear();
                confirmNewPasswordField.Clear();
            }
            else
            {
                if(currentPasswordField.Password != State.Password)
                {
                    MessageBox.Show("Wprowadz poprawne aktualne haslo!");
                    currentPasswordField.Clear();
                    newPasswordField.Clear();
                    confirmNewPasswordField.Clear();
                }
                else
                {
                    if (newPasswordField.Password != confirmNewPasswordField.Password)
                    {
                        MessageBox.Show("Hasla musza byc takie same");
                        currentPasswordField.Clear();
                        newPasswordField.Clear();
                        confirmNewPasswordField.Clear();
                    }
                    else
                    {
                        if(newPasswordField.Password == State.Password)
                        {
                            MessageBox.Show("Nowe haslo musi byc inne nie z stare");
                            currentPasswordField.Clear();
                            newPasswordField.Clear();
                            confirmNewPasswordField.Clear();
                        }
                        else
                        {
                            String newPassword = newPasswordField.Password;

                            var wynik = await UserManager.ChangePassword(State.User.Id, newPassword);

                            if (wynik)
                            {
                                MessageBox.Show("Haslo zmienione pomyslnie!");
                                var mainWindow = (MainWindow)Application.Current.MainWindow;
                                mainWindow?.ChangeView(new MainAppPage());
                            }
                            else
                            {
                                MessageBox.Show("Blad");
                                currentPasswordField.Clear();
                                newPasswordField.Clear();
                                confirmNewPasswordField.Clear();
                            }
                        }

                    }
                }
            }
        }
    }
}
