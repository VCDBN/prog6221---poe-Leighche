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

namespace RecipeApp
{

    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // Event handler for the button click that opens the MainWindow
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
        }

        // Event handler for the button click that opens the Calory window
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Calory form2 = new Calory();
            form2.Show();
        }

        // Event handler for the button click that exits the application
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }

}
