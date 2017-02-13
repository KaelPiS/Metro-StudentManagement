using MahApps.Metro.Controls;
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

namespace StudentManagement.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            //var t = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, Tick, this.Dispatcher);
            //var t1 = new DispatcherTimer(TimeSpan.FromMinutes(1), DispatcherPriority.Normal, Tick1, this.Dispatcher);
        }
        //int i = 0;int i1 = 01;
        //void Tick(object sender, EventArgs e)
        //{
        //    if (i < 10)
        //        = new TextBlock { Text = "0" + i.ToString(), SnapsToDevicePixels = true };
        //    else
        //        Hour.Content = new TextBlock { Text = i.ToString(), SnapsToDevicePixels = true };
        //    i++;
        //}
        //void Tick1(object sender, EventArgs e)
        //{
        //    if (i1 < 10)
        //        Minute.Content = new TextBlock { Text = "0" + i1.ToString(), SnapsToDevicePixels = true };
        //    else
        //        Minute.Content = new TextBlock { Text = i1.ToString(), SnapsToDevicePixels = true };
        //    i1++;
        //}
    }
}
