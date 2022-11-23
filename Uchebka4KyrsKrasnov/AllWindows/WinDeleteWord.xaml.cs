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
    /// Логика взаимодействия для WinDeleteWord.xaml
    /// </summary>
    public partial class WinDeleteWord : Window
    {
        public event Action DeleteWord;
        public WinDeleteWord()
        {
            InitializeComponent();
            FeelCmbBox();
        }
         public void FeelCmbBox()
        {
            cmbboxDeleteWord.ItemsSource = App.word_Slovardb.Word.ToList();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void ClearCmbBox()
        {
            cmbboxDeleteWord.SelectedIndex = -1;
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            var dw = cmbboxDeleteWord.SelectedItem as Word;
            App.word_Slovardb.Word.Remove(dw);
            App.word_Slovardb.SaveChanges();
            DeleteWord?.Invoke();
            MessageBox.Show("Успешное удаление!", "Молодец!", MessageBoxButton.OK, MessageBoxImage.Information);
            ClearCmbBox();
        }
    }
}
