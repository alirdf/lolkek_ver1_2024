using lolkek.DB_;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace lolkek.Win_
{
    /// <summary>
    /// Interaction logic for AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Window
    {
        private TbТовары t1 = new TbТовары();
        public AddEdit(TbТовары t2)
        {
            if(t2 != null)
                t1 = t2;
            DataContext = t1;
            InitializeComponent();
            CbКатегории.ItemsSource =lolkekEntities.GetContext().TbКатегории.ToList();
        }

        private void btBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            if (a.ShowDialog() == true)
            {
                string b = a.FileName;
                img.Source = new BitmapImage(new Uri(b));
                TbПуть_картинки.AppendText(b);
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (t1.Код_Товара == 0)
                lolkekEntities.GetContext().TbТовары.Add(t1);
            lolkekEntities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");
            this.Close();

        }
    }
}
