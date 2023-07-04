# RecipMe

## Table of Contents
- [Motivation](#motivation)
- [What RecipMe does?](#what-recipme-does)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [Technologies Used](#technologies-used)
- [Changes Based on Lecturer's Feedback](#changes-based-on-lecturers-feedback)
- [Feedback](#feedback)
- [Author](#author)
- [License](#license)
- [Contact](#contact)

  
## MOTIVATION:
 
RecipeMe was born out of the sheer delight experienced by Sanele at Lindiwe's birthday party, where he discovered the tantalizing flavors of home-cooked meals prepared with love and secret family recipes. Inspired by this culinary revelation, Sanele realized that anyone could unlock their potential as a skilled cook, regardless of their profession.
 
Our motivation behind developing RecipMe is to empower individuals like Sanele to explore the world of cooking and embark on their own culinary adventures. We believe that cooking should be accessible, enjoyable, and rewarding for everyone, irrespective of their skill level. By providing a comprehensive recipe app, we aim to facilitate the development of cooking skills, foster creativity in the kitchen, and ultimately bring the joy of delicious homemade meals to people's lives.
 
 
 
## What RecipMe does?


1. __Recipe Creation:__ Users can enter the name of a recipe and specify the number of ingredients required. They can then input the details of each ingredient, such as its name, quantity, unit of measurement, food group, and calorie amount. The app keeps track of the total calorie count for each recipe.
 
 
2. __Recipe Sorting__ The app allows users to sort the recipes alphabetically by name, ensuring easy navigation and organization of the recipe collection.
 
 
3. __Displaying Recipes__ Users can view the recipes’ details in the collection, including the recipe name, list of ingredients with their respective details (name, quantity, measurement, food group, and calories), total calorie count, and step-by-step instructions and they can tick off steps completed.
 
 
4. __Recipe Search__ Users can search for a specific recipe by entering its name. The app will display the details of the matching recipe, including its ingredients, total calorie count, and steps.
 
 
5. __Modifying Recipe Data:__ The app provides functionality to manipulate the quantities of ingredients. Users can choose to display the recipe data with quantities halved, doubled, or tripled, allowing for easy adjustments based on serving size or personal preference.
 
 
6. __Resetting Recipe Data__ Users can reset the quantities of ingredients back to their original values, as initially entered during recipe creation.
 
 
7. __Managing Recipe Lists__ Users can choose to clear the entire recipe collection, removing all recipes from the list.

8. __Filter function__ allows  The user shall to be able to filter the list of recipes by:
a. entering the name of an ingredient that must be in the recipe,
b. choosing a food group that must be in the recipe, or
c. selecting a maximum number of calories

## Features

- Add new recipes with name, food group, ingredients, and step descriptions.
- View recipe details, including recipe name, food group, ingredients, and step descriptions which can be ticked off.
- Mark off step descriptions as they are completed.
- Calculate and display the total calories for each recipe.
- Filter Recipes Using Ingredient Name, Food Group, MAX cALORIES
- Search App for Recipes Based on Recipe Name and display Recipe

## Installation

1. Clone the repository:

2. Navigate to the project directory:

3. Install the required dependencies:

4. Start the application:


## Usage

1. Launch the RecipMe.
2. Click on "Add Recipe" to create a new recipe.
3. Fill in the recipe details, including name, food group, ingredients, and step descriptions.
4. Click on "Save" to add the recipe.
5. To view a recipe's details, click on the show Recipes button.
6. To mark off a step description as completed, click on the checkbox next to the step.
7. The total calories for the recipe will be automatically calculated and displayed.
8. For more tips on how to use App refer to App Manual

## Contributing


Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.
 
When contributing to this project, please ensure that your changes are well-documented and follow the coding style and guidelines defined in the project.

 <br>
 my git repo: https://github.com/VCDBN/prog6221---poe-Leighche.git
1. Fork the repository.<br>
2. Create a new branch for your feature or bug fix.<br>
3. Make the necessary code changes.<br>
4. Test your changes to ensure they work as expected.<br>
5. Commit your changes and push them to your fork.<br>
6. Submit a pull request describing your changes.<br>


## Technologies Used:
* C#
* .NET Framework

## CHANGES BASED ON LECTURER'S FEEDBACK:

Because I had 100% for Part 2 not much was changed in terms of the application specifications, but I implemented various colours and imagery to liven up the app and I used WPF to make it visually appealing and vibrant also 
Made Use of multiple UI elements like ComboBoxes and TextBoxes to give the Application a sense of realism and depth, I also made use of multiple forms and colour schemes and themes and match the background
with the function of the application such as the calories form having a background being diabetes medication and i maintained  the following:

 App Functionality: The user can enter ingredients and steps, and the data is stored in memory The application allows users to enter the name, quantity, measurement, food group, and calorie amount of ingredients, as well as the steps for a recipe. The entered data is stored in memory using a List to manage multiple recipes, and a List within each recipe to store the ingredient details.  

* App Functionality: The entered recipe is displayed in a neat format to the user The application presents the entered recipe in a well-organized format, including the recipe name, and ingredients with their details (name, quantity, measurement, food group, and calories), total calorie count, and step-by-step instructions. The DisplayRecipes method is responsible for displaying the recipes in a neat format.  

* App Functionality: The recipe can be scaled with all ingredients scaled accordingly The application provides methods DisplayHalfedData, DisplayDoubledData, and DisplayTripledData to scale the quantities of all ingredients within the recipes. These methods iterate over each recipe and ingredient, modifying the Qty property accordingly.  

* App Functionality: The recipe scale can be reset back to the original values The application implements the Reset method, which sets the quantity (Qty) of each ingredient back to its original value. The original quantities are stored in a Dictionary called originalQuantities.  

* App Functionality: The data can be cleared, and a new recipe entered The application includes the EmptyLists method, which clears the entire recipe collection by calling recipes.Clear(). This allows users to start fresh and enter a new recipe.  

* Application Structure: The application makes use of classes in a logical way The application utilizes the classes RecipeManager, Recipe, and Ingredient to organize and manage recipe-related data. The RecipeManager class handles recipe creation, management, and display, while the Recipe class represents a single recipe with its properties and a list of ingredients. The Ingredient class stores the details of each ingredient.  

* Coding Standards: Code is well structured and documented The code follows a structured format, with meaningful method and variable names. It includes comments to explain the purpose of each section and important steps. The code appears to be well-documented and adheres to coding standards, enhancing readability and maintainability.  
 
## FEEDBACK
 
If you have any feedback or questions, feel free to reach out to me. I appreciate your input!
 
## AUTHOR
 
 Leighchè Jaikarran (ST10033808)
 
 

## License

The RecipMe is open-source software licensed under the [MIT license](https://opensource.org/licenses/MIT).

## Contact

For any inquiries or support, please contact [ST10033808](mailto: ST10033808@vcconnect.edu.za).


