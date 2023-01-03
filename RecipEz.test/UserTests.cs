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
            Assert.AreEqual(user.FirstName, "First");
            Assert.AreEqual(user.LastName, "Last");
        }

        [Test]
        public void ShouldHaveAnEmail()
        {
            // Arrange
            User user = new User("First", "Last", "firstlast@example.com");
            // Act 
            // Assert
            Assert.AreEqual(user.Email, "firstlast@example.com");
        }

        [Test]
        public void ShouldHaveASetDescriptionFunction()
        {
            // Arrange 
            User user = new User("First", "Last", "firstlast@example.com");
            // Act 
            user.SetDescription("A fun loving dev from Colchester");
            // Assert 
            Assert.AreEqual(user.Description, "A fun loving dev from Colchester");
        }
    }
}