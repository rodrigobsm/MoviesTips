using System;
using System.ComponentModel;

namespace MoviesTips.Models
{
    public class Movie : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(id)));
            }
        }

        private String poster_path;
        public String Poster_Path
        {
            get { return poster_path; }
            set
            {
                poster_path = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(poster_path)));
            }
        }

        private String backdrop_path;
        public String Backdrop_Path
        {
            get { return backdrop_path; }
            set
            {
                backdrop_path = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(backdrop_path)));
            }
        }

        private Genre[] genres;
        public Genre[] Genres
        {
            get { return genres; }
            set
            {
                genres = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(genres)));
            }
        }

        private String overview;
        public String Overview
        {
            get { return overview; }
            set
            {
                overview = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(overview)));
            }
        }

        private String release_date;
        public String Release_Date
        {
            get { return release_date; }
            set
            {
                release_date = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(release_date)));
            }
        }

        private String title;
        public String Title
        {
            get { return title; }
            set
            {
                title = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(title)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
