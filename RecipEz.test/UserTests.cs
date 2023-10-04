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
        public void ShouldHaveAnEmail()
        {
            // Arrange
            User user = new User("firstlast@example.com", "Mypassword123!");
            // Act 
            // Assert
            Assert.That(user.Email, Is.EqualTo("firstlast@example.com"));
        }

        [Test]
        public void ShouldErrorIfEmailIsInvalid()
        {
            // Arrange
            var ex = Assert.Throws<InvalidOperationException>(() => new User("firstlastexample.com", "Mypassword123!"));
            // Act
            // Assert
            Assert.That(ex.Message, Is.EqualTo("Email address is not valid"));
        }

        [Test]
        public void ShouldHaveASetDescriptionFunction()
        {
            // Arrange 
            User user = new User("firstlast@example.com", "Mypassword123!");
            // Act 
            user.SetDescription("A fun loving dev from Colchester");
            // Assert 
            Assert.That(user.Description, Is.EqualTo("A fun loving dev from Colchester"));
        }


        [Test]
        public void VerifyPasswordShouldFailWhenPasswordIsIncorrect()
        {

            // Arrange
            User user = new User("firstlast@example.com", "Mysecretpassword123!");
            //  Act
            // Assert
            Assert.That(user.VerifyPassword("incorrect"), Is.False);
        }

        [Test]
        public void VerifyPasswordShouldPassWhenPasswordIsCorrect()
        {
            // Arrange
            User user = new User("firstlast@example.com", "Password123!");
            // Act
            // Assert
            Assert.That(user.VerifyPassword("Password123!"), Is.True);
        }

        [Test]
        public void PasswordShouldBeAtLeast8Characters()
        {
            // Arrange
            // Act
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new User("edsouthgate@example.com", "Sh0rt!"));
        }

        [Test]
        public void PasswordsShouldHaveAtLeastOneCapitalLetter()
        {
            // Arrange
            // Act
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new User("edsouthgate@example.com", "password"));
        
        }

        [Test]
        public void PasswordsShouldHaveAtLeastOneLowercaseLetter()
        {
            // Arrange
            // Act
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new User("edsouthgate@example.com", "PASSWORD"));
        }

        [Test]
        public void PasswordsShouldHaveAtLeastOneSpecialCharacter()
        {
            // Arrange
            // Act
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new User("edsouthgate@example.com", "PASSword1"));
        }

        [Test]
        public void PasswordsShouldHaveAtLeastOneNumber()
        {
            // Arrange
            // Act
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => new User("edsouthgate@example", "Password!"));
        }

        [Test]
        public void ShouldHaveRecipeList()
        {
            // Arrange
            User user = new User("firstlast@example.com", "Mypassword123!");

            // Act
            // Assert
            Assert.That(user.Recipes, Is.Not.Null);
        }
    }
}