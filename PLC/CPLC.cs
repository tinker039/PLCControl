using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.LogNet;
using HslCommunication.Profinet.Omron;

namespace PLCControl.PLC
{
    public class CPLC
    {
        private static CPLC _instance;
        public static CPLC Instance { get { if (_instance == null) _instance = new CPLC(); return _instance; } }
        public OmronFinsNet _omronFinsNet;
        private string IP = "127.0.0.1";// PLC的IP地址
        private int Port { get; set; } = 9600;// PLC的端口
        public byte SA1 { get; set; } = 0x00; // PC网络号， PC的IP地址的最后一个数
        public byte DA1 { get; set; } = 0x00;  // PLC网络号，PLC的IP地址的最后一个数
        public byte DA2 { get; set; } = 0x00;

        // 实例化一个日志后，就可以使用了
        static ILogNet logNet = new LogNetSingle(".\\log.txt");
        #region 日志的基本使用
        /*
         // 然后我们的代码就可以调用下面的方法来存储日志了，支持下面的5个等级的
            logNet.WriteDebug( "Debug log test" );
            logNet.WriteInfo( "Info log test" );
            logNet.WriteWarn( "Warn log test" );
            logNet.WriteError( "Error log test" );
            logNet.WriteFatal( "Fatal log test" );

            // 还有下面的几种额外的情况
            logNet.WriteNewLine( );                       // 追加一行空行
            logNet.WriteDescrition( "test" );             // 写入额外的注释的信息
            logNet.WriteAnyString( "any string" );        // 写任意的数据，不受格式化影响

            // 此处的5个等级有高低之分 debug < info < warn < error < fatal < all
            // 如果我们需要屏蔽debug等级的话
            logNet.SetMessageDegree( HslMessageDegree.INFO );

            // 如果我们需要屏蔽debug及info等级的
            logNet.SetMessageDegree( HslMessageDegree.WARN );

            // 如果所有的日志在记录之前需要在控制台显示出来
            logNet.BeforeSaveToFile += (object sender, HslEventArgs e) =>
            {
                Console.WriteLine( e.HslMessage.ToString( ) );
            };

            // 带关键字的功能
            logNet.WriteDebug( "A","Debug log test" );
            logNet.WriteInfo( "B", "Info log test" );
            logNet.WriteWarn( "C", "Warn log test" );
            logNet.WriteError( "A", "Error log test" );
            logNet.WriteFatal( "B", "Fatal log test" );

            // 有了关键字之后，我们就可以根据关键字过滤了
            logNet.FiltrateKeyword( "B" ); // 我们不需要B的关键字的日志
            logNet.RemoveFiltrate( "B" );  // 重新需要B的关键字的日志
         
         */
        #endregion


        CPLC()
        {
            _omronFinsNet = new OmronFinsNet() { IpAddress = IP, Port = Port, SA1 = SA1, DA1 = DA1, DA2 = DA2, ConnectTimeOut = 1100 };
            #region 旧代码
            //OperateResult connect = _omronFinsNet.ConnectServer();
            //if (!connect.IsSuccess)
            //{
            //    Console.WriteLine("connect failed:" + connect.Message);
            //    return;
            //}
            #endregion

            _omronFinsNet.SetPersistentConnection();//长连接模式

            //日志记录之前现在控制台打印一遍
            logNet.BeforeSaveToFile += (object sender, HslEventArgs e) =>
            {
                Console.WriteLine(e.HslMessage.ToString());
            };
            logNet.WriteDebug("PLC", "PLC连接成功!");
        }
        /// <summary>
        /// 读取String类型数据
        /// </summary>
        /// <param name="Address">PLC寄存器地址</param>
        /// <param name="Length">读取数据的长度</param>
        /// <param name="IsFormatString">是否调整字符串顺序(不调整顺序错乱)</param>
        /// <returns>返回读取到的String类型数据,发生错误时返回Error</returns>
        public string ReadString(string Address, ushort Length, bool IsFormatString = true)
        {
            string strResult;
            OperateResult<string> operateResult = _omronFinsNet.ReadString(Address, Length);
            if (!operateResult.IsSuccess)
            {
                logNet.WriteError("PLC", $"读取String类型失败!    地址:{Address}    读取长度:{Length}");
                return "Error";
            }
            strResult = operateResult.Content;
            if (IsFormatString)
            {
                char[] chars = (strResult + "\0").ToCharArray();
                for (int i = 0; i * 2 + 1 < chars.Length; i++)
                {
                    char temp = chars[2 * i];
                    chars[2 * i] = chars[i * 2 + 1];
                    chars[i * 2 + 1] = temp;
                }
                strResult = new string(chars);
            }
            return strResult;
        }

        /// <summary>
        /// 向PLC写单个BOOL值,返回操作是否成功
        /// </summary>
        /// <param name="address">PLC地址</param>
        /// <param name="value">BOOL值</param>
        /// <returns>操作结果</returns>
        public bool WriteBool(string address, bool value)
        {
            OperateResult operateResult = _omronFinsNet.Write(address, value);
            return operateResult.IsSuccess;
        }
        /// <summary>
        /// 读单个bool值
        /// </summary>
        /// <param name="address">PLC地址</param>
        /// <returns>**读取失败返回false**</returns>
        public bool ReadBool(string address)
        {
            OperateResult<bool> operateResult = _omronFinsNet.ReadBool(address);
            if (operateResult.IsSuccess && operateResult.Content)
            {
                return true;
            }
            return false;
        }
    }
}
