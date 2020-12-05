using PLCControl.PLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PLCControl.Timer
{
    class CTimer
    {
        private static CTimer _instence;
        public static CTimer Instence { get { if (_instence == null) _instence = new CTimer(); return _instence; } }
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private Dictionary<string, EventHandler> UsingEventDic = new Dictionary<string, EventHandler>();

        /// <summary>
        ///一个计时器,用来处理后台数据
        /// </summary>
        private Dictionary<string, EventHandler> _currectEventDic;

        /// <summary>
        /// 线程
        /// </summary>
        private Thread thread;

        /// <summary>
        /// 一个字典,保存计时器中的委托
        /// </summary>
        public Dictionary<string, EventHandler> EventDic { get { if (_currectEventDic == null) _currectEventDic = new Dictionary<string, EventHandler>(); return _currectEventDic; } }
        private CTimer()
        {
            thread = new Thread(Tick);
            thread.IsBackground = true;
            thread.Start();
        }
                           
        private void Tick()
        {
            while (true)
            {
                //一个类似心跳的操作,如果无法写入视为PLC断开
                if (!CPLC.Instance.IsConnectioned)
                    continue;
                if (EventDic.Count == 0)
                {
                    continue;
                }

                foreach (EventHandler @event in EventDic.Values)
                {
                    @event(null, null);
                }

                Thread.Sleep(700);
            }

        }

        /// <summary>
        /// 添加一个委托,每0.1秒执行一次
        /// </summary>
        /// <param name="key">一个通俗易懂的Key,用来删除这个委托</param>
        /// <param name="e">委托本身</param>
        /// <returns></returns>
        public int AddEventHandler(string key, EventHandler e)
        {
            if (EventDic.ContainsKey(key))
                return -1;
            _currectEventDic.Add(key, e);
            logger.Debug("CTimer:", $"添加一个委托: {key} \t{e}");
            return EventDic.Count;
        }

        /// <summary>
        /// 这个事不用干了
        /// </summary>
        /// <param name="key">一个通俗易懂的Key,用来删除这个委托</param>
        /// <param name="e">委托本身</param>
        /// <returns></returns>
        public int DeleteEventHandler(string key)
        {
            if (!EventDic.ContainsKey(key))
                return -1;
            logger.Debug("CTimer:", $"删除一个委托: {key} \t{_currectEventDic[key]}");
            _currectEventDic.Remove(key);

            return EventDic.Count;
        }
        /// <summary>
        /// 清空所有
        /// </summary>
        public void Clear()
        {
            if (EventDic.Count == 0)
                return;
            foreach (var item in _currectEventDic.Values)
                _currectEventDic.Clear();
            logger.Debug("CTimer:", $"删除所有委托");
        }
    }
}
