using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FantasyRPG;
using FantasyRPGIntegrationTesting;
using NSubstitute;

namespace FantasyRPGUnitTesting
{
    [Category("Unit Tests")]
    public class ABalrog
    {
        [Test]
        public void ReportsItsRaceAsBalrog() 
        {
            Balrog sut = new();
            Assert.That(sut.Race, Is.EqualTo("Balrog"));
        }

        [Test]
        public void CanInflictBaseDamageTwice()
        {

            int baseDamage = 25;
            IRandom mockRandom = Substitute.For<IRandom>();
            mockRandom.Get(1, 30).Returns(baseDamage); // damage
            mockRandom.Get(1, 100).Returns(10);
            Damage mockDamage = Substitute.For<Damage>();
            Balrog sut = new(mockRandom, mockDamage)
            {
                Strength = 30
            };
            sut.InflictDamage();
            mockDamage.Received().Base = baseDamage; // check if the base damage is correct
            mockDamage.Received().Additional = 10 + baseDamage;  // the additional damage should match the base damage
        }
    }
}
