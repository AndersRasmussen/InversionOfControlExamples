using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Netcompany.Courses.TPS.Step5;
using NUnit.Framework;

namespace Netcompany.Courses.TPS.Windsor
{
    [TestFixture]
    public class WindsorContainerTest
    {
        [Test]
        public void SamuraiSwordTest()
        {
            // Arrange
            var container = new WindsorContainer();
            container.Register(
                Component.For<IWeapon>().ImplementedBy<Sword>(),
                Component.For<Samurai>()
            );
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
            var container = new WindsorContainer();
            container.Register(
                Component.For<IWeapon>().ImplementedBy<ThrowingStar>(),
                Component.For<Samurai>()
            );
            var samurai = container.Resolve<Samurai>();

            // Act
            string result = samurai.Attack("pig");

            // Assert
            Assert.AreEqual("Sliced pig in pieces!", result);
        }
    }
}
