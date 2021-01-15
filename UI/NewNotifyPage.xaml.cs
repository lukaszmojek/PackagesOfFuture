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
    /// Interaction logic for NewNotifyPage.xaml
    /// </summary>
    public partial class NewNotifyPage : Page
    {
        public NewNotifyPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainAppPage());
        }

        private async void NewNotifyButton_Click(object sender, RoutedEventArgs e)
        {
            String description = NotifyDescription.Text;

            var wynik = await UserManager.NewIssue(State.User.Id, description);

            if(wynik)
            {
                MessageBox.Show("Zgloszenie przyjete");
                NotifyDescription.Clear();
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new MainAppPage());
            }
            else
            {
                MessageBox.Show("Blad");
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new MainAppPage());
            }
        }
    }
}
