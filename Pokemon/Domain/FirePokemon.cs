using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain
{
    public class FirePokemon : PokemonCreature
    {

        public FirePokemon(string name, int level) : base(name, level) 
        {
            Type = ElementType.Fire;
        }
    }
}
