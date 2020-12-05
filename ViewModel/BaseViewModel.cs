using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PLCControl.ViewModel
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool Set<T>(ref T target, T value, [CallerMemberName] string porperName = "")
        {
            if (object.Equals(target, value))
                return false;
            target = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(porperName));
            }
            return true;
        }

        public static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    }
}
