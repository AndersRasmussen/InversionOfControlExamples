using NUnit.Framework;

namespace Netcompany.Courses.TPS.Step3
{
    /// <summary>
    /// Step 3 - Interface Segregation Principle
    /// 
    /// - Identify that a Samurai has a concrete dependency on the Sword
    /// - Abstract the Sword into a Weapon
    /// - Change the Samurai to use the abstraction
    /// </summary>
    public class Samurai
    {
        private readonly IWeapon _weapon = new Sword();

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
