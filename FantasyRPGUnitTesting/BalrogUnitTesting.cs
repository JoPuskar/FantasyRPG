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

            IRandom mockRandom = Substitute.For<IRandom>();
            mockRandom.Get(1, Arg.Any<int>()).Returns(20);
            Damage mockDamage = Substitute.For<Damage>();

            int baseDamageTwice = 40;
            Balrog sut = new(mockRandom, mockDamage)
            {
                Strength = 50
            };

            sut.InflictDamage();
            mockDamage.Received().Base = baseDamageTwice;
        }
    }
}
