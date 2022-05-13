using AppExamen2P.Models;
using AppExamen2P.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamen2P.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GasStationDetailPage : ContentPage
    {
        public GasStationDetailPage()
        {
            InitializeComponent();

            BindingContext = new GasStationDetailViewModel();
        }

        public GasStationDetailPage(GasStationModel gasStationSelected)
        {
            InitializeComponent();

            BindingContext = new GasStationDetailViewModel(gasStationSelected);
        }


    }
}