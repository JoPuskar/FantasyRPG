

using FantasyRPGUnitTesting;

namespace FantasyRPG
{
    public class Creature
    {
        protected IRandom? _random;
        protected Damage _damage;

        public virtual string Race { get; protected set; } = "Unkown";
        public int Strength { get; set; }
        public virtual int HitPoints { get; set; }

        public Creature()
        {
            _random = new RandomGenerator();
            _damage = new();
        }

        public Creature(IRandom random, Damage damage)
        {
            _random = random;
            _damage = damage;
        }

        public virtual Damage InflictDamage()
        {
            _damage.Base = _random.Get(1, Strength);
            return _damage;

        }
        public virtual int TakeDamage(int damage)
        {
            // All creatures have a 1% chance of dodging the damage
            if (_random.Get(1, 100) < 2)
            {
                damage = 0;
            }
            HitPoints -= damage;
            return damage;
        }

        public int Attack(Creature Creature)
        {
            return Creature.TakeDamage(InflictDamage().Total);
        }
    }
}
