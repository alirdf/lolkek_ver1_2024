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
using System.Windows.Shapes;
using System.Data.Entity;

namespace lolkek.Win_
{
    /// <summary>
    /// Interaction logic for ViewEdit.xaml
    /// </summary>
    public partial class ViewEdit : Window
    {
        public ViewEdit()
        {
            InitializeComponent();
            lv1.ItemsSource = lolkekEntities.GetContext().TbТовары.ToList();
        }

        private void BtnРедактировать_Click(object sender, RoutedEventArgs e)
        {
            Win_.AddEdit a = new Win_.AddEdit((sender as Button).DataContext as TbТовары);
            a.Show();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbПоиск_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CbСортировка_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cbфильтр_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnДобавить_Click(object sender, RoutedEventArgs e)
        {
            Win_.AddEdit a = new Win_.AddEdit(null);
            a.Show();
        }

        private void BtnУдалить_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var r1 = lv1.SelectedItems.Cast<TbТовары>().ToList();
                if (MessageBox.Show($"Точно удалить", "Внимание",
                    MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                {
                    lolkekEntities.GetContext().TbТовары.RemoveRange(r1);
                    lolkekEntities.GetContext().SaveChanges();
                    MessageBox.Show("Удалено");
                    lv1.ItemsSource = lolkekEntities.GetContext().TbТовары.ToList();
                }
            }
            catch { MessageBox.Show("Ошибка"); }
        }
    }
}
