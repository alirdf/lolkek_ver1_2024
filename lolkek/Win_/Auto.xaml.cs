using lolkek.DB_;
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
    /// Interaction logic for Auto.xaml
    /// </summary>
    public partial class Auto : Window
    {
        public Auto()
        {
            InitializeComponent();
        }

        private void AuBut_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var user = lolkekEntities.GetContext().TbПользоавтели.
                    FirstOrDefault(x => x.Логин == AuLog.Text 
                    && x.Пароль == AuPas.Password);
                if (user != null)
                {
                    Win_.ViewEdit a = new Win_.ViewEdit();
                    a.Show();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Не правильный логин или пароль");
                }
            }
            catch { MessageBox.Show("Ошибка"); };
        }

        private void ReBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                TbПользоавтели пользоавтели = new TbПользоавтели()
                {
                    Логин = ReLog.Text,
                    Пароль = RePas.Password,
                    //Роль = Convert.ToInt16(ReLog.Text)
                    // Роль = int.Parse(RePas.Password)
                };
                lolkekEntities.GetContext().TbПользоавтели.AddOrUpdate(пользоавтели);
                lolkekEntities.GetContext().SaveChanges();
                MessageBox.Show("Регистрация успешная");
            }
            catch { MessageBox.Show("Ощибка регистрации"); };
        }
    }
}
