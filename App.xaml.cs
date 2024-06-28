using model;
using MVVMtest.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMtest
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        PersonData personData = new PersonData();
        protected override void OnStartup(StartupEventArgs e)
        {
            personData.NewPersons();
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow(personData);
            mainWindow.Show();
        }
    }
}
