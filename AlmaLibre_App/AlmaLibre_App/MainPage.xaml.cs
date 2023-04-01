using AlmaLibre_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;


namespace AlmaLibre_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            string productCode = ProductCode.Text;
            string ipserver = ServerAddressEntry.Text;



            string url = "http://" + ipserver + "/JoresWS/api/producto/" + productCode;
            
            try
            {
                HttpClient cliente = new HttpClient();
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                string respuestastring = await respuesta.Content.ReadAsStringAsync();

                Producto encontrado = JsonConvert.DeserializeObject<Producto>(respuestastring);
                if (encontrado.ProductoId != 0)
                {
                    ProductDetails.IsVisible = true;
                    ProductDetails.BindingContext = encontrado;
                }
                else
                {
                    await DisplayAlert("Error", "Producto no encontrado", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se encuentra el servidor, actualice la dirección IP", "OK");
            }
        }
    }

}


