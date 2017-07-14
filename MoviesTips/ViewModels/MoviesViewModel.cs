using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using MoviesTips.Views;

namespace MoviesTips.ViewModels
{
    public class MoviesViewModel : INotifyPropertyChanged
    {

        // Current listing page
        public int _page = 1;

        // Commands for the Views
        public ICommand LoadMoviesCommand { get; set; }

        private ObservableCollection<Models.Result> results;
        public ObservableCollection<Models.Result> Results {
            get { return results;  }
            set {
                results = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(results)));
            }
        }

        public MoviesViewModel()
        {
            // Bind the results to ListView
            Results = new ObservableCollection<Models.Result>();

            LoadMoviesCommand = new Xamarin.Forms.Command(async () =>
            {
                var r = await TMDBAPI.API.GetUpcomingMoviesAsync(this._page);
                foreach (var item in r.Results) {

                    String PosterImage;

                    // Check if a poster image path is available, otherwise shows placeholder
                    if (null != item.Poster_Path) {
                        PosterImage = "https://image.tmdb.org/t/p/w300/" + item.Poster_Path;
                    } else {
                        PosterImage = "no_poster_placeholder.png";
                    }


                    // Wraps texto to fit listview space
                    // TODO: Use grid to fix height and overlap issues

                    String OverviewWrap;
                    int max_chars = 150;
                    max_chars -= item.Title.Length;

                    if (item.Overview.Length > max_chars) {
                        OverviewWrap = item.Overview.Substring(0, max_chars) + "...";
                    } else {
                        OverviewWrap = item.Overview;
                    }

                    Results.Add(new Models.Result {
                        Id = item.Id,
                        Title = item.Title,
                        Backdrop_Path = item.Backdrop_Path,
                        Genre_Ids = item.Genre_Ids,
                        Overview = OverviewWrap,
                        Poster_Path = PosterImage,
                        Release_Date = "Release: "+item.Release_Date });
                }

            });

           
            // Automatically loads upcoming movies from API
            LoadMoviesCommand.Execute(this);

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}