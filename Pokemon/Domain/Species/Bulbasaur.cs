

using Pokemon.Domain;

namespace Pokemon.Domain.Species
{
    public class Bulbasaur : GrassPokemon
    {
        public Bulbasaur() : base("Bulbasaur", 1)
        {
            var vineWhip = new Attack("Vine Whip", ElementType.Grass, 7);
            var leafage = new Attack("Leafage", ElementType.Grass, 11);

            AddAttack(vineWhip);
            AddAttack(leafage);
        }

        // Valfri overload för annan startlevel
        public Bulbasaur(int level) : base("Bulbasaur", level)
        {
            var vineWhip = new Attack("Vine Whip", ElementType.Grass, 7);
            var leafage = new Attack("Leafage", ElementType.Grass, 11);

            AddAttack(vineWhip);
            AddAttack(leafage);
        }
    }
}


// OBS: I ett större spel skulle namn, typ och attacker hämtas från en databas
// eller "species registry" i stället för att hårdkodas i varje klass.
// Här hårdkodar vi för att visa arv och konstruktoranrop tydligt (kursuppgift).

