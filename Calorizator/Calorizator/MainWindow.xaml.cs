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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calorizator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Products> Products = new List<Products>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void comboBox_ct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            comboBox_pr.Items.Clear();

            List<string> Category = new List<string>();

            BinaryFormatter formatter = new BinaryFormatter();
            List<Products> Products;
            using (FileStream fs = new FileStream("../../base.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    Products = (List<Products>)formatter.Deserialize(fs);
                }
                catch
                {
                    Products = new List<Products>();
                }
            }
            foreach (Products p in Products)
            {
                if (p.Category == comboBox_ct.Text)
                {
                    Category.Add(p.Name);

                }
            }

            for (int i = 0; i < Category.Count; i++)
            {
                comboBox_pr.Items.Add(Category[i]);
            }




        }

        List<Products> Pr = new List<Products>();

        double s_w = 0;
        double s_p = 0;
        double s_o = 0;
        double s_c = 0;
        double s_k = 0;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            s_w = 0;
            s_p = 0;
            s_o = 0;
            s_c = 0;
            s_k = 0;

            double weight = double.Parse(textBox.Text) / 100;

            BinaryFormatter formatter = new BinaryFormatter();
            List<Products> Products;

            using (FileStream fs = new FileStream("../../base.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    Products = (List<Products>)formatter.Deserialize(fs);
                }
                catch
                {
                    Products = new List<Products>();
                }
            }
            foreach (Products p in Products)
            {
                if (p.Name == comboBox_pr.Text)
                {
                    p.Weight = int.Parse(textBox.Text);
                    p.Protein *= weight;
                    p.Oil *= weight;
                    p.Carbs *= weight;
                    p.Calories *= weight;

                    Pr.Add(p);

                }
            }
            dataGrid.ItemsSource = Pr;

            textBox.Clear();


            foreach (Products pr in Pr)
            {
                s_w += pr.Weight;
                s_p += pr.Protein;
                s_o += pr.Oil;
                s_c += pr.Carbs;
                s_k += pr.Calories;
            }

            label_i.Content = "на " + s_w.ToString() + " гр.  " + s_p.ToString() + " бел.  " + s_o.ToString() + " жир.  " + s_c.ToString() + " угл.  " + s_k.ToString() + " ккал  ";

        }

        private void comboBox_pr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_del_Click(object sender, RoutedEventArgs e)
        {
            int s_i = dataGrid.SelectedIndex + 1;
            if (s_i == 0)

            {
                MessageBox.Show("Выберите продукт в таблице");
            }
            else
            {
                MessageBoxResult result;
                result = MessageBox.Show("Вы уверены, что хотите удалить " + Pr[s_i - 1].Name + "?", "Удаление элемента", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    s_w -= Pr[s_i - 1].Weight; s_w = Math.Round(s_w, 3);
                    s_p -= Pr[s_i - 1].Protein; s_p = Math.Round(s_p, 3);
                    s_o -= Pr[s_i - 1].Oil; s_o = Math.Round(s_o, 3);
                    s_c -= Pr[s_i - 1].Carbs; s_c = Math.Round(s_c, 3);
                    s_k -= Pr[s_i - 1].Calories; s_k = Math.Round(s_k, 3);

                    label_i.Content = "на " + s_w.ToString() + " гр.  " + s_p.ToString() + " бел.  " + s_o.ToString() + " жир.  " + s_c.ToString() + " угл.  " + s_k.ToString() + " ккал  ";

                    Pr.RemoveAt(s_i - 1);

                    dataGrid.ItemsSource = null;
                    dataGrid.Columns.Clear();
                    dataGrid.ItemsSource = Pr;
                }


            }
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {

            button.Background = new SolidColorBrush(Colors.SeaShell);

        }

        private void button_del_MouseEnter(object sender, MouseEventArgs e)
        {
            button_del.Background = new SolidColorBrush(Colors.Pink);
        }
    }
}

            

