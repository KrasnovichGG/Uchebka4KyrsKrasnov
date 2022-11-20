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
using Uchebka4KyrsKrasnov.RegAndLog;

namespace Uchebka4KyrsKrasnov.AllWindows
{
    /// <summary>
    /// Логика взаимодействия для WinUserProf.xaml
    /// </summary>
    public partial class WinUserProf : Window
    {
        
        
        public WinUserProf()
        {
            InitializeComponent();
            FeelTextBox();
        }
        public void FeelTextBox()
        {
            txtBoxUserComm.Text = App.user.Information_User;
            TxtBoxNameUserProf.Text = App.user.Name_User;
            TxtBoxPersID.Text = Convert.ToString(App.user.Id_User);
            TxtBPhoneUSERpROF.Text = App.user.Phone;
            txtbroverka.Text = App.user.Auth.Role.Name_Role;
            if (App.user.Image.Length > 0)
                ImageUserProf.Source = new Bitmap(new MemoryStream(App.user.Image)).BitmapToImageSource();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
