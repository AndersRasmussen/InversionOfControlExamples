using NUnit.Framework;

namespace Netcompany.Courses.TPS.Step1
{
    public class Samurai
    {
        public string Attack(string target)
        {
            return string.Format("Chopped {0} in half!", target);
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void SamuraiTest()
        {
            // Arrange
            var samurai = new Samurai();

            // Act
            string result = samurai.Attack("pig");

            // Assert
            Assert.AreEqual("Chopped pig in half!", result);
        }
    }
}
