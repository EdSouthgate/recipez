using RecipEzDomain;

namespace RecipEz.test
{
    public class UserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldHaveAFirstName()
        {
            // Arrange
            User user = new User("First", "Last");
            // Act 
            // Assert
            Assert.That(user.FirstName, Is.EqualTo("First"));
        }

        [Test]
        public void ShouldErrorWhenFirstNameIsLessThanThreeChars()
        {
            // Arrange
            var ex = Assert.Throws<InvalidOperationException>(() => new User("Fi", "Last"));
            // Act
            // Assert
            Assert.That(ex.Message, Is.EqualTo("First name must be at least 3 characters"));
        }

        [Test]
        public void ShouldHaveALastName()
        {
            // Arrange
            User user = new User("First", "Last");
            // Act 
            // Assert
            Assert.That(user.LastName, Is.EqualTo("Last"));
        }

        [Test]
        public void ShouldErrorWhenLastNameIsLessThanThreeChars()
        {
            // Arrange
            var ex = Assert.Throws<InvalidOperationException>(() => new User("First", "La"));
            // Act
            // Assert
            Assert.That(ex.Message, Is.EqualTo("Last name must be at least 3 characters"));
        }

        [Test]
        public void ShouldHaveAnEmail()
        {
            // Arrange
            User user = new User("First", "Last", "firstlast@example.com");
            // Act 
            // Assert
            Assert.That(user.Email.ToString(), Is.EqualTo("firstlast@example.com"));
        }

        [Test]
        public void ShouldErrorIfEmailIsInvalid()
        {
            // Arrange
            var ex = Assert.Throws<InvalidOperationException>(() => new User("First", "Last", "firstlastexample.com"));
            // Act
            // Assert
            Assert.That(ex.Message, Is.EqualTo("Email address is not valid"));
        }

        [Test]
        public void ShouldHaveASetDescriptionFunction()
        {
            // Arrange 
            User user = new User("First", "Last", "firstlast@example.com");
            // Act 
            user.SetDescription("A fun loving dev from Colchester");
            // Assert 
            Assert.That(user.Description, Is.EqualTo("A fun loving dev from Colchester"));
        }

        [Test]
        public void ShouldHaveASetPasswordFunction()
        {
            // Arrange
            User user = new User("First", "Last", "firstlast@example.com");
            // Act 
            user.SetPassword("mysecretpassword");
            // Assert
            Assert.That(user.VerifyPassword("mysecretpassword"), Is.True);
        }

        [Test]
        public void VerifyPasswordShouldFailWhenPasswordIsIncorrect()
        {

            // Arrange
            User user = new User("First", "Last", "firstlast@example.com");
            // Act 
            user.SetPassword("mysecretpassword");
            // Assert
            Assert.That(user.VerifyPassword("incorrect"), Is.False);
        }

        [Test]
        public void ShouldHaveRecipeList()
        {
            // Arrange
            User user = new User("First", "Last", "firstlast@example.com");

            // Act
            // Assert
            Assert.That(user.Recipes, Is.Not.Null);
        }
    }
}