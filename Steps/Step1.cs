using NUnit.Framework;

namespace Netcompany.Courses.TPS.Step1
{
    /// <summary>
    /// Step 1
    /// 
    /// Initial example
    /// </summary>
    public class Samurai
    {
        public string Attack(string target)
        {
            return $"Chopped {target} in half!";
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
