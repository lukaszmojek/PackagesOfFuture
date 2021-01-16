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
using Logic;


namespace UI
{
    /// <summary>
    /// Interaction logic for ReviewNotifyPage.xaml
    /// </summary>
    public partial class ReviewNotifyPage : Page
    {
        ObservableCollection<SupportIssueDto> listOfIssues = new ObservableCollection<SupportIssueDto>();

        public ReviewNotifyPage()
        {
            InitializeComponent();
            LoadIssues();
        }


        private async void LoadIssues()
        {
            if (await UserManager.GetIssuesForUser(State.User.Id))
            {
                foreach (var issues in State.IssuesForUser)
                {
                    listOfIssues.Add(issues);
                }
            }
            IssuesListView.ItemsSource = listOfIssues;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainAppPage());
        }
    }
}
