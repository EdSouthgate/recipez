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
    }
}