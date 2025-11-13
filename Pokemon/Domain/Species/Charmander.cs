

namespace Pokemon.Domain.Species
{
    public class Charmander : FirePokemon
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
    }
}


// OBS: I ett större spel skulle namn, typ och attacker hämtas från en databas
// eller "species registry" i stället för att hårdkodas i varje klass.
// Här hårdkodar vi för att visa arv och konstruktoranrop tydligt (kursuppgift).

