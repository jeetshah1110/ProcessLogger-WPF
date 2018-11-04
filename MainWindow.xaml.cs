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
using System.IO;
using System.Diagnostics;
using System.IO;
namespace ProcessLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string str1 = null, str2 = null, str3 = null;
            Button bobj = sender as Button;
            if (File.Exists("LOG.txt"))
            {
                File.Delete("LOG.txt");

            }
            StreamWriter sw = new StreamWriter("LOG.txt", append: true);
            var ProList = Process.GetProcesses();
            foreach (Process p in ProList)
            {
                str1 = str1 + p.ProcessName + "\n";

                str2 = str2 + Convert.ToString(p.VirtualMemorySize64) + "\n";
                str3 = str3 + Convert.ToString(p.Id) + "\n";


                sw.WriteLine(p.ProcessName + "\t" + Convert.ToString(p.VirtualMemorySize64) + "\t" + Convert.ToString(p.Id));


            }
            textbox1.Text = str1;
            textbox2.Text = str2;
            textbox3.Text = str3;

            sw.Close();


        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            textbox2.Text = "";
            textbox3.Text = "";
        }
    }
}
