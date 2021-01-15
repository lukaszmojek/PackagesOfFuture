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
    /// Logika interakcji dla klasy DeleteUserPage.xaml
    /// </summary>
    public partial class DeleteUserPage : Page
    {
        ObservableCollection<UserDto> listOfNames = new ObservableCollection<UserDto>();


        public DeleteUserPage()
        {
            InitializeComponent();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            if (await UserManager.GetUsers())
            {
                foreach (var user in State.Users.Where(x => x.Id != State.User.Id))
                {
                    listOfNames.Add(user);
                }
            }

            UserListView.ItemsSource = listOfNames;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AdminPage());
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser();
        }

        private async void DeleteUser()
        {
            if (await UserManager.DeleteUser(State.UserSelectedForDeleting.Id))
            {
                State.UserSelectedForDeleting = null;
                listOfNames = new ObservableCollection<UserDto>();
                LoadUsers();
            }
        }

        private void UserListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            State.UserSelectedForDeleting = UserListView.SelectedItem as UserDto;
        }
    }
}
