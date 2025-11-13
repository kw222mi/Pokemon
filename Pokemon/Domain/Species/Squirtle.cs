
using Pokemon.Domain;

namespace Pokemon.Domain.Species
{
    public class Squirtle : WaterPokemon
    {
        public Squirtle() : base("Squirtle", 1)
        {
            var waterGun = new Attack("Water Gun", ElementType.Water, 10);
            var bubble = new Attack("Bubble", ElementType.Water, 7);

            AddAttack(waterGun);
            AddAttack(bubble);
        }

        // Valfri overload för annan startlevel
        public Squirtle(int level) : base("Squirtle", level)
        {
            var waterGun = new Attack("Water Gun", ElementType.Water, 10);
            var bubble = new Attack("Bubble", ElementType.Water, 7);

            AddAttack(waterGun);
            AddAttack(bubble);
        }
    }
}



// OBS: I ett större spel skulle namn, typ och attacker hämtas från en databas
// eller "species registry" i stället för att hårdkodas i varje klass.
// Här hårdkodar jag för att visa arv och konstruktoranrop tydligt (kursuppgift).
