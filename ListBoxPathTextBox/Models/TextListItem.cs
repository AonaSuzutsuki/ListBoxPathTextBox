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
        private string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public ICommand ClearTextCommand { get; set; }

        public TextListItem()
        {
            ClearTextCommand = new DelegateCommand(ClearText);
        }

        public void ClearText()
        {
            Text = string.Empty;
        }
    }
}
