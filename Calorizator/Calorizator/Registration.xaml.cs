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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();

        }

        List<_Authorization> Users = new List<_Authorization>();

        private void button_registr_Click(object sender, RoutedEventArgs e)
        {

            if (login.Text == "")
            {
                MessageBox.Show("Введите логин!");
                return;
            }

            if (passwordBox.Password.ToString() == "")
            {
                MessageBox.Show("Введите пароль!");
                return;
            }

            if (passwordBox_1.Password.ToString() == "")
            {
                MessageBox.Show("Введите пароль повторно!");
                return;
            }

            if (passwordBox.Password.ToString() != passwordBox_1.Password.ToString())
            {
                MessageBox.Show("Пароли не совпадают! Попробуйте еще раз.");
                passwordBox_1.Clear();
                return;

            }
            
            _Authorization user = new _Authorization(login.Text, passwordBox.Password);
            
            
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("../../users.dat", FileMode.OpenOrCreate))
            {

                try
                {
                    Users = (List<_Authorization>)formatter.Deserialize(fs);
                }
                catch
                {
                    Users = new List<_Authorization>();
                }
            }

           
            foreach (_Authorization u in Users)
            {
                if (login.Text == u.Login)
                {
                    MessageBox.Show("Такой логин уже используется! Попробуйте ещё раз.");
                    login.Clear();
                    passwordBox.Clear();
                    passwordBox_1.Clear();
                    return;
                }
            }
            Users.Add(user);


            using (FileStream fs = new FileStream("../../users.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Users);
                }

            MessageBox.Show("Регистрация успешно завершена. Выполните вход.");
                NavigationService.GoBack();
            }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void button_registr_MouseEnter(object sender, MouseEventArgs e)
        {
            button_registr.FontSize=12;
        }
    }
    }

