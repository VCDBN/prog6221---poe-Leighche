using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private List<Ingredient> ingredients; // List to store ingredients
        private List<Recipe> recipes; // List to store recipes

        public MainWindow()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>(); // Initialize the list of ingredients
            recipes = new List<Recipe>(); // Initialize the list of recipes
        }

        private void AddIngredients_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(numIngredientsTextBox.Text, out int numIngredients))
            {
                for (int i = 0; i < numIngredients; i++)
                {
                    StackPanel ingredientPanel = new StackPanel();

                    // Create TextBox for ingredient name
                    TextBox nameTextBox = new TextBox();
                    // Set properties for the TextBox
                    nameTextBox.Margin = new Thickness(0, 0, 10, 0);
                    nameTextBox.Width = 150;
                    nameTextBox.Tag = "Name";
                    ingredientPanel.Children.Add(CreateInputLabel("Ingredient Name:"));
                    ingredientPanel.Children.Add(nameTextBox);

                    // Create ComboBox for food group
                    ComboBox foodGroupComboBox = new ComboBox();
                    // Set properties for the ComboBox
                    foodGroupComboBox.Margin = new Thickness(0, 0, 10, 0);
                    foodGroupComboBox.Width = 150;
                    // Add food group options to the ComboBox
                    foodGroupComboBox.Items.Add("Starchy foods");
                    foodGroupComboBox.Items.Add("Vegetables and fruits");
                    foodGroupComboBox.Items.Add("Dry beans, peas, lentils and soya");
                    foodGroupComboBox.Items.Add("Chicken, fish, meat and egg");
                    foodGroupComboBox.Items.Add("Milk and dairy products");
                    foodGroupComboBox.Items.Add("Fats and oil");
                    foodGroupComboBox.Items.Add("Water");
                    foodGroupComboBox.Tag = "FoodGroup";
                    ingredientPanel.Children.Add(CreateInputLabel("Food Group:"));
                    ingredientPanel.Children.Add(foodGroupComboBox);

                    // Create TextBox for quantity
                    TextBox quantityTextBox = new TextBox();
                    // Set properties for the TextBox
                    quantityTextBox.Margin = new Thickness(0, 0, 10, 0);
                    quantityTextBox.Width = 100;
                    quantityTextBox.Tag = "Quantity";
                    ingredientPanel.Children.Add(CreateInputLabel("Quantity:"));
                    ingredientPanel.Children.Add(quantityTextBox);

                    // Create TextBox for unit of measurement
                    TextBox unitTextBox = new TextBox();
                    // Set properties for the TextBox
                    unitTextBox.Margin = new Thickness(0, 0, 10, 0);
                    unitTextBox.Width = 100;
                    unitTextBox.Tag = "Unit";
                    ingredientPanel.Children.Add(CreateInputLabel("Unit of Measurement:"));
                    ingredientPanel.Children.Add(unitTextBox);

                    // Create TextBox for calories
                    TextBox caloriesTextBox = new TextBox();
                    // Set properties for the TextBox
                    caloriesTextBox.Width = 100;
                    caloriesTextBox.Tag = "Calories";
                    ingredientPanel.Children.Add(CreateInputLabel("Calories:"));
                    ingredientPanel.Children.Add(caloriesTextBox);

                    // Create TextBox for step description
                    TextBox stepTextBox = new TextBox();
                    // Set properties for the TextBox
                    stepTextBox.Margin = new Thickness(0, 0, 10, 0);
                    stepTextBox.Width = 300;
                    stepTextBox.Tag = "Step";
                    ingredientPanel.Children.Add(CreateInputLabel("Step Description:"));
                    ingredientPanel.Children.Add(stepTextBox);

                    // Add the ingredient panel to the ingredients stack panel
                    ingredientsStackPanel.Children.Add(ingredientPanel);
                }
            }
            else
            {
                MessageBox.Show("Invalid number of ingredients."); // Show a message if the number of ingredients is invalid
            }
        }


        private void CaloriesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox caloriesTextBox && double.TryParse(caloriesTextBox.Text, out double totalCalories))
            {
                if (totalCalories > 300)
                {
                    MessageBox.Show("Total calories of the recipe exceed 300 calories.", "Calorie Warning"); // Show a warning if total calories exceed 300
                }
            }
        }

        private TextBlock CreateInputLabel(string label)
        {
            return new TextBlock { Text = label, Width = 150 }; // Create a TextBlock for ingredient labels
        }

        private void CalculateTotalCalories()
        {
            double totalCalories = ingredients.Sum(ingredient => ingredient.Calories); // Calculate the total calories of the ingredients
            totalCaloriesTextBlock.Text = totalCalories.ToString(); // Display the total calories
        }

        private void CollectIngredients()
        {
            ingredients.Clear(); // Clear the list of ingredients

            foreach (StackPanel ingredientPanel in ingredientsStackPanel.Children)
            {
                Ingredient ingredient = new Ingredient();

                foreach (UIElement element in ingredientPanel.Children)
                {
                    if (element is TextBox textBox)
                    {
                        string tag = textBox.Tag.ToString();
                        switch (tag)
                        {
                            case "Name":
                                ingredient.Name = textBox.Text; // Set the name of the ingredient
                                break;
                            case "Quantity":
                                if (double.TryParse(textBox.Text, out double quantity))
                                    ingredient.Quantity = quantity; // Set the quantity of the ingredient
                                break;
                            case "Unit":
                                ingredient.Unit = textBox.Text; // Set the unit of measurement of the ingredient
                                break;
                            case "Calories":
                                if (double.TryParse(textBox.Text, out double calories))
                                    ingredient.Calories = calories; // Set the calories of the ingredient
                                break;
                            case "Step":
                                ingredient.Step = textBox.Text; // Set the step description of the ingredient
                                break;
                        }
                    }
                    else if (element is ComboBox comboBox)
                    {
                        ingredient.FoodGroup = comboBox.SelectedItem.ToString(); // Set the food group of the ingredient
                    }
                }

                ingredients.Add(ingredient); // Add the ingredient to the list
            }
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            CollectIngredients();

            Recipe recipe = new Recipe
            {
                Name = recipeNameTextBox.Text, // Set the name of the recipe
                Ingredients = ingredients.ToList() // Create a copy of the ingredients list and assign it to the recipe
            };

            recipes.Add(recipe); // Add the recipe to the list of recipes

            // Clear the ingredients list after saving the recipe
            ingredients.Clear();

            ClearForm(); // Clear the form fields

            // Check if total calories exceed 300 and show a warning if necessary
            double totalCalories = recipe.Ingredients.Sum(ingredient => ingredient.Calories);
            if (totalCalories > 300)
            {
                MessageBox.Show("RECIPE SAVED\n\nTotal calories of the recipe exceed 300 calories.", "Calorie Warning see Calary page on Home screen"); // Show a warning if total calories exceed 300
            }
            else
            {
                MessageBox.Show("Recipe saved successfully!", "Success"); // Show a success message if the recipe is saved successfully
            }
        }

        private void ShowRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes found.", "No Recipes");
                return;
            }

            List<Recipe> sortedRecipes = recipes.OrderBy(recipe => recipe.Name).ToList();

            RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(sortedRecipes);
            recipeDetailsWindow.ShowDialog();
        }



        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchKeyword = recipeNameTextBox.Text.Trim(); // Get the search keyword from the text box

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                List<Recipe> searchResults = recipes.Where(recipe => recipe.Name.IndexOf(searchKeyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList(); // Search for recipes that match the search keyword

                if (searchResults.Count > 0)
                {
                    // Display the search results in a message box or any other desired way
                    string searchResultMessage = "Search Results:\n\n";

                    foreach (Recipe recipe in searchResults)
                    {
                        searchResultMessage += $"Recipe Name: {recipe.Name}\n\n";
                        double totalCalories = 0;
                        foreach (Ingredient ingredient in recipe.Ingredients)
                        {
                            totalCalories += ingredient.Calories;
                            searchResultMessage += $"- Ingredient: {ingredient.Name} \nQuantity: {ingredient.Quantity} {ingredient.Unit} \nFood Group: {ingredient.FoodGroup} \nCalories: {ingredient.Calories} \nStep Description: {ingredient.Step} \nTotal Calories: {totalCalories}\n\n";
                            // Add ingredient details to the search result message
                        }

                        searchResultMessage += "\n";
                    }

                    MessageBox.Show(searchResultMessage, "Search Results"); // Display the search results in a message box
                }
                else
                {
                    MessageBox.Show("No recipes found matching the search keyword.", "No Results Enter Recipe Name in Text Box"); // Show a message if no recipes are found
                }
            }
            else
            {
                MessageBox.Show("Please enter a search keyword.", "Invalid Search"); // Show a message if the search keyword is empty
            }
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the FilterRecipesWindow and pass the 'ingredients' and 'recipes' lists to its constructor
            FilterRecipesWindow filterWindow = new FilterRecipesWindow(recipes);

            // Display the FilterRecipesWindow
            filterWindow.ShowDialog();
        }

        private void ClearRecipes_Click(object sender, RoutedEventArgs e)
        {
            recipes.Clear(); // Clear the list of recipes
            MessageBox.Show("All recipes have been cleared.", "Recipes Cleared"); // Show a message indicating that all recipes have been cleared
        }

        private void ScaleQuantities_Click(object sender, RoutedEventArgs e)
        {
            ScaleQuantitiesWindow scaleQuantitiesWindow = new ScaleQuantitiesWindow(recipes); // Create a scale quantities window
            scaleQuantitiesWindow.ShowDialog(); // Show the scale quantities window
        }

        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            foreach (Recipe recipe in recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (ingredient.OriginalQuantity != 0)
                    {
                        ingredient.Quantity = ingredient.OriginalQuantity; // Reset the quantity of each ingredient to its original value
                    }
                }
            }

            MessageBox.Show("All ingredient quantities have been reset.", "Quantities Reset"); // Show a message indicating that all ingredient quantities have been reset
        }


        private void ClearForm()
        {
            recipeNameTextBox.Clear(); // Clear the recipe name text box
            numIngredientsTextBox.Clear(); // Clear the number of ingredients text box

            // Clear the ingredients stack panel
            ingredientsStackPanel.Children.Clear();

            // Clear the total calories text block
            totalCaloriesTextBlock.Text = string.Empty;
        }
    }
}
