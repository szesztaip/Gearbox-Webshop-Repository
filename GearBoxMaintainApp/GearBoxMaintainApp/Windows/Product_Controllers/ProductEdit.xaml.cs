using GearBoxMaintainApp.Dtos;
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

namespace GearBoxMaintainApp.Windows.Product_Controllers
{
    /// <summary>
    /// Interaction logic for ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : Window
    {
        string tok;
        Termek prduct;
        public ProductEdit(string token,Termek termek)
        {
            this.tok = token;
            this.prduct = termek;
            InitializeComponent();
            Name.Text = termek.Nev;
            Size.Text = termek.Meret;
            Amount.Text = Convert.ToString(termek.Db);
            Price.Text = Convert.ToString(termek.Ar);
            Picture.Text = termek.Kep;
            Discription.Text = termek.Leiras;
            List<Kategoriafajtak> cucc = new List<Kategoriafajtak>();
            cucc = CRUD.GetKategoriaks(tok);
            for (int i = 0; i < cucc.Count; i++)
            {
                Category.Items.Add(cucc[i].Id + " - " + cucc[i].KategoriaNev);
                if (cucc[i].Id == termek.KategoriaId)
                {
                    Category.SelectedIndex = i;
                }
            }
            
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
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
                    termek.vanEraktaron = false;
                }
            }
            else
            {
                termek.db = 0;
            }
            if (int.TryParse(Price.Text, out int g))
            {
                termek.ar = Convert.ToInt32(Price.Text);
            }
            else
            {
                termek.ar = 0;
            }
            termek.kep = Picture.Text;

            MessageBox.Show(CRUD.PutTermekek(tok,prduct.Id,termek));
        }

    }
}
