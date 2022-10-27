using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFRepetition.Managers;
using WPFRepetition.Models;
using WPFRepetition.ViewModels;

namespace WPFRepetition
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly DataManager _dataManager;
        private readonly NavigationManager _navigationManager;

        public App()
        {
            _dataManager = new DataManager();
            _navigationManager = new NavigationManager();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationManager.CurrentViewModel = new LeftViewModel(_dataManager.DataModel, _navigationManager);
            var mainWindow = new MainWindow() { DataContext = new MainViewModel(_navigationManager, _dataManager) };
            mainWindow.Show();

            base.OnStartup(e);
        }

    }
}
