using DDD3.UI.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DDD3.UI.ViewModels;
public class ViewCViewModel : BindableBase, IConfirmNavigationRequest
{
    private IMessageService _messageService;

    public ViewCViewModel() : this(new MessageService()) { }

    public ViewCViewModel(IMessageService messageService)
    {
        _messageService = messageService;
    }

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
