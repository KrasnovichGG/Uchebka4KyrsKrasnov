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
using Uchebka4KyrsKrasnov.DBword;

namespace Uchebka4KyrsKrasnov.AllWindows
{
    /// <summary>
    /// Логика взаимодействия для WinAddWord.xaml
    /// </summary>
    public partial class WinAddWord : Window
    {
        public event Action AddWord;
        public WinAddWord()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void ClearBox()
        {
            TxtboxValueWord.Clear();
            TxtboxTranskription.Clear();
        }

        private void BtnSaveinDB_Click(object sender, RoutedEventArgs e)
        {
            if (TxtboxTranskription.Text == "" || TxtboxValueWord.Text == "")
            {
                MessageBox.Show("Не оставляйте незаполенные поля, или же информация не сохранится", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if ((App.word_Slovardb.Word.Where(x => x.Value_Word.ToLower() == TxtboxValueWord.Text.ToLower()).FirstOrDefault() != null))
            {
                MessageBox.Show("Такое слово уже существует!😘", "Да, это проверка на одинаковые слова", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearBox();
            }
            else
            {
                Word word = new Word();
                word.Value_Word = TxtboxValueWord.Text;
                word.Transcription_Word = TxtboxTranskription.Text;
                App.word_Slovardb.Word.Add(word);
                App.word_Slovardb.SaveChanges();
                AddWord?.Invoke();
                MessageBox.Show("Успешное добавление!", "Слово добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearBox();
            }
        }
    }
}
