using Netcompany.Courses.TPS.Step6;
using NUnit.Framework;

namespace Netcompany.Courses.TPS.Homemade
{
    [TestFixture]
    public class HomemadeContainerTest
    {
        [Test]
        public void SamuraiSwordTest()
        {
            // Arrange
            var container = new HomemadeContainer();
            container.Register<IWeapon, Sword>();
            container.Register<Samurai>();
            var samurai = container.Resolve<Samurai>();

            // Act
            string result = samurai.Attack("pig");

            // Assert
            Assert.AreEqual("Chopped pig in half!", result);
        }

        [Test]
        public void SamuraiThrowingStarTest()
        {
            // Arrange
            var container = new HomemadeContainer();
            container.Register<IWeapon, ThrowingStar>();
            container.Register<Samurai>();
            var samurai = container.Resolve<Samurai>();

            // Act
            string result = samurai.Attack("pig");

            // Assert
            Assert.AreEqual("Sliced pig in pieces!", result);
        }
    }
}