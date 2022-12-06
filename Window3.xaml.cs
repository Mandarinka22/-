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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        sobolevEntities database;
        public Window3(sobolevEntities db, Services_ service)
        {
            this.database = db;
            this.DataContext = service;

            InitializeComponent();
        }

        private void button(object sender, RoutedEventArgs e)
        {
            database.SaveChanges();
        }

        private void button1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}