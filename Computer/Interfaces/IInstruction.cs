using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Computer.Interfaces
{
    public interface IInstruction
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter);

        object Execute(object parameter);
    }
}
