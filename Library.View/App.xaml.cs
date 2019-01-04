using Library.Core;
using Library.View.ViewModels;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    IUnityContainer container = new UnityContainer();
        //    container.RegisterType<ICustomer, Customer>();
        //    container.RegisterType<IBook, Book>();
        //    container.RegisterType<IMainViewModel, MainViewModel>();

        //    var mainViewModel = container.Resolve<MainViewModel>();
        //    var window = new MainWindow { DataContext = mainViewModel };
        //    window.Show();
        //}
    }
}