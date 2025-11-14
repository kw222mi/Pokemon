using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain
{
    internal class LegendaryAttack : Attack
    {

        public LegendaryAttack  (Attack baseAttack) : base ($"Legendary {baseAttack.Name} ", baseAttack.Type, baseAttack.BasePower)
        {

        }

        public override void Use(int attackerLevel)
        {
            if (attackerLevel < 1)
                throw new ArgumentOutOfRangeException(nameof(attackerLevel), "Level måste vara ≥ 1.");

            int damage = BasePower + attackerLevel *2;

            Console.WriteLine($"{Name} unleashes its true potential damage {damage}");
        }
    }
}
