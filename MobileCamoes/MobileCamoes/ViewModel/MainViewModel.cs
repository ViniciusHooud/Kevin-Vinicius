using MobileCamoes.Model;
using MobileCamoes.Services;
using MobileCamoes.ViewModel.Base;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileCamoes.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        readonly ISerieService _serieService;

        public ICommand ItemClickCommand { get; }

        public ICommand TakePicuteCommand { get; }


        public ObservableCollection<Serie> Items { get; }


        private ImageSource foto { get; set; }
        public ImageSource Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel(ISerieService serieService) : base("Kevin & Vinicius - Series")
        {
            _serieService = serieService;

            Items = new ObservableCollection<Serie>();

            ItemClickCommand = new Command<Serie>(async (item) => await ItemClickCommandExecute(item));
            TakePicuteCommand = new Command(async () => await TakePicure());

            Foto = ImageSource.FromFile("camera.png");

        }

        private async Task TakePicure()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Rear
            });

            if (file == null)
                return;

            Foto = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

            return;
        }

        private async Task ItemClickCommandExecute(Serie item)
        {
            if (item != null)
            {
                await NavigationService.NavigateToAsync<DetailViewModel>(item);
            }
        }

        public override async Task InitializeAsync(object navgationData)
        {
            await base.InitializeAsync(navgationData);
            await LoadDataAsync();
        }

        async Task LoadDataAsync()
        {
            var result = await _serieService.GetSeriesAsync();

            if (result != null)
            {
                foreach (Serie serie in result.Series)
                {
                    serie.Genrers = new List<Genrer>();
                    foreach (int genrer in serie.GenrersId)
                    {
                        try
                        {
                            serie.Genrers.Add(await _serieService.GetGenrerAsync(genrer));
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }

            AddItens(result);
        }

        private void AddItens(SerieResponse result)
        {
            Items.Clear();
            result?.Series.ToList().ForEach(x => Items.Add(x));
        }
    }
}
