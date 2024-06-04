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
            var alltype  = DB_.lolkekEntities.GetContext().TbКатегории.ToList();
            alltype.Insert(0, new DB_.TbКатегории
            {
                Название = "все типы"
            });
            CbСортировка.ItemsSource = alltype;
            CbСортировка.SelectedIndex = 0;
            lv1.ItemsSource = lolkekEntities.GetContext().TbТовары.ToList();
        }

        private void Update()
        {
            var select = CbСортировка.SelectedItem as TbКатегории;
            IQueryable<TbТовары> query = lolkekEntities.GetContext().TbТовары.Include(x => x.TbКатегории);
            if (select.Код_Категории != 0)
            {
                query = query.Where(x => x.Категория == select.Код_Категории);
            }

            if (!string.IsNullOrEmpty(TbПоиск.Text))
            {
                query = query.Where(x => x.Название.Contains(TbПоиск.Text) || x.Описание.Contains(TbПоиск.Text));
            }

            switch (Cbфильтр.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    query = query.OrderBy(x => x.Название);
                    break;
                case 2:
                    query = query.OrderByDescending(x => x.Название);
                    break;
            }

            lv1.ItemsSource = query.ToList();
        }

        private void BtnРедактировать_Click(object sender, RoutedEventArgs e)
        {
            Win_.AddEdit a = new Win_.AddEdit((sender as Button).
            DataContext as TbТовары);
            a.Show();
        }
        private void BtnДобавить_Click(object sender, RoutedEventArgs e)
        {
            Win_.AddEdit a = new Win_.AddEdit(null);
            a.Show();
        }
      

        private void TbПоиск_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void CbСортировка_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Cbфильтр_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
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

        private void BtnНазад_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
