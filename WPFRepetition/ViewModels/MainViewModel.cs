using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using WPFRepetition.Managers;

namespace WPFRepetition.ViewModels;

public class MainViewModel : ObservableObject 
    // Med observable object så får vi med INotifyPropertyChanged!! 
{
    private readonly NavigationManager _navigationManager;
    private readonly DataManager _dataManager;

    public IRelayCommand NavigateLeftCommand { get; }
    public IRelayCommand NavigateCenterCommand { get; }
    public IRelayCommand NavigateRightCommand { get; }

    public ObservableObject CurrentViewModel
    {
        get { return _navigationManager.CurrentViewModel; }
    }

    // Det här är tydligen den absolut enklaste formen av dependency injection. 
    // Vi skickar in "det vi behöver" för i en specifik instans 
    public MainViewModel(NavigationManager navigationManager, DataManager dataManager)
    {
        _dataManager = dataManager;
        _navigationManager = navigationManager;

        NavigateLeftCommand = new RelayCommand(() =>
            _navigationManager.CurrentViewModel = new LeftViewModel(_dataManager.DataModel));

        NavigateCenterCommand = new RelayCommand(() =>
            _navigationManager.CurrentViewModel = new CenterViewModel(_dataManager.DataModel));

        NavigateRightCommand = new RelayCommand(() =>
            _navigationManager.CurrentViewModel = new RightViewModel(_dataManager.DataModel));

        _navigationManager.CurrentViewModelChanged += CurrentViewModelChanged;

    }
    
    private void CurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}