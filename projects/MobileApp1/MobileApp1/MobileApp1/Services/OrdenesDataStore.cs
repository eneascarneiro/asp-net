using MobileApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp1.Services
{
    
    public class OrdenesDataStore : IDataStoreOrdenes<Orden>
    {
        List<Orden> items;
        ObservableCollection<Orden> CollectionInterna;
        public OrdenesDataStore()
        {
            items = new List<Orden>();
        }

        public async Task<bool> AddItemAsync(Orden item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }
        public async Task<ObservableCollection<Orden>> ReadFromApi(WebApiOrders _WebApiOrders)
        {
            ObservableCollection<Orden> CollectionInterna = await _WebApiOrders.RefreshDataAsync();



            return CollectionInterna;
        }

        public async Task<bool> UpdateItemAsync(Orden item)
        {
            var oldItem = items.Where((Orden arg) => arg.OrderID == item.OrderID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Orden arg) => arg.OrderID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Orden> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.OrderID == id));
        }

        public async Task<IEnumerable<Orden>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
