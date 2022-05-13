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
    public partial class GasStationListPage : ContentPage
    {
        public GasStationListPage()
        {
            InitializeComponent();

            BindingContext = new GasStationListViewModel();
        }
    }
}