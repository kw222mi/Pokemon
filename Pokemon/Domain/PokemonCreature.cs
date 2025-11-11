using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pokemon.Domain
{
    public class PokemonCreature
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public PokemonCreature(string name, int level) {
            Name = name;
            Level = level;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"{Name} (Level {Level})");

        }

        public void UseSimpleAttack (string attackName, int basePower) {
            if (string.IsNullOrWhiteSpace(attackName)) { throw new ArgumentException("Attacknamn saknas. Ange minst 1 tecken."); }

            else if(basePower <= 0) { throw new ArgumentException("BasePower måste vara > 0."); }

                int damage = basePower + Level;
            Console.WriteLine($"{Name} använder {attackName} – Skada: {damage} ({basePower}+{Level})");

        }

    }

   
}
