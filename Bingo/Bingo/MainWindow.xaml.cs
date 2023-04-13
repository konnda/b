using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace Bingo
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        int num_count = 0;
        int?[] published_num = new int?[42];
        int x = 0;
        string SoundFile = "bingo.wav";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            No1.Text = string.Join(" ", published_num);

            SoundPlayer player = new SoundPlayer(@"E:\bingo.wav");
            player.Play();

            Random new_num = new Random();
            for(int i = 0; i < 30; i++)//数字を適当に表示したい
            {
                textbox1.Text = new_num.Next(1,42).ToString();
                System.Threading.Thread.Sleep(100);
            }

            x = new_num.Next(1, 42);
            for(int i = 0;num_count > i; i++)
            {
                if(x == published_num[i])
                {
                    x = new_num.Next(1, 42);
                    i = 0;
                }
            }
            textbox1.Text = x.ToString();
            published_num[num_count] = x;
            num_count++;
            if (num_count == 42)
            {
                num_count = 0;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
