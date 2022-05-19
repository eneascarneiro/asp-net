using MobileApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp1.ViewModels
{

    public partial class NewNotasViewModel : BaseViewModelNotas
    {
        private string titulo;
        private string asistentes;
        private string descripcion;

        public NewNotasViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(titulo)
                && !String.IsNullOrWhiteSpace(asistentes)
                && !String.IsNullOrWhiteSpace(descripcion);
        }

        public string Titulo
        {
            get => titulo;
            set => SetProperty(ref titulo, value);
        }
        public string Asistentes
        {
            get => asistentes;
            set => SetProperty(ref asistentes, value);
        }
        public string Descripcion
        {
            get => descripcion;
            set => SetProperty(ref descripcion, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            ItemNotas newItem = new ItemNotas()
            {
                Id = Guid.NewGuid().ToString(),
                Titulo = Titulo,
                Asistentes = Asistentes,
                Description = Descripcion
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}