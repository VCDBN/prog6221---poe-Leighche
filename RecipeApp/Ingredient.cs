using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class Ingredient
    {
        public string Name { get; set; }               // Property to store the name of the ingredient
        public string FoodGroup { get; set; }          // Property to store the food group of the ingredient
        public double Quantity { get; set; }           // Property to store the quantity of the ingredient
        public string Unit { get; set; }               // Property to store the unit of measurement for the ingredient
        public double Calories { get; set; }           // Property to store the calorie content of the ingredient
        public string Step { get; set; }               // Property to store the step or instructions for the ingredient

        public double OriginalQuantity { get; set; }   // Property to store the original quantity of the ingredient before scaling or modification
    }

    public class Recipe
    {
        public string Name { get; set; }               // Property to store the name of the recipe

        public string FoodGroup { get; set; }
        public List<Ingredient> Ingredients { get; set; }   // Property to store the list of ingredients for the recipe
    }
}
