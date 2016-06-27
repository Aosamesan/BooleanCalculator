using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BooleanCalculator.Command
{
    public class OpenHowToUseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Dialog.LicenseDialog howToUse = new Dialog.LicenseDialog();
            howToUse.Show();
        }
    }
}
