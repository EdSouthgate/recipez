using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipEz.test
{
    internal class RecipeTests
    {
        [Test]
        public void ShouldHaveAName()
        {
            // Arrange
            Recipe recipe = new Recipe("Recipe name");
            // Act 
            // Assert
            Assert.That(recipe.Name, Is.EqualTo("Recipe name"));
        }

        [Test]
        public void ShouldUpdateNameWhenSetNameIsCalledWithAString()
        {
            // Arrange
            Recipe recipe = new Recipe("My recipoe");
            // Act 
            recipe.UpdateName("My recipe");
            // Assert
            Assert.That(recipe.Name, Is.EqualTo("My recipe"));
        }
    }
}
