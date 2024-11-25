using FantasyRPG;
using FantasyRPGIntegrationTesting;
using FantasyRPGUnitTesting;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NSubstitute;

namespace FantasyRPGConsole
{
    public class Program
    {
        static void Main(string[] args)
        {

            int humanWins = 0;
            int balrogWins = 0;
            int ties = 0;

            // Initialize random generator and creatures

            //IRandom random = new RandomGenerator();

            Human human = new Human()
            {
                Strength = 50,
                HitPoints = 100
            };

            Balrog balrog = new Balrog()
            {
                Strength = 50,
                HitPoints = 100
            };

            // Creating the battle instance

            Battle battle = new Battle();

            // Repeat the duel 100 times

            for (int i = 0; i < 100; i++)
            {
                // Resetting hitpoints after each fresh duel

                human.HitPoints = 100;
                balrog.HitPoints = 100;

                int result = battle.Duel(human, balrog);
               
//                int damageToBalrog = human.Attack(balrog);
//              int damageToHuman = balrog.Attack(human);

                // Count the result
                if (result == 1) humanWins++;
                else if (result == 2) balrogWins++;
                else ties++;

                // Output message for each attack in this duel

                foreach (string message in battle.Messages)
                {
                    Console.WriteLine(message);
                }

//                Console.WriteLine($"Duel {i + 1} result: {battle.Messages[battle.Messages.Count - 1]}");
            }

            // Report the number of times human wins, Balrog wins, and the number of ties.

            Console.WriteLine($"\nResults after 100 duels:");
            Console.WriteLine($"\nHuman wins: {humanWins}");
            Console.WriteLine($"\nBalrog wins: {balrogWins}");
            Console.WriteLine($"\nTies: {ties}");

        }
    }
}
