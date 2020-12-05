using PLCControl.Model;
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

namespace PLCControl.View
{
    /// <summary>
    /// TestPageView.xaml 的交互逻辑
    /// </summary>
    public partial class TestPageView : Page
    {
        List<IOPoint> IOPoints = new List<IOPoint>();

        public List<IOPoint> FIOPoints { get { return IOPoints; } set { IOPoints = value; } }

        public TestPageView()
        {
            InitializeComponent();

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

            ListView.ItemsSource = IOPoints;
        }
    }
}
