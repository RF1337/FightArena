using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    internal class HumanHero : Hero
    {
        // Creating a constructor and calling the base constructor because this class inherits from Hero that has a base constructor
        public HumanHero(decimal hitPoints, decimal attackPoints, decimal defencePoints, string heroName) : base(hitPoints, attackPoints, defencePoints, heroName)
        {
            //Setting hitPoints to 90 so no matter what user types when instantiating the object since all humans have 90 HP
            HitPoints = 90;
            AttackPoints = attackPoints;
            DefencePoints = defencePoints;
            HeroName = heroName;
        }
    }
}
