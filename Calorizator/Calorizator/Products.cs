using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calorizator
{
    [Serializable]
    class Products
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private double protein;

        public double Protein
        {
            get { return protein; }
            set { protein = value; }
        }

        private double oil;

        public double Oil
        {
            get { return oil; }
            set { oil = value; }
        }

        private double carbs;

        public double Carbs
        {
            get { return carbs; }
            set { carbs = value; }
        }
        private double calories;

        public double Calories
        {
            get { return calories; }
            set { calories = value; }
        }


        public Products(string _name, string _category, int _weight, double _protein, double _oil, double _carbs, double _calories)
        {
            name = _name;
            category = _category;
            weight = _weight;
            protein = _protein;
            oil = _oil;
            carbs = _carbs;
            calories = _calories;

        }
    }
}
