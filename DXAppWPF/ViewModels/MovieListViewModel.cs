using DevExpress.Data.Browsing;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Grid;
using DXAppWPF.Data;
using DXAppWPF.Interfaces;
using Ninject;
using System.Windows;
using System.Windows.Input;

namespace DXAppWPF.ViewModels
{
    public class MovieListViewModel
    {
        [Inject]
        public static IConvert _convert { get; set; }
        public virtual MovieList Movies { get; set; }

        public MovieListViewModel(IConvert convert)
        {
            _convert = convert;
            Movies = new MovieList();
            SaveCVSCommand = new DelegateCommand<object>(SaveCVSExecute);
            SaveTXTCommand = new DelegateCommand<object>(SaveTXTExecute);
            SaveAllCommand = new DelegateCommand<object>(SaveAllExecute);
            EditMovieCommand = new DelegateCommand<object>(EditMovieExecute);
        }

        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }

        #region Сommands

        public DelegateCommand<object> EditMovieCommand { get; private set; }
        public void EditMovieExecute(object movieObject)
        {
            var movie = movieObject as MovieInfo;
            MessageBox.Show(movie.ToString());
        }

        public DelegateCommand<object> SaveCVSCommand { get; private set; }

        public void SaveCVSExecute(object sender)
        {
            _convert.SaveFile(_convert.CheckRow(sender), "csv");
        }

        public DelegateCommand<object> SaveTXTCommand { get; private set; }
        public void SaveTXTExecute(object sender)
        {
            _convert.SaveFile(_convert.CheckRow(sender), "txt");
        }

        public DelegateCommand<object> SaveAllCommand { get; private set; }
        public void SaveAllExecute(object sender)
        {
            TableView view = sender as TableView;
            string path = FileConvert.Path + "Table.csv";
            view.ExportToCsv(path);
            MessageBox.Show($"Файл сохранен по этому пути: {path}");
        }
        #endregion
    }
}