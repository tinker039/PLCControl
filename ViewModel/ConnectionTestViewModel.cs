using PLCControl.Model;
using PLCControl.PLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PLCControl.ViewModel
{
    class ConnectionTestViewModel
    {

        public List<string> _FFFF = new List<string>() { "11", "ddd", "ffff" };

        public List<string> FFFF { get { return _FFFF; } }
        public List<IOPoint> FIOPoints { get { return IOPoints; } set { IOPoints = value; } }


        List<IOPoint> IOPoints = new List<IOPoint>() { new IOPoint() { Name = "aaa", Address = "D10.04", Status = false },
      new IOPoint() { Name = "bbb", Address = "D10.05", Status = false }  };
        public ConnectionTestViewModel()
        {
            IOPoints.Add(new IOPoint() { Name = "ccc", Address = "D10.01", Status = true });
            IOPoints.Add(new IOPoint() { Name = "ddd", Address = "D10.02", Status = false });
            IOPoints.Add(new IOPoint() { Name = "eee", Address = "D10.03", Status = false });
            StartTimer();
        }

        private void StartTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(10000000);//间隔为一秒
            timer.Tick += (sender, e) =>
            {
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

            };
            timer.Start();
        }

    }
}
