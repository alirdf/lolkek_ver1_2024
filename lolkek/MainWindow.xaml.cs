using lolkek.DB_;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace lolkek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var a = lolkekEntities.GetContext().TbТовары.ToList();
            a.Insert(0, new TbТовары { Название = "Все" });
            CbСортировка.SelectedIndex = 0;
            CbСортировка.ItemsSource = a;
            lv1.ItemsSource = lolkekEntities.GetContext().TbТовары.ToList();
        }

        private void Update()
        {
            var b = CbСортировка.SelectedItem as TbТовары; 
            IQueryable<TbТовары> a = lolkekEntities.GetContext().TbТовары;
            if(b.Код_Товара != 0)
            {
                a = a.Where(x =>x.Категория == b.Код_Товара);
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TbПоиск_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CbСортировка_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Cbфильтр_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnВход_Click(object sender, RoutedEventArgs e)
        {
            Win_.Auto a = new Win_.Auto();
            a.Show();
            this.Close();
        }
    }
}
