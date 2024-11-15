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
        IRandom mockRandom = Substitute.For<IRandom>();
        mockRandom.Get(1, 30).Returns(25);
        Damage mockDamage = Substitute.For<Damage>();
        Creature sut = new(mockRandom, mockDamage)
        {
            Strength = 30
        };
        int baseDamage = sut.InflictDamage().Base;
        Assert.That(baseDamage, Is.EqualTo(25));
    }

    [Test]
    public void Has99PercentChanceOfTakingDamange()
    { 
        IRandom randomMock = Substitute.For<IRandom>();
        Damage mockDamage = Substitute.For<Damage>();
        randomMock.Get(1, 100).Returns(89);
        Creature sut = new(randomMock, mockDamage)
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
        Damage mockDamage = Substitute.For<Damage>();
        randomMock.Get(1, 100).Returns(1);
        Creature sut = new(randomMock, mockDamage)
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
        Damage mockDamage = Substitute.For<Damage>();
        randonMock.Get(1, Arg.Any<int>()).Returns(1);
        Creature sut = new(randonMock, mockDamage)
        {
            Strength = 1,
            HitPoints = 100
        };
        Creature mockCreature = Substitute.For<Creature>();
        _  = sut.Attack(mockCreature);
        mockCreature.Received().TakeDamage(Arg.Any<int>());
    }
}