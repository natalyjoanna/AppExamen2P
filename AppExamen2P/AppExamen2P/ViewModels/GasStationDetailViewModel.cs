using AppExamen2P.Models;
using AppExamen2P.Services;
using AppExamen2P.Views;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppExamen2P.ViewModels
{
    public class GasStationDetailViewModel : BaseViewModel
    {
        // Comandos

        private Command _CancelCommand;
        public Command CancelCommand => _CancelCommand ?? (_CancelCommand = new Command(CancelAction));

        private Command _SaveCommand;
        public Command SaveCommand => _SaveCommand ?? (_SaveCommand = new Command(SaveAction));

        private Command _DeleteCommand;
        public Command DeleteCommand => _DeleteCommand ?? (_DeleteCommand = new Command(DeleteAction));

        private Command _TakePictureCommand;
        public Command TakePictureCommand => _TakePictureCommand ?? (_TakePictureCommand = new Command(TakePictureAction));

        private Command _SelectPictureCommand;
        public Command SelectPictureCommand => _SelectPictureCommand ?? (_SelectPictureCommand = new Command(SelectPictureAction));

        private Command _LocationCommand;
        public Command LocationCommand => _LocationCommand ?? (_LocationCommand = new Command(LocationAction));

        



        // Propiedades
        private GasStationModel _GasStationSelected;
        public GasStationModel GasStationSelected
        {
            get => _GasStationSelected;
            set => SetProperty(ref _GasStationSelected, value);
        }

        private string _Picture;
        public string Picture
        {
            get => _Picture;
            set => SetProperty(ref _Picture, value);
        }

        // Constructor
        public GasStationDetailViewModel()
        {
            GasStationSelected = new GasStationModel();
        }

        public GasStationDetailViewModel(GasStationModel gasStationSelected)
        {
            GasStationSelected = gasStationSelected;
        }

        // Metodos

        private async void CancelAction()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void SaveAction()
        {
            await App.GasStationDataBase.SaveGasStationAsync(GasStationSelected);

            GasStationListViewModel.GetInstance().LoadGasStations();

            CancelAction();
        }

        private async void DeleteAction()
        {
            await App.GasStationDataBase.DeleteGasStationAsync(GasStationSelected);

            GasStationListViewModel.GetInstance().LoadGasStations();

            CancelAction();
        }

        private void LocationAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new LocationPage());
        }

        private async void TakePictureAction()
        {
            // Inicializa la cámara
            await CrossMedia.Current.Initialize();



            // Si la cámara no está disponible o no está soportada lanza un mensaje y termina este método
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }



            // Toma la fotografía y la regresa en el objeto file
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "AppExamen2P",
                Name = "camPicture.jpg"
            });



            // Si el objeto file es null termina este método
            if (file == null) return;



            // Asignamos la ruta de la fotografía en la propiedad de la imagen
            Picture = GasStationSelected.ImageBase64 = await new ImageService().ConvertImageFileToBase64(file.Path);



            /*image.Source = ImageSource.FromStream(() =>
            {
            var stream = file.GetStream();
            return stream;
            });*/
        }

        private async void SelectPictureAction()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Pick Photo", ":( No pick photo available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
                return;

            Picture = GasStationSelected.ImageBase64 = await new ImageService().ConvertImageFileToBase64(file.Path); //file.Path;

            /*image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });*/
        }
    }
}
