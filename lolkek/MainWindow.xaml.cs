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
using System.Data.Entity.Infrastructure;

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
            var alltyp = lolkekEntities.GetContext().TbКатегории.ToList();
            alltyp.Insert(0, new DB_.TbКатегории
            {
                Название = "Все типы"
            });

            CbСортировка.ItemsSource = alltyp;
            CbСортировка.SelectedIndex = 0;
            lv1.ItemsSource = lolkekEntities.GetContext().TbТовары.ToList();
        }

        private void Update()
        {
            var selectedCategory = CbСортировка.SelectedItem as TbКатегории;
            IQueryable<TbТовары> query = lolkekEntities.GetContext().TbТовары.Include(mk => mk.TbКатегории);

            if (selectedCategory.Код_Категории != 0)
            {
                query = query.Where(t => t.Категория == selectedCategory.Код_Категории);
            }

            if (!string.IsNullOrEmpty(TbПоиск.Text))
            {
                query = query.Where(t => t.Название.Contains(TbПоиск.Text) ||
                                        t.TbКатегории.Название.Contains(TbПоиск.Text) ||
                                        t.Описание.Contains(TbПоиск.Text));
            }

            switch (Cbфильтр.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    query = query.OrderBy(t => t.Название);
                    break;
                case 2:
                    query = query.OrderByDescending(t => t.Название);
                    break;
            }

            lv1.ItemsSource = query.ToList();
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

        private void BtnВход_Click(object sender, RoutedEventArgs e)
        {
            Win_.Auto a = new Win_.Auto();
            a.Show();
            
        }
    }
}
