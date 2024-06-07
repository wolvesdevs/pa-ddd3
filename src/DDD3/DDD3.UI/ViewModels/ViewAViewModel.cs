using DDD3.UI.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DDD3.UI.ViewModels;
public class ViewAViewModel : BindableBase, INavigationAware
{
    private IDialogService _dialogService;

    private string _myLabel = string.Empty;
    public string MyLabel
    {
        get => _myLabel;
        set => SetProperty(ref _myLabel, value);
    }

    public DelegateCommand OKButton { get; }

    public ViewAViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
        OKButton = new DelegateCommand(OKButtonExecute);
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        MyLabel = navigationContext.Parameters.GetValue<string>(nameof(MyLabel));
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    private void OKButtonExecute()
    {
        //MessageBox.Show("OKButtonExecute");
        DialogParameters p = new();
        p.Add(nameof(ViewBViewModel.ViewBTextBox), "Saveします");
        _dialogService.ShowDialog(nameof(ViewB), p, null);
    }
}
