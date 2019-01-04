using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View.ViewModels.Factories
{
    internal interface IMainViewModelFactory
    {
        IMainViewModel CreateMainViewModel();
    }

    internal class MainViewModelFactory : IMainViewModelFactory
    {
        private static IMainViewModelFactory _current;

        public static IMainViewModelFactory Current
        {
            get
            {
                if (_current == null)
                    _current = new MainViewModelFactory();

                return _current;
            }
        }

        public IMainViewModel CreateMainViewModel()
        {
            return new MainViewModel(ModelManager.Current.Customers, ModelManager.Current.Books);
        }
    }
}