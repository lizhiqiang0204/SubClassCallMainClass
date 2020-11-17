using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SubClassCallMainClass
{
    public class Work
    {
        public void DoWork(MainWindow mainWindow)
        {
            var order = Task.Run(() =>
            {
                for (; ; )
                {
                    mainWindow.num++;//更改MainWindow.xaml.cs主类的属性
                    Thread.Sleep(1000);
                    mainWindow.myWriteLog(Brushes.Red, $"子类调用主类的方法,并且更改主类属性num:{mainWindow.num}");//访问MainWindow.xaml.cs主类的方法
                }
            });
        }

    }
}
