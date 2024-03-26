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

namespace GearBoxMaintainApp.Windows.User_Controllers
{
    /// <summary>
    /// Interaction logic for UserEdit.xaml
    /// </summary>
    public partial class UserEdit : Window
    {
        string token;
        Vasarlo data = new Vasarlo(); 
        public UserEdit(string tok,Vasarlo vasarlo)
        {
            token = tok;
            data = vasarlo;
            InitializeComponent();
            
            Username.Text = vasarlo.FelhasznaloNev;
            Phonenumber.Text = vasarlo.Telefonszam;
            Email.Text = vasarlo.Email;

            var cucc = CRUD.GetJogok(token);
            for (int i=0;i<cucc.Count;i++)
            {
                Permissions.Items.Add(cucc[i].Id+" - " + cucc[i].Nev);
                if (cucc[i].Id == vasarlo.Jogosultsag)
                {
                    Permissions.SelectedIndex = i;
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            VasarloDto vasarlo = new VasarloDto()
            {
                id = data.Id,
                felhasznalonev = Username.Text,
                telefonszam = Phonenumber.Text,
                email = Email.Text,
                jelszo = data.Hash,
                jogosultsag = Convert.ToInt32((Permissions.SelectedItem as string).Split('-')[0].Trim())
            };

            MessageBox.Show(CRUD.PutUser(token,data.Id,vasarlo));
            this.Close();
        }
    }
}
