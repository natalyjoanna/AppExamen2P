using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppExamen2P.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        // Comandos 
        private Command _GetLocationCommand;
        public Command GetLocationCommand => _GetLocationCommand ?? (_GetLocationCommand = new Command(GetLocationAction));



        // Propiedades
        private double _latitude;
        public double Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }



        private double _longitude;
        public double Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }

        // Constructor 
        public LocationViewModel()
        {

        }

        // Metodos
        private void GetLocationAction(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
