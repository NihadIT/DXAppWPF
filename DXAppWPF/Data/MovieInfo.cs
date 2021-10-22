using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DXAppWPF.Data
{
   public class MovieInfo : INotifyPropertyChanged
    {
        public MovieInfo() { }
        public MovieInfo(int movieId, string name, int genreId,
            string director, double minutes) 
        {
            MovieId = movieId;
            Name = name;
            GenreId = genreId;
            Director = director;
            Minutes = minutes;
        }

        int movieId;
        public int MovieId
        {
            get { return movieId; }
            set
            {
                if (movieId == value)
                    return;
                movieId = value;
                OnPropertyChanged("MovieId");
            }
        }

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged("Name");
            }
        }

        int genreId;
        public int GenreId
        {
            get { return genreId; }
            set
            {
                if (genreId == value)
                    return;
                genreId = value;
                OnPropertyChanged("GenreId");
            }
        }

        string director;
        public string Director
        {
            get { return director; }
            set
            {
                if (director == value)
                    return;
                director = value;
                OnPropertyChanged("Director");
            }
        }

        double minutes;
        public double Minutes
        {
            get { return minutes; }
            set
            {
                if (minutes == value)
                    return;
                minutes = value;
                OnPropertyChanged("Milliseconds");
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Minutes: {1}, Director: {2}",
              Name, minutes, Director);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
