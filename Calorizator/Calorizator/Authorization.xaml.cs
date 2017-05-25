using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace Calorizator
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }



        private void button_enter_Click(object sender, RoutedEventArgs e)
        {
            List<_Authorization> Check = new List<_Authorization>();
            BinaryFormatter formatter = new BinaryFormatter();
            List<_Authorization> Logins;
            using (FileStream fs = new FileStream("../../users.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    Logins = (List<_Authorization>)formatter.Deserialize(fs);
                }
                catch
                {
                    Logins = new List<_Authorization>();
                }
            }

            foreach (_Authorization a in Logins)
            {

                if (textBox_login.Text == "")
                {
                    MessageBox.Show("Введите логин!");
                    return;
                }

                if (passwordBox.Password == "")

                {
                    MessageBox.Show("Введите пароль!");
                    return;
                }

                if ((textBox_login.Text == a.Login)&(passwordBox.Password != a.Password))

                {
                    MessageBox.Show("Неверный пароль! Попробуйте еще раз.");
                    passwordBox.Clear();
                    return;

                }


                if ((textBox_login.Text == a.Login) & (passwordBox.Password == a.Password))

                {
                    Check.Add(a);
                    NavigationService.Navigate(new MainPage());
                    return;

                }



            }
            if (Check.Count == 0)
            {
                MessageBox.Show("Пользователя с таким логином нет!");
                textBox_login.Clear();
                passwordBox.Clear();
                return;
            }
        }

        private void button_reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void button_enter_MouseEnter(object sender, MouseEventArgs e)
        {
            button_enter.FontSize = 16;
        }
        
        private void button_reg_MouseEnter(object sender, MouseEventArgs e)
        {
            button_reg.FontSize = 16;
        }
      
        private void button_reg_MouseLeave_1(object sender, MouseEventArgs e)
        {
            button_reg.FontSize = 13;
        }

        private void button_enter_MouseLeave_1(object sender, MouseEventArgs e)
        {
            button_enter.FontSize = 13;
        }
    }
}
