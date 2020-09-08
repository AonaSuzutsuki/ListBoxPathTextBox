using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ListBoxPathTextBox.Models;
using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace ListBoxPathTextBox.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Properties

        public ReadOnlyCollection<TextListItem> TextList { get; set; }
        public ReactiveProperty<TextListItem> TextListSelectedItem { get; set; }

        public ReactiveProperty<bool> CanRemove { get; set; }

        #endregion

        #region Event Properties

        public ICommand AddElementCommand { get; set; }
        public ICommand RemoveElementCommand { get; set; }

        #endregion

        public MainWindowViewModel(MainWindowModel model)
        {
            TextList = model.TextListItems.ToReadOnlyReactiveCollection(m => m);
            TextListSelectedItem = model.ToReactivePropertyAsSynchronized(m => m.TextListSelectedItem);
            CanRemove = model.ObserveProperty(m => m.CanRemove).ToReactiveProperty();

            AddElementCommand = new DelegateCommand(model.AddPathElement);
            RemoveElementCommand = new DelegateCommand(model.RemovePathElement);
        }
    }
}
