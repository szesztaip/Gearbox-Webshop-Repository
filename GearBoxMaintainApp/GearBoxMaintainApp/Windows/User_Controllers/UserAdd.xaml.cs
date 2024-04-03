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
using GearBoxMaintainApp.Tool_Classes;

namespace GearBoxMaintainApp.Windows.User_Controllers
{
    /// <summary>
    /// Interaction logic for UserAdd.xaml
    /// </summary>
    public partial class UserAdd : Window
    {
        string token;
        public UserAdd(string tok)
        {
            token = tok;
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            RegisztracioDto regisztracio = new RegisztracioDto
            {
                felhasznalonev = Username.Text,
                telefonszam = Phonenumber.Text,
                email = Email.Text,
                jelszo = Password.Text
            };

            if ((regisztracio.email.Contains("@") && regisztracio.email.Contains(".hu")) || (regisztracio.email.Contains("@") && regisztracio.email.Contains(".com")))
            {
                byte uccc = 0;
                byte occc = 0;

                foreach (var item in regisztracio.email)
                {
                    if (item == '@')
                    {
                        occc++;
                    }
                }

                if (occc>1)
                {
                    MessageBox.Show("Invalid email address");
                }
                else
                {
                    foreach (var item in regisztracio.email.Split('@')[1])
                    {
                        if (item == '.')
                        {
                            uccc++;
                        }
                    }

                    if (uccc > 1)
                    {
                        MessageBox.Show("Invalid email address");
                    }
                    else
                    {
                        MessageBox.Show(CRUD.Registration(token, regisztracio));
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid email address");
            }



        }
    }
}
