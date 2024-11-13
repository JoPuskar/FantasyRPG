using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FantasyRPG;

namespace FantasyRPGUnitTesting
{
    [Category("Unit Testing")]
    public class AHuman
    {
        [Test]
        public void ReportsItsRaceAsHuman() 

        {
            Human sut = new();
            Assert.That(sut.Race, Is.EqualTo("Human"));

        }
    }
}
