using System;

namespace POE.P2
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe r = new Recipe(); //create an obj of the class

            while (true) //while loop for users to select a valid option
            {
                Console.ForegroundColor = ConsoleColor.White; //sets text colour
                Console.WriteLine("---RECIPE MANAGER---\n"); //housekeeping
                Console.WriteLine("(1) Add a Recipe"); //option 1
                Console.WriteLine("(2) List all Recipes"); //option 2
                Console.WriteLine("(3) Display a Recipe"); //option 3
                Console.WriteLine("(4) Scale a Recipe"); //option 4
                Console.WriteLine("(5) Reset a Recipe"); //option 5
                Console.WriteLine("(6) Clear a Recipe"); //option 6
                Console.WriteLine("(7) Exit"); //option 7

                Console.ForegroundColor = ConsoleColor.Blue; //sets text colour
                Console.Write("\nENTER OPTION: "); //housekeeping
                string input = Console.ReadLine(); //saves user input
                Console.WriteLine(); //housekeeping

                if (input == "1") //option 1
                {
                    r.AddRecipe(); //AddRecipe method
                }
                else if (input == "2") //option 2
                {
                    r.ListRecipe(); //ListRecipe method
                }
                else if (input == "3") //option 3
                {
                    r.DisplayRecipe(); //DisplayRecipe method
                }
                else if (input == "4") //option 4
                {
                    r.ScaleRecipe(); //ScaleRecipe method
                }
                else if (input == "5") //option 5
                {
                    r.ResetRecipe(); //ResetRecipe method
                }
                else if (input == "6") //option 6
                {
                    r.ClearRecipe(); //ClearRecipe method
                }
                else if (input == "7") //option 7
                {
                    return; //exit
                }
                else //invalid option
                {
                    Console.ForegroundColor = ConsoleColor.Red; //sets text colour
                    Console.WriteLine("---INVALID---"); //housekeeping
                    Console.WriteLine(); //housekeeping
                }
            }
        }
    }
}

//REFERENCES
//Troelsen, A. and Japikse, P. (n.d.). Pro C# 9 with .NET 5. Apress Uuuu-Uuuu.