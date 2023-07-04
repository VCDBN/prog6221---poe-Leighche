using RecipeApp;                            // Importing the RecipeApp namespace
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class RecipeDetailsWindow : Window
    {
        public RecipeDetailsWindow(List<Recipe> recipes)
        {
            InitializeComponent();

            PopulateRecipes(recipes);           // Call the method to populate recipes
        }

        private void PopulateRecipes(List<Recipe> recipes)
        {
            foreach (Recipe recipe in recipes)  // Iterate over each recipe in the list
            {
                StackPanel recipePanel = new StackPanel();                    // Create a new StackPanel for the recipe
                recipePanel.Margin = new Thickness(0, 0, 0, 10);              // Set the margin of the StackPanel

                // Recipe Name
                TextBlock nameTextBlock = new TextBlock();                     // Create a new TextBlock for the recipe name
                nameTextBlock.Text = "Recipe Name: " + recipe.Name.ToUpper() + "\n\n"; // Set the text of the TextBlock
                recipePanel.Children.Add(nameTextBlock);                       // Add the TextBlock to the recipePanel

                // Food Group
                TextBlock foodGroupTextBlock = new TextBlock();                // Create a new TextBlock for the food group
                foodGroupTextBlock.Text = "Food Group: " + recipe.FoodGroup;   // Set the text of the TextBlock
                recipePanel.Children.Add(foodGroupTextBlock);                  // Add the TextBlock to the recipePanel

                // Ingredients
                double totalCalories = 0;                                      // Variable to keep track of total calories
                foreach (Ingredient ingredient in recipe.Ingredients)          // Iterate over each ingredient in the recipe
                {
                    TextBlock ingredientTextBlock = new TextBlock();           // Create a new TextBlock for the ingredient
                    totalCalories += ingredient.Calories;                      // Update the total calories
                    ingredientTextBlock.Text = "Ingredient: " + ingredient.Name + "\n Quantity: " + ingredient.Quantity + " " + ingredient.Unit + "\nFood Group: " + ingredient.FoodGroup + "\nCalories: " + ingredient.Calories + "\n\nTotal Calories: " + totalCalories; // Set the text of the TextBlock
                    recipePanel.Children.Add(ingredientTextBlock);             // Add the TextBlock to the recipePanel
                }

                // Step Descriptions with CheckBoxes
                foreach (Ingredient ingredient in recipe.Ingredients)          // Iterate over each ingredient in the recipe
                {
                    CheckBox stepCheckBox = new CheckBox();                    // Create a new CheckBox for the step
                    stepCheckBox.Content = ingredient.Step;                     // Set the content of the CheckBox
                    recipePanel.Children.Add(stepCheckBox);                     // Add the CheckBox to the recipePanel
                }

                recipesStackPanel.Children.Add(recipePanel);                   // Add the recipePanel to the main recipesStackPanel
            }
        }
    }
}
