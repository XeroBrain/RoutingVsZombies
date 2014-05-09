using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RtgVsZmbs.Base
{
    class ViewModelBase : INotifyPropertyChanged
    {
        #region Field

        public event PropertyChangedEventHandler PropertyChanged;

        private RelayCommand _myCommand;

        #endregion

        #region Member

        //es wird der Name des Propertys welches sich andert hier eingetragen.
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ICommand MyCommand
        {
            get
            {
                if (_myCommand == null)
                {
                   // _myCommand = new RelayCommand(x => DoMyCommand(x), x => CanDoMyCommand(x));
                }
                return _myCommand;
            }
        }

        #endregion
    }
}
