using NUnit.Framework;

namespace Netcompany.Courses.TPS.Step5
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
            return string.Format("Sliced pig in pieces!");
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void SamuraiSwordTest()
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
        public void SamuraiThrowingStarTest()
        {
            // Arrange
            var sword = new ThrowingStar();
            var samurai = new Samurai(sword);

            // Act
            string result = samurai.Attack("pig");

            // Assert
            Assert.AreEqual("Sliced pig in pieces!", result);
        }
    }
}
