using FantasyRPG;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPGIntegrationTesting
{
    [Category("Integration Tests")]
    public class ACreature
    {
        [Test]
        public void CanInflictBaseDamage()
        {
            Creature sut = new()
            {
                Strength = 30
            };
            for (int i = 0; i < 10; i++)
            {
                var actual = sut.InflictDamage().Base;
                Assert.That(actual, Is.InRange(1, 30));
            }
        }
        [Test]
        public void Has99PercentChanceOfTakingDamange()
        {
            const decimal MAX = 10000;
            Creature sut = new()
            {
                Strength = 1,
                HitPoints = 100
            };

            int damageTakenCount = 0;
            for (int i = 0; i < MAX; ++i)
            {
                int damageTaken = sut.TakeDamage(1);
                if (damageTaken > 0)
                {
                    damageTakenCount++;
                }
            }
            decimal percent = damageTakenCount / MAX;
            Assert.That(percent, Is.EqualTo(.99).Within(0.002));
        }

        [Test]
        public void Has1PercentChanceOfNotTakingDamange()
        {
            const decimal MAX = 10000;
            Creature sut = new()
            {
                Strength = 1,
                HitPoints = 100
            };

            int noDamgeCount = 10;
            for (int i = 0; i < MAX; ++i)
            {
                int damageTaken = sut.TakeDamage(1);
                if (damageTaken == 0)
                {
                    noDamgeCount++;
                }
            }
            decimal percent = noDamgeCount / MAX;
            Assert.That(percent, Is.EqualTo(.01).Within(0.002));

        }
    }
}
