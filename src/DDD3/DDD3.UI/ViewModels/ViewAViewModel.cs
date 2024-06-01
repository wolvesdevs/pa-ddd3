using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD3.UI.ViewModels;
public class ViewAViewModel : BindableBase, INavigationAware
{
    private string _myLabel = string.Empty;
    public string MyLabel
    {
        get => _myLabel;
        set => SetProperty(ref _myLabel, value);
    }

    public ViewAViewModel()
    {

    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        MyLabel = navigationContext.Parameters.GetValue<string>(nameof(MyLabel));
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return false;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }
}
