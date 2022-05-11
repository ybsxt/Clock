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
using Microsoft.Win32;

namespace Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Timer.Interval = new TimeSpan(1000000);
            Timer.Tick += new EventHandler(timer_tick);
            Timer.Start();
            Time.Text = DateTime.Now.ToString("HH:mm:ss");
            Date.Text = DateTime.Now.ToString("yyyy年MM月dd日") + " " + weekdays[Convert.ToInt32(DateTime.Now.DayOfWeek)];
        }

        private DispatcherTimer Timer = new DispatcherTimer();
        private string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };

        private void timer_tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString("HH:mm:ss");
            Date.Text = DateTime.Now.ToString("yyyy年MM月dd日") + " " + weekdays[Convert.ToInt32(DateTime.Now.DayOfWeek)];
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

       

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Escape) this.Close();
            if (e.Key == Key.T) Topmost = !Topmost;
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Timer.Stop();
        }
    }
}
