using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Weekend_01
{
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

    class War
    {
        public class Kata
        {
            public static string DeclareWinner(Fighter fighter1, Fighter fighter2, string firstAttacker)
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
}
