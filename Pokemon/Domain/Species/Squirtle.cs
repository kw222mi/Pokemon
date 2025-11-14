using Pokemon.Domain;

namespace Pokemon.Domain.Species
{
    /// <summary>
    /// Represents the first-stage water Pokémon Squirtle.
    /// Squirtle starts with two basic water-type attacks and can evolve into Wartortle.
    /// </summary>
    public class Squirtle : WaterPokemon, IEvolvable
    {
        /// <summary>
        /// Creates a Squirtle at level 1 with its predefined starting attacks.
        /// </summary>
        public Squirtle()
            : base("Squirtle", 1)
        {
            var waterGun = new Attack("Water Gun", ElementType.Water, 10);
            var bubble = new Attack("Bubble", ElementType.Water, 7);

            AddAttack(waterGun);
            AddAttack(bubble);
        }

        /// <summary>
        /// Creates a Squirtle at a specified level.
        /// Useful for testing or for constructing the evolved form with a chosen level.
        /// </summary>
        /// <param name="level">The initial level of the Squirtle.</param>
        public Squirtle(int level)
            : base("Squirtle", level)
        {
            var waterGun = new Attack("Water Gun", ElementType.Water, 10);
            var bubble = new Attack("Bubble", ElementType.Water, 7);

            AddAttack(waterGun);
            AddAttack(bubble);
        }

        /// <summary>
        /// Evolves Squirtle into Wartortle.
        /// Evolution requires at least level 10 and increases the level by +10.
        /// Returns a new Wartortle instance representing the evolved form.
        /// </summary>
        /// <returns>A new <see cref="Wartortle"/> instance with increased level.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if Squirtle is below the minimum level required for evolution.
        /// </exception>
        public PokemonCreature Evolve()
        {
            if (Level < 10)
                throw new InvalidOperationException(
                    $"{Name} cannot evolve before level 10. (Current level: {Level})");

            int newLevel = Level + 10;
            return new Wartortle(newLevel);
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name} speaks: Squirr squirr!");
        }
    }
}

