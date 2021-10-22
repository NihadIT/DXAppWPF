using DXAppWPF.Interfaces;
using DXAppWPF.Data;
using DXAppWPF.ViewModels;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXAppWPF
{
    class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IConvert>().To<FileConvert>().InSingletonScope();
            Bind<MovieListViewModel>().ToSelf().InTransientScope();
        }
    }
}
