using Prism.Mvvm;
using System;

namespace DDDNET8.WPF.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
