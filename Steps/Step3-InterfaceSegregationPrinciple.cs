using NUnit.Framework;

/// <summary>
/// Step 3 - Interface Segregation Principle
/// 
/// - Identify that a Samurai has a concrete dependency on the Sword
/// - Abstract the Sword into a Weapon
/// - Change the Samurai to use the abstraction
/// </summary>
namespace Netcompany.Courses.TPS.Step3
{
    public class Samurai
    {
        private IWeapon _weapon = new Sword();

        public string Attack(string target)
        {
            return _weapon.Hit(target);
        }
    }

    public interface IWeapon
    {
        string Hit(string target);
    }

    public class Sword : IWeapon
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
