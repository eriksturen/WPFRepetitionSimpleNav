using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WPFRepetition.Managers;

public class NavigationManager
{
	private ObservableObject _currentViewModel;

	public ObservableObject CurrentViewModel
	{
		get { return _currentViewModel; }
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
	}

    private ObservableObject _navigationBarViewModel;

	public ObservableObject NavigationBarViewModel
	{
		get { return _navigationBarViewModel; }
        set
        {
            _navigationBarViewModel = value;
            OnCurrentViewModelChanged();
        }
	}

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }

    public event Action CurrentViewModelChanged;

}