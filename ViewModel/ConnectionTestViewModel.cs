﻿using PLCControl.Model;
using PLCControl.PLC;
using PLCControl.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PLCControl.ViewModel
{
    class ConnectionTestViewModel : BaseViewModel
    {
        private DispatcherTimer timer = new DispatcherTimer();

        public static int i = 0;
        public List<string> _FFFF = new List<string>() { "11", "ddd", "ffff" };

        public List<string> FFFF { get { return _FFFF; } }
        public List<IOPoint> FIOPoints { get { return IOPoints; } set { IOPoints = value; } }
        List<IOPoint> IOPoints = new List<IOPoint>();

        private string _showMsg;

        public string ShouMsg
        {
            get { return _showMsg; }
            set { Set(ref _showMsg, value); }
        }

        public ConnectionTestViewModel()
        {
            i++;
            IOPoints.Add(new IOPoint() { Name = "ccc", Address = "W230.00", Status = true });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.01", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.02", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.03", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.04", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.05", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.06", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.07", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "W230.08", Status = false });
            StartTimer();
            ShouMsg = $"这是第{i}个窗口";
        }

        private void StartTimer()
        {
            CTimer.Instence.AddEventHandler("IO测试", (sender, e) =>
            {
                logger.Debug($"当前线程{Thread.CurrentThread.ManagedThreadId}进行PLC读写");
                Random random = new Random();
                foreach (var item in FIOPoints)
                {
                    if (item.IsTest)//如果开启测试 就随机写值
                    {
                        item.Status = !item.Status;
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
            logger.Debug($"IO读写线程:AWSL ");
            CTimer.Instence.DeleteEventHandler("IO测试");
        }
    }
}
