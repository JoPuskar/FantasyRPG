using FantasyRPG;
using NSubstitute;

namespace FantasyRPGUnitTesting;

[Category("Unit Tests")]
public class ACreature {


    [Test]
    public void ReportsItsRaceAsUnkown()
    {
        Creature sut = new();
        string race = sut.Race;
        Assert.That(race, Is.EqualTo("Unkown"));
    }

    [Test]
    public void CanInflictABaseDamage()
    {
        IRandom random = Substitute.For<IRandom>();
        random.Get(1, 30).Returns(25);
        Creature sut = new(random)
        {
            Strength = 30
        };
        int baseDamage = sut.InflictDamage();
        Assert.That(baseDamage, Is.EqualTo(25));
    }
}