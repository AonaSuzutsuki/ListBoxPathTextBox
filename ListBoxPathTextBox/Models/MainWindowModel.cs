using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace ListBoxPathTextBox.Models
{
    public class MainWindowModel : BindableBase
    {
        #region Fields

        private TextListItem _textListSelectedItem;
        private bool _canRemove;

        #endregion

        #region Properties

        public ObservableCollection<TextListItem> TextListItems { get; } = new ObservableCollection<TextListItem>();

        public TextListItem TextListSelectedItem
        {
            get => _textListSelectedItem;
            set
            {
                CanRemove = value != null;
                SetProperty(ref _textListSelectedItem, value);
            }
        }

        public bool CanRemove
        {
            get => _canRemove;
            set => SetProperty(ref _canRemove, value);
        }

        #endregion

        public void AddPathElement()
        {
            TextListItems.Add(new TextListItem
            {
                TextBoxGotFocusAction = item => TextListSelectedItem = item
            });
        }

        public void RemovePathElement()
        {
            if (TextListSelectedItem == null)
                return;
            TextListItems.Remove(TextListSelectedItem);
        }
    }
}
