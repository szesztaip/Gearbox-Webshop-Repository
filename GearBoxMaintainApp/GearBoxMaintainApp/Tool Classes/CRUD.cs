using GearBoxMaintainApp.Dtos;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Gearbox_Back_End.Models;

namespace GearBoxMaintainApp.Tool_Classes
{
    class CRUD
    {
        #region Termekek
        public static List<Termek> GetTermekek(string token)
        {
            string url = "Termek";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string result = webClient.DownloadString(connection.Url() + url);
                return JsonConvert.DeserializeObject<List<Termek>>(result).ToList();
            }
            catch (Exception x)
            {
                MessageBox.Show("Hiba lépett fel a művelet során : " + x.Message);
                return new List<Termek>();
            }
        }

        public static string PostTermekek(string token, TermekDto termek)
        {
            string url = "Termek";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string result = webClient.UploadString(connection.Url() + url, "POST", JsonConvert.SerializeObject(termek));
                return result;
            }
            catch (Exception x)
            {

                return x.Message;
            }
        }

        public static string PutTermekek(string token, Guid id, TermekDto termek)
        {
            string url = "Termek";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string result = webClient.UploadString(connection.Url() + url + $"/{id}", "PUT", JsonConvert.SerializeObject(termek));
                return result;
            }
            catch (Exception x)
            {

                return x.Message;
            }
        }

        public static string DeleteTermek(string token, Guid id)
        {
            string url = "Termek";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;
            try
            {
                string result = webClient.UploadString(connection.Url() + url + $"/{id}", "Delete", "");
                return result;
            }
            catch (Exception x)
            {

                return x.Message;
            }

        }
        #endregion

        #region Kategoriak
        public static List<Kategoriafajtak> GetKategoriaks(string token)
        {
            string url = "Kategoriafajtak";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string result = webClient.DownloadString(connection.Url() + url);
                return JsonConvert.DeserializeObject<List<Kategoriafajtak>>(result).ToList();
            }
            catch (Exception x)
            {
                MessageBox.Show("Hiba lépett fel a művelet során : " + x.Message);
                return new List<Kategoriafajtak>();
            }
        }
        #endregion

        #region Besorolas
        public static List<Besorola> GetBesorolas(string token)
        {
            string url = "Besorolas";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string result = webClient.DownloadString(connection.Url() + url);
                return JsonConvert.DeserializeObject<List<Besorola>>(result).ToList();
            }
            catch (Exception x)
            {
                MessageBox.Show("Hiba lépett fel a művelet során : " + x.Message);
                return new List<Besorola>();
            }
        }
        #endregion

        #region Felhasznalok

        public static List<Vasarlo> GetVasarlok(string token)
        {
            string url = "Vasarlo";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string result = webClient.DownloadString(connection.Url() + url);
                return JsonConvert.DeserializeObject<List<Vasarlo>>(result).ToList();
            }
            catch (Exception x)
            {
                MessageBox.Show("Hiba lépett fel a művelet során : " + x.Message);
                return new List<Vasarlo>();
            }
        }

        public static string Registration(string token, RegisztracioDto vasarlo)
        {
            string url = "regisztracio";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string result = webClient.UploadString(connection.Url() + url, "POST", JsonConvert.SerializeObject(vasarlo));
                return result;
            }
            catch (Exception x)
            {

                return x.Message;
            }
        }

        public static string PutUser(string token, Guid id, VasarloDto vasarlo)
        {
            string url = "Vasarlo";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string result = webClient.UploadString(connection.Url() + url + $"/{id}", "PUT", JsonConvert.SerializeObject(vasarlo));
                return result;
            }
            catch (Exception x)
            {

                return x.Message;
            }
        }

        public static string DeleteUser(string token, Guid id)
        {
            string url = "Vasarlo";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;
            try
            {
                string result = webClient.UploadString(connection.Url() + url + $"/{id}", "Delete", "");
                return result;
            }
            catch (Exception x)
            {

                return x.Message;
            }

        }

        #endregion

        #region Jogosultsagok

        public static List<Jogosultsagok> GetJogok(string token)
        {
            string url = "Jogosultsag";
            Connection connection = new Connection();
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string result = webClient.DownloadString(connection.Url() + url);
                return JsonConvert.DeserializeObject<List<Jogosultsagok>>(result).ToList();
            }
            catch (Exception x)
            {
                MessageBox.Show("Hiba lépett fel a művelet során : " + x.Message);
                return new List<Jogosultsagok>();
            }
        }

        #endregion
    }
}
