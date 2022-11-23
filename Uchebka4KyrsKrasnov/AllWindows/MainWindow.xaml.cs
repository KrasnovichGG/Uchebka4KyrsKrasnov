using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using Uchebka4KyrsKrasnov.RegAndLog;

namespace Uchebka4KyrsKrasnov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime todayDay = DateTime.Now;
        string dayWord;
        string trans;
        public static bool isAdmin = true;
        DateTime LastDay = DateTime.Now;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "Test.txt";
        List<Word> workList = new List<Word>();
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            LastDay = GetLastDay();
            CmbsORT.ItemsSource = FillCmbsORT();
            LstALLword.ItemsSource = App.word_Slovardb.Word.ToList();
            workList = App.word_Slovardb.Word.ToList();
            isadmin();

        }

        private DateTime GetLastDay()
        {
            if (!File.Exists(path))
            {
                return new DateTime(2012, 12, 12);
            }
            using (StreamReader sr = new StreamReader(path))
            {
                var ab = sr.ReadLine();

                if (ab.ToString() == null)
                {
                    sr.Close();
                    return new DateTime(2012, 12, 12);
                }
                var a = ab.ToString();
                string[] arr = a.Split(';');
                dayWord = arr[0];
                trans = arr[2];
                return Convert.ToDateTime(arr[1]);
            }
        }

        private List<char> FillCmbsORT()
        {
            List<Char> list = new List<Char>();

            for (char ch = 'А'; ch <= 'Я'; ch++)
            {
                list.Add(ch);
            }

            return list;
        }

        private void isadmin()
        {
            if (App.user.Auth.Id_Role == 1)
            {
                BtnHELPuSER.Visibility = Visibility.Hidden;
                Btn_exit.Visibility = Visibility.Hidden;
            }
            else if (App.user.Auth.Id_Role == 2)
            {
                BtnRemoveWord.Visibility = Visibility.Hidden;
                BtnADDWORD.Visibility = Visibility.Hidden;
                isAdmin = false;
            }
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

        private void BtnRemoveWord_Click(object sender, RoutedEventArgs e)
        {
            WinDeleteWord winDeleteWord = new WinDeleteWord();
            winDeleteWord.DeleteWord += () => { LstALLword.ItemsSource = App.word_Slovardb.Word.ToList(); };
            winDeleteWord.ShowDialog();
        }

        private void btnVixodinAutariz_Click(object sender, RoutedEventArgs e)
        {
            var a = MessageBox.Show("Вы точно хотите выйти в окно авторизации пользователей?", "??", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (MessageBoxResult.Yes == a)
            {
                WinLog winLog = new WinLog();
                winLog.Show();
                Close();
            }
        }

        private void BtnHELPuSER_Click(object sender, RoutedEventArgs e)
        {
            WinHelp winHelp = new WinHelp();
            winHelp.ShowDialog();
        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            var b = MessageBox.Show("Вы точно хотите выйти из приложения?", "??", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (MessageBoxResult.Yes == b)
            {
                Application.Current.Shutdown();
            }
        }

        private void CmbsORT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbsORT.SelectedIndex == -1)
                return;
            var ch = (Char)CmbsORT.SelectedItem;
            List<Word> lst = App.word_Slovardb.Word.ToList();
            workList = lst.Where(x => x.Value_Word[0].ToString() == ch.ToString()).ToList();
            LstALLword.ItemsSource = workList;
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            workList = App.word_Slovardb.Word.ToList();
            LstALLword.ItemsSource = workList;
            TxtbPoisk.Clear();
            CmbsORT.SelectedIndex = -1;
        }

        private void TxtbPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtbPoisk.Text.Trim() == "")
            {
                workList = App.word_Slovardb.Word.ToList();
                CmbsORT_SelectionChanged(null, null);
                LstALLword.ItemsSource = workList;
            }
            else
            {
                CmbsORT_SelectionChanged(null, null);
                LstALLword.ItemsSource = workList.Where(x => x.Value_Word.ToLower().Contains(TxtbPoisk.Text.ToLower())).ToList();
            }
        }

        private async void btnWORDDay_Click(object sender, RoutedEventArgs e)
        {
            LastDay = GetLastDay();
            if (todayDay.Date != LastDay.Date)
            {
                Random RND = new Random();
                var lst = App.word_Slovardb.Word.ToList();
                SlovoDnyPnl.Visibility = Visibility.Visible;
                var er = (lst[RND.Next(0, lst.Count)]);
                WordTxt.Text = er.Value_Word;
                TransTxt.Text = er.Transcription_Word;
                DateTxt.Text = LastDay.Date.ToString();
                await Task.Run(() => Thread.Sleep(5000));
                SlovoDnyPnl.Visibility = Visibility.Collapsed;
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(WordTxt.Text + ";" + todayDay + ";" + TransTxt.Text);
                }
            }
            else
            {
                var lst = App.word_Slovardb.Word.ToList();
                SlovoDnyPnl.Visibility = Visibility.Visible;
                WordTxt.Text = dayWord;
                TransTxt.Text = trans;
                DateTxt.Text = todayDay.ToString();
                await Task.Run(() => Thread.Sleep(5000));
                SlovoDnyPnl.Visibility = Visibility.Collapsed;
            }
        }
    }
}
