using Xamarin.Forms;

namespace MoviesTips.Views
{
    public partial class SearchMovies : ContentPage
    {
        public SearchMovies()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.MoviesSearchViewModel();

            // Show movie info view when list view item is tapped.
            this.MoviesListView.ItemTapped += async (sender, e) =>
            {
                var Result = e.Item as Models.Result;

                // Call API to get this movie information.
                var Movie = await TMDBAPI.API.GetMovieInfoAsync(Result.Id);

                // Show view.
                await Navigation.PushAsync(new Views.Movie(Movie));
            };

        }
    }
}
