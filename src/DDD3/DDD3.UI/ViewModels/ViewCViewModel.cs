using DDD3.UI.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace DDD3.UI.ViewModels;
public class ViewCViewModel : BindableBase, IConfirmNavigationRequest
{
    #region フィールド

    private IMessageService _messageService;

    #endregion

    #region プロパティ

    private ObservableCollection<string> _myListBox = new();
    public ObservableCollection<string> MyListBox
    {
        get => _myListBox;
        set => SetProperty(ref _myListBox, value);
    }

    #endregion

    #region コンストラクタ

    public ViewCViewModel() : this(new MessageService()) { }

    public ViewCViewModel(IMessageService messageService)
    {
        _messageService = messageService;

        MyListBox.Add("AAA");
        MyListBox.Add("BBB");
        MyListBox.Add("CCC");
    }

    #endregion

    public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
    {
        if (_messageService.Question("とじますか？") == MessageBoxResult.OK)
        {
            continuationCallback(true);
        }
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return false;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
    }
}
