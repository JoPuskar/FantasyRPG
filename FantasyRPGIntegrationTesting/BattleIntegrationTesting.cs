using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FantasyRPG;
using FantasyRPGUnitTesting;
using NSubstitute;

namespace FantasyRPGIntegrationTesting
{
    [Category("Integration Tests")]
    public class ABattle
    {
        [Test]
        public void ReportThatCreature1WonTheDuel()
        {
            Human creature1 = new()
            {
                Strength = 10,
                HitPoints = 5,
            };


            Demon creature2 = new()
            {
                Strength = 0,
                HitPoints = 6,
            };

            Battle sut = new();

            int result = sut.Duel(creature1, creature2);

            Assert.That(result, Is.EqualTo(1));
            Assert.That(sut.Messages, Contains.Item("Human wins!"));
            
        }

        [Test]
        public void ReportThatCreature2WonTheDuel()
        {
            Human creature1 = new()
            {
                Strength = 1,
                HitPoints = 5,
            };


            Demon creature2 = new()
            {
                Strength = 8,
                HitPoints = 6,
            };

            Battle sut = new();

            int result = sut.Duel(creature1, creature2);

            Assert.That(result, Is.EqualTo(2));
            Assert.That(sut.Messages, Contains.Item("Demon wins!"));

        }

        [Test]
        public void ReportThatTheDuelEndsInATie()
        {
            Creature creature1 = new()
            {
                Strength = 1,
                HitPoints = 3,
            };


            Creature creature2 = new()
            {
                Strength = 1,
                HitPoints = 3,
            };

            Battle sut = new();

            int result = sut.Duel(creature1, creature2);

            Assert.That(result, Is.EqualTo(0));
            Assert.That(sut.Messages, Contains.Item("The duel ends in a Tie!"));

        }

        [Test]
        public void ReportTheDuelsMessages()
        {
            // Mock the random generator to control the damage output
            //IRandom mockRandom = Substitute.For<IRandom>();
            //Damage mockDamage = Substitute.For<Damage>();

          //  mockRandom.Get(1, Arg.Any<int>()).Returns(10);

            Creature creature1 = new()
            {
                Strength = 1,
                HitPoints = 3,
            };


            Creature creature2 = new()
            {
                Strength = 1,
                HitPoints = 3,
            };

            Battle sut = new();

            sut.Duel(creature1, creature2);

            Assert.That(sut.Messages, Has.Count.EqualTo(7));



        }

    }
}
