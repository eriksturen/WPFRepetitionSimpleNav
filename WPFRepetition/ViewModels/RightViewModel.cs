using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels;

public class RightViewModel : ObservableObject
{
    private readonly DataModel _dataModel;

    private readonly NavigationManager _navigationManager;
    public IRelayCommand CountUpCommand { get; }

    public IRelayCommand NavigateLeftCommand { get; }
    public IRelayCommand NavigateRightCommand { get; }

    private int _counter;

    public int Counter
    {
        get { return _dataModel.Counter; }
        set
        {
            SetProperty(_dataModel.Counter, value, _dataModel,
            (model, value) => model.Counter = value);
        }
    }

    public RightViewModel(DataModel dataModel, NavigationManager navigationManager)
    {
        _dataModel = dataModel;
        _navigationManager = navigationManager;
        CountUpCommand = new RelayCommand(() => Counter++);

        NavigateLeftCommand = new RelayCommand(() =>
            _navigationManager.CurrentViewModel = new CenterViewModel(_dataModel, _navigationManager));

        NavigateRightCommand = new RelayCommand(() =>
            _navigationManager.CurrentViewModel = new LeftViewModel(_dataModel, _navigationManager));
    }
}