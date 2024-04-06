using GearBoxMaintainApp.Tool_Classes;
using GearBoxMaintainApp.Windows.Product;
using GearBoxMaintainApp.Windows.Product_Controllers;
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

namespace GearBoxMaintainApp.Windows
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class ProductMain : Window
    {
        string tok;
        public ProductMain(string token)
        {
            tok = token;
            InitializeComponent();
            DrGrid.ItemsSource = CRUD.GetTermekek(tok);
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            DrGrid.ItemsSource = CRUD.GetTermekek(tok);
        }

        private void Add_Product_Click(object sender, RoutedEventArgs e)
        {
            ProductAdd productadd = new ProductAdd(tok);
            productadd.ShowDialog();
            DrGrid.ItemsSource = CRUD.GetTermekek(tok);

        }

        private void Delete_Product_Click(object sender, RoutedEventArgs e)
        {
            string question = "Biztosan szeretné törölni az adott terméket?";
            string cap = "Figyelem!";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage image = MessageBoxImage.Warning;
            MessageBoxResult result;
            result = MessageBox.Show(question,cap, button, image);
            if (result.ToString() == "Yes")
            {
                MessageBox.Show(CRUD.DeleteTermek(tok, (DrGrid.SelectedItem as Termek).Id));
            }
            DrGrid.ItemsSource = CRUD.GetTermekek(tok);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (DrGrid.SelectedItem != null)
            {
                ProductEdit edit = new ProductEdit(tok, (DrGrid.SelectedItem as Termek));
                edit.ShowDialog();
                DrGrid.ItemsSource = CRUD.GetTermekek(tok);
            }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Hub hub = new Hub(tok);
            hub.Show();
            this.Close();
        }

        private void PictureUploader_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileDialog = new Microsoft.Win32.OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.DefaultExt = ".png";
                fileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";

                // Show the dialog and check if the user selected a file
                if (fileDialog.ShowDialog() == true)
                {
                    if (CRUD.FTPUploader(fileDialog.FileName))
                    {
                        MessageBox.Show("Upload succesfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed Upload!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
