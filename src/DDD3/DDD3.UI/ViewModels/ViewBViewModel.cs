using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD3.UI.ViewModels;
public class ViewBViewModel : BindableBase, IDialogAware
{
    public ViewBViewModel()
    {

    }

    public string Title => "View B";

    public event Action<IDialogResult> RequestClose;

    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
    }
}
