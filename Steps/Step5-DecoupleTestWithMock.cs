using Moq;
using NUnit.Framework;

namespace Netcompany.Courses.TPS.Step5
{
    /// <summary>
    /// Step 5 - Decouple tests
    /// 
    /// - Identify that the SamuraiTest still tests both the Samurai and the Sword
    /// - Use a mock to not couple the SamuraiTest to a concrete Weapon
    /// - Notice that we now can configure and verify behavior done on the Weapon dependency which are local to the test
    /// 
    /// Notes:
    /// - See Tests.MockVsStub for discussion about mocks and stubs
    /// - The Tests class should be splitted into seperate classes (SamuraiTests, SwordTests, etc.)
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
    }
}
