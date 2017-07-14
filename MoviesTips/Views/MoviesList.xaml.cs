using System;
using System.Collections;
using System.Collections.Generic;
using MoviesTips.ViewModels;
using Xamarin.Forms;

namespace MoviesTips.Views
{
    public partial class MoviesList : ContentPage
    {

        private MoviesViewModel _viewModel = new MoviesViewModel();


        public MoviesList()
        {
            InitializeComponent();

            // Binds with ModelView class
            this.BindingContext = this._viewModel;

            // Show movie info view when list view item is tapped
            this.MoviesListView.ItemTapped += async (sender, e) =>
            {
                var Result = e.Item as Models.Result;

                // Call API to get this movie information
                var Movie = await TMDBAPI.API.GetMovieInfoAsync(Result.Id);

                // Show view
                await Navigation.PushAsync(new Views.Movie(Movie));
            };

        }

		protected void Handle_ItemAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
		{
            // When the last listview item is displayed, loads more 20 records from webservice (infinite scroll)
            var items = this.MoviesListView.ItemsSource as IList;
            if (items != null && e.Item == items[items.Count-1]) {
                this._viewModel._page++;
                this._viewModel.LoadMoviesCommand.Execute(this);
            }
		}

    }
}
