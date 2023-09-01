namespace POE.P2
{
    public class Ingredient //class ingredient
    {
        public string Name { get; set; } //gets and sets for Name
        public double Quantity { get; set; } //gets and sets for Quantity
        public string Unit { get; set; } //gets and sets for Unit
        public double Calories { get; set; } //gets and sets for Calories
        public string FoodGroup { get; set; } //gets and sets for FoodGroup

        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup) //constructor
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}
