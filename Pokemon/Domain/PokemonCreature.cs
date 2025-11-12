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
            // --- Validering ---
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Namn saknas. Ange 2–15 tecken.", nameof(name));

            name = name.Trim();
            if (name.Length < 2 || name.Length > 15)
                throw new ArgumentOutOfRangeException(nameof(name), "Ogiltigt namn. Längd måste vara 2–15 tecken.");

            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level), "Ogiltig level. Level måste vara ≥ 1.");

            // --- Sättning ---
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

        public void RaiseLevel(int delta)
        {
            if (delta <= 0)
                throw new ArgumentException("Level-ökning måste vara > 0.", nameof(delta));

            int newLevel = checked(Level + delta);
            if (newLevel < 1)
                throw new ArgumentOutOfRangeException(nameof(delta), "Ogiltig level efter ökning.");

            Level = newLevel;
        }

    }

   
}
