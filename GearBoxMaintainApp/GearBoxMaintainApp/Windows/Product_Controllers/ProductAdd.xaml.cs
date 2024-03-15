using GearBoxMaintainApp.Tool_Classes;
using Newtonsoft.Json;
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
using GearBoxMaintainApp.Dtos;

namespace GearBoxMaintainApp.Windows.Product
{
    /// <summary>
    /// Interaction logic for ProductAdd.xaml
    /// </summary>
    public partial class ProductAdd : Window
    {
        string tok;
        public ProductAdd(string token)
        {
            tok = token;
            InitializeComponent();
            List<Kategoriafajtak> cucc = new List<Kategoriafajtak>();
            cucc = CRUD.GetKategoriaks(tok);
            foreach (var item in cucc)
            {
                Category.Items.Add(item.Id+" - "+item.KategoriaNev);
            }
            Category.SelectedIndex = 0;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TermekDto termek = new TermekDto();
            termek.nev = Name.Text;
            termek.kategoria = Convert.ToInt32((Category.SelectedItem as String).Split('-')[0].Trim());
            termek.meret = Size.Text;
            termek.leiras = Discription.Text;
            if (int.TryParse(Amount.Text, out int s))
            {
                termek.db = Convert.ToInt32(Amount.Text);
                if (Convert.ToInt32(Amount.Text) > 0)
                {
                    termek.vanEraktaron = true;
                }
                else
                {
                    termek.vanEraktaron= false;
                }
            }
            else
            {
                termek.db=0;
            }
            if (int.TryParse(Price.Text, out int g))
            {
                termek.ar = Convert.ToInt32(Price.Text);
            }
            else
            {
                termek.ar=0;
            }
            termek.kep = Picture.Text;

            MessageBox.Show(CRUD.PostTermekek(tok,termek));
        }
    }
}
