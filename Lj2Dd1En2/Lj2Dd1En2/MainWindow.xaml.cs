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

namespace Lj2Dd1En2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Meal bevat de eigenschappen die over een maaltijd.
        public class Meal
        {
            private int mealId;
            public int MealId
            {
                Get { return mealId; }
                Set { mealId = value; }
            }
            private string name = null!;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private string? description;
            public string? Description
            {
                get { return description; }
                set { description = value; }
            }
            private decimal price;
            public decimal Price
            {
                get { return price; }
                set { price = value; }
            }
        }

    }
}
