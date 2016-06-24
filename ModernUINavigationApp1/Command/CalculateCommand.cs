using ModernUINavigationApp1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ModernUINavigationApp1.Command
{
    public class CalculateCommand : ICommand
    {
        public CalculatorViewModel ViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                if (parameter is string)
                    ViewModel?.Calculate(parameter as string);
                else
                    throw new Exception();
                SystemSounds.Beep.Play();
            }
            catch (Exception e)
            {
                SystemSounds.Hand.Play();
                (new Dialog.ErrorDialog()).ShowDialog();
            }
        }
    }
}
