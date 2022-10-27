using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels;

public class RightViewModel : ObservableObject
{
    private readonly DataModel _dataModel;

    public IRelayCommand CountUpCommand { get; }


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

    public RightViewModel(DataModel dataModel)
    {
        _dataModel = dataModel;
        CountUpCommand = new RelayCommand(() => Counter++);

    }
}