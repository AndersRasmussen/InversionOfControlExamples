using NUnit.Framework;

/// <summary>
/// Step 2 - Seperation of Concerns
/// 
/// - Identify that it isn't the Samurai which chops thing in half, it is the a Sword
/// - Seperate the responsibilities up into two classes
/// - Adds a new SwordTest which tests the sword in isolation
/// </summary>
namespace Netcompany.Courses.TPS.Step2
{
    public class Samurai
    {
        public string Attack(string target)
        {
            var sword = new Sword();
            return sword.Hit(target);
        }
    }

    public class Sword
    {
        public string Hit(string target)
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

        [Test]
        public void SwordTest()
        {
            // Arrange
            var sword = new Sword();

            // Act
            var result = sword.Hit("pig");

            // Assert
            Assert.AreEqual("Chopped pig in half!", result);
        }
    }
}
