using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoviesTips.TMDBAPI
{
    public class API
    {
        // The Movie DB API key provided by the client.
        public const String TMTB_API_KEY = "1f54bd990f1cdfb230adb312546d765d";

        // Get the upcoming movies.
        public static async Task<Models.MoviesResults> GetUpcomingMoviesAsync(int page)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("https://api.themoviedb.org/3/movie/upcoming?page=" + page + "&api_key=" + TMTB_API_KEY);
                var obj = JsonConvert.DeserializeObject<Models.MoviesResults>(json);
                return obj;
            }
        }

        // Get the information about a movie by id.
        public static async Task<Models.Movie> GetMovieInfoAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("https://api.themoviedb.org/3/movie/" + id + "?api_key=" + TMTB_API_KEY);
                var obj = JsonConvert.DeserializeObject<Models.Movie>(json);
                return obj;
            }
        }

        // Search movies by name.
        public static async Task<Models.MoviesResults> SearchMoviesAsync(String query)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("https://api.themoviedb.org/3/search/movie?query=" + query + "&api_key=" + TMTB_API_KEY);
                var obj = JsonConvert.DeserializeObject<Models.MoviesResults>(json);
                return obj;
            }
        }

    }
}
