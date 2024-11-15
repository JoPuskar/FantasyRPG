using FantasyRPG;
using FantasyRPGUnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPGIntegrationTesting
{
    [Category("Integration Tests")]
    public class AHuman
    {
        [Test]
        public void Has10PercentChanceOfInflictingDoubleDamage()
        {
            Human sut = new()
            {
                Strength = 30
            };

            int doubleDamageCount = 0;

            for (int i = 0; i < 20000; i++)
            {
                Damage damage = sut.InflictDamage();
                if (damage.Total == damage.Base * 2)
                { 
                    doubleDamageCount++;
                }

            }
            decimal percent = doubleDamageCount / 20000m;
            Assert.That(percent, Is.EqualTo(0.1).Within(0.003));
        }
    }
}
