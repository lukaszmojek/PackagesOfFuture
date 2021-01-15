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
    /// Logika interakcji dla klasy RecoverPasswordPage.xaml
    /// </summary>
    public partial class RecoverPasswordPage : Page
    {
        public RecoverPasswordPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new LoginPage());
        }

        private void RecoverPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            
            if(emailField.Text == "" || nameField.Text == "" || lastNameField.Text == "")
            {
                MessageBox.Show("Zadne pole nie moze byc puste!");
            }
            else
            {
                string haslo = "bajojajo";
                recoverPasswordLabel.Content = "Hasło: " + haslo;
            }

            
        }
    }
}
