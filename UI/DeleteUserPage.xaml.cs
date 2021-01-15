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
    /// Logika interakcji dla klasy DeleteUserPage.xaml
    /// </summary>
    public partial class DeleteUserPage : Page
    {
        ObservableCollection<PersonData> listOfNames = new ObservableCollection<PersonData>();

        class PersonData
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
        }


        public DeleteUserPage()
        {
            InitializeComponent();
            test();
        }

        private async void test()
        {
            var wynik = await UserManager.GetUsers();

            
            listOfNames.Add(new PersonData() { Name = "Test", Age = 20, Email = "email@int.pl3" });
            listOfNames.Add(new PersonData() { Name = "Test2", Age = 203, Email = "email@int.pl4" });
            listOfNames.Add(new PersonData() { Name = "Test3", Age = 204, Email = "email@int.pl5" });

            UserListView.ItemsSource = listOfNames;

            
            labelTest.Content = State.Users.First().Email;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AdminPage());
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {

           // listOfNames.Add("test");

            //UserListView.Items.Add("test");

            //int test UserListView.SelectedIndex;
            //listOfNames.RemoveAt(test);


            //UserListView.Items.RemoveAt(test)
        }

    }
}
