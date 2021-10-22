using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXAppWPF.Data
{
    public class MovieList : ObservableCollection<MovieInfo>
    {
        public MovieList()
        {
            Add(new MovieInfo(1, "Venom 2", 1, "Andy Serkis", 132));
            Add(new MovieInfo(2, "Oxygen (2021)", 2, "Alexander Azha", 95));
            Add(new MovieInfo(3, "Eiffel", 3, "Martin Bourboulon", 90));
            Add(new MovieInfo(4, "Infinity", 1, "Antoine Fuqua", 106));
            Add(new MovieInfo(5, "Jumanji", 4, "Jake Kasdan", 110));
            Add(new MovieInfo(6, "Dune", 2, "Denis Villeneuve", 99));
            Add(new MovieInfo(7, "Cinderella", 3, "Kay Cannon", 82));
        }
    }
}
