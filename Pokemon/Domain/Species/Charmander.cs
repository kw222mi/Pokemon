
using Pokemon.Domain;

namespace Pokemon.Domain.Species
{
    public class Charmander : FirePokemon, IEvolvable
    {

        public Charmander() : base ("Charmander", 1) {

            var ember = new Attack("Ember", ElementType.Fire, 10);
            var flameBurst = new Attack("Flame Burst", ElementType.Fire, 7);


            AddAttack(ember);

            AddAttack(flameBurst);
            
        }

        public Charmander(int level) : base("Charmander", level)
        {

            var ember = new Attack("Ember", ElementType.Fire, 7);
            var flameBurst = new Attack("Flame Burst", ElementType.Fire, 7);


            AddAttack(ember);

            AddAttack(flameBurst);

        }

        public PokemonCreature Evolve()
        {

            if (this.Level < 10) throw new InvalidOperationException(
            $"{Name} kan inte evolva före level 10. (Nuvarande level: {Level})");

            else
                    {
                        var level = this.Level + 10;
                        return new Charmeleon(level);
                    }
        }
    }
}


// OBS: I ett större spel skulle namn, typ och attacker hämtas från en databas
// eller "species registry" i stället för att hårdkodas i varje klass.
// Här hårdkodar jag för att visa arv och konstruktoranrop tydligt (kursuppgift).

