using DXAppWPF.Data;
using DXAppWPF.Interfaces;
using DXAppWPF.ViewModels;
using DXAppWPF.Views;
using Ninject;
using System.Windows;

namespace DXAppWPF
{
    public partial class App : Application
    {
        private IKernel kernal;
        protected override void OnStartup(StartupEventArgs e)
        {
            kernal = new StandardKernel();
            kernal.Load(new IocConfiguration());

            var appContent = kernal.Get<MovieListViewModel>();

            MainWindow = new MainWindow(); 
            MainWindow.DataContext = appContent;
            MainWindow.Show();
        }
    }
}
