using System;
using System.Collections.Generic;
using MoviesTips.Models;
using Xamarin.Forms;

namespace MoviesTips.Views
{
    public partial class Movie : ContentPage
    {
        private Models.Movie movie;

        public Movie(Models.Movie movie)
        {
            InitializeComponent();
            this.movie = movie;

            // Check if a poster image path is available, otherwise shows placeholder
            String PosterImage;
			if (null != movie.Poster_Path)
			{
				PosterImage = "https://image.tmdb.org/t/p/w500/" + movie.Poster_Path;
			} else {
				PosterImage = "no_poster_placeholder.png";
			}

            // Bind information to view
			this.MovieTitle.Text = movie.Title;
            this.MoviePoster.Source = PosterImage;
            this.MovieOverview.Text = movie.Overview;
            this.MovieReleaseDate.Text = movie.Release_Date;

            int total = movie.Genres.Length;
            int i = 0;
            foreach (var genre in movie.Genres) {
                this.MovieGenres.Text += genre.Name;
                if (i < total-1)
                    this.MovieGenres.Text += ", ";
                else
                    this.MovieGenres.Text += ".";
                i++;
            }


        }
    }
}
