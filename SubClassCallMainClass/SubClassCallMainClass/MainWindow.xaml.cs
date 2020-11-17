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

namespace SubClassCallMainClass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int num = 0;
        public MainWindow()
        {
            InitializeComponent();
            myWriteLog(Brushes.Black, "主类调用自己的方法");

        }

        #region 打印日志方法

        public void myWriteLog(SolidColorBrush color, string str)
        {
            myParagraph.Dispatcher.Invoke(new Action(() =>
            {
                Run run = new Run() { Text = str, Foreground = color };
                myParagraph.Inlines.Add(run);
                myParagraph.Inlines.Add(new LineBreak());//换行（如果用\r\n也能换行，但是要把内容拷贝到Word里面\r\n换行符不能识别，推荐使用LineBreak()来换行）
            }));
        }

        #endregion
        private void LogTextChanged(object sender, TextChangedEventArgs e)
        {
            RichTextBox richTextBox = sender as RichTextBox;
            richTextBox.ScrollToEnd();
        }

        private void BtnClickWork(object sender, RoutedEventArgs e)
        {
            Work myWork = new Work();//实例化子类Work
            myWork.DoWork(this);//this 就是MainWindow类的实例,通过参数传递给子类Work,这样Work类就可以访问MainWindow的属性和方法了
        }

        private void BtnClickDis(object sender, RoutedEventArgs e)
        {
            myWriteLog(Brushes.Black, $"主类num{num}");
        }
    }
}
