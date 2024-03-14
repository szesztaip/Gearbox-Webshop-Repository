using GearBoxMaintainApp.Dtos;
using GearBoxMaintainApp.Tool_Classes;
using GearBoxMaintainApp.Windows;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GearBoxMaintainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        Connection connection = new Connection();
        private void windowchanger_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            try
            {
                LoginDto loginDto = new LoginDto();
                loginDto.email = EmailAdress.Text;
                loginDto.jelszo = Password.Text;
                string result = webClient.UploadString(connection.Url() + "login/bejelentkezes", "POST", JsonConvert.SerializeObject(loginDto));
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(JsonConvert.DeserializeObject<Token>(result).usertoken);
                if (jwtSecurityToken.Claims.First(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value == "Admin")
                {
                    Hub eloszto = new Hub(JsonConvert.DeserializeObject<Token>(result).usertoken);
                    eloszto.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Önnek nincs hozzáférési joga az alkalmazáshoz!");
                }

            }
            catch (Exception g)
            {
                MessageBox.Show("Hiba történt a bejelentkezés alatt! : " + g.Message);
            }
        }
    }
}