using Xamarin.Forms;

namespace MoviesTips
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Create tabs objects.
            var UpcomingTab = new NavigationPage(new Views.MoviesList())
            {
                Title = "Upcoming",
                Icon = "video-camera.png"
            };

            var SearchTab = new NavigationPage(new Views.SearchMovies())
            {
                Title = "Search",
                Icon = "search.png"
            };

            // Loads tabs into main view
            MainPage = new TabbedPage()
            {
                Title = "Movies",
                Children = {
                    UpcomingTab,
                    SearchTab,
                }
            };



        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
