using FantasyRPGUnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG
{
    public class Balrog: Demon 
    {
        public Balrog(): base() { }

        public Balrog(IRandom random, Damage damage): base(random, damage) { }

        public override string Race
        {
            get;
            protected set;
        } = "Balrog";

        public override Damage InflictDamage()
        {
            _ = base.InflictDamage();

            // A Balrog can inflict base damage twice

            _damage.Additional += _damage.Base;
            return _damage;
        }

    }
}
