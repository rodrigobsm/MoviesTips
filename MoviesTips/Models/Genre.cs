using System;
using System.ComponentModel;

namespace MoviesTips.Models
{
    public class Genre : INotifyPropertyChanged
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

        private String name;
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
