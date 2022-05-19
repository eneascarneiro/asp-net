using MobileApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaNotas : ContentPage
    {
        ItemsNotasViewModel _viewModel;

        public ListaNotas()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsNotasViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}