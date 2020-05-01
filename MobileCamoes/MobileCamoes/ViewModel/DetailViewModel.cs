using MobileCamoes.Infra.Repository;
using MobileCamoes.Model;
using MobileCamoes.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileCamoes.ViewModel
{
    public class DetailViewModel : ViewModelBase

    {
        private Serie DetailSerie = new Serie();

        private string image;
        public string Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }

        private string name;
        public string Name
        {
            get => name; 
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string overview;
        public string Overview
        {
            get => overview;
            set
            {
                overview = value;
                OnPropertyChanged();
            }
        }

        private string releaseDate;
        public string ReleaseDate
        {
            get => releaseDate;
            set
            {
                releaseDate = value;
                OnPropertyChanged();
            }
        }

        private bool isFavorited = false;
        public ImageSource SerieFavorite
        {
            get => isFavorited ? ImageSource.FromFile("favorited.png") : ImageSource.FromFile("unfavorited.png");
        }

        public ImageSource FirstStar
        {
            get => DetailSerie.VoteAverage > 2 ? ImageSource.FromFile("star.png") : ImageSource.FromFile("unstar.png");
        }
        public ImageSource SecondStar
        {
            get => DetailSerie.VoteAverage > 4 ? ImageSource.FromFile("star.png") : ImageSource.FromFile("unstar.png");
        }
        public ImageSource ThridStar
        {
            get => DetailSerie.VoteAverage > 6 ? ImageSource.FromFile("star.png") : ImageSource.FromFile("unstar.png");
        }
        public ImageSource FourStar
        {
            get => DetailSerie.VoteAverage > 8 ? ImageSource.FromFile("star.png") : ImageSource.FromFile("unstar.png");
        }
        public ImageSource FiveStar
        {
            get => DetailSerie.VoteAverage >= 9.5 ? ImageSource.FromFile("star.png") : ImageSource.FromFile("unstar.png");
        }


        private readonly ISerieRepository _repository;
        public DetailViewModel(ISerieRepository repository) : base("")
        {
            _repository = repository;
        }


        public override async Task InitializeAsync(object navgationData)
        {
            await base.InitializeAsync(navgationData);
            DetailSerie = navgationData as Serie;

            Title = DetailSerie.Name;
            Image = DetailSerie.Poster;
            Name = string.IsNullOrEmpty(DetailSerie.Name) ? string.Empty : DetailSerie.Name.ToUpper();
            Overview = DetailSerie.Overview;
            ReleaseDate = DetailSerie.ReleaseDate;

            isFavorited = _repository.Exist(DetailSerie.Id);
            OnPropertyChanged("FirstStar");
            OnPropertyChanged("SecondStar");
            OnPropertyChanged("ThridStar");
            OnPropertyChanged("FourStar");
            OnPropertyChanged("FiveStar");
        }

    }
}
