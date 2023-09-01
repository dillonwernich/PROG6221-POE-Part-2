using System;
using System.Collections.Generic;

namespace POE.P2
{
    public class Recipe //class recipe
    {
        List<Recipe> recipes = new List<Recipe>(); //List<T> to save recipes
        public delegate void RecipeNotificationDelegate(Recipe recipe); //delegate
        private RecipeNotificationDelegate notificationDelegate; //calorie notification

        public string Name { get; set; } //gets and sets for Recipe Name
        public List<Ingredient> Ingredients { get; set; } //gets and sets for Ingredients
        public List<string> Steps { get; set; } //gets and sets for Steps

        public Recipe(string name, List<Ingredient> ingredients, List<string> steps) //constructor
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public Recipe() //constructor for creating obj of class in main and unit test
        {
        }

        public void AddRecipe() //AddRecipe method
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White; //sets text colour
                Console.WriteLine("------------------------------"); //housekeeping
                Console.Write("Recipe Name: "); //housekeeping
                string name = Console.ReadLine(); //saves user input for recipe name
                Console.WriteLine("------------------------------"); //housekeeping

                Console.Write("Number of Ingredients: "); //housekeeping
                int numIngredients = int.Parse(Console.ReadLine()); //saves user input for num Ingredients

                List<Ingredient> ingredients = new List<Ingredient>(); //stores recipe in List<T>

