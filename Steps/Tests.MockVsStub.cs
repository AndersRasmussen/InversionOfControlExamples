using Moq;
using Netcompany.Courses.TPS.Step4;
using NUnit.Framework;

namespace Netcompany.Courses.TPS.Steps.MockVsStub
{
    /// <summary>
    /// Mocks vs Stubs
    /// 
    /// - Mocks have dependency configuration specificed more local to the test
    /// - Stubs are easier shared, but can be hard to maintain when mutiple tests uses the same stub
    /// - Mocks support verification of called methods/properties
    /// </summary>
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SamuraiTestUsingMock()
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
        public void SamuraiTestUsingStub()
        {
            // Arrange
            var weapon = new WeaponStub();
            var samurai = new Samurai(weapon);

            // Act
            string result = samurai.Attack("an object");

            // Assert
            Assert.AreEqual("Done something on an object", result);
        }

        private class WeaponStub : IWeapon
        {
            public string Hit(string target)
            {
                return $"Done something on {target}";
            }
        }
    }
}
