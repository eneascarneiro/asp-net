using MobileApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp1.Services
{
    
    public class NotesDataStore : IDataStoreNotas<ItemNotas>
    {
        readonly List<ItemNotas> items;

        public NotesDataStore()
        {
            items = new List<ItemNotas>()
            {
                new ItemNotas { Id = Guid.NewGuid().ToString(), Titulo = ".", Asistentes = ".", Description = "." }
            };
        }

        public async Task<bool> AddItemAsync(ItemNotas item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemNotas item)
        {
            var oldItem = items.Where((ItemNotas arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemNotas arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemNotas> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemNotas>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
