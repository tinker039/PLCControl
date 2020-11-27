using PLCControl.PLC;
using PLCControl.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PLCControl
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new ConnectionTestView();
            StartTimer();
        }

        /// <summary>
        /// 切换显示界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            if (btn.Content.ToString() == "aaa")
                MainFrame.Content = new ConnectionTestView();

        }
        int ff = 0;
        private void StartTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(10000000);//间隔为一秒
            timer.Tick += (sender, e) => { txtTime.Text = ff.ToString(); ff++; };
            timer.Start();
        }

    }
}
