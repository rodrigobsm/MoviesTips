using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MoviesTips.Models
{
    public class MoviesResults : INotifyPropertyChanged
    {
		private List<Result> results;
		public List<Result> Results
		{
			get { return results; }
			set
			{
				results = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(results)));
			}
		}

		private int page;
		public int Page
		{
			get { return page; }
			set
			{
				page = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(page)));
			}
		}

        private int total_pages;
		public int Total_pages
		{
			get { return total_pages; }
			set
			{
				total_pages = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(total_pages)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
    }
        
}
