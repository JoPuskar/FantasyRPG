
namespace FantasyRPG
{
    public class Creature
    {
        private IRandom? _random = null;

        public virtual string Race { get; protected set; } = "Unkown";
        public int Strength { get; set; }

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
    }
}
