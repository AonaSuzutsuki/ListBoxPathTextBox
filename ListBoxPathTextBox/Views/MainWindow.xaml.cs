using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ListBoxPathTextBox.Models;
using ListBoxPathTextBox.ViewModels;

namespace ListBoxPathTextBox.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClearFocus
    {
        public MainWindow()
        {
            InitializeComponent();

            var model  = new MainWindowModel();
            DataContext = new MainWindowViewModel(model, this);
        }

        public void ClearFocus()
        {
            Box.Focus();
        }
    }
}
