using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
    public partial class Window2 : Window
    {
        sobolevEntities db;
        List<Clients> ClientsList;
        public Window2()
        {
            InitializeComponent();
            db = new sobolevEntities();
            ClientsList = db.Clients.ToList();
            Table2.ItemsSource = ClientsList;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Window1 w1 = new Window1();
            w1.Show();
            this.Close();
        }
    }
}
