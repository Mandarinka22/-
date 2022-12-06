using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        sobolevEntities db;
        List<Services_> servicesList;

        public Window1()
        {
            InitializeComponent();
            db = new sobolevEntities();
            servicesList = db.Services_.ToList();
            Table1.ItemsSource = servicesList;
        }
        
            private void refreshdatagrid()
            {
            Table1.ItemsSource = db.Services_.ToList();
            Table1.Items.Refresh();
            }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button b1 = sender as Button;
            var b2 = b1.DataContext as Services_;
            OpenFileDialog i = new OpenFileDialog();
            i.Title = "Выберите фотографию";
            i.Filter = "All supported graphics|*.jpeg;*.jpg;*.png|" + " JPEG(*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (i.ShowDialog() == true)
            {
                b2.ServicesImages = new ServicesImages { ImagePath = i.FileName };
            }
            Window4 newClientWindow = new Window4(db, b2);
            newClientWindow.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            db = new sobolevEntities();
            Services_ item = Table1.SelectedItem as Services_;
            try
            {
                Services_ service = db.Services_.Where(c => c.Id == item.Id).Single();
                db.Services_.Remove(service);
                db.SaveChanges();
                MessageBox.Show("Клиент успешно удалён!");
                refreshdatagrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var nw = new Services_();
            db.Services_.Add(nw);
            OpenFileDialog das = new OpenFileDialog();
            das.Title = "Выберите фотографию";
            das.Filter = "All supported graphics|*.jpeg;*.jpg;*.png|" + " JPEG(*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (das.ShowDialog() == true)
            {
                nw.ServicesImages = new ServicesImages { ImagePath = das.FileName };
            }
            Window3 newClientWindow = new Window3(db, nw);
            newClientWindow.ShowDialog();
            MessageBox.Show("Клиент успешно добавлен");
            refreshdatagrid();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Window2 w2 = new Window2();
            w2.Show();
            this.Close();
        }
    }
}
