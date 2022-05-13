using AppExamen2P.Data;
using AppExamen2P.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamen2P
{
    public partial class App : Application
    {

        static GasStationDataBase gasStationDataBase;
        public static GasStationDataBase GasStationDataBase
        {
            get
            {
                if (gasStationDataBase == null) gasStationDataBase = new GasStationDataBase();
                return gasStationDataBase;
            }
        }
        public App()
        {
            InitializeComponent();

            NavigationPage nav = new NavigationPage(new GasStationListPage());
            MainPage = nav;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
