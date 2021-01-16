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
using Data.Entities;
using Logic;
using ResourceEnums;

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

        private async void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            await HandleStatusChange(SupportIssueStatus.Cancelled);
        }

        private async void ResolveButton_Click(object sender, RoutedEventArgs e)
        {
            await HandleStatusChange(SupportIssueStatus.Resolved);
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            await HandleStatusChange(SupportIssueStatus.Investigation);
        }

        private async Task HandleStatusChange(SupportIssueStatus status)
        {
            SetButtonState(false);

            if (await UserManager.ChangeSupportIssueStatus(State.SelectedSupportIssue.Id, status))
            {
                listOfIssues = new ObservableCollection<SupportIssueDto>();
                LoadIssues();
            }

            SetButtonState(true);
        }

        private void SetButtonState(bool state)
        {
            CancelButton.IsEnabled = state;
            ResolveButton.IsEnabled = state;
            StartButton.IsEnabled = state;
        }

        private void IssuesListView_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            State.SelectedSupportIssue = IssuesListView.SelectedItem as SupportIssueDto;
        }
    }
}
