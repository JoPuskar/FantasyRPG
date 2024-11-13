

namespace FantasyRPG
{
    public class Creature
    {
        private IRandom? _random = null;

        public virtual string Race { get; protected set; } = "Unkown";
        public int Strength { get; set; }
        public virtual int HitPoints { get; set; }

        public Creature()
        {
            _random = new RandomGenerator();
        }

        public Creature(IRandom random)
        {
            _random = random;
        }

        public virtual int InflictDamage()
        {
            return _random!.Get(1, Strength);

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

        public object Attack(Creature Creature)
        {
            return Creature.TakeDamage(InflictDamage());
        }
    }
}
