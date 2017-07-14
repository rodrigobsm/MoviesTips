using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using MoviesTips.Views;

namespace MoviesTips.ViewModels
{
    public class MoviesSearchViewModel : INotifyPropertyChanged
    {
        // Commands for the Views
        public ICommand SearchMoviesCommand { get; set; }

        private String searchedtext;
		public String SearchedText
		{
			get { return searchedtext; }
			set
			{
				searchedtext = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(searchedtext)));

			}
		}

        private ObservableCollection<Models.Result> results;
        public ObservableCollection<Models.Result> Results {
            get { return results;  }
            set {
                results = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(results)));
            }
        }

        public MoviesSearchViewModel()
        {
            // Bind the results to ListView
            Results = new ObservableCollection<Models.Result>();

            SearchMoviesCommand = new Xamarin.Forms.Command(async () =>
            {
                // Clear listing
                Results.Clear();

                var r = await TMDBAPI.API.SearchMoviesAsync(SearchedText);
                foreach (var item in r.Results)
                {
                    // Check if a poster image path is available, otherwise shows placeholder
                    String PosterImage;
					if (null != item.Poster_Path)
					{
						PosterImage = "https://image.tmdb.org/t/p/w500/" + item.Poster_Path;
					} else {
						PosterImage = "no_poster_placeholder.png";
					}

					// Wraps texto to fit listview space
					// TODO: Use grid to fix height and overlap issues

					String OverviewWrap;
					int max_chars = 150;
					max_chars -= item.Title.Length;

					if (item.Overview.Length > max_chars)
					{
						OverviewWrap = item.Overview.Substring(0, max_chars) + "...";
					} else {
						OverviewWrap = item.Overview;
					}

					Results.Add(new Models.Result
					{
						Id = item.Id,
						Title = item.Title,
						Backdrop_Path = item.Backdrop_Path,
						Genre_Ids = item.Genre_Ids,
						Overview = OverviewWrap,
						Poster_Path = PosterImage,
						Release_Date = "Release: " + item.Release_Date
					});
                }
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}