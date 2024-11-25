using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FantasyRPG;
using FantasyRPGUnitTesting;

namespace FantasyRPGIntegrationTesting
{
    [Category("Integration Tests")]
    public class ADemon
    {
        [Test]
        public void Has25PercentChanceOfInflictingAdditional10Damage()
        {
            Demon sut = new()
            {
                Strength = 30
            };

            int MAX = 20000;
            int additional10DamageCount = 0;

            for (int i = 0; i < MAX; i++)
            {
                Damage damage = sut.InflictDamage();
                if (damage.Additional == 10)    
                {
                    additional10DamageCount++;
                }
            }

            decimal percent = additional10DamageCount / 20000m;
            Assert.That(percent, Is.EqualTo(0.25).Within(0.003));
        }

        [Test]
        public void Has75PercentChanceOfInflictingBaseDamage()
        {
            Demon sut = new()
            {
                Strength = 50
            };

            int MAX = 20000;
            int baseDamageCount = 0;

            for (int i = 0; i < MAX; i++)
            {
                Damage damage = sut.InflictDamage();
                if (damage.Additional == 0 )
                {
                    baseDamageCount++;
                }
            }

            decimal percent = baseDamageCount / 20000m;
            Assert.That(percent, Is.EqualTo(0.75).Within(0.003));
        }
    }
}
