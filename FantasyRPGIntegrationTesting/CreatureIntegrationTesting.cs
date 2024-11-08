using FantasyRPG;
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
            for (int i = 0; i < 10; i++) {
                var actual = sut.InflictDamage();
                Assert.That(actual, Is.InRange(1, 30));
            }
        }
    }
}
