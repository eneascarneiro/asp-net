using MobileApp1.Models;
using MobileApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp1.ViewModels
{
    public class OrdenesViewModel : BaseViewModelOrdenes
    {
        readonly WebApiOrders _WebApiOrders;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        private ObservableCollection<Orden> ordenes;

        public OrdenesViewModel()
        {
            _WebApiOrders = new WebApiOrders();
            Ordenes = new ObservableCollection<Orden>();
            //Invocar al api para leer
            _ = GetDatosOrdenesApi1();
        }
        //Metodos y propiedades
        public ObservableCollection<Orden> Ordenes
        {
            get
            { 
                return ordenes; 
            }
            set 
            {
                ordenes = value;
                RaisepropertyChanged("Ordenes");
            }
        }
        async Task GetDatosOrdenesLocal()
        {
            IsBusy = true;

            try
            {
                Ordenes.Clear();
                await DataStore.GetItemsAsync(true);
                var ordenes = await DataStore.GetItemsAsync(true);
                foreach (var item in ordenes)
                {
                    Ordenes.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        async Task<ObservableCollection<Orden>> ReadFromApi1(WebApiOrders _WebApiOrders)
        {
            ObservableCollection<Orden> CollectionInterna = await _WebApiOrders.RefreshDataAsync();



            return CollectionInterna;
        }
        async Task GetDatosOrdenesApi1()
        {
            await GetDatosOrdenesApi();
        }
        async Task GetDatosOrdenesApi()
        {
            IsBusy = true;

            try
            {
                Ordenes.Clear();
                
                var ordenes = await ReadFromApi1(_WebApiOrders);
                foreach (var item in ordenes)
                {
                    Ordenes.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private string shipCountry;

        public string ShipCountry { get => shipCountry; set => SetProperty(ref shipCountry, value); }

        private string orderID;

        public string OrderID { get => orderID; set => SetProperty(ref orderID, value); }

        private string customerID;

        public string CustomerID { get => customerID; set => SetProperty(ref customerID, value); }


    }
}
