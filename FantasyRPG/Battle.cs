using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FantasyRPG
{
    public class Battle
    {
        public List<String> Messages { get; private set; } = new();

        public int Duel(Creature creature1, Creature creature2) 
        {
            Messages.Clear();

            while (creature1.HitPoints > 0 && creature2.HitPoints > 0)
            {
                // Creature 1 attacks creature 2
                int damageToCreature2 = creature1.Attack(creature2);
                Messages.Add($"The {creature1.Race} deals {damageToCreature2} damage to the {creature2.Race}.");

                //// Check if creature2 is defeated
                //if (creature2.HitPoints < 1)
                //{
                //    break;
                //}

                // Creature2 attacks creature1
                int damageToCreature1 = creature2.Attack(creature1);
                Messages.Add($"The {creature2.Race} deals {damageToCreature1} damage to the {creature1.Race}.");
            }

            // Determine the result

            if (creature1.HitPoints < 1 && creature2.HitPoints < 1)
            {
                Messages.Add("The duel ends in a Tie!");
                return 0;
            }

            else if (creature1.HitPoints < 1)
            {
                Messages.Add($"{creature2.Race} wins!");
                return 2;
            }
                
            {
                Messages.Add($"{creature1.Race} wins!");
                return 1;
            
            }   
        }
    }
}
