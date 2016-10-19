using Moq;
using NUnit.Framework;

/// <summary>
/// Step 6
/// 
/// - Easily add new weapons and test the functionality in isolation
/// </summary>
namespace Netcompany.Courses.TPS.Step6
{
    public class Samurai
    {
        private IWeapon _weapon;

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
            return string.Format("Chopped {0} in half!", target);
        }
    }

    public class ThrowingStar : IWeapon
    {
        public string Hit(string target)
        {
            return string.Format("Sliced {0} in pieces!", target);
        }
    }

    public class SmokeBomb : IWeapon
    {
        public string Hit(string target)
        {
            return string.Format("Disabled {0} temporary!", target);
        }
    }

    public class PoisonedDart : IWeapon
    {
        public string Hit(string target)
        {
            return string.Format("Kills {0} instantly!", target);
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void SamuraiTest()
        {
            // Arrange
            var weaponMock = new Mock<IWeapon>(MockBehavior.Strict);
            weaponMock.Setup(x => x.Hit("an object")).Returns("Done something on an object");
            var weapon = weaponMock.Object;
            var samurai = new Samurai(weapon);

            // Act
            string result = samurai.Attack("an object");

            // Assert
            Assert.AreEqual("Done something on an object", result);
            weaponMock.Verify(x => x.Hit("an object"), Times.Once);
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

        [Test]
        public void ThrowingStarTest()
        {
            // Arrange
            var throwingStar = new ThrowingStar();

            // Act
            var result = throwingStar.Hit("pig");

            // Assert
            Assert.AreEqual("Sliced pig in pieces!", result);
        }

        [Test]
        public void SmokeBombTest()
        {
            // Arrange
            var smokeBomb = new SmokeBomb();

            // Act
            string result = smokeBomb.Hit("pig");

            // Assert
            Assert.AreEqual("Disabled pig temporary!", result);
        }

        [Test]
        public void PoisonedDartTest()
        {
            // Arrange
            var poisonedDart = new PoisonedDart();

            // Act
            string result = poisonedDart.Hit("pig");

            // Assert
            Assert.AreEqual("Kills pig instantly!", result);
        }
    }
}
