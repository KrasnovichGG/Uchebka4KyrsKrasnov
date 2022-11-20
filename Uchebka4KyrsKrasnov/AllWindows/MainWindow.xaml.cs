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
using Uchebka4KyrsKrasnov.AllWindows;
using Uchebka4KyrsKrasnov.DBword;

namespace Uchebka4KyrsKrasnov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            LstALLword.ItemsSource = App.word_Slovardb.Word.ToList();
        }

        private void BtnMyProfile_Click(object sender, RoutedEventArgs e)
        {
            WinUserProf winUserProf = new WinUserProf();
            winUserProf.ShowDialog(); ;

        }

        private void BtnADDWORD_Click(object sender, RoutedEventArgs e)
        {
            WinAddWord winAddWord = new WinAddWord();
            winAddWord.AddWord += () => { LstALLword.ItemsSource = App.word_Slovardb.Word.ToList(); };
            winAddWord.ShowDialog();
        }
    }
}
