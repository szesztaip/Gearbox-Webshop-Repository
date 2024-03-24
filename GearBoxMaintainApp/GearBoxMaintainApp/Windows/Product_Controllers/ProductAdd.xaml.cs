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
using Gearbox_Back_End.Models;

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
                Category.Items.Add(item.Id + " - " + item.KategoriaNev);
            }
            Category.SelectedIndex = 0;

            List<Besorola> cuccs = new List<Besorola>();
            cuccs = CRUD.GetBesorolas(tok);
            foreach (var item in cuccs)
            {
                SortType.Items.Add(item.Nev + " | " + item.Id.ToString());
            }
            SortType.SelectedIndex = 0;
        }

        public static int Checker(string c)
        {
            if (int.TryParse(c, out int g))
            {
                return g;
            }
            else
            {
                return 0;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TermekDto termek = new TermekDto();
            termek.nev = Name.Text;
            termek.kategoria = Checker((Category.SelectedItem as String).Split('-')[0].Trim());
            termek.besorolasId = Guid.Parse((SortType.SelectedItem as string).Split("|")[1].Trim());
            termek.meret = Size.Text;
            termek.leiras = Discription.Text;
            termek.db = Checker(Amount.Text);
            if (Checker(Amount.Text) > 0)
            {
                termek.vanEraktaron = true;
            }
            else
            {
                termek.vanEraktaron = false;
            }
            termek.ar = Checker(Price.Text);
            termek.kep = Picture.Text;

            MessageBox.Show(CRUD.PostTermekek(tok, termek));
        }
    }
}
