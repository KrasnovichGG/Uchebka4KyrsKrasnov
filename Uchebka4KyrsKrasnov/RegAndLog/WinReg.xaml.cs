using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace Uchebka4KyrsKrasnov.RegAndLog
{
    /// <summary>
    /// Логика взаимодействия для WinReg.xaml
    /// </summary>
    public partial class WinReg : Window
    {
        public string FilePath;
        public WinReg()
        {
            InitializeComponent();
        }
        private void Btnback_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void Contains()
        {
            var user = App.word_Slovardb.Auth.Where(x =>x.Email_User == txtBoxEmailUser.Text && x.Password == TxtBoxPassword.Text).FirstOrDefault();
            if (user != null)
            {
                throw new Exception("Такой пользователь уже сущесвует пожалуста введите другие данные!");
            }

        }
        public bool ProverkaProbel()
        {
            if(TxtBCommentUser.Text.Trim() == "" || TxtbRegPhone.Text.Trim() == "" || TxtBCommentUser.Text.Trim() == "" || txtBoxEmailUser.Text.Trim() == "" || TxtBoxPassword.Text.Trim() == "" || Image_USER.Source == null)
            {
                MessageBox.Show("Пожалуйства введите все данные!","Что-то не так!",MessageBoxButton.OK,MessageBoxImage.Error);
                return true;
            }
            return false;
        }
        public void ClearBoxes()
        {
            TxtbRegName.Clear();
            TxtbRegPhone.Clear();
            TxtBCommentUser.Clear();
            txtBoxEmailUser.Clear();
            TxtBoxPassword.Clear();
            Image_USER.Source = null;
        }
        //Нужна проверка на невыбранное изображеник
        private void BtnAddImageToWin_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                Image_USER.Source = new Bitmap(openFileDialog.FileName).BitmapToImageSource();
            }
        }

        private void BtnSaveDB_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                if (ProverkaProbel())
                    return;
                Contains();
                User user = new User()
                {
                    Name_User = TxtbRegName.Text.Trim(),
                    Information_User = TxtBCommentUser.Text.Trim(),
                    Phone = TxtbRegPhone.Text.Trim(),
                    Image = File.ReadAllBytes(FilePath),
                };
                App.word_Slovardb.User.Add(user);
                App.word_Slovardb.SaveChanges();
                Auth auth = new Auth()
                {
                    Email_User = TxtbRegName.Text.Trim(),
                    Password = TxtBoxPassword.Text.Trim(),
                    Role = App.word_Slovardb.Role.Where(x => x.Id_Role == 2).FirstOrDefault(),
                    Id_User = user.Id_User
                };
                App.word_Slovardb.Auth.Add(auth);
                App.word_Slovardb.SaveChanges();
                MessageBox.Show("Успешно!");
                ClearBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
    static class Extensions
    {
        public static BitmapImage BitmapToImageSource(this Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }
    }
}
