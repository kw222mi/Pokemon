using Pokemon.Domain;

namespace Pokemon.Domain.Species
{
    /// <summary>
    /// Represents the first-stage fire Pokémon Charmander.
    /// Charmander starts with basic fire-type moves and can evolve into Charmeleon.
    /// </summary>
    public class Charmander : FirePokemon, IEvolvable
    {
        /// <summary>
        /// Creates a Charmander at level 1 with its predefined starting attacks.
        /// </summary>
        public Charmander()
            : base("Charmander", 1)
        {
            var ember = new Attack("Ember", ElementType.Fire, 10);
            var flameBurst = new Attack("Flame Burst", ElementType.Fire, 7);

            AddAttack(ember);
            AddAttack(flameBurst);
        }

        /// <summary>
        /// Creates a Charmander at a specific level.
        /// Useful for evolution or testing higher-level scenarios.
        /// </summary>
        /// <param name="level">The initial level of the Charmander.</param>
        public Charmander(int level)
            : base("Charmander", level)
        {
            var ember = new Attack("Ember", ElementType.Fire, 10);
            var flameBurst = new Attack("Flame Burst", ElementType.Fire, 7);

            AddAttack(ember);
            AddAttack(flameBurst);
        }

        /// <summary>
        /// Evolves Charmander into Charmeleon.
        /// Evolution requires at least level 10 and increases the level by +10.
        /// Returns a new instance of Charmeleon representing the evolved form.
        /// </summary>
        /// <returns>A new <see cref="Charmeleon"/> instance with increased level.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if Charmander is below the required level to evolve.
        /// </exception>
        public PokemonCreature Evolve()
        {
            if (Level < 10)
                throw new InvalidOperationException(
                    $"{Name} cannot evolve before level 10. (Current level: {Level})");

            int newLevel = Level + 10;
            return new Charmeleon(newLevel);
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name } speaks: Char! Char!");
        }
    }
}


