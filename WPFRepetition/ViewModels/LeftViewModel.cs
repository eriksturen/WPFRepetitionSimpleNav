using System;
using System.DirectoryServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels;

public class LeftViewModel : ObservableObject
{
    private readonly DataModel _dataModel;

    private readonly NavigationManager _navigationManager;

    // Vi vet att vi har en knapp i vyn. Därför behöver vi ge knappen möjlighet att nå ett command - 
    // Den här viewmodellen är klistret mellan commandet och vyn 
    public IRelayCommand CountDownCommand { get; }
    public IRelayCommand NavigateLeftCommand { get; }
    public IRelayCommand NavigateRightCommand { get; }

    // för att commandet ska kunna få nåt i sig behöver vi en propfull:
    private int _counter;

    public int Counter
    {
        get { return _dataModel.Counter; }
        set
        {
            SetProperty(_dataModel.Counter, value, _dataModel, (model, value) => model.Counter = value);
        }
    }

    // sen en konstruktor där vi kan sätta countdowncommandet till nåt. 
    // vi gör så att countdowncommand bara blir ett relaycommand där countern räknas upp. 
    // Skulle kunna vara nåt annat också! Kan exvis definiera en ny funktion längre ner och köra den i relaycommmandet 
    public LeftViewModel(DataModel dataModel, NavigationManager navigationManager)
    {
        _dataModel = dataModel;
        _navigationManager = navigationManager;
        CountDownCommand = new RelayCommand(() => Counter--);

        NavigateLeftCommand = new RelayCommand(() =>
            _navigationManager.CurrentViewModel = new RightViewModel(_dataModel, _navigationManager));

        NavigateRightCommand = new RelayCommand(() =>
            _navigationManager.CurrentViewModel = new CenterViewModel(_dataModel, _navigationManager));
        //CountDownCommand = new RelayCommand(EnAnnanFunktion);
    }

    //public void EnAnnanFunktion()
    //{
    //    Console.WriteLine("Testtext");
    //    Counter--;
    //}

}