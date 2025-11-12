using Pokemon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    internal class FirePokemon : PokemonCreature
    {

        public FirePokemon(string name, int level) : base(name, level) 
        {
            Type = ElementType.Fire;
        }
    }
}
