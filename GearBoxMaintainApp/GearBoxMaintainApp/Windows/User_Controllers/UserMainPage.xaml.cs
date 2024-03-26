using GearBoxMaintainApp.Tool_Classes;
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
using System.Windows.Shapes;

namespace GearBoxMaintainApp.Windows.User_Controllers
{
    /// <summary>
    /// Interaction logic for UserMainPage.xaml
    /// </summary>
    public partial class UserMainPage : Window
    {
        string token;
        public UserMainPage(string tok)
        {
            token = tok;
            InitializeComponent();
            DrGrid.ItemsSource = CRUD.GetVasarlok(token);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            DrGrid.ItemsSource = CRUD.GetVasarlok(token);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            UserAdd user = new UserAdd(token);
            user.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string question = "Biztosan szeretné törölni az adott felhasználót?";
            string cap = "Figyelem!";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage image = MessageBoxImage.Warning;
            MessageBoxResult result;
            result = MessageBox.Show(question, cap, button, image);
            if (result.ToString() == "Yes")
            {
                MessageBox.Show(CRUD.DeleteUser(token, (DrGrid.SelectedItem as Vasarlo).Id));
            }
            DrGrid.ItemsSource = CRUD.GetVasarlok(token);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Hub hub = new Hub(token);
            hub.Show();
            this.Close();
        }
    }
}
