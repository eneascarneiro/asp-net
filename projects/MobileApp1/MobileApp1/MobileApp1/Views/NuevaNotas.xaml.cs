using MobileApp1.Models;
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
    public partial class NuevaNotas : ContentPage
    {
        public Item Item { get; set; }

        public NuevaNotas()
        {
            InitializeComponent();
            BindingContext = new NewNotasViewModel();
        }
    }
}