using AppExamen2P.Models;
using AppExamen2P.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppExamen2P.ViewModels
{
    public class GasStationListViewModel : BaseViewModel
    {
        // Variables
        static GasStationListViewModel instance;

        // Comandos
        private Command _NewCommand;
        public Command NewCommand => _NewCommand ?? (_NewCommand = new Command(NewAction));



        // Propiedades
        private List<GasStationModel> _GasStations;
        public List<GasStationModel> GasStations
        {
            get => _GasStations;
            set => SetProperty(ref _GasStations, value);
        }

        private GasStationModel _GasStationSelected;
        public GasStationModel GasStationSelected
        {
            get => _GasStationSelected;
            set
            {
                if (SetProperty(ref _GasStationSelected, value))
                {
                    SelectGasStationAction();
                }
            }
        }

        // Constructores

        public GasStationListViewModel()
        {
            instance = this;

            LoadGasStations();
        }

        // Metodos

        public static GasStationListViewModel GetInstance()
        {
            return instance;
        }

        private void NewAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new GasStationDetailPage());
        }

        public async void LoadGasStations()
        {
            GasStations = await App.GasStationDataBase.GetAllGasStationsAsync();
        }

        private void SelectGasStationAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new GasStationDetailPage(GasStationSelected));
        }
    }
}
