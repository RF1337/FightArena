using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal class Hero
    {
        // Constructors
        // Creating a constructor for the Hero class
        public Hero(decimal hitPoints, decimal attackPoints, decimal defencePoints, string heroName)
        {
            HitPoints = hitPoints;
            AttackPoints = attackPoints;
            DefencePoints = defencePoints;
            HeroName = heroName;
        }

        // Properties
        // Creating getters and setters for the variables needed
        public decimal HitPoints { get; set; }
        public decimal AttackPoints { get; set; }
        public decimal DefencePoints { get; set; }
        public string HeroName { get; set; }


        // Method for attacking against opponent
        // Taking Hero as parameter so they can select a victim
        public virtual void Attack(Hero victim)
        {
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
            }
            else
            {
                Console.WriteLine("Victim is dead");
            }
        }
    }
}
