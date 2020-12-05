using PLCControl.PLC;
using PLCControl.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PLCControl.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private Object _ContentPage;

        public Object ContetnPage
        {
            get { return _ContentPage; }
            set { Set(ref _ContentPage, value); }
        }


        ListBoxItem _selectItem = null;
        public ListBoxItem SelectItem
        {
            get { return _selectItem; }
            set
            {
                if (Set(ref _selectItem, value))
                {
                    switch (SelectItem.Content.ToString())
                    {
                        case "IO测试":
                            ContetnPage = new ConnectionTestView();
                            break;
                        case "报警信息":
                            ContetnPage = new AlarmView();
                            break;
                        case "测试页面":
                            ContetnPage = new TestPageView();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public MainWindowViewModel()
        {
            StartTimer();
        }
        private string _plcStatus;
        public string PLCstatus
        {
            get { return _plcStatus; }
            set
            {
                Set(ref _plcStatus, value);
            }
        }

        private string _time;
        public string RunTime
        {
            get { return _time; }
            set
            {
                Set(ref _time, value);
            }
        }
        int ff = 0;

        private void StartTimer()
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    if (!CPLC.Instance.IsConnectioned)
                    {
                        PLCstatus = "未连接";
                        CPLC.Instance.Connection();
                    }
                    else
                    {
                        PLCstatus = "已连接";
                    }
                    RunTime = $"已运行:{ff}s"; ff++;
                    Thread.Sleep(1000);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
