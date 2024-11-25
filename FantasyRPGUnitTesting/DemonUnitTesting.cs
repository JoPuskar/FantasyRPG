using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FantasyRPG;
using NSubstitute;

namespace FantasyRPGUnitTesting
{
    [Category("Unit Tests")]
    public class ADemon
    {
        [Test]
        public void ReportsItsRaceAsHuman()
        {
            Demon sut = new();
            Assert.That(sut.Race, Is.EqualTo("Demon"));
        }

        [Test]
        public void Has25PercentChanceOfInflictingAdditional10Damage()
        {
            int additional = 10;
            IRandom mockRandom = Substitute.For<IRandom>();
            mockRandom.Get(1, 30).Returns(additional); // damage
            mockRandom.Get(1, 100).Returns(25); // 25% chance
            Damage mockDamage = Substitute.For<Damage>();
            Demon sut = new(mockRandom, mockDamage)
            {
                Strength = 30
            };
            sut.InflictDamage();
            mockDamage.Received().Additional = additional;
        }

        [Test]
        public void Has75PercentChanceOfInflictingDoubleDamage()
        {
            int Base = 50;
            IRandom mockRandom = Substitute.For<IRandom>();
            mockRandom.Get(1, 75).Returns(Base); // damage
            Damage mockDamage = Substitute.For<Damage>();
            Demon sut = new(mockRandom, mockDamage)
            {
                Strength = 75
            };
            sut.InflictDamage();
            mockDamage.Received().Base = Base;
        }
    }
}
