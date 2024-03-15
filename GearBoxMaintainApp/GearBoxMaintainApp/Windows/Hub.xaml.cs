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
    /// Interaction logic for Hub.xaml
    /// </summary>
    public partial class Hub : Window
    {
        string tok;
        public Hub(string token)
        {
            tok = token;
            InitializeComponent();
        }

        private void Productconnector_Click(object sender, RoutedEventArgs e)
        {
            ProductMain openproducteditor = new ProductMain(tok);
            openproducteditor.Show();
            this.Close();
        }
    }
}
