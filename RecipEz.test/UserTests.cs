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
            User user = new User("First", "Last");
            Assert.AreEqual(user.first, "First");
            Assert.AreEqual(user.last, "Last");
        }

        [Test]
        public void ShouldHaveAnEmail()
        {
            User user = new User("First", "Last", "firstlast@example.com");
            Assert.AreEqual(user.email, "firstlast@example.com");
        }
    }
}