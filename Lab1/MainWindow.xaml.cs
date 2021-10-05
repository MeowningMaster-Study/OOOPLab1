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
using Lab1Libraries.IP;

namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Log("Бесполезный графический интерфейс");
            Log(IPv4.Parse("255.255.255.255/0").ToString());
            Log(IPv6.Parse("::1/0").ToString());
            Log(IPv6.Parse("11:22:F3A3:44:55:C66:77:88/16").HasSubnet(IPv6.Parse("11::0")).ToString());
            Log(IPv4.Parse("255.255.255.255/0").ToIPv6().ToString());
        }

        void Log(string text)
        {
            logsBox.Text += '\n' + text;
        }
    }
}
