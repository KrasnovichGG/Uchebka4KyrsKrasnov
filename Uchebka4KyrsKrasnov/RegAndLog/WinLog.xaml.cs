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
using System.Windows.Shapes;
using Uchebka4KyrsKrasnov.AllWindows;

namespace Uchebka4KyrsKrasnov.RegAndLog
{
    /// <summary>
    /// Логика взаимодействия для WinLog.xaml
    /// </summary>
    public partial class WinLog : Window
    {
        public WinLog()
        {
            InitializeComponent();
        }

        private void BtnRegUser_Click(object sender, RoutedEventArgs e)
        {
            WinReg winReg = new WinReg();
            winReg.ShowDialog();
        }

        private void BtnHelpUser_Click(object sender, RoutedEventArgs e)
        {
            WinHelp winHelp = new WinHelp();
            winHelp.ShowDialog();
        }
    }
}
