using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PLCControl.Timer
{
    class CTimer
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        CTimer(EventHandler e)
        {
            _timer.Interval = new TimeSpan(10000000);//一秒
            _timer.Tick += e;

            _timer.Start();
        }

    }
}
