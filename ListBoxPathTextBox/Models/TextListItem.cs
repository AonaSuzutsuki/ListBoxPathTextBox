using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace ListBoxPathTextBox.Models
{
    public class TextListItem : BindableBase
    {
        #region Fields

        private string _text;

        #endregion

        #region Properties

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        #endregion

        #region Event Properties

        public ICommand ClearTextCommand { get; set; }

        #endregion

        public TextListItem()
        {
            ClearTextCommand = new DelegateCommand(() => Text = string.Empty);
        }
    }
}
