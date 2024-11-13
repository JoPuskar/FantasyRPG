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

    [Test]
    public void Has99PercentChanceOfTakingDamange()
    { 
        IRandom randomMock = Substitute.For<IRandom>();
        randomMock.Get(1, 100).Returns(89);
        Creature sut = new(randomMock)
        {
            Strength = 1,
            HitPoints = 100
        };

        int damage = 10;
        _ = sut.TakeDamage(damage);
        Assert.That(sut.HitPoints, Is.EqualTo(90));
    }
    public void Has1PercentChanceOfNotTakingDamange()
    {
        IRandom randomMock = Substitute.For<IRandom>();
        randomMock.Get(1, 100).Returns(1);
        Creature sut = new(randomMock)
        {
            Strength = 1,
            HitPoints = 100
        };

        int damage = 10;
        _ = sut.TakeDamage(damage);
        Assert.That(sut.HitPoints, Is.EqualTo(100));
    }

    [Test]
    public void CanAttackAnotherCreature()
    { 
        IRandom randonMock = Substitute.For<IRandom>();

        randonMock.Get(1, Arg.Any<int>()).Returns(1);
        Creature sut = new(randonMock)
        {
            Strength = 1,
            HitPoints = 100
        };
        Creature mockCreature = Substitute.For<Creature>();
        _  = sut.Attack(mockCreature);
        mockCreature.Received().TakeDamage(Arg.Any<int>());
    }
}