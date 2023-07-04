using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class FilterRecipesWindow : Window
    {
        private List<Recipe> recipes; // List to store all recipes
        private List<Recipe> filteredRecipes; // List to store filtered recipes

        public FilterRecipesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes; // Assign the provided list of recipes to the private field
            filteredRecipes = new List<Recipe>(); // Initialize the list of filtered recipes
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = ingredientNameTextBox.Text.Trim(); // Get the trimmed text from the ingredient name TextBox
            string foodGroup = ((ComboBoxItem)foodGroupComboBox.SelectedItem)?.Content.ToString(); // Get the content of the selected ComboBoxItem as the food group

            int maxCalories;
            bool hasMaxCalories = int.TryParse(maxCaloriesTextBox.Text.Trim(), out maxCalories);

            filteredRecipes.Clear(); // Clear the list of filtered recipes

            foreach (Recipe recipe in recipes)
            {
                bool ingredientNameMatch = string.IsNullOrEmpty(ingredientName) ||
                    recipe.Ingredients.Any(ingredient => ingredient.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase));

                bool foodGroupMatch = foodGroup == "All" ||
                    recipe.Ingredients.Any(ingredient => ingredient.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase));

                bool maxCaloriesMatch = !hasMaxCalories ||
                    recipe.Ingredients.Sum(ingredient => ingredient.Calories) <= maxCalories;

                // Check if the recipe matches any of the specified filters
                if ((string.IsNullOrEmpty(ingredientName) || ingredientNameMatch) &&
                    (foodGroup == "All" || foodGroupMatch) &&
                    (!hasMaxCalories || maxCaloriesMatch))
                {
                    filteredRecipes.Add(recipe); // Add the recipe to the list of filtered recipes if it matches the filters
                }
            }

            if (filteredRecipes.Count == 0)
            {
                MessageBox.Show("No recipes found matching the specified filters.", "Filtered Recipes"); // Display a message if no recipes match the filters
            }
            else
            {
                // Display the filtered recipes
                string recipesText = "Filtered Recipes:" + Environment.NewLine;

                foreach (Recipe recipe in filteredRecipes)
                {
                    // Generate a formatted string with information about each filtered recipe
                    recipesText += "Recipe Name: " + recipe.Name + Environment.NewLine;
                    recipesText += "Ingredients:" + Environment.NewLine;

                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        recipesText += "  - Ingredient Name: " + ingredient.Name + Environment.NewLine;
                        recipesText += "    Food Group: " + ingredient.FoodGroup + Environment.NewLine;
                        recipesText += "    Quantity: " + ingredient.Quantity + " " + ingredient.Unit + Environment.NewLine;
                        recipesText += "    Calories: " + ingredient.Calories + Environment.NewLine;
                    }

                    recipesText += Environment.NewLine;
                }

                MessageBox.Show(recipesText, "Filtered Recipes"); // Display the formatted string with the filtered recipes
            }

            Close(); // Close the window
        }

    }
}
