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
using Uchebka4KyrsKrasnov.DBword;

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
        public void ClearBox()
        {
            TxtBoxLogUser.Clear();
            PBLogUser.Clear();
        }
        private void BtnLogUser_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxLogUser.Text.Trim() == "" || PBLogUser.Password.Trim() == "")
            {
                MessageBox.Show("Пожалуйста введите коректные данные!", "Что-то не так!", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearBox();
                return;
            }
            else foreach (var user in App.word_Slovardb.Auth)
                {
                    if (user.Email_User == TxtBoxLogUser.Text.Trim())
                    {
                        if (user.Password == PBLogUser.Password.Trim() && user.Id_Role == 1)
                            MessageBox.Show($"Добро пожаловать: {user.User.Name_User},Ваша роль: {user.Role.Name_Role}", "Привет!", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (user.Password == PBLogUser.Password.Trim() && user.Id_Role == 2)
                            MessageBox.Show($"Добро пожаловать: {user.User.Name_User},Ваша роль: {user.Role.Name_Role}", "Привет!", MessageBoxButton.OK, MessageBoxImage.Information);

                        App.user = user.User;
                        MainWindow windowUser = new MainWindow();
                        windowUser.Show();
                        Close();
                    }
                }
            if(App.user == null)
            {
                MessageBox.Show("Неправильный логин или пароль!", "Что-то не так!", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearBox();
                return;
            }
        }
    }
}
