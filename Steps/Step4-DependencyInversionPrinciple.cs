using NUnit.Framework;

namespace Netcompany.Courses.TPS.Step4
{
    /// <summary>
    /// Step 4 - Dependency Inversion Principle
    /// 
    /// - Identify that the Samurai still has a hard dependency on a Sword despite the Weapon abstraction
    /// - Remove the responsibility of new'ing the Sword dependency from the Samurai and make it injectable from the constructor
    /// </summary>
    public class Samurai
    {
        private readonly IWeapon _weapon;

        public Samurai(IWeapon weapon)
        {
            _weapon = weapon;
        }

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
            var sword = new Sword();
            var samurai = new Samurai(sword);

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
