using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace Uchebka4KyrsKrasnov.AllWindows
{
    /// <summary>
    /// Логика взаимодействия для WinHelp.xaml
    /// </summary>
    public partial class WinHelp : Window
    {
        public WinHelp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void Cleartxtbox()
        {
            TxtBoTZIV.Clear();
            TxtBoxEmail.Clear();
            TxtBoxName.Clear();
            TxTboxTEMA.Clear();
            TxtBPhone.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxTboxTEMA.Text) || string.IsNullOrEmpty(TxtBoxEmail.Text) || string.IsNullOrEmpty(TxtBPhone.Text) || string.IsNullOrEmpty(TxtBoxName.Text))
            {
                MessageBox.Show("Пожалуйста заполните все данные!");
                Cleartxtbox();
            }
            else
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Credentials = new NetworkCredential("Sasha-kr90@bk.ru", "FiGrJ8bzefcXDz3iWfwX");
                    smtpClient.Host = ("smtp.mail.ru");
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.From = new MailAddress("Sasha-kr90@bk.ru");
                    mailMessage.To.Add(new MailAddress(TxtBoxEmail.Text));
                    mailMessage.Subject = "Тема сообщения: " + TxTboxTEMA.Text;
                    mailMessage.Body = TxtBoxEmail.Text;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = ($"Привет : {TxtBoxName.Text}, я обязательно отвечу на твой отзыв, если ты чуть-чуть подождешь:), а пока что ознакомься с тем, что ты меня отправил! " + "<br>" + "Имя: " + TxtBoxName.Text + "<br>" + "Телефон: " + TxtBPhone.Text + "<br>" + "Почта: " + TxtBoxEmail.Text + "<br>" + "Текст сообщения: " + TxtBoTZIV.Text);
                    smtpClient.Send(mailMessage);
                    MessageBox.Show("Ваше сообщение отправлено!");
                    Cleartxtbox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
