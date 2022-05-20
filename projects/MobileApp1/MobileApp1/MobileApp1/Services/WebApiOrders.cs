using MobileApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp1.Services
{
    public class WebApiOrders
    {
        System.Net.Http.HttpClient client;

        public string WebApiUrl {get;set;}

        public ObservableCollection<Orden> Ordenes {get;set;}

        public WebApiOrders()
        {
            client = new System.Net.Http.HttpClient();
        }
        //Metodo de refresco de ordenes
        public async Task<ObservableCollection<Orden>> RefreshDataAsync()
        {
            WebApiUrl = "https://ej2services.syncfusion.com/production/web-services/api/Orders"; // Set your REST API URL here.
            var uri = new Uri(WebApiUrl);
            try
            {
                var response = await client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    var ContenidoRespuesta = await response.Content.ReadAsStringAsync();
                    Ordenes = JsonConvert.DeserializeObject<ObservableCollection<Orden>>(ContenidoRespuesta);
                    return Ordenes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
           

        }
    }
}
