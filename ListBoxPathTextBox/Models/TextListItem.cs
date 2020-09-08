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

        public Action<TextListItem> TextBoxGotFocusAction { get; set; }
        public ICommand ClearTextCommand { get; set; }
        public ICommand TextBoxGotFocusCommand { get; set; }

        public TextListItem()
        {
            ClearTextCommand = new DelegateCommand(ClearText);
            TextBoxGotFocusCommand = new DelegateCommand(TextBoxGotFocus);
        }

        public void ClearText()
        {
            Text = string.Empty;
        }

        public void TextBoxGotFocus()
        {
            TextBoxGotFocusAction?.Invoke(this);
        }
    }
}
