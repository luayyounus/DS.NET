using System;

namespace CodeChallenges
{
    // Kata on Code Wars https://www.codewars.com/kata/two-fighters-one-winner 
    public class Fighter
    {
        public string Name;
        public int Health, DamagePerAttack;
        public Fighter(string name, int health, int damagePerAttack)
        {
            this.Name = name;
            this.Health = health;
            this.DamagePerAttack = damagePerAttack;
        }
    }

    public class DeclareWinner
    {
        private static void Main(string[] args)
        {
            Fighter fighterOne = new Fighter("Luay", 10, 4);
            Fighter fighterTwo = new Fighter("Csharp", 10, 2);
            string resultWinner = CheckWinner(fighterOne, fighterTwo, "Luay");
            Console.WriteLine("The winner is {0}", resultWinner);
            Console.ReadLine();
        }
        public static string CheckWinner(Fighter fighter1, Fighter fighter2, string firstAttacker)
        {
            string currentAttacker = firstAttacker;
            while (fighter1.Health > 0 && fighter2.Health > 0)
            {
                if (currentAttacker == fighter1.Name)
                    fighter2.Health -= fighter1.DamagePerAttack;
                else
                    fighter1.Health -= fighter2.DamagePerAttack;

                currentAttacker = (currentAttacker == fighter2.Name) ? fighter1.Name : fighter2.Name;
            }
            return (fighter1.Health <= 0) ? fighter2.Name : fighter1.Name;
        }
    }
}
