using System;
using System.Collections.Generic;
using System.IO;
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
            Products p;
            string[] line = File.ReadAllLines("base.txt");
            for (int i = 0; i < line.Length; i++)
            {

                string[] mas = line[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                p = new Products(mas[0], mas[1], 0, double.Parse(mas[2]), double.Parse(mas[3]), double.Parse(mas[4]), double.Parse(mas[5]));

                if (mas[1] == comboBox_ct.Text)
                {
                    Category.Add(p.Name);

                }
            }


           
                for (int i = 0; i < Category.Count; i++)
                {
                    comboBox_pr.Items.Add(Category[i]);
                }


            
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource=null;
           
            double weight = double.Parse(textBox.Text)/100;
            Products p;
            string[] line = File.ReadAllLines("base.txt");
            for (int i = 0; i < line.Length; i++)
            {

                string[] mas = line[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                p = new Products(mas[0], mas[1], int.Parse(textBox.Text), double.Parse(mas[2])*weight, double.Parse(mas[3])*weight, double.Parse(mas[4])*weight, double.Parse(mas[5])*weight);

                if (mas[0] == comboBox_pr.Text)
                {
                    Products.Add(p);
                    
                } 

            }
            dataGrid.ItemsSource = Products;

            textBox.Clear();

            double s_w = 0;
            double s_p = 0;
            double s_o = 0;
            double s_c = 0;
            double s_k = 0;

            foreach (Products pr in Products)
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
    }
}
