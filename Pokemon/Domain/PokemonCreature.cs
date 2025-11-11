using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine($"{Name} {Level}");
        }
    }

   
}
