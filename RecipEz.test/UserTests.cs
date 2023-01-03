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
            Assert.That("First", Is.EqualTo(user.FirstName));
            Assert.That("Last", Is.EqualTo(user.LastName));
        }

        [Test]
        public void ShouldHaveAnEmail()
        {
            // Arrange
            User user = new User("First", "Last", "firstlast@example.com");
            // Act 
            // Assert
            Assert.That("firstlast@example.com", Is.EqualTo(user.Email));
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
    }
}