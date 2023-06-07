using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal class SwitchAttackHero : Hero
    {
        // Making a variable for the 2 attacks the Hero has
        // They are used for setting the AttackPoints to the specific attack method's damage
        private decimal AttackX { get; }
        private decimal AttackY { get; }

        // Making a variable named attackMethodTurn to keep track of how many times the attackMethod has been used
        private decimal attackMethodTurn;

        public SwitchAttackHero(decimal hitPoints, decimal attackPoints ,decimal attackX, decimal attackY, decimal defencePoints, string heroName) : base(hitPoints, attackPoints, defencePoints, heroName)
        {
            AttackPoints = attackPoints;
            HitPoints = hitPoints;
            AttackX = attackX;
            AttackY = attackY;
            DefencePoints = defencePoints;
            HeroName = heroName;
        }

        // Method for attacking against opponent
        // Taking Hero as parameter so they can select a victim
        public override void Attack(Hero victim)
        {
            // If the attackMethodTurn is divisible by 2 (that means it is 0, 2, 4 etc.)
            // Then it sets the AttackPoints to AttackX
            if (attackMethodTurn % 2 == 0)
            {
                AttackPoints = AttackX;
            }

            // And if it isn't divisible by 2 then that means it's 1, 3, 5 etc. which will then set the AttackPoints to AttackY
            else
            {
                AttackPoints = AttackY;
            }

            if (victim.HitPoints > 0)
            {
                // If the attack points - the defence points of the victim is more than 0 (meaning that they do more damage
                // than the victim can defend) then it runs the code below
                if ((AttackPoints - victim.DefencePoints) > 0)
                {
                    // The code below then sets the victim's hitpoints to be subtracted by the attackpoints - the amount they blocked
                    // Since it would otherwise just attack with the full attack without considering the amount it blocked
                    victim.HitPoints -= (AttackPoints - victim.DefencePoints);

                    // Then it prints how much damage the attacker did to the victim and what their current HP is
                    Console.WriteLine($"{HeroName} is attacking and did {AttackPoints - victim.DefencePoints} damage to " +
                    $"{victim.HeroName}, {victim.HeroName} now has {victim.HitPoints} HP");
                }
                else if (AttackPoints - victim.DefencePoints <= 0)
                {
                    // If the code above didn't run, that means the defence points was more than, or equal to the attack points.
                    // Which would result in not taking any damage.
                    Console.WriteLine($"{HeroName} did not have enough attack points to deal damage");
                }
                attackMethodTurn++;
            }
            else
            // If the victim's HP is not over 0 then that means they're dead, and therefor it will
            // print this message to the console
            {
                Console.WriteLine("Victim is dead");
            }
        }
    }
}
