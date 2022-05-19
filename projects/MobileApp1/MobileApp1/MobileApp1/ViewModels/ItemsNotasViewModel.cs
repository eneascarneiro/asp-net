using MobileApp1.Models;
using MobileApp1.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp1.ViewModels
{
    public class ItemsNotasViewModel : BaseViewModelNotas
    {
        private ItemNotas _selectedItem;

        public ObservableCollection<ItemNotas> Items { get; }
        public Command LoadItemsNotasCommand { get; }
        public Command AddItemNotasCommand { get; }
        public Command<ItemNotas> ItemNotasTapped { get; }

        public ItemsNotasViewModel()
        {
            Title = "Consulta Notas";
            Items = new ObservableCollection<ItemNotas>();
            LoadItemsNotasCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemNotasTapped = new Command<ItemNotas>(OnItemSelected);

            AddItemNotasCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public ItemNotas SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(ItemNotas item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}