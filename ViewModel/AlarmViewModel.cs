using PLCControl.Model;
using PLCControl.PLC;
using PLCControl.Timer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PLCControl.ViewModel
{
    class AlarmViewModel : BaseViewModel
    {
        private List<IOPoint> _alarmList = new List<IOPoint>();
        public List<IOPoint> AlarmList { get { return _alarmList; } set { Set(ref _alarmList, value); } }


        private List<IOPoint> _tempAlarmList = null;
        public List<IOPoint> TempAlarmList { get { if (_tempAlarmList == null) return _alarmList; return _tempAlarmList; } set { Set(ref _tempAlarmList, value); } }
        /// <summary>
        /// 把报警分为两部分  - 第一部分
        /// </summary>
        public List<IOPoint> AlarmList1 { get { return _alarmList.GetRange(0, _alarmList.Count / 2); } }
        /// <summary>
        /// 把报警分为两部分  - 第二部分
        /// </summary>
        public List<IOPoint> AlarmList2 { get { return _alarmList.GetRange(_alarmList.Count / 2, _alarmList.Count / 2); } }

        private bool _isScreen = false;
        public bool IsScreen { get { return _isScreen; } set { Set(ref _isScreen, value); } }

        public AlarmViewModel()
        {
            string[] msgs = File.ReadAllLines("./DB File/Alarm.csv");
            for (int i = 1; i < msgs.Length; i++)
            {
                string[] temp = msgs[i].Split(',');
                if (string.IsNullOrWhiteSpace(temp[0]) || string.IsNullOrWhiteSpace(temp[1]))
                    continue;
                AlarmList.Add(new IOPoint() { Name = temp[1], Address = temp[0], Status = false });
            }
            StartTimer();
        }


        private void StartTimer()
        {
            CTimer.Instence.AddEventHandler("报警信息", (sender, e) =>
            {
                logger.Debug($"当前线程{Thread.CurrentThread.ManagedThreadId}进行PLC读写");
                Random random = new Random();
                foreach (var item in AlarmList)
                {
                    if ((item.IsTest != item.Status))//如果开启测试 就随机写值
                    {
                        item.Status = item.IsTest;
                        //写入PLC
                        if (!CPLC.Instance.WriteBool(item.Address, item.Status))
                        { throw new Exception("写入PLC地址bool失败  connectiontextviewmodel.cs  56"); }
                    }
                    item.Status = CPLC.Instance.ReadBool(item.Address);
                }
            });
        }


        public void Unloaded(object sender, RoutedEventArgs e)
        {
            logger.Debug($"报警信息:AWSL ");
            CTimer.Instence.DeleteEventHandler("报警信息");
        }


        public void Screen(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sender.ToString()))
            {
                TempAlarmList = AlarmList;
                IsScreen = false;
            }
            TempAlarmList = AlarmList.Where(p => { return p.Name.Contains(sender.ToString()); }).ToList();
            IsScreen = true;

        }
    }
}
