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

    public partial class OrdenesView : ContentPage
    {
        OrdenesViewModel _viewModel;
        public OrdenesView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new OrdenesViewModel();
        }
 
    }
}