                for (int i = 0; i < numIngredients; i++) //for loop
                {
                    Console.WriteLine("------------------------------"); //housekeeping
                    Console.Write($"Name of Ingredient {i + 1}: "); //housekeeping with numnber incrementing
                    string ingredientName = Console.ReadLine(); //saves user input for ingredientName

                    Console.Write($"Quantity of {ingredientName}: ");  //housekeeping with ingredientName
                    double quantity = double.Parse(Console.ReadLine()); //saves user input for quantity

                    Console.Write($"Unit of Measurement for {ingredientName}: "); //housekeeping with ingredientName
                    string unit = Console.ReadLine(); //save user input for unit of measurement 

                    Console.Write($"Calories for {quantity} {unit} of {ingredientName}: "); //housekeeping with quantity, unit and ingredientName
                    double calories = double.Parse(Console.ReadLine()); //saves user input for num of calories

                    Console.Write($"Food Group for {ingredientName}: "); //housekeeping with ingredientName
                    string foodGroup = Console.ReadLine(); //saves userinput for foodGroup

                    ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup)); //adds ingredientName, quantity, unit, calories and foodGroup to List<T>
                }
                Console.WriteLine("------------------------------"); //housekeeping

                Console.Write("Enter number of steps: "); //housekeeping
                int numSteps = int.Parse(Console.ReadLine()); //saves user input for numSteps
                Console.WriteLine("------------------------------"); //housekeeping

                List<string> steps = new List<string>(); //saves steps in List<T>
                for (int i = 0; i < numSteps; i++) //for loop
                {
                    Console.Write($"Enter step {i + 1}: "); //housekeeping with number incrementing
                    string step = Console.ReadLine(); //saves user input for step

                    steps.Add(step); //adds step to List<T>
                }
                Console.WriteLine("------------------------------"); //housekeeping

                Recipe recipe = new Recipe(name, ingredients, steps); //stores name, ingredient and steps in recipe
                recipes.Add(recipe); //adds recipe to List<T>

                Console.ForegroundColor = ConsoleColor.Green; //sets text colour
                Console.WriteLine($"\n---RECIPE ADDED---\n"); //housekeeping
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                Console.WriteLine("\nERROR: " + ex.Message); //error message
                Console.WriteLine();
            }
        }

        public void ListRecipe() //ListRecipe method
        {
            try
            {
                if (recipes.Count == 0) //if recipe = 0
                {
                    Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                    Console.WriteLine("---NO RECIPES ADDED---\n"); //housekeeping
                }
                else //else list the recipes
                {
                    Console.ForegroundColor = ConsoleColor.White; //sets text colour
                    recipes.Sort((x, y) => x.Name.CompareTo(y.Name)); //stores recipes in alphabetical order in recipe

                    Console.WriteLine("------RECIPES------"); //housekeeping
                    foreach (var recipe in recipes) //for each loop
                    {
                        Console.WriteLine(recipe.Name); //recipe lists all recipes in alphabetical order
                    }
                    Console.WriteLine("-------------------\n"); //housekeeping
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                Console.WriteLine("\nERROR: " + ex.Message); //error message
                Console.WriteLine();
            }
        }

        public void DisplayRecipe() //DisplayRecipe method
        {
            try
            {
                if (recipes.Count == 0) //if recipe = 0
                {
                    Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                    Console.WriteLine("---NO RECIPES ADDED---"); //housekeeping
                }
                else //else ask user for recipe name
                {
                    Console.ForegroundColor = ConsoleColor.White; //sets text colour
                    Console.WriteLine("-----------------------------------"); //housekeeping
                    Console.Write("Recipe Name: "); //housekeeping
                    string name = Console.ReadLine(); //stores user input for recipe name

                    Recipe recipe = recipes.Find(x => x.Name == name); //stores recipe name in recipe

                    if (recipe == null) //if recipe not found
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                        Console.WriteLine($"\nRecipe {name} not found.\n"); //housekeeping with name
                    }
                    else //else display the recipe
                    {
                        Console.ForegroundColor = ConsoleColor.White; //sets text colour
                        recipe.PrintRecipe(1.0); //prints recipe with orginal values
                        double totalCalories = recipe.GetTotalCalories(); //gets total calories

                        if (totalCalories > 300) //if totalCalories is greater than 300
                        {
                            notificationDelegate?.Invoke(this); //invokes the RecipeCalorieExceeded delegate
                            Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                            Console.WriteLine("WARNING: THIS RECIPE HAS MORE THAN 300 CALORIES!"); //displays a warning if calories is >= 300
                        }
                    }
                }
                Console.WriteLine(); //housekeeping
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                Console.WriteLine("\nERROR: " + ex.Message); //error message
                Console.WriteLine();
            }
        }

        public void ScaleRecipe() //ScaleRecipe method
        {
            try
            {
                if (recipes.Count == 0) //if recipe = 0
                {
                    Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                    Console.WriteLine("---NO RECIPES ADDED---\n"); //housekeeping
                }
                else //else ask user for recipe name
                {
                    Console.ForegroundColor = ConsoleColor.White; //sets text colour
                    Console.WriteLine("-------------------"); //housekeeping
                    Console.Write("Recipe Name: "); //housekeeping
                    string name = Console.ReadLine(); //stores user input for recipe name
                    Console.WriteLine("-------------------\n"); //housekeeping

                    Recipe recipe = recipes.Find(x => x.Name == name); //stores recipe name in recipe
                    if (recipe == null) //if recipe is not found
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                        Console.WriteLine($"\nRecipe {name} not found.\n"); //housekeeping
                    }
                    else //else ask user for scaling factor and scale the recipe
                    {
                        Console.ForegroundColor = ConsoleColor.Blue; //sets text colour
                        Console.Write("Scaling Factor (0,5 | 2 | 3): "); //housekeeping
                        double scale = double.Parse(Console.ReadLine()); //saves user input for scale
                        Console.WriteLine(); //housekeeping

                        Console.ForegroundColor = ConsoleColor.White; //sets text colour
                        recipe.PrintRecipe(scale); //displays scaled recipe

                        Console.ForegroundColor = ConsoleColor.Green; //sets text colour
                        Console.WriteLine("---RECIPE SCALED---\n"); //housekeeping
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                Console.WriteLine("\nERROR: " + ex.Message); //error message
                Console.WriteLine();
            }
        }

        public void ResetRecipe() //ResetRecipe method
        {
            try
            {
                if (recipes.Count == 0) //if recipe = 0
                {
                    Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                    Console.WriteLine("---NO RECIPES ADDED---"); //housekeeping
                }
                else //else ask user for recipe name
                {
                    Console.ForegroundColor = ConsoleColor.White; //sets text colour
                    Console.WriteLine("-----------------------------------"); //housekeeping
                    Console.Write("Recipe Name: "); //housekeeping
                    string name = Console.ReadLine(); //stores user input for recipe name

                    Recipe recipe = recipes.Find(x => x.Name == name); //stores recipe name in recipe
                    if (recipe == null) //if recipe not found
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                        Console.WriteLine($"\nRecipe {name} not found.\n");  //housekeeping
                    }
                    else //else reset recipe
                    {
                        Console.ForegroundColor = ConsoleColor.White; //sets text colour
                        recipe.PrintRecipe(1.0); //displays recipe reset
                        Console.ForegroundColor = ConsoleColor.Green; //sets text colour
                        Console.WriteLine("---RECIPE RESET---"); //housekeeping
                    }
                }
                Console.WriteLine(); //housekeeping
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                Console.WriteLine("\nERROR: " + ex.Message); //error message
                Console.WriteLine();
            }
        }

        public void ClearRecipe() //ClearRecipe method
        {
            try
            {
                if (recipes.Count == 0) //if recipe = 0
                {
                    Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                    Console.WriteLine("---NO RECIPE ADDED---\n"); //housekeeping
                }
                else //else ask user for recipe name
                {
                    Console.ForegroundColor = ConsoleColor.White; //sets text colour
                    Console.WriteLine("-------------------"); //housekeeping
                    Console.Write("Recipe Name: "); //housekeeping
                    string name = Console.ReadLine(); //stores user input for recipe name
                    Console.WriteLine("-------------------"); //housekeeping

                    Recipe recipe = recipes.Find(x => x.Name == name); //stores recipe name in recipe
                    if (recipe == null) //if recipe not found
                    {
                        Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                        Console.WriteLine($"\nRecipe {name} not found.\n"); //housekeeping
                    }
                    else //else clear recipe
                    {
                        recipes.Remove(recipe); //clears the recipe selected
                        Console.ForegroundColor = ConsoleColor.Green; //sets text colour
                        Console.WriteLine("\n---RECIPE CLEARED---"); //housekeeping
                        Console.WriteLine(); //housekeeping
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                Console.WriteLine("\nERROR: " + ex.Message); //error message
                Console.WriteLine();
            }
        }

        public void PrintRecipe(double scale) //PrintRecipe method
        {
            Console.WriteLine("-----------------------------------"); //housekeeping
            Console.WriteLine("INGREDIENTS:"); //housekeeping
            foreach (var ingredient in Ingredients) //for each loop
            {
                Console.WriteLine($"{ingredient.Quantity * scale} {ingredient.Unit} {ingredient.Name}"); //displays ingredients
            }
            Console.WriteLine("-----------------------------------"); //housekeeping
            Console.WriteLine("STEPS:"); //housekeeping
            for (int i = 0; i < Steps.Count; i++) //for loop
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}"); //displays the steps wit num incrementing
            }
            Console.WriteLine("-----------------------------------"); //housekeeping
            double totalCalories = GetTotalCalories(); //sets total calories
            Console.WriteLine($"Total calories: {totalCalories * scale}"); //displays total calories
            Console.WriteLine("-----------------------------------\n"); //housekeeping
        }

        public double GetTotalCalories() //GetTotalCalories method
        {
            double totalCalories = 0; //sets totalCalories to 0
            foreach (var ingredient in Ingredients) //for each loop
            {
                totalCalories += ingredient.Calories; //takes totalCalories entered and adds them together
            }
            return totalCalories; //returns the total
        }

    }
}
