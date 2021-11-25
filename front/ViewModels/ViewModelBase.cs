using System;
using System.Collections.Generic;
using System.Text;
using PropertyChanged;
using ReactiveUI;

namespace front.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModelBase : ReactiveObject
    {
    }
}