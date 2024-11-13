using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG
{
    public class Human : Creature
    {
        public override string Race
        {
            get;
            protected set;
        } = "Human";
    }
}
