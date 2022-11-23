using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Uchebka4KyrsKrasnov.DBword;

namespace Uchebka4KyrsKrasnov
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Word_SlovarEntities word_Slovardb = new Word_SlovarEntities();
        public static User user;
        public static Role role;
    }
}
