using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace POE.P2.Test
{
    [TestClass]
    public class RecipeTest
    {
        [TestMethod]
        public void GetTotalCalories()
        {
            // Arrange
            Recipe recipe = new Recipe();
            double expected = 52;
            Ingredient ingredient1 = new Ingredient("Ingredient 1", 30, "unit1", 50, "category1");
            Ingredient ingredient2 = new Ingredient("Ingredient 2", 10, "unit2", 2, "category2");

            recipe.Ingredients = new List<Ingredient> { ingredient1, ingredient2 };

            // Act
            double actual = recipe.GetTotalCalories();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
