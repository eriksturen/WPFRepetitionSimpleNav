using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels;

public class CenterViewModel : ObservableObject
{
    private readonly DataModel _dataModel;

    public IRelayCommand ResetCounterCommand { get; }

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

    public CenterViewModel(DataModel dataModel)
    {
        _dataModel = dataModel;
        ResetCounterCommand = new RelayCommand(() => Counter = 0);
    }
}
