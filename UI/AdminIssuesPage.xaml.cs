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
using Contracts.Requests;
using Logic;

namespace UI
{
    /// <summary>
    /// Logika interakcji dla klasy AdminIssuesPage.xaml
    /// </summary>
    public partial class AdminIssuesPage : Page
    {
        ObservableCollection<SupportIssueDto> listOfIssues = new ObservableCollection<SupportIssueDto>();
        public AdminIssuesPage()
        {
            InitializeComponent();

            LoadIssues();
        }

        private async void LoadIssues()
        {
            if (await UserManager.GetIssuesForSupport())
            {
                foreach (var issues in State.IssuesForSupport)
                {
                    listOfIssues.Add(issues);
                }
            }
            IssuesListView.ItemsSource = listOfIssues;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            State.IssuesForSupport = null;
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AdminPage());
        }
    }
}
