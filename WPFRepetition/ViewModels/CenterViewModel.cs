using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels;

public class CenterViewModel : ObservableObject
{
    private readonly DataModel _dataModel;

    private readonly NavigationManager _navigationManager;
    public IRelayCommand ResetCounterCommand { get; }
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

    public CenterViewModel(DataModel dataModel, NavigationManager navigationManager)
    {
        _dataModel = dataModel;
        _navigationManager = navigationManager;
        ResetCounterCommand = new RelayCommand(() => Counter = 0);

        NavigateLeftCommand = new RelayCommand(() =>
            _navigationManager.CurrentViewModel = new LeftViewModel(_dataModel, _navigationManager));

        NavigateRightCommand = new RelayCommand(() =>
            _navigationManager.CurrentViewModel = new RightViewModel(_dataModel, _navigationManager));

    }
}
