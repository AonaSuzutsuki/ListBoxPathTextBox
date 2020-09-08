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
        #region Fields

        private readonly MainWindowModel _model;

        #endregion

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
            _model = model;

            TextList = model.TextListItems.ToReadOnlyReactiveCollection(m => m);
            TextListSelectedItem = model.ToReactivePropertyAsSynchronized(m => m.TextListSelectedItem);
            CanRemove = model.ObserveProperty(m => m.CanRemove).ToReactiveProperty();

            AddElementCommand = new DelegateCommand(AddElement);
            RemoveElementCommand = new DelegateCommand(RemoveElement);
        }

        public void AddElement()
        {
            _model.AddPathElement();
        }

        public void RemoveElement()
        {
            _model.RemovePathElement();
        }
    }
}
