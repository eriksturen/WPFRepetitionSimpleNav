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

        _navigationManager.CurrentViewModelChanged += CurrentViewModelChanged;

    }
    
    private void CurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}