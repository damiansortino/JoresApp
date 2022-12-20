using AlmaLibre_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlmaLibre_App
{
    public partial class MainPage : ContentPage
    {
        private string urlservicio = "http://192.168.77.106/AlmaLibre/Api/Producto/";
        
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void barra_busqueda_SearchButtonPressed(object sender, EventArgs e)
        {
            string codigo = barra_busqueda.Text;

            Buscarproducto(codigo);
        }

        private async void Buscarproducto(string codigo)
        {
            string url = urlservicio;
            url = url + codigo;

            HttpClient cliente = new HttpClient();
            HttpResponseMessage respuesta = await cliente.GetAsync(url);
            string respuestastring = await respuesta.Content.ReadAsStringAsync();

            Producto encontrado = JsonConvert.DeserializeObject<Producto>(respuestastring);
            List<Producto> filtrados = new List<Producto>();
            filtrados.Add(encontrado);

            MyCollectionView.ItemsSource = filtrados;
        }
    }
}

