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
    public partial class ScaleQuantitiesWindow : Window
    {
        private List<Recipe> recipes; // List to store recipes

        public ScaleQuantitiesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes; // Assign the provided list of recipes to the private field
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            double scalingFactor; // Variable to store the scaling factor
            if (double.TryParse((scalingFactorComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(), out scalingFactor))
            {
                // If the scaling factor is successfully parsed from the selected ComboBoxItem's content
                foreach (Recipe recipe in recipes)
                {
                    // Iterate over each recipe in the list of recipes
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        // Iterate over each ingredient in the recipe's list of ingredients
                        if (ingredient.OriginalQuantity == 0)
                        {
                            // If the original quantity of the ingredient is 0 (indicating it hasn't been scaled before)
                            ingredient.OriginalQuantity = ingredient.Quantity; // Store the original quantity before scaling
                        }

                        ingredient.Quantity *= scalingFactor; // Scale the ingredient's quantity by the scaling factor
                    }
                }

                MessageBox.Show("Ingredient quantities have been scaled.", "Quantities Scaled"); // Display a message indicating successful scaling
            }
            else
            {
                MessageBox.Show("Invalid scaling factor selected.", "Invalid Scaling Factor"); // Display an error message for an invalid scaling factor
            }

            Close(); // Close the window
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Close the window
        }
    }
}