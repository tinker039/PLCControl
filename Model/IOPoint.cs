using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCControl.Model
{

    public class IOPoint : INotifyPropertyChanged
    {
        /// <summary>
        /// IO点名称
        /// </summary>
        private string _name;
        /// <summary>
        /// IO点名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// PLC中地址
        /// </summary>
        private string _address;
        /// <summary>
        /// PLC中地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value; if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Address"));
            }
        }
        /// <summary>
        /// 当前状态
        /// </summary>
        private bool _status;


        /// <summary>
        /// 当前状态
        /// </summary>
        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
            }
        }

        /// <summary>
        /// 开启测试
        /// </summary>
        private bool _test = false;
        /// <summary>
        /// 是否开启测试
        /// </summary>
        public bool IsTest
        {
            get { return _test; }
            set { _test = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void Set<T>(ref T target, T value, string name = "")
        {
            target = value;
        }
    }
}